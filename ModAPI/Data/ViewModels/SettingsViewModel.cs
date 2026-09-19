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
using System.Linq;
using ModAPI.Configurations;

public class SettingsViewModel : INotifyPropertyChanged
{
    public void Changed()
    {
        OnPropertyChanged("Language");
        OnPropertyChanged("UpdateVersionsTable");
        OnPropertyChanged("CanUpdateVersionsTable");
        OnPropertyChanged("UseSteam");
        OnPropertyChanged("CanEditSteamPathManually");
        OnPropertyChanged("DevLog");
        OnPropertyChanged("ClearLogsOnStart");
    }

    public int Language
    {
        get => ModAPI.MainWindow.LanguageOrder.IndexOf(Configuration.CurrentLanguage.Key.ToLower());
        set
        {
            if (value >= 0 && value < ModAPI.MainWindow.LanguageOrder.Count)
            {
                var langKey = ModAPI.MainWindow.LanguageOrder[value];
                Configuration.ChangeLanguage(langKey);
                Configuration.SetString("Language", langKey, true);
                Configuration.Save();
            }
        }
    }

    // 최신버전유지/스팀연결은 사용자가 명시적으로 켜야만 동작하는 opt-in 방식이라,
    // 값이 없을 때(신규 설치 등) true가 아니라 false로 취급한다.
    public bool UpdateVersionsTable
    {
        get { return Configuration.GetString("UpdateVersions") == "true"; }
        set
        {
            Configuration.SetString("UpdateVersions", value ? "true" : "false", true);
            Configuration.Save();
        }
    }

    // "버전 테이블 유지"는 실제로 유효한 게임 경로가 있어야만 의미가 있다 —
    // Game.Verify()는 CheckGamePath()를 통과해야 VersionsData.Refresh()(버전 테이블
    // 다운로드)까지 도달하고, 경로가 비어있거나 잘못돼 있으면 그 전에 조기 종료된다.
    // 경로 없는 상태에서 체크박스를 켜봐야 아무 일도 안 일어나 사용자만 혼란스러우므로,
    // 현재 선택된 게임의 경로가 유효할 때만 체크박스 자체를 활성화한다.
    public bool CanUpdateVersionsTable => ModAPI.App.Game != null && ModAPI.App.Game.CheckGamePath();

    public bool UseSteam
    {
        get { return Configuration.GetString("UseSteam") == "true"; }
        set
        {
            Configuration.SetString("UseSteam", value ? "true" : "false", true);
            Configuration.Save();
            OnPropertyChanged("CanEditSteamPathManually");
        }
    }

    // 스팀 연결이 켜져 있으면 스팀 경로를 자동으로 탐지/관리하므로(MainWindow의
    // UseSteamCheckBox_Checked가 레지스트리에서 자동으로 채워 넣음), 수동 편집(찾아보기/
    // 저장/초기화) 영역은 그동안 비활성화한다. 꺼져 있을 때만 사용자가 직접 지정한다.
    public bool CanEditSteamPathManually => !UseSteam;

    // 개발자 로그 — 기본값 false (opt-in). 켜면 --dev 로 실행한 것과 동일하게
    // ModAPI.dev.log 가 생성/기록된다. 껐다 켰다 할 때마다 즉시 반영되도록
    // Configuration 값을 매번 직접 읽어서 판단한다(별도 캐시 없음).
    // 주의: Debug.DevMode를 여기서 같이 켜면 안 된다 — 이 체크박스는 일반 사용자가
    // 크래시 재현 시 상세 로그만 남기려고 켜는 용도인데, Debug.DevMode를 업데이트
    // 확인 저장소 분기 등 다른 용도로도 쓰기 시작하면 사용자가 로그만 켰을 뿐인데
    // 의도치 않게 개발/테스트 채널로 전환되는 부작용이 생긴다. 저장소 분기처럼
    // "진짜 개발자만" 써야 하는 판단은 App.DevMode(--dev 플래그 전용)만 참조한다.
    public bool DevLog
    {
        get { return Configuration.GetString("DevLog") == "true"; }
        set
        {
            Configuration.SetString("DevLog", value ? "true" : "false", true);
            Configuration.Save();
        }
    }

    // 로그 초기화 — 기본값 false (opt-in). 켜져 있으면 앱을 시작할 때마다
    // logs 폴더의 로그 파일을 전부 비운다.
    public bool ClearLogsOnStart
    {
        get { return Configuration.GetString("ClearLogsOnStart") == "true"; }
        set
        {
            Configuration.SetString("ClearLogsOnStart", value ? "true" : "false", true);
            Configuration.Save();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected internal void OnPropertyChanged(string propertyname)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
    }
}