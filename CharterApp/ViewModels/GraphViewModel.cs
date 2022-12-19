using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using CharterApp.Models;
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
        public double x { get; set; }
        public ScottPlot.WpfPlot DataPlot { get; }
        //private readonly ScottPlot.Plottable.ScatterPlot MyScatterPlot;
        public string Cords { get; set; }
        public GraphViewModel()
        {
            DataPlot = new();
            Cords = string.Empty;
        }

        //public void OnMouseMoved()
        //{
        //    (double x, double y) = DataPlot.GetMouseCoordinates();
        //    double xyRatio = DataPlot.Plot.XAxis.Dims.PxPerUnit / DataPlot.Plot.YAxis.Dims.PxPerUnit;
        //    (double pointX, double pointY, int pointIndex) = MyScatterPlot.GetPointNearest(x, y, xyRatio);
        //    Cords = $"coordinates: x {pointX}, y {pointY}";
        //}
        public void SelectGeometryType(IGeometryType geometryType)
        {

            DataPlot.Plot.Legend();
            DataPlot.Plot.Title($"{geometryType.GeometryName}");
            DataPlot.Plot.XLabel("Angle");
            DataPlot.Plot.YLabel("EGW [μm]");
        }

        public void Draw(IGeometry geometry)
        {
            var xvalues = new double[91];
            var yvalues = new double[91];

            for (int x = 1; x < 91; x++)
            {
                xvalues[x] = x;
                yvalues[x] = geometry.ZFunction(x);
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
    }
}
