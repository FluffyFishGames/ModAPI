using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MODAPI_LangTool.Helpers
{
    public class MissingKeyResult
    {
        public List<string> MissingKeys { get; set; } = new List<string>();
        public List<string> EmptyKeys { get; set; } = new List<string>();
        public int TotalKeys { get; set; }
        public int TranslatedKeys { get; set; }
    }

    public static class MissingKeyDetector
    {
        /// <summary>
        /// 영어 기준 키 목록과 대상 언어 파일 비교
        /// 누락된 키, 빈 값 키 반환
        /// </summary>
        public static MissingKeyResult Detect(string englishXamlPath, string targetXamlPath)
        {
            var result = new MissingKeyResult();

            if (!File.Exists(englishXamlPath))
                return result;

            var englishContent = File.ReadAllText(englishXamlPath, Encoding.UTF8);
            var englishKeys = XamlGenerator.ParseXamlKeys(englishContent);
            result.TotalKeys = englishKeys.Count;

            if (!File.Exists(targetXamlPath))
            {
                result.MissingKeys.AddRange(englishKeys.Keys);
                return result;
            }

            var targetContent = File.ReadAllText(targetXamlPath, Encoding.UTF8);
            var targetKeys = XamlGenerator.ParseXamlKeys(targetContent);

            foreach (var kv in englishKeys)
            {
                // 메타 키 제외
                if (kv.Key == "LangCode" || kv.Key == "Locale" || kv.Key == "LangName")
                    continue;

                if (!targetKeys.ContainsKey(kv.Key))
                {
                    result.MissingKeys.Add(kv.Key);
                }
                else if (string.IsNullOrWhiteSpace(targetKeys[kv.Key]))
                {
                    result.EmptyKeys.Add(kv.Key);
                }
                else
                {
                    result.TranslatedKeys++;
                }
            }

            return result;
        }
    }
}
