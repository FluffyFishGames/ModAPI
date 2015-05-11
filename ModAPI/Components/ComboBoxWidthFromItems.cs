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
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

namespace ModAPI.Components
{
    public static class ComboBoxWidthFromItemsBehavior
    {
        public static readonly DependencyProperty ComboBoxWidthFromItemsProperty =
            DependencyProperty.RegisterAttached
            (
                "ComboBoxWidthFromItems",
                typeof(bool),
                typeof(ComboBoxWidthFromItemsBehavior),
                new UIPropertyMetadata(false, OnComboBoxWidthFromItemsPropertyChanged)
            );
        public static bool GetComboBoxWidthFromItems(DependencyObject obj)
        {
            return (bool)obj.GetValue(ComboBoxWidthFromItemsProperty);
        }
        public static void SetComboBoxWidthFromItems(DependencyObject obj, bool value)
        {
            obj.SetValue(ComboBoxWidthFromItemsProperty, value);
        }
        private static void OnComboBoxWidthFromItemsPropertyChanged(DependencyObject dpo,
                                                                    DependencyPropertyChangedEventArgs e)
        {
            ComboBox comboBox = dpo as ComboBox;
            if (comboBox != null)
            {
                if ((bool)e.NewValue == true)
                {
                    comboBox.Loaded += OnComboBoxLoaded;
                }
                else
                {
                    comboBox.Loaded -= OnComboBoxLoaded;
                }
            }
        }
        private static void OnComboBoxLoaded(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            Action action = () => { comboBox.SetWidthFromItems(); };
            comboBox.Dispatcher.BeginInvoke(action, DispatcherPriority.ContextIdle);
        }
    }

    public static class ComboBoxExtensionMethods
    {
        public static void SetWidthFromItems(this ComboBox comboBox)
        {
            double comboBoxWidth = 19;// comboBox.DesiredSize.Width;

            // Create the peer and provider to expand the comboBox in code behind. 
            ComboBoxAutomationPeer peer = new ComboBoxAutomationPeer(comboBox);
            IExpandCollapseProvider provider = (IExpandCollapseProvider)peer.GetPattern(PatternInterface.ExpandCollapse);
            EventHandler eventHandler = null;
            eventHandler = new EventHandler(delegate
            {
                if (comboBox.IsDropDownOpen &&
                    comboBox.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                {
                    double width = 0;
                    foreach (var item in comboBox.Items)
                    {
                        ComboBoxItem comboBoxItem = comboBox.ItemContainerGenerator.ContainerFromItem(item) as ComboBoxItem;
                        comboBoxItem.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                        
                        if (comboBoxItem.DesiredSize.Width > width)
                        {
                            width = comboBoxItem.DesiredSize.Width;
                        }
                    }
                    comboBox.Width = comboBoxWidth + width;
                    // Remove the event handler. 
                    comboBox.ItemContainerGenerator.StatusChanged -= eventHandler;
                    comboBox.DropDownOpened -= eventHandler;
                    provider.Collapse();
                }
            });
            comboBox.ItemContainerGenerator.StatusChanged += eventHandler;
            comboBox.DropDownOpened += eventHandler;
            // Expand the comboBox to generate all its ComboBoxItem's. 
            provider.Expand();
        }
    }
}