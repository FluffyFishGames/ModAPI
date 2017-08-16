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
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ModAPI;
using ModAPI.Configurations;
using ModAPI.Data;
using ModAPI.Utils;
using Path = System.IO.Path;

public class ModsViewModel : INotifyPropertyChanged
{
    protected DispatcherTimer Timer;
    protected bool _SelectNewestModVersions;
    protected bool FirstBatchLoaded;

    public bool SelectNewestModVersions
    {
        set
        {
            if (FirstBatchLoaded)
            {
                SelectNewestVersions();
            }
            else
            {
                _SelectNewestModVersions = value;
            }
        }
        get { return _SelectNewestModVersions; }
    }

    public void Update()
    {
        foreach (var li in Mods)
        {
            var mv = (ModViewModel) li.DataContext;
            mv.Update();
        }
    }

    public ModsViewModel()
    {
        _Mods = new ObservableCollection<ListViewItem>();
        Configuration.OnLanguageChanged += Update;

        Timer = new DispatcherTimer();
        Timer.Tick += Tick;
        Timer.Interval = new TimeSpan(10000000); // 1s
        Timer.Start();

        FindMods();
    }

    protected Dictionary<string, Mod> LoadedFiles = new Dictionary<string, Mod>();
    protected Regex Validation = new Regex("^([a-zA-Z0-9_]+)-([0-9\\.]+)-([0-9abcdef]{32})\\.mod$");
    protected bool Loading;

    protected void FindMods()
    {
        try
        {
            if (Loading)
            {
                return;
            }
            var path = Path.GetFullPath(Configuration.GetPath("mods") + Path.DirectorySeparatorChar + App.Game.GameConfiguration.Id);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var keys = LoadedFiles.Keys.ToArray();
            for (var i = 0; i < keys.Length; i++)
            {
                var file = keys[i];
                if (!File.Exists(file))
                {
                    var mod = LoadedFiles[file];
                    var id = LoadedFiles[file].Id + "-" + LoadedFiles[file].HeaderData.GetVersion();
                    Mod.Mods.Remove(id);
                    for (var j = 0; j < _Mods.Count; j++)
                    {
                        var vm = (ModViewModel) _Mods[j].DataContext;
                        if (vm.VersionsData.Values.Contains(mod))
                        {
                            vm.VersionsData.Remove(Mod.Header.ParseModVersion(mod.HeaderData.GetVersion()));
                            if (vm.VersionsData.Count == 0)
                            {
                                _Mods.RemoveAt(j);
                            }
                            break;
                        }
                    }
                    LoadedFiles.Remove(file);
                }
            }

            var files = Directory.GetFiles(path);
            var toLoad = new List<string>();
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                if (!LoadedFiles.ContainsKey(file) && Validation.IsMatch(fileName))
                {
                    toLoad.Add(file);
                }
            }

            if (toLoad.Count > 0)
            {
                Loading = true;
                var progressHandler = new ProgressHandler();
                var t = new Thread(delegate() { LoadMods(toLoad, progressHandler); });
                progressHandler.Task = "LoadingMods";
                progressHandler.OnComplete += (s, e) => MainWindow.Instance.Dispatcher.Invoke(delegate { UpdateMods(); });
                Schedule.AddTask("GUI", "OperationPending", null, new object[] { "LoadingMods", progressHandler, null, true });
                t.Start();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    protected void UpdateMods()
    {
        foreach (var kv in Mod.Mods)
        {
            var add = true;
            ModViewModel alreadyVm = null;
            foreach (var i in _Mods)
            {
                var vm = ((ModViewModel) i.DataContext);
                if (vm.VersionsData.Values.Contains(kv.Value))
                {
                    add = false;
                }
                if (vm.Id == kv.Value.Id)
                {
                    alreadyVm = vm;
                }
            }
            if (add)
            {
                var mod = kv.Value;
                if (alreadyVm != null)
                {
                    alreadyVm.VersionsData.Add(Mod.Header.ParseModVersion(mod.HeaderData.GetVersion()), mod);
                    alreadyVm.OnPropertyChanged("Version");
                    alreadyVm.OnPropertyChanged("Name");
                }
                else
                {
                    var item = new ListViewItem();

                    var outerPanel = new StackPanel();
                    outerPanel.Orientation = Orientation.Horizontal;
                    outerPanel.Margin = new Thickness(-5, 0, 0, 0);
                    var checkBox = new CheckBox();
                    checkBox.SetBinding(CheckBox.IsCheckedProperty, "Selected");
                    outerPanel.Children.Add(checkBox);

                    var panel = new StackPanel();

                    var textBlock = new TextBlock();
                    textBlock.SetBinding(TextBlock.TextProperty, "Name");
                    textBlock.Style = (Style) Application.Current.FindResource("HeaderLabel");

                    panel.Children.Add(textBlock);

                    var textBlock2 = new TextBlock();
                    textBlock2.SetBinding(TextBlock.TextProperty, "Version");
                    textBlock2.FontSize = 12;
                    textBlock2.Style = (Style) Application.Current.FindResource("NormalLabel");
                    panel.Children.Add(textBlock2);
                    outerPanel.Children.Add(panel);

                    var mvm = new ModViewModel(mod);
                    item.DataContext = mvm;
                    item.Content = outerPanel;
                    _Mods.Add(item);
                }
            }
        }

        foreach (var item in _Mods)
        {
            var vm = (ModViewModel) item.DataContext;
            vm.Initialized();
        }
        FirstBatchLoaded = true;
        if (_SelectNewestModVersions)
        {
            SelectNewestVersions();
        }
    }

    public void SelectNewestVersions()
    {
        foreach (var item in _Mods)
        {
            var vm = (ModViewModel) item.DataContext;
            var v = vm.VersionsData.Keys.ToList();
            v.Sort();
            v.Reverse();
            foreach (var li in vm.Versions)
            {
                var versionModel = (ModVersionViewModel) li.DataContext;
                if (Mod.Header.ParseModVersion(versionModel.Mod.HeaderData.GetVersion()) == v[0])
                {
                    vm.SelectedVersion = li;
                    break;
                }
            }
        }
        _SelectNewestModVersions = false;
    }

    protected void LoadMods(List<string> toLoad, ProgressHandler progressHandler)
    {
        for (var i = 0; i < toLoad.Count; i++)
        {
            var fileName = toLoad[i];
            var collection = Validation.Match(Path.GetFileName(fileName));

            var id = collection.Groups[1].Captures[0].Value + "-" + collection.Groups[2].Captures[0].Value;

            var mod = new Mod(App.Game, fileName);
            if (Mod.Mods.ContainsKey(id) || mod.Load())
            {
                LoadedFiles.Add(fileName, mod);
                if (!Mod.Mods.ContainsKey(id))
                {
                    Mod.Mods.Add(id, mod);
                }
            }
            progressHandler.Progress = (i / (float) toLoad.Count) * 100f;
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
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }

    protected ObservableCollection<ListViewItem> _Mods = new ObservableCollection<ListViewItem>();

    public ObservableCollection<ListViewItem> Mods
    {
        get { return _Mods; }
    }

    protected int _SelectedMod = -1;

    public int SelectedMod
    {
        get { return _SelectedMod; }
        set
        {
            _SelectedMod = value;
            if (_SelectedMod >= 0)
            {
                MainWindow.Instance.SetMod(((ModViewModel) _Mods[_SelectedMod].DataContext));
            }
        }
    }
}
