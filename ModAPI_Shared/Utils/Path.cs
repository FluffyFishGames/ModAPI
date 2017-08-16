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
using Microsoft.Win32;
using ModAPI.Configurations;

namespace ModAPI.Utils
{
    public class Path
    {
        protected static IPathParser[] Parsers = { new RegistryParser(), new ConfigurationPathParser() };
        protected static Dictionary<string, string> GlobalVariables = new Dictionary<string, string>();

        public static void SetGlobalVariable(string name, string path)
        {
            if (GlobalVariables.ContainsKey(name))
            {
                GlobalVariables[name] = path;
            }
            else
            {
                GlobalVariables.Add(name, path);
            }
        }

        public static string Parse(string path, string[] variables)
        {
            var varDict = new Dictionary<string, string>();
            foreach (var var in variables)
            {
                var parts = var.Split(new[] { ":" }, StringSplitOptions.None);
                if (parts.Length == 2 && !varDict.ContainsKey(parts[0]))
                {
                    varDict.Add(parts[0], parts[1]);
                }
            }
            return Parse(path, varDict);
        }

        public static string Parse(string path, Dictionary<string, string> variables)
        {
            foreach (var parser in Parsers)
            {
                var identifier = parser.GetIdentifier();
                var index = -1;
                while ((index = path.IndexOf("%$" + identifier)) >= 0)
                {
                    var index1 = index + 2 + identifier.Length + 1;
                    var index2 = path.IndexOf("%", index + 1);
                    var newPath = "";
                    if (index > 0)
                    {
                        newPath = path.Substring(0, index);
                    }
                    newPath += parser.Parse(path.Substring(index1, index2 - index1));
                    newPath += path.Substring(index2 + 1);
                    path = newPath;
                }
            }
            foreach (var kv in variables)
            {
                path = path.Replace("%" + kv.Key + "%", kv.Value);
            }
            foreach (var kv in GlobalVariables)
            {
                path = path.Replace("%" + kv.Key + "%", kv.Value);
            }
            return path;
        }

        public interface IPathParser
        {
            string Parse(string path);
            string GetIdentifier();
        }

        public class RegistryParser : IPathParser
        {
            public string GetIdentifier()
            {
                return "REGISTRY";
            }

            public string Parse(string path)
            {
                var index = path.LastIndexOf("\\");
                return (string) Registry.GetValue(path.Substring(0, index), path.Substring(index + 1), "");
            }
        }

        public class ConfigurationPathParser : IPathParser
        {
            public string GetIdentifier()
            {
                return "PATH";
            }

            public string Parse(string path)
            {
                return Configuration.GetPath(path);
            }
        }
    }
}
