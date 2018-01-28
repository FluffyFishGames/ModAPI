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
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace ModAPI
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        private DispatcherTimer _timer;
        public static float Progress;
        public const float GuiDeltaTime = 1f / 60f; // 60 fps
        private float _shownProgress;
        private RectangleGeometry _clipRect;
        private float _alpha = 1f;

        public SplashScreen()
        {
            AssemblyResolver.Initialize();
            InitializeComponent();
            Preloader.Load();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs args)
        {
            DragMove();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement) FindName("ForegroundImage")).MouseLeftButtonDown += MoveWindow;
            ((FrameworkElement) FindName("BackgroundImage")).MouseLeftButtonDown += MoveWindow;

            _clipRect = (RectangleGeometry) FindName("LoadingRect");
            _timer = new DispatcherTimer();
            _timer.Tick += GuiTick;
            _timer.Interval = new TimeSpan((long) (GuiDeltaTime * 10000000));
            _timer.Start();
        }

        protected bool LoadingWindow;
        protected bool windowLoaded;
        protected MainWindow Window;
        protected ProgressHandler GuiProgress;
        protected Thread MainWindowThread;

        public void GuiTick(object sender, EventArgs e)
        {
            if (!LoadingWindow && Progress >= 70f)
            {
                Debug.Log("SplashScreen", "Preparing and opening main window.");
                GuiProgress = new ProgressHandler();
                GuiProgress.OnChange += delegate { Progress = 70f + (GuiProgress.Progress / 100f * 30f); };
                GuiProgress.OnComplete += delegate { windowLoaded = true; };
                LoadingWindow = true;
                MainWindowThread = new Thread(ShowWindow);
                MainWindowThread.SetApartmentState(ApartmentState.STA);
                //MainWindowThread.IsBackground = true;
                MainWindowThread.Start();
            }
            if (_shownProgress == 100f && _alpha > 0f)
            {
                if (windowLoaded)
                {
                    MainWindow.BlendIn = true;
                    _alpha -= 5f * GuiDeltaTime;
                    if (_alpha <= 0f)
                    {
                        _alpha = 0f;
                        Hide();
                        //Close();
                    }
                }
            }
            Opacity = _alpha;
            if (_shownProgress < Progress)
            {
                _shownProgress += 200f * GuiDeltaTime;
                if (_shownProgress > Progress)
                {
                    _shownProgress = Progress;
                }
            }
            _clipRect.Rect = new Rect(0, 0, (_shownProgress / 100f) * 620f, 180f);
        }

        void ShowWindow()
        {
            try
            {
                Window = new MainWindow();
                Window.Loaded += window_Loaded;
                Window.Show();
                Dispatcher.Run();
            }
            catch (Exception e)
            {
                Debug.Log("SplashScreen", "Unexpected exception occured while preparing main window: " + e, Debug.Type.Error);
            }
        }

        void window_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.Log("SplashScreen", "Main window loaded. Warming up GUI.");
            try
            {
                ((MainWindow) sender).Preload(GuiProgress);
            }
            catch (Exception ex)
            {
                Debug.Log("SplashScreen", "Unexpected exception occured while preparing main window: " + ex, Debug.Type.Error);
            }
        }

        private void WindowActivated(object sender, EventArgs e)
        {
            Topmost = true;
        }

        private void WindowDeactivated(object sender, EventArgs e)
        {
            Topmost = true;
            Activate();
        }
    }
}
