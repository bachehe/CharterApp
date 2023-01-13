using CharterApp.Lamps;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CharterApp.Models
{
    public class GeometrySTRESS : IGeometry
    {
        private readonly LinearFactor _linearFactor;
        private readonly AngleFactor _angleFactor;
        private readonly PlaneValue _plane; 
        private readonly LampEnum _lampEnum;
        public Lamp Lamp { get; set; }
        public List<IParametr> Parameters => new() { _linearFactor, _angleFactor, _plane };
        public string LegendLabel => $"{Lamp.LampName}, {_linearFactor.Name}: {_linearFactor.Value}μm, {_angleFactor.NameTetha}: {_angleFactor.Value}, hkl: {{{_plane.Value.ToString().PadLeft(3, '0')}}}";

        public GeometrySTRESS()
        {
            _linearFactor = new();
            _angleFactor = new();
            _plane = new();
            Lamp = new(_lampEnum);
        }

        public double ZFunction(double x)
        {
            if (_linearFactor.Value == 0 || _angleFactor.Value == 0)
            {
                MessageBox.Show("Values has to be greater than 0", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                _linearFactor.Value = 1;
                _angleFactor.Value = 1;
            }

            var upper = Math.Log(0.05) * -1;
            var lower = 2 * _linearFactor.Value;
            var rad = Math.Sin((_angleFactor.Value * Math.PI) / 180) * Math.Cos((x * Math.PI) / 180);
            var result = ((upper / lower) * rad) * 10000;

            return result;
        }
    }
}
