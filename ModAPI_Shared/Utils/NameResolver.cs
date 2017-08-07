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
using System.Linq;

namespace ModAPI.Utils
{
    public class NameResolver
    {
        public static void Parse(string input, ref string Namespace, ref string Type)
        {
            var parts = input.Split(new[] { "." }, StringSplitOptions.None);
            Namespace = "";
            for (var i = 0; i < parts.Length; i++)
            {
                if (i == parts.Length - 1)
                {
                    Type = parts[i];
                }
                else
                {
                    if (i != 0)
                    {
                        Namespace += ".";
                    }
                    Namespace += parts[i];
                }
            }
        }

        public static void Parse(string input, ref string Namespace, ref string Type, ref string FieldName, ref string FieldType)
        {
            var parts = input.Split(new[] { " " }, StringSplitOptions.None);
            var parts2 = parts[1].Split(new[] { "::" }, StringSplitOptions.None);
            var parts3 = parts2[0].Split(new[] { "." }, StringSplitOptions.None);
            Namespace = "";
            FieldName = parts2[1];
            FieldType = parts[0];
            for (var i = 0; i < parts3.Length; i++)
            {
                if (i == parts3.Length - 1)
                {
                    Type = parts3[i];
                }
                else
                {
                    if (i != 0)
                    {
                        Namespace += ".";
                    }
                    Namespace += parts3[i];
                }
            }
        }

        public static void Parse(string input, ref string Namespace, ref string Type, ref string Method, ref string ReturnType, ref string[] Arguments)
        {
            var parts = new string[2];
            var k = input.IndexOf(" ");
            parts[0] = input.Substring(0, k);
            parts[1] = input.Substring(k + 1);
            ReturnType = parts[0];
            Namespace = "";

            var parts2 = new string[2];
            var ind = parts[1].IndexOf("::");
            parts2[0] = parts[1].Substring(0, ind);
            parts2[1] = parts[1].Substring(ind + 2);
            var parts3 = parts2[0].Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);

            var index = parts2[1].IndexOf("(");
            Method = parts2[1].Substring(0, index);

            var args = parts2[1].Substring(index + 1, parts2[1].Length - (index + 2));
            var Args = args.Split(new[] { "," }, StringSplitOptions.None).ToList();
            for (var j = 0; j < Args.Count; j++)
            {
                Args[j] = Args[j].Trim();
                if (Args[j] == "")
                {
                    Args.RemoveAt(j);
                    j--;
                }
            }

            Arguments = Args.ToArray();

            for (var i = 0; i < parts3.Length; i++)
            {
                if (i == parts3.Length - 1)
                {
                    Type = parts3[i];
                }
                else
                {
                    if (i != 0)
                    {
                        Namespace += ".";
                    }
                    Namespace += parts3[i];
                }
            }
        }
    }
}
