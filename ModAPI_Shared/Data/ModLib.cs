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
using System.Text;
using System.Xml.Linq;
using ModAPI.Configurations;
using ModAPI.Utils;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using Path = System.IO.Path;

namespace ModAPI.Data
{
    public class ModLib
    {
        public Game Game;
        public string ModApiVersion = "";
        public string GameVersion = "";
        public DateTime CreationTime;
        public bool Exists;

        public ModLib(Game game)
        {
            Game = game;
            var libraryPath = GetLibraryFolder();
            var filePath = libraryPath + Path.DirectorySeparatorChar + "BaseModLib.dll";
            if (File.Exists(filePath))
            {
                try
                {
                    var definition = ModuleDefinition.ReadModule(filePath);
                    foreach (var r in definition.Resources)
                    {
                        if (r is EmbeddedResource && r.Name == "Meta")
                        {
                            var metaXml = XDocument.Parse(Encoding.UTF8.GetString(((EmbeddedResource) r).GetResourceData()));
                            GameVersion = metaXml.Root.Element("GameVersion").Value;
                            ModApiVersion = metaXml.Root.Element("ModAPIVersion").Value;
                            CreationTime = new DateTime(long.Parse(metaXml.Root.Element("CreationTime").Value));
                        }
                    }
                    Exists = true;
                }
                catch (Exception e)
                {
                    Debug.Log("Modlib: " + Game.GameConfiguration.Id, "Modlibrary is invalid. Exception: " + e, Debug.Type.Warning);
                }
            }
        }

        public string GetLibraryFolder()
        {
            return Path.GetFullPath(Configuration.GetPath("ModLib") + Path.DirectorySeparatorChar + Game.GameConfiguration.Id);
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

        public void Create(ProgressHandler progress = null)
        {
            var libraryPath = GetLibraryFolder();
            Directory.CreateDirectory(libraryPath);

            /** Remove old files **/
            SetProgress(progress, 0, "RemovingOldFiles");
            var oldFiles = Directory.GetFiles(libraryPath);
            var removedFiles = 0;
            foreach (var file in oldFiles)
            {
                var attr = File.GetAttributes(file);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    Directory.Delete(file, true);
                }
                else
                {
                    File.Delete(file);
                }
                removedFiles++;
            }
            Debug.Log("Modlib: " + Game.GameConfiguration.Id, "Removed " + removedFiles + " files and directories.");
            SetProgress(progress, 1f, "CreatingModToolkit");

            var baseModLibPath = Configuration.GetPath("Libraries") + Path.DirectorySeparatorChar + "BaseModLib.dll";
            if (!File.Exists(baseModLibPath))
            {
                Debug.Log("Modlib: " + Game.GameConfiguration.Id, "Couldn't find BaseModLib.dll.", Debug.Type.Error);
                SetProgress(progress, "Error.BaseModLibNotFound");
                return;
            }

            var baseModLib = ModuleDefinition.ReadModule(baseModLibPath);

            foreach (var type in baseModLib.Types)
            {
                var changeMethods = new List<string>();
                foreach (var method in type.Methods)
                {
                    if (method.HasCustomAttributes)
                    {
                        if (method.CustomAttributes[0].AttributeType.Name == "AddModname")
                        {
                            changeMethods.Add(method.Name);
                        }
                    }
                }
                foreach (var method in type.Methods)
                {
                    if (changeMethods.Contains(method.Name))
                    {
                        method.IsPrivate = false;
                        method.IsFamily = false;
                        method.IsAssembly = false;
                        method.IsFamilyAndAssembly = false;
                        method.IsPublic = true;
                        Debug.Log("Modlib: " + Game.GameConfiguration.Id, "Changed the accessibility of " + method.FullName + " in BaseModLib.dll");
                    }
                }
            }

            var mscorlibPublicKeyToken = new byte[] { 0x7C, 0xEC, 0x85, 0xD7, 0xBE, 0xA7, 0x79, 0x8E };
            var systemXmlPublicKeyToken = new byte[] { 0x31, 0xBF, 0x38, 0x56, 0xAD, 0x36, 0x4E, 0x35 };
            foreach (var assemblyReference in baseModLib.AssemblyReferences)
            {
                if ((assemblyReference.Name.StartsWith("System") || assemblyReference.Name.StartsWith("mscorlib")))
                {
                    assemblyReference.Version = new System.Version("2.0.5.0");
                    if (assemblyReference.Name == "System.Xml.Linq")
                    {
                        assemblyReference.PublicKeyToken = systemXmlPublicKeyToken;
                    }
                    else
                    {
                        assemblyReference.PublicKeyToken = mscorlibPublicKeyToken;
                    }

                    Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Changed assembly reference token of " + assemblyReference.Name + " in BaseModLib.dll.");
                }
            }

            CreationTime = DateTime.Now;
            GameVersion = Game.BackupVersion.Id;
            ModApiVersion = Version.Descriptor;

            var metaXml = new XDocument();
            var rootElement = new XElement("Meta");
            rootElement.Add(new XElement("GameVersion", GameVersion));
            rootElement.Add(new XElement("ModAPIVersion", ModApiVersion));
            rootElement.Add(new XElement("CreationTime", CreationTime.Ticks + ""));
            metaXml.Add(rootElement);
            var metaResource = new EmbeddedResource("Meta", ManifestResourceAttributes.Public, Encoding.UTF8.GetBytes(metaXml.ToString()));
            baseModLib.Resources.Add(metaResource);

            baseModLib.Write(libraryPath + Path.DirectorySeparatorChar + "BaseModLib.dll");
            Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Successfully parsed BaseModLib.dll and copied in mod library.");

            SetProgress(progress, 5f, "ModifyingAssemblies");
            var assemblyResolver = new CustomAssemblyResolver();
            assemblyResolver.AddPath(Configuration.GetPath("OriginalGameFiles") + Path.DirectorySeparatorChar + Game.GameConfiguration.Id +
                                     Path.DirectorySeparatorChar);
            assemblyResolver.AddPath(libraryPath);

            var searchFolders = new List<string>();
            for (var i = 0; i < Game.GameConfiguration.IncludeAssemblies.Count; i++)
            {
                var assemblyPath = Configuration.GetPath("OriginalGameFiles") + Path.DirectorySeparatorChar + Game.GameConfiguration.Id +
                                   Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.IncludeAssemblies[i]);
                var folder = Path.GetDirectoryName(assemblyPath);
                if (!searchFolders.Contains(folder))
                {
                    Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Added folder \"" + folder + "\" to assembly resolver.");
                    searchFolders.Add(folder);
                }
            }
            for (var i = 0; i < Game.GameConfiguration.CopyAssemblies.Count; i++)
            {
                var assemblyPath = Configuration.GetPath("OriginalGameFiles") + Path.DirectorySeparatorChar + Game.GameConfiguration.Id +
                                   Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.CopyAssemblies[i]);
                var folder = Path.GetDirectoryName(assemblyPath);
                if (!searchFolders.Contains(folder))
                {
                    Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Added folder \"" + folder + "\" to assembly resolver.");
                    searchFolders.Add(folder);
                }
            }
            for (var i = 0; i < searchFolders.Count; i++)
            {
                assemblyResolver.AddPath(searchFolders[i]);
            }

            for (var i = 0; i < Game.GameConfiguration.IncludeAssemblies.Count; i++)
            {
                var assemblyPath = Configuration.GetPath("OriginalGameFiles") + Path.DirectorySeparatorChar + Game.GameConfiguration.Id +
                                   Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.IncludeAssemblies[i]);

                Debug.Log("ModLib: " + Game.GameConfiguration.Id, "======================================================================");
                Debug.Log("ModLib: " + Game.GameConfiguration.Id, "========================     NEW ASSEMBLY     ========================");
                Debug.Log("ModLib: " + Game.GameConfiguration.Id, "======================================================================");
                Debug.Log("ModLib: " + Game.GameConfiguration.Id, assemblyPath);
                Debug.Log("ModLib: " + Game.GameConfiguration.Id, "======================================================================");

                if (File.Exists(assemblyPath))
                {
                    try
                    {
                        var module = ModuleDefinition.ReadModule(assemblyPath, new ReaderParameters
                        {
                            AssemblyResolver = assemblyResolver
                        });
                        foreach (var type in module.Types)
                        {
                            if (string.IsNullOrEmpty(type.Namespace))
                            {
                                Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Validating root namespace type " + type.FullName);
                            }

                            if ((string.IsNullOrEmpty(type.Namespace) || !CheckName(type.Namespace, Game.GameConfiguration.ExcludeNamespaces))
                                && !CheckName(type.Name, Game.GameConfiguration.ExcludeTypes)
                                && !CheckName(type.FullName, Game.GameConfiguration.NoFamily))
                            {
                                if (string.IsNullOrEmpty(type.Namespace))
                                {
                                    Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Processing root namespace type " + type.FullName);
                                }

                                if (type.IsAbstract && type.IsSealed)
                                {
                                    type.IsAbstract = false;
                                    type.IsSealed = false;
                                    type.IsBeforeFieldInit = true;

                                    var constructor = new MethodDefinition(".ctor",
                                        MethodAttributes.SpecialName | MethodAttributes.RTSpecialName | MethodAttributes.Public | MethodAttributes.HideBySig, type.Module.TypeSystem.Void);
                                    type.Methods.Add(constructor);
                                    Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Added public constructor to abstract class " + constructor.FullName);
                                }

                                if (type.IsNotPublic)
                                {
                                    type.IsPublic = true;
                                }

                                var constructors = type.GetConstructors().ToArray();
                                if (constructors.Length == 0)
                                {
                                    var constructor = new MethodDefinition(".ctor",
                                        MethodAttributes.SpecialName | MethodAttributes.RTSpecialName | MethodAttributes.Public | MethodAttributes.HideBySig, type.Module.TypeSystem.Void);
                                    type.Methods.Add(constructor);
                                    Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Added public constructor " + constructor.FullName);
                                }
                                else
                                {
                                    foreach (var constructor in constructors)
                                    {
                                        constructor.IsPublic = true;
                                        Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Changed non-public constructor " + constructor.FullName + " to public");
                                    }
                                }

                                foreach (var m in type.Methods)
                                {
                                    if (!m.IsConstructor)
                                    {
                                        if (!m.IsGetter && !m.IsSetter && !m.IsStatic)
                                        {
                                            m.IsVirtual = true;
                                        }
                                        if (m.IsPrivate)
                                        {
                                            m.IsFamily = true;
                                            Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Changed private method " + m.FullName + " to protectded");
                                        }
                                        else if (m.IsAssembly)
                                        {
                                            m.IsAssembly = false;
                                            m.IsPublic = true;
                                            Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Changed internal method " + m.FullName + " to public");
                                        }
                                    }
                                }
                                foreach (var f in type.Fields)
                                {
                                    if (f.IsPrivate)
                                    {
                                        f.IsFamily = true;
                                        Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Changed private field " + f.FullName + " to protectded");
                                    }
                                    else if (f.IsAssembly)
                                    {
                                        f.IsAssembly = false;
                                        f.IsPublic = true;
                                        Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Changed internal field " + f.FullName + " to public");
                                    }
                                }
                            }
                        }
                        var savePath = Path.GetFullPath(libraryPath + Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.IncludeAssemblies[i]));
                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                        module.Write(savePath);
                        Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Saved modified \"" + module.Name + "\" into " + savePath + "");
                    }
                    catch (Exception e)
                    {
                        Debug.Log("ModLib: " + Game.GameConfiguration.Id, "File couldnt be parsed: \"" + assemblyPath + "\". Exception: " + e, Debug.Type.Error);
                        SetProgress(progress, "Error.ModifyAssemblyException");
                        return;
                    }
                    Debug.Log("ModLib: " + Game.GameConfiguration.Id, "Successfully parsed file: \"" + assemblyPath + "\" and copied in mod library.");
                }
                else
                {
                    SetProgress(progress, "Error.ModifyAssemblyFileNotFound");
                    Debug.Log("ModLib: " + Game.GameConfiguration.Id, "File not found: \"" + assemblyPath + "\".", Debug.Type.Error);
                    return;
                }
                SetProgress(progress, 5f + (i / (float) Game.GameConfiguration.IncludeAssemblies.Count) * 75f);
            }

            SetProgress(progress, 80f, "CopyingAssemblies");

            for (var i = 0; i < Game.GameConfiguration.CopyAssemblies.Count; i++)
            {
                var copyFrom = Configuration.GetPath("OriginalGameFiles") + Path.DirectorySeparatorChar + Game.GameConfiguration.Id +
                               Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.CopyAssemblies[i]);
                var copyTo = Path.GetFullPath(libraryPath + Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.CopyAssemblies[i]));

                if (File.Exists(copyFrom))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(copyTo));
                    File.Copy(copyFrom, copyTo, true);
                }
                else
                {
                    SetProgress(progress, "Error.CopyAssemblyFileNotFound");
                    Debug.Log("ModLib: " + Game.GameConfiguration.Id, "File not found: \"" + copyFrom + "\".", Debug.Type.Error);
                    return;
                }
                SetProgress(progress, 80f + (i / (float) Game.GameConfiguration.CopyAssemblies.Count) * 20f);
            }
            Exists = true;
            SetProgress(progress, 100f, "Finish");
        }

        public static bool CheckName(string name, List<string> list)
        {
            var found = false;
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i].EndsWith("*"))
                {
                    if (name.StartsWith(list[i].Substring(0, list[i].Length - 1)))
                    {
                        found = true;
                        break;
                    }
                }
                else
                {
                    if (name == list[i])
                    {
                        found = true;
                        break;
                    }
                }
            }
            return found;
        }
    }
}
