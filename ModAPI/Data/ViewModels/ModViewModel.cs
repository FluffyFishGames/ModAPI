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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ModAPI;
using ModAPI.Configurations;
using System.Xml.Linq;
using ModAPI.Data.Models;
using ModAPI.Data;
using ModAPI.Components;

public class ModViewModel : INotifyPropertyChanged
{
    public ObservableDictionary<int, Mod> versions = new ObservableDictionary<int,Mod>();
    protected ObservableCollection<ListViewItem> _Versions = new ObservableCollection<ListViewItem>();
    protected ObservableCollection<Grid> _Buttons = new ObservableCollection<Grid>();

    public ObservableCollection<ListViewItem> Versions
    {
        get
        {
            return _Versions;
        }
    }

    public ObservableCollection<Grid> Buttons
    {
        get
        {
            return _Buttons;
        }
    }

    public void Update()
    {
        OnPropertyChanged("Name");
        OnPropertyChanged("Description");
        foreach (Grid li in Buttons)
        {
            ModButtonViewModel mv = (ModButtonViewModel)li.DataContext;
            mv.OnPropertyChanged("Name");
            mv.OnPropertyChanged("Description");
        }
    }
    public ModViewModel(Mod mod)
    {
        versions.CollectionChanged += VersionsChanged;
        this.versions.Add(Mod.Header.ParseModVersion(mod.header.GetVersion()), mod);
    }

    protected bool _Initialized = false;
    public void Initialized()
    {
        if (!_Initialized)
        {
            _Initialized = true;
            VersionsChanged(null, null);
            Mod mod = this.versions[this.versions.Keys.First()];
            _Selected = Configuration.GetString("Mods." + mod.Game.GameConfiguration.ID + "." + mod.ID + ".Selected") == "true";
        }
    }

    protected void VersionsChanged(object sender, EventArgs e)
    {
        if (versions.Count == 0)
            return;
        for (int i = 0; i < _Versions.Count; i++)
        {
            ListViewItem item = _Versions[i];
            Mod mod = ((ModVersionViewModel)item.DataContext).mod;
            if (!versions.Values.Contains(mod))
            {
                _Versions.RemoveAt(i);
                i--;
            }
        }

        List<int> versionKeys = versions.Keys.ToList();
        versionKeys.Sort();
        versionKeys.Reverse();
        ListViewItem[] old = _Versions.ToArray();
        _Versions = new ObservableCollection<ListViewItem>();

        
        foreach (int n in versionKeys)
        {
            Mod mod = versions[n];
            bool add = true;
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
                ListViewItem newItem = new ListViewItem();
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Vertical;
                newItem.DataContext = new ModVersionViewModel(mod);
                
                TextBlock label = new TextBlock();
                label.SetBinding(TextBlock.TextProperty, "Version");
                label.Style = (Style) Application.Current.FindResource("HeaderLabel");
                
                StackPanel panel2 = new StackPanel();
                panel2.Orientation = Orientation.Horizontal;
                TextBlock compatibleLabel = new TextBlock();
                compatibleLabel.SetResourceReference(TextBlock.TextProperty, "Lang.Mods.Labels.Compatible");
                compatibleLabel.FontSize = 14;
                compatibleLabel.Style = (Style) Application.Current.FindResource("NormalLabel");

                compatibleLabel.Margin = new Thickness(0, 0, 5, 0);
                TextBlock label2 = new TextBlock();
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
                int versionToPrefer = Configuration.GetInt("Mods." + versions[versions.Keys.ToArray()[0]].Game.GameConfiguration.ID + "." + versions[versions.Keys.ToArray()[0]].ID + ".Version");
                bool found = false;
                foreach (ListViewItem item in _Versions)
                {
                    Mod mod = ((ModVersionViewModel)item.DataContext).mod;
                    int build = Mod.Header.ParseModVersion(mod.header.GetVersion());
                    if (build == versionToPrefer)
                    {
                        SelectedVersion = item;
                        found = true;
                    }
                }
                if (!found)
                {
                    if (_Versions.Count > 0)
                        SelectedVersion = _Versions[0];
                    else
                        SelectedVersion = null;
                }
                DontSaveVersion = false;
                OnPropertyChanged("SelectedVersion");
                OnPropertyChanged("Name");
                OnPropertyChanged("Description");
                OnPropertyChanged("Version");
            }
    }

    protected bool DontSaveVersion = false;

    protected bool _Selected = false;
    public bool Selected
    {
        set
        {
            Mod mod = this.versions[this.versions.Keys.First()];
            Configuration.SetString("Mods." + mod.Game.GameConfiguration.ID + "." + mod.ID + ".Selected", value?"true":"false", true);
            Configuration.Save();
            _Selected = value;
        }
        get
        {
            return _Selected;
        }
    }

    public string Name
    {
        get
        {
            if (SelectedVersion == null) return "";
            ModVersionViewModel vm = ((ModVersionViewModel)SelectedVersion.DataContext);
            if (vm != null)
            {
                Mod mod = vm.mod;
                if (mod != null)
                {
                    string ret = mod.header.GetName().GetString(Configuration.CurrentLanguage.Key, "EN");
                    if (ret == "" && mod.header.GetName().GetLanguages().Count > 0)
                        ret = mod.header.GetName().GetString(mod.header.GetName().GetLanguages()[0]);
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
            if (SelectedVersion == null) return "";
            ModVersionViewModel vm = ((ModVersionViewModel)SelectedVersion.DataContext);

            if (vm != null)
            {
                Mod mod = vm.mod;
                if (mod != null)
                {
                    string ret = mod.header.GetDescription().GetString(Configuration.CurrentLanguage.Key, "EN");
                    if (ret == "" && mod.header.GetDescription().GetLanguages().Count > 0)
                        ret = mod.header.GetDescription().GetString(mod.header.GetDescription().GetLanguages()[0]);
                    return ret;
                }
            }
            return "";
        }
    }

    public string ID
    {
        get
        {
            if (versions.Count == 0) return "";
            Mod mod = versions[versions.Keys.First()];
            if (mod != null)
            {
                return mod.ID;
            }
            return "";
        }
    }

    protected ListViewItem _SelectedVersion;
    
    public ListViewItem SelectedVersion
    {
        get
        {
            return _SelectedVersion;
        }
        set
        {
            _SelectedVersion = value;
            if (_SelectedVersion != null)
            {
                ModVersionViewModel vm = ((ModVersionViewModel)SelectedVersion.DataContext);
                _Buttons = new ObservableCollection<Grid>();
                if (vm != null)
                {
                    Mod mod = vm.mod;

                    if (mod != null)
                    {
                        if (!DontSaveVersion)
                        {
                            Configuration.SetInt("Mods." + mod.Game.GameConfiguration.ID + "." + mod.ID + ".Version", Mod.Header.ParseModVersion(mod.header.GetVersion()), true);
                            Configuration.Save();
                        }

                        foreach (Mod.Header.Button button in mod.header.GetButtons())
                        {
                            StackPanel panel = new StackPanel();
                            TextBlock label = new TextBlock();

                        }

                        foreach (Mod.Header.Button button in mod.header.GetButtons())
                        {
                            Grid panel = new Grid();
                            panel.HorizontalAlignment = HorizontalAlignment.Stretch;
                            ColumnDefinition col1 = new ColumnDefinition();
                            ColumnDefinition col2 = new ColumnDefinition();
                            ColumnDefinition col3 = new ColumnDefinition();
                            col1.Width = new GridLength(1, GridUnitType.Auto);
                            col1.SharedSizeGroup = "Buttons0";
                            col2.Width = new GridLength(1, GridUnitType.Auto);
                            col2.SharedSizeGroup = "Buttons1";
                            col3.Width = new GridLength(1, GridUnitType.Star);
                            panel.ColumnDefinitions.Add(col1);
                            panel.ColumnDefinitions.Add(col2);
                            panel.ColumnDefinitions.Add(col3);

                            ModButtonViewModel bvm = new ModButtonViewModel(button);
                            panel.DataContext = bvm;

                            TextBlock label = new TextBlock();
                            label.Style = Application.Current.FindResource("NormalLabel") as Style;
                            label.SetBinding(TextBlock.TextProperty, "Name");
                            label.VerticalAlignment = VerticalAlignment.Center;
                            label.Margin = new Thickness(0,0,10,0);
                            Grid.SetColumn(label, 0);

                            TextBlock label2 = new TextBlock();
                            label2.Style = Application.Current.FindResource("NormalLabel") as Style;
                            label2.SetBinding(TextBlock.TextProperty, "Description");
                            label2.VerticalAlignment = VerticalAlignment.Center;
                            label2.TextWrapping = TextWrapping.Wrap;
                            label2.Margin = new Thickness(10, 0, 0, 0);
                            
                            TextBox input = new TextBox();
                            input.IsReadOnly = true;
                            input.KeyUp += delegate(object o, KeyEventArgs e) {ChangeStandardKey(o, e, bvm);};
                            input.KeyDown += delegate(object o, KeyEventArgs e) {StandardKeyDown(o, e, bvm);};
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
        TextBox t = (TextBox)sender;
        t.Focus();
        System.Windows.Forms.KeysConverter kc = new System.Windows.Forms.KeysConverter();
        string a = "";
        PressedKeys.Sort();
        PressedKeys.Reverse();
        foreach (Key k in PressedKeys)
        {
            if (a != "") a += "+";
            a += kc.ConvertToString(k);
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
                Ignore = false;
            return;
        }
        else
        {
            button.Key = a;
            if (PressedKeys.Count > 0)
                Ignore = true;
        }
    }

    protected bool Ignore = false;

    private void StandardKeyDown(object sender, KeyEventArgs e, ModButtonViewModel button)
    {
        TextBox t = (TextBox)sender;
        t.Focus();
        e.Handled = true;
        if (PressedKeys.Contains(e.Key))
            return;
        PressedKeys.Add(e.Key);
    }
    public string Version
    {
        get
        {
            if (SelectedVersion == null) return "";
            ModVersionViewModel vm = ((ModVersionViewModel)SelectedVersion.DataContext);
            if (vm != null)
            {
                Mod mod = vm.mod;
                if (mod != null)
                {
                    return mod.header.GetVersion();
                }
            }
            return "";
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected internal void OnPropertyChanged(string propertyname)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
    }

}
