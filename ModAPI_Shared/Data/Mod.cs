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
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Ionic.Zip;
using ModAPI.Utils;
using Mono.Cecil;
using Path = System.IO.Path;

namespace ModAPI.Data
{
    public class Mod
    {
        public string ID;
        public bool Valid;
        public DateTime LoadedDate;
        public Game Game;
        public ZipFile Resources;

        public string UniqueID
        {
            get
            {
                var md5 = MD5.Create();
                var unique = md5.ComputeHash(GetHashBytes());
                return ID + "-" + header.GetVersion() + "-" + BitConverter.ToString(unique).ToLower().Replace("-", "");
            }
        }

        public static Dictionary<string, Mod> Mods = new Dictionary<string, Mod>();
        protected static Dictionary<string, Mod> FilenameToMod = new Dictionary<string, Mod>();

        protected static bool modsLoaded = false;
        public string FileName = "";

        public Header header;
        public ModuleDefinition module;
        public ModuleDefinition originalModule;
        public bool HasResources;
        public int ResourcesIndex;

        protected bool loaded;
        protected string headerText = "";
        protected string assemblyText = "";

        public byte[] GetHashBytes()
        {
            var hashBytes = new List<byte>();
            hashBytes.AddRange(header.GetHashBytes());
            return hashBytes.ToArray();
        }

        public Mod()
        {
        }

        public void Remove()
        {
            if (FileName != "" && File.Exists(FileName))
            {
                File.Delete(FileName);
            }
        }

        public void Verify()
        {
            Valid = true;
            if (header == null)
            {
                Valid = false;
            }
            else
            {
                header.Verify();
                if (!header.Valid)
                {
                    Valid = false;
                }
            }
            if (module == null)
            {
                Valid = false;
            }
        }

        public Header GetHeader()
        {
            if (header != null || Load())
            {
                return header;
            }
            return null;
        }

        public ModuleDefinition GetModule()
        {
            if (module != null || Load())
            {
                return module;
            }
            return null;
        }

        public void RewindModule()
        {
            var stream = new MemoryStream();
            originalModule.Write(stream);
            stream.Position = 0;
            module = ModuleDefinition.ReadModule(stream);
            AssignModule();
        }

        public bool Save()
        {
            try
            {
                var modContent = header.GetXML().ToString();
                modContent += "\r\n";
                var stream = new MemoryStream();
                module.Write(stream);
                stream.Position = 0;
                originalModule = ModuleDefinition.ReadModule(stream);
                stream.Position = 0;
                var modBytes = new byte[stream.Length];
                stream.Read(modBytes, 0, (int) stream.Length); //max size of mods are 2047,9MB
                modContent += Convert.ToBase64String(modBytes);

                var folder = Path.GetDirectoryName(FileName);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var fileStream = File.Create(FileName);

                if (Resources != null)
                {
                    HasResources = true;
                    ResourcesIndex = Encoding.UTF8.GetBytes(modContent + "\r\n\r\n").Length;

                    var resourcesStream = new MemoryStream();
                    Resources.Save(resourcesStream);
                    resourcesStream.Position = 0;
                    var resourcesBytes = new byte[resourcesStream.Length];
                    resourcesStream.Read(resourcesBytes, 0, resourcesBytes.Length);
                    modContent += "\r\n\r\n" + Convert.ToBase64String(resourcesBytes);
                }

                var gzip = new GZipStream(fileStream, CompressionLevel.Optimal);
                var b = Encoding.UTF8.GetBytes(modContent);
                gzip.Write(b, 0, b.Length);
                gzip.Close();

                //fileStream.Write(modFile, 0, modFile.Length);
                fileStream.Close();
                return true;
            }
            catch (Exception e)
            {
                Debug.Log("Mod: " + ID, "Couldn't save mod to: \"" + FileName + "\": " + e, Debug.Type.ERROR);
                return false;
            }
        }

        public bool Load()
        {
            if (loaded)
            {
                return true;
            }
            if (File.Exists(FileName))
            {
                var b = File.ReadAllBytes(FileName);
                var decompressedBytes = new byte[0];
                try
                {
                    using (var stream = new GZipStream(new MemoryStream(b), CompressionMode.Decompress))
                    {
                        const int size = 4096;
                        var buffer = new byte[size];

                        using (var memory = new MemoryStream())
                        {
                            var count = 0;
                            do
                            {
                                count = stream.Read(buffer, 0, size);
                                if (count > 0)
                                {
                                    memory.Write(buffer, 0, count);
                                }
                            } while (count > 0);
                            decompressedBytes = memory.ToArray();
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("Game: " + Game.GameConfiguration.ID, "Can't load the mod at \"" + FileName + "\". Exception: " + e, Debug.Type.WARNING);
                    return false;
                }

                var text = Encoding.UTF8.GetString(decompressedBytes);
                var parts = text.Split(new[] { "\n" }, StringSplitOptions.None);
                var header = "";

                var headerSize = 0;
                for (var i = 0; i < parts.Length; i++)
                {
                    header += parts[i] + "\n";
                    headerSize += parts[i].Length + 1;
                    if (parts[i].EndsWith("</Mod>\r"))
                    {
                        break;
                    }
                    if (i == parts.Length - 1)
                    {
                        Debug.Log("Game: " + Game.GameConfiguration.ID, "Can't load the mod at \"" + FileName + "\". File-header is corrupted.", Debug.Type.WARNING);
                        return false;
                    }
                }

                this.header = new Header(this, header);
                var assemblyText = text.Substring(headerSize);
                var resourcesIndex = assemblyText.IndexOf("\r\n\r\n");
                if (resourcesIndex > 0)
                {
                    // Resources found
                    HasResources = true;
                    assemblyText = assemblyText.Substring(0, resourcesIndex);
                    ResourcesIndex = Encoding.UTF8.GetBytes(assemblyText + "\r\n\r\n").Length + Encoding.UTF8.GetBytes(header).Length;
                }

                Debug.Log("Game: " + Game.GameConfiguration.ID, "Successfully loaded mod header \"" + ID + "\" in version \"" + this.header.GetVersion() + "\" at \"" + FileName + "\"");

                try
                {
                    var dllBytes = Convert.FromBase64String(assemblyText);
                    var dllStream = new MemoryStream(dllBytes);
                    dllStream.Position = 0;

                    originalModule = ModuleDefinition.ReadModule(dllStream);
                    dllStream.Position = 0;
                    module = ModuleDefinition.ReadModule(dllStream);

                    AssignModule();

                    Debug.Log("Game: " + Game.GameConfiguration.ID, "Successfully loaded mod module \"" + ID + "\" in version \"" + this.header.GetVersion() + "\" at \"" + FileName + "\"");
                }
                catch (Exception e)
                {
                    module = null;
                    Debug.Log("Game: " + Game.GameConfiguration.ID, "Can't load the mod at \"" + FileName + "\". File-module is corrupted. Exception: " + e, Debug.Type.WARNING);
                    return false;
                }
                loaded = true;
                Verify();
                LoadedDate = new DateTime();
                return true;
            }
            return false;
        }

        public ModuleDefinition GetModuleCopy()
        {
            //byte[] dllBytes = Convert.FromBase64String(this.assemblyText);
            var dllStream = new MemoryStream();
            originalModule.Write(dllStream);
            dllStream.Position = 0;
            return ModuleDefinition.ReadModule(dllStream);
        }

        public ZipFile GetResources()
        {
            if (HasResources)
            {
                var b = File.ReadAllBytes(FileName);
                var decompressedBytes = new byte[0];
                try
                {
                    using (var stream = new GZipStream(new MemoryStream(b), CompressionMode.Decompress))
                    {
                        const int size = 4096;
                        var buffer = new byte[size];

                        using (var memory = new MemoryStream())
                        {
                            var count = 0;
                            do
                            {
                                count = stream.Read(buffer, 0, size);
                                if (count > 0)
                                {
                                    memory.Write(buffer, 0, count);
                                }
                            } while (count > 0);
                            decompressedBytes = memory.ToArray();
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("Game: " + Game.GameConfiguration.ID, "Can't load the mod at \"" + FileName + "\". Exception: " + e, Debug.Type.WARNING);
                    return null;
                }
                try
                {
                    var zipBytes = Convert.FromBase64String(Encoding.UTF8.GetString(decompressedBytes, ResourcesIndex, decompressedBytes.Length - ResourcesIndex));
                    var m = new MemoryStream();
                    m.Write(zipBytes, 0, zipBytes.Length);
                    m.Position = 0;
                    var zip = ZipFile.Read(m);
                    return zip;
                }
                catch (Exception e)
                {
                    Debug.Log("Game: " + Game.GameConfiguration.ID, "Can't load the resources for the mod at \"" + FileName + "\". Exception: " + e, Debug.Type.WARNING);
                    return null;
                }
            }
            return null;
        }

        protected void AssignModule()
        {
            foreach (var i in header.GetAddClasses())
            {
                var type = TypeResolver.FindTypeDefinition(module, i.TypeName);
                if (type != null)
                {
                    i.Type = type;
                }
                else
                {
                    Debug.Log("Game: " + Game.GameConfiguration.ID, "Can't find type \"" + i.TypeName + "\" in mod \"" + ID + "\" but it is declared in its header as add class.");
                }
            }
            foreach (var i in header.GetAddMethods())
            {
                var method = TypeResolver.FindMethodDefinition(module, i.Path);
                if (method != null)
                {
                    i.Method = method;
                }
                else
                {
                    Debug.Log("Game: " + Game.GameConfiguration.ID, "Can't find method \"" + i.Path + "\" in mod \"" + ID + "\" but it is declared in its header as add method.");
                }
            }
            foreach (var i in header.GetInjectIntos())
            {
                var method = TypeResolver.FindMethodDefinition(module, i.Path);
                if (method != null)
                {
                    i.Method = method;
                }
                else
                {
                    Debug.Log("Game: " + Game.GameConfiguration.ID, "Can't find method \"" + i.Path + "\" in mod \"" + ID + "\" but it is declared in its header as inject into.");
                }
            }
            foreach (var i in header.GetAddFields())
            {
                var field = TypeResolver.FindFieldDefinition(module, i.Path);
                if (field != null)
                {
                    i.Field = field;
                }
                else
                {
                    Debug.Log("Game: " + Game.GameConfiguration.ID, "Can't find field \"" + i.Path + "\" in mod \"" + ID + "\" but it is declared in its header as add field.");
                }
            }
        }

        public Mod(Game game, string fileName)
        {
            Game = game;
            FileName = fileName;
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

        public class Header
        {
            public bool Valid;
            public Mod Mod;
            protected string ID;
            protected string Version;
            protected string Compatible;
            protected int VersionNumber;
            protected MultilingualValue Name;
            protected MultilingualValue Description;
            protected List<Button> Buttons;
            protected List<AddMethod> AddMethods;
            protected List<AddField> AddFields;
            protected List<AddClass> AddClasses;
            protected List<InjectInto> InjectIntos;

            public byte[] GetHashBytes()
            {
                var hashBytes = new List<byte>();
                hashBytes.AddRange(Encoding.UTF8.GetBytes(ID));
                hashBytes.AddRange(Encoding.UTF8.GetBytes(Version));
                hashBytes.AddRange(Name.GetHashBytes());
                hashBytes.AddRange(Encoding.UTF8.GetBytes(Compatible));
                hashBytes.AddRange(Description.GetHashBytes());

                foreach (var h in Buttons)
                {
                    hashBytes.AddRange(h.GetHashBytes());
                }
                foreach (var h in AddMethods)
                {
                    hashBytes.AddRange(h.GetHashBytes());
                }
                foreach (var h in AddFields)
                {
                    hashBytes.AddRange(h.GetHashBytes());
                }
                foreach (var h in AddClasses)
                {
                    hashBytes.AddRange(h.GetHashBytes());
                }
                foreach (var h in InjectIntos)
                {
                    hashBytes.AddRange(h.GetHashBytes());
                }
                return hashBytes.ToArray();
            }

            public Header(Mod mod)
            {
                Mod = mod;
            }

            public static bool VerifyModID(string name)
            {
                var validation = new Regex("^[a-zA-Z0-9_]+$");
                return validation.IsMatch(name);
            }

            public static bool VerifyModVersion(string version)
            {
                var validation = new Regex("^([0-9]{1,2})(\\.[0-9]{1,2}){0,3}$");
                return validation.IsMatch(version);
            }

            public static int ParseModVersion(string version)
            {
                try
                {
                    var parts = version.Split(new[] { "." }, StringSplitOptions.None);
                    var num = 0;
                    var multiplier = 100 * 100 * 100;
                    for (var i = 0; i < parts.Length; i++)
                    {
                        num += int.Parse(parts[i]) * multiplier;
                        multiplier /= 100;
                    }
                    return num;
                }
                catch (Exception)
                {
                    return -1;
                }
            }

            public bool SetID(string ID)
            {
                if (VerifyModID(ID))
                {
                    this.ID = ID;
                    Mod.ID = this.ID;
                    return true;
                }
                Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Invalid mod configuration: The ID \"" + ID + "\" is invalid.", Debug.Type.WARNING);
                return false;
            }

            protected bool SetID(XAttribute attribute)
            {
                if (attribute == null)
                {
                    Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Invalid mod configuration: The ID is missing.", Debug.Type.WARNING);
                    return false;
                }
                return SetID(attribute.Value);
            }

            public string GetVersion()
            {
                return Version;
            }

            public string GetCompatible()
            {
                return Compatible;
            }

            public bool SetCompatible(string compatible)
            {
                Compatible = compatible;
                return true;
            }

            protected bool SetCompatible(XElement element)
            {
                if (element == null)
                {
                    Compatible = "";
                    return false;
                }
                return SetCompatible(element.Value);
            }

            public bool SetVersion(string version)
            {
                if (VerifyModVersion(version))
                {
                    Version = version;
                    VersionNumber = ParseModVersion(version);
                    if (VersionNumber == -1)
                    {
                        return false;
                    }
                    return true;
                }
                Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Invalid mod configuration for ID \"" + ID + "\": The version string is invalid.", Debug.Type.WARNING);
                return false;
            }

            protected bool SetVersion(XElement element)
            {
                if (element == null)
                {
                    Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Invalid mod configuration for ID \"" + ID + "\": The version string is missing.", Debug.Type.WARNING);
                    return false;
                }
                return SetVersion(element.Value);
            }

            public bool SetName(MultilingualValue val)
            {
                Name = val;
                return true;
            }

            protected bool SetName(XElement element)
            {
                if (element == null)
                {
                    Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Invalid mod configuration for ID \"" + ID + "\": The name is missing.", Debug.Type.WARNING);
                    return false;
                }
                var val = new MultilingualValue();
                val.SetXML(element);
                return SetName(val);
            }

            public bool SetDescription(MultilingualValue val)
            {
                Description = val;
                return true;
            }

            protected bool SetDescription(XElement element)
            {
                if (element == null)
                {
                    Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Invalid mod configuration for ID \"" + ID + "\": The description is missing.", Debug.Type.WARNING);
                    return false;
                }
                var val = new MultilingualValue();
                val.SetXML(element);
                return SetDescription(val);
            }

            public MultilingualValue GetDescription()
            {
                return Description;
            }

            public MultilingualValue GetName()
            {
                return Name;
            }

            public bool AddButton(Button button)
            {
                if (Buttons != null)
                {
                    foreach (var otherButton in Buttons)
                    {
                        if (button.ID == otherButton.ID)
                        {
                            Debug.Log("Game: " + Mod.Game.GameConfiguration.ID,
                                "Invalid mod configuration for ID \"" + ID + "\": There are more than one button with ID \"" + button.ID + "\".", Debug.Type.WARNING);
                            return false;
                        }
                    }
                }
                else
                {
                    Buttons = new List<Button>();
                }
                Buttons.Add(button);
                return true;
            }

            public bool AddButton(XElement element)
            {
                var button = new Button(Mod);
                if (button.SetXML(element))
                {
                    return AddButton(button);
                }
                return false;
            }

            public List<InjectInto> GetInjectIntos()
            {
                return InjectIntos;
            }

            public List<AddField> GetAddFields()
            {
                return AddFields;
            }

            public List<AddMethod> GetAddMethods()
            {
                return AddMethods;
            }

            public List<AddClass> GetAddClasses()
            {
                return AddClasses;
            }

            public List<Button> GetButtons()
            {
                return Buttons;
            }

            public void RemoveInjectInto(InjectInto obj)
            {
                InjectIntos.Remove(obj);
            }

            public void RemoveAddField(AddField obj)
            {
                AddFields.Remove(obj);
            }

            public void RemoveAddClass(AddClass obj)
            {
                AddClasses.Remove(obj);
            }

            public void RemoveAddMethod(AddMethod obj)
            {
                AddMethods.Remove(obj);
            }

            public bool AddInjectInto(InjectInto obj)
            {
                if (InjectIntos == null)
                {
                    InjectIntos = new List<InjectInto>();
                }
                InjectIntos.Add(obj);
                return true;
            }

            public bool AddInjectInto(XElement element)
            {
                var obj = new InjectInto(Mod);
                obj.SetXML(element);
                return AddInjectInto(obj);
            }

            public bool AddAddClass(AddClass obj)
            {
                if (AddClasses == null)
                {
                    AddClasses = new List<AddClass>();
                }
                AddClasses.Add(obj);
                return true;
            }

            public bool AddAddClass(XElement element)
            {
                var obj = new AddClass(Mod);
                obj.SetXML(element);
                return AddAddClass(obj);
            }

            public bool AddAddField(AddField obj)
            {
                if (AddFields == null)
                {
                    AddFields = new List<AddField>();
                }
                AddFields.Add(obj);
                return true;
            }

            public bool AddAddField(XElement element)
            {
                var obj = new AddField(Mod);
                obj.SetXML(element);
                return AddAddField(obj);
            }

            public bool AddAddMethod(AddMethod obj)
            {
                if (AddMethods == null)
                {
                    AddMethods = new List<AddMethod>();
                }
                AddMethods.Add(obj);
                return true;
            }

            public bool AddAddMethod(XElement element)
            {
                var obj = new AddMethod(Mod);
                obj.SetXML(element);
                return AddAddMethod(obj);
            }

            public XDocument GetXML()
            {
                var document = new XDocument();
                var rootElement = new XElement("Mod");
                rootElement.SetAttributeValue("ID", ID);
                rootElement.Add(new XElement("Compatible", Compatible));
                rootElement.Add(new XElement("Version", Version));

                var nameElement = Name.GetXML();
                nameElement.Name = "Name";
                rootElement.Add(nameElement);

                var descriptionElement = Description.GetXML();
                descriptionElement.Name = "Description";
                rootElement.Add(descriptionElement);

                foreach (var button in Buttons)
                {
                    rootElement.Add(button.GetXML());
                }
                foreach (var injectInto in InjectIntos)
                {
                    rootElement.Add(injectInto.GetXML());
                }
                foreach (var addField in AddFields)
                {
                    rootElement.Add(addField.GetXML());
                }
                foreach (var addMethod in AddMethods)
                {
                    rootElement.Add(addMethod.GetXML());
                }
                foreach (var addClass in AddClasses)
                {
                    rootElement.Add(addClass.GetXML());
                }

                document.Add(rootElement);
                return document;
            }

            public void SetXML(XDocument configuration)
            {
                if (!SetID(configuration.Root.Attribute("ID")))
                {
                    return;
                }
                if (!SetVersion(configuration.Root.Element("Version")))
                {
                    return;
                }
                if (!SetName(configuration.Root.Element("Name")))
                {
                    return;
                }
                if (!SetDescription(configuration.Root.Element("Description")))
                {
                    return;
                }
                SetCompatible(configuration.Root.Element("Compatible"));
                Buttons = new List<Button>();
                foreach (var buttonElement in configuration.Root.Elements("Button"))
                {
                    AddButton(buttonElement);
                }

                InjectIntos = new List<InjectInto>();
                AddFields = new List<AddField>();
                AddMethods = new List<AddMethod>();
                AddClasses = new List<AddClass>();

                foreach (var subElement in configuration.Root.Elements("InjectInto"))
                {
                    AddInjectInto(subElement);
                }
                foreach (var subElement in configuration.Root.Elements("AddField"))
                {
                    AddAddField(subElement);
                }
                foreach (var subElement in configuration.Root.Elements("AddMethod"))
                {
                    AddAddMethod(subElement);
                }
                foreach (var subElement in configuration.Root.Elements("AddClass"))
                {
                    AddAddClass(subElement);
                }
                Verify();
            }

            public void Verify()
            {
                Valid = true;
                if (ID == "")
                {
                    Valid = false;
                }
                if (Version == "")
                {
                    Valid = false;
                }
                if (Name == null)
                {
                    Valid = false;
                }
                if (Description == null)
                {
                    Valid = false;
                }
                var buttonIDs = new List<string>();
                foreach (var b in Buttons)
                {
                    if (buttonIDs.Contains(b.ID))
                    {
                        Valid = false;
                    }
                    buttonIDs.Add(b.ID);
                }

                foreach (var i in InjectIntos)
                {
                    i.Verify();
                    if (!i.Valid)
                    {
                        Valid = false;
                    }
                }
                foreach (var i in AddFields)
                {
                    i.Verify();
                    if (!i.Valid)
                    {
                        Valid = false;
                    }
                }
                foreach (var i in AddMethods)
                {
                    i.Verify();
                    if (!i.Valid)
                    {
                        Valid = false;
                    }
                }
                foreach (var i in AddClasses)
                {
                    i.Verify();
                    if (!i.Valid)
                    {
                        Valid = false;
                    }
                }
            }

            public Header(Mod mod, string header)
            {
                Mod = mod;
                try
                {
                    var configuration = XDocument.Parse(header);
                    SetXML(configuration);
                    Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Successfully parsed mod header of mod \"" + ID + "\".");
                }
                catch (Exception e)
                {
                    Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Error while parsing header of mod \"" + ID + "\". Filename: \"" + Mod.FileName + "\"", Debug.Type.WARNING);
                    Valid = false;
                }
            }

            public class Button
            {
                public string StandardKey;
                public string ID;
                public MultilingualValue Name;
                public MultilingualValue Description;
                public Mod Mod;
                public bool Valid = false;

                public byte[] GetHashBytes()
                {
                    var hashBytes = new List<byte>();
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(ID));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(StandardKey));
                    hashBytes.AddRange(Name.GetHashBytes());
                    hashBytes.AddRange(Description.GetHashBytes());
                    return hashBytes.ToArray();
                }

                public Button(Mod mod)
                {
                    Mod = mod;
                }

                public bool SetXML(XElement element)
                {
                    ID = XMLHelper.GetXMLAttributeAsString(element, "ID", "");
                    if (ID == "")
                    {
                        Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Invalid mod configuration for ID \"" + Mod.ID + "\": A button is missing an ID.", Debug.Type.WARNING);
                        return false;
                    }
                    StandardKey = XMLHelper.GetXMLAttributeAsString(element, "Standard", "");
                    if (element.Element("Name") == null)
                    {
                        Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Invalid mod configuration for ID \"" + Mod.ID + "\": The button \"" + ID + "\" has no name.",
                            Debug.Type.WARNING);
                        return false;
                    }
                    Name = new MultilingualValue();
                    Name.SetXML(element.Element("Name"));
                    Description = new MultilingualValue();
                    Description.SetXML(element.Element("Description"));
                    return true;
                }

                public XElement GetXML()
                {
                    var ret = new XElement("Button");
                    ret.SetAttributeValue("ID", ID);
                    if (StandardKey != "")
                    {
                        ret.SetAttributeValue("Standard", StandardKey);
                        /*XElement standard = new XElement("StandardKey");
                        standard.Value = this.StandardKey;
                        ret.Add(standard);*/
                    }
                    if (Name != null)
                    {
                        var name = Name.GetXML();
                        name.Name = "Name";
                        ret.Add(name);
                    }
                    if (Description != null)
                    {
                        var desc = Description.GetXML();
                        desc.Name = "Description";
                        ret.Add(desc);
                    }
                    return ret;
                }
            }

            public class AddMethod
            {
                public string AssemblyName;
                public string TypeName;
                public string ReturnType;
                public string Path;
                public string MethodName;
                public string CheckSum = "";
                public Mod Mod;
                public bool Valid;
                protected MethodDefinition _Method;

                public byte[] GetHashBytes()
                {
                    var hashBytes = new List<byte>();
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(AssemblyName));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(TypeName));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(ReturnType));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(Path));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(MethodName));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(CheckSum));
                    return hashBytes.ToArray();
                }

                public AddMethod(Mod mod)
                {
                    Mod = mod;
                }

                public MethodDefinition Method
                {
                    get { return _Method; }
                    set
                    {
                        _Method = value;
                        UpdateValues();
                    }
                }

                public void SetXML(XElement element)
                {
                    AssemblyName = XMLHelper.GetXMLAttributeAsString(element, "AssemblyName", "");
                    MethodName = XMLHelper.GetXMLAttributeAsString(element, "MethodName", "");
                    TypeName = XMLHelper.GetXMLAttributeAsString(element, "TypeName", "");
                    ReturnType = XMLHelper.GetXMLAttributeAsString(element, "ReturnType", "");
                    Path = XMLHelper.GetXMLAttributeAsString(element, "Path", "");
                    CheckSum = XMLHelper.GetXMLAttributeAsString(element, "CheckSum", "");
                    Verify();
                }

                public XElement GetXML()
                {
                    UpdateValues();
                    var ret = new XElement("AddMethod");
                    ret.SetAttributeValue("AssemblyName", AssemblyName);
                    ret.SetAttributeValue("TypeName", TypeName);
                    ret.SetAttributeValue("MethodName", MethodName);
                    ret.SetAttributeValue("ReturnType", ReturnType);
                    ret.SetAttributeValue("Path", Path);
                    ret.SetAttributeValue("CheckSum", CheckSum);
                    return ret;
                }

                public void Verify()
                {
                    Valid = true;
                    if (_Method != null)
                    {
                        var NewCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Method)).ToLower().Replace("-", "");
                        if (CheckSum != NewCheckSum)
                        {
                            Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Mismatched checksum at \"" + Mod.ID + ".AddMethods." + Path + "\".");
                            Valid = false;
                        }
                    }
                }

                public void UpdateValues()
                {
                    if (_Method != null)
                    {
                        ReturnType = _Method.ReturnType.FullName;
                        TypeName = _Method.DeclaringType.BaseType.FullName;
                        MethodName = _Method.Name;
                        Path = _Method.FullName;

                        /** @TODO: Replace this basic checksum creation with something better **/
                        var NewCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Method)).ToLower().Replace("-", "");
                        if (CheckSum == "")
                        {
                            CheckSum = NewCheckSum;
                        }
                        Verify();
                    }
                }
            }

            public class AddField
            {
                public string AssemblyName;
                public string TypeName;
                public string FieldType;
                public string FieldName;
                public string Path;
                public string CheckSum = "";
                public Mod Mod;
                protected FieldDefinition _Field;
                public bool Valid;

                public byte[] GetHashBytes()
                {
                    var hashBytes = new List<byte>();
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(AssemblyName));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(TypeName));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(FieldType));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(FieldName));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(Path));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(CheckSum));
                    return hashBytes.ToArray();
                }

                public AddField(Mod mod)
                {
                    Mod = mod;
                }

                public FieldDefinition Field
                {
                    get { return _Field; }
                    set
                    {
                        _Field = value;
                        UpdateValues();
                    }
                }

                public void SetXML(XElement element)
                {
                    AssemblyName = XMLHelper.GetXMLAttributeAsString(element, "AssemblyName", "");
                    TypeName = XMLHelper.GetXMLAttributeAsString(element, "TypeName", "");
                    FieldType = XMLHelper.GetXMLAttributeAsString(element, "FieldType", "");
                    FieldName = XMLHelper.GetXMLAttributeAsString(element, "FieldName", "");
                    Path = XMLHelper.GetXMLAttributeAsString(element, "Path", "");
                    CheckSum = XMLHelper.GetXMLAttributeAsString(element, "CheckSum", "");
                    Verify();
                }

                public void Verify()
                {
                    Valid = true;
                    if (_Field != null)
                    {
                        var NewCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Field)).ToLower().Replace("-", "");
                        if (CheckSum != NewCheckSum)
                        {
                            Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Mismatched checksum at \"" + Mod.ID + ".AddFields." + Path + "\".");
                            Valid = false;
                        }
                    }
                }

                public XElement GetXML()
                {
                    UpdateValues();
                    var ret = new XElement("AddField");
                    ret.SetAttributeValue("AssemblyName", AssemblyName);
                    ret.SetAttributeValue("TypeName", TypeName);
                    ret.SetAttributeValue("FieldType", FieldType);
                    ret.SetAttributeValue("FieldName", FieldName);
                    ret.SetAttributeValue("Path", Path);
                    ret.SetAttributeValue("CheckSum", CheckSum);
                    return ret;
                }

                public void UpdateValues()
                {
                    if (_Field != null)
                    {
                        FieldType = _Field.FieldType.FullName;
                        FieldName = _Field.Name;
                        TypeName = _Field.DeclaringType.BaseType.FullName;
                        Path = _Field.FullName;

                        /** @TODO: Replace this basic checksum creation with something better **/
                        var NewCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Field)).ToLower().Replace("-", "");
                        if (CheckSum == "")
                        {
                            CheckSum = NewCheckSum;
                        }
                        Verify();
                    }
                }
            }

            public class InjectInto
            {
                public string AssemblyName;
                public string TypeName;
                public string MethodName;
                public string Path;
                public string CheckSum = "";
                public int Priority;
                public Mod Mod;
                public bool Valid;

                protected MethodDefinition _Method;

                public byte[] GetHashBytes()
                {
                    var hashBytes = new List<byte>();
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(AssemblyName));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(TypeName));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(MethodName));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(Path));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(CheckSum));
                    hashBytes.AddRange(BitConverter.GetBytes(Priority));
                    return hashBytes.ToArray();
                }

                public InjectInto(Mod mod)
                {
                    Mod = mod;
                }

                public MethodDefinition Method
                {
                    get { return _Method; }
                    set
                    {
                        _Method = value;
                        UpdateValues();
                    }
                }

                public void SetXML(XElement element)
                {
                    AssemblyName = XMLHelper.GetXMLAttributeAsString(element, "AssemblyName", "");
                    TypeName = XMLHelper.GetXMLAttributeAsString(element, "TypeName", "");
                    MethodName = XMLHelper.GetXMLAttributeAsString(element, "MethodName", "");
                    Path = XMLHelper.GetXMLAttributeAsString(element, "Path", "");
                    Priority = XMLHelper.GetXMLAttributeAsInt(element, "Priority", 0);
                    CheckSum = XMLHelper.GetXMLAttributeAsString(element, "CheckSum", "");
                    Verify();
                }

                public XElement GetXML()
                {
                    UpdateValues();
                    var ret = new XElement("InjectInto");
                    ret.SetAttributeValue("AssemblyName", AssemblyName);
                    ret.SetAttributeValue("TypeName", TypeName);
                    ret.SetAttributeValue("MethodName", MethodName);
                    ret.SetAttributeValue("Path", Path);
                    ret.SetAttributeValue("Priority", Priority);
                    ret.SetAttributeValue("CheckSum", CheckSum);
                    return ret;
                }

                public void Verify()
                {
                    Valid = true;
                    if (_Method != null)
                    {
                        var NewCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Method)).ToLower().Replace("-", "");
                        if (CheckSum != NewCheckSum)
                        {
                            Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Mismatched checksum at \"" + Mod.ID + ".InjectIntos." + Path + "\".");
                            Valid = false;
                        }
                    }
                }

                public void UpdateValues()
                {
                    if (_Method != null)
                    {
                        MethodName = _Method.Name;
                        TypeName = _Method.DeclaringType.BaseType.FullName;
                        Path = _Method.FullName;
                        Priority = 0;
                        foreach (var ca in _Method.CustomAttributes)
                        {
                            if (ca.AttributeType.FullName == "ModAPI.Priority")
                            {
                                Priority = (int) ca.ConstructorArguments[0].Value;
                            }
                        }

                        /** @TODO: Replace this basic checksum creation with something better **/
                        var NewCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Method)).ToLower().Replace("-", "");
                        if (CheckSum == "")
                        {
                            CheckSum = NewCheckSum;
                        }
                        Verify();
                    }
                }
            }

            public class AddClass
            {
                public string TypeName;
                public string CheckSum = "";
                public Mod Mod;
                public bool Valid;

                protected TypeDefinition _Type;

                public byte[] GetHashBytes()
                {
                    var hashBytes = new List<byte>();
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(TypeName));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(CheckSum));
                    return hashBytes.ToArray();
                }

                public AddClass(Mod mod)
                {
                    Mod = mod;
                }

                public TypeDefinition Type
                {
                    get { return _Type; }
                    set
                    {
                        _Type = value;
                        UpdateValues();
                    }
                }

                public void SetXML(XElement element)
                {
                    TypeName = XMLHelper.GetXMLAttributeAsString(element, "TypeName", "");
                    CheckSum = XMLHelper.GetXMLAttributeAsString(element, "CheckSum", "");
                    Verify();
                }

                public void Verify()
                {
                    Valid = true;
                    if (_Type != null)
                    {
                        var NewCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Type)).ToLower().Replace("-", "");
                        if (CheckSum != NewCheckSum)
                        {
                            Debug.Log("Game: " + Mod.Game.GameConfiguration.ID, "Mismatched checksum at \"" + Mod.ID + ".AddClasses." + TypeName + "\".");
                            Valid = false;
                        }
                    }
                }

                public XElement GetXML()
                {
                    UpdateValues();
                    var ret = new XElement("AddClass");
                    ret.SetAttributeValue("TypeName", TypeName);
                    ret.SetAttributeValue("CheckSum", CheckSum);
                    return ret;
                }

                public void UpdateValues()
                {
                    if (_Type != null)
                    {
                        TypeName = _Type.FullName;
                        /** @TODO: Replace this basic checksum creation with something better **/
                        var NewCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Type)).ToLower().Replace("-", "");
                        if (CheckSum == "")
                        {
                            CheckSum = NewCheckSum;
                        }
                        Verify();
                    }
                }
            }
        }
    }
}
