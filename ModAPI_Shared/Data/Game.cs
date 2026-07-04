/*  
 *  ModAPI
 *  Copyright (C) 2015 FluffyFish / Philipp Mohrenstecher
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *  
 *  To contact me you can e-mail me at info@fluffyfish.de
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Xml.Linq;
using ModAPI.Configurations;
using ModAPI.Utils;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Path = ModAPI.Utils.Path;

namespace ModAPI.Data
{
    public class Game
    {
        public static readonly string[] VersionUpdateDomains =
        {
            // GitHub — 직접 관리하는 최신 Versions.xml (우선순위 1)
            "https://raw.githubusercontent.com/FluffyFishGames/ModAPI/master/ModAPI/configs/games/{0}/Versions.xml",
            // 기존 서버 — 폴백 (우선순위 2)
            "http://modapi.survivetheforest.net/app/configs/games/{0}/Versions.xml",
            //"http://modapi.cc/app/configs/games/{0}/Versions.xml", Outdated
        };

        public event EventHandler<EventArgs> OnModlibUpdate;

        public Configuration.GameConfiguration GameConfiguration;
        public List<Mod> Mods = new List<Mod>();
        public string GamePath = "";
        public bool Valid;
        public ModLib ModLibrary;

        protected bool RegenerateModLibrary;
        protected Dictionary<string, Mod> FileNameToMod = new Dictionary<string, Mod>();
        protected Versions VersionsData;
        protected string CheckSumBackup;
        protected string CheckSumGame;
        protected string CheckSumModded;

        public Versions.Version BackupVersion;
        public Versions.Version GameVersion;

        public Game(Configuration.GameConfiguration gameConfiguration)
        {
            GameConfiguration = gameConfiguration;
            ModLibrary = new ModLib(this);
            GamePath = Configuration.GetPath("Games." + gameConfiguration.Id);
            Verify();
        }

        /// <summary>
        /// 경량 생성자 — Verify() 없이 GameConfiguration과 GamePath만 설정
        /// </summary>
        public Game(Configuration.GameConfiguration gameConfiguration, bool lightweightOnly)
        {
            GameConfiguration = gameConfiguration;
            GamePath = Configuration.GetPath("Games." + gameConfiguration.Id);
            ModLibrary = new ModLib(this);
        }

        protected void GamePathSpecified()
        {
            Configuration.SetPath("Games." + GameConfiguration.Id, GamePath, true);
            Configuration.Save();
            Verify();
        }

        public void Verify()
        {
            Debug.Log("Game: " + this.GameConfiguration.Id, "Modified by: SiXxKilLuR ", Debug.Type.Notice, detailedOnly: true);
            Valid = true;

            // Developer mode bypass: skip game path validation when --dev argument is passed
            var args = System.Environment.GetCommandLineArgs();
            foreach (var arg in args)
            {
                if (arg.Equals("--dev", System.StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Log("Game: " + this.GameConfiguration.Id, "Developer mode active - skipping game path validation.", Debug.Type.Notice);
                    return;
                }
            }

            /** Some files are missing. Try auto-detection. If not found, user sets path in Settings tab. **/
            if (!CheckGamePath())
            {
                GamePath = FindGamePath();
                if (!CheckGamePath())
                {
                    Valid = false;
                    return;
                }
            }

            Configuration.SetPath("Games." + GameConfiguration.Id, GamePath, true);

            if (VersionsData == null)
            {
                VersionsData = new Versions(this);
            }
            VersionsData.Refresh();

            GenerateCheckSums();

            GameVersion = VersionsData.GetVersion(CheckSumGame);
            BackupVersion = VersionsData.GetVersion(CheckSumBackup);
            Debug.Log("Game: " + this.GameConfiguration.Id, "Checksum: " + this.CheckSumGame, Debug.Type.Notice, detailedOnly: true);

            if (((GameVersion.IsValid && !BackupVersion.IsValid) || (GameVersion.IsValid && BackupVersion.IsValid && GameVersion.Id != BackupVersion.Id)))
            {
                BackupGameFiles();
                Thread.Sleep(1000);
                GenerateCheckSums();
                GameVersion = VersionsData.GetVersion(CheckSumGame);
                BackupVersion = VersionsData.GetVersion(CheckSumBackup);
                RegenerateModLibrary = true;
            }

            if ((CheckSumGame != CheckSumBackup && CheckSumGame != CheckSumModded) || (!GameVersion.IsValid && CheckSumModded != "" && CheckSumModded != CheckSumGame))
            {
                // Versions.xml에 현재 버전이 없으면 자동 등록
                if (VersionsData.VersionsList.Count == 0 || VersionsData.VersionsList.All(o => o.CheckSum != CheckSumGame))
                {
                    Debug.Log("Game: " + GameConfiguration.Id, "Auto registering game version with checksum: " + CheckSumGame);
                    VersionsData.VersionsList.Add(new Versions.Version(CheckSumGame));

                    BackupGameFiles();
                    Thread.Sleep(1000);
                    GenerateCheckSums();
                    GameVersion = VersionsData.GetVersion(CheckSumGame);
                    BackupVersion = VersionsData.GetVersion(CheckSumBackup);
                    RegenerateModLibrary = true;
                }
                else
                {
                    Debug.Log("Game: " + GameConfiguration.Id, "Neither the game and modded checksum nor the game and backup checksum did match. Game checksum: " + CheckSumGame);
                    Schedule.AddTask("GUI", "RestoreGameFiles", Verify, new object[] { this });
                    Valid = false;
                    RegenerateModLibrary = true;
                    return;
                }
            }

            if (!ModLibrary.Exists || ModLibrary.ModApiVersion != Version.Descriptor)
            {
                RegenerateModLibrary = true;
                Schedule.AddTask("SelectNewestModVersions", delegate { });
            }

            if (RegenerateModLibrary)
            {
                CreateModLibrary(true);
            }
        }

        public void CreateModLibrary(bool autoClose = false)
        {
            var progressHandler = new ProgressHandler();
            Schedule.AddTask("GUI", "OperationPending", null, new object[] { "CreatingModLibrary", progressHandler, null, autoClose });
            var t = new Thread(delegate ()
            {
                ModLibrary.Create(progressHandler);
                OnModlibUpdate?.Invoke(this, new EventArgs());
            });
            t.Start();
        }

        public string FindGamePath()
        {
            var prevGamePath = GamePath;
            foreach (var searchPath in GameConfiguration.SearchPaths)
            {
                var p = Path.Parse(searchPath, new string[0]);
                GamePath = p;
                if (CheckGamePath())
                {
                    return p;
                }
            }
            return prevGamePath;
        }

        public string GetGameFolder()
        {
            if (File.Exists(GamePath) || Directory.Exists(GamePath))
            {
                var gameFolder = GamePath;
                if ((File.GetAttributes(GamePath) & FileAttributes.Directory) != FileAttributes.Directory)
                {
                    gameFolder = System.IO.Path.GetDirectoryName(gameFolder);
                }
                return gameFolder;
            }
            return "";
        }

        protected void BackupGameFiles()
        {
            var progressHandler = new ProgressHandler
            {
                Task = "CreatingBackup"
            };
            Schedule.AddTask("GUI", "OperationPending", null, new object[] { "BackupGameFiles", progressHandler, null, true });

            var t = new Thread(delegate ()
            {
                var gameFolder = GetGameFolder();
                if (string.IsNullOrEmpty(gameFolder)) return;
                foreach (var n in GameConfiguration.IncludeAssemblies)
                {
                    var path = System.IO.Path.GetFullPath(gameFolder + System.IO.Path.DirectorySeparatorChar + ParsePath(n));
                    var backupPath = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                                                System.IO.Path.DirectorySeparatorChar + ParsePath(n));
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(backupPath));
                    File.Copy(path, backupPath, true);
                }
                foreach (var n in GameConfiguration.CopyAssemblies)
                {
                    var path = System.IO.Path.GetFullPath(gameFolder + System.IO.Path.DirectorySeparatorChar + ParsePath(n));
                    var backupPath = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                                                System.IO.Path.DirectorySeparatorChar + ParsePath(n));
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(backupPath));
                    File.Copy(path, backupPath, true);
                }
                progressHandler.Progress = 100f;
            });
            t.Start();
        }

        protected void GenerateCheckSums()
        {
            CheckSumBackup = "";
            CheckSumGame = "";
            CheckSumModded = "";
            var gameFolder = GetGameFolder();
            if (string.IsNullOrEmpty(gameFolder)) return;
            var digester = MD5.Create();
            foreach (var p in VersionsData.CheckFiles)
            {
                var gamePath = System.IO.Path.GetFullPath(gameFolder + System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                var backupPath = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                                            System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                var moddedPath = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                                            System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                if (File.Exists(gamePath))
                {
                    CheckSumGame += BitConverter.ToString(digester.ComputeHash(File.ReadAllBytes(gamePath)));
                }
                if (File.Exists(backupPath))
                {
                    CheckSumBackup += BitConverter.ToString(digester.ComputeHash(File.ReadAllBytes(backupPath)));
                }
                if (File.Exists(moddedPath))
                {
                    CheckSumModded += BitConverter.ToString(digester.ComputeHash(File.ReadAllBytes(moddedPath)));
                }
            }
            if (CheckSumBackup.Length != CheckSumGame.Length)
            {
                CheckSumBackup = "";
            }
            if (CheckSumModded.Length != CheckSumGame.Length)
            {
                CheckSumModded = "";
            }

            CheckSumGame = CheckSumGame.Replace("-", "");
            CheckSumModded = CheckSumModded.Replace("-", "");
            CheckSumBackup = CheckSumBackup.Replace("-", "");
        }

        public bool CheckGamePath()
        {
            var gameFolder = GetGameFolder();
            if (string.IsNullOrEmpty(gameFolder)) return false;
            // IncludeAssemblies만 확인 — 게임 설치 여부 판단 기준
            // CopyAssemblies는 복사 대상일 뿐, 없어도 게임 설치 자체는 유효
            foreach (var n in GameConfiguration.IncludeAssemblies)
            {
                var path = System.IO.Path.GetFullPath(gameFolder + System.IO.Path.DirectorySeparatorChar + ParsePath(n));
#if DEBUG
                // 디버그: File.Exists만 확인 (더미 파일 허용)
                if (!File.Exists(path))
                {
                    Debug.Log("Required file \"" + path + "\" couldn't be found.", Debug.Type.Warning);
                    return false;
                }
#else
                // 릴리즈: PE 헤더 + .NET 메타데이터 검증
                if (!ModAPI.Utils.FileValidator.IsValidAssemblyDll(path))
                {
                    Debug.Log("Required assembly validation failed: \"" + path + "\"", Debug.Type.Warning);
                    return false;
                }
#endif
            }
            return true;
        }

        public string[] GetIncludedAssemblies()
        {
            var gameFolder = GetGameFolder();
            if (string.IsNullOrEmpty(gameFolder)) return new string[0];
            var ret = new string[GameConfiguration.IncludeAssemblies.Count];
            for (var i = 0; i < GameConfiguration.IncludeAssemblies.Count; i++)
            {
                var n = GameConfiguration.IncludeAssemblies[i];
                var path = System.IO.Path.GetFullPath(gameFolder + System.IO.Path.DirectorySeparatorChar + ParsePath(n));
                ret[i] = path;
            }
            return ret;
        }

        public string ParsePath(string n)
        {
            var fileName = GameConfiguration.SelectFile;
            var fileBase = System.IO.Path.GetFileNameWithoutExtension(GameConfiguration.SelectFile);
            n = Path.Parse(n, new[] { "fileBase:" + fileBase, "fileName:" + fileName });

            return n;
        }

        protected void SetProgress(ProgressHandler progress, float percentage, string newTask = "")
        {
            if (progress == null)
            {
                return;
            }
            if (newTask != "")
            {
                progress.Task = newTask;
            }
            progress.Progress = percentage;
        }

        protected void SetProgress(ProgressHandler progress, string newTask)
        {
            if (progress == null)
            {
                return;
            }
            progress.Task = newTask;
        }

        private static TypeDefinition GetTypeFromModules(Dictionary<string, ModuleDefinition> assemblies, string typeName, params string[] moduleKeys)
        {
            foreach (var key in moduleKeys)
            {
                if (!assemblies.ContainsKey(key)) continue;
                var t = assemblies[key].GetType(typeName);
                if (t != null) return t;
            }
            return null;
        }

        public void ApplyMods(List<Mod> mods, ProgressHandler handler)
        {
            try
            {
                if (mods.Count == 0)
                {
                    SetProgress(handler, "Saving");
                    if (!ApplyOriginalFiles())
                    {
                        throw new Exception("Could not apply original files.");
                    }
                    SetProgress(handler, 100f, "Finish");
                    return;
                }
                if (!RemoveModdedFiles())
                {
                    throw new Exception("Could not removed modded files.");
                }

                SetProgress(handler, "Preparing");
                var modsConfiguration = new XDocument();
                modsConfiguration.Add(new XElement("RuntimeConfiguration"));

                var libraryFolder = ModLibrary.GetLibraryFolder();

                // modlib\{GameId}\ 폴더가 없으면 먼저 생성
                if (!Directory.Exists(libraryFolder))
                {
                    Debug.Log("ModLoader: " + GameConfiguration.Id, "Library folder does not exist, creating: " + libraryFolder, Debug.Type.Warning);
                    Directory.CreateDirectory(libraryFolder);
                }

                var baseModLibPath = libraryFolder + System.IO.Path.DirectorySeparatorChar + "BaseModLib.dll";

                // BaseModLib.dll 없으면 자동 생성 후 재시도
                if (!File.Exists(baseModLibPath))
                {
                    Debug.Log("ModLoader: " + GameConfiguration.Id, "BaseModLib.dll not found at: " + baseModLibPath + ". Attempting to create ModLibrary.", Debug.Type.Warning);
                    if (!ModLibrary.Exists || ModLibrary.ModApiVersion != Version.Descriptor)
                    {
                        CreateModLibrary(true);
                    }
                }

                // CreateModLibrary가 비동기로 실행될 수 있으므로 완료될 때까지 대기 (최대 15초)
                if (!File.Exists(baseModLibPath))
                {
                    Debug.Log("ModLoader: " + GameConfiguration.Id, "Waiting for CreateModLibrary to complete...", Debug.Type.Warning);
                    for (int wait = 0; wait < 30; wait++)
                    {
                        Thread.Sleep(500);
                        if (File.Exists(baseModLibPath))
                        {
                            Debug.Log("ModLoader: " + GameConfiguration.Id, "BaseModLib.dll created after " + ((wait + 1) * 500) + "ms.");
                            break;
                        }
                    }
                }

                if (!File.Exists(baseModLibPath))
                {
                    Debug.Log("ModLoader: " + GameConfiguration.Id, "BaseModLib.dll still not found after waiting. Cannot apply mods.", Debug.Type.Error);
                    Schedule.AddTask("GUI", "OperationDone", null, new object[] { handler });
                    return;
                }

                // BaseModLib.dll이 다른 스레드(CreateModLibrary)에서 쓰기 중일 수 있으므로 재시도
                ModuleDefinition baseModLib = null;
                for (int retry = 0; retry < 10; retry++)
                {
                    try
                    {
                        baseModLib = ModuleDefinition.ReadModule(baseModLibPath);
                        break;
                    }
                    catch (System.IO.IOException)
                    {
                        Debug.Log("ModLoader: " + GameConfiguration.Id, "BaseModLib.dll is locked, retrying... (" + (retry + 1) + "/10)", Debug.Type.Warning);
                        Thread.Sleep(500);
                    }
                }
                if (baseModLib == null)
                {
                    Debug.Log("ModLoader: " + GameConfiguration.Id, "Could not read BaseModLib.dll after 10 retries.", Debug.Type.Error);
                    Schedule.AddTask("GUI", "OperationDone", null, new object[] { handler });
                    return;
                }
                var logType = baseModLib.GetType("ModAPI.Log");
                var baseSystemType = baseModLib.GetType("ModAPI.BaseSystem");
                MethodReference initializeMethod = null;
                MethodReference logMethod = null;

                var configurationAttributes = new Dictionary<string, TypeDefinition>();
                foreach (var modLibType in baseModLib.Types)
                {
                    if (modLibType.BaseType != null && modLibType.BaseType.Name == "ConfigurationAttribute")
                    {
                        configurationAttributes.Add(modLibType.FullName, modLibType);
                    }
                }

                foreach (var modLibMethod in logType.Methods)
                {
                    if (modLibMethod.Name == "Write" && modLibMethod.Parameters.Count == 2 && modLibMethod.Parameters[0].ParameterType.FullName == "System.String" &&
                        modLibMethod.Parameters[1].ParameterType.FullName == "System.String")
                    {
                        logMethod = modLibMethod;
                        break;
                    }
                }
                foreach (var modLibMethod in baseSystemType.Methods)
                {
                    if (modLibMethod.Name == "Initialize")
                    {
                        initializeMethod = modLibMethod;
                        break;
                    }
                }

                /*if (LogMethod == null)
                {
                    System.Console.WriteLine("NO LOG METHOD");
                    // ERROR
                    return;
                }*/

                var injectableClasses = new Dictionary<string, string>();
                var assemblyTypes = new Dictionary<string, Dictionary<string, TypeDefinition>>();

                var Assemblies = new Dictionary<string, ModuleDefinition>();

                // If backup folder doesn't exist, create it from game install folder before reading.
                // This ensures all subsequent reads come from backup — no file locks on game folder.
                var backupBase = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id + System.IO.Path.DirectorySeparatorChar);
                if (!Directory.Exists(backupBase) && !string.IsNullOrEmpty(GamePath))
                {
                    var _gf = GetGameFolder();
                    if (!string.IsNullOrEmpty(_gf))
                    {
                        Debug.Log("ModLoader: " + GameConfiguration.Id, "Backup folder does not exist. Creating from game install: " + _gf);
                        foreach (var n in GameConfiguration.IncludeAssemblies)
                        {
                            var srcPath = System.IO.Path.GetFullPath(_gf + System.IO.Path.DirectorySeparatorChar + ParsePath(n));
                            var dstPath = System.IO.Path.GetFullPath(backupBase + ParsePath(n));
                            if (File.Exists(srcPath))
                            {
                                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(dstPath));
                                File.Copy(srcPath, dstPath, true);
                                Debug.Log("ModLoader: " + GameConfiguration.Id, "Backed up: " + srcPath, Debug.Type.Notice, detailedOnly: true);
                            }
                        }
                        foreach (var n in GameConfiguration.CopyAssemblies)
                        {
                            var srcPath = System.IO.Path.GetFullPath(_gf + System.IO.Path.DirectorySeparatorChar + ParsePath(n));
                            var dstPath = System.IO.Path.GetFullPath(backupBase + ParsePath(n));
                            if (File.Exists(srcPath))
                            {
                                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(dstPath));
                                File.Copy(srcPath, dstPath, true);
                                Debug.Log("ModLoader: " + GameConfiguration.Id, "Backed up: " + srcPath, Debug.Type.Notice, detailedOnly: true);
                            }
                        }
                    }
                }

                var assemblyResolver = new CustomAssemblyResolver();
                assemblyResolver.AddPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                         System.IO.Path.DirectorySeparatorChar);

                // 실제 게임 폴더는 백업이 없을 때만 추가 — 백업이 있으면 불필요하며
                // Cecil이 게임 폴더 DLL에 file lock을 유지하여 DirectoryCopy 시 IOException 발생
                if (!Directory.Exists(backupBase))
                {
                    var _gameFolder = GetGameFolder();
                    if (string.IsNullOrEmpty(_gameFolder)) return;
                    var actualManagedPath = System.IO.Path.GetFullPath(_gameFolder + System.IO.Path.DirectorySeparatorChar + ParsePath(GameConfiguration.AssemblyPath));
                    if (Directory.Exists(actualManagedPath))
                    {
                        assemblyResolver.AddPath(actualManagedPath);
                        Debug.Log("ModLib: " + GameConfiguration.Id, "Added actual game folder to resolver (no backup): " + actualManagedPath);
                    }
                }

                var searchFolders = new List<string>();
                for (var i = 0; i < GameConfiguration.IncludeAssemblies.Count; i++)
                {
                    var assemblyPath = Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                       System.IO.Path.DirectorySeparatorChar + ParsePath(GameConfiguration.IncludeAssemblies[i]);
                    var folder = System.IO.Path.GetDirectoryName(assemblyPath);
                    if (!searchFolders.Contains(folder))
                    {
                        Debug.Log("ModLib: " + GameConfiguration.Id, "Added folder \"" + folder + "\" to assembly resolver.", Debug.Type.Notice, detailedOnly: true);
                        searchFolders.Add(folder);
                    }
                }
                for (var i = 0; i < GameConfiguration.CopyAssemblies.Count; i++)
                {
                    var assemblyPath = Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                       System.IO.Path.DirectorySeparatorChar + ParsePath(GameConfiguration.CopyAssemblies[i]);
                    var folder = System.IO.Path.GetDirectoryName(assemblyPath);
                    if (!searchFolders.Contains(folder))
                    {
                        Debug.Log("ModLib: " + GameConfiguration.Id, "Added folder \"" + folder + "\" to assembly resolver.", Debug.Type.Notice, detailedOnly: true);
                        searchFolders.Add(folder);
                    }
                }
                for (var i = 0; i < searchFolders.Count; i++)
                {
                    assemblyResolver.AddPath(searchFolders[i]);
                }

                foreach (var p in GameConfiguration.IncludeAssemblies)
                {
                    var path = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                                          System.IO.Path.DirectorySeparatorChar + ParsePath(p));

                    // Fallback: if backup path doesn't exist, try actual game install path
                    if (!File.Exists(path) && !string.IsNullOrEmpty(GamePath))
                    {
                        var fallbackPath = System.IO.Path.GetFullPath(GamePath + System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                        if (File.Exists(fallbackPath))
                        {
                            Debug.Log("ModLoader: " + GameConfiguration.Id, "Backup not found, using game install fallback: \"" + fallbackPath + "\"");
                            path = fallbackPath;
                        }
                    }

                    var key = System.IO.Path.GetFileNameWithoutExtension(path);

                    var module = ModuleDefinition.ReadModule(path, new ReaderParameters
                    {
                        AssemblyResolver = assemblyResolver
                    });
                    module.AssemblyReferences.Add(new AssemblyNameReference("BaseModLib", new System.Version("1.0.0.0")));
                    assemblyTypes.Add(key, new Dictionary<string, TypeDefinition>());

                    foreach (var type in module.Types)
                    {
                        if (!ModLib.CheckName(type.Namespace, GameConfiguration.ExcludeNamespaces) && !ModLib.CheckName(type.FullName, GameConfiguration.ExcludeTypes) &&
                            !ModLib.CheckName(type.FullName, GameConfiguration.NoFamily))
                        {
                            if (!assemblyTypes[key].ContainsKey(type.FullName))
                            {
                                assemblyTypes[key].Add(type.FullName, type);
                            }
                        }
                    }

                    Assemblies.Add(key, module);
                }

                if (!Assemblies.ContainsKey("mscorlib") || !Assemblies.ContainsKey("UnityEngine"))
                {
                    foreach (var p in GameConfiguration.CopyAssemblies)
                    {
                        var originalPath = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                                              System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                        var key = System.IO.Path.GetFileNameWithoutExtension(originalPath);

                        // mscorlib, UnityEngine, UnityEngine.CoreModule 모두 로드
                        if ((key == "mscorlib" || key == "UnityEngine" || key == "UnityEngine.CoreModule") && !Assemblies.ContainsKey(key))
                        {
                            // 원본 백업 경로 우선, 없으면 실제 게임 폴더에서 로드
                            var path = originalPath;
                            if (!File.Exists(path))
                            {
                                var _gf = GetGameFolder();
                                if (!string.IsNullOrEmpty(_gf))
                                    path = System.IO.Path.GetFullPath(_gf + System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                            }
                            if (File.Exists(path))
                            {
                                var module = ModuleDefinition.ReadModule(path);
                                Assemblies.Add(key, module);
                            }
                        }
                    }
                }

                SetProgress(handler, 5f);
                // 신규 Unity는 타입이 CoreModule에 있으므로 두 모듈 모두에서 탐색
                var unityEngineObject = GetTypeFromModules(Assemblies, "UnityEngine.Object", "UnityEngine", "UnityEngine.CoreModule");
                var unityEngineApplication = GetTypeFromModules(Assemblies, "UnityEngine.Application", "UnityEngine", "UnityEngine.CoreModule");
                var unityEngineComponent = GetTypeFromModules(Assemblies, "UnityEngine.Component", "UnityEngine", "UnityEngine.CoreModule");

                var systemAppDomain = Assemblies["mscorlib"].GetType("System.AppDomain");
                var systemResolveEventHandler = Assemblies["mscorlib"].GetType("System.ResolveEventHandler");
                var systemResolveEventArgs = Assemblies["mscorlib"].GetType("System.ResolveEventArgs");
                var systemReflectionAssembly = Assemblies["mscorlib"].GetType("System.Reflection.Assembly");
                var systemReflectionAssemblyName = Assemblies["mscorlib"].GetType("System.Reflection.AssemblyName");
                var systemString = Assemblies["mscorlib"].GetType("System.String");
                var systemIoFile = Assemblies["mscorlib"].GetType("System.IO.File");
                MethodDefinition systemAppDomainGetCurrentDomain = null;
                MethodDefinition systemAppDomainAddAssemblyResolve = null;
                MethodDefinition systemResolveEventArgsGetName = null;
                MethodDefinition systemResolveEventHandlerCtor = null;
                MethodDefinition systemReflectionAssemblyNameCtor = null;
                MethodDefinition systemReflectionAssemblyNameGetName = null;
                MethodDefinition systemStringFormat = null;
                MethodDefinition systemStringConcat = null;
                MethodDefinition systemReflectionAssemblyLoadFrom = null;
                MethodDefinition unityEngineApplicationGetDataPath = null;
                MethodDefinition systemIoFileWriteAllText = null;

                foreach (var m in unityEngineApplication.Methods)
                {
                    if (m.Name == "get_dataPath")
                    {
                        unityEngineApplicationGetDataPath = m;
                    }
                }

                foreach (var m in systemIoFile.Methods)
                {
                    if (m.Name == "WriteAllText" && m.Parameters.Count == 2)
                    {
                        systemIoFileWriteAllText = m;
                    }
                }
                foreach (var m in systemAppDomain.Methods)
                {
                    if (m.Name == "get_CurrentDomain")
                    {
                        systemAppDomainGetCurrentDomain = m;
                    }
                    if (m.Name == "add_AssemblyResolve")
                    {
                        systemAppDomainAddAssemblyResolve = m;
                    }
                }
                foreach (var m in systemResolveEventHandler.Methods)
                {
                    if (m.IsConstructor && m.Parameters.Count == 2 && m.Parameters[0].ParameterType.FullName == "System.Object")
                    {
                        systemResolveEventHandlerCtor = m;
                    }
                }
                foreach (var m in systemResolveEventArgs.Methods)
                {
                    if (m.Name == "get_Name")
                    {
                        systemResolveEventArgsGetName = m;
                    }
                }
                foreach (var m in systemReflectionAssembly.Methods)
                {
                    if (m.Name == "LoadFrom" && m.Parameters.Count == 1 && m.Parameters[0].ParameterType.FullName == "System.String")
                    {
                        systemReflectionAssemblyLoadFrom = m;
                    }
                }
                foreach (var m in systemReflectionAssemblyName.Methods)
                {
                    if (m.IsConstructor && m.Parameters.Count == 1 && m.Parameters[0].ParameterType.FullName == "System.String")
                    {
                        systemReflectionAssemblyNameCtor = m;
                    }
                    if (m.Name == "get_Name")
                    {
                        systemReflectionAssemblyNameGetName = m;
                    }
                }
                foreach (var m in systemString.Methods)
                {
                    if (m.Name == "Format" && m.Parameters.Count == 2 && m.Parameters[0].ParameterType.FullName == "System.String" && m.Parameters[1].ParameterType.FullName == "System.Object")
                    {
                        systemStringFormat = m;
                    }
                    if (m.Name == "Concat" && m.Parameters.Count == 2 && m.Parameters[0].ParameterType.FullName == "System.String" && m.Parameters[1].ParameterType.FullName == "System.String")
                    {
                        systemStringConcat = m;
                    }
                }

                var resolveModAssembly = new MethodDefinition("ResolveModAssembly", MethodAttributes.HideBySig | MethodAttributes.Private | MethodAttributes.Static,
                    Assemblies["UnityEngine"].ImportReference(systemReflectionAssembly));
                resolveModAssembly.Parameters.Add(new ParameterDefinition("sender", ParameterAttributes.None, Assemblies["UnityEngine"].TypeSystem.Object));
                resolveModAssembly.Parameters.Add(new ParameterDefinition("e", ParameterAttributes.None, Assemblies["UnityEngine"].ImportReference(systemResolveEventArgs)));

                if (resolveModAssembly.Body == null)
                {
                    resolveModAssembly.Body = new MethodBody(resolveModAssembly);
                }

                resolveModAssembly.Body.Variables.Add(new VariableDefinition(Assemblies["UnityEngine"].TypeSystem.String));
                resolveModAssembly.Body.Variables.Add(new VariableDefinition(Assemblies["UnityEngine"].TypeSystem.String));
                resolveModAssembly.Body.Variables.Add(new VariableDefinition(Assemblies["UnityEngine"].ImportReference(systemReflectionAssembly)));

                var processor = resolveModAssembly.Body.GetILProcessor();
                var _tryStart = processor.Create(OpCodes.Ldarg_1);
                processor.Append(_tryStart);
                processor.Append(processor.Create(OpCodes.Callvirt, Assemblies["UnityEngine"].ImportReference(systemResolveEventArgsGetName)));
                processor.Append(processor.Create(OpCodes.Newobj, Assemblies["UnityEngine"].ImportReference(systemReflectionAssemblyNameCtor)));
                processor.Append(processor.Create(OpCodes.Call, Assemblies["UnityEngine"].ImportReference(systemReflectionAssemblyNameGetName)));
                processor.Append(processor.Create(OpCodes.Stloc_0));
                processor.Append(processor.Create(OpCodes.Call, unityEngineApplicationGetDataPath));
                processor.Append(processor.Create(OpCodes.Ldstr, "/../Mods/{0}.dll"));
                processor.Append(processor.Create(OpCodes.Call, Assemblies["UnityEngine"].ImportReference(systemStringConcat)));
                processor.Append(processor.Create(OpCodes.Ldloc_0));
                processor.Append(processor.Create(OpCodes.Call, Assemblies["UnityEngine"].ImportReference(systemStringFormat)));
                processor.Append(processor.Create(OpCodes.Stloc_1));

                processor.Append(processor.Create(OpCodes.Ldstr, "test.txt"));
                processor.Append(processor.Create(OpCodes.Ldloc_1));
                processor.Append(processor.Create(OpCodes.Call, Assemblies["UnityEngine"].ImportReference(systemIoFileWriteAllText)));

                processor.Append(processor.Create(OpCodes.Ldloc_1));
                processor.Append(processor.Create(OpCodes.Call, Assemblies["UnityEngine"].ImportReference(systemReflectionAssemblyLoadFrom)));
                processor.Append(processor.Create(OpCodes.Stloc_2));

                var exitPoint = processor.Create(OpCodes.Ldloc_2);
                processor.Append(exitPoint);
                processor.Append(processor.Create(OpCodes.Ret));

                processor.InsertBefore(exitPoint, processor.Create(OpCodes.Leave, exitPoint));
                var _tryEnd = processor.Create(OpCodes.Pop);
                processor.InsertBefore(exitPoint, _tryEnd);
                processor.InsertBefore(exitPoint, processor.Create(OpCodes.Ldnull));
                processor.InsertBefore(exitPoint, processor.Create(OpCodes.Stloc_2));
                processor.InsertBefore(exitPoint, processor.Create(OpCodes.Leave, exitPoint));

                var exceptionHandler = new ExceptionHandler(ExceptionHandlerType.Catch)
                {
                    TryStart = _tryStart,
                    TryEnd = _tryEnd,
                    HandlerStart = _tryEnd,
                    HandlerEnd = exitPoint,
                    CatchType = Assemblies["UnityEngine"].ImportReference(Assemblies["mscorlib"].GetType("System.Exception"))
                };
                resolveModAssembly.Body.ExceptionHandlers.Add(exceptionHandler);

                unityEngineApplication.Methods.Add(resolveModAssembly);

                var ctorMethod = new MethodDefinition(".cctor",
                    MethodAttributes.SpecialName | MethodAttributes.RTSpecialName | MethodAttributes.HideBySig | MethodAttributes.Private | MethodAttributes.Static,
                    Assemblies["UnityEngine"].TypeSystem.Void);

                processor = ctorMethod.Body.GetILProcessor();
                var last = processor.Create(OpCodes.Ret);
                processor.Append(last);
                processor.InsertBefore(last, processor.Create(OpCodes.Call, Assemblies["UnityEngine"].ImportReference(systemAppDomainGetCurrentDomain)));
                processor.InsertBefore(last, processor.Create(OpCodes.Ldnull));
                processor.InsertBefore(last, processor.Create(OpCodes.Ldftn, resolveModAssembly));
                processor.InsertBefore(last, processor.Create(OpCodes.Newobj, Assemblies["UnityEngine"].ImportReference(systemResolveEventHandlerCtor)));
                processor.InsertBefore(last, processor.Create(OpCodes.Callvirt, Assemblies["UnityEngine"].ImportReference(systemAppDomainAddAssemblyResolve)));

                unityEngineApplication.Methods.Add(ctorMethod);

                foreach (var method in unityEngineComponent.Methods)
                {
                    if ((method.Name == "GetComponent" || method.Name == "GetComponentInChildren" || method.Name == "GetComponentsInChildren" || method.Name == "GetComponentsInParent" ||
                         method.Name == "get_gameObject" || method.Name == "get_transform" || method.Name == "GetComponents" || method.Name == "SendMessageUpwards" || method.Name == "SendMessage" ||
                         method.Name == "BroadcastMessage") && !method.IsInternalCall)
                    {
                        processor = method.Body.GetILProcessor();
                        last = method.Body.Instructions[0];
                        processor.InsertBefore(last, processor.Create(OpCodes.Call, Assemblies["UnityEngine"].ImportReference(initializeMethod)));
                    }
                }

                SetProgress(handler, 10f);

                var modTools = new Dictionary<string, MethodDefinition>();
                var injectToType = new Dictionary<string, TypeDefinition>();
                var injectToMethod = new Dictionary<string, MethodDefinition>();

                var injectIntos = new Dictionary<string, Dictionary<int, List<Mod.Header.InjectInto>>>();
                var addMethods = new Dictionary<string, List<Mod.Header.AddMethod>>();
                var addFields = new Dictionary<string, List<Mod.Header.AddField>>();
                var addedTypes = new Dictionary<string, List<TypeDefinition>>();

                var addedClasses = new Dictionary<TypeReference, TypeDefinition>();
                var addedFields = new Dictionary<FieldReference, FieldDefinition>();
                var addedMethods = new Dictionary<MethodReference, MethodDefinition>();
                var injectedMethods = new Dictionary<MethodReference, MethodDefinition>();
                var newMethods = new Dictionary<MethodReference, MethodDefinition>();
                var typesMap = new Dictionary<TypeReference, TypeDefinition>();

                var addReferences = new Dictionary<string, AssemblyNameReference>();

                var insertConstructor = new Dictionary<TypeDefinition, TypeDefinition>();

                var modConfigurations = new Dictionary<string, XElement>();
                var c = 0;
                foreach (var mod in mods)
                {
                    mod.RewindModule();
                    var modConfiguration = new XElement("Mod");
                    modConfigurations.Add(mod.Id, modConfiguration);
                    modConfiguration.SetAttributeValue("ID", mod.Id);
                    modConfiguration.SetAttributeValue("UniqueID", mod.UniqueId);
                    modConfiguration.SetAttributeValue("Version", mod.HeaderData.GetVersion());

                    foreach (var button in mod.HeaderData.GetButtons())
                    {
                        var assignedKey = Configuration.GetString("Mods." + GameConfiguration.Id + "." + mod.Id + ".Buttons." + button.Id);
                        if (assignedKey == "")
                        {
                            assignedKey = button.StandardKey;
                        }
                        var buttonConfiguration = new XElement("Button");
                        buttonConfiguration.SetAttributeValue("ID", button.Id);
                        buttonConfiguration.Value = assignedKey;
                        modConfiguration.Add(buttonConfiguration);
                    }

                    modsConfiguration.Root.Add(modConfiguration);
                    addedTypes.Add(mod.Id, new List<TypeDefinition>());
                    foreach (var addClass in mod.HeaderData.GetAddClasses())
                    {
                        foreach (var m in addClass.Type.Methods)
                        {
                            MonoHelper.ParseCustomAttributes(addClass.Mod, modsConfiguration, m, configurationAttributes);
                        }

                        addedTypes[mod.Id].Add(addClass.Type);
                        addedClasses.Add(addClass.Type, addClass.Type);
                    }

                    foreach (var addMethod in mod.HeaderData.GetAddMethods())
                    {
                        if (!typesMap.ContainsKey(addMethod.Method.DeclaringType))
                        {
                            typesMap.Add(addMethod.Method.DeclaringType, Assemblies[addMethod.AssemblyName].GetType(addMethod.TypeName));
                        }

                        var key = addMethod.AssemblyName + "::" + addMethod.TypeName;
                        if (!addMethods.ContainsKey(key))
                        {
                            addMethods.Add(key, new List<Mod.Header.AddMethod>());
                        }
                        addMethods[key].Add(addMethod);
                    }

                    foreach (var addField in mod.HeaderData.GetAddFields())
                    {
                        if (!typesMap.ContainsKey(addField.Field.DeclaringType))
                        {
                            typesMap.Add(addField.Field.DeclaringType, Assemblies[addField.AssemblyName].GetType(addField.TypeName));
                        }

                        var key = addField.AssemblyName + "::" + addField.TypeName;
                        if (!addFields.ContainsKey(key))
                        {
                            addFields.Add(key, new List<Mod.Header.AddField>());
                        }
                        addFields[key].Add(addField);
                    }

                    foreach (var injectInto in mod.HeaderData.GetInjectIntos())
                    {
                        if (!typesMap.ContainsKey(injectInto.Method.DeclaringType))
                        {
                            typesMap.Add(injectInto.Method.DeclaringType, Assemblies[injectInto.AssemblyName].GetType(injectInto.TypeName));
                        }

                        var parameters = "";
                        var first = true;
                        foreach (var param in injectInto.Method.Parameters)
                        {
                            if (!first)
                            {
                                parameters += ",";
                            }
                            parameters += param.ParameterType.FullName;
                            first = false;
                            // @TODO: Add parameter name at some time to verify integrity. NameResolver does not support this currently.
                        }
                        var key = injectInto.AssemblyName + "::" + injectInto.Method.ReturnType.FullName + " " + injectInto.TypeName + "::" + injectInto.MethodName + "(" + parameters + ")";
                        if (!injectIntos.ContainsKey(key))
                        {
                            injectIntos.Add(key, new Dictionary<int, List<Mod.Header.InjectInto>>());
                        }
                        if (!injectIntos[key].ContainsKey(injectInto.Priority))
                        {
                            injectIntos[key].Add(injectInto.Priority, new List<Mod.Header.InjectInto>());
                        }
                        injectIntos[key][injectInto.Priority].Add(injectInto);
                    }

                    foreach (var entry in typesMap)
                    {
                        if (entry.Value == null) continue;
                        Debug.Log("Game: " + GameConfiguration.Id, "Type entry: " + entry.Key.FullName + " - " + entry.Value.FullName, Debug.Type.Notice, detailedOnly: true);
                    }

                    /*foreach (Mod.Header.AddClass addClass in mod.HeaderData.GetAddClasses()) 
                    {
                        string key = mod.ID;
                        if (!addClasses.ContainsKey(key))
                            addClasses.Add(key, new List<Mod.Header.AddClass>());
                        addClasses[key].Add(addClass);
                    }*/
                    c++;
                    SetProgress(handler, 10f + (c / (float)mods.Count) * 20f, "FetchingInjections");
                }

                SetProgress(handler, 30f, "Injecting");
                foreach (var kv in addFields)
                {
                    var path = kv.Key;
                    var parts = path.Split(new[] { "::" }, StringSplitOptions.None);
                    var type = Assemblies[parts[0]].GetType(parts[1]);

                    foreach (var field in kv.Value)
                    {
                        var newField = MonoHelper.CopyField(field.Field);
                        type.Fields.Add(newField);
                        addedFields.Add(field.Field, newField);
                    }
                }
                SetProgress(handler, 35f);
                foreach (var kv in addMethods)
                {
                    var path = kv.Key;
                    var parts = path.Split(new[] { "::" }, StringSplitOptions.None);
                    var type = Assemblies[parts[0]].GetType(parts[1]);

                    foreach (var method in kv.Value)
                    {
                        var newMethod = MonoHelper.CopyMethod(method.Method);
                        type.Methods.Add(newMethod);
                        MonoHelper.ParseCustomAttributes(method.Mod, modsConfiguration, newMethod, configurationAttributes);
                        addedMethods.Add(method.Method, newMethod);
                    }
                }
                SetProgress(handler, 40f);

                MethodReference methodObjectToString = null;
                MethodReference methodStringConcat = null;
                MethodReference methodExceptionConstructor = null;
                TypeReference typeException = null;
                foreach (var m in Assemblies["mscorlib"].GetType("System.Object").Methods)
                {
                    if (m.Name == "ToString")
                    {
                        methodObjectToString = m;
                    }
                }
                foreach (var m in Assemblies["mscorlib"].GetType("System.String").Methods)
                {
                    if (m.Name == "Concat" && m.Parameters.Count == 2 && m.Parameters[0].ParameterType.Name == "String" && m.Parameters[1].ParameterType.Name == "String")
                    {
                        methodStringConcat = m;
                    }
                }
                typeException = Assemblies["mscorlib"].GetType("System.Exception");
                foreach (var m in Assemblies["mscorlib"].GetType("System.Exception").Methods)
                {
                    if (m.IsConstructor && m.Parameters.Count == 1 && m.Parameters[0].ParameterType.Name == "String")
                    {
                        methodExceptionConstructor = m;
                    }
                }

                foreach (var kv in injectIntos)
                {
                    var path = kv.Key;
                    var ind = path.IndexOf("::");
                    var parts = new string[2];
                    parts[0] = path.Substring(0, ind);
                    parts[1] = path.Substring(ind + 2);

                    var Namespace = "";
                    var Type = "";
                    var method = "";
                    var returnType = "";
                    var parameters = new string[0];
                    NameResolver.Parse(parts[1], ref Namespace, ref Type, ref method, ref returnType, ref parameters);

                    var fullTypeName = Namespace + (Namespace != "" ? "." : "") + Type;
                    var type = Assemblies[parts[0]].GetType(fullTypeName);

                    MethodDefinition lastMethod = null;
                    MethodDefinition originalMethod = null;
                    var originalMethodFullName = "";
                    if (type.IsAbstract && type.IsSealed && path.Contains(".ctor"))
                    {
                        // Skip instance constructors of static classes
                        continue;
                    }
                    foreach (var methodDefinition in type.Methods)
                    {
                        if (methodDefinition.Name == method && methodDefinition.Parameters.Count == parameters.Length && methodDefinition.ReturnType.FullName == returnType)
                        {
                            var ok = true;
                            for (var i = 0; i < methodDefinition.Parameters.Count; i++)
                            {
                                if (methodDefinition.Parameters[i].ParameterType.FullName != parameters[i])
                                {
                                    ok = false;
                                    break;
                                }
                            }
                            if (ok)
                            {
                                originalMethod = methodDefinition;
                                originalMethodFullName = originalMethod.FullName;
                                break;
                            }
                        }
                    }

                    var priorities = kv.Value.Keys.ToList();
                    priorities.Sort();

                    var objectToString = Assemblies[parts[0]].ImportReference(methodObjectToString);
                    var stringConcat = Assemblies[parts[0]].ImportReference(methodStringConcat);
                    var exceptionConstructor = Assemblies[parts[0]].ImportReference(methodExceptionConstructor);
                    var exception = Assemblies[parts[0]].ImportReference(typeException);

                    var constructorInstructions = new List<Instruction>();
                    var staticConstructorInstructions = new List<Instruction>();

                    var num = 0;
                    foreach (var prio in priorities)
                    {
                        foreach (var injectInto in kv.Value[prio])
                        {
                            var newMethod = MonoHelper.CopyMethod(injectInto.Method);

                            // Handle constructor, append modified code after the original code
                            if (newMethod.IsConstructor)
                            {
                                // Create a copy of the modded constructor instructions
                                var instructions = newMethod.Body.Instructions.ToList();

                                // Remove constructor call
                                foreach (var instruction in newMethod.Body.Instructions)
                                {
                                    // Remove instruction
                                    instructions.Remove(instruction);

                                    // If the instruction is the call to the base constuctor then we are done
                                    if (instruction.OpCode.Code == Code.Call &&
                                        (((MethodReference)instruction.Operand).Name == ".ctor" ||
                                         ((MethodReference)instruction.Operand).Name == ".cctor"))
                                    {
                                        break;
                                    }
                                }

                                // Remove last instruction (which is 'ret')
                                instructions.RemoveAt(instructions.Count - 1);

                                // If there are still instructions left - means actually added code and not a blank constructor - then add them to the constructor
                                if (instructions.Count > 0)
                                {
                                    // Get the last instruction
                                    var lastInstruction = originalMethod.Body.Instructions[originalMethod.Body.Instructions.Count - 1];

                                    // Insert remaining instructions before the last instruction of the original constructor
                                    foreach (var instruction in instructions)
                                    {
                                        // Inject modded instructions
                                        originalMethod.Body.GetILProcessor().InsertBefore(lastInstruction, instruction);
                                    }

                                    injectedMethods.Add(newMethod, originalMethod);
                                }
                            }
                            // Regular method (no constructor)
                            else
                            {
                                // Apply same modifies and attributes as the original method to not break the game's code
                                newMethod.Attributes = originalMethod.Attributes;
                                newMethod.IsFamily = originalMethod.IsFamily;
                                newMethod.IsPublic = originalMethod.IsPublic;
                                newMethod.IsPrivate = originalMethod.IsPrivate;
                                newMethod.IsVirtual = originalMethod.IsVirtual;
                                newMethod.IsStatic = originalMethod.IsStatic;

                                // Rename new method's name
                                newMethod.Name = newMethod.Name + "__" + num;
                                num += 1;

                                // Route base method calls to the correct modded version (if present)
                                foreach (var instruction in newMethod.Body.Instructions)
                                {
                                    if (instruction.OpCode.Code == Code.Call &&
                                        instruction.Operand is MethodReference &&
                                        ((MethodReference)instruction.Operand).FullName == originalMethodFullName)
                                    {
                                        instruction.Operand = lastMethod ?? originalMethod;
                                    }
                                }

                                // Get the return variable (if it has a return type)
                                VariableDefinition returnVariable = null;
                                var isReturningValue = newMethod.ReturnType.FullName != "System.Void";
                                if (isReturningValue)
                                {
                                    // Create a new return variable we can use to return outside of the try-catch block
                                    returnVariable = new VariableDefinition(newMethod.ReturnType);
                                    newMethod.Body.Variables.Add(returnVariable);
                                }

                                #region Add Exception Handler

                                // Create the IL processor
                                var ilProcessor = newMethod.Body.GetILProcessor();

                                // Get the start and end of the method's instructions
                                var tryStart = newMethod.Body.Instructions[0];
                                var lastInstruction = newMethod.Body.Instructions.Last();

                                // Handle methods with return value
                                if (isReturningValue)
                                {
                                    // Create load return variable instruction for later use
                                    var loadReturnVariable = ilProcessor.Create(OpCodes.Ldloc, returnVariable);

                                    // Apply new last instruction
                                    ilProcessor.InsertBefore(lastInstruction, loadReturnVariable);
                                    lastInstruction = loadReturnVariable;

                                    // Loop through a copy of the instructions
                                    var lastReturn = newMethod.Body.Instructions.Last();
                                    foreach (var instruction in newMethod.Body.Instructions.ToList())
                                    {
                                        if (instruction.OpCode.Code == Code.Ret)
                                        {
                                            // Store return value into the return variable
                                            ilProcessor.InsertBefore(instruction == lastReturn ? lastInstruction : instruction, ilProcessor.Create(OpCodes.Stloc, returnVariable));
                                        }
                                    }
                                }

                                // Add exception object
                                var exceptionVariable = new VariableDefinition(exception);
                                newMethod.Body.Variables.Add(exceptionVariable);

                                var handlerStart = ilProcessor.Create(OpCodes.Stloc, exceptionVariable);
                                var tryEnd = ilProcessor.Create(OpCodes.Leave, lastInstruction);

                                // Handle exception, log the complete exception
                                ilProcessor.InsertBefore(lastInstruction, tryEnd);
                                ilProcessor.InsertBefore(lastInstruction, handlerStart);
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldstr, "Exception thrown: "));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldloc, exceptionVariable));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Callvirt, objectToString));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Call, stringConcat));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldstr, injectInto.Mod.Id));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Call, logMethod));

                                // Reference 'this' on non-static methods
                                if (!originalMethod.IsStatic)
                                {
                                    ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldarg_0));
                                }

                                // Add parameters of modded method to the upcoming call
                                foreach (var param in newMethod.Parameters)
                                {
                                    ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldarg, param));
                                }

                                // Call the base method (or another modded method if modded more than once) in catch block
                                ilProcessor.InsertBefore(lastInstruction, lastMethod != null ? ilProcessor.Create(OpCodes.Call, lastMethod) : ilProcessor.Create(OpCodes.Call, originalMethod));

                                // Add the return value
                                if (isReturningValue)
                                {
                                    ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Stloc, returnVariable));
                                }

                                // End the exception block
                                var handlerEnd = ilProcessor.Create(OpCodes.Leave, lastInstruction);
                                ilProcessor.InsertBefore(lastInstruction, handlerEnd);

                                // Add the exception handler to the new method body
                                newMethod.Body.ExceptionHandlers.Add(new ExceptionHandler(ExceptionHandlerType.Catch)
                                {
                                    TryStart = tryStart,
                                    TryEnd = handlerStart,
                                    HandlerStart = handlerStart,
                                    HandlerEnd = lastInstruction,
                                    CatchType = exception
                                });

                                #endregion

                                lastMethod = newMethod;
                                type.Methods.Add(newMethod);
                                injectedMethods.Add(newMethod, newMethod);
                            }
                        }
                    }

                    // Rename original method if it's not the constructor
                    if (!originalMethod.IsConstructor)
                    {
                        lastMethod.Name = originalMethod.Name;
                        originalMethod.Name = "__" + method + "__Original";
                        newMethods.Add(originalMethod, lastMethod);
                    }
                }
                SetProgress(handler, 50f, "Resolving");

                /** RESOLVE ALL LINKS **/
                foreach (var method in addedMethods.Values)
                {
                    MonoHelper.Resolve(method.Module, method, addedClasses, addedFields, addedMethods, injectedMethods, typesMap);
                }

                foreach (var method in injectedMethods.Values)
                {
                    MonoHelper.Resolve(method.Module, method, addedClasses, addedFields, addedMethods, injectedMethods, typesMap);
                }

                foreach (var field in addedFields.Values)
                {
                    MonoHelper.Resolve(field.Module, field, addedClasses, typesMap);
                }

                var modFolder = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                                           System.IO.Path.DirectorySeparatorChar + "Mods" + System.IO.Path.DirectorySeparatorChar);
                var assemblyFolder = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                                                System.IO.Path.DirectorySeparatorChar + ParsePath(GameConfiguration.AssemblyPath)) + System.IO.Path.DirectorySeparatorChar;
                if (!Directory.Exists(assemblyFolder))
                {
                    Directory.CreateDirectory(assemblyFolder);
                }
                if (!Directory.Exists(modFolder))
                {
                    Directory.CreateDirectory(modFolder);
                }

                foreach (var mod in mods)
                {
                    var modModule = mod.GetModuleCopy();
                    for (var j = 0; j < modModule.Types.Count; j++)
                    {
                        var t = modModule.Types[j];
                        foreach (var m in t.Methods)
                        {
                            MonoHelper.Resolve(m.Module, m, addedClasses, addedFields, addedMethods, injectedMethods, typesMap);
                        }
                    }
                    for (var j = 0; j < modModule.Types.Count; j++)
                    {
                        var t = modModule.Types[j];
                        var keep = false;
                        foreach (var type in addedTypes[mod.Id])
                        {
                            if (type.FullName == t.FullName)
                            {
                                keep = true;
                            }
                        }
                        if (!keep)
                        {
                            modModule.Types.Remove(t);
                        }
                    }
                    var path = System.IO.Path.GetFullPath(assemblyFolder + System.IO.Path.DirectorySeparatorChar + modModule.Name);
                    modModule.Write(path);
                    var zip = mod.GetResources();
                    if (zip != null)
                    {
                        zip.Save(modFolder + mod.Id + ".resources");
                        modConfigurations[mod.Id].SetAttributeValue("HasResources", "true");
                    }
                }

                SetProgress(handler, 80f, "Saving");
                File.Copy(
                    baseModLibPath,
                    System.IO.Path.GetFullPath(assemblyFolder + System.IO.Path.DirectorySeparatorChar + "BaseModLib.dll"),
                    true);
                foreach (var p in GameConfiguration.IncludeAssemblies)
                {
                    var path = System.IO.Path.GetFullPath(
                        Configuration.GetPath("ModdedGameFiles") +
                        System.IO.Path.DirectorySeparatorChar +
                        GameConfiguration.Id +
                        System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                    var folder = System.IO.Path.GetDirectoryName(path);
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    var key = System.IO.Path.GetFileNameWithoutExtension(path);

                    var module = Assemblies[key];

                    // Remap all .NET 4.8 / Silverlight assembly references to The Forest's Mono 2.0 versions
                    // and remove any duplicate references (e.g., mscorlib 2.0.5.0 from Silverlight)
                    AssemblyVersionMap.RemapAllReferences(module);
                    AssemblyVersionMap.RemoveDuplicateReferences(module);

                    foreach (var type in module.Types)
                    {
                        foreach (var subType in type.NestedTypes)
                        {
                            foreach (var method2 in subType.Methods)
                            {
                                MonoHelper.Remap(module, method2, newMethods);
                            }
                        }
                        foreach (var method in type.Methods)
                        {
                            MonoHelper.Remap(module, method, newMethods);
                        }
                    }
                    module.Write(path);
                }

                foreach (var p in GameConfiguration.CopyAssemblies)
                {
                    var path = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                                          System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                    var folder = System.IO.Path.GetDirectoryName(path);
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    var key = System.IO.Path.GetFileNameWithoutExtension(path);
                    if (key == "UnityEngine")
                    {
                        Assemblies[key].Write(path);
                    }
                }

                var guiPath = System.IO.Path.GetFullPath(Configuration.GetPath("Libraries") + System.IO.Path.DirectorySeparatorChar + "GUI.assetbundle");
                if (File.Exists(guiPath))
                {
                    File.Copy(guiPath, System.IO.Path.GetFullPath(modFolder + System.IO.Path.DirectorySeparatorChar + "GUI.assetbundle"), true);
                }

                var assemblies = new[]
                {
                    "I18N.CJK.dll",
                    "I18N.dll",
                    "I18N.MidEast.dll",
                    "I18N.Other.dll",
                    "I18N.Rare.dll",
                    "I18N.West.dll",
                    "System.Xml.Linq.dll",
                    // C# 7.3 polyfills for BaseModLib and mod DLLs built with .NET 3.5 + LangVersion 7.3.
                    // These DLLs must be present in TheForest_Data/Managed/ at runtime so Mono 2.0
                    // can resolve them when loading mods that use async/await.
                    System.IO.Path.Combine("polyfills", "AsyncBridge.dll"),
                    System.IO.Path.Combine("polyfills", "System.Threading.dll"),
                };
                foreach (var ass in assemblies)
                {
                    var assPath = System.IO.Path.GetFullPath(Configuration.GetPath("Libraries") + System.IO.Path.DirectorySeparatorChar + ass);
                    if (File.Exists(assPath))
                    {
                        // Use filename only for destination — polyfills are in a subfolder of Libraries
                        // but must be copied flat into Managed/ (no subdirectory).
                        var destFileName = System.IO.Path.GetFileName(assPath);
                        File.Copy(assPath, System.IO.Path.GetFullPath(assemblyFolder + destFileName), true);
                    }
                }
                var ionicZipPath = System.IO.Path.GetFullPath("Ionic.Zip.dll");
                if (File.Exists(ionicZipPath))
                {
                    File.Copy(ionicZipPath, assemblyFolder + "Ionic.Zip.dll", true);
                }

                modsConfiguration.Save(System.IO.Path.GetFullPath(modFolder + System.IO.Path.DirectorySeparatorChar + "RuntimeConfiguration.xml"));

                var moddedPath = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar);
                var gamePath = GamePath;
                var directories = Directory.GetDirectories(moddedPath);
                foreach (var d in directories)
                {
                    DirectoryCopy(d, gamePath, true);
                }
                var files = Directory.GetFiles(moddedPath);
                foreach (var f in files)
                {
                    File.Copy(f, gamePath + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetFileName(f), true);
                }
                SetProgress(handler, 100f, "Finish");
            }
            catch (Exception e)
            {
                RemoveModdedFiles();
                ApplyOriginalFiles();
                Debug.Log("ModLoader: " + GameConfiguration.Id, "An exception occured: " + e, Debug.Type.Error);
                SetProgress(handler, "Error.Unexpected");
                //Communicator.Error(e.ToString());
            }
        }

        private bool RemoveModdedFiles()
        {
            try
            {
                var outputFolder = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                                              System.IO.Path.DirectorySeparatorChar);
                if (!Directory.Exists(outputFolder))
                {
                    return true;
                }
                var oldFiles = Directory.GetFiles(outputFolder);
                foreach (var file in oldFiles)
                {
                    File.Delete(file);
                }
                var oldDirectories = Directory.GetDirectories(outputFolder);
                foreach (var directory in oldDirectories)
                {
                    Directory.Delete(directory, true);
                }
                return true;
            }
            catch (Exception e2)
            {
                Debug.Log("ModLoader: " + GameConfiguration.Id, "Could not remove modded files: " + e2, Debug.Type.Error);
                return false;
            }
        }

        private bool ApplyOriginalFiles()
        {
            try
            {
                var originalFolder = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.Id +
                                                                System.IO.Path.DirectorySeparatorChar);

                // 원본 백업 폴더가 없으면 건너뜀 (첫 실행 시 정상)
                if (!Directory.Exists(originalFolder))
                {
                    Debug.Log("ModLoader: " + GameConfiguration.Id, "Original files folder does not exist yet, skipping restore: " + originalFolder, Debug.Type.Warning);
                    return true;
                }

                DirectoryCopy(originalFolder, GamePath, true);
                return true;
            }
            catch (Exception e2)
            {
                Debug.Log("ModLoader: " + GameConfiguration.Id, "Could not apply original files to game: " + e2, Debug.Type.Error);
                return false;
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            var dir = new DirectoryInfo(sourceDirName);
            var dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                var temppath = System.IO.Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (var subdir in dirs)
                {
                    var temppath = System.IO.Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        public class Versions
        {
            public Game Game;
            public bool Valid;
            protected string FileName;
            public HashSet<string> CheckFiles;
            public HashSet<Version> VersionsList;

            public Versions(Game game)
            {
                FileName = Configuration.GetPath("Configurations") + System.IO.Path.DirectorySeparatorChar + "games" + System.IO.Path.DirectorySeparatorChar + game.GameConfiguration.Id +
                           System.IO.Path.DirectorySeparatorChar +
                           "Versions.xml";
                Game = game;
            }

            public Version GetVersion(string checkSum)
            {
                if (checkSum == "")
                {
                    return Version.Zero;
                }
                foreach (var v in VersionsList)
                {
                    if (string.Equals(v.CheckSum, checkSum, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return v;
                    }
                }
                return Version.Zero;
            }

            public void Refresh()
            {
                CheckFiles = new HashSet<string>();
                VersionsList = new HashSet<Version>();

                if (Configuration.GetString("UpdateVersions").ToLower() == "true")
                {
                    UpdateVersions();
                }

                try
                {
                    var document = XDocument.Load(FileName);

                    foreach (var element in document.Root.Element("files").Elements("file"))
                    {
                        CheckFiles.Add(element.Value);
                    }
                    foreach (var element in document.Root.Elements("version"))
                    {
                        VersionsList.Add(new Version(element));
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("Game: " + Game.GameConfiguration.Id, "Failed parsing VersionsData file: " + e, Debug.Type.Error);
                }

                Valid = true;
            }

            public void UpdateVersions()
            {
                var gameId = Game.GameConfiguration.Id;

                // ── TLS 설정 ──────────────────────────────────────────────
                // SSL/TLS 보안 채널 오류 방지를 위해 TLS 버전을 명시적으로 설정
                // 서버와 클라이언트가 협상하여 공통으로 지원하는 최상위 버전이 자동 선택됨
                var prevProtocol = System.Net.ServicePointManager.SecurityProtocol;
                System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12 |
                    System.Net.SecurityProtocolType.Tls11 |
                    System.Net.SecurityProtocolType.Tls;

                Debug.Log("Game: " + gameId,
                    $"[UpdateVersions] TLS protocol set: {System.Net.ServicePointManager.SecurityProtocol} (was: {prevProtocol})",
                    Debug.Type.Notice, detailedOnly: true);

                // ── 다운로드 ──────────────────────────────────────────────
                string successfulResponse = null;
                string successfulUrl = null;
                Debug.Log("Game: " + gameId,
                    $"[UpdateVersions] Starting version file download. Servers: {string.Join(", ", VersionUpdateDomains)}",
                    Debug.Type.Notice, detailedOnly: true);

                using (var client = new WebClient())
                {
                    foreach (var url in VersionUpdateDomains)
                    {
                        // 이미 1순위 서버에서 성공했으면 나머지 서버는 시도하지 않음
                        // (모든 성공 응답을 병합하면 동일 버전 항목이 중복으로 합쳐져
                        //  체크섬이 두 배 길이로 깨지는 문제가 발생함)
                        if (successfulResponse != null)
                            break;

                        var formattedUrl = string.Format(url, gameId);
                        Debug.Log("Game: " + gameId,
                            $"[UpdateVersions] Trying URL: {formattedUrl}",
                            Debug.Type.Notice, detailedOnly: true);
                        try
                        {
                            var response = client.DownloadString(formattedUrl);
                            successfulResponse = response;
                            successfulUrl = formattedUrl;
                            Debug.Log("Game: " + gameId,
                                $"[UpdateVersions] Download succeeded. URL: {formattedUrl} | Response length: {response.Length} chars | Protocol: {System.Net.ServicePointManager.SecurityProtocol}",
                                Debug.Type.Notice);
                        }
                        catch (WebException e)
                        {
                            var httpStatus = (e.Response as System.Net.HttpWebResponse)?.StatusCode;
                            Debug.Log("Game: " + gameId,
                                $"[UpdateVersions] WebException on URL: {formattedUrl}" +
                                $" | Status: {httpStatus?.ToString() ?? "N/A"}" +
                                $" | Protocol: {System.Net.ServicePointManager.SecurityProtocol}" +
                                $" | Error: {e.Message}" +
                                $" | Detail: {e}",
                                Debug.Type.Error);
                        }
                        catch (Exception e)
                        {
                            Debug.Log("Game: " + gameId,
                                $"[UpdateVersions] Unexpected error on URL: {formattedUrl}" +
                                $" | Type: {e.GetType().Name}" +
                                $" | Error: {e.Message}" +
                                $" | Detail: {e}",
                                Debug.Type.Error);
                        }
                    }
                }

                Debug.Log("Game: " + gameId,
                    $"[UpdateVersions] Download phase complete." +
                    $" Result: {(successfulResponse != null ? $"Success ({successfulUrl})" : "All servers failed")}",
                    Debug.Type.Notice);

                // ── 파싱 ──────────────────────────────────────────────────
                // 1순위 우선 — 처음 성공한 서버 응답 하나만 사용 (병합하지 않음)
                if (successfulResponse != null)
                {
                    try
                    {
                        var document = XDocument.Parse(successfulResponse);

                        var filesBefore = CheckFiles.Count;
                        var versionsBefore = VersionsList.Count;

                        foreach (var element in document.Root.Element("files").Elements("file"))
                        {
                            CheckFiles.Add(element.Value);
                        }
                        foreach (var element in document.Root.Elements("version"))
                        {
                            VersionsList.Add(new Version(element));
                        }

                        Debug.Log("Game: " + gameId,
                            $"[UpdateVersions] Parsed successfully." +
                            $" Files: {filesBefore} → {CheckFiles.Count}" +
                            $" | Versions: {versionsBefore} → {VersionsList.Count}",
                            Debug.Type.Notice);
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Game: " + gameId,
                            $"[UpdateVersions] Failed parsing VersionsData from server." +
                            $" | Type: {e.GetType().Name}" +
                            $" | Error: {e.Message}" +
                            $" | Detail: {e}",
                            Debug.Type.Error);
                    }

                    // ── 저장 ──────────────────────────────────────────────
                    try
                    {
                        var finalDocument = new XDocument(new XElement("VersionsData"));
                        finalDocument.Root.Add(new XElement("files", CheckFiles.Select(o => new XElement("file", o))));
                        foreach (var version in VersionsList.OrderBy(o => o.Id))
                        {
                            var element = new XElement("version", new XAttribute("id", version.Id));
                            element.Add(new XElement("checksum", version.CheckSum));
                            finalDocument.Root.Add(element);
                        }
                        finalDocument.Save(FileName);
                        Debug.Log("Game: " + gameId,
                            $"[UpdateVersions] VersionsData saved successfully. Path: {FileName}" +
                            $" | Total versions: {VersionsList.Count}" +
                            $" | Total files: {CheckFiles.Count}",
                            Debug.Type.Notice);
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Game: " + gameId,
                            $"[UpdateVersions] Failed saving VersionsData file. Path: {FileName}" +
                            $" | Type: {e.GetType().Name}" +
                            $" | Error: {e.Message}" +
                            $" | Detail: {e}",
                            Debug.Type.Error);
                    }
                }
                else
                {
                    Debug.Log("Game: " + gameId,
                        $"[UpdateVersions] No responses received from any server." +
                        $" Servers tried: {string.Join(", ", VersionUpdateDomains)}" +
                        $" | Protocol: {System.Net.ServicePointManager.SecurityProtocol}",
                        Debug.Type.Error);
                }
            }

            public struct Version : IEquatable<Version>
            {
                public static readonly Version Zero = default(Version);

                public string Id;
                public string CheckSum;

                public bool IsValid => !string.IsNullOrWhiteSpace(Id) && !string.IsNullOrWhiteSpace(CheckSum);

                public Version(string checkSum)
                {
                    Id = "Auto-Updated";
                    CheckSum = checkSum;
                }

                public Version(XElement element)
                {
                    Id = XmlHelper.GetXmlAttributeAsString(element, "id");
                    CheckSum = XmlHelper.GetXmlElementAsString(element, "checksum");
                }

                public bool Equals(Version other)
                {
                    return string.Equals(Id, other.Id) && string.Equals(CheckSum, other.CheckSum);
                }

                public override bool Equals(object obj)
                {
                    if (ReferenceEquals(null, obj))
                    {
                        return false;
                    }
                    return obj is Version && Equals((Version)obj);
                }

                public override int GetHashCode()
                {
                    unchecked
                    {
                        return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (CheckSum != null ? CheckSum.GetHashCode() : 0);
                    }
                }
            }
        }
    }
}