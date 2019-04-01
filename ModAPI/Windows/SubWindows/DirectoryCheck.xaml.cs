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
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using IWshRuntimeLibrary;
using File = System.IO.File;
using Path = System.IO.Path;



namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class DirectoryCheck : BaseSubWindow
    {
        
        public DirectoryCheck()
        {
            InitializeComponent();
            SetCloseable(true);

           
        }

       public DirectoryCheck(string langKey)//, string newVersion)
            : base(langKey)
        {
            InitializeComponent();
            SetCloseable(true);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Environment.Exit(0);
            
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs ev)
        {
            MoveApp();
        }

        #region Check loading paths & move files by: SiXxKilLuR 03/25/2019 01:15PM      
        //Check of ran from tmp directories and move to a working directory
        private static string Apath;
        private static string FPath;
       
        private static void MoveApp()
        {
            Apath = (Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName));
            FPath = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "ModAPI";

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(Apath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(Apath, FPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(Apath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(Apath, FPath), true);
            CDSK();
        }

        private static string dstring;

        private static void CDSK()
        {
            dstring = Application.Current.Resources["Lang.Windows.DirectoryCheck.IDesc"].ToString(); 
            WshShell wsh = new WshShell();
            IWshShortcut shortcut = wsh.CreateShortcut(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ModAPI.lnk") as IWshShortcut;
            shortcut.Arguments = "";
            shortcut.TargetPath = FPath + "\\ModAPI.exe";
            shortcut.WindowStyle = 1;
            shortcut.Description = dstring;
            shortcut.WorkingDirectory = FPath;
            shortcut.IconLocation = FPath + "\\ModAPI.exe";
            shortcut.Save();

            Environment.Exit(0);
            
        }
        
        #endregion
    }
}
