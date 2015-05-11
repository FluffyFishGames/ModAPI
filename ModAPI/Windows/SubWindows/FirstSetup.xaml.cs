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
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class FirstSetup : BaseSubWindow
    {
        public FirstSetup()
            : base()
        {
            InitializeComponent();
            Check();
            SetCloseable(false);
        }

        public FirstSetup(string langKey)
            : base(langKey)
        {
            InitializeComponent();
            Check();
            SetCloseable(false);
        }

        protected void Check()
        {
        }

        protected bool Completed = false;

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Completed = true;
            Configurations.Configuration.SetString("UseSteam", (bool)this.UseSteam.IsChecked?"true":"false", true);
            Configurations.Configuration.SetString("AutoUpdate", (bool)this.AutoUpdate.IsChecked ? "true" : "false", true);
            Configurations.Configuration.SetString("UpdateVersions", (bool)this.UseAutoUpdateVersions.IsChecked ? "true" : "false", true);
            Configurations.Configuration.SetString("SetupDone", "true", true);
            Configurations.Configuration.Save();
            Close();
            MainWindow.Instance.FirstSetupDone();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (!Completed)
                Environment.Exit(0);
        }
    }
}
