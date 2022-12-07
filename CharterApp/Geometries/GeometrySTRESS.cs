using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.Models
{
    public class GeometrySTRESS : IGeometry
    {
        private readonly LinearFactor _linearFactor;

        public List<IParametr> Parameters => new() { _linearFactor };

        public GeometrySTRESS()
        {
            _linearFactor = new();
        }

        public double ZFunction(double x) // wzór tu
        {
            throw new NotImplementedException();
        }
    }
}
