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
                return;

            Elements.Add(new());
        }

        private void CalculateLinearFactor(object? obj)
        {
            decimal res = 0;

            if (Data.Values.Values.Any(x => x.ElementDensity == Density) && Density != 0)
            {
                foreach (var el in Elements)
                {
                    if (el.Percentage == 0 || el.Element == null)
                    {
                        MessageBox.Show("No input was recorded", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    var dbValue = Data.Values[el.Element];
                    var kAlfa = dbValue[Lamp.LampType];

                    res += (el.Percentage * kAlfa);
                }
                res *= Density;
                Result = Math.Round(res, 4);

                OnPropertyChanged(nameof(Result));
            }
            else
            {
                MessageBox.Show("Density value out of database resource", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


            #region test
            //if (!(MoPercentage < 0 || CuPercentage < 0 || CrPercentage < 0 || CoPercentage < 0 || MoPercentage > 1 || CuPercentage > 1 || CrPercentage > 1 || CoPercentage > 1))
            //{
            //    FePercentage = 1 - MoPercentage - CuPercentage - CoPercentage - CrPercentage;

            //    //if (MoPercentage + CuPercentage + CoPercentage + CrPercentage >= 1)
            //    //{
            //    //    MessageBox.Show("Invalid input for elements", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    //    return;
            //    //}

            //    if (Element is null)
            //    {
            //        MessageBox.Show("Please choose an element", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            //        return;
            //    }

            //    var dbValue = Data.Values[Element];

            //    //LinearFactor = Math.Round(dbValue[Lamps.LampEnum.Mo] * MoPercentage +
            //    //    dbValue[Lamps.LampEnum.Cu] * CuPercentage +
            //    //    dbValue[Lamps.LampEnum.Co] * CoPercentage +
            //    //    dbValue[Lamps.LampEnum.Cr] * CrPercentage) * dbValue.ElementDensity), 4);

            //    OnPropertyChanged(nameof(LinearFactor));
            //    OnPropertyChanged(nameof(FePercentage));
            //}
            //else
            //{
            //    MessageBox.Show("Invalid input for parameters", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            #endregion
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new(propertyName));
        }
    }
}
