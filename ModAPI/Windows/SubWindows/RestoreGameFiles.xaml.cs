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

namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class RestoreGameFiles : BaseSubWindow
    {
        protected Utils.Schedule.Task Task;
        public RestoreGameFiles(Utils.Schedule.Task Task)
            : base()
        {
            InitializeComponent();
            this.Task = Task;
            Check();
            SetCloseable(false);
        }

        public RestoreGameFiles(string langKey, Utils.Schedule.Task Task)
            : base(langKey)
        {
            InitializeComponent();
            this.Task = Task;
            Check();
            SetCloseable(false);
        }

        protected void Check()
        {
            NoSteamText.Visibility = System.Windows.Visibility.Collapsed;
            SteamText.Visibility = System.Windows.Visibility.Collapsed;
            NoVersionUpdateText.Visibility = System.Windows.Visibility.Collapsed;
            VersionNotFoundText.Visibility = System.Windows.Visibility.Collapsed;
            ActivateVersionUpdate.Visibility = System.Windows.Visibility.Collapsed;
            ActivateSteam.Visibility = System.Windows.Visibility.Collapsed;
            Restore.Visibility = System.Windows.Visibility.Collapsed;
            Recheck.Visibility = System.Windows.Visibility.Collapsed;

            Close.Visibility = System.Windows.Visibility.Visible;

            if (ModAPI.Configurations.Configuration.GetString("UpdateVersions").ToLower() != "true")
            {
                NoVersionUpdateText.Visibility = System.Windows.Visibility.Visible;
                ActivateVersionUpdate.Visibility = System.Windows.Visibility.Visible;
            }
            else 
            {
                VersionNotFoundText.Visibility = System.Windows.Visibility.Visible;
            }

            if (ModAPI.Configurations.Configuration.GetString("UseSteam").ToLower() != "true")
            {
                NoSteamText.Visibility = System.Windows.Visibility.Visible;
                ActivateSteam.Visibility = System.Windows.Visibility.Visible;
                Recheck.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                Restore.Visibility = System.Windows.Visibility.Visible;
                SteamText.Visibility = System.Windows.Visibility.Visible;
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
                this.Close();
            }
        }


        private void ActivateVersionUpdate_Click(object sender, RoutedEventArgs e)
        {
            Configurations.Configuration.SetString("UpdateVersions", "true", true);
            Configurations.Configuration.Save();
            Close();
            Task.Complete();
        }

        private void ActivateSteam_Click(object sender, RoutedEventArgs e)
        {
            Configurations.Configuration.SetString("UseSteam", "true", true);
            Configurations.Configuration.Save();
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
            ProgressHandler progressHandler = new ProgressHandler();
            progressHandler.OnComplete += (s, ev) => Dispatcher.Invoke((Action) delegate() {
                Task.Complete();
            });
            Thread t = new Thread(delegate() {
                try
                {
                    string steamPath = Configurations.Configuration.GetPath("Steam");
                    Process p = new Process();
                    p.StartInfo.FileName = steamPath + System.IO.Path.DirectorySeparatorChar + "Steam.exe";
                    p.StartInfo.Arguments = "steam://validate/" + App.Game.GameConfiguration.SteamAppID;
                    p.StartInfo.UseShellExecute = false;
                    p.Start();
                    progressHandler.Task = "Restore";
                    progressHandler.Progress = 50f;
                    int state = 0;
                    string lastLine = "";
                    while (true)
                    {
                        Process[] processes = Process.GetProcesses();
                        bool foundSteam = false;
                        foreach (Process pp in processes)
                        {
                            try
                            {
                                if (!pp.HasExited && pp.ProcessName == "Steam")
                                {
                                    foundSteam = true;
                                    break;
                                }
                            }
                            catch (System.Exception ex)
                            {
                            }
                        }

                        string logFile = steamPath + System.IO.Path.DirectorySeparatorChar + "logs" + System.IO.Path.DirectorySeparatorChar + "content_log.txt";
                        System.IO.FileStream s = new System.IO.FileStream(logFile, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
                        System.IO.FileInfo f = new System.IO.FileInfo(logFile);
                        byte[] data = new byte[f.Length];
                        s.Read(data, 0, (int)f.Length);
                        string content = System.Text.Encoding.UTF8.GetString(data);

                        string[] l = content.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);// System.IO.File.ReadAllLines(SteamPath + "\\logs\\content_log.txt");
                        if (lastLine == "")
                            lastLine = l[l.Length - 2];
                        bool check = false;
                        foreach (string n in l)
                        {
                            if (n == lastLine)
                                check = true;
                            if (check)
                            {
                                if (n.EndsWith("AppID " + App.Game.GameConfiguration.SteamAppID + " state changed : Fully Installed,"))
                                    state = 3;
                                else if (n.Contains("AppID " + App.Game.GameConfiguration.SteamAppID) && n.Contains("(Suspended)"))
                                    state = 1;
                                else if (n.Contains("Failed to get list of download sources from any known CS!"))
                                    state = 2;
                            }
                        }

                        if (state == 0 && !foundSteam)
                        {
                            state = 4;
                        }

                        if (state > 0)
                            break;

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
                            progressHandler.Task = "Error.Cancelled";
                        else if (state == 2)
                            progressHandler.Task = "Error.NoConnection";
                        else if (state == 4)
                            progressHandler.Task = "Error.SteamClosed";

                        Dispatcher.Invoke((Action)delegate()
                        {
                            Task.Complete();
                        });
                    }

                }
                catch (Exception exx)
                {
                    System.Console.WriteLine(exx.ToString());
                }
            });

            Close();
            ModAPI.Windows.SubWindows.OperationPending win4 = new ModAPI.Windows.SubWindows.OperationPending("Lang.Windows.OperationPending", "RestoreGameFiles", progressHandler, null, true);
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
