using CharterApp.Lamps;
using System;
using System.Collections.Generic;

namespace CharterApp.Models
{
    public class GeometryBB : IGeometry
    {
        private readonly LinearFactor _linearFactor;
     
        public List<IParametr> Parameters => new() { _linearFactor };

        public string LegendLabel => $"{Lamp.LampName}, {_linearFactor.Name}: {_linearFactor.Value}";

        public Lamp Lamp { get; set; }

        public GeometryBB()
        {
            _linearFactor = new();
        }

        public double ZFunction(double x)
        {
            var rad = Math.Sin((x * Math.PI) / 180);
            var upper = Math.Log(20);
            var lower = 2 * _linearFactor.Value;
            var result = ((upper / lower) * rad) * 10000;

            return result;
        }
    }
}
