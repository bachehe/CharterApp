using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CharterApp.ViewModels
{
    public class GraphViewModel
    {
        public PointCollection Points { get; }
        public GraphViewModel()
        {
            Points = new();
            Points.Add(new(50, 100));
            Points.Add(new(70, 250));
            Points.Add(new(230, 299));
        }
    }
}
