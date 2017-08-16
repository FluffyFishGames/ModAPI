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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Linq;
using ModAPI.Data.Models;
using ModAPI.Utils;

namespace ModAPI.Components.Inputs
{
    public class Slider
    {
        public static void Add(Grid grid, FieldDefinition field, string label, Binding value, int row, int startColumn)
        {
            var minimum = Convert.ToDouble(field.GetExtra("min", "0"));
            var maximum = Convert.ToDouble(field.GetExtra("max", "0"));
            var labelStyle = field.GetExtra("labelstyle", "NormalLabel");
            var inputStyle = field.GetExtra("inputstyle", "");

            Add(grid, label, value, row, minimum, maximum, labelStyle, inputStyle, startColumn);
        }

        public static void Add(Grid grid, XElement element, string label, Binding value, int row, int startColumn)
        {
            var minimum = XmlHelper.GetXmlAttributeAsDouble(element, "Min", 0.0);
            var maximum = XmlHelper.GetXmlAttributeAsDouble(element, "Max", 0.0);
            var labelStyle = XmlHelper.GetXmlAttributeAsString(element, "LabelStyle", "NormalLabel");
            var inputStyle = XmlHelper.GetXmlAttributeAsString(element, "InputStyle", "");

            Add(grid, label, value, row, minimum, maximum, labelStyle, inputStyle, startColumn);
        }

        public static void Add(Grid grid, string label, Binding value, int row, double minimum, double maximum, string labelStyle, string inputStyle, int startColumn)
        {
            var column = startColumn;
            if (label != "")
            {
                var labelElement = new TextBlock
                {
                    Style = App.Instance.Resources[labelStyle] as Style
                };
                labelElement.SetResourceReference(TextBlock.TextProperty, label);
                labelElement.VerticalAlignment = VerticalAlignment.Center;
                labelElement.Margin = new Thickness(column > 0 ? 5 : 0, 0, 10, 0);

                grid.Children.Add(labelElement);
                Grid.SetColumn(labelElement, column);
                Grid.SetRow(labelElement, row);
                column += 1;
            }

            var inputElement = new System.Windows.Controls.Slider
            {
                Orientation = Orientation.Horizontal,
                Minimum = minimum,
                Maximum = maximum,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Margin = new Thickness(column > 0 ? 5 : 0, 0, 0, 5)
            };
            if (inputStyle != "")
            {
                var s = App.Instance.Resources[inputStyle] as Style;
                if (s.TargetType == typeof(System.Windows.Controls.Slider))
                {
                    inputElement.Style = s;
                }
            }
            inputElement.SetBinding(System.Windows.Controls.Slider.ValueProperty, value);

            grid.Children.Add(inputElement);
            Grid.SetColumn(inputElement, column);
            Grid.SetRow(inputElement, row);
        }
    }
}
