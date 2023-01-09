using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using CharterApp.Models;
using CharterApp.Views;
using ScottPlot;
using ScottPlot.WPF;

namespace CharterApp.ViewModels
{
    public interface IGraphViewModel
    {
        void SelectGeometryType(IGeometryType geometryType);
        void Draw(IGeometry geometry);
        void Clear();
    }
    public class GraphViewModel : IGraphViewModel
    {
        public ObservableCollection<double> XValues { get; set; }
        public ObservableCollection<double> YValues { get; set; }
        public DelegateCommand DetailWindow { get; }     
        public ScottPlot.WpfPlot DataPlot { get; }
        public GraphViewModel()
        {
            XValues = new ObservableCollection<double>();
            YValues = new ObservableCollection<double>();

            DataPlot = new();
            DetailWindow = new(OnClickOpenDetailWindow);
        }

        public void SelectGeometryType(IGeometryType geometryType)
        {
            DataPlot.Plot.Legend();
            DataPlot.Plot.Title($"{geometryType.GeometryName}");
            DataPlot.Plot.XLabel("Angle [°]");
            DataPlot.Plot.YLabel("EGW [μm]");
        }

        public void Draw(IGeometry geometry)
         {
            var yvalues = new double[90];
            var xvalues = new double[90];

            XValues.Clear();
            YValues.Clear();
            for (int x = 1; x < 91; x++)
            {
                xvalues[x-1] = x;
                yvalues[x-1] = Math.Round(geometry.ZFunction(x), 2);

                if (yvalues[x - 1] == 0 && x == 1)
                    return;

                XValues.Add(x);
                YValues.Add(yvalues[x-1]);

                if (double.IsInfinity(yvalues[x-1]) && double.IsNaN(yvalues[x-1]))
                    return;
            }

            //graph data implementation
            DataPlot.Plot.AddScatter(xvalues, yvalues, label: geometry.LegendLabel, markerShape: MarkerShape.none);

            //graph style
            DataPlot.BorderBrush = new SolidColorBrush(Colors.White);

            //graph funcionality
            DataPlot.Plot.AxisAuto();
            DataPlot.Refresh();
        }
        public void Clear()
        {
            DataPlot.Plot.Clear();
            DataPlot.Refresh();
        }
        private void OnClickOpenDetailWindow(object? obj)
        {
            DetailView view = new();
            view.DataContext = this;
            view.Show();
        }
    }
}
