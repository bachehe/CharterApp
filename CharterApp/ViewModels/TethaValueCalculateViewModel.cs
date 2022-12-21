﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CharterApp.ViewModels
{
    public interface ITethaValueCalculateViewModel
    {
        DelegateCommand CalculateCommand { get; }
    }
    public class TethaValueCalculateViewModel : ITethaValueCalculateViewModel, INotifyPropertyChanged
    {
        public double Dhkl { get; set; }
        public double LambdaValue { get; set; }
        public double Result { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public DelegateCommand CalculateCommand { get; }

        public TethaValueCalculateViewModel()
        {
            CalculateCommand = new(CalculateTetha);
        }

        public void CalculateTetha(object? obj)
        {
            if(!(Dhkl <= 0 || LambdaValue <= 0 || Dhkl >= 1000 || LambdaValue >= 1000))
            {
                Result = Math.Round(2 * Math.Pow(Math.Sin(LambdaValue / Dhkl), -1), 4);
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