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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ModAPI.Components;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Controls.Primitives;
using ModAPI.Configurations;
using ModAPI.Components.Panels;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Net;

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

        protected bool FirstSetup = false;

        protected static List<Window> windowQueue = new List<Window>();
        protected static Window currentWindow = null;
        protected static bool positionWindow = false;
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
                        currentWindow.Show();
                    currentWindow.UpdateLayout();
                    windowQueue.RemoveAt(0);
                    MainWindow.Instance.Focusable = false;
                }
                else
                {
                    MainWindow.Instance.Focusable = true;
                }
            }
        }
        static void PositionSubWindow(object sender, EventArgs e)
        {
            if (positionWindow)
            {
                Window window = (Window)sender;
                if (window.IsVisible)
                {
                    window.Left = MainWindow.Instance.Left + MainWindow.Instance.ActualWidth / 2.0 - window.ActualWidth / 2.0;
                    window.Top = MainWindow.Instance.Top + MainWindow.Instance.ActualHeight / 2.0 - window.ActualHeight / 2.0;
                    window.Opacity = 1.0;
                    positionWindow = false;
                }
            }
        }

        static void SubWindowClosed(object sender, EventArgs e)
        {
            windowQueue.Remove((Window)sender);
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
                return;

            App.Game = new Data.Game(Configuration.Games[Configuration.CurrentGame]);
            App.Game.OnModlibUpdate += (s, e) => Dispatcher.Invoke((Action) delegate() {
                UpdateModlibVersion();
            });
            UpdateModlibVersion();

            ModProjects = new ModProjectsViewModel();
            Mods = new ModsViewModel();
            ModsPanel.DataContext = Mods;
            Development.DataContext = ModProjects;

            Configuration.Save();

            if (Configuration.GetString("AutoUpdate").ToLower() == "true")
            {
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create("http://www.modapi.de/app/lastVersion.txt");
                WebReq.Method = "GET";
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
                Stream Answer = WebResp.GetResponseStream();
                StreamReader _Answer = new StreamReader(Answer);
                string answer = _Answer.ReadToEnd();
                if (answer != ModAPI.Version.Number + "")
                {
                    ModAPI.Windows.SubWindows.UpdateAvailable win = new ModAPI.Windows.SubWindows.UpdateAvailable("Lang.Windows.UpdateAvailable", answer);
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
                    Utils.Schedule.AddTask("GUI", "SpecifySteamPath", FirstSetupDone, CheckSteam);
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
            string SteamPath = Configuration.GetPath("Steam");
            if (!System.IO.File.Exists(SteamPath + System.IO.Path.DirectorySeparatorChar + "Steam.exe"))
            {
                SteamPath = SearchSteam();
                Configuration.SetPath("Steam", SteamPath, true);
            }
            return System.IO.File.Exists(SteamPath + System.IO.Path.DirectorySeparatorChar + "Steam.exe");
        }

        protected string SearchSteam()
        {
            string SteamPath = (string) Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam\\","SteamPath", "");
            if (!System.IO.File.Exists(SteamPath + System.IO.Path.DirectorySeparatorChar + "Steam.exe"))
            {
                SteamPath = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam\\","SteamExe", "");
                if (System.IO.File.Exists(SteamPath))
                {
                    SteamPath = System.IO.Path.GetDirectoryName(SteamPath);
                }
            }
            return SteamPath;
        }

        public ModProjectsViewModel ModProjects;
        protected List<string> Languages = new List<string>() { "EN", "DE", "AR", "BN", "ZH", "FR", "HI", "IT", "JA", "KO", "PT", "RU", "ES", "TR", "VI" };
        protected Dictionary<string, ComboBoxItem> LanguageItems = new Dictionary<string, ComboBoxItem>();
        protected SettingsViewModel SettingsVM;

        protected void ShowLoginLoader()
        {
            Dispatcher.Invoke(delegate()
            {
                LoginButton.Visibility = System.Windows.Visibility.Collapsed;
                LoginLoader.Visibility = System.Windows.Visibility.Visible;
                LoggedIn.Visibility = System.Windows.Visibility.Collapsed;
            });
        }

        protected void ShowLoginUser(ModAPI.Utils.WebService.User user)
        {
            Dispatcher.Invoke(delegate() {
                LoginButton.Visibility = System.Windows.Visibility.Collapsed;
                LoginLoader.Visibility = System.Windows.Visibility.Collapsed;
                LoggedIn.Visibility = System.Windows.Visibility.Visible;
                UserAvatarLoader.Visibility = System.Windows.Visibility.Visible;
                System.Console.WriteLine(user.Usergroup);
                Usergroup.SetResourceReference(TextBlock.TextProperty, "Lang.UserGroup." + user.Usergroup);
                Username.Text = user.Username;
                user.OnAvatarChange = AvatarChange;
                user.LoadAvatar();
            });
        }

        protected void AvatarChange()
        {
            this.Dispatcher.Invoke(delegate()
            {
                UserAvatarLoader.Visibility = System.Windows.Visibility.Collapsed;
                BitmapImage Avatar = new BitmapImage();
                Avatar.BeginInit();
                if (ModAPI.Utils.WebService.CurrentUser.Avatar == null)
                {
                    Avatar.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/noAvatar.png");
                }
                else
                {
                    Avatar.StreamSource = ModAPI.Utils.WebService.CurrentUser.Avatar;
                }
                Avatar.CacheOption = BitmapCacheOption.OnLoad;
                Avatar.EndInit();
                UserAvatar.Source = Avatar;
                UserAvatar.InvalidateProperty(Image.SourceProperty);
            });
        }
        
        protected void ShowLoginError(int id, string text)
        {
            Dispatcher.Invoke(delegate()
            {
                ShowLogin();
                ModAPI.Windows.SubWindows.LoginWindow win = new ModAPI.Windows.SubWindows.LoginWindow("Lang.Windows.Login", true);
                win.ShowSubWindow();
            });
        }

        protected void ShowLogin()
        {
            Dispatcher.Invoke(delegate()
            {
                LoginButton.Visibility = System.Windows.Visibility.Visible;
                LoginLoader.Visibility = System.Windows.Visibility.Collapsed;
                LoggedIn.Visibility = System.Windows.Visibility.Collapsed;
            });
        }

        public MainWindow()
        {
            //System.Console.WriteLine("AAA");
            if (Configuration.Languages["en"] != null)
                App.Instance.Resources.MergedDictionaries.Add(Configuration.Languages["en"].Resource);
            InitializeComponent();
            Instance = this;

            ModAPI.Utils.WebService.OnDoLogin = ShowLoginLoader;
            ModAPI.Utils.WebService.OnLogin = ShowLoginUser;
            ModAPI.Utils.WebService.OnLoginError = ShowLoginError;
            ModAPI.Utils.WebService.OnLogout = ShowLogin;
            ModAPI.Utils.WebService.Initialize();

            foreach (string LangCode in Languages)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Style = Application.Current.FindResource("ComboBoxItem") as Style;
                newItem.DataContext = LangCode;
                LanguageItems.Add(LangCode, newItem);
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Horizontal;
                Image image = new Image();
                image.Height = 20;
                BitmapImage source = new BitmapImage();
                source.BeginInit();
                source.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/Lang_"+LangCode+".png");
                source.EndInit();
                image.Source = source;
                image.Margin = new Thickness(0,0,5,0);
                panel.Children.Add(image);

                TextBlock label = new TextBlock();
                label.SetResourceReference(TextBlock.TextProperty, "Lang.Languages." + LangCode);
                panel.Children.Add(label);

                newItem.Content = panel;
                DevelopmentLanguageSelector.Items.Add(newItem);
            }

            FirstSetup = Configuration.GetString("SetupDone").ToLower() != "true";
            if (FirstSetup)
            {
                ModAPI.Windows.SubWindows.FirstSetup win = new ModAPI.Windows.SubWindows.FirstSetup("Lang.Windows.FirstSetup");
                win.ShowSubWindow();
                win.Show();
            }
            else
            {
                FirstSetupDone();
            }

            Configuration.OnLanguageChanged += LanguageChanged;

            foreach (Configuration.Language language in Configuration.Languages.Values)
            {
                AddLanguage(language);
            }

            SettingsVM = new SettingsViewModel();
            Settings.DataContext = SettingsVM;
            //LanguageSelector.SelectedIndex = Configuration.Languages.Values.ToList().IndexOf(Configuration.CurrentLanguage);

            foreach (GUIConfiguration.Tab tab in GUIConfiguration.Tabs)
            {
                IconTabItem newTab = new IconTabItem();
                Style style = App.Instance.Resources["TopTab"] as Style;
                newTab.Style = style;

                try
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri("pack://application:,,,/ModAPI;component/resources/textures/Icons/" + tab.IconName);
                    image.EndInit();
                    newTab.IconSource = image;
                }
                catch (Exception e)
                {
                    Debug.Log("MainWindow", "Couldn't find the icon \""+tab.IconName+"\".", Debug.Type.WARNING);
                }
                try
                {
                    BitmapImage imageSelected = new BitmapImage();
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
                IPanel newPanel = (IPanel)Activator.CreateInstance(tab.ComponentType);
                newTab.Content = newPanel;
                Debug.Log("MainWindow", "Added tab of type \"" + tab.TypeName + "\".");
                newPanel.SetTab(tab);
                Panels.Add(newPanel);
                Tabs.Items.Add(newTab);
            }

            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(GUITick);
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
                List<Utils.Schedule.Task> Tasks = Utils.Schedule.GetTasks("GUI");
                foreach (Utils.Schedule.Task task in Tasks)
                {
                    if (!task.BeingHandled)
                    {
                        switch (task.Name)
                        {
                            case "SpecifyGamePath":
                                ModAPI.Windows.SubWindows.SpecifyGamePath win = new ModAPI.Windows.SubWindows.SpecifyGamePath("Lang.Windows.SpecifyGamePath", task);
                                win.ShowSubWindow();
                                //win.Show();
                                task.BeingHandled = true;
                                break;
                            case "SpecifySteamPath":
                                ModAPI.Windows.SubWindows.SpecifySteamPath win2 = new ModAPI.Windows.SubWindows.SpecifySteamPath("Lang.Windows.SpecifySteamPath", task);
                                win2.ShowSubWindow();
                                //win2.Show();
                                task.BeingHandled = true;
                                break;
                            case "RestoreGameFiles":
                                ModAPI.Windows.SubWindows.RestoreGameFiles win3 = new ModAPI.Windows.SubWindows.RestoreGameFiles("Lang.Windows.RestoreGameFiles", task);
                                win3.ShowSubWindow();
                                //win3.Show();
                                task.BeingHandled = true;
                                break;
                            case "OperationPending":
                                ModAPI.Windows.SubWindows.OperationPending win4 = new ModAPI.Windows.SubWindows.OperationPending("Lang.Windows.OperationPending", task);
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
                if (FadeBackground.Visibility == System.Windows.Visibility.Collapsed)
                    FadeBackground.Visibility = System.Windows.Visibility.Visible;
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
                        FadeBackground.Visibility = System.Windows.Visibility.Collapsed;
                    }
                }
            }
        }

        void LanguageChanged()
        {
            if (CurrentLanguage != null)
                App.Instance.Resources.MergedDictionaries.Remove(CurrentLanguage);

            CurrentLanguage = Configuration.CurrentLanguage.Resource;
            App.Instance.Resources.MergedDictionaries.Add(CurrentLanguage);
            UpdateModlibVersion();
        }

        void AddLanguage(Configuration.Language language)
        {
            ComboBoxItem c = new ComboBoxItem();
            c.Style = Application.Current.FindResource("ComboBoxItem") as Style;
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            c.Content = panel;

            if (language.ImageStream != null)
            {
                Image i = new Image();
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = language.ImageStream;
                img.EndInit();
                i.Source = img;
                i.Margin = new Thickness(0, 0, 10, 0);

                panel.Children.Add(i);
            }

            TextBlock text = new TextBlock();

            text.VerticalAlignment = VerticalAlignment.Center;
            text.Text = language.Resource["LangName"] as String;

            panel.Children.Add(text);
            LanguageSelector.Items.Add(c);
        }

        public Dictionary<int, int> BuildingToIndex = new Dictionary<int, int>();
        public Dictionary<int, int> IndexToBuilding = new Dictionary<int, int>();
        protected Dictionary<int, ToggleButton> BuildingButtons = new Dictionary<int, ToggleButton>();

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement)this.FindName("Mover")).MouseLeftButtonDown += new MouseButtonEventHandler(MoveWindow);

            if (WindowState == System.Windows.WindowState.Maximized)
            {
                ((Button)FindName("MaximizeButton")).Visibility = System.Windows.Visibility.Hidden;
                ((Button)FindName("MaximizeButton")).Width = 0;
            }
            else
            {
                ((Button)FindName("NormalizeButton")).Visibility = System.Windows.Visibility.Hidden;
                ((Button)FindName("NormalizeButton")).Width = 0;
            }

            VersionLabel.Text = ModAPI.Version.Descriptor+" ["+ModAPI.Version.Number+"]";


        }

        public Dictionary<string, Grid> InventoryElements = new Dictionary<string, Grid>();

        private void MoveWindow(object sender, MouseButtonEventArgs args)
        {
            DragMove();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Minimized;
        }

        private void Normalize(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Normal;
            ((Button)FindName("MaximizeButton")).Visibility = System.Windows.Visibility.Visible;
            ((Button)FindName("MaximizeButton")).Width = 24;
            ((Button)FindName("NormalizeButton")).Visibility = System.Windows.Visibility.Hidden;
            ((Button)FindName("NormalizeButton")).Width = 0;
        }

        private void Maximize(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Maximized;
            ((Button)FindName("MaximizeButton")).Visibility = System.Windows.Visibility.Hidden;
            ((Button)FindName("MaximizeButton")).Width = 0;
            ((Button)FindName("NormalizeButton")).Visibility = System.Windows.Visibility.Visible;
            ((Button)FindName("NormalizeButton")).Width = 24;
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
            ToggleButton button = (ToggleButton)sender;
            /*BuildingSelect.SelectedIndex = BuildingToIndex[(int) button.DataContext];

            BuildingSelect.IsDropDownOpen = false;*/
        }

        private void BuildingSelect_DropDownOpened(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int, ToggleButton> button in BuildingButtons)
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
                e.Handled = true;
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

        bool AltDown = false;
        bool CtrlDown = false;

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftAlt)
                AltDown = false;
            if (e.Key == Key.LeftCtrl)
                CtrlDown = false;
        }

        private void Tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void IconTabItem_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public void Preload(ProgressHandler handler)
        {
            handler.OnComplete += delegate
            {
                Debug.Log("MainWindow", "GUI is ready.");
            };
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
            ModAPI.Windows.SubWindows.CreateModProject win = new ModAPI.Windows.SubWindows.CreateModProject("Lang.Windows.CreateModProject");
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
                SelectedMod.Visibility = System.Windows.Visibility.Visible;
                NoModSelected.Visibility = System.Windows.Visibility.Collapsed;
                SelectedMod.DataContext = model;
            }
            else
            {
                SelectedMod.Visibility = System.Windows.Visibility.Collapsed;
                NoModSelected.Visibility = System.Windows.Visibility.Visible;
                SelectedMod.DataContext = null;
            }
        }

        public void SetProject(ModProjectViewModel model)
        {
            CurrentModProjectViewModel = model;
            DevelopmentLanguageSelector.SelectedIndex = -1;
            foreach (KeyValuePair<string, ComboBoxItem> kv in LanguageItems)
            {
                bool a = model.Project.Languages.Contains(kv.Key);
                kv.Value.Visibility = a ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
                kv.Value.IsEnabled = !a;
            }
            
            if (model != null)
            {
                SelectedProject.Visibility = System.Windows.Visibility.Visible;
                NoProjectSelected.Visibility = System.Windows.Visibility.Collapsed;
                SelectedProject.DataContext = model;
            }
            else
            {
                SelectedProject.Visibility = System.Windows.Visibility.Collapsed;
                NoProjectSelected.Visibility = System.Windows.Visibility.Visible;
                SelectedProject.DataContext = null;
            }
        }

        private void AddProjectLanguage(object sender, RoutedEventArgs e)
        {
            if (CurrentModProjectViewModel != null)
            {
                CurrentModProjectViewModel.AddProjectLanguage((string) (((ComboBoxItem)DevelopmentLanguageSelector.SelectedItem).DataContext));
                DevelopmentLanguageSelector.SelectedIndex = -1;
                foreach (KeyValuePair<string, ComboBoxItem> kv in LanguageItems)
                {
                    bool a = CurrentModProjectViewModel.Project.Languages.Contains(kv.Key);
                    kv.Value.Visibility = a ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
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
                ModAPI.Windows.SubWindows.RemoveModProject win = new ModAPI.Windows.SubWindows.RemoveModProject("Lang.Windows.RemoveModProject", CurrentModProjectViewModel.Project.ID, CurrentModProjectViewModel.Project);
                win.Confirm = delegate(object obj)
                {
                    ProjectList.SelectedIndex = -1;
                    NoProjectSelected.Visibility = Visibility.Visible;
                    SelectedProject.DataContext = null;
                    SelectedProject.Visibility = Visibility.Collapsed;
                    ModProjects.Remove((ModAPI.Data.Models.ModProject)obj);
                };
                win.ShowSubWindow();
                win.Show();
            }
        }

        private void CreateMod(object sender, RoutedEventArgs e)
        {
            if (CurrentModProjectViewModel != null)
            {
                ProgressHandler progressHandler = new ProgressHandler();
                Thread thread = new Thread(delegate() {
                    CurrentModProjectViewModel.Project.Create(progressHandler);
                });
                ModAPI.Windows.SubWindows.OperationPending window = new ModAPI.Windows.SubWindows.OperationPending("Lang.Windows.OperationPending", "CreateMod", progressHandler);
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
            List<Data.Mod> mods = new List<Data.Mod>();
            foreach (ListViewItem i in Mods.Mods)
            {
                ModViewModel vm = (ModViewModel)i.DataContext;
                if (vm != null && vm.Selected)
                {
                    ModVersionViewModel vm2 = (ModVersionViewModel)vm.SelectedVersion.DataContext;
                    if (vm2 != null)
                    {
                        mods.Add(vm2.mod);
                    }
                }
            }
            ProgressHandler progressHandler = new ProgressHandler();
            progressHandler.OnComplete += (object o, EventArgs ex) => {
                if (Configuration.GetString("UseSteam") == "true" && App.Game.GameConfiguration.SteamAppID != "")
                {
                
                    Process p = new Process();
                    p.StartInfo.FileName = Configuration.GetPath("Steam") + System.IO.Path.DirectorySeparatorChar + "Steam.exe";
                    p.StartInfo.Arguments = "-applaunch "+App.Game.GameConfiguration.SteamAppID;
                    p.Start();
                } 
                else 
                {
                    Process p = new Process();
                    p.StartInfo.FileName = App.Game.GamePath + System.IO.Path.DirectorySeparatorChar + App.Game.GameConfiguration.SelectFile;
                    p.Start();
                }
            };

            Thread thread = new Thread(delegate()
            {
                App.Game.ApplyMods(mods, progressHandler);
                
            });
            ModAPI.Windows.SubWindows.OperationPending window = new ModAPI.Windows.SubWindows.OperationPending("Lang.Windows.OperationPending", "ApplyMods", progressHandler, null, true);
            if (!window.Completed)
            {
                window.ShowSubWindow();
                window.Show();
            }
            thread.Start();
            
        }

        private void ClickFacebook(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.facebook.com/SouldrinkerLP");
        }

        private void ClickTwitter(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.twitter.com/SouldrinkerLP");
        }

        private void ClickYouTube(object sender, RoutedEventArgs e)
        {

            System.Diagnostics.Process.Start("http://www.youtube.com/SouldrinkerLP");
        }

        private void ClickTwitch(object sender, RoutedEventArgs e)
        {

            System.Diagnostics.Process.Start("http://live.souldrinker.de");
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Environment.Exit(0);
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            ModAPI.Windows.SubWindows.LoginWindow win = new ModAPI.Windows.SubWindows.LoginWindow("Lang.Windows.Login");
            win.ShowSubWindow();
        }

        private void DoLogout(object sender, RoutedEventArgs e)
        {
            Utils.WebService.Logout();
        }
        
    }
}
