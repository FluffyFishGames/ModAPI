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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModAPI.Configurations;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Threading;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Ionic.Zip;

namespace ModAPI.Data
{
    public class Game
    {
        public event EventHandler<EventArgs> OnModlibUpdate;

        public Configuration.GameConfiguration GameConfiguration;
        public List<Mod> Mods = new List<Mod>();
        public string GamePath = "";
        public bool Valid = false;
        public ModLib ModLibrary;

        protected bool RegenerateModLibrary = false;
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
            this.ModLibrary = new ModLib(this);
            GamePath = Configuration.GetPath("Games." + GameConfiguration.ID);
            Verify();
        }

        protected void GamePathSpecified()
        {
            Configuration.SetPath("Games." + this.GameConfiguration.ID, this.GamePath, true);
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
                    Utils.Schedule.AddTask("GUI", "SpecifyGamePath", GamePathSpecified, new object[] { this }, CheckGamePath);
                    Valid = false;
                    return;
                }
            }

            Configuration.SetPath("Games." + this.GameConfiguration.ID, GamePath, true);

            if (versions == null)
            {
                versions = new Versions(this);
            }
            versions.Refresh();

            GenerateCheckSums();
            GameVersion = versions.GetVersion(CheckSumGame);
            BackupVersion = versions.GetVersion(CheckSumBackup);
            
            if ((GameVersion != null && BackupVersion == null) || (GameVersion != null && BackupVersion != null && GameVersion.ID != BackupVersion.ID))
            {
                BackupGameFiles();
                Thread.Sleep(1000);
                GenerateCheckSums();
                GameVersion = versions.GetVersion(CheckSumGame);
                BackupVersion = versions.GetVersion(CheckSumBackup);
                RegenerateModLibrary = true;
            }
            
            if ((CheckSumGame != CheckSumBackup && CheckSumGame != CheckSumModded) || (GameVersion == null && CheckSumModded != "" && CheckSumModded != CheckSumGame))
            {
                System.Console.WriteLine("EH?");
                Debug.Log("Game: " + this.GameConfiguration.ID, "Neither the game and modded checksum nor the game and backup checksum did match. Game checksum: " + CheckSumGame);
                Utils.Schedule.AddTask("GUI", "RestoreGameFiles", Verify, new object[] { this });
                Valid = false;
                RegenerateModLibrary = true;
                return;
            }

            if (!ModLibrary.Exists || ModLibrary.ModAPIVersion != Version.Descriptor)
            {
                RegenerateModLibrary = true;
                ModAPI.Utils.Schedule.AddTask("SelectNewestModVersions", delegate() { }, null);
            }

            if (RegenerateModLibrary)
            {
                CreateModLibrary(true);
            }
        }

        public void CreateModLibrary(bool AutoClose = false)
        {
            ProgressHandler progressHandler = new ProgressHandler();
            Utils.Schedule.AddTask("GUI", "OperationPending", null, new object[] { "CreatingModLibrary", progressHandler, null, AutoClose });
            Thread t = new Thread(delegate() {
                ModLibrary.Create(progressHandler);
                if (OnModlibUpdate != null)
                    OnModlibUpdate(this, new EventArgs());
            });
            t.Start();
        }

        public string FindGamePath()
        {
            string prevGamePath = GamePath;
            foreach (string searchPath in GameConfiguration.SearchPaths)
            {
                string p = Utils.Path.Parse(searchPath, new string[0]);
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
                string GameFolder = GamePath;
                if ((File.GetAttributes(GamePath) & FileAttributes.Directory) != FileAttributes.Directory)
                {
                    GameFolder = Path.GetDirectoryName(GameFolder);
                }
                return GameFolder;
            }
            else
            {
                return "";
            }
        }

        protected void BackupGameFiles()
        {
            ProgressHandler progressHandler = new ProgressHandler();
            progressHandler.Task = "CreatingBackup";
            Utils.Schedule.AddTask("GUI", "OperationPending", null, new object[] {"BackupGameFiles", progressHandler, null, true});

            Thread t = new Thread(delegate() {
                string GameFolder = GetGameFolder();
                foreach (string n in GameConfiguration.IncludeAssemblies)
                {
                    string path = Path.GetFullPath(GameFolder + Path.DirectorySeparatorChar + ParsePath(n));
                    string backupPath = Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + Path.DirectorySeparatorChar + GameConfiguration.ID + Path.DirectorySeparatorChar + ParsePath(n));
                    Directory.CreateDirectory(Path.GetDirectoryName(backupPath));
                    File.Copy(path, backupPath, true);
                }
                foreach (string n in GameConfiguration.CopyAssemblies)
                {
                    string path = Path.GetFullPath(GameFolder + Path.DirectorySeparatorChar + ParsePath(n));
                    string backupPath = Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + Path.DirectorySeparatorChar + GameConfiguration.ID + Path.DirectorySeparatorChar + ParsePath(n));
                    Directory.CreateDirectory(Path.GetDirectoryName(backupPath));
                    File.Copy(path, backupPath, true);
                }
                progressHandler.Progress = 100f;
            });
            t.Start();

        }

        protected void GenerateCheckSums()
        {
            this.CheckSumBackup = "";
            this.CheckSumGame = "";
            this.CheckSumModded = "";
            string GameFolder = GetGameFolder();
            MD5 digester = MD5.Create();
            foreach (string p in versions.CheckFiles)
            {
                string gamePath = Path.GetFullPath(GameFolder + Path.DirectorySeparatorChar + ParsePath(p));
                string backupPath = Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + Path.DirectorySeparatorChar + GameConfiguration.ID + Path.DirectorySeparatorChar + ParsePath(p));
                string moddedPath = Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + Path.DirectorySeparatorChar + GameConfiguration.ID + Path.DirectorySeparatorChar + ParsePath(p));
                if (File.Exists(gamePath))
                    CheckSumGame += System.BitConverter.ToString(digester.ComputeHash(File.ReadAllBytes(gamePath)));
                if (File.Exists(backupPath))
                    CheckSumBackup += System.BitConverter.ToString(digester.ComputeHash(File.ReadAllBytes(backupPath)));
                if (File.Exists(moddedPath))
                    CheckSumModded += System.BitConverter.ToString(digester.ComputeHash(File.ReadAllBytes(moddedPath)));
            }
            if (CheckSumBackup.Length != CheckSumGame.Length)
                CheckSumBackup = "";
            if (CheckSumModded.Length != CheckSumGame.Length)
                CheckSumModded = "";

            CheckSumGame = CheckSumGame.Replace("-", "");
            CheckSumModded = CheckSumModded.Replace("-", "");
            CheckSumBackup = CheckSumBackup.Replace("-", "");

        }

        public bool CheckGamePath()
        {
            string GameFolder = GetGameFolder();
            foreach (string n in GameConfiguration.IncludeAssemblies)
            {
                string path = Path.GetFullPath(GameFolder + Path.DirectorySeparatorChar + ParsePath(n));
                if (!File.Exists(path))
                {
                    Debug.Log("Required file \"" + path + "\" couldn't be found.", Debug.Type.WARNING);
                    return false;
                }
            }
            foreach (string n in GameConfiguration.CopyAssemblies)
            {
                string path = Path.GetFullPath(GameFolder + Path.DirectorySeparatorChar + ParsePath(n));
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
            string GameFolder = GetGameFolder();
            string[] ret = new string[GameConfiguration.IncludeAssemblies.Count];
            for (int i = 0; i < GameConfiguration.IncludeAssemblies.Count; i++) 
            {
                string n = GameConfiguration.IncludeAssemblies[i];
                string path = Path.GetFullPath(GameFolder + Path.DirectorySeparatorChar + ParsePath(n));
                ret[i] = path;
            }
            return ret;
        }

        public string ParsePath(string n)
        {
            string fileName = GameConfiguration.SelectFile;
            string fileBase = Path.GetFileNameWithoutExtension(GameConfiguration.SelectFile);
            n = Utils.Path.Parse(n, new string[] { "fileBase:" + fileBase, "fileName:" + fileName });
            
            return n;
        }


        protected void SetProgress(ProgressHandler progress, float percentage, string newTask = "")
        {
            if (progress == null)
                return;
            if (newTask != "")
                progress.Task = newTask;
            progress.Progress = percentage;
        }

        protected void SetProgress(ProgressHandler progress, string newTask)
        {
            if (progress == null)
                return;
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
                        throw new Exception("Could not apply original files.");
                    SetProgress(handler, 100f, "Finish");
                    return;
                }
                if (!RemoveModdedFiles())
                    throw new Exception("Could not removed modded files.");

                SetProgress(handler, "Preparing");
                XDocument modsConfiguration = new XDocument();
                modsConfiguration.Add(new XElement("RuntimeConfiguration"));

                string LibraryFolder = ModLibrary.GetLibraryFolder();

                string baseModLibPath = LibraryFolder + System.IO.Path.DirectorySeparatorChar + "BaseModLib.dll";
                ModuleDefinition baseModLib = ModuleDefinition.ReadModule(baseModLibPath);
                TypeDefinition LogType = baseModLib.GetType("ModAPI.Log");
                TypeDefinition BaseSystemType = baseModLib.GetType("ModAPI.BaseSystem");
                MethodReference InitializeMethod = null;
                MethodReference LogMethod = null;

                Dictionary<string, TypeDefinition> ConfigurationAttributes = new Dictionary<string, TypeDefinition>();
                foreach (TypeDefinition modLibType in baseModLib.Types)
                {
                    if (modLibType.BaseType != null && modLibType.BaseType.Name == "ConfigurationAttribute")
                    {
                        ConfigurationAttributes.Add(modLibType.FullName, modLibType);
                    }
                }

                foreach (MethodDefinition modLibMethod in LogType.Methods)
                {
                    if (modLibMethod.Name == "Write" && modLibMethod.Parameters.Count == 2 && modLibMethod.Parameters[0].ParameterType.FullName == "System.String" && modLibMethod.Parameters[1].ParameterType.FullName == "System.String")
                    {
                        LogMethod = modLibMethod;
                        break;
                    }
                }
                foreach (MethodDefinition modLibMethod in BaseSystemType.Methods)
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

                Dictionary<string, string> injectableClasses = new Dictionary<string, string>();
                Dictionary<string, Dictionary<string, TypeDefinition>> assemblyTypes = new Dictionary<string, Dictionary<string, TypeDefinition>>();

                Dictionary<string, ModuleDefinition> Assemblies = new Dictionary<string,ModuleDefinition>();

                Utils.CustomAssemblyResolver assemblyResolver = new Utils.CustomAssemblyResolver();
                assemblyResolver.AddPath(ModAPI.Configurations.Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar);

                List<string> SearchFolders = new List<string>();
                for (int i = 0; i < GameConfiguration.IncludeAssemblies.Count; i++)
                {
                    string assemblyPath = ModAPI.Configurations.Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + ParsePath(GameConfiguration.IncludeAssemblies[i]);
                    string folder = System.IO.Path.GetDirectoryName(assemblyPath);
                    if (!SearchFolders.Contains(folder))
                    {
                        Debug.Log("ModLib: " + GameConfiguration.ID, "Added folder \"" + folder + "\" to assembly resolver.");
                        SearchFolders.Add(folder);
                    }
                }
                for (int i = 0; i < GameConfiguration.CopyAssemblies.Count; i++)
                {
                    string assemblyPath = ModAPI.Configurations.Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + ParsePath(GameConfiguration.CopyAssemblies[i]);
                    string folder = System.IO.Path.GetDirectoryName(assemblyPath);
                    if (!SearchFolders.Contains(folder))
                    {
                        Debug.Log("ModLib: " + GameConfiguration.ID, "Added folder \"" + folder + "\" to assembly resolver.");
                        SearchFolders.Add(folder);
                    }
                }
                for (int i = 0; i < SearchFolders.Count; i++)
                    assemblyResolver.AddPath(SearchFolders[i]);
                
                foreach (string p in GameConfiguration.IncludeAssemblies) 
                {
                    string path = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                    string key = System.IO.Path.GetFileNameWithoutExtension(path);

                    ModuleDefinition module = ModuleDefinition.ReadModule(path, new ReaderParameters() { 
                        AssemblyResolver = assemblyResolver
                    });
                    module.AssemblyReferences.Add(new AssemblyNameReference("BaseModLib", new System.Version("1.0.0.0")));
                    assemblyTypes.Add(key, new Dictionary<string, TypeDefinition>());

                    foreach (TypeDefinition type in module.Types)
                    {
                        if (!ModLib.CheckName(type.Namespace, GameConfiguration.ExcludeNamespaces) && !ModLib.CheckName(type.FullName, GameConfiguration.ExcludeTypes) && !ModLib.CheckName(type.FullName, GameConfiguration.NoFamily))
                        {
                            if (!assemblyTypes[key].ContainsKey(type.FullName))
                                assemblyTypes[key].Add(type.FullName, type);
                        }
                    }

                    Assemblies.Add(key, module);
                }

                if (!Assemblies.ContainsKey("mscorlib") || !Assemblies.ContainsKey("UnityEngine"))
                {
                    foreach (string p in GameConfiguration.CopyAssemblies) 
                    {
                        string path = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                        string key = System.IO.Path.GetFileNameWithoutExtension(path);
                    
                        if ((key == "mscorlib" && !Assemblies.ContainsKey("mscorlib")) || (key == "UnityEngine" && !Assemblies.ContainsKey("UnityEngine")))
                        {
                            ModuleDefinition module = ModuleDefinition.ReadModule(path);
                            Assemblies.Add(key, module);
                        }
                    }
                }

                SetProgress(handler, 5f);
                TypeDefinition UnityEngineObject = Assemblies["UnityEngine"].GetType("UnityEngine.Object");
                TypeDefinition UnityEngineApplication = Assemblies["UnityEngine"].GetType("UnityEngine.Application");
                TypeDefinition UnityEngineComponent = Assemblies["UnityEngine"].GetType("UnityEngine.Component");

                TypeDefinition SystemAppDomain = Assemblies["mscorlib"].GetType("System.AppDomain");
                TypeDefinition SystemResolveEventHandler = Assemblies["mscorlib"].GetType("System.ResolveEventHandler");
                TypeDefinition SystemResolveEventArgs = Assemblies["mscorlib"].GetType("System.ResolveEventArgs");
                TypeDefinition SystemReflectionAssembly = Assemblies["mscorlib"].GetType("System.Reflection.Assembly");
                TypeDefinition SystemReflectionAssemblyName = Assemblies["mscorlib"].GetType("System.Reflection.AssemblyName");
                TypeDefinition SystemString = Assemblies["mscorlib"].GetType("System.String");
                TypeDefinition SystemIOFile = Assemblies["mscorlib"].GetType("System.IO.File");
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

                foreach (MethodDefinition m in UnityEngineApplication.Methods)
                {
                    if (m.Name == "get_dataPath")
                        UnityEngineApplicationGetDataPath = m;
                }

                foreach (MethodDefinition m in SystemIOFile.Methods)
                {
                    if (m.Name == "WriteAllText" && m.Parameters.Count == 2)
                        SystemIOFileWriteAllText = m;
                }
                foreach (MethodDefinition m in SystemAppDomain.Methods)
                {
                    if (m.Name == "get_CurrentDomain")
                        SystemAppDomainGetCurrentDomain = m;
                    if (m.Name == "add_AssemblyResolve")
                        SystemAppDomainAddAssemblyResolve = m;
                }
                foreach (MethodDefinition m in SystemResolveEventHandler.Methods)
                {
                    if (m.IsConstructor && m.Parameters.Count == 2 && m.Parameters[0].ParameterType.FullName == "System.Object")
                        SystemResolveEventHandlerCtor = m;
                }
                foreach (MethodDefinition m in SystemResolveEventArgs.Methods)
                {
                    if (m.Name == "get_Name")
                        SystemResolveEventArgsGetName = m;
                    
                }
                foreach (MethodDefinition m in SystemReflectionAssembly.Methods)
                {
                    if (m.Name == "LoadFrom" && m.Parameters.Count == 1 && m.Parameters[0].ParameterType.FullName == "System.String")
                        SystemReflectionAssemblyLoadFrom = m;
                }
                foreach (MethodDefinition m in SystemReflectionAssemblyName.Methods)
                {
                    if (m.IsConstructor && m.Parameters.Count == 1 && m.Parameters[0].ParameterType.FullName == "System.String")
                        SystemReflectionAssemblyNameCtor = m;
                    if (m.Name == "get_Name")
                        SystemReflectionAssemblyNameGetName = m;
                }
                foreach (MethodDefinition m in SystemString.Methods)
                {
                    if (m.Name == "Format" && m.Parameters.Count == 2 && m.Parameters[0].ParameterType.FullName == "System.String" && m.Parameters[1].ParameterType.FullName == "System.Object")
                        SystemStringFormat = m;
                    if (m.Name == "Concat" && m.Parameters.Count == 2 && m.Parameters[0].ParameterType.FullName == "System.String" && m.Parameters[1].ParameterType.FullName == "System.String")
                        SystemStringConcat = m;
                }

                MethodDefinition ResolveModAssembly = new MethodDefinition("ResolveModAssembly", MethodAttributes.HideBySig | MethodAttributes.Private | MethodAttributes.Static, Assemblies["UnityEngine"].Import(SystemReflectionAssembly));
                ResolveModAssembly.Parameters.Add(new ParameterDefinition("sender", ParameterAttributes.None, Assemblies["UnityEngine"].TypeSystem.Object));
                ResolveModAssembly.Parameters.Add(new ParameterDefinition("e", ParameterAttributes.None, Assemblies["UnityEngine"].Import(SystemResolveEventArgs)));
                
                if (ResolveModAssembly.Body == null)
                    ResolveModAssembly.Body = new MethodBody(ResolveModAssembly);

                ResolveModAssembly.Body.Variables.Add(new VariableDefinition("filename", Assemblies["UnityEngine"].TypeSystem.String));
                ResolveModAssembly.Body.Variables.Add(new VariableDefinition("path", Assemblies["UnityEngine"].TypeSystem.String));
                ResolveModAssembly.Body.Variables.Add(new VariableDefinition("ret", Assemblies["UnityEngine"].Import(SystemReflectionAssembly)));
                
                ILProcessor _processor = ResolveModAssembly.Body.GetILProcessor();
                Instruction _tryStart = _processor.Create(OpCodes.Ldarg_1);
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
                
                Instruction exitPoint = _processor.Create(OpCodes.Ldloc_2);
                _processor.Append(exitPoint);
                _processor.Append(_processor.Create(OpCodes.Ret));
                
                _processor.InsertBefore(exitPoint, _processor.Create(OpCodes.Leave, exitPoint));
                Instruction _tryEnd = _processor.Create(OpCodes.Pop);
                _processor.InsertBefore(exitPoint, _tryEnd);
                _processor.InsertBefore(exitPoint, _processor.Create(OpCodes.Ldnull));
                _processor.InsertBefore(exitPoint, _processor.Create(OpCodes.Stloc_2));
                _processor.InsertBefore(exitPoint, _processor.Create(OpCodes.Leave, exitPoint));
                
                ExceptionHandler _exceptionHandler = new ExceptionHandler(ExceptionHandlerType.Catch);
                _exceptionHandler.TryStart = _tryStart;
                _exceptionHandler.TryEnd = _tryEnd;
                _exceptionHandler.HandlerStart = _tryEnd;
                _exceptionHandler.HandlerEnd = exitPoint;
                _exceptionHandler.CatchType = (TypeReference) Assemblies["UnityEngine"].Import(Assemblies["mscorlib"].GetType("System.Exception"));
                ResolveModAssembly.Body.ExceptionHandlers.Add(_exceptionHandler);
                
                UnityEngineApplication.Methods.Add(ResolveModAssembly);

                MethodDefinition ctorMethod = new MethodDefinition(".cctor", MethodAttributes.SpecialName | MethodAttributes.RTSpecialName | MethodAttributes.HideBySig | MethodAttributes.Private | MethodAttributes.Static, Assemblies["UnityEngine"].TypeSystem.Void);

                _processor = ctorMethod.Body.GetILProcessor();
                Instruction last = _processor.Create(OpCodes.Ret);
                _processor.Append(last);
                _processor.InsertBefore(last, _processor.Create(OpCodes.Call, Assemblies["UnityEngine"].Import(SystemAppDomainGetCurrentDomain)));
                _processor.InsertBefore(last, _processor.Create(OpCodes.Ldnull));
                _processor.InsertBefore(last, _processor.Create(OpCodes.Ldftn, ResolveModAssembly));
                _processor.InsertBefore(last, _processor.Create(OpCodes.Newobj, Assemblies["UnityEngine"].Import(SystemResolveEventHandlerCtor)));
                _processor.InsertBefore(last, _processor.Create(OpCodes.Callvirt, Assemblies["UnityEngine"].Import(SystemAppDomainAddAssemblyResolve)));
                
                UnityEngineApplication.Methods.Add(ctorMethod);

                foreach (MethodDefinition method in UnityEngineComponent.Methods)
                {
                    if ((method.Name == "GetComponent" || method.Name=="GetComponentInChildren" || method.Name == "GetComponentsInChildren" || method.Name == "GetComponentsInParent" || method.Name == "get_gameObject" || method.Name == "get_transform" || method.Name == "GetComponents" || method.Name == "SendMessageUpwards" || method.Name == "SendMessage" || method.Name == "BroadcastMessage") && !method.IsInternalCall)
                    {
                        _processor = method.Body.GetILProcessor();
                        last = method.Body.Instructions[0];
                        _processor.InsertBefore(last, _processor.Create(OpCodes.Call, Assemblies["UnityEngine"].Import(InitializeMethod)));
                    }
                }

                SetProgress(handler, 10f);

                Dictionary<string, MethodDefinition> modTools = new Dictionary<string, MethodDefinition>();
                Dictionary<string, TypeDefinition> InjectToType = new Dictionary<string, TypeDefinition>();
                Dictionary<string, MethodDefinition> InjectToMethod = new Dictionary<string, MethodDefinition>();

                Dictionary<string, Dictionary<int, List<Mod.Header.InjectInto>>> injectIntos = new Dictionary<string, Dictionary<int, List<Mod.Header.InjectInto>>>();
                Dictionary<string, List<Mod.Header.AddMethod>> addMethods = new Dictionary<string,List<Mod.Header.AddMethod>>();
                Dictionary<string, List<Mod.Header.AddField>> addFields = new Dictionary<string, List<Mod.Header.AddField>>();
                Dictionary<string, List<TypeDefinition>> addedTypes = new Dictionary<string, List<TypeDefinition>>();

                Dictionary<TypeReference, TypeDefinition> AddedClasses = new Dictionary<TypeReference, TypeDefinition>();
                Dictionary<FieldReference, FieldDefinition> AddedFields = new Dictionary<FieldReference, FieldDefinition>();
                Dictionary<MethodReference, MethodDefinition> AddedMethods = new Dictionary<MethodReference, MethodDefinition>();
                Dictionary<MethodReference, MethodDefinition> InjectedMethods = new Dictionary<MethodReference, MethodDefinition>();
                Dictionary<MethodReference, MethodDefinition> NewMethods = new Dictionary<MethodReference, MethodDefinition>();
                Dictionary<TypeReference, TypeReference> TypesMap = new Dictionary<TypeReference, TypeReference>();
                
                Dictionary<string, AssemblyNameReference> AddReferences = new Dictionary<string, AssemblyNameReference>();

                Dictionary<TypeDefinition, TypeDefinition> InsertConstructor = new Dictionary<TypeDefinition, TypeDefinition>();

                Dictionary<string, XElement> ModConfigurations = new Dictionary<string, XElement>();
                int c = 0;
                foreach (Mod mod in Mods)
                {
                    mod.RewindModule();
                    XElement modConfiguration = new XElement("Mod");
                    ModConfigurations.Add(mod.ID, modConfiguration);
                    modConfiguration.SetAttributeValue("ID", mod.ID);
                    modConfiguration.SetAttributeValue("UniqueID", mod.UniqueID);
                    modConfiguration.SetAttributeValue("Version", mod.header.GetVersion());

                    foreach (Mod.Header.Button button in mod.header.GetButtons())
                    {
                        string AssignedKey = Configuration.GetString("Mods." + GameConfiguration.ID + "." + mod.ID + ".Buttons." + button.ID);
                        if (AssignedKey == "")
                            AssignedKey = button.StandardKey;
                        XElement buttonConfiguration = new XElement("Button");
                        buttonConfiguration.SetAttributeValue("ID", button.ID);
                        buttonConfiguration.Value = AssignedKey;
                        modConfiguration.Add(buttonConfiguration);
                    }

                    modsConfiguration.Root.Add(modConfiguration);
                    addedTypes.Add(mod.ID, new List<TypeDefinition>());
                    foreach (Mod.Header.AddClass addClass in mod.header.GetAddClasses())
                    {
                        foreach (MethodDefinition m in addClass.Type.Methods)
                        {
                            Utils.MonoHelper.ParseCustomAttributes(addClass.Mod, modsConfiguration, m, ConfigurationAttributes);
                        }

                        addedTypes[mod.ID].Add(addClass.Type);
                        AddedClasses.Add(addClass.Type, addClass.Type);
                    }

                    foreach (Mod.Header.AddMethod addMethod in mod.header.GetAddMethods())
                    {
                        if (!TypesMap.ContainsKey((TypeReference)addMethod.Method.DeclaringType))
                        {
                            TypesMap.Add(addMethod.Method.DeclaringType, Assemblies[addMethod.AssemblyName].GetType(addMethod.TypeName));
                        }

                        string key = addMethod.AssemblyName + "::" + addMethod.TypeName;
                        if (!addMethods.ContainsKey(key))
                            addMethods.Add(key, new List<Mod.Header.AddMethod>());
                        addMethods[key].Add(addMethod);
                    }

                    foreach (Mod.Header.AddField addField in mod.header.GetAddFields())
                    {
                        if (!TypesMap.ContainsKey((TypeReference)addField.Field.DeclaringType))
                        {
                            TypesMap.Add(addField.Field.DeclaringType, Assemblies[addField.AssemblyName].GetType(addField.TypeName));
                        }

                        string key = addField.AssemblyName + "::" + addField.TypeName;
                        if (!addFields.ContainsKey(key))
                            addFields.Add(key, new List<Mod.Header.AddField>());
                        addFields[key].Add(addField);
                    }

                    foreach (Mod.Header.InjectInto injectInto in mod.header.GetInjectIntos()) 
                    {
                        if (!TypesMap.ContainsKey((TypeReference)injectInto.Method.DeclaringType))
                        {
                            TypesMap.Add(injectInto.Method.DeclaringType, Assemblies[injectInto.AssemblyName].GetType(injectInto.TypeName));
                        }

                        string parameters = "";
                        bool first = true;
                        foreach (ParameterDefinition param in injectInto.Method.Parameters) 
                        {
                            if (!first) {
                                parameters += ",";
                            }
                            parameters += param.ParameterType.FullName;
                            first = false;
                            // @TODO: Add parameter name at some time to verify integrity. NameResolver does not support this currently.
                        }
                        string key = injectInto.AssemblyName + "::" + injectInto.Method.ReturnType.FullName + " " + injectInto.TypeName + "::" + injectInto.MethodName + "("+parameters+")";
                        if (!injectIntos.ContainsKey(key))
                            injectIntos.Add(key, new Dictionary<int, List<Mod.Header.InjectInto>>());
                        if (!injectIntos[key].ContainsKey(injectInto.Priority))
                            injectIntos[key].Add(injectInto.Priority, new List<Mod.Header.InjectInto>());
                        injectIntos[key][injectInto.Priority].Add(injectInto);
                    }

                    /*foreach (Mod.Header.AddClass addClass in mod.header.GetAddClasses()) 
                    {
                        string key = mod.ID;
                        if (!addClasses.ContainsKey(key))
                            addClasses.Add(key, new List<Mod.Header.AddClass>());
                        addClasses[key].Add(addClass);
                    }*/
                    c++;
                    SetProgress(handler,  10f + ((float)c / (float)Mods.Count) * 20f, "FetchingInjections");
                }

                SetProgress(handler, 30f, "Injecting");
                foreach (KeyValuePair<string, List<Mod.Header.AddField>> kv in addFields) 
                {
                    string path = kv.Key;
                    string[] parts = path.Split(new string[]{"::"}, StringSplitOptions.None);
                    TypeDefinition type = Assemblies[parts[0]].GetType(parts[1]);

                    foreach (Mod.Header.AddField field in kv.Value) 
                    {
                        FieldDefinition newField = Utils.MonoHelper.CopyField(field.Field);
                        type.Fields.Add(newField);
                        AddedFields.Add(field.Field, newField);
                    }
                }
                SetProgress(handler, 35f);
                foreach (KeyValuePair<string, List<Mod.Header.AddMethod>> kv in addMethods) 
                {
                    string path = kv.Key;
                    string[] parts = path.Split(new string[]{"::"}, StringSplitOptions.None);
                    TypeDefinition type = Assemblies[parts[0]].GetType(parts[1]);

                    foreach (Mod.Header.AddMethod method in kv.Value) 
                    {
                        MethodDefinition newMethod = Utils.MonoHelper.CopyMethod(method.Method); 
                        type.Methods.Add(newMethod);
                        Utils.MonoHelper.ParseCustomAttributes(method.Mod, modsConfiguration, newMethod, ConfigurationAttributes);
                        AddedMethods.Add(method.Method, newMethod);
                    }
                }
                SetProgress(handler, 40f);

                MethodReference methodObjectToString = null;
                MethodReference methodStringConcat = null;
                MethodReference methodExceptionConstructor = null;
                TypeReference typeException = null;
                foreach (MethodDefinition _m in Assemblies["mscorlib"].GetType("System.Object").Methods)
                {
                    if (_m.Name == "ToString")
                        methodObjectToString = (MethodReference)_m;
                }
                foreach (MethodDefinition _m in Assemblies["mscorlib"].GetType("System.String").Methods)
                {
                    if (_m.Name == "Concat" && _m.Parameters.Count == 2 && _m.Parameters[0].ParameterType.Name == "String" && _m.Parameters[1].ParameterType.Name == "String")
                        methodStringConcat = (MethodReference)_m;
                }
                typeException = (TypeReference) Assemblies["mscorlib"].GetType("System.Exception");
                foreach (MethodDefinition _m in Assemblies["mscorlib"].GetType("System.Exception").Methods)
                {
                    if (_m.IsConstructor && _m.Parameters.Count == 1 && _m.Parameters[0].ParameterType.Name == "String")
                        methodExceptionConstructor = (MethodReference)_m;
                }

                foreach (KeyValuePair<string, Dictionary<int, List<Mod.Header.InjectInto>>> kv in injectIntos)
                {
                    string path = kv.Key;
                    int ind = path.IndexOf("::");
                    string[] parts = new string[2];
                    parts[0] = path.Substring(0, ind);
                    parts[1] = path.Substring(ind + 2);

                    string Namespace = "";
                    string Type = "";
                    string Method = "";
                    string ReturnType = "";
                    string[] Parameters = new string[0];
                    Utils.NameResolver.Parse(parts[1], ref Namespace, ref Type, ref Method, ref ReturnType, ref Parameters);

                    string FullTypeName = Namespace + (Namespace != ""?".":"") + Type;
                    TypeDefinition type = Assemblies[parts[0]].GetType(FullTypeName);
                    
                    MethodDefinition lastMethod = null;
                    MethodDefinition originalMethod = null;
                    string originalMethodFullName = "";
                    if (type.IsAbstract && type.IsSealed && path.Contains(".ctor"))
                    {
                        // Skip instance constructors of static classes
                        continue;
                    }
                    foreach (MethodDefinition _method in type.Methods) 
                    {
                        if (_method.Name == Method && _method.Parameters.Count == Parameters.Length && _method.ReturnType.FullName == ReturnType) 
                        {
                            bool ok = true;
                            for (int i = 0; i < _method.Parameters.Count; i++)
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
                    
                    List<int> priorities = kv.Value.Keys.ToList();
                    priorities.Sort();
                    
                    MethodReference objectToString = Assemblies[parts[0]].Import(methodObjectToString);
                    MethodReference stringConcat = Assemblies[parts[0]].Import(methodStringConcat);
                    MethodReference exceptionConstructor = Assemblies[parts[0]].Import(methodExceptionConstructor);
                    TypeReference exception = Assemblies[parts[0]].Import(typeException);

                    List<Instruction> ConstructorInstructions = new List<Instruction>();
                    List<Instruction> StaticConstructorInstructions = new List<Instruction>();

                    int num = 0;
                    foreach (int prio in priorities)
                    {
                        foreach (Mod.Header.InjectInto injectInto in kv.Value[prio])
                        {   
                            MethodDefinition newMethod = Utils.MonoHelper.CopyMethod(injectInto.Method);
                            if (newMethod.IsConstructor)
                            {
                                for (int i = 0; i < newMethod.Body.Instructions.Count; i++)
                                {
                                    Instruction currInstruction = newMethod.Body.Instructions[i];
                                    if (currInstruction.OpCode.Code != Code.Ret && !(currInstruction.OpCode.Code == Code.Call && (((MethodReference)currInstruction.Operand).Name == ".ctor" || ((MethodReference)currInstruction.Operand).Name == ".cctor")))
                                    originalMethod.Body.GetILProcessor().Append(currInstruction);
                                }
                                InjectedMethods.Add(newMethod, originalMethod);
                            }
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

                                bool isReturningValue = newMethod.ReturnType.FullName != "System.Void";
                                VariableDefinition returnVariable = null;

                                for (int i = 0; i < newMethod.Body.Instructions.Count; i++)
                                {
                                    Instruction currInstruction = newMethod.Body.Instructions[i];
                                    if (currInstruction.OpCode.Code == Code.Call && (currInstruction.Operand is MethodReference) && ((MethodReference)currInstruction.Operand).FullName == originalMethodFullName)
                                    {
                                        if (lastMethod != null)
                                            currInstruction.Operand = lastMethod;
                                        else
                                            currInstruction.Operand = originalMethod;
                                    }
                                }
                                Instruction returnInstruction = newMethod.Body.Instructions[newMethod.Body.Instructions.Count - 1];
                                Instruction lastInstruction = newMethod.Body.Instructions[newMethod.Body.Instructions.Count - (isReturningValue ? 2 : 1)];

                                Instruction tryStart = newMethod.Body.Instructions[0];
                                Instruction tryEnd = null;
                                Instruction handlerStart = null;
                                Instruction handlerEnd = null;

                                if (isReturningValue)
                                {
                                    returnVariable = newMethod.Body.Variables[newMethod.Body.Variables.Count - 1];
                                }
                                VariableDefinition exceptionVariable = new VariableDefinition("___ModAPIException___", exception);
                                newMethod.Body.Variables.Add(exceptionVariable);
                                
                                ILProcessor ilProcessor = newMethod.Body.GetILProcessor();
                                handlerStart = ilProcessor.Create(OpCodes.Stloc, exceptionVariable);

                                tryEnd = ilProcessor.Create(OpCodes.Leave, lastInstruction);
                                ilProcessor.InsertBefore(lastInstruction, tryEnd);
                                ilProcessor.InsertBefore(lastInstruction, handlerStart);
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldstr, "Exception thrown: "));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldloc, exceptionVariable));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Callvirt, objectToString));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Call, stringConcat));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldstr, injectInto.Mod.ID));
                                ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Call, LogMethod));
                                if (!originalMethod.IsStatic)
                                    ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldarg_0));

                                foreach (ParameterDefinition param in originalMethod.Parameters)
                                {
                                    ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Ldarg, param));
                                }
                                if (lastMethod != null)
                                    ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Call, lastMethod));
                                else
                                    ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Call, originalMethod));
                                if (isReturningValue)
                                    ilProcessor.InsertBefore(lastInstruction, ilProcessor.Create(OpCodes.Stloc, returnVariable));
                                handlerEnd = ilProcessor.Create(OpCodes.Leave, lastInstruction);
                                ilProcessor.InsertBefore(lastInstruction, handlerEnd);

                                ExceptionHandler exHandler = new ExceptionHandler(ExceptionHandlerType.Catch);
                                exHandler.TryStart = tryStart;
                                exHandler.TryEnd = handlerStart;
                                exHandler.HandlerStart = handlerStart;
                                exHandler.HandlerEnd = lastInstruction;
                                exHandler.CatchType = exception;
                                newMethod.Body.ExceptionHandlers.Add(exHandler);

                                lastMethod = newMethod;
                                type.Methods.Add(newMethod);
                                InjectedMethods.Add(newMethod, newMethod);
                            }
                        }
                    }
                    if (!originalMethod.IsConstructor)
                    {
                        lastMethod.Name = originalMethod.Name;
                        originalMethod.Name = "__" + Method + "__Original";
                    }
                    NewMethods.Add(originalMethod, lastMethod);
                }
                SetProgress(handler, 50f, "Resolving");

                /** RESOLVE ALL LINKS **/
                foreach (MethodDefinition method in AddedMethods.Values)
                {
                    Utils.MonoHelper.Resolve(method.Module, method, AddedClasses, AddedFields, AddedMethods, InjectedMethods, TypesMap);
                }

                foreach (MethodDefinition method in InjectedMethods.Values)
                {
                    Utils.MonoHelper.Resolve(method.Module, method, AddedClasses, AddedFields, AddedMethods, InjectedMethods, TypesMap);
                }

                foreach (FieldDefinition field in AddedFields.Values)
                {
                    Utils.MonoHelper.Resolve(field.Module, field, AddedClasses, TypesMap);
                }

                string modFolder = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + "Mods" + System.IO.Path.DirectorySeparatorChar);
                string assemblyFolder = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + ParsePath(GameConfiguration.AssemblyPath)) + System.IO.Path.DirectorySeparatorChar;
                if (!System.IO.Directory.Exists(assemblyFolder))
                    System.IO.Directory.CreateDirectory(assemblyFolder);
                if (!System.IO.Directory.Exists(modFolder))
                    System.IO.Directory.CreateDirectory(modFolder);

                foreach (Mod mod in Mods)
                {
                    ModuleDefinition modModule = mod.GetModuleCopy();
                    for (int j = 0; j < modModule.Types.Count; j++)
                    {
                        TypeDefinition t = modModule.Types[j];
                        foreach (MethodDefinition m in t.Methods)
                        {
                            Utils.MonoHelper.Resolve(m.Module, m, AddedClasses, AddedFields, AddedMethods, InjectedMethods, TypesMap);
                        }
                    }
                    for (int j = 0; j < modModule.Types.Count; j++)
                    {
                        TypeDefinition t = modModule.Types[j];
                        bool keep = false;
                        foreach (TypeDefinition type in addedTypes[mod.ID])
                        {
                            if (type.FullName == t.FullName)
                                keep = true;
                        }
                        if (!keep)
                        {
                            modModule.Types.Remove(t);
                        }
                    }
                    string path = System.IO.Path.GetFullPath(assemblyFolder + System.IO.Path.DirectorySeparatorChar + modModule.Name);
                    modModule.Write(path);
                    ZipFile zip = mod.GetResources();
                    if (zip != null)
                    {
                        zip.Save(modFolder + mod.ID + ".resources");
                        ModConfigurations[mod.ID].SetAttributeValue("HasResources", "true");
                    }
                }

                SetProgress(handler, 80f, "Saving");
                System.IO.File.Copy(
                    baseModLibPath, 
                    System.IO.Path.GetFullPath(assemblyFolder + System.IO.Path.DirectorySeparatorChar + "BaseModLib.dll"), 
                    true);
                foreach (string p in GameConfiguration.IncludeAssemblies)
                {
                    string path = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                    string folder = System.IO.Path.GetDirectoryName(path);
                    if (!System.IO.Directory.Exists(folder))
                        System.IO.Directory.CreateDirectory(folder);
                    string key = System.IO.Path.GetFileNameWithoutExtension(path);

                    ModuleDefinition module = Assemblies[key];
                    for (int i = 0 ; i < module.AssemblyReferences.Count; i++)
                    {
                        // @HOTFIX: Remove unwanted references to mscorlib 2.0.5.0
                        if (module.AssemblyReferences[i].Name == "mscorlib" && module.AssemblyReferences[i].Version.ToString() == "2.0.5.0")
                        {
                            module.AssemblyReferences.RemoveAt(i);
                            i--;
                        }
                    }
                    foreach (TypeDefinition type in module.Types)
                    {
                        foreach (TypeDefinition subType in type.NestedTypes)
                        {
                            foreach (MethodDefinition method2 in subType.Methods)
                            {
                                Utils.MonoHelper.Remap(module, method2, NewMethods);
                            }
                        }
                        foreach (MethodDefinition method in type.Methods)
                        {
                            Utils.MonoHelper.Remap(module, method, NewMethods);
                        }
                    }
                    module.Write(path);
                }
                
                foreach (string p in GameConfiguration.CopyAssemblies)
                {
                    string path = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + ParsePath(p));
                    string folder = System.IO.Path.GetDirectoryName(path);
                    if (!System.IO.Directory.Exists(folder))
                        System.IO.Directory.CreateDirectory(folder);
                    string key = System.IO.Path.GetFileNameWithoutExtension(path);
                    if (key == "UnityEngine")
                    {
                        Assemblies[key].Write(path);
                    }

                }

                string guiPath = System.IO.Path.GetFullPath(Configuration.GetPath("Libraries") + System.IO.Path.DirectorySeparatorChar + "GUI.assetbundle");
                if (System.IO.File.Exists(guiPath))
                {
                    System.IO.File.Copy(guiPath, System.IO.Path.GetFullPath(modFolder + System.IO.Path.DirectorySeparatorChar + "GUI.assetbundle"), true);
                }

                string[] assemblies = new string[] { 
                    "I18N.CJK.dll",
                    "I18N.dll",
                    "I18N.MidEast.dll",
                    "I18N.Other.dll",
                    "I18N.Rare.dll",
                    "I18N.West.dll",
                    "System.Xml.Linq.dll"
                };
                foreach (string ass in assemblies)
                {
                    string assPath = System.IO.Path.GetFullPath(Configuration.GetPath("Libraries") + System.IO.Path.DirectorySeparatorChar + ass);
                    if (System.IO.File.Exists(assPath))
                    {
                        System.IO.File.Copy(assPath, System.IO.Path.GetFullPath(assemblyFolder + ass), true);
                    }
                }
                string ionicZipPath = System.IO.Path.GetFullPath("Ionic.Zip.dll");
                if (System.IO.File.Exists(ionicZipPath))
                {
                    System.IO.File.Copy(ionicZipPath, assemblyFolder + "Ionic.Zip.dll", true);
                }
                
                modsConfiguration.Save(System.IO.Path.GetFullPath(modFolder + System.IO.Path.DirectorySeparatorChar + "RuntimeConfiguration.xml"));

                string moddedPath = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar);
                string gamePath = this.GamePath;
                string[] directories = System.IO.Directory.GetDirectories(moddedPath);
                foreach (string d in directories)
                    DirectoryCopy(d, gamePath, true);
                string[] files = System.IO.Directory.GetFiles(moddedPath);
                foreach (string f in files)
                    System.IO.File.Copy(f, gamePath + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetFileName(f), true);
                SetProgress(handler, 100f, "Finish");
            }
            catch (System.Exception e)
            {
                RemoveModdedFiles();
                ApplyOriginalFiles();
                Debug.Log("ModLoader: " + GameConfiguration.ID, "An exception occured: " + e.ToString(), Debug.Type.ERROR);
                SetProgress(handler, "Error.Unexpected");
                //Communicator.Error(e.ToString());
            }
        }

        private bool RemoveModdedFiles()
        {
            try
            {
                string OutputFolder = System.IO.Path.GetFullPath(Configuration.GetPath("ModdedGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar);
                if (!System.IO.Directory.Exists(OutputFolder))
                    return true;
                string[] oldFiles = System.IO.Directory.GetFiles(OutputFolder);
                foreach (string file in oldFiles)
                    System.IO.File.Delete(file);
                string[] oldDirectories = System.IO.Directory.GetDirectories(OutputFolder);
                foreach (string directory in oldDirectories)
                    System.IO.Directory.Delete(directory, true);
                return true;
            }
            catch (Exception e2)
            {
                Debug.Log("ModLoader: " + GameConfiguration.ID, "Could not remove modded files: " + e2.ToString(), Debug.Type.ERROR);
                return false;
            }
        }

        private bool ApplyOriginalFiles()
        {
            try
            {
                string OriginalFolder = System.IO.Path.GetFullPath(Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar);
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
                Debug.Log("ModLoader: " + GameConfiguration.ID, "Could not apply original files to game: " + e2.ToString(), Debug.Type.ERROR);
                return false;
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

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
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        public class Versions
        {
            public Game Game;
            public bool Valid = false; 
            protected string FileName;
            public List<string> CheckFiles;
            public List<Version> VersionsList;
            
            public Versions(Game Game) 
            {
                FileName = Configuration.GetPath("Configurations") + Path.DirectorySeparatorChar + "games" + Path.DirectorySeparatorChar + Game.GameConfiguration.ID + Path.DirectorySeparatorChar + "Versions.xml";
                this.Game = Game;
            }

            public Version GetVersion(string CheckSum)
            {
                if (CheckSum == "") return null;
                foreach (Version v in VersionsList)
                {
                    if (v.CheckSum.ToLower() == CheckSum.ToLower())
                        return v;
                }
                return null;
            }

            public void Refresh()
            {
                if (Configuration.GetString("UpdateVersions").ToLower() == "true")
                {
                    UpdateVersions();
                }
                try
                {
                    XDocument document = XDocument.Load(FileName);
                    
                    CheckFiles = new List<string>();
                    VersionsList = new List<Version>();
                    foreach (XElement element in document.Root.Element("files").Elements("file")) 
                    {
                        CheckFiles.Add(element.Value);
                    }
                    foreach (XElement element in document.Root.Elements("version")) 
                    {
                        VersionsList.Add(new Version(element));
                    }
                    Valid = true;
                }
                catch (Exception e)
                {
                    Debug.Log("Game: " + this.Game.GameConfiguration.ID, "Failed parsing versions file: "+e.ToString(), Debug.Type.ERROR);
                }
            }

            public void UpdateVersions()
            {
                try
                {
                    HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create("http://www.modapi.de/app/configs/games/" + Game.GameConfiguration.ID + "/Versions.xml");
                    WebReq.Method = "GET";
                    HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
                    Stream Answer = WebResp.GetResponseStream();
                    StreamReader _Answer = new StreamReader(Answer);
                    File.WriteAllText(FileName, _Answer.ReadToEnd());
                } catch (Exception e)
                {
                    Debug.Log("Game: " + this.Game.GameConfiguration.ID, "Failed to update versions table. Server seems offline.", Debug.Type.WARNING);
                }
            }

            public class Version
            {
                public string ID;
                public string CheckSum;
                
                public Version(XElement element)
                {
                    ID = Utils.XMLHelper.GetXMLAttributeAsString(element, "id", "");
                    CheckSum = Utils.XMLHelper.GetXMLElementAsString(element, "checksum", "");
                }
            }
        }
    }
}
