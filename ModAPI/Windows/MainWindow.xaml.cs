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

            Configuration.Save();
        }

        public bool CheckSteamPath()
        {
            if (App.DevMode) return true;
            if (Configuration.GetString("UseSteam").ToLower() == "true")
            {
                if (!CheckSteam())
                {
                    Schedule.AddTask("GUI", "SpecifySteamPath", FirstSetupDone, CheckSteam);
                    return false;
                }
            }
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
            if (!File.Exists(steamPath + Path.DirectorySeparatorChar + "Steam.exe"))
            {
                steamPath = SearchSteam();
                Configuration.SetPath("Steam", steamPath, true);
            }
            return File.Exists(steamPath + Path.DirectorySeparatorChar + "Steam.exe");
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
                catch (Exception e)
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
                catch (Exception e)
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

            var classicItem = new ComboBoxItem
            {
                Style = Application.Current.FindResource("ComboBoxItem") as Style
            };
            var classicText = new TextBlock { VerticalAlignment = VerticalAlignment.Center, FontSize = 16, Padding = new Thickness(0, 0, 10, 0) };
            classicText.SetResourceReference(TextBlock.TextProperty, "Lang.Options.Theme.Classic");
            classicItem.Content = classicText;
            ThemeSelector.Items.Add(classicItem);

            var lightItem = new ComboBoxItem
            {
                Style = Application.Current.FindResource("ComboBoxItem") as Style
            };
            var lightText = new TextBlock { VerticalAlignment = VerticalAlignment.Center, FontSize = 16, Padding = new Thickness(0, 0, 10, 0) };
            lightText.SetResourceReference(TextBlock.TextProperty, "Lang.Options.Theme.Light");
            lightItem.Content = lightText;
            ThemeSelector.Items.Add(lightItem);

            var darkItem = new ComboBoxItem
            {
                Style = Application.Current.FindResource("ComboBoxItem") as Style
            };
            var darkText = new TextBlock { VerticalAlignment = VerticalAlignment.Center, FontSize = 16, Padding = new Thickness(0, 0, 10, 0) };
            darkText.SetResourceReference(TextBlock.TextProperty, "Lang.Options.Theme.Dark");
            darkItem.Content = darkText;
            ThemeSelector.Items.Add(darkItem);

            var currentTheme = App.GetCurrentTheme();
            switch (currentTheme)
            {
                case "light":
                    ThemeSelector.SelectedIndex = 1;
                    break;
                case "dark":
                    ThemeSelector.SelectedIndex = 2;
                    break;
                default: // classic
                    ThemeSelector.SelectedIndex = 0;
                    break;
            }

            _themeInitializing = false;
        }

        private void ThemeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_themeInitializing) return;

            string theme;
            switch (ThemeSelector.SelectedIndex)
            {
                case 1:
                    theme = "light";
                    break;
                case 2:
                    theme = "dark";
                    break;
                default:
                    theme = "classic";
                    break;
            }

            // If same theme, do nothing
            if (theme == App.GetCurrentTheme()) return;

            var selectedTheme = theme;
            var win = new Windows.SubWindows.ThemeConfirm("Lang.Windows.ThemeConfirm");
            win.Closed += (s, args) =>
            {
                if (win.Confirmed)
                {
                    App.SaveTheme(selectedTheme);

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
                    // Revert selection
                    _themeInitializing = true;
                    var currentTheme = App.GetCurrentTheme();
                    switch (currentTheme)
                    {
                        case "light":
                            ThemeSelector.SelectedIndex = 1;
                            break;
                        case "dark":
                            ThemeSelector.SelectedIndex = 2;
                            break;
                        default:
                            ThemeSelector.SelectedIndex = 0;
                            break;
                    }
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
                var i = new Image();
                var img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = language.ImageStream;
                img.EndInit();
                i.Source = img;
                i.Margin = new Thickness(0, 0, 10, 0);

                panel.Children.Add(i);
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

            VersionLabel.Text = Version.Descriptor + " [" + Version.BuildDate + "]";
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
            WindowState = WindowState.Normal;
            ((Button)FindName("MaximizeButton")).Visibility = Visibility.Visible;
            ((Button)FindName("MaximizeButton")).Width = 24;
            ((Button)FindName("NormalizeButton")).Visibility = Visibility.Hidden;
            ((Button)FindName("NormalizeButton")).Width = 0;
        }

        private void Maximize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
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
        }

        public void Preload(ProgressHandler handler)
        {
            handler.OnComplete += delegate { Debug.Log("MainWindow", "GUI is ready."); };
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
            catch (Exception ex)
            {
            }
        }

        private void CreateModLibrary(object sender, RoutedEventArgs e)
        {
            if (ProjectList.Items.Count == 0)
            {
                var win = new Windows.SubWindows.NoProjectWarning("Lang.Windows.NoProjectWarning");
                win.ShowSubWindow();
                win.Show();
                return;
            }
            App.Game.CreateModLibrary();
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
                NoModSelected.Visibility = Visibility.Collapsed;
                SelectedMod.DataContext = model;
            }
            else
            {
                SelectedMod.Visibility = Visibility.Collapsed;
                NoModSelected.Visibility = Visibility.Visible;
                SelectedMod.DataContext = null;
            }
        }

        private void DeleteMod_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentModViewModel == null) return;

            var modName = CurrentModViewModel.Name;
            var modId = CurrentModViewModel.Id;
            var versionsData = CurrentModViewModel.VersionsData;

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
                    if (App.Game != null && !string.IsNullOrEmpty(App.Game.GamePath))
                    {
                        var gameFolder = App.Game.GetGameFolder();
                        if (!string.IsNullOrEmpty(gameFolder))
                        {
                            // Delete from assemblyPath (e.g. TheForest_Data/Managed/)
                            try
                            {
                                var assemblyRelPath = App.Game.ParsePath(App.Game.GameConfiguration.AssemblyPath);
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
                                    }
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

                    // Step 3: Delete from ModdedGameFiles staging area
                    try
                    {
                        var moddedBase = Path.GetFullPath(
                            ModAPI.Configurations.Configuration.GetPath("ModdedGameFiles") +
                            Path.DirectorySeparatorChar + App.Game.GameConfiguration.Id);

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
                                App.Game.ParsePath(App.Game.GameConfiguration.AssemblyPath));
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

                    // Step 4: Reset UI - ModsViewModel timer will auto-detect deleted files
                    SetMod(null);
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
            DevelopmentLanguageSelector.SelectedIndex = -1;
            foreach (var kv in LanguageItems)
            {
                var a = model.Project.Languages.Contains(kv.Key);
                kv.Value.Visibility = a ? Visibility.Collapsed : Visibility.Visible;
                kv.Value.IsEnabled = !a;
            }

            if (model != null)
            {
                SelectedProject.Visibility = Visibility.Visible;
                NoProjectSelected.Visibility = Visibility.Collapsed;
                SelectedProject.DataContext = model;
            }
            else
            {
                SelectedProject.Visibility = Visibility.Collapsed;
                NoProjectSelected.Visibility = Visibility.Visible;
                SelectedProject.DataContext = null;
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
            var mods = new List<Mod>();
            foreach (var i in Mods.Mods)
            {
                var vm = (ModViewModel)i.DataContext;
                if (vm != null && vm.Selected)
                {
                    var vm2 = (ModVersionViewModel)vm.SelectedVersion.DataContext;
                    if (vm2 != null)
                    {
                        mods.Add(vm2.Mod);
                    }
                }
            }
            var progressHandler = new ProgressHandler();
            progressHandler.OnComplete += (o, ex) =>
            {
                if (Configuration.GetString("UseSteam") == "true" && App.Game.GameConfiguration.SteamAppId != "")
                {
                    var p = new Process();
                    p.StartInfo.FileName = Configuration.GetPath("Steam") + Path.DirectorySeparatorChar + "Steam.exe";
                    p.StartInfo.Arguments = "-applaunch " + App.Game.GameConfiguration.SteamAppId;
                    p.Start();
                }
                else
                {
                    var p = new Process();
                    p.StartInfo.FileName = App.Game.GamePath + Path.DirectorySeparatorChar + App.Game.GameConfiguration.SelectFile;
                    p.Start();
                }
            };

            var thread = new Thread(delegate () { App.Game.ApplyMods(mods, progressHandler); });
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

        private List<ModInfo> ParseModsFromHtml(string html, string gameLabel)
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
                    DownloadCount = downloadCount,
                    ModId = modId,
                    Slug = slug
                });
            }

            return mods;
        }

        private void LoadModsFromWeb()
        {
            var sources = new[]
            {
                new { Url = "https://modapi.survivetheforest.net/mods/", Label = "The Forest" },
                new { Url = "https://modapi.survivetheforest.net/mods/game/TheForestDedicatedServer/", Label = "Dedicated Server" },
                new { Url = "https://modapi.survivetheforest.net/mods/game/TheForestVR/", Label = "VR" }
            };

            var allMods = new List<ModInfo>();

            foreach (var source in sources)
            {
                var html = FetchHtml(source.Url);
                var mods = ParseModsFromHtml(html, source.Label);
                allMods.AddRange(mods);
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

            DownloadStatusText.Text = string.Format("{0} mods", filteredList.Count);
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
        };

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
                    LoadModsFromWeb();
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
                        DownloadStatusText.Text = string.Format("{0} versions", versions.Count);
                    }
                    else
                    {
                        DownloadStatusText.Text = string.Format("HTML:{0} Btn:{1} Ver:{2} DL:{3}", htmlLen, btnCount, verCount, dlLinkCount);
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
            DownloadStatusText.Text = FindResource("Lang.Downloads.Status.Downloading") as string;

            var thread = new Thread(() =>
            {
                try
                {
                    var success = DownloadModFile(selectedVersion.ModId, selectedVersion.FileId, selectedVersion.GameShortName);
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            DownloadButton.IsEnabled = true;
                            DownloadStatusText.Text = success
                                ? (FindResource("Lang.Downloads.Status.Complete") as string)
                                : (FindResource("Lang.Downloads.Status.Error") as string);
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
                            DownloadStatusText.Text = FindResource("Lang.Downloads.Status.Error") as string;
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
                    var modsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mods", gameShortName);
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