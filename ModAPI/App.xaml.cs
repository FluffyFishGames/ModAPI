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

using ModAPI.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ModAPI
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static string Version = "2.0.9618";
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
                catch (Exception)
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

        // ── 테마 레지스트리 ─────────────────────────────────────────────────────
        // 새 테마 추가 시: 이 딕셔너리에 한 줄만 추가하면 됩니다.
        // key   = theme.cfg에 저장되는 ID (소문자)
        // value = Themes/ 하위 XAML 파일명 (null = Classic: Dictionary.xaml만 사용)
        public static readonly Dictionary<string, string> ThemeRegistry =
            new Dictionary<string, string>
            {
                { "classic", null },
                { "light",   "FluentStylesLight.xaml" },
                { "dark",    "FluentStyles.xaml" },
                { "diablo",  "FluentStylesDiablo.xaml" },
                { "nebula",  "FluentStylesNebula.xaml" },
                { "sunset",  "FluentStylesSunset.xaml" },
                { "ocean",   "FluentStylesOcean.xaml" },
                { "nordic",  "FluentStylesNordic.xaml" },
                { "citrus",  "FluentStylesCitrus.xaml" },
                { "bloom",   "FluentStylesBloom.xaml" },
            };

        // 순서가 보장된 테마 ID 목록 (ThemeSelector 인덱스와 1:1 대응)
        public static readonly List<string> ThemeIds =
            new List<string>(new[]
            {
                "classic", "light", "dark", "diablo",
                "nebula", "sunset", "ocean", "nordic", "citrus", "bloom"
            });

        private void ApplyTheme()
        {
            var theme = GetCurrentTheme();

            // App.xaml 기본 로드된 FluentStyles* 제거
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
                Resources.MergedDictionaries.Remove(toRemove);

            // 레지스트리에서 파일명 조회 후 로드
            string fileName;
            if (ThemeRegistry.TryGetValue(theme, out fileName) && fileName != null)
            {
                Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/ModAPI;component/Themes/" + fileName)
                });
            }
            // classic / 미등록 테마: Dictionary.xaml 단독 사용 (추가 로드 없음)
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
            return "classic";
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