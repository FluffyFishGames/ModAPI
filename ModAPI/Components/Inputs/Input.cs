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
    public class Input
    {

        public static void Add(Grid grid, XElement element, string label, Binding value, int row, int startColumn)
        {
            string inputType = Utils.XMLHelper.GetXMLAttributeAsString(element, "InputType", "TextField");
            Add(grid, element, inputType, label, value, row, startColumn);
        }


        public static void Add(Grid grid, FieldDefinition field, string label, Binding value, int row, int startColumn)
        {
            string inputType = field.GetExtra("inputtype", "");
            if (inputType == "") 
            {
                if (field.FieldType == typeof(System.Boolean))
                    inputType = "CheckBox";
                else 
                    inputType = "TextField";
            }
            Add(grid, field, inputType, label, value, row, startColumn);
        }

        public static void Add(Grid grid, XElement element, string inputType, string label, Binding value, int row, int startColumn)
        {
            
            if (inputType == "Slider")
                Slider.Add(grid, element, label, value, row, startColumn);
            if (inputType == "TextField")
                TextField.Add(grid, element, label, value, row, startColumn);
            if (inputType == "TimeDisplay")
                TextField.Add(grid, element, label, value, row, startColumn);
            if (inputType == "CheckBox")
                CheckBox.Add(grid, element, label, value, row, startColumn);
        }


        public static void Add(Grid grid, FieldDefinition field, string inputType, string label, Binding value, int row, int startColumn)
        {
            if (inputType == "Slider")
                Slider.Add(grid, field, label, value, row, startColumn);
            if (inputType == "TextField")
                TextField.Add(grid, field, label, value, row, startColumn);
            if (inputType == "TimeDisplay")
                TimeDisplay.Add(grid, field, label, value, row, startColumn);
            if (inputType == "CheckBox")
                CheckBox.Add(grid, field, label, value, row, startColumn);
        }
    }
}
