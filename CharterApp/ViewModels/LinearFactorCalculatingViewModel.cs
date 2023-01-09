using CharterApp.Lamps;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace CharterApp.ViewModels
{
    public interface ILinearFactorCalculatingViewModel
    {
        DelegateCommand CalculateCommand { get; }
    }
    public class LinearFactorCalculatingViewModel : ILinearFactorCalculatingViewModel, INotifyPropertyChanged
    {
        public decimal SumPercentage;
        private int _maxElementCount = 10;
        public decimal Density { get; set; }
        public decimal Result { get; set; }
        public Lamp? Lamp { get; set; }
        public ObservableCollection<LampElement> Elements { get; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public DelegateCommand CalculateCommand { get; }
        public DelegateCommand AddElementCommand { get; }
        public DelegateCommand RemoveElementCommand { get; }

        public LinearFactorCalculatingViewModel()
        {
            Elements = new();
            CalculateCommand = new(CalculateLinearFactor);
            AddElementCommand = new(OnAddElementExecute);
            RemoveElementCommand = new(OnRemoveGeometryExecute);
        }
        private void OnRemoveGeometryExecute(object? obj)
        {
            if (obj is not LampElement element)
                return;

            Elements.Remove(element);
        }
        private void OnAddElementExecute(object? obj)
        {
            if (Elements.Count == _maxElementCount)
            {
                MessageBox.Show("Can not add more elements", "Limit for elements reached", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Elements.Add(new());
        }

        public void CalculateLinearFactor(object? obj)
        {
            //Data.Values.Values.Any(x => x.ElementDensity == Density) && Density != 0 => condition for density out of database
            
            decimal res = 0;
            SumPercentage = 0;
            if(Density <= 0 || Density >= 24)
            {
                MessageBox.Show("Density has to be between 0 and 24", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            foreach (var el in Elements)
            {
                if (el.Percentage == 0 || el.Element == null)
                {
                    MessageBox.Show("No input was recorded", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var dbValue = Data.Values[el.Element];
                var kAlfa = dbValue[Lamp.LampType];

                SumPercentage += el.Percentage;

                res += (el.Percentage * kAlfa);
            }
            if (SumPercentage != 1)
            {
                MessageBox.Show("Sum of element value's should be equal to 1", "Invalid element value's", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            res *= Density;
            Result = Math.Round(res, 4);
            OnPropertyChanged(nameof(Result));

            SumPercentage = 0;
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new(propertyName));
        }
    }

}