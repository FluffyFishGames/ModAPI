using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MODAPI_LangTool.Helpers
{
    public static class FlagDownloader
    {
        private static readonly HttpClient _client = new HttpClient();
        private const string FlagUrl = "https://flagcdn.com/h24/{0}.png";

        static FlagDownloader()
        {
            _client.DefaultRequestHeaders.Add("User-Agent", "MODAPI-LangTool/1.0");
            _client.Timeout = TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// ISO 3166-1 alpha-2 코드로 국기 이미지 다운로드
        /// </summary>
        /// <param name="isoCode">ISO 코드 (예: kr, us, gb)</param>
        /// <param name="savePath">저장 경로 (예: resources\langs\Language.KR.png)</param>
        public static async Task<bool> DownloadFlagAsync(string isoCode, string savePath)
        {
            try
            {
                var url = string.Format(FlagUrl, isoCode.ToLower());
                var bytes = await _client.GetByteArrayAsync(url);

                if (bytes == null || bytes.Length == 0)
                    return false;

                var dir = Path.GetDirectoryName(savePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.WriteAllBytes(savePath, bytes);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 국기 이미지 파일명 생성 규칙
        /// langCode → Language.{LANGCODE}.png
        /// </summary>
        public static string GetFlagFileName(string langCode)
        {
            return $"Language.{langCode.ToUpper()}.png";
        }
    }
}
