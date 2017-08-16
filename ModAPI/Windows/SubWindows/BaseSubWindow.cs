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

using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ModAPI.Windows.SubWindows
{
    public class BaseSubWindow : Window
    {
        public BaseSubWindow(string langKey)
        {
            Utils.Language.SetKey(this, langKey);
        }

        public BaseSubWindow()
        {
        }

        protected bool Closeable = true;

        public void SetCloseable(bool closeable)
        {
            this.Closeable = closeable;
            var b = ((Button) GetTemplateChild("PART_Close"));
            if (b != null)
            {
                b.Visibility = closeable ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public void ShowSubWindow()
        {
            MainWindow.OpenWindow(this);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ((Rectangle) GetTemplateChild("PART_Mover")).MouseDown += (sender, e) => { DragMove(); };
            ((Button) GetTemplateChild("PART_Close")).Click += (sender, e) => { Close(); };
            ((Button) GetTemplateChild("PART_Close")).Visibility = Closeable ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
