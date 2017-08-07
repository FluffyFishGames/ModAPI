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
using System.IO;
using System.Text;
using ModAPI.Attributes;

namespace ModAPI
{
    public class Log
    {
        protected static Dictionary<string, FileStream> FileStreams = new Dictionary<string, FileStream>();

        [AddModname]
        public static void Write(string a)
        {
        }

        [AddModname]
        public static void Write(object a)
        {
        }

        internal static void Write(object a, string ModName)
        {
            if (a != null)
            {
                Write(a.ToString(), ModName);
            }
            else
            {
                Write("null", ModName);
            }
        }

        internal static void Write(string s, string ModName)
        {
            var currentDir = Path.GetFullPath(BaseSystem.ModsFolder + "Logs" + Path.DirectorySeparatorChar);
            if (!Directory.Exists(currentDir))
            {
                Directory.CreateDirectory(currentDir);
            }

            if (!FileStreams.ContainsKey(ModName))
            {
                var fileName = currentDir + ModName + ".log";
                FileStreams.Add(ModName, new FileStream(fileName, FileMode.Create));
            }
            var w = Encoding.UTF8.GetBytes("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "] " + s + "\r\n");
            FileStreams[ModName].Write(w, 0, w.Length);
            FileStreams[ModName].Flush();
        }
    }
}
