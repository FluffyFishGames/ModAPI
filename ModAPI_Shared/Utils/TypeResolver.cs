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
        protected static List<ModuleDefinition> Modules = new List<ModuleDefinition>();

        public static void AddGlobalModule(ModuleDefinition module)
        {
            Modules.Add(module);
        }

        public static void ResetGlobalModules()
        {
            Modules = new List<ModuleDefinition>();
        }

        public static MethodDefinition FindMethodDefinition(ModuleDefinition module, string path, bool global = false)
        {
            var Namespace = "";
            var method = "";
            var type = "";
            var returnType = "";
            var arguments = new string[0];
            NameResolver.Parse(path, ref Namespace, ref type, ref method, ref returnType, ref arguments);

            return GetMethodDefinition(module, Namespace, method, type, returnType, arguments);
        }

        public static MethodReference FindMethodReference(ModuleDefinition module, string path, bool global = false)
        {
            var Namespace = "";
            var method = "";
            var type = "";
            var returnType = "";
            var arguments = new string[0];
            NameResolver.Parse(path, ref Namespace, ref type, ref method, ref returnType, ref arguments);

            return GetMethodReference(module, Namespace, method, type, returnType, arguments);
        }

        public static TypeDefinition FindTypeDefinition(ModuleDefinition module, string path)
        {
            var Namespace = "";
            var Type = "";
            NameResolver.Parse(path, ref Namespace, ref Type);

            var type = GetTypeDefinition(module, Namespace, Type);
            return type;
        }

        public static FieldDefinition FindFieldDefinition(ModuleDefinition module, string path)
        {
            var Namespace = "";
            var type = "";
            var fieldName = "";
            var fieldType = "";
            NameResolver.Parse(path, ref Namespace, ref type, ref fieldName, ref fieldType);

            var field = GetFieldDefinition(module, Namespace, type, fieldName, fieldType);
            return field;
        }

        public static FieldReference FindFieldReference(ModuleDefinition module, string path)
        {
            var Namespace = "";
            var type = "";
            var fieldName = "";
            var fieldType = "";
            NameResolver.Parse(path, ref Namespace, ref type, ref fieldName, ref fieldType);

            var field = GetFieldReference(module, Namespace, type, fieldName, fieldType);
            return field;
        }

        public static TypeReference FindTypeReference(ModuleDefinition module, string path)
        {
            var Namespace = "";
            var Type = "";
            NameResolver.Parse(path, ref Namespace, ref Type);

            var type = GetTypeReference(module, Namespace, Type);
            return type;
        }

        public static TypeDefinition GetTypeDefinition(ModuleDefinition module, string Namespace, string Type)
        {
            var type = module.GetType(Namespace, Type);
            if (type == null)
            {
                foreach (var gmodule in Modules)
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

        public static MethodDefinition GetMethodDefinition(ModuleDefinition module, string Namespace, string Method, string Type, string returnType, string[] arguments, bool global = false)
        {
            var type = module.GetType(Namespace, Type);
            foreach (var method in type.Methods)
            {
                if (Method == method.Name && method.ReturnType.FullName == returnType && method.Parameters.Count == arguments.Length)
                {
                    var ok = true;
                    for (var k = 0; k < method.Parameters.Count; k++)
                    {
                        if (method.Parameters[k].ParameterType.FullName != arguments[k])
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
                foreach (var gmodule in Modules)
                {
                    var m = GetMethodDefinition(gmodule, Namespace, Method, Type, returnType, arguments, true);
                    if (m != null)
                    {
                        return m;
                    }
                }
            }
            return null;
        }

        public static FieldDefinition GetFieldDefinition(ModuleDefinition module, string Namespace, string Type, string fieldName, string fieldType)
        {
            var type = module.GetType(Namespace, Type);

            if (type == null)
            {
                foreach (var gmodule in Modules)
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
                    if (field.Name == fieldName && field.FieldType.FullName == fieldType)
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

        public static MethodReference GetMethodReference(ModuleDefinition module, string Namespace, string method, string type, string returnType, string[] arguments)
        {
            var m = GetMethodDefinition(module, Namespace, method, type, returnType, arguments);
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

        public static FieldReference GetFieldReference(ModuleDefinition module, string Namespace, string type, string fieldName, string fieldType)
        {
            var f = GetFieldDefinition(module, Namespace, type, fieldName, fieldType);
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
