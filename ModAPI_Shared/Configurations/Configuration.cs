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
using System.IO;
using System.Xml.Linq;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace ModAPI.Configurations
{
    public class Configuration
    {
        public static string ConfigurationFile = "resources" + Path.DirectorySeparatorChar + "Configuration.xml";
        public enum ResultCode { OK, ERROR };
        public enum ErrorCode { CONFIGURATION_NOT_FOUND, MALFORMED_CONFIGURATION };
        
        public static string ErrorString = "";
        public static ErrorCode Error;
        public static string RootPath = "";
        public delegate void LanguageChanged();
        public static LanguageChanged OnLanguageChanged;
        public static Dictionary<string, Language> Languages = new Dictionary<string, Language>();
        public static Dictionary<string, GameConfiguration> Games = new Dictionary<string, GameConfiguration>();
        public static string CurrentGame = "";
        public static Language CurrentLanguage;

        protected static Dictionary<string, string> paths = new Dictionary<string, string>();
        protected static Dictionary<string, string> userPaths = new Dictionary<string, string>();
        protected static ProgressHandler progressHandler;
        protected static Dictionary<string, ConfigData> configData = new Dictionary<string, ConfigData>();
        protected static Dictionary<string, ConfigData> userConfigData = new Dictionary<string, ConfigData>();
        
        static void ChangeProgress(float progress)
        {
            if (progressHandler != null)
                progressHandler.Progress = progress;
        }

        public static string GetString(string key)
        {
            key = key.ToLower();
            if (userConfigData.ContainsKey(key))
            {
                return userConfigData[key].StringValue;
            } 
            if (configData.ContainsKey(key))
            {
                return configData[key].StringValue;
            }
            Debug.Log("Configuration", "Configuration key \"" + key + "\" does not exist..");
            return "";
        }

        public static int GetInt(string key)
        {
            key = key.ToLower();
            if (userConfigData.ContainsKey(key))
            {
                return userConfigData[key].IntValue;
            }
            if (configData.ContainsKey(key))
            {
                return configData[key].IntValue;
            }
            Debug.Log("Configuration", "Configuration key \"" + key + "\" does not exist..");
            return 0;
        }

        public static void SetString(string key, string value, bool userConfig = false)
        {
            key = key.ToLower();
            if (userConfig)
            {
                if (userConfigData.ContainsKey(key))
                {
                    userConfigData[key].StringValue = value;
                }
                else
                {
                    ConfigData dat = new ConfigData();
                    dat.StringValue = value;
                    userConfigData.Add(key, dat);
                }
            }
            else
            {
                if (configData.ContainsKey(key))
                {
                    configData[key].StringValue = value;
                }
                else
                {
                    ConfigData dat = new ConfigData();
                    dat.StringValue = value;
                    configData.Add(key, dat);
                }
            }
        }

        public static void SetInt(string key, int value, bool userConfig = false)
        {
            key = key.ToLower();
            if (userConfig)
            {
                if (userConfigData.ContainsKey(key))
                {
                    userConfigData[key].IntValue = value;
                }
                else
                {
                    ConfigData dat = new ConfigData();
                    dat.IntValue = value;
                    userConfigData.Add(key, dat);
                }
            }
            else
            {
                if (configData.ContainsKey(key))
                {
                    configData[key].IntValue = value;
                }
                else
                {
                    ConfigData dat = new ConfigData();
                    dat.IntValue = value;
                    configData.Add(key, dat);
                }
            }
        }

        public static void Save()
        {
            XDocument newDocument = new XDocument();
            XElement rootElement = new XElement("UserConfiguration");
            newDocument.Add(rootElement);
            foreach (KeyValuePair<string, ConfigData> kv in userConfigData)
            {
                XElement element = rootElement;
                string[] parts = kv.Key.Split(new string[] { "." }, StringSplitOptions.None);
                for (int i = 0; i < parts.Length; i++)
                {
                    XElement child = element.Element(parts[i]);
                    if (child == null) {
                        child = new XElement(parts[i]);
                        element.Add(child);
                    }
                    element = child;
                }
                element.Value = kv.Value.StringValue;
            }

            XElement pathsElement = new XElement("Paths");
            foreach (KeyValuePair<string, string> kv in userPaths)
            {
                XElement element = pathsElement;
                string[] parts = kv.Key.Split(new string[] { "." }, StringSplitOptions.None);
                for (int i = 0; i < parts.Length; i++)
                {
                    XElement child = element.Element(parts[i]);
                    if (child == null)
                    {
                        child = new XElement(parts[i]);
                        element.Add(child);
                    }
                    element = child;
                }
                element.Value = kv.Value;
            }

            rootElement.Add(pathsElement);

            string configPath = GetPath("Configurations");
            string userConfigFile = Path.GetFullPath(configPath + Path.DirectorySeparatorChar + "UserConfiguration.xml");
            newDocument.Save(userConfigFile);
        }

        public static ResultCode Load(ProgressHandler progressHandler = null)
        {
            Configuration.progressHandler = progressHandler;
            
            string ConfigurationFileName = FindConfiguration(System.IO.Directory.GetCurrentDirectory());
            if (ConfigurationFileName != "" && File.Exists(ConfigurationFileName))
            {
                try
                {
                    XDocument configXML = XDocument.Load(ConfigurationFileName);
                    if (ParseGeneric(configXML) != ResultCode.OK)
                    {
                        Debug.Log("Configuration", "Failed parsing generic configuration file \"" + ConfigurationFileName + "\".", Debug.Type.ERROR);
                        return ResultCode.ERROR;
                    }

                    Debug.Log("Configuration", "Generic configuration file \"" + ConfigurationFileName + "\" parsed successfully.");
                    ChangeProgress(15f);

                    string gameConfigPath = GetPath("GameConfigurations");
                    if (gameConfigPath == "")
                    {
                        Error = ErrorCode.MALFORMED_CONFIGURATION;
                        ErrorString = "GameConfigurations Path is not set.";
                        Debug.Log("Configuration", ErrorString, Debug.Type.ERROR);
                        return ResultCode.ERROR;
                    }
                    if (GetString("Game") == "")
                    {
                        Error = ErrorCode.MALFORMED_CONFIGURATION;
                        ErrorString = "No game defined in configuration.";
                        Debug.Log("Configuration", ErrorString, Debug.Type.ERROR);
                        return ResultCode.ERROR;
                    }

                    string[] gameConfigFiles = Directory.GetFiles(gameConfigPath, "*.xml");
                    foreach (string gameConfigFile in gameConfigFiles)
                    {
                        try
                        {
                            XDocument gameConfig = XDocument.Load(gameConfigFile);
                            GameConfiguration gameConfiguration = new GameConfiguration(gameConfig);
                            Games.Add(gameConfiguration.ID, gameConfiguration);
                            Debug.Log("Configuration", "Game configuration file for \"" + gameConfiguration.ID + "\" parsed successfully.");
                    
                        }
                        catch (System.Xml.XmlException e)
                        {
                            Debug.Log("Configuration", "The file \"" + gameConfigFile + "\" could not be parsed. Exception: " + e.ToString(), Debug.Type.WARNING);
                        }
                        catch (Exception e)
                        {
                            Debug.Log("Configuration", "The file \"" + gameConfigFile + "\" could not be parsed. Unexpected exception: " + e.ToString(), Debug.Type.WARNING);
                        }
                    }
                    ChangeProgress(30f);

                    if (!Games.ContainsKey(GetString("Game")))
                    {
                        Error = ErrorCode.MALFORMED_CONFIGURATION;
                        ErrorString = "The game configuration for \"" + GetString("Game") + "\" couldn't be found.";
                        Debug.Log("Configuration", ErrorString, Debug.Type.ERROR);
                        return ResultCode.ERROR;
                    }

                    CurrentGame = GetString("Game");
                    Debug.Log("Configuration", "Selected the Game \"" + GetString("Game") + "\" successfully.");

                    string configPath = GetPath("Configurations");
                    if (configPath == "")
                    {
                        Debug.Log("Configuration", "Can't load the UserConfiguration.xml because the Configuration Path is missing.", Debug.Type.WARNING);
                    }
                    else
                    {
                        string userConfigFile = Path.GetFullPath(configPath + Path.DirectorySeparatorChar + "UserConfiguration.xml");
                        if (File.Exists(userConfigFile))
                        {
                            try
                            {
                                XDocument userConfigXML = XDocument.Load(userConfigFile);
                                if (ParseGeneric(userConfigXML, true) != ResultCode.OK)
                                    Debug.Log("Configuration", "Couldn't load the UserConfiguration.xml.", Debug.Type.WARNING);
                                else
                                    Debug.Log("Configuration", "Generic configuration file \"" + userConfigFile + "\" parsed successfully.");
                            }
                            catch (System.Xml.XmlException e)
                            {
                                Debug.Log("Configuration", "The file \"" + userConfigFile + "\" could not be parsed. Exception: " + e.ToString(), Debug.Type.WARNING);
                            }
                            catch (Exception e)
                            {
                                Debug.Log("Configuration", "The file \"" + userConfigFile + "\" could not be parsed. Unexpected exception: " + e.ToString(), Debug.Type.WARNING);
                            }
                        }
                        else
                        {
                            Debug.Log("Configuration", "Couldn't load the UserConfiguration.xml because it's missing.", Debug.Type.WARNING);
                        }
                    }
                    ChangeProgress(50f);

                    if (ParseLanguages() != ResultCode.OK)
                        return ResultCode.ERROR;
                    
                    ChangeProgress(100f);
                    return ResultCode.OK;
                }
                catch (System.Xml.XmlException ex)
                {
                    Error = ErrorCode.MALFORMED_CONFIGURATION;
                    ErrorString = "The file \"" + ConfigurationFile + "\" could not be parsed. Exception: "+ex.ToString();
                    Debug.Log("Configuration", ErrorString, Debug.Type.ERROR);
                    return ResultCode.ERROR;
                }
                catch (Exception ex)
                {
                    Error = ErrorCode.MALFORMED_CONFIGURATION;
                    ErrorString = "The file \"" + ConfigurationFile + "\" could not be parsed. Unexpected exception: " + ex.ToString();
                    Debug.Log("Configuration", ErrorString, Debug.Type.ERROR);
                    return ResultCode.ERROR;
                }
            }
            else
            {
                Error = ErrorCode.CONFIGURATION_NOT_FOUND;
                ErrorString = "Could not find \"" + ConfigurationFile + "\".";
                Debug.Log("Configuration", ErrorString, Debug.Type.ERROR);
                return ResultCode.ERROR;
            }
        }

        public static void ChangeLanguage(string langCode)
        {
            langCode = langCode.ToLower();
            if (Languages.ContainsKey(langCode))
            {
                CurrentLanguage = Languages[langCode];
                Debug.Log("Configuration", "Language changed to " + CurrentLanguage.Key);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Languages[langCode].Get("Locale"));
                if (OnLanguageChanged != null)
                    OnLanguageChanged();

            }
        }

        static ResultCode ParseGeneric(XDocument document, bool userConfig = false)
        {
            if (document.Root == null) return ResultCode.OK;
            XElement paths = document.Root.Element("Paths");
            if (paths != null)
            {
                foreach (XElement path in paths.Elements())
                {
                    ParsePath(path, userConfig);
                }
            }

            foreach (XElement element in document.Root.Elements())
            {
                if (element.Name.LocalName.ToLower() != "paths")
                {
                    if (!element.HasElements)
                        SetString(element.Name.LocalName, element.Value.Trim(), userConfig);
                    ParseSub(element, element.Name.LocalName + ".", userConfig);
                }
            }
            return ResultCode.OK;
        }

        static void ParseSub(XElement parent, string prefix, bool userConfig = false)
        {
            foreach (XElement element in parent.Elements())
            {
                if (!element.HasElements)
                    SetString(prefix + element.Name.LocalName, element.Value.Trim(), userConfig);
                ParseSub(element, prefix + element.Name.LocalName + ".", userConfig);
            }
        }

        static void ParsePath(XElement element, bool userConfig = false, string pre = "")
        {
            string pathName = pre + element.Name.LocalName.ToLower();
            if (element.HasElements)
            {
                foreach (XElement sub in element.Elements())
                {
                    ParsePath(sub, userConfig, pathName + ".");
                }
            } 
            else 
            {
                string path = element.Value.ToString();
                if (userConfig)
                {
                    if (!userPaths.ContainsKey(pathName))
                        userPaths.Add(pathName, path);
                    else
                        userPaths[pathName] = path;
                }
                else
                {
                    if (!paths.ContainsKey(pathName))
                        paths.Add(pathName, path);
                    else
                        paths[pathName] = path;
                }

                if (!userConfig)
                    Directory.CreateDirectory(RootPath + Path.DirectorySeparatorChar + path);
            }
        }

        static ResultCode ParseLanguages()
        {
            string languagePath = GetPath("Languages");

            if (languagePath != "" && Directory.Exists(languagePath))
            {
                string[] langFiles = Directory.GetFiles(languagePath, "*.xaml");
                float count = langFiles.Length;
                float done = 0f;

                foreach (string langFile in langFiles)
                {
                    string imageFile = Path.GetFullPath(languagePath + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(langFile) + ".png");
                    try
                    {
                        FileStream fs = new FileStream(langFile, FileMode.Open);
                        ResourceDictionary dlc = (ResourceDictionary)XamlReader.Load(fs);

                        Language language = new Language(dlc, imageFile);
                        if (language.Key == "")
                        {
                            Debug.Log("Configuration", "The language file \"" + langFile + "\" could not be parsed. The LangCode Key is missing.", Debug.Type.WARNING);
                        }
                        else
                        {
                            string langKey = language.Key.ToLower();
                            if (!Languages.ContainsKey(langKey))
                            {
                                Languages.Add(langKey, language);
                                Debug.Log("Configuration", "Loaded language \"" + language.Key + "\" successfully.");
                            }
                            else
                            {
                                Debug.Log("Configuration", "The language \"" + language.Key + "\" exists more than once.", Debug.Type.WARNING);
                            }
                        }
                    }
                    catch (System.Xaml.XamlException e)
                    {
                        Debug.Log("Configuration", "The language file \"" + langFile + "\" could not be parsed. Exception: " + e.ToString(), Debug.Type.WARNING);
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Configuration", "The language file \"" + langFile + "\" could not be parsed. Unexpected exception: " + e.ToString(), Debug.Type.WARNING);
                    }
                    done += 1f;
                    ChangeProgress(50f + (done / count) * 40f);
                }
            }
            else
            {
                Error = ErrorCode.MALFORMED_CONFIGURATION;
                ErrorString = "Could not find the languages path.";
                Debug.Log("Configuration", ErrorString, Debug.Type.ERROR);
                return ResultCode.ERROR;
            }

            Debug.Log("Configuration", Languages.Count + " languages parsed successfully.");
            CultureInfo ci = CultureInfo.InstalledUICulture;
            string systemLangKey = ci.TwoLetterISOLanguageName.ToLower();
            if (GetString("Language") != "" && Languages.ContainsKey(GetString("Language")))
                ChangeLanguage(GetString("Language"));
            else if (Languages.ContainsKey(systemLangKey))
                ChangeLanguage(systemLangKey);
            else if (Languages.ContainsKey("en"))
                ChangeLanguage("en");
            else if (Languages.Count > 0)
                ChangeLanguage(Languages.Keys.ToArray()[0]);
            else
                Debug.Log("Configuration", "No suitable language found.", Debug.Type.WARNING);

            return ResultCode.OK;
        }

        public static void SetPath(string name, string path, bool userConfig = false)
        {
            string key = name.ToLower();
            if (userConfig)
            {
                if (userPaths.ContainsKey(key))
                {
                    userPaths[key] = path;
                }
                else
                {
                    userPaths.Add(key, path);
                }
            }
            else
            {
                if (paths.ContainsKey(key))
                {
                    paths[key] = path;
                }
                else
                {
                    paths.Add(key, path);
                }
            }
        }

        public static string GetPath(string name)
        {
            string key = name.ToLower();
            if (userPaths.ContainsKey(key))
            {
                if (Path.IsPathRooted(userPaths[key]))
                    return userPaths[key];
                else
                    return Path.GetFullPath(RootPath + Path.DirectorySeparatorChar + userPaths[key]);
            }

            if (paths.ContainsKey(key))
            {
                if (Path.IsPathRooted(paths[key]))
                    return paths[key];
                else
                    return Path.GetFullPath(RootPath + Path.DirectorySeparatorChar + paths[key]);
            }

            StackTrace stackTrace = new StackTrace();
            MethodBase method = stackTrace.GetFrame(1).GetMethod();
            Debug.Log("Configuration", "Path \"" + name + "\" is not present. (called by: " + method.DeclaringType.FullName + "::"+ method.Name + ")", Debug.Type.WARNING);
            return "";
        }

        static string FindConfiguration(string path)
        {
            path = Path.GetFullPath(path);
            if (System.IO.File.Exists(path + Path.DirectorySeparatorChar + ConfigurationFile))
            {
                RootPath = path;
                paths.Add("root", path);
                return path + Path.DirectorySeparatorChar + ConfigurationFile;
            }
            else
            {
                try
                {
                    string newPath = Directory.GetParent(path).FullName;
                    if (newPath != path)
                    {
                        return FindConfiguration(newPath);
                    }
                    else
                    {
                        Debug.Log("Configuration", "Couldn't find configuration.");
                        return "";
                    }
                }
                catch (Exception ex)
                {
                    Debug.Log("Configuration", "Unexpected exception while searching for configuration: " + ex.ToString());
                    return "";
                }
            }
        }

        public class ConfigData
        {
            public string StringValue = "";
            public int IntValue
            {
                get
                {
                    int ret = 0;
                    try 
                    {
                        ret = int.Parse(StringValue);
                    }
                    catch (Exception e)
                    {

                    }
                    return ret;
                }
                set
                {
                    StringValue = value + "";
                }
            }
        }

        public class Language
        {
            public MemoryStream ImageStream;
            public string Key;
            public ResourceDictionary Resource;

            public string Get(string key)
            {
                if (this.Resource.Contains(key))
                {
                    return this.Resource[key] as String;
                }
                return "";
            }

            public Language(ResourceDictionary resource, string imageFile)
            {
                this.Resource = resource;

                Key = Get("LangCode");
                if (Key != "")
                {
                    if (File.Exists(imageFile))
                    {
                        try
                        {
                            ImageStream = new MemoryStream();
                            FileStream stream = new FileStream(imageFile, FileMode.Open);
                            ImageStream.SetLength(stream.Length);
                            stream.Read(ImageStream.GetBuffer(), 0, (int)stream.Length);
                            ImageStream.Flush();
                            stream.Close();
                            Debug.Log("Language", "Image file \"" + imageFile + "\" loaded for language \"" + Key + "\".");
                        }
                        catch (Exception e)
                        {
                            Debug.Log("Language", "Could not read image file \"" + imageFile + "\" for language \"" + Key + "\".", Debug.Type.WARNING);
                        }
                    }
                    else
                    {
                        Debug.Log("Language", "No image defined for language \"" + Get("langcode") + "\".", Debug.Type.WARNING);
                    }
                }
            }
        }

        
        public class GameConfiguration
        {
            public string ID;
            public string SteamAppID;
            public bool Selectable = true;
            protected string _AssemblyPath = "";

            public GameConfiguration Extended
            {
                get
                {
                    if (_Extends != "" && Configuration.Games.ContainsKey(_Extends))
                    {
                        return Configuration.Games[_Extends];
                    }
                    return null;
                }
            }
            public string SelectFile
            {
                get
                {
                    if (Extended != null && _SelectFile == "")
                        return Extended.SelectFile;
                    return _SelectFile;
                }
            }
            public string Name
            {
                get
                {
                    return _Name;
                }
            }

            public string AssemblyPath
            {
                get
                {
                    string ret = _AssemblyPath.Trim();
                    if (ret == "" && Extended != null)
                    {
                        ret = Extended.AssemblyPath;
                    }
                    return ret;
                }
            }


            public List<string> IncludeAssemblies
            {
                get
                {
                    List<string> ret = new List<string>();
                    if (Extended != null)
                    {
                        List<string> _include = Extended.IncludeAssemblies;
                        for (int i = 0; i < _include.Count; i++)
                            ret.Add(_include[i]);
                    }
                    for (int i = 0; i < _IncludeAssemblies.Count; i++)
                        ret.Add(_IncludeAssemblies[i]);
                    return ret;
                }
            }

            public List<string> SearchPaths
            {
                get
                {
                    List<string> ret = new List<string>();
                    if (Extended != null)
                    {
                        List<string> _include = Extended.SearchPaths;
                        for (int i = 0; i < _include.Count; i++)
                            ret.Add(_include[i]);
                    }
                    for (int i = 0; i < _SearchPaths.Count; i++)
                        ret.Add(_SearchPaths[i]);
                    return ret;
                }
            }

            public List<string> CopyAssemblies
            {
                get
                {
                    List<string> ret = new List<string>();
                    if (Extended != null)
                    {
                        List<string> _include = Extended.CopyAssemblies;
                        for (int i = 0; i < _include.Count; i++)
                            ret.Add(_include[i]);
                    }
                    for (int i = 0; i < _CopyAssemblies.Count; i++)
                        ret.Add(_CopyAssemblies[i]);
                    return ret;
                }
            }

            public List<string> ExcludeNamespaces
            {
                get
                {
                    List<string> ret = new List<string>();
                    if (Extended != null)
                    {
                        List<string> _exclude = Extended.ExcludeNamespaces;
                        for (int i = 0; i < _exclude.Count; i++)
                            ret.Add(_exclude[i]);
                    }
                    for (int i = 0; i < _ExcludeNamespaces.Count; i++)
                        ret.Add(_ExcludeNamespaces[i]);
                    return ret;
                }
            }

            public List<string> ExcludeTypes
            {
                get
                {
                    List<string> ret = new List<string>();
                    if (Extended != null)
                    {
                        List<string> _exclude = Extended.ExcludeTypes;
                        for (int i = 0; i < _exclude.Count; i++)
                            ret.Add(_exclude[i]);
                    }
                    for (int i = 0; i < _ExcludeTypes.Count; i++)
                        ret.Add(_ExcludeTypes[i]);
                    return ret;
                }
            }

            public List<string> NoFamily
            {
                get
                {
                    List<string> ret = new List<string>();
                    if (Extended != null)
                    {
                        List<string> _exclude = Extended.NoFamily;
                        for (int i = 0; i < _exclude.Count; i++)
                            ret.Add(_exclude[i]);
                    }
                    for (int i = 0; i < _NoFamily.Count; i++)
                        ret.Add(_NoFamily[i]);
                    return ret;
                }
            }

            protected string _SelectFile = "";
            protected string _Name = "";
            protected string _Extends = "";
            protected List<string> _SearchPaths = new List<string>();
            protected List<string> _IncludeAssemblies = new List<string>();
            protected List<string> _CopyAssemblies = new List<string>();
            protected List<string> _ExcludeNamespaces = new List<string>();
            protected List<string> _ExcludeTypes = new List<string>();
            protected List<string> _NoFamily = new List<string>();

            public GameConfiguration(XDocument document)
            {
                XAttribute id = document.Root.Attribute("id");
                ID = id.Value;

                SteamAppID = Utils.XMLHelper.GetXMLElementAsString(document.Root, "steamAppID", "");
                XAttribute extends = document.Root.Attribute("extends");
                if (extends != null) _Extends = extends.Value;
                XAttribute selectable = document.Root.Attribute("selectable");
                if (selectable != null && selectable.Value == "false") Selectable = false;
                
                XElement selectFile = document.Root.Element("selectFile");
                if (selectFile != null) _SelectFile = selectFile.Value;
                XElement name = document.Root.Element("name");
                if (name != null) _Name = name.Value;

                XElement assPath = document.Root.Element("assemblyPath");
                if (assPath != null)
                    _AssemblyPath = assPath.Value.ToString();

                foreach (XElement el in document.Root.Elements("copyAssembly"))
                {
                    _CopyAssemblies.Add(el.Value);
                }
                foreach (XElement el in document.Root.Elements("searchPath"))
                {
                    _SearchPaths.Add(el.Value);
                } 
                foreach (XElement el in document.Root.Elements("includeAssembly"))
                {
                    _IncludeAssemblies.Add(el.Value);
                }
                foreach (XElement el in document.Root.Elements("excludeNamespace"))
                {
                    _ExcludeNamespaces.Add(el.Value);
                }
                foreach (XElement el in document.Root.Elements("excludeType"))
                {
                    _ExcludeTypes.Add(el.Value);
                }
                foreach (XElement el in document.Root.Elements("noFamily"))
                {
                    _NoFamily.Add(el.Value);
                }
            }
        }
    }
}
