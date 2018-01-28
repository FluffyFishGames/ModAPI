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
using System.IO;
using System.Linq;
using ModAPI.Configurations;

namespace ModAPI
{
    public class Debug
    {
        public static string Environment = "global";
        public static bool Verbose = false;

        protected static string LastEnvironment = "";
        protected static FileStream LogStream;
        protected static StreamWriter LogWriter;

        public enum Type
        {
            Notice,
            Warning,
            Error
        }

        public static void Log(string type, string message, Type logType = Type.Notice)
        {
            var logFileName = Configuration.GetPath("Logs") + Path.DirectorySeparatorChar + Environment + ".log";
            if (logFileName.StartsWith("" + Path.DirectorySeparatorChar))
            {
                logFileName = logFileName.Substring(1);
            }
            if (Environment != LastEnvironment || LogStream == null || !LogStream.CanWrite)
            {
                if (LogStream != null)
                {
                    try
                    {
                        LogStream.Close();
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (File.Exists(logFileName))
                {
                    var directory = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
                    if (Path.GetFileName(logFileName) != logFileName)
                    {
                        directory = Path.GetDirectoryName(logFileName) + Path.DirectorySeparatorChar;
                    }
                    var oldLogs = (Directory.GetFiles(directory, Environment + ".*.log")).ToList();
                    oldLogs.Sort();
                    oldLogs.Reverse();
                    foreach (var oldLog in oldLogs)
                    {
                        try
                        {
                            var fileName = Path.GetFileNameWithoutExtension(oldLog);
                            var num = int.Parse(fileName.Substring(Environment.Length + 1));
                            if (num < 5)
                            {
                                File.Move(oldLog, Path.GetDirectoryName(oldLog) + Path.DirectorySeparatorChar + Environment + "." + (num + 1) + ".log");
                            }
                            else
                            {
                                File.Delete(oldLog);
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    File.Move(logFileName, directory + Environment + ".0.log");
                }

                LogStream = new FileStream(logFileName, FileMode.Create, FileAccess.Write, FileShare.Read);
                LogWriter = new StreamWriter(LogStream);
                LastEnvironment = Environment;
            }

            if (LogWriter != null)
            {
                var prefix = "";
                if (logType == Type.Warning)
                {
                    prefix = "WARNING: ";
                }
                if (logType == Type.Error)
                {
                    prefix = "ERROR: ";
                }
                var msg = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] (" + type + "): " + prefix + message;
                if (Verbose)
                {
                    Console.WriteLine(msg);
                }
                LogWriter.WriteLine(msg);
                LogWriter.Flush();
                LogStream.Flush();
            }
        }

        public static void Log(string type, object message, Type logType = Type.Notice)
        {
            Log(type, message.ToString());
        }
    }
}
