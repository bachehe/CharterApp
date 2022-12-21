using CharterApp.Lamps;
using System.Collections.Generic;

namespace CharterApp.Models
{
    public interface IGeometry
    {
        List<IParametr> Parameters { get; }
        string LegendLabel { get; }
        Lamp Lamp { get; set; }
        double ZFunction(double x);
    }
}
