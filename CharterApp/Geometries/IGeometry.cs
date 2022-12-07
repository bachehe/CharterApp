using System.Collections.Generic;

namespace CharterApp.Models
{
    public interface IGeometry
    {
        List<IParametr> Parameters { get; }
        double ZFunction(double x);
    }
}
