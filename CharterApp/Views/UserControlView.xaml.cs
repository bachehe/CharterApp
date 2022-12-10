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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharterApp.Views
{
    /// <summary>
    /// Interaction logic for UserControlView.xaml
    /// </summary>
    public partial class UserControlView : UserControl
    {
        public UserControlView()
        {
            InitializeComponent();
        }
        private void GeometryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GeometryCB.IsEnabled = false;
        }
        private void ButtonCB_Click(object sender, RoutedEventArgs e)
        {
            GeometryCB.IsEnabled = true;
        }
    }
}
