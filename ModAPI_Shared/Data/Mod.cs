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
using System.Xml.Linq;
using System.Text.RegularExpressions;
using Mono.Cecil.Cil;
using Mono.Cecil;
using System.IO;
using System.Security.Cryptography;
using Ionic.Zip;

namespace ModAPI.Data
{
    public class Mod
    {
        public string ID;
        public bool Valid = false;
        public DateTime LoadedDate;
        public Game Game;
        public ZipFile Resources;

        public string UniqueID
        {
            get
            {
                MD5 md5 = MD5.Create();
                byte[] unique = md5.ComputeHash(GetHashBytes());
                return ID + "-" + header.GetVersion() + "-" + System.BitConverter.ToString(unique).ToLower().Replace("-", "");
            }
        }
        
        public static Dictionary<string, Mod> Mods = new Dictionary<string,Mod>();
        protected static Dictionary<string, Mod> FilenameToMod = new Dictionary<string, Mod>();

        protected static bool modsLoaded = false;
        public string FileName = "";
        
        public Header header = null;
        public ModuleDefinition module;
        public ModuleDefinition originalModule;
        public bool HasResources = false;
        public int ResourcesIndex = 0;

        protected bool loaded = false;
        protected string headerText = "";
        protected string assemblyText = "";

        public byte[] GetHashBytes()
        {
            List<byte> hashBytes = new List<byte>();
            hashBytes.AddRange(header.GetHashBytes());
            return hashBytes.ToArray();
        }

        public Mod()
        {

        }

        public void Remove()
        {
            if (FileName != "" && System.IO.File.Exists(FileName))
            {
                System.IO.File.Delete(FileName);
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
                    Valid = false;
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
                return this.module;
            }
            return null;
        }

        public void RewindModule()
        {
            MemoryStream stream = new MemoryStream();
            originalModule.Write(stream);
            stream.Position = 0;
            module = ModuleDefinition.ReadModule(stream);
            AssignModule();
        }
        public bool Save()
        {
            try
            {
                string modContent = header.GetXML().ToString();
                modContent += "\r\n";
                MemoryStream stream = new MemoryStream();
                module.Write(stream);
                stream.Position = 0;
                originalModule = ModuleDefinition.ReadModule(stream);
                stream.Position = 0;
                byte[] modBytes = new byte[stream.Length];
                stream.Read(modBytes, 0, (int)stream.Length); //max size of mods are 2047,9MB
                modContent += Convert.ToBase64String(modBytes);

                string folder = System.IO.Path.GetDirectoryName(FileName);
                if (!System.IO.Directory.Exists(folder))
                    System.IO.Directory.CreateDirectory(folder);

                System.IO.FileStream fileStream = System.IO.File.Create(FileName);
                
                if (Resources != null)
                {
                    this.HasResources = true;
                    this.ResourcesIndex = System.Text.Encoding.UTF8.GetBytes(modContent + "\r\n\r\n").Length;
                    
                    MemoryStream resourcesStream = new MemoryStream();
                    this.Resources.Save(resourcesStream);
                    resourcesStream.Position = 0;
                    byte[] resourcesBytes = new byte[resourcesStream.Length];
                    resourcesStream.Read(resourcesBytes, 0, resourcesBytes.Length);
                    modContent += "\r\n\r\n" + Convert.ToBase64String(resourcesBytes);
                }

                System.IO.Compression.GZipStream gzip = new System.IO.Compression.GZipStream(fileStream, System.IO.Compression.CompressionLevel.Optimal);
                byte[] b = Encoding.UTF8.GetBytes(modContent);
                gzip.Write(b, 0, b.Length);
                gzip.Close();

                //fileStream.Write(modFile, 0, modFile.Length);
                fileStream.Close();
                return true;
            }
            catch (Exception e)
            {
                Debug.Log("Mod: " + this.ID, "Couldn't save mod to: \"" + FileName + "\": " + e.ToString(), Debug.Type.ERROR);
                return false;
            }
        }
        public bool Load()
        {
            if (loaded) return true;
            if (System.IO.File.Exists(FileName))
            {
                byte[] b = System.IO.File.ReadAllBytes(FileName);
                byte[] decompressedBytes = new byte[0];
                try
                {
                    using (System.IO.Compression.GZipStream stream = new System.IO.Compression.GZipStream(new System.IO.MemoryStream(b), System.IO.Compression.CompressionMode.Decompress))
                    {
                        const int size = 4096;
                        byte[] buffer = new byte[size];

                        using (System.IO.MemoryStream memory = new System.IO.MemoryStream())
                        {
                            int count = 0;
                            do
                            {
                                count = stream.Read(buffer, 0, size);
                                if (count > 0)
                                {
                                    memory.Write(buffer, 0, count);
                                }
                            }
                            while (count > 0);
                            decompressedBytes = memory.ToArray();
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("Game: "+this.Game.GameConfiguration.ID, "Can't load the mod at \"" + FileName + "\". Exception: "+e.ToString(), Debug.Type.WARNING);
                    return false;
                }

                string text = Encoding.UTF8.GetString(decompressedBytes);
                string[] parts = text.Split(new string[] { "\n" }, StringSplitOptions.None);
                string header = "";

                int headerSize = 0;
                for (int i = 0; i < parts.Length; i++)
                {
                    header += parts[i] + "\n";
                    headerSize += parts[i].Length + 1;
                    if (parts[i].EndsWith("</Mod>\r"))
                    {
                        break;
                    }
                    if (i == parts.Length - 1)
                    {
                        Debug.Log("Game: "+this.Game.GameConfiguration.ID, "Can't load the mod at \"" + FileName + "\". File-header is corrupted.", Debug.Type.WARNING);
                        return false;
                    }
                }

                this.header = new Header(this, header);
                string assemblyText = text.Substring(headerSize);
                int resourcesIndex = assemblyText.IndexOf("\r\n\r\n");
                if (resourcesIndex > 0)
                {
                    // Resources found
                    this.HasResources = true;
                    assemblyText = assemblyText.Substring(0, resourcesIndex);
                    this.ResourcesIndex = Encoding.UTF8.GetBytes(assemblyText + "\r\n\r\n").Length + Encoding.UTF8.GetBytes(header).Length;
                }

                Debug.Log("Game: "+this.Game.GameConfiguration.ID, "Successfully loaded mod header \"" + this.ID + "\" in version \"" + this.header.GetVersion() + "\" at \"" + FileName + "\"");

                try
                {
                    byte[] dllBytes = Convert.FromBase64String(assemblyText);
                    MemoryStream dllStream = new MemoryStream(dllBytes);
                    dllStream.Position = 0;

                    this.originalModule = ModuleDefinition.ReadModule(dllStream);
                    dllStream.Position = 0;
                    this.module = ModuleDefinition.ReadModule(dllStream);
                    
                    AssignModule();

                    Debug.Log("Game: "+this.Game.GameConfiguration.ID, "Successfully loaded mod module \"" + this.ID + "\" in version \"" + this.header.GetVersion() + "\" at \"" + FileName + "\"");
                }
                catch (Exception e)
                {
                    this.module = null;
                    Debug.Log("Game: "+this.Game.GameConfiguration.ID, "Can't load the mod at \"" + FileName + "\". File-module is corrupted. Exception: "+e.ToString(), Debug.Type.WARNING);
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
            MemoryStream dllStream = new MemoryStream();
            originalModule.Write(dllStream);
            dllStream.Position = 0;
            return ModuleDefinition.ReadModule(dllStream);
        }

        public ZipFile GetResources()
        {
            if (HasResources)
            {
                byte[] b = System.IO.File.ReadAllBytes(FileName);
                byte[] decompressedBytes = new byte[0];
                try
                {
                    using (System.IO.Compression.GZipStream stream = new System.IO.Compression.GZipStream(new System.IO.MemoryStream(b), System.IO.Compression.CompressionMode.Decompress))
                    {
                        const int size = 4096;
                        byte[] buffer = new byte[size];

                        using (System.IO.MemoryStream memory = new System.IO.MemoryStream())
                        {
                            int count = 0;
                            do
                            {
                                count = stream.Read(buffer, 0, size);
                                if (count > 0)
                                {
                                    memory.Write(buffer, 0, count);
                                }
                            }
                            while (count > 0);
                            decompressedBytes = memory.ToArray();
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("Game: " + this.Game.GameConfiguration.ID, "Can't load the mod at \"" + FileName + "\". Exception: " + e.ToString(), Debug.Type.WARNING);
                    return null;
                }
                try
                {
                    byte[] zipBytes = Convert.FromBase64String(System.Text.Encoding.UTF8.GetString(decompressedBytes, this.ResourcesIndex, decompressedBytes.Length - this.ResourcesIndex));
                    MemoryStream m = new MemoryStream();
                    m.Write(zipBytes, 0, zipBytes.Length);
                    m.Position = 0;
                    ZipFile zip = ZipFile.Read(m);
                    return zip;
                } catch (Exception e)
                {
                    Debug.Log("Game: " + this.Game.GameConfiguration.ID, "Can't load the resources for the mod at \"" + FileName + "\". Exception: " + e.ToString(), Debug.Type.WARNING);
                    return null;
                }
            }
            return null;
        }
        protected void AssignModule()
        {
            foreach (Header.AddClass i in this.header.GetAddClasses())
            {
                TypeDefinition type = Utils.TypeResolver.FindTypeDefinition(module, i.TypeName);
                if (type != null)
                    i.Type = type;
                else
                    Debug.Log("Game: "+this.Game.GameConfiguration.ID, "Can't find type \"" + i.TypeName + "\" in mod \"" + this.ID + "\" but it is declared in its header as add class.");
            }
            foreach (Header.AddMethod i in this.header.GetAddMethods())
            {
                MethodDefinition method = Utils.TypeResolver.FindMethodDefinition(module, i.Path);
                if (method != null)
                    i.Method = method;
                else
                    Debug.Log("Game: "+this.Game.GameConfiguration.ID, "Can't find method \"" + i.Path + "\" in mod \"" + this.ID + "\" but it is declared in its header as add method.");
            }
            foreach (Header.InjectInto i in this.header.GetInjectIntos())
            {
                MethodDefinition method = Utils.TypeResolver.FindMethodDefinition(module, i.Path);
                if (method != null)
                    i.Method = method;
                else
                    Debug.Log("Game: "+this.Game.GameConfiguration.ID, "Can't find method \"" + i.Path + "\" in mod \"" + this.ID + "\" but it is declared in its header as inject into.");
            }
            foreach (Header.AddField i in this.header.GetAddFields())
            {
                FieldDefinition field = Utils.TypeResolver.FindFieldDefinition(module, i.Path);
                if (field != null)
                    i.Field = field;
                else
                    Debug.Log("Game: "+this.Game.GameConfiguration.ID, "Can't find field \"" + i.Path + "\" in mod \"" + this.ID + "\" but it is declared in its header as add field.");
            }
        }

        public Mod(Game game, string fileName) 
        {
            this.Game = game;
            this.FileName = fileName;
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
                List<byte> hashBytes = new List<byte>();
                hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(ID));
                hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(Version));
                hashBytes.AddRange(Name.GetHashBytes());
                hashBytes.AddRange(Encoding.UTF8.GetBytes(this.Compatible));
                hashBytes.AddRange(Description.GetHashBytes());

                foreach (Button h in Buttons)
                {
                    hashBytes.AddRange(h.GetHashBytes());
                }
                foreach (AddMethod h in AddMethods)
                {
                    hashBytes.AddRange(h.GetHashBytes());
                }
                foreach (AddField h in AddFields)
                {
                    hashBytes.AddRange(h.GetHashBytes());
                }
                foreach (AddClass h in AddClasses)
                {
                    hashBytes.AddRange(h.GetHashBytes());
                }
                foreach (InjectInto h in InjectIntos)
                {
                    hashBytes.AddRange(h.GetHashBytes());
                }
                return hashBytes.ToArray();
            }

            public Header(Mod mod)
            {
                this.Mod = mod;
            }

            public static bool VerifyModID(string name)
            {
                Regex validation = new Regex("^[a-zA-Z0-9_]+$");
                return validation.IsMatch(name);
            }

            public static bool VerifyModVersion(string version)
            {
                Regex validation = new Regex("^([0-9]{1,2})(\\.[0-9]{1,2}){0,3}$");
                return validation.IsMatch(version);
            }

            public static int ParseModVersion(string version)
            {
                try
                {
                    string[] parts = version.Split(new string[] { "." }, StringSplitOptions.None);
                    int num = 0;
                    int multiplier = 100 * 100 * 100;
                    for (int i = 0; i < parts.Length; i++)
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
                Debug.Log("Game: "+this.Mod.Game.GameConfiguration.ID, "Invalid mod configuration: The ID \""+ID+"\" is invalid.", Debug.Type.WARNING);
                return false;
            }

            protected bool SetID(XAttribute attribute)
            {
                if (attribute == null)
                {
                    Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Invalid mod configuration: The ID is missing.", Debug.Type.WARNING);
                    return false;
                }
                return SetID(attribute.Value);
            }

            public string GetVersion()
            {
                return this.Version;
            }

            public string GetCompatible()
            {
                return this.Compatible;
            }

            public bool SetCompatible(string compatible)
            {
                this.Compatible = compatible;
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
                    this.Version = version;
                    this.VersionNumber = ParseModVersion(version);
                    if (this.VersionNumber == -1)
                        return false;
                    return true;
                }
                Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Invalid mod configuration for ID \"" + this.ID + "\": The version string is invalid.", Debug.Type.WARNING);
                return false;
            }

            protected bool SetVersion(XElement element)
            {
                if (element == null)
                {
                    Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Invalid mod configuration for ID \"" + this.ID + "\": The version string is missing.", Debug.Type.WARNING);
                    return false;
                }
                return SetVersion(element.Value);
            }

            public bool SetName(MultilingualValue val)
            {
                this.Name = val;
                return true;
            }

            protected bool SetName(XElement element)
            {
                if (element == null)
                {
                    Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Invalid mod configuration for ID \"" + this.ID + "\": The name is missing.", Debug.Type.WARNING);
                    return false;
                }
                MultilingualValue val = new MultilingualValue();
                val.SetXML(element);
                return SetName(val);
            }

            public bool SetDescription(MultilingualValue val)
            {
                this.Description = val;
                return true;
            }

            protected bool SetDescription(XElement element)
            {
                if (element == null)
                {
                    Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Invalid mod configuration for ID \"" + this.ID + "\": The description is missing.", Debug.Type.WARNING);
                    return false;
                }
                MultilingualValue val = new MultilingualValue();
                val.SetXML(element);
                return SetDescription(val);
            }

            public MultilingualValue GetDescription()
            {
                return this.Description;
            }

            public MultilingualValue GetName()
            {
                return this.Name;
            }

            public bool AddButton(Button button)
            {
                if (this.Buttons != null)
                {
                    foreach (Button otherButton in this.Buttons)
                    {
                        if (button.ID == otherButton.ID)
                        {
                            Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Invalid mod configuration for ID \"" + this.ID + "\": There are more than one button with ID \"" + button.ID + "\".", Debug.Type.WARNING);
                            return false;
                        }
                    }
                }
                else
                {
                    this.Buttons = new List<Button>();
                }
                this.Buttons.Add(button);
                return true;
            }

            public bool AddButton(XElement element)
            {
                Button button = new Button(this.Mod);
                if (button.SetXML(element))
                {
                    return AddButton(button);
                }
                return false;
            }

            public List<InjectInto> GetInjectIntos()
            {
                return this.InjectIntos;
            }

            public List<AddField> GetAddFields()
            {
                return this.AddFields;
            }

            public List<AddMethod> GetAddMethods()
            {
                return this.AddMethods;
            }

            public List<AddClass> GetAddClasses()
            {
                return this.AddClasses;
            }

            public List<Button> GetButtons()
            {
                return this.Buttons;
            }

            public void RemoveInjectInto(InjectInto obj)
            {
                this.InjectIntos.Remove(obj);
            }

            public void RemoveAddField(AddField obj)
            {
                this.AddFields.Remove(obj);
            }

            public void RemoveAddClass(AddClass obj)
            {
                this.AddClasses.Remove(obj);
            }

            public void RemoveAddMethod(AddMethod obj)
            {
                this.AddMethods.Remove(obj);
            }

            public bool AddInjectInto(InjectInto obj)
            {
                if (this.InjectIntos == null)
                    this.InjectIntos = new List<InjectInto>();
                this.InjectIntos.Add(obj);
                return true;
            }

            public bool AddInjectInto(XElement element)
            {
                InjectInto obj = new InjectInto(this.Mod);
                obj.SetXML(element);
                return AddInjectInto(obj);
            }

            public bool AddAddClass(AddClass obj)
            {
                if (this.AddClasses == null)
                    this.AddClasses = new List<AddClass>();
                this.AddClasses.Add(obj);
                return true;
            }

            public bool AddAddClass(XElement element)
            {
                AddClass obj = new AddClass(this.Mod);
                obj.SetXML(element);
                return AddAddClass(obj);
            }

            public bool AddAddField(AddField obj)
            {
                if (this.AddFields == null)
                    this.AddFields = new List<AddField>();
                this.AddFields.Add(obj);
                return true;
            }

            public bool AddAddField(XElement element)
            {
                AddField obj = new AddField(this.Mod);
                obj.SetXML(element);
                return AddAddField(obj);
            }

            public bool AddAddMethod(AddMethod obj)
            {
                if (this.AddMethods == null)
                    this.AddMethods = new List<AddMethod>();
                this.AddMethods.Add(obj);
                return true;
            }

            public bool AddAddMethod(XElement element)
            {
                AddMethod obj = new AddMethod(this.Mod);
                obj.SetXML(element);
                return AddAddMethod(obj);
            }

            public XDocument GetXML()
            {
                XDocument document = new XDocument();
                XElement rootElement = new XElement("Mod");
                rootElement.SetAttributeValue("ID", this.ID);
                rootElement.Add(new XElement("Compatible", this.Compatible));
                rootElement.Add(new XElement("Version", this.Version));
                
                XElement nameElement = this.Name.GetXML();
                nameElement.Name = "Name";
                rootElement.Add(nameElement);

                XElement descriptionElement = this.Description.GetXML();
                descriptionElement.Name = "Description";
                rootElement.Add(descriptionElement);

                foreach (Button button in Buttons)
                    rootElement.Add(button.GetXML());
                foreach (InjectInto injectInto in InjectIntos)
                    rootElement.Add(injectInto.GetXML());
                foreach (AddField addField in AddFields)
                    rootElement.Add(addField.GetXML());
                foreach (AddMethod addMethod in AddMethods)
                    rootElement.Add(addMethod.GetXML());
                foreach (AddClass addClass in AddClasses)
                    rootElement.Add(addClass.GetXML());

                document.Add(rootElement);
                return document;
            }

            public void SetXML(XDocument configuration)
            {
                if (!SetID(configuration.Root.Attribute("ID")))
                    return;
                if (!SetVersion(configuration.Root.Element("Version")))
                    return;
                if (!SetName(configuration.Root.Element("Name")))
                    return;
                if (!SetDescription(configuration.Root.Element("Description")))
                    return;
                SetCompatible(configuration.Root.Element("Compatible"));
                this.Buttons = new List<Button>();
                foreach (XElement buttonElement in configuration.Root.Elements("Button"))
                {
                    AddButton(buttonElement);        
                }

                this.InjectIntos = new List<InjectInto>();
                this.AddFields = new List<AddField>();
                this.AddMethods = new List<AddMethod>();
                this.AddClasses = new List<AddClass>();

                foreach (XElement subElement in configuration.Root.Elements("InjectInto"))
                {
                    AddInjectInto(subElement);
                }
                foreach (XElement subElement in configuration.Root.Elements("AddField"))
                {
                    AddAddField(subElement);
                }
                foreach (XElement subElement in configuration.Root.Elements("AddMethod"))
                {
                    AddAddMethod(subElement);
                }
                foreach (XElement subElement in configuration.Root.Elements("AddClass"))
                {
                    AddAddClass(subElement);
                }
                Verify();
            }

            public void Verify()
            {
                Valid = true;
                if (this.ID == "")
                    Valid = false;
                if (this.Version == "")
                    Valid = false;
                if (this.Name == null)
                    Valid = false;
                if (this.Description == null)
                    Valid = false;
                List<string> buttonIDs = new List<string>();
                foreach (Button b in this.Buttons)
                {
                    if (buttonIDs.Contains(b.ID))
                    {
                        Valid = false;
                    }
                    buttonIDs.Add(b.ID);
                }

                foreach (InjectInto i in InjectIntos)
                {
                    i.Verify();
                    if (!i.Valid)
                        Valid = false;
                }
                foreach (AddField i in AddFields)
                {
                    i.Verify();
                    if (!i.Valid)
                        Valid = false;
                }
                foreach (AddMethod i in AddMethods)
                {
                    i.Verify();
                    if (!i.Valid)
                        Valid = false;
                }
                foreach (AddClass i in AddClasses)
                {
                    i.Verify();
                    if (!i.Valid)
                        Valid = false;
                }
            }

            public Header(Mod mod, string header)
            {
                this.Mod = mod;
                try 
                {
                    XDocument configuration = XDocument.Parse(header);
                    SetXML(configuration);
                    Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Successfully parsed mod header of mod \"" + this.ID + "\".");
                } 
                catch (Exception e) 
                {
                    Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Error while parsing header of mod \"" + this.ID + "\". Filename: \"" + this.Mod.FileName + "\"", Debug.Type.WARNING);
                    this.Valid = false;
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
                    List<byte> hashBytes = new List<byte>();
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(ID));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(StandardKey));
                    hashBytes.AddRange(Name.GetHashBytes());
                    hashBytes.AddRange(Description.GetHashBytes());
                    return hashBytes.ToArray();
                }

                public Button(Mod mod)
                {
                    this.Mod = mod;
                }

                public bool SetXML(XElement element)
                {
                    ID = Utils.XMLHelper.GetXMLAttributeAsString(element, "ID", "");
                    if (ID == "")
                    {
                        Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Invalid mod configuration for ID \"" + this.Mod.ID + "\": A button is missing an ID.", Debug.Type.WARNING);
                        return false;
                    }
                    StandardKey = Utils.XMLHelper.GetXMLAttributeAsString(element, "Standard", "");
                    if (element.Element("Name") == null)
                    {
                        Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Invalid mod configuration for ID \"" + this.Mod.ID + "\": The button \"" + this.ID + "\" has no name.", Debug.Type.WARNING);
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
                    XElement ret = new XElement("Button");
                    ret.SetAttributeValue("ID", this.ID);
                    if (this.StandardKey != "")
                    {
                        ret.SetAttributeValue("Standard", this.StandardKey);
                        /*XElement standard = new XElement("StandardKey");
                        standard.Value = this.StandardKey;
                        ret.Add(standard);*/
                    }
                    if (this.Name != null)
                    {
                        XElement name = this.Name.GetXML();
                        name.Name = "Name";
                        ret.Add(name);
                    }
                    if (this.Description != null)
                    {
                        XElement desc = this.Description.GetXML();
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
                public bool Valid = false;
                protected MethodDefinition _Method;

                public byte[] GetHashBytes()
                {
                    List<byte> hashBytes = new List<byte>();
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(AssemblyName));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(TypeName));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(ReturnType));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(Path));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(MethodName));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(CheckSum));
                    return hashBytes.ToArray();
                }

                public AddMethod(Mod mod)
                {
                    this.Mod = mod;
                }

                public MethodDefinition Method 
                {
                    get
                    {
                        return _Method;
                    }
                    set
                    {
                        _Method = value;
                        UpdateValues();
                    }
                }
                

                public void SetXML(XElement element)
                {
                    AssemblyName = Utils.XMLHelper.GetXMLAttributeAsString(element, "AssemblyName", "");
                    MethodName = Utils.XMLHelper.GetXMLAttributeAsString(element, "MethodName", "");
                    TypeName = Utils.XMLHelper.GetXMLAttributeAsString(element, "TypeName", "");
                    ReturnType = Utils.XMLHelper.GetXMLAttributeAsString(element, "ReturnType", "");
                    Path = Utils.XMLHelper.GetXMLAttributeAsString(element, "Path", "");
                    CheckSum = Utils.XMLHelper.GetXMLAttributeAsString(element, "CheckSum", "");
                    Verify();
                }

                public XElement GetXML()
                {
                    UpdateValues();
                    XElement ret = new XElement("AddMethod");
                    ret.SetAttributeValue("AssemblyName", this.AssemblyName);
                    ret.SetAttributeValue("TypeName", this.TypeName);
                    ret.SetAttributeValue("MethodName", this.MethodName);
                    ret.SetAttributeValue("ReturnType", this.ReturnType);
                    ret.SetAttributeValue("Path", this.Path);
                    ret.SetAttributeValue("CheckSum", this.CheckSum);
                    return ret;
                }

                public void Verify()
                {
                    Valid = true;
                    if (this._Method != null)
                    {
                        string NewCheckSum = BitConverter.ToString(ModAPI.Utils.Checksum.CreateChecksum(this._Method)).ToLower().Replace("-", "");
                        if (this.CheckSum != NewCheckSum)
                        {
                            Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Mismatched checksum at \"" + this.Mod.ID + ".AddMethods." + this.Path + "\".");
                            Valid = false;
                        }
                    }
                }

                public void UpdateValues()
                {
                    if (_Method != null)
                    {
                        this.ReturnType = _Method.ReturnType.FullName;
                        this.TypeName = _Method.DeclaringType.BaseType.FullName;
                        this.MethodName = _Method.Name;
                        this.Path = _Method.FullName;

                        /** @TODO: Replace this basic checksum creation with something better **/
                        string NewCheckSum = BitConverter.ToString(ModAPI.Utils.Checksum.CreateChecksum(this._Method)).ToLower().Replace("-", "");
                        if (this.CheckSum == "")
                        {
                            this.CheckSum = NewCheckSum;
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
                public bool Valid = false;

                public byte[] GetHashBytes()
                {
                    List<byte> hashBytes = new List<byte>();
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(AssemblyName));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(TypeName));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(FieldType));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(FieldName));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(Path));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(CheckSum));
                    return hashBytes.ToArray();
                }

                public AddField(Mod mod)
                {
                    this.Mod = mod;
                }

                public FieldDefinition Field 
                {
                    get
                    {
                        return _Field;
                    }
                    set
                    {
                        _Field = value;
                        UpdateValues();
                    }
                }

                public void SetXML(XElement element)
                {
                    AssemblyName = Utils.XMLHelper.GetXMLAttributeAsString(element, "AssemblyName", "");
                    TypeName = Utils.XMLHelper.GetXMLAttributeAsString(element, "TypeName", "");
                    FieldType = Utils.XMLHelper.GetXMLAttributeAsString(element, "FieldType", "");
                    FieldName = Utils.XMLHelper.GetXMLAttributeAsString(element, "FieldName", "");
                    Path = Utils.XMLHelper.GetXMLAttributeAsString(element, "Path", "");
                    CheckSum = Utils.XMLHelper.GetXMLAttributeAsString(element, "CheckSum", "");
                    Verify();
                }

                public void Verify()
                {
                    Valid = true;
                    if (this._Field != null)
                    {
                        string NewCheckSum = BitConverter.ToString(ModAPI.Utils.Checksum.CreateChecksum(this._Field)).ToLower().Replace("-", "");
                        if (this.CheckSum != NewCheckSum)
                        {
                            Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Mismatched checksum at \"" + this.Mod.ID + ".AddFields." + this.Path + "\".");
                            Valid = false;
                        }
                    }
                }

                public XElement GetXML()
                {
                    UpdateValues();
                    XElement ret = new XElement("AddField");
                    ret.SetAttributeValue("AssemblyName", this.AssemblyName);
                    ret.SetAttributeValue("TypeName", this.TypeName);
                    ret.SetAttributeValue("FieldType", this.FieldType);
                    ret.SetAttributeValue("FieldName", this.FieldName);
                    ret.SetAttributeValue("Path", this.Path);
                    ret.SetAttributeValue("CheckSum", this.CheckSum);
                    return ret;
                }

                public void UpdateValues()
                {
                    if (_Field != null)
                    {
                        this.FieldType = _Field.FieldType.FullName;
                        this.FieldName = _Field.Name;
                        this.TypeName = _Field.DeclaringType.BaseType.FullName;
                        this.Path = _Field.FullName;

                        /** @TODO: Replace this basic checksum creation with something better **/
                        string NewCheckSum = BitConverter.ToString(ModAPI.Utils.Checksum.CreateChecksum(this._Field)).ToLower().Replace("-", "");
                        if (this.CheckSum == "")
                        {
                            this.CheckSum = NewCheckSum;
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
                public bool Valid = false;

                protected MethodDefinition _Method;


                public byte[] GetHashBytes()
                {
                    List<byte> hashBytes = new List<byte>();
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(AssemblyName));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(TypeName));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(MethodName));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(Path));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(CheckSum));
                    hashBytes.AddRange(System.BitConverter.GetBytes(Priority));
                    return hashBytes.ToArray();
                }

                public InjectInto(Mod mod)
                {
                    this.Mod = mod;
                }

                public MethodDefinition Method
                {
                    get
                    {
                        return _Method;
                    }
                    set
                    {
                        _Method = value;
                        UpdateValues();
                    }
                }

                public void SetXML(XElement element)
                {
                    AssemblyName = Utils.XMLHelper.GetXMLAttributeAsString(element, "AssemblyName", "");
                    TypeName = Utils.XMLHelper.GetXMLAttributeAsString(element, "TypeName", "");
                    MethodName = Utils.XMLHelper.GetXMLAttributeAsString(element, "MethodName", "");
                    Path = Utils.XMLHelper.GetXMLAttributeAsString(element, "Path", "");
                    Priority = Utils.XMLHelper.GetXMLAttributeAsInt(element, "Priority", 0);
                    CheckSum = Utils.XMLHelper.GetXMLAttributeAsString(element, "CheckSum", "");
                    Verify();
                }

                public XElement GetXML()
                {
                    UpdateValues();
                    XElement ret = new XElement("InjectInto");
                    ret.SetAttributeValue("AssemblyName", this.AssemblyName);
                    ret.SetAttributeValue("TypeName", this.TypeName);
                    ret.SetAttributeValue("MethodName", this.MethodName);
                    ret.SetAttributeValue("Path", this.Path);
                    ret.SetAttributeValue("Priority", this.Priority);
                    ret.SetAttributeValue("CheckSum", this.CheckSum);
                    return ret;
                }

                public void Verify()
                {
                    Valid = true;
                    if (this._Method != null)
                    {
                        string NewCheckSum = BitConverter.ToString(ModAPI.Utils.Checksum.CreateChecksum(this._Method)).ToLower().Replace("-", "");
                        if (this.CheckSum != NewCheckSum)
                        {
                            Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Mismatched checksum at \"" + this.Mod.ID + ".InjectIntos." + this.Path + "\".");
                            Valid = false;
                        }
                    }
                }

                public void UpdateValues()
                {
                    if (_Method != null)
                    {
                        this.MethodName = _Method.Name;
                        this.TypeName = _Method.DeclaringType.BaseType.FullName;
                        this.Path = _Method.FullName;
                        this.Priority = 0;
                        foreach (CustomAttribute ca in _Method.CustomAttributes)
                        {
                            if (ca.AttributeType.FullName == "ModAPI.Priority")
                            {
                                this.Priority = (int)ca.ConstructorArguments[0].Value;
                            }
                        }

                        /** @TODO: Replace this basic checksum creation with something better **/
                        string NewCheckSum = BitConverter.ToString(ModAPI.Utils.Checksum.CreateChecksum(this._Method)).ToLower().Replace("-", "");
                        if (this.CheckSum == "")
                        {
                            this.CheckSum = NewCheckSum;
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
                public bool Valid = false;

                protected TypeDefinition _Type;

                public byte[] GetHashBytes()
                {
                    List<byte> hashBytes = new List<byte>();
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(TypeName));
                    hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(CheckSum));
                    return hashBytes.ToArray();
                }

                public AddClass(Mod mod)
                {
                    this.Mod = mod;
                }

                public TypeDefinition Type
                {
                    get
                    {
                        return _Type;
                    }
                    set
                    {
                        _Type = value;
                        UpdateValues();
                    }
                }

                public void SetXML(XElement element)
                {
                    TypeName = Utils.XMLHelper.GetXMLAttributeAsString(element, "TypeName", "");
                    CheckSum = Utils.XMLHelper.GetXMLAttributeAsString(element, "CheckSum", "");
                    Verify();
                }

                public void Verify()
                {
                    Valid = true;
                    if (this._Type != null)
                    {
                        string NewCheckSum = BitConverter.ToString(ModAPI.Utils.Checksum.CreateChecksum(this._Type)).ToLower().Replace("-", "");
                        if (this.CheckSum != NewCheckSum)
                        {
                            Debug.Log("Game: " + this.Mod.Game.GameConfiguration.ID, "Mismatched checksum at \"" + this.Mod.ID + ".AddClasses." + this.TypeName + "\".");
                            Valid = false;
                        }
                    }
                }

                public XElement GetXML()
                {
                    UpdateValues();
                    XElement ret = new XElement("AddClass");
                    ret.SetAttributeValue("TypeName", this.TypeName);
                    ret.SetAttributeValue("CheckSum", this.CheckSum);
                    return ret;
                }

                public void UpdateValues()
                {
                    if (_Type != null)
                    {
                        this.TypeName = _Type.FullName;
                        /** @TODO: Replace this basic checksum creation with something better **/
                        string NewCheckSum = BitConverter.ToString(ModAPI.Utils.Checksum.CreateChecksum(this._Type)).ToLower().Replace("-","");
                        if (this.CheckSum == "") 
                        {
                            this.CheckSum = NewCheckSum;
                        }
                        Verify();
                    }
                }
            }
        }
    }
}
