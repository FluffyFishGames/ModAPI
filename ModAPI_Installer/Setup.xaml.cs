using System;
using System.Windows;
using System.Windows.Input;

namespace ModAPI_Installer
{
    /// <summary>
    /// Interaktionslogik für Setup.xaml
    /// </summary>
    public partial class Setup : Window
    {
        public Setup()
        {
            InitializeComponent();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs args)
        {
            DragMove();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement) FindName("Mover")).MouseLeftButtonDown += MoveWindow;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
            Environment.Exit(0);
        }
    }
}
