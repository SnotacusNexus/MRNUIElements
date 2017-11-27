using MRNUIElements.Controllers;
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
    /// Interaction logic for ImageViewer.xaml
    /// </summary>
    public partial class ImageViewer : UserControl
    {
        ServiceLayer s1 = ServiceLayer.getInstance();
        public string Path { get; set; }

      public ImageViewer()
        {
            InitializeComponent();

            image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(Path);
        }
    }
}
