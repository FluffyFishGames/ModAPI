/*  
 *  ModAPI
 *  Copyright (C) 2015 FluffyFish / Philipp Mohrenstecher
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *  
 *  To contact me you can e-mail me at info@fluffyfish.de
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;


namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class SpecifySteamPath : BaseSubWindow
    {
        protected bool Completed = false;
        protected Utils.Schedule.Task Task;
        public SpecifySteamPath(Utils.Schedule.Task Task)
            : base()
        {
            InitializeComponent();
            this.Task = Task;
            this.SteamPath.Text = Configurations.Configuration.GetPath("Steam");
            Check();
            SetCloseable(false);
        }

        public SpecifySteamPath(string langKey, Utils.Schedule.Task Task)
            : base(langKey)
        {
            InitializeComponent();
            this.Task = Task;
            this.SteamPath.Text = Configurations.Configuration.GetPath("Steam");
            Check();
            SetCloseable(false);
        }

        protected void Check()
        {
            Configurations.Configuration.SetPath("Steam", this.SteamPath.Text);
            if (this.Task.Check())
            {
                AcceptIcon.Visibility = System.Windows.Visibility.Visible;
                DeclineIcon.Visibility = System.Windows.Visibility.Hidden;
                ConfirmButton.Opacity = 1f;
                ConfirmButton.IsEnabled = true;
            }
            else
            {
                AcceptIcon.Visibility = System.Windows.Visibility.Hidden;
                DeclineIcon.Visibility = System.Windows.Visibility.Visible;
                ConfirmButton.Opacity = 0.5f;
                ConfirmButton.IsEnabled = false;
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Configurations.Configuration.SetPath("Steam", this.SteamPath.Text, true);
            if (Task.Check())
            {
                Completed = true;
                Task.Complete();
                this.Close();
            }
        }

        private void SteamPath_TextInput(object sender, TextCompositionEventArgs e)
        {
            Check();
        }

        private void SteamPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check();
        }

        private void OnClickBrowse(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Steam.exe|Steam.exe";

            if (openFileDialog1.ShowDialog() == true)
            {
                this.SteamPath.Text = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
            }

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (!Completed)
            Environment.Exit(0);
        }
    }
}
