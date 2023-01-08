using CharterApp.Lamps;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CharterApp.ViewModels
{
    public class LampElement
    {
        public string? Element { get; set; }
        public decimal Percentage { get; set; }
    }

    public interface ILinearFactorCalculatingViewModel
    {
        DelegateCommand CalculateCommand { get; }
    }
    public class LinearFactorCalculatingViewModel : ILinearFactorCalculatingViewModel, INotifyPropertyChanged
    {
        public Lamp? Lamp { get; set; }

        public ObservableCollection<LampElement> Elements { get; }


        public event PropertyChangedEventHandler? PropertyChanged;
        public DelegateCommand CalculateCommand { get; }
        public DelegateCommand AddElementCommand { get; }

        public LinearFactorCalculatingViewModel()
        {
            CalculateCommand = new(CalculateLinearFactor);
            Elements = new();

            AddElementCommand = new(OnAddElementExecute);
        }

        private void OnAddElementExecute(object? obj)
        {
            Elements.Add(new());
        }

        private void CalculateLinearFactor(object? obj)
        {
            foreach (var el in Elements)
            {
                var dbValue = Data.Values[el.Element];
                var d = dbValue.ElementDensity;
                var moAlfa = dbValue[Lamp.LampType];

            }
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
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new(propertyName));
        }
    }
}
