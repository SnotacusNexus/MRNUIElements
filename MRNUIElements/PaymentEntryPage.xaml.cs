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
		public DTO_Claim Claim { get; set; }
		public DateTime PaymentDate { get; set; }
		public int PaymentDescriptionID { get; set; }

		public PaymentEntryPage(DTO_Claim claim=null, int DocTypeID=0)
		{
		//	OnInit();
			InitializeComponent();
			OnInit();
			switch (DocTypeID)
			{
				case 13:
					{
						PaymentDescriptionID = 1;
						PaymentDescriptionTextBlock.Text = "First/Deposit Check";
						break;
					}
				case 14:
					{
						PaymentDescriptionID = 5;
						PaymentDescriptionTextBlock.Text = "Deductible Check";
						break;
					}
				case 15:
					{
						PaymentDescriptionID = 3;
						PaymentDescriptionTextBlock.Text = "Depreciation Check";
						break;
					}
				case 16:
					{
						PaymentDescriptionID = 2;
						PaymentDescriptionTextBlock.Text = "Supplemental Check";
						break;
					}
				default:
					{
						PaymentDescriptionID = 4;
						PaymentDescriptionTextBlock.Text = "Upgrade Check";
						break;
					}
			}
			if (claim != null) {
				Claim = claim;
				ClaimIDTextBlock.Text = Claim.MRNNumber;
			}
			while (s1.PaymentsList == null)
				Thread.Sleep(10);


			if (Claim !=null)
  				if (s1.PaymentsList.Exists(x => x.ClaimID == Claim.ClaimID && x.PaymentDescriptionID == this.PaymentDescriptionID))
 				{
 					System.Windows.Forms.MessageBox.Show("A Payment of this type has already been recorded.");
  					DisplayPayment(Claim, PaymentDescriptionID);
  					//new MainWindow().MRNClaimNexusMainFrame.Navigate(new GetClaimsPage());
 				}
		}
		async private void OnInit()
		{
			await s1.GetAllPayments();

		}

		private void paymentDateDatePicker_LostFocus(object sender, RoutedEventArgs e)
		{
			if(paymentDateDatePicker.SelectedDate.HasValue)
			PaymentDate = paymentDateDatePicker.SelectedDate.Value;
		}

		
		private void amountTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			
			if (amountTextBox.Text == string.Empty) amountTextBox.Value = 0;
			if (amountTextBox.Text != string.Empty) SubmitScopeEntry.IsEnabled = true;
			
		}
	  

		private void CancelScopeEntry_Click(object sender, RoutedEventArgs e)
		{
			NexusHome Page = new NexusHome();
			this.NavigationService.Navigate(Page);
		}

		async private void SubmitScopeEntry_Click(object sender, RoutedEventArgs e)
		{

			if (paymentDateDatePicker.SelectedDate != null && paymentDateDatePicker.SelectedDate <= DateTime.Today && amountTextBox.Value>0)
					{
						DTO_Payment p = new DTO_Payment();

						p.Amount = (double)amountTextBox.Value;
						p.PaymentDate = paymentDateDatePicker.SelectedDate.Value;
						p.PaymentDescriptionID = this.PaymentDescriptionID;
						p.ClaimID = Claim.ClaimID;
						p.PaymentTypeID = 1;
						await s1.AddPayment(p);
					

			
						if (s1.Payment.Message == null)
						{
							MessageBox.Show("Payment Added.");

						}
						else
						{
							MessageBox.Show(s1.Payment.Message);
						}
					}
					

		}
		private void DisplayPayment(DTO_Claim claim, int paymentDescriptionType)
		{
			System.Windows.Forms.MessageBox.Show("On " + s1.PaymentsList.Find(x => x.ClaimID == claim.ClaimID && x.PaymentDescriptionID == paymentDescriptionType).PaymentDate.ToString() + " a payment was made for the amount of $ " + s1.PaymentsList.Find(x => x.ClaimID == claim.ClaimID && x.PaymentDescriptionID == paymentDescriptionType).Amount.ToString());	
		}
	}
}															
