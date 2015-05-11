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

public class ModProjectButtonViewModel : INotifyPropertyChanged
{
    public ModProjectViewModel ProjectViewModel;
    public ModProject.Button Button;

    public ModProjectButtonViewModel(ModProjectViewModel projectViewModel, ModProject.Button button)
    {
        this.ProjectViewModel = projectViewModel;
        this.Button = button;
        this.Button.Name.OnChange += NameChanged;
        this.Button.Description.OnChange += DescriptionChanged;

        CheckForErrors();
    }

    protected void NameChanged(object sender, EventArgs e)
    {
        ProjectViewModel.Project.SaveConfiguration();
        CheckForErrors();
    }

    protected void DescriptionChanged(object sender, EventArgs e)
    {
        ProjectViewModel.Project.SaveConfiguration();
        CheckForErrors();
    }

    protected Visibility _IDError = Visibility.Collapsed;
    protected Visibility _NameError = Visibility.Collapsed;
    protected Visibility _Error = Visibility.Collapsed;

    public Visibility NameError
    {
        get
        {
            return _NameError;
        }
    }

    public Visibility Error
    {
        get
        {
            return _Error;
        }
    }

    public Visibility IDError
    {
        get
        {
            return _IDError;
        }
    }

    public void CheckForErrors()
    {
        _NameError = Visibility.Collapsed;

        foreach (string LangCode in ProjectViewModel.Project.Languages)
        {
            if (Button.Name.GetString(LangCode).Trim() == "")
                _NameError = Visibility.Visible;
        }

        _IDError = Visibility.Collapsed;

        foreach (ModProject.Button button in ProjectViewModel.Project.Buttons)
        {   
            if (button != Button && button.ID == Button.ID)
                _IDError = Visibility.Visible;
        }
        if (Button.ID == "")
            _IDError = Visibility.Visible;

        _Error = _IDError == Visibility.Visible || _NameError == Visibility.Visible ? Visibility.Visible : Visibility.Collapsed;

        OnPropertyChanged("NameError");
        OnPropertyChanged("IDError");
        OnPropertyChanged("Error");
        ProjectViewModel.CheckForErrors();
    }

    public string ID
    {
        get
        {
            return Button.ID;
        }
        set
        {
            Button.ID = value;
            ProjectViewModel.Project.SaveConfiguration();
            OnPropertyChanged("ID");
            CheckForErrors();
        }
    }

    public string StandardKey
    {
        get
        {
            return Button.StandardKey;
        }
        set
        {
            Button.StandardKey = value;
            ProjectViewModel.Project.SaveConfiguration();
            OnPropertyChanged("StandardKey");
            CheckForErrors();
        }
    }


    public MultilingualValue Name
    {
        get
        {
            return Button.Name;
        }
    }

    public MultilingualValue Description
    {
        get
        {
            return Button.Description;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected internal void OnPropertyChanged(string propertyname)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
    }

    public ObservableCollection<string> Languages
    {
        get
        {
            return ProjectViewModel.Languages;
        }
    }
}
