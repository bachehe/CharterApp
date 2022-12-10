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
        public string Name => "STRESS";
        public GeometrySTRESS()
        {
            _linearFactor = new();
        }

        public double ZFunction(double x)
        {
            double result = 1;
            double sinValue = 42.5;
            for (int i = 1; i <= 90; i++)
            {
                var upper = Math.Log(0.05) * -1;
                var lower = 2 * x;
                var rad = Math.Sin((sinValue * Math.PI) / 180) * Math.Cos((i * Math.PI) / 180); //value 42.5 i think is also user input
                result = ((upper / lower) * rad) * 10000;
            }
            return result;
        }
    }
}
