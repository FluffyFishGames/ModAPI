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

using System.ComponentModel;
using ModAPI.Configurations;
using ModAPI.Data;

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
            var ret = button.Name.GetString(Configuration.CurrentLanguage.Key, "EN");
            if (ret == "" && button.Name.GetLanguages().Count > 0)
            {
                ret = button.Name.GetString(button.Name.GetLanguages()[0]);
            }
            return ret;
        }
    }

    public string Description
    {
        get
        {
            var ret = button.Description.GetString(Configuration.CurrentLanguage.Key, "EN");
            if (ret == "" && button.Description.GetLanguages().Count > 0)
            {
                ret = button.Description.GetString(button.Name.GetLanguages()[0]);
            }
            return ret;
        }
    }

    public string Key
    {
        get { return AssignedKey; }
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
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
