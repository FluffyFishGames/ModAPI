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

/*
namespace CustomControls
{
    public class TabControlContentStretchBehavior : Behavior<TabControl>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += TabControlLoaded;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= TabControlLoaded;
            base.OnDetaching();
        }

        private void TabControlLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // stretch content (bugfix for tabcontrol item that uses scrollviewer that always stretches the contentpresenter)
            FrameworkElement contentHost = AssociatedObject.FindChildByName("PART_SelectedContentHost");
            if (contentHost != null)
            {
                // initially stretch
                contentHost.HorizontalAlignment = HorizontalAlignment.Stretch;
                contentHost.VerticalAlignment = VerticalAlignment.Stretch;
                // if value gets changed it will be set to stretched again
                DependencyPropertyDescriptor dpdh = DependencyPropertyDescriptor.FromProperty(FrameworkElement.HorizontalAlignmentProperty, typeof(FrameworkElement));
                if (dpdh != null)
                {
                    dpdh.AddValueChanged(contentHost, delegate
                    {
                        contentHost.HorizontalAlignment = HorizontalAlignment.Stretch;
                    });
                }
                DependencyPropertyDescriptor dpdv = DependencyPropertyDescriptor.FromProperty(FrameworkElement.VerticalAlignmentProperty, typeof(FrameworkElement));
                if (dpdv != null)
                {
                    dpdv.AddValueChanged(contentHost, delegate
                    {
                        contentHost.VerticalAlignment = VerticalAlignment.Stretch;
                    });
                }
            }
        }
    }
}
*/


