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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ModAPI;
using ModAPI.Configurations;
using ModAPI.Data;
using ModAPI.Utils;
using Path = System.IO.Path;

public class ModsViewModel : INotifyPropertyChanged
{
    protected DispatcherTimer Timer;
    protected bool _SelectNewestModVersions;
    protected bool FirstBatchLoaded;

    public bool SelectNewestModVersions
    {
        set
        {
            if (FirstBatchLoaded)
            {
                SelectNewestVersions();
            }
            else
            {
                _SelectNewestModVersions = value;
            }
        }
        get => _SelectNewestModVersions;
    }

    public void Update()
    {
        foreach (var li in Mods)
        {
            var mv = (ModViewModel)li.DataContext;
            mv.Update();
        }
    }

    public ModsViewModel()
    {
        _Mods = new ObservableCollection<ListViewItem>();
        Configuration.OnLanguageChanged += Update;

        Timer = new DispatcherTimer();
        Timer.Tick += Tick;
        Timer.Interval = new TimeSpan(10000000); // 1s
        Timer.Start();

        FindMods();
    }

    protected Dictionary<string, Mod> LoadedFiles = new Dictionary<string, Mod>();
    protected Regex Validation = new Regex("^([a-zA-Z0-9_]+)-([0-9\\.]+)-([0-9abcdef]{32})\\.mod$");
    protected bool Loading;

    // 1초마다 폴링되는 FindMods()가 매번 동일한 로그를 반복해서
    // modapi.detailed.log 를 무한정 불려놓는 문제를 막기 위한 상태 캐시.
    // 마지막 스캔과 파일 개수가 같고 실제로 추가/삭제된 mod 도 없으면
    // "아무 변화 없음" 스캔으로 보고 반복 로그를 생략한다.
    protected int _lastFindModsFileCount = -1;

    protected void FindMods()
    {
        try
        {
            if (Loading)
            {
                return;
            }
            var modsBase = Path.GetFullPath(Configuration.GetPath("mods"));
            var path = Path.GetFullPath(modsBase + Path.DirectorySeparatorChar + App.Game.GameConfiguration.Id);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var keys = LoadedFiles.Keys.ToArray();
            var modsRemoved = false;
            for (var i = 0; i < keys.Length; i++)
            {
                var file = keys[i];
                if (!File.Exists(file))
                {
                    var mod = LoadedFiles[file];
                    // Mod.Mods 키에 게임ID를 포함시켜야 한다 (아래 LoadMods()와 동일한 키 형식).
                    // 게임ID 없이 "ModId-Version"만 쓰면, 서로 다른 게임 폴더에 같은 이름의
                    // mod가 있을 때 한쪽을 지워도 다른 게임 쪽 항목까지 같이 지워지는 문제가 있었다.
                    var modGameId = mod.Game?.GameConfiguration?.Id ?? "";
                    var id = modGameId + "-" + LoadedFiles[file].Id + "-" + LoadedFiles[file].HeaderData.GetVersion();
                    Mod.Mods.Remove(id);
                    for (var j = 0; j < _Mods.Count; j++)
                    {
                        var vm = (ModViewModel)_Mods[j].DataContext;
                        if (vm.VersionsData.Values.Contains(mod))
                        {
                            vm.VersionsData.Remove(Mod.Header.ParseModVersion(mod.HeaderData.GetVersion()));
                            if (vm.VersionsData.Count == 0)
                            {
                                _Mods.RemoveAt(j);
                                modsRemoved = true;
                            }
                            break;
                        }
                    }
                    LoadedFiles.Remove(file);
                }
            }

            // 삭제된 mod 가 있으면 FilteredMods 갱신 알림
            // (없으면 특정 게임 필터가 선택된 상태에서는 화면이 갱신되지 않고
            //  All 필터로 전환해야만 비로소 목록에서 사라지는 것처럼 보이는 문제가 발생함)
            if (modsRemoved)
            {
                OnPropertyChanged("FilteredMods");
            }

            // Collect .mod files from all game subdirectories under modsBase
            var allFiles = new List<string>();
            if (Directory.Exists(modsBase))
            {
                foreach (var dir in Directory.GetDirectories(modsBase))
                {
                    allFiles.AddRange(Directory.GetFiles(dir));
                }
            }
            var files = allFiles.ToArray();
            var toLoad = new List<string>();

            // 지난 스캔과 파일 개수가 같고(=새로 추가/삭제된 게 없고) mod 제거도 없었다면
            // "변화 없는" 스캔으로 보고 아래의 반복적인 상세 로그를 생략한다.
            var scanQuiet = !modsRemoved && files.Length == _lastFindModsFileCount;

            if (!scanQuiet)
            {
                Debug.Log("ModsViewModel", $"[FindMods] Scanning mods folder: {modsBase} | Total files found: {files.Length}", Debug.Type.Notice, detailedOnly: true);
            }

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);

                // 이미 로드된 파일 스킵
                if (LoadedFiles.ContainsKey(file))
                {
                    if (!scanQuiet)
                    {
                        Debug.Log("ModsViewModel", $"[FindMods] Skip (already loaded): {fileName}", Debug.Type.Notice, detailedOnly: true);
                    }
                    continue;
                }

                // .mod 확장자 파일만 검사
                if (!fileName.EndsWith(".mod", StringComparison.OrdinalIgnoreCase))
                {
                    if (!scanQuiet)
                    {
                        Debug.Log("ModsViewModel", $"[FindMods] Skip (not .mod): {fileName}", Debug.Type.Notice, detailedOnly: true);
                    }
                    continue;
                }

                // 정규식 패턴 검증
                // 필요 형식: {ModId}-{Version}-{32자리 MD5}.mod
                // 예: UltimateCheatMenu-2.3.6-a1b2c3d4e5f6789012345678901234ab.mod
                if (Validation.IsMatch(fileName))
                {
                    toLoad.Add(file);
                    Debug.Log("ModsViewModel", $"[FindMods] Queued for load: {fileName}", Debug.Type.Notice, detailedOnly: true);
                }
                else
                {
                    // 패턴 매칭 실패 — 파일명 형식 진단 (같은 파일이 계속 남아있는 동안은
                    // scanQuiet 로 한 번만 남기고, 문제되는 파일이 바뀌면 다시 남긴다)
                    if (!scanQuiet)
                    {
                        var parts = fileName.Replace(".mod", "").Split('-');
                        string reason;
                        if (parts.Length < 3)
                            reason = $"Too few segments (expected 3+, got {parts.Length}). Format: {{ModId}}-{{Version}}-{{MD5Hash}}.mod";
                        else if (!System.Text.RegularExpressions.Regex.IsMatch(parts[0], "^[a-zA-Z0-9_]+$"))
                            reason = "Invalid ModId segment: " + parts[0] + " (only letters, digits, underscore allowed)";
                        else if (!System.Text.RegularExpressions.Regex.IsMatch(parts[1], "^[0-9.]+$"))
                            reason = "Invalid Version segment: " + parts[1] + " (only digits and dots allowed)";
                        else if (parts.Length < 3 || !System.Text.RegularExpressions.Regex.IsMatch(parts[parts.Length - 1], "^[0-9abcdef]{32}$"))
                            reason = "Invalid or missing MD5 hash: " + (parts.Length >= 3 ? parts[parts.Length - 1] : "(missing)") + " (must be 32 lowercase hex chars)";
                        else
                            reason = "Pattern mismatch (unknown reason)";

                        Debug.Log("ModsViewModel",
                            $"[FindMods] Skip (filename validation failed): {fileName}" +
                            $" | Reason: {reason}" +
                            $" | Expected pattern: {{ModId}}-{{Version}}-{{32hexMD5}}.mod",
                            Debug.Type.Warning);
                    }
                }
            }

            if (!scanQuiet || toLoad.Count > 0)
            {
                Debug.Log("ModsViewModel", $"[FindMods] Scan complete. Queued: {toLoad.Count} / {files.Length} files", Debug.Type.Notice, detailedOnly: true);
            }

            _lastFindModsFileCount = files.Length;

            if (toLoad.Count > 0)
            {
                Loading = true;
                var progressHandler = new ProgressHandler();
                var t = new Thread(delegate () { LoadMods(toLoad, progressHandler); });
                progressHandler.Task = "LoadingMods";
                progressHandler.OnComplete += (s, e) => MainWindow.Instance.Dispatcher.Invoke(delegate { UpdateMods(); });
                Schedule.AddTask("GUI", "OperationPending", null, new object[] { "LoadingMods", progressHandler, null, true });
                t.Start();
            }
        }
        catch (Exception e)
        {
            Debug.Log("ModsViewModel", $"[FindMods] Exception: {e}", Debug.Type.Error);
            Console.WriteLine(e.ToString());
        }
    }

    protected void UpdateMods()
    {
        foreach (var kv in Mod.Mods)
        {
            var add = true;
            ModViewModel alreadyVm = null;
            var kvGameId = kv.Value.Game?.GameConfiguration?.Id ?? "";
            foreach (var i in _Mods)
            {
                var vm = ((ModViewModel)i.DataContext);
                if (vm.VersionsData.Values.Contains(kv.Value))
                {
                    add = false;
                }
                // ModId만으로 묶으면 서로 다른 게임의 같은 이름 mod(예: GH와 TheForest에
                // 둘 다 있는 "UltimateCheatmenu")가 같은 화면 항목으로 합쳐져 버린다.
                // 그 상태에서 같은 버전 번호가 VersionsData에 중복으로 추가되려다가
                // "키 중복" 예외로 앱이 죽는 문제가 있었다 — 게임까지 같이 비교해야 한다.
                if (vm.Id == kv.Value.Id && vm.GameId == kvGameId)
                {
                    alreadyVm = vm;
                }
            }
            if (add)
            {
                var mod = kv.Value;
                if (alreadyVm != null)
                {
                    alreadyVm.VersionsData.Add(Mod.Header.ParseModVersion(mod.HeaderData.GetVersion()), mod);
                    alreadyVm.OnPropertyChanged("Version");
                    alreadyVm.OnPropertyChanged("Name");
                }
                else
                {
                    var item = new ListViewItem();

                    var outerPanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Margin = new Thickness(-5, 0, 0, 0)
                    };
                    var checkBox = new CheckBox();
                    checkBox.SetBinding(CheckBox.IsCheckedProperty, "Selected");
                    outerPanel.Children.Add(checkBox);

                    var panel = new StackPanel();

                    var textBlock = new TextBlock();
                    textBlock.SetBinding(TextBlock.TextProperty, "Name");
                    textBlock.Style = (Style)Application.Current.FindResource("HeaderLabel");

                    panel.Children.Add(textBlock);

                    var textBlock2 = new TextBlock();
                    textBlock2.SetBinding(TextBlock.TextProperty, "Version");
                    textBlock2.FontSize = 12;
                    textBlock2.Style = (Style)Application.Current.FindResource("NormalLabel");
                    panel.Children.Add(textBlock2);
                    outerPanel.Children.Add(panel);

                    // 다른 게임용으로 보이는 mod에 경고 배지(⚠) 표시.
                    // Game.CheckModGameCompatibilityLight()가 로드 시점에 판정한 결과를
                    // ModViewModel.HasGameMismatch/GameMismatchTooltip 이 그대로 노출한다.
                    var mismatchIcon = new TextBlock
                    {
                        Text = "⚠",
                        FontSize = 14,
                        Foreground = System.Windows.Media.Brushes.Orange,
                        Margin = new Thickness(6, 0, 0, 0),
                        VerticalAlignment = VerticalAlignment.Center
                    };
                    mismatchIcon.SetBinding(TextBlock.VisibilityProperty, new System.Windows.Data.Binding("HasGameMismatch")
                    {
                        Converter = new System.Windows.Controls.BooleanToVisibilityConverter()
                    });
                    mismatchIcon.SetBinding(TextBlock.ToolTipProperty, "GameMismatchTooltip");
                    outerPanel.Children.Add(mismatchIcon);

                    var mvm = new ModViewModel(mod);
                    item.DataContext = mvm;
                    item.Content = outerPanel;
                    _Mods.Add(item);
                }
            }
        }

        OnPropertyChanged("FilteredMods");

        foreach (var item in _Mods)
        {
            var vm = (ModViewModel)item.DataContext;
            vm.Initialized();
        }
        FirstBatchLoaded = true;
        if (_SelectNewestModVersions)
        {
            SelectNewestVersions();
        }
    }

    public void SelectNewestVersions()
    {
        foreach (var item in _Mods)
        {
            var vm = (ModViewModel)item.DataContext;
            var v = vm.VersionsData.Keys.ToList();
            v.Sort();
            v.Reverse();
            foreach (var li in vm.Versions)
            {
                var versionModel = (ModVersionViewModel)li.DataContext;
                if (Mod.Header.ParseModVersion(versionModel.Mod.HeaderData.GetVersion()) == v[0])
                {
                    vm.SelectedVersion = li;
                    break;
                }
            }
        }
        _SelectNewestModVersions = false;
    }

    protected void LoadMods(List<string> toLoad, ProgressHandler progressHandler)
    {
        for (var i = 0; i < toLoad.Count; i++)
        {
            var fileName = toLoad[i];
            var collection = Validation.Match(Path.GetFileName(fileName));

            // 파일 경로에서 GameId 추출 (아래 id 계산과 Game 인스턴스 선택 모두에 사용)
            var gameId = Path.GetFileName(Path.GetDirectoryName(fileName));

            // Mod.Mods 키에 게임ID를 포함시킨다. 이게 없으면 서로 다른 게임 폴더에
            // 같은 이름(ModId+Version)의 mod가 있을 때, 먼저 로드된 쪽이 있다는 이유로
            // 뒤에 스캔되는 다른 게임의 mod는 mod.Load()조차 호출되지 않고 조용히
            // 스킵되어(그러면서 LoadedFiles 에는 "처리됨"으로 등록만 되어 재시도도 안 됨)
            // 그 게임의 목록에 영원히 나타나지 않는 문제가 있었다.
            var id = gameId + "-" + collection.Groups[1].Captures[0].Value + "-" + collection.Groups[2].Captures[0].Value;

            ModAPI.Data.Game modGame = App.Game;
            if (!string.IsNullOrEmpty(gameId) &&
                !string.Equals(gameId, App.Game?.GameConfiguration?.Id, StringComparison.OrdinalIgnoreCase))
            {
                ModAPI.Configurations.Configuration.GameConfiguration cfg = null;
                if (ModAPI.Configurations.Configuration.Games.ContainsKey(gameId))
                    cfg = ModAPI.Configurations.Configuration.Games[gameId];
                if (cfg != null)
                    modGame = new ModAPI.Data.Game(cfg, true);
            }
            var mod = new Mod(modGame, fileName);
            var alreadyKnown = Mod.Mods.ContainsKey(id);
            if (alreadyKnown || mod.Load())
            {
                LoadedFiles.Add(fileName, mod);
                if (!alreadyKnown)
                {
                    Mod.Mods.Add(id, mod);

                    // 새로 로드된 mod에 한해, 이 폴더의 게임과 실제로 맞는지 경량 검사한다.
                    // (이미 알려진 mod는 처음 로드될 때 이미 검사했으므로 다시 안 함)
                    try
                    {
                        mod.GameMismatchReason = modGame?.CheckModGameCompatibilityLight(mod);
                        if (!string.IsNullOrEmpty(mod.GameMismatchReason))
                        {
                            Debug.Log("ModsViewModel",
                                "[FindMods] Mod \"" + mod.Id + "\" in \"" + gameId + "\" folder looks mismatched: " + mod.GameMismatchReason,
                                Debug.Type.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Log("ModsViewModel",
                            "[FindMods] Compatibility check failed for \"" + mod.Id + "\": " + ex.Message,
                            Debug.Type.Warning, detailedOnly: true);
                    }
                }
            }
            else
            {
                // Load failed (corrupted header, etc.) — register to prevent infinite retry
                LoadedFiles.Add(fileName, mod);
            }
            progressHandler.Progress = (i / (float)toLoad.Count) * 100f;
        }
        progressHandler.Progress = 100f;
        Loading = false;
    }

    protected void Tick(object sender, EventArgs e)
    {
        FindMods();
    }

    // ── Game Filter ───────────────────────────────────────────────────────
    private string _selectedGameFilter = "All";
    public string SelectedGameFilter
    {
        get => _selectedGameFilter;
        set
        {
            _selectedGameFilter = value;
            OnPropertyChanged("SelectedGameFilter");
            OnPropertyChanged("FilteredMods");
        }
    }

    // ── Mod List Width ───────────────────────────────────────────────────
    private double _modListWidth = 220;
    public double ModListWidth
    {
        get => _modListWidth;
        set { _modListWidth = value; OnPropertyChanged("ModListWidth"); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected internal void OnPropertyChanged(string propertyname)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
    }

    protected ObservableCollection<ListViewItem> _Mods = new ObservableCollection<ListViewItem>();

    public ObservableCollection<ListViewItem> Mods => _Mods;

    public ObservableCollection<ListViewItem> FilteredMods
    {
        get
        {
            if (string.IsNullOrEmpty(_selectedGameFilter) || _selectedGameFilter == "All")
                return _Mods;

            var filtered = new ObservableCollection<ListViewItem>();
            foreach (var item in _Mods)
            {
                var vm = item.DataContext as ModViewModel;
                if (vm != null && string.Equals(vm.GameId, _selectedGameFilter, StringComparison.OrdinalIgnoreCase))
                    filtered.Add(item);
            }
            return filtered;
        }
    }

    private ListViewItem _selectedModItem;
    public ListViewItem SelectedModItem
    {
        get => _selectedModItem;
        set
        {
            _selectedModItem = value;
            OnPropertyChanged("SelectedModItem");
            if (value != null)
            {
                var vm = value.DataContext as ModViewModel;
                if (vm != null)
                    MainWindow.Instance.SetMod(vm);
            }
            else
            {
                MainWindow.Instance.SetMod(null);
            }
        }
    }
    protected int _SelectedMod = -1;

    public int SelectedMod
    {
        get => _SelectedMod;
        set
        {
            _SelectedMod = value;
            if (_SelectedMod >= 0)
            {
                MainWindow.Instance.SetMod(((ModViewModel)_Mods[_SelectedMod].DataContext));
            }
        }
    }
}