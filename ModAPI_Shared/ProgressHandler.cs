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

namespace ModAPI
{
    public class ProgressHandler
    {
        public event EventHandler<EventArgs> OnChange;
        public event EventHandler<EventArgs> OnComplete;
        //public delegate void Change();
        //public delegate void Complete();
        //public Complete OnComplete;
        //public Change OnChange;
        protected string _Task;
        public string Task
        {
            get { return _Task; }
            set
            {
                _Task = value;
                OnChange?.Invoke(this, new EventArgs());
            }
        }
        protected float _Progress;
        protected bool Completed;

        public float Progress
        {
            get { return _Progress; }
            set
            {
                _Progress = value;
                OnChange?.Invoke(this, new EventArgs());
                /*if (OnChange != null)
                    OnChange();*/
                if (value == 100f)
                {
                    if (OnComplete != null && !Completed)
                    {
                        Completed = true;
                        OnComplete(this, new EventArgs());
                    }
                    /*if (OnComplete != null)
                        OnComplete();*/
                }
            }
        }
    }
}
