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
            :base(langKey)
        {
            InitializeComponent();
            TextChanged();
        }

        private void TextChanged()
        {
            string path = "";
            try
            {
                path = System.IO.Path.GetFullPath(Configurations.Configuration.GetPath("Projects") + System.IO.Path.DirectorySeparatorChar + App.Game.GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + ID.Text);
            }
            catch (Exception e) {}
            
            if (ID.Text == "" || !ModAPI.Data.Mod.Header.VerifyModID(ID.Text) || (path != "" && System.IO.Directory.Exists(path)))
            {
                if (path != "" && System.IO.Directory.Exists(path) && ID.Text != "")
                    ErrorID.Visibility = System.Windows.Visibility.Visible;
                else
                    ErrorID.Visibility = System.Windows.Visibility.Collapsed;
                    
                ConfirmButton.IsEnabled = false;
                ConfirmButton.Opacity = 0.5;
            }
            else
            {
                ErrorID.Visibility = System.Windows.Visibility.Collapsed;
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
            MainWindow.Instance.ModProjects.CreateProject(this.ID.Text);
            Close();
        }
    }
}
