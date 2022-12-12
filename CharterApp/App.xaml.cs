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
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IGeometry? _geometry;
        private static IGeometryType _geometryType;
        private static IParametr _parametr;
        private static IGraphViewModel _graphViewModel;
        private static IMainWindowViewModel _mainWindowViewModel;
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

            _geometry = ContainerConfig.Resolve<IGeometry>();
            _geometryType = ContainerConfig.Resolve<IGeometryType>();
            _parametr = ContainerConfig.Resolve<IParametr>();
            _graphViewModel = ContainerConfig.Resolve<IGraphViewModel>();
            MainWindow = new MainWindow(_mainWindowViewModel);

            RunApp();
        }
        private void RunApp()
        {
            MainWindow.Show();
        }
    }
}
