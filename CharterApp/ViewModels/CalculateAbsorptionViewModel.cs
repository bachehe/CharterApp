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
        double Absorption();
    }
    public class CalculateAbsorptionViewModel : ICalculateAbsorptionViewModel
    {
        private double _result;
        public double Result
        {
            get { return _result; }
            set { _result = value; }
        }
        private double _valueJo;
        public double ValueJo
        {
            get { return _valueJo; }
            set 
            { 
                _valueJo = value;
                OnPropertyChanged(nameof(ValueJo));
            }
        }
        private double _valueJx;
        public double ValueJx
        {
            get { return _valueJx; }
            set
            {
                _valueJx = value;
                OnPropertyChanged(nameof(ValueJx));
            }
        }
        private double _linearFactor;
        public double LinearFactor
        {
            get { return _linearFactor; }
            set
            {
                _linearFactor = value;
                OnPropertyChanged(nameof(LinearFactor));
            }
        }

        public double Absorption()
        {
            _result = Math.Log(_valueJo / _valueJx) / (_linearFactor * -1);
            return _result;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
