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
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ModAPI.Data;

namespace ModAPI.Components.Inputs
{
    //[ContentProperty("ItemsSource")]
    public class MultilingualTextField : ComboBox
    {
        public static readonly DependencyProperty CurrentTextProperty =
            DependencyProperty.Register("CurrentText", typeof(String), typeof(MultilingualTextField), new PropertyMetadata("", TextChanged));
        public string CurrentText
        {
            get { return (string) GetValue(CurrentTextProperty); }
            set
            {
                var item = (ComboBoxItem) SelectedItem;
                if (item != null)
                {
                    Value.SetString((string) ((ComboBoxItem) SelectedItem).DataContext, value);
                }
                SetValue(CurrentTextProperty, value);
            }
        }

        public static void ValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var textField = (MultilingualTextField) sender;
            textField.SelectedIndex = 0;
            var item = (ComboBoxItem) textField.SelectedItem;
            if (item != null)
            {
                textField.CurrentText = textField.Value.GetString((string) ((ComboBoxItem) textField.SelectedItem).DataContext);
            }
            else
            {
                textField.CurrentText = "";
            }
        }

        public static void TextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var textfield = (MultilingualTextField) sender;

            //System.Console.WriteLine("A");
            var item = (ComboBoxItem) textfield.SelectedItem;
            if (item != null)
            {
                textfield.Value.SetString((string) item.DataContext, (string) e.NewValue);
            }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(MultilingualValue), typeof(MultilingualTextField),
            new PropertyMetadata(new MultilingualValue(), ValueChanged));
        public MultilingualValue Value
        {
            get { return (MultilingualValue) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty LanguagesProperty = DependencyProperty.Register("Languages", typeof(ObservableCollection<string>), typeof(MultilingualTextField),
            new PropertyMetadata(new ObservableCollection<string> { "EN" }, OnLanguagesChanged));

        public ObservableCollection<string> Languages
        {
            get { return (ObservableCollection<string>) GetValue(LanguagesProperty); }
            set { SetValue(LanguagesProperty, value); }
        }

        public static void OnLanguagesChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((MultilingualTextField) sender).LanguagesChanged(null, null);
        }

        protected ObservableCollection<string> LastLanguages;

        public void LanguagesChanged(object sender, EventArgs e)
        {
            if (LastLanguages != null)
            {
                LastLanguages.CollectionChanged -= LanguagesChanged;
            }
            Languages.CollectionChanged += LanguagesChanged;
            LastLanguages = Languages;
            Items.Clear();
            foreach (var langCode in Languages)
            {
                var newItem = new ComboBoxItem
                {
                    Style = Application.Current.FindResource("ComboBoxItem") as Style,
                    DataContext = langCode
                };
                var panel = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };
                var image = new Image
                {
                    Height = 20
                };
                var source = new BitmapImage();
                source.BeginInit();
                source.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/Lang_" + langCode + ".png");
                source.EndInit();
                image.Source = source;
                image.Margin = new Thickness(0, 0, 5, 0);
                panel.Children.Add(image);

                var label = new TextBlock();
                label.SetResourceReference(TextBlock.TextProperty, "Lang.Languages." + langCode);
                panel.Children.Add(label);

                newItem.Content = panel;
                Items.Add(newItem);
            }
            if (Languages.Count >= 1 && SelectedIndex < 0)
            {
                SelectedIndex = 0;
            }
            IsEnabled = Languages.Count > 0;
            if (Languages.Count == 0)
            {
                CurrentText = "";
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            LanguagesChanged(null, null);
            SelectedIndex = 0;
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            var item = (ComboBoxItem) SelectedItem;
            if (item != null)
            {
                CurrentText = Value.GetString((string) ((ComboBoxItem) SelectedItem).DataContext);
                //OnPropertyChanged(new DependencyPropertyChangedEventArgs(TextProperty, this.Text, Value.GetString());
            }
        }

        /*  public IEnumerable ItemsSource
          {
              get { return (IEnumerable)GetValue(ItemsSourceProperty); }
              set { SetValue(ItemsSourceProperty, value); }
          }
  
          public static readonly DependencyProperty ItemsSourceProperty =
              DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(MultilingualTextField), new PropertyMetadata(new PropertyChangedCallback(OnItemsSourcePropertyChanged)));
  
          private static void OnItemsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
          {
              var control = sender as MultilingualTextField;
              if (control != null)
                  control.OnItemsSourceChanged((IEnumerable)e.OldValue, (IEnumerable)e.NewValue);
          }
  
          private void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
          {
              // Remove handler for oldValue.CollectionChanged
              var oldValueINotifyCollectionChanged = oldValue as INotifyCollectionChanged;
  
              if (null != oldValueINotifyCollectionChanged)
              {
                  oldValueINotifyCollectionChanged.CollectionChanged -= new NotifyCollectionChangedEventHandler(newValueINotifyCollectionChanged_CollectionChanged);
              }
              // Add handler for newValue.CollectionChanged (if possible)
              var newValueINotifyCollectionChanged = newValue as INotifyCollectionChanged;
              if (null != newValueINotifyCollectionChanged)
              {
                  newValueINotifyCollectionChanged.CollectionChanged += new NotifyCollectionChangedEventHandler(newValueINotifyCollectionChanged_CollectionChanged);
              }
  
          }
  
          void newValueINotifyCollectionChanged_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
          {
              //Do your stuff here.
          }
          
          static MultilingualTextField()
          {
              DefaultStyleKeyProperty.OverrideMetadata(typeof(MultilingualTextField), new FrameworkPropertyMetadata(typeof(MultilingualTextField)));
          }*/
    }
}
