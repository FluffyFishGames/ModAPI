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

using System.Collections.Generic;
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
            var Namespace = "";
            var Method = "";
            var Type = "";
            var ReturnType = "";
            var Arguments = new string[0];
            NameResolver.Parse(Path, ref Namespace, ref Type, ref Method, ref ReturnType, ref Arguments);

            return GetMethodDefinition(module, Namespace, Method, Type, ReturnType, Arguments);
        }

        public static MethodReference FindMethodReference(ModuleDefinition module, string Path, bool global = false)
        {
            var Namespace = "";
            var Method = "";
            var Type = "";
            var ReturnType = "";
            var Arguments = new string[0];
            NameResolver.Parse(Path, ref Namespace, ref Type, ref Method, ref ReturnType, ref Arguments);

            return GetMethodReference(module, Namespace, Method, Type, ReturnType, Arguments);
        }

        public static TypeDefinition FindTypeDefinition(ModuleDefinition module, string Path)
        {
            var Namespace = "";
            var Type = "";
            NameResolver.Parse(Path, ref Namespace, ref Type);

            var type = GetTypeDefinition(module, Namespace, Type);
            return type;
        }

        public static FieldDefinition FindFieldDefinition(ModuleDefinition module, string Path)
        {
            var Namespace = "";
            var Type = "";
            var FieldName = "";
            var FieldType = "";
            NameResolver.Parse(Path, ref Namespace, ref Type, ref FieldName, ref FieldType);

            var field = GetFieldDefinition(module, Namespace, Type, FieldName, FieldType);
            return field;
        }

        public static FieldReference FindFieldReference(ModuleDefinition module, string Path)
        {
            var Namespace = "";
            var Type = "";
            var FieldName = "";
            var FieldType = "";
            NameResolver.Parse(Path, ref Namespace, ref Type, ref FieldName, ref FieldType);

            var field = GetFieldReference(module, Namespace, Type, FieldName, FieldType);
            return field;
        }

        public static TypeReference FindTypeReference(ModuleDefinition module, string Path)
        {
            var Namespace = "";
            var Type = "";
            NameResolver.Parse(Path, ref Namespace, ref Type);

            var type = GetTypeReference(module, Namespace, Type);
            return type;
        }

        public static TypeDefinition GetTypeDefinition(ModuleDefinition module, string Namespace, string Type)
        {
            var type = module.GetType(Namespace, Type);
            if (type == null)
            {
                foreach (var gmodule in modules)
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
            var type = module.GetType(Namespace, Type);
            foreach (var method in type.Methods)
            {
                if (Method == method.Name && method.ReturnType.FullName == ReturnType && method.Parameters.Count == Arguments.Length)
                {
                    var ok = true;
                    for (var k = 0; k < method.Parameters.Count; k++)
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
                foreach (var gmodule in modules)
                {
                    var m = GetMethodDefinition(gmodule, Namespace, Method, Type, ReturnType, Arguments, true);
                    if (m != null)
                    {
                        return m;
                    }
                }
            }
            return null;
        }

        public static FieldDefinition GetFieldDefinition(ModuleDefinition module, string Namespace, string Type, string FieldName, string FieldType)
        {
            var type = module.GetType(Namespace, Type);

            if (type == null)
            {
                foreach (var gmodule in modules)
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
                foreach (var field in type.Fields)
                {
                    if (field.Name == FieldName && field.FieldType.FullName == FieldType)
                    {
                        return field;
                    }
                }
            }
            return null;
        }

        public static TypeReference GetTypeReference(ModuleDefinition module, string Namespace, string Type)
        {
            var type = GetTypeDefinition(module, Namespace, Type);
            if (type == null)
            {
                return null;
            }
            if (type.Module == module)
            {
                return type;
            }
            return module.Import(type);
        }

        public static MethodReference GetMethodReference(ModuleDefinition module, string Namespace, string Method, string Type, string ReturnType, string[] Arguments)
        {
            var m = GetMethodDefinition(module, Namespace, Method, Type, ReturnType, Arguments);
            if (m == null)
            {
                return null;
            }
            if (m.Module == module)
            {
                return m;
            }
            return module.Import(m);
        }

        public static FieldReference GetFieldReference(ModuleDefinition module, string Namespace, string Type, string FieldName, string FieldType)
        {
            var f = GetFieldDefinition(module, Namespace, Type, FieldName, FieldType);
            if (f == null)
            {
                return null;
            }
            if (f.Module == module)
            {
                return f;
            }
            return module.Import(f);
        }
    }
}
