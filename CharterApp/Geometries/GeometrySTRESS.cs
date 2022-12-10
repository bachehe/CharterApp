﻿using System;
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
            double sinValue = 42.5;
            double variable = _linearFactor.Value;

            var upper = Math.Log(0.05) * -1;
            var lower = 2 * variable;
            var rad = Math.Sin((sinValue * Math.PI) / 180) * Math.Cos((x * Math.PI) / 180); //value 42.5 i think is also user input
            var result = ((upper / lower) * rad) * 10000;
            
            return result;
        }
    }
}
