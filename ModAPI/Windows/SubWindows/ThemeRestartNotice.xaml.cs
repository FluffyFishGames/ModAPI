using System.Windows;

namespace ModAPI.Windows.SubWindows
{
    public partial class ThemeRestartNotice : BaseSubWindow
    {
        public ThemeRestartNotice()
        {
            InitializeComponent();
        }

        public ThemeRestartNotice(string langKey)
            : base(langKey)
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
