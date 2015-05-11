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

namespace ModAPI.Utils
{
    public class NameResolver
    {
        public static void Parse(string input, ref string Namespace, ref string Type)
        {
            string[] parts = input.Split(new string[] { "." }, System.StringSplitOptions.None);
            Namespace = "";
            for (int i = 0; i < parts.Length; i++)
            {
                if (i == parts.Length - 1)
                {
                    Type = parts[i];
                }
                else
                {
                    if (i != 0)
                        Namespace += ".";
                    Namespace += parts[i];
                }
            }
        }

        public static void Parse(string input, ref string Namespace, ref string Type, ref string FieldName, ref string FieldType)
        {
            string[] parts = input.Split(new string[] { " " }, System.StringSplitOptions.None);
            string[] parts2 = parts[1].Split(new string[] { "::" }, System.StringSplitOptions.None);
            string[] parts3 = parts2[0].Split(new string[] { "." }, System.StringSplitOptions.None);
            Namespace = "";
            FieldName = parts2[1];
            FieldType = parts[0];
            for (int i = 0; i < parts3.Length; i++)
            {
                if (i == parts3.Length - 1)
                {
                    Type = parts3[i];
                }
                else
                {
                    if (i != 0)
                        Namespace += ".";
                    Namespace += parts3[i];
                }
            }
        }

        public static void Parse(string input, ref string Namespace, ref string Type, ref string Method, ref string ReturnType, ref string[] Arguments)
        {
            string[] parts = new string[2];
            int k = input.IndexOf(" ");
            parts[0] = input.Substring(0, k);
            parts[1] = input.Substring(k + 1);
            ReturnType = parts[0];
            Namespace = "";

            string[] parts2 = new string[2];
            int ind = parts[1].IndexOf("::");
            parts2[0] = parts[1].Substring(0, ind);
            parts2[1] = parts[1].Substring(ind + 2);
            string[] parts3 = parts2[0].Split(new string[] { "." }, System.StringSplitOptions.RemoveEmptyEntries);

            int index = parts2[1].IndexOf("(");
            Method = parts2[1].Substring(0, index);

            string args = parts2[1].Substring(index + 1, parts2[1].Length - (index + 2));
            List<string> Args = args.Split(new string[] { "," }, System.StringSplitOptions.None).ToList();
            for (int j = 0; j < Args.Count; j++)
            {
                Args[j] = Args[j].Trim();
                if (Args[j] == "")
                {
                    Args.RemoveAt(j);
                    j--;
                }
            }

            Arguments = Args.ToArray();
            
            for (int i = 0; i < parts3.Length; i++)
            {
                if (i == parts3.Length - 1)
                {
                    Type = parts3[i];
                }
                else
                {
                    if (i != 0)
                        Namespace += ".";
                    Namespace += parts3[i];
                }
            }
        }
    }
}
