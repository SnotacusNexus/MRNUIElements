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
using MRNUIElements.Controllers;
namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for CheckInvoicePage.xaml
	/// </summary>
	public partial class PaymentEntryPage : Page
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();

		public PaymentEntryPage()
		{
		//	OnInit();
			InitializeComponent();
			this.claimIDComboBox.DataContext = s1.ClaimsList;
			this.paymentTypeComboBox.DataContext = s1.PaymentDescriptions;

		}
		private void OnInit()
		{
		

		}

		private void paymentDateDatePicker_LostFocus(object sender, RoutedEventArgs e)
		{

		}

		private void claimIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void amountTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			double d;
			if (amountTextBox.Text == string.Empty) amountTextBox.Text = "0";
			if (amountTextBox.Text != string.Empty) SubmitScopeEntry.IsEnabled = true;
			if (!double.TryParse(amountTextBox.Text, out d)) MessageBox.Show("Not a valid value.");
		}

		private void paymentTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
					  
		}

		private void CancelScopeEntry_Click(object sender, RoutedEventArgs e)
		{
			NexusHome Page = new NexusHome();
			this.NavigationService.Navigate(Page);
		}

		async private void SubmitScopeEntry_Click(object sender, RoutedEventArgs e)
		{

			int.Parse(s1.ClaimsList[claimIDComboBox.SelectedIndex].ClaimID.ToString());
			if (claimIDComboBox.SelectedIndex > -1)
				if (paymentTypeComboBox.SelectedIndex > -1)
					if (paymentDateDatePicker.SelectedDate != null && paymentDateDatePicker.SelectedDate >= DateTime.Today)
					{
						DTO_Payment p = new DTO_Payment();

						p.Amount = double.Parse(amountTextBox.Text);
						p.PaymentDate = paymentDateDatePicker.SelectedDate.Value;
						p.PaymentDescriptionID = ((DTO_LU_PaymentDescription)paymentTypeComboBox.SelectedValue).PaymentDescriptionID;
						p.ClaimID = ((DTO_Claim)claimIDComboBox.SelectedValue).ClaimID;
						p.PaymentTypeID = 1;
						await s1.AddPayment(p);
					

			
						if (s1.Payment.Message == null)
						{
							MessageBox.Show(s1.Payment.PaymentID.ToString());
						}
						else
						{
							MessageBox.Show(s1.Payment.Message);
						}
					}
					else MessageBox.Show("Select a date");
				else MessageBox.Show("Select a Payment Description");
			else MessageBox.Show("Pick a Claim Number");

		}
	}
}															
