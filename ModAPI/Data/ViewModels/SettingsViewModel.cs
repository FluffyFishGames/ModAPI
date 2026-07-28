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
        OnPropertyChanged("AutoUpdate");
        OnPropertyChanged("UseSteam");
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

    // 최신버전유지/업데이트검색/스팀연결 3가지는 아직 개발이 완전하지 않은 기능이라,
    // 값이 없을 때(신규 설치 등) true가 아니라 false로 취급한다 — 사용자가 명시적으로
    // 켜야만 동작하는 opt-in 방식.
    public bool UpdateVersionsTable
    {
        get { return Configuration.GetString("UpdateVersions") == "true"; }
        set
        {
            Configuration.SetString("UpdateVersions", value ? "true" : "false", true);
            Configuration.Save();
        }
    }

    public bool AutoUpdate
    {
        get { return Configuration.GetString("AutoUpdate") == "true"; }
        set
        {
            Configuration.SetString("AutoUpdate", value ? "true" : "false", true);
            Configuration.Save();
        }
    }
    public bool UseSteam
    {
        get { return Configuration.GetString("UseSteam") == "true"; }
        set
        {
            Configuration.SetString("UseSteam", value ? "true" : "false", true);
            Configuration.Save();
        }
    }

    // 개발자 로그 — 기본값 false (opt-in). 켜면 --dev 로 실행한 것과 동일하게
    // ModAPI.dev.log 가 생성/기록된다. 껐다 켰다 할 때마다 즉시 반영되도록
    // Configuration 값을 매번 직접 읽어서 판단한다(별도 캐시 없음).
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