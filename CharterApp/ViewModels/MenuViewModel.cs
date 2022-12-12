using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CharterApp.ViewModels
{
    public interface IMenuViewModel
    {
        void Help();
        void Info();
    }
    public class MenuViewModel : IMenuViewModel
    {
        public void Help()
        {
            MessageBox.Show("Left-click-drag: pan \nRight-click-drag: zoom \nMiddle-click-drag:zoom region " +
                "\nALT+Left-click-drag:zoom region \nScroll wheel: zoom to cursor \n\nRight-click: show menu " +
                "\nMiddle-click: auto-axis \n Double-click: show benchmark \n\nCTRL+Left-click-drag to pan horizontally " +
                "\nSHIFT+Left-click-drag to pan vertically \nCTRL+Right-click-drag to zoom vertically \nSHIFT+Right-click-drag to zoom vertically" +
                "\nCTRL+SHIFT+Right-click-drag to zoom evenly \nSHIFT+click-drag draggables for fixed-size dragging", "Mouse and Keyboard");
        }
        public void Info()
        {
            MessageBox.Show("Charter is app created by 2 AGH students: \n" +
                "\nDamian Bachowski (https://github.com/bachehe)\nGeorgij Kupryianov (https://github.com/GeorgeKarlinzer)" +
                "\n\nCharter is app beign a part of Engineer Project, \nwhich allows user to easly create and analyse \ncharts for rentgenography workflow.", "CharterApp Info");
        }
    }
}
