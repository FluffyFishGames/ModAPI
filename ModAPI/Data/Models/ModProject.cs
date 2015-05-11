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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ModAPI;
using ModAPI.Configurations;
using System.Xml.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.IO;
using Ionic.Zip;

namespace ModAPI.Data.Models
{
    public class ModProject
    {
        public string ID;
        protected string PreviousID;
        public Game Game;
        public MultilingualValue Name = new MultilingualValue();
        public MultilingualValue Description = new MultilingualValue();
        public string Version = "1.0.0.0";

        public List<string> Languages = new List<string>() { "EN" };
        public List<Button> Buttons = new List<Button>();

        public class Button
        {
            public ModProject project;
            public string ID;
            public string StandardKey;
            public MultilingualValue Name = new MultilingualValue();
            public MultilingualValue Description = new MultilingualValue();
            public XElement GetXML()
            {
                XElement buttonElement = new XElement("Button");
                if (this.StandardKey != "")
                    buttonElement.SetAttributeValue("Standard", this.StandardKey);
                buttonElement.SetAttributeValue("ID", this.ID);

                XElement nameElement = new XElement("Name");
                foreach (string langKey in project.Languages)
                {
                    XElement langElement = new XElement(langKey, this.Name.GetString(langKey));
                    nameElement.Add(langElement);
                }
                buttonElement.Add(nameElement);

                XElement descriptionElement = new XElement("Description");
                foreach (string langKey in project.Languages)
                {
                    XElement langElement = new XElement(langKey, this.Description.GetString(langKey));
                    descriptionElement.Add(langElement);
                }
                buttonElement.Add(descriptionElement);

                return buttonElement;
            }
        }

        public bool Valid = false;

        public void Verify()
        {
            Valid = false;
            if (!Mod.Header.VerifyModVersion(this.Version) || !Mod.Header.VerifyModID(this.ID))
                return;

            foreach (string langKey in Languages)
                if (this.Name.GetString(langKey).Trim() == "")
                    return;

            List<string> ButtonIDs = new List<string>();
            foreach (Button b in Buttons)
            {
                if (ButtonIDs.Contains(b.ID))
                    return;
                foreach (string langKey in Languages)
                    if (b.Name.GetString(langKey).Trim() == "")
                        return;
                ButtonIDs.Add(b.ID);
            }

            Valid = true;
        }

        public bool SaveFailed = false;

        public void Remove()
        {
            string path = GetFolderPath();
            System.IO.Directory.Delete(path, true);
        }

        public void SaveConfiguration()
        {
            SaveFailed = false;
            if (ID == "" && PreviousID != "")
                ID = PreviousID;
            Verify();
            if (!Valid)
            {
                string checkPath = GetFolderPath();
                if (!Mod.Header.VerifyModID(this.ID) || (PreviousID != ID && PreviousID != "" && System.IO.Directory.Exists(checkPath)))
                    ID = PreviousID;
            }
            if (PreviousID != ID && PreviousID != "")
            {
                string checkPath = GetFolderPath();
                if (checkPath == "" || System.IO.Directory.Exists(checkPath))
                {
                    ID = PreviousID;
                }
                else
                {
                    string previousPath = GetFolderPath(PreviousID);
                    string newPath = GetFolderPath(ID);
                    string previousProjectPath = newPath + System.IO.Path.DirectorySeparatorChar + PreviousID + ".csproj";
                    string newProjectPath = newPath + System.IO.Path.DirectorySeparatorChar + ID + ".csproj";
                    string previousSolutionPath = newPath + System.IO.Path.DirectorySeparatorChar + PreviousID + ".sln";
                    string newSolutionPath = newPath + System.IO.Path.DirectorySeparatorChar + ID + ".sln";
                    string previousSolutionUserOptionsPath = newPath + System.IO.Path.DirectorySeparatorChar + PreviousID + ".suo";
                    string newSolutionUserOptionsPath = newPath + System.IO.Path.DirectorySeparatorChar + ID + ".suo";
                    try
                    {
                        System.IO.Directory.Move(previousPath, newPath); 
                        if (System.IO.File.Exists(previousProjectPath))
                            System.IO.File.Move(previousProjectPath, newProjectPath);
                        if (System.IO.File.Exists(previousSolutionPath))
                            System.IO.File.Move(previousSolutionPath, newSolutionPath);
                        if (System.IO.File.Exists(previousSolutionUserOptionsPath))
                            System.IO.File.Move(previousSolutionUserOptionsPath, newSolutionUserOptionsPath);
                    }
                    catch (Exception e)
                    {
                        SaveFailed = true;
                        ID = PreviousID;
                        return;
                    }
                    PreviousID = ID;
                }
            }

            XDocument configuration = new XDocument();
            XElement rootElement = new XElement("Mod");
            rootElement.SetAttributeValue("ID", this.ID);

            rootElement.Add(new XElement("Compatible", this.Game.ModLibrary.GameVersion));

            XElement nameElement = new XElement("Name");
            foreach (string langKey in Languages)
            {
                XElement langElement = new XElement(langKey, this.Name.GetString(langKey));
                nameElement.Add(langElement);
            }

            XElement descriptionElement = new XElement("Description");
            foreach (string langKey in Languages)
            {
                XElement langElement = new XElement(langKey, this.Description.GetString(langKey));
                descriptionElement.Add(langElement);
            }
            XElement versionElement = new XElement("Version", this.Version);

            foreach (Button button in Buttons)
            {
                XElement buttonElement = button.GetXML();
                rootElement.Add(buttonElement);
            }

            rootElement.Add(nameElement);
            rootElement.Add(descriptionElement);
            rootElement.Add(versionElement);

            configuration.Add(rootElement);
            string path = GetFolderPath() + "ModInfo.xml";
            try
            {
                System.IO.File.WriteAllText(path, configuration.ToString());
            }
            catch (Exception e)
            {
                SaveFailed = true;
                return;
            }

            string projectPath = GetFolderPath() + System.IO.Path.DirectorySeparatorChar + ID + ".csproj";
            string solutionPath = GetFolderPath() + System.IO.Path.DirectorySeparatorChar + ID + ".sln";

            List<XElement> Compile = new List<XElement>();
            List<XElement> EmbeddedResources = new List<XElement>();
            List<Uri> ModLibrary = new List<Uri>();

            if (System.IO.File.Exists(projectPath)) 
            {
                XDocument projectFile = XDocument.Load(projectPath);

                foreach (XElement element in projectFile.Root.Elements())
                {
                    if (element.Name.LocalName == "ItemGroup")
                    {
                        foreach (XElement subElement in element.Elements())
                        {
                            if (subElement.Name.LocalName == "EmbeddedResource")
                            {
                                EmbeddedResources.Add(subElement);
                            }
                            if (subElement.Name.LocalName == "Compile")
                            {
                                Compile.Add(subElement);
                            }
                        }
                    }
                }
            }

            ModLibrary.Add(new Uri(System.IO.Path.GetFullPath(Configuration.GetPath("Libraries") + System.IO.Path.DirectorySeparatorChar + "BaseModLib.dll")));
            foreach (string assemblyPath in Game.GameConfiguration.IncludeAssemblies)
            {
                ModLibrary.Add(new Uri(System.IO.Path.GetFullPath(Game.ModLibrary.GetLibraryFolder() + System.IO.Path.DirectorySeparatorChar + Game.ParsePath(assemblyPath))));
            }
            foreach (string assemblyPath in Game.GameConfiguration.CopyAssemblies)
            {
                ModLibrary.Add(new Uri(System.IO.Path.GetFullPath(Game.ModLibrary.GetLibraryFolder() + System.IO.Path.DirectorySeparatorChar + Game.ParsePath(assemblyPath))));
            }

            Uri projectUri = new Uri(GetFolderPath());
            string references = "";
            string resources = "";
            string compiles = "";
            foreach (Uri uri in ModLibrary)
            {
                string filePath = projectUri.MakeRelativeUri(uri).ToString();
                references += "<Reference Include=\""+System.IO.Path.GetFileNameWithoutExtension(filePath)+"\">\r\n"+
"      <HintPath>"+filePath+"</HintPath>\r\n"+
"      <Private>False</Private>\r\n"+
"    </Reference>\r\n";
            }
            foreach (XElement resource in EmbeddedResources)
            {
                resources += resource.ToString().Replace("xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\"","") + "\r\n";
            }
            foreach (XElement compile in Compile)
            {
                compiles += compile.ToString().Replace("xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\"","") + "\r\n";
            }

            string projectText = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
"<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\r\n" +
"  <Import Project=\"$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props\" Condition=\"Exists('$(MSBuildExtensionsPath\\)\\$(MSBuildToolsVersion)\\Microsoft.Common.props')\" />\r\n" +
"  <PropertyGroup>\r\n" +
"    <Configuration Condition=\" '$(Configuration)' == '' \">Release</Configuration>\r\n" +
"    <Platform Condition=\" '$(Platform)' == '' \">x86</Platform>\r\n" +
"    <ProjectGuid>{53821041-E269-4717-BAED-3C9C6836E83F}</ProjectGuid>\r\n" +
"    <OutputType>Library</OutputType>\r\n" +
"    <AppDesignerFolder>Properties</AppDesignerFolder>\r\n" +
"    <RootNamespace>"+ID+"</RootNamespace>\r\n" +
"    <AssemblyName>"+ID+"</AssemblyName>\r\n" +
"    <TargetFrameworkVersion>v3.5</TargetFrameworkVersion>\r\n" +
"    <FileAlignment>512</FileAlignment>\r\n" +
"    <TargetFrameworkProfile />\r\n" +
"  </PropertyGroup>\r\n" +
"  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|x86' \">\r\n" +
"    <DebugType>pdbonly</DebugType>\r\n" +
"    <Optimize>true</Optimize>\r\n" +
"    <OutputPath>Mod\\</OutputPath>\r\n" +
"    <DefineConstants>TRACE</DefineConstants>\r\n" +
"    <ErrorReport>prompt</ErrorReport>\r\n" +
"    <WarningLevel>4</WarningLevel>\r\n" +
"  </PropertyGroup>\r\n" +
"  <ItemGroup>\r\n" +
"    "+resources+"\r\n" +
"  </ItemGroup>\r\n" +
"  <ItemGroup>\r\n" +
"    "+references+"\r\n" +
"  </ItemGroup>\r\n" +
"  <ItemGroup>\r\n" +
"    "+compiles+"\r\n" +
"  </ItemGroup>\r\n" +
"  <Import Project=\"$(MSBuildToolsPath)\\Microsoft.CSharp.targets\" />\r\n" +
"</Project>";

            string solutionText = "Microsoft Visual Studio Solution File, Format Version 12.00\r\n"+
"# Visual Studio 2013\r\n"+
"VisualStudioVersion = 12.0.21005.1\r\n"+
"MinimumVisualStudioVersion = 10.0.40219.1\r\n"+
"Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \""+ID+"\", \""+ID+".csproj\", \"{53821041-E269-4717-BAED-3C9C6836E83F}\"\r\n"+
"EndProject\r\n"+
"Global\r\n"+
"	GlobalSection(SolutionConfigurationPlatforms) = preSolution\r\n"+
"		Release|x86 = Release|x86\r\n"+
"	EndGlobalSection\r\n"+
"	GlobalSection(ProjectConfigurationPlatforms) = postSolution\r\n"+
"		{53821041-E269-4717-BAED-3C9C6836E83F}.Release|x86.ActiveCfg = Release|x86\r\n"+
"		{53821041-E269-4717-BAED-3C9C6836E83F}.Release|x86.Build.0 = Release|x86\r\n"+
"	EndGlobalSection\r\n"+
"	GlobalSection(SolutionProperties) = preSolution\r\n"+
"		HideSolutionNode = FALSE\r\n"+
"	EndGlobalSection\r\n"+
"EndGlobal";

            try
            {
                System.IO.File.WriteAllText(projectPath, projectText);
                System.IO.File.WriteAllText(solutionPath, solutionText);
            }
            catch (Exception e)
            {
                SaveFailed = true;
                return;
            }
        }

        public void LoadConfiguration()
        {
            try
            {
                string path = GetFolderPath() + "ModInfo.xml";
                this.Languages = new List<string>();
                if (System.IO.File.Exists(path))
                {
                    XDocument configuration = XDocument.Load(path);
                    this.ID = configuration.Root.Attribute("ID").Value;
                    this.Name = new MultilingualValue();
                    this.Name.SetXML(configuration.Root.Element("Name"));
                    this.Description = new MultilingualValue();
                    this.Description.SetXML(configuration.Root.Element("Description"));
                    this.Version = configuration.Root.Element("Version").Value;
                    this.Buttons = new List<Button>();

                    foreach (string k in this.Description.GetLanguages())
                        if (!Languages.Contains(k))
                            Languages.Add(k);
                    foreach (string k in this.Name.GetLanguages())
                        if (!Languages.Contains(k))
                            Languages.Add(k);
                    foreach (XElement button in configuration.Root.Elements("Button"))
                    {
                        Button b = new Button();
                        b.project = this;
                        b.ID = Utils.XMLHelper.GetXMLAttributeAsString(button, "ID", "");
                        b.StandardKey = Utils.XMLHelper.GetXMLAttributeAsString(button, "Standard", "");
                        b.Name = new MultilingualValue();
                        b.Name.SetXML(button.Element("Name"));
                        b.Description = new MultilingualValue();
                        b.Description.SetXML(button.Element("Description"));

                        foreach (string k in b.Description.GetLanguages())
                            if (!Languages.Contains(k))
                                Languages.Add(k);
                        foreach (string k in b.Name.GetLanguages())
                            if (!Languages.Contains(k))
                                Languages.Add(k);

                        Buttons.Add(b);
                    }
                }
            } 
            catch (Exception e)
            {

            }
        }

        public ModProject(Game game, string ID)
        {
            this.Game = game;
            this.ID = ID;
            PreviousID = ID;
            if (this.ID != "")
            {
                string path = GetFolderPath();
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                else
                {
                    LoadConfiguration();
                }
            }
        }

        protected string GetFolderPath(string ID = "")
        {
            if (ID == "") ID = this.ID;
            try
            {
                return System.IO.Path.GetFullPath(Configurations.Configuration.GetPath("Projects") + System.IO.Path.DirectorySeparatorChar + Game.GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + ID + System.IO.Path.DirectorySeparatorChar);
            }
            catch (Exception e)
            {
                return "";
            }
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


        public void Create(ProgressHandler progress)
        {
            string modFilePath = GetFolderPath() + System.IO.Path.DirectorySeparatorChar + "Mod" + System.IO.Path.DirectorySeparatorChar + this.ID + ".dll";
            if (!System.IO.File.Exists(modFilePath))
            {
                Debug.Log("Mod: "+ID, "Couldn't find the compiled mod dll at \""+modFilePath+"\".", Debug.Type.ERROR);
                SetProgress(progress, "Error.FileNotFound");
                return;
            }

            string modInfoPath = GetFolderPath() + System.IO.Path.DirectorySeparatorChar + "ModInfo.xml";
            if (!System.IO.File.Exists(modInfoPath))
            {
                Debug.Log("Mod: "+ID, "Couldn't find the mod configuration at \""+modInfoPath+"\".", Debug.Type.ERROR);
                SetProgress(progress, "Error.FileNotFound");
                return;
            }

            string libraryFolder = Game.ModLibrary.GetLibraryFolder();
            string baseModLibPath = libraryFolder + System.IO.Path.DirectorySeparatorChar + "BaseModLib.dll";

            if (!System.IO.File.Exists(baseModLibPath))
            {
                Debug.Log("Mod: "+ID, "Couldn't find BaseModLib.dll at \""+baseModLibPath+"\".", Debug.Type.ERROR);
                SetProgress(progress, "Error.FileNotFound");
                return;
            }

            ModuleDefinition modModule;
            ModuleDefinition baseModLib;
            try 
            {
                SetProgress(progress, 0f, "Preparing");
                baseModLib = ModuleDefinition.ReadModule(baseModLibPath);
                SetProgress(progress, 5f);
                modModule = ModuleDefinition.ReadModule(modFilePath);
                SetProgress(progress, 10f);
            } 
            catch (Exception e) 
            {
                Debug.Log("Mod: "+ID, "One of the assemblies is corrupted: "+e.ToString(), Debug.Type.ERROR);
                SetProgress(progress, "Error.CorruptAssembly");
                return;
            }

            Mod mod = new Mod(this.Game, "");
            mod.header = new Mod.Header(mod, System.IO.File.ReadAllText(modInfoPath));
            mod.module = modModule;
            MemoryStream stream = new MemoryStream();
            mod.module.Write(stream);
            stream.Position = 0;
            mod.originalModule = ModuleDefinition.ReadModule(stream);
            
            SetProgress(progress, 15f);

            try 
            {
                Dictionary<MethodReference, MethodReference> baseModLibRemap = new Dictionary<MethodReference, MethodReference>();
                foreach (TypeDefinition baseModLibType in baseModLib.Types)
                {
                    foreach (MethodDefinition method in baseModLibType.Methods)
                    {
                        if (method.HasCustomAttributes && method.CustomAttributes[0].AttributeType.Name == "AddModname")
                        {
                            foreach (MethodDefinition method2 in baseModLibType.Methods)
                            {
                                if (!method2.HasCustomAttributes && method2.Name == method.Name && method2.Parameters.Count > method.Parameters.Count)
                                {
                                    bool add = true;
                                    for (int i = 0; i < method.Parameters.Count; i++)
                                    {
                                        ParameterDefinition param = method.Parameters[i];
                                        if (param.ParameterType.FullName != method2.Parameters[i].ParameterType.FullName)
                                            add = false;
                                    }
                                    if (add)
                                    {
                                        baseModLibRemap.Add(method, method2);
                                    }
                                }
                            }
                        }
                    }
                }
                SetProgress(progress, 20f, "FetchingTypes");

                Dictionary<string, string> injectableClasses = new Dictionary<string, string>();
                Dictionary<string, Dictionary<string, TypeDefinition>> assemblyTypes = new Dictionary<string, Dictionary<string, TypeDefinition>>();
            
                for (int i = 0; i < Game.GameConfiguration.IncludeAssemblies.Count; i++)
                {
                    string assembly = libraryFolder + System.IO.Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.IncludeAssemblies[i]);
                    ModuleDefinition module = ModuleDefinition.ReadModule(assembly);
                    string key = System.IO.Path.GetFileNameWithoutExtension(assembly);
                    assemblyTypes.Add(key, new Dictionary<string, TypeDefinition>());
                    foreach (TypeDefinition type in module.Types)
                    {
                        if (!ModLib.CheckName(type.Namespace, Game.GameConfiguration.ExcludeNamespaces) && !ModLib.CheckName(type.FullName, Game.GameConfiguration.ExcludeTypes) && !ModLib.CheckName(type.FullName, Game.GameConfiguration.NoFamily))
                        {
                            assemblyTypes[key].Add(type.FullName, type);
                            if (!injectableClasses.ContainsKey(type.FullName))
                            {
                                injectableClasses.Add(type.FullName, key);
                            }
                        }
                    }
                    SetProgress(progress, 20f + ((float)i / (float)Game.GameConfiguration.IncludeAssemblies.Count) * 30f);
                }

                SetProgress(progress, 50f, "ConvertingClasses");
                Dictionary<string, TypeDefinition> newClasses = new Dictionary<string, TypeDefinition>();
                for (int i = 0; i < modModule.Types.Count; i++)
                {
                    TypeDefinition type = modModule.Types[i];
                    if (type.FullName == "<Module>")
                        continue;
                
                    foreach (MethodDefinition method in type.Methods)
                    {
                        if (method != null && method.Body != null)
                        {
                            for (int j = 0; j < method.Body.Instructions.Count; j++)
                            {
                                ILProcessor methodIL = method.Body.GetILProcessor();

                                Instruction instruction = method.Body.Instructions[j];
                                if (instruction.OpCode == OpCodes.Call && instruction.Operand != null)
                                {
                                    foreach (KeyValuePair<MethodReference, MethodReference> map in baseModLibRemap)
                                    {
                                        if (((MethodReference)instruction.Operand).FullName == map.Key.FullName)
                                        {
                                            instruction.Operand = type.Module.Import(map.Value);
                                            Instruction newInstruction = methodIL.Create(OpCodes.Ldstr, ID);
                                            methodIL.InsertBefore(instruction, newInstruction);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    string assemblyName = "";
                    if (type.BaseType != null && injectableClasses.ContainsKey(type.BaseType.FullName))
                        assemblyName = injectableClasses[type.BaseType.FullName];
                    if (assemblyName == "" || !assemblyTypes[assemblyName].ContainsKey(type.BaseType.FullName))
                    {
                        Mod.Header.AddClass addClass = new Mod.Header.AddClass(mod);
                        addClass.Type = type;
                        mod.header.AddAddClass(addClass);
                    }
                    else
                    {
                        foreach (Mono.Cecil.FieldDefinition field in type.Fields)
                        {
                            Mod.Header.AddField addField = new Mod.Header.AddField(mod);
                            addField.Field = field;
                            addField.AssemblyName = assemblyName;
                            mod.header.AddAddField(addField);
                        }
                        foreach (MethodDefinition method in type.Methods)
                        {
                            if (method == null) continue;
                            int priority = int.MaxValue;

                            if (method.CustomAttributes != null)
                            {
                                foreach (CustomAttribute attribute in method.CustomAttributes)
                                {
                                    if (attribute.AttributeType.Name == "Priority")
                                    {
                                        priority = (int)attribute.ConstructorArguments[0].Value;
                                    }
                                }
                            }

                            bool inject = false;
                            
                            if (method.IsVirtual || method.IsStatic || method.IsConstructor) 
                            {
                                foreach (MethodDefinition _m in assemblyTypes[assemblyName][type.BaseType.FullName].Methods)
                                {                
                                    if (_m.Name == method.Name)
                                    {
                                        if ((_m.IsStatic && method.IsStatic) || (_m.IsConstructor && method.IsConstructor))
                                        {
                                            if (method.Parameters.Count == _m.Parameters.Count)
                                            {
                                                bool ok = true;
                                                for (int pi = 0; pi < _m.Parameters.Count; pi++)
                                                {
                                                    ParameterDefinition param = _m.Parameters[pi];
                                                    if (param.ParameterType.FullName != method.Parameters[pi].ParameterType.FullName)
                                                    {
                                                        ok = false;
                                                        break;
                                                    }
                                                }
                                                if (ok)
                                                {
                                                    inject = true;
                                                }
                                            }
                                        }
                                        else if (!_m.IsStatic && !method.IsStatic) 
                                            inject = true;
                                        break;
                                    }
                                }
                            }

                            if (inject) 
                            {
                                Mod.Header.InjectInto injectInto = new Mod.Header.InjectInto(mod);
                                injectInto.Method = method;
                                injectInto.Priority = priority;
                                injectInto.AssemblyName = assemblyName;
                                mod.header.AddInjectInto(injectInto);
                            } 
                            else 
                            {
                                Mod.Header.AddMethod addMethod = new Mod.Header.AddMethod(mod);
                                addMethod.Method = method;
                                addMethod.AssemblyName = assemblyName;
                                mod.header.AddAddMethod(addMethod);
                            }
                        }
                    }
                    SetProgress(progress, 50f + ((float)i / (float)modModule.Types.Count) * 30f);
                }

                foreach (AssemblyNameReference aref in modModule.AssemblyReferences)
                {
                    if (aref.Name == "mscorlib" || aref.Name == "System")
                    {
                        aref.Version = new System.Version("2.0.0.0");
                        aref.PublicKeyToken = new byte[] { 0xB7, 0x7A, 0x5C, 0x56, 0x19, 0x34, 0xE0, 0x89 };
                    }
                    if (aref.Name == "System.Core")
                    {
                        aref.Version = new System.Version("3.5.0.0");
                        aref.PublicKeyToken = new byte[] { 0xB7, 0x7A, 0x5C, 0x56, 0x19, 0x34, 0xE0, 0x89 };
                    }
                    if (aref.Name == "System.Xml")
                    {
                        aref.Version = new System.Version("2.0.0.0");
                        aref.PublicKeyToken = new byte[] { 0xB7, 0x7A, 0x5C, 0x56, 0x19, 0x34, 0xE0, 0x89 };
                    }
                }
            } 
            catch (Exception e) 
            {
                Debug.Log("Mod: "+ID, "An unexpected error occured while parsing the assembly: "+e.ToString(), Debug.Type.ERROR);
                SetProgress(progress, "Error.UnexpectedError");
                return;
            }

            
            string modResourcesPath = GetFolderPath() + System.IO.Path.DirectorySeparatorChar + "Resources/";
            if (!System.IO.Directory.Exists(modResourcesPath))
            {
                System.IO.Directory.CreateDirectory(modResourcesPath);
            }
            if (System.IO.Directory.GetFiles(modResourcesPath).Length > 0 || System.IO.Directory.GetDirectories(modResourcesPath).Length > 0)
            {
                ZipFile newZipFile = new ZipFile();
                newZipFile.AddDirectory(modResourcesPath); 
                newZipFile.Comment = "Automaticlly created resources zip file.";
                mod.Resources = newZipFile;
            }
            
            
            try 
            {
                SetProgress(progress, 90f, "SavingMod");

                
                string modFolder = System.IO.Path.GetFullPath(Configuration.GetPath("mods") + System.IO.Path.DirectorySeparatorChar + Game.GameConfiguration.ID);

                if (!System.IO.Directory.Exists(modFolder))
                    System.IO.Directory.CreateDirectory(modFolder);

                mod.FileName = System.IO.Path.GetFullPath(modFolder + System.IO.Path.DirectorySeparatorChar + mod.UniqueID + ".mod");
                if (mod.Save()) 
                {
                    string key = mod.ID + "-" + mod.header.GetVersion();
                    if (Mod.Mods.ContainsKey(key)) 
                    {
                        if (Mod.Mods[key].FileName != mod.FileName)
                            Mod.Mods[key].Remove();
                        //Mod.Mods[key] = mod;
                    } 
                    /*else 
                    {
                        Mod.Mods.Add(key, mod);
                    }*/
                    SetProgress(progress, 100f, "Finish");
                } 
                else 
                {
                    Debug.Log("Mod: "+ID, "Could not save the mod.", Debug.Type.ERROR);
                    SetProgress(progress, "Error.Save");
                }
            } 
            catch (Exception e) 
            {
                Debug.Log("Mod: "+ID, "An error occured while saving the mod: "+e.ToString(), Debug.Type.ERROR);
                SetProgress(progress, "Error.Save");
            }
        }

    }
}
