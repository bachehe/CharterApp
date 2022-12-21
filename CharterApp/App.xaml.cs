using CharterApp.Models;
using CharterApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CharterApp
{
    public partial class App : Application
    {
        public App()
        {
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception)e.ExceptionObject;

            string errorMsg = string.Format($"An unhandled exception occured: {ex.Message}");
            MessageBox.Show(errorMsg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void App_Startup(object sender, StartupEventArgs args)
        {
            ContainerConfig.Configure();

            var viewModel = ContainerConfig.Resolve<MainWindowViewModel>();

            MainWindow = new MainWindow(viewModel);

            RunApp();
        }

        private void RunApp()
        {
            MainWindow.Show();
        }
    }
}
