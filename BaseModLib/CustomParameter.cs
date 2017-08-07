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

        public CustomParameter(List<string> Possible)
        {
            for (var i = 0; i < Possible.Count; i++)
            {
                Possible[i] = Possible[i].ToLower();
            }
            this.Possible = Possible;
        }

        public CustomParameter(string[] Possible)
        {
            for (var i = 0; i < Possible.Length; i++)
            {
                Possible[i] = Possible[i].ToLower();
            }
            this.Possible = Possible.ToList();
        }

        public CustomParameter(ParameterType type, bool Required)
        {
            ParameterType = type;
            this.Required = Required;
        }

        public CustomParameter(List<string> Possible, bool Required)
        {
            for (var i = 0; i < Possible.Count; i++)
            {
                Possible[i] = Possible[i].ToLower();
            }
            this.Possible = Possible;
            this.Required = Required;
        }

        public CustomParameter(string[] Possible, bool Required)
        {
            for (var i = 0; i < Possible.Length; i++)
            {
                Possible[i] = Possible[i].ToLower();
            }
            this.Possible = Possible.ToList();
            this.Required = Required;
        }
    }
}
