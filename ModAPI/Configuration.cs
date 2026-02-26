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
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ModAPI;

/*namespace ModAPI
{*/
/// <summary>
/// Legacy configuration class - no longer used.
/// Replaced by ModAPI.Configurations.Configuration in ModAPI_Shared.
/// Contains dead references to souldrinker.de and modapi.cc backends.
/// </summary>
[System.Obsolete("Legacy code - not used anywhere in the application")]
public class OldConfiguration
{
    public static Dictionary<string, Language> Languages = new Dictionary<string, Language>();
    protected static ResourceDictionary CurrentLanguage;
    public static List<ComboBoxItem> LanguageItems;
    protected static Dictionary<string, string> Data;
    protected static Dictionary<string, string> Standard;
    public static string ProgramPath = Path.GetFullPath(".");

    public enum ResultCode
    {
        Ok,
        ERROR
    }

    public enum ErrorCode
    {
        ConfigCorrupted
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
        {
            Data[key] = value;
        }
        else
        {
            Data.Add(key, value);
        }
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
            Standard.Add("savepath", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low\\SKS\\TheForest\\");
        }
    }

    public static Hashes GetHashes()
    {
        var h = new Hashes();
        if (h.LoadHashesFromNet())
        {
            return h;
        }
        return null;
    }

    public static string GetChecksum(string gamePath)
    {
        var b1 = new byte[0];
        var b2 = new byte[0];
        var b3 = new byte[0];
        var b4 = new byte[0];

        try
        {
            b1 = File.ReadAllBytes(gamePath + "\\theforest_data\\Managed\\Assembly-CSharp.dll");
        }
        catch (Exception e)
        {
        }
        try
        {
            b2 = File.ReadAllBytes(gamePath + "\\theforest_data\\Managed\\Assembly-CSharp-firstpass.dll");
        }
        catch (Exception e)
        {
        }
        try
        {
            b3 = File.ReadAllBytes(gamePath + "\\theforest_data\\Managed\\Assembly-UnityScript.dll");
        }
        catch (Exception e)
        {
        }
        try
        {
            b4 = File.ReadAllBytes(gamePath + "\\theforest_data\\Managed\\Assembly-UnityScript-firstpass.dll");
        }
        catch (Exception e)
        {
        }

        var md5 = MD5.Create();
        var hash = BitConverter.ToString(md5.ComputeHash(b1)).Replace("-", "") +
                   BitConverter.ToString(md5.ComputeHash(b2)).Replace("-", "") +
                   BitConverter.ToString(md5.ComputeHash(b3)).Replace("-", "") +
                   BitConverter.ToString(md5.ComputeHash(b4)).Replace("-", "");

        return hash;
    }

    public class Hashes
    {
        public class Version
        {
            public string BuildId;
            public string Number;
            public string Hash;
        }

        public List<Version> Versions;

        public void ParseHashes(string hashFile)
        {
            Versions = new List<Version>();
            var lines = hashFile.Split(new[] { "\n" }, StringSplitOptions.None);
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Replace("\r", "").Trim();
                var parts = line.Split(new[] { "|" }, StringSplitOptions.None);
                var newVersion = new Version
                {
                    Number = parts[0],
                    BuildId = parts[1],
                    Hash = parts[2]
                };
                Versions.Add(newVersion);
            }
        }

        public bool LoadHashesFromNet()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://www.souldrinker.de/modapi/theforest/VersionsData.txt");
            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.Found)
            {
                var s = response.GetResponseStream();
                var mem = new MemoryStream();

                var buffer = new byte[1024];
                var c = 0;
                while ((c = s.Read(buffer, 0, buffer.Length)) != 0)
                {
                    mem.Write(buffer, 0, c);
                }

                mem.Position = 0;
                var allBytes = new byte[mem.Length];
                mem.Read(allBytes, 0, allBytes.Length);

                var versionFile = Encoding.UTF8.GetString(allBytes);
                ParseHashes(versionFile);
                return true;
            }
            return false;
        }
    }

    public static ResultCode Load()
    {
        StandardConfiguration();
        Data = new Dictionary<string, string>();
        if (!ProgramPath.EndsWith("\\"))
        {
            ProgramPath += "\\";
        }

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

        return ResultCode.Ok;
    }

    public static void Save()
    {
        var ConfigDataInst = "";
        var keys = Data.Keys.ToArray();
        for (var i = 0; i < keys.Length; i++)
        {
            ConfigDataInst += (i != 0 ? "\r\n" : "") + keys[i] + "=" + Data[keys[i]];
        }
        File.WriteAllText(ProgramPath + "config.dat", ConfigDataInst);
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

            foreach (var language in Languages.Values)
            {
                var c = new ComboBoxItem
                {
                    Style = Application.Current.FindResource("ComboBoxItem") as Style
                };
                var panel = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };
                c.Content = panel;

                var fileName = "langs/" + language.Resource["LangCode"] + ".png";
                if (File.Exists(fileName))
                {
                    var ms = new MemoryStream();
                    var stream = new FileStream(fileName, FileMode.Open);
                    ms.SetLength(stream.Length);
                    stream.Read(ms.GetBuffer(), 0, (int)stream.Length);
                    ms.Flush();
                    stream.Close();

                    var i = new Image();
                    var img = new BitmapImage();
                    img.BeginInit();
                    img.StreamSource = ms;
                    img.EndInit();
                    i.Source = img;
                    i.Margin = new Thickness(0, 0, 10, 0);

                    panel.Children.Add(i);
                }

                var text = new TextBlock
                {
                    Name = "Label",

                    VerticalAlignment = VerticalAlignment.Center,
                    Text = language.Resource["LangName"] as String
                };
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
            {
                App.Instance.Resources.MergedDictionaries.Remove(CurrentLanguage);
            }

            App.Instance.Resources.MergedDictionaries.Add(Languages[language].Resource);
            CurrentLanguage = Languages[language].Resource;

            OnLanguageChanged?.Invoke();
        }
        return false;
    }

    public class Language
    {
        public string Key;
        public ResourceDictionary Resource;

        public Language(ResourceDictionary resource)
        {
            Resource = resource;
            Key = Resource["LangCode"] as String;
        }
    }
}
//}