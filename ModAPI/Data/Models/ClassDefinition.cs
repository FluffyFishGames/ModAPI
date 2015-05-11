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
using System.Xml.Linq;
using System.Reflection;

namespace ModAPI.Data.Models
{
    public class ClassDefinition
    {
        public string Name = "";
        public Type ClassType;
        public Dictionary<string, string> Extra;
        public Dictionary<string, FieldDefinition> Fields;
        public bool Valid = false;

        public void SetConfiguration(XElement configuration)
        {
            this.Fields = new Dictionary<string, FieldDefinition>();
            Extra = new Dictionary<string,string>();
            foreach (XAttribute attribute in configuration.Attributes()) 
            {
                string name = attribute.Name.LocalName.ToLower();
                if (name == "class")
                    Name = attribute.Value;
                else
                    Extra.Add(name, attribute.Value);
            }

            if (Name == "") 
            {
                Debug.Log("Data.ClassDefinition", "No class is defined in \""+configuration+"\".", Debug.Type.WARNING);
            } 
            else if (!DynamicTypes.Types.ContainsKey(Name)) 
            {
                Debug.Log("Data.ClassDefinition", "Dynamic type \""+Name+"\" couldn't be found.", Debug.Type.WARNING);
            }
            else
            {
                Valid = true;

                ClassType = DynamicTypes.Types[Name];
                List<string> Fields = new List<string>();
                foreach (XElement sub in configuration.Elements()) 
                {
                    string tagName = sub.Name.LocalName.ToLower();
                    if (tagName == "include") 
                    {
                        XAttribute FieldAttribute = sub.Attribute("Field");
                        if (FieldAttribute == null)
                        {
                            Debug.Log("Data.ClassDefinition", "Found invalid include element. Missing Field attribute: "+sub.ToString(), Debug.Type.WARNING);
                        }
                        else 
                        {
                            FieldInfo field = ClassType.GetField(FieldAttribute.Value);
                            if (field == null) 
                            {
                                Debug.Log("Data.ClassDefinition", "Found invalid include element. The field \""+FieldAttribute.Value+"\" is mmissin in class \""+this.Name+"\".", Debug.Type.WARNING);
                            }
                            else 
                            {
                                AddField(field);
                            }
                        }
                    }
                    else if (tagName == "all") 
                    {
                        List<string> Exclude = new List<string>();
                        foreach (XElement sub2 in sub.Elements()) 
                        {
                            string tagName2 = sub2.Name.LocalName.ToLower();
                            if (tagName2 == "exclude") 
                            {
                                XAttribute FieldAttribute = sub2.Attribute("Field");
                                if (FieldAttribute == null) 
                                {
                                    Debug.Log("Data.ClassDefinition", "Found invalid exclude element. Missing Field attribute: "+sub2.ToString(), Debug.Type.WARNING);
                                }
                                else 
                                {
                                    Exclude.Add(FieldAttribute.Value);
                                }
                            } 
                            else 
                            {
                                Debug.Log("Data.ClassDefinition", "Found invalid child element \""+tagName2+"\" for element \""+tagName+"\".", Debug.Type.WARNING);
                            }
                        }
                        string fieldType = "";
                        XAttribute typeAttribute = sub.Attribute("Type");
                        if (typeAttribute != null)
                            fieldType = typeAttribute.Value;

                        FieldInfo[] fields = ClassType.GetFields();
                        foreach (FieldInfo field in fields) 
                        {
                            if (!Exclude.Contains(field.Name) && (fieldType == "" || field.FieldType.FullName == fieldType)) 
                            {
                                AddField(field);
                            }
                        }
                    } 
                    else 
                    {
                        Debug.Log("Data.ClassDefinition", "Found unknown child element \""+tagName+"\".", Debug.Type.WARNING);
                    }
                }
            }
        }

        void AddField(FieldInfo field)
        {
            FieldDefinition newField = new FieldDefinition();
            newField.ClassName = this.Name;
            newField.FieldName = field.Name;
            newField.FieldType = field.FieldType;
            Fields.Add(field.Name, newField);
        }
    }
}
