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
using System.ComponentModel;
using System.Windows;
using ModAPI.Data;
using ModAPI.Data.Models;

public class ModProjectButtonViewModel : INotifyPropertyChanged
{
    public ModProjectViewModel ProjectViewModel;
    public ModProject.Button Button;

    public ModProjectButtonViewModel(ModProjectViewModel projectViewModel, ModProject.Button button)
    {
        ProjectViewModel = projectViewModel;
        Button = button;
        Button.Name.OnChange += NameChanged;
        Button.Description.OnChange += DescriptionChanged;

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

    protected Visibility _IdError = Visibility.Collapsed;
    protected Visibility _NameError = Visibility.Collapsed;
    protected Visibility _Error = Visibility.Collapsed;

    public Visibility NameError
    {
        get { return _NameError; }
    }

    public Visibility Error
    {
        get { return _Error; }
    }

    public Visibility IdError
    {
        get { return _IdError; }
    }

    public void CheckForErrors()
    {
        _NameError = Visibility.Collapsed;

        foreach (var langCode in ProjectViewModel.Project.Languages)
        {
            if (Button.Name.GetString(langCode).Trim() == "")
            {
                _NameError = Visibility.Visible;
            }
        }

        _IdError = Visibility.Collapsed;

        foreach (var button in ProjectViewModel.Project.Buttons)
        {
            if (button != Button && button.Id == Button.Id)
            {
                _IdError = Visibility.Visible;
            }
        }
        if (Button.Id == "")
        {
            _IdError = Visibility.Visible;
        }

        _Error = IdError == Visibility.Visible || _NameError == Visibility.Visible ? Visibility.Visible : Visibility.Collapsed;

        OnPropertyChanged("NameError");
        OnPropertyChanged("IDError");
        OnPropertyChanged("Error");
        ProjectViewModel.CheckForErrors();
    }

    public string Id
    {
        get { return Button.Id; }
        set
        {
            Button.Id = value;
            ProjectViewModel.Project.SaveConfiguration();
            OnPropertyChanged("ID");
            CheckForErrors();
        }
    }

    public string StandardKey
    {
        get { return Button.StandardKey; }
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
        get { return Button.Name; }
    }

    public MultilingualValue Description
    {
        get { return Button.Description; }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected internal void OnPropertyChanged(string propertyname)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }

    public ObservableCollection<string> Languages
    {
        get { return ProjectViewModel.Languages; }
    }
}
