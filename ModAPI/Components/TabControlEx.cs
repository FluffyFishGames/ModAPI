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
using System.Windows.Controls.Primitives;
using System.Collections.Specialized;
using ModAPI.Components.Panels;

namespace ModAPI.Components
{
    [TemplatePart(Name = "PART_ItemsHolder", Type = typeof(Panel))]
    public class TabControlEx : TabControl
    {

        public static readonly DependencyProperty ExtraPanelProperty = DependencyProperty.Register("ExtraPanel", typeof(FrameworkElement), typeof(TabControlEx), new PropertyMetadata());
        
        protected FrameworkElement _ExtraPanel;
        public FrameworkElement ExtraPanel
        {
            get
            {
                return _ExtraPanel;
            }
            set
            {
                _ExtraPanel = value;
            }
        }
        private Panel ItemsHolderPanel = null;

        public void Preload(ProgressHandler handler)
        {
            if (Items.Count > 1)
            {
                TabItem first = Items[1] as TabItem;
                if (first != null)
                    PreloadTab(handler, first);
            }
        }

        Action _Loaded;
        Action _LoadNext;

        public void PreloadTab(ProgressHandler handler, TabItem item)
        {
            _LoadNext = () =>
            {
                int currIndex = this.Items.IndexOf(item);
                handler.Progress = ((float)currIndex / ((float)this.Items.Count - 1f)) * 100f;
                
                if (item != this.Items[this.Items.Count - 1])
                {
                
                    int nextIndex = currIndex + 1;
                    TabItem nextItem = this.Items[nextIndex] as TabItem;

                    if (nextItem != null)
                    {
                        PreloadTab(handler, nextItem);
                    }
                }
                else
                {
                    SelectedIndex = 0;
                }
            };
            _Loaded = () =>
            {
                if (item.Content is IPanel)
                {
                    int currIndex = this.Items.IndexOf(item);
                    ProgressHandler subHandler = new ProgressHandler();
                    subHandler.OnComplete += delegate
                    {
                        _LoadNext();
                    };
                    subHandler.OnChange += delegate
                    {
                        handler.Progress = ((((float)currIndex - 1) / ((float)this.Items.Count - 1f)) + (subHandler.Progress / 100f * 1f / ((float)this.Items.Count - 1f))) * 100f;
                    };
                    ((IPanel)item.Content).Preload(subHandler);
                }
                else
                {
                    _LoadNext();
                }
            };
            item.Loaded += item_GotFocus;

            this.SelectedItem = item;
            this.UpdateLayout();
            if (item.IsLoaded)
                _Loaded();
            
        }

        void item_GotFocus(object sender, RoutedEventArgs e)
        {
            _Loaded();
            ((TabItem)sender).Loaded -= item_GotFocus;
        }

        public void Loaded()
        {
            Opacity = 1.0;
        }

        public TabControlEx()
            : base()
        {
            // This is necessary so that we get the initial databound selected item
            ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
        }

        /// <summary>
        /// If containers are done, generate the selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            if (this.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            {
                this.ItemContainerGenerator.StatusChanged -= ItemContainerGenerator_StatusChanged;
                UpdateSelectedItem();
            }
        }

        /// <summary>
        /// Get the ItemsHolder and generate any children
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ItemsHolderPanel = GetTemplateChild("PART_ItemsHolder") as Panel;

            UpdateSelectedItem();
        }

        /// <summary>
        /// When the items change we remove any generated panel children and add any new ones as necessary
        /// </summary>
        /// <param name="e"></param>
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            if (ItemsHolderPanel == null)
                return;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    ItemsHolderPanel.Children.Clear();
                    break;

                case NotifyCollectionChangedAction.Add:
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (var item in e.OldItems)
                        {
                            ContentPresenter cp = FindChildContentPresenter(item);
                            if (cp != null)
                                ItemsHolderPanel.Children.Remove(cp);
                        }
                    }

                    // Don't do anything with new items because we don't want to
                    // create visuals that aren't being shown

                    UpdateSelectedItem();
                    break;

                case NotifyCollectionChangedAction.Replace:
                    throw new NotImplementedException("Replace not implemented yet");
            }
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            UpdateSelectedItem();
        }

        private void UpdateSelectedItem()
        {
            if (ItemsHolderPanel == null)
                return;

            // Generate a ContentPresenter if necessary
            TabItem item = GetSelectedTabItem();
            if (item != null)
                CreateChildContentPresenter(item);

            // show the right child
            foreach (ContentPresenter child in ItemsHolderPanel.Children)
                child.Visibility = ((child.Tag as TabItem).IsSelected) ? Visibility.Visible : Visibility.Collapsed;
        }

        private ContentPresenter CreateChildContentPresenter(object item)
        {
            
            if (item == null)
                return null;

            ContentPresenter cp = FindChildContentPresenter(item);
            
            if (cp != null)
                return cp;

            // the actual child to be added.  cp.Tag is a reference to the TabItem
            cp = new ContentPresenter();
            cp.Content = (item is TabItem) ? (item as TabItem).Content : item;
            cp.ContentTemplate = this.SelectedContentTemplate;
            cp.ContentTemplateSelector = this.SelectedContentTemplateSelector;
            cp.ContentStringFormat = this.SelectedContentStringFormat;
            cp.Visibility = Visibility.Collapsed;
            cp.Tag = (item is TabItem) ? item : (this.ItemContainerGenerator.ContainerFromItem(item));
            ItemsHolderPanel.Children.Add(cp);
            return cp;
        }

        private ContentPresenter FindChildContentPresenter(object data)
        {
            if (data is TabItem)
                data = (data as TabItem).Content;

            if (data == null)
                return null;

            if (ItemsHolderPanel == null)
                return null;

            foreach (ContentPresenter cp in ItemsHolderPanel.Children)
            {
                if (cp.Content == data)
                    return cp;
            }

            return null;
        }

        protected TabItem GetSelectedTabItem()
        {
            object selectedItem = base.SelectedItem;
            if (selectedItem == null)
                return null;

            TabItem item = selectedItem as TabItem;
            if (item == null)
                item = base.ItemContainerGenerator.ContainerFromIndex(base.SelectedIndex) as TabItem;

            return item;
        }
    }
}
