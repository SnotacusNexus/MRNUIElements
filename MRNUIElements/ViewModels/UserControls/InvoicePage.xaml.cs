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

namespace MRNUIElements
{


	/// <summary>
	/// Interaction logic for InvoicePage.xaml
	/// </summary>
	public partial class InvoicePage : UserControl
	{
		bool savetodisk = false;
		public int InvoiceTypeID { get; set; }
		List<DTO_Vendor> VendorList = new List<DTO_Vendor>();
		DTO_Invoice Invoice = new DTO_Invoice();
		public DTO_Claim Claim { get; set; }
		List<DTO_ClaimVendor> ClaimVendorList = new List<DTO_ClaimVendor>();
		static ServiceLayer s1 = ServiceLayer.getInstance();

		public InvoicePage(DTO_Claim claim, int invoiceTypeID)
		{
			InitializeComponent();
			Claim = claim;
			InvoiceTypeID = invoiceTypeID;
			InitialDBFunctions();
			InvoiceDatePicker.SelectedDate = DateTime.Today;

			if (_busyindicator == null)
				_busyindicator = new Syncfusion.Windows.Controls.Notification.SfBusyIndicator();
			if (!_busyindicator.IsVisible)
				_busyindicator.Visibility = Visibility.Visible;
			_busyindicator.IsBusy = true;
			try
			{

				Invoice = (DTO_Invoice)s1.InvoicesList.Select(x => x.ClaimID == Claim.ClaimID && x.InvoiceTypeID == InvoiceTypeID);

				if (Invoice.InvoiceTypeID > 0)
				{
					var result = System.Windows.MessageBox.Show("A Payment of this type has already been recorded.", "UPDATE PAYMENT INFO FOR " + Claim + "?!?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);    //TODO add follow up message box would you like to up date it?
					if (result == System.Windows.MessageBoxResult.No)

					{
						textBox_Copy4.Value = (decimal)Invoice.InvoiceAmount;
						InvoiceDatePicker.SelectedDate = Invoice.InvoiceDate;
						InvoiceTypeTextBlock.Text = ((DTO_LU_InvoiceType)s1.InvoiceTypes[Invoice.InvoiceTypeID]).InvoiceType;
						VendorsList.SelectedIndex = Invoice.VendorID;

					}
					else SubmitScopeEntry.IsEnabled = true;

				}
			}
			catch (Exception ex)
			{

				SubmitScopeEntry_Click(this, new RoutedEventArgs { Source = this });
				
			}
		}

	
		async private void InitialDBFunctions()
		{
			if (Claim == null)
				await s1.GetAllClaims();

			await s1.GetAllVendors();

			await s1.GetAllClaimVendors();
			while (s1.VendorsList.Count < 1)
				await Task.Delay(1);

			await s1.GetAllClaimVendors();

			_busyindicator.IsBusy = false;
			if (_busyindicator.IsVisible)
			_busyindicator.Visibility = Visibility.Collapsed;
			foreach (DTO_Vendor v in s1.VendorsList)
			{
				VendorList.Add(v);
			}
			foreach (DTO_ClaimVendor cv in s1.ClaimVendorsList)
			{
				ClaimVendorList.Add(cv);
			}
			this.InvoiceTypeList.DataContext = s1.InvoiceTypes;
			this.VendorsList.DataContext = s1.VendorsList;
			this.InvoiceTypeList.ItemsSource = s1.InvoiceTypes;
			this.VendorsList.ItemsSource = s1.VendorsList;
			this.InvoiceDatePicker.SelectedDate = DateTime.Today;
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


				if ((Claim != null) && (VendorsList.SelectedIndex > -1) && InvoiceTypeID>0 && (InvoiceDatePicker.SelectedDate.HasValue) && (textBox_Copy4.Value > 0))
			{
				DTO_ClaimVendor cv = new DTO_ClaimVendor();
				DTO_Vendor vendor = new DTO_Vendor();
				// s1.Vendor.VendorID = 7;
				DTO_Invoice i = new DTO_Invoice();

				i.ClaimID = Claim.ClaimID;
				i.InvoiceTypeID = ((DTO_LU_InvoiceType)InvoiceTypeList.SelectedValue).InvoiceTypeID;
				i.VendorID = ((DTO_Vendor)VendorsList.SelectedValue).VendorID;
				i.InvoiceAmount = (double)textBox_Copy4.Value;
				i.InvoiceDate = InvoiceDatePicker.SelectedDate.Value;
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
	}
}
