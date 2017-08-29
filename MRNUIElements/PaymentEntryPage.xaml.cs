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

using System.Windows.Forms;
using System.Drawing;
//using System.Drawing.Imaging;
//using System.Drawing.Drawing2D;
//using System.Drawing.Text;
using MRNUIElements.ImageManipulation;

using System.IO;
using MRNNexus_Model;
using System.Globalization;
using MRNUIElements.Controllers;
using System.Collections.ObjectModel;

namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for CheckInvoicePage.xaml
	/// </summary>
	public partial class PaymentEntryPage : PageFunction<object>
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		static Frame f = GetClaimsPage.getInstanceg();
		static GetClaimsPage G = GetClaimsPage.getInstanceH();
		public static PaymentEntryPage P;
		public static DTO_Claim Claim { get; set; }
		public DateTime PaymentDate { get; set; }
		public static int PaymentDescriptionID { get; set; }
		public static string PaymentDescription { get; set; }
		public static double Amount { get; set; }
		public static int DocTypeID { get; set; }
		public int Valley { get; internal set; }

		protected int ClaimStatusType = 0;
		protected string FullFilePath;
		public System.Drawing.Image bitmap;
		//static DTO_Payment payment = new DTO_Payment();


		public List<DTO_LU_PaymentDescription> PDList = new List<DTO_LU_PaymentDescription>();
		public List<DTO_Payment> Payments = new List<DTO_Payment>();
		ClaimPickerPopUp cppu = new ClaimPickerPopUp();
		protected bool paymentExist = true;
		public PaymentEntryPage(DTO_Claim claim = null, int DocTypeID = 0, DTO_Payment payment = null)
		{
			InitializeComponent();


			if (claim != null && DocTypeID > 0)
			{
				OnInit(claim, DocTypeID);
			//	while (s1.PaymentsList == null)
			//		Thread.Sleep(10);

				try
				{


					var a = s1.PaymentsList.Where(x => x.PaymentDescriptionID == SetPaymentTypeID(DocTypeID)).ToList();
					if (a.Count() > 0)
					{

						paymentDateDatePicker.SelectedDate = a[0].PaymentDate;
						amountTextBox.Value = (decimal)a[0].Amount;
						amountTextBox.IsEnabled = false;
						paymentDateDatePicker.IsEnabled = false;
						if (System.Windows.Forms.MessageBox.Show("Found this document.", "Do you want to change it?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
						{
							amountTextBox.IsEnabled = true;
							paymentDateDatePicker.IsEnabled = true;
							G.statusTextBlock.Text = "How much was this check for?";
							amountTextBox.IsEnabled = true;
						}

					}
					else
					{
						paymentDateDatePicker.Text = DateTime.Today.ToShortDateString();
						SetPaymentTypeID(DocTypeID);
						G.statusTextBlock.Text = "How much was this check for?";
					}



				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show("You Suck! You Jackass!!!");
					paymentDateDatePicker.SelectedDate = DateTime.Today;
					SetPaymentTypeID(DocTypeID);
					G.statusTextBlock.Text = "How much was this check for?";
				}



			}
			else if (payment != null)
				DisplayPayment(payment);


		}

		public void DisplayPayment(DTO_Payment payment)
		{
			amountTextBox.Value = (decimal)payment.Amount;
			SetPaymentTypeID(payment.PaymentDescriptionID);
			paymentDateDatePicker.SelectedDate = payment.PaymentDate;
		}

		async private void OnInit(DTO_Claim claim, int DocTypeId)
		{
			try
			{

				//await s1.GetPaymentsByClaimID(claim);
				//	s1.PaymentsList.ForEach(x => Payments.Add(x));


			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("Payment Date Error Code " + paymentDateDatePicker.Text + "-" + Claim.ToString() + "--" + PaymentDescriptionID + " Report this error to IT Dept." + "\r\n" + ex.ToString());

			}

		}

		private void paymentDateDatePicker_LostFocus(object sender, RoutedEventArgs e)
		{
			if (paymentDateDatePicker.SelectedDate.HasValue)
				PaymentDate = paymentDateDatePicker.SelectedDate.Value;
		}


		private void amountTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

			//if (amountTextBox.Text == string.Empty) amountTextBox.Value = 0;
			if (amountTextBox.Value > 0) SubmitScopeEntry.IsEnabled = true;

		}


		private void CancelScopeEntry_Click(object sender, RoutedEventArgs e)
		{
			G.ReadyToUpdate = true;
			G.updateUI();
		}

		async private void SubmitScopeEntry_Click(object sender, RoutedEventArgs e)
		{

			if (paymentDateDatePicker.SelectedDate != null && paymentDateDatePicker.SelectedDate <= DateTime.Today && amountTextBox.Value > 0)
			{
				SetPaymentTypeID(DocTypeID);
				DTO_Payment p = new DTO_Payment();

				p.Amount = (double)amountTextBox.Value;
				p.PaymentDate = paymentDateDatePicker.SelectedDate.Value;
				p.PaymentDescriptionID = PaymentDescriptionID;
				p.ClaimID = Claim.ClaimID;
				p.PaymentTypeID = 1;
				try
				{

					await s1.AddPayment(p);
					//		UploadImage(SelectFile());
				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.ToString());

				}


				if (s1.Payment.Message == null)
				{
					// TODO: Upload the pic of check.
					//TODO:  Add Claim Document Entry. Taken Care of on upload. But the update of the claim status still needs updating;

					var cs = new DTO_ClaimStatus();
					cs.ClaimID = Claim.ClaimID;
					cs.ClaimStatusDate = DateTime.Today;
					cs.ClaimStatusTypeID = ClaimStatusType;
					try
					{


						await s1.UpdateClaimStatuses(cs);

					}
					catch (Exception ex)
					{
						System.Windows.Forms.MessageBox.Show(ex.ToString());
					}

					System.Windows.MessageBox.Show("Payment Added.");

				}
				else
				{
					System.Windows.MessageBox.Show(s1.Payment.Message);
				}
				G.ReadyToUpdate = true;
				f.Navigate(new MRNLogo1());
				G.updateUI();
			}
		}





		private void DisplayPayment(DTO_Claim claim, int paymentDescriptionType)
		{
			System.Windows.Forms.MessageBox.Show("On " + s1.PaymentsList.Find(x => x.ClaimID == claim.ClaimID && x.PaymentDescriptionID == paymentDescriptionType).PaymentDate.ToString() + " a payment was made for the amount of $ " + s1.PaymentsList.Find(x => x.ClaimID == claim.ClaimID && x.PaymentDescriptionID == paymentDescriptionType).Amount.ToString());
		}


		int SetPaymentTypeID(int docTypeID)
		{
			switch (docTypeID)
			{
				case 13:
					{
						PaymentDescriptionID = 1;
						PaymentDescriptionTextBlock.Text = "First/Deposit Check";
						ClaimStatusType = 7;

						return 1;
					}
				case 14:
					{
						PaymentDescriptionID = 5;
						PaymentDescriptionTextBlock.Text = "Deductible Check";
						ClaimStatusType = 21;
						return 5;
					}
				case 15:
					{
						PaymentDescriptionID = 3;
						PaymentDescriptionTextBlock.Text = "Depreciation Check";
						ClaimStatusType = 20;
						return 3;
					}
				case 16:
					{
						PaymentDescriptionID = 2;
						PaymentDescriptionTextBlock.Text = "Supplemental Check";
						ClaimStatusType = 18;

						return 2;
					}
				default:
					{
						PaymentDescriptionID = 4;
						PaymentDescriptionTextBlock.Text = "Upgrade Check";

						return 4;
					}
			}
		}
		async public Task<bool> CheckFileExist(int cdt = 0)
		{                                                           //the worker function to callback after determining if the file exists in the location that has been picked if so it will ask what would you like to do with it.
			try
			{

				await s1.GetPaymentsByClaimID(Claim);


			}
			catch (Exception ex)
			{

				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			if (s1.ClaimDocumentsList.Exists(x => x.DocTypeID == PaymentDescriptionID))
				return true;
			else return false;
		}



		string GetDocumentTypeByID(int doctypeid)
		{
			return ((DTO_LU_ClaimDocumentType)s1.ClaimDocTypes.Where(t => t.ClaimDocumentTypeID == doctypeid)).ClaimDocumentType.ToString();
		}






		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			//	busyIndicator.IsBusy = false;
		}

		//Connects to a URL and attempts to download the file

	}
}

