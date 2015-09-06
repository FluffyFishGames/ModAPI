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
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;

namespace ModAPI.Data
{
    public class ModLib
    {
        public Game Game;
        public string ModAPIVersion = "";
        public string GameVersion = "";
        public DateTime CreationTime;
        public bool Exists = false;

        public ModLib(Game Game)
        {
            this.Game = Game;
            string libraryPath = GetLibraryFolder();
            string filePath = libraryPath + System.IO.Path.DirectorySeparatorChar + "BaseModLib.dll";
            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    ModuleDefinition definition = ModuleDefinition.ReadModule(filePath);
                    foreach (Resource r in definition.Resources)
                    {
                        if (r is EmbeddedResource && r.Name == "Meta")
                        {
                            XDocument metaXML = XDocument.Parse(System.Text.Encoding.UTF8.GetString(((EmbeddedResource)r).GetResourceData()));
                            this.GameVersion = metaXML.Root.Element("GameVersion").Value;
                            this.ModAPIVersion = metaXML.Root.Element("ModAPIVersion").Value;
                            this.CreationTime = new DateTime(long.Parse(metaXML.Root.Element("CreationTime").Value));
                        }
                    }
                    Exists = true;
                }
                catch (Exception e)
                {
                    Debug.Log("Modlib: " + this.Game.GameConfiguration.ID, "Modlibrary is invalid. Exception: "+e.ToString(), Debug.Type.WARNING);
                }
            }
        }

        public string GetLibraryFolder()
        {
            return System.IO.Path.GetFullPath(Configurations.Configuration.GetPath("ModLib") + System.IO.Path.DirectorySeparatorChar + Game.GameConfiguration.ID);
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

        public void Create(ProgressHandler progress = null)
        {
            string libraryPath = GetLibraryFolder();
            System.IO.Directory.CreateDirectory(libraryPath);

            /** Remove old files **/
            SetProgress(progress, 0, "RemovingOldFiles"); 
            string[] oldFiles = System.IO.Directory.GetFiles(libraryPath);
            int removedFiles = 0;
            foreach (string file in oldFiles)
            {
                System.IO.FileAttributes attr = System.IO.File.GetAttributes(@file);
                if ((attr & System.IO.FileAttributes.Directory) == System.IO.FileAttributes.Directory)
                    System.IO.Directory.Delete(file, true);
                else
                    System.IO.File.Delete(file);
                removedFiles++;
            }
            Debug.Log("Modlib: " + this.Game.GameConfiguration.ID, "Removed " + removedFiles + " files and directories.");
            SetProgress(progress, 1f, "CreatingModToolkit");
            
            string baseModLibPath = Configurations.Configuration.GetPath("Libraries") + System.IO.Path.DirectorySeparatorChar + "BaseModLib.dll";
            if (!System.IO.File.Exists(baseModLibPath)) 
            {
                Debug.Log("Modlib: " + this.Game.GameConfiguration.ID, "Couldn't find BaseModLib.dll.", Debug.Type.ERROR);
                SetProgress(progress, "Error.BaseModLibNotFound");
                return;
            }

            ModuleDefinition baseModLib = ModuleDefinition.ReadModule(baseModLibPath);

            foreach (TypeDefinition type in baseModLib.Types)
            {
                List<string> ChangeMethods = new List<string>();
                foreach (MethodDefinition method in type.Methods)
                {
                    if (method.HasCustomAttributes)
                    {
                        if (method.CustomAttributes[0].AttributeType.Name == "AddModname")
                        {
                            ChangeMethods.Add(method.Name);
                        }
                    }
                }
                foreach (MethodDefinition method in type.Methods)
                {
                    if (ChangeMethods.Contains(method.Name))
                    {
                        method.IsPrivate = false;
                        method.IsFamily = false;
                        method.IsAssembly = false;
                        method.IsFamilyAndAssembly = false;
                        method.IsPublic = true;
                        Debug.Log("Modlib: " + this.Game.GameConfiguration.ID, "Changed the accessibility of " + method.FullName + " in BaseModLib.dll");
                    }
                }
            }
            
            byte[] mscorlibPublicKeyToken = new byte[] { 0x7C, 0xEC, 0x85, 0xD7, 0xBE, 0xA7, 0x79, 0x8E };
            byte[] systemXmlPublicKeyToken = new byte[] { 0x31, 0xBF, 0x38, 0x56, 0xAD, 0x36, 0x4E, 0x35 };
            foreach (AssemblyNameReference assemblyReference in baseModLib.AssemblyReferences)
            {
                if ((assemblyReference.Name.StartsWith("System") || assemblyReference.Name.StartsWith("mscorlib")))
                {
                    assemblyReference.Version = new System.Version("2.0.5.0");
                    if (assemblyReference.Name == "System.Xml.Linq")
                        assemblyReference.PublicKeyToken = systemXmlPublicKeyToken;
                    else
                        assemblyReference.PublicKeyToken = mscorlibPublicKeyToken;
                    
                    Debug.Log("ModLib: " + this.Game.GameConfiguration.ID, "Changed assembly reference token of " + assemblyReference.Name + " in BaseModLib.dll.");
                }
            }

            CreationTime = DateTime.Now;
            GameVersion = Game.BackupVersion.ID;
            ModAPIVersion = ModAPI.Version.Descriptor;

            XDocument metaXML = new XDocument();
            XElement rootElement = new XElement("Meta");
            rootElement.Add(new XElement("GameVersion", GameVersion));
            rootElement.Add(new XElement("ModAPIVersion", ModAPIVersion));
            rootElement.Add(new XElement("CreationTime", CreationTime.Ticks + ""));
            metaXML.Add(rootElement);
            EmbeddedResource metaResource = new EmbeddedResource("Meta", ManifestResourceAttributes.Public, System.Text.Encoding.UTF8.GetBytes(metaXML.ToString()));
            baseModLib.Resources.Add(metaResource);
            
            baseModLib.Write(libraryPath + System.IO.Path.DirectorySeparatorChar + "BaseModLib.dll");
            Debug.Log("ModLib: " + this.Game.GameConfiguration.ID, "Successfully parsed BaseModLib.dll and copied in mod library.");
            
            SetProgress(progress, 5f, "ModifyingAssemblies");
            Utils.CustomAssemblyResolver assemblyResolver = new Utils.CustomAssemblyResolver();
            assemblyResolver.AddPath(ModAPI.Configurations.Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + Game.GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar);
            assemblyResolver.AddPath(libraryPath);

            List<string> SearchFolders = new List<string>();
            for (int i = 0; i < Game.GameConfiguration.IncludeAssemblies.Count; i++)
            {
                string assemblyPath = ModAPI.Configurations.Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + Game.GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.IncludeAssemblies[i]);
                string folder = System.IO.Path.GetDirectoryName(assemblyPath);
                if (!SearchFolders.Contains(folder))
                {
                    Debug.Log("ModLib: " + this.Game.GameConfiguration.ID, "Added folder \"" + folder + "\" to assembly resolver.");
                    SearchFolders.Add(folder);
                }
            }
            for (int i = 0; i < Game.GameConfiguration.CopyAssemblies.Count; i++)
            {
                string assemblyPath = ModAPI.Configurations.Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + Game.GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.CopyAssemblies[i]);
                string folder = System.IO.Path.GetDirectoryName(assemblyPath);
                if (!SearchFolders.Contains(folder))
                {
                    Debug.Log("ModLib: " + this.Game.GameConfiguration.ID, "Added folder \"" + folder + "\" to assembly resolver.");
                    SearchFolders.Add(folder);
                }
            }
            for (int i = 0; i < SearchFolders.Count; i++)
                assemblyResolver.AddPath(SearchFolders[i]);

                for (int i = 0; i < Game.GameConfiguration.IncludeAssemblies.Count; i++)
                {
                    string assemblyPath = ModAPI.Configurations.Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + Game.GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.IncludeAssemblies[i]);
                    if (System.IO.File.Exists(assemblyPath))
                    {
                        try
                        {
                            ModuleDefinition module = ModuleDefinition.ReadModule(assemblyPath, new ReaderParameters()
                            {
                                AssemblyResolver = assemblyResolver
                            });
                            foreach (TypeDefinition type in module.Types)
                            {
                                if (!CheckName(type.Namespace, Game.GameConfiguration.ExcludeNamespaces) && !CheckName(type.Name, Game.GameConfiguration.ExcludeTypes) && !CheckName(type.FullName, Game.GameConfiguration.NoFamily))
                                {

                                    if (type.IsAbstract && type.IsSealed)
                                    {
                                        type.IsAbstract = false;
                                        type.IsSealed = false;
                                        type.IsBeforeFieldInit = true;

                                        MethodDefinition constructor = new MethodDefinition(".ctor", MethodAttributes.SpecialName | MethodAttributes.RTSpecialName | MethodAttributes.Public | MethodAttributes.HideBySig, type.Module.TypeSystem.Void);
                                        type.Methods.Add(constructor);
                                    }

                                    foreach (MethodDefinition m in type.Methods)
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
                                            }
                                            Debug.Log("ModLib: " + this.Game.GameConfiguration.ID, "Changed private method " + m.FullName + " to protectded");
                                        }
                                    }
                                    foreach (FieldDefinition f in type.Fields)
                                    {
                                        if (f.IsPrivate)
                                        {
                                            f.IsFamily = true;
                                            Debug.Log("ModLib: " + this.Game.GameConfiguration.ID, "Changed private field " + f.FullName + " to protectded");
                                        }
                                    }
                                }
                            }
                            string savePath = System.IO.Path.GetFullPath(libraryPath + System.IO.Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.IncludeAssemblies[i]));
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(savePath));
                            module.Write(savePath);
                            Debug.Log("ModLib: " + this.Game.GameConfiguration.ID, "Saved modified \"" + module.Name + "\".");
                        }
                        catch (Exception e)
                        {
                            Debug.Log("ModLib: " + this.Game.GameConfiguration.ID, "File couldnt be parsed: \"" + assemblyPath + "\". Exception: " + e.ToString(), Debug.Type.ERROR);
                            SetProgress(progress, "Error.ModifyAssemblyException");
                            return;
                        }
                        Debug.Log("ModLib: " + this.Game.GameConfiguration.ID, "Successfully parsed file: \"" + assemblyPath + "\" and copied in mod library.");
                    }
                    else
                    {
                        SetProgress(progress, "Error.ModifyAssemblyFileNotFound");
                        Debug.Log("ModLib: " + this.Game.GameConfiguration.ID, "File not found: \"" + assemblyPath + "\".", Debug.Type.ERROR);
                        return;
                    }
                    SetProgress(progress, 5f + ((float)i / (float)Game.GameConfiguration.IncludeAssemblies.Count) * 75f);
                }

            SetProgress(progress, 80f, "CopyingAssemblies");

            for (int i = 0; i < Game.GameConfiguration.CopyAssemblies.Count; i++)
            {
                string copyFrom = Configurations.Configuration.GetPath("OriginalGameFiles") + System.IO.Path.DirectorySeparatorChar + Game.GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.CopyAssemblies[i]);
                string copyTo = System.IO.Path.GetFullPath(libraryPath + System.IO.Path.DirectorySeparatorChar + Game.ParsePath(Game.GameConfiguration.CopyAssemblies[i]));

                if (System.IO.File.Exists(copyFrom))
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(copyTo));
                    System.IO.File.Copy(copyFrom, copyTo, true);
                } 
                else 
                {
                    SetProgress(progress, "Error.CopyAssemblyFileNotFound");
                    Debug.Log("ModLib: "+ this.Game.GameConfiguration.ID, "File not found: \""+copyFrom+"\".", Debug.Type.ERROR);
                    return;
                }
                SetProgress(progress, 80f + ((float)i / (float)Game.GameConfiguration.CopyAssemblies.Count) * 20f);
            }
            Exists = true;
            SetProgress(progress, 100f, "Finish");
        }

        public static bool CheckName(string name, List<string> list)
        {
            bool found = false;
            for (int i = 0; i < list.Count; i++)
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
