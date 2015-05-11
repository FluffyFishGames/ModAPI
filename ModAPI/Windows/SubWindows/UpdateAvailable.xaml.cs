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
    public partial class UpdateAvailable : BaseSubWindow
    {
        protected string newVersion = "";

        public UpdateAvailable()
            : base()
        {
            InitializeComponent();
        }

        public UpdateAvailable(string langKey, string newVersion)
            : base(langKey)
        {
            InitializeComponent();
            this.newVersion = newVersion;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs ev)
        {
            ProgressHandler handler = new ProgressHandler();
            Thread t = new Thread(delegate() 
                {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.modapi.de/app/archives/" + this.newVersion + ".zip");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream();
                byte[] buffer = new byte[4096];
                MemoryStream memory = new MemoryStream();
                int count = 0;
                long current = 0;
                float progress = 0f;
                handler.Task = "Download";
                while ((count = s.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memory.Write(buffer, 0, count);
                    current += count;
                    progress = (float)((((double)current / (double)response.ContentLength)) * 70.0);
                    handler.Progress = progress;
                }

                memory.Position = 0;
                ZipFile zip = ZipFile.Read(memory);
                string directory = "./_update";
                int n = 0;
                handler.Task = "Extracting";
                foreach (ZipEntry e in zip)
                {
                    try
                    {
                        e.Extract(directory, ExtractExistingFileAction.OverwriteSilently);
                    }
                    catch (Exception ex3)
                    {

                    }
                    n += 1;
                    handler.Progress = 70f + ((float)n / (float)zip.Count) * 30f;
                }

                Process p = new Process();
                p.StartInfo.FileName = "Updater.exe";
                p.StartInfo.Verb = "runas";
                p.Start();
                Environment.Exit(0);
            });

            ModAPI.Windows.SubWindows.OperationPending window = new ModAPI.Windows.SubWindows.OperationPending("Lang.Windows.OperationPending", "Update", handler);
            if (!window.Completed)
            {
                window.ShowSubWindow();
                window.Show();
                Close();
            }
            t.Start();

        }
    }
}
