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

using System.Collections.Generic;

namespace ModAPI
{
    public class Mods
    {
        public static Dictionary<string, Mod> LoadedMods = new Dictionary<string, Mod>();

        public static void Add(Mod mod)
        {
            LoadedMods.Add(mod.ID, mod);
        }

        public static bool IsModLoaded(string ModID)
        {
            return LoadedMods.ContainsKey(ModID);
        }
    }
}
