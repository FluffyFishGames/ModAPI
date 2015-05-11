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
    public partial class OperationPending : BaseSubWindow
    {
        protected bool Cancelable = false;
        protected Utils.Schedule.Task Task;
        protected ProgressHandler progressHandler;
        protected string TaskName;
        public delegate void Cancel();
        protected Cancel CancelCallback;
        protected string LangKey;
        public bool Completed = false;
        protected bool AutoClose = false;

        public OperationPending(Utils.Schedule.Task Task)
            : base()
        {
            InitializeComponent();
            this.Task = Task;
            Init();
        }

        public OperationPending(string langKey, Utils.Schedule.Task Task)
            : base(langKey)
        {
            InitializeComponent();
            this.LangKey = langKey;
            this.Task = Task;
            Init();
        }

        public OperationPending(string langKey, string TaskName, ProgressHandler progressHandler, Cancel cancelCallback = null, bool AutoClose = false)
            : base(langKey)
        {
            InitializeComponent();
            this.progressHandler = progressHandler;
            this.TaskName = TaskName;
            this.CancelCallback = cancelCallback;
            this.AutoClose = AutoClose;

            this.LangKey = langKey;
            Init();
        }

        private void Init()
        {
            if (this.Task != null)
            {
                this.TaskName = (string)this.Task.Parameters[0];
                this.progressHandler = (ProgressHandler)this.Task.Parameters[1];
                this.CancelCallback = ((Cancel)this.Task.Parameters[2]);
                this.AutoClose = ((bool)this.Task.Parameters[3]);
            }

            this.progressHandler.OnChange += (s, e) => Dispatcher.Invoke((Action)delegate() { ChangeProgress(); });
            this.progressHandler.OnComplete += (s, e) => Dispatcher.Invoke((Action)delegate() { OperationComplete(); });
            if (this.CancelCallback == null)
                this.CancelButton.Visibility = System.Windows.Visibility.Collapsed;
            if (this.AutoClose)
                this.ConfirmButton.Visibility = System.Windows.Visibility.Collapsed;
            SetCloseable(false);
            this.ChangeProgress();

            if (progressHandler.Progress == 100f)
                this.OperationComplete();
        }

        private void OperationComplete()
        {
            this.Completed = true;
            if (this.AutoClose)
            {
                if (Task != null) Task.Complete();
                this.Close();
            }
            else
            {
                this.ConfirmButton.Opacity = 1.0;
                this.ConfirmButton.IsEnabled = true;
            }
        }

        private void ChangeProgress()
        {
            this.ProgressBar.Value = this.progressHandler.Progress;
            Utils.Language.SetKey(this.CurrentTask, "Tasks." + this.TaskName + "." + this.progressHandler.Task);
            if (this.progressHandler.Task != null && this.progressHandler.Task.StartsWith("Error."))
            {
                this.ConfirmButton.Visibility = System.Windows.Visibility.Visible;
                this.ConfirmButton.Opacity = 1.0;
                this.ConfirmButton.IsEnabled = true;
                Completed = true;
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (Completed)
            {
                if (Task != null) Task.Complete();
                this.Close();
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.CancelCallback();
            if (Task != null) Task.Complete();
            this.Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (this.CancelCallback == null && !Completed)
            {
                e.Cancel = true;
            }
            else
            {
                if (!Completed)
                    this.CancelCallback();
                if (Task != null) Task.Complete();
            }
        }
    }
}
