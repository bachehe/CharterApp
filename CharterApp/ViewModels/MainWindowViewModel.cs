using CharterApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly int _maxGeometryCount = 4;


        private IGeometryType? _selectedGeometryType;
        public List<IGeometryType> GeometryTypes { get; }
        public IGeometryType? SelectedGeometryType
        {
            get => _selectedGeometryType;
            set
            {
                _selectedGeometryType = value;
                OnClearExecute(null);

                if(value is not null)
                {
                    GraphViewModel.SelectGeometryType(value);
                    Geometries.Add(value.CreateGeometry());
                }

                DrawCommand.UpdateCanExecute();
            }
        }

        public ObservableCollection<IGeometry> Geometries { get; }

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

            Geometries = new();

            AddGeometryCommand = new(OnAddGeometryExecute);
            RemoveGeometryCommand = new(OnRemoveGeometryExecute);
            DrawCommand = new(OnDrawExecute);
            ClearCommand = new(OnClearExecute);
            GraphViewModel = new();
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
                if (g.Parameters.Any(x => !x.Validate()))
                    return;

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
