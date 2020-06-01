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
        public string Id;
        protected string PreviousId;
        public Game Game;
        public MultilingualValue Name = new MultilingualValue();
        public MultilingualValue Description = new MultilingualValue();
        public string Version = "1.0.0.0";

        public List<string> Languages = new List<string> { "EN" };
        public List<Button> Buttons = new List<Button>();

        public class Button
        {
            public ModProject Project;
            public string Id;
            public string StandardKey;
            public MultilingualValue Name = new MultilingualValue();
            public MultilingualValue Description = new MultilingualValue();

            public XElement GetXml()
            {
                var buttonElement = new XElement("Button");
                if (StandardKey != "")
                {
                    buttonElement.SetAttributeValue("Standard", StandardKey);
                }
                buttonElement.SetAttributeValue("ID", Id);

                var nameElement = new XElement("Name");
                foreach (var langKey in Project.Languages)
                {
                    var langElement = new XElement(langKey, Name.GetString(langKey));
                    nameElement.Add(langElement);
                }
                buttonElement.Add(nameElement);

                var descriptionElement = new XElement("Description");
                foreach (var langKey in Project.Languages)
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
            if (!Mod.Header.VerifyModVersion(Version) || !Mod.Header.VerifyModId(Id))
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

            var buttonIDs = new List<string>();
            foreach (var b in Buttons)
            {
                if (buttonIDs.Contains(b.Id))
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
                buttonIDs.Add(b.Id);
            }

            Valid = true;
        }

        public bool SaveFailed;

        public void Remove()
        {
            var path = GetFolderPath();
            Directory.Delete(path, true);
        }

        /// <summary>Checks if character is alphanumeric.</summary>
        /// <param name="c">The character to test.</param>
        /// <returns>Returns true if character is alphanumeric, false otherwise.</returns>
        public bool IsAlphaNum(char c) => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9');

        /// <summary>Removes all special characters from given string (keeps only alphanumeric characters).</summary>
        /// <param name="str">The string we want to remove special characters from.</param>
        /// <returns>Returns a string composed of alphanumeric characters only.</returns>
        public string ToAlphaNum(string str)
        {
            string alphaNumStr = "";
            if (!string.IsNullOrEmpty(str))
                for (int i = 0; i < str.Length; i++)
                    if (IsAlphaNum(str[i]))
                        alphaNumStr += str[i];
            return alphaNumStr;
        }

        /// <summary>Generates a unique alias for given library name (removes all special characters and makes sure it has not already been attributed).</summary>
        /// <param name="existingAliases">The list of already DLL attributed aliases.</param>
        /// <param name="libName">The library name we want an alias for.</param>
        /// <returns>Returns a unique alias (in case <paramref name="libName"/> is null, empty or does not contains any alphanumeric character, returns the string "lib").</returns>
        public string GetUniqueAliasForLib(ref List<string> existingAliases, string libName)
        {
            libName = ToAlphaNum(libName);
            if (string.IsNullOrEmpty(libName))
                libName = "lib";
            if (existingAliases != null)
            {
                if (existingAliases.Contains(libName))
                {
                    int i = 1;
                    while (existingAliases.Contains(libName + i.ToString()))
                        i++;
                    libName += i.ToString();
                }
                existingAliases.Add(libName);
            }
            return libName;
        }

        public void SaveConfiguration()
        {
            SaveFailed = false;
            if (Id == "" && PreviousId != "")
            {
                Id = PreviousId;
            }
            Verify();
            if (!Valid)
            {
                var checkPath = GetFolderPath();
                if (!Mod.Header.VerifyModId(Id) || (PreviousId != Id && PreviousId != "" && Directory.Exists(checkPath)))
                {
                    Id = PreviousId;
                }
            }
            if (PreviousId != Id && PreviousId != "")
            {
                var checkPath = GetFolderPath();
                if (checkPath == "" || Directory.Exists(checkPath))
                {
                    Id = PreviousId;
                }
                else
                {
                    var previousPath = GetFolderPath(PreviousId);
                    var newPath = GetFolderPath(Id);
                    var previousProjectPath = newPath + Path.DirectorySeparatorChar + PreviousId + ".csproj";
                    var newProjectPath = newPath + Path.DirectorySeparatorChar + Id + ".csproj";
                    var previousSolutionPath = newPath + Path.DirectorySeparatorChar + PreviousId + ".sln";
                    var newSolutionPath = newPath + Path.DirectorySeparatorChar + Id + ".sln";
                    var previousSolutionUserOptionsPath = newPath + Path.DirectorySeparatorChar + PreviousId + ".suo";
                    var newSolutionUserOptionsPath = newPath + Path.DirectorySeparatorChar + Id + ".suo";
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
                        Id = PreviousId;
                        return;
                    }
                    PreviousId = Id;
                }
            }

            var configuration = new XDocument();
            var rootElement = new XElement("Mod");
            rootElement.SetAttributeValue("ID", Id);

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
                var buttonElement = button.GetXml();
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

            var projectPath = GetFolderPath() + Path.DirectorySeparatorChar + Id + ".csproj";
            var solutionPath = GetFolderPath() + Path.DirectorySeparatorChar + Id + ".sln";

            var Compile = new List<XElement>();
            var embeddedResources = new List<XElement>();
            var modLibrary = new List<Uri>();

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
                                embeddedResources.Add(subElement);
                            }
                            if (subElement.Name.LocalName == "Compile")
                            {
                                Compile.Add(subElement);
                            }
                        }
                    }
                }
            }

            modLibrary.Add(new Uri(Path.GetFullPath(Configuration.GetPath("Libraries") + Path.DirectorySeparatorChar + "BaseModLib.dll")));
            foreach (var assemblyPath in Game.GameConfiguration.IncludeAssemblies)
            {
                modLibrary.Add(new Uri(Path.GetFullPath(Game.ModLibrary.GetLibraryFolder() + Path.DirectorySeparatorChar + Game.ParsePath(assemblyPath))));
            }
            foreach (var assemblyPath in Game.GameConfiguration.CopyAssemblies)
            {
                modLibrary.Add(new Uri(Path.GetFullPath(Game.ModLibrary.GetLibraryFolder() + Path.DirectorySeparatorChar + Game.ParsePath(assemblyPath))));
            }

            var projectUri = new Uri(GetFolderPath());
            var references = "";
            var resources = "";
            var compiles = "";
            var uniqueAliases = new List<string>();
            foreach (var uri in modLibrary)
            {
                var filePath = projectUri.MakeRelativeUri(uri).ToString();
                var libName = Path.GetFileNameWithoutExtension(filePath);
                references += "<Reference Include=\"" + libName + "\">\r\n" +
                              "      <HintPath>" + filePath + "</HintPath>\r\n" +
                              "      <Aliases>global," + GetUniqueAliasForLib(ref uniqueAliases, libName) + "</Aliases>\r\n" + // Allows to avoid compilation errors when a class has same namespace defined in two different DLLs.
                              "      <Private>False</Private>\r\n" +
                              "    </Reference>\r\n";
            }
            foreach (var resource in embeddedResources)
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
                              "    <RootNamespace>" + Id + "</RootNamespace>\r\n" +
                              "    <AssemblyName>" + Id + "</AssemblyName>\r\n" +
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
                               "Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"" + Id + "\", \"" + Id + ".csproj\", \"{53821041-E269-4717-BAED-3C9C6836E83F}\"\r\n" +
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
                if (!File.Exists(projectPath))
                    File.WriteAllText(projectPath, projectText);
                if (!File.Exists(solutionPath))
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
                    Id = configuration.Root.Attribute("ID").Value;
                    Name = new MultilingualValue();
                    Name.SetXml(configuration.Root.Element("Name"));
                    Description = new MultilingualValue();
                    Description.SetXml(configuration.Root.Element("Description"));
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
                        var b = new Button
                        {
                            Project = this,
                            Id = XmlHelper.GetXmlAttributeAsString(button, "ID"),
                            StandardKey = XmlHelper.GetXmlAttributeAsString(button, "Standard"),
                            Name = new MultilingualValue()
                        };
                        b.Name.SetXml(button.Element("Name"));
                        b.Description = new MultilingualValue();
                        b.Description.SetXml(button.Element("Description"));

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

        public ModProject(Game game, string id)
        {
            Game = game;
            Id = id;
            PreviousId = id;
            if (Id != "")
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

        protected string GetFolderPath(string id = "")
        {
            if (id == "")
            {
                id = Id;
            }
            try
            {
                return Path.GetFullPath(Configuration.GetPath("Projects") + Path.DirectorySeparatorChar + Game.GameConfiguration.Id +
                                        Path.DirectorySeparatorChar + id + Path.DirectorySeparatorChar);
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
            var modFilePath = GetFolderPath() + Path.DirectorySeparatorChar + "Mod" + Path.DirectorySeparatorChar + Id + ".dll";
            if (!File.Exists(modFilePath))
            {
                Debug.Log("Mod: " + Id, "Couldn't find the compiled mod dll at \"" + modFilePath + "\".", Debug.Type.Error);
                SetProgress(progress, "Error.FileNotFound");
                return;
            }

            var modInfoPath = GetFolderPath() + Path.DirectorySeparatorChar + "ModInfo.xml";
            if (!File.Exists(modInfoPath))
            {
                Debug.Log("Mod: " + Id, "Couldn't find the mod configuration at \"" + modInfoPath + "\".", Debug.Type.Error);
                SetProgress(progress, "Error.FileNotFound");
                return;
            }

            var libraryFolder = Game.ModLibrary.GetLibraryFolder();
            var baseModLibPath = libraryFolder + Path.DirectorySeparatorChar + "BaseModLib.dll";

            if (!File.Exists(baseModLibPath))
            {
                Debug.Log("Mod: " + Id, "Couldn't find BaseModLib.dll at \"" + baseModLibPath + "\".", Debug.Type.Error);
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
                assemblyResolver.AddPath(Configuration.GetPath("ModLib") + Path.DirectorySeparatorChar + Game.GameConfiguration.Id +
                                         Path.DirectorySeparatorChar);
                modModule = ModuleDefinition.ReadModule(modFilePath, new ReaderParameters
                {
                    AssemblyResolver = assemblyResolver
                });
                SetProgress(progress, 10f);
            }
            catch (Exception e)
            {
                Debug.Log("Mod: " + Id, "One of the assemblies is corrupted: " + e, Debug.Type.Error);
                SetProgress(progress, "Error.CorruptAssembly");
                return;
            }

            var mod = new Mod(Game, "");
            mod.HeaderData = new Mod.Header(mod, File.ReadAllText(modInfoPath));
            mod.Module = modModule;
            var stream = new MemoryStream();

            mod.Module.Write(stream);
            stream.Position = 0;
            mod.OriginalModule = ModuleDefinition.ReadModule(stream);

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
                                var methodIl = method.Body.GetILProcessor();

                                var instruction = method.Body.Instructions[j];
                                if (instruction.OpCode == OpCodes.Call && instruction.Operand != null)
                                {
                                    foreach (var map in baseModLibRemap)
                                    {
                                        if (((MethodReference) instruction.Operand).FullName == map.Key.FullName)
                                        {
                                            instruction.Operand = type.Module.Import(map.Value);
                                            var newInstruction = methodIl.Create(OpCodes.Ldstr, Id);
                                            methodIl.InsertBefore(instruction, newInstruction);
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
                        mod.HeaderData.AddAddClass(addClass);
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
                            mod.HeaderData.AddAddField(addField);
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
                                foreach (var m in assemblyTypes[assemblyName][type.BaseType.FullName].Methods.Where(o => o.Name == method.Name))
                                {
                                    // Only compare methods with same parameter count
                                    if (method.Parameters.Count == m.Parameters.Count)
                                    {
                                        // No need to compare parameterless methods
                                        if (method.Parameters.Count == 0)
                                        {
                                            inject = true;
                                            break;
                                        }
                                        
                                        // Comapare parameters
                                        if (!m.Parameters.Where((param, pi) => param.ParameterType.FullName != method.Parameters[pi].ParameterType.FullName).Any())
                                        {
                                            inject = true;
                                            break;
                                        }
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
                                mod.HeaderData.AddInjectInto(injectInto);
                            }
                            else
                            {
                                var addMethod = new Mod.Header.AddMethod(mod)
                                {
                                    Method = method,
                                    AssemblyName = assemblyName
                                };
                                mod.HeaderData.AddAddMethod(addMethod);
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
                Debug.Log("Mod: " + Id, "An unexpected error occured while parsing the assembly: " + e, Debug.Type.Error);
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

                var modFolder = Path.GetFullPath(Configuration.GetPath("mods") + Path.DirectorySeparatorChar + Game.GameConfiguration.Id);

                if (!Directory.Exists(modFolder))
                {
                    Directory.CreateDirectory(modFolder);
                }

                mod.FileName = Path.GetFullPath(modFolder + Path.DirectorySeparatorChar + mod.UniqueId + ".mod");
                if (mod.Save())
                {
                    var key = mod.Id + "-" + mod.HeaderData.GetVersion();
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
                    Debug.Log("Mod: " + Id, "Could not save the mod.", Debug.Type.Error);
                    SetProgress(progress, "Error.Save");
                }
            }
            catch (Exception e)
            {
                Debug.Log("Mod: " + Id, "An error occured while saving the mod: " + e, Debug.Type.Error);
                SetProgress(progress, "Error.Save");
            }
        }
    }
}
