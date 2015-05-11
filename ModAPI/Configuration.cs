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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Net;
using System.Xml.Linq;
using System.Reflection;
using System.Reflection.Emit;
using ModAPI;

/*namespace ModAPI
{*/
    public class OldConfiguration
    {


        public static Dictionary<string, Language> Languages = new Dictionary<string, Language>();
        protected static ResourceDictionary CurrentLanguage = null;
        public static List<ComboBoxItem> LanguageItems;
        protected static Dictionary<string, string> Data;
        protected static Dictionary<string, string> Standard;
        public static string ProgramPath = System.IO.Path.GetFullPath(".");
        public enum ResultCode
        {
            OK,
            ERROR
        };

        public enum ErrorCode
        {
            CONFIG_CORRUPTED
        }

        

        public static ErrorCode Error;

        public static int GetInt(string key)
        {
            key = key.ToLower();
            try
            {
                if (!Data.ContainsKey(key))
                {
                    return int.Parse(Standard[key]);
                }
                return int.Parse(Data[key]);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public static string Get(string key)
        {
            key = key.ToLower();
            try
            {
                if (!Data.ContainsKey(key))
                {
                    return Standard[key];
                }
                return Data[key];
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public static void Set(string key, string value)
        {
            key = key.ToLower();
            if (Data.ContainsKey(key))
                Data[key] = value;
            else
                Data.Add(key, value);
        }

        public static void Set(string key, int value)
        {
            key = key.ToLower();
            Set(key, "" + value);
        }


        public static void StandardConfiguration()
        {
            if (Standard == null)
            {
                Standard = new Dictionary<string, string>();
                Standard.Add("savepath", System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + "Low\\SKS\\TheForest\\");
            }
        }

        public static Hashes GetHashes()
        {
            Hashes h = new Hashes();
            if (h.LoadHashesFromNet())
            {
                return h;
            }
            return null;
        }

        public static string GetChecksum(string GamePath)
        {
            byte[] b1 = new byte[0];
            byte[] b2 = new byte[0];
            byte[] b3 = new byte[0];
            byte[] b4 = new byte[0];

            try { b1 = System.IO.File.ReadAllBytes(GamePath + "\\theforest_data\\Managed\\Assembly-CSharp.dll"); }
            catch (Exception e) { }
            try { b2 = System.IO.File.ReadAllBytes(GamePath + "\\theforest_data\\Managed\\Assembly-CSharp-firstpass.dll"); }
            catch (Exception e) { }
            try { b3 = System.IO.File.ReadAllBytes(GamePath + "\\theforest_data\\Managed\\Assembly-UnityScript.dll"); }
            catch (Exception e) { }
            try { b4 = System.IO.File.ReadAllBytes(GamePath + "\\theforest_data\\Managed\\Assembly-UnityScript-firstpass.dll"); }
            catch (Exception e) { }

            MD5 md5 = MD5.Create();
            string hash = System.BitConverter.ToString(md5.ComputeHash(b1)).Replace("-", "") +
                System.BitConverter.ToString(md5.ComputeHash(b2)).Replace("-", "") +
                System.BitConverter.ToString(md5.ComputeHash(b3)).Replace("-", "") +
                System.BitConverter.ToString(md5.ComputeHash(b4)).Replace("-", "");

            return hash;
        }

        public class Hashes
        {
            public class Version
            {
                public string BuildID;
                public string Number;
                public string Hash;
            }

            public List<Version> Versions;

            public void ParseHashes(string hashFile)
            {
                Versions = new List<Version>();
                string[] lines = hashFile.Split(new string[] { "\n" }, StringSplitOptions.None);
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Replace("\r", "").Trim();
                    string[] parts = line.Split(new string[] { "|" }, StringSplitOptions.None);
                    Version newVersion = new Version();
                    newVersion.Number = parts[0];
                    newVersion.BuildID = parts[1];
                    newVersion.Hash = parts[2];
                    Versions.Add(newVersion);
                }
            }

            public bool LoadHashesFromNet()
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.souldrinker.de/modapi/theforest/versions.txt");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.Found)
                {
                    Stream s = response.GetResponseStream();
                    MemoryStream mem = new MemoryStream();

                    byte[] buffer = new byte[1024];
                    int c = 0;
                    while ((c = s.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        mem.Write(buffer, 0, c);
                    }

                    mem.Position = 0;
                    byte[] allBytes = new byte[mem.Length];
                    mem.Read(allBytes, 0, allBytes.Length);

                    string versionFile = System.Text.Encoding.UTF8.GetString(allBytes);
                    ParseHashes(versionFile);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static ResultCode Load()
        {
            StandardConfiguration();
            Data = new Dictionary<string, string>();
            if (!ProgramPath.EndsWith("\\"))
                ProgramPath += "\\";
           
            /*if (System.IO.File.Exists("config.dat"))
            {
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(ProgramPath + "config.dat");
                    for (int i = 0; i < lines.Length; i++)
                    {
                        int firstIndex = lines[i].IndexOf("=");
                        if (firstIndex > 0)
                        {
                            Set(lines[i].Substring(0, firstIndex).Trim().ToLower(), lines[i].Substring(firstIndex + 1).Trim());
                        }
                    }
                }
                catch (Exception e)
                {
                    Error = ErrorCode.CONFIG_CORRUPTED;
                    return ResultCode.ERROR;
                }
            }*/

            return ResultCode.OK;
        }

        public static void Save()
        {
            string ConfigData = "";
            string[] keys = Data.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                ConfigData += (i != 0 ? "\r\n" : "") + keys[i] + "=" + Data[keys[i]];
            }
            System.IO.File.WriteAllText(ProgramPath + "config.dat", ConfigData);
        }

        public static void AddLanguage(Language language)
        {
            Languages.Add(language.Key, language);
        }

        public static List<ComboBoxItem> GetLanguageList()
        {
            if (LanguageItems == null)
            {
                LanguageItems = new List<ComboBoxItem>();
                    
                foreach (Language language in Languages.Values)
                {
                    ComboBoxItem c = new ComboBoxItem();
                    c.Style = Application.Current.FindResource("ComboBoxItem") as Style;
                    StackPanel panel = new StackPanel();
                    panel.Orientation = Orientation.Horizontal;
                    c.Content = panel;

                    string fileName = "langs/" + language.Resource["LangCode"] + ".png";
                    if (System.IO.File.Exists(fileName))
                    {
                        MemoryStream ms = new MemoryStream();
                        FileStream stream = new FileStream(fileName, FileMode.Open);
                        ms.SetLength(stream.Length);
                        stream.Read(ms.GetBuffer(), 0, (int)stream.Length);
                        ms.Flush();
                        stream.Close();

                        Image i = new Image();
                        BitmapImage img = new BitmapImage();
                        img.BeginInit();
                        img.StreamSource = ms;
                        img.EndInit();
                        i.Source = img;
                        i.Margin = new Thickness(0, 0, 10, 0);

                        panel.Children.Add(i);
                    }

                    TextBlock text = new TextBlock();
                    text.Name = "Label";
                    
                    text.VerticalAlignment = VerticalAlignment.Center;
                    text.Text = language.Resource["LangName"] as String;
                    
                    panel.Children.Add(text);

                    LanguageItems.Add(c);
                }
            }
            return LanguageItems;
        }

        public delegate void LanguageChanged();
        public static LanguageChanged OnLanguageChanged;
        
        public static bool ChangeLanguage(string language)
        {
            if (Languages.ContainsKey(language))
            {
                if (CurrentLanguage != null)
                    App.Instance.Resources.MergedDictionaries.Remove(CurrentLanguage);
                
                App.Instance.Resources.MergedDictionaries.Add(Languages[language].Resource);
                CurrentLanguage = Languages[language].Resource;

                if (OnLanguageChanged != null)
                    OnLanguageChanged();
            }
            return false;
        }

        public class Language
        {
            public string Key;
            public ResourceDictionary Resource;
            public Language(ResourceDictionary resource)
            {
                this.Resource = resource;
                this.Key = Resource["LangCode"] as String;
            }
        }
    }
//}
