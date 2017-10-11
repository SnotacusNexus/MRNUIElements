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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for ClaimItPage.xaml
    /// </summary>
    public partial class ClaimItPage : Page
    {
        public ClaimItPage()
        {
            InitializeComponent();


            Vector3DAnimation myVectorAnimation = new Vector3DAnimation(new Vector3D(-1, -1, -1), new Duration(TimeSpan.FromMilliseconds(5000)));
            myVectorAnimation.RepeatBehavior = RepeatBehavior.Forever;
        }

        private void OKBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
