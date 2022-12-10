using CharterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharterApp.ViewModels
{
    public class MainWindowViewModel
    {
        private IGeometry? selectedGeometry;

        public List<IGeometry> Geometries { get; }
        public IGeometry? SelectedGeometry { get => selectedGeometry;
            set 
            {
                selectedGeometry = value;
                DrawCommand.UpdateCanExecute();
            }
        }
        public DelegateCommand DrawCommand { get; }
        public DelegateCommand ClearCommand { get; }
        public GraphViewModel GraphViewModel { get; }

        public MainWindowViewModel()
        {
            Geometries = new()
            {
                new GeometryBB(),
                new GeometrySKP(),
                new GeometrySTRESS()
            };

            DrawCommand = new(OnDrawExecute);
            ClearCommand = new(OnClearExecute);
            GraphViewModel = new();

        }

        private void OnDrawExecute(object? obj)
        {
            if (SelectedGeometry is null)
                return;

            if (SelectedGeometry.Parameters.Any(x => !x.Validate()))
                return;

            GraphViewModel.Draw(SelectedGeometry!);
        }
        private void OnClearExecute(object? obj)
        {
            GraphViewModel.Clear();
        }
    }
}
