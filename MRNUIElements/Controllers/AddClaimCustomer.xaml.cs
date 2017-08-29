using MRNNexus_Model;
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
	public partial class AddClaimCustomer 
	{
		static MRNClaim MrnClaim;
		static ServiceLayer s1 = ServiceLayer.getInstance();

		public AddClaimCustomer(MRNClaim MrnClaim)
		{
			InitializeComponent();
			AddClaimCustomer.MrnClaim = MrnClaim;
			if (MrnClaim.a != null)
			{
				Cust_Address.DataContext = MrnClaim.a;
				Cust_Zipcode.DataContext = MrnClaim.a;
				Cust_City.DataContext = MrnClaim.a;
				Cust_State.DataContext = MrnClaim.a;
			}
			if (MrnClaim.c != null)
			{
				Cust_FirstName.DataContext = MrnClaim.c;
				Cust_MiddleName.DataContext = MrnClaim.c;
				Cust_LastName.DataContext = MrnClaim.c;
				Cust_Suffix.DataContext = MrnClaim.c;
				Cust_PrimaryNumber.DataContext = MrnClaim.c;
				Cust_SecondaryNumber.DataContext = MrnClaim.c;
				Cust_Email.DataContext = MrnClaim.c;
			}
		}

		private void Cust_Zipcode_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (MrnClaim.a == null)
			{
				if (Cust_Zipcode.Text.Length != 5)
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
		}

		private void NextButton_Click(object sender, RoutedEventArgs e)
		{

			NavigationService.Navigate(new AddClaimInsuranceCarrier(MrnClaim));
			//Next Step
			//Insurance/Mortgage Input
		}

		private void PreviousCustomercomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			MrnClaim.c = ((DTO_Customer)PreviousCustomercomboBox.SelectedItem);
		}
	}
}
