using System.Windows;

namespace ModAPI.Windows.SubWindows
{
    public partial class DeleteModConfirm : BaseSubWindow
    {
        public bool Confirmed { get; private set; }

        public DeleteModConfirm(string langKey, string modName)
            : base(langKey)
        {
            InitializeComponent();

            var format = Application.Current.TryFindResource(langKey + ".Text") as string
                         ?? "Delete mod \"{0}\" and all its versions?\nThis will also remove deployed .dll files from the game folder.";
            MessageText.Text = string.Format(format, modName);
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
