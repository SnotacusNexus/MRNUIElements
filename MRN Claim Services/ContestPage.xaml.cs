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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MRN_Claim_Services
{
    /// <summary>
    /// Interaction logic for ContestPage.xaml
    /// </summary>
    public partial class ContestPage : Page
    {
        public ContestPage()
        {
            InitializeComponent();
            RotateTransform3D myRotateTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 1));

        }

        private void OK_CLick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
