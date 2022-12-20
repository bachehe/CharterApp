using CharterApp.Calculate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.ViewModels
{
    public class LinearFactorCalculatingViewModel : INotifyPropertyChanged
    {
        public double Density { get; set; }

        public double MoPercentage { get; set; }
        public double CuPercentage { get; set; }
        public double CoPercentage { get; set; }
        public double CrPercentage { get; set; }

        public double LinearFactor { get; set; }
        

        public event PropertyChangedEventHandler? PropertyChanged;


        private void Calculate()
        {
            if (MoPercentage + CuPercentage + CoPercentage + CrPercentage != 1)
                return;

            var index = Data.Densities.IndexOf(Density);

            LinearFactor = (Data.MoValues[index] * MoPercentage +
                Data.CuValues[index] * CuPercentage +
                Data.CoValues[index] * CoPercentage +
                Data.CrValues[index] * CrPercentage) * Density;

            PropertyChanged?.Invoke(this, new(nameof(LinearFactor)));
        }
    }
}
