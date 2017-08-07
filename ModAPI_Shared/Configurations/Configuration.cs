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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Xaml;
using System.Xml;
using System.Xml.Linq;
using ModAPI.Utils;
using Path = System.IO.Path;
using XamlReader = System.Windows.Markup.XamlReader;

namespace ModAPI.Configurations
{
    public class Configuration
    {
        public static string ConfigurationFile = "resources" + Path.DirectorySeparatorChar + "Configuration.xml";

        public enum ResultCode
        {
            OK,
            ERROR
        }

        public enum ErrorCode
        {
            CONFIGURATION_NOT_FOUND,
            MALFORMED_CONFIGURATION
        }

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
            {
                progressHandler.Progress = progress;
            }
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
                    var dat = new ConfigData();
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
                    var dat = new ConfigData();
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
                    var dat = new ConfigData();
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
                    var dat = new ConfigData();
                    dat.IntValue = value;
                    configData.Add(key, dat);
                }
            }
        }

        public static void Save()
        {
            var newDocument = new XDocument();
            var rootElement = new XElement("UserConfiguration");
            newDocument.Add(rootElement);
            foreach (var kv in userConfigData)
            {
                var element = rootElement;
                var parts = kv.Key.Split(new[] { "." }, StringSplitOptions.None);
                for (var i = 0; i < parts.Length; i++)
                {
                    var child = element.Element(parts[i]);
                    if (child == null)
                    {
                        child = new XElement(parts[i]);
                        element.Add(child);
                    }
                    element = child;
                }
                element.Value = kv.Value.StringValue;
            }

            var pathsElement = new XElement("Paths");
            foreach (var kv in userPaths)
            {
                var element = pathsElement;
                var parts = kv.Key.Split(new[] { "." }, StringSplitOptions.None);
                for (var i = 0; i < parts.Length; i++)
                {
                    var child = element.Element(parts[i]);
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

            var configPath = GetPath("Configurations");
            var userConfigFile = Path.GetFullPath(configPath + Path.DirectorySeparatorChar + "UserConfiguration.xml");
            newDocument.Save(userConfigFile);
        }

        public static ResultCode Load(ProgressHandler progressHandler = null)
        {
            Configuration.progressHandler = progressHandler;

            var ConfigurationFileName = FindConfiguration(Directory.GetCurrentDirectory());
            if (ConfigurationFileName != "" && File.Exists(ConfigurationFileName))
            {
                try
                {
                    var configXML = XDocument.Load(ConfigurationFileName);
                    if (ParseGeneric(configXML) != ResultCode.OK)
                    {
                        Debug.Log("Configuration", "Failed parsing generic configuration file \"" + ConfigurationFileName + "\".", Debug.Type.ERROR);
                        return ResultCode.ERROR;
                    }

                    Debug.Log("Configuration", "Generic configuration file \"" + ConfigurationFileName + "\" parsed successfully.");
                    ChangeProgress(15f);

                    var gameConfigPath = GetPath("GameConfigurations");
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

                    var gameConfigFiles = Directory.GetFiles(gameConfigPath, "*.xml");
                    foreach (var gameConfigFile in gameConfigFiles)
                    {
                        try
                        {
                            var gameConfig = XDocument.Load(gameConfigFile);
                            var gameConfiguration = new GameConfiguration(gameConfig);
                            Games.Add(gameConfiguration.ID, gameConfiguration);
                            Debug.Log("Configuration", "Game configuration file for \"" + gameConfiguration.ID + "\" parsed successfully.");
                        }
                        catch (XmlException e)
                        {
                            Debug.Log("Configuration", "The file \"" + gameConfigFile + "\" could not be parsed. Exception: " + e, Debug.Type.WARNING);
                        }
                        catch (Exception e)
                        {
                            Debug.Log("Configuration", "The file \"" + gameConfigFile + "\" could not be parsed. Unexpected exception: " + e, Debug.Type.WARNING);
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

                    var configPath = GetPath("Configurations");
                    if (configPath == "")
                    {
                        Debug.Log("Configuration", "Can't load the UserConfiguration.xml because the Configuration Path is missing.", Debug.Type.WARNING);
                    }
                    else
                    {
                        var userConfigFile = Path.GetFullPath(configPath + Path.DirectorySeparatorChar + "UserConfiguration.xml");
                        if (File.Exists(userConfigFile))
                        {
                            try
                            {
                                var userConfigXML = XDocument.Load(userConfigFile);
                                if (ParseGeneric(userConfigXML, true) != ResultCode.OK)
                                {
                                    Debug.Log("Configuration", "Couldn't load the UserConfiguration.xml.", Debug.Type.WARNING);
                                }
                                else
                                {
                                    Debug.Log("Configuration", "Generic configuration file \"" + userConfigFile + "\" parsed successfully.");
                                }
                            }
                            catch (XmlException e)
                            {
                                Debug.Log("Configuration", "The file \"" + userConfigFile + "\" could not be parsed. Exception: " + e, Debug.Type.WARNING);
                            }
                            catch (Exception e)
                            {
                                Debug.Log("Configuration", "The file \"" + userConfigFile + "\" could not be parsed. Unexpected exception: " + e, Debug.Type.WARNING);
                            }
                        }
                        else
                        {
                            Debug.Log("Configuration", "Couldn't load the UserConfiguration.xml because it's missing.", Debug.Type.WARNING);
                        }
                    }
                    ChangeProgress(50f);

                    if (ParseLanguages() != ResultCode.OK)
                    {
                        return ResultCode.ERROR;
                    }

                    ChangeProgress(100f);
                    return ResultCode.OK;
                }
                catch (XmlException ex)
                {
                    Error = ErrorCode.MALFORMED_CONFIGURATION;
                    ErrorString = "The file \"" + ConfigurationFile + "\" could not be parsed. Exception: " + ex;
                    Debug.Log("Configuration", ErrorString, Debug.Type.ERROR);
                    return ResultCode.ERROR;
                }
                catch (Exception ex)
                {
                    Error = ErrorCode.MALFORMED_CONFIGURATION;
                    ErrorString = "The file \"" + ConfigurationFile + "\" could not be parsed. Unexpected exception: " + ex;
                    Debug.Log("Configuration", ErrorString, Debug.Type.ERROR);
                    return ResultCode.ERROR;
                }
            }
            Error = ErrorCode.CONFIGURATION_NOT_FOUND;
            ErrorString = "Could not find \"" + ConfigurationFile + "\".";
            Debug.Log("Configuration", ErrorString, Debug.Type.ERROR);
            return ResultCode.ERROR;
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
                {
                    OnLanguageChanged();
                }
            }
        }

        static ResultCode ParseGeneric(XDocument document, bool userConfig = false)
        {
            if (document.Root == null)
            {
                return ResultCode.OK;
            }
            var paths = document.Root.Element("Paths");
            if (paths != null)
            {
                foreach (var path in paths.Elements())
                {
                    ParsePath(path, userConfig);
                }
            }

            foreach (var element in document.Root.Elements())
            {
                if (element.Name.LocalName.ToLower() != "paths")
                {
                    if (!element.HasElements)
                    {
                        SetString(element.Name.LocalName, element.Value.Trim(), userConfig);
                    }
                    ParseSub(element, element.Name.LocalName + ".", userConfig);
                }
            }
            return ResultCode.OK;
        }

        static void ParseSub(XElement parent, string prefix, bool userConfig = false)
        {
            foreach (var element in parent.Elements())
            {
                if (!element.HasElements)
                {
                    SetString(prefix + element.Name.LocalName, element.Value.Trim(), userConfig);
                }
                ParseSub(element, prefix + element.Name.LocalName + ".", userConfig);
            }
        }

        static void ParsePath(XElement element, bool userConfig = false, string pre = "")
        {
            var pathName = pre + element.Name.LocalName.ToLower();
            if (element.HasElements)
            {
                foreach (var sub in element.Elements())
                {
                    ParsePath(sub, userConfig, pathName + ".");
                }
            }
            else
            {
                var path = element.Value;
                if (userConfig)
                {
                    if (!userPaths.ContainsKey(pathName))
                    {
                        userPaths.Add(pathName, path);
                    }
                    else
                    {
                        userPaths[pathName] = path;
                    }
                }
                else
                {
                    if (!paths.ContainsKey(pathName))
                    {
                        paths.Add(pathName, path);
                    }
                    else
                    {
                        paths[pathName] = path;
                    }
                }

                if (!userConfig)
                {
                    Directory.CreateDirectory(RootPath + Path.DirectorySeparatorChar + path);
                }
            }
        }

        static ResultCode ParseLanguages()
        {
            var languagePath = GetPath("Languages");

            if (languagePath != "" && Directory.Exists(languagePath))
            {
                var langFiles = Directory.GetFiles(languagePath, "*.xaml");
                float count = langFiles.Length;
                var done = 0f;

                foreach (var langFile in langFiles)
                {
                    var imageFile = Path.GetFullPath(languagePath + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(langFile) + ".png");
                    try
                    {
                        var fs = new FileStream(langFile, FileMode.Open);
                        var dlc = (ResourceDictionary) XamlReader.Load(fs);

                        var language = new Language(dlc, imageFile);
                        if (language.Key == "")
                        {
                            Debug.Log("Configuration", "The language file \"" + langFile + "\" could not be parsed. The LangCode Key is missing.", Debug.Type.WARNING);
                        }
                        else
                        {
                            var langKey = language.Key.ToLower();
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
                    catch (XamlException e)
                    {
                        Debug.Log("Configuration", "The language file \"" + langFile + "\" could not be parsed. Exception: " + e, Debug.Type.WARNING);
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Configuration", "The language file \"" + langFile + "\" could not be parsed. Unexpected exception: " + e, Debug.Type.WARNING);
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
            var ci = CultureInfo.InstalledUICulture;
            var systemLangKey = ci.TwoLetterISOLanguageName.ToLower();
            if (GetString("Language") != "" && Languages.ContainsKey(GetString("Language")))
            {
                ChangeLanguage(GetString("Language"));
            }
            else if (Languages.ContainsKey(systemLangKey))
            {
                ChangeLanguage(systemLangKey);
            }
            else if (Languages.ContainsKey("en"))
            {
                ChangeLanguage("en");
            }
            else if (Languages.Count > 0)
            {
                ChangeLanguage(Languages.Keys.ToArray()[0]);
            }
            else
            {
                Debug.Log("Configuration", "No suitable language found.", Debug.Type.WARNING);
            }

            return ResultCode.OK;
        }

        public static void SetPath(string name, string path, bool userConfig = false)
        {
            var key = name.ToLower();
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
            var key = name.ToLower();
            if (userPaths.ContainsKey(key))
            {
                if (Path.IsPathRooted(userPaths[key]))
                {
                    return userPaths[key];
                }
                return Path.GetFullPath(RootPath + Path.DirectorySeparatorChar + userPaths[key]);
            }

            if (paths.ContainsKey(key))
            {
                if (Path.IsPathRooted(paths[key]))
                {
                    return paths[key];
                }
                return Path.GetFullPath(RootPath + Path.DirectorySeparatorChar + paths[key]);
            }

            var stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(1).GetMethod();
            Debug.Log("Configuration", "Path \"" + name + "\" is not present. (called by: " + method.DeclaringType.FullName + "::" + method.Name + ")", Debug.Type.WARNING);
            return "";
        }

        static string FindConfiguration(string path)
        {
            path = Path.GetFullPath(path);
            if (File.Exists(path + Path.DirectorySeparatorChar + ConfigurationFile))
            {
                RootPath = path;
                paths.Add("root", path);
                return path + Path.DirectorySeparatorChar + ConfigurationFile;
            }
            try
            {
                var newPath = Directory.GetParent(path).FullName;
                if (newPath != path)
                {
                    return FindConfiguration(newPath);
                }
                Debug.Log("Configuration", "Couldn't find configuration.");
                return "";
            }
            catch (Exception ex)
            {
                Debug.Log("Configuration", "Unexpected exception while searching for configuration: " + ex);
                return "";
            }
        }

        public class ConfigData
        {
            public string StringValue = "";
            public int IntValue
            {
                get
                {
                    var ret = 0;
                    try
                    {
                        ret = int.Parse(StringValue);
                    }
                    catch (Exception e)
                    {
                    }
                    return ret;
                }
                set { StringValue = value + ""; }
            }
        }

        public class Language
        {
            public MemoryStream ImageStream;
            public string Key;
            public ResourceDictionary Resource;

            public string Get(string key)
            {
                if (Resource.Contains(key))
                {
                    return Resource[key] as String;
                }
                return "";
            }

            public Language(ResourceDictionary resource, string imageFile)
            {
                Resource = resource;

                Key = Get("LangCode");
                if (Key != "")
                {
                    if (File.Exists(imageFile))
                    {
                        try
                        {
                            ImageStream = new MemoryStream();
                            var stream = new FileStream(imageFile, FileMode.Open);
                            ImageStream.SetLength(stream.Length);
                            stream.Read(ImageStream.GetBuffer(), 0, (int) stream.Length);
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
                    if (_Extends != "" && Games.ContainsKey(_Extends))
                    {
                        return Games[_Extends];
                    }
                    return null;
                }
            }
            public string SelectFile
            {
                get
                {
                    if (Extended != null && _SelectFile == "")
                    {
                        return Extended.SelectFile;
                    }
                    return _SelectFile;
                }
            }
            public string Name
            {
                get { return _Name; }
            }

            public string AssemblyPath
            {
                get
                {
                    var ret = _AssemblyPath.Trim();
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
                    var ret = new List<string>();
                    if (Extended != null)
                    {
                        var _include = Extended.IncludeAssemblies;
                        for (var i = 0; i < _include.Count; i++)
                        {
                            ret.Add(_include[i]);
                        }
                    }
                    for (var i = 0; i < _IncludeAssemblies.Count; i++)
                    {
                        ret.Add(_IncludeAssemblies[i]);
                    }
                    return ret;
                }
            }

            public List<string> SearchPaths
            {
                get
                {
                    var ret = new List<string>();
                    if (Extended != null)
                    {
                        var _include = Extended.SearchPaths;
                        for (var i = 0; i < _include.Count; i++)
                        {
                            ret.Add(_include[i]);
                        }
                    }
                    for (var i = 0; i < _SearchPaths.Count; i++)
                    {
                        ret.Add(_SearchPaths[i]);
                    }
                    return ret;
                }
            }

            public List<string> CopyAssemblies
            {
                get
                {
                    var ret = new List<string>();
                    if (Extended != null)
                    {
                        var _include = Extended.CopyAssemblies;
                        for (var i = 0; i < _include.Count; i++)
                        {
                            ret.Add(_include[i]);
                        }
                    }
                    for (var i = 0; i < _CopyAssemblies.Count; i++)
                    {
                        ret.Add(_CopyAssemblies[i]);
                    }
                    return ret;
                }
            }

            public List<string> ExcludeNamespaces
            {
                get
                {
                    var ret = new List<string>();
                    if (Extended != null)
                    {
                        var _exclude = Extended.ExcludeNamespaces;
                        for (var i = 0; i < _exclude.Count; i++)
                        {
                            ret.Add(_exclude[i]);
                        }
                    }
                    for (var i = 0; i < _ExcludeNamespaces.Count; i++)
                    {
                        ret.Add(_ExcludeNamespaces[i]);
                    }
                    return ret;
                }
            }

            public List<string> ExcludeTypes
            {
                get
                {
                    var ret = new List<string>();
                    if (Extended != null)
                    {
                        var _exclude = Extended.ExcludeTypes;
                        for (var i = 0; i < _exclude.Count; i++)
                        {
                            ret.Add(_exclude[i]);
                        }
                    }
                    for (var i = 0; i < _ExcludeTypes.Count; i++)
                    {
                        ret.Add(_ExcludeTypes[i]);
                    }
                    return ret;
                }
            }

            public List<string> NoFamily
            {
                get
                {
                    var ret = new List<string>();
                    if (Extended != null)
                    {
                        var _exclude = Extended.NoFamily;
                        for (var i = 0; i < _exclude.Count; i++)
                        {
                            ret.Add(_exclude[i]);
                        }
                    }
                    for (var i = 0; i < _NoFamily.Count; i++)
                    {
                        ret.Add(_NoFamily[i]);
                    }
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
                var id = document.Root.Attribute("id");
                ID = id.Value;

                SteamAppID = XMLHelper.GetXMLElementAsString(document.Root, "steamAppID", "");
                var extends = document.Root.Attribute("extends");
                if (extends != null)
                {
                    _Extends = extends.Value;
                }
                var selectable = document.Root.Attribute("selectable");
                if (selectable != null && selectable.Value == "false")
                {
                    Selectable = false;
                }

                var selectFile = document.Root.Element("selectFile");
                if (selectFile != null)
                {
                    _SelectFile = selectFile.Value;
                }
                var name = document.Root.Element("name");
                if (name != null)
                {
                    _Name = name.Value;
                }

                var assPath = document.Root.Element("assemblyPath");
                if (assPath != null)
                {
                    _AssemblyPath = assPath.Value;
                }

                foreach (var el in document.Root.Elements("copyAssembly"))
                {
                    _CopyAssemblies.Add(el.Value);
                }
                foreach (var el in document.Root.Elements("searchPath"))
                {
                    _SearchPaths.Add(el.Value);
                }
                foreach (var el in document.Root.Elements("includeAssembly"))
                {
                    _IncludeAssemblies.Add(el.Value);
                }
                foreach (var el in document.Root.Elements("excludeNamespace"))
                {
                    _ExcludeNamespaces.Add(el.Value);
                }
                foreach (var el in document.Root.Elements("excludeType"))
                {
                    _ExcludeTypes.Add(el.Value);
                }
                foreach (var el in document.Root.Elements("noFamily"))
                {
                    _NoFamily.Add(el.Value);
                }
            }
        }
    }
}
