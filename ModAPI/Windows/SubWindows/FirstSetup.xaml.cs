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
using System.Windows.Media;
using ModAPI.Configurations;

namespace ModAPI.Windows.SubWindows
{
    /// <summary>
    /// Interaktionslogik für TheForestBuildingsRemove.xaml
    /// </summary>
    public partial class FirstSetup : BaseSubWindow
    {
        // 환영 탭의 "환영합니다" 버튼으로 다시 연 것인지 여부. true면 순수 정보 팝업으로만
        // 동작한다 — 최초 실행 완료 처리(SetupDone 저장, FirstSetupDone() 호출)를 다시
        // 실행하지 않고, 닫아도 앱이 종료되지 않으며, 버튼 문구도 "계속" 대신 "닫기"로 바뀐다.
        protected bool IsReopen;

        public FirstSetup()
        {
            InitializeComponent();
            Check();
            SetCloseable(false);
        }

        public FirstSetup(string langKey)
            : base(langKey)
        {
            InitializeComponent();
            Check();
            SetCloseable(false);
        }

        public FirstSetup(string langKey, bool isReopen)
            : base(langKey)
        {
            InitializeComponent();
            IsReopen = isReopen;
            Check();
            SetCloseable(isReopen);
            if (isReopen)
            {
                ConfirmButtonIcon.Text = "";
                Utils.Language.SetKey(ConfirmButtonText, "Buttons.Close");
            }
        }

        protected void Check()
        {
            ApplyClassicThemeTextFix();
        }

        // NormalLabel(흰 글자+검은 그림자)은 원래 classic 테마의 이미지 배경 위에서
        // 읽히도록 설계된 전역 스타일이다. Fluent 계열 테마(Ocean/Sunset/Dark 등)는
        // 이미 자체 NormalLabel이 그림자 없이 테마에 맞는 색을 쓰도록 되어 있어 손댈
        // 필요가 없지만, classic 테마에서만 이 팝업의 배경(PanelCenter, 밝은 회색)과
        // 흰 글자+그림자 조합이 안 어울려서 여기서만 어두운 글자색으로 바꿔준다.
        // XAML에서 테마별로 분기할 방법이 마땅치 않아 코드에서 한 번만 처리한다 —
        // 다른 테마의 스타일/색상은 전혀 건드리지 않는다(classic일 때만 조건 통과).
        private void ApplyClassicThemeTextFix()
        {
            if (App.GetCurrentTheme() != "classic") return;

            var darkText = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x22));
            TextBlock1.Foreground = darkText;
            TextBlock1.Effect = null;
            WhatsNewTitleBlock.Foreground = darkText;
            WhatsNewTitleBlock.Effect = null;
            WhatsNewTextBlock.Foreground = darkText;
            WhatsNewTextBlock.Effect = null;
            WhatsNewBorder.Background = Brushes.White;
            WhatsNewBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(0xD0, 0xD0, 0xD0));
        }

        protected bool Completed;

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Completed = true;
            if (!IsReopen)
            {
                // 스팀 연결 / 버전 테이블 유지는 더 이상 여기서 묻지 않는다 — 설정 탭에서
                // 언제든 켤 수 있고, 기본값(false, opt-in)은 Configuration.GetString()이
                // 값이 없을 때 이미 false로 취급하므로 여기서 따로 저장할 필요가 없다.
                Configuration.SetString("SetupDone", "true", true);
                Configuration.Save();
            }
            Close();
            if (!IsReopen)
            {
                MainWindow.Instance.FirstSetupDone();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (!Completed && !IsReopen)
            {
                Environment.Exit(0);
            }
        }
    }
}