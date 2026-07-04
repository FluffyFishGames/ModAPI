using System;
using System.Windows;

namespace ModAPI.Windows.SubWindows
{
    public partial class GameIntegrityWarning : Window
    {
        public bool UserConfirmed { get; private set; } = false;

        private string _langKey;

        /// <summary>
        /// gameDisplayName: 팝업 메시지에 표시할 게임명 (예: "The Forest", "Green Hell")
        /// </summary>
        public GameIntegrityWarning(string langKey, string gameDisplayName = null)
        {
            InitializeComponent();
            _langKey = langKey;
            ApplyClassicThemeFix();
            ApplyMessage(gameDisplayName);
        }

        /// <summary>
        /// 언어 리소스의 {0} 자리에 게임명을 채워 메시지를 구성합니다.
        /// 게임명이 없으면 일반 문구를 그대로 사용합니다.
        /// </summary>
        private void ApplyMessage(string gameDisplayName)
        {
            try
            {
                var template = Application.Current.Resources["Lang.Windows.GameNoSignature.Text"] as string;
                if (string.IsNullOrEmpty(template))
                    template = "{0} executable has no digital signature. This is common for indie games and does not affect gameplay.";

                MessageText.Text = !string.IsNullOrEmpty(gameDisplayName)
                    ? string.Format(template, gameDisplayName)
                    : template;
            }
            catch (Exception ex)
            {
                // 언어 리소스에 {0} 이 없거나 형식이 깨진 경우에도 팝업 자체는 떠야 하므로
                // 안전한 기본 문구로 대체하고 강제 종료를 방지한다.
                Debug.Log("GameIntegrityWarning",
                    $"[ApplyMessage] Failed to format message: {ex.GetType().Name} | {ex.Message}",
                    Debug.Type.Error);
                MessageText.Text = !string.IsNullOrEmpty(gameDisplayName)
                    ? gameDisplayName + " executable has no digital signature."
                    : "The game executable has no digital signature.";
            }
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

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            UserConfirmed = true;
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            UserConfirmed = false;
            DialogResult = false;
            Close();
        }
    }
}