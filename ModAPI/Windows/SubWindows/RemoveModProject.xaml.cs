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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class RemoveModProject : BaseSubWindow
    {
        public object Data;

        public RemoveModProject(string removeList, object data)
            : base()
        {
            InitializeComponent();
            this.Data = data;
            Init(removeList);
        }

        public RemoveModProject(string langKey, string removeList, object data)
            : base(langKey)
        {
            InitializeComponent();
            this.Data = data;
            Init(removeList);
        }

        protected void Init(string removeList)
        {
            this.RemoveList.Text = removeList;
            this.ConfirmButton.Click += (a, b) =>
            {
                if (Confirm != null)
                    Confirm(Data);
                Close();
            };
            this.CancelButton.Click += (a, b) =>
            {
                Close();
            };
        }

        public delegate void OnConfirm(object data);
        public OnConfirm Confirm;
    }
}
