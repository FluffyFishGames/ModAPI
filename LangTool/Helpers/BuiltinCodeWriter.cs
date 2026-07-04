using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MODAPI_LangTool.Models;

namespace MODAPI_LangTool.Helpers
{
    public static class BuiltinCodeWriter
    {
        // ── 경로 탐색 ──────────────────────────────────────────────────

        /// <summary>
        /// ModAPI 루트 기준으로 LangTool\MainWindow.xaml.cs 경로 반환
        /// </summary>
        public static string FindMainWindowCs(string modApiRootPath)
        {
            // ModAPI 루트 → 솔루션 루트 → LangTool\MainWindow.xaml.cs
            var solutionRoot = Path.GetFullPath(Path.Combine(modApiRootPath, ".."));
            var candidate = Path.Combine(solutionRoot, "LangTool", "MainWindow.xaml.cs");
            if (File.Exists(candidate)) return candidate;
            return null;
        }

        /// <summary>
        /// ModAPI 루트 기준으로 ModAPI.csproj 경로 반환
        /// </summary>
        public static string FindModApiCsproj(string modApiRootPath)
        {
            var candidate = Path.Combine(modApiRootPath, "ModAPI.csproj");
            if (File.Exists(candidate)) return candidate;
            return null;
        }

        // ── CreateDefaultLangsJson() 재작성 ────────────────────────────

        /// <summary>
        /// MainWindow.xaml.cs 의 CreateDefaultLangsJson() 메서드를
        /// 현재 builtin:true 언어 전체로 재작성
        /// </summary>
        public static bool RewriteCreateDefaultLangsJson(
            string mainWindowCsPath,
            IEnumerable<LanguageEntry> builtinLanguages,
            out string error)
        {
            error = null;
            try
            {
                var content = File.ReadAllText(mainWindowCsPath, Encoding.UTF8);

                // 메서드 블록 전체를 정규식으로 탐색
                var pattern = new Regex(
                    @"private LangsJson CreateDefaultLangsJson\(\)\s*\{.*?\}(\s*\})",
                    RegexOptions.Singleline);

                if (!pattern.IsMatch(content))
                {
                    error = "CreateDefaultLangsJson() 메서드를 찾을 수 없습니다.";
                    return false;
                }

                var newMethod = BuildCreateDefaultMethod(builtinLanguages);
                content = pattern.Replace(content, newMethod + "$1");

                File.WriteAllText(mainWindowCsPath, content, Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        private static string BuildCreateDefaultMethod(IEnumerable<LanguageEntry> languages)
        {
            var sb = new StringBuilder();
            sb.AppendLine("private LangsJson CreateDefaultLangsJson()");
            sb.AppendLine("        {");
            sb.AppendLine("            return new LangsJson");
            sb.AppendLine("            {");
            sb.AppendLine("                Languages = new List<LanguageEntry>");
            sb.AppendLine("                {");

            foreach (var lang in languages)
            {
                sb.AppendLine(
                    $"                    new LanguageEntry {{ " +
                    $"IsoCode=\"{lang.IsoCode}\", " +
                    $"LangCode=\"{lang.LangCode}\", " +
                    $"LangName=\"{EscapeCs(lang.LangName)}\", " +
                    $"Builtin=true, Active=true }},");
            }

            sb.AppendLine("                }");
            sb.AppendLine("            };");
            sb.Append("        }");
            return sb.ToString();
        }

        private static string EscapeCs(string s)
            => s?.Replace("\\", "\\\\").Replace("\"", "\\\"") ?? "";

        // ── ModAPI.csproj 에 Language.XX.xaml 등록 ─────────────────────

        /// <summary>
        /// ModAPI.csproj 의 Resource 섹션에 Language.XX.xaml 추가
        /// 이미 등록된 경우 스킵
        /// </summary>
        public static bool RegisterLangFileInCsproj(
            string csprojPath,
            string langCode,
            out string error)
        {
            error = null;
            try
            {
                var content = File.ReadAllText(csprojPath, Encoding.UTF8);
                var fileName = $"Language.{langCode.ToUpper()}.xaml";
                var resourceEntry =
                    $"<Resource Include=\"resources\\langs\\{fileName}\" />";

                // 이미 등록되어 있으면 스킵
                if (content.Contains(fileName))
                    return true;

                // 기존 Language.EN.xaml 항목 다음에 삽입
                var anchor = "<Resource Include=\"resources\\langs\\Language.EN.xaml\" />";
                if (!content.Contains(anchor))
                {
                    // 앵커 없으면 아무 Resource 항목 뒤에 삽입
                    var fallback = new Regex(
                        @"(<Resource Include=""resources\\langs\\Language\.\w+\.xaml""\s*/>)(?![\s\S]*<Resource Include=""resources\\langs\\Language\.\w+\.xaml""\s*/>.*" + Regex.Escape(fileName) + ")",
                        RegexOptions.Singleline);
                    var m = fallback.Match(content);
                    if (!m.Success)
                    {
                        error = $"ModAPI.csproj 에서 Resource 삽입 위치를 찾을 수 없습니다.";
                        return false;
                    }
                    content = content.Insert(
                        m.Index + m.Length,
                        Environment.NewLine + "    " + resourceEntry);
                }
                else
                {
                    content = content.Replace(
                        anchor,
                        anchor + Environment.NewLine + "    " + resourceEntry);
                }

                File.WriteAllText(csprojPath, content, Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
