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

using MRNNexus_Model;

namespace MRNUIElements.Controllers
{
	
	/// <summary>
	/// Interaction logic for AddLeadInformation.xaml
	/// </summary>
	public partial class AddLeadInformation : PageFunction<object>
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
	

		public AddLeadInformation()
		{
			InitializeComponent();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			//On to Customer
			NavigationService.Navigate(new AddClaimCustomer());
		}
		
	}
}
