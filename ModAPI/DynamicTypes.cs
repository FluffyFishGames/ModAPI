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
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Xml;
using System.Xml.Linq;
using ModAPI.Configurations;
using ModAPI.Data.Models;

namespace ModAPI
{
    public class DynamicTypes
    {
        public static Dictionary<string, Type> Types = new Dictionary<string, Type>();
        public static Dictionary<string, TypeBuilder> BuildingTypes = new Dictionary<string, TypeBuilder>();

        public enum ResultCode
        {
            OK,
            ERROR
        }

        public enum ErrorCode
        {
            FILE_NOT_FOUND,
            MALFORMED_CONFIGURATION,
            UNEXPECTED
        }

        public static ErrorCode Error;
        public static string ErrorString;

        public static object Get(object obj, string fieldName)
        {
            if (obj == null)
            {
                return null;
            }
            var field = obj.GetType().GetField(fieldName);
            if (field == null)
            {
                return null;
            }
            return field.GetValue(obj);
        }

        public static void Set(object obj, string fieldName, object value)
        {
            if (obj == null)
            {
                return;
            }
            var field = obj.GetType().GetField(fieldName);
            if (field == null)
            {
                return;
            }
            field.SetValue(obj, value);
        }

        public static int GetInt(object obj, string fieldName)
        {
            var ret = Get(obj, fieldName);
            if (ret == null)
            {
                return 0;
            }
            return (int) ret;
        }

        protected static Dictionary<string, TypeBuilder> buildingTypes = new Dictionary<string, TypeBuilder>();
        protected static Dictionary<string, FieldBuilder> buildingFields = new Dictionary<string, FieldBuilder>();
        protected static Dictionary<string, List<WaitForType>> waitForType = new Dictionary<string, List<WaitForType>>();
        protected static Dictionary<string, Action<Type>> typeParsed = new Dictionary<string, Action<Type>>();
        protected static Dictionary<string, int> typeWaiting = new Dictionary<string, int>();
        protected static AssemblyBuilder assemblyBuilder;
        protected static ModuleBuilder moduleBuilder;

        protected class WaitForType
        {
            protected TypeBuilder newType;
            protected Type fieldType;
            protected string fieldTypeName;
            protected string fieldName;
            protected string waitName;
            protected bool isProperty;

            public WaitForType(TypeBuilder newType, string fieldTypeName, string waitName, string fieldName, bool isProperty = false)
            {
                this.isProperty = isProperty;
                this.newType = newType;
                this.fieldTypeName = fieldTypeName;
                this.fieldName = fieldName;
                this.waitName = waitName;

                if (!typeParsed.ContainsKey(waitName))
                {
                    typeParsed.Add(waitName, TypeParsed);
                }
                if (!waitForType.ContainsKey(waitName))
                {
                    waitForType.Add(waitName, new List<WaitForType>());
                }

                waitForType[waitName].Add(this);
            }

            public void TypeParsed(Type type)
            {
                if (waitForType.ContainsKey(type.FullName))
                {
                    foreach (var t in waitForType[type.FullName])
                    {
                        t.Parsed();
                    }
                }
            }

            public void Parsed()
            {
                fieldType = DynamicTypes.GetType(fieldTypeName);
                if (fieldType == null)
                {
                    Debug.Log("DynamicTypes.WaitForType", "Couldn't find type \"" + fieldTypeName + "\".", Debug.Type.ERROR);
                }
                else
                {
                    if (isProperty)
                    {
                        if (ParseProperty(newType, fieldType, fieldTypeName, fieldName))
                        {
                            typeWaiting[newType.FullName]--;
                            if (typeWaiting[newType.FullName] == 0)
                            {
                                TypeComplete(newType);
                            }
                        }
                    }
                    else
                    {
                        if (ParseField(newType, fieldType, fieldTypeName, fieldName))
                        {
                            typeWaiting[newType.FullName]--;
                            if (typeWaiting[newType.FullName] == 0)
                            {
                                TypeComplete(newType);
                            }
                        }
                    }
                }
            }
        }

        public static Type GetType(string type, bool typeLookup = true)
        {
            var isArray = false;
            var isGeneric = false;
            var genericTypes = new Type[0];
            var arrayDepth = 0;
            var baseName = type;
            if (type.Contains("`") && type.Contains("[")) //generic type
            {
                var ind = type.IndexOf("`") + 1;
                var ind2 = type.IndexOf("[", ind);
                var genericCount = int.Parse(type.Substring(ind, ind2 - ind));
                var param = type.Substring(ind2 + 1, type.Length - (ind2 + 1) - 1);
                var p = param.Split(new[] { "," }, StringSplitOptions.None);
                genericTypes = new Type[genericCount];
                for (var i = 0; i < genericCount; i++)
                {
                    var gt = GetType(p[i]);
                    if (gt == null)
                    {
                        Debug.Log("DynamicTypes", "GetType wasn't able to resolve type \"" + p[i] + "\" of generic type \"" + type + "\".", Debug.Type.ERROR);
                    }
                    else
                    {
                        genericTypes[i] = gt;
                    }
                }
                isGeneric = true;
                baseName = type.Substring(0, ind2);
            }
            else if (type.Contains("[]")) //array type
            {
                var ind = -1;
                while ((ind = type.IndexOf("[]", ind + 1)) > 0)
                {
                    arrayDepth++;
                }
                isArray = true;
                baseName = type.Substring(0, type.IndexOf("["));
            }

            if (Types.ContainsKey(baseName))
            {
                if (isArray)
                {
                    return Types[baseName].MakeArrayType(arrayDepth);
                }
                if (isGeneric)
                {
                    return Types[baseName].MakeGenericType(genericTypes);
                }
                return Types[baseName];
            }
            if (BuildingTypes.ContainsKey(baseName))
            {
                if (isArray)
                {
                    return BuildingTypes[baseName].MakeArrayType(arrayDepth);
                }
                if (isGeneric)
                {
                    return BuildingTypes[baseName].MakeGenericType(genericTypes);
                }
                return BuildingTypes[baseName];
            }
            if (typeLookup)
            {
                try
                {
                    var t = Type.GetType(
                        baseName,
                        name => { return AppDomain.CurrentDomain.GetAssemblies().Where(z => z.FullName == name.FullName).FirstOrDefault(); },
                        (assembly, typeName, typeBool) =>
                        {
                            var _t = GetType(typeName, false);
                            if (_t == null)
                            {
                                _t = Type.GetType(typeName);
                            }
                            return _t;
                        },
                        false);

                    if (isArray)
                    {
                        return t.MakeArrayType(arrayDepth);
                    }
                    if (isGeneric)
                    {
                        return t.MakeGenericType(genericTypes);
                    }
                    return t;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
            return null;
        }

        protected static void ParseClass(XElement el, TypeBuilder parentType = null)
        {
            var ClassName = el.Attribute("Name").Value;
            var Namespace = "";
            if (el.Attribute("Namespace") != null)
            {
                Namespace = el.Attribute("Namespace").Value;
            }

            if (Namespace.Length > 0 && !Namespace.EndsWith("."))
            {
                Namespace += ".";
            }

            TypeBuilder newType = null;
            if (parentType != null)
            {
                try
                {
                    newType = parentType.DefineNestedType(ClassName, TypeAttributes.NestedPublic | TypeAttributes.Class);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            else
            {
                newType = moduleBuilder.DefineType(Namespace + ClassName, TypeAttributes.Public | TypeAttributes.Class);
            }

            Type baseType = null;
            if (el.Attribute("Base") != null)
            {
                baseType = GetType(el.Attribute("Base").Value);
            }
            if (baseType == null)
            {
                baseType = typeof(BaseXMLProvider);
            }
            newType.SetParent(baseType);
            Debug.Log("DynamicTypes", "Parsing dynamic type \"" + newType.FullName + "\".");
            BuildingTypes.Add(newType.FullName, newType);
            foreach (var subClass in el.Elements("Class"))
            {
                ParseClass(subClass, newType);
            }

            foreach (var propertyEl in el.Elements("Property"))
            {
                var propertyName = propertyEl.Attribute("Name").Value;
                var typeName = propertyEl.Attribute("Type").Value;
                var propertyType = GetType(typeName);
                if (!ParseProperty(newType, propertyType, typeName, propertyName))
                {
                    if (!typeWaiting.ContainsKey(newType.FullName))
                    {
                        typeWaiting.Add(newType.FullName, 0);
                    }
                    typeWaiting[newType.FullName]++;
                }
            }

            foreach (var fieldEl in el.Elements("Field"))
            {
                var fieldName = fieldEl.Attribute("Name").Value;
                var typeName = fieldEl.Attribute("Type").Value;
                var fieldType = GetType(typeName);
                if (!ParseField(newType, fieldType, typeName, fieldName))
                {
                    if (!typeWaiting.ContainsKey(newType.FullName))
                    {
                        typeWaiting.Add(newType.FullName, 0);
                    }
                    typeWaiting[newType.FullName]++;
                }
            }

            if (!typeWaiting.ContainsKey(newType.FullName))
            {
                TypeComplete(newType);
            }
            else
            {
                Debug.Log("DynamicTypes", "Dynamic type \"" + newType.FullName + "\" is waiting for completion.");
            }
        }

        protected static void TypeComplete(TypeBuilder newType)
        {
            if (typeParsed.ContainsKey(newType.FullName))
            {
                typeParsed[newType.FullName](newType);
            }
            Debug.Log("DynamicTypes", "Successfully parsed dynamic type \"" + newType.FullName + "\".");
        }

        protected static bool ParseField(TypeBuilder newType, Type fieldType, string fieldTypeName, string fieldName)
        {
            if (fieldType == null)
            {
                var waitingType = fieldTypeName.Replace("System.Collections.Generic.List`1", "").Replace("]", "").Replace("[", "");
                Debug.Log("DynamicTypes", "Couldn't find field type \"" + fieldTypeName + "\". Waiting for dynamic generation of \"" + waitingType + "\".");
                new WaitForType(newType, fieldTypeName, waitingType, fieldName);
            }
            else if (fieldName != "")
            {
                var field = newType.DefineField(fieldName, fieldType, FieldAttributes.Public);
                Debug.Log("DynamicTypes", "Added field \"" + fieldName + "\" of type \"" + fieldType.FullName + "\" to dynamic type \"" + newType.FullName + "\".");
                return true;
            }
            else
            {
                Debug.Log("DynamicTypes", "Empty field name in type \"" + newType.FullName + "\".", Debug.Type.WARNING);
            }
            return false;
        }

        protected static bool ParseProperty(TypeBuilder newType, Type propertyType, string propertyTypeName, string propertyName)
        {
            if (propertyType == null)
            {
                var waitingType = propertyTypeName.Replace("System.Collections.Generic.List`1", "").Replace("]", "").Replace("[", "");
                Debug.Log("DynamicTypes", "Couldn't find property type \"" + propertyTypeName + "\". Waiting for dynamic generation of \"" + waitingType + "\".");
                new WaitForType(newType, propertyTypeName, waitingType, propertyName, true);
            }
            else if (propertyName != "")
            {
                var property = newType.DefineProperty(propertyName, PropertyAttributes.None, propertyType, null);
                var field = newType.DefineField("__" + propertyName, propertyType, FieldAttributes.Public);

                var getter = newType.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, CallingConventions.HasThis,
                    propertyType, Type.EmptyTypes);
                var getterIL = getter.GetILGenerator();
                getterIL.Emit(OpCodes.Ldarg_0);
                getterIL.Emit(OpCodes.Ldfld, field);
                getterIL.Emit(OpCodes.Ret);

                var setter = newType.DefineMethod("set_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, CallingConventions.HasThis,
                    null, new[] { propertyType });
                var setterIL = setter.GetILGenerator();
                setterIL.Emit(OpCodes.Ldarg_0);
                setterIL.Emit(OpCodes.Ldarg_1);
                setterIL.Emit(OpCodes.Stfld, field);
                setterIL.Emit(OpCodes.Ret);

                property.SetGetMethod(getter);
                property.SetSetMethod(setter);

                Debug.Log("DynamicTypes", "Added property \"" + propertyName + "\" of type \"" + propertyType.FullName + "\" to dynamic type \"" + newType.FullName + "\".");
                return true;
            }
            else
            {
                Debug.Log("DynamicTypes", "Empty property name in type \"" + newType.FullName + "\".", Debug.Type.WARNING);
            }
            return false;
        }

        public static ResultCode Load(ProgressHandler progressHandler)
        {
            var fileName = Path.GetFullPath(Configuration.GetPath("GameConfigurations") + Path.DirectorySeparatorChar + Configuration.CurrentGame + Path.DirectorySeparatorChar +
                                            "DynamicClasses.xml");
            if (File.Exists(fileName))
            {
                try
                {
                    var DynamicClasses = XDocument.Load(fileName);
                    var assemblyName = new AssemblyName("DynamicClasses");
                    assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
                    moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicClassesModule");
                    progressHandler.Progress = 10f;
                    var classes = DynamicClasses.Root.Elements("Class");
                    float count = classes.Count();
                    var done = 0f;
                    foreach (var el in classes)
                    {
                        ParseClass(el);
                        done += 1f;
                        progressHandler.Progress = 10f + (done / count) * 89f;
                    }

                    foreach (var builder in BuildingTypes.Values)
                    {
                        var t = builder.CreateType();
                        Types.Add(t.FullName, t);
                        Debug.Log("DynamicTypes", "Successfully created dynamic type \"" + t.FullName + "\".");
                    }
                    progressHandler.Progress = 100f;
                }
                catch (XmlException e)
                {
                    Error = ErrorCode.MALFORMED_CONFIGURATION;
                    ErrorString = "The dynamic types configuration file is malformed. Exception: " + e;
                    Debug.Log("DynamicTypes", ErrorString, Debug.Type.ERROR);
                    return ResultCode.ERROR;
                }
                catch (Exception e)
                {
                    Error = ErrorCode.UNEXPECTED;
                    ErrorString = "Unexpected exception while parsing dynamic types: " + e;
                    Debug.Log("DynamicTypes", ErrorString, Debug.Type.ERROR);
                    return ResultCode.ERROR;
                }
                return ResultCode.OK;
            }
            Error = ErrorCode.FILE_NOT_FOUND;
            ErrorString = "The dynamic types configuration file \"" + fileName + "\" couldn't be found.";
            Debug.Log("DynamicTypes", ErrorString, Debug.Type.ERROR);
            return ResultCode.ERROR;
        }
    }
}
