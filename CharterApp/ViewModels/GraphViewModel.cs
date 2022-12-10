using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
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
            DataPlot.Plot.AddScatter(xvalues, yvalues, label: $"value");

            //graph style
            DataPlot.BorderBrush = new SolidColorBrush(Colors.White);
            DataPlot.Plot.Style(ScottPlot.Style.Blue2);

            //graph description
            DataPlot.Plot.Legend();
            DataPlot.Plot.Title("CHART");
            DataPlot.Plot.XLabel("Angle");
            DataPlot.Plot.YLabel("EGW");

            DataPlot.Refresh();
        }
        public void Clear()
        {
            DataPlot.Plot.Clear();
        }
    }
}
