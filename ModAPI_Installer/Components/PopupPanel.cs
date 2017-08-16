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

namespace ModAPI.Components
{
    /// <summary>
    /// Interaktionslogik für PopupPanel.xaml
    /// </summary>
    public class PopupPanel : ContentControl
    {
        /*
        public static readonly DependencyPropertyKey ChildrenProperty = DependencyProperty.RegisterReadOnly(
             "Children",
             typeof(UIElementCollection),
             typeof(PopupPanel),
             new PropertyMetadata());

        public UIElementCollection Children
        {
            get { return (UIElementCollection)GetValue(ChildrenProperty.DependencyProperty); }
            private set { SetValue(ChildrenProperty, value); }
        }*/

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(PopupPanel));

        public string Title
        {
            get => (string) GetValue(TitleProperty); set => SetValue(TitleProperty, value);
        }

        public Grid InnerElement;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            /*InnerElement = (Grid) this.FindName("Inner");
            Children = InnerElement.Children;*/
        }
    }
}
