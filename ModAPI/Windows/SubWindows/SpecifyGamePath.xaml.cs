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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using ModAPI.Data;
using ModAPI.Utils;
using Path = System.IO.Path;

namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class SpecifyGamePath : BaseSubWindow
    {
        protected Schedule.Task Task;
        protected bool Completed;

        public SpecifyGamePath(Schedule.Task task)
        {
            InitializeComponent();
            Task = task;
            GamePath.Text = ((Game)task.Parameters[0]).GamePath;
            Check();
        }

        public SpecifyGamePath(string langKey, Schedule.Task task)
            : base(langKey)
        {
            InitializeComponent();
            Task = task;
            GamePath.Text = ((Game)task.Parameters[0]).GamePath;
            Check();
        }

        protected void Check()
        {
            ((Game)Task.Parameters[0]).GamePath = GamePath.Text;
            if (Task.Check())
            {
                AcceptIcon.Visibility = Visibility.Visible;
                DeclineIcon.Visibility = Visibility.Hidden;
                ConfirmButton.Opacity = 1f;
                ConfirmButton.IsEnabled = true;
            }
            else
            {
                AcceptIcon.Visibility = Visibility.Hidden;
                DeclineIcon.Visibility = Visibility.Visible;
                ConfirmButton.Opacity = 0.5f;
                ConfirmButton.IsEnabled = false;
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ((Game)Task.Parameters[0]).GamePath = GamePath.Text;
            if (Task.Check())
            {
                Completed = true;
                Task.Complete();
                Close();
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
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = App.Game.GameConfiguration.SelectFile + "|" + App.Game.GameConfiguration.SelectFile,
                RestoreDirectory = true
            };
            if (openFileDialog1.ShowDialog() == true)
            {
                GamePath.Text = Path.GetDirectoryName(openFileDialog1.FileName);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (!Completed)
            {
                Environment.Exit(0);
            }
        }
    }
}