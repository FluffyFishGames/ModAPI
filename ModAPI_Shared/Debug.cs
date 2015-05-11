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
using System.IO;
using ModAPI.Configurations;

namespace ModAPI
{
    public class Debug
    {
        public static string Environment = "global";
        public static bool Verbose = false;

        protected static string lastEnvironment = "";
        protected static FileStream logStream;
        protected static StreamWriter logWriter;
        public enum Type { NOTICE, WARNING, ERROR };

        public static void Log(string type, string message, Type logType = Type.NOTICE)
        {
            string logFileName = Configuration.GetPath("Logs") + Path.DirectorySeparatorChar + Environment+".log";
            if (logFileName.StartsWith(""+Path.DirectorySeparatorChar))
                logFileName = logFileName.Substring(1);
            if (Environment != lastEnvironment || logStream == null || !logStream.CanWrite)
            {
                if (logStream != null)
                {
                    try
                    {
                        logStream.Close();
                    }
                    catch (Exception ex) {}
                }
                if (System.IO.File.Exists(logFileName))
                {
                    string directory = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
                    if (Path.GetFileName(logFileName) != logFileName)
                        directory = Path.GetDirectoryName(logFileName) + Path.DirectorySeparatorChar;
                    List<string> oldLogs = (Directory.GetFiles(directory, Environment + ".*.log")).ToList();
                    oldLogs.Sort();
                    oldLogs.Reverse();
                    foreach (string oldLog in oldLogs)
                    {
                        try
                        {
                            string fileName = Path.GetFileNameWithoutExtension(oldLog);
                            int num = int.Parse(fileName.Substring(Environment.Length + 1));
                            if (num < 5)
                                File.Move(oldLog, Path.GetDirectoryName(oldLog) + Path.DirectorySeparatorChar + Environment + "." + (num + 1) + ".log");
                            else
                                File.Delete(oldLog);
                        }
                        catch (Exception ex) { }
                    }

                    File.Move(logFileName, directory + Environment + ".0.log");
                }
                
                logStream = new FileStream(logFileName, FileMode.Create, FileAccess.Write, FileShare.Read);
                logWriter = new StreamWriter(logStream);
                lastEnvironment = Environment;
            }

            if (logWriter != null)
            {
                string prefix = "";
                if (logType == Type.WARNING)
                    prefix = "WARNING: ";
                if (logType == Type.ERROR)
                    prefix = "ERROR: ";
                string msg = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] (" + type + "): " + prefix + message;
                if (Verbose)
                    System.Console.WriteLine(msg);
                logWriter.WriteLine(msg);
                logWriter.Flush();
                logStream.Flush();
            }
        }

        public static void Log(string type, object message, Type logType = Type.NOTICE)
        {
            Log(type, message.ToString());
        }
    }
}
