using System.Windows;

namespace ModAPI.Windows.SubWindows
{
    public partial class ThemeConfirm : BaseSubWindow
    {
        public bool Confirmed { get; private set; }

        public ThemeConfirm()
        {
            InitializeComponent();
        }

        public ThemeConfirm(string langKey)
            : base(langKey)
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            Confirmed = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Confirmed = false;
            Close();
        }
    }
}
