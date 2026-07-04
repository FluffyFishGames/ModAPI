using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using MODAPI_LangTool.Models;

namespace MODAPI_LangTool.Helpers
{
    public static class LangsJsonHelper
    {
        public static LangsJson Load(string path)
        {
            if (!File.Exists(path))
                return new LangsJson();

            var json = File.ReadAllText(path, Encoding.UTF8);
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var ser = new DataContractJsonSerializer(typeof(LangsJson));
                return (LangsJson)ser.ReadObject(ms);
            }
        }

        public static void Save(string path, LangsJson data)
        {
            var settings = new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            };
            var ser = new DataContractJsonSerializer(typeof(LangsJson), settings);

            using (var ms = new MemoryStream())
            {
                ser.WriteObject(ms, data);
                var json = Encoding.UTF8.GetString(ms.ToArray());

                // 보기 좋게 들여쓰기 처리
                json = FormatJson(json);
                File.WriteAllText(path, json, Encoding.UTF8);
            }
        }

        private static string FormatJson(string json)
        {
            var sb = new StringBuilder();
            int indent = 0;
            bool inString = false;

            foreach (char c in json)
            {
                if (c == '"' ) inString = !inString;

                if (!inString)
                {
                    if (c == '{' || c == '[')
                    {
                        sb.Append(c);
                        sb.AppendLine();
                        indent++;
                        sb.Append(new string(' ', indent * 2));
                        continue;
                    }
                    if (c == '}' || c == ']')
                    {
                        sb.AppendLine();
                        indent--;
                        sb.Append(new string(' ', indent * 2));
                        sb.Append(c);
                        continue;
                    }
                    if (c == ',')
                    {
                        sb.Append(c);
                        sb.AppendLine();
                        sb.Append(new string(' ', indent * 2));
                        continue;
                    }
                    if (c == ':')
                    {
                        sb.Append(c);
                        sb.Append(' ');
                        continue;
                    }
                }
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
