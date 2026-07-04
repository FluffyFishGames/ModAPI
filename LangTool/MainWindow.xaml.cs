using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MODAPI_LangTool.Helpers;
using MODAPI_LangTool.Models;

namespace MODAPI_LangTool
{
    public class TranslationRow : INotifyPropertyChanged
    {
        private string _value;
        public string Key { get; set; }
        public string Value
        {
            get => _value;
            set { _value = value; OnPropertyChanged("Value"); }
        }
        public string EnglishValue { get; set; }
        public bool IsMissing => string.IsNullOrWhiteSpace(Value);
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public partial class MainWindow : Window
    {
        private string _rootPath = "";
        private string _langPath = "";
        private string _langsJsonPath = "";
        private string _englishXamlPath = "";

        private LangsJson _langsData;
        private ObservableCollection<LanguageEntry> _langList = new ObservableCollection<LanguageEntry>();
        private ObservableCollection<TranslationRow> _translationRows = new ObservableCollection<TranslationRow>();

        private LanguageEntry _selectedEntry;
        private bool _isDirty = false;
        private bool _langSelectorInitializing = false;

        public MainWindow()
        {
            InitializeComponent();
            LangListBox.ItemsSource = _langList;
            KeysDataGrid.ItemsSource = _translationRows;

            InitLangSelector();

            // 저장된 경로 자동 로드
            var savedPath = App.LoadSavedRootPath();
            if (!string.IsNullOrEmpty(savedPath))
                TryLoadRootPath(savedPath);
        }

        #region 언어 선택기 초기화

        private void InitLangSelector()
        {
            _langSelectorInitializing = true;
            LangSelector.ItemsSource = App.AvailableLanguages;

            var current = App.AvailableLanguages.FirstOrDefault(
                l => l.LangCode.Equals(App.CurrentLangCode, StringComparison.OrdinalIgnoreCase));
            if (current != null)
                LangSelector.SelectedItem = current;

            UpdateLangSelectorFlag();
            _langSelectorInitializing = false;
        }

        private void LangSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_langSelectorInitializing) return;
            var selected = LangSelector.SelectedItem as LangInfo;
            if (selected == null) return;

            App.ApplyLanguage(selected);
            UpdateLangSelectorFlag();
        }

        private void UpdateLangSelectorFlag()
        {
            var selected = LangSelector.SelectedItem as LangInfo;
            if (selected == null) { LangSelectorFlag.Source = null; return; }

            // 언어 폴더에서 국기 이미지 로드
            var flagPath = string.IsNullOrEmpty(App.LangFolder) ? "" :
                Path.Combine(App.LangFolder,
                    FlagDownloader.GetFlagFileName(selected.LangCode));

            if (File.Exists(flagPath))
            {
                try
                {
                    var bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = new Uri(flagPath);
                    bmp.CacheOption = BitmapCacheOption.OnLoad;
                    bmp.EndInit();
                    LangSelectorFlag.Source = bmp;
                }
                catch { LangSelectorFlag.Source = null; }
            }
            else
            {
                LangSelectorFlag.Source = null;
            }
        }

        #endregion

        #region 경로 선택

        private void BrowseRoot_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog
            {
                Description = GetRes("Lang.LangTool.RootPath") ?? "Select ModAPI root folder",
                ShowNewFolderButton = false
            };

            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            TryLoadRootPath(dialog.SelectedPath);
        }

        private void TryLoadRootPath(string selected)
        {
            var langsDir = Path.Combine(selected, "resources", "langs");

            if (!Directory.Exists(langsDir))
            {
                SetStatus(GetRes("Lang.LangTool.Msg.InvalidPath") ?? "❌ resources/langs folder not found.", true);
                return;
            }

            _rootPath = selected;
            _langPath = langsDir;
            _langsJsonPath = Path.Combine(langsDir, "langs.json");
            _englishXamlPath = Path.Combine(langsDir, "Language.EN.xaml");

            RootPathBox.Text = _rootPath;
            LangPathBox.Text = _langPath;

            // 경로 저장
            App.SaveRootPath(_rootPath);

            LoadLangsJson();
        }

        #endregion

        #region 데이터 로드

        private void LoadLangsJson()
        {
            try
            {
                _langsData = File.Exists(_langsJsonPath)
                    ? LangsJsonHelper.Load(_langsJsonPath)
                    : CreateDefaultLangsJson();

                if (!File.Exists(_langsJsonPath))
                    LangsJsonHelper.Save(_langsJsonPath, _langsData);

                RefreshLangList();
                SetStatus($"✅ {_langsData.Languages.Count}");
            }
            catch (Exception ex)
            {
                SetStatus($"❌ {ex.Message}", true);
            }
        }

        private LangsJson CreateDefaultLangsJson()
        {
            return new LangsJson
            {
                Languages = new List<LanguageEntry>
                {
                    new LanguageEntry { IsoCode="us", LangCode="EN",    LangName="English",      Builtin=true, Active=true },
                    new LanguageEntry { IsoCode="kr", LangCode="KR",    LangName="한국어",        Builtin=true, Active=true },
                    new LanguageEntry { IsoCode="de", LangCode="DE",    LangName="Deutsch",      Builtin=true, Active=true },
                    new LanguageEntry { IsoCode="es", LangCode="ES",    LangName="Español",      Builtin=true, Active=true },
                    new LanguageEntry { IsoCode="fr", LangCode="FR",    LangName="Français",     Builtin=true, Active=true },
                    new LanguageEntry { IsoCode="it", LangCode="IT",    LangName="Italiano",     Builtin=true, Active=true },
                    new LanguageEntry { IsoCode="jp", LangCode="JP",    LangName="日本語",        Builtin=true, Active=true },
                    new LanguageEntry { IsoCode="pl", LangCode="PL",    LangName="Polski",       Builtin=true, Active=true },
                    new LanguageEntry { IsoCode="pt", LangCode="PT",    LangName="Português",    Builtin=true, Active=true },
                    new LanguageEntry { IsoCode="ru", LangCode="RU",    LangName="Русский",      Builtin=true, Active=true },
                    new LanguageEntry { IsoCode="vn", LangCode="VI",    LangName="Tiếng Việt",   Builtin=true, Active=true },
                    new LanguageEntry { IsoCode="cn", LangCode="ZH",    LangName="简体中文",      Builtin=true, Active=true },
                    new LanguageEntry { IsoCode="tw", LangCode="ZH-TW", LangName="繁體中文",     Builtin=true, Active=true },
                }
            };
        }

        private void RefreshLangList()
        {
            _langList.Clear();
            foreach (var lang in _langsData.Languages)
                _langList.Add(lang);
        }

        #endregion

        #region 언어 목록 선택

        private void LangListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 편집 가능한 활성 언어에서 변경사항이 있을 때만 팝업 표시
            bool canEdit = _selectedEntry != null
                && _selectedEntry.IsEditable
                && _selectedEntry.Active;

            if (_isDirty && canEdit)
            {
                var res = ModApiDialog.Ask(this,
                    GetRes("Lang.LangTool.Msg.SaveConfirmTitle") ?? "Save Confirmation",
                    GetRes("Lang.LangTool.Msg.SaveConfirm") ?? "You have unsaved changes. Do you want to save?",
                    ModApiDialogType.Warning);

                if (res == MessageBoxResult.Yes) SaveCurrentLanguage();
                else if (res == MessageBoxResult.Cancel)
                {
                    LangListBox.SelectionChanged -= LangListBox_SelectionChanged;
                    LangListBox.SelectedItem = _selectedEntry;
                    LangListBox.SelectionChanged += LangListBox_SelectionChanged;
                    return;
                }
            }

            _selectedEntry = LangListBox.SelectedItem as LanguageEntry;
            LoadSelectedLanguage();
        }

        private void LoadSelectedLanguage()
        {
            _isDirty = false;
            _translationRows.Clear();

            if (_selectedEntry == null) { ClearEditPanel(); return; }

            // 편집 가능 조건: 내장 언어 아님(IsEditable) AND 활성 상태(Active)
            bool canEdit = _selectedEntry.IsEditable && _selectedEntry.Active;

            IsoCodeBox.Text = _selectedEntry.IsoCode;
            LangCodeBox.Text = _selectedEntry.LangCode;
            LangNameBox.Text = _selectedEntry.LangName;
            LangNameBox.IsEnabled = canEdit;

            // 읽기전용 안내 표시
            if (_selectedEntry.Builtin)
            {
                ReadOnlyNotice.Text = GetRes("Lang.LangTool.ReadOnly") ?? "(Built-in language — Read only)";
                ReadOnlyNotice.Visibility = Visibility.Visible;
            }
            else if (!_selectedEntry.Active)
            {
                ReadOnlyNotice.Text = GetRes("Lang.LangTool.InactiveNotice") ?? "(Inactive — Activate to edit)";
                ReadOnlyNotice.Visibility = Visibility.Visible;
            }
            else
            {
                ReadOnlyNotice.Visibility = Visibility.Collapsed;
            }

            LoadFlagPreview(_selectedEntry);
            KeysDataGrid.IsReadOnly = !canEdit;
            SaveButton.IsEnabled = canEdit;

            // 업데이트 버튼: 활성 상태일 때만 사용 가능
            UpdateBuiltinButton.IsEnabled = canEdit;

            // 비활성화/활성화 버튼
            // 활성 상태 → 파란색(ToolButton) + "비활성화"
            // 비활성 상태 → 빨간색(DangerButton) + "활성화"
            DeactivateButton.IsEnabled = _selectedEntry.IsEditable;
            if (_selectedEntry.Active)
            {
                DeactivateButton.Style = (Style)FindResource("DangerButton");
                DeactivateButton.Content = GetRes("Lang.LangTool.Deactivate") ?? "Deactivate";
            }
            else
            {
                DeactivateButton.Style = (Style)FindResource("ToolButton");
                DeactivateButton.Content = GetRes("Lang.LangTool.Reactivate") ?? "Activate";
            }

            LoadTranslationKeys();
        }

        private void LoadTranslationKeys()
        {
            if (string.IsNullOrEmpty(_langPath)) return;

            var englishKeys = new Dictionary<string, string>();
            if (File.Exists(_englishXamlPath))
                englishKeys = XamlGenerator.ParseXamlKeys(
                    File.ReadAllText(_englishXamlPath, System.Text.Encoding.UTF8));

            var targetKeys = new Dictionary<string, string>();
            var targetPath = Path.Combine(_langPath,
                $"Language.{_selectedEntry.LangCode.ToUpper()}.xaml");
            if (File.Exists(targetPath))
                targetKeys = XamlGenerator.ParseXamlKeys(
                    File.ReadAllText(targetPath, System.Text.Encoding.UTF8));

            foreach (var kv in englishKeys)
            {
                targetKeys.TryGetValue(kv.Key, out var translated);
                _translationRows.Add(new TranslationRow
                {
                    Key = kv.Key,
                    Value = translated ?? "",
                    EnglishValue = kv.Value
                });
            }

            UpdateMissingKeyInfo();
        }

        private void UpdateMissingKeyInfo()
        {
            if (string.IsNullOrEmpty(_langPath) || _selectedEntry == null) return;

            var targetPath = Path.Combine(_langPath,
                $"Language.{_selectedEntry.LangCode.ToUpper()}.xaml");
            var result = MissingKeyDetector.Detect(_englishXamlPath, targetPath);

            int missing = result.MissingKeys.Count + result.EmptyKeys.Count;
            MissingKeyText.Text = missing > 0
                ? string.Format(GetRes("Lang.LangTool.MissingKeys") ?? "⚠ Missing/Empty keys: {0}", missing)
                : (GetRes("Lang.LangTool.AllTranslated") ?? "✅ All keys translated");

            TranslationProgressText.Text = string.Format(
                GetRes("Lang.LangTool.Progress") ?? "Translated: {0} / {1}",
                result.TranslatedKeys, result.TotalKeys);
        }

        private void ClearEditPanel()
        {
            IsoCodeBox.Text = "";
            LangCodeBox.Text = "";
            LangNameBox.Text = "";
            LangNameBox.IsEnabled = false;
            PreviewFlagImage.Source = null;
            ReadOnlyNotice.Visibility = Visibility.Collapsed;
            KeysDataGrid.IsReadOnly = true;
            SaveButton.IsEnabled = false;
            UpdateBuiltinButton.IsEnabled = false;
            DeactivateButton.IsEnabled = false;
            MissingKeyText.Text = "";
            TranslationProgressText.Text = "";
        }

        private void LoadFlagPreview(LanguageEntry entry)
        {
            try
            {
                var flagPath = Path.Combine(_langPath,
                    FlagDownloader.GetFlagFileName(entry.LangCode));
                if (File.Exists(flagPath))
                {
                    var bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = new Uri(flagPath);
                    bmp.CacheOption = BitmapCacheOption.OnLoad;
                    bmp.EndInit();
                    PreviewFlagImage.Source = bmp;
                }
                else PreviewFlagImage.Source = null;
            }
            catch { PreviewFlagImage.Source = null; }
        }

        #endregion

        #region 언어 추가

        private async void AddLanguage_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_rootPath))
            {
                ModApiDialog.Show(this,
                    GetRes("Lang.LangTool.Msg.NoPathTitle") ?? "No Path",
                    GetRes("Lang.LangTool.Msg.NoPath") ?? "Please select the ModAPI root path first.",
                    ModApiDialogType.Warning);
                return;
            }

            var usedIsoCodes = _langsData?.Languages
                .Select(l => l.IsoCode) ?? Enumerable.Empty<string>();
            var dialog = new AddLanguageDialog(usedIsoCodes);
            dialog.Owner = this;
            if (dialog.ShowDialog() != true) return;

            var isoCode = dialog.IsoCode.Trim().ToLower();
            var langCode = dialog.LangCode.Trim().ToUpper();
            var langName = dialog.LangName.Trim();

            if (_langsData.Languages.Any(
                l => l.LangCode.Equals(langCode, StringComparison.OrdinalIgnoreCase)))
            {
                ModApiDialog.Show(this,
                    GetRes("Lang.LangTool.Msg.DuplicateTitle") ?? "Duplicate Error",
                    string.Format(GetRes("Lang.LangTool.Msg.NoDuplicate") ?? "'{0}' code already exists.", langCode),
                    ModApiDialogType.Warning);
                return;
            }

            SetStatus(GetRes("Lang.LangTool.Status.Loading") ?? "Processing...");

            try
            {
                var flagSavePath = Path.Combine(_langPath,
                    FlagDownloader.GetFlagFileName(langCode));
                bool flagOk = await FlagDownloader.DownloadFlagAsync(isoCode, flagSavePath);

                if (!flagOk)
                {
                    bool cont = ModApiDialog.Confirm(this,
                        GetRes("Lang.LangTool.Msg.FlagFailedTitle") ?? "Download Failed",
                        GetRes("Lang.LangTool.Msg.FlagFailed") ?? "Flag image download failed.\nAdd language without flag?",
                        ModApiDialogType.Warning);
                    if (!cont) return;
                }

                var xamlPath = Path.Combine(_langPath, $"Language.{langCode}.xaml");
                XamlGenerator.GenerateFromEnglish(
                    _englishXamlPath, xamlPath, langCode, langName, isoCode);

                var newEntry = new LanguageEntry
                {
                    IsoCode = isoCode,
                    LangCode = langCode,
                    LangName = langName,
                    Builtin = false,
                    Active = true
                };
                _langsData.Languages.Add(newEntry);
                LangsJsonHelper.Save(_langsJsonPath, _langsData);

                _isDirty = false;
                LangListBox.SelectionChanged -= LangListBox_SelectionChanged;
                RefreshLangList();
                LangListBox.SelectedItem = _langList.FirstOrDefault(l => l.LangCode == langCode);
                _selectedEntry = LangListBox.SelectedItem as LanguageEntry;
                LangListBox.SelectionChanged += LangListBox_SelectionChanged;
                LoadSelectedLanguage();

                SetStatus($"✅ '{langName}' ({langCode})" + (flagOk ? "" : " — no flag"));
            }
            catch (Exception ex)
            {
                SetStatus($"❌ {ex.Message}", true);
            }
        }

        #endregion

        #region 비활성화 / 재활성화

        private void DeactivateLanguage_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEntry == null || !_selectedEntry.IsEditable) return;

            if (_selectedEntry.Active)
            {
                bool confirmed = ModApiDialog.Confirm(this,
                    GetRes("Lang.LangTool.Msg.DeactivateTitle") ?? "Deactivate Confirmation",
                    GetRes("Lang.LangTool.Msg.DeactivateConfirm") ?? "Do you want to deactivate this language?",
                    ModApiDialogType.Warning);
                if (!confirmed) return;
                _selectedEntry.Active = false;
            }
            else
            {
                _selectedEntry.Active = true;
            }

            LangsJsonHelper.Save(_langsJsonPath, _langsData);

            // RefreshLangList() 호출 전 _isDirty 초기화
            // → SelectionChanged 이벤트가 발생해도 저장 팝업이 뜨지 않도록
            _isDirty = false;

            var currentEntry = _selectedEntry;

            // SelectionChanged 이벤트 임시 해제 후 목록 갱신
            LangListBox.SelectionChanged -= LangListBox_SelectionChanged;
            RefreshLangList();
            LangListBox.SelectedItem = _langList.FirstOrDefault(
                l => l.LangCode == currentEntry.LangCode);
            _selectedEntry = LangListBox.SelectedItem as LanguageEntry;
            LangListBox.SelectionChanged += LangListBox_SelectionChanged;

            // 버튼 스타일/텍스트 갱신
            if (_selectedEntry?.Active == true)
            {
                DeactivateButton.Style = (Style)FindResource("DangerButton");
                DeactivateButton.Content = GetRes("Lang.LangTool.Deactivate") ?? "Deactivate";
            }
            else
            {
                DeactivateButton.Style = (Style)FindResource("ToolButton");
                DeactivateButton.Content = GetRes("Lang.LangTool.Reactivate") ?? "Activate";
            }
            UpdateBuiltinButton.IsEnabled = _selectedEntry?.IsEditable == true
                && _selectedEntry?.Active == true;
            SetStatus($"✅ '{currentEntry.LangName}'");
        }

        #endregion

        #region 내장 전환

        private void UpdateBuiltin_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEntry == null || !_selectedEntry.IsEditable) return;

            bool warn1 = ModApiDialog.Confirm(this,
                GetRes("Lang.LangTool.Msg.BuiltinWarnTitle") ?? "Convert to Built-in",
                GetRes("Lang.LangTool.Msg.BuiltinWarn") ?? "⚠ Warning: This cannot be undone! Continue?",
                ModApiDialogType.Warning);
            if (!warn1) return;

            bool warn2 = ModApiDialog.Confirm(this,
                GetRes("Lang.LangTool.Msg.BuiltinConfirmTitle") ?? "Final Confirmation",
                GetRes("Lang.LangTool.Msg.BuiltinConfirm") ?? "Final confirmation. Continue?",
                ModApiDialogType.Warning);
            if (!warn2) return;

            _selectedEntry.Builtin = true;
            LangsJsonHelper.Save(_langsJsonPath, _langsData);

            _isDirty = false;
            var currentEntry = _selectedEntry;

            // 1. CreateDefaultLangsJson() 소스코드 재작성
            var builtinList = _langsData.Languages.Where(l => l.Builtin).ToList();
            var mainWindowCsPath = BuiltinCodeWriter.FindMainWindowCs(_rootPath);
            if (mainWindowCsPath != null)
            {
                if (!BuiltinCodeWriter.RewriteCreateDefaultLangsJson(
                    mainWindowCsPath, builtinList, out string csErr))
                {
                    ModApiDialog.Show(this, "Warning",
                        $"CreateDefaultLangsJson() rewrite failed:\n{csErr}",
                        ModApiDialogType.Warning);
                }
            }
            else
            {
                ModApiDialog.Show(this, "Warning",
                    "LangTool\\MainWindow.xaml.cs not found.\nSkipping CreateDefaultLangsJson() rewrite.",
                    ModApiDialogType.Warning);
            }

            // 2. ModAPI.csproj 에 Language.XX.xaml 등록
            var csprojPath = BuiltinCodeWriter.FindModApiCsproj(_rootPath);
            if (csprojPath != null)
            {
                if (!BuiltinCodeWriter.RegisterLangFileInCsproj(
                    csprojPath, currentEntry.LangCode, out string csprojErr))
                {
                    ModApiDialog.Show(this, "Warning",
                        $"ModAPI.csproj registration failed:\n{csprojErr}",
                        ModApiDialogType.Warning);
                }
            }
            else
            {
                ModApiDialog.Show(this, "Warning",
                    "ModAPI.csproj not found.\nSkipping csproj registration.",
                    ModApiDialogType.Warning);
            }

            LangListBox.SelectionChanged -= LangListBox_SelectionChanged;
            RefreshLangList();
            LangListBox.SelectedItem = _langList.FirstOrDefault(
                l => l.LangCode == currentEntry.LangCode);
            _selectedEntry = LangListBox.SelectedItem as LanguageEntry;
            LangListBox.SelectionChanged += LangListBox_SelectionChanged;

            LoadSelectedLanguage();
            SetStatus($"✅ '{currentEntry.LangName}' → Built-in (source & csproj updated)");
        }

        #endregion

        #region 저장

        private void LangNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_selectedEntry == null || !_selectedEntry.IsEditable) return;
            _isDirty = true;
        }

        private void KeysDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (_selectedEntry == null || !_selectedEntry.IsEditable) return;
            _isDirty = true;
        }

        private void SaveLanguage_Click(object sender, RoutedEventArgs e)
            => SaveCurrentLanguage();

        private void SaveCurrentLanguage()
        {
            if (_selectedEntry == null || !_selectedEntry.IsEditable) return;
            try
            {
                _selectedEntry.LangName = LangNameBox.Text.Trim();

                var xamlPath = Path.Combine(_langPath,
                    $"Language.{_selectedEntry.LangCode.ToUpper()}.xaml");
                var keys = new Dictionary<string, string>();
                foreach (var row in _translationRows)
                    keys[row.Key] = row.Value ?? "";

                XamlGenerator.SaveAllKeys(
                    xamlPath, keys,
                    _selectedEntry.LangCode,
                    _selectedEntry.LangName,
                    _selectedEntry.IsoCode);

                LangsJsonHelper.Save(_langsJsonPath, _langsData);
                _isDirty = false;
                UpdateMissingKeyInfo();
                SetStatus(GetRes("Lang.LangTool.Status.Saved") ?? "✅ Saved successfully.");
            }
            catch (Exception ex)
            {
                SetStatus($"❌ {ex.Message}", true);
            }
        }

        #endregion

        #region 유틸리티

        private string GetRes(string key)
        {
            try { return Application.Current.Resources[key] as string; }
            catch { return null; }
        }

        private void SetStatus(string message, bool isError = false)
        {
            StatusText.Text = message;
            StatusText.Foreground = isError
                ? new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromRgb(233, 69, 96))
                : new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromRgb(136, 136, 136));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // 편집 가능한 활성 언어에서 변경사항이 있을 때만 팝업 표시
            bool canEdit = _selectedEntry != null
                && _selectedEntry.IsEditable
                && _selectedEntry.Active;

            if (_isDirty && canEdit)
            {
                var res = ModApiDialog.Ask(this,
                    GetRes("Lang.LangTool.Msg.SaveConfirmTitle") ?? "Save Confirmation",
                    GetRes("Lang.LangTool.Msg.SaveConfirm") ?? "You have unsaved changes. Do you want to save?",
                    ModApiDialogType.Warning);
                if (res == MessageBoxResult.Yes) SaveCurrentLanguage();
                else if (res == MessageBoxResult.Cancel) e.Cancel = true;
            }
            base.OnClosing(e);
        }

        #endregion
    }
}