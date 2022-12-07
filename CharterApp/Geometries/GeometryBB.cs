using System;
using System.Collections.Generic;

namespace CharterApp.Models
{
    public class GeometryBB : IGeometry
    {
        private readonly LinearFactor _linearFactor;
     
        public List<IParametr> Parameters => new() { _linearFactor };

        public GeometryBB()
        {
            _linearFactor = new();
        }

        public double ZFunction(double x) // wzór tu
        {
            throw new NotImplementedException();
        }
    }
}
