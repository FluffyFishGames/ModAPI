using System.ComponentModel;
using System.Runtime.Serialization;

namespace MODAPI_LangTool.Models
{
    [DataContract]
    public class LanguageEntry : INotifyPropertyChanged
    {
        private string _isoCode;
        private string _langCode;
        private string _langName;
        private bool _builtin;
        private bool _active;

        [DataMember(Name = "isoCode")]
        public string IsoCode
        {
            get => _isoCode;
            set { _isoCode = value; OnPropertyChanged("IsoCode"); }
        }

        [DataMember(Name = "langCode")]
        public string LangCode
        {
            get => _langCode;
            set { _langCode = value; OnPropertyChanged("LangCode"); }
        }

        [DataMember(Name = "langName")]
        public string LangName
        {
            get => _langName;
            set { _langName = value; OnPropertyChanged("LangName"); }
        }

        [DataMember(Name = "builtin")]
        public bool Builtin
        {
            get => _builtin;
            set { _builtin = value; OnPropertyChanged("Builtin"); OnPropertyChanged("IsEditable"); OnPropertyChanged("StatusIcon"); }
        }

        [DataMember(Name = "active")]
        public bool Active
        {
            get => _active;
            set { _active = value; OnPropertyChanged("Active"); OnPropertyChanged("StatusIcon"); OnPropertyChanged("StatusText"); }
        }

        // UI 전용 속성
        public bool IsEditable => !Builtin;

        public string StatusIcon
        {
            get
            {
                if (Builtin) return "🔒";
                if (!Active) return "🚫";
                return "✅";
            }
        }

        public string StatusText
        {
            get
            {
                if (Builtin) return "내장";
                if (!Active) return "비활성";
                return "활성";
            }
        }

        public string FlagFileName => $"Language.{LangCode?.ToUpper()}.png";

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
