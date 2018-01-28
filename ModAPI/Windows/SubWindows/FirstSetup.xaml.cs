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
using ModAPI.Configurations;

namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class FirstSetup : BaseSubWindow
    {
        public FirstSetup()
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

        protected bool Completed;

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Completed = true;
            Configuration.SetString("UseSteam", (bool) UseSteam.IsChecked ? "true" : "false", true);
            Configuration.SetString("AutoUpdate", (bool) AutoUpdate.IsChecked ? "true" : "false", true);
            Configuration.SetString("UpdateVersions", (bool) UseAutoUpdateVersions.IsChecked ? "true" : "false", true);
            Configuration.SetString("SetupDone", "true", true);
            Configuration.Save();
            Close();
            MainWindow.Instance.FirstSetupDone();
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
