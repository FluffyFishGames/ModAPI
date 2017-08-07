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
using ModAPI.Attributes;
using UnityEngine;

namespace ModAPI
{
    public class Resources
    {
        [AddModname]
        public static Texture2D GetTexture(string resourceIdentifier)
        {
            return null;
        }

        public static Texture2D GetTexture(string resourceIdentifier, string ModID)
        {
            var key = ModID + "::" + resourceIdentifier.ToLower();
            if (TextureResources.ContainsKey(key))
            {
                return TextureResources[key];
            }
            return null;
        }

        protected static Dictionary<string, Texture2D> TextureResources = new Dictionary<string, Texture2D>();

        internal static void Add(Mod mod, string path, Texture2D texture)
        {
            var key = mod.ID + "::" + path.ToLower();
            if (!TextureResources.ContainsKey(key))
            {
                TextureResources.Add(key, texture);
            }
        }
    }
}
