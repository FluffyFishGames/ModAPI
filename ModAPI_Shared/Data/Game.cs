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
            "http://modapi.cc/app/configs/games/{0}/Versions.xml",
            "http://modapi.survivetheforest.net/app/configs/games/{0}/Versions.xml"
        };

        public event EventHandler<EventArgs> OnModlibUpdate;

        public Configuration.GameConfiguration GameConfiguration;
        public List<Mod> Mods = new List<Mod>();
        public string GamePath = "";
        public bool Valid;
        public ModLib ModLibrary;

        protected bool RegenerateModLibrary;
        protected Dictionary<string, Mod> FileNameToMod = new Dictionary<string, Mod>();
        protected Versions versions;
        protected string CheckSumBackup;
        protected string CheckSumGame;
        protected string CheckSumModded;

        public Versions.Version BackupVersion;
        public Versions.Version GameVersion;

        public Game(Configuration.GameConfiguration GameConfiguration)
        {
            this.GameConfiguration = GameConfiguration;
            ModLibrary = new ModLib(this);
            GamePath = Configuration.GetPath("Games." + GameConfiguration.ID);
            Verify();
        }

        protected void GamePathSpecified()
        {
            Configuration.SetPath("Games." + GameConfiguration.ID, GamePath, true);
            Configuration.Save();
            Verify();
        }

        public void Verify()
        {
            Valid = true;

            /** Some files are missing. We need to schedule a task to specify a new path before we can continue. **/
            if (!CheckGamePath())
            {
                GamePath = FindGamePath();
                if (!CheckGamePath())
                {
                    Schedule.AddTask("GUI", "SpecifyGamePath", GamePathSpecified, new object[] { this }, CheckGamePath);
                    Valid = false;
                    return;
                }
            }

            Configuration.SetPath("Games." + GameConfiguration.ID, GamePath, true);

            if (versions == null)
            {
                versions = new Versions(this);
            }
            versions.Refresh();

            GenerateCheckSums();

            GameVersion = versions.GetVersion(CheckSumGame);
            BackupVersion = versions.GetVersion(CheckSumBackup);

            if (((GameVersion.IsValid && !BackupVersion.IsValid) || (GameVersion.IsValid && BackupVersion.IsValid && GameVersion.ID != BackupVersion.ID)))
            {
                BackupGameFiles();
                Thread.Sleep(1000);
                GenerateCheckSums();
                GameVersion = versions.GetVersion(CheckSumGame);
                BackupVersion = versions.GetVersion(CheckSumBackup);
                RegenerateModLibrary = true;
            }

            if ((CheckSumGame != CheckSumBackup && CheckSumGame != CheckSumModded) || (!GameVersion.IsValid && CheckSumModded != "" && CheckSumModded != CheckSumGame))
            {
                if (versions.VersionsList.Count == 0 || versions.VersionsList.All(o => o.CheckSum != CheckSumGame))
                {
                    Debug.Log("Game: " + GameConfiguration.ID, "Auto updating game with checksum: " + CheckSumGame);
                    versions.VersionsList.Add(new Versions.Version(CheckSumGame));

                    BackupGameFiles();
                    Thread.Sleep(1000);
                    GenerateCheckSums();
                    GameVersion = versions.GetVersion(CheckSumGame);
                    BackupVersion = versions.GetVersion(CheckSumBackup);
                    RegenerateModLibrary = true;
                }
                else
                {
                    Console.WriteLine("EH?");
                    Debug.Log("Game: " + GameConfiguration.ID, "Neither the game and modded checksum nor the game and backup checksum did match. Game checksum: " + CheckSumGame);
                    Schedule.AddTask("GUI", "RestoreGameFiles", Verify, new object[] { this });
                    Valid = false;
                    RegenerateModLibrary = true;
                    return;
                }
            }

            if (!ModLibrary.Exists || ModLibrary.ModAPIVersion != Version.Descriptor)
            {
                RegenerateModLibrary = true;
                Schedule.AddTask("SelectNewestModVersions", delegate { }, null);
            }

            if (RegenerateModLibrary)
            {
                CreateModLibrary(true);
            }
        }

        public void CreateModLibrary(bool AutoClose = false)
        {
            var progressHandler = new ProgressHandler();
            Schedule.AddTask("GUI", "OperationPending", null, new object[] { "CreatingModLibrary", progressHandler, null, AutoClose });
            var t = new Thread(delegate()
            {
                ModLibrary.Create(progressHandler);
                if (OnModlibUpdate != null)
                {
                    OnModlibUpdate(this, new EventArgs());
                }
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
                var GameFolder = GamePath;
                if ((File.GetAttributes(GamePath) & FileAttributes.Directory) != FileAttributes.Directory)
                {
                    GameFolder = System.IO.Path.GetDirectoryName(GameFolder);
                }
                return GameFolder;
            }
            return "";
        }

        protected void BackupGameFiles()
        {
            var progressHandler = new ProgressHandler();
            progressHandler.Task = "CreatingBackup";
            Schedule.AddTask("GUI", "OperationPending", null, new object[] { "BackupGameFiles", progressHandler, null, true });

            var t = new Thread(delegate()
            {
                var GameFolder = GetGameFolder();
                foreach (var n in GameConfiguration.IncludeAssemblies)
                {
                    var path = System.IO.Path.GetFullPath(GameFolder + System.IO.Path.DirectorySeparatorChar + ParsePath(n));
                    var backupPath = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
                                                                System.IO.Path.DirectorySeparatorChar + ParsePath(n));
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(backupPath));
                    File.Copy(path, backupPath, true);
                }
                foreach (var n in GameConfiguration.CopyAssemblies)
                {
                    var path = System.IO.Path.GetFullPath(GameFolder + System.IO.Path.DirectorySeparatorChar + ParsePath(n));
                    var backupPath = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
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
            var GameFolder = GetGameFolder();
            var digester = MD5.Create();
            foreach (var p in versions.CheckFiles)
            {
                var gamePath = System.IO.Path.GetFullPath(GameFolder + System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                var backupPath = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
                                                            System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                var moddedPath = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
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
            var GameFolder = GetGameFolder();
            foreach (var n in GameConfiguration.IncludeAssemblies)
            {
                var path = System.IO.Path.GetFullPath(GameFolder + System.IO.Path.DirectorySeparatorChar + ParsePath(n));
                if (!File.Exists(path))
                {
                    Debug.Log("Required file \"" + path + "\" couldn't be found.", Debug.Type.WARNING);
                    return false;
                }
            }
            foreach (var n in GameConfiguration.CopyAssemblies)
            {
                var path = System.IO.Path.GetFullPath(GameFolder + System.IO.Path.DirectorySeparatorChar + ParsePath(n));
                if (!File.Exists(path))
                {
                    Debug.Log("Required file \"" + path + "\" couldn't be found.", Debug.Type.WARNING);
                    return false;
                }
            }
            return true;
        }

        public string[] GetIncludedAssemblies()
        {
            var GameFolder = GetGameFolder();
            var ret = new string[GameConfiguration.IncludeAssemblies.Count];
            for (var i = 0; i < GameConfiguration.IncludeAssemblies.Count; i++)
            {
                var n = GameConfiguration.IncludeAssemblies[i];
                var path = System.IO.Path.GetFullPath(GameFolder + System.IO.Path.DirectorySeparatorChar + ParsePath(n));
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

        public void ApplyMods(List<Mod> Mods, ProgressHandler handler)
        {
            try
            {
                if (Mods.Count == 0)
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

                var LibraryFolder = ModLibrary.GetLibraryFolder();

                var baseModLibPath = LibraryFolder + System.IO.Path.DirectorySeparatorChar + "BaseModLib.dll";
                var baseModLib = ModuleDefinition.ReadModule(baseModLibPath);
                var LogType = baseModLib.GetType("ModAPI.Log");
                var BaseSystemType = baseModLib.GetType("ModAPI.BaseSystem");
                MethodReference InitializeMethod = null;
                MethodReference LogMethod = null;

                var ConfigurationAttributes = new Dictionary<string, TypeDefinition>();
                foreach (var modLibType in baseModLib.Types)
                {
                    if (modLibType.BaseType != null && modLibType.BaseType.Name == "ConfigurationAttribute")
                    {
                        ConfigurationAttributes.Add(modLibType.FullName, modLibType);
                    }
                }

                foreach (var modLibMethod in LogType.Methods)
                {
                    if (modLibMethod.Name == "Write" && modLibMethod.Parameters.Count == 2 && modLibMethod.Parameters[0].ParameterType.FullName == "System.String" &&
                        modLibMethod.Parameters[1].ParameterType.FullName == "System.String")
                    {
                        LogMethod = modLibMethod;
                        break;
                    }
                }
                foreach (var modLibMethod in BaseSystemType.Methods)
                {
                    if (modLibMethod.Name == "Initialize")
                    {
                        InitializeMethod = modLibMethod;
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

                var assemblyResolver = new CustomAssemblyResolver();
                assemblyResolver.AddPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
                                         System.IO.Path.DirectorySeparatorChar);

                var SearchFolders = new List<string>();
                for (var i = 0; i < GameConfiguration.IncludeAssemblies.Count; i++)
                {
                    var assemblyPath = Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
                                       System.IO.Path.DirectorySeparatorChar + ParsePath(GameConfiguration.IncludeAssemblies[i]);
                    var folder = System.IO.Path.GetDirectoryName(assemblyPath);
                    if (!SearchFolders.Contains(folder))
                    {
                        Debug.Log("ModLib: " + GameConfiguration.ID, "Added folder \"" + folder + "\" to assembly resolver.");
                        SearchFolders.Add(folder);
                    }
                }
                for (var i = 0; i < GameConfiguration.CopyAssemblies.Count; i++)
                {
                    var assemblyPath = Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
                                       System.IO.Path.DirectorySeparatorChar + ParsePath(GameConfiguration.CopyAssemblies[i]);
                    var folder = System.IO.Path.GetDirectoryName(assemblyPath);
                    if (!SearchFolders.Contains(folder))
                    {
                        Debug.Log("ModLib: " + GameConfiguration.ID, "Added folder \"" + folder + "\" to assembly resolver.");
                        SearchFolders.Add(folder);
                    }
                }
                for (var i = 0; i < SearchFolders.Count; i++)
                {
                    assemblyResolver.AddPath(SearchFolders[i]);
                }

                foreach (var p in GameConfiguration.IncludeAssemblies)
                {
                    var path = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
                                                          System.IO.Path.DirectorySeparatorChar + ParsePath(p));
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
                        var path = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
                                                              System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                        var key = System.IO.Path.GetFileNameWithoutExtension(path);

                        if ((key == "mscorlib" && !Assemblies.ContainsKey("mscorlib")) || (key == "UnityEngine" && !Assemblies.ContainsKey("UnityEngine")))
                        {
                            var module = ModuleDefinition.ReadModule(path);
                            Assemblies.Add(key, module);
                        }
                    }
                }

                SetProgress(handler, 5f);
                var UnityEngineObject = Assemblies["UnityEngine"].GetType("UnityEngine.Object");
                var UnityEngineApplication = Assemblies["UnityEngine"].GetType("UnityEngine.Application");
                var UnityEngineComponent = Assemblies["UnityEngine"].GetType("UnityEngine.Component");

                var SystemAppDomain = Assemblies["mscorlib"].GetType("System.AppDomain");
                var SystemResolveEventHandler = Assemblies["mscorlib"].GetType("System.ResolveEventHandler");
                var SystemResolveEventArgs = Assemblies["mscorlib"].GetType("System.ResolveEventArgs");
                var SystemReflectionAssembly = Assemblies["mscorlib"].GetType("System.Reflection.Assembly");
                var SystemReflectionAssemblyName = Assemblies["mscorlib"].GetType("System.Reflection.AssemblyName");
                var SystemString = Assemblies["mscorlib"].GetType("System.String");
                var SystemIOFile = Assemblies["mscorlib"].GetType("System.IO.File");
                MethodDefinition SystemAppDomainGetCurrentDomain = null;
                MethodDefinition SystemAppDomainAddAssemblyResolve = null;
                MethodDefinition SystemResolveEventArgsGetName = null;
                MethodDefinition SystemResolveEventHandlerCtor = null;
                MethodDefinition SystemReflectionAssemblyNameCtor = null;
                MethodDefinition SystemReflectionAssemblyNameGetName = null;
                MethodDefinition SystemStringFormat = null;
                MethodDefinition SystemStringConcat = null;
                MethodDefinition SystemReflectionAssemblyLoadFrom = null;
                MethodDefinition UnityEngineApplicationGetDataPath = null;
                MethodDefinition SystemIOFileWriteAllText = null;

                foreach (var m in UnityEngineApplication.Methods)
                {
                    if (m.Name == "get_dataPath")
                    {
                        UnityEngineApplicationGetDataPath = m;
                    }
                }

                foreach (var m in SystemIOFile.Methods)
                {
                    if (m.Name == "WriteAllText" && m.Parameters.Count == 2)
                    {
                        SystemIOFileWriteAllText = m;
                    }
                }
                foreach (var m in SystemAppDomain.Methods)
                {
                    if (m.Name == "get_CurrentDomain")
                    {
                        SystemAppDomainGetCurrentDomain = m;
                    }
                    if (m.Name == "add_AssemblyResolve")
                    {
                        SystemAppDomainAddAssemblyResolve = m;
                    }
                }
                foreach (var m in SystemResolveEventHandler.Methods)
                {
                    if (m.IsConstructor && m.Parameters.Count == 2 && m.Parameters[0].ParameterType.FullName == "System.Object")
                    {
                        SystemResolveEventHandlerCtor = m;
                    }
                }
                foreach (var m in SystemResolveEventArgs.Methods)
                {
                    if (m.Name == "get_Name")
                    {
                        SystemResolveEventArgsGetName = m;
                    }
                }
                foreach (var m in SystemReflectionAssembly.Methods)
                {
                    if (m.Name == "LoadFrom" && m.Parameters.Count == 1 && m.Parameters[0].ParameterType.FullName == "System.String")
                    {
                        SystemReflectionAssemblyLoadFrom = m;
                    }
                }
                foreach (var m in SystemReflectionAssemblyName.Methods)
                {
                    if (m.IsConstructor && m.Parameters.Count == 1 && m.Parameters[0].ParameterType.FullName == "System.String")
                    {
                        SystemReflectionAssemblyNameCtor = m;
                    }
                    if (m.Name == "get_Name")
                    {
                        SystemReflectionAssemblyNameGetName = m;
                    }
                }
                foreach (var m in SystemString.Methods)
                {
                    if (m.Name == "Format" && m.Parameters.Count == 2 && m.Parameters[0].ParameterType.FullName == "System.String" && m.Parameters[1].ParameterType.FullName == "System.Object")
                    {
                        SystemStringFormat = m;
                    }
                    if (m.Name == "Concat" && m.Parameters.Count == 2 && m.Parameters[0].ParameterType.FullName == "System.String" && m.Parameters[1].ParameterType.FullName == "System.String")
                    {
                        SystemStringConcat = m;
                    }
                }

                var ResolveModAssembly = new MethodDefinition("ResolveModAssembly", MethodAttributes.HideBySig | MethodAttributes.Private | MethodAttributes.Static,
                    Assemblies["UnityEngine"].Import(SystemReflectionAssembly));
                ResolveModAssembly.Parameters.Add(new ParameterDefinition("sender", ParameterAttributes.None, Assemblies["UnityEngine"].TypeSystem.Object));
                ResolveModAssembly.Parameters.Add(new ParameterDefinition("e", ParameterAttributes.None, Assemblies["UnityEngine"].Import(SystemResolveEventArgs)));

                if (ResolveModAssembly.Body == null)
                {
                    ResolveModAssembly.Body = new MethodBody(ResolveModAssembly);
                }

                ResolveModAssembly.Body.Variables.Add(new VariableDefinition("filename", Assemblies["UnityEngine"].TypeSystem.String));
                ResolveModAssembly.Body.Variables.Add(new VariableDefinition("path", Assemblies["UnityEngine"].TypeSystem.String));
                ResolveModAssembly.Body.Variables.Add(new VariableDefinition("ret", Assemblies["UnityEngine"].Import(SystemReflectionAssembly)));

                var _processor = ResolveModAssembly.Body.GetILProcessor();
                var _tryStart = _processor.Create(OpCodes.Ldarg_1);
                _processor.Append(_tryStart);
                _processor.Append(_processor.Create(OpCodes.Callvirt, Assemblies["UnityEngine"].Import(SystemResolveEventArgsGetName)));
                _processor.Append(_processor.Create(OpCodes.Newobj, Assemblies["UnityEngine"].Import(SystemReflectionAssemblyNameCtor)));
                _processor.Append(_processor.Create(OpCodes.Call, Assemblies["UnityEngine"].Import(SystemReflectionAssemblyNameGetName)));
                _processor.Append(_processor.Create(OpCodes.Stloc_0));
                _processor.Append(_processor.Create(OpCodes.Call, UnityEngineApplicationGetDataPath));
                _processor.Append(_processor.Create(OpCodes.Ldstr, "/../Mods/{0}.dll"));
                _processor.Append(_processor.Create(OpCodes.Call, Assemblies["UnityEngine"].Import(SystemStringConcat)));
                _processor.Append(_processor.Create(OpCodes.Ldloc_0));
                _processor.Append(_processor.Create(OpCodes.Call, Assemblies["UnityEngine"].Import(SystemStringFormat)));
                _processor.Append(_processor.Create(OpCodes.Stloc_1));

                _processor.Append(_processor.Create(OpCodes.Ldstr, "test.txt"));
                _processor.Append(_processor.Create(OpCodes.Ldloc_1));
                _processor.Append(_processor.Create(OpCodes.Call, Assemblies["UnityEngine"].Import(SystemIOFileWriteAllText)));

                _processor.Append(_processor.Create(OpCodes.Ldloc_1));
                _processor.Append(_processor.Create(OpCodes.Call, Assemblies["UnityEngine"].Import(SystemReflectionAssemblyLoadFrom)));
                _processor.Append(_processor.Create(OpCodes.Stloc_2));

                var exitPoint = _processor.Create(OpCodes.Ldloc_2);
                _processor.Append(exitPoint);
                _processor.Append(_processor.Create(OpCodes.Ret));

                _processor.InsertBefore(exitPoint, _processor.Create(OpCodes.Leave, exitPoint));
                var _tryEnd = _processor.Create(OpCodes.Pop);
                _processor.InsertBefore(exitPoint, _tryEnd);
                _processor.InsertBefore(exitPoint, _processor.Create(OpCodes.Ldnull));
                _processor.InsertBefore(exitPoint, _processor.Create(OpCodes.Stloc_2));
                _processor.InsertBefore(exitPoint, _processor.Create(OpCodes.Leave, exitPoint));

                var _exceptionHandler = new ExceptionHandler(ExceptionHandlerType.Catch);
                _exceptionHandler.TryStart = _tryStart;
                _exceptionHandler.TryEnd = _tryEnd;
                _exceptionHandler.HandlerStart = _tryEnd;
                _exceptionHandler.HandlerEnd = exitPoint;
                _exceptionHandler.CatchType = Assemblies["UnityEngine"].Import(Assemblies["mscorlib"].GetType("System.Exception"));
                ResolveModAssembly.Body.ExceptionHandlers.Add(_exceptionHandler);

                UnityEngineApplication.Methods.Add(ResolveModAssembly);

                var ctorMethod = new MethodDefinition(".cctor",
                    MethodAttributes.SpecialName | MethodAttributes.RTSpecialName | MethodAttributes.HideBySig | MethodAttributes.Private | MethodAttributes.Static,
                    Assemblies["UnityEngine"].TypeSystem.Void);

                _processor = ctorMethod.Body.GetILProcessor();
                var last = _processor.Create(OpCodes.Ret);
                _processor.Append(last);
                _processor.InsertBefore(last, _processor.Create(OpCodes.Call, Assemblies["UnityEngine"].Import(SystemAppDomainGetCurrentDomain)));
                _processor.InsertBefore(last, _processor.Create(OpCodes.Ldnull));
                _processor.InsertBefore(last, _processor.Create(OpCodes.Ldftn, ResolveModAssembly));
                _processor.InsertBefore(last, _processor.Create(OpCodes.Newobj, Assemblies["UnityEngine"].Import(SystemResolveEventHandlerCtor)));
                _processor.InsertBefore(last, _processor.Create(OpCodes.Callvirt, Assemblies["UnityEngine"].Import(SystemAppDomainAddAssemblyResolve)));

                UnityEngineApplication.Methods.Add(ctorMethod);

                foreach (var method in UnityEngineComponent.Methods)
                {
                    if ((method.Name == "GetComponent" || method.Name == "GetComponentInChildren" || method.Name == "GetComponentsInChildren" || method.Name == "GetComponentsInParent" ||
                         method.Name == "get_gameObject" || method.Name == "get_transform" || method.Name == "GetComponents" || method.Name == "SendMessageUpwards" || method.Name == "SendMessage" ||
                         method.Name == "BroadcastMessage") && !method.IsInternalCall)
                    {
                        _processor = method.Body.GetILProcessor();
                        last = method.Body.Instructions[0];
                        _processor.InsertBefore(last, _processor.Create(OpCodes.Call, Assemblies["UnityEngine"].Import(InitializeMethod)));
                    }
                }

                SetProgress(handler, 10f);

                var modTools = new Dictionary<string, MethodDefinition>();
                var InjectToType = new Dictionary<string, TypeDefinition>();
                var InjectToMethod = new Dictionary<string, MethodDefinition>();

                var injectIntos = new Dictionary<string, Dictionary<int, List<Mod.Header.InjectInto>>>();
                var addMethods = new Dictionary<string, List<Mod.Header.AddMethod>>();
                var addFields = new Dictionary<string, List<Mod.Header.AddField>>();
                var addedTypes = new Dictionary<string, List<TypeDefinition>>();

                var AddedClasses = new Dictionary<TypeReference, TypeDefinition>();
                var AddedFields = new Dictionary<FieldReference, FieldDefinition>();
                var AddedMethods = new Dictionary<MethodReference, MethodDefinition>();
                var InjectedMethods = new Dictionary<MethodReference, MethodDefinition>();
                var NewMethods = new Dictionary<MethodReference, MethodDefinition>();
                var TypesMap = new Dictionary<TypeReference, TypeReference>();

                var AddReferences = new Dictionary<string, AssemblyNameReference>();

                var InsertConstructor = new Dictionary<TypeDefinition, TypeDefinition>();

                var ModConfigurations = new Dictionary<string, XElement>();
                var c = 0;
                foreach (var mod in Mods)
                {
                    mod.RewindModule();
                    var modConfiguration = new XElement("Mod");
                    ModConfigurations.Add(mod.ID, modConfiguration);
                    modConfiguration.SetAttributeValue("ID", mod.ID);
                    modConfiguration.SetAttributeValue("UniqueID", mod.UniqueID);
                    modConfiguration.SetAttributeValue("Version", mod.header.GetVersion());

                    foreach (var button in mod.header.GetButtons())
                    {
                        var AssignedKey = Configuration.GetString("Mods." + GameConfiguration.ID + "." + mod.ID + ".Buttons." + button.ID);
                        if (AssignedKey == "")
                        {
                            AssignedKey = button.StandardKey;
                        }
                        var buttonConfiguration = new XElement("Button");
                        buttonConfiguration.SetAttributeValue("ID", button.ID);
                        buttonConfiguration.Value = AssignedKey;
                        modConfiguration.Add(buttonConfiguration);
                    }

                    modsConfiguration.Root.Add(modConfiguration);
                    addedTypes.Add(mod.ID, new List<TypeDefinition>());
                    foreach (var addClass in mod.header.GetAddClasses())
                    {
                        foreach (var m in addClass.Type.Methods)
                        {
                            MonoHelper.ParseCustomAttributes(addClass.Mod, modsConfiguration, m, ConfigurationAttributes);
                        }

                        addedTypes[mod.ID].Add(addClass.Type);
                        AddedClasses.Add(addClass.Type, addClass.Type);
                    }

                    foreach (var addMethod in mod.header.GetAddMethods())
                    {
                        if (!TypesMap.ContainsKey(addMethod.Method.DeclaringType))
                        {
                            TypesMap.Add(addMethod.Method.DeclaringType, Assemblies[addMethod.AssemblyName].GetType(addMethod.TypeName));
                        }

                        var key = addMethod.AssemblyName + "::" + addMethod.TypeName;
                        if (!addMethods.ContainsKey(key))
                        {
                            addMethods.Add(key, new List<Mod.Header.AddMethod>());
                        }
                        addMethods[key].Add(addMethod);
                    }

                    foreach (var addField in mod.header.GetAddFields())
                    {
                        if (!TypesMap.ContainsKey(addField.Field.DeclaringType))
                        {
                            TypesMap.Add(addField.Field.DeclaringType, Assemblies[addField.AssemblyName].GetType(addField.TypeName));
                        }

                        var key = addField.AssemblyName + "::" + addField.TypeName;
                        if (!addFields.ContainsKey(key))
                        {
                            addFields.Add(key, new List<Mod.Header.AddField>());
                        }
                        addFields[key].Add(addField);
                    }

                    foreach (var injectInto in mod.header.GetInjectIntos())
                    {
                        if (!TypesMap.ContainsKey(injectInto.Method.DeclaringType))
                        {
                            TypesMap.Add(injectInto.Method.DeclaringType, Assemblies[injectInto.AssemblyName].GetType(injectInto.TypeName));
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

                    foreach (var entry in TypesMap)
                    {
                        Debug.Log("Game: " + GameConfiguration.ID, "Type entry: " + entry.Key.FullName + " - " + entry.Value.FullName);
                    }

                    /*foreach (Mod.Header.AddClass addClass in mod.header.GetAddClasses()) 
                    {
                        string key = mod.ID;
                        if (!addClasses.ContainsKey(key))
                            addClasses.Add(key, new List<Mod.Header.AddClass>());
                        addClasses[key].Add(addClass);
                    }*/
                    c++;
                    SetProgress(handler, 10f + (c / (float) Mods.Count) * 20f, "FetchingInjections");
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
                        AddedFields.Add(field.Field, newField);
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
                        MonoHelper.ParseCustomAttributes(method.Mod, modsConfiguration, newMethod, ConfigurationAttributes);
                        AddedMethods.Add(method.Method, newMethod);
                    }
                }
                SetProgress(handler, 40f);

                MethodReference methodObjectToString = null;
                MethodReference methodStringConcat = null;
                MethodReference methodExceptionConstructor = null;
                TypeReference typeException = null;
                foreach (var _m in Assemblies["mscorlib"].GetType("System.Object").Methods)
                {
                    if (_m.Name == "ToString")
                    {
                        methodObjectToString = _m;
                    }
                }
                foreach (var _m in Assemblies["mscorlib"].GetType("System.String").Methods)
                {
                    if (_m.Name == "Concat" && _m.Parameters.Count == 2 && _m.Parameters[0].ParameterType.Name == "String" && _m.Parameters[1].ParameterType.Name == "String")
                    {
                        methodStringConcat = _m;
                    }
                }
                typeException = Assemblies["mscorlib"].GetType("System.Exception");
                foreach (var _m in Assemblies["mscorlib"].GetType("System.Exception").Methods)
                {
                    if (_m.IsConstructor && _m.Parameters.Count == 1 && _m.Parameters[0].ParameterType.Name == "String")
                    {
                        methodExceptionConstructor = _m;
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
                    var Method = "";
                    var ReturnType = "";
                    var Parameters = new string[0];
                    NameResolver.Parse(parts[1], ref Namespace, ref Type, ref Method, ref ReturnType, ref Parameters);

                    var FullTypeName = Namespace + (Namespace != "" ? "." : "") + Type;
                    var type = Assemblies[parts[0]].GetType(FullTypeName);

                    MethodDefinition lastMethod = null;
                    MethodDefinition originalMethod = null;
                    var originalMethodFullName = "";
                    if (type.IsAbstract && type.IsSealed && path.Contains(".ctor"))
                    {
                        // Skip instance constructors of static classes
                        continue;
                    }
                    foreach (var _method in type.Methods)
                    {
                        if (_method.Name == Method && _method.Parameters.Count == Parameters.Length && _method.ReturnType.FullName == ReturnType)
                        {
                            var ok = true;
                            for (var i = 0; i < _method.Parameters.Count; i++)
                            {
                                if (_method.Parameters[i].ParameterType.FullName != Parameters[i])
                                {
                                    ok = false;
                                    break;
                                }
                            }
                            if (ok)
                            {
                                originalMethod = _method;
                                originalMethodFullName = originalMethod.FullName;
                                break;
                            }
                        }
                    }

                    var priorities = kv.Value.Keys.ToList();
                    priorities.Sort();

                    var objectToString = Assemblies[parts[0]].Import(methodObjectToString);
                    var stringConcat = Assemblies[parts[0]].Import(methodStringConcat);
                    var exceptionConstructor = Assemblies[parts[0]].Import(methodExceptionConstructor);
                    var exception = Assemblies[parts[0]].Import(typeException);

                    var ConstructorInstructions = new List<Instruction>();
                    var StaticConstructorInstructions = new List<Instruction>();

                    var num = 0;
                    foreach (var prio in priorities)
                    {
                        foreach (var injectInto in kv.Value[prio])
                        {
                            var newMethod = MonoHelper.CopyMethod(injectInto.Method);
                            if (newMethod.IsConstructor)
                            {
                                foreach (var currInstruction in newMethod.Body.Instructions)
                                {
                                    if (currInstruction.OpCode.Code != Code.Ret && !(currInstruction.OpCode.Code == Code.Call &&
                                                                                     (((MethodReference) currInstruction.Operand).Name == ".ctor" ||
                                                                                      ((MethodReference) currInstruction.Operand).Name == ".cctor")))
                                    {
                                        originalMethod.Body.GetILProcessor().Append(currInstruction);
                                    }
                                }
                                InjectedMethods.Add(newMethod, originalMethod);
                            }
                            /*else if (originalMethod.IsStatic)
                            {
                                continue;

                                newMethod.Attributes = originalMethod.Attributes;
                                newMethod.IsFamily = originalMethod.IsFamily;
                                newMethod.IsPublic = originalMethod.IsPublic;
                                newMethod.IsPrivate = originalMethod.IsPrivate;
                                newMethod.IsVirtual = originalMethod.IsVirtual;
                                newMethod.IsStatic = originalMethod.IsStatic;

                                type.Methods.Remove(originalMethod);
                                originalMethod = newMethod;

                                type.Methods.Add(originalMethod);
                                InjectedMethods.Add(originalMethod, originalMethod);
                                NewMethods.Add(originalMethod, originalMethod);
                            }*/
                            else
                            {
                                newMethod.Attributes = originalMethod.Attributes;
                                newMethod.IsFamily = originalMethod.IsFamily;
                                newMethod.IsPublic = originalMethod.IsPublic;
                                newMethod.IsPrivate = originalMethod.IsPrivate;
                                newMethod.IsVirtual = originalMethod.IsVirtual;
                                newMethod.IsStatic = originalMethod.IsStatic;

                                newMethod.Name = newMethod.Name + "__" + num;
                                num += 1;

                                var isReturningValue = newMethod.ReturnType.FullName != "System.Void";
                                VariableDefinition returnVariable = null;

                                foreach (var currInstruction in newMethod.Body.Instructions)
                                {
                                    if (currInstruction.OpCode.Code == Code.Call && (currInstruction.Operand is MethodReference) &&
                                        ((MethodReference) currInstruction.Operand).FullName == originalMethodFullName)
                                    {
                                        currInstruction.Operand = lastMethod ?? originalMethod;
                                    }
                                }
                                var returnInstruction = newMethod.Body.Instructions[newMethod.Body.Instructions.Count - 1];
                                var lastInstruction = newMethod.Body.Instructions[newMethod.Body.Instructions.Count - (isReturningValue ? 2 : 1)];

                                var tryStart = newMethod.Body.Instructions[0];

                                if (isReturningValue)
                                {
                                    if (newMethod.Body.Variables.Count == 0)
                                    {
                                        Debug.Log("Game: " + GameConfiguration.ID, "newMethod.Name = " + newMethod.Name);
                                        Debug.Log("Game: " + GameConfiguration.ID, "newMethod.FullName = " + newMethod.FullName);
                                        Debug.Log("Game: " + GameConfiguration.ID, "newMethod.Attributes = " + newMethod.Attributes);
                                        Debug.Log("Game: " + GameConfiguration.ID, "newMethod.ReturnType.FullName = " + newMethod.ReturnType.FullName);
                                        Debug.Log("Game: " + GameConfiguration.ID, "injectInto.Method.Body.Variables.Count = " + injectInto.Method.Body.Variables.Count);
                                        Debug.Log("Game: " + GameConfiguration.ID, "injectInto.Method.Body.Variables = " + injectInto.Method.Body.Variables);

                                        //Assemblies[injectInto.AssemblyName].GetType(injectInto.TypeName).Module.Import(newMethod.ReturnType).Resolve();
                                        //newMethod.Module.Import(newMethod.ReturnType).Resolve();
                                        returnVariable = new VariableDefinition(newMethod.ReturnType);
                                    }
                                    else
                                    {
                                        returnVariable = newMethod.Body.Variables[newMethod.Body.Variables.Count - 1];
                                    }
                                }
                                var exceptionVariable = new VariableDefinition("___ModAPIException___", exception);
                                newMethod.Body.Variables.Add(exceptionVariable);

                                var ilProcessor = newMethod.Body.GetILProcessor();
                                var handlerStart = ilProcessor.Create(OpCodes.Stloc, exceptionVariable);

                                var tryEnd = ilProcessor.Create(OpCodes.Leave, lastInstruction);
                                ilProcessor.InsertBefore(lastInstruction, tryEnd);
                                ilProcessor.InsertBefore(lastInstruction, handlerStart);
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldstr, "Exception thrown: "));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldloc, exceptionVariable));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Callvirt, objectToString));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Call, stringConcat));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldstr, injectInto.Mod.ID));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Call, LogMethod));
                                if (!originalMethod.IsStatic)
                                {
                                    ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldarg_0));
                                }

                                foreach (var param in originalMethod.Parameters)
                                {
                                    ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldarg, param));
                                }
                                ilProcessor.InsertBefore(lastInstruction, lastMethod != null ? ilProcessor.Create(OpCodes.Call, lastMethod) : ilProcessor.Create(OpCodes.Call, originalMethod));
                                if (isReturningValue)
                                {
                                    ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Stloc, returnVariable));
                                }
                                var handlerEnd = ilProcessor.Create(OpCodes.Leave, lastInstruction);
                                ilProcessor.InsertBefore(lastInstruction, handlerEnd);

                                var exHandler = new ExceptionHandler(ExceptionHandlerType.Catch)
                                {
                                    TryStart = tryStart,
                                    TryEnd = handlerStart,
                                    HandlerStart = handlerStart,
                                    HandlerEnd = lastInstruction,
                                    CatchType = exception
                                };
                                newMethod.Body.ExceptionHandlers.Add(exHandler);

                                lastMethod = newMethod;
                                type.Methods.Add(newMethod);
                                InjectedMethods.Add(newMethod, newMethod);
                            }
                        }
                    }
                    if ( /*!originalMethod.IsStatic &&*/ !originalMethod.IsConstructor)
                    {
                        lastMethod.Name = originalMethod.Name;
                        originalMethod.Name = "__" + Method + "__Original";
                    }

                    //if (!originalMethod.IsStatic)
                    {
                        NewMethods.Add(originalMethod, lastMethod);
                    }
                }
                SetProgress(handler, 50f, "Resolving");

                /** RESOLVE ALL LINKS **/
                foreach (var method in AddedMethods.Values)
                {
                    MonoHelper.Resolve(method.Module, method, AddedClasses, AddedFields, AddedMethods, InjectedMethods, TypesMap);
                }

                foreach (var method in InjectedMethods.Values)
                {
                    MonoHelper.Resolve(method.Module, method, AddedClasses, AddedFields, AddedMethods, InjectedMethods, TypesMap);
                }

                foreach (var field in AddedFields.Values)
                {
                    MonoHelper.Resolve(field.Module, field, AddedClasses, TypesMap);
                }

                var modFolder = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
                                                           System.IO.Path.DirectorySeparatorChar + "Mods" + System.IO.Path.DirectorySeparatorChar);
                var assemblyFolder = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
                                                                System.IO.Path.DirectorySeparatorChar + ParsePath(GameConfiguration.AssemblyPath)) + System.IO.Path.DirectorySeparatorChar;
                if (!Directory.Exists(assemblyFolder))
                {
                    Directory.CreateDirectory(assemblyFolder);
                }
                if (!Directory.Exists(modFolder))
                {
                    Directory.CreateDirectory(modFolder);
                }

                foreach (var mod in Mods)
                {
                    var modModule = mod.GetModuleCopy();
                    for (var j = 0; j < modModule.Types.Count; j++)
                    {
                        var t = modModule.Types[j];
                        foreach (var m in t.Methods)
                        {
                            MonoHelper.Resolve(m.Module, m, AddedClasses, AddedFields, AddedMethods, InjectedMethods, TypesMap);
                        }
                    }
                    for (var j = 0; j < modModule.Types.Count; j++)
                    {
                        var t = modModule.Types[j];
                        var keep = false;
                        foreach (var type in addedTypes[mod.ID])
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
                        zip.Save(modFolder + mod.ID + ".resources");
                        ModConfigurations[mod.ID].SetAttributeValue("HasResources", "true");
                    }
                }

                SetProgress(handler, 80f, "Saving");
                File.Copy(
                    baseModLibPath,
                    System.IO.Path.GetFullPath(assemblyFolder + System.IO.Path.DirectorySeparatorChar + "BaseModLib.dll"),
                    true);
                foreach (var p in GameConfiguration.IncludeAssemblies)
                {
                    var path = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
                                                          System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                    var folder = System.IO.Path.GetDirectoryName(path);
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    var key = System.IO.Path.GetFileNameWithoutExtension(path);

                    var module = Assemblies[key];
                    for (var i = 0; i < module.AssemblyReferences.Count; i++)
                    {
                        // @HOTFIX: Remove unwanted references to mscorlib 2.0.5.0
                        if (module.AssemblyReferences[i].Name == "mscorlib" && module.AssemblyReferences[i].Version.ToString() == "2.0.5.0")
                        {
                            module.AssemblyReferences.RemoveAt(i);
                            i--;
                        }
                    }
                    foreach (var type in module.Types)
                    {
                        foreach (var subType in type.NestedTypes)
                        {
                            foreach (var method2 in subType.Methods)
                            {
                                MonoHelper.Remap(module, method2, NewMethods);
                            }
                        }
                        foreach (var method in type.Methods)
                        {
                            MonoHelper.Remap(module, method, NewMethods);
                        }
                    }
                    module.Write(path);
                }

                foreach (var p in GameConfiguration.CopyAssemblies)
                {
                    var path = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
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
                    "System.Xml.Linq.dll"
                };
                foreach (var ass in assemblies)
                {
                    var assPath = System.IO.Path.GetFullPath(Configuration.GetPath("Libraries") + System.IO.Path.DirectorySeparatorChar + ass);
                    if (File.Exists(assPath))
                    {
                        File.Copy(assPath, System.IO.Path.GetFullPath(assemblyFolder + ass), true);
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
                Debug.Log("ModLoader: " + GameConfiguration.ID, "An exception occured: " + e, Debug.Type.ERROR);
                SetProgress(handler, "Error.Unexpected");
                //Communicator.Error(e.ToString());
            }
        }

        private bool RemoveModdedFiles()
        {
            try
            {
                var OutputFolder = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
                                                              System.IO.Path.DirectorySeparatorChar);
                if (!Directory.Exists(OutputFolder))
                {
                    return true;
                }
                var oldFiles = Directory.GetFiles(OutputFolder);
                foreach (var file in oldFiles)
                {
                    File.Delete(file);
                }
                var oldDirectories = Directory.GetDirectories(OutputFolder);
                foreach (var directory in oldDirectories)
                {
                    Directory.Delete(directory, true);
                }
                return true;
            }
            catch (Exception e2)
            {
                Debug.Log("ModLoader: " + GameConfiguration.ID, "Could not remove modded files: " + e2, Debug.Type.ERROR);
                return false;
            }
        }

        private bool ApplyOriginalFiles()
        {
            try
            {
                var OriginalFolder = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID +
                                                                System.IO.Path.DirectorySeparatorChar);
                /*string[] originalFiles = System.IO.Directory.GetFiles(OriginalFolder);
                foreach (string file in originalFiles)
                    System.IO.File.Copy(file, GamePath + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetFileName(file));
                string[] originalDirectories = System.IO.Directory.GetDirectories(OriginalFolder);
                foreach (string directory in originalDirectories)*/
                DirectoryCopy(OriginalFolder, GamePath, true);
                return true;
            }
            catch (Exception e2)
            {
                Debug.Log("ModLoader: " + GameConfiguration.ID, "Could not apply original files to game: " + e2, Debug.Type.ERROR);
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

            public Versions(Game Game)
            {
                FileName = Configuration.GetPath("Configurations") + System.IO.Path.DirectorySeparatorChar + "games" + System.IO.Path.DirectorySeparatorChar + Game.GameConfiguration.ID +
                           System.IO.Path.DirectorySeparatorChar +
                           "Versions.xml";
                this.Game = Game;
            }

            public Version GetVersion(string CheckSum)
            {
                if (CheckSum == "")
                {
                    return Version.Zero;
                }
                foreach (var v in VersionsList)
                {
                    if (string.Equals(v.CheckSum, CheckSum, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return v;
                    }
                }
                return Version.Zero;
            }

            public void Refresh()
            {
                CheckFiles = new HashSet<string>
                {
                    "%fileBase%_data/Managed/Assembly-CSharp-firstpass.dll",
                    "%fileBase%_data/Managed/Assembly-CSharp.dll",
                    "%fileBase%_data/Managed/Assembly-UnityScript-firstpass.dll",
                    "%fileBase%_data/Managed/Assembly-UnityScript.dll"
                };
                VersionsList = new HashSet<Version>();

                //if (Configuration.GetString("UpdateVersions").ToLower() == "true")
                {
                    UpdateVersions();
                }

                try
                {
                    var document = XDocument.Load(FileName);

                    foreach (var element in document.Root.Element("files").Elements("file"))
                    {
                        if (!CheckFiles.Contains(element.Value))
                        {
                            CheckFiles.Add(element.Value);
                        }
                    }
                    foreach (var element in document.Root.Elements("version"))
                    {
                        VersionsList.Add(new Version(element));
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("Game: " + Game.GameConfiguration.ID, "Failed parsing versions file: " + e, Debug.Type.ERROR);
                }

                Valid = true;
            }

            public void UpdateVersions()
            {
                var responses = new List<string>();

                using (var client = new WebClient())
                {
                    foreach (var url in VersionUpdateDomains)
                    {
                        try
                        {
                            responses.Add(client.DownloadString(string.Format(url, Game.GameConfiguration.ID)));
                        }
                        catch (WebException e)
                        {
                            // Something is wrong with the server or connection
                            Debug.Log("Game: " + Game.GameConfiguration.ID, "Failed to download one of the version files: " + e, Debug.Type.ERROR);
                        }
                        catch (Exception e)
                        {
                            // Something else happened
                            Debug.Log("Game: " + Game.GameConfiguration.ID, "Something failed while trying to download one of the version files: " + e, Debug.Type.ERROR);
                        }
                    }
                }

                if (responses.Count > 0)
                {
                    foreach (var response in responses)
                    {
                        try
                        {
                            var document = XDocument.Parse(response);

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
                            Debug.Log("Game: " + Game.GameConfiguration.ID, "Failed parsing versions file from server: " + e, Debug.Type.ERROR);
                        }
                    }

                    try
                    {
                        // Save updated versions
                        var finalDocument = new XDocument(new XElement("versions"));
                        finalDocument.Root.Add(new XElement("files", CheckFiles.Select(o => new XElement("file", o))));
                        foreach (var version in VersionsList.OrderBy(o => o.ID))
                        {
                            var element = new XElement("version", new XAttribute("id", version.ID));
                            element.Add(new XElement("checksum", version.CheckSum));
                            finalDocument.Root.Add(element);
                        }
                        finalDocument.Save(FileName);
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Game: " + Game.GameConfiguration.ID, "Failed saving version file: " + e, Debug.Type.ERROR);
                    }
                }
                else
                {
                    Debug.Log("Game: " + Game.GameConfiguration.ID, "No version files available on any of the servers: " + string.Join(", ", VersionUpdateDomains), Debug.Type.ERROR);
                }
            }

            public struct Version : IEquatable<Version>
            {
                public static readonly Version Zero = default(Version);

                public string ID;
                public string CheckSum;

                public bool IsValid => !string.IsNullOrWhiteSpace(ID) && !string.IsNullOrWhiteSpace(CheckSum);

                public Version(string checkSum)
                {
                    ID = "Auto-Updated";
                    CheckSum = checkSum;
                }

                public Version(XElement element)
                {
                    ID = XMLHelper.GetXMLAttributeAsString(element, "id");
                    CheckSum = XMLHelper.GetXMLElementAsString(element, "checksum");
                }

                public bool Equals(Version other)
                {
                    return string.Equals(ID, other.ID) && string.Equals(CheckSum, other.CheckSum);
                }

                public override bool Equals(object obj)
                {
                    if (ReferenceEquals(null, obj))
                    {
                        return false;
                    }
                    return obj is Version && Equals((Version) obj);
                }

                public override int GetHashCode()
                {
                    unchecked
                    {
                        return ((ID != null ? ID.GetHashCode() : 0) * 397) ^ (CheckSum != null ? CheckSum.GetHashCode() : 0);
                    }
                }
            }
        }
    }
}
