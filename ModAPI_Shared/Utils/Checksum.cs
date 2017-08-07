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
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Mono.Cecil;

namespace ModAPI.Utils
{
    public class Checksum
    {
        public static byte[] CreateChecksum(object obj)
        {
            if (obj == null)
            {
                return new byte[0];
            }

            /*List<object> objs = new List<object>();
            string data = GetString(obj, ref objs);*/
            var digest = MD5.Create();
            return digest.ComputeHash(Encoding.UTF8.GetBytes(obj.ToString()));
            //return Encoding.UTF8.GetBytes(data);
            /*BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }*/
        }

        public static byte[] CreateChecksum(TypeDefinition type)
        {
            var data = type.FullName + "|";
            foreach (var method in type.Methods)
            {
                data += method.FullName + "|";
            }
            var digest = MD5.Create();
            return digest.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        public static byte[] CreateChecksum(TypeReference type)
        {
            var data = type.FullName + "|";
            var digest = MD5.Create();
            return digest.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        public static byte[] CreateChecksum(FieldDefinition field)
        {
            var data = field.FullName + "|";
            var digest = MD5.Create();
            return digest.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        public static byte[] CreateChecksum(FieldReference field)
        {
            var data = field.FullName + "|";
            var digest = MD5.Create();
            return digest.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        public static byte[] CreateChecksum(MethodDefinition method)
        {
            var data = method.FullName + "|";
            foreach (var i in method.Body.Instructions)
            {
                data += i + "|";
            }

            var digest = MD5.Create();
            return digest.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        public static byte[] CreateChecksum(MethodReference method)
        {
            var data = method.FullName + "|";
            data += method.ReturnType.FullName + "|";

            var digest = MD5.Create();
            return digest.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        protected static string GetString(object obj, ref List<object> already)
        {
            var data = "";
            try
            {
                if (obj is IEnumerable)
                {
                    var i = (IEnumerable) obj;
                    foreach (var a in i)
                    {
                        if (already.Contains(a))
                        {
                            continue;
                        }
                        already.Add(a);
                        data += GetString(a, ref already) + "|";
                    }
                }
                else if (obj is Enum)
                {
                    data += Enum.GetName(obj.GetType(), obj) + "|";
                }
                else
                {
                    var type = obj.GetType();
                    foreach (var f in type.GetFields())
                    {
                        var k = f.GetValue(obj);
                        if (already.Contains(k))
                        {
                            continue;
                        }
                        already.Add(k);
                        data += GetString(k, ref already) + "|";
                    }
                    foreach (var p in type.GetProperties())
                    {
                        var k = p.GetValue(obj);
                        if (already.Contains(k))
                        {
                            continue;
                        }
                        already.Add(k);
                        data += GetString(k, ref already) + "|";
                    }
                    data += obj + "|";
                }
            }
            catch (Exception e)
            {
                data += "StackOverflow|";
            }
            return data;
        }
    }
}
