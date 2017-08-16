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
            Ok,
            ERROR
        }

        public enum ErrorCode
        {
            FileNotFound,
            MalformedConfiguration,
            Unexpected
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
        protected static Dictionary<string, FieldBuilder> BuildingFields = new Dictionary<string, FieldBuilder>();
        protected static Dictionary<string, List<WaitForType>> WaitForTypeDictionary = new Dictionary<string, List<WaitForType>>();
        protected static Dictionary<string, Action<Type>> TypeParsed = new Dictionary<string, Action<Type>>();
        protected static Dictionary<string, int> TypeWaiting = new Dictionary<string, int>();
        protected static AssemblyBuilder AssemblyBuilder;
        protected static ModuleBuilder ModuleBuilder;

        protected class WaitForType
        {
            protected TypeBuilder NewType;
            protected Type FieldType;
            protected string FieldTypeName;
            protected string FieldName;
            protected string WaitName;
            protected bool IsProperty;

            public WaitForType(TypeBuilder newType, string fieldTypeName, string waitName, string fieldName, bool isProperty = false)
            {
                this.IsProperty = isProperty;
                this.NewType = newType;
                this.FieldTypeName = fieldTypeName;
                this.FieldName = fieldName;
                this.WaitName = waitName;

                if (!DynamicTypes.TypeParsed.ContainsKey(waitName))
                {
                    DynamicTypes.TypeParsed.Add(waitName, TypeParsed);
                }
                if (!WaitForTypeDictionary.ContainsKey(waitName))
                {
                    WaitForTypeDictionary.Add(waitName, new List<WaitForType>());
                }

                WaitForTypeDictionary[waitName].Add(this);
            }

            public void TypeParsed(Type type)
            {
                if (WaitForTypeDictionary.ContainsKey(type.FullName))
                {
                    foreach (var t in WaitForTypeDictionary[type.FullName])
                    {
                        t.Parsed();
                    }
                }
            }

            public void Parsed()
            {
                FieldType = DynamicTypes.GetType(FieldTypeName);
                if (FieldType == null)
                {
                    Debug.Log("DynamicTypes.WaitForType", "Couldn't find type \"" + FieldTypeName + "\".", Debug.Type.Error);
                }
                else
                {
                    if (IsProperty)
                    {
                        if (ParseProperty(NewType, FieldType, FieldTypeName, FieldName))
                        {
                            TypeWaiting[NewType.FullName]--;
                            if (TypeWaiting[NewType.FullName] == 0)
                            {
                                TypeComplete(NewType);
                            }
                        }
                    }
                    else
                    {
                        if (ParseField(NewType, FieldType, FieldTypeName, FieldName))
                        {
                            TypeWaiting[NewType.FullName]--;
                            if (TypeWaiting[NewType.FullName] == 0)
                            {
                                TypeComplete(NewType);
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
                        Debug.Log("DynamicTypes", "GetType wasn't able to resolve type \"" + p[i] + "\" of generic type \"" + type + "\".", Debug.Type.Error);
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
            var className = el.Attribute("Name").Value;
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
                    newType = parentType.DefineNestedType(className, TypeAttributes.NestedPublic | TypeAttributes.Class);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            else
            {
                newType = ModuleBuilder.DefineType(Namespace + className, TypeAttributes.Public | TypeAttributes.Class);
            }

            Type baseType = null;
            if (el.Attribute("Base") != null)
            {
                baseType = GetType(el.Attribute("Base").Value);
            }
            if (baseType == null)
            {
                baseType = typeof(BaseXmlProvider);
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
                    if (!TypeWaiting.ContainsKey(newType.FullName))
                    {
                        TypeWaiting.Add(newType.FullName, 0);
                    }
                    TypeWaiting[newType.FullName]++;
                }
            }

            foreach (var fieldEl in el.Elements("Field"))
            {
                var fieldName = fieldEl.Attribute("Name").Value;
                var typeName = fieldEl.Attribute("Type").Value;
                var fieldType = GetType(typeName);
                if (!ParseField(newType, fieldType, typeName, fieldName))
                {
                    if (!TypeWaiting.ContainsKey(newType.FullName))
                    {
                        TypeWaiting.Add(newType.FullName, 0);
                    }
                    TypeWaiting[newType.FullName]++;
                }
            }

            if (!TypeWaiting.ContainsKey(newType.FullName))
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
            if (TypeParsed.ContainsKey(newType.FullName))
            {
                TypeParsed[newType.FullName](newType);
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
                Debug.Log("DynamicTypes", "Empty field name in type \"" + newType.FullName + "\".", Debug.Type.Warning);
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
                var getterIl = getter.GetILGenerator();
                getterIl.Emit(OpCodes.Ldarg_0);
                getterIl.Emit(OpCodes.Ldfld, field);
                getterIl.Emit(OpCodes.Ret);

                var setter = newType.DefineMethod("set_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, CallingConventions.HasThis,
                    null, new[] { propertyType });
                var setterIl = setter.GetILGenerator();
                setterIl.Emit(OpCodes.Ldarg_0);
                setterIl.Emit(OpCodes.Ldarg_1);
                setterIl.Emit(OpCodes.Stfld, field);
                setterIl.Emit(OpCodes.Ret);

                property.SetGetMethod(getter);
                property.SetSetMethod(setter);

                Debug.Log("DynamicTypes", "Added property \"" + propertyName + "\" of type \"" + propertyType.FullName + "\" to dynamic type \"" + newType.FullName + "\".");
                return true;
            }
            else
            {
                Debug.Log("DynamicTypes", "Empty property name in type \"" + newType.FullName + "\".", Debug.Type.Warning);
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
                    var dynamicClasses = XDocument.Load(fileName);
                    var assemblyName = new AssemblyName("DynamicClasses");
                    AssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
                    ModuleBuilder = AssemblyBuilder.DefineDynamicModule("DynamicClassesModule");
                    progressHandler.Progress = 10f;
                    var classes = dynamicClasses.Root.Elements("Class");
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
                    Error = ErrorCode.MalformedConfiguration;
                    ErrorString = "The dynamic types configuration file is malformed. Exception: " + e;
                    Debug.Log("DynamicTypes", ErrorString, Debug.Type.Error);
                    return ResultCode.ERROR;
                }
                catch (Exception e)
                {
                    Error = ErrorCode.Unexpected;
                    ErrorString = "Unexpected exception while parsing dynamic types: " + e;
                    Debug.Log("DynamicTypes", ErrorString, Debug.Type.Error);
                    return ResultCode.ERROR;
                }
                return ResultCode.Ok;
            }
            Error = ErrorCode.FileNotFound;
            ErrorString = "The dynamic types configuration file \"" + fileName + "\" couldn't be found.";
            Debug.Log("DynamicTypes", ErrorString, Debug.Type.Error);
            return ResultCode.ERROR;
        }
    }
}
