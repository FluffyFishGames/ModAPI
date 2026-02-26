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
using System.IO;
using System.Windows;
using ModAPI.Data;

namespace ModAPI
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static string Version = "2.0.0";
        public static bool DevMode;

        public ResourceDictionary LanguageDictionary;
        public static App Instance;
        public static Game Game;

        public static string RootPath;
        public static string UpdatePath;

        static void CopyFiles(string directory, string b = "")
        {
            var files = Directory.GetFiles(directory);
            foreach (var file in files)
            {
                try
                {
                    File.Copy(file, RootPath + Path.DirectorySeparatorChar + b + Path.GetFileName(file), true);
                    File.Delete(file);
                }
                catch (Exception e)
                {
                    //System.Console.WriteLine(e);
                }
            }
            var directories = Directory.GetDirectories(directory);
            foreach (var dir in directories)
            {
                CopyFiles(directory + Path.DirectorySeparatorChar + Path.GetFileName(dir), b + Path.DirectorySeparatorChar + Path.GetFileName(dir) + Path.DirectorySeparatorChar);
                Directory.Delete(dir);
            }
        }

        public static string ThemeFile = "theme.cfg";

        public App()
        {
            AssemblyResolver.Initialize();
            RootPath = Path.GetFullPath(".");
            UpdatePath = Path.GetFullPath("_update") + Path.DirectorySeparatorChar;
            DevMode = false;
            var args = Environment.GetCommandLineArgs();
            foreach (var arg in args)
            {
                if (arg.Equals("--dev", StringComparison.OrdinalIgnoreCase))
                {
                    DevMode = true;
                    break;
                }
            }

            if (Directory.Exists(UpdatePath))
            {
                CopyFiles(UpdatePath);
                Directory.Delete(UpdatePath, true);
            }

            Debug.Environment = "ModAPI";

            Instance = this;
            InitializeComponent();

            ApplyTheme();
        }

        private void ApplyTheme()
        {
            var theme = GetCurrentTheme();
            if (theme == "dark") return; // FluentStyles.xaml already loaded via App.xaml

            ResourceDictionary toRemove = null;
            foreach (var dict in Resources.MergedDictionaries)
            {
                if (dict.Source != null && dict.Source.ToString().Contains("FluentStyles"))
                {
                    toRemove = dict;
                    break;
                }
            }
            if (toRemove != null)
            {
                Resources.MergedDictionaries.Remove(toRemove);
            }

            if (theme == "light")
            {
                var lightTheme = new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/ModAPI;component/FluentStylesLight.xaml")
                };
                Resources.MergedDictionaries.Add(lightTheme);
            }
            // classic: Dictionary.xaml only (original ModAPI design) + fallback resources
        }

        public static string GetCurrentTheme()
        {
            try
            {
                var path = Path.Combine(RootPath, ThemeFile);
                if (File.Exists(path))
                {
                    return File.ReadAllText(path).Trim().ToLower();
                }
            }
            catch { }
            return "dark";
        }

        public static void SaveTheme(string theme)
        {
            try
            {
                var path = Path.Combine(RootPath, ThemeFile);
                File.WriteAllText(path, theme);
            }
            catch { }
        }
    }
}