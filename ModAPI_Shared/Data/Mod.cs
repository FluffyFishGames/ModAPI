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
        public string Id;
        public bool Valid;
        public DateTime LoadedDate;
        public Game Game;
        public ZipFile Resources;

        public string UniqueId
        {
            get
            {
                var md5 = MD5.Create();
                var unique = md5.ComputeHash(GetHashBytes());
                return Id + "-" + HeaderData.GetVersion() + "-" + BitConverter.ToString(unique).ToLower().Replace("-", "");
            }
        }

        public static Dictionary<string, Mod> Mods = new Dictionary<string, Mod>();
        protected static Dictionary<string, Mod> FilenameToMod = new Dictionary<string, Mod>();

        protected static bool ModsLoaded = false;
        public string FileName = "";

        public Header HeaderData;
        public ModuleDefinition Module;
        public ModuleDefinition OriginalModule;
        public bool HasResources;
        public int ResourcesIndex;

        protected bool Loaded;
        protected string HeaderText = "";
        protected string AssemblyText = "";

        public byte[] GetHashBytes()
        {
            var hashBytes = new List<byte>();
            hashBytes.AddRange(HeaderData.GetHashBytes());
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
            if (HeaderData == null)
            {
                Valid = false;
            }
            else
            {
                HeaderData.Verify();
                if (!HeaderData.Valid)
                {
                    Valid = false;
                }
            }
            if (Module == null)
            {
                Valid = false;
            }
        }

        public Header GetHeader()
        {
            if (HeaderData != null || Load())
            {
                return HeaderData;
            }
            return null;
        }

        public ModuleDefinition GetModule()
        {
            if (Module != null || Load())
            {
                return Module;
            }
            return null;
        }

        public void RewindModule()
        {
            var stream = new MemoryStream();
            OriginalModule.Write(stream);
            stream.Position = 0;
            Module = ModuleDefinition.ReadModule(stream);
            AssignModule();
        }

        public bool Save()
        {
            try
            {
                var modContent = HeaderData.GetXml().ToString();
                modContent += "\r\n";
                var stream = new MemoryStream();
                Module.Write(stream);
                stream.Position = 0;
                OriginalModule = ModuleDefinition.ReadModule(stream);
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
                Debug.Log("Mod: " + Id, "Couldn't save mod to: \"" + FileName + "\": " + e, Debug.Type.Error);
                return false;
            }
        }

        public bool Load()
        {
            if (Loaded)
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
                    Debug.Log("Game: " + Game.GameConfiguration.Id, "Can't load the mod at \"" + FileName + "\". Exception: " + e, Debug.Type.Warning);
                    return false;
                }

                var text = Encoding.UTF8.GetString(decompressedBytes);
                var parts = text.Split(new[] { "\n" }, StringSplitOptions.None);
                var HeaderData = "";

                var headerSize = 0;
                for (var i = 0; i < parts.Length; i++)
                {
                    HeaderData += parts[i] + "\n";
                    headerSize += parts[i].Length + 1;
                    if (parts[i].EndsWith("</Mod>\r"))
                    {
                        break;
                    }
                    if (i == parts.Length - 1)
                    {
                        Debug.Log("Game: " + Game.GameConfiguration.Id, "Can't load the mod at \"" + FileName + "\". File-HeaderData is corrupted.", Debug.Type.Warning);
                        return false;
                    }
                }

                this.HeaderData = new Header(this, HeaderData);
                var assemblyText = text.Substring(headerSize);
                var resourcesIndex = assemblyText.IndexOf("\r\n\r\n");
                if (resourcesIndex > 0)
                {
                    // Resources found
                    HasResources = true;
                    assemblyText = assemblyText.Substring(0, resourcesIndex);
                    ResourcesIndex = Encoding.UTF8.GetBytes(assemblyText + "\r\n\r\n").Length + Encoding.UTF8.GetBytes(HeaderData).Length;
                }

                Debug.Log("Game: " + Game.GameConfiguration.Id, "Successfully loaded mod HeaderData \"" + Id + "\" in version \"" + this.HeaderData.GetVersion() + "\" at \"" + FileName + "\"");

                try
                {
                    var dllBytes = Convert.FromBase64String(assemblyText);
                    var dllStream = new MemoryStream(dllBytes)
                    {
                        Position = 0
                    };
                    OriginalModule = ModuleDefinition.ReadModule(dllStream);
                    dllStream.Position = 0;
                    Module = ModuleDefinition.ReadModule(dllStream);

                    AssignModule();

                    Debug.Log("Game: " + Game.GameConfiguration.Id, "Successfully loaded mod module \"" + Id + "\" in version \"" + this.HeaderData.GetVersion() + "\" at \"" + FileName + "\"");
                }
                catch (Exception e)
                {
                    Module = null;
                    Debug.Log("Game: " + Game.GameConfiguration.Id, "Can't load the mod at \"" + FileName + "\". File-module is corrupted. Exception: " + e, Debug.Type.Warning);
                    return false;
                }
                Loaded = true;
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
            OriginalModule.Write(dllStream);
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
                    Debug.Log("Game: " + Game.GameConfiguration.Id, "Can't load the mod at \"" + FileName + "\". Exception: " + e, Debug.Type.Warning);
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
                    Debug.Log("Game: " + Game.GameConfiguration.Id, "Can't load the resources for the mod at \"" + FileName + "\". Exception: " + e, Debug.Type.Warning);
                    return null;
                }
            }
            return null;
        }

        protected void AssignModule()
        {
            foreach (var i in HeaderData.GetAddClasses())
            {
                var type = TypeResolver.FindTypeDefinition(Module, i.TypeName);
                if (type != null)
                {
                    i.Type = type;
                }
                else
                {
                    Debug.Log("Game: " + Game.GameConfiguration.Id, "Can't find type \"" + i.TypeName + "\" in mod \"" + Id + "\" but it is declared in its HeaderData as add class.");
                }
            }
            foreach (var i in HeaderData.GetAddMethods())
            {
                var method = TypeResolver.FindMethodDefinition(Module, i.Path);
                if (method != null)
                {
                    i.Method = method;
                }
                else
                {
                    Debug.Log("Game: " + Game.GameConfiguration.Id, "Can't find method \"" + i.Path + "\" in mod \"" + Id + "\" but it is declared in its HeaderData as add method.");
                }
            }
            foreach (var i in HeaderData.GetInjectIntos())
            {
                var method = TypeResolver.FindMethodDefinition(Module, i.Path);
                if (method != null)
                {
                    i.Method = method;
                }
                else
                {
                    Debug.Log("Game: " + Game.GameConfiguration.Id, "Can't find method \"" + i.Path + "\" in mod \"" + Id + "\" but it is declared in its HeaderData as inject into.");
                }
            }
            foreach (var i in HeaderData.GetAddFields())
            {
                var field = TypeResolver.FindFieldDefinition(Module, i.Path);
                if (field != null)
                {
                    i.Field = field;
                }
                else
                {
                    Debug.Log("Game: " + Game.GameConfiguration.Id, "Can't find field \"" + i.Path + "\" in mod \"" + Id + "\" but it is declared in its HeaderData as add field.");
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
            protected string Id;
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
                hashBytes.AddRange(Encoding.UTF8.GetBytes(Id));
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

            public static bool VerifyModId(string name)
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

            public bool SetId(string id)
            {
                if (VerifyModId(id))
                {
                    Id = id;
                    Mod.Id = Id;
                    return true;
                }
                Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Invalid mod configuration: The ID \"" + id + "\" is invalid.", Debug.Type.Warning);
                return false;
            }

            protected bool SetId(XAttribute attribute)
            {
                if (attribute == null)
                {
                    Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Invalid mod configuration: The ID is missing.", Debug.Type.Warning);
                    return false;
                }
                return SetId(attribute.Value);
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
                Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Invalid mod configuration for ID \"" + Id + "\": The version string is invalid.", Debug.Type.Warning);
                return false;
            }

            protected bool SetVersion(XElement element)
            {
                if (element == null)
                {
                    Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Invalid mod configuration for ID \"" + Id + "\": The version string is missing.", Debug.Type.Warning);
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
                    Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Invalid mod configuration for ID \"" + Id + "\": The name is missing.", Debug.Type.Warning);
                    return false;
                }
                var val = new MultilingualValue();
                val.SetXml(element);
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
                    Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Invalid mod configuration for ID \"" + Id + "\": The description is missing.", Debug.Type.Warning);
                    return false;
                }
                var val = new MultilingualValue();
                val.SetXml(element);
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
                        if (button.Id == otherButton.Id)
                        {
                            Debug.Log("Game: " + Mod.Game.GameConfiguration.Id,
                                "Invalid mod configuration for ID \"" + Id + "\": There are more than one button with ID \"" + button.Id + "\".", Debug.Type.Warning);
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
                if (button.SetXml(element))
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
                obj.SetXml(element);
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
                obj.SetXml(element);
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
                obj.SetXml(element);
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
                obj.SetXml(element);
                return AddAddMethod(obj);
            }

            public XDocument GetXml()
            {
                var document = new XDocument();
                var rootElement = new XElement("Mod");
                rootElement.SetAttributeValue("ID", Id);
                rootElement.Add(new XElement("Compatible", Compatible));
                rootElement.Add(new XElement("Version", Version));

                var nameElement = Name.GetXml();
                nameElement.Name = "Name";
                rootElement.Add(nameElement);

                var descriptionElement = Description.GetXml();
                descriptionElement.Name = "Description";
                rootElement.Add(descriptionElement);

                foreach (var button in Buttons)
                {
                    rootElement.Add(button.GetXml());
                }
                foreach (var injectInto in InjectIntos)
                {
                    rootElement.Add(injectInto.GetXml());
                }
                foreach (var addField in AddFields)
                {
                    rootElement.Add(addField.GetXml());
                }
                foreach (var addMethod in AddMethods)
                {
                    rootElement.Add(addMethod.GetXml());
                }
                foreach (var addClass in AddClasses)
                {
                    rootElement.Add(addClass.GetXml());
                }

                document.Add(rootElement);
                return document;
            }

            public void SetXml(XDocument configuration)
            {
                if (!SetId(configuration.Root.Attribute("ID")))
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
                if (Id == "")
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
                    if (buttonIDs.Contains(b.Id))
                    {
                        Valid = false;
                    }
                    buttonIDs.Add(b.Id);
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

            public Header(Mod mod, string HeaderData)
            {
                Mod = mod;
                try
                {
                    var configuration = XDocument.Parse(HeaderData);
                    SetXml(configuration);
                    Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Successfully parsed mod HeaderData of mod \"" + Id + "\".");
                }
                catch (Exception e)
                {
                    Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Error while parsing HeaderData of mod \"" + Id + "\". Filename: \"" + Mod.FileName + "\"", Debug.Type.Warning);
                    Valid = false;
                }
            }

            public class Button
            {
                public string StandardKey;
                public string Id;
                public MultilingualValue Name;
                public MultilingualValue Description;
                public Mod Mod;
                public bool Valid = false;

                public byte[] GetHashBytes()
                {
                    var hashBytes = new List<byte>();
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(Id));
                    hashBytes.AddRange(Encoding.UTF8.GetBytes(StandardKey));
                    hashBytes.AddRange(Name.GetHashBytes());
                    hashBytes.AddRange(Description.GetHashBytes());
                    return hashBytes.ToArray();
                }

                public Button(Mod mod)
                {
                    Mod = mod;
                }

                public bool SetXml(XElement element)
                {
                    Id = XmlHelper.GetXmlAttributeAsString(element, "ID", "");
                    if (Id == "")
                    {
                        Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Invalid mod configuration for ID \"" + Mod.Id + "\": A button is missing an ID.", Debug.Type.Warning);
                        return false;
                    }
                    StandardKey = XmlHelper.GetXmlAttributeAsString(element, "Standard", "");
                    if (element.Element("Name") == null)
                    {
                        Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Invalid mod configuration for ID \"" + Mod.Id + "\": The button \"" + Id + "\" has no name.",
                            Debug.Type.Warning);
                        return false;
                    }
                    Name = new MultilingualValue();
                    Name.SetXml(element.Element("Name"));
                    Description = new MultilingualValue();
                    Description.SetXml(element.Element("Description"));
                    return true;
                }

                public XElement GetXml()
                {
                    var ret = new XElement("Button");
                    ret.SetAttributeValue("ID", Id);
                    if (StandardKey != "")
                    {
                        ret.SetAttributeValue("Standard", StandardKey);
                        /*XElement standard = new XElement("StandardKey");
                        standard.Value = this.StandardKey;
                        ret.Add(standard);*/
                    }
                    if (Name != null)
                    {
                        var name = Name.GetXml();
                        name.Name = "Name";
                        ret.Add(name);
                    }
                    if (Description != null)
                    {
                        var desc = Description.GetXml();
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

                public void SetXml(XElement element)
                {
                    AssemblyName = XmlHelper.GetXmlAttributeAsString(element, "AssemblyName", "");
                    MethodName = XmlHelper.GetXmlAttributeAsString(element, "MethodName", "");
                    TypeName = XmlHelper.GetXmlAttributeAsString(element, "TypeName", "");
                    ReturnType = XmlHelper.GetXmlAttributeAsString(element, "ReturnType", "");
                    Path = XmlHelper.GetXmlAttributeAsString(element, "Path", "");
                    CheckSum = XmlHelper.GetXmlAttributeAsString(element, "CheckSum", "");
                    Verify();
                }

                public XElement GetXml()
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
                        var newCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Method)).ToLower().Replace("-", "");
                        if (CheckSum != newCheckSum)
                        {
                            Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Mismatched checksum at \"" + Mod.Id + ".AddMethods." + Path + "\".");
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
                        var newCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Method)).ToLower().Replace("-", "");
                        if (CheckSum == "")
                        {
                            CheckSum = newCheckSum;
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

                public void SetXml(XElement element)
                {
                    AssemblyName = XmlHelper.GetXmlAttributeAsString(element, "AssemblyName", "");
                    TypeName = XmlHelper.GetXmlAttributeAsString(element, "TypeName", "");
                    FieldType = XmlHelper.GetXmlAttributeAsString(element, "FieldType", "");
                    FieldName = XmlHelper.GetXmlAttributeAsString(element, "FieldName", "");
                    Path = XmlHelper.GetXmlAttributeAsString(element, "Path", "");
                    CheckSum = XmlHelper.GetXmlAttributeAsString(element, "CheckSum", "");
                    Verify();
                }

                public void Verify()
                {
                    Valid = true;
                    if (_Field != null)
                    {
                        var newCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Field)).ToLower().Replace("-", "");
                        if (CheckSum != newCheckSum)
                        {
                            Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Mismatched checksum at \"" + Mod.Id + ".AddFields." + Path + "\".");
                            Valid = false;
                        }
                    }
                }

                public XElement GetXml()
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
                        var newCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Field)).ToLower().Replace("-", "");
                        if (CheckSum == "")
                        {
                            CheckSum = newCheckSum;
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

                public void SetXml(XElement element)
                {
                    AssemblyName = XmlHelper.GetXmlAttributeAsString(element, "AssemblyName", "");
                    TypeName = XmlHelper.GetXmlAttributeAsString(element, "TypeName", "");
                    MethodName = XmlHelper.GetXmlAttributeAsString(element, "MethodName", "");
                    Path = XmlHelper.GetXmlAttributeAsString(element, "Path", "");
                    Priority = XmlHelper.GetXmlAttributeAsInt(element, "Priority", 0);
                    CheckSum = XmlHelper.GetXmlAttributeAsString(element, "CheckSum", "");
                    Verify();
                }

                public XElement GetXml()
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
                        var newCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Method)).ToLower().Replace("-", "");
                        if (CheckSum != newCheckSum)
                        {
                            Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Mismatched checksum at \"" + Mod.Id + ".InjectIntos." + Path + "\".");
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
                        var newCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Method)).ToLower().Replace("-", "");
                        if (CheckSum == "")
                        {
                            CheckSum = newCheckSum;
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

                public void SetXml(XElement element)
                {
                    TypeName = XmlHelper.GetXmlAttributeAsString(element, "TypeName", "");
                    CheckSum = XmlHelper.GetXmlAttributeAsString(element, "CheckSum", "");
                    Verify();
                }

                public void Verify()
                {
                    Valid = true;
                    if (_Type != null)
                    {
                        var newCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Type)).ToLower().Replace("-", "");
                        if (CheckSum != newCheckSum)
                        {
                            Debug.Log("Game: " + Mod.Game.GameConfiguration.Id, "Mismatched checksum at \"" + Mod.Id + ".AddClasses." + TypeName + "\".");
                            Valid = false;
                        }
                    }
                }

                public XElement GetXml()
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
                        var newCheckSum = BitConverter.ToString(Checksum.CreateChecksum(_Type)).ToLower().Replace("-", "");
                        if (CheckSum == "")
                        {
                            CheckSum = newCheckSum;
                        }
                        Verify();
                    }
                }
            }
        }
    }
}
