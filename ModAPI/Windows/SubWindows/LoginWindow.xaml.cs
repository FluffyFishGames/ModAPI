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
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Net;
using Ionic.Zip;

namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class LoginWindow : BaseSubWindow
    {
        
        public LoginWindow()
            : base()
        {
            InitializeComponent();
        }

        public LoginWindow(string langKey, bool showError = false)
            : base(langKey)
        {
            InitializeComponent();
            if (showError)
                Error.Visibility = System.Windows.Visibility.Visible;
        }


        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ModAPI.Utils.WebService.Login(this.Username.Text, this.Password.Password);
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
