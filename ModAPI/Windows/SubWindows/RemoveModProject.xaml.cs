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

namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class RemoveModProject : BaseSubWindow
    {
        public object Data;

        public RemoveModProject(string removeList, object data)
        {
            InitializeComponent();
            Data = data;
            Init(removeList);
        }

        public RemoveModProject(string langKey, string removeList, object data)
            : base(langKey)
        {
            InitializeComponent();
            Data = data;
            Init(removeList);
        }

        protected void Init(string removeList)
        {
            RemoveList.Text = removeList;
            ConfirmButton.Click += (a, b) =>
            {
                Confirm?.Invoke(Data);
                Close();
            };
            CancelButton.Click += (a, b) => { Close(); };
        }

        public delegate void OnConfirm(object data);

        public OnConfirm Confirm;
    }
}
