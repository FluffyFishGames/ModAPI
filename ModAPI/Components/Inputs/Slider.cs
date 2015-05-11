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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using ModAPI.Data.Models;

namespace ModAPI.Components.Inputs
{
    public class Slider
    {
        public static void Add(Grid grid, FieldDefinition field, string label, Binding value, int row, int startColumn)
        {
            double minimum = Convert.ToDouble(field.GetExtra("min", "0"));
            double maximum = Convert.ToDouble(field.GetExtra("max", "0"));
            string labelStyle = field.GetExtra("labelstyle", "NormalLabel");
            string inputStyle = field.GetExtra("inputstyle", "");

            Add(grid, label, value, row, minimum, maximum, labelStyle, inputStyle, startColumn);
        }

        public static void Add(Grid grid, XElement element, string label, Binding value, int row, int startColumn)
        {
            double minimum = Utils.XMLHelper.GetXMLAttributeAsDouble(element, "Min", 0.0);
            double maximum = Utils.XMLHelper.GetXMLAttributeAsDouble(element, "Max", 0.0);
            string labelStyle = Utils.XMLHelper.GetXMLAttributeAsString(element, "LabelStyle", "NormalLabel");
            string inputStyle = Utils.XMLHelper.GetXMLAttributeAsString(element, "InputStyle", "");

            Add(grid, label, value, row, minimum, maximum, labelStyle, inputStyle, startColumn);
        }

        public static void Add(Grid grid, string label, Binding value, int row, double minimum, double maximum, string labelStyle, string inputStyle, int startColumn)
        {
            int column = startColumn;
            if (label != "")
            {
                TextBlock labelElement = new TextBlock();
                labelElement.Style = App.Instance.Resources[labelStyle] as Style;
                labelElement.SetResourceReference(TextBlock.TextProperty, label);
                labelElement.VerticalAlignment = VerticalAlignment.Center;
                labelElement.Margin = new Thickness(column > 0 ? 5 : 0, 0, 10, 0);

                grid.Children.Add(labelElement);
                Grid.SetColumn(labelElement, column);
                Grid.SetRow(labelElement, row);
                column += 1;
            }

            System.Windows.Controls.Slider inputElement = new System.Windows.Controls.Slider();
            inputElement.Orientation = Orientation.Horizontal;
            inputElement.Minimum = minimum;
            inputElement.Maximum = maximum;
            inputElement.HorizontalAlignment = HorizontalAlignment.Stretch;
            inputElement.Margin = new Thickness(column > 0 ? 5 : 0, 0, 0, 5);
            if (inputStyle != "")
            {
                Style s = App.Instance.Resources[inputStyle] as Style;
                if (s.TargetType == typeof(System.Windows.Controls.Slider))
                    inputElement.Style = s;
            }
            inputElement.SetBinding(System.Windows.Controls.Slider.ValueProperty, value);

            grid.Children.Add(inputElement);
            Grid.SetColumn(inputElement, column);
            Grid.SetRow(inputElement, row);
        }
    }
}
