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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModAPI.Components
{
    /// <summary>
    /// Interaktionslogik für IconTabItem.xaml
    /// </summary>
    public partial class IconTabItem : TabItem
    {
        public static readonly DependencyProperty CurrentIconSourceProperty = DependencyProperty.Register("CurrentIconSource", typeof(BitmapSource), typeof(IconTabItem), new PropertyMetadata());
        public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register("IconSource", typeof(BitmapSource), typeof(IconTabItem), new PropertyMetadata());
        public static readonly DependencyProperty SelectedIconSourceProperty = DependencyProperty.Register("SelectedIconSource", typeof(BitmapSource), typeof(IconTabItem), new PropertyMetadata());
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(String), typeof(IconTabItem), new PropertyMetadata());
        public static readonly DependencyProperty ShowWarningProperty = DependencyProperty.Register("ShowWarning", typeof(Visibility), typeof(IconTabItem), new PropertyMetadata(Visibility.Collapsed));
        public BitmapSource CurrentIconSource
        {
            get { return base.GetValue(CurrentIconSourceProperty) as BitmapSource; }
            set { base.SetValue(CurrentIconSourceProperty, value); }
        }

        public BitmapSource IconSource
        {
            get { return base.GetValue(IconSourceProperty) as BitmapSource; }
            set { base.SetValue(IconSourceProperty, value); }
        }

        public BitmapSource SelectedIconSource
        {
            get { return base.GetValue(SelectedIconSourceProperty) as BitmapSource; }
            set { base.SetValue(SelectedIconSourceProperty, value); }
        }

        public string Label
        {
            get { return (string)base.GetValue(LabelProperty); }
            set { base.SetValue(LabelProperty, value); }
        }

        public Visibility ShowWarning
        {
            get { return (Visibility)base.GetValue(ShowWarningProperty); }
            set { base.SetValue(ShowWarningProperty, value); }
        }
    }
}