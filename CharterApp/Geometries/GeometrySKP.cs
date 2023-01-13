using CharterApp.Lamps;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CharterApp.Models
{
    public class GeometrySKP : IGeometry
    {
        private readonly LinearFactor _linearFactor;
        private readonly AngleFactor _angleFactor;
        private readonly LampEnum _lampEnum;
        public Lamp Lamp { get; set; }

        public List<IParametr> Parameters => new() { _linearFactor, _angleFactor };
        public string LegendLabel => $"{Lamp.LampName}, {_linearFactor.Name}: {_linearFactor.Value}μm, α: {_angleFactor.Value}°";


        public GeometrySKP()
        {
            _linearFactor = new();
            _angleFactor = new();
            Lamp = new(_lampEnum);
        }

        public double ZFunction(double x)
        {
            if (_linearFactor.Value == 0 || _angleFactor.Value == 0)
            {
                MessageBox.Show("Values has to be greater than 0", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                _linearFactor.Value = 1;
                _angleFactor.Value = 1;
               // return 1;
            }

            var alpha = _angleFactor.Value;
            var variable = _linearFactor.Value;

            var upper = Math.Log(0.05) * -1;
            var sin1 = Math.Sin((alpha * Math.PI) / 180);
            var sin2 = Math.Sin(((2 * x - alpha) * Math.PI) / 180);
            var result = (upper / (variable * (1 / sin1 + 1 / sin2)) * 10000);

            return result;
        }
    }
}
