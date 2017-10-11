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
		static MRNClaim MrnClaim= MRNClaim.getInstance();
		static ServiceLayer s1 = ServiceLayer.getInstance();

		public AddClaimCustomer(MRNClaim MrnClaim)
		{
			InitializeComponent();
			AddClaimCustomer.MrnClaim = MrnClaim;
			if (MrnClaim.a != null)
			{
				Cust_Address.Text = MrnClaim.a.Address;
				Cust_Zipcode.Text = MrnClaim.a.Zip;
				//Cust_City.Text = MrnClaim.a;
				//Cust_State.Text = MrnClaim.a;
			}
			if (MrnClaim.c != null)
			{
				Cust_FirstName.Text = MrnClaim.c.FirstName;
				Cust_MiddleName.Text = MrnClaim.c.MiddleName;
				Cust_LastName.Text = MrnClaim.c.LastName;
				Cust_Suffix.Text = MrnClaim.c.Suffix;
				Cust_PrimaryNumber.Text = MrnClaim.c.PrimaryNumber;
				Cust_SecondaryNumber.Text = MrnClaim.c.SecondaryNumber;
				Cust_Email.Text = MrnClaim.c.Email;
			}
		}

		private void Cust_Zipcode_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (MRNClaim.getInstance().a == null)
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
            var c = new DTO_Customer()
            {
                FirstName = Cust_FirstName.Text,
                MiddleName = Cust_MiddleName.Text,
                LastName = Cust_LastName.Text,
                Suffix = Cust_Suffix.Text,
                PrimaryNumber = Cust_PrimaryNumber.Text,
                SecondaryNumber = Cust_SecondaryNumber.Text,
                Email = Cust_Email.Text,
                MailPromos = (bool)mailPromosCheckBox.IsChecked
            };
            MRNClaim.getInstance().c = c;

            NavigationService.Navigate(new AddClaimInsuranceCarrier(MRNClaim.getInstance()));
			//Next Step
			//Insurance/Mortgage Input
		}

		private void PreviousCustomercomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            MRNClaim.getInstance().c = ((DTO_Customer)PreviousCustomercomboBox.SelectedItem);
		}
	}
}
