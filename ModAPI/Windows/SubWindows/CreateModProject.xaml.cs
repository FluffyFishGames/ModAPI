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
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ModAPI.Configurations;
using ModAPI.Data;

namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für CreateModProject.xaml
    /// </summary>
    public partial class CreateModProject : BaseSubWindow
    {
        public CreateModProject()
        {
            InitializeComponent();
            TextChanged();
        }

        public CreateModProject(string langKey)
            : base(langKey)
        {
            InitializeComponent();
            TextChanged();
        }

        private void TextChanged()
        {
            var path = "";
            try
            {
                path = Path.GetFullPath(Configuration.GetPath("Projects") + Path.DirectorySeparatorChar + App.Game.GameConfiguration.Id +
                                        Path.DirectorySeparatorChar + ID.Text);
            }
            catch (Exception e)
            {
            }

            if (ID.Text == "" || !Mod.Header.VerifyModId(ID.Text) || (path != "" && Directory.Exists(path)))
            {
                if (path != "" && Directory.Exists(path) && ID.Text != "")
                {
                    ErrorID.Visibility = Visibility.Visible;
                }
                else
                {
                    ErrorID.Visibility = Visibility.Collapsed;
                }

                ConfirmButton.IsEnabled = false;
                ConfirmButton.Opacity = 0.5;
            }
            else
            {
                ErrorID.Visibility = Visibility.Collapsed;
                ConfirmButton.IsEnabled = true;
                ConfirmButton.Opacity = 1;
            }
        }

        private void TextChanged(object sender, KeyEventArgs e)
        {
            TextChanged();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged();
        }

        private void TextChanged(object sender, TextCompositionEventArgs e)
        {
            TextChanged();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ModProjects.CreateProject(ID.Text);
            Close();
        }
    }
}
