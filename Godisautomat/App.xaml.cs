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

namespace Godisautomat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
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

            // Log it
            //IoC.Logger.Log("Application starting...", LogLevel.Debug);

            // Set up YAML config file(s).
            IoC.Application.CandyCategories = await YamlHelper.SetUpConfigFile($"{AppDomain.CurrentDomain.BaseDirectory}Configs");
            
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
