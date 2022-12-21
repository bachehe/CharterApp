using CharterApp.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for LinearFactorCalculatingView.xaml
    /// </summary>
    public partial class LinearFactorCalculatingView : Window
    {
        public LinearFactorCalculatingView()
        {
            DataContext = new LinearFactorCalculatingViewModel();
            InitializeComponent();
        }
    }
}
