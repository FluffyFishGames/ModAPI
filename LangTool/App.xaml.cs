using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace MODAPI_LangTool
{
    public partial class App : Application
    {
        public static readonly List<LangInfo> AvailableLanguages = new List<LangInfo>();
        public static string CurrentLangCode = "EN";
        public static string LangFolder = "";

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LangFolder = FindLangFolder();
            BuildLanguageList();

            var savedLang = LoadSavedLang();
            var found = AvailableLanguages.FirstOrDefault(
                l => l.LangCode.Equals(savedLang, StringComparison.OrdinalIgnoreCase));
            if (found == null)
                found = AvailableLanguages.FirstOrDefault(
                    l => l.LangCode.Equals("EN", StringComparison.OrdinalIgnoreCase))
                    ?? AvailableLanguages.FirstOrDefault();

            if (found != null)
                ApplyLanguage(found);
        }

        private static string FindLangFolder()
        {
            var exe = AppDomain.CurrentDomain.BaseDirectory;

            var c1 = Path.Combine(exe, "resources", "langs");
            if (Directory.Exists(c1)) return c1;

            var c2 = Path.GetFullPath(Path.Combine(exe, "..", "..", "..", "ModAPI", "resources", "langs"));
            if (Directory.Exists(c2)) return c2;

            var c3 = Path.GetFullPath(Path.Combine(exe, "..", "..", "..", "..", "ModAPI", "resources", "langs"));
            if (Directory.Exists(c3)) return c3;

            // 저장된 경로 기반 탐색
            var saved = LoadSavedRootPath();
            if (!string.IsNullOrEmpty(saved))
            {
                var c4 = Path.Combine(saved, "resources", "langs");
                if (Directory.Exists(c4)) return c4;
            }

            return "";
        }

        private static void BuildLanguageList()
        {
            AvailableLanguages.Clear();

            if (string.IsNullOrEmpty(LangFolder) || !Directory.Exists(LangFolder))
            {
                AvailableLanguages.Add(new LangInfo { LangCode = "EN", LangName = "English", FilePath = "" });
                return;
            }

            var files = Directory.GetFiles(LangFolder, "Language.*.xaml")
                                 .OrderBy(f => f).ToList();

            foreach (var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                var parts = name.Split('.');
                if (parts.Length < 2) continue;
                var code = parts[1].ToUpper();
                var langName = ReadLangName(file) ?? code;
                AvailableLanguages.Add(new LangInfo { LangCode = code, LangName = langName, FilePath = file });
            }

            if (AvailableLanguages.Count == 0)
                AvailableLanguages.Add(new LangInfo { LangCode = "EN", LangName = "English", FilePath = "" });
        }

        private static string ReadLangName(string filePath)
        {
            try
            {
                var content = File.ReadAllText(filePath, Encoding.UTF8);
                var match = System.Text.RegularExpressions.Regex.Match(
                    content, @"<s:String\s+x:Key=""LangName"">([^<]*)</s:String>");
                return match.Success ? match.Groups[1].Value.Trim() : null;
            }
            catch { return null; }
        }

        public static void ApplyLanguage(LangInfo lang)
        {
            CurrentLangCode = lang.LangCode;

            if (!string.IsNullOrEmpty(lang.FilePath) && File.Exists(lang.FilePath))
            {
                try
                {
                    var dict = new ResourceDictionary
                    {
                        Source = new Uri(lang.FilePath, UriKind.Absolute)
                    };

                    var existing = Current.Resources.MergedDictionaries
                        .FirstOrDefault(d => d.Source != null &&
                            d.Source.AbsolutePath.Contains("Language."));
                    if (existing != null)
                        Current.Resources.MergedDictionaries.Remove(existing);

                    Current.Resources.MergedDictionaries.Add(dict);
                }
                catch { }
            }

            SaveLang(lang.LangCode);
        }

        // ── langtool.cfg (key=value 형식) ──────────────────────────────

        private static string SettingsPath =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "langtool.cfg");

        private static Dictionary<string, string> LoadSettings()
        {
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            try
            {
                if (!File.Exists(SettingsPath)) return dict;
                foreach (var line in File.ReadAllLines(SettingsPath, Encoding.UTF8))
                {
                    var idx = line.IndexOf('=');
                    if (idx < 1) continue;
                    dict[line.Substring(0, idx).Trim()] = line.Substring(idx + 1).Trim();
                }
            }
            catch { }
            return dict;
        }

        private static void SaveSettings(Dictionary<string, string> dict)
        {
            try
            {
                var lines = new List<string>();
                foreach (var kv in dict)
                    lines.Add($"{kv.Key}={kv.Value}");
                File.WriteAllLines(SettingsPath, lines, Encoding.UTF8);
            }
            catch { }
        }

        // ── 언어 ──────────────────────────────────────────────────────

        private static string LoadSavedLang()
        {
            var d = LoadSettings();
            if (d.TryGetValue("Lang", out var lang) && !string.IsNullOrEmpty(lang))
                return lang;
            // 구버전 호환: 파일 전체가 언어 코드였던 경우
            try
            {
                if (File.Exists(SettingsPath))
                {
                    var raw = File.ReadAllText(SettingsPath, Encoding.UTF8).Trim();
                    if (!raw.Contains("=")) return raw;
                }
            }
            catch { }
            return "EN";
        }

        private static void SaveLang(string code)
        {
            var d = LoadSettings();
            d["Lang"] = code;
            SaveSettings(d);
        }

        // ── 경로 ──────────────────────────────────────────────────────

        public static string LoadSavedRootPath()
        {
            var d = LoadSettings();
            d.TryGetValue("RootPath", out var p);
            return p ?? "";
        }

        public static void SaveRootPath(string rootPath)
        {
            var d = LoadSettings();
            d["RootPath"] = rootPath;
            SaveSettings(d);
        }
    }

    public class LangInfo
    {
        public string LangCode { get; set; }
        public string LangName { get; set; }
        public string FilePath { get; set; }
        public override string ToString() => LangName;
    }
}