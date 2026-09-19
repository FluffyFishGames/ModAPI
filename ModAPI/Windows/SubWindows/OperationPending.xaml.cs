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
        protected string Details;

        // 완료 버튼을 눌러 창을 닫기 직전에 호출된다 — "완료 후 이어서 무언가를 실행해야
        // 하는" 흐름(예: 업데이트 적용 후 재시작)에서만 구독한다. 기존 호출부는 아무도
        // 구독하지 않으므로 동작 변화 없음.
        public event EventHandler Confirmed;

        public OperationPending(Schedule.Task task)
        {
            InitializeComponent();
            Task = task;
            Init();
        }

        public OperationPending(string langKey, Schedule.Task task)
            : base(langKey)
        {
            InitializeComponent();
            LangKey = langKey;
            Task = task;
            Init();
        }

        public OperationPending(string langKey, string taskName, ProgressHandler progressHandler, Cancel cancelCallback = null, bool autoClose = false, string details = null)
            : base(langKey)
        {
            InitializeComponent();
            ProgressHandler = progressHandler;
            TaskName = taskName;
            CancelCallback = cancelCallback;
            AutoClose = autoClose;
            Details = details;

            LangKey = langKey;
            Init();
        }

        // 다운로드 단계에서는 아직 릴리스 노트가 없을 수 있어(백그라운드로 병렬 조회하는 경우),
        // 나중에 별도로 채워 넣을 수 있도록 공개 메서드로도 제공한다.
        public void SetDetails(string details)
        {
            Details = details;
            if (Completed)
            {
                ShowDetailsIfAny();
            }
        }

        private void ShowDetailsIfAny()
        {
            if (string.IsNullOrWhiteSpace(Details)) return;
            DetailsTextBox.Text = Details;
            DetailsBorder.Visibility = Visibility.Visible;
            // 창 높이를 수동으로 조정하지 않는다 — SubWindow 스타일이
            // SizeToContent="WidthAndHeight"이므로, DetailsBorder가 보이는 순간
            // DetailsTextBox의 고정 Height(200)를 반영해서 창이 자동으로 커진다.
            // 수동으로 Height를 건드리면 이 자동 계산과 충돌해서 오히려 깨진다.
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
                ShowDetailsIfAny();
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
                Confirmed?.Invoke(this, EventArgs.Empty);
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
