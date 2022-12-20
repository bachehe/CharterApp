using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public DelegateCommand CalculateCommand { get; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public CalculateAbsorptionViewModel()
        {
            CalculateCommand = new(CalculateAbsorption);
        }

        private void CalculateAbsorption(object? obj)
        {
            Result = Math.Log(ValueJo / ValueJx) / (-LinearFactor);
            OnPropertyChanged(nameof(Result));
        }
        
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new(propertyName));
        }
    }
}
