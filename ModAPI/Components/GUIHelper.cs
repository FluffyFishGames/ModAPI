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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Globalization;

public static class VisualTreeHelperExtensions
{
    public static IEnumerable<DependencyObject> GetAllChildren(this DependencyObject parent)
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            // retrieve child at specified index
            var directChild = (Visual)VisualTreeHelper.GetChild(parent, i);

            // return found child
            yield return directChild;

            // return all children of the found child
            foreach (var nestedChild in directChild.GetAllChildren())
                yield return nestedChild;
        }
    }
}

namespace GUIHelper
{


    public class TimeDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double max = (double) parameter;
            double val = System.Convert.ToDouble(value);

            double hour = (max / 24f);
            int currentHour = (int) (val / hour);
            int currentMinute = (int)((val - (currentHour * hour)) * (60.0 / hour));
            string sHour = currentHour + "";
            string sMinute = currentMinute + "";
            if (sHour.Length == 1) sHour = "0" + sHour;
            if (sMinute.Length == 1) sMinute = "0" + sMinute;

            return sHour+":"+sMinute;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ModelDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType.FullName == "System.Double")
                return System.Convert.ToDouble(value);
            if (targetType.FullName == "System.Single")
                return System.Convert.ToSingle(value);
            if (targetType.FullName == "System.Int32")
                return System.Convert.ToInt32(value);
            if (targetType.FullName == "System.Boolean")
                return System.Convert.ToBoolean(value);
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType.FullName == "System.Double")
                return System.Convert.ToDouble(value);
            if (targetType.FullName == "System.Single")
                return System.Convert.ToSingle(value);
            if (targetType.FullName == "System.Int32")
                return System.Convert.ToInt32(value);
            if (targetType.FullName == "System.Boolean")
                return System.Convert.ToBoolean(value);
            return value;
        }
    }
    public class GridlengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new GridLength((double)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class SubtractConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            int result = (int) value[0]; 
            for (int i = 1; i < value.Length; i++)
                result -= (int)value[i];
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { (int)value + 1, 1 };
        }
    }
}
