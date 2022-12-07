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

        public double ZFunction(double x) 
        {
            double result = 1;
            var alpha = 1; 
            for (int i = 1; i <= 90; i++)
            {
                var tetha = i;
                var variable = x;

                var upper = Math.Log(0.05) * -1;
                var sin1 = Math.Sin((alpha * Math.PI) / 180);
                var sin2 = Math.Sin(((2 * tetha - alpha) * Math.PI) / 180);
                result = (upper / (variable * (1 / sin1 + 1 / sin2)) * 10000);
            }
            return result;
        }
    }
}
