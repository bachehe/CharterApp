using System;
using System.Collections.Generic;

namespace CharterApp.Models
{
    public class GeometrySKP : IGeometry
    {
        private readonly LinearFactor _linearFactor;
        private readonly AngleFactor _angleFactor;

        public List<IParametr> Parameters => new() { _linearFactor, _angleFactor};
        public string LegendLabel => $"{_linearFactor.Name}: {_linearFactor.Value}, {_angleFactor.Name}: {_angleFactor.Value}";

        public GeometrySKP()
        {
            _linearFactor = new();
            _angleFactor = new();
        }

        public double ZFunction(double x) 
        {
            var alpha = _angleFactor.Value; 

            var tetha = x;
            var variable = _linearFactor.Value;

            var upper = Math.Log(0.05) * -1;
            var sin1 = Math.Sin((alpha * Math.PI) / 180);
            var sin2 = Math.Sin(((2 * tetha - alpha) * Math.PI) / 180);
            var result = (upper / (variable * (1 / sin1 + 1 / sin2)) * 10000);
            
            return result;
        }
    }
}
