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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Navigation;
using System.Windows.Shell;
using Microsoft.Win32;
using ModAPI.Components;
using ModAPI.Components.Panels;
using ModAPI.Configurations;
using ModAPI.Data;
using ModAPI.Data.Models;
using ModAPI.Utils;
using ModAPI.Windows.SubWindows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace ModAPI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool BlendIn = false;
        public static ResourceDictionary CurrentLanguage;
        public static List<string> LanguageOrder = new List<string>();

        public static MainWindow Instance;
        public List<IPanel> Panels = new List<IPanel>();
        protected Dictionary<string, ComboBoxItem> DevelopmentLanguagesItems;

        public const float GuiDeltaTime = 1f / 60f; // 60 fps

        protected bool FirstSetup;

        protected static List<Window> WindowQueue = new List<Window>();
        protected static Window CurrentWindow;
        protected static bool PositionWindow;

        public static void OpenWindow(Window window)
        {
            window.Closed += SubWindowClosed;
            window.ContentRendered += PositionSubWindow;
            //window.IsVisibleChanged += PositionSubWindow;
            WindowQueue.Add(window);
            NextWindow();
        }

        static void NextWindow()
        {
            if (CurrentWindow == null)
            {
                if (WindowQueue.Count > 0)
                {
                    PositionWindow = true;
                    CurrentWindow = WindowQueue[0];
                    CurrentWindow.Opacity = 0.0;
                    if (CurrentWindow.IsEnabled)
                    {
                        CurrentWindow.Show();
                    }
                    CurrentWindow.UpdateLayout();
                    WindowQueue.RemoveAt(0);
                    Instance.Focusable = false;
                }
                else
                {
                    Instance.Focusable = true;
                }
            }
        }

        static void PositionSubWindow(object sender, EventArgs e)
        {
            if (PositionWindow)
            {
                var window = (Window)sender;
                if (window.IsVisible)
                {
                    window.Left = Instance.Left + Instance.ActualWidth / 2.0 - window.ActualWidth / 2.0;
                    window.Top = Instance.Top + Instance.ActualHeight / 2.0 - window.ActualHeight / 2.0;
                    window.Opacity = 1.0;
                    PositionWindow = false;
                }
            }
        }

        static void SubWindowClosed(object sender, EventArgs e)
        {
            WindowQueue.Remove((Window)sender);
            if (CurrentWindow == sender)
            {
                CurrentWindow = null;
                NextWindow();
            }
        }

        protected ModsViewModel Mods;

        public void FirstSetupDone()
        {
            FirstSetup = false;

            // 설정 탭의 "로그 초기화"가 켜져 있으면, 시작할 때마다 logs 폴더의
            // 로그 파일을 전부 비운다. Debug.ClearLogs()가 열려있는 스트림을 먼저
            // 닫고 지우므로 "파일이 사용 중" 문제 없이 안전하게 처리된다.
            // (참고: Configuration 로딩 등 이 시점 이전에 이미 몇 줄의 로그가 기록되어
            //  있을 수 있는데, 그 앞부분까지 포함해서 지워진다 — 완전히 이르게 처리하려면
            //  Configuration.Load() 이전 시점에 넣어야 하나, 그 지점은 이 파일 범위 밖이라
            //  현재는 여기서 처리한다)
            var clearLogsOnStart = Configuration.GetString("ClearLogsOnStart", silent: true);
            Debug.Log("FirstSetupDone", "[ClearLogs] ClearLogsOnStart config value = \"" + clearLogsOnStart + "\"", Debug.Type.Notice);
            if (clearLogsOnStart == "true")
            {
                Debug.ClearLogs();
                Debug.Log("FirstSetupDone", "[ClearLogs] Debug.ClearLogs() executed.", Debug.Type.Notice);
            }

            if (!CheckSteamPath())
            {
                return;
            }

            App.Game = new Game(Configuration.Games[Configuration.CurrentGame]);
            App.Game.OnModlibUpdate += (s, e) => Dispatcher.Invoke(delegate { UpdateModlibVersion(); });
            UpdateModlibVersion();

            ModProjects = new ModProjectsViewModel();
            Mods = new ModsViewModel();
            ModsPanel.DataContext = Mods;
            Development.DataContext = ModProjects;

            // 게임 필터 탭 빌드 (고정 목록 — 게임 설치/모드 유무 무관)
            BuildModGameFilter();
            InitSteamPath();
            BuildGamePathsPanel();
            BuildDevGameFilter();
            InitFontSize();
            InitModListWidth();
            InitProjectListWidth();
            _uiInitialized = true;
            UpdateListWidthSliderMax();
            UpdateMinWindowWidth();
            InitTexture();
            // FirstSetup에서 저장된 값을 Settings 탭에 반영
            SettingsVm?.Changed();

            // AlwaysOnTop 상태 복원
            if ((LoadUiCfg("AlwaysOnTop") ?? Configuration.GetString("AlwaysOnTop", silent: true)).ToLower() == "true")
            {
                this.Topmost = true;
                var cb = FindName("AlwaysOnTopCheckBox") as System.Windows.Controls.CheckBox;
                if (cb != null) cb.IsChecked = true;
            }

            var supportedIds = new List<string> { "TheForest", "Subnautica", "Raft", "EscapeThePacific", "GH" };

            // App.Game(현재 선택된 게임)은 이미 Verify()에서 FindGamePath() 자동탐색을 거쳤다
            // (단, 그것도 이제 "스팀연결"이 켜져있을 때만 실제로 탐색하도록 게이팅되어 있다).
            // 나머지 게임들도 마찬가지로 "스팀연결"이 켜져있을 때만 경로 자동탐색을 시도한다.
            // 꺼져있으면(신규 설치 기본값) 자동탐색 자체를 건너뛰고, 사용자가 Settings 탭에서
            // 직접 설정하기 전까지 전부 빈 상태로 둔다 — 5개 게임 전부 일관되게 취급한다.
            if (Configuration.GetString("UseSteam") == "true")
            {
                foreach (var gid in supportedIds)
                {
                    if (string.Equals(gid, Configuration.CurrentGame, StringComparison.OrdinalIgnoreCase))
                    {
                        Debug.Log("FirstSetupDone", $"[AutoDetect] Skip {gid}: is CurrentGame (already handled by App.Game.Verify())", Debug.Type.Notice, detailedOnly: true);
                        continue;
                    }

                    var existingPath = Configuration.GetPath("Games." + gid, silent: true);
                    if (!string.IsNullOrEmpty(existingPath))
                    {
                        Debug.Log("FirstSetupDone", $"[AutoDetect] Skip {gid}: already has a saved path ({existingPath})", Debug.Type.Notice, detailedOnly: true);
                        continue;
                    }

                    Configuration.GameConfiguration autoCfg = null;
                    if (Configuration.Games.ContainsKey(gid)) autoCfg = Configuration.Games[gid];
                    if (autoCfg == null)
                    {
                        Debug.Log("FirstSetupDone", $"[AutoDetect] Skip {gid}: no GameConfiguration found in Configuration.Games", Debug.Type.Warning);
                        continue;
                    }

                    Debug.Log("FirstSetupDone", $"[AutoDetect] Trying {gid}...", Debug.Type.Notice, detailedOnly: true);
                    var tempGame = new Game(autoCfg, true);
                    var foundPath = tempGame.FindGamePath();
                    if (!string.IsNullOrEmpty(foundPath))
                    {
                        Configuration.SetPath("Games." + gid, foundPath, true);
                        Debug.Log("FirstSetupDone",
                            $"[AutoDetect] Found {gid} at: {foundPath}",
                            Debug.Type.Notice);
                    }
                    else
                    {
                        Debug.Log("FirstSetupDone",
                            $"[AutoDetect] Not found: {gid} (no matching path in SearchPaths or Steam libraries)",
                            Debug.Type.Notice, detailedOnly: true);
                    }
                }
            }
            else
            {
                Debug.Log("FirstSetupDone",
                    "[AutoDetect] UseSteam is off — skipping auto-detect for all games, leaving paths blank until user configures them manually",
                    Debug.Type.Notice);
            }

            // 지원 게임 5종 중 "설정 탭에서 게임설치경로가 검증된 게임"만 mods / projects 폴더 생성
            // (경로 미설정/실행파일 없음 상태에서 폴더만 먼저 생기면, 사용자가 미설치 게임 폴더에
            //  엉뚱한 모드를 잘못 넣어둘 여지가 생기므로 검증 통과한 게임에 한해서만 생성한다)
            var modsBase = Configuration.GetPath("mods");
            var projectsBase = Configuration.GetPath("projects");
            foreach (var gid in supportedIds)
            {
                var savedPath = Configuration.GetPath("Games." + gid, silent: true);
                if (string.IsNullOrEmpty(savedPath)) continue;

                Configuration.GameConfiguration gcfg = null;
                if (Configuration.Games.ContainsKey(gid)) gcfg = Configuration.Games[gid];
                if (gcfg == null) continue;

                var exePath = System.IO.Path.Combine(savedPath, gcfg.SelectFile);
                if (!File.Exists(exePath)) continue;

                var modsDir = System.IO.Path.Combine(modsBase, gid);
                var projectDir = System.IO.Path.Combine(projectsBase, gid);
                if (!string.IsNullOrEmpty(modsBase) && !Directory.Exists(modsDir)) Directory.CreateDirectory(modsDir);
                if (!string.IsNullOrEmpty(projectsBase) && !Directory.Exists(projectDir)) Directory.CreateDirectory(projectDir);
            }

            Configuration.Save();
        }

        public bool CheckSteamPath()
        {
            if (App.DevMode) return true;
            // 스팀 미설치 시 팝업 없이 진행 — Mods탭 게임시작 버튼에서 안내
            return true;
        }

        protected void UpdateModlibVersion()
        {
            if (App.Game != null && App.Game.ModLibrary != null)
            {
                if (App.Game.ModLibrary.Exists)
                {
                    ModLibCreationTime.Text = App.Game.ModLibrary.CreationTime.ToShortDateString() + " " + App.Game.ModLibrary.CreationTime.ToShortTimeString();
                    ModLibModAPIVersion.Text = App.Game.ModLibrary.ModApiVersion;
                    ModLibGameVersion.Text = App.Game.ModLibrary.GameVersion;
                }
                else
                {
                    ModLibCreationTime.Text = "-";
                    ModLibModAPIVersion.Text = "-";
                    ModLibGameVersion.Text = "-";
                }
            }
        }

        protected bool CheckSteam()
        {
            var steamPath = Configuration.GetPath("Steam");
            var steamExe = steamPath + Path.DirectorySeparatorChar + "Steam.exe";
#if DEBUG
            // 디버그: File.Exists만 확인 (더미 파일 허용)
            if (!File.Exists(steamExe))
            {
                steamPath = SearchSteam();
                Configuration.SetPath("Steam", steamPath, true);
                steamExe = steamPath + Path.DirectorySeparatorChar + "Steam.exe";
            }
            return File.Exists(steamExe);
#else
            // 릴리즈: PE 헤더 검증
            if (!ModAPI.Utils.FileValidator.IsValidSteamExe(steamExe))
            {
                steamPath = SearchSteam();
                Configuration.SetPath("Steam", steamPath, true);
                steamExe = steamPath + Path.DirectorySeparatorChar + "Steam.exe";
            }
            return ModAPI.Utils.FileValidator.IsValidSteamExe(steamExe);
#endif
        }

        protected string SearchSteam()
        {
            var steamPath = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam\\", "SteamPath", "");
            if (!File.Exists(steamPath + Path.DirectorySeparatorChar + "Steam.exe"))
            {
                steamPath = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam\\", "SteamExe", "");
                if (File.Exists(steamPath))
                {
                    steamPath = Path.GetDirectoryName(steamPath);
                }
            }
            return steamPath;
        }

        public ModProjectsViewModel ModProjects;
        protected List<string> Languages = new List<string> { "EN", "DE", "AR", "BN", "ZH", "ZH-TW", "FR", "HI", "IT", "JA", "KO", "PT", "RU", "ES", "TR", "VI" };
        protected Dictionary<string, ComboBoxItem> LanguageItems = new Dictionary<string, ComboBoxItem>();
        protected SettingsViewModel SettingsVm;

        public MainWindow()
        {
            //System.Console.WriteLine("AAA");
            if (Configuration.Languages["en"] != null)
            {
                App.Instance.Resources.MergedDictionaries.Add(Configuration.Languages["en"].Resource);
            }
            // AppBaseFontSize 기본값 사전 등록 (DynamicResource가 찾을 수 있도록)
            Application.Current.Resources["AppBaseFontSize"] = 13.0;
            Application.Current.Resources["AppBaseHeaderFontSize"] = 16.0;
            Application.Current.Resources["AppBaseSmallFontSize"] = 12.0;
            Application.Current.Resources["AppBaseTinyFontSize"] = 10.0;
            Application.Current.Resources["AppBaseLargeFontSize"] = 20.0;
            InitializeComponent();
            Instance = this;
            CheckDir();

            foreach (var langCode in Languages)
            {
                var newItem = new ComboBoxItem
                {
                    Style = Application.Current.FindResource("ComboBoxItem") as Style,
                    DataContext = langCode
                };
                LanguageItems.Add(langCode, newItem);
                var panel = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };

                try
                {
                    var image = new Image
                    {
                        Height = 20
                    };
                    var source = new BitmapImage();
                    source.BeginInit();
                    source.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/Lang_" + langCode + ".png");
                    source.EndInit();
                    image.Source = source;
                    image.Margin = new Thickness(0, 0, 5, 0);
                    panel.Children.Add(image);
                }
                catch { }

                var label = new TextBlock
                {
                    FontSize = 16
                };
                label.SetResourceReference(TextBlock.TextProperty, "Lang.Languages." + langCode);
                panel.Children.Add(label);

                newItem.Content = panel;
                DevelopmentLanguageSelector.Items.Add(newItem);
            }

            FirstSetup = Configuration.GetString("SetupDone").ToLower() != "true";
            if (FirstSetup)
            {
                var win = new FirstSetup("Lang.Windows.FirstSetup");
                win.ShowSubWindow();
                win.Show();
            }
            else
            {
                FirstSetupDone();
            }

            Configuration.OnLanguageChanged += LanguageChanged;

            // Custom language order for Settings selector (KR after FR)
            string[] preferredOrder = { "en", "de", "es", "fr", "ko", "it", "ja", "pl", "pt", "ru", "vi", "zh", "zh-tw" };
            LanguageOrder.Clear();
            foreach (var langCode in preferredOrder)
            {
                if (Configuration.Languages.ContainsKey(langCode))
                {
                    AddLanguage(Configuration.Languages[langCode]);
                    LanguageOrder.Add(langCode);
                }
            }
            // Add any remaining languages not in the preferred order
            foreach (var language in Configuration.Languages.Values)
            {
                var key = language.Key.ToLower();
                if (Array.IndexOf(preferredOrder, key) < 0)
                {
                    AddLanguage(language);
                    LanguageOrder.Add(key);
                }
            }

            SettingsVm = new SettingsViewModel();
            Settings.DataContext = SettingsVm;
            SettingsCheckboxes.DataContext = SettingsVm;
            //LanguageSelector.SelectedIndex = Configuration.Languages.Values.ToList().IndexOf(Configuration.CurrentLanguage);

            InitializeThemeSelector();

            foreach (var tab in GuiConfiguration.Tabs)
            {
                var newTab = new IconTabItem();
                var style = App.Instance.Resources["TopTab"] as Style;
                newTab.Style = style;

                try
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/" + tab.IconName);
                    image.EndInit();
                    newTab.IconSource = image;
                }
                catch (Exception)
                {
                    Debug.Log("MainWindow", "Couldn't find the icon \"" + tab.IconName + "\".", Debug.Type.Warning);
                }
                try
                {
                    var imageSelected = new BitmapImage();
                    imageSelected.BeginInit();
                    imageSelected.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/" + tab.IconSelectedName);
                    imageSelected.EndInit();
                    newTab.SelectedIconSource = imageSelected;
                }
                catch (Exception)
                {
                    Debug.Log("MainWindow", "Couldn't find the icon \"" + tab.IconSelectedName + "\".", Debug.Type.Warning);
                }

                newTab.SetResourceReference(IconTabItem.LabelProperty, tab.LangPath + ".Tab");
                var newPanel = (IPanel)Activator.CreateInstance(tab.ComponentType);
                newTab.Content = newPanel;
                Debug.Log("MainWindow", "Added tab of type \"" + tab.TypeName + "\".");
                newPanel.SetTab(tab);
                Panels.Add(newPanel);
                Tabs.Items.Add(newTab);
            }

            Timer = new DispatcherTimer();
            Timer.Tick += GuiTick;
            Timer.Interval = new TimeSpan((long)(GuiDeltaTime * 10000000));
            Timer.Start();
            LanguageChanged();
            SettingsVm.Changed();
        }

        #region Check loading paths & move files by: SiXxKilLuR 03/25/2019 01:15PM      
        //Check if ran from tmp directories and move to a working directory
        private static string Apath;
        private static string Mpath;

        private static void CheckDir()
        {
            Apath = (System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName));
            Mpath = (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)));

            if (Apath.Contains(Mpath))

            {
                TDialog();
            }
            else
            {

            }

        }

        public static void TDialog()
        {
            var win = new DirectoryCheck("Lang.Windows.DirectoryCheck");
            win.ShowSubWindow();
            win.Show();

        }

        #endregion


        protected DispatcherTimer Timer;

        void GuiTick(object sender, EventArgs e)
        {
            if (!FirstSetup)
            {
                var tasks = Schedule.GetTasks("GUI");
                foreach (var task in tasks)
                {
                    if (!task.BeingHandled)
                    {
                        switch (task.Name)
                        {
                            case "SpecifyGamePath":
                                var win = new SpecifyGamePath("Lang.Windows.SpecifyGamePath", task);
                                win.ShowSubWindow();
                                //win.Show();
                                task.BeingHandled = true;
                                break;
                            case "SpecifySteamPath":
                                var win2 = new SpecifySteamPath("Lang.Windows.SpecifySteamPath", task);
                                win2.ShowSubWindow();
                                //win2.Show();
                                task.BeingHandled = true;
                                break;
                            case "RestoreGameFiles":
                                var win3 = new RestoreGameFiles("Lang.Windows.RestoreGameFiles", task);
                                win3.ShowSubWindow();
                                //win3.Show();
                                task.BeingHandled = true;
                                break;
                            case "OperationPending":
                                var win4 = new OperationPending("Lang.Windows.OperationPending", task);
                                if (!win4.Completed)
                                {
                                    win4.ShowSubWindow();
                                    //  win4.Show();
                                }
                                task.BeingHandled = true;
                                break;
                            case "SelectNewestModVersions":
                                if (Mods != null)
                                {
                                    Mods.SelectNewestModVersions = true;
                                    task.BeingHandled = true;
                                }
                                break;
                        }
                    }
                }
            }
            if (BlendIn)
            {
                if (Opacity < 1f)
                {
                    Opacity += GuiDeltaTime * 5f;
                    if (Opacity >= 1f)
                    {
                        Opacity = 1f;
                    }
                }
            }

            if (CurrentWindow != null)
            {
                if (FadeBackground.Visibility == Visibility.Collapsed)
                {
                    FadeBackground.Visibility = Visibility.Visible;
                }
                if (FadeBackground.Opacity < 0.8f)
                {
                    FadeBackground.Opacity += GuiDeltaTime * 5f;
                    if (FadeBackground.Opacity >= 0.8f)
                    {
                        FadeBackground.Opacity = 0.8f;
                    }
                }
            }
            else
            {
                if (FadeBackground.Opacity > 0f)
                {
                    FadeBackground.Opacity -= GuiDeltaTime * 5f;
                    if (FadeBackground.Opacity <= 0f)
                    {
                        FadeBackground.Opacity = 0f;
                        FadeBackground.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        void LanguageChanged()
        {
            if (CurrentLanguage != null)
            {
                App.Instance.Resources.MergedDictionaries.Remove(CurrentLanguage);
            }

            CurrentLanguage = Configuration.CurrentLanguage.Resource;
            App.Instance.Resources.MergedDictionaries.Add(CurrentLanguage);
            UpdateModlibVersion();
        }

        private bool _themeInitializing;

        private void InitializeThemeSelector()
        {
            _themeInitializing = true;

            // ThemeIds 순서대로 ComboBoxItem 자동 생성 — 새 테마 추가 시 코드 변경 불필요
            foreach (var id in App.ThemeIds)
            {
                var item = new ComboBoxItem
                {
                    Style = Application.Current.FindResource("ComboBoxItem") as Style
                };
                var text = new TextBlock
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 16,
                    Padding = new Thickness(0, 0, 10, 0)
                };
                // 언어 키 규칙: Lang.Options.Theme.{첫글자대문자 + 나머지}
                var langKey = "Lang.Options.Theme." + char.ToUpper(id[0]) + id.Substring(1);
                text.SetResourceReference(TextBlock.TextProperty, langKey);
                item.Content = text;
                ThemeSelector.Items.Add(item);
            }

            var currentTheme = App.GetCurrentTheme();
            var idx = App.ThemeIds.IndexOf(currentTheme);
            ThemeSelector.SelectedIndex = idx >= 0 ? idx : 0;

            _themeInitializing = false;
        }

        // ── UI Settings File (ui.cfg) ────────────────────────────────────────
        private static readonly string UiCfgFile = "ui.cfg";

        private static string GetUiCfgPath()
        {
            // App.RootPath 우선, 없으면 실행 파일 위치 사용
            var root = App.RootPath;
            if (string.IsNullOrEmpty(root))
                root = System.IO.Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().Location) ?? ".";
            return System.IO.Path.Combine(root, UiCfgFile);
        }

        private static void SaveUiCfg(string key, string value)
        {
            try
            {
                var path = GetUiCfgPath();
                var lines = System.IO.File.Exists(path)
                    ? new System.Collections.Generic.List<string>(System.IO.File.ReadAllLines(path))
                    : new System.Collections.Generic.List<string>();

                var found = false;
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].StartsWith(key + "="))
                    {
                        lines[i] = key + "=" + value;
                        found = true;
                        break;
                    }
                }
                if (!found) lines.Add(key + "=" + value);
                System.IO.File.WriteAllLines(path, lines);
                Debug.Log("UiCfg", "Saved: " + key + "=" + value + " \u2192 " + path);
            }
            catch (Exception ex)
            {
                Debug.Log("UiCfg", "Save failed: " + ex.Message, Debug.Type.Warning);
            }
        }

        private static string LoadUiCfg(string key)
        {
            try
            {
                var path = GetUiCfgPath();
                if (!System.IO.File.Exists(path)) return null;
                foreach (var line in System.IO.File.ReadAllLines(path))
                {
                    if (line.StartsWith(key + "="))
                        return line.Substring(key.Length + 1).Trim();
                }
            }
            catch { }
            return null;
        }

        private void SaveAllSettings()
        {
            // ui.cfg에 직접 저장 (Configuration 시스템 우회)
            SaveUiCfg("ModListWidth", ((int)_modListWidth).ToString());
            SaveUiCfg("ProjectListWidth", ((int)_projectListWidth).ToString());

            // FontSize
            var fontSel = FindName("FontSizeSelector") as System.Windows.Controls.ComboBox;
            if (fontSel?.SelectedItem is System.Windows.Controls.ComboBoxItem fontItem)
                SaveUiCfg("AppFontSize", ((double)fontItem.Tag).ToString(System.Globalization.CultureInfo.InvariantCulture));

            // AlwaysOnTop
            var aotCb = FindName("AlwaysOnTopCheckBox") as System.Windows.Controls.CheckBox;
            if (aotCb != null)
                SaveUiCfg("AlwaysOnTop", aotCb.IsChecked == true ? "true" : "false");

            // Background Texture
            SaveUiCfg("TexturePath", _texturePath ?? "");
            SaveUiCfg("TextureActive", _textureActive ? "true" : "false");

            // 스팀 경로 — TextBox 값 저장 (빈 값도 저장해서 초기화 상태 유지)
            var steamBox = FindName("SteamPathBox") as System.Windows.Controls.TextBox;
            if (steamBox != null)
            {
                if (!string.IsNullOrWhiteSpace(steamBox.Text))
                {
                    SaveUiCfg("SteamPathReset", "0");
                    Configuration.SetPath("Steam", steamBox.Text, true);
                }
                else
                {
                    // 비어있으면 초기화 플래그 유지
                    Configuration.SetPath("Steam", "", true);
                }
            }

            // 게임 경로 — GamePathsPanel 내 TextBox 값 모두 저장
            // 빈 TextBox 도 저장 — 초기화 상태를 XML 에 반영 (공백 경로 유지 불가 시 플래그로 보완)
            var pathsPanel = FindName("GamePathsPanel") as StackPanel;
            if (pathsPanel != null)
            {
                foreach (var child in pathsPanel.Children)
                {
                    var card = child as System.Windows.Controls.Border;
                    if (card?.Tag is string gameId)
                    {
                        var tb = FindVisualChild<System.Windows.Controls.TextBox>(card);
                        if (tb != null)
                        {
                            if (!string.IsNullOrWhiteSpace(tb.Text))
                            {
                                Configuration.SetPath("Games." + gameId, tb.Text, true);
                                SaveUiCfg("GamePathReset_" + gameId, "0");
                            }
                            else
                            {
                                // 비어있으면 초기화 플래그 유지 (resetBtn 에서 이미 "1" 저장)
                                Configuration.SetPath("Games." + gameId, "", true);
                            }
                        }
                    }
                }
            }

            Configuration.Save();
        }

        private static T FindVisualChild<T>(System.Windows.DependencyObject parent) where T : System.Windows.DependencyObject
        {
            for (int i = 0; i < System.Windows.Media.VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = System.Windows.Media.VisualTreeHelper.GetChild(parent, i);
                if (child is T t) return t;
                var result = FindVisualChild<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        private void ThemeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_themeInitializing) return;
            // 배경 텍스처 활성 중일 때는 테마 전환 차단
            if (_textureActive) return;

            var idx = ThemeSelector.SelectedIndex;
            if (idx < 0 || idx >= App.ThemeIds.Count) return;
            var theme = App.ThemeIds[idx];

            // 현재 테마와 동일하면 무시
            if (theme == App.GetCurrentTheme()) return;

            var selectedTheme = theme;
            var win = new Windows.SubWindows.ThemeConfirm("Lang.Windows.ThemeConfirm");
            win.Closed += (s, args) =>
            {
                if (win.Confirmed)
                {
                    App.SaveTheme(selectedTheme);
                    SaveAllSettings();
                    Configuration.Save();

                    // Auto restart
                    var exePath = System.IO.Path.Combine(App.RootPath, "ModAPI.exe");
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = exePath,
                        UseShellExecute = true,
                        WorkingDirectory = App.RootPath
                    });
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    // Revert selection — ThemeIds.IndexOf 로 인덱스 조회
                    _themeInitializing = true;
                    var currentTheme = App.GetCurrentTheme();
                    var revertIdx = App.ThemeIds.IndexOf(currentTheme);
                    ThemeSelector.SelectedIndex = revertIdx >= 0 ? revertIdx : 0;
                    _themeInitializing = false;
                }
            };
            win.ShowSubWindow();
            win.Show();
        }

        void AddLanguage(Configuration.Language language)
        {
            var c = new ComboBoxItem
            {
                Style = Application.Current.FindResource("ComboBoxItem") as Style
            };
            var panel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            c.Content = panel;

            if (language.ImageStream != null)
            {
                var img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = language.ImageStream;
                img.EndInit();

                var i = new Image
                {
                    Width = 36,
                    Height = 24,
                    Stretch = System.Windows.Media.Stretch.Uniform,
                    VerticalAlignment = VerticalAlignment.Center,
                    Source = img,
                };

                // 테두리 추가 — Light 테마에서 흰색 국기가 배경에 묻히지 않도록
                var border = new Border
                {
                    BorderBrush = new SolidColorBrush(Color.FromArgb(60, 0, 0, 0)),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(2),
                    Margin = new Thickness(0, 0, 10, 0),
                    VerticalAlignment = VerticalAlignment.Center,
                    Child = i,
                };

                panel.Children.Add(border);
            }

            var text = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                Text = language.Resource["LangName"] as String,
                FontSize = 16
            };
            panel.Children.Add(text);
            LanguageSelector.Items.Add(c);
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement)FindName("Mover")).MouseLeftButtonDown += MoveWindow;

            // Force WindowChrome after all styles are applied - guarantees drag for all themes
            var chrome = new WindowChrome
            {
                GlassFrameThickness = new Thickness(0),
                CaptionHeight = 48,
                ResizeBorderThickness = new Thickness(6),
                CornerRadius = new CornerRadius(0),
                UseAeroCaptionButtons = false
            };
            WindowChrome.SetWindowChrome(this, chrome);

            if (WindowState == WindowState.Maximized)
            {
                ((Button)FindName("MaximizeButton")).Visibility = Visibility.Hidden;
                ((Button)FindName("MaximizeButton")).Width = 0;
            }
            else
            {
                ((Button)FindName("NormalizeButton")).Visibility = Visibility.Hidden;
                ((Button)FindName("NormalizeButton")).Width = 0;
            }

            // 레이아웃 완료 후 MinWidth 계산 → 창 너비를 MinWidth(최소)로 설정
            this.UpdateLayout();
            UpdateMinWindowWidth();
            this.Width = this.MinWidth;
            var screenW = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Width = this.MinWidth;
            this.Left = (screenW - this.Width) / 2;

            VersionLabel.Text = App.Version + " [" + Version.BuildDate + "]";

            // Welcome 탭을 기본 선택 (index 0 — 맨 앞)
            Tabs.SelectedIndex = 0;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs args)
        {
            DragMove();
        }

        private void RootGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.GetPosition(this).Y <= 48)
            {
                DragMove();
            }
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Normalize(object sender, RoutedEventArgs e)
        {
            // 저장된 원래 크기/위치 복원
            if (_prevWidth > 0)
            {
                this.Left = _prevLeft;
                this.Top = _prevTop;
                this.Width = _prevWidth;
                this.Height = _prevHeight;
                this.MaxWidth = _prevMaxWidth;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
            ((Button)FindName("MaximizeButton")).Visibility = Visibility.Visible;
            ((Button)FindName("MaximizeButton")).Width = 24;
            ((Button)FindName("NormalizeButton")).Visibility = Visibility.Hidden;
            ((Button)FindName("NormalizeButton")).Width = 0;
        }

        // 최대화 전 원래 상태 저장용 필드
        private double _prevLeft, _prevTop, _prevWidth, _prevHeight, _prevMaxWidth;

        private void Maximize(object sender, RoutedEventArgs e)
        {
            // 현재 상태 저장
            _prevLeft = this.Left;
            _prevTop = this.Top;
            _prevWidth = this.Width;
            _prevHeight = this.Height;
            _prevMaxWidth = this.MaxWidth;

            // MaxWidth 제한 해제 후 현재 화면 WorkArea 에 맞춰 최대화
            this.MaxWidth = double.PositiveInfinity;
            var workArea = System.Windows.SystemParameters.WorkArea;
            this.Left = workArea.Left;
            this.Top = workArea.Top;
            this.Width = workArea.Width;
            this.Height = workArea.Height;
            ((Button)FindName("MaximizeButton")).Visibility = Visibility.Hidden;
            ((Button)FindName("MaximizeButton")).Width = 0;
            ((Button)FindName("NormalizeButton")).Visibility = Visibility.Visible;
            ((Button)FindName("NormalizeButton")).Width = 24;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
            Environment.Exit(0);
        }

        private void Window_LayoutUpdated(object sender, EventArgs e)
        {
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void Tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // WPF TabControl은 보통 "현재 보이는 탭"만 실제로 측정한다. Settings 탭이
            // 화면에 뜨기 전(예: Welcome 탭이 보이는 상태)에 창 높이가 이미 SizeToContent로
            // 고정되면, 나중에 Settings 탭으로 전환해도 그 탭 안의 게임 경로 카드들
            // 크기가 창 높이 계산에 전혀 반영되지 않는다 — 폰트 크기와 무관하게 탭을
            // 전환할 때마다 다시 계산해줘야 한다.
            // Settings 탭 인덱스: Welcome(0), Mods(1), Downloads(2), Development(3), Themes(4), Settings(5)
            if (Tabs.SelectedIndex == 5)
            {
                UpdateWindowHeight();
            }
        }

        public void Preload(ProgressHandler handler)
        {
            handler.OnComplete += delegate
            {
                Debug.Log("MainWindow", "GUI is ready.");
                // 화면 해상도의 80%를 MAX값으로 메모리에 저장 (1회)
                var screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
                ScreenMaxWidth = Math.Floor(screenWidth * 0.8);
                // 슬라이더 최대값 적용
                UpdateListWidthSliderMax();
                // 창 최대 너비 설정 (사용자가 드래그로 MAX까지 조절 가능)
                this.MaxWidth = ScreenMaxWidth;
            };
            Debug.Log("MainWindow", "Preparing GUI.");
            Opacity = 0.0f;
            Tabs.Preload(handler);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (CurrentWindow != null)
            {
                CurrentWindow.Activate();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                App.Instance.Shutdown();
            }
            catch (Exception)
            {
            }
        }

        private void CreateModLibrary(object sender, RoutedEventArgs e)
        {
            // 검증 1: 스팀 설치 여부 확인 (프로젝트 존재 여부와 무관하게 항상 먼저)
            var steamPathLib = ModAPI.Configurations.Configuration.GetPath("Steam");
            var steamExeLib = steamPathLib + System.IO.Path.DirectorySeparatorChar + "Steam.exe";
#if DEBUG
            var steamValidLib = !string.IsNullOrEmpty(steamPathLib) && System.IO.File.Exists(steamExeLib);
#else
            var steamValidLib = ModAPI.Utils.FileValidator.IsValidSteamExe(steamExeLib);
#endif
            if (!steamValidLib)
            {
                var winSteam = new Windows.SubWindows.NoProjectWarning("Lang.Windows.SteamNotFound");
                winSteam.ShowSubWindow();
                winSteam.Show();
                return;
            }
            // 검증 2: 프로젝트 목록 확인
            if (ProjectList.Items.Count == 0)
            {
                var win = new Windows.SubWindows.NoProjectWarning("Lang.Windows.NoProjectWarning");
                win.ShowSubWindow();
                win.Show();
                return;
            }
            // 검증 3: 게임 경로 미설정 시 ModLibrary 생성 불가
            if (App.Game == null || string.IsNullOrEmpty(App.Game.GamePath))
            {
                var win2 = new Windows.SubWindows.NoProjectWarning("Lang.Windows.GamePathNotSet");
                win2.ShowSubWindow();
                win2.Show();
                return;
            }

            // 검증 4: gamefiles\original 백업 폴더 존재 여부 확인
            // 백업이 없으면 Verify()를 먼저 실행 (BackupGameFiles + CreateModLibrary 포함)
            // 백업이 있으면 바로 CreateModLibrary() 실행
            bool backupExists = false;
            if (App.Game.GameConfiguration.IncludeAssemblies.Count > 0)
            {
                var firstInclude = App.Game.GameConfiguration.IncludeAssemblies[0];
                var backupFile = System.IO.Path.GetFullPath(
                    ModAPI.Configurations.Configuration.GetPath("OriginalGameFiles") +
                    System.IO.Path.DirectorySeparatorChar + App.Game.GameConfiguration.Id +
                    System.IO.Path.DirectorySeparatorChar + App.Game.ParsePath(firstInclude));
                backupExists = System.IO.File.Exists(backupFile);
            }

            if (!backupExists)
            {
                // 백업 없음 → Verify()가 BackupGameFiles() + CreateModLibrary()까지 처리
                App.Game.Verify();
            }
            else
            {
                // 백업 있음 → 바로 ModLib 재생성
                App.Game.CreateModLibrary();
            }
        }

        private void CreateProject(object sender, RoutedEventArgs e)
        {
            var win = new CreateModProject("Lang.Windows.CreateModProject");
            win.ShowSubWindow();
            win.Show();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

        protected ModProjectViewModel CurrentModProjectViewModel;
        protected ModViewModel CurrentModViewModel;

        public void SetMod(ModViewModel model)
        {
            CurrentModViewModel = model;
            DeleteModButton.IsEnabled = model != null;
            if (model != null)
            {
                SelectedMod.Visibility = Visibility.Visible;
                SelectedMod.DataContext = model;
            }
            else
            {
                SelectedMod.Visibility = Visibility.Collapsed;
                SelectedMod.DataContext = null;
            }
        }

        private void DeleteMod_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentModViewModel == null) return;

            var modName = CurrentModViewModel.Name;
            var modId = CurrentModViewModel.Id;
            var versionsData = CurrentModViewModel.VersionsData;

            // 삭제 대상 mod 가 속한 게임 인스턴스를 직접 사용 — App.Game(현재 활성 게임)에
            // 의존하면 다른 게임이 활성화된 상태에서 엉뚱한 게임 폴더를 참조하게 됨
            // (예: TheForest 가 활성 상태에서 Green Hell mod 를 삭제하면
            //  TheForest 의 Managed 폴더를 뒤져서 GH DLL을 찾지 못해 삭제가 누락됨)
            var modGame = versionsData.Count > 0
                ? versionsData[versionsData.Keys.First()].Game
                : null;

            // 삭제 대상 ModViewModel 참조 보관 — 파일 삭제 후 메모리 캐시(_Selected)도 초기화하기 위함
            // ModsViewModel.UpdateMods() 의 동시성 타이밍에 따라 같은 ModId 로 재다운로드 시
            // ViewModel 인스턴스가 재사용될 수 있는데, 이 경우 Configuration 키만 지워서는
            // 이미 메모리에 캐싱된 _Selected 값(true)이 그대로 남아 체크박스가 활성 상태로 보임
            var targetModViewModel = CurrentModViewModel;

            Debug.Log("DeleteMod",
                $"[Delete] Target mod: {modId} | Game: {modGame?.GameConfiguration?.Id ?? "(null)"}" +
                $" | App.Game (active): {App.Game?.GameConfiguration?.Id ?? "(null)"}",
                Debug.Type.Notice);

            var win = new Windows.SubWindows.DeleteModConfirm("Lang.Windows.DeleteModConfirm", modName);
            win.Closed += (s, args) =>
            {
                if (!win.Confirmed) return;

                try
                {
                    // Collect module names from all versions BEFORE deleting files
                    var moduleNames = new HashSet<string>();
                    foreach (var kv in versionsData)
                    {
                        var mod = kv.Value;
                        try
                        {
                            var module = mod.GetModule();
                            if (module != null && !string.IsNullOrEmpty(module.Name))
                                moduleNames.Add(module.Name);
                        }
                        catch { }
                    }

                    // Step 1: Delete all .mod files for this mod
                    foreach (var kv in versionsData)
                    {
                        var mod = kv.Value;
                        if (!string.IsNullOrEmpty(mod.FileName) && File.Exists(mod.FileName))
                        {
                            try { File.Delete(mod.FileName); }
                            catch (Exception ex) { Debug.Log("DeleteMod", "Failed to delete: " + mod.FileName + " - " + ex.Message, Debug.Type.Warning); }
                        }
                    }

                    // Step 2: Delete deployed mod DLL from game folder
                    // mod 자신이 속한 게임(modGame)의 경로를 사용 — App.Game 이 아님
                    if (modGame != null)
                    {
                        // modGame.GamePath 가 비어있으면 저장된 설정 경로로 보완
                        if (string.IsNullOrEmpty(modGame.GamePath))
                        {
                            var savedPath = ModAPI.Configurations.Configuration.GetPath(
                                "Games." + modGame.GameConfiguration.Id, silent: true);
                            if (!string.IsNullOrEmpty(savedPath))
                                modGame.GamePath = savedPath;
                        }

                        if (!string.IsNullOrEmpty(modGame.GamePath))
                        {
                            var gameFolder = modGame.GetGameFolder();
                            Debug.Log("DeleteMod",
                                $"[Delete] Using game folder: {gameFolder} (Game: {modGame.GameConfiguration.Id})",
                                Debug.Type.Notice);

                            if (!string.IsNullOrEmpty(gameFolder))
                            {
                                // Delete from assemblyPath (e.g. GH_Data/Managed/)
                                try
                                {
                                    var assemblyRelPath = modGame.ParsePath(modGame.GameConfiguration.AssemblyPath);
                                    var assemblyDir = Path.GetFullPath(Path.Combine(gameFolder, assemblyRelPath));
                                    if (Directory.Exists(assemblyDir))
                                    {
                                        foreach (var moduleName in moduleNames)
                                        {
                                            var dllPath = Path.Combine(assemblyDir, moduleName);
                                            if (File.Exists(dllPath))
                                            {
                                                try { File.Delete(dllPath); Debug.Log("DeleteMod", "Deleted DLL: " + dllPath); }
                                                catch (Exception ex) { Debug.Log("DeleteMod", "Failed to delete DLL: " + dllPath + " - " + ex.Message, Debug.Type.Warning); }
                                            }
                                            else
                                            {
                                                Debug.Log("DeleteMod",
                                                    $"[Delete] DLL not found (already removed or never deployed): {dllPath}",
                                                    Debug.Type.Notice);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.Log("DeleteMod",
                                            $"[Delete] Assembly directory not found: {assemblyDir}",
                                            Debug.Type.Warning);
                                    }
                                }
                                catch (Exception ex) { Debug.Log("DeleteMod", "Error resolving assembly path: " + ex.Message, Debug.Type.Warning); }

                                // Delete from Mods folder (resources)
                                var gameModsDir = Path.Combine(gameFolder, "Mods");
                                if (Directory.Exists(gameModsDir))
                                {
                                    var modRes = Path.Combine(gameModsDir, modId + ".resources");
                                    if (File.Exists(modRes))
                                    {
                                        try { File.Delete(modRes); }
                                        catch (Exception ex) { Debug.Log("DeleteMod", "Failed to delete resources: " + modRes + " - " + ex.Message, Debug.Type.Warning); }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.Log("DeleteMod",
                                $"[Delete] Skip game folder cleanup — path not configured for: {modGame.GameConfiguration.Id}",
                                Debug.Type.Warning);
                        }
                    }
                    else
                    {
                        Debug.Log("DeleteMod",
                            "[Delete] Skip game folder cleanup — mod.Game is null",
                            Debug.Type.Warning);
                    }

                    // Step 3: Delete from ModdedGameFiles staging area
                    if (modGame != null)
                    {
                        try
                        {
                            var moddedBase = Path.GetFullPath(
                                ModAPI.Configurations.Configuration.GetPath("ModdedGameFiles") +
                                Path.DirectorySeparatorChar + modGame.GameConfiguration.Id);

                            // Delete from staging Mods folder (resources)
                            var moddedModsDir = Path.Combine(moddedBase, "Mods");
                            if (Directory.Exists(moddedModsDir))
                            {
                                var moddedRes = Path.Combine(moddedModsDir, modId + ".resources");
                                if (File.Exists(moddedRes))
                                    File.Delete(moddedRes);
                            }

                            // Delete from staging assembly folder (DLLs)
                            try
                            {
                                var moddedAssemblyDir = Path.GetFullPath(
                                    moddedBase + Path.DirectorySeparatorChar +
                                    modGame.ParsePath(modGame.GameConfiguration.AssemblyPath));
                                if (Directory.Exists(moddedAssemblyDir))
                                {
                                    foreach (var moduleName in moduleNames)
                                    {
                                        var moddedDll = Path.Combine(moddedAssemblyDir, moduleName);
                                        if (File.Exists(moddedDll))
                                            File.Delete(moddedDll);
                                    }
                                }
                            }
                            catch { }
                        }
                        catch { }
                    }

                    // Step 3.5: Force-reset in-memory Selected state on the ViewModel itself
                    // ModViewModel.Selected setter 는 Configuration.SetString(...) 도 함께 호출하므로
                    // 메모리 캐시와 Configuration 값을 동시에 false 로 맞춘다.
                    // (setter 가 VersionsData 의 mod 객체에 접근하므로 Step 1의 파일 삭제와는 무관하게 동작)
                    if (targetModViewModel != null)
                    {
                        try
                        {
                            targetModViewModel.Selected = false;
                            Debug.Log("DeleteMod",
                                $"[Delete] Forced in-memory + Configuration Selected = false for: {modId}",
                                Debug.Type.Notice);
                        }
                        catch (Exception ex)
                        {
                            Debug.Log("DeleteMod",
                                $"[Delete] Failed to reset in-memory Selected: {ex.Message}",
                                Debug.Type.Warning);
                        }
                    }

                    // Step 3.6: Remove persisted Selected/Version settings from Configuration entirely
                    // Step 3.5 가 "false" 로 키를 남겼다면, 여기서 키 자체를 완전히 제거하여
                    // 다음 mod 재다운로드 시 Initialized() 가 "키 없음" 상태로 깨끗하게 시작하도록 함
                    if (modGame != null)
                    {
                        var configPrefix = "Mods." + modGame.GameConfiguration.Id + "." + modId + ".";
                        var removedCount = ModAPI.Configurations.Configuration.RemoveKeysWithPrefix(configPrefix);
                        ModAPI.Configurations.Configuration.Save();
                        Debug.Log("DeleteMod",
                            $"[Delete] Removed {removedCount} config key(s) with prefix: {configPrefix}",
                            Debug.Type.Notice);
                    }

                    // Step 4: Reset UI - ModsViewModel timer will auto-detect deleted files
                    SetMod(null);

                    Debug.Log("DeleteMod", $"[Delete] Completed: {modId}", Debug.Type.Notice);
                }
                catch (Exception ex)
                {
                    Debug.Log("DeleteMod", "Error deleting mod: " + ex.Message, Debug.Type.Error);
                }
            };
            win.ShowSubWindow();
            win.Show();
        }

        public void SetProject(ModProjectViewModel model)
        {
            CurrentModProjectViewModel = model;

            // DataContext를 먼저 null로 해제한 뒤 SelectedIndex를 변경
            // → SelectedIndex 변경 이벤트가 발생할 때 DataContext가 없어 NameChanged가 SaveConfiguration을 호출하지 않음
            SelectedProject.DataContext = null;
            DevelopmentLanguageSelector.SelectedIndex = -1;

            if (model != null)
            {
                foreach (var kv in LanguageItems)
                {
                    var a = model.Project.Languages.Contains(kv.Key);
                    kv.Value.Visibility = a ? Visibility.Collapsed : Visibility.Visible;
                    kv.Value.IsEnabled = !a;
                }
                SelectedProject.Visibility = Visibility.Visible;
                NoProjectSelected.Visibility = Visibility.Collapsed;
                SelectedProject.DataContext = model;
            }
            else
            {
                SelectedProject.Visibility = Visibility.Collapsed;
                NoProjectSelected.Visibility = Visibility.Visible;
            }
        }

        private void AddProjectLanguage(object sender, RoutedEventArgs e)
        {
            if (CurrentModProjectViewModel != null)
            {
                CurrentModProjectViewModel.AddProjectLanguage((string)(((ComboBoxItem)DevelopmentLanguageSelector.SelectedItem).DataContext));
                DevelopmentLanguageSelector.SelectedIndex = -1;
                foreach (var kv in LanguageItems)
                {
                    var a = CurrentModProjectViewModel.Project.Languages.Contains(kv.Key);
                    kv.Value.Visibility = a ? Visibility.Collapsed : Visibility.Visible;
                    kv.Value.IsEnabled = !a;
                }
            }
        }

        private void AddModProjectButton(object sender, RoutedEventArgs e)
        {
            if (CurrentModProjectViewModel != null)
            {
                CurrentModProjectViewModel.AddButton();
            }
        }

        private void RemoveModProjectButton(object sender, RoutedEventArgs e)
        {
            if (CurrentModProjectViewModel != null)
            {
                var win =
                    new RemoveModProject("Lang.Windows.RemoveModProject", CurrentModProjectViewModel.Project.Id, CurrentModProjectViewModel.Project)
                    {
                        Confirm = delegate (object obj)
                        {
                            ProjectList.SelectedIndex = -1;
                            NoProjectSelected.Visibility = Visibility.Visible;
                            SelectedProject.DataContext = null;
                            SelectedProject.Visibility = Visibility.Collapsed;
                            ModProjects.Remove((ModProject)obj);
                        }
                    };
                win.ShowSubWindow();
                win.Show();
            }
        }

        private void CreateMod(object sender, RoutedEventArgs e)
        {
            if (CurrentModProjectViewModel != null)
            {
                var progressHandler = new ProgressHandler();
                var thread = new Thread(delegate () { CurrentModProjectViewModel.Project.Create(progressHandler); });
                var window = new OperationPending("Lang.Windows.OperationPending", "CreateMod", progressHandler);
                if (!window.Completed)
                {
                    window.ShowSubWindow();
                    window.Show();
                }
                thread.Start();
            }
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            // ── 검증 1: Steam 설치 확인 ───────────────────────────────────────
            var steamPath = ModAPI.Configurations.Configuration.GetPath("Steam");
            var steamExePath = steamPath + System.IO.Path.DirectorySeparatorChar + "Steam.exe";
#if DEBUG
            var steamValid = !string.IsNullOrEmpty(steamPath) && System.IO.File.Exists(steamExePath);
#else
            var steamValid = ModAPI.Utils.FileValidator.IsValidSteamExe(steamExePath);
#endif
            if (!steamValid)
            {
                Debug.Log("StartGame", "[Validate] Steam not found → SteamNotFound popup", Debug.Type.Error);
                var winSteam = new Windows.SubWindows.NoProjectWarning("Lang.Windows.SteamNotFound");
                winSteam.ShowSubWindow();
                winSteam.Show();
                return;
            }
            Debug.Log("StartGame", "[Validate] Steam OK", Debug.Type.Notice);

            // ── 활성화된 mod 수집 ─────────────────────────────────────────────
            var currentFilter = Mods?.SelectedGameFilter ?? "All";
            bool isAllFilter = string.IsNullOrEmpty(currentFilter) || currentFilter == "All";

            var mods = new List<Mod>();
            foreach (var i in Mods.Mods)
            {
                var vm = (ModViewModel)i.DataContext;
                if (vm != null && vm.Selected)
                {
                    // All 필터가 아니면, 현재 선택된 필터의 게임 mod만 수집한다.
                    // (필터를 특정 게임으로 바꿔도 다른 게임에서 체크해둔 mod가
                    //  안 보이는 채로 계속 집계되어, 필터와 무관하게 게임 선택
                    //  팝업이 뜨는 등 필터를 무시하는 것처럼 보이는 문제가 있었다)
                    if (!isAllFilter && !string.Equals(vm.GameId, currentFilter, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    var vm2 = (ModVersionViewModel)vm.SelectedVersion.DataContext;
                    if (vm2 != null)
                    {
                        mods.Add(vm2.Mod);
                        Debug.Log("StartGame",
                            $"[ModCollect] Selected: {vm2.Mod.Id} | Game: {vm2.Mod.Game?.GameConfiguration?.Id}",
                            Debug.Type.Notice);
                    }
                }
            }
            Debug.Log("StartGame", $"[ModCollect] Total: {mods.Count} | Filter: {currentFilter}", Debug.Type.Notice);

            // 선택된 mod 의 게임 ID 목록
            var selectedGameIds = mods
                .Select(m => m.Game?.GameConfiguration?.Id ?? "")
                .Where(id => !string.IsNullOrEmpty(id))
                .Distinct()
                .ToList();

            // ── 검증 2: 게임 경로 확인 ───────────────────────────────────────
            // All 필터 또는 복수 게임 mod 선택 시 → 게임 선택 팝업
            // 특정 게임 필터 선택 시 → 해당 게임 경로 직접 확인
            var supportedGameIds2 = new List<string> { "TheForest", "Subnautica", "Raft", "EscapeThePacific", "GH" };

            bool needGameSelect = isAllFilter || selectedGameIds.Count >= 2;

            Debug.Log("StartGame",
                $"[Validate] Filter: {currentFilter}" +
                $" | SelectedGameIds: [{string.Join(", ", selectedGameIds)}]" +
                $" | NeedGameSelect: {needGameSelect}",
                Debug.Type.Notice);

            if (needGameSelect)
            {
                // 후보: 활성화된 mod 의 게임이 있으면 해당 게임만, 없으면 전체 지원 게임
                var candidateIds = selectedGameIds.Count >= 1 ? selectedGameIds : supportedGameIds2;

                Debug.Log("StartGame",
                    $"[GameSelect] Candidate IDs: [{string.Join(", ", candidateIds)}]",
                    Debug.Type.Notice);

                // ── 팝업에 표시할 게임 목록 결정 ────────────────────────────────
                // 활성화된 mod 의 게임이 있으면 해당 게임 전체를 후보로 삼되,
                // 실제로 "설정 탭에 경로가 등록되어 있고 exe가 존재하는" 게임만 팝업에 남긴다.
                // (경로 미설정 게임까지 선택지로 보여주면, 사용자가 뭘 고르든 결국
                //  아래의 GamePathNotSet으로 다시 튕기게 되어 "게임 선택 → 경로 없음 안내"
                //  순서가 뒤바뀐 것처럼 보이는 문제가 있었다. 경로 검증을 먼저 하고
                //  통과한 게임만으로 선택 팝업을 구성한다)
                var popupGames = candidateIds.Count >= 1 ? candidateIds : supportedGameIds2;

                var installedPopupGames = popupGames.Where(gid =>
                {
                    var p = ModAPI.Configurations.Configuration.GetPath("Games." + gid, silent: true);
                    if (string.IsNullOrEmpty(p)) return false;
                    var exeName = ModAPI.Configurations.Configuration.Games.ContainsKey(gid)
                        ? ModAPI.Configurations.Configuration.Games[gid].SelectFile : null;
                    if (string.IsNullOrEmpty(exeName)) return false;
                    return System.IO.File.Exists(System.IO.Path.Combine(p, exeName));
                }).ToList();

                Debug.Log("StartGame",
                    $"[GameSelect] Popup games: [{string.Join(", ", popupGames)}]" +
                    $" | Installed: [{string.Join(", ", installedPopupGames)}]",
                    Debug.Type.Notice);

                if (installedPopupGames.Count == 0)
                {
                    Debug.Log("StartGame",
                        "[GameSelect] No installed games available → GamePathNotSet popup",
                        Debug.Type.Error);
                    var winNoGame = new Windows.SubWindows.NoProjectWarning("Lang.Windows.GamePathNotSet");
                    winNoGame.ShowSubWindow();
                    winNoGame.Show();
                    return;
                }

                // ── 검증 3: 모드 선택 여부 (게임 선택 팝업보다 먼저 확인) ───────────
                // 1.스팀경로 → 2.게임경로 → 3.모드선택 순서를 지키기 위해,
                // 게임 후보가 여러 개라서 SelectGameDialog를 띄우기 전에
                // "애초에 선택한 mod가 하나라도 있는지"부터 먼저 확인한다.
                if (mods.Count == 0)
                {
                    Debug.Log("StartGame",
                        $"[Validate] No mods selected (filter: {currentFilter}) → NoModSelected popup",
                        Debug.Type.Warning);
                    var winNoModEarly = new Windows.SubWindows.NoProjectWarning("Lang.Windows.NoModSelected");
                    winNoModEarly.ShowSubWindow();
                    winNoModEarly.Show();
                    return;
                }

                string chosenGameId;
                if (installedPopupGames.Count == 1)
                {
                    // 후보가 1개면 자동 선택
                    chosenGameId = installedPopupGames[0];
                    Debug.Log("StartGame",
                        $"[GameSelect] Auto-selected single game: {chosenGameId}",
                        Debug.Type.Notice);
                }
                else
                {
                    // 2개 이상이면 팝업 (설치 확인된 게임만 표시)
                    Debug.Log("StartGame",
                        $"[GameSelect] Showing SelectGameDialog with {installedPopupGames.Count} options",
                        Debug.Type.Notice);
                    var selectWin = new Windows.SubWindows.SelectGameDialog(installedPopupGames);
                    selectWin.Owner = this;
                    selectWin.ShowDialog();
                    if (string.IsNullOrEmpty(selectWin.SelectedGameId))
                    {
                        Debug.Log("StartGame",
                            "[GameSelect] User cancelled SelectGameDialog",
                            Debug.Type.Notice);
                        return;
                    }
                    chosenGameId = selectWin.SelectedGameId;
                    Debug.Log("StartGame",
                        $"[GameSelect] User selected: {chosenGameId}",
                        Debug.Type.Notice);
                }

                // ── 선택한 게임 경로 확인 (2순위) ───────────────────────────
                var chosenPath = ModAPI.Configurations.Configuration.GetPath("Games." + chosenGameId, silent: true);
                var chosenExeName = ModAPI.Configurations.Configuration.Games.ContainsKey(chosenGameId)
                    ? ModAPI.Configurations.Configuration.Games[chosenGameId].SelectFile : null;
                var chosenExeFull = !string.IsNullOrEmpty(chosenPath) && !string.IsNullOrEmpty(chosenExeName)
                    ? System.IO.Path.Combine(chosenPath, chosenExeName) : null;

                if (string.IsNullOrEmpty(chosenPath) ||
                    string.IsNullOrEmpty(chosenExeFull) ||
                    !System.IO.File.Exists(chosenExeFull))
                {
                    Debug.Log("StartGame",
                        $"[Validate] Game path not set or exe not found for: {chosenGameId} → GamePathNotSet popup",
                        Debug.Type.Error);
                    var winNoPath = new Windows.SubWindows.NoProjectWarning("Lang.Windows.GamePathNotSet");
                    winNoPath.ShowSubWindow();
                    winNoPath.Show();
                    return;
                }
                Debug.Log("StartGame",
                    $"[Validate] Game path OK: {chosenGameId} → {chosenExeFull}",
                    Debug.Type.Notice);

                // 선택한 게임으로 필터 전환
                Mods.SelectedGameFilter = chosenGameId;
                SyncModGameFilterRadioButton(chosenGameId);

                // 선택한 게임의 mod 만 재수집 — 다른 게임 mod 는 완전히 무시
                mods.Clear();
                foreach (var i in Mods.Mods)
                {
                    var vm = (ModViewModel)i.DataContext;
                    if (vm != null && vm.Selected &&
                        string.Equals(vm.GameId, chosenGameId, StringComparison.OrdinalIgnoreCase))
                    {
                        var vm2 = (ModVersionViewModel)vm.SelectedVersion.DataContext;
                        if (vm2 != null) mods.Add(vm2.Mod);
                    }
                }

                Debug.Log("StartGame",
                    $"[GameSelect] Mods collected for {chosenGameId}: {mods.Count}개" +
                    $" | [{string.Join(", ", mods.Select(m => m.Id))}]",
                    Debug.Type.Notice);

                if (mods.Count == 0)
                {
                    Debug.Log("StartGame",
                        $"[GameSelect] No mods selected for {chosenGameId} → NoModSelected popup",
                        Debug.Type.Warning);
                    var winNoMod = new Windows.SubWindows.NoProjectWarning("Lang.Windows.NoModSelected");
                    winNoMod.ShowSubWindow();
                    winNoMod.Show();
                    return;
                }
            }
            else
            {
                // ── 검증 3: 특정 게임 필터 선택 시 "게임경로 → mod 활성화" 순서로 확인 ───────────
                // (게임경로 검증 없이 mod 개수부터 확인하면, 경로도 없고 mod도 없는 상태에서
                //  "모드를 선택하세요" 팝업이 먼저 떠서 원인을 오해하게 만드는 문제가 있었다)
                var filterPath = ModAPI.Configurations.Configuration.GetPath("Games." + currentFilter, silent: true);
                var filterExeName = ModAPI.Configurations.Configuration.Games.ContainsKey(currentFilter)
                    ? ModAPI.Configurations.Configuration.Games[currentFilter].SelectFile : null;
                var filterExeFull = !string.IsNullOrEmpty(filterPath) && !string.IsNullOrEmpty(filterExeName)
                    ? System.IO.Path.Combine(filterPath, filterExeName) : null;

                if (string.IsNullOrEmpty(filterPath) ||
                    string.IsNullOrEmpty(filterExeFull) ||
                    !System.IO.File.Exists(filterExeFull))
                {
                    Debug.Log("StartGame",
                        $"[Validate] Game path not set or exe not found for filter: {currentFilter} → GamePathNotSet popup",
                        Debug.Type.Error);
                    var winNoPath = new Windows.SubWindows.NoProjectWarning("Lang.Windows.GamePathNotSet");
                    winNoPath.ShowSubWindow();
                    winNoPath.Show();
                    return;
                }
                Debug.Log("StartGame", $"[Validate] Game path OK for filter: {currentFilter}", Debug.Type.Notice);

                if (mods.Count == 0)
                {
                    Debug.Log("StartGame",
                        $"[Validate] No mods selected for filter: {currentFilter} → NoModSelected popup",
                        Debug.Type.Warning);
                    var winNoMod = new Windows.SubWindows.NoProjectWarning("Lang.Windows.NoModSelected");
                    winNoMod.ShowSubWindow();
                    winNoMod.Show();
                    return;
                }
                Debug.Log("StartGame", $"[Validate] Mods OK: {mods.Count}개", Debug.Type.Notice);
            }

            // 선택된 mod의 게임 ID로 게임 객체 결정
            var modGameId = mods[0].Game?.GameConfiguration?.Id;
            Game targetGame = null;

            if (!string.IsNullOrEmpty(modGameId))
            {
                // App.Game이 같은 게임이면 바로 사용 (이미 완전 초기화됨)
                if (App.Game != null &&
                    string.Equals(App.Game.GameConfiguration.Id, modGameId, StringComparison.OrdinalIgnoreCase))
                {
                    // GamePath 가 비어있으면 저장된 경로로 보완
                    if (string.IsNullOrEmpty(App.Game.GamePath))
                    {
                        var savedPathForAppGame = ModAPI.Configurations.Configuration.GetPath(
                            "Games." + modGameId, silent: true);
                        if (!string.IsNullOrEmpty(savedPathForAppGame))
                            App.Game.GamePath = savedPathForAppGame;
                    }
                    targetGame = App.Game;
                }
                else
                {
                    // 저장된 경로로 게임 실행 가능 여부 먼저 확인
                    Configuration.GameConfiguration gameConfig = null;
                    if (Configuration.Games.ContainsKey(modGameId))
                        gameConfig = Configuration.Games[modGameId];
                    else
                    {
                        foreach (var kv in Configuration.Games)
                        {
                            if (string.Equals(kv.Value.Id, modGameId, StringComparison.OrdinalIgnoreCase))
                            {
                                gameConfig = kv.Value;
                                break;
                            }
                        }
                    }

                    if (gameConfig != null)
                    {
                        // 경량 Game으로 FindGamePath() 자동 탐색 시도
                        var tempGame = new Game(gameConfig, true);
                        var savedPath = Configuration.GetPath("Games." + gameConfig.Id, silent: true);

                        if (string.IsNullOrEmpty(savedPath))
                        {
                            // 자동 탐색 시도
                            savedPath = tempGame.FindGamePath();
                            if (!string.IsNullOrEmpty(savedPath))
                            {
                                // 탐색 성공 → 저장
                                Configuration.SetPath("Games." + gameConfig.Id, savedPath, true);
                                Configuration.Save();
                            }
                        }

                        if (string.IsNullOrEmpty(savedPath))
                        {
                            // 검증 4: 경로 미설정 → Settings 탭 안내
                            var win = new Windows.SubWindows.NoProjectWarning("Lang.Windows.GamePathNotSet");
                            win.ShowSubWindow();
                            win.Show();
                            return;
                        }

                        // 검증 5: 게임 실행파일 존재 여부 확인
                        var exePath = System.IO.Path.Combine(savedPath, gameConfig.SelectFile);
                        if (!System.IO.File.Exists(exePath))
                        {
                            var win = new Windows.SubWindows.NoProjectWarning("Lang.Windows.GameNotInstalled");
                            win.ShowSubWindow();
                            win.Show();
                            return;
                        }

                        // 완전 초기화된 Game 객체 생성 (Verify 포함)
                        targetGame = new Game(gameConfig);
                    }
                }
            }

            if (targetGame == null)
                targetGame = App.Game;

#if !DEBUG
            // ── 검증: 게임 실행파일 무결성 확인 ─────────────────────────────
            if (targetGame != null && !string.IsNullOrEmpty(targetGame.GamePath))
            {
                var gameExePath = System.IO.Path.Combine(
                    targetGame.GamePath, targetGame.GameConfiguration.SelectFile);

                // 검증 A: PE 헤더 검증 — 실행파일 위/변조 확인
                if (!ModAPI.Utils.FileValidator.IsValidGameExe(gameExePath))
                {
                    Debug.Log("StartGame",
                        $"[Integrity] Game executable PE validation failed: {gameExePath}",
                        Debug.Type.Error);
                    var winCorrupt = new Windows.SubWindows.NoProjectWarning(
                        "Lang.Windows.GameExeCorrupted");
                    winCorrupt.ShowSubWindow();
                    winCorrupt.Show();
                    return;
                }
                Debug.Log("StartGame",
                    $"[Integrity] Game executable PE validation passed: {gameExePath}",
                    Debug.Type.Notice);

                // 검증 B: Assembly-CSharp.dll 체크섬 → Versions.xml 비교
                var managedFolder = System.IO.Path.Combine(
                    targetGame.GamePath,
                    targetGame.GameConfiguration.Id + "_Data",
                    "Managed");

                if (!System.IO.Directory.Exists(managedFolder))
                {
                    // 일부 게임은 Data 폴더명이 다름 — GH 등
                    managedFolder = System.IO.Path.Combine(
                        targetGame.GamePath,
                        targetGame.GameConfiguration.Id.Replace("EscapeThePacific", "EscapeThePacific") + "_Data",
                        "Managed");
                }

                var actualChecksum = ModAPI.Utils.FileValidator.ComputeAssemblyChecksum(managedFolder);
                if (actualChecksum != null && targetGame.GameVersion.IsValid)
                {
                    var expectedChecksum = targetGame.GameVersion.CheckSum?.ToLower();
                    if (!string.IsNullOrEmpty(expectedChecksum) &&
                        !string.Equals(actualChecksum, expectedChecksum, StringComparison.OrdinalIgnoreCase))
                    {
                        Debug.Log("StartGame",
                            $"[Integrity] Assembly checksum mismatch!" +
                            $" Expected: {expectedChecksum} | Actual: {actualChecksum}",
                            Debug.Type.Error);
                        var winTampered = new Windows.SubWindows.NoProjectWarning(
                            "Lang.Windows.GameAssemblyTampered");
                        winTampered.ShowSubWindow();
                        winTampered.Show();
                        return;
                    }
                    Debug.Log("StartGame",
                        $"[Integrity] Assembly checksum matched: {actualChecksum}",
                        Debug.Type.Notice);
                }

                // 검증 C: 디지털 서명 확인 (경고만 — 차단하지 않음)
                if (!ModAPI.Utils.FileValidator.HasDigitalSignature(gameExePath))
                {
                    Debug.Log("StartGame",
                        $"[Integrity] Game executable has no digital signature: {gameExePath}",
                        Debug.Type.Warning);

                    bool userConfirmed;
                    try
                    {
                        // 사용자에게 선택권 부여 — 계속 진행 여부
                        string displayName;
                        try
                        {
                            displayName = GameDisplayNames.ContainsKey(targetGame.GameConfiguration.Id)
                                ? GameDisplayNames[targetGame.GameConfiguration.Id]
                                : targetGame.GameConfiguration.Id;
                        }
                        catch (Exception exName)
                        {
                            Debug.Log("StartGame",
                                $"[Integrity] Failed to resolve game display name: {exName.Message}",
                                Debug.Type.Warning);
                            displayName = targetGame?.GameConfiguration?.Id ?? "";
                        }

                        Debug.Log("StartGame",
                            $"[Integrity] Opening GameIntegrityWarning popup. DisplayName: {displayName}",
                            Debug.Type.Notice);

                        var winNoSig = new Windows.SubWindows.GameIntegrityWarning(
                            "Lang.Windows.GameNoSignature", displayName);
                        winNoSig.ShowSubWindow();
                        winNoSig.ShowDialog();
                        userConfirmed = winNoSig.UserConfirmed;

                        Debug.Log("StartGame",
                            $"[Integrity] GameIntegrityWarning closed. UserConfirmed: {userConfirmed}",
                            Debug.Type.Notice);
                    }
                    catch (Exception exPopup)
                    {
                        // 팝업 생성/표시 중 예외 발생 시 ModAPI 전체가 강제 종료되지 않도록 방어
                        // 서명 없음은 경고일 뿐 차단 사유가 아니므로, 팝업 자체가 실패해도
                        // 안전하게 통과시키고 원인을 로그로 남긴다.
                        Debug.Log("StartGame",
                            $"[Integrity] GameIntegrityWarning popup failed: {exPopup.GetType().Name}" +
                            $" | {exPopup.Message} | {exPopup}",
                            Debug.Type.Error);
                        userConfirmed = true;
                    }

                    if (!userConfirmed)
                        return;
                    Debug.Log("StartGame",
                        "[Integrity] User chose to continue despite missing signature.",
                        Debug.Type.Notice);
                }
                else
                {
                    Debug.Log("StartGame",
                        $"[Integrity] Game executable digital signature verified: {gameExePath}",
                        Debug.Type.Notice);
                }
            }
#endif

            var progressHandler = new ProgressHandler();
            progressHandler.OnComplete += (o, ex) =>
            {
                var excludedSummary = targetGame.LastExcludedModsSummary;
                var launched = targetGame.LastAppliedModCount > 0;

                // 실제로 적용된 mod가 0개면(전부 게임 불일치로 제외됐거나 실패) 게임을
                // 실행하지 않는다. SetProgress(handler, 100f, "Finish")만으로는 "적용된 게
                // 없어도 정상 종료"와 "실제로 적용하고 정상 종료"를 구분할 수 없었는데,
                // Game.LastAppliedModCount로 구분해서 판단한다.
                //
                // "mod 제외됨" 안내와 "게임 실행 여부" 안내는 같은 작업의 결과라서 각자
                // 따로 팝업을 띄우면(서명 경고 팝업과도 겹쳐서) 순서가 헷갈렸다.
                // 여기서 하나로 합쳐서 한 번만 보여준다.
                if (!string.IsNullOrEmpty(excludedSummary) || !launched)
                {
                    Debug.Log("StartGame",
                        "[Launch] LastAppliedModCount=" + targetGame.LastAppliedModCount +
                        " | ExcludedMods=" + (string.IsNullOrEmpty(excludedSummary) ? "(none)" : excludedSummary) +
                        (launched ? " → launching with remaining mods" : " → skipping game launch (nothing to run)"),
                        Debug.Type.Warning);

                    Func<string, string, string> lang = (key, fallback) =>
                    {
                        try
                        {
                            var v = Application.Current.Resources[key] as string;
                            return string.IsNullOrEmpty(v) ? fallback : v;
                        }
                        catch (Exception)
                        {
                            return fallback;
                        }
                    };

                    string title;
                    string message;
                    var excludedTemplate = lang("Lang.Windows.IncompatibleModsExcluded.Text",
                        "The following mod(s) appear to be built for a different game and were excluded: {0}");

                    if (!launched)
                    {
                        title = lang("Lang.Windows.NoModsApplied.Title", "No Mods Applied");
                        message = lang("Lang.Windows.NoModsApplied.Text",
                            "No valid mods remained to apply, so the game was not started.");
                        if (!string.IsNullOrEmpty(excludedSummary))
                        {
                            message += "\n\n" + string.Format(excludedTemplate, excludedSummary);
                        }
                    }
                    else
                    {
                        title = lang("Lang.Windows.IncompatibleModsExcluded.Title", "Some Mods Excluded");
                        message = string.Format(excludedTemplate, excludedSummary);
                    }

                    Dispatcher.Invoke(delegate
                    {
                        var win = Windows.SubWindows.ModsExcludedWarning.CreateWithCustomMessage(
                            title, message, "Lang.Windows.NoModsApplied.OK");
                        win.ShowSubWindow();
                        win.ShowDialog();
                    });

                    if (!launched) return;
                }

                if (Configuration.GetString("UseSteam") == "true" && targetGame.GameConfiguration.SteamAppId != "")
                {
                    var p = new Process();
                    p.StartInfo.FileName = Configuration.GetPath("Steam") + Path.DirectorySeparatorChar + "Steam.exe";
                    p.StartInfo.Arguments = "-applaunch " + targetGame.GameConfiguration.SteamAppId;
                    p.Start();
                }
                else
                {
                    var p = new Process();
                    p.StartInfo.FileName = targetGame.GamePath + Path.DirectorySeparatorChar + targetGame.GameConfiguration.SelectFile;
                    p.Start();
                }
            };

            var thread = new Thread(delegate () { targetGame.ApplyMods(mods, progressHandler); });
            var window = new OperationPending("Lang.Windows.OperationPending", "ApplyMods", progressHandler, null, true);
            if (!window.Completed)
            {
                window.ShowSubWindow();
                window.Show();
            }
            thread.Start();
        }

        // ===== Downloads Tab =====

        private List<ModInfo> _allMods = new List<ModInfo>();
        private string _sortProperty = "DownloadCount";
        private bool _sortAscending = false;
        private string _selectedCategory = "All";
        private string _selectedGame = "All";

        public class ModInfo
        {
            public string Name { get; set; }
            public string Author { get; set; }
            public string Category { get; set; }
            public string Game { get; set; }
            public string GameId { get; set; }   // 게임 폴더명 (mods\{GameId}\)
            public string DownloadCount { get; set; }
            public int ModId { get; set; }
            public string Slug { get; set; }
        }

        public class ModVersionInfo
        {
            public string Version { get; set; }
            public string Compatible { get; set; }
            public string Date { get; set; }
            public string Size { get; set; }
            public string Downloads { get; set; }
            public int ModId { get; set; }
            public int FileId { get; set; }
            public string GameShortName { get; set; }
        }

        private bool CheckInternetConnection()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://modapi.survivetheforest.net");
                request.Timeout = 5000;
                request.Method = "HEAD";
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                return false;
            }
        }

        private void UpdateDownloadPanelVisibility(bool isOnline)
        {
            DownloadOnlinePanel.Visibility = isOnline ? Visibility.Visible : Visibility.Collapsed;
            DownloadOfflinePanel.Visibility = isOnline ? Visibility.Collapsed : Visibility.Visible;
        }

        private string FetchHtml(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 15000;
                request.UserAgent = "ModAPI/2.0";
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
            catch
            {
                return "";
            }
        }

        private List<ModInfo> ParseModsFromHtml(string html, string gameLabel, string gameId = "TheForest")
        {
            var mods = new List<ModInfo>();
            if (string.IsNullOrEmpty(html)) return mods;

            // Split HTML by mod entry blocks using the View link pattern
            // Each mod has: <a href="/mod/{id}/{slug}"> for title and [View] link
            var modBlocks = Regex.Split(html, @"(?=<h4[^>]*>\s*<a\s+href=""/mod/)");

            foreach (var block in modBlocks)
            {
                if (string.IsNullOrWhiteSpace(block)) continue;

                // Extract mod ID and slug from title link
                var linkMatch = Regex.Match(block, @"<a\s+href=""/mod/(\d+)/([^""]+)""[^>]*>([^<]+)</a>");
                if (!linkMatch.Success) continue;

                var modId = int.Parse(linkMatch.Groups[1].Value);
                var slug = linkMatch.Groups[2].Value;
                var name = System.Net.WebUtility.HtmlDecode(linkMatch.Groups[3].Value).Trim();

                // Extract category (text after material-icons "label")
                var category = "";
                var catMatch = Regex.Match(block, @">label</[^>]+>\s*(?:<[^>]+>\s*)*([^<]+)");
                if (catMatch.Success)
                    category = catMatch.Groups[1].Value.Trim();

                // Extract author name (text after avatar image)
                var author = "";
                var authorMatch = Regex.Match(block, @"(?:steamstatic|steamcdn|akamaihd)[^""]*full\.jpg[^>]*/?\>\s*(?:<[^>]+>\s*)*([^<\r\n]+)");
                if (authorMatch.Success)
                    author = authorMatch.Groups[1].Value.Trim();
                if (string.IsNullOrEmpty(author))
                {
                    // Fallback: look for text between avatar section and date pattern
                    var fallbackMatch = Regex.Match(block, @"full\.jpg[^>]*/?\>[\s\S]*?(?:</[^>]+>\s*)*\n\s*(\S[^\n<]*?)\s*\n");
                    if (fallbackMatch.Success)
                        author = fallbackMatch.Groups[1].Value.Trim();
                }

                // Extract download count (number after "Downloads" text with file_download icon)
                var downloadCount = "0";
                var dlMatch = Regex.Match(block, @">file_download</[^>]+>.*?>Downloads\s*</[^>]+>\s*(?:<[^>]+>\s*)*([0-9,]+)");
                if (!dlMatch.Success)
                    dlMatch = Regex.Match(block, @"Downloads\s*(?:<[^>]+>\s*)*([0-9,]+)");
                if (dlMatch.Success)
                    downloadCount = dlMatch.Groups[1].Value.Trim();

                mods.Add(new ModInfo
                {
                    Name = name,
                    Author = author,
                    Category = category,
                    Game = gameLabel,
                    GameId = gameId,
                    DownloadCount = downloadCount,
                    ModId = modId,
                    Slug = slug
                });
            }

            return mods;
        }

        private void LoadModsFromWeb(Action<int> onProgress = null)
        {
            var sources = new[]
            {
                new { Url = "https://modapi.survivetheforest.net/mods/", Label = "The Forest", Id = "TheForest" },
                new { Url = "https://modapi.survivetheforest.net/mods/game/TheForestDedicatedServer/", Label = "Dedicated Server", Id = "TheForestDedicatedServer" },
                new { Url = "https://modapi.survivetheforest.net/mods/game/TheForestVR/", Label = "VR", Id = "TheForestVR" },
                new { Url = "https://modapi.survivetheforest.net/mods/game/Subnautica/", Label = "Subnautica", Id = "Subnautica" },
                new { Url = "https://modapi.survivetheforest.net/mods/game/Raft/", Label = "RAFT", Id = "Raft" },
                new { Url = "https://modapi.survivetheforest.net/mods/game/EscapeThePacific/", Label = "Escape The Pacific", Id = "EscapeThePacific" },
                new { Url = "https://modapi.survivetheforest.net/mods/game/GH/", Label = "Green Hell", Id = "GH" },
                new { Url = "https://modapi.survivetheforest.net/mods/game/SonsOfTheForest/", Label = "SOTF", Id = "SonsOfTheForest" },
            };

            var allMods = new List<ModInfo>();

            for (var i = 0; i < sources.Length; i++)
            {
                var source = sources[i];
                var html = FetchHtml(source.Url);
                var mods = ParseModsFromHtml(html, source.Label, source.Id);
                allMods.AddRange(mods);

                // 진행률: 현재 소스 완료 후 비율 (1~100%)
                var percent = (int)Math.Round((i + 1) / (double)sources.Length * 100);
                onProgress?.Invoke(percent);
            }

            // Remove duplicates by ModId (keep first occurrence)
            _allMods = allMods
                .GroupBy(m => m.ModId)
                .Select(g => g.First())
                .OrderByDescending(m =>
                {
                    int count;
                    int.TryParse(m.DownloadCount.Replace(",", ""), out count);
                    return count;
                })
                .ToList();
        }

        private void ApplyModFilter()
        {
            var searchText = DownloadSearchBox.Text.Trim().ToLower();
            DownloadModList.Items.Clear();

            var filtered = _allMods.AsEnumerable();

            // 1st filter: Game
            if (!string.IsNullOrEmpty(_selectedGame) && _selectedGame != "All")
            {
                filtered = filtered.Where(m =>
                    m.Game.IndexOf(_selectedGame, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            // 2nd filter: Category
            if (!string.IsNullOrEmpty(_selectedCategory) && _selectedCategory != "All")
            {
                filtered = filtered.Where(m =>
                    m.Category.Equals(_selectedCategory, StringComparison.OrdinalIgnoreCase));
            }

            // Search text filter
            if (!string.IsNullOrEmpty(searchText))
            {
                filtered = filtered.Where(m =>
                    m.Name.ToLower().Contains(searchText) ||
                    m.Author.ToLower().Contains(searchText) ||
                    m.Category.ToLower().Contains(searchText) ||
                    m.Game.ToLower().Contains(searchText)
                );
            }

            var filteredList = filtered.ToList();

            // Apply sort
            var sorted = SortModList(filteredList);

            foreach (var mod in sorted)
            {
                DownloadModList.Items.Add(mod);
            }

            var loadComplete = FindResource("Lang.Downloads.Status.LoadComplete") as string ?? "불러오기 완료";
            DownloadStatusText.Text = string.Format("  {0} mods  ←  {1}", filteredList.Count, loadComplete);
        }

        private static readonly Dictionary<string, string> CategoryMap = new Dictionary<string, string>
        {
            { "CatAll", "All" },
            { "CatBugfixes", "Bugfixes" },
            { "CatBalancing", "Balancing" },
            { "CatCheats", "Cheats" },
            { "CatBuildings", "Buildings" },
            { "CatGraphical", "Graphical" },
            { "CatChanges", "Changes" },
            { "CatItems", "Items" },
            { "CatEnemies", "Enemies" },
            { "CatMultiplayer", "Multiplayer" },
            { "CatWorldchanges", "Worldchanges" },
            { "CatOther", "Other" },
        };

        private void CategoryFilter_Checked(object sender, RoutedEventArgs e)
        {
            var rb = sender as System.Windows.Controls.RadioButton;
            if (rb == null) return;

            string category;
            if (!CategoryMap.TryGetValue(rb.Name, out category))
                category = "All";

            _selectedCategory = category;
            if (_allMods.Count > 0)
                ApplyModFilter();
        }

        private static readonly Dictionary<string, string> GameMap = new Dictionary<string, string>
        {
            { "GameAll", "All" },
            { "GameTheForest", "The Forest" },
            { "GameDedicatedServer", "Dedicated Server" },
            { "GameVR", "VR" },
            { "GameSubnautica", "Subnautica" },
            { "GameRaft", "RAFT" },
            { "GameEscapeThePacific", "Escape The Pacific" },
            { "GameGreenHell", "Green Hell" },
            { "GameSOTF", "SOTF" },
        };

        // GameConfiguration.Id → Lang key (Downloads 탭과 공유)
        private static readonly List<string> GamePathOrderedIds = new List<string>
        {
            "TheForest", "TheForestDedicatedServer", "TheForestVR",
            "Subnautica", "Raft", "EscapeThePacific", "GH"
        };

        private bool _allExpanded = false;
        private readonly List<Border> _gameCardBorders = new List<Border>();
        private readonly List<StackPanel> _gameCardContents = new List<StackPanel>();

        private void InitSteamPath()
        {
            var box = FindName("SteamPathBox") as System.Windows.Controls.TextBox;
            if (box == null) return;
            // 초기화 플래그 확인 — XML 이 빈 문자열을 저장하지 않는 경우 대비
            var resetFlag = LoadUiCfg("SteamPathReset") ?? "0";
            if (resetFlag == "1")
            {
                box.Text = "";
                return;
            }
            var saved = Configuration.GetPath("Steam", silent: true);
            // App.RootPath 와 같으면 미설정으로 간주 (GetFullPath("") 방어)
            if (!string.IsNullOrEmpty(saved))
            {
                try
                {
                    var full = System.IO.Path.GetFullPath(saved);
                    if (string.Equals(full.TrimEnd('\\'), App.RootPath.TrimEnd('\\'),
                        StringComparison.OrdinalIgnoreCase))
                        saved = "";
                }
                catch { saved = ""; }
            }
            box.Text = string.IsNullOrEmpty(saved) ? "" : saved;
        }

        private void SteamBrowse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Steam.exe|Steam.exe",
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == true)
            {
                var folder = System.IO.Path.GetDirectoryName(dialog.FileName);
                var box = FindName("SteamPathBox") as System.Windows.Controls.TextBox;
                if (box != null) box.Text = folder;
                // 경로 저장 시 초기화 플래그 제거
                SaveUiCfg("SteamPathReset", "0");
                Configuration.SetPath("Steam", folder, true);
                Configuration.Save();
                Debug.Log("Steam", "Path saved (browse): " + folder);
            }
        }

        private void SteamSave_Click(object sender, RoutedEventArgs e)
        {
            var box = FindName("SteamPathBox") as System.Windows.Controls.TextBox;
            if (box == null) return;
            // 경로 저장 시 초기화 플래그 제거
            SaveUiCfg("SteamPathReset", "0");
            Configuration.SetPath("Steam", box.Text, true);
            Configuration.Save();
            Debug.Log("Steam", "Path saved: " + box.Text);
        }

        private void SteamReset_Click(object sender, RoutedEventArgs e)
        {
            // 초기화 플래그 저장 — XML 은 빈 문자열 미저장으로 신뢰 불가
            SaveUiCfg("SteamPathReset", "1");
            Configuration.SetPath("Steam", "", true);
            Configuration.Save();
            var box = FindName("SteamPathBox") as System.Windows.Controls.TextBox;
            if (box != null) box.Text = "";
            Debug.Log("Steam", "Path reset.");
        }

        private void BuildGamePathsPanel()
        {
            var panel = FindName("GamePathsPanel") as StackPanel;
            if (panel == null) return;
            panel.Children.Clear();
            _gameCardBorders.Clear();
            _gameCardContents.Clear();

            foreach (var gameId in GamePathOrderedIds)
            {
                Configuration.GameConfiguration config = null;
                if (Configuration.Games.ContainsKey(gameId))
                    config = Configuration.Games[gameId];
                else
                {
                    foreach (var kv in Configuration.Games)
                    {
                        if (string.Equals(kv.Value.Id, gameId, StringComparison.OrdinalIgnoreCase))
                        { config = kv.Value; break; }
                    }
                }
                if (config == null) continue;

                var gameName = !string.IsNullOrEmpty(config.Name) ? config.Name : config.Id;
                // 경로 정규화 — 구분자를 백슬래시로 통일
                var rawPath = (Configuration.GetPath("Games." + gameId, silent: true) ?? "").Trim();
                // ui.cfg 초기화 플래그 확인 — Configuration XML 이 빈 문자열을 저장하지 않는 경우 대비
                var resetFlag = LoadUiCfg("GamePathReset_" + gameId) ?? "0";
                bool wasReset = resetFlag == "1";
                // rawPath 가 App.RootPath 와 같으면 경로 미설정으로 간주 (GetFullPath("") 방어)
                string savedPath;
                if (wasReset || string.IsNullOrEmpty(rawPath))
                {
                    savedPath = "";
                }
                else
                {
                    var fullPath = System.IO.Path.GetFullPath(rawPath.Replace('/', '\\'));
                    savedPath = string.Equals(fullPath.TrimEnd('\\'),
                        App.RootPath.TrimEnd('\\'),
                        StringComparison.OrdinalIgnoreCase)
                        ? ""
                        : fullPath;
                }

                // 경로 미설정 시 빈 상태로 유지 — 자동 탐색은 최초 설정(FirstSetupDone)에서만 수행
                // Settings 탭은 저장된 값을 그대로 표시
                // 설치 여부 확인 — 경로 비어있거나 exe 없으면 미설치
                var exeName = config.SelectFile;
                var isInstalled = !string.IsNullOrEmpty(savedPath)
                    && System.IO.File.Exists(System.IO.Path.Combine(savedPath, exeName));
                // 미설치: 경로 비어있거나 exe 없는 경우 모두 해당
                var capturedId = gameId;
                var capturedConfig = config;

                // 카드 외곽 Border
                var card = new Border
                {
                    Margin = new Thickness(0, 0, 0, 0),
                    CornerRadius = new CornerRadius(0),
                    BorderThickness = new Thickness(0, 0, 0, 1),
                    Tag = capturedId,
                };
                card.SetResourceReference(Border.BorderBrushProperty, "FluentBorderBrush");
                card.SetResourceReference(Border.BackgroundProperty, "FluentSurfaceBrush");

                // 헤더 행 (클릭 시 펼치기/닫기)
                var headerGrid = new Grid { Margin = new Thickness(12, 10, 12, 10), Cursor = Cursors.Hand };
                headerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                headerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                headerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                // 화살표 아이콘
                var arrow = new TextBlock
                {
                    Text = "▶",
                    FontSize = 10,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 10, 0),
                };
                arrow.SetResourceReference(TextBlock.ForegroundProperty, "FluentTextSecondaryBrush");
                Grid.SetColumn(arrow, 0);

                // 게임명
                var nameText = new TextBlock
                {
                    Text = gameName,
                    FontSize = 14,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = (FontFamily)FindResource("NormalFont"),
                };
                nameText.SetResourceReference(TextBlock.ForegroundProperty, "FluentTextPrimaryBrush");
                Grid.SetColumn(nameText, 1);

                // 현재 경로 요약 (헤더 우측) — 설치됨 / 미설치
                // SetResourceReference 사용 → 언어 변경 시 자동 반영
                var pathSummary = new TextBlock
                {
                    FontSize = 11,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextTrimming = TextTrimming.CharacterEllipsis,
                    MaxWidth = 280,
                };
                // 설치됨: 경로 있고 exe 존재 / 미설치: 그 외 모든 경우
                pathSummary.SetResourceReference(TextBlock.TextProperty,
                    isInstalled ? "Lang.Options.Labels.Installed" : "Lang.Options.Labels.NotInstalled");
                pathSummary.SetResourceReference(TextBlock.ForegroundProperty, "FluentTextPrimaryBrush");
                Grid.SetColumn(pathSummary, 2);

                headerGrid.Children.Add(arrow);
                headerGrid.Children.Add(nameText);
                headerGrid.Children.Add(pathSummary);

                // 펼침 콘텐츠 (기본 숨김)
                var pathBox = new TextBox
                {
                    Text = savedPath,   // 이미 정규화된 경로
                    Height = 32,
                    MinWidth = 300,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 6, 0),
                    FontFamily = (FontFamily)FindResource("NormalFont"),
                    FontSize = 12,
                    IsReadOnly = true,
                };
                pathBox.SetResourceReference(TextBox.ForegroundProperty, "FluentTextPrimaryBrush");
                pathBox.SetResourceReference(TextBox.BackgroundProperty, "FluentSurfaceBrush");

                var browseBtn = new Button
                {
                    Width = 80,
                    Height = 32,
                    Style = (Style)FindResource("NormalButton"),
                };
                var browseBtnText = new TextBlock { Style = (Style)FindResource("NormalLabel") };
                browseBtnText.SetResourceReference(TextBlock.TextProperty, "Lang.Options.Labels.Browse");
                browseBtn.Content = browseBtnText;

                var saveBtn = new Button
                {
                    Height = 32,
                    Margin = new Thickness(6, 0, 0, 0),
                    Style = (Style)FindResource("NormalButton"),
                    IsEnabled = false,
                };
                var saveBtnText = new TextBlock { Style = (Style)FindResource("NormalLabel") };
                saveBtnText.SetResourceReference(TextBlock.TextProperty, "Lang.Options.Labels.GamePathSave");
                saveBtn.Content = saveBtnText;

                var resetBtn = new Button
                {
                    Height = 32,
                    Margin = new Thickness(6, 0, 0, 0),
                    Style = (Style)FindResource("NormalButton"),
                };
                var resetBtnIcon = new TextBlock { Text = "\uE72C", FontFamily = new System.Windows.Media.FontFamily("Segoe MDL2 Assets"), FontSize = 14, Margin = new Thickness(0, 0, 5, 0), VerticalAlignment = VerticalAlignment.Center };
                var resetBtnText = new TextBlock { Style = (Style)FindResource("NormalLabel") };
                resetBtnText.SetResourceReference(TextBlock.TextProperty, "Lang.Options.Labels.PathReset");
                var resetBtnContent = new StackPanel { Orientation = Orientation.Horizontal };
                resetBtnContent.Children.Add(resetBtnIcon);
                resetBtnContent.Children.Add(resetBtnText);
                resetBtn.Content = resetBtnContent;

                browseBtn.Click += (s, e) =>
                {
                    var dlg = new Microsoft.Win32.OpenFileDialog
                    {
                        Filter = capturedConfig.SelectFile + "|" + capturedConfig.SelectFile,
                        Title = gameName,
                        RestoreDirectory = true,
                    };
                    if (dlg.ShowDialog() == true)
                    {
                        var folder = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(dlg.FileName));
                        pathBox.Text = folder;
                        saveBtn.IsEnabled = true;
                        // 저장 전 미리 설치 여부 확인
                        var preCheck = System.IO.Path.Combine(folder, capturedConfig.SelectFile);
                        pathSummary.SetResourceReference(TextBlock.TextProperty,
                            System.IO.File.Exists(preCheck)
                                ? "Lang.Options.Labels.Installed"
                                : "Lang.Options.Labels.NotInstalled");
                    }
                };

                saveBtn.Click += (s, e) =>
                {
                    // 경로 저장 시 초기화 플래그 제거
                    SaveUiCfg("GamePathReset_" + capturedId, "0");
                    Configuration.SetPath("Games." + capturedId, pathBox.Text, true);
                    Configuration.Save();
                    saveBtn.IsEnabled = false;
                    // 저장 후 실행파일 존재 확인 → 설치됨 / 미설치 표시
                    var exeCheck = System.IO.Path.Combine(pathBox.Text, capturedConfig.SelectFile);
                    pathSummary.SetResourceReference(TextBlock.TextProperty,
                        System.IO.File.Exists(exeCheck)
                            ? "Lang.Options.Labels.Installed"
                            : "Lang.Options.Labels.NotInstalled");
                };

                resetBtn.Click += (s, e) =>
                {
                    // ui.cfg 에 초기화 플래그 저장 — Configuration XML 은 빈 문자열 미저장으로 신뢰 불가
                    SaveUiCfg("GamePathReset_" + capturedId, "1");
                    Configuration.SetPath("Games." + capturedId, "", true);
                    Configuration.Save();
                    pathBox.Text = "";
                    saveBtn.IsEnabled = false;
                    pathSummary.SetResourceReference(TextBlock.TextProperty, "Lang.Options.Labels.NotInstalled");
                };

                var pathRow = new Grid { Margin = new Thickness(12, 0, 12, 10) };
                pathRow.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                pathRow.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                pathRow.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                pathRow.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                Grid.SetColumn(pathBox, 0);
                Grid.SetColumn(browseBtn, 1);
                Grid.SetColumn(saveBtn, 2);
                Grid.SetColumn(resetBtn, 3);
                pathRow.Children.Add(pathBox);
                pathRow.Children.Add(browseBtn);
                pathRow.Children.Add(saveBtn);
                pathRow.Children.Add(resetBtn);

                var content = new StackPanel { Orientation = Orientation.Vertical, Visibility = Visibility.Collapsed };
                content.Children.Add(pathRow);

                var cardStack = new StackPanel { Orientation = Orientation.Vertical };
                cardStack.Children.Add(headerGrid);
                cardStack.Children.Add(content);
                card.Child = cardStack;

                // 클릭 이벤트
                var capturedArrow = arrow;
                var capturedContent = content;
                headerGrid.MouseLeftButtonDown += (s, e) =>
                {
                    var isVisible = capturedContent.Visibility == Visibility.Visible;
                    capturedContent.Visibility = isVisible ? Visibility.Collapsed : Visibility.Visible;
                    capturedArrow.Text = isVisible ? "▶" : "▼";
                    UpdateWindowHeight();

                    // 하나라도 펼쳐져 있으면 '모두접기', 모두 접혀있으면 '모두펼치기'
                    _allExpanded = _gameCardContents.Any(c => c.Visibility == Visibility.Visible);
                    var btn = FindName("ExpandAllBtn") as Button;
                    if (btn != null)
                    {
                        var tb = btn.Content as TextBlock;
                        if (tb != null)
                            tb.SetResourceReference(TextBlock.TextProperty, _allExpanded
                                ? "Lang.Options.Labels.CollapseAll"
                                : "Lang.Options.Labels.ExpandAll");
                    }
                };

                _gameCardBorders.Add(card);
                _gameCardContents.Add(content);
                panel.Children.Add(card);

            }
        }

        private static readonly List<string> DevGameOrderedIds = new List<string>
        {
            "TheForest", "Subnautica", "Raft", "EscapeThePacific", "GH"
        };

        private void BuildDevGameFilter()
        {
            var panel = FindName("DevGameFilterPanel") as StackPanel;
            if (panel == null) return;
            panel.Children.Clear();

            var currentId = App.Game?.GameConfiguration?.Id ?? "TheForest";

            foreach (var gameId in DevGameOrderedIds)
            {
                Configuration.GameConfiguration config = null;
                if (Configuration.Games.ContainsKey(gameId))
                    config = Configuration.Games[gameId];
                else
                {
                    foreach (var kv in Configuration.Games)
                    {
                        if (string.Equals(kv.Value.Id, gameId, StringComparison.OrdinalIgnoreCase))
                        { config = kv.Value; break; }
                    }
                }
                if (config == null) continue;

                var name = !string.IsNullOrEmpty(config.Name) ? config.Name : config.Id;
                var capturedId = gameId;
                var capturedConfig = config;

                var rb = new RadioButton
                {
                    Content = name,
                    Margin = new Thickness(0, 0, 0, 4),
                    IsChecked = string.Equals(gameId, currentId, StringComparison.OrdinalIgnoreCase),
                    Tag = gameId,
                };
                rb.Checked += (s, e) => SwitchDevGame(capturedId, capturedConfig);
                panel.Children.Add(rb);
            }
        }

        private void SwitchDevGame(string gameId, Configuration.GameConfiguration config)
        {
            if (App.Game != null && string.Equals(App.Game.GameConfiguration.Id, gameId, StringComparison.OrdinalIgnoreCase))
                return;

            var savedPath = Configuration.GetPath("Games." + gameId, silent: true);
            if (string.IsNullOrEmpty(savedPath))
                Debug.Log("DevGameFilter", "Game path not set for: " + gameId + ". Please set in Settings tab.", Debug.Type.Warning);

            // 경량 생성자로 즉시 전환 (UI 블로킹 없음)
            App.Game = new Game(config, true);
            // 저장된 경로가 있으면 GamePath 설정 — CreateModLibrary 등이 경로를 사용할 수 있도록
            if (!string.IsNullOrEmpty(savedPath))
                App.Game.GamePath = savedPath;
            App.Game.OnModlibUpdate += (s, ev) => Dispatcher.Invoke(delegate { UpdateModlibVersion(); });

            // 기존 프로젝트 뷰모델 타이머 정지
            if (ModProjects != null) ModProjects.Dispose();

            // 프로젝트 목록 즉시 새로고침
            ModProjects = new ModProjectsViewModel();
            var devTab = FindName("Development") as FrameworkElement;
            if (devTab != null) devTab.DataContext = ModProjects;
            SetProject(null);
            UpdateModlibVersion();
            Debug.Log("DevGameFilter", "Development context switched to: " + gameId);
        }

        // ── Font Size ────────────────────────────────────────────────────────
        private bool _fontSizeUpdating = false;
        private static readonly double DefaultFontSize = 13.0;

        private void InitFontSize()
        {
            var selector = FindName("FontSizeSelector") as System.Windows.Controls.ComboBox;
            if (selector == null) return;

            selector.Items.Clear();

            // 테마 ComboBoxItem 스타일 적용
            if (Application.Current.Resources.Contains("ComboBoxItem"))
                selector.ItemContainerStyle = Application.Current.Resources["ComboBoxItem"] as Style;

            // 화면 해상도 기반 폰트 크기 범위
            var screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            int maxSize = screenWidth >= 7680 ? 28 : screenWidth >= 3840 ? 22 : 16;

            for (int sz = 10; sz <= maxSize; sz++)
            {
                var item = new System.Windows.Controls.ComboBoxItem
                {
                    Content = sz + "px",
                    Tag = (double)sz
                };
                if (Application.Current.Resources.Contains("ComboBoxItem"))
                    item.Style = Application.Current.Resources["ComboBoxItem"] as Style;
                selector.Items.Add(item);
            }

            // 저장된 값 또는 기본값 선택 (클램프 없이 그대로)
            var saved = LoadUiCfg("AppFontSize") ?? Configuration.GetString("AppFontSize", silent: true);
            double current = DefaultFontSize;
            if (!string.IsNullOrEmpty(saved) && double.TryParse(saved, out double s))
                current = s;

            _fontSizeUpdating = true;
            for (int i = 0; i < selector.Items.Count; i++)
            {
                var item = selector.Items[i] as System.Windows.Controls.ComboBoxItem;
                if (item != null && (double)item.Tag == current)
                {
                    selector.SelectedIndex = i;
                    break;
                }
            }
            if (selector.SelectedIndex < 0) selector.SelectedIndex = 0;
            _fontSizeUpdating = false;

            ApplyFontSize(current);

            // 시작 시 저장된 폰트 크기를 불러오는 경로라서 FontSizeSelector_Changed(콤보박스
            // 변경 이벤트)가 호출되지 않는다(_fontSizeUpdating 로 억제됨). 그래서 창 너비/높이
            // 재계산도 같이 빠져있었다 — 저장된 폰트가 MAX 등 큰 값이면, 처음 실행 시 창
            // 크기가 그 폰트에 맞게 계산되지 않아 마지막 카드가 잘리는 문제가 있었다.
            // 콤보박스 변경 핸들러와 동일하게 여기서도 재계산해준다.
            Dispatcher.BeginInvoke(new Action(() =>
            {
                this.UpdateLayout();
                UpdateMinWindowWidth();
                this.Width = this.MinWidth;
                UpdateWindowHeight();
            }), System.Windows.Threading.DispatcherPriority.Render);
        }

        private void ApplyFontSize(double size)
        {
            var r = Application.Current.Resources;
            r["AppBaseFontSize"] = (double)size;
            r["AppBaseHeaderFontSize"] = (double)(size + 3);   // 16 기준 +3
            r["AppBaseSmallFontSize"] = (double)Math.Max(8, size - 1);  // 12 기준 -1
            r["AppBaseTinyFontSize"] = (double)Math.Max(7, size - 3);  // 10 기준 -3
            r["AppBaseLargeFontSize"] = (double)(size + 7);   // 20 기준 +7
        }

        private void FontSizeSelector_Changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (_fontSizeUpdating) return;
            var selector = sender as System.Windows.Controls.ComboBox;
            if (selector == null) return;
            var item = selector.SelectedItem as System.Windows.Controls.ComboBoxItem;
            if (item == null) return;
            var size = (double)item.Tag;
            ApplyFontSize(size);
            SaveUiCfg("AppFontSize", size.ToString(System.Globalization.CultureInfo.InvariantCulture));
            // 폰트 크기 변경 후 레이아웃 재계산 완료 후 MinWidth/높이 업데이트.
            // 너비 계산과 높이 계산을 같은 콜백 안에서 순서대로 실행해야 한다 —
            // 따로 예약하면(별도의 Dispatcher.BeginInvoke) 폰트 변경이 실제로 화면에
            // 반영되기 전에 높이를 측정해버려서, 여전히 이전 폰트 크기 기준으로
            // 잘못 계산되는 문제가 있었다.
            Dispatcher.BeginInvoke(new Action(() =>
            {
                this.UpdateLayout();
                UpdateMinWindowWidth();
                this.Width = this.MinWidth;
                UpdateWindowHeight();
            }), System.Windows.Threading.DispatcherPriority.Render);
        }

        // ── Minimum Window Width ─────────────────────────────────────────────
        private void UpdateMinWindowWidth()
        {
            try
            {
                // ProjectListWidthMax/Box 중 가장 오른쪽 끝을 기준으로 창 너비 설정
                double rightEdge = 0;
                var elements = new string[] { "ProjectListWidthMax", "ProjectListWidthBox" };
                foreach (var name in elements)
                {
                    var el = FindName(name) as System.Windows.FrameworkElement;
                    if (el == null) continue;
                    var transform = el.TransformToAncestor(this);
                    var r = transform.Transform(new System.Windows.Point(el.ActualWidth, 0)).X;
                    if (r > rightEdge) rightEdge = r;
                }

                if (rightEdge < 10) return;

                // 우측 여백 48px 포함한 너비가 MinWidth이자 기본 Width
                var targetWidth = Math.Max(800, rightEdge + 48);
                this.MinWidth = targetWidth;
                this.Width = targetWidth;
            }
            catch { }
        }

        // ── Screen Width MAX (해상도 기반, 시작 시 1회 계산) ─────────────────
        public static double ScreenMaxWidth { get; private set; } = 1200;

        private void UpdateWindowHeight()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                // 배경 텍스처 활성 시 TextureLayer1 의 이미지 원본 크기(4K 등)가
                // SizeToContent.Height 측정에 포함되어 창 높이가 비정상적으로 커지는 것 방지
                // → 측정 구간에서만 Collapsed 처리 (Source 는 건드리지 않음)
                // → Dispatcher 콜백 내 동기 처리이므로 화면 깜빡임 없음
                var layer = FindName("TextureLayer1") as System.Windows.Controls.Image;
                bool wasVisible = layer != null && layer.Visibility == Visibility.Visible;
                if (wasVisible) layer.Visibility = Visibility.Collapsed;

                this.UpdateLayout();
                this.SizeToContent = SizeToContent.Height;
                this.SizeToContent = SizeToContent.Manual;

                // "모두 펼치기"로 게임 경로 카드 5개가 한꺼번에 열리는 등, 콘텐츠가
                // 화면보다 커질 수 있다. 이 탭 콘텐츠에는 별도 스크롤 영역이 없어서
                // SizeToContent.Height 로 측정한 값이 그대로 창 높이가 되면, 창이
                // 화면 전체 크기(또는 그 이상)로 커져버리는 문제가 있었다. 작업 표시줄을
                // 제외한 화면 높이를 넘지 않도록 상한선을 둔다.
                var maxHeight = System.Windows.SystemParameters.WorkArea.Height - 40;
                if (this.Height > maxHeight)
                {
                    this.Height = maxHeight;
                }
                if (this.Top < 0)
                {
                    this.Top = 0;
                }

                if (wasVisible) layer.Visibility = Visibility.Visible;
            }), System.Windows.Threading.DispatcherPriority.Render);
        }

        public void NavigateToSettings()
        {
            // Settings 탭 인덱스: Welcome(0), Mods(1), Downloads(2), Development(3), Themes(4), Settings(5)
            Tabs.SelectedIndex = 5;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            // 콘텐츠 렌더링 완료 후 — ActualWidth/ActualHeight 정확히 측정 가능.
            // InitFontSize()에서도 높이 재계산을 시도하지만, 그건 카드들이 화면에
            // 완전히 자리잡기 전(레이아웃 패스 이전)에 실행될 수 있어 너무 작은 값으로
            // 잘못 고정될 위험이 있다. 여기(ContentRendered)는 이미 너비 계산이
            // 안정적으로 동작하고 있는 "확실히 안전한" 시점이므로, 높이도 여기서
            // 한 번 더 확정한다.
            UpdateMinWindowWidth();
            this.Width = this.MinWidth;
            var screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Left = (screenWidth - this.Width) / 2;
            UpdateWindowHeight();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // 창 크기 변경 시에는 별도 처리 없음 (너비는 시작 시 고정)
        }

        private void UpdateListWidthSliderMax()
        {
            // ScreenMaxWidth가 아직 설정되지 않았으면 건너뜀
            var maxVal = ScreenMaxWidth;
            if (maxVal <= 0) return;

            var modSlider = FindName("ModListWidthSlider") as System.Windows.Controls.Slider;
            var projSlider = FindName("ProjectListWidthSlider") as System.Windows.Controls.Slider;
            var maxLabel = FindName("MaxWidthLabel") as System.Windows.Controls.TextBlock;
            var modList = FindName("ModListBox") as System.Windows.Controls.ListBox;
            var projList = FindName("ProjectList") as System.Windows.Controls.ListBox;

            var modMax = FindName("ModListWidthMax") as System.Windows.Controls.TextBlock;
            var projMax = FindName("ProjectListWidthMax") as System.Windows.Controls.TextBlock;

            // 목록 너비 슬라이더의 MAX = ScreenMaxWidth × 30%
            var listMaxVal = Math.Floor(maxVal * 0.3);

            // Maximum 변경 시 Value 클램프 이벤트가 발생하지 않도록 플래그 설정
            _modListWidthUpdating = true;
            _projectListWidthUpdating = true;

            if (modSlider != null) modSlider.Maximum = listMaxVal;
            if (projSlider != null) projSlider.Maximum = listMaxVal;
            if (modList != null) modList.MaxWidth = listMaxVal;
            if (projList != null) projList.MaxWidth = listMaxVal;
            if (maxLabel != null) maxLabel.Text = (int)maxVal + " px";
            if (modMax != null) modMax.Text = (int)listMaxVal + "  ";
            if (projMax != null) projMax.Text = (int)listMaxVal + "  ";

            _modListWidthUpdating = false;
            _projectListWidthUpdating = false;
        }

        // ── UI 초기화 완료 플래그 — 초기화 중 이벤트로 인한 저장 방지 ────────────
        private bool _uiInitialized = false;

        // ── Mod List Width ──────────────────────────────────────────────────
        private bool _modListWidthUpdating = false;
        private double _modListWidth = 220;
        private DispatcherTimer _modListWidthSaveTimer;

        private void InitModListWidth()
        {
            var uiCfgVal = LoadUiCfg("ModListWidth");
            var configVal = Configuration.GetString("ModListWidth", silent: true);
            Debug.Log("InitModListWidth", "ui.cfg=" + (uiCfgVal ?? "null") + " config=" + (configVal ?? "null") + " path=" + GetUiCfgPath());
            var saved = uiCfgVal ?? configVal;
            double defaultWidth = 150; // 저장값 없을 때 슬라이더 최솟값으로 시작
            double width = defaultWidth;
            if (!string.IsNullOrEmpty(saved) && double.TryParse(saved, out double w))
                width = w;
            Debug.Log("InitModListWidth", "Using width=" + width);

            _modListWidthUpdating = true;
            var slider = FindName("ModListWidthSlider") as System.Windows.Controls.Slider;
            var box = FindName("ModListWidthBox") as System.Windows.Controls.TextBox;
            if (slider != null) { slider.Maximum = 7680; slider.Value = width; }
            if (box != null) box.Text = ((int)width).ToString();
            _modListWidthUpdating = false;
            ApplyModListWidth(width);
            Debug.Log("InitModListWidth", "Set slider.Value=" + width);
        }

        private void ApplyModListWidth(double width)
        {
            _modListWidth = width;
            var list = FindName("ModListBox") as System.Windows.Controls.ListBox;
            if (list != null) list.Width = width;
            if (Mods != null) Mods.ModListWidth = width;
        }

        private void ModListWidthSlider_Changed(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (_modListWidthUpdating || !_uiInitialized) return;
            var width = Math.Round(e.NewValue);
            _modListWidthUpdating = true;
            var box = FindName("ModListWidthBox") as System.Windows.Controls.TextBox;
            if (box != null) box.Text = ((int)width).ToString();
            _modListWidthUpdating = false;
            if (ScreenMaxWidth > 0 && width > Math.Floor(ScreenMaxWidth * 0.3)) width = Math.Floor(ScreenMaxWidth * 0.3);
            ApplyModListWidth(width);

            // Debounce: save 500ms after last drag movement
            if (_modListWidthSaveTimer == null)
            {
                _modListWidthSaveTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
                _modListWidthSaveTimer.Tick += (s, ev) =>
                {
                    _modListWidthSaveTimer.Stop();
                    SaveUiCfg("ModListWidth", ((int)_modListWidth).ToString());
                    Debug.Log("ModListWidth", "Saved (debounced): " + ((int)_modListWidth));
                };
            }
            _modListWidthSaveTimer.Stop();
            _modListWidthSaveTimer.Start();
        }

        private void ModListWidthBox_Changed(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (_modListWidthUpdating || !_uiInitialized) return;
            var box = sender as System.Windows.Controls.TextBox;
            if (box == null) return;
            if (!int.TryParse(box.Text, out int val)) return;
            val = (int)Math.Max(150, Math.Min(ScreenMaxWidth > 0 ? Math.Floor(ScreenMaxWidth * 0.3) : 7680, val));
            _modListWidthUpdating = true;
            var slider = FindName("ModListWidthSlider") as System.Windows.Controls.Slider;
            if (slider != null) slider.Value = val;
            _modListWidthUpdating = false;
            ApplyModListWidth(val);
            SaveUiCfg("ModListWidth", val.ToString());
        }

        // ── Project List Width ───────────────────────────────────────────────
        private bool _projectListWidthUpdating = false;
        private double _projectListWidth = 180;
        private DispatcherTimer _projectListWidthSaveTimer;
        public double ProjectListWidth
        {
            get => _projectListWidth;
            set { _projectListWidth = value; }
        }

        private void InitProjectListWidth()
        {
            var saved = LoadUiCfg("ProjectListWidth") ?? Configuration.GetString("ProjectListWidth", silent: true);
            double defaultWidth = 150; // 저장값 없을 때 슬라이더 최솟값으로 시작
            double width = defaultWidth;
            if (!string.IsNullOrEmpty(saved) && double.TryParse(saved, out double w))
                width = w;

            _projectListWidthUpdating = true;
            var slider = FindName("ProjectListWidthSlider") as System.Windows.Controls.Slider;
            var box = FindName("ProjectListWidthBox") as System.Windows.Controls.TextBox;
            // Maximum을 임시로 크게 설정하여 저장값이 잘리지 않도록
            if (slider != null) { slider.Maximum = 7680; slider.Value = width; }
            if (box != null) box.Text = ((int)width).ToString();
            _projectListWidthUpdating = false;
            _projectListWidth = width;
            var list = FindName("ProjectList") as System.Windows.Controls.ListBox;
            if (list != null) list.Width = width;
        }

        private void ProjectListWidthSlider_Changed(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (_projectListWidthUpdating || !_uiInitialized) return;
            var width = Math.Round(e.NewValue);
            _projectListWidthUpdating = true;
            var box = FindName("ProjectListWidthBox") as System.Windows.Controls.TextBox;
            if (box != null) box.Text = ((int)width).ToString();
            _projectListWidthUpdating = false;
            _projectListWidth = width;
            if (ScreenMaxWidth > 0 && width > Math.Floor(ScreenMaxWidth * 0.3)) width = Math.Floor(ScreenMaxWidth * 0.3);
            var list = FindName("ProjectList") as System.Windows.Controls.ListBox;
            if (list != null) list.Width = width;

            // Debounce: save 500ms after last drag movement
            if (_projectListWidthSaveTimer == null)
            {
                _projectListWidthSaveTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
                _projectListWidthSaveTimer.Tick += (s, ev) =>
                {
                    _projectListWidthSaveTimer.Stop();
                    SaveUiCfg("ProjectListWidth", ((int)_projectListWidth).ToString());
                };
            }
            _projectListWidthSaveTimer.Stop();
            _projectListWidthSaveTimer.Start();
        }

        private void ProjectListWidthBox_Changed(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (_projectListWidthUpdating || !_uiInitialized) return;
            var box = sender as System.Windows.Controls.TextBox;
            if (box == null) return;
            if (!int.TryParse(box.Text, out int val)) return;
            val = (int)Math.Max(150, Math.Min(ScreenMaxWidth > 0 ? Math.Floor(ScreenMaxWidth * 0.3) : 7680, val));
            _projectListWidthUpdating = true;
            var slider = FindName("ProjectListWidthSlider") as System.Windows.Controls.Slider;
            if (slider != null) slider.Value = val;
            _projectListWidthUpdating = false;
            _projectListWidth = val;
            SaveUiCfg("ProjectListWidth", val.ToString());
            var list = FindName("ProjectList") as System.Windows.Controls.ListBox;
            if (list != null) list.Width = val;
        }

        private void AlwaysOnTop_Changed(object sender, RoutedEventArgs e)
        {
            var cb = sender as System.Windows.Controls.CheckBox;
            if (cb == null) return;
            var isOn = cb.IsChecked == true;
            this.Topmost = isOn;
            SaveUiCfg("AlwaysOnTop", isOn ? "true" : "false");
        }

        // ── Background Texture ───────────────────────────────────────────────
        private const long TextureMaxInputBytes = 50L * 1024 * 1024; // 50MB 입력 한도 (4K 이미지 허용)
        private const string TextureStoreName = "bg.dat";            // 위장 확장자로 저장
        private const int TextureJpegQuality = 75;                   // JPEG 압축 품질 (0~100)

        // 파일 앞에 삽입하는 커스텀 매직 헤더
        private static readonly byte[] TextureMagic = new byte[]
        {
            0x4D, 0x4F, 0x44, 0x41, 0x50, 0x49,  // "MODAPI"
            0x42, 0x47, 0x00, 0x01, 0x00, 0x00,  // "BG" + version
            0xFF, 0x00, 0xFE, 0x00                // padding noise
        };

        private string _texturePath = "";
        private bool _textureActive = false;

        private string GetTextureStorePath()
        {
            var dir = System.IO.Path.Combine(App.RootPath, "resources", "textures", "ui_bg");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            return System.IO.Path.Combine(dir, TextureStoreName);
        }

        private static string ComputeFileHash(string path)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var hash = sha.ComputeHash(fs);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        private bool VerifyTextureHash(string storePath)
        {
            var savedHash = LoadUiCfg("TextureHash") ?? "";
            if (string.IsNullOrEmpty(savedHash)) return false;
            try
            {
                var actual = ComputeFileHash(storePath);
                return string.Equals(actual, savedHash, StringComparison.OrdinalIgnoreCase);
            }
            catch { return false; }
        }

        private bool HasTextureMagic(byte[] data)
        {
            if (data.Length < TextureMagic.Length) return false;
            for (int i = 0; i < TextureMagic.Length; i++)
                if (data[i] != TextureMagic[i]) return false;
            return true;
        }

        private void InvalidateTexture(string storePath)
        {
            Debug.Log("Texture", "bg.dat tampered or corrupted. Clearing texture.", Debug.Type.Warning);
            try
            {
                if (File.Exists(storePath))
                {
                    File.SetAttributes(storePath, FileAttributes.Normal);
                    File.Delete(storePath);
                }
            }
            catch { }
            _texturePath = "";
            SaveUiCfg("TexturePath", "");
            SaveUiCfg("TextureHash", "");
            SaveUiCfg("TextureActive", "false");
            _textureActive = false;
            Dispatcher.BeginInvoke(new Action(() =>
            {
                var box = FindName("TexturePathBox") as System.Windows.Controls.TextBox;
                if (box != null) box.Text = "";
                SetTextureControlState(false, false);
                RestoreThemeState();
                var win = new Windows.SubWindows.NoProjectWarning("Lang.Windows.TextureTampered");
                win.ShowSubWindow();
                win.Show();
            }));
        }

        // ── 배경 투명화 (두 계층) ──────────────────────────────────────────────
        // 계층 1: MergedDictionaries 오버레이 → {DynamicResource} 참조 패널 자동 투명화
        // 계층 2: 비주얼 트리 순회 → Panel(Grid 제외)/Border 투명화
        //   제외: Grid, ButtonBase, ComboBox (배경 원본 유지)

        private ResourceDictionary _bgOverlay;
        private static readonly string[] TextureBgBrushKeys = new[]
        {
            "FluentBgBrush", "FluentBgSecondaryBrush", "FluentBgTertiaryBrush",
            "FluentSurfaceBrush", "FluentCardBrush", "FluentTabBarBrush",
            "FluentBorderBrush"
        };
        // 반투명화 전 원본 브러시 저장 (element → (brush, usesClearValue))
        // usesClearValue=true: Style/TemplatedParent 출처 → ClearValue 로 복원
        // usesClearValue=false: XAML 로컬값 출처 → 직접 복원
        private readonly Dictionary<DependencyObject,
            Tuple<System.Windows.Media.Brush, bool>> _styleBackgrounds
            = new Dictionary<DependencyObject,
                Tuple<System.Windows.Media.Brush, bool>>();

        // 원본 색상 기반 반투명 브러시 생성
        private static System.Windows.Media.Brush MakeSemiTransparent(
            System.Windows.Media.Brush original, byte alpha = 100)
        {
            var solid = original as System.Windows.Media.SolidColorBrush;
            var c = solid != null ? solid.Color : System.Windows.Media.Colors.Black;
            return new System.Windows.Media.SolidColorBrush(
                System.Windows.Media.Color.FromArgb(alpha, c.R, c.G, c.B));
        }

        // 비주얼 트리 순회 → Panel(Grid 제외)/Border 를 반투명으로 설정
        // 제외: ButtonBase, ComboBox (배경 원본 유지, 내부 순회 중단)
        // Grid 는 배경 유지, 자식은 계속 순회
        private void WalkStyleBackgrounds(Visual visual)
        {
            if (visual is System.Windows.Controls.Primitives.ButtonBase
                || visual is System.Windows.Controls.ComboBox)
                return;

            // 탭 헤더 패널은 완전히 건너뜀 — 탭 버튼 배경 수정 방지
            if (visual is System.Windows.Controls.Primitives.TabPanel)
                return;

            // Collapsed 요소는 건너뜀
            var fe = visual as FrameworkElement;
            if (fe != null && fe.Visibility == Visibility.Collapsed)
                return;

            bool isGrid = visual is System.Windows.Controls.Grid;

            if (!isGrid && visual is System.Windows.Controls.Panel panel)
            {
                var bg = panel.Background;
                if (bg != null
                    && bg != System.Windows.Media.Brushes.Transparent
                    && !_styleBackgrounds.ContainsKey(panel))
                {
                    var src = DependencyPropertyHelper.GetValueSource(
                        panel, System.Windows.Controls.Panel.BackgroundProperty);
                    bool clearVal = src.BaseValueSource == BaseValueSource.Style
                        || src.BaseValueSource == BaseValueSource.DefaultStyle;
                    _styleBackgrounds[panel] = Tuple.Create(bg, clearVal);
                    panel.Background = MakeSemiTransparent(bg);
                }
            }
            else if (visual is Border border)
            {
                var bg = border.Background;
                if (bg != null
                    && bg != System.Windows.Media.Brushes.Transparent
                    && !_styleBackgrounds.ContainsKey(border))
                {
                    var src = DependencyPropertyHelper.GetValueSource(
                        border, Border.BackgroundProperty);
                    bool clearVal = src.BaseValueSource == BaseValueSource.Style
                        || src.BaseValueSource == BaseValueSource.DefaultStyle;
                    _styleBackgrounds[border] = Tuple.Create(bg, clearVal);
                    border.Background = MakeSemiTransparent(bg);
                }
            }
            else if (visual is System.Windows.Controls.ListBox lb)
            {
                // ListView/ListBox 는 Control 이므로 Panel/Border 분기에 걸리지 않음
                // 배경이 있으면 반투명 처리
                var bg = lb.Background;
                if (bg != null
                    && bg != System.Windows.Media.Brushes.Transparent
                    && !_styleBackgrounds.ContainsKey(lb))
                {
                    var src = DependencyPropertyHelper.GetValueSource(
                        lb, System.Windows.Controls.Control.BackgroundProperty);
                    bool clearVal = src.BaseValueSource == BaseValueSource.Style
                        || src.BaseValueSource == BaseValueSource.DefaultStyle;
                    _styleBackgrounds[lb] = Tuple.Create(bg, clearVal);
                    lb.Background = MakeSemiTransparent(bg);
                }
            }

            int count = VisualTreeHelper.GetChildrenCount(visual);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(visual, i) as Visual;
                if (child != null) WalkStyleBackgrounds(child);
            }
        }

        private void SaveAndClearBrushes()
        {
            if (_bgOverlay != null || _styleBackgrounds.Count > 0) return; // 이중 호출 방지

            // 계층 1: DynamicResource 참조 패널 투명화
            _bgOverlay = new ResourceDictionary();
            foreach (var key in TextureBgBrushKeys)
                _bgOverlay[key] = System.Windows.Media.Brushes.Transparent;
            Application.Current.Resources.MergedDictionaries.Add(_bgOverlay);

            // 계층 2: 비주얼 트리 Panel/Border 반투명화 (동기 실행)
            WalkStyleBackgrounds(this);
        }

        private void RestoreBrushes()
        {
            // 계층 1 복원: 오버레이 제거 → DynamicResource 자동 복원
            if (_bgOverlay != null)
            {
                var merged = Application.Current.Resources.MergedDictionaries;
                if (merged.Contains(_bgOverlay))
                    merged.Remove(_bgOverlay);
                _bgOverlay = null;
            }

            // 계층 2 복원
            // ClearValue: Style/TemplatedParent 출처 → Style 트리거 재활성화
            // 직접 복원: XAML 로컬값(StaticResource/DynamicResource) 출처
            foreach (var kv in _styleBackgrounds)
            {
                var useClear = kv.Value.Item2;
                var original = kv.Value.Item1;
                if (kv.Key is System.Windows.Controls.Panel p)
                {
                    if (useClear) p.ClearValue(System.Windows.Controls.Panel.BackgroundProperty);
                    else p.Background = original;
                }
                else if (kv.Key is Border b)
                {
                    if (useClear) b.ClearValue(Border.BackgroundProperty);
                    else b.Background = original;
                }
                else if (kv.Key is System.Windows.Controls.ListBox lb)
                {
                    if (useClear) lb.ClearValue(System.Windows.Controls.Control.BackgroundProperty);
                    else lb.Background = original;
                }
            }
            _styleBackgrounds.Clear();
        }

        private void SetThemeSelectorLock(bool locked)
        {
            var overlay = FindName("ThemeSelectorOverlay") as System.Windows.Controls.Border;
            if (overlay != null)
                overlay.Visibility = locked ? Visibility.Visible : Visibility.Collapsed;
            // Opacity 는 보조 수단으로 유지 (테마에 따라 동작 여부 다름)
            ThemeSelector.Opacity = locked ? 0.4 : 1.0;
        }

        // ThemeSelector Opacity 복원 + 비주얼 트리 배경 복원 + TextureLayer ZIndex 초기화
        private void RestoreThemeState()
        {
            var layer = FindName("TextureLayer1") as System.Windows.Controls.Image;
            if (layer != null)
            {
                layer.Source = null;
                layer.Opacity = 0.13;
                layer.Visibility = Visibility.Collapsed;
            }
            RestoreBrushes();
            var themeSelector = FindName("ThemeSelector") as System.Windows.Controls.ComboBox;
            SetThemeSelectorLock(false);
        }

        // Toggle + ClearBtn 활성/비활성 일괄 처리
        private void SetTextureControlState(bool hasFile, bool isActive)
        {
            var toggle = FindName("TextureActiveCheckBox") as System.Windows.Controls.CheckBox;
            var clearBtn = FindName("TextureClearBtn") as System.Windows.Controls.Button;
            if (toggle != null)
            {
                toggle.IsEnabled = hasFile;
                if (!hasFile) toggle.IsChecked = false;
            }
            if (clearBtn != null) clearBtn.IsEnabled = hasFile;
        }

        private void InitTexture()
        {
            _texturePath = LoadUiCfg("TexturePath") ?? "";
            _textureActive = (LoadUiCfg("TextureActive") ?? "false").ToLower() == "true";

            var box = FindName("TexturePathBox") as System.Windows.Controls.TextBox;
            if (box != null) box.Text = _texturePath;

            // bg.dat 존재 여부로 토글/ClearBtn 잠금 결정
            var storePath = GetTextureStorePath();
            bool hasValidFile = File.Exists(storePath);
            if (!hasValidFile) _textureActive = false;
            SetTextureControlState(hasValidFile, _textureActive);
            var toggle = FindName("TextureActiveCheckBox") as System.Windows.Controls.CheckBox;
            if (toggle != null) toggle.IsChecked = hasValidFile && _textureActive;

            // ContextIdle 이후 실행 — 모든 테마 Style·ControlTemplate 완전 적용 후 투명화 처리
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Tabs.SelectionChanged += OnTabsSelectionChangedForTexture;
                ApplyTexture();
                SetThemeSelectorLock(_textureActive);

                // 초기 탭 콘텐츠 재처리 — ContextIdle 시점에 미처리된 요소 보완
                // ApplicationIdle 은 ContextIdle 보다 낮은 우선순위 → 렌더링 완전 완료 후 실행
                if (_textureActive)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        WalkStyleBackgrounds(this);
                    }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
                }
            }), System.Windows.Threading.DispatcherPriority.ContextIdle);
        }

        // 탭 전환 시 새로 로드된 탭 콘텐츠를 투명화 처리
        private void OnTabsSelectionChangedForTexture(object sender, SelectionChangedEventArgs e)
        {
            if (!_textureActive) return;

            // ContextIdle: 모든 렌더링·템플릿 적용 완료 후 실행
            // Loaded 우선순위는 ControlTemplate 내부 요소가 아직 비주얼 트리에 없는 경우 있음
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (!_textureActive) return;
                WalkStyleBackgrounds(this);
            }), System.Windows.Threading.DispatcherPriority.ContextIdle);
        }

        private void ApplyTexture()
        {
            var layer = FindName("TextureLayer1") as System.Windows.Controls.Image;
            if (layer == null) return;

            var storePath = GetTextureStorePath();

            if (_textureActive && File.Exists(storePath))
            {
                // 무결성 검증
                if (!VerifyTextureHash(storePath))
                {
                    InvalidateTexture(storePath);
                    return;
                }

                var raw = File.ReadAllBytes(storePath);

                // 매직 헤더 검증
                if (!HasTextureMagic(raw))
                {
                    InvalidateTexture(storePath);
                    return;
                }

                try
                {
                    var jpegData = new byte[raw.Length - TextureMagic.Length];
                    Array.Copy(raw, TextureMagic.Length, jpegData, 0, jpegData.Length);

                    var bmp = new System.Windows.Media.Imaging.BitmapImage();
                    bmp.BeginInit();
                    bmp.StreamSource = new System.IO.MemoryStream(jpegData);
                    bmp.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                    bmp.EndInit();
                    bmp.Freeze();

                    layer.Source = bmp;
                    layer.Opacity = 1.0;
                    layer.Visibility = Visibility.Visible;

                    SaveAndClearBrushes();
                }
                catch (Exception ex)
                {
                    Debug.Log("Texture", "ApplyTexture failed: " + ex.Message, Debug.Type.Warning);
                    layer.Source = null;
                    layer.Opacity = 0.13;
                    layer.Visibility = Visibility.Collapsed;
                    RestoreBrushes();
                }

                // ThemeSelector Opacity — Render 이후 지연 설정
                // WalkStyleBackgrounds 실행 후 WPF Style 재적용으로 Opacity 가 1.0 으로 초기화되는 것 방지
                SetThemeSelectorLock(_textureActive);
            }
            else
            {
                layer.Source = null;
                layer.Opacity = 0.13;
                layer.Visibility = Visibility.Collapsed;
                RestoreThemeState();
            }
        }

        private void TextureBrowse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg",
                Title = "Select Texture Image",
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() != true) return;

            var info = new FileInfo(dialog.FileName);
            if (info.Length > TextureMaxInputBytes)
            {
                var win = new Windows.SubWindows.NoProjectWarning("Lang.Windows.TextureTooLarge");
                win.ShowSubWindow();
                win.Show();
                return;
            }

            try
            {
                var src = new System.Windows.Media.Imaging.BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(dialog.FileName, UriKind.Absolute);
                src.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                src.EndInit();
                src.Freeze();

                var encoder = new System.Windows.Media.Imaging.JpegBitmapEncoder
                {
                    QualityLevel = TextureJpegQuality
                };
                encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(src));

                byte[] jpegBytes;
                using (var ms = new System.IO.MemoryStream())
                {
                    encoder.Save(ms);
                    jpegBytes = ms.ToArray();
                }

                var storePath = GetTextureStorePath();

                // Hidden 속성이 있으면 덮어쓰기 전에 Normal로 초기화 (Hidden 파일 덮어쓰기 거부 방지)
                if (File.Exists(storePath))
                    File.SetAttributes(storePath, FileAttributes.Normal);

                using (var fs = new FileStream(storePath, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(TextureMagic, 0, TextureMagic.Length);
                    fs.Write(jpegBytes, 0, jpegBytes.Length);
                }

                // 저장 완료 후 Hidden 재적용
                File.SetAttributes(storePath, FileAttributes.Hidden);

                var hash = ComputeFileHash(storePath);
                SaveUiCfg("TextureHash", hash);

                _texturePath = System.IO.Path.GetFileName(dialog.FileName);
                var box = FindName("TexturePathBox") as System.Windows.Controls.TextBox;
                if (box != null) box.Text = _texturePath;
                SaveUiCfg("TexturePath", _texturePath);

                // 이미지 선택 완료 → 토글 잠금 해제 + 자동 활성화
                _textureActive = true;
                SaveUiCfg("TextureActive", "true");
                SetTextureControlState(true, true);

                // 토글 체크 상태 UI 반영
                var toggle = FindName("TextureActiveCheckBox") as System.Windows.Controls.CheckBox;
                // 토글 이벤트 억제 후 IsChecked 설정 — TextureActive_Changed 이중 발화 방지
                if (toggle != null)
                {
                    toggle.Checked -= TextureActive_Changed;
                    toggle.IsChecked = true;
                    toggle.Checked += TextureActive_Changed;
                }

                ApplyTexture();
            }
            catch (Exception ex)
            {
                SetTextureControlState(false, false);
                Debug.Log("Texture", "Failed to load/compress image: " + ex.Message, Debug.Type.Warning);
            }
        }

        private void TextureClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var storePath = GetTextureStorePath();
                if (File.Exists(storePath))
                {
                    // Hidden 파일은 삭제 전 Normal로 초기화
                    File.SetAttributes(storePath, FileAttributes.Normal);
                    File.Delete(storePath);
                }
            }
            catch { }

            _texturePath = "";
            _textureActive = false;
            var box = FindName("TexturePathBox") as System.Windows.Controls.TextBox;
            if (box != null) box.Text = "";
            SaveUiCfg("TexturePath", "");
            SaveUiCfg("TextureHash", "");
            SaveUiCfg("TextureActive", "false");

            SetTextureControlState(false, false);
            RestoreThemeState();

            // Window.Background 해제 → GC 가 이전 ImageBrush 수집
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }

        private void TextureActive_Changed(object sender, RoutedEventArgs e)
        {
            var cb = sender as System.Windows.Controls.CheckBox;
            if (cb == null) return;
            _textureActive = cb.IsChecked == true;
            SaveUiCfg("TextureActive", _textureActive ? "true" : "false");
            ApplyTexture();

            // ApplyTexture 내부 Dispatcher 지연보다 늦게 실행되도록 확실히 보장
            SetThemeSelectorLock(_textureActive);
        }

        private void ExpandAll_Click(object sender, RoutedEventArgs e)
        {
            _allExpanded = !_allExpanded;
            var btn = FindName("ExpandAllBtn") as Button;
            foreach (var content in _gameCardContents)
            {
                content.Visibility = _allExpanded ? Visibility.Visible : Visibility.Collapsed;
            }
            UpdateWindowHeight();
            // 화살표도 갱신
            var panel = FindName("GamePathsPanel") as StackPanel;
            if (panel != null)
            {
                foreach (var card in panel.Children.OfType<Border>())
                {
                    var stack = card.Child as StackPanel;
                    if (stack == null) continue;
                    var header = stack.Children.OfType<Grid>().FirstOrDefault();
                    if (header == null) continue;
                    var arrowTb = header.Children.OfType<TextBlock>().FirstOrDefault();
                    if (arrowTb != null) arrowTb.Text = _allExpanded ? "▼" : "▶";
                }
            }
            // 버튼 텍스트 전환
            if (btn != null)
            {
                var tb = (btn.Content as TextBlock);
                if (tb != null)
                    tb.SetResourceReference(TextBlock.TextProperty, _allExpanded
                        ? "Lang.Options.Labels.CollapseAll"
                        : "Lang.Options.Labels.ExpandAll");
            }
        }


        private static readonly Dictionary<string, string> ModGameLangKeyMap = new Dictionary<string, string>
        {
            { "TheForest",                "Lang.Downloads.Game.TheForest" },
            { "TheForestDedicatedServer", "Lang.Downloads.Game.DedicatedServer" },
            { "TheForestVR",              "Lang.Downloads.Game.VR" },
            { "Subnautica",               "Lang.Downloads.Game.Subnautica" },
            { "Raft",                     "Lang.Downloads.Game.Raft" },
            { "EscapeThePacific",         "Lang.Downloads.Game.EscapeThePacific" },
            { "GH",                       "Lang.Downloads.Game.GreenHell" },
        };

        // 지원 게임 고정 순서 (SonsOfTheForest는 IL2CPP이므로 제외)
        private static readonly List<string> SupportedGameIds = new List<string>
        {
            "All",
            "TheForest",
            "TheForestDedicatedServer",
            "TheForestVR",
            "Subnautica",
            "Raft",
            "EscapeThePacific",
            "GH",
        };

        private void BuildModGameFilter()
        {
            ModGameFilterPanel.Children.Clear();

            foreach (var gameId in SupportedGameIds)
            {
                string langKey = null;
                if (gameId == "All")
                    langKey = "Lang.Downloads.Game.All";
                else
                    ModGameLangKeyMap.TryGetValue(gameId, out langKey);

                var rb = new RadioButton
                {
                    GroupName = "ModGameFilter",
                    IsChecked = gameId == "All",
                    Margin = new Thickness(0, 2, 0, 2),
                    FontSize = 12
                };
                rb.SetResourceReference(RadioButton.ForegroundProperty, "FluentTextPrimaryBrush");
                rb.SetResourceReference(RadioButton.FontFamilyProperty, "NormalFont");

                if (langKey != null)
                    rb.SetResourceReference(RadioButton.ContentProperty, langKey);
                else
                    rb.Content = gameId;

                var capturedId = gameId;
                rb.Checked += (s, e) => { if (Mods != null) Mods.SelectedGameFilter = capturedId; };
                ModGameFilterPanel.Children.Add(rb);
            }
        }

        // 게임 ID → 표시명 매핑 (팝업 메시지용)
        private static readonly Dictionary<string, string> GameDisplayNames =
            new Dictionary<string, string>
            {
                { "TheForest",        "The Forest" },
                { "Subnautica",       "Subnautica" },
                { "Raft",             "Raft" },
                { "EscapeThePacific", "Escape The Pacific" },
                { "GH",               "Green Hell" },
            };

        /// <summary>
        /// ModGameFilterPanel 의 라디오버튼을 지정한 gameId 로 동기화합니다.
        /// StartGame 에서 All → 특정 게임으로 전환 시 UI 반영을 위해 호출합니다.
        /// </summary>
        private void SyncModGameFilterRadioButton(string gameId)
        {
            if (ModGameFilterPanel == null) return;
            foreach (var child in ModGameFilterPanel.Children)
            {
                var rb = child as RadioButton;
                if (rb == null) continue;

                // Tag 대신 Checked 이벤트에서 사용하는 capturedId 와 비교하기 위해
                // RadioButton.Content 또는 Tag 를 활용 — 여기서는 Content 의 리소스키가 아닌
                // DataContext 가 없으므로 Panel 내 인덱스 순서로 SupportedGameIds 와 매핑
                var idx = ModGameFilterPanel.Children.IndexOf(rb);
                if (idx >= 0 && idx < SupportedGameIds.Count)
                {
                    // 이벤트 중복 방지: Checked 이벤트가 다시 SelectedGameFilter 를 바꾸지 않도록
                    // 이미 올바른 값이면 스킵
                    var isTarget = string.Equals(
                        SupportedGameIds[idx], gameId, StringComparison.OrdinalIgnoreCase);
                    if (isTarget && rb.IsChecked != true)
                    {
                        rb.IsChecked = true;
                        break;
                    }
                }
            }
        }

        private void GameFilter_Checked(object sender, RoutedEventArgs e)
        {
            var rb = sender as System.Windows.Controls.RadioButton;
            if (rb == null) return;

            string game;
            if (!GameMap.TryGetValue(rb.Name, out game))
                game = "All";

            _selectedGame = game;
            if (_allMods.Count > 0)
                ApplyModFilter();
        }

        private List<ModInfo> SortModList(List<ModInfo> list)
        {
            switch (_sortProperty)
            {
                case "Name":
                    return _sortAscending ? list.OrderBy(m => m.Name).ToList() : list.OrderByDescending(m => m.Name).ToList();
                case "Author":
                    return _sortAscending ? list.OrderBy(m => m.Author).ToList() : list.OrderByDescending(m => m.Author).ToList();
                case "Category":
                    return _sortAscending ? list.OrderBy(m => m.Category).ToList() : list.OrderByDescending(m => m.Category).ToList();
                case "Game":
                    return _sortAscending ? list.OrderBy(m => m.Game).ToList() : list.OrderByDescending(m => m.Game).ToList();
                case "DownloadCount":
                    return _sortAscending
                        ? list.OrderBy(m => ParseDownloadCount(m.DownloadCount)).ToList()
                        : list.OrderByDescending(m => ParseDownloadCount(m.DownloadCount)).ToList();
                default:
                    return list;
            }
        }

        private int ParseDownloadCount(string count)
        {
            if (string.IsNullOrEmpty(count)) return 0;
            var cleaned = count.Replace(",", "").Replace(".", "").Trim();
            int result;
            return int.TryParse(cleaned, out result) ? result : 0;
        }

        private GridViewColumnHeader _lastSortHeader = null;

        private void DownloadModList_HeaderClick(object sender, RoutedEventArgs e)
        {
            var header = e.OriginalSource as GridViewColumnHeader;
            if (header == null || header.Role == GridViewColumnHeaderRole.Padding) return;

            var column = header.Column;
            if (column == null) return;

            var binding = column.DisplayMemberBinding as System.Windows.Data.Binding;
            if (binding == null) return;

            var property = binding.Path.Path;

            // Remove arrow from previous header
            if (_lastSortHeader != null && _lastSortHeader.Column != null)
            {
                var prevText = _lastSortHeader.Column.Header as string ?? "";
                prevText = prevText.Replace(" ▲", "").Replace(" ▼", "");
                _lastSortHeader.Column.Header = prevText;
            }

            if (_sortProperty == property)
            {
                _sortAscending = !_sortAscending;
            }
            else
            {
                _sortProperty = property;
                _sortAscending = true;
            }

            // Add arrow to current header
            var headerText = column.Header as string ?? column.Header?.ToString() ?? "";
            headerText = headerText.Replace(" ▲", "").Replace(" ▼", "");
            column.Header = headerText + (_sortAscending ? " ▲" : " ▼");
            _lastSortHeader = header;

            ApplyModFilter();
        }

        private void DownloadSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DownloadSearchPlaceholder != null)
                DownloadSearchPlaceholder.Visibility = string.IsNullOrEmpty(DownloadSearchBox.Text) ? Visibility.Visible : Visibility.Collapsed;
            if (_allMods.Count > 0)
                ApplyModFilter();
        }

        private void DownloadRefresh_Click(object sender, RoutedEventArgs e)
        {
            DownloadRefreshButton.IsEnabled = false;
            DownloadStatusText.Text = FindResource("Lang.Downloads.Status.Loading") as string;

            var thread = new Thread(() =>
            {
                var online = CheckInternetConnection();
                if (online)
                {
                    var sourceLabels = new[]
                    {
                        "The Forest", "Dedicated Server", "VR", "Subnautica",
                        "RAFT", "Escape The Pacific", "Green Hell", "SOTF"
                    };
                    var inProgress = "  " + (FindResource("Lang.Downloads.Status.InProgress") as string ?? "진행중");
                    var sourceIndex = 0;
                    var currentPercent = 0;
                    LoadModsFromWeb(targetPercent =>
                    {
                        var label = sourceIndex < sourceLabels.Length ? sourceLabels[sourceIndex] : "";
                        sourceIndex++;
                        // 현재값에서 목표값까지 1씩 카운트
                        while (currentPercent < targetPercent)
                        {
                            currentPercent++;
                            var p = currentPercent;
                            var l = label;
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                DownloadStatusText.Text = string.Format("  {0}%  ←  {1} {2}", p, l, inProgress);
                            }));
                            System.Threading.Thread.Sleep(15);
                        }
                    });
                }

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    UpdateDownloadPanelVisibility(online);
                    DownloadRefreshButton.IsEnabled = true;
                    if (online)
                    {
                        ApplyModFilter();
                    }
                }));
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void DownloadRetryConnection_Click(object sender, RoutedEventArgs e)
        {
            DownloadRefresh_Click(sender, e);
        }

        private ModInfo _selectedMod;
        private List<ModVersionInfo> _currentVersions = new List<ModVersionInfo>();

        private void DownloadModList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mod = DownloadModList.SelectedItem as ModInfo;
            if (mod == null)
            {
                DownloadVersionPanel.Visibility = Visibility.Collapsed;
                DownloadVersionPlaceholder.Visibility = Visibility.Visible;
                DownloadButton.IsEnabled = false;
                return;
            }

            _selectedMod = mod;
            DownloadButton.IsEnabled = false;
            DownloadVersionPanel.Visibility = Visibility.Collapsed;
            DownloadVersionPlaceholder.Visibility = Visibility.Visible;
            DownloadStatusText.Text = FindResource("Lang.Downloads.Status.Loading") as string;

            var thread = new Thread(() =>
            {
                var url = "https://modapi.survivetheforest.net/mod/" + mod.ModId + "/" + mod.Slug;
                var html = FetchHtml(url);
                var htmlLen = html != null ? html.Length : 0;
                var versions = ParseVersionsFromHtml(html);

                // Debug: count using IndexOf (no Regex on large HTML)
                int btnCount = 0, verCount = 0, dlLinkCount = 0;
                if (html != null)
                {
                    int p = 0;
                    while ((p = html.IndexOf("create-mod-single", p)) >= 0) { btnCount++; p += 17; }
                    p = 0;
                    while ((p = html.IndexOf("Version ", p)) >= 0) { verCount++; p += 8; }
                    p = 0;
                    while ((p = html.IndexOf("/download/mod/", p)) >= 0) { dlLinkCount++; p += 14; }
                }

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    _currentVersions = versions;
                    DownloadVersionTitle.Text = mod.Name;
                    DownloadVersionList.Items.Clear();

                    foreach (var v in versions)
                    {
                        DownloadVersionList.Items.Add(v);
                    }

                    if (versions.Count > 0)
                    {
                        DownloadVersionPlaceholder.Visibility = Visibility.Collapsed;
                        DownloadVersionPanel.Visibility = Visibility.Visible;
                        DownloadStatusText.Text = string.Format("  {0} versions", versions.Count);
                    }
                    else
                    {
                        DownloadStatusText.Text = FindResource("Lang.Downloads.Status.NoDownloads") as string ?? "No downloads available.";
                    }
                    DownloadButton.IsEnabled = false;
                }));
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void DownloadInfo_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedMod == null) return;
            var url = "https://modapi.survivetheforest.net/mod/" + _selectedMod.ModId + "/" + _selectedMod.Slug;
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void DownloadVersionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DownloadButton.IsEnabled = DownloadVersionList.SelectedItem != null;
        }

        private void DownloadMod_Click(object sender, RoutedEventArgs e)
        {
            var selectedVersion = DownloadVersionList.SelectedItem as ModVersionInfo;
            if (selectedVersion == null) return;

            DownloadButton.IsEnabled = false;
            DownloadStatusText.Text = "  " + (FindResource("Lang.Downloads.Status.Downloading") as string ?? "Downloading...");

            var thread = new Thread(() =>
            {
                try
                {
                    // _selectedMod.GameId 우선 사용 — data-game 파싱 실패 시 올바른 폴더에 저장
                    var gameShortName = (!string.IsNullOrEmpty(_selectedMod?.GameId))
                        ? _selectedMod.GameId
                        : selectedVersion.GameShortName;
                    var success = DownloadModFile(selectedVersion.ModId, selectedVersion.FileId, gameShortName);
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            DownloadButton.IsEnabled = true;
                            DownloadStatusText.Text = success
                                ? "  " + (FindResource("Lang.Downloads.Status.Complete") as string ?? "Download complete!")
                                : "  " + (FindResource("Lang.Downloads.Status.Error") as string ?? "Error occurred.");
                        }
                        catch { }
                    }));
                }
                catch
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            DownloadButton.IsEnabled = true;
                            DownloadStatusText.Text = "  " + (FindResource("Lang.Downloads.Status.Error") as string ?? "Error occurred.");
                        }
                        catch { }
                    }));
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private List<ModVersionInfo> ParseVersionsFromHtml(string html)
        {
            var versions = new List<ModVersionInfo>();
            if (string.IsNullOrEmpty(html)) return versions;

            // Step 1: Find all download buttons using IndexOf
            var btnList = new List<Dictionary<string, string>>();
            int searchPos = 0;
            while (true)
            {
                int btnIdx = html.IndexOf("create-mod-single", searchPos);
                if (btnIdx < 0) break;

                int tagEnd = html.IndexOf('>', btnIdx);
                if (tagEnd < 0) break;

                var tag = html.Substring(btnIdx, tagEnd - btnIdx);
                var modid = ExtractAttribute(tag, "data-modid");
                var fileid = ExtractAttribute(tag, "data-fileid");
                var game = ExtractAttribute(tag, "data-game");

                if (modid != null && fileid != null && game != null)
                {
                    btnList.Add(new Dictionary<string, string>
                    {
                        { "modid", modid },
                        { "fileid", fileid },
                        { "game", game }
                    });
                }
                searchPos = tagEnd + 1;
            }

            // Step 2: Find all version blocks using IndexOf
            var verList = new List<Dictionary<string, string>>();
            searchPos = 0;
            while (true)
            {
                int verIdx = html.IndexOf("Version ", searchPos);
                if (verIdx < 0) break;

                // Extract chunk (max 500 chars from this point)
                int chunkEnd = Math.Min(verIdx + 500, html.Length);
                var chunk = html.Substring(verIdx, chunkEnd - verIdx);

                // Parse: "Version 1.0.0.5 (1.11b)"
                int spaceAfterVer = chunk.IndexOf(' ');
                if (spaceAfterVer < 0) { searchPos = verIdx + 8; continue; }

                int parenOpen = chunk.IndexOf('(', spaceAfterVer);
                if (parenOpen < 0) { searchPos = verIdx + 8; continue; }

                int parenClose = chunk.IndexOf(')', parenOpen);
                if (parenClose < 0) { searchPos = verIdx + 8; continue; }

                var version = chunk.Substring(spaceAfterVer + 1, parenOpen - spaceAfterVer - 1).Trim();
                var compatible = chunk.Substring(parenOpen + 1, parenClose - parenOpen - 1).Trim();

                // Validate version format (must start with digit)
                if (version.Length == 0 || !char.IsDigit(version[0]))
                {
                    searchPos = verIdx + 8;
                    continue;
                }

                // Parse date: "12. Feb 2021" pattern - find "dd. Mmm yyyy"
                var date = ExtractDate(chunk, parenClose);

                // Parse size: "2.69 kB" or "467.17 kB"
                var size = ExtractSize(chunk, parenClose);

                // Parse download count: "238,681 downloads"
                var downloads = ExtractDownloadCount(chunk, parenClose);

                verList.Add(new Dictionary<string, string>
                {
                    { "version", version },
                    { "compatible", compatible },
                    { "date", date },
                    { "size", size },
                    { "downloads", downloads }
                });

                searchPos = verIdx + 8;
            }

            // Step 3: Combine buttons with version info
            int count = Math.Min(btnList.Count, verList.Count);
            for (int i = 0; i < count; i++)
            {
                versions.Add(new ModVersionInfo
                {
                    Version = verList[i]["version"],
                    Compatible = verList[i]["compatible"],
                    Date = verList[i]["date"],
                    Size = verList[i]["size"],
                    Downloads = verList[i]["downloads"],
                    ModId = int.Parse(btnList[i]["modid"]),
                    FileId = int.Parse(btnList[i]["fileid"]),
                    GameShortName = btnList[i]["game"]
                });
            }

            // Step 4: Fallback - if no buttons but versions found, try download links
            if (btnList.Count == 0 && verList.Count > 0)
            {
                var dlLinks = new List<string[]>();
                int dlPos = 0;
                while (true)
                {
                    int dlIdx = html.IndexOf("/download/mod/", dlPos);
                    if (dlIdx < 0) break;

                    int pathStart = dlIdx + "/download/mod/".Length;
                    int pathEnd = html.IndexOf('"', pathStart);
                    if (pathEnd < 0) pathEnd = html.IndexOf('\'', pathStart);
                    if (pathEnd < 0) { dlPos = pathStart; continue; }

                    var path = html.Substring(pathStart, pathEnd - pathStart);
                    var parts = path.Split('/');
                    if (parts.Length >= 2)
                    {
                        dlLinks.Add(new[] { parts[0], parts[1] });
                    }
                    dlPos = pathEnd + 1;
                }

                var gameAttr = ExtractFirstAttribute(html, "data-game");
                var gameName = gameAttr ?? "TheForest";

                int linkCount = Math.Min(dlLinks.Count, verList.Count);
                for (int i = 0; i < linkCount; i++)
                {
                    versions.Add(new ModVersionInfo
                    {
                        Version = verList[i]["version"],
                        Compatible = verList[i]["compatible"],
                        Date = verList[i]["date"],
                        Size = verList[i]["size"],
                        Downloads = verList[i]["downloads"],
                        ModId = int.Parse(dlLinks[i][0]),
                        FileId = int.Parse(dlLinks[i][1]),
                        GameShortName = gameName
                    });
                }
            }

            return versions;
        }

        private string ExtractAttribute(string tag, string attrName)
        {
            var search = attrName + "=\"";
            int idx = tag.IndexOf(search);
            if (idx < 0) return null;
            int valStart = idx + search.Length;
            int valEnd = tag.IndexOf('"', valStart);
            if (valEnd < 0) return null;
            return tag.Substring(valStart, valEnd - valStart);
        }

        private string ExtractFirstAttribute(string html, string attrName)
        {
            var search = attrName + "=\"";
            int idx = html.IndexOf(search);
            if (idx < 0) return null;
            int valStart = idx + search.Length;
            int valEnd = html.IndexOf('"', valStart);
            if (valEnd < 0) return null;
            return html.Substring(valStart, valEnd - valStart);
        }

        private string ExtractDate(string chunk, int startAfter)
        {
            // Look for pattern: dd. Mmm yyyy
            for (int i = startAfter; i < chunk.Length - 14; i++)
            {
                if (char.IsDigit(chunk[i]) && i + 1 < chunk.Length && char.IsDigit(chunk[i + 1])
                    && chunk[i + 2] == '.')
                {
                    // Found "dd." - look for month and year
                    int spaceIdx = i + 3;
                    while (spaceIdx < chunk.Length && chunk[spaceIdx] == ' ') spaceIdx++;

                    // Check for month name (3+ letters)
                    int monthStart = spaceIdx;
                    int monthEnd = monthStart;
                    while (monthEnd < chunk.Length && char.IsLetter(chunk[monthEnd])) monthEnd++;

                    if (monthEnd - monthStart >= 3)
                    {
                        int yearStart = monthEnd;
                        while (yearStart < chunk.Length && !char.IsDigit(chunk[yearStart])) yearStart++;

                        if (yearStart + 4 <= chunk.Length && char.IsDigit(chunk[yearStart])
                            && char.IsDigit(chunk[yearStart + 1]) && char.IsDigit(chunk[yearStart + 2])
                            && char.IsDigit(chunk[yearStart + 3]))
                        {
                            return chunk.Substring(i, yearStart + 4 - i).Trim();
                        }
                    }
                }
            }
            return "";
        }

        private string ExtractSize(string chunk, int startAfter)
        {
            // Look for pattern: number followed by kB, MB, B
            var lower = chunk.ToLower();
            foreach (var suffix in new[] { " kb", " mb", " b" })
            {
                int idx = lower.IndexOf(suffix, startAfter);
                if (idx > 0)
                {
                    // Walk back to find the number start
                    int numEnd = idx;
                    int numStart = idx - 1;
                    while (numStart >= startAfter && (char.IsDigit(chunk[numStart]) || chunk[numStart] == '.'))
                        numStart--;
                    numStart++;

                    if (numStart < numEnd)
                    {
                        return chunk.Substring(numStart, idx + suffix.Length - numStart).Trim();
                    }
                }
            }
            return "";
        }

        private string ExtractDownloadCount(string chunk, int startAfter)
        {
            var lower = chunk.ToLower();
            int idx = lower.IndexOf("downloads", startAfter);
            if (idx < 0) idx = lower.IndexOf("download", startAfter);
            if (idx < 0) return "0";

            // Walk back past spaces
            int numEnd = idx - 1;
            while (numEnd >= startAfter && chunk[numEnd] == ' ') numEnd--;

            // Walk back through digits and commas
            int numStart = numEnd;
            while (numStart >= startAfter && (char.IsDigit(chunk[numStart]) || chunk[numStart] == ','))
                numStart--;
            numStart++;

            if (numStart <= numEnd)
            {
                return chunk.Substring(numStart, numEnd - numStart + 1);
            }
            return "0";
        }

        private bool DownloadModFile(int modId, int fileId, string gameShortName)
        {
            try
            {
                var url = "https://modapi.survivetheforest.net/download/mod/" + modId + "/" + fileId;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "ModAPI/2.0";
                request.AllowAutoRedirect = true;
                request.Timeout = 30000;

                using (var response = (HttpWebResponse)request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    var fileName = "";
                    var disposition = response.Headers["Content-Disposition"];
                    if (!string.IsNullOrEmpty(disposition))
                    {
                        // Try filename*=UTF-8'' format first
                        int starIdx = disposition.IndexOf("filename*=");
                        if (starIdx >= 0)
                        {
                            int tickIdx = disposition.IndexOf("''", starIdx);
                            if (tickIdx >= 0)
                            {
                                int valStart = tickIdx + 2;
                                int valEnd = disposition.IndexOf(';', valStart);
                                if (valEnd < 0) valEnd = disposition.Length;
                                try { fileName = Uri.UnescapeDataString(disposition.Substring(valStart, valEnd - valStart).Trim()); } catch { }
                            }
                        }

                        // Try filename="..." or filename=... format
                        if (string.IsNullOrEmpty(fileName))
                        {
                            int fnIdx = disposition.IndexOf("filename=");
                            if (fnIdx >= 0)
                            {
                                int valStart = fnIdx + "filename=".Length;
                                if (valStart < disposition.Length && disposition[valStart] == '"')
                                {
                                    valStart++;
                                    int valEnd = disposition.IndexOf('"', valStart);
                                    if (valEnd > valStart)
                                        fileName = disposition.Substring(valStart, valEnd - valStart);
                                }
                                else
                                {
                                    int valEnd = disposition.IndexOf(';', valStart);
                                    if (valEnd < 0) valEnd = disposition.Length;
                                    fileName = disposition.Substring(valStart, valEnd - valStart).Trim();
                                }
                            }
                        }

                        // URL decode if needed
                        if (!string.IsNullOrEmpty(fileName) && fileName.Contains("%"))
                        {
                            try { fileName = Uri.UnescapeDataString(fileName); } catch { }
                        }
                    }

                    if (string.IsNullOrEmpty(fileName))
                    {
                        var uriPath = response.ResponseUri.AbsolutePath;
                        int lastSlash = uriPath.LastIndexOf('/');
                        if (lastSlash >= 0 && lastSlash + 1 < uriPath.Length)
                        {
                            fileName = uriPath.Substring(lastSlash + 1);
                            try { fileName = Uri.UnescapeDataString(fileName); } catch { }
                        }
                    }

                    // Remove invalid filename characters
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        foreach (var c in Path.GetInvalidFileNameChars())
                        {
                            fileName = fileName.Replace(c.ToString(), "");
                        }
                    }

                    if (string.IsNullOrEmpty(fileName) || !fileName.EndsWith(".mod"))
                    {
                        fileName = "mod_" + modId + "_" + fileId + ".mod";
                    }

                    // Determine target folder
                    // SonsOfTheForest는 IL2CPP 빌드이므로 ModAPI로 적용 불가
                    // mods\ 대신 downloads\ 에 저장하여 모드 목록 자동 로딩에서 제외
                    var isIl2Cpp = string.Equals(gameShortName, "SonsOfTheForest", StringComparison.OrdinalIgnoreCase);
                    var modsDir = isIl2Cpp
                        ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "downloads", gameShortName)
                        : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mods", gameShortName);
                    if (!Directory.Exists(modsDir))
                        Directory.CreateDirectory(modsDir);

                    var filePath = Path.Combine(modsDir, fileName);
                    var tempPath = filePath + ".downloading";

                    using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
                    {
                        var buffer = new byte[8192];
                        int bytesRead;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                    }

                    // Verify downloaded file is not empty
                    var tempFileInfo = new FileInfo(tempPath);
                    if (tempFileInfo.Length == 0)
                    {
                        Debug.Log("Downloads", "Downloaded file is empty (0 bytes): " + fileName, Debug.Type.Warning);
                        try { File.Delete(tempPath); } catch { }
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            var win = new Windows.SubWindows.NoProjectWarning("Lang.Windows.DownloadEmpty");
                            win.ShowSubWindow();
                            win.Show();
                        }));
                        return false;
                    }

                    // Rename temp file to final name (atomic for FindMods timer)
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                    File.Move(tempPath, filePath);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.Log("Downloads", "Download failed: " + ex.Message, Debug.Type.Error);
                return false;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Environment.Exit(0);
        }

    }
}