using CharterApp.Lamps;
using System;
using System.Collections.Generic;

namespace CharterApp.Models
{
    public class GeometrySTRESS : IGeometry
    {
        private readonly LinearFactor _linearFactor;
        private readonly AngleFactor _angleFactor;
        public List<IParametr> Parameters => new() { _linearFactor, _angleFactor };
        public string LegendLabel => $"{Lamp.LampName}, {_linearFactor.Name}: {_linearFactor.Value}μm, {_angleFactor.Name}: {_angleFactor.Value}°";

        public Lamp Lamp { get; set; }

        public GeometrySTRESS()
        {
            _linearFactor = new();
            _angleFactor = new ();
        }

        public double ZFunction(double x)
        {
            double sinValue = _angleFactor.Value;
            double variable = _linearFactor.Value;

            var upper = Math.Log(0.05) * -1;
            var lower = 2 * variable;
            var rad = Math.Sin((sinValue * Math.PI) / 180) * Math.Cos((x * Math.PI) / 180); //value 42.5 i think is also user input
            var result = ((upper / lower) * rad) * 10000;
            
            return result;
        }
    }
}
