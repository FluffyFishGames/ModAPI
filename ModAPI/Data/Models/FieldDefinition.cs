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

namespace ModAPI.Data.Models
{
    public class FieldDefinition
    {
        public string ClassName = "";
        public string FieldName = "";
        public Dictionary<string, string> Extra = new Dictionary<string,string>();
        public Type FieldType;
        public XElement Configuration;

        public FieldDefinition()
        {

        }

        public FieldDefinition(string FieldName, Type FieldType)
        {
            this.FieldType = FieldType;
            this.FieldName = FieldName;
        }
        public string GetExtra(string key, string standard)
        {
            if (Extra.ContainsKey(key))
                return Extra[key];
            return standard;
        }

        public void SetExtra(string key, string value)
        {
            if (Extra.ContainsKey(key))
                Extra[key] = value;
            Extra.Add(key, value);
        }

        public void AddConfiguration(XElement element)
        {
            if (this.Configuration != null)
            {
                foreach (XAttribute attribute in element.Attributes())
                {
                    string attributeName = attribute.Name.LocalName.ToLower();
                    if (attributeName != "class" && attributeName != "field" && (element.Name.LocalName.ToLower() != "field" || attributeName != "name"))
                    {
                        Configuration.SetAttributeValue(attribute.Name, attribute.Value);
                        if (Extra.ContainsKey(attributeName))
                            Extra[attributeName] = attribute.Value;
                        else
                            Extra.Add(attributeName, attribute.Value);
                    }
                }
            }
        }

        public void SetConfiguration(XElement element, ClassDefinition cl = null)
        {
            this.Configuration = element;
            Extra = new Dictionary<string,string>();
            foreach (XAttribute attribute in element.Attributes()) 
            {
                if (attribute.Name.LocalName.ToLower() == "class")
                    ClassName = attribute.Value;
                else if (attribute.Name.LocalName.ToLower() == "field")
                    FieldName = attribute.Value;
                else if (attribute.Name.LocalName.ToLower() == "name" && element.Name.LocalName.ToLower()=="field")
                    FieldName = attribute.Value;
                else
                    Extra.Add(attribute.Name.LocalName.ToLower(), attribute.Value);
            }
            if (cl != null)
                ClassName = cl.Name;
            if (ClassName == "" || FieldName == "") 
            {
                Debug.Log("ModAPI.Data", "Invalid FieldDefinition: " + element.ToString(), Debug.Type.WARNING);
            }
        }
    }
}
