namespace MODAPI_LangTool.Models
{
    public class IsoCountry
    {
        public string IsoCode  { get; set; }  // 소문자 2자리 (예: kr)
        public string Name     { get; set; }  // 영문 국가명 (예: South Korea)
        public string LangCode { get; set; }  // 기본 언어파일 코드 (예: KR)
        public bool   IsUsed   { get; set; }  // 이미 추가된 언어 여부

        public string DisplayText =>
            IsUsed
                ? $"[{IsoCode.ToUpper()}] {Name}  ✓"
                : $"[{IsoCode.ToUpper()}] {Name}";

        public override string ToString() => DisplayText;
    }
}
