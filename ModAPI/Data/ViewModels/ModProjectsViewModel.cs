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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using ModAPI;
using ModAPI.Configurations;
using ModAPI.Data;
using ModAPI.Data.Models;

public class ModProjectsViewModel : INotifyPropertyChanged
{
    protected List<ModProject> ModProjects = new List<ModProject>();
    protected DispatcherTimer Timer;

    public ModProjectsViewModel()
    {
        _Projects = new ObservableCollection<ListViewItem>();

        Timer = new DispatcherTimer();
        Timer.Tick += Tick;
        Timer.Interval = new TimeSpan(10000000); // 1s
        Timer.Start();

        FindProjects();
    }

    public void CreateProject(string id)
    {
        ModProjects.Add(new ModProject(App.Game, id));
        FindProjects();
        _SelectedProject = ModProjects.Count;
        OnPropertyChanged("SelectedProject");
    }

    public void Remove(ModProject project)
    {
        for (var i = 0; i < _Projects.Count; i++)
        {
            var vm = (ModProjectViewModel) (_Projects[i].DataContext);
            if (vm.Project == project)
            {
                _Projects.RemoveAt(i);
                break;
            }
        }
        ModProjects.Remove(project);
        project.Remove();
    }

    protected void FindProjects()
    {
        try
        {
            var path = Path.GetFullPath(Configuration.GetPath("projects") + Path.DirectorySeparatorChar + App.Game.GameConfiguration.Id);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var files = Directory.GetDirectories(path);
            foreach (var file in files)
            {
                var attr = File.GetAttributes(file);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    var id = Path.GetFileName(file);
                    var add = true;
                    foreach (var project in ModProjects)
                    {
                        if (project.Id == id)
                        {
                            add = false;
                            break;
                        }
                    }
                    if (add && Mod.Header.VerifyModId(id))
                    {
                        ModProjects.Add(new ModProject(App.Game, id));
                    }
                }
            }

            /** Add new projects **/
            foreach (var project in ModProjects)
            {
                var add = true;
                foreach (var item in _Projects)
                {
                    if (((ModProjectViewModel) item.DataContext).Project == project)
                    {
                        add = false;
                        break;
                    }
                }
                if (add)
                {
                    var newItem = new ListViewItem
                    {
                        DataContext = new ModProjectViewModel(project)
                    };
                    var panel = new Grid();
                    var image = new Image
                    {
                        Height = 20
                    };
                    var source = new BitmapImage();
                    source.BeginInit();
                    source.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/Icon_Warning.png");
                    source.EndInit();
                    image.Source = source;
                    image.HorizontalAlignment = HorizontalAlignment.Right;
                    //image.Margin = new Thickness(0, 0, 5, 0);
                    image.SetBinding(Image.VisibilityProperty, "Error");

                    var image2 = new Image
                    {
                        Height = 20
                    };
                    var source2 = new BitmapImage();
                    source2.BeginInit();
                    source2.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/Icon_Error.png");
                    source2.EndInit();
                    image2.Source = source2;
                    image2.HorizontalAlignment = HorizontalAlignment.Right;
                    image.Margin = new Thickness(5, 0, 0, 0);
                    image2.SetBinding(Image.VisibilityProperty, "SaveError");

                    var label = new TextBlock();
                    label.SetBinding(TextBlock.TextProperty, "Id");

                    panel.Children.Add(label);
                    panel.Children.Add(image);
                    panel.Children.Add(image2);

                    newItem.Content = panel;
                    _Projects.Add(newItem);
                }
            }

            for (var i = 0; i < ModProjects.Count; i++)
            {
                var p = ModProjects[i];
                var checkPath = Configuration.GetPath("projects") + Path.DirectorySeparatorChar + App.Game.GameConfiguration.Id + Path.DirectorySeparatorChar + p.Id;
                if (!Directory.Exists(checkPath))
                {
                    ModProjects.RemoveAt(i);
                    i--;
                }
            }
            /** Remove deleted projects **/
            for (var i = 0; i < _Projects.Count; i++)
            {
                var item = _Projects[i];
                var check = ((ModProjectViewModel) item.DataContext).Project;
                if (!ModProjects.Contains(check))
                {
                    _Projects.RemoveAt(i);
                    i--;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("F", e.ToString());
        }
    }

    protected void Tick(object sender, EventArgs e)
    {
        FindProjects();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected internal void OnPropertyChanged(string propertyname)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
    }

    protected ObservableCollection<ListViewItem> _Projects;

    public ObservableCollection<ListViewItem> Projects => _Projects;
    protected int _SelectedProject = -1;

    public int SelectedProject
    {
        get => _SelectedProject;
        set
        {
            _SelectedProject = value;
            if (_SelectedProject >= 0)
            {
                MainWindow.Instance.SetProject(((ModProjectViewModel) _Projects[_SelectedProject].DataContext));
            }
        }
    }
}
