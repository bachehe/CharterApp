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

        public double ZFunction(double x)
        {
            double result = 1;
            for (int i = 1; i <= 90; i++)
            {
                var rad = Math.Sin((i * Math.PI) / 180);
                var upper = Math.Log(20);
                var lower = 2 * x;
                result = ((upper / lower) * rad) * 10000;      
                Console.WriteLine(String.Format("{0:0.0000}", result));
            }
            return result;
        }
    }
}
