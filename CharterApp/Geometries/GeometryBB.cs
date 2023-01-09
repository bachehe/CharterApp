using CharterApp.Lamps;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CharterApp.Models
{
    public class GeometryBB : IGeometry
    {
        private readonly LinearFactor _linearFactor;
        public List<IParametr> Parameters => new() { _linearFactor };
        private readonly LampEnum _lampEnum;
        public Lamp Lamp { get; set; }
        public string LegendLabel => $"{Lamp.LampName}, {_linearFactor.Name}: {_linearFactor.Value}μm, θ";
        public GeometryBB()
        {
            _linearFactor = new();
            Lamp = new(_lampEnum);
        }

        public double ZFunction(double x)
        {
            if (_linearFactor.Value == 0)
            {
                MessageBox.Show("Values has to be greater than 0", "Invalid input", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                return 0;          
            }

            var rad = Math.Sin((x * Math.PI) / 180);
            var upper = Math.Log(20);
            var lower = 2 * _linearFactor.Value;

            var result = ((upper / lower) * rad) * 10000;

            return result;
        }
    }
}
