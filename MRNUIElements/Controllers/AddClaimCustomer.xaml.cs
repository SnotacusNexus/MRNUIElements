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

namespace MRNUIElements.Controllers
{
	/// <summary>
	/// Interaction logic for AddClaimCustomer.xaml
	/// </summary>
	public partial class AddClaimCustomer : PageFunction<Object>
	{
		public AddClaimCustomer()
		{
			InitializeComponent();
		}

		private void Cust_Zipcode_TextChanged(object sender, TextChangedEventArgs e)
		{
			if(Cust_Zipcode.Text.Length != 5)
			{
				return;
			}
			if (Cust_Zipcode.Text.Length == 5)
			{
				var CSZ = new AddressZipcodeValidation();
				CSZ.CityStateLookupRequest(Cust_Zipcode.Text);
				Cust_City.Text = CSZ.City;
				Cust_State.Text = CSZ.State;
			}

		}

		private void NextButton_Click(object sender, RoutedEventArgs e)
		{
			//Next Step
			//Insurance/Mortgage Input
		}
	}
}
