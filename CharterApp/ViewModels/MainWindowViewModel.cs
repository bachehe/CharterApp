﻿using CharterApp.Models;
using CharterApp.Lamps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CharterApp.Views;

namespace CharterApp.ViewModels
{
    public interface IMainWindowViewModel
    {

    }
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly int _maxGeometryCount = 4;
        private MenuViewModel MenuViewModel = new();
        private IGeometryType? _selectedGeometryType;

        public List<IGeometryType> GeometryTypes { get; }
        public IGeometryType? SelectedGeometryType
        {
            get => _selectedGeometryType;
            set
            {
                _selectedGeometryType = value;
                OnClearExecute(null);

                if (value is not null)
                {
                    GraphViewModel.SelectGeometryType(value);
                    Geometries.Add(value.CreateGeometry());
                }

                DrawCommand.UpdateCanExecute();
            }
        }
        public DelegateCommand DataBaseWindow { get; }
        public DelegateCommand TethaCalculateWindow { get; }
        public DelegateCommand LinearFactorCalculatingWindow { get; }
        public ObservableCollection<IGeometry> Geometries { get; }
        public DelegateCommand CalculateAbsortpionWindow { get; }
        public DelegateCommand ExitCommand { get; }
        public DelegateCommand MinimizeCommand { get; }
        public DelegateCommand MenuHelpCommand { get; }
        public DelegateCommand MenuInfoCalculateCommand { get; }
        public DelegateCommand MenuInfoCommand { get; }
        public DelegateCommand AddGeometryCommand { get; }
        public DelegateCommand RemoveGeometryCommand { get; }
        public DelegateCommand DrawCommand { get; }
        public DelegateCommand ClearCommand { get; }
        public GraphViewModel GraphViewModel { get; }
        public MainWindowViewModel()
        {
            GeometryTypes = new()
            {
                new GeometryType<GeometryBB>("BB"),
                new GeometryType<GeometrySKP>("SKP"),
                new GeometryType<GeometrySTRESS>("STRESS"),
            };

            DataBaseWindow = new(OnClickOpenDataBaseWindow);
            TethaCalculateWindow = new(OnClickTethaOpenTetha);
            LinearFactorCalculatingWindow = new(OnClickOpenLinearFactor);
            CalculateAbsortpionWindow = new(OnClickOpenAbsorption);
            Geometries = new();
            MinimizeCommand = new(OnClickMinimizeCommand);
            ExitCommand = new(OnClickExitCommand);
            MenuInfoCalculateCommand = new(OnClickInfoCalculateOpen);
            MenuInfoCommand = new(OnClickInfoExecute);
            MenuHelpCommand = new(OnClickHelpExecute);
            AddGeometryCommand = new(OnAddGeometryExecute);
            RemoveGeometryCommand = new(OnRemoveGeometryExecute);
            DrawCommand = new(OnDrawExecute);
            ClearCommand = new(OnClearExecute);
            GraphViewModel = new();

        }
    
        private void OnClickInfoCalculateOpen(object? obj)
        {
            MenuViewModel.CalculateInfo();
        }
        private void OnClickOpenDataBaseWindow(object? obj)
        {
            DataBaseView view = new();
            view.Show();
        }
        private void OnClickTethaOpenTetha(object? obj)
        {
            TethaValueCalculateView view = new();
            view.Show();
        }
        private void OnClickOpenLinearFactor(object? obj)
        {
            //LinearFactorCalculatingView view = new();

            CalculateLinearFactorView view = new();
            view.Show();
        }
        private void OnClickOpenAbsorption(object? obj)
        {
            CalculateAbsorptionView view = new();
            view.Show();
        }
        private void OnClickMinimizeCommand(object? obj)
        {
            Window window = Application.Current.MainWindow;
            window.WindowState = WindowState.Minimized;       
        }
        private void OnClickExitCommand(object? obj)
        {
            Application.Current.Shutdown();
        }
        private void OnClickInfoExecute(object? obj)
        {
            MenuViewModel.Info();       
        }
        private void OnClickHelpExecute(object? obj)
        {
            MenuViewModel.Help();
        }
        private void OnAddGeometryExecute(object? obj)
        {
            if (SelectedGeometryType is null || Geometries.Count == _maxGeometryCount)
                return;

            Geometries.Add(SelectedGeometryType.CreateGeometry());
        }
        private void OnRemoveGeometryExecute(object? obj)
        {
            if (obj is not IGeometry geometry)
                return;

            Geometries.Remove(geometry);

            OnDrawExecute(null);
        }
        private void OnDrawExecute(object? obj)
        {
            GraphViewModel.Clear();

            foreach (var g in Geometries)
            {
                if (g.Parameters.Any(x => !x.Validate()) || g.Lamp.LampName == null)
                {
                    MessageBox.Show("No valid input for values was recorded", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }           

                GraphViewModel.Draw(g);
            }
        }
        private void OnClearExecute(object? obj)
        {
            Geometries.Clear();
            GraphViewModel.Clear();
        }
    }
}
