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

using System.ComponentModel;
using System.Windows;
using ModAPI.Utils;

namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class OperationPending : BaseSubWindow
    {
        protected bool Cancelable = false;
        protected Schedule.Task Task;
        protected ProgressHandler ProgressHandler;
        protected string TaskName;

        public delegate void Cancel();

        protected Cancel CancelCallback;
        protected string LangKey;
        public bool Completed;
        protected bool AutoClose;

        public OperationPending(Schedule.Task task)
        {
            InitializeComponent();
            this.Task = task;
            Init();
        }

        public OperationPending(string langKey, Schedule.Task task)
            : base(langKey)
        {
            InitializeComponent();
            LangKey = langKey;
            this.Task = task;
            Init();
        }

        public OperationPending(string langKey, string taskName, ProgressHandler progressHandler, Cancel cancelCallback = null, bool autoClose = false)
            : base(langKey)
        {
            InitializeComponent();
            this.ProgressHandler = progressHandler;
            this.TaskName = taskName;
            CancelCallback = cancelCallback;
            this.AutoClose = autoClose;

            LangKey = langKey;
            Init();
        }

        private void Init()
        {
            if (Task != null)
            {
                TaskName = (string) Task.Parameters[0];
                ProgressHandler = (ProgressHandler) Task.Parameters[1];
                CancelCallback = ((Cancel) Task.Parameters[2]);
                AutoClose = ((bool) Task.Parameters[3]);
            }

            ProgressHandler.OnChange += (s, e) => Dispatcher.Invoke(delegate { ChangeProgress(); });
            ProgressHandler.OnComplete += (s, e) => Dispatcher.Invoke(delegate { OperationComplete(); });
            if (CancelCallback == null)
            {
                CancelButton.Visibility = Visibility.Collapsed;
            }
            if (AutoClose)
            {
                ConfirmButton.Visibility = Visibility.Collapsed;
            }
            SetCloseable(false);
            ChangeProgress();

            if (ProgressHandler.Progress == 100f)
            {
                OperationComplete();
            }
        }

        private void OperationComplete()
        {
            Completed = true;
            if (AutoClose)
            {
                if (Task != null)
                {
                    Task.Complete();
                }
                Close();
            }
            else
            {
                ConfirmButton.Opacity = 1.0;
                ConfirmButton.IsEnabled = true;
            }
        }

        private void ChangeProgress()
        {
            ProgressBar.Value = ProgressHandler.Progress;
            Utils.Language.SetKey(CurrentTask, "Tasks." + TaskName + "." + ProgressHandler.Task);
            if (ProgressHandler.Task != null && ProgressHandler.Task.StartsWith("Error."))
            {
                ConfirmButton.Visibility = Visibility.Visible;
                ConfirmButton.Opacity = 1.0;
                ConfirmButton.IsEnabled = true;
                Completed = true;
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (Completed)
            {
                if (Task != null)
                {
                    Task.Complete();
                }
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CancelCallback();
            if (Task != null)
            {
                Task.Complete();
            }
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (CancelCallback == null && !Completed)
            {
                e.Cancel = true;
            }
            else
            {
                if (!Completed)
                {
                    CancelCallback();
                }
                if (Task != null)
                {
                    Task.Complete();
                }
            }
        }
    }
}
