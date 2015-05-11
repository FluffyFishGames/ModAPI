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

public class SettingsViewModel : INotifyPropertyChanged
{
    public SettingsViewModel()
    {
    }

    public void Changed()
    {
        OnPropertyChanged("Language");
        OnPropertyChanged("UpdateVersionsTable");
        OnPropertyChanged("AutoUpdate");
        OnPropertyChanged("UseSteam");
    }

    public int Language
    {
        get
        {
            return Configuration.Languages.Keys.ToList().IndexOf(Configuration.CurrentLanguage.Key.ToLower());
        }
        set
        {
            Configuration.ChangeLanguage(Configuration.Languages.Keys.ToList()[value]);
            Configuration.SetString("Language", Configuration.Languages.Keys.ToList()[value], true);
            Configuration.Save();
        }
    }

    public bool UpdateVersionsTable
    {
        get
        {
            return Configuration.GetString("UpdateVersions") == "true";
        }
        set
        {
            Configuration.SetString("UpdateVersions", value?"true":"false", true);
            Configuration.Save();
        }
    }

    public bool AutoUpdate
    {
        get
        {
            return Configuration.GetString("AutoUpdate") == "true";
        }
        set
        {
            Configuration.SetString("AutoUpdate", value ? "true" : "false", true);
            Configuration.Save();
        }
    }
    public bool UseSteam
    {
        get
        {
            return Configuration.GetString("UseSteam") == "true";
        }
        set
        {
            Configuration.SetString("UseSteam", value?"true":"false", true);
            Configuration.Save();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected internal void OnPropertyChanged(string propertyname)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
    }

}
