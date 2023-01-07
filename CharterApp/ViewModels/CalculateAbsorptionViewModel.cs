using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CharterApp.Views;

namespace CharterApp.ViewModels
{
    public interface ICalculateAbsorptionViewModel
    {
        DelegateCommand CalculateCommand { get; }
    }
    public class CalculateAbsorptionViewModel : ICalculateAbsorptionViewModel, INotifyPropertyChanged
    {
        public double Result { get; set; }
        public double ValueJo { get; set; }
        public double ValueJx { get; set; }
        public double LinearFactor { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;
        public DelegateCommand CalculateCommand { get; }

        public CalculateAbsorptionViewModel()
        {
            CalculateCommand = new(CalculateAbsorption);
        }

        private void CalculateAbsorption(object? obj)
        {
            if (!(ValueJo <= 0 || ValueJx <= 0 || LinearFactor <= 0 || ValueJo == ValueJx || ValueJo >= 1000 || ValueJx >= 1000 || LinearFactor >= 1000 || ValueJo < ValueJx))
            {
                Result = Math.Round(Math.Log(ValueJo / ValueJx) / (LinearFactor), 4);
                OnPropertyChanged(nameof(Result));
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
