using System;
using System.Collections.Generic;
using System.Collections;
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
using static MRNUIElements.MainWindow;
using System.Collections.ObjectModel;
using static MRNUIElements.Utilities;
using System.Threading;

namespace MRNUIElements
{


	/// <summary>
	/// Interaction logic for InvoicePage.xaml
	/// </summary>
	public partial class InvoicePage : PageFunction<object>
	{
		bool savetodisk = false;
		List<DTO_Vendor> VendorList = new List<DTO_Vendor>();
		public DTO_Claim Claim { get; set; }
		 List<DTO_ClaimVendor> ClaimVendorList = new List<DTO_ClaimVendor>();
		static public ServiceLayer s1 = ServiceLayer.getInstance();
		static public ObservableCollection<DTO_Invoice> InvoiceCollection = new ObservableCollection<DTO_Invoice>();

	 public InvoicePage(DTO_Claim claim = null,int invoiceTypeID = 0, DTO_Invoice invoice = null)
		{		  
				InitializeComponent();
			InitialDBFunctions();
			if (claim != null)
				this.Claim = claim;

			/*
			var cppu = new ClaimPickerPopUp();
			try
			{
				if (string.IsNullOrEmpty(Claim.ToString()))
					if (claim != null)
					{
						Claim = claim;

					}
					else
					{
						cppu.ShowDialog();


					}

			}

			catch (Exception ex)
			{

				System.Windows.Forms.MessageBox.Show("No Claim Selected. You must have found the back door. Try coming through the front door.");
			}
			finally
			{

				//TODO Build Claim Selection Mini Window for pop up with filtered list based on user creds.


			}
			




			if (Claim != null)                  // overkill
				if (s1.InvoicesList.Exists(x => x.ClaimID == this.Claim.ClaimID && x.InvoiceTypeID == ((DTO_LU_InvoiceType)this.InvoiceTypeList.SelectedItem).InvoiceTypeID) )
				{
				/*	var result = System.Windows.MessageBox.Show("A Payment of this type has already been recorded.", "UPDATE PAYMENT INFO FOR " + Claim + "?!?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);    //TODO add follow up message box would you like to up date it?
					if (result == System.Windows.MessageBoxResult.No) 
						DisplayInvoice(Claim, ((DTO_LU_InvoiceType)InvoiceTypeList.SelectedItem).InvoiceTypeID);
				*/
			//new MainWindow().MRNClaimNexusMainFrame.Navigate(new GetClaimsPage());
			//}  */
			//	if (!_busyindicator.IsVisible)
			//	_busyindicator.Visibility = Visibility.Visible;
			//_busyindicator.IsBusy = true;
			if (Claim == null)
			{
				System.Windows.Forms.MessageBox.Show("You have to select a claim first.");
				return;
			}
				while (s1.VendorsList.Count()<1)
						Thread.Sleep(1);
			if (invoice != null)
			{
				

			
				
				
					
				
				
				textBox_Copy4.Value = (decimal)invoice.InvoiceAmount;
				((DTO_Vendor)VendorsList.SelectedValue).VendorID = invoice.VendorID;
				((DTO_LU_InvoiceType)InvoiceTypeList.SelectedValue).InvoiceTypeID = invoice.InvoiceTypeID;
				InvoiceDatePicker.SelectedDate = invoice.InvoiceDate;
			}
		
			
		}
		private void AddVendor_Click(object sender, RoutedEventArgs e)
		{

		}

		
		async private void InitialDBFunctions()
		{
			if (Claim == null)
				await s1.GetAllClaims();

			await s1.GetAllVendors();
			await s1.GetInvoicesByClaimID(Claim);
			await s1.GetAllClaimVendors();
			while (s1.VendorsList.Count < 1)
				await Task.Delay(1);

			//await s1.GetAllClaimVendors();

			//_busyindicator.IsBusy = false;
			//if (_busyindicator.IsVisible)
			//_busyindicator.Visibility = Visibility.Collapsed;

			foreach (var a in s1.InvoicesList)
				InvoiceCollection.Add(a);

			foreach (DTO_Vendor v in s1.VendorsList)
			{
				VendorList.Add(v);
			}
			  foreach(DTO_ClaimVendor cv in s1.ClaimVendorsList)
			{
				ClaimVendorList.Add(cv);
			}

			this.InvoiceTypeList.DataContext = s1.InvoiceTypes;
			this.VendorsList.DataContext = s1.VendorsList;
			this.InvoiceTypeList.ItemsSource = s1.InvoiceTypes;
			this.VendorsList.ItemsSource = s1.VendorsList;
			this.InvoiceDatePicker.SelectedDate = DateTime.Today;
			this.listview.ItemsSource = InvoiceCollection;
		}

		async private void SubmitScopeEntry_Click(object sender, RoutedEventArgs e)
		{

			/*
			try
			{
				await s1.GetClaimVendorsByClaimID(Claim);

			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}

				   */


			if ((Claim != null) && (VendorsList.SelectedIndex > -1) && (InvoiceTypeList.SelectedIndex > -1) && (InvoiceDatePicker.SelectedDate.HasValue) && (textBox_Copy4.Value>0))
				  {
					DTO_ClaimVendor cv = new DTO_ClaimVendor();
					DTO_Vendor vendor = new DTO_Vendor();
				// s1.Vendor.VendorID = 7;
					DTO_Invoice i = new DTO_Invoice();

					i.ClaimID = Claim.ClaimID;
					i.InvoiceTypeID = ((DTO_LU_InvoiceType)InvoiceTypeList.SelectedValue).InvoiceTypeID;
					i.VendorID = ((DTO_Vendor)VendorsList.SelectedValue).VendorID;
					i.InvoiceAmount = (double)textBox_Copy4.Value;
					i.InvoiceDate = (DateTime)InvoiceDatePicker.SelectedDate;
					i.Paid = true;

				try
				{
					await s1.AddInvoice(i);
				}
				catch (Exception ex)
				{

					System.Windows.Forms.MessageBox.Show(ex.ToString());
				}
					cv.VendorID = ((DTO_Vendor)VendorsList.SelectedValue).VendorID;
					cv.ClaimID = Claim.ClaimID;
					cv.ServiceTypeID = ((DTO_LU_InvoiceType)InvoiceTypeList.SelectedValue).InvoiceTypeID;
				try
				{
					await s1.AddClaimVendor(cv);
				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.ToString());

				}

			}
			else MessageBox.Show("Select a date, Invoice Type, Invoice Amount > 0  and a Vendor");



			if (s1.Invoice.Message == null)
				{
				MessageBox.Show(s1.Invoice.InvoiceID.ToString());
				}
			else
				{
				MessageBox.Show(s1.Invoice.Message);
				}

		}

		private void CancelScopeEntry_Click(object sender, RoutedEventArgs e)
		{
			//CustomerAgreement inspectionspage = new CustomerAgreement();
			//new MRNUIElements.MainWindow().MRNClaimNexusMainFrame.NavigationService.Navigate(inspectionspage);
		}

	private void textBox_Copy4_TextChanged(object sender, TextChangedEventArgs e)
		{

			if (textBox_Copy4.Text == string.Empty) textBox_Copy4.Value = 0;
			if (textBox_Copy4.Text != string.Empty) SubmitScopeEntry.IsEnabled = true;

		}

		private void InvoiceDatePicker_CalendarClosed(object sender, RoutedEventArgs e)
		{

		}

	

		private void textBox_Copy4_GotFocus(object sender, RoutedEventArgs e)
		{
			textBox_Copy4.SelectAll();
		}

		private void toggleButton_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void comboBox1_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		//	InvoiceTypeList.Text = InvoiceTypeList.SelectedValue.ToString();
		}

		private void InvoiceTypeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}



	public class ClaimInvoice:ObservableCollection<ClaimInvoice>
	{
		public string VendorCompanyName { get; set; }
		public double InvoiceAmount { get; set; }
		public DateTime InvoiceDate { get; set; }
		public string InvoiceType { get; set; }
		public ClaimInvoice()
		{



		}

		async void db()
		{
			await Utilities.s1.GetAllInvoices();
			await Utilities.s1.GetAllVendors();
			while (Utilities.s1.InvoicesList == null)
				await Task.Delay(1);
			foreach (var i in Utilities.s1.InvoicesList)
			{
				 
				VendorCompanyName = Utilities.s1.VendorsList.Where(x => x.VendorID == i.VendorID).ToList()[0].CompanyName;
				InvoiceAmount = i.InvoiceAmount;
				InvoiceDate = i.InvoiceDate;
				InvoiceType = Utilities.s1.InvoiceTypes.Where(x => x.InvoiceTypeID == i.InvoiceTypeID).ToList()[0].InvoiceType.ToString();

				Add(this);
		
			}
		}
	}

}


