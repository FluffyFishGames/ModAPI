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
using System.Xml.Linq;
using Ionic.Zip;
using ModAPI.Configurations;
using ModAPI.Utils;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Path = System.IO.Path;

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

        public List<string> Languages = new List<string> { "EN" };
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
                var buttonElement = new XElement("Button");
                if (StandardKey != "")
                {
                    buttonElement.SetAttributeValue("Standard", StandardKey);
                }
                buttonElement.SetAttributeValue("ID", ID);

                var nameElement = new XElement("Name");
                foreach (var langKey in project.Languages)
                {
                    var langElement = new XElement(langKey, Name.GetString(langKey));
                    nameElement.Add(langElement);
                }
                buttonElement.Add(nameElement);

                var descriptionElement = new XElement("Description");
                foreach (var langKey in project.Languages)
                {
                    var langElement = new XElement(langKey, Description.GetString(langKey));
                    descriptionElement.Add(langElement);
                }
                buttonElement.Add(descriptionElement);

                return buttonElement;
            }
        }

        public bool Valid;

        public void Verify()
        {
            Valid = false;
            if (!Mod.Header.VerifyModVersion(Version) || !Mod.Header.VerifyModID(ID))
            {
                return;
            }

            foreach (var langKey in Languages)
            {
                if (Name.GetString(langKey).Trim() == "")
                {
                    return;
                }
            }

            var ButtonIDs = new List<string>();
            foreach (var b in Buttons)
            {
                if (ButtonIDs.Contains(b.ID))
                {
                    return;
                }
                foreach (var langKey in Languages)
                {
                    if (b.Name.GetString(langKey).Trim() == "")
                    {
                        return;
                    }
                }
                ButtonIDs.Add(b.ID);
            }

            Valid = true;
        }

        public bool SaveFailed;

        public void Remove()
        {
            var path = GetFolderPath();
            Directory.Delete(path, true);
        }

        public void SaveConfiguration()
        {
            SaveFailed = false;
            if (ID == "" && PreviousID != "")
            {
                ID = PreviousID;
            }
            Verify();
            if (!Valid)
            {
                var checkPath = GetFolderPath();
                if (!Mod.Header.VerifyModID(ID) || (PreviousID != ID && PreviousID != "" && Directory.Exists(checkPath)))
                {
                    ID = PreviousID;
                }
            }
            if (PreviousID != ID && PreviousID != "")
            {
                var checkPath = GetFolderPath();
                if (checkPath == "" || Directory.Exists(checkPath))
                {
                    ID = PreviousID;
                }
                else
                {
                    var previousPath = GetFolderPath(PreviousID);
                    var newPath = GetFolderPath(ID);
                    var previousProjectPath = newPath + Path.DirectorySeparatorChar + PreviousID + ".csproj";
                    var newProjectPath = newPath + Path.DirectorySeparatorChar + ID + ".csproj";
                    var previousSolutionPath = newPath + Path.DirectorySeparatorChar + PreviousID + ".sln";
                    var newSolutionPath = newPath + Path.DirectorySeparatorChar + ID + ".sln";
                    var previousSolutionUserOptionsPath = newPath + Path.DirectorySeparatorChar + PreviousID + ".suo";
                    var newSolutionUserOptionsPath = newPath + Path.DirectorySeparatorChar + ID + ".suo";
                    try
                    {
                        Directory.Move(previousPath, newPath);
                        if (File.Exists(previousProjectPath))
                        {
                            File.Move(previousProjectPath, newProjectPath);
                        }
                        if (File.Exists(previousSolutionPath))
                        {
                            File.Move(previousSolutionPath, newSolutionPath);
                        }
                        if (File.Exists(previousSolutionUserOptionsPath))
                        {
                            File.Move(previousSolutionUserOptionsPath, newSolutionUserOptionsPath);
                        }
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

            var configuration = new XDocument();
            var rootElement = new XElement("Mod");
            rootElement.SetAttributeValue("ID", ID);

            rootElement.Add(new XElement("Compatible", Game.ModLibrary.GameVersion));

            var nameElement = new XElement("Name");
            foreach (var langKey in Languages)
            {
                var langElement = new XElement(langKey, Name.GetString(langKey));
                nameElement.Add(langElement);
            }

            var descriptionElement = new XElement("Description");
            foreach (var langKey in Languages)
            {
                var langElement = new XElement(langKey, Description.GetString(langKey));
                descriptionElement.Add(langElement);
            }
            var versionElement = new XElement("Version", Version);

            foreach (var button in Buttons)
            {
                var buttonElement = button.GetXML();
                rootElement.Add(buttonElement);
            }

            rootElement.Add(nameElement);
            rootElement.Add(descriptionElement);
            rootElement.Add(versionElement);

            configuration.Add(rootElement);
            var path = GetFolderPath() + "ModInfo.xml";
            try
            {
                File.WriteAllText(path, configuration.ToString());
            }
            catch (Exception e)
            {
                SaveFailed = true;
                return;
            }

            var projectPath = GetFolderPath() + Path.DirectorySeparatorChar + ID + ".csproj";
            var solutionPath = GetFolderPath() + Path.DirectorySeparatorChar + ID + ".sln";

            var Compile = new List<XElement>();
            var EmbeddedResources = new List<XElement>();
            var ModLibrary = new List<Uri>();

            if (File.Exists(projectPath))
            {
                var projectFile = XDocument.Load(projectPath);

                foreach (var element in projectFile.Root.Elements())
                {
                    if (element.Name.LocalName == "ItemGroup")
                    {
                        foreach (var subElement in element.Elements())
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

            ModLibrary.Add(new Uri(Path.GetFullPath(Configuration.GetPath("Libraries") + Path.DirectorySeparatorChar + "BaseModLib.dll")));
            foreach (var assemblyPath in Game.GameConfiguration.IncludeAssemblies)
            {
                ModLibrary.Add(new Uri(Path.GetFullPath(Game.ModLibrary.GetLibraryFolder() + Path.DirectorySeparatorChar + Game.ParsePath(assemblyPath))));
            }
            foreach (var assemblyPath in Game.GameConfiguration.CopyAssemblies)
            {
                ModLibrary.Add(new Uri(Path.GetFullPath(Game.ModLibrary.GetLibraryFolder() + Path.DirectorySeparatorChar + Game.ParsePath(assemblyPath))));
            }

            var projectUri = new Uri(GetFolderPath());
            var references = "";
            var resources = "";
            var compiles = "";
            foreach (var uri in ModLibrary)
            {
                var filePath = projectUri.MakeRelativeUri(uri).ToString();
                references += "<Reference Include=\"" + Path.GetFileNameWithoutExtension(filePath) + "\">\r\n" +
                              "      <HintPath>" + filePath + "</HintPath>\r\n" +
                              "      <Private>False</Private>\r\n" +
                              "    </Reference>\r\n";
            }
            foreach (var resource in EmbeddedResources)
            {
                resources += resource.ToString().Replace("xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\"", "") + "\r\n";
            }
            foreach (var compile in Compile)
            {
                compiles += compile.ToString().Replace("xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\"", "") + "\r\n";
            }

            var projectText = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                              "<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\r\n" +
                              "  <Import Project=\"$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props\" Condition=\"Exists('$(MSBuildExtensionsPath\\)\\$(MSBuildToolsVersion)\\Microsoft.Common.props')\" />\r\n" +
                              "  <PropertyGroup>\r\n" +
                              "    <Configuration Condition=\" '$(Configuration)' == '' \">Release</Configuration>\r\n" +
                              "    <Platform Condition=\" '$(Platform)' == '' \">x86</Platform>\r\n" +
                              "    <ProjectGuid>{53821041-E269-4717-BAED-3C9C6836E83F}</ProjectGuid>\r\n" +
                              "    <OutputType>Library</OutputType>\r\n" +
                              "    <AppDesignerFolder>Properties</AppDesignerFolder>\r\n" +
                              "    <RootNamespace>" + ID + "</RootNamespace>\r\n" +
                              "    <AssemblyName>" + ID + "</AssemblyName>\r\n" +
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
                              "    " + resources + "\r\n" +
                              "  </ItemGroup>\r\n" +
                              "  <ItemGroup>\r\n" +
                              "    " + references + "\r\n" +
                              "  </ItemGroup>\r\n" +
                              "  <ItemGroup>\r\n" +
                              "    " + compiles + "\r\n" +
                              "  </ItemGroup>\r\n" +
                              "  <Import Project=\"$(MSBuildToolsPath)\\Microsoft.CSharp.targets\" />\r\n" +
                              "</Project>";

            var solutionText = "Microsoft Visual Studio Solution File, Format Version 12.00\r\n" +
                               "# Visual Studio 15\r\n" +
                               "VisualStudioVersion = 15.0.26403.7\r\n" +
                               "MinimumVisualStudioVersion = 10.0.40219.1\r\n" +
                               "Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"" + ID + "\", \"" + ID + ".csproj\", \"{53821041-E269-4717-BAED-3C9C6836E83F}\"\r\n" +
                               "EndProject\r\n" +
                               "Global\r\n" +
                               "	GlobalSection(SolutionConfigurationPlatforms) = preSolution\r\n" +
                               "		Release|x86 = Release|x86\r\n" +
                               "	EndGlobalSection\r\n" +
                               "	GlobalSection(ProjectConfigurationPlatforms) = postSolution\r\n" +
                               "		{53821041-E269-4717-BAED-3C9C6836E83F}.Release|x86.ActiveCfg = Release|x86\r\n" +
                               "		{53821041-E269-4717-BAED-3C9C6836E83F}.Release|x86.Build.0 = Release|x86\r\n" +
                               "	EndGlobalSection\r\n" +
                               "	GlobalSection(SolutionProperties) = preSolution\r\n" +
                               "		HideSolutionNode = FALSE\r\n" +
                               "	EndGlobalSection\r\n" +
                               "EndGlobal\r\n";

            try
            {
                File.WriteAllText(projectPath, projectText);
                File.WriteAllText(solutionPath, solutionText);
            }
            catch (Exception e)
            {
                SaveFailed = true;
            }
        }

        public void LoadConfiguration()
        {
            try
            {
                var path = GetFolderPath() + "ModInfo.xml";
                Languages = new List<string>();
                if (File.Exists(path))
                {
                    var configuration = XDocument.Load(path);
                    ID = configuration.Root.Attribute("ID").Value;
                    Name = new MultilingualValue();
                    Name.SetXML(configuration.Root.Element("Name"));
                    Description = new MultilingualValue();
                    Description.SetXML(configuration.Root.Element("Description"));
                    Version = configuration.Root.Element("Version").Value;
                    Buttons = new List<Button>();

                    foreach (var k in Description.GetLanguages())
                    {
                        if (!Languages.Contains(k))
                        {
                            Languages.Add(k);
                        }
                    }
                    foreach (var k in Name.GetLanguages())
                    {
                        if (!Languages.Contains(k))
                        {
                            Languages.Add(k);
                        }
                    }
                    foreach (var button in configuration.Root.Elements("Button"))
                    {
                        var b = new Button();
                        b.project = this;
                        b.ID = XMLHelper.GetXMLAttributeAsString(button, "ID", "");
                        b.StandardKey = XMLHelper.GetXMLAttributeAsString(button, "Standard", "");
                        b.Name = new MultilingualValue();
                        b.Name.SetXML(button.Element("Name"));
                        b.Description = new MultilingualValue();
                        b.Description.SetXML(button.Element("Description"));

                        foreach (var k in b.Description.GetLanguages())
                        {
                            if (!Languages.Contains(k))
                            {
                                Languages.Add(k);
                            }
                        }
                        foreach (var k in b.Name.GetLanguages())
                        {
                            if (!Languages.Contains(k))
                            {
                                Languages.Add(k);
                            }
                        }

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
            Game = game;
            this.ID = ID;
            PreviousID = ID;
            if (this.ID != "")
            {
                var path = GetFolderPath();
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    LoadConfiguration();
                }
            }
        }

        protected string GetFolderPath(string ID = "")
        {
            if (ID == "")
            {
                ID = this.ID;
            }
            try
            {
                return Path.GetFullPath(Configuration.GetPath("Projects") + Path.DirectorySeparatorChar + Game.GameConfiguration.ID +
                                        Path.DirectorySeparatorChar + ID + Path.DirectorySeparatorChar);
            }
            catch (Exception e)
            {
                return "";
            }
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

        public void Create(ProgressHandler progress)
        {
            var modFilePath = GetFolderPath() + Path.DirectorySeparatorChar + "Mod" + Path.DirectorySeparatorChar + ID + ".dll";
            if (!File.Exists(modFilePath))
            {
                Debug.Log("Mod: " + ID, "Couldn't find the compiled mod dll at \"" + modFilePath + "\".", Debug.Type.ERROR);
                SetProgress(progress, "Error.FileNotFound");
                return;
            }

            var modInfoPath = GetFolderPath() + Path.DirectorySeparatorChar + "ModInfo.xml";
            if (!File.Exists(modInfoPath))
            {
                Debug.Log("Mod: " + ID, "Couldn't find the mod configuration at \"" + modInfoPath + "\".", Debug.Type.ERROR);
                SetProgress(progress, "Error.FileNotFound");
                return;
            }

            var libraryFolder = Game.ModLibrary.GetLibraryFolder();
            var baseModLibPath = libraryFolder + Path.DirectorySeparatorChar + "BaseModLib.dll";

            if (!File.Exists(baseModLibPath))
            {
                Debug.Log("Mod: " + ID, "Couldn't find BaseModLib.dll at \"" + baseModLibPath + "\".", Debug.Type.ERROR);
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
                var assemblyResolver = new CustomAssemblyResolver();
                assemblyResolver.AddPath(Configuration.GetPath("ModLib") + Path.DirectorySeparatorChar + Game.GameConfiguration.ID +
                                         Path.DirectorySeparatorChar);
                modModule = ModuleDefinition.ReadModule(modFilePath, new ReaderParameters
                {
                    AssemblyResolver = assemblyResolver
                });
                SetProgress(progress, 10f);
            }
            catch (Exception e)
            {
                Debug.Log("Mod: " + ID, "One of the assemblies is corrupted: " + e, Debug.Type.ERROR);
                SetProgress(progress, "Error.CorruptAssembly");
                return;
            }

            var mod = new Mod(Game, "");
            mod.header = new Mod.Header(mod, File.ReadAllText(modInfoPath));
            mod.module = modModule;
            var stream = new MemoryStream();

            mod.module.Write(stream);
            stream.Position = 0;
            mod.originalModule = ModuleDefinition.ReadModule(stream);

            SetProgress(progress, 15f);

            try
            {
                var baseModLibRemap = new Dictionary<MethodReference, MethodReference>();
                foreach (var baseModLibType in baseModLib.Types)
                {
                    foreach (var method in baseModLibType.Methods)
                    {
                        if (method.HasCustomAttributes && method.CustomAttributes[0].AttributeType.Name == "AddModname")
                        {
                            foreach (var method2 in baseModLibType.Methods)
                            {
                                if (!method2.HasCustomAttributes && method2.Name == method.Name && method2.Parameters.Count > method.Parameters.Count)
                                {
                                    var add = true;
                                    for (var i = 0; i < method.Parameters.Count; i++)
                                    {
                                        var param = method.Parameters[i];
                                        if (param.ParameterType.FullName != method2.Parameters[i].ParameterType.FullName)
                                        {
                                            add = false;
                                        }
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

                var injectableClasses = new Dictionary<string, string>();
                var assemblyTypes = new Dictionary<string, Dictionary<string, TypeDefinition>>();

                for (var i = 0; i < Game.GameConfiguration.IncludeAssemblies.Count; i++)
                {
                    var assembly = libraryFolder + Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.IncludeAssemblies[i]);
                    var module = ModuleDefinition.ReadModule(assembly);
                    var key = Path.GetFileNameWithoutExtension(assembly);
                    assemblyTypes.Add(key, new Dictionary<string, TypeDefinition>());
                    foreach (var type in module.Types)
                    {
                        if (!ModLib.CheckName(type.Namespace, Game.GameConfiguration.ExcludeNamespaces) && !ModLib.CheckName(type.FullName, Game.GameConfiguration.ExcludeTypes) &&
                            !ModLib.CheckName(type.FullName, Game.GameConfiguration.NoFamily))
                        {
                            assemblyTypes[key].Add(type.FullName, type);
                            if (!injectableClasses.ContainsKey(type.FullName))
                            {
                                injectableClasses.Add(type.FullName, key);
                            }
                        }
                    }
                    SetProgress(progress, 20f + (i / (float) Game.GameConfiguration.IncludeAssemblies.Count) * 30f);
                }

                SetProgress(progress, 50f, "ConvertingClasses");
                var newClasses = new Dictionary<string, TypeDefinition>();
                for (var i = 0; i < modModule.Types.Count; i++)
                {
                    var type = modModule.Types[i];
                    if (type.FullName == "<Module>")
                    {
                        continue;
                    }

                    foreach (var method in type.Methods)
                    {
                        if (method?.Body != null)
                        {
                            for (var j = 0; j < method.Body.Instructions.Count; j++)
                            {
                                var methodIL = method.Body.GetILProcessor();

                                var instruction = method.Body.Instructions[j];
                                if (instruction.OpCode == OpCodes.Call && instruction.Operand != null)
                                {
                                    foreach (var map in baseModLibRemap)
                                    {
                                        if (((MethodReference) instruction.Operand).FullName == map.Key.FullName)
                                        {
                                            instruction.Operand = type.Module.Import(map.Value);
                                            var newInstruction = methodIL.Create(OpCodes.Ldstr, ID);
                                            methodIL.InsertBefore(instruction, newInstruction);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    var assemblyName = "";
                    if (type.BaseType != null && injectableClasses.ContainsKey(type.BaseType.FullName))
                    {
                        assemblyName = injectableClasses[type.BaseType.FullName];
                    }
                    if (assemblyName == "" || !assemblyTypes[assemblyName].ContainsKey(type.BaseType.FullName))
                    {
                        var addClass = new Mod.Header.AddClass(mod) { Type = type };
                        mod.header.AddAddClass(addClass);
                    }
                    else
                    {
                        foreach (var field in type.Fields)
                        {
                            var addField = new Mod.Header.AddField(mod)
                            {
                                Field = field,
                                AssemblyName = assemblyName
                            };
                            mod.header.AddAddField(addField);
                        }
                        foreach (var method in type.Methods)
                        {
                            if (method == null)
                            {
                                continue;
                            }
                            var priority = int.MaxValue;

                            if (method.CustomAttributes != null)
                            {
                                foreach (var attribute in method.CustomAttributes)
                                {
                                    if (attribute.AttributeType.Name == "Priority")
                                    {
                                        priority = (int) attribute.ConstructorArguments[0].Value;
                                    }
                                }
                            }

                            var inject = false;

                            if (method.IsVirtual || method.IsStatic || method.IsConstructor)
                            {
                                foreach (var _m in assemblyTypes[assemblyName][type.BaseType.FullName].Methods)
                                {
                                    if (_m.Name == method.Name)
                                    {
                                        if ((_m.IsStatic && method.IsStatic) || (_m.IsConstructor && method.IsConstructor))
                                        {
                                            if (method.Parameters.Count == _m.Parameters.Count)
                                            {
                                                var ok = !_m.Parameters.Where((param, pi) => param.ParameterType.FullName != method.Parameters[pi].ParameterType.FullName).Any();
                                                if (ok)
                                                {
                                                    inject = true;
                                                }
                                            }
                                        }
                                        else if (!_m.IsStatic && !method.IsStatic)
                                        {
                                            inject = true;
                                        }
                                        break;
                                    }
                                }
                            }

                            if (inject)
                            {
                                var injectInto = new Mod.Header.InjectInto(mod)
                                {
                                    Method = method,
                                    Priority = priority,
                                    AssemblyName = assemblyName
                                };
                                mod.header.AddInjectInto(injectInto);
                            }
                            else
                            {
                                var addMethod = new Mod.Header.AddMethod(mod)
                                {
                                    Method = method,
                                    AssemblyName = assemblyName
                                };
                                mod.header.AddAddMethod(addMethod);
                            }
                        }
                    }
                    SetProgress(progress, 50f + (i / (float) modModule.Types.Count) * 30f);
                }

                foreach (var aref in modModule.AssemblyReferences)
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
                Debug.Log("Mod: " + ID, "An unexpected error occured while parsing the assembly: " + e, Debug.Type.ERROR);
                SetProgress(progress, "Error.UnexpectedError");
                return;
            }

            var modResourcesPath = GetFolderPath() + Path.DirectorySeparatorChar + "Resources/";
            if (!Directory.Exists(modResourcesPath))
            {
                Directory.CreateDirectory(modResourcesPath);
            }
            if (Directory.GetFiles(modResourcesPath).Length > 0 || Directory.GetDirectories(modResourcesPath).Length > 0)
            {
                var newZipFile = new ZipFile();
                newZipFile.AddDirectory(modResourcesPath);
                newZipFile.Comment = "Automaticlly created resources zip file.";
                mod.Resources = newZipFile;
            }

            try
            {
                SetProgress(progress, 90f, "SavingMod");

                var modFolder = Path.GetFullPath(Configuration.GetPath("mods") + Path.DirectorySeparatorChar + Game.GameConfiguration.ID);

                if (!Directory.Exists(modFolder))
                {
                    Directory.CreateDirectory(modFolder);
                }

                mod.FileName = Path.GetFullPath(modFolder + Path.DirectorySeparatorChar + mod.UniqueID + ".mod");
                if (mod.Save())
                {
                    var key = mod.ID + "-" + mod.header.GetVersion();
                    if (Mod.Mods.ContainsKey(key))
                    {
                        if (Mod.Mods[key].FileName != mod.FileName)
                        {
                            Mod.Mods[key].Remove();
                        }
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
                    Debug.Log("Mod: " + ID, "Could not save the mod.", Debug.Type.ERROR);
                    SetProgress(progress, "Error.Save");
                }
            }
            catch (Exception e)
            {
                Debug.Log("Mod: " + ID, "An error occured while saving the mod: " + e, Debug.Type.ERROR);
                SetProgress(progress, "Error.Save");
            }
        }
    }
}
