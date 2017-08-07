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

namespace ModAPI.Data.Models
{
    public class DataField
    {
        public object InitValue;
        public BaseData Container;
        public object ContainerObject;
        public FieldDefinition Field;
        public object DataObject;

        protected object _MaxValue;
        public object MaxValue
        {
            set
            {
                _MaxValue = value;
                CheckMinMax();
            }
            get { return _MaxValue; }
        }

        protected object _MinValue;
        public object MinValue
        {
            set
            {
                _MinValue = value;
                CheckMinMax();
            }
            get { return _MinValue; }
        }

        protected object _Value;
        public object Value
        {
            set
            {
                if (Field.FieldType != null)
                {
                    if (Field.FieldType.FullName == "System.String")
                    {
                        try
                        {
                            _Value = Convert.ToString(value);
                        }
                        catch (Exception e)
                        {
                        }
                    }
                    if (Field.FieldType.FullName == "System.Single")
                    {
                        try
                        {
                            _Value = Convert.ToSingle(value);
                        }
                        catch (Exception e)
                        {
                        }
                    }
                    if (Field.FieldType.FullName == "System.Double")
                    {
                        try
                        {
                            _Value = Convert.ToDouble(value);
                        }
                        catch (Exception e)
                        {
                        }
                    }
                    if (Field.FieldType.FullName == "System.Int32")
                    {
                        try
                        {
                            _Value = Convert.ToInt32(value);
                        }
                        catch (Exception e)
                        {
                        }
                    }
                    if (Field.FieldType.FullName == "System.Boolean")
                    {
                        try
                        {
                            _Value = Convert.ToBoolean(value);
                        }
                        catch (Exception e)
                        {
                        }
                    }
                }
                else
                {
                    _Value = value;
                }
                CheckMinMax();
            }
            get { return _Value; }
        }

        void CheckMinMax()
        {
            if (Container != null && Container.CheckMinMax(this))
            {
                if (_MinValue != null)
                {
                    try
                    {
                        if (_Value is double)
                        {
                            if ((double) _Value < Convert.ToDouble(_MinValue))
                            {
                                _Value = Convert.ToDouble(_MinValue);
                            }
                        }
                        if (_Value is float)
                        {
                            if ((float) _Value < Convert.ToSingle(_MinValue))
                            {
                                _Value = Convert.ToSingle(_MinValue);
                            }
                        }
                        if (_Value is int)
                        {
                            if ((int) _Value < Convert.ToInt32(_MinValue))
                            {
                                _Value = Convert.ToInt32(_MinValue);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Value = 0;
                    }
                }
                if (_MaxValue != null)
                {
                    try
                    {
                        if (_Value is double)
                        {
                            if ((double) _Value > Convert.ToDouble(_MaxValue))
                            {
                                _Value = Convert.ToDouble(_MaxValue);
                            }
                        }
                        if (_Value is float)
                        {
                            if ((float) _Value > Convert.ToSingle(_MaxValue))
                            {
                                _Value = Convert.ToSingle(_MaxValue);
                            }
                        }
                        if (_Value is int)
                        {
                            if ((int) _Value > Convert.ToInt32(_MaxValue))
                            {
                                _Value = Convert.ToInt32(_MaxValue);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Value = 0;
                    }
                }
            }
        }

        public bool Changed
        {
            get { return _Value != InitValue; }
        }

        public void Save()
        {
            DynamicTypes.Set(ContainerObject, Field.FieldName, Value);
        }

        public DataField(BaseData container, FieldDefinition field, object Object)
        {
            Container = container;
            ContainerObject = Object;
            Field = field;
            if (DynamicTypes.Types.ContainsKey(ContainerObject.GetType().FullName))
            {
                InitValue = DynamicTypes.Get(ContainerObject, field.FieldName);
            }
            else
            {
                InitValue = ContainerObject.GetType().GetField(field.FieldName).GetValue(ContainerObject);
            }
            _Value = InitValue;
            if (field.Extra.ContainsKey("max"))
            {
                _MaxValue = double.Parse(field.Extra["max"]);
            }
            if (field.Extra.ContainsKey("min"))
            {
                _MinValue = double.Parse(field.Extra["min"]);
            }

            CheckMinMax();
        }

        public DataField(FieldDefinition field, object Object)
        {
            ContainerObject = Object;
            Field = field;
            if (DynamicTypes.Types.ContainsKey(ContainerObject.GetType().FullName))
            {
                InitValue = DynamicTypes.Get(ContainerObject, field.FieldName);
                Console.WriteLine(Object.GetType().FullName + "_" + field.FieldName + "_" + InitValue);
            }
            else
            {
                InitValue = ContainerObject.GetType().GetField(field.FieldName).GetValue(ContainerObject);
            }
            _Value = InitValue;
            if (field.Extra.ContainsKey("max"))
            {
                _MaxValue = double.Parse(field.Extra["max"]);
            }
            if (field.Extra.ContainsKey("min"))
            {
                _MinValue = double.Parse(field.Extra["min"]);
            }

            CheckMinMax();
        }

        public void Confirm()
        {
            InitValue = _Value;
        }
    }
}
