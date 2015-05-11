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
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ModAPI.Utils
{
    public class MonoHelper
    {

        public static FieldDefinition CopyField(FieldDefinition field)
        {
            FieldDefinition newField = new FieldDefinition(field.Name, field.Attributes, field.FieldType);
            newField.HasDefault = field.HasDefault;
            if (field.InitialValue != null)
            {
                byte[] arr = new byte[field.InitialValue.Length];
                field.InitialValue.CopyTo(arr, 0);
                newField.InitialValue = arr;
            }
            return newField;
        }

        public static MethodDefinition CopyMethod(MethodDefinition method) 
        {
            MethodDefinition newMethod = new MethodDefinition(method.Name, method.Attributes, method.ReturnType);
            foreach (ParameterDefinition param in method.Parameters) 
            {
                ParameterDefinition newParam = new ParameterDefinition(param.Name, param.Attributes, param.ParameterType);
                newMethod.Parameters.Add(newParam);
            }

            foreach (CustomAttribute attr in method.CustomAttributes)
            {
                CustomAttribute newAttr = new CustomAttribute(attr.Constructor);
                foreach (CustomAttributeArgument arg in attr.ConstructorArguments)
                {
                    CustomAttributeArgument newArg = new CustomAttributeArgument(arg.Type, arg.Value);
                    newAttr.ConstructorArguments.Add(newArg);
                }
                foreach (CustomAttributeNamedArgument arg in attr.Fields)
                {
                    CustomAttributeNamedArgument newArg = new CustomAttributeNamedArgument(arg.Name, new CustomAttributeArgument(arg.Argument.Type, arg.Argument.Value));
                    newAttr.Fields.Add(newArg);
                }
                newMethod.CustomAttributes.Add(newAttr);
            }

            if (method.Body != null) 
            {
                if (newMethod.Body == null)
                    newMethod.Body = new MethodBody(newMethod);
                foreach (Instruction inst in method.Body.Instructions) 
                {
                    newMethod.Body.Instructions.Add(inst);
                }

                foreach (VariableDefinition var in method.Body.Variables) 
                {
                    VariableDefinition newVar = new VariableDefinition(var.Name, var.VariableType);
                    newMethod.Body.Variables.Add(newVar);
                }

                foreach (ExceptionHandler handler in method.Body.ExceptionHandlers)
                {
                    ExceptionHandler newHandler = new ExceptionHandler(handler.HandlerType);
                    newHandler.HandlerStart = handler.HandlerStart;
                    newHandler.HandlerEnd = handler.HandlerEnd;
                    newHandler.TryStart = handler.TryStart;
                    newHandler.TryEnd = handler.TryEnd;
                    newHandler.FilterStart = handler.FilterStart;
                    newHandler.CatchType = handler.CatchType;
                    newMethod.Body.ExceptionHandlers.Add(newHandler);
                }

                newMethod.Body.InitLocals = method.Body.InitLocals;
            }
            return newMethod;
        }

        public static void Remap(
            ModuleDefinition hostModule,
            MethodDefinition method,
            Dictionary<MethodReference, MethodDefinition> NewMethods)
        {
            if (method.Body != null)
            {
                foreach (Instruction instruction in method.Body.Instructions)
                {
                    if (instruction.Operand is MethodReference)
                    {
                        MethodReference methodReference = (MethodReference)instruction.Operand;
                        if (NewMethods.ContainsKey(methodReference))
                            instruction.Operand = (MethodReference)NewMethods[methodReference]; //hostModule.Import(
                    }
                }
            }
        }

        public static void Resolve(
            ModuleDefinition hostModule,
            FieldDefinition field,
            Dictionary<TypeReference, TypeDefinition> AddedClasses,
            Dictionary<TypeReference, TypeReference> TypesMap)
        {
            field.FieldType = Resolve(hostModule, field.FieldType, AddedClasses, TypesMap);
        }

        public static void Resolve(
            ModuleDefinition hostModule,
            MethodDefinition method,
            Dictionary<TypeReference, TypeDefinition> AddedClasses,
            Dictionary<FieldReference, FieldDefinition> AddedFields,
            Dictionary<MethodReference, MethodDefinition> AddedMethods,
            Dictionary<MethodReference, MethodDefinition> InjectedMethods,
            Dictionary<TypeReference, TypeReference> TypesMap)
        {
            
            foreach (CustomAttribute attr in method.CustomAttributes)
            {
                if (attr.Constructor.Module != hostModule)
                    attr.Constructor = hostModule.Import(attr.Constructor);
                for (int i = 0; i < attr.ConstructorArguments.Count; i++)
                {
                    CustomAttributeArgument arg = attr.ConstructorArguments[i];
                    if (arg.Type.Module != hostModule)
                    {
                        attr.ConstructorArguments[i] = new CustomAttributeArgument(hostModule.Import(arg.Type), arg.Value);
                    }
                } 
                for (int i = 0; i < attr.Fields.Count; i++)
                {
                    CustomAttributeNamedArgument arg = attr.Fields[i];
                    if (arg.Argument.Type.Module != hostModule)
                    {
                        attr.Fields[i] = new CustomAttributeNamedArgument(arg.Name, new CustomAttributeArgument(hostModule.Import(arg.Argument.Type), arg.Argument.Value));
                    }
                }
            }
            if (method.Body != null)
            {
                foreach (ExceptionHandler handler in method.Body.ExceptionHandlers)
                {
                    handler.CatchType = Resolve(hostModule, handler.CatchType, AddedClasses, TypesMap);
                }
                foreach (VariableDefinition variable in method.Body.Variables)
                {
                    variable.VariableType = Resolve(hostModule, variable.VariableType, AddedClasses, TypesMap);
                }
                foreach (Instruction instruction in method.Body.Instructions)
                {
                  /* if (instruction.Operand != null)
                        System.Console.WriteLine(instruction.Operand.GetType().FullName);*/

                    if (instruction.Operand is GenericInstanceMethod)
                    {
                        GenericInstanceMethod genericInstance = (GenericInstanceMethod)instruction.Operand;
                        instruction.Operand = Resolve(hostModule, genericInstance, AddedClasses, AddedMethods, TypesMap);
                    }
                    else if (instruction.Operand is MethodReference)
                    {
                        MethodReference methodReference = (MethodReference)instruction.Operand;
                        instruction.Operand = Resolve(hostModule, methodReference, AddedClasses, AddedMethods, TypesMap);
                    }
                    else if (instruction.Operand is TypeReference)
                    {
                        TypeReference typeReference = (TypeReference)instruction.Operand;
                        instruction.Operand = Resolve(hostModule, typeReference, AddedClasses, TypesMap);
                    }
                    else if (instruction.Operand is FieldReference)
                    {
                        FieldReference fieldReference = (FieldReference)instruction.Operand;
                        instruction.Operand = Resolve(hostModule, fieldReference, AddedClasses, AddedFields, TypesMap);
                    }
                    
                }
            }
        }

        protected static TypeReference Resolve(
            ModuleDefinition hostModule,
            TypeReference type,
            Dictionary<TypeReference, TypeDefinition> AddedClasses,
            Dictionary<TypeReference, TypeReference> TypesMap)
        {
            if (type is GenericInstanceType)
            {
                GenericInstanceType gType = (GenericInstanceType)type;
                GenericInstanceType nType = new GenericInstanceType(Resolve(hostModule, gType.ElementType, AddedClasses, TypesMap));
                foreach (TypeReference t in gType.GenericArguments)
                {
                    nType.GenericArguments.Add(Resolve(hostModule, t, AddedClasses, TypesMap));
                }
                return nType;
            }
            if (type == null || type is GenericParameter || (type.IsArray && type.GetElementType() is GenericParameter))
                return type;
            if (TypesMap.ContainsKey(type))
                return hostModule.Import(TypesMap[type]);
            foreach (TypeReference addedType in AddedClasses.Keys)
            {
                if (addedType == type)
                {
                    return hostModule.Import(AddedClasses[addedType]);
                }
            }
            if (type.Module != hostModule)
            {
                TypeDefinition t = hostModule.GetType(type.FullName);
                if (t != null)
                {
                    return (TypeReference)t;
                }
                if (hostModule == null || type == null)
                    return type;
                else
                {
                    try
                    {
                        return hostModule.Import(type);
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine(type.GetElementType());
                        System.Console.WriteLine(type.GetType().FullName);
                        throw e;
                    }
                }
            }
            else
                return type;
                
        }

        protected static FieldReference Resolve(
            ModuleDefinition hostModule,
            FieldReference field,
            Dictionary<TypeReference, TypeDefinition> AddedClasses,
            Dictionary<FieldReference, FieldDefinition> AddedFields,
            Dictionary<TypeReference, TypeReference> TypesMap)
        {
            /*field.FieldType = Resolve(hostModule, field.FieldType, AddedClasses);
            return field;
            */
            foreach (FieldReference addedField in AddedFields.Keys)
            {
                if (addedField.FullName == field.FullName || addedField == field)
                {
                    if (AddedFields[addedField].Module != hostModule)
                        return hostModule.Import(AddedFields[addedField]);
                    else 
                        return AddedFields[addedField]; //hostModule.Import(
                }
            }
            if (field.Module != hostModule)
            {
                TypeDefinition t = hostModule.GetType(field.DeclaringType.FullName);
                if (t != null)
                {
                    foreach (FieldDefinition f in t.Fields)
                    {
                        if (f.FullName == field.FullName)
                        {
                            return (FieldReference)f;
                        }
                    }
                }
                return hostModule.Import(field);
            }
            else
            {
                return field;
            }
        }

        protected static MethodReference Resolve(
            ModuleDefinition hostModule,
            MethodReference method,
            Dictionary<TypeReference, TypeDefinition> AddedClasses,
            Dictionary<MethodReference, MethodDefinition> AddedMethods,
            Dictionary<TypeReference, TypeReference> TypesMap)
        {
            if (AddedMethods.ContainsKey(method))
                return AddedMethods[method]; //hostModule.Import(
            MethodReference newReference = new MethodReference(method.Name, Resolve(hostModule, method.ReturnType, AddedClasses, TypesMap), Resolve(hostModule, method.DeclaringType, AddedClasses, TypesMap));
            
            foreach (GenericParameter generic in method.GenericParameters)
            {
                GenericParameter newGeneric = new GenericParameter(generic.Name, newReference);
                newGeneric.Attributes = generic.Attributes;

                newReference.GenericParameters.Add(newGeneric);
            }
            if (method.ReturnType is GenericParameter)
            {
                GenericParameter g = (GenericParameter)method.ReturnType;
                if (newReference.GenericParameters.Count > g.Position)
                    newReference.ReturnType = newReference.GenericParameters[g.Position];
            }
            foreach (ParameterDefinition parameter in method.Parameters)
                newReference.Parameters.Add(new ParameterDefinition(parameter.Name, parameter.Attributes, Resolve(hostModule, parameter.ParameterType, AddedClasses, TypesMap)));
            newReference.CallingConvention = method.CallingConvention;
            newReference.MethodReturnType.Attributes = method.MethodReturnType.Attributes;
            newReference.HasThis = method.HasThis;
            return newReference;
        }

        protected static GenericInstanceMethod Resolve(
            ModuleDefinition hostModule,
            GenericInstanceMethod method,
            Dictionary<TypeReference, TypeDefinition> AddedClasses,
            Dictionary<MethodReference, MethodDefinition> AddedMethods,
            Dictionary<TypeReference, TypeReference> TypesMap)
        {
            if (AddedMethods.ContainsKey(method))
                return (GenericInstanceMethod)((MethodReference)AddedMethods[method]); //hostModule.Import(
            MethodReference elementMethod = Resolve(hostModule, method.ElementMethod, AddedClasses, AddedMethods, TypesMap);
            GenericInstanceMethod newReference = new GenericInstanceMethod(elementMethod);
  /*          if (method.Name == "Deserialize")
            {
                System.Console.WriteLine(method.Name);
                System.Console.WriteLine(method.GenericArguments.Count);
                System.Console.WriteLine(method.Parameters.Count);
                foreach (ParameterDefinition parameter in method.Parameters)
                    System.Console.WriteLine(parameter.GetType().FullName);
            }*/
            foreach (TypeReference type in method.GenericArguments)
            {
                TypeReference newType = Resolve(hostModule, type, AddedClasses, TypesMap);
                newReference.GenericArguments.Add(newType);
            }
            if (method.ReturnType is GenericParameter)
            {
                GenericParameter g = (GenericParameter)method.ReturnType;

                newReference.ReturnType = elementMethod.GenericParameters[g.Position];
            }
/*            if (method.Name == "Deserialize")
            {
                System.Console.WriteLine(method);
                System.Console.WriteLine(newReference);
            }
            foreach (ParameterDefinition parameter in method.Parameters)
                newReference.Parameters.Add(new ParameterDefinition(parameter.Name, parameter.Attributes, Resolve(hostModule, parameter.ParameterType, AddedClasses, TypesMap)));
            /*
            if (method.Name == "Deserialize")
            {
                System.Console.WriteLine(method);
                System.Console.WriteLine(newReference);
            }*/
            return newReference;
        }

        public static void ParseCustomAttributes(ModAPI.Data.Mod mod, XDocument configuration, MethodDefinition method, Dictionary<string, TypeDefinition> ConfigurationAttributes)
        {
            for (int k = 0; k < method.CustomAttributes.Count; k++)
            {
                CustomAttribute attribute = method.CustomAttributes[k];
                string attrKey = attribute.AttributeType.FullName;
                if (ConfigurationAttributes.ContainsKey(attrKey))
                {
                    TypeDefinition attributeType = ConfigurationAttributes[attrKey];
                    bool valid = true;
                    foreach (TypeReference interfc in attributeType.Interfaces) 
                    {
                        if (interfc.Name == "IStaticAttribute" && !method.IsStatic)
                        {
                            Debug.Log("Modloader: "+mod.Game.GameConfiguration.ID, "Method \"" + method.FullName + "\" is using attribute \"" + method.CustomAttributes[k].AttributeType.FullName + "\" which is only suitable for static methods but isn't marked as static.", Debug.Type.WARNING);
                            valid = false;
                        }
                        if (interfc.Name == "INoParametersAttribute" && method.Parameters.Count > 0)
                        {
                            Debug.Log("Modloader: " + mod.Game.GameConfiguration.ID, "Method \"" + method.FullName + "\" is using attribute \"" + method.CustomAttributes[k].AttributeType.FullName + "\" which is only suitable for methods without parameters but has parameters.", Debug.Type.WARNING);
                            valid = false;
                        }
                    }
                    if (!valid)
                        continue;
                    List<string> Names = new List<string>();
                    if (attribute.ConstructorArguments.Count > 0)
                    {
                        foreach (MethodDefinition m in attributeType.Methods)
                        {
                            if (m.IsConstructor)
                            {
                                foreach (ParameterDefinition p in m.Parameters)
                                {
                                    Names.Add(p.Name);
                                }
                                break;
                            }
                        }
                    }
                    XElement newElement = new XElement(attributeType.Name);
                    for (int i = 0; i < attribute.ConstructorArguments.Count; i++)
                    {
                        CustomAttributeArgument arg = attribute.ConstructorArguments[i];
                        newElement.SetAttributeValue(Names[i], arg.Value);
                    }
                    newElement.Value = method.FullName;
                    newElement.SetAttributeValue("ModID", mod.ID);
                    configuration.Root.Add(newElement);

                    method.CustomAttributes.RemoveAt(k);
                    k--;
                }
            }
        }
    }
}
