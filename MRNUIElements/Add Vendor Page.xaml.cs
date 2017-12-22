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
	/// Interaction logic for Add_Vendor_Page.xaml
	/// </summary>
	public partial class Add_Vendor_Page : Page
	{
		public Add_Vendor_Page()
		{
			InitializeComponent();
            this.DataContext = this;
		}

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            vendorTypeIDComboBox.ItemsSource = Controllers.ServiceLayer.getInstance().VendorTypes;
           
        }
    }
}
