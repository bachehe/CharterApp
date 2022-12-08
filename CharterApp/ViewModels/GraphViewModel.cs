using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ScottPlot;
using ScottPlot.WPF;

namespace CharterApp.ViewModels
{
    public class GraphViewModel
    {
        public ScottPlot.WpfPlot DataPlot { get; set; } = new ScottPlot.WpfPlot();
        //public PointCollection Points { get; }
        public GraphViewModel()
        {
            //Points = new();
            //Points.Add(new(50, 100));
            //Points.Add(new(70, 250));
            //Points.Add(new(230, 299));

            double[] dataX = new double[] { 1, 2, 3, 4, 5 };
            double[] dataY = new double[] { 1, 4, 9, 16, 25 };

            DataPlot.BorderBrush = new SolidColorBrush(Colors.White);
            DataPlot.Plot.AddScatter(dataX, dataY, label:"first");

            double[] dataXX = new double[] { 5, 7, 12, 16, 25 };
            double[] dataYY = new double[] { 1, 9, 17, 21, 43 };
            DataPlot.Plot.AddScatter(dataXX, dataYY, label: "second");
            DataPlot.Plot.Legend();
            DataPlot.Plot.Title("CHART");
            DataPlot.Plot.XLabel("Angle");
            DataPlot.Plot.YLabel("EGW");
            DataPlot.Plot.Layout(left: 100, right: 100, bottom: 100, top: 50);
            DataPlot.Refresh();
            
            

        }
    }
}
