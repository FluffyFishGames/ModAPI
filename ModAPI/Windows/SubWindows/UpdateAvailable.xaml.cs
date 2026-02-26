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
using System.Net;
using System.Threading;
using System.Windows;
using Ionic.Zip;

namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class UpdateAvailable : BaseSubWindow
    {
        protected string NewVersion = "";

        public UpdateAvailable()
        {
            InitializeComponent();
        }

        public UpdateAvailable(string langKey, string newVersion)
            : base(langKey)
        {
            InitializeComponent();
            NewVersion = newVersion;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs ev)
        {
            var handler = new ProgressHandler();
            var t = new Thread(delegate ()
            {
                var request = (HttpWebRequest)WebRequest.Create("https://github.com/zzangae/ModAPI/releases/download/" + NewVersion + "/ModAPI.zip");
                request.AllowAutoRedirect = true;
                request.UserAgent = "ModAPI-Updater";
                var response = (HttpWebResponse)request.GetResponse();
                var s = response.GetResponseStream();
                var buffer = new byte[4096];
                var memory = new MemoryStream();
                var count = 0;
                long current = 0;
                var progress = 0f;
                handler.Task = "Download";
                while ((count = s.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memory.Write(buffer, 0, count);
                    current += count;
                    progress = (float)(((current / (double)response.ContentLength)) * 70.0);
                    handler.Progress = progress;
                }

                memory.Position = 0;
                var zip = ZipFile.Read(memory);
                var directory = "./_update";
                var n = 0;
                handler.Task = "Extracting";
                foreach (var e in zip)
                {
                    try
                    {
                        e.Extract(directory, ExtractExistingFileAction.OverwriteSilently);
                    }
                    catch (Exception ex3)
                    {
                    }
                    n += 1;
                    handler.Progress = 70f + (n / (float)zip.Count) * 30f;
                }

                var p = new Process();
                p.StartInfo.FileName = "Updater.exe";
                p.StartInfo.Verb = "runas";
                p.Start();
                Environment.Exit(0);
            });

            var window = new OperationPending("Lang.Windows.OperationPending", "Update", handler);
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