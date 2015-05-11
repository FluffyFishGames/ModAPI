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

public class ModProjectsViewModel : INotifyPropertyChanged
{
    protected List<ModProject> ModProjects = new List<ModProject>();
    protected DispatcherTimer Timer;

    public ModProjectsViewModel()
    {
        _Projects = new ObservableCollection<ListViewItem>();
        
        Timer = new DispatcherTimer();
        Timer.Tick += new EventHandler(Tick);
        Timer.Interval = new TimeSpan((long) (10000000)); // 1s
        Timer.Start();

        FindProjects();
    }

    public void CreateProject(string ID)
    {
        ModProjects.Add(new ModProject(App.Game, ID));
        FindProjects();
        _SelectedProject = ModProjects.Count;
        OnPropertyChanged("SelectedProject");
    }

    public void Remove(ModProject project)
    {
        for (int i = 0; i < _Projects.Count; i++)
        {
            ModProjectViewModel vm = (ModProjectViewModel) (_Projects[i].DataContext);
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
            string path = System.IO.Path.GetFullPath(Configuration.GetPath("projects") + System.IO.Path.DirectorySeparatorChar + App.Game.GameConfiguration.ID);
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            string[] files = System.IO.Directory.GetDirectories(path);
            foreach (string file in files)
            {
                System.IO.FileAttributes attr = System.IO.File.GetAttributes(@file);
                if ((attr & System.IO.FileAttributes.Directory) == System.IO.FileAttributes.Directory)
                {
                    string id = System.IO.Path.GetFileName(file);
                    bool add = true;
                    foreach (ModProject project in ModProjects)
                    {
                        if (project.ID == id)
                        {
                            add = false;
                            break;
                        }
                    }
                    if (add && ModAPI.Data.Mod.Header.VerifyModID(id))
                        ModProjects.Add(new ModProject(App.Game, id));
                }
            }

            /** Add new projects **/
            foreach (ModProject project in ModProjects)
            {
                bool add = true;
                foreach (ListViewItem item in _Projects)
                {
                    if (((ModProjectViewModel)item.DataContext).Project == project)
                    {
                        add = false;
                        break;
                    }
                }
                if (add)
                {
                    ListViewItem newItem = new ListViewItem();
                    newItem.DataContext = new ModProjectViewModel(project);
                    Grid panel = new Grid();
                    Image image = new Image();
                    image.Height = 20;
                    BitmapImage source = new BitmapImage();
                    source.BeginInit();
                    source.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/Icon_Warning.png");
                    source.EndInit();
                    image.Source = source;
                    image.HorizontalAlignment = HorizontalAlignment.Right;
                    //image.Margin = new Thickness(0, 0, 5, 0);
                    image.SetBinding(Image.VisibilityProperty, "Error");


                    Image image2 = new Image();
                    image2.Height = 20;
                    BitmapImage source2 = new BitmapImage();
                    source2.BeginInit();
                    source2.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/Icon_Error.png");
                    source2.EndInit();
                    image2.Source = source2;
                    image2.HorizontalAlignment = HorizontalAlignment.Right;
                    image.Margin = new Thickness(5, 0, 0, 0);
                    image2.SetBinding(Image.VisibilityProperty, "SaveError");


                    TextBlock label = new TextBlock();
                    label.SetBinding(TextBlock.TextProperty, "ID");

                    panel.Children.Add(label);
                    panel.Children.Add(image);
                    panel.Children.Add(image2);
                    
                    newItem.Content = panel;
                    _Projects.Add(newItem);
                }
            }

            for (int i = 0; i < ModProjects.Count; i++)
            {
                ModProject p = ModProjects[i];
                string checkPath = Configuration.GetPath("projects") + System.IO.Path.DirectorySeparatorChar + App.Game.GameConfiguration.ID + System.IO.Path.DirectorySeparatorChar + p.ID;
                if (!System.IO.Directory.Exists(checkPath))
                {
                    ModProjects.RemoveAt(i);
                    i--;
                }
            }
            /** Remove deleted projects **/
            for (int i = 0; i < _Projects.Count; i++)
            {
                ListViewItem item = _Projects[i];
                ModProject check = ((ModProjectViewModel)item.DataContext).Project;
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
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
    }

    protected ObservableCollection<ListViewItem> _Projects;
    
    public ObservableCollection<ListViewItem> Projects
    {
        get
        {
            return _Projects;
        }
    }

    protected int _SelectedProject = -1;

    public int SelectedProject
    {
        get
        {
            return _SelectedProject;
        }
        set
        {
            _SelectedProject = value;
            if (_SelectedProject >= 0)
                MainWindow.Instance.SetProject(((ModProjectViewModel)_Projects[_SelectedProject].DataContext));
        }
    }
}
