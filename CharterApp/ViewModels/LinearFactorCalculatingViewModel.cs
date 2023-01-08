using CharterApp.Calculate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CharterApp.ViewModels
{
    public interface ILinearFactorCalculatingViewModel
    {
        DelegateCommand CalculateCommand { get; }
    }
    public class LinearFactorCalculatingViewModel : ILinearFactorCalculatingViewModel, INotifyPropertyChanged
    {
        public decimal Density { get; set; }
        public decimal MoPercentage { get; set; }
        public decimal CuPercentage { get; set; }
        public decimal CoPercentage { get; set; }
        public decimal CrPercentage { get; set; }
        public decimal LinearFactor { get; set; }

        public decimal FePercentage { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public DelegateCommand CalculateCommand { get; }

        public LinearFactorCalculatingViewModel()
        {
            CalculateCommand = new(CalculateLinearFactor);
        }

        private void CalculateLinearFactor(object? obj)
        {
            if (!(MoPercentage < 0 || CuPercentage < 0 || CrPercentage < 0 || CoPercentage < 0 || MoPercentage > 1 || CuPercentage > 1 || CrPercentage > 1 || CoPercentage > 1))
            {
                FePercentage = 1 - MoPercentage - CuPercentage - CoPercentage - CrPercentage;

                //if (MoPercentage + CuPercentage + CoPercentage + CrPercentage >= 1)
                //{
                //    MessageBox.Show("Invalid input for elements", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return;
                //}

                var index = Data.Densities.IndexOf(Density);

                if (index == -1)
                {
                    MessageBox.Show("Density out of database resource", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                LinearFactor = Math.Round(((Data.MoValues[index] * MoPercentage +
                    Data.CuValues[index] * CuPercentage +
                    Data.CoValues[index] * CoPercentage +
                    Data.CrValues[index] * CrPercentage) * Density), 4);

                OnPropertyChanged(nameof(LinearFactor));
                OnPropertyChanged(nameof(FePercentage));
            }
            else
            {
                MessageBox.Show("Invalid input for parameters", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new(propertyName));
        }
    }
}
