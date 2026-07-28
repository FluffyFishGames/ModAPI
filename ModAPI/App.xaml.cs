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
using System.Globalization;
using System.Threading;
using System.Windows;

namespace ModAPI
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static string Version = "2.0.9621";
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
            // .NET 예외 메시지가 Windows 시스템 언어를 따르지 않도록 고정
            // 프랑스어 등 비영어 Windows 환경에서 예외 메시지가 혼용되는 문제 방지
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            // ── 전역 예외 로깅 ─────────────────────────────────────────────
            // 지금까지는 Debug.Log()를 명시적으로 호출한 지점만 기록되고, 어디선가
            // 예외가 안 잡힌 채로 터지면 아무 흔적도 안 남고 그냥 종료되는 문제가 있었다.
            // UI 스레드(DispatcherUnhandledException)와 그 외 스레드(AppDomain의
            // UnhandledException) 양쪽 모두에 핸들러를 걸어서, 어떤 예외든 죽기 전에
            // 종류/메시지/스택 트레이스를 반드시 로그에 남기도록 한다.
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

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
                    Debug.DevMode = true;
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

        // UI(Dispatcher) 스레드에서 안 잡힌 예외 — 대부분의 크래시가 여기 해당된다.
        // (바인딩 평가, 이벤트 핸들러, 화면 렌더링 준비 중 예외 등)
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                Debug.Log("App",
                    "[UnhandledException:UI] " + e.Exception.GetType().FullName + ": " + e.Exception.Message +
                    "\n" + e.Exception.StackTrace +
                    (e.Exception.InnerException != null
                        ? "\n-- Inner: " + e.Exception.InnerException.GetType().FullName + ": " + e.Exception.InnerException.Message + "\n" + e.Exception.InnerException.StackTrace
                        : ""),
                    Debug.Type.Error);
            }
            catch (Exception)
            {
                // 로깅 자체가 실패해도 원래 예외 처리 흐름은 막지 않는다
            }
            // e.Handled 를 설정하지 않으므로 기존 동작(앱 종료) 그대로 유지 — 로그만 남기고
            // 계속 실행할지는 원인 파악 후 별도로 결정한다.
        }

        // UI 스레드가 아닌 곳(백그라운드 스레드 등)에서 안 잡힌 예외.
        // 이 이벤트가 발생한 시점엔 이미 프로세스가 종료 확정 상태라 되돌릴 수 없지만,
        // 최소한 원인을 로그에 남길 수 있다.
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var ex = e.ExceptionObject as Exception;
                Debug.Log("App",
                    "[UnhandledException:Domain] IsTerminating=" + e.IsTerminating + " | " +
                    (ex != null
                        ? ex.GetType().FullName + ": " + ex.Message + "\n" + ex.StackTrace
                        : "Non-Exception object: " + e.ExceptionObject),
                    Debug.Type.Error);
            }
            catch (Exception)
            {
                // 로깅 자체가 실패해도 조용히 무시 (이미 종료 확정 상태)
            }
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