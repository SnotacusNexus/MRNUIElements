using MRNNexus_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
	/// Interaction logic for AddPropertyAddress.xaml
	/// </summary>
	public partial class AddPropertyAddress : PageFunction<Object>
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		DTO_Address address = new DTO_Address();

		//public ReturnEventHandler<object> Return { get; internal set; }

		public AddPropertyAddress()
		{
			InitializeComponent();
			Select_Button.IsEnabled = false;
			GetAddress();
			while (s1.AddressesList == null)
				Thread.Sleep(10);
		}

		private async void GetAddress()
		{
			await s1.GetAllAddresses();
		}

		private void Button_Click(object sender, ReturnEventArgs<object> e)
		{
			e.Result = address;
			//Return = (System.Windows.Navigation.ReturnEventHandler<object>)e.Result;
			
			//Select Address

		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			//Cancel
			NavigationService ns = NavigationService.GetNavigationService((DependencyObject)sender);

		}

		private void ComboBoxAdv_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateAddress((DTO_Address)AddressCombo.SelectedItem);
		}

		DTO_Address UpdateAddress(DTO_Address _address = null, string zip="", string addressstring="")
		{
			if (_address != null)
				address = _address;
			else if (zip != "" && addressstring != "")
			{
				address.Address = addressstring;
				address.Zip = zip;

			}
			return address;


		}

		private void MaskedTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (ZipcodeBox.Text.Length != 5 || string.IsNullOrEmpty(AddressCombo.SelectedValue.ToString()))
				return;
			else
				AddressCombo.ItemsSource = s1.AddressesList.Where(x => x.Zip == ZipcodeBox.Text).ToList();
			Select_Button.IsEnabled = true;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button_Click(sender, e);
		}
	}
}
