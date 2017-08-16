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
using System.Text;
using System.Threading;
using System.Windows;
using ModAPI.Configurations;
using ModAPI.Utils;
using Path = System.IO.Path;

namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class RestoreGameFiles : BaseSubWindow
    {
        protected Schedule.Task Task;

        public RestoreGameFiles(Schedule.Task task)
        {
            InitializeComponent();
            this.Task = task;
            Check();
            SetCloseable(false);
        }

        public RestoreGameFiles(string langKey, Schedule.Task task)
            : base(langKey)
        {
            InitializeComponent();
            this.Task = task;
            Check();
            SetCloseable(false);
        }

        protected void Check()
        {
            NoSteamText.Visibility = Visibility.Collapsed;
            SteamText.Visibility = Visibility.Collapsed;
            NoVersionUpdateText.Visibility = Visibility.Collapsed;
            VersionNotFoundText.Visibility = Visibility.Collapsed;
            ActivateVersionUpdate.Visibility = Visibility.Collapsed;
            ActivateSteam.Visibility = Visibility.Collapsed;
            Restore.Visibility = Visibility.Collapsed;
            Recheck.Visibility = Visibility.Collapsed;

            Close.Visibility = Visibility.Visible;

            if (Configuration.GetString("UpdateVersions").ToLower() != "true")
            {
                NoVersionUpdateText.Visibility = Visibility.Visible;
                ActivateVersionUpdate.Visibility = Visibility.Visible;
            }
            else
            {
                VersionNotFoundText.Visibility = Visibility.Visible;
            }

            if (Configuration.GetString("UseSteam").ToLower() != "true")
            {
                NoSteamText.Visibility = Visibility.Visible;
                ActivateSteam.Visibility = Visibility.Visible;
                Recheck.Visibility = Visibility.Visible;
            }
            else
            {
                Restore.Visibility = Visibility.Visible;
                SteamText.Visibility = Visibility.Visible;
            }
            /*
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
            }*/
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            //((ModAPI.Data.Game)Task.Parameters[0]).GamePath = this.GamePath.Text;
            if (Task.Check())
            {
                Task.Complete();
                Close();
            }
        }

        private void ActivateVersionUpdate_Click(object sender, RoutedEventArgs e)
        {
            Configuration.SetString("UpdateVersions", "true", true);
            Configuration.Save();
            Close();
            Task.Complete();
        }

        private void ActivateSteam_Click(object sender, RoutedEventArgs e)
        {
            Configuration.SetString("UseSteam", "true", true);
            Configuration.Save();
            Close();
            if (MainWindow.Instance.CheckSteamPath())
            {
                Task.Complete();
            }

            /*NoSteamText.Visibility = System.Windows.Visibility.Visible;
            ActivateSteam.Visibility = System.Windows.Visibility.Visible;
            Recheck.Visibility = System.Windows.Visibility.Visible;
            Restore.Visibility = System.Windows.Visibility.Collapsed;
            SteamText.Visibility = System.Windows.Visibility.Collapsed;*/
        }

        private void Restore_Click(object sender, RoutedEventArgs e)
        {
            var progressHandler = new ProgressHandler();
            progressHandler.OnComplete += (s, ev) => Dispatcher.Invoke(delegate { Task.Complete(); });
            var t = new Thread(delegate()
            {
                try
                {
                    var steamPath = Configuration.GetPath("Steam");
                    var p = new Process();
                    p.StartInfo.FileName = steamPath + Path.DirectorySeparatorChar + "Steam.exe";
                    p.StartInfo.Arguments = "steam://validate/" + App.Game.GameConfiguration.SteamAppId;
                    p.StartInfo.UseShellExecute = false;
                    p.Start();
                    progressHandler.Task = "Restore";
                    progressHandler.Progress = 50f;
                    var state = 0;
                    var lastLine = "";
                    while (true)
                    {
                        var processes = Process.GetProcesses();
                        var foundSteam = false;
                        foreach (var pp in processes)
                        {
                            try
                            {
                                if (!pp.HasExited && pp.ProcessName == "Steam")
                                {
                                    foundSteam = true;
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }

                        var logFile = steamPath + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "content_log.txt";
                        var s = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        var f = new FileInfo(logFile);
                        var data = new byte[f.Length];
                        s.Read(data, 0, (int) f.Length);
                        var content = Encoding.UTF8.GetString(data);

                        var l = content.Split(new[] { "\r\n" }, StringSplitOptions.None); // System.IO.File.ReadAllLines(SteamPath + "\\logs\\content_log.txt");
                        if (lastLine == "")
                        {
                            lastLine = l[l.Length - 2];
                        }
                        var check = false;
                        foreach (var n in l)
                        {
                            if (n == lastLine)
                            {
                                check = true;
                            }
                            if (check)
                            {
                                if (n.EndsWith("AppID " + App.Game.GameConfiguration.SteamAppId + " state changed : Fully Installed,"))
                                {
                                    state = 3;
                                }
                                else if (n.Contains("AppID " + App.Game.GameConfiguration.SteamAppId) && n.Contains("(Suspended)"))
                                {
                                    state = 1;
                                }
                                else if (n.Contains("Failed to get list of download sources from any known CS!"))
                                {
                                    state = 2;
                                }
                            }
                        }

                        if (state == 0 && !foundSteam)
                        {
                            state = 4;
                        }

                        if (state > 0)
                        {
                            break;
                        }

                        Thread.Sleep(500);
                    }

                    if (state == 3)
                    {
                        progressHandler.Task = "Finish";
                        progressHandler.Progress = 100f;
                    }
                    else
                    {
                        if (state == 1)
                        {
                            progressHandler.Task = "Error.Cancelled";
                        }
                        else if (state == 2)
                        {
                            progressHandler.Task = "Error.NoConnection";
                        }
                        else if (state == 4)
                        {
                            progressHandler.Task = "Error.SteamClosed";
                        }

                        Dispatcher.Invoke(delegate { Task.Complete(); });
                    }
                }
                catch (Exception exx)
                {
                    Console.WriteLine(exx.ToString());
                }
            });

            Close();
            var win4 = new OperationPending("Lang.Windows.OperationPending", "RestoreGameFiles", progressHandler, null, true);
            if (!win4.Completed)
            {
                win4.ShowSubWindow();
            }
            t.Start();
        }

        private void Recheck_Click(object sender, RoutedEventArgs e)
        {
            if (Task.Check())
            {
                Close();
                Task.Complete();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
