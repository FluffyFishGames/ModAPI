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
using Mono.Cecil;

namespace ModAPI.Utils
{
    public class TypeResolver
    {
        protected static List<ModuleDefinition> modules = new List<ModuleDefinition>();
        public static void AddGlobalModule(ModuleDefinition module) 
        {
            modules.Add(module);
        }

        public static void ResetGlobalModules() 
        {
            modules = new List<ModuleDefinition>();
        }

        public static MethodDefinition FindMethodDefinition(ModuleDefinition module, string Path, bool global = false)
        {
            string Namespace = "";
            string Method = "";
            string Type = "";
            string ReturnType = "";
            string[] Arguments = new string[0];
            Utils.NameResolver.Parse(Path, ref Namespace, ref Type, ref Method, ref ReturnType, ref Arguments);

            return GetMethodDefinition(module, Namespace, Method, Type, ReturnType, Arguments);
        }

        public static MethodReference FindMethodReference(ModuleDefinition module, string Path, bool global = false)
        {
            string Namespace = "";
            string Method = "";
            string Type = "";
            string ReturnType = "";
            string[] Arguments = new string[0];
            Utils.NameResolver.Parse(Path, ref Namespace, ref Type, ref Method, ref ReturnType, ref Arguments);

            return GetMethodReference(module, Namespace, Method, Type, ReturnType, Arguments);
        }

        public static TypeDefinition FindTypeDefinition(ModuleDefinition module, string Path)
        {
            string Namespace = "";
            string Type = "";
            Utils.NameResolver.Parse(Path, ref Namespace, ref Type);

            TypeDefinition type = GetTypeDefinition(module, Namespace, Type);
            return type;
        }

        public static FieldDefinition FindFieldDefinition(ModuleDefinition module, string Path)
        {
            string Namespace = "";
            string Type = "";
            string FieldName = "";
            string FieldType = "";
            Utils.NameResolver.Parse(Path, ref Namespace, ref Type, ref FieldName, ref FieldType);

            FieldDefinition field = GetFieldDefinition(module, Namespace, Type, FieldName, FieldType);
            return field;
        }

        public static FieldReference FindFieldReference(ModuleDefinition module, string Path)
        {
            string Namespace = "";
            string Type = "";
            string FieldName = "";
            string FieldType = "";
            Utils.NameResolver.Parse(Path, ref Namespace, ref Type, ref FieldName, ref FieldType);

            FieldReference field = GetFieldReference(module, Namespace, Type, FieldName, FieldType);
            return field;
        }

        public static TypeReference FindTypeReference(ModuleDefinition module, string Path)
        {
            string Namespace = "";
            string Type = "";
            Utils.NameResolver.Parse(Path, ref Namespace, ref Type);

            TypeReference type = GetTypeReference(module, Namespace, Type);
            return type;
        }

        public static TypeDefinition GetTypeDefinition(ModuleDefinition module, string Namespace, string Type)
        {
            TypeDefinition type = module.GetType(Namespace, Type);
            if (type == null)
            {
                foreach (ModuleDefinition gmodule in modules)
                {
                    type = GetTypeDefinition(gmodule, Namespace, Type);
                    if (type != null)
                    {
                        return type;
                    }
                }
            }
            return type;
        }

        public static MethodDefinition GetMethodDefinition(ModuleDefinition module, string Namespace, string Method, string Type, string ReturnType, string[] Arguments, bool global = false)
        {
            TypeDefinition type = module.GetType(Namespace, Type);
            foreach (MethodDefinition method in type.Methods)
            {

                if (Method == method.Name && method.ReturnType.FullName == ReturnType && method.Parameters.Count == Arguments.Length)
                {
                    bool ok = true;
                    for (int k = 0; k < method.Parameters.Count; k++)
                    {
                        if (method.Parameters[k].ParameterType.FullName != Arguments[k])
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok)
                    {
                        return method;
                    }
                }
            }
            if (!global)
            {
                foreach (ModuleDefinition gmodule in modules)
                {
                    MethodDefinition m = GetMethodDefinition(gmodule, Namespace, Method, Type, ReturnType, Arguments, true);
                    if (m != null)
                        return m;
                }
            }
            return null;
        }

        public static FieldDefinition GetFieldDefinition(ModuleDefinition module, string Namespace, string Type, string FieldName, string FieldType)
        {
            TypeDefinition type = module.GetType(Namespace, Type);
            
            if (type == null)
            {
                foreach (ModuleDefinition gmodule in modules)
                {
                    type = GetTypeDefinition(gmodule, Namespace, Type);
                    if (type != null)
                    {
                        break;
                        //return type;
                    }
                }
            }
            if (type != null)
            {
                foreach (FieldDefinition field in type.Fields)
                {
                    if (field.Name == FieldName && field.FieldType.FullName == FieldType)
                        return field;
                }
            }
            return null;
        }

        public static TypeReference GetTypeReference(ModuleDefinition module, string Namespace, string Type)
        {
            TypeDefinition type = GetTypeDefinition(module, Namespace, Type);
            if (type == null) return null;
            if (type.Module == module)
            {
                return (TypeReference)type;
            }
            else
            {
                return module.Import(type);
            }
        }

        public static MethodReference GetMethodReference(ModuleDefinition module, string Namespace, string Method, string Type, string ReturnType, string[] Arguments)
        {
            MethodDefinition m = GetMethodDefinition(module, Namespace, Method, Type, ReturnType, Arguments);
            if (m == null)
                return null;
            else
            {
                if (m.Module == module)
                    return (MethodReference)m;
                else
                    return module.Import(m);
            }
        }

        public static FieldReference GetFieldReference(ModuleDefinition module, string Namespace, string Type, string FieldName, string FieldType)
        {
            FieldDefinition f = GetFieldDefinition(module, Namespace, Type, FieldName, FieldType);
            if (f == null)
                return null;
            else
            {
                if (f.Module == module)
                    return (FieldReference)f;
                else
                    return module.Import(f);
            }
        }
    }
}
