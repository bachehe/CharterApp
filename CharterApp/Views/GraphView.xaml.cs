using CharterApp.ViewModels;
using ScottPlot;
using ScottPlot.WPF;
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
    public partial class GraphView : UserControl
    {
        public GraphView()
        {
            InitializeComponent();

            Graph.RightClicked -= Graph.DefaultRightClickEvent;
            Graph.RightClicked += CustomRightClickEvent!;
        }
        private void CustomRightClickEvent(object sender, EventArgs e)
        {

            MenuItem menuHelp = new MenuItem
            {
                Header = "Help"
            };
            menuHelp.Click += RightClickMenu_Help_Click;

            ContextMenu menu = new ContextMenu();
            
            menu.Items.Add(menuHelp);
            menu.IsOpen = true;

        }
        private void RightClickMenu_Help_Click(object sender, EventArgs e)
        {
            new HelpWindow().Show();
        }
    }
}
