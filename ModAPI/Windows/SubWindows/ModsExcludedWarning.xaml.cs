using System;
using System.Windows;

namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// 다른 게임용으로 보이는 mod가 자동으로 제외됐을 때 사용자에게 안내하는 팝업.
    /// (ApplyMods()의 게임 호환성 사전 검증에서 mod가 하나 이상 제외된 경우 표시)
    /// </summary>
    public partial class ModsExcludedWarning : Window
    {
        private string _langKey;

        /// <summary>
        /// modsSummary: 제외된 mod 목록을 사람이 읽을 수 있게 정리한 문자열
        /// (예: "DebugMode (Green Hell 전용으로 보임)")
        /// </summary>
        public ModsExcludedWarning(string langKey, string modsSummary = null)
        {
            InitializeComponent();
            _langKey = langKey;
            ApplyClassicThemeFix();
            ApplyTexts(modsSummary);
        }

        /// <summary>
        /// 여러 안내(예: "이 mod는 제외됨" + "그래서 게임을 실행하지 않음")를 팝업 하나로
        /// 합쳐서 보여줄 때 쓴다. 완성된 제목/본문을 그대로 쓰고, langKey 기반의 자동
        /// 포맷팅은 건너뛴다.
        /// </summary>
        /// <param name="okButtonFullLangKey">확인 버튼 문구의 전체 리소스 키 (예: "Lang.Windows.NoModsApplied.OK")</param>
        public static ModsExcludedWarning CreateWithCustomMessage(string title, string message, string okButtonFullLangKey)
        {
            var win = new ModsExcludedWarning(null, null);
            win.TitleText.Text = title;
            win.MessageText.Text = message;
            string okText;
            try
            {
                okText = Application.Current.Resources[okButtonFullLangKey] as string;
            }
            catch (Exception)
            {
                okText = null;
            }
            win.OkButton.Content = string.IsNullOrEmpty(okText) ? "OK" : okText;
            return win;
        }

        private string GetLang(string suffix, string fallback)
        {
            try
            {
                var value = Application.Current.Resources[_langKey + suffix] as string;
                return string.IsNullOrEmpty(value) ? fallback : value;
            }
            catch (Exception)
            {
                return fallback;
            }
        }

        private void ApplyTexts(string modsSummary)
        {
            TitleText.Text = GetLang(".Title", "Some mods were excluded");

            try
            {
                var template = GetLang(".Text",
                    "The following mod(s) appear to be built for a different game and were excluded:\n{0}");
                MessageText.Text = !string.IsNullOrEmpty(modsSummary)
                    ? string.Format(template, modsSummary)
                    : template;
            }
            catch (Exception ex)
            {
                // 언어 리소스 형식이 깨진 경우에도 팝업 자체는 떠야 하므로 안전한 기본 문구로 대체
                Debug.Log("ModsExcludedWarning",
                    $"[ApplyTexts] Failed to format message: {ex.GetType().Name} | {ex.Message}",
                    Debug.Type.Error);
                MessageText.Text = !string.IsNullOrEmpty(modsSummary)
                    ? "The following mod(s) were excluded: " + modsSummary
                    : "Some mods were excluded.";
            }

            OkButton.Content = GetLang(".OK", "OK");
        }

        /// <summary>
        /// 클래식 테마는 FluentBgBrush = Transparent 이므로
        /// 팝업 배경이 보이지 않는 문제를 수정합니다.
        /// </summary>
        private void ApplyClassicThemeFix()
        {
            var bgBrush = System.Windows.Application.Current.Resources["FluentBgBrush"]
                as System.Windows.Media.SolidColorBrush;
            if (bgBrush == null || bgBrush.Color.A == 0)
            {
                var border = (System.Windows.Controls.Border)Content;
                border.Background = new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromRgb(30, 20, 0));
                border.BorderBrush = new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromRgb(255, 215, 0)); // #FFD700
            }
        }

        public void ShowSubWindow()
        {
            Owner = MainWindow.Instance;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}