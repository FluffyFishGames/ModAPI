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

public class ModButtonViewModel : INotifyPropertyChanged
{
    protected Mod.Header.Button button;
    protected string AssignedKey = "";

    public ModButtonViewModel(Mod.Header.Button button)
    {
        this.button = button;
        AssignedKey = Configuration.GetString("Mods." + button.Mod.Game.GameConfiguration.ID + "." + button.Mod.ID + ".Buttons." + button.ID);
        if (AssignedKey == "")
        {
            Key = button.StandardKey;

        }
    }

    public string Name
    {
        get
        {
            string ret = this.button.Name.GetString(Configuration.CurrentLanguage.Key, "EN");
            if (ret == "" && this.button.Name.GetLanguages().Count > 0)
                ret = this.button.Name.GetString(this.button.Name.GetLanguages()[0]);
            return ret;
        }
    }

    public string Description
    {
        get
        {
            string ret = this.button.Description.GetString(Configuration.CurrentLanguage.Key, "EN");
            if (ret == "" && this.button.Description.GetLanguages().Count > 0)
                ret = this.button.Description.GetString(this.button.Name.GetLanguages()[0]);
            return ret;
        }
    }

    public string Key
    {
        get
        {
            return AssignedKey;
        }
        set
        {
            AssignedKey = value;
            Configuration.SetString("Mods." + button.Mod.Game.GameConfiguration.ID + "." + button.Mod.ID + ".Buttons." + button.ID, AssignedKey, true);
            Configuration.Save();
            OnPropertyChanged("Key");
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected internal void OnPropertyChanged(string propertyname)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
    }

}
