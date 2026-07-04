using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MODAPI_LangTool
{
    public enum ModApiDialogType
    {
        Info,
        Warning,
        Error,
        Confirm       // Yes / No
    }

    public partial class ModApiDialog : Window
    {
        public MessageBoxResult Result { get; private set; } = MessageBoxResult.Cancel;

        private ModApiDialog() { InitializeComponent(); }

        // ── 정적 팩토리 메서드 ─────────────────────────────────────────

        /// <summary>확인 버튼 하나짜리 알림창</summary>
        public static void Show(Window owner, string title, string message,
            ModApiDialogType type = ModApiDialogType.Info)
        {
            var dlg = Build(owner, title, message, type);
            dlg.AddButton("OK", MessageBoxResult.OK, true);
            dlg.ShowDialog();
        }

        /// <summary>Yes / No 선택창. Yes 선택 시 true 반환</summary>
        public static bool Confirm(Window owner, string title, string message,
            ModApiDialogType type = ModApiDialogType.Warning)
        {
            var dlg = Build(owner, title, message, type);
            dlg.AddButton("Yes", MessageBoxResult.Yes, true);
            dlg.AddButton("No",  MessageBoxResult.No,  false);
            dlg.ShowDialog();
            return dlg.Result == MessageBoxResult.Yes;
        }

        /// <summary>Yes / No / Cancel 선택창</summary>
        public static MessageBoxResult Ask(Window owner, string title, string message,
            ModApiDialogType type = ModApiDialogType.Warning)
        {
            var dlg = Build(owner, title, message, type);
            dlg.AddButton("Yes",    MessageBoxResult.Yes,    true);
            dlg.AddButton("No",     MessageBoxResult.No,     false);
            dlg.AddButton("Cancel", MessageBoxResult.Cancel, false);
            dlg.ShowDialog();
            return dlg.Result;
        }

        // ── 빌더 ──────────────────────────────────────────────────────

        private static ModApiDialog Build(Window owner, string title, string message,
            ModApiDialogType type)
        {
            var dlg = new ModApiDialog();
            dlg.Owner = owner;
            dlg.TitleText.Text   = title;
            dlg.MessageText.Text = message;

            switch (type)
            {
                case ModApiDialogType.Warning:
                    dlg.IconText.Text       = "⚠";
                    dlg.IconText.Foreground = new SolidColorBrush(Color.FromRgb(233, 69, 96));
                    dlg.BorderColor("#E94560");
                    break;
                case ModApiDialogType.Error:
                    dlg.IconText.Text       = "✕";
                    dlg.IconText.Foreground = new SolidColorBrush(Color.FromRgb(233, 69, 96));
                    dlg.BorderColor("#E94560");
                    break;
                case ModApiDialogType.Confirm:
                    dlg.IconText.Text       = "?";
                    dlg.IconText.Foreground = new SolidColorBrush(Color.FromRgb(15, 52, 96));
                    dlg.BorderColor("#0F3460");
                    break;
                default: // Info
                    dlg.IconText.Text       = "ℹ";
                    dlg.IconText.Foreground = new SolidColorBrush(Color.FromRgb(100, 180, 255));
                    dlg.BorderColor("#0F3460");
                    break;
            }

            return dlg;
        }

        private void BorderColor(string hex)
        {
            var c = (Color)ColorConverter.ConvertFromString(hex);
            ((Border)Content).BorderBrush = new SolidColorBrush(c);
        }

        private void AddButton(string label, MessageBoxResult result, bool isAccent)
        {
            var btn = new Button
            {
                Content         = label,
                Padding         = new Thickness(20, 8, 20, 8),
                FontSize        = 13,
                FontWeight      = isAccent ? FontWeights.SemiBold : FontWeights.Normal,
                BorderThickness = new Thickness(0),
                Cursor          = System.Windows.Input.Cursors.Hand,
                Margin          = new Thickness(8, 0, 0, 0),
                Background      = isAccent
                    ? new SolidColorBrush(Color.FromRgb(233, 69, 96))
                    : new SolidColorBrush(Color.FromRgb(51, 51, 85)),
                Foreground      = new SolidColorBrush(Colors.White),
            };

            var capturedResult = result;
            btn.Click += (s, e) =>
            {
                Result = capturedResult;
                DialogResult = true;
                Close();
            };

            ButtonPanel.Children.Add(btn);
        }
    }
}
