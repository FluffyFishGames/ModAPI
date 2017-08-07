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
using System.Xml.Linq;
using ModAPI.Utils;

namespace ModAPI.Data.Models
{
    public class XMLParser
    {
        public static XElement GetXML(object thisObj)
        {
            var root = new XElement("Object");
            root.SetAttributeValue("Type", thisObj.GetType().FullName);
            var fields = thisObj.GetType().GetFields();
            foreach (var field in fields)
            {
                var obj = field.GetValue(thisObj);
                if (obj is IXMLProvider)
                {
                    var subElement = ((IXMLProvider) obj).GetXML();
                    var typeAttribute = subElement.Attribute("Type");
                    if (typeAttribute != null)
                    {
                        typeAttribute.Remove();
                    }
                    subElement.Name = field.Name;
                    root.Add(subElement);
                }
                else if (obj != null)
                {
                    if (obj.GetType().IsArray)
                    {
                        var subElement = new XElement(field.Name);
                        var objs = (object[]) obj;
                        var elementType = objs.GetType().GetElementType();
                        subElement.SetAttributeValue("Length", objs.Length);
                        foreach (var o in objs)
                        {
                            subElement.Add(ParseItem(o, elementType));
                        }
                        root.Add(subElement);
                    }
                    else if (obj is IList)
                    {
                        var list = (IList) obj;
                        var subElement = new XElement(field.Name);
                        var elementType = field.FieldType.GetGenericArguments()[0];
                        subElement.SetAttributeValue("Length", list.Count);
                        foreach (var o in list)
                        {
                            subElement.Add(ParseItem(o, elementType));
                        }
                        root.Add(subElement);
                    }
                    else
                    {
                        var subElement = new XElement(field.Name, obj.ToString());
                        root.Add(subElement);
                    }
                }
            }
            return root;
        }

        protected static XElement ParseItem(object o, Type elementType)
        {
            XElement subElement2 = null;
            if (o != null)
            {
                if (o is IXMLProvider)
                {
                    subElement2 = ((IXMLProvider) o).GetXML();
                    subElement2.Name = "Item";
                    var typeAttribute = subElement2.Attribute("Type");
                    if (typeAttribute != null)
                    {
                        typeAttribute.Remove();
                    }
                }
                else
                {
                    subElement2 = new XElement("Item", o.ToString());
                }
                if (o.GetType() != elementType)
                {
                    subElement2.SetAttributeValue("Type", o.GetType().FullName);
                }
            }
            else
            {
                subElement2 = new XElement("Item", "null");
            }
            return subElement2;
        }

        public static object ReadItem(XElement arrayElement, Type elementType)
        {
            object ret = null;
            if (typeof(IXMLProvider).IsAssignableFrom(elementType))
            {
                var newObj = Activator.CreateInstance(elementType);
                ((IXMLProvider) newObj).SetXML(arrayElement);
                ret = newObj;
            }
            else
            {
                ret = Convert.ChangeType(arrayElement.Value, elementType);
            }
            return ret;
        }

        public static void SetXML(object thisObj, XElement element)
        {
            var fields = thisObj.GetType().GetFields();
            foreach (var field in fields)
            {
                var subElement = element.Element(field.Name);
                if (subElement != null)
                {
                    if (field.FieldType.IsArray)
                    {
                        var elementType = field.FieldType.GetElementType();
                        var arrayLength = XMLHelper.GetXMLAttributeAsInt(subElement, "Length", 0);
                        var newArray = Array.CreateInstance(elementType, arrayLength);
                        var i = 0;
                        foreach (var arrayElement in subElement.Elements())
                        {
                            newArray.SetValue(ReadItem(arrayElement, elementType), i);
                            i++;
                        }
                        field.SetValue(thisObj, newArray);
                    }
                    else if (typeof(IList).IsAssignableFrom(field.FieldType))
                    {
                        var elementType = field.FieldType.GetGenericArguments()[0];
                        var listLength = XMLHelper.GetXMLAttributeAsInt(subElement, "Length", 0);
                        var newList = (IList) Activator.CreateInstance(field.FieldType);
                        foreach (var listElement in subElement.Elements())
                        {
                            newList.Add(ReadItem(listElement, elementType));
                        }
                        field.SetValue(thisObj, newList);
                    }
                    else if (typeof(IXMLProvider).IsAssignableFrom(field.FieldType))
                    {
                        var newObj = Activator.CreateInstance(field.FieldType);
                        ((IXMLProvider) newObj).SetXML(subElement);
                        field.SetValue(thisObj, newObj);
                    }
                    else
                    {
                        field.SetValue(thisObj, Convert.ChangeType(subElement.Value, field.FieldType));
                    }
                }
            }
        }
    }

    public class BaseXMLProvider : IXMLProvider
    {
        public virtual XElement GetXML()
        {
            return XMLParser.GetXML(this);
        }

        public virtual void SetXML(XElement element)
        {
            XMLParser.SetXML(this, element);
        }
    }
}
