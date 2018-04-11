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

namespace Godisautomat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static List<BitmapImage> _cachedImages = new List<BitmapImage>();

        /// <summary>
        /// Custom startup so we load our IoC immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            // Let the base application do what it needs
            base.OnStartup(e);

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
            IoC.Application.GoToPage(DataModels.ApplicationPage.Categories);
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
    }
}
