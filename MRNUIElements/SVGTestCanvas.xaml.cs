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

namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class SVGTestCanvas : Page
    {
        public SVGTestCanvas()
        {
            InitializeComponent();
            var urisource = new Uri(@"../../ResourceFiles/HailHit.png", UriKind.Relative);
            ImageBrush brush = new ImageBrush();
            brush.ImageSource= new BitmapImage(urisource);
            IC.Background = brush;
            
        }
    }
}
