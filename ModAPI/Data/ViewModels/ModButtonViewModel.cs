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
    protected Mod.Header.Button Button;
    protected string AssignedKey = "";

    public ModButtonViewModel(Mod.Header.Button button)
    {
        Button = button;
        AssignedKey = Configuration.GetString("Mods." + button.Mod.Game.GameConfiguration.Id + "." + button.Mod.Id + ".Buttons." + button.Id);
        if (AssignedKey == "")
        {
            Key = button.StandardKey;
        }
    }

    public string Name
    {
        get
        {
            var ret = Button.Name.GetString(Configuration.CurrentLanguage.Key, "EN");
            if (ret == "" && Button.Name.GetLanguages().Count > 0)
            {
                ret = Button.Name.GetString(Button.Name.GetLanguages()[0]);
            }
            return ret;
        }
    }

    public string Description
    {
        get
        {
            var ret = Button.Description.GetString(Configuration.CurrentLanguage.Key, "EN");
            if (ret == "" && Button.Description.GetLanguages().Count > 0)
            {
                ret = Button.Description.GetString(Button.Name.GetLanguages()[0]);
            }
            return ret;
        }
    }

    public string Key
    {
        get => AssignedKey; set
        {
            AssignedKey = value;
            Configuration.SetString("Mods." + Button.Mod.Game.GameConfiguration.Id + "." + Button.Mod.Id + ".Buttons." + Button.Id, AssignedKey, true);
            Configuration.Save();
            OnPropertyChanged("Key");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected internal void OnPropertyChanged(string propertyname)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
    }
}
