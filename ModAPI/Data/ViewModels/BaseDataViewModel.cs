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
using System.ComponentModel;
using System.Dynamic;
using ModAPI.Data.Models;

namespace ModAPI.Data.ViewModels
{
    public class BaseDataViewModel : DynamicObject, INotifyPropertyChanged
    {
        protected BaseData Model;
        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<string, object> DynamicValues = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (binder.Name.StartsWith("__Dynamic"))
            {
                try
                {
                    var key = binder.Name.Substring("__Dynamic".Length);

                    if (DynamicValues.ContainsKey(key))
                    {
                        result = DynamicValues[key];
                        return true;
                    }
                    result = null;
                    return false;
                }
                catch (Exception e)
                {
                    result = null;
                    return false;
                }
            }
            if (binder.Name.StartsWith("__Field"))
            {
                try
                {
                    var fieldNumber = int.Parse(binder.Name.Substring("__Field".Length));
                    if (fieldNumber >= 0 && fieldNumber < Model.Fields.Count)
                    {
                        result = Model.GetFieldValue(fieldNumber);
                        return true;
                    }
                    result = null;
                    return false;
                }
                catch (Exception e)
                {
                    result = null;
                    return false;
                }
            }
            result = null;
            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (binder.Name.StartsWith("__Dynamic"))
            {
                try
                {
                    var key = binder.Name.Substring("__Dynamic".Length);
                    if (DynamicValues.ContainsKey(key))
                    {
                        DynamicValues[key] = value;
                    }
                    else
                    {
                        DynamicValues.Add(key, value);
                    }
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            if (binder.Name.StartsWith("__Field"))
            {
                try
                {
                    var fieldNumber = int.Parse(binder.Name.Substring("__Field".Length));
                    if (fieldNumber >= 0 && fieldNumber < Model.Fields.Count)
                    {
                        Model.SetFieldValue(fieldNumber, value);
                        OnPropertyChanged(fieldNumber);
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        public BaseDataViewModel(BaseData baseData)
        {
            Model = baseData;
        }

        protected void OnPropertyChanged(int fieldNum)
        {
            PropertyChanged(this, new PropertyChangedEventArgs("__Field" + fieldNum));
        }
    }
}
