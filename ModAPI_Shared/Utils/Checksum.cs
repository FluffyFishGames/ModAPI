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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.IO;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Security.Cryptography;

namespace ModAPI.Utils
{
    public class Checksum
    {
        public static byte[] CreateChecksum(object obj)
        {
            if (obj == null)
                return new byte[0];

            /*List<object> objs = new List<object>();
            string data = GetString(obj, ref objs);*/
            MD5 digest = MD5.Create();
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
            string data = type.FullName + "|";
            foreach (MethodDefinition method in type.Methods)
            {
                data += method.FullName + "|";
            }
            MD5 digest = MD5.Create();
            return digest.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        public static byte[] CreateChecksum(TypeReference type)
        {
            string data = type.FullName + "|";
            MD5 digest = MD5.Create();
            return digest.ComputeHash(Encoding.UTF8.GetBytes(data));
        }
        
        
        public static byte[] CreateChecksum(FieldDefinition field)
        {
            string data = field.FullName + "|";
            MD5 digest = MD5.Create();
            return digest.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        public static byte[] CreateChecksum(FieldReference field)
        {
            string data = field.FullName + "|";
            MD5 digest = MD5.Create();
            return digest.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        public static byte[] CreateChecksum(MethodDefinition method)
        {
            string data = method.FullName + "|";
            foreach (Instruction i in method.Body.Instructions)
            {
                data += i.ToString() + "|";
            }

            MD5 digest = MD5.Create();
            return digest.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        public static byte[] CreateChecksum(MethodReference method)
        {
            string data = method.FullName + "|";
            data += method.ReturnType.FullName + "|";

            MD5 digest = MD5.Create();
            return digest.ComputeHash(Encoding.UTF8.GetBytes(data));
        }
        protected static string GetString(object obj, ref List<object> already)
        {
            string data = "";
            try
            {
                if (obj is IEnumerable)
                {
                    IEnumerable i = (IEnumerable)obj;
                    foreach (object a in i)
                    {
                        if (already.Contains(a))
                            continue;
                        already.Add(a);
                        data += GetString(a,ref already) + "|";
                    }
                }
                else if (obj is Enum)
                {
                    data += Enum.GetName(obj.GetType(), obj) + "|";
                }
                else
                {
                    Type type = obj.GetType();
                    foreach (FieldInfo f in type.GetFields())
                    {
                        object k = f.GetValue(obj);
                        if (already.Contains(k))
                            continue;
                        already.Add(k);
                        data += GetString(k,ref already) + "|";
                    }
                    foreach (PropertyInfo p in type.GetProperties())
                    {
                        object k = p.GetValue(obj);
                        if (already.Contains(k))
                            continue;
                        already.Add(k);
                        data += GetString(k,ref already) + "|";
                    }
                    data += obj.ToString() + "|";
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
