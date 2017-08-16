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
using System.Xml;
using System.Xml.Linq;

namespace ModAPI.Configurations
{
    public class GuiConfiguration
    {
        public enum ResultCode
        {
            Ok,
            ERROR
        }

        public enum ErrorCode
        {
            FileNotFound,
            MalformedConfiguration
        }

        public static ErrorCode Error;
        public static string ErrorString = "";
        public static List<Tab> Tabs;

        protected static ProgressHandler CurrentProgressHandler;

        protected static void ChangeProgress(float progress)
        {
            if (CurrentProgressHandler != null)
            {
                CurrentProgressHandler.Progress = progress;
            }
        }

        public static ResultCode Load(ProgressHandler handler)
        {
            CurrentProgressHandler = handler;
            var gameConfigPath = Configuration.GetPath("GameConfigurations");
            if (gameConfigPath == "")
            {
                Error = ErrorCode.MalformedConfiguration;
                ErrorString = "Couldn't find the game configurations path.";
                Debug.Log("GUIConfiguration", ErrorString, Debug.Type.Error);
                return ResultCode.ERROR;
            }

            var gameConfigFile = Path.GetFullPath(gameConfigPath + Path.DirectorySeparatorChar + Configuration.CurrentGame + Path.DirectorySeparatorChar + "GUI.xml");
            if (!File.Exists(gameConfigFile))
            {
                Error = ErrorCode.FileNotFound;
                ErrorString = "Couldn't find the file \"" + gameConfigFile + "\".";
                Debug.Log("GUIConfiguration", ErrorString, Debug.Type.Error);
                return ResultCode.ERROR;
            }

            Debug.Log("GUIConfiguration", "Parsing the GUI configuration file \"" + gameConfigFile + "\".");
            try
            {
                var configuration = XDocument.Load(gameConfigFile);
                Tabs = new List<Tab>();
                if (!ParseTabs(configuration.Root))
                {
                    Error = ErrorCode.MalformedConfiguration;
                    ErrorString = "The configuration file \"" + gameConfigFile + "\" contains invalid elements.";
                    Debug.Log("GUIConfiguration", ErrorString, Debug.Type.Error);
                    return ResultCode.ERROR;
                }
            }
            catch (XmlException ex)
            {
                Error = ErrorCode.MalformedConfiguration;
                ErrorString = "The file \"" + gameConfigFile + "\" couldn't be parsed. Exception: " + ex;
                Debug.Log("GUIConfiguration", ErrorString, Debug.Type.Error);
                return ResultCode.ERROR;
            }
            catch (Exception ex)
            {
                Error = ErrorCode.MalformedConfiguration;
                ErrorString = "The file \"" + gameConfigFile + "\" couldn't be parsed. Unexpected exception: " + ex;
                Debug.Log("GUIConfiguration", ErrorString, Debug.Type.Error);
                return ResultCode.ERROR;
            }
            Debug.Log("GUIConfiguration", "Successfully parsed the GUI configuration.");
            ChangeProgress(100f);
            return ResultCode.Ok;
        }

        static bool ParseTabs(XElement parent, Tab parentTab = null)
        {
            var success = true;
            foreach (var el in parent.Elements("Tab"))
            {
                var newTab = new Tab(el);
                if (newTab.Error)
                {
                    return false;
                }
                if (parentTab == null)
                {
                    Tabs.Add(newTab);
                }
                else
                {
                    parentTab.Tabs.Add(newTab);
                }

                if (!ParseTabs(el, newTab))
                {
                    success = false;
                }
            }
            return success;
        }

        public class Tab
        {
            public List<Tab> Tabs = new List<Tab>();
            public string IconName;
            public string IconSelectedName;
            public string LangPath;
            public string TypeName;
            public XDocument Configuration;
            public bool Error;
            public Type ComponentType;

            public Tab(XElement element)
            {
                if (element.Attribute("Icon") != null)
                {
                    IconName = element.Attribute("Icon").Value;
                }
                if (element.Attribute("IconSelected") != null)
                {
                    IconSelectedName = element.Attribute("IconSelected").Value;
                }
                if (element.Attribute("Lang") != null)
                {
                    LangPath = element.Attribute("Lang").Value;
                }
                if (element.Attribute("Type") != null)
                {
                    TypeName = "ModAPI.Components.Panels." + element.Attribute("Type").Value;
                }
                if (element.Attribute("Config") != null)
                {
                    var configFile = Path.GetFullPath(Configurations.Configuration.GetPath("GameConfigurations") + Path.DirectorySeparatorChar +
                                                      Configurations.Configuration.CurrentGame + Path.DirectorySeparatorChar + element.Attribute("Config").Value);
                    try
                    {
                        Configuration = XDocument.Load(configFile);
                    }
                    catch (XmlException e)
                    {
                        Debug.Log("GUIConfiguration", "The file \"" + configFile + "\" couldn't be parsed. Exception: " + e, Debug.Type.Error);
                        Error = true;
                        return;
                    }
                    catch (Exception e)
                    {
                        Debug.Log("GUIConfiguration", "The file \"" + configFile + "\" couldn't be parsed. Unexpected exception: " + e, Debug.Type.Error);
                        Error = true;
                        return;
                    }
                    Debug.Log("GUIConfiguration", "Parsed the configuration file \"" + configFile + "\" successfully.");
                }

                if (TypeName == "")
                {
                    Debug.Log("GUIConfiguration", "No type defined for tab", Debug.Type.Error);
                    Error = true;
                    return;
                }
                ComponentType = Type.GetType(TypeName);
                if (ComponentType == null)
                {
                    Debug.Log("GUIConfiguration", "Component type \"" + TypeName + "\" couldn't be found.", Debug.Type.Error);
                    Error = true;
                    return;
                }
                Debug.Log("GUIConfiguration", "Successfully added tab with panel type \"" + TypeName + "\".");
            }
        }
    }
}
