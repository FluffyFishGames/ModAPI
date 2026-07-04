using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MODAPI_LangTool.Models
{
    [DataContract]
    public class LangsJson
    {
        [DataMember(Name = "languages")]
        public List<LanguageEntry> Languages { get; set; } = new List<LanguageEntry>();
    }
}
