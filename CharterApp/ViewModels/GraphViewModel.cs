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
    public class GraphViewModel
    {
        public ScottPlot.WpfPlot DataPlot { get; }
        public GraphViewModel()
        {
            DataPlot = new();
        }

        public void SelectGeometryType(IGeometryType geometryType)
        {
            DataPlot.Plot.Legend();
            DataPlot.Plot.Title($"Graph of {geometryType.GeometryName} Geometry Type");
            DataPlot.Plot.XLabel("θ");
            DataPlot.Plot.YLabel("EGW");
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
            DataPlot.Plot.AddScatter(xvalues, yvalues, label: geometry.LegendLabel, markerShape: MarkerShape.none );

            //graph style
            DataPlot.BorderBrush = new SolidColorBrush(Colors.White);
            DataPlot.Plot.Style(Style.Blue2);

            //graph funcionality
            DataPlot.Plot.AxisAuto();
            //DataPlot.Plot.SaveFig("scatter_markers.png", 800, 1200);

            DataPlot.Refresh();
        }
        public void Clear()
        {
            DataPlot.Plot.Clear();
            DataPlot.Refresh();
        }
    }
}
