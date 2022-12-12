using Autofac;
using Autofac.Core;
using CharterApp.Models;
using CharterApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp
{
    public static class ContainerConfig
    {
        private static IContainer container;
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<GeometryBB>().As<IGeometry>();
            builder.RegisterType<GeometrySKP>().As<IGeometry>();
            builder.RegisterType<GeometrySTRESS>().As<IGeometry>();

            builder.RegisterType<AngleFactor>().As<IParametr>();
            builder.RegisterType<LinearFactor>().As<IParametr>();

            builder.RegisterType<GraphViewModel>().As<IGraphViewModel>();
            builder.RegisterType<MenuViewModel>().As<IMenuViewModel>();
            builder.RegisterType<MainWindowViewModel>().As<MainWindowViewModel>();

            container = builder.Build();

            return container;
        }
        public static T Resolve<T>()
        {
            if (container == null)
                throw new Exception("Config not started");

            return container.Resolve<T>(new Parameter[0]);
        }
        public static T Resolve<T>(Parameter[] parameters)
        {
            if(container == null)
                throw new Exception("Config not started");

            return container.Resolve<T>(parameters); 
        }
    }
}
