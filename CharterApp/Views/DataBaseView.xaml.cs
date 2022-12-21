using CharterApp.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CharterApp.Views
{
    /// <summary>
    /// Interaction logic for DataBaseView.xaml
    /// </summary>
    public partial class DataBaseView : Window
    {
        public DataBaseView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var filePath = "./Data/basecsv.csv";

            DataBaseViewModel model = new();

            DataTable dt = new DataTable();
            dt.Columns.Add("Density", typeof(string));
            dt.Columns.Add("Mo", typeof(string));
            dt.Columns.Add("Cu", typeof(string));
            dt.Columns.Add("Co", typeof(string));
            dt.Columns.Add("Cr", typeof(string));

            foreach (var line in File.ReadAllLines(filePath))
            {
                var values = line.Split(';');
                var density = decimal.Parse(values[0]);
                var mo = decimal.Parse(values[1]);
                var cu = decimal.Parse(values[2]);
                var co = decimal.Parse(values[3]);
                var cr = decimal.Parse(values[4]);

                model.Density.Add(density);
                model.Mo.Add(mo);
                model.Cu.Add(cu);
                model.Co.Add(co);
                model.Cr.Add(cr);

                dt.Rows.Add(values);
            }
            DataView dv = new DataView(dt);
            DataGrid.ItemsSource = dv;
        }
    }
}
