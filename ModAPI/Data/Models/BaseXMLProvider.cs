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
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;
using ModAPI.Utils;

namespace ModAPI.Data.Models
{

    public class XMLParser
    {
        public static XElement GetXML(object thisObj) {

            XElement root = new XElement("Object");
            root.SetAttributeValue("Type", thisObj.GetType().FullName);
            FieldInfo[] fields = thisObj.GetType().GetFields();
            foreach (FieldInfo field in fields)
            {
                object obj = field.GetValue(thisObj);
                if (obj is IXMLProvider)
                {
                    XElement subElement = ((IXMLProvider)obj).GetXML();
                    XAttribute typeAttribute = subElement.Attribute("Type");
                    if (typeAttribute != null)
                        typeAttribute.Remove();
                    subElement.Name = field.Name;
                    root.Add(subElement);
                }
                else if (obj != null)
                {
                    if (obj.GetType().IsArray)
                    {
                        XElement subElement = new XElement(field.Name);
                        object[] objs = (object[])obj;
                        Type elementType = objs.GetType().GetElementType();
                        subElement.SetAttributeValue("Length", objs.Length);
                        foreach (object o in objs)
                        {
                            subElement.Add(ParseItem(o, elementType));
                        }
                        root.Add(subElement);
                    }
                    else if (obj is IList)
                    {
                        IList list = (IList)obj;
                        XElement subElement = new XElement(field.Name);
                        Type elementType = field.FieldType.GetGenericArguments()[0];
                        subElement.SetAttributeValue("Length", list.Count);
                        foreach (object o in list)
                        {
                            subElement.Add(ParseItem(o, elementType));
                        }
                        root.Add(subElement);
                    }
                    else
                    {
                        XElement subElement = new XElement(field.Name, obj.ToString());
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
                    subElement2 = ((IXMLProvider)o).GetXML();
                    subElement2.Name = "Item";
                    XAttribute typeAttribute = subElement2.Attribute("Type");
                    if (typeAttribute != null)
                        typeAttribute.Remove();
                }
                else
                {
                    subElement2 = new XElement("Item", o.ToString());
                }
                if (o.GetType() != elementType)
                    subElement2.SetAttributeValue("Type", o.GetType().FullName);

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
                object newObj = Activator.CreateInstance(elementType);
                ((IXMLProvider)newObj).SetXML(arrayElement);
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
            FieldInfo[] fields = thisObj.GetType().GetFields();
            foreach (FieldInfo field in fields)
            {
                XElement subElement = element.Element(field.Name);
                if (subElement != null)
                {
                    if (field.FieldType.IsArray)
                    {
                        Type elementType = field.FieldType.GetElementType();
                        int arrayLength = XMLHelper.GetXMLAttributeAsInt(subElement, "Length", 0);
                        Array newArray = Array.CreateInstance(elementType, arrayLength);
                        int i = 0;
                        foreach (XElement arrayElement in subElement.Elements())
                        {
                            newArray.SetValue(ReadItem(arrayElement, elementType), i);
                            i++;
                        }
                        field.SetValue(thisObj, newArray);
                    }
                    else if (typeof(IList).IsAssignableFrom(field.FieldType))
                    {
                        Type elementType = field.FieldType.GetGenericArguments()[0];
                        int listLength = XMLHelper.GetXMLAttributeAsInt(subElement, "Length", 0);
                        IList newList = (IList)Activator.CreateInstance(field.FieldType);
                        foreach (XElement listElement in subElement.Elements())
                        {
                            newList.Add(ReadItem(listElement, elementType));
                        }
                        field.SetValue(thisObj, newList);
                    }
                    else if (typeof(IXMLProvider).IsAssignableFrom(field.FieldType))
                    {
                        object newObj = Activator.CreateInstance(field.FieldType);
                        ((IXMLProvider)newObj).SetXML(subElement);
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
        public BaseXMLProvider() { }

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
