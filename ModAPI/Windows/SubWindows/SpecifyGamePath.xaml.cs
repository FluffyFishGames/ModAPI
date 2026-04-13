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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using ModAPI.Data;
using ModAPI.Utils;
using System.IO;
using Path = System.IO.Path;

namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class SpecifyGamePath : BaseSubWindow
    {
        protected Schedule.Task Task;
        protected bool Completed;

        public SpecifyGamePath(Schedule.Task task)
        {
            InitializeComponent();
            Task = task;
            GamePath.Text = ((Game)task.Parameters[0]).GamePath;
            Check();
        }

        public SpecifyGamePath(string langKey, Schedule.Task task)
            : base(langKey)
        {
            InitializeComponent();
            Task = task;
            var game = (Game)task.Parameters[0];
            GamePath.Text = game.GamePath;
            GameNameLabel.Text = !string.IsNullOrEmpty(game.GameConfiguration.Name)
                ? game.GameConfiguration.Name
                : game.GameConfiguration.Id;
            Check();
        }

        protected void Check()
        {
            var game = (Game)Task.Parameters[0];
            game.GamePath = GamePath.Text;

            // 경로 지정 팝업에서는 SelectFile(실행파일)만 존재하면 유효
            // CheckGamePath()는 모든 DLL을 검사하므로 여기서는 사용하지 않음
            var valid = IsGamePathValid(game);

            AcceptIcon.Visibility = valid ? Visibility.Visible : Visibility.Hidden;
            DeclineIcon.Visibility = valid ? Visibility.Hidden : Visibility.Visible;
            ConfirmButton.Opacity = valid ? 1f : 0.5f;
            ConfirmButton.IsEnabled = valid;
        }

        protected bool IsGamePathValid(Game game)
        {
            var path = game.GamePath;
            if (string.IsNullOrWhiteSpace(path))
                return false;

            // 파일이 선택된 경우 → 폴더로 변환
            string folder = path;
            if (File.Exists(path) && !Directory.Exists(path))
                folder = Path.GetDirectoryName(path);

            if (!Directory.Exists(folder))
                return false;

            // SelectFile(실행파일)이 존재하는지만 확인
            var selectFile = game.GameConfiguration.SelectFile;
            if (string.IsNullOrWhiteSpace(selectFile))
                return false;

            return File.Exists(Path.Combine(folder, selectFile));
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var game = (Game)Task.Parameters[0];
            // 파일이 선택된 경우 → 폴더로 변환
            var path = GamePath.Text;
            if (File.Exists(path) && !Directory.Exists(path))
                path = Path.GetDirectoryName(path);
            game.GamePath = path;

            if (IsGamePathValid(game))
            {
                Completed = true;
                Task.Complete();
                Close();
            }
        }

        private void GamePath_TextInput(object sender, TextCompositionEventArgs e)
        {
            Check();
        }

        private void GamePath_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check();
        }

        private void OnClickBrowse(object sender, RoutedEventArgs e)
        {
            // App.Game 대신 실제 대상 게임의 SelectFile 사용
            var targetGame = (Game)Task.Parameters[0];
            var selectFile = targetGame.GameConfiguration.SelectFile;
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = selectFile + "|" + selectFile,
                RestoreDirectory = true
            };
            if (openFileDialog1.ShowDialog() == true)
            {
                GamePath.Text = Path.GetDirectoryName(openFileDialog1.FileName);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (!Completed)
            {
                Environment.Exit(0);
            }
        }
    }
}