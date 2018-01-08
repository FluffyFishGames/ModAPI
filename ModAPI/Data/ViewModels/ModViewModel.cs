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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using ModAPI.Configurations;
using ModAPI.Data;
using Application = System.Windows.Application;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using ListViewItem = System.Windows.Controls.ListViewItem;
using Orientation = System.Windows.Controls.Orientation;
using TextBox = System.Windows.Controls.TextBox;

public class ModViewModel : INotifyPropertyChanged
{
    public ObservableDictionary<int, Mod> VersionsData = new ObservableDictionary<int, Mod>();
    protected ObservableCollection<ListViewItem> _Versions = new ObservableCollection<ListViewItem>();
    protected ObservableCollection<Grid> _Buttons = new ObservableCollection<Grid>();

    public ObservableCollection<ListViewItem> Versions => _Versions;
    public ObservableCollection<Grid> Buttons => _Buttons;

    public void Update()
    {
        OnPropertyChanged("Name");
        OnPropertyChanged("Description");
        foreach (var li in Buttons)
        {
            var mv = (ModButtonViewModel) li.DataContext;
            mv.OnPropertyChanged("Name");
            mv.OnPropertyChanged("Description");
        }
    }

    public ModViewModel(Mod mod)
    {
        VersionsData.CollectionChanged += VersionsChanged;
        VersionsData.Add(Mod.Header.ParseModVersion(mod.HeaderData.GetVersion()), mod);
    }

    protected bool _Initialized;

    public void Initialized()
    {
        if (!_Initialized)
        {
            _Initialized = true;
            VersionsChanged(null, null);
            var mod = VersionsData[VersionsData.Keys.First()];
            _Selected = Configuration.GetString("Mods." + mod.Game.GameConfiguration.Id + "." + mod.Id + ".Selected") == "true";
        }
    }

    protected void VersionsChanged(object sender, EventArgs e)
    {
        if (VersionsData.Count == 0)
        {
            return;
        }
        for (var i = 0; i < _Versions.Count; i++)
        {
            var item = _Versions[i];
            var mod = ((ModVersionViewModel) item.DataContext).Mod;
            if (!VersionsData.Values.Contains(mod))
            {
                _Versions.RemoveAt(i);
                i--;
            }
        }

        var versionKeys = VersionsData.Keys.ToList();
        versionKeys.Sort();
        versionKeys.Reverse();
        var old = _Versions.ToArray();
        _Versions = new ObservableCollection<ListViewItem>();

        foreach (var n in versionKeys)
        {
            var mod = VersionsData[n];
            var add = true;
            /*foreach (ListViewItem item in _Versions)
            {
                if (item.DataContext == mod)
                {
                    add = false;
                    break;
                }
            }*/
            if (add)
            {
                var newItem = new ListViewItem();
                var panel = new StackPanel
                {
                    Orientation = Orientation.Vertical
                };
                newItem.DataContext = new ModVersionViewModel(mod);

                var label = new TextBlock();
                label.SetBinding(TextBlock.TextProperty, "Version");
                label.Style = (Style) Application.Current.FindResource("HeaderLabel");

                var panel2 = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };
                var compatibleLabel = new TextBlock();
                compatibleLabel.SetResourceReference(TextBlock.TextProperty, "Lang.Mods.Labels.Compatible");
                compatibleLabel.FontSize = 14;
                compatibleLabel.Style = (Style) Application.Current.FindResource("NormalLabel");

                compatibleLabel.Margin = new Thickness(0, 0, 5, 0);
                var label2 = new TextBlock();
                label2.SetBinding(TextBlock.TextProperty, "Compatible");
                label2.FontSize = 14;

                panel2.Children.Add(compatibleLabel);
                panel2.Children.Add(label2);

                panel.Children.Add(label);
                panel.Children.Add(panel2);

                newItem.Content = panel;
                _Versions.Add(newItem);
            }
        }

        OnPropertyChanged("Versions");

        if (_Initialized)
        {
            DontSaveVersion = true;
            var versionToPrefer = Configuration.GetInt("Mods." + VersionsData[VersionsData.Keys.ToArray()[0]].Game.GameConfiguration.Id + "." + VersionsData[VersionsData.Keys.ToArray()[0]].Id +
                                                       ".Version");
            var found = false;
            foreach (var item in _Versions)
            {
                var mod = ((ModVersionViewModel) item.DataContext).Mod;
                var build = Mod.Header.ParseModVersion(mod.HeaderData.GetVersion());
                if (build == versionToPrefer)
                {
                    SelectedVersion = item;
                    found = true;
                }
            }
            if (!found)
            {
                if (_Versions.Count > 0)
                {
                    SelectedVersion = _Versions[0];
                }
                else
                {
                    SelectedVersion = null;
                }
            }
            DontSaveVersion = false;
            OnPropertyChanged("SelectedVersion");
            OnPropertyChanged("Name");
            OnPropertyChanged("Description");
            OnPropertyChanged("Version");
        }
    }

    protected bool DontSaveVersion;

    protected bool _Selected;
    public bool Selected
    {
        set
        {
            var mod = VersionsData[VersionsData.Keys.First()];
            Configuration.SetString("Mods." + mod.Game.GameConfiguration.Id + "." + mod.Id + ".Selected", value ? "true" : "false", true);
            Configuration.Save();
            _Selected = value;
        }
        get => _Selected;
    }

    public string Name
    {
        get
        {
            if (SelectedVersion == null)
            {
                return "";
            }
            var vm = ((ModVersionViewModel) SelectedVersion.DataContext);
            if (vm != null)
            {
                var mod = vm.Mod;
                if (mod != null)
                {
                    var ret = mod.HeaderData.GetName().GetString(Configuration.CurrentLanguage.Key, "EN");
                    if (ret == "" && mod.HeaderData.GetName().GetLanguages().Count > 0)
                    {
                        ret = mod.HeaderData.GetName().GetString(mod.HeaderData.GetName().GetLanguages()[0]);
                    }
                    return ret;
                }
            }
            return "";
        }
    }

    public string Description
    {
        get
        {
            if (SelectedVersion == null)
            {
                return "";
            }
            var vm = ((ModVersionViewModel) SelectedVersion.DataContext);

            if (vm != null)
            {
                var mod = vm.Mod;
                if (mod != null)
                {
                    var ret = mod.HeaderData.GetDescription().GetString(Configuration.CurrentLanguage.Key, "EN");
                    if (ret == "" && mod.HeaderData.GetDescription().GetLanguages().Count > 0)
                    {
                        ret = mod.HeaderData.GetDescription().GetString(mod.HeaderData.GetDescription().GetLanguages()[0]);
                    }
                    return ret;
                }
            }
            return "";
        }
    }

    public string Id
    {
        get
        {
            if (VersionsData.Count == 0)
            {
                return "";
            }
            var mod = VersionsData[VersionsData.Keys.First()];
            if (mod != null)
            {
                return mod.Id;
            }
            return "";
        }
    }

    protected ListViewItem _SelectedVersion;

    public ListViewItem SelectedVersion
    {
        get => _SelectedVersion;
        set
        {
            _SelectedVersion = value;
            if (_SelectedVersion != null)
            {
                var vm = ((ModVersionViewModel) SelectedVersion.DataContext);
                _Buttons = new ObservableCollection<Grid>();
                if (vm != null)
                {
                    var mod = vm.Mod;

                    if (mod != null)
                    {
                        if (!DontSaveVersion)
                        {
                            Configuration.SetInt("Mods." + mod.Game.GameConfiguration.Id + "." + mod.Id + ".Version", Mod.Header.ParseModVersion(mod.HeaderData.GetVersion()), true);
                            Configuration.Save();
                        }

                        foreach (var button in mod.HeaderData.GetButtons())
                        {
                            var panel = new StackPanel();
                            var label = new TextBlock();
                        }

                        foreach (var button in mod.HeaderData.GetButtons())
                        {
                            var panel = new Grid
                            {
                                HorizontalAlignment = HorizontalAlignment.Stretch
                            };
                            var col1 = new ColumnDefinition();
                            var col2 = new ColumnDefinition();
                            var col3 = new ColumnDefinition();
                            col1.Width = new GridLength(1, GridUnitType.Auto);
                            col1.SharedSizeGroup = "Buttons0";
                            col2.Width = new GridLength(1, GridUnitType.Auto);
                            col2.SharedSizeGroup = "Buttons1";
                            col3.Width = new GridLength(1, GridUnitType.Star);
                            panel.ColumnDefinitions.Add(col1);
                            panel.ColumnDefinitions.Add(col2);
                            panel.ColumnDefinitions.Add(col3);

                            var bvm = new ModButtonViewModel(button);
                            panel.DataContext = bvm;

                            var label = new TextBlock
                            {
                                Style = Application.Current.FindResource("NormalLabel") as Style
                            };
                            label.SetBinding(TextBlock.TextProperty, "Name");
                            label.VerticalAlignment = VerticalAlignment.Center;
                            label.Margin = new Thickness(0, 0, 10, 0);
                            Grid.SetColumn(label, 0);

                            var label2 = new TextBlock
                            {
                                Style = Application.Current.FindResource("NormalLabel") as Style
                            };
                            label2.SetBinding(TextBlock.TextProperty, "Description");
                            label2.VerticalAlignment = VerticalAlignment.Center;
                            label2.TextWrapping = TextWrapping.Wrap;
                            label2.Margin = new Thickness(10, 0, 0, 0);

                            var input = new TextBox
                            {
                                IsReadOnly = true
                            };
                            input.KeyUp += delegate(object o, KeyEventArgs e) { ChangeStandardKey(o, e, bvm); };
                            input.KeyDown += delegate(object o, KeyEventArgs e) { StandardKeyDown(o, e, bvm); };
                            input.SetBinding(TextBox.TextProperty, "Key");

                            Grid.SetColumn(input, 1);
                            Grid.SetColumn(label2, 2);

                            panel.Children.Add(label);
                            panel.Children.Add(input);
                            panel.Children.Add(label2);

                            _Buttons.Add(panel);
                        }
                    }
                }
            }
            OnPropertyChanged("Name");
            OnPropertyChanged("Description");
            OnPropertyChanged("Version");
            OnPropertyChanged("Buttons");
        }
    }

    protected List<Key> PressedKeys = new List<Key>();

    private void ChangeStandardKey(object sender, KeyEventArgs e, ModButtonViewModel button)
    {
        var t = (TextBox) sender;
        t.Focus();
        var kc = new KeysConverter();
        var a = "";
        PressedKeys.Sort();
        PressedKeys.Reverse();
        foreach (var k in PressedKeys)
        {
            if (a != "")
            {
                a += "+";
            }
            a += kc.ConvertToString(k)?.Replace("NumPad", "Keypad");
        }

        if (e.Key == Key.RightAlt)
        {
            PressedKeys.Remove(Key.LeftCtrl);
        }
        PressedKeys.Remove(e.Key);
        e.Handled = true;

        if (Ignore)
        {
            if (PressedKeys.Count == 0)
            {
                Ignore = false;
            }
        }
        else
        {
            button.Key = a;
            if (PressedKeys.Count > 0)
            {
                Ignore = true;
            }
        }
    }

    protected bool Ignore;

    private void StandardKeyDown(object sender, KeyEventArgs e, ModButtonViewModel button)
    {
        var t = (TextBox) sender;
        t.Focus();
        e.Handled = true;
        if (PressedKeys.Contains(e.Key))
        {
            return;
        }
        PressedKeys.Add(e.Key);
    }

    public string Version
    {
        get
        {
            if (SelectedVersion == null)
            {
                return "";
            }
            var vm = ((ModVersionViewModel) SelectedVersion.DataContext);
            if (vm != null)
            {
                var mod = vm.Mod;
                if (mod != null)
                {
                    return mod.HeaderData.GetVersion();
                }
            }
            return "";
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected internal void OnPropertyChanged(string propertyname)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
    }
}
