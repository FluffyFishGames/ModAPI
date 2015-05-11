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
using System.Text.RegularExpressions;
using System.Threading;

public class ModsViewModel : INotifyPropertyChanged
{
    protected DispatcherTimer Timer;
    protected bool _SelectNewestModVersions = false;
    protected bool _FirstBatchLoaded = false;

    public bool SelectNewestModVersions
    {
        set 
        {
            if (_FirstBatchLoaded)
                SelectNewestVersions();
            else 
                _SelectNewestModVersions = value;
        }
        get 
        {
            return _SelectNewestModVersions;
        }
    }

    public void Update()
    {
        foreach (ListViewItem li in Mods)
        {
            ModViewModel mv = (ModViewModel)li.DataContext;
            mv.Update();
        }
    }

    public ModsViewModel()
    {
        _Mods = new ObservableCollection<ListViewItem>();
        Configuration.OnLanguageChanged += Update;

        Timer = new DispatcherTimer();
        Timer.Tick += new EventHandler(Tick);
        Timer.Interval = new TimeSpan((long) (10000000)); // 1s
        Timer.Start();

        FindMods();
    }

    protected Dictionary<string, Mod> LoadedFiles = new Dictionary<string, Mod>();
    protected Regex validation = new Regex("^([a-zA-Z0-9_]+)-([0-9\\.]+)-([0-9abcdef]{32})\\.mod$");
    protected bool Loading = false;

    protected void FindMods()
    {
        try
        {
            if (Loading) return;
            string path = System.IO.Path.GetFullPath(Configuration.GetPath("mods") + System.IO.Path.DirectorySeparatorChar + App.Game.GameConfiguration.ID);
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            
            string[] Keys = LoadedFiles.Keys.ToArray();
            for (int i = 0; i < Keys.Length; i++)
            {
                string file = Keys[i];
                if (!System.IO.File.Exists(file))
                {
                    Mod mod = LoadedFiles[file];
                    string id = LoadedFiles[file].ID + "-" + LoadedFiles[file].header.GetVersion();
                    Mod.Mods.Remove(id);
                    for (int j = 0; j < _Mods.Count; j++)
                    {
                        ModViewModel vm = (ModViewModel)_Mods[j].DataContext;
                        if (vm.versions.Values.Contains(mod))
                        {
                            vm.versions.Remove(Mod.Header.ParseModVersion(mod.header.GetVersion()));
                            if (vm.versions.Count == 0)
                            {
                                _Mods.RemoveAt(j);
                            }
                            break;
                        }
                    }
                    LoadedFiles.Remove(file);
                }
            }

            string[] files = System.IO.Directory.GetFiles(path);
            List<string> ToLoad = new List<string>();
            foreach (string file in files)
            {
                string fileName = System.IO.Path.GetFileName(file);
                if (!LoadedFiles.ContainsKey(file) && validation.IsMatch(fileName)) 
                {
                    ToLoad.Add(file);
                }
            }

            if (ToLoad.Count > 0)
            {
                Loading = true;
                ProgressHandler progressHandler = new ProgressHandler();
                Thread t = new Thread(delegate() {
                    LoadMods(ToLoad, progressHandler);
                });
                progressHandler.Task = "LoadingMods";
                progressHandler.OnComplete += (s, e) => MainWindow.Instance.Dispatcher.Invoke((Action)delegate() { UpdateMods(); });
                ModAPI.Utils.Schedule.AddTask("GUI", "OperationPending", null, new object[] {"LoadingMods", progressHandler, null, true});
                t.Start();
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.ToString());
        }
    }

    protected void UpdateMods()
    {
        foreach (KeyValuePair<string, Mod> kv in Mod.Mods)
        {
            bool add = true;
            ModViewModel alreadyVM = null;
            foreach (ListViewItem i in _Mods) 
            {
                ModViewModel vm = ((ModViewModel)i.DataContext);
                if (vm.versions.Values.Contains(kv.Value)) 
                {
                    add = false;
                }
                if (vm.ID == kv.Value.ID)
                {
                    alreadyVM = vm;
                }
            }
            if (add)
            {
                Mod mod = kv.Value;
                if (alreadyVM != null)
                {
                    alreadyVM.versions.Add(Mod.Header.ParseModVersion(mod.header.GetVersion()), mod);
                    alreadyVM.OnPropertyChanged("Version");
                    alreadyVM.OnPropertyChanged("Name");
                }
                else
                {
                    ListViewItem item = new ListViewItem();

                    StackPanel outerPanel = new StackPanel();
                    outerPanel.Orientation = Orientation.Horizontal;
                    outerPanel.Margin = new Thickness(-5, 0, 0, 0);
                    CheckBox checkBox = new CheckBox();
                    checkBox.SetBinding(CheckBox.IsCheckedProperty, "Selected");
                    outerPanel.Children.Add(checkBox);

                    StackPanel panel = new StackPanel();

                    TextBlock textBlock = new TextBlock();
                    textBlock.SetBinding(TextBlock.TextProperty, "Name");
                    panel.Children.Add(textBlock);

                    TextBlock textBlock2 = new TextBlock();
                    textBlock2.SetBinding(TextBlock.TextProperty, "Version");
                    textBlock2.FontSize = 14;
                    panel.Children.Add(textBlock2);
                    outerPanel.Children.Add(panel);

                    ModViewModel mvm = new ModViewModel(mod);
                    item.DataContext = mvm;
                    item.Content = outerPanel;
                    _Mods.Add(item);
                }
            }
        }

        foreach (ListViewItem item in _Mods)
        {
            ModViewModel vm = (ModViewModel)item.DataContext;
            vm.Initialized();
        }
        _FirstBatchLoaded = true;
        if (_SelectNewestModVersions)
            SelectNewestVersions();
    }

    public void SelectNewestVersions() 
    {
        foreach (ListViewItem item in _Mods)
        {
            ModViewModel vm = (ModViewModel)item.DataContext;
            List<int> v = vm.versions.Keys.ToList();
            v.Sort();
            v.Reverse();
            foreach (ListViewItem li in vm.Versions) 
            {
                ModVersionViewModel versionModel = (ModVersionViewModel) li.DataContext;
                if (Mod.Header.ParseModVersion(versionModel.mod.header.GetVersion()) == v[0]) 
                {
                    vm.SelectedVersion = li;
                    break;
                }
            }
        }
        _SelectNewestModVersions = false;
    }


    protected void LoadMods(List<string> ToLoad, ProgressHandler progressHandler)
    {
        for (int i = 0; i < ToLoad.Count; i++)
        {
            string fileName = ToLoad[i];
            Match collection = validation.Match(System.IO.Path.GetFileName(fileName));

            string id = collection.Groups[1].Captures[0].Value + "-" + collection.Groups[2].Captures[0].Value;
            
            Mod mod = new Mod(App.Game, fileName);
            if (Mod.Mods.ContainsKey(id) || mod.Load())
            {
                LoadedFiles.Add(fileName, mod);
                if (!Mod.Mods.ContainsKey(id))
                    Mod.Mods.Add(id, mod);
            }
            progressHandler.Progress = ((float)i / (float)ToLoad.Count) * 100f;
        }
        progressHandler.Progress = 100f;
        Loading = false;
    }

    protected void Tick(object sender, EventArgs e)
    {
        FindMods();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected internal void OnPropertyChanged(string propertyname)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
    }


    protected ObservableCollection<ListViewItem> _Mods = new ObservableCollection<ListViewItem>();
    
    public ObservableCollection<ListViewItem> Mods
    {
        get
        {
            return _Mods;
        }
    }

    protected int _SelectedMod = -1;

    public int SelectedMod
    {
        get
        {
            return _SelectedMod;
        }
        set
        {
            _SelectedMod = value;
            if (_SelectedMod >= 0)
                MainWindow.Instance.SetMod(((ModViewModel)_Mods[_SelectedMod].DataContext));
        }
    }
}
