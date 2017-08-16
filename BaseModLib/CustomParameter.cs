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
using System.Linq;

namespace ModAPI
{
    public class CustomParameter
    {
        public ParameterType ParameterType;
        public List<string> Possible;
        public bool Required = true;

        public CustomParameter(ParameterType type)
        {
            ParameterType = type;
        }

        public CustomParameter(List<string> possible)
        {
            for (var i = 0; i < possible.Count; i++)
            {
                possible[i] = possible[i].ToLower();
            }
            this.Possible = possible;
        }

        public CustomParameter(string[] possible)
        {
            for (var i = 0; i < possible.Length; i++)
            {
                possible[i] = possible[i].ToLower();
            }
            this.Possible = possible.ToList();
        }

        public CustomParameter(ParameterType type, bool required)
        {
            ParameterType = type;
            this.Required = required;
        }

        public CustomParameter(List<string> possible, bool required)
        {
            for (var i = 0; i < possible.Count; i++)
            {
                possible[i] = possible[i].ToLower();
            }
            this.Possible = possible;
            this.Required = required;
        }

        public CustomParameter(string[] possible, bool required)
        {
            for (var i = 0; i < possible.Length; i++)
            {
                possible[i] = possible[i].ToLower();
            }
            this.Possible = possible.ToList();
            this.Required = required;
        }
    }
}
