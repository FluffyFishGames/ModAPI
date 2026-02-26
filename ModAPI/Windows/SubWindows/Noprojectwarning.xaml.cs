using System.Windows;

namespace ModAPI.Windows.SubWindows
{
    public partial class NoProjectWarning : BaseSubWindow
    {
        public NoProjectWarning()
        {
            InitializeComponent();
        }

        public NoProjectWarning(string langKey)
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