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

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Linq;
using ModAPI.Data.Models;
using ModAPI.Utils;

namespace ModAPI.Components.Inputs
{
    public class TextField
    {
        public static void Add(Grid grid, FieldDefinition field, string label, Binding value, int row, int startColumn)
        {
            var labelStyle = field.GetExtra("labelstyle", "NormalLabel");
            var inputStyle = field.GetExtra("inputstyle", "");

            Add(grid, label, value, row, labelStyle, inputStyle, startColumn);
        }

        public static void Add(Grid grid, XElement element, string label, Binding value, int row, int startColumn)
        {
            var labelStyle = XMLHelper.GetXMLAttributeAsString(element, "LabelStyle", "NormalLabel");
            var inputStyle = XMLHelper.GetXMLAttributeAsString(element, "InputStyle", "");

            Add(grid, label, value, row, labelStyle, inputStyle, startColumn);
        }

        public static void Add(Grid grid, string label, Binding value, int row, string labelStyle, string inputStyle, int startColumn)
        {
            var column = startColumn;
            if (label != "")
            {
                var labelElement = new TextBlock();
                labelElement.Style = App.Instance.Resources[labelStyle] as Style;
                labelElement.SetResourceReference(TextBlock.TextProperty, label);
                labelElement.VerticalAlignment = VerticalAlignment.Center;
                labelElement.Margin = new Thickness(column > 0 ? 5 : 0, 0, 0, 5);

                grid.Children.Add(labelElement);
                Grid.SetColumn(labelElement, column);
                Grid.SetRow(labelElement, row);
                column += 1;
            }

            var inputElement = new TextBox();
            inputElement.HorizontalAlignment = HorizontalAlignment.Stretch;
            inputElement.Margin = new Thickness(column > 0 ? 5 : 0, 0, 0, 5);
            if (inputStyle != "")
            {
                var s = App.Instance.Resources[inputStyle] as Style;
                ;
                if (s.TargetType == typeof(TextBox))
                {
                    inputElement.Style = s;
                }
            }
            inputElement.SetBinding(TextBox.TextProperty, value);

            grid.Children.Add(inputElement);
            Grid.SetColumn(inputElement, column);
            Grid.SetRow(inputElement, row);
        }
    }
}
