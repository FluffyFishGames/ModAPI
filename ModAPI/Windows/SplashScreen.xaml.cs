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
        private DispatcherTimer Timer;
        public static float Progress;
        public const float GUIDeltaTime = 1f / 60f; // 60 fps
        private float ShownProgress;
        private RectangleGeometry ClipRect;
        private float Alpha = 1f;

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

            ClipRect = (RectangleGeometry) FindName("LoadingRect");
            Timer = new DispatcherTimer();
            Timer.Tick += GUITick;
            Timer.Interval = new TimeSpan((long) (GUIDeltaTime * 10000000));
            Timer.Start();
        }

        protected bool loadingWindow;
        protected bool windowLoaded;
        protected MainWindow window;
        protected ProgressHandler GUIProgress;
        protected Thread MainWindowThread;

        public void GUITick(object sender, EventArgs e)
        {
            if (!loadingWindow && Progress >= 70f)
            {
                Debug.Log("SplashScreen", "Preparing and opening main window.");
                GUIProgress = new ProgressHandler();
                GUIProgress.OnChange += delegate { Progress = 70f + (GUIProgress.Progress / 100f * 30f); };
                GUIProgress.OnComplete += delegate { windowLoaded = true; };
                loadingWindow = true;
                MainWindowThread = new Thread(ShowWindow);
                MainWindowThread.SetApartmentState(ApartmentState.STA);
                //MainWindowThread.IsBackground = true;
                MainWindowThread.Start();
            }
            if (ShownProgress == 100f && Alpha > 0f)
            {
                if (windowLoaded)
                {
                    MainWindow.BlendIn = true;
                    Alpha -= 5f * GUIDeltaTime;
                    if (Alpha <= 0f)
                    {
                        Alpha = 0f;
                        Hide();
                        //Close();
                    }
                }
            }
            Opacity = Alpha;
            if (ShownProgress < Progress)
            {
                ShownProgress += 200f * GUIDeltaTime;
                if (ShownProgress > Progress)
                {
                    ShownProgress = Progress;
                }
            }
            ClipRect.Rect = new Rect(0, 0, (ShownProgress / 100f) * 620f, 180f);
        }

        void ShowWindow()
        {
            try
            {
                window = new MainWindow();
                window.Loaded += window_Loaded;
                window.Show();
                Dispatcher.Run();
            }
            catch (Exception e)
            {
                Debug.Log("SplashScreen", "Unexpected exception occured while preparing main window: " + e, Debug.Type.ERROR);
            }
        }

        void window_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.Log("SplashScreen", "Main window loaded. Warming up GUI.");
            try
            {
                ((MainWindow) sender).Preload(GUIProgress);
            }
            catch (Exception ex)
            {
                Debug.Log("SplashScreen", "Unexpected exception occured while preparing main window: " + ex, Debug.Type.ERROR);
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
