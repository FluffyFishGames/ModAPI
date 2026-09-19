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

namespace Updater
{
    class Updater
    {
        public static string RootPath;
        public static string UpdatePath;

        // 진단용 — 동작 로직은 그대로 두고, ModAPI.exe 재실행이 왜 실패하는지 원인만
        // 파악하기 위해 추가. 원작자 코드(Update()/CopyFiles())는 건드리지 않는다.
        private static void LogDiag(string message)
        {
            try
            {
                File.AppendAllText(
                    Path.Combine(RootPath ?? Path.GetFullPath("."), "Updater.diag.log"),
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}");
            }
            catch (Exception)
            {
                // 로그 기록 자체가 실패해도 무시 — 진단 목적이라 앱 동작에 영향을 주면 안 됨.
            }
        }

        public static void Update()
        {
            RootPath = Path.GetFullPath(".");
            UpdatePath = Path.GetFullPath("_update") + Path.DirectorySeparatorChar;
            LogDiag($"Update() started. RootPath=\"{RootPath}\" UpdatePath=\"{UpdatePath}\"");
            var c = 100;
            while (c > 0)
            {
                Thread.Sleep(500);
                var ps = Process.GetProcesses();
                var breakit = true;
                foreach (var p in ps)
                {
                    try
                    {
                        if (p.ProcessName == "ModAPI")
                        {
                            breakit = false;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                if (breakit)
                {
                    break;
                }
                c--;
            }

            LogDiag($"Wait loop finished. c={c} (0 means ModAPI never exited) | Directory.Exists(UpdatePath)={Directory.Exists(UpdatePath)}");

            if (c > 0 && Directory.Exists(UpdatePath))
            {
                CopyFiles(UpdatePath);
                LogDiag("CopyFiles() completed. Attempting to relaunch ModAPI.exe...");
                try
                {
                    var p = new Process();
                    p.StartInfo.FileName = "ModAPI.exe";
                    p.StartInfo.Verb = "runas";
                    LogDiag($"Process.Start() about to run. Process working directory (Environment.CurrentDirectory)=\"{Environment.CurrentDirectory}\"");
                    p.Start();
                    LogDiag("Process.Start() returned successfully — ModAPI.exe should now be launching.");
                }
                catch (Exception ex)
                {
                    LogDiag("Process.Start() THREW an exception: " + ex);
                }
            }
        }

        static void CopyFiles(string directory, string b = "")
        {
            var files = Directory.GetFiles(directory);
            foreach (var file in files)
            {
                try
                {
                    File.Copy(file, RootPath + Path.DirectorySeparatorChar + b + Path.GetFileName(file), true);
                    File.Delete(file);
                }
                catch (Exception)
                {
                    //System.Console.WriteLine(e);
                }
            }
            var directories = Directory.GetDirectories(directory);
            foreach (var dir in directories)
            {
                CopyFiles(directory + Path.DirectorySeparatorChar + Path.GetFileName(dir), b + Path.DirectorySeparatorChar + Path.GetFileName(dir) + Path.DirectorySeparatorChar);
                Directory.Delete(dir);
            }
        }
    }
}