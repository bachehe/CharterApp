using System;
using System.Collections.Generic;

namespace CharterApp.Models
{
    public class GeometrySKP : IGeometry
    {
        private readonly LinearFactor _linearFactor;
        private readonly AngleFactor _angleFactor;

        public List<IParametr> Parameters => new() { _linearFactor, _angleFactor};

        public GeometrySKP()
        {
            _linearFactor = new();
            _angleFactor = new();
        }

        public double ZFunction(double x) // wzór tu
        {
            throw new NotImplementedException();
        }
    }
}
