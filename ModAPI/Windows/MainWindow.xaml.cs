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
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
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

        public static MainWindow Instance;
        public List<IPanel> Panels = new List<IPanel>();
        protected Dictionary<string, ComboBoxItem> DevelopmentLanguagesItems;

        public const float GUIDeltaTime = 1f / 60f; // 60 fps

        protected bool FirstSetup;

        protected static List<Window> windowQueue = new List<Window>();
        protected static Window currentWindow;
        protected static bool positionWindow;

        public static void OpenWindow(Window window)
        {
            window.Closed += SubWindowClosed;
            window.ContentRendered += PositionSubWindow;
            //window.IsVisibleChanged += PositionSubWindow;
            windowQueue.Add(window);
            NextWindow();
        }

        static void NextWindow()
        {
            if (currentWindow == null)
            {
                if (windowQueue.Count > 0)
                {
                    positionWindow = true;
                    currentWindow = windowQueue[0];
                    currentWindow.Opacity = 0.0;
                    if (currentWindow.IsEnabled)
                    {
                        currentWindow.Show();
                    }
                    currentWindow.UpdateLayout();
                    windowQueue.RemoveAt(0);
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
            if (positionWindow)
            {
                var window = (Window) sender;
                if (window.IsVisible)
                {
                    window.Left = Instance.Left + Instance.ActualWidth / 2.0 - window.ActualWidth / 2.0;
                    window.Top = Instance.Top + Instance.ActualHeight / 2.0 - window.ActualHeight / 2.0;
                    window.Opacity = 1.0;
                    positionWindow = false;
                }
            }
        }

        static void SubWindowClosed(object sender, EventArgs e)
        {
            windowQueue.Remove((Window) sender);
            if (currentWindow == sender)
            {
                currentWindow = null;
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

            if (Configuration.GetString("AutoUpdate").ToLower() == "true")
            {
                var WebReq = (HttpWebRequest) WebRequest.Create("http://www.modapi.cc/app/lastVersion.txt");
                WebReq.Method = "GET";
                var WebResp = (HttpWebResponse) WebReq.GetResponse();
                var Answer = WebResp.GetResponseStream();
                var _Answer = new StreamReader(Answer);
                var answer = _Answer.ReadToEnd();
                if (answer != Version.Number + "")
                {
                    var win = new UpdateAvailable("Lang.Windows.UpdateAvailable", answer);
                    win.ShowSubWindow();
                }
            }
        }

        public bool CheckSteamPath()
        {
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
                    ModLibModAPIVersion.Text = App.Game.ModLibrary.ModAPIVersion;
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
            var SteamPath = Configuration.GetPath("Steam");
            if (!File.Exists(SteamPath + Path.DirectorySeparatorChar + "Steam.exe"))
            {
                SteamPath = SearchSteam();
                Configuration.SetPath("Steam", SteamPath, true);
            }
            return File.Exists(SteamPath + Path.DirectorySeparatorChar + "Steam.exe");
        }

        protected string SearchSteam()
        {
            var SteamPath = (string) Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam\\", "SteamPath", "");
            if (!File.Exists(SteamPath + Path.DirectorySeparatorChar + "Steam.exe"))
            {
                SteamPath = (string) Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam\\", "SteamExe", "");
                if (File.Exists(SteamPath))
                {
                    SteamPath = Path.GetDirectoryName(SteamPath);
                }
            }
            return SteamPath;
        }

        public ModProjectsViewModel ModProjects;
        protected List<string> Languages = new List<string> { "EN", "DE", "AR", "BN", "ZH", "FR", "HI", "IT", "JA", "KO", "PT", "RU", "ES", "TR", "VI" };
        protected Dictionary<string, ComboBoxItem> LanguageItems = new Dictionary<string, ComboBoxItem>();
        protected SettingsViewModel SettingsVM;

        protected void ShowLoginLoader()
        {
            Dispatcher.Invoke(delegate
            {
                LoginButton.Visibility = Visibility.Collapsed;
                LoginLoader.Visibility = Visibility.Visible;
                LoggedIn.Visibility = Visibility.Collapsed;
            });
        }

        protected void ShowLoginUser(WebService.User user)
        {
            Dispatcher.Invoke(delegate
            {
                LoginButton.Visibility = Visibility.Collapsed;
                LoginLoader.Visibility = Visibility.Collapsed;
                LoggedIn.Visibility = Visibility.Visible;
                UserAvatarLoader.Visibility = Visibility.Visible;
                Console.WriteLine(user.Usergroup);
                Usergroup.SetResourceReference(TextBlock.TextProperty, "Lang.UserGroup." + user.Usergroup);
                Username.Text = user.Username;
                user.OnAvatarChange = AvatarChange;
                user.LoadAvatar();
            });
        }

        protected void AvatarChange()
        {
            Dispatcher.Invoke(delegate
            {
                UserAvatarLoader.Visibility = Visibility.Collapsed;
                var Avatar = new BitmapImage();
                Avatar.BeginInit();
                if (WebService.CurrentUser.Avatar == null)
                {
                    Avatar.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/noAvatar.png");
                }
                else
                {
                    Avatar.StreamSource = WebService.CurrentUser.Avatar;
                }
                Avatar.CacheOption = BitmapCacheOption.OnLoad;
                Avatar.EndInit();
                UserAvatar.Source = Avatar;
                UserAvatar.InvalidateProperty(Image.SourceProperty);
            });
        }

        protected void ShowLoginError(int id, string text)
        {
            Dispatcher.Invoke(delegate
            {
                ShowLogin();
                var win = new LoginWindow("Lang.Windows.Login", true);
                win.ShowSubWindow();
            });
        }

        protected void ShowLogin()
        {
            Dispatcher.Invoke(delegate
            {
                LoginButton.Visibility = Visibility.Visible;
                LoginLoader.Visibility = Visibility.Collapsed;
                LoggedIn.Visibility = Visibility.Collapsed;
            });
        }

        public MainWindow()
        {
            //System.Console.WriteLine("AAA");
            if (Configuration.Languages["en"] != null)
            {
                App.Instance.Resources.MergedDictionaries.Add(Configuration.Languages["en"].Resource);
            }
            InitializeComponent();
            Instance = this;

            WebService.OnDoLogin = ShowLoginLoader;
            WebService.OnLogin = ShowLoginUser;
            WebService.OnLoginError = ShowLoginError;
            WebService.OnLogout = ShowLogin;
            WebService.Initialize();

            foreach (var LangCode in Languages)
            {
                var newItem = new ComboBoxItem();
                newItem.Style = Application.Current.FindResource("ComboBoxItem") as Style;
                newItem.DataContext = LangCode;
                LanguageItems.Add(LangCode, newItem);
                var panel = new StackPanel();
                panel.Orientation = Orientation.Horizontal;
                var image = new Image();
                image.Height = 20;
                var source = new BitmapImage();
                source.BeginInit();
                source.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/Lang_" + LangCode + ".png");
                source.EndInit();
                image.Source = source;
                image.Margin = new Thickness(0, 0, 5, 0);
                panel.Children.Add(image);

                var label = new TextBlock();

                label.FontSize = 16;
                label.SetResourceReference(TextBlock.TextProperty, "Lang.Languages." + LangCode);
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

            foreach (var language in Configuration.Languages.Values)
            {
                AddLanguage(language);
            }

            SettingsVM = new SettingsViewModel();
            Settings.DataContext = SettingsVM;
            //LanguageSelector.SelectedIndex = Configuration.Languages.Values.ToList().IndexOf(Configuration.CurrentLanguage);

            foreach (var tab in GUIConfiguration.Tabs)
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
                    Debug.Log("MainWindow", "Couldn't find the icon \"" + tab.IconName + "\".", Debug.Type.WARNING);
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
                    Debug.Log("MainWindow", "Couldn't find the icon \"" + tab.IconSelectedName + "\".", Debug.Type.WARNING);
                }

                newTab.SetResourceReference(IconTabItem.LabelProperty, tab.LangPath + ".Tab");
                var newPanel = (IPanel) Activator.CreateInstance(tab.ComponentType);
                newTab.Content = newPanel;
                Debug.Log("MainWindow", "Added tab of type \"" + tab.TypeName + "\".");
                newPanel.SetTab(tab);
                Panels.Add(newPanel);
                Tabs.Items.Add(newTab);
            }

            Timer = new DispatcherTimer();
            Timer.Tick += GUITick;
            Timer.Interval = new TimeSpan((long) (GUIDeltaTime * 10000000));
            Timer.Start();
            LanguageChanged();
            SettingsVM.Changed();
        }

        protected DispatcherTimer Timer;

        void GUITick(object sender, EventArgs e)
        {
            LoginLoaderRotation.Angle += 5;
            UserAvatarLoaderRotation.Angle += 5;
            if (!FirstSetup)
            {
                var Tasks = Schedule.GetTasks("GUI");
                foreach (var task in Tasks)
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
                    Opacity += GUIDeltaTime * 5f;
                    if (Opacity >= 1f)
                    {
                        Opacity = 1f;
                    }
                }
            }

            if (currentWindow != null)
            {
                if (FadeBackground.Visibility == Visibility.Collapsed)
                {
                    FadeBackground.Visibility = Visibility.Visible;
                }
                if (FadeBackground.Opacity < 0.8f)
                {
                    FadeBackground.Opacity += GUIDeltaTime * 5f;
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
                    FadeBackground.Opacity -= GUIDeltaTime * 5f;
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

        void AddLanguage(Configuration.Language language)
        {
            var c = new ComboBoxItem();
            c.Style = Application.Current.FindResource("ComboBoxItem") as Style;
            var panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
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

            var text = new TextBlock();

            text.VerticalAlignment = VerticalAlignment.Center;
            text.Text = language.Resource["LangName"] as String;
            text.FontSize = 16;

            panel.Children.Add(text);
            LanguageSelector.Items.Add(c);
        }

        public Dictionary<int, int> BuildingToIndex = new Dictionary<int, int>();
        public Dictionary<int, int> IndexToBuilding = new Dictionary<int, int>();
        protected Dictionary<int, ToggleButton> BuildingButtons = new Dictionary<int, ToggleButton>();

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement) FindName("Mover")).MouseLeftButtonDown += MoveWindow;

            if (WindowState == WindowState.Maximized)
            {
                ((Button) FindName("MaximizeButton")).Visibility = Visibility.Hidden;
                ((Button) FindName("MaximizeButton")).Width = 0;
            }
            else
            {
                ((Button) FindName("NormalizeButton")).Visibility = Visibility.Hidden;
                ((Button) FindName("NormalizeButton")).Width = 0;
            }

            VersionLabel.Text = Version.Descriptor + " [" + Version.Number + "]";
        }

        public Dictionary<string, Grid> InventoryElements = new Dictionary<string, Grid>();

        private void MoveWindow(object sender, MouseButtonEventArgs args)
        {
            DragMove();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Normalize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
            ((Button) FindName("MaximizeButton")).Visibility = Visibility.Visible;
            ((Button) FindName("MaximizeButton")).Width = 24;
            ((Button) FindName("NormalizeButton")).Visibility = Visibility.Hidden;
            ((Button) FindName("NormalizeButton")).Width = 0;
        }

        private void Maximize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
            ((Button) FindName("MaximizeButton")).Visibility = Visibility.Hidden;
            ((Button) FindName("MaximizeButton")).Width = 0;
            ((Button) FindName("NormalizeButton")).Visibility = Visibility.Visible;
            ((Button) FindName("NormalizeButton")).Width = 24;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
            Environment.Exit(0);
        }

        private void ComboBoxItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void Building_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton) sender;
            /*BuildingSelect.SelectedIndex = BuildingToIndex[(int) button.DataContext];

            BuildingSelect.IsDropDownOpen = false;*/
        }

        private void BuildingSelect_DropDownOpened(object sender, EventArgs e)
        {
            foreach (var button in BuildingButtons)
            {
                button.Value.IsChecked = false;
            }
        }

        private void Window_LayoutUpdated(object sender, EventArgs e)
        {
            /*
            BuildingImage.Visibility = BuildingImage.ActualWidth < 150 ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible;
            double available = BuildingTabGrid.ActualWidth - BuildingList.ActualWidth - 20.0;
            if (available > 0)
            {
                if (available > BuildingValuesGrid.ActualWidth + 150)
                {
                    BuildingValuesColumn.Width = new GridLength(0, GridUnitType.Auto);
                }
                else
                {
                    if (BuildingValuesColumn.ActualWidth != available)
                        BuildingValuesColumn.Width = new GridLength(available);
                }
            }*/
        }

        private void BuildingSelect_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }

        private void BuildingSelect_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Tab)
            {
                e.Handled = true;
            }
        }

        private void BuildingList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            ListBox listBox = (ListBox) sender;
            if (listBox.SelectedItems.Count == 1) 
            {
                BuildingGrid.DataContext = ((ListBoxItem)(listBox.SelectedItem)).DataContext;
            }
            else
            {
                List<SavegameBuildingViewModel> Selected = new List<SavegameBuildingViewModel>();
                foreach (ListBoxItem item in listBox.SelectedItems)
                {
                    Selected.Add((SavegameBuildingViewModel) item.DataContext);
                }
                BuildingGrid.DataContext = new SavegameMultipleBuildingViewModel(Selected);
            }*/
        }

        bool AltDown;
        bool CtrlDown;

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftAlt)
            {
                AltDown = false;
            }
            if (e.Key == Key.LeftCtrl)
            {
                CtrlDown = false;
            }
        }

        private void Tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void IconTabItem_Loaded(object sender, RoutedEventArgs e)
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
            if (currentWindow != null)
            {
                currentWindow.Activate();
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
            App.Game.CreateModLibrary();
        }

        private void CreateProject(object sender, RoutedEventArgs e)
        {
            var win = new CreateModProject("Lang.Windows.CreateModProject");
            win.ShowSubWindow();
            win.Show();
        }

        protected ModProjectViewModel CurrentModProjectViewModel;
        protected ModViewModel CurrentModViewModel;

        public void SetMod(ModViewModel model)
        {
            CurrentModViewModel = model;
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
                CurrentModProjectViewModel.AddProjectLanguage((string) (((ComboBoxItem) DevelopmentLanguageSelector.SelectedItem).DataContext));
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
                    new RemoveModProject("Lang.Windows.RemoveModProject", CurrentModProjectViewModel.Project.ID, CurrentModProjectViewModel.Project);
                win.Confirm = delegate(object obj)
                {
                    ProjectList.SelectedIndex = -1;
                    NoProjectSelected.Visibility = Visibility.Visible;
                    SelectedProject.DataContext = null;
                    SelectedProject.Visibility = Visibility.Collapsed;
                    ModProjects.Remove((ModProject) obj);
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
                var thread = new Thread(delegate() { CurrentModProjectViewModel.Project.Create(progressHandler); });
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
                var vm = (ModViewModel) i.DataContext;
                if (vm != null && vm.Selected)
                {
                    var vm2 = (ModVersionViewModel) vm.SelectedVersion.DataContext;
                    if (vm2 != null)
                    {
                        mods.Add(vm2.mod);
                    }
                }
            }
            var progressHandler = new ProgressHandler();
            progressHandler.OnComplete += (o, ex) =>
            {
                if (Configuration.GetString("UseSteam") == "true" && App.Game.GameConfiguration.SteamAppID != "")
                {
                    var p = new Process();
                    p.StartInfo.FileName = Configuration.GetPath("Steam") + Path.DirectorySeparatorChar + "Steam.exe";
                    p.StartInfo.Arguments = "-applaunch " + App.Game.GameConfiguration.SteamAppID;
                    p.Start();
                }
                else
                {
                    var p = new Process();
                    p.StartInfo.FileName = App.Game.GamePath + Path.DirectorySeparatorChar + App.Game.GameConfiguration.SelectFile;
                    p.Start();
                }
            };

            var thread = new Thread(delegate() { App.Game.ApplyMods(mods, progressHandler); });
            var window = new OperationPending("Lang.Windows.OperationPending", "ApplyMods", progressHandler, null, true);
            if (!window.Completed)
            {
                window.ShowSubWindow();
                window.Show();
            }
            thread.Start();
        }

        private void ClickFacebook(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.facebook.com/SouldrinkerLP");
        }

        private void ClickTwitter(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.twitter.com/SouldrinkerLP");
        }

        private void ClickYouTube(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.youtube.com/SouldrinkerLP");
        }

        private void ClickTwitch(object sender, RoutedEventArgs e)
        {
            Process.Start("http://live.souldrinker.de");
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Environment.Exit(0);
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            var win = new LoginWindow("Lang.Windows.Login");
            win.ShowSubWindow();
        }

        private void DoLogout(object sender, RoutedEventArgs e)
        {
            WebService.Logout();
        }
    }
}
