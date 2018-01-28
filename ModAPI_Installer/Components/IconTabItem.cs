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
using System.Windows.Media.Imaging;

namespace ModAPI.Components
{
    /// <summary>
    /// Interaktionslogik für IconTabItem.xaml
    /// </summary>
    public class IconTabItem : TabItem
    {
        public static readonly DependencyProperty CurrentIconSourceProperty = DependencyProperty.Register("CurrentIconSource", typeof(BitmapSource), typeof(IconTabItem), new PropertyMetadata());
        public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register("IconSource", typeof(BitmapSource), typeof(IconTabItem), new PropertyMetadata());
        public static readonly DependencyProperty SelectedIconSourceProperty = DependencyProperty.Register("SelectedIconSource", typeof(BitmapSource), typeof(IconTabItem), new PropertyMetadata());
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(String), typeof(IconTabItem), new PropertyMetadata());
        public static readonly DependencyProperty ShowWarningProperty = DependencyProperty.Register("ShowWarning", typeof(Visibility), typeof(IconTabItem), new PropertyMetadata(Visibility.Collapsed));
        public BitmapSource CurrentIconSource
        {
            get => GetValue(CurrentIconSourceProperty) as BitmapSource;
            set => SetValue(CurrentIconSourceProperty, value);
        }

        public BitmapSource IconSource
        {
            get => GetValue(IconSourceProperty) as BitmapSource;
            set => SetValue(IconSourceProperty, value);
        }

        public BitmapSource SelectedIconSource
        {
            get => GetValue(SelectedIconSourceProperty) as BitmapSource;
            set => SetValue(SelectedIconSourceProperty, value);
        }

        public string Label
        {
            get => (string) GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public Visibility ShowWarning
        {
            get => (Visibility) GetValue(ShowWarningProperty);
            set => SetValue(ShowWarningProperty, value);
        }
    }
}
