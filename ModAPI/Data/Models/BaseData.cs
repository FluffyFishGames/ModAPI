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
using System.Xml.Linq;

namespace ModAPI.Data.Models
{
    public class BaseData : ISaveableData
    {
        public Dictionary<string, ClassDefinition> Classes;
        public List<FieldDefinition> Fields;
        public Dictionary<int, DataField> Data = new Dictionary<int, DataField>();
        public Dictionary<int, double> Offset = new Dictionary<int, double>();

        public void SetOffset(int fieldNum, double offset)
        {
            if (Offset.ContainsKey(fieldNum))
            {
                Offset[fieldNum] = offset;
            }
            else
            {
                Offset.Add(fieldNum, offset);
            }
        }

        public virtual FieldDefinition GetField(FieldDefinition f)
        {
            foreach (var field in Fields)
            {
                if (field.ClassName == f.ClassName && field.FieldName == f.FieldName)
                {
                    return field;
                }
            }
            return null;
        }

        public virtual bool CheckMinMax(DataField val)
        {
            return true;
        }

        public virtual void Save()
        {
            foreach (var data in Data.Values)
            {
                data.Save();
                data.Confirm();
            }
        }

        public virtual void Unload()
        {
            Data = new Dictionary<int, DataField>();
        }

        public virtual object GetFieldValue(int fieldNum)
        {
            if (Data.ContainsKey(fieldNum))
            {
                if (Offset.ContainsKey(fieldNum))
                {
                    var val = Convert.ToDouble(Data[fieldNum].Value) + Offset[fieldNum];
                    if (Data[fieldNum].MaxValue != null && Data[fieldNum].MinValue != null)
                    {
                        var max = Convert.ToDouble(Data[fieldNum].MaxValue);
                        var min = Convert.ToDouble(Data[fieldNum].MinValue);
                        while (val > max)
                        {
                            val -= (max - min);
                        }
                        while (val < min)
                        {
                            val += (max - min);
                        }
                    }
                    return val;
                }
                return Data[fieldNum].Value;
            }
            return null;
        }

        public virtual void SetFieldValue(int fieldNum, object value)
        {
            if (Data.ContainsKey(fieldNum))
            {
                if (Offset.ContainsKey(fieldNum))
                {
                    var val = Convert.ToDouble(value) - Offset[fieldNum];
                    if (Data[fieldNum].MaxValue != null && Data[fieldNum].MinValue != null)
                    {
                        var max = Convert.ToDouble(Data[fieldNum].MaxValue);
                        var min = Convert.ToDouble(Data[fieldNum].MinValue);
                        while (val > max)
                        {
                            val -= (max - min);
                        }
                        while (val < min)
                        {
                            val += (max - min);
                        }
                    }
                    Data[fieldNum].Value = val;
                }
                else
                {
                    Data[fieldNum].Value = value;
                }
            }
        }

        public virtual void AddObject(object newObject)
        {
            if (newObject == null)
            {
                return;
            }
            var objectName = newObject.GetType().FullName;
            if (Classes.ContainsKey(objectName))
            {
                var definition = Classes[objectName];
                foreach (var field in definition.Fields.Values)
                {
                    var index = Fields.IndexOf(field);
                    if (Data.ContainsKey(index))
                    {
                        Data[index] = new DataField(this, field, newObject);
                    }
                    else
                    {
                        Data.Add(index, new DataField(this, field, newObject));
                    }

                    Data[index].DataObject = newObject;
                }
            }
        }

        public virtual void SetConfiguration(XDocument document)
        {
            Classes = new Dictionary<string, ClassDefinition>();
            Fields = new List<FieldDefinition>();
            foreach (var include in document.Root.Elements("Include"))
            {
                var classDefinition = new ClassDefinition();
                classDefinition.SetConfiguration(include);
                if (classDefinition.Valid)
                {
                    Classes.Add(classDefinition.Name, classDefinition);
                    foreach (var field in classDefinition.Fields)
                    {
                        Fields.Add(field.Value);
                    }
                }
            }

            var extraRootElement = document.Root.Element("Extra");
            if (extraRootElement != null)
            {
                foreach (var extraElement in extraRootElement.Elements("Field"))
                {
                    var tmpDefinition = new FieldDefinition();
                    tmpDefinition.SetConfiguration(extraElement);
                    if (!Classes.ContainsKey(tmpDefinition.ClassName))
                    {
                        Debug.Log("ModAPI.Data", "The class \"" + tmpDefinition.ClassName + "\" defined in Extra element is not included in this data package.");
                    }
                    else
                    {
                        var cl = Classes[tmpDefinition.ClassName];
                        if (!cl.Fields.ContainsKey(tmpDefinition.FieldName))
                        {
                            Debug.Log("ModAPI.Data",
                                "The field \"" + tmpDefinition.FieldName + "\" in class \"" + tmpDefinition.ClassName +
                                "\" defined in Extra element either doesn't exist or is not included in this data package.");
                        }
                        else
                        {
                            cl.Fields[tmpDefinition.FieldName].SetConfiguration(tmpDefinition.Configuration);
                            var offset = Convert.ToDouble(cl.Fields[tmpDefinition.FieldName].GetExtra("offset", "0"));
                            if (offset != 0.0)
                            {
                                SetOffset(Fields.IndexOf(cl.Fields[tmpDefinition.FieldName]), offset);
                            }
                            //cl.Fields[tmpDefinition.FieldName].Extra = tmpDefinition.Extra;
                        }
                    }
                }
            }
        }
    }
}
