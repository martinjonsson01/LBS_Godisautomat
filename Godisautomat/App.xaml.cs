using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Godisautomat.IoCComponents.Base;
using Dna;
using Godisautomat.IoCComponents.Interfaces;
using Godisautomat.TaskComponents;
using Godisautomat.Helpers.YAML;
using System.IO;
using System.Windows.Media.Imaging;
using System.Net.Cache;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using Godisautomat.ViewModels;
using Godisautomat.Animation;

namespace Godisautomat
{
    internal struct LASTINPUTINFO
    {
        public uint cbSize;
        public uint dwTime;
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        DispatcherTimer IdleTimer = new DispatcherTimer();

        private static List<BitmapImage> _cachedImages = new List<BitmapImage>();

        [DllImport("User32.dll")]
        public static extern bool LockWorkStation();
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO Dummy);
        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();

        /// <summary>
        /// Custom startup so we load our IoC immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            // Let the base application do what it needs.
            base.OnStartup(e);

            // Fix FPS.
            Timeline.DesiredFrameRateProperty.OverrideMetadata(
                typeof(Timeline),
                new FrameworkPropertyMetadata { DefaultValue = 60 }
               );

            // Setup the main application 
            ApplicationSetupAsync();

            // Set up YAML config file(s).
            IoC.Application.CandyCategories = await YamlHelper.LoadConfigFile($"{AppDomain.CurrentDomain.BaseDirectory}");

            // Pre-cache images.
            foreach (var category in IoC.Application.CandyCategories)
            {
                _cachedImages.Add(new BitmapImage(new Uri(category.ImageUrl), new HttpRequestCachePolicy(new DateTime(10000000))));
                foreach (var type in category.CandyTypes)
                {
                    _cachedImages.Add(new BitmapImage(new Uri(type.ImageUrl), new HttpRequestCachePolicy(new DateTime(10000000))));
                }
            }

            // Setup the application view model.
            IoC.Application.GoToPage(DataModels.ApplicationPage.Categories, new CategoriesViewModel { PageLoadAnimation = PageAnimation.None, PageUnloadAnimation = PageAnimation.SlideOutToRight});

            // Set up idle timer.
            IdleTimer.Interval = new TimeSpan(0, 0, 1);
            IdleTimer.Tick += (sender, arg) =>
            {
                // If UI has been idle for 30 seconds.
                if (GetIdleTime() > 30 * 1000)
                {
                    // Go back to main screen.
                    IoC.Application.GoToPage(DataModels.ApplicationPage.Categories);
                    IoC.Application.DarkeningGridOpacity = 0;
                    IoC.Application.PayButtonVisibility = Visibility.Hidden;
                }
            };
            IdleTimer.Start();
        }

        /// <summary>
        /// Configures our application ready for use
        /// </summary>
        private void ApplicationSetupAsync()
        {
            // Setup the Dna Framework
            new DefaultFrameworkConstruction()
                //.UseFileLogger()
                //.UseClientDataStore()
                .Build();

            // Setup IoC
            IoC.Setup();

            // Add our task manager
            IoC.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());
        }


        public static uint GetIdleTime()
        {
            LASTINPUTINFO LastUserAction = new LASTINPUTINFO();
            LastUserAction.cbSize = (uint)Marshal.SizeOf(LastUserAction);
            GetLastInputInfo(ref LastUserAction);
            return ((uint)Environment.TickCount - LastUserAction.dwTime);
        }

        public static long GetTickCount()
        {
            return Environment.TickCount;
        }

        public static long GetLastInputTime()
        {
            LASTINPUTINFO LastUserAction = new LASTINPUTINFO();
            LastUserAction.cbSize = (uint)Marshal.SizeOf(LastUserAction);
            if (!GetLastInputInfo(ref LastUserAction))
            {
                throw new Exception(GetLastError().ToString());
            }

            return LastUserAction.dwTime;
        }

    }
}
