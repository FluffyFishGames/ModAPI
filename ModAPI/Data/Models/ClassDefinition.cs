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
using System.Reflection;
using System.Xml.Linq;

namespace ModAPI.Data.Models
{
    public class ClassDefinition
    {
        public string Name = "";
        public Type ClassType;
        public Dictionary<string, string> Extra;
        public Dictionary<string, FieldDefinition> Fields;
        public bool Valid;

        public void SetConfiguration(XElement configuration)
        {
            this.Fields = new Dictionary<string, FieldDefinition>();
            Extra = new Dictionary<string, string>();
            foreach (var attribute in configuration.Attributes())
            {
                var name = attribute.Name.LocalName.ToLower();
                if (name == "class")
                {
                    Name = attribute.Value;
                }
                else
                {
                    Extra.Add(name, attribute.Value);
                }
            }

            if (Name == "")
            {
                Debug.Log("Data.ClassDefinition", "No class is defined in \"" + configuration + "\".", Debug.Type.Warning);
            }
            else if (!DynamicTypes.Types.ContainsKey(Name))
            {
                Debug.Log("Data.ClassDefinition", "Dynamic type \"" + Name + "\" couldn't be found.", Debug.Type.Warning);
            }
            else
            {
                Valid = true;

                ClassType = DynamicTypes.Types[Name];
                var Fields = new List<string>();
                foreach (var sub in configuration.Elements())
                {
                    var tagName = sub.Name.LocalName.ToLower();
                    if (tagName == "include")
                    {
                        var fieldAttribute = sub.Attribute("Field");
                        if (fieldAttribute == null)
                        {
                            Debug.Log("Data.ClassDefinition", "Found invalid include element. Missing Field attribute: " + sub, Debug.Type.Warning);
                        }
                        else
                        {
                            var field = ClassType.GetField(fieldAttribute.Value);
                            if (field == null)
                            {
                                Debug.Log("Data.ClassDefinition", "Found invalid include element. The field \"" + fieldAttribute.Value + "\" is mmissin in class \"" + Name + "\".",
                                    Debug.Type.Warning);
                            }
                            else
                            {
                                AddField(field);
                            }
                        }
                    }
                    else if (tagName == "all")
                    {
                        var exclude = new List<string>();
                        foreach (var sub2 in sub.Elements())
                        {
                            var tagName2 = sub2.Name.LocalName.ToLower();
                            if (tagName2 == "exclude")
                            {
                                var fieldAttribute = sub2.Attribute("Field");
                                if (fieldAttribute == null)
                                {
                                    Debug.Log("Data.ClassDefinition", "Found invalid exclude element. Missing Field attribute: " + sub2, Debug.Type.Warning);
                                }
                                else
                                {
                                    exclude.Add(fieldAttribute.Value);
                                }
                            }
                            else
                            {
                                Debug.Log("Data.ClassDefinition", "Found invalid child element \"" + tagName2 + "\" for element \"" + tagName + "\".", Debug.Type.Warning);
                            }
                        }
                        var fieldType = "";
                        var typeAttribute = sub.Attribute("Type");
                        if (typeAttribute != null)
                        {
                            fieldType = typeAttribute.Value;
                        }

                        var fields = ClassType.GetFields();
                        foreach (var field in fields)
                        {
                            if (!exclude.Contains(field.Name) && (fieldType == "" || field.FieldType.FullName == fieldType))
                            {
                                AddField(field);
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("Data.ClassDefinition", "Found unknown child element \"" + tagName + "\".", Debug.Type.Warning);
                    }
                }
            }
        }

        void AddField(FieldInfo field)
        {
            var newField = new FieldDefinition
            {
                ClassName = Name,
                FieldName = field.Name,
                FieldType = field.FieldType
            };
            Fields.Add(field.Name, newField);
        }
    }
}
