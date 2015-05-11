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
    public partial class SpecifyGamePath : BaseSubWindow
    {
        protected Utils.Schedule.Task Task;
        protected bool Completed = false;
        public SpecifyGamePath(Utils.Schedule.Task Task)
            : base()
        {
            InitializeComponent();
            this.Task = Task;
            this.GamePath.Text = ((ModAPI.Data.Game)Task.Parameters[0]).GamePath;
            Check();
            SetCloseable(false);
        }

        public SpecifyGamePath(string langKey, Utils.Schedule.Task Task)
            : base(langKey)
        {
            InitializeComponent();
            this.Task = Task;
            this.GamePath.Text = ((ModAPI.Data.Game)Task.Parameters[0]).GamePath;
            Check();
            SetCloseable(false);
        }

        protected void Check()
        {
            ((ModAPI.Data.Game)Task.Parameters[0]).GamePath = this.GamePath.Text;
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
            ((ModAPI.Data.Game)Task.Parameters[0]).GamePath = this.GamePath.Text;
            if (Task.Check())
            {
                Completed = true;
                Task.Complete();
                this.Close();
            }
        }

        private void GamePath_TextInput(object sender, TextCompositionEventArgs e)
        {
            Check();
        }

        private void GamePath_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check();
        }

        private void OnClickBrowse(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = App.Game.GameConfiguration.SelectFile + "|" + App.Game.GameConfiguration.SelectFile;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                this.GamePath.Text = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
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
