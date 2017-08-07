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
using System.Reflection;

namespace ModAPI
{
    class AssemblyResolver
    {
        protected static bool Initialized;

        public static void Initialize()
        {
            if (!Initialized)
            {
                Initialized = true;

                AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
                {
                    try
                    {
                        var filename = new AssemblyName(e.Name).Name;
                        var path = Path.GetFullPath("." + Path.DirectorySeparatorChar + "libs" + Path.DirectorySeparatorChar + filename + ".dll");
                        path.Replace("file:///", "");
                        if (!File.Exists(path))
                        {
                            path = Path.GetFullPath("." + Path.DirectorySeparatorChar + "libs" + Path.DirectorySeparatorChar + filename);
                            path.Replace("file:///", "");
                        }
                        if (File.Exists(path))
                        {
                            return Assembly.LoadFrom(path);
                        }
                        return null;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                };
            }
        }
    }
}
