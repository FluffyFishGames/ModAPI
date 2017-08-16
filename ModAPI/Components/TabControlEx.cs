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
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
            get => _ExtraPanel; set => _ExtraPanel = value;
        }
        private Panel _itemsHolderPanel;

        public void Preload(ProgressHandler handler)
        {
            if (Items.Count > 1)
            {
                var first = Items[1] as TabItem;
                if (first != null)
                {
                    PreloadTab(handler, first);
                }
            }
        }

        Action _loaded;
        Action _loadNext;

        public void PreloadTab(ProgressHandler handler, TabItem item)
        {
            _loadNext = () =>
            {
                var currIndex = Items.IndexOf(item);
                handler.Progress = (currIndex / (Items.Count - 1f)) * 100f;

                if (item != Items[Items.Count - 1])
                {
                    var nextIndex = currIndex + 1;
                    var nextItem = Items[nextIndex] as TabItem;

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
            _loaded = () =>
            {
                if (item.Content is IPanel)
                {
                    var currIndex = Items.IndexOf(item);
                    var subHandler = new ProgressHandler();
                    subHandler.OnComplete += delegate { _loadNext(); };
                    subHandler.OnChange += delegate { handler.Progress = ((((float) currIndex - 1) / (Items.Count - 1f)) + (subHandler.Progress / 100f * 1f / (Items.Count - 1f))) * 100f; };
                    ((IPanel) item.Content).Preload(subHandler);
                }
                else
                {
                    _loadNext();
                }
            };
            item.Loaded += item_GotFocus;

            SelectedItem = item;
            UpdateLayout();
            if (item.IsLoaded)
            {
                _loaded();
            }
        }

        void item_GotFocus(object sender, RoutedEventArgs e)
        {
            _loaded();
            ((TabItem) sender).Loaded -= item_GotFocus;
        }

        public void Loaded()
        {
            Opacity = 1.0;
        }

        public TabControlEx()
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
            if (ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            {
                ItemContainerGenerator.StatusChanged -= ItemContainerGenerator_StatusChanged;
                UpdateSelectedItem();
            }
        }

        /// <summary>
        /// Get the ItemsHolder and generate any children
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _itemsHolderPanel = GetTemplateChild("PART_ItemsHolder") as Panel;

            UpdateSelectedItem();
        }

        /// <summary>
        /// When the items change we remove any generated panel children and add any new ones as necessary
        /// </summary>
        /// <param name="e"></param>
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            if (_itemsHolderPanel == null)
            {
                return;
            }

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    _itemsHolderPanel.Children.Clear();
                    break;

                case NotifyCollectionChangedAction.Add:
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (var item in e.OldItems)
                        {
                            var cp = FindChildContentPresenter(item);
                            if (cp != null)
                            {
                                _itemsHolderPanel.Children.Remove(cp);
                            }
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
            if (_itemsHolderPanel == null)
            {
                return;
            }

            // Generate a ContentPresenter if necessary
            var item = GetSelectedTabItem();
            if (item != null)
            {
                CreateChildContentPresenter(item);
            }

            // show the right child
            foreach (ContentPresenter child in _itemsHolderPanel.Children)
            {
                child.Visibility = ((child.Tag as TabItem).IsSelected) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private ContentPresenter CreateChildContentPresenter(object item)
        {
            if (item == null)
            {
                return null;
            }

            var cp = FindChildContentPresenter(item);

            if (cp != null)
            {
                return cp;
            }

            // the actual child to be added.  cp.Tag is a reference to the TabItem
            cp = new ContentPresenter
            {
                Content = (item is TabItem) ? (item as TabItem).Content : item,
                ContentTemplate = SelectedContentTemplate,
                ContentTemplateSelector = SelectedContentTemplateSelector,
                ContentStringFormat = SelectedContentStringFormat,
                Visibility = Visibility.Collapsed,
                Tag = (item is TabItem) ? item : (ItemContainerGenerator.ContainerFromItem(item))
            };
            _itemsHolderPanel.Children.Add(cp);
            return cp;
        }

        private ContentPresenter FindChildContentPresenter(object data)
        {
            if (data is TabItem)
            {
                data = (data as TabItem).Content;
            }

            if (data == null)
            {
                return null;
            }

            if (_itemsHolderPanel == null)
            {
                return null;
            }

            foreach (ContentPresenter cp in _itemsHolderPanel.Children)
            {
                if (cp.Content == data)
                {
                    return cp;
                }
            }

            return null;
        }

        protected TabItem GetSelectedTabItem()
        {
            var selectedItem = SelectedItem;
            if (selectedItem == null)
            {
                return null;
            }

            var item = selectedItem as TabItem;
            if (item == null)
            {
                item = ItemContainerGenerator.ContainerFromIndex(SelectedIndex) as TabItem;
            }

            return item;
        }
    }
}
