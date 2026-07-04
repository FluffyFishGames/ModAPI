using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MODAPI_LangTool.Helpers
{
    public static class XamlGenerator
    {
        private const string Header =
            "\uFEFF<ResourceDictionary xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\r\n" +
            "                    xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\r\n" +
            "                    xmlns:s=\"clr-namespace:System;assembly=mscorlib\">\r\n\r\n\r\n\r\n";

        private const string Footer = "</ResourceDictionary>\r\n    ";

        /// <summary>
        /// 영어 기준 파일을 읽어 새 언어 XAML 파일 생성
        /// 메타 키(LangCode, Locale, LangName)는 새 언어 정보로 설정
        /// 나머지 모든 키는 영어 값을 그대로 복사 (번역 대기 상태)
        /// </summary>
        public static void GenerateFromEnglish(
            string englishXamlPath,
            string outputPath,
            string langCode,
            string langName,
            string isoCode)
        {
            var englishContent = File.ReadAllText(englishXamlPath, Encoding.UTF8);
            var keys = ParseXamlKeys(englishContent);

            var sb = new StringBuilder();
            sb.Append(Header);

            foreach (var kv in keys)
            {
                string value;
                switch (kv.Key)
                {
                    case "LangCode":
                        value = langCode.ToUpper();
                        break;
                    case "Locale":
                        value = $"{isoCode.ToLower()}-{isoCode.ToUpper()}";
                        break;
                    case "LangName":
                        value = langName;
                        break;
                    default:
                        value = kv.Value;
                        break;
                }

                // XML 특수문자 이스케이프
                value = value
                    .Replace("&", "&amp;")
                    .Replace("<", "&lt;")
                    .Replace(">", "&gt;")
                    .Replace("\"", "&quot;");

                // 이미 이스케이프된 것 중복 방지
                value = value
                    .Replace("&amp;amp;", "&amp;")
                    .Replace("&amp;lt;", "&lt;")
                    .Replace("&amp;gt;", "&gt;")
                    .Replace("&amp;quot;", "&quot;");

                sb.AppendLine($"    <s:String x:Key=\"{kv.Key}\">{value}</s:String>");
            }

            sb.Append(Footer);

            var dir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllText(outputPath, sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// XAML 파일에서 키-값 쌍 파싱
        /// </summary>
        public static Dictionary<string, string> ParseXamlKeys(string xamlContent)
        {
            var result = new Dictionary<string, string>();
            var pattern = new Regex(
                @"<s:String\s+x:Key=""([^""]+)"">([^<]*)</s:String>",
                RegexOptions.Singleline);

            foreach (Match m in pattern.Matches(xamlContent))
            {
                var key = m.Groups[1].Value;
                var value = m.Groups[2].Value
                    .Replace("&amp;", "&")
                    .Replace("&lt;", "<")
                    .Replace("&gt;", ">")
                    .Replace("&quot;", "\"");

                if (!result.ContainsKey(key))
                    result[key] = value;
            }
            return result;
        }

        /// <summary>
        /// 기존 XAML 파일에서 특정 키 값 업데이트 후 저장
        /// </summary>
        public static void UpdateXamlKey(string xamlPath, string key, string newValue)
        {
            var content = File.ReadAllText(xamlPath, Encoding.UTF8);
            var escaped = newValue
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;");

            var pattern = new Regex(
                $@"(<s:String\s+x:Key=""{Regex.Escape(key)}"">)[^<]*(</s:String>)");
            content = pattern.Replace(content, $"${{1}}{escaped}${{2}}");
            File.WriteAllText(xamlPath, content, Encoding.UTF8);
        }

        /// <summary>
        /// XAML 파일 전체 키-값 저장
        /// </summary>
        public static void SaveAllKeys(
            string xamlPath,
            Dictionary<string, string> keys,
            string langCode,
            string langName,
            string isoCode)
        {
            var sb = new StringBuilder();
            sb.Append(Header);

            foreach (var kv in keys)
            {
                var value = kv.Value
                    .Replace("&", "&amp;")
                    .Replace("<", "&lt;")
                    .Replace(">", "&gt;")
                    .Replace("\"", "&quot;");

                sb.AppendLine($"    <s:String x:Key=\"{kv.Key}\">{value}</s:String>");
            }

            sb.Append(Footer);
            File.WriteAllText(xamlPath, sb.ToString(), Encoding.UTF8);
        }
    }
}
