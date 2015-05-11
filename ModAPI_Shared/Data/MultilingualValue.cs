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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ModAPI.Data
{
    public class MultilingualValue
    {
        protected Dictionary<string, string> Langs = new Dictionary<string,string>();
        public event EventHandler<EventArgs> OnChange;

        public byte[] GetHashBytes()
        {
            List<byte> hashBytes = new List<byte>();
            foreach (KeyValuePair<string, string> kv in Langs)
            {
                hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(kv.Key));
                hashBytes.AddRange(System.Text.Encoding.UTF8.GetBytes(kv.Value));
            }
            return hashBytes.ToArray();
        }

        public List<string> GetLanguages()
        {
            return Langs.Keys.ToList();
        }

        public void SetString(string langKey, string value)
        {
            if (Langs.ContainsKey(langKey))
                Langs[langKey] = value;
            else
                Langs.Add(langKey, value);
            if (OnChange != null)
                OnChange(this, new EventArgs());
        }

        public string GetString(string langKey, string standardLanguage = "")
        {
            if (Langs.ContainsKey(langKey))
                return Langs[langKey];
            else if (standardLanguage != "" && Langs.ContainsKey(standardLanguage))
                return Langs[standardLanguage];
            else
                return "";
        }

        public void SetXML(XElement element)
        {
            if (element == null) return;
            this.Langs = new Dictionary<string,string>();
            foreach (XElement el in element.Elements())
            {
                string key = el.Name.LocalName.ToUpper();
                string value = el.Value;
                if (!this.Langs.ContainsKey(key))
                    this.Langs.Add(key, value);
            }
        }

        public XElement GetXML()
        {
            XElement element = new XElement("LangItem");
            foreach (KeyValuePair<string, string> kv in Langs)
            {
                XElement subElement = new XElement(kv.Key.ToUpper());
                subElement.Value = kv.Value;
                element.Add(subElement);
            }
            return element;
        }
    }
}
