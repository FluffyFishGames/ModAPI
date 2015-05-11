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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModAPI.Components
{
    /// <summary>
    /// Interaktionslogik für ModProjectButton.xaml
    /// </summary>
    public partial class ModProjectButton : UserControl
    {
        public ModProjectButton()
        {
            InitializeComponent();
        }

        private void RemoveButton(object sender, RoutedEventArgs e)
        {
            ModProjectButtonViewModel viewModel = ((ModProjectButtonViewModel) DataContext);
            viewModel.ProjectViewModel.RemoveButton(viewModel.Button);
        }

        protected List<Key> PressedKeys = new List<Key>();

        private void ChangeStandardKey(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.KeysConverter kc = new System.Windows.Forms.KeysConverter();
            string a = "";
            PressedKeys.Sort();
            PressedKeys.Reverse();
            foreach (Key k in PressedKeys)
            {
                if (a != "") a += "+";
                a += kc.ConvertToString(k);
            }

            if (e.Key == Key.RightAlt)
            {
                PressedKeys.Remove(Key.LeftCtrl);
            }
            PressedKeys.Remove(e.Key);
            StandardKeyInput.Focus(); 
            e.Handled = true;

            if (Ignore)
            {
                if (PressedKeys.Count == 0)
                    Ignore = false;
                return;
            }
            else
            {
                ((ModProjectButtonViewModel)DataContext).StandardKey = a;
                if (PressedKeys.Count > 0) 
                    Ignore = true;
            }
        }

        protected bool Ignore = false;

        private void StandardKeyDown(object sender, KeyEventArgs e)
        {
            StandardKeyInput.Focus();
            e.Handled = true; 
            if (PressedKeys.Contains(e.Key))
                return;
            PressedKeys.Add(e.Key);
        }
    }
}
