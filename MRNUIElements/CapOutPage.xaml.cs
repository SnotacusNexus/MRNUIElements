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
using System.Printing;
using MRNUIElements.Controllers;
namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for CapOutPage.xaml
	/// </summary>
	public partial class CapOutPage : Page
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		

		public CapOutPage()
		{
			InitializeComponent();
			


		}
		private void LogOut(object sender, RoutedEventArgs e)
		{
			Login Page = new Login();
			this.NavigationService.Navigate(Page);
		}

		private void Print_Click(object sender, RoutedEventArgs e)
		{
			PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
			if (printDlg.ShowDialog() == true)
			{
				//get selected printer capabilities
				System.Printing.PrintCapabilities capabilities = printDlg.PrintQueue.GetPrintCapabilities(printDlg.PrintTicket);

				//get scale of the print wrt to screen of WPF visual
				double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / this.ActualWidth, capabilities.PageImageableArea.ExtentHeight /
							   this.ActualHeight);

				//Transform the Visual to scale
				this.LayoutTransform = new ScaleTransform(scale, scale);

				//get the size of the printer page
				Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);

				//update the layout of the visual to the printer page size.
				this.Measure(sz);
				this.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));

				//now print the visual to printer to fit on the one page.
				printDlg.PrintVisual(this, "First Fit to Page WPF Print");
			}

		}

		private void OKBtnClick(object sender, RoutedEventArgs e)
		{
			;
		}

		private void CancelBtnClick(object sender, RoutedEventArgs e)
		{
			;
		}

		private void ClaimPickerComboCO_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			OnInit(int.Parse(ClaimPickerComboCO.SelectedValue.ToString()));
		}

		private void PayoutCheckBoxCO_Checked(object sender, RoutedEventArgs e)
		{
			if (PayoutCheckBoxCO.IsChecked == false) PayoutCheckBoxCO.IsChecked = true;
			else PayoutCheckBoxCO.IsChecked = false;
		}

		private void PayoutSliderCO_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			;
		}

		async private void OnInit(int claimID)
		{
			ClaimPickerComboCO.ItemsSource = s1.ClaimsList;
			if (ClaimPickerComboCO.SelectedIndex != -1)
				claimID = s1.Claim.ClaimID;
			else { 
				s1.Claim.ClaimID = claimID; }
			PayoutCheckBoxCO.IsChecked = false;
			PayoutSliderCO.IsEnabled = false;
			s1.Inspection.ClaimID = claimID;
			await s1.GetSumOfPaymentsByClaimID(s1.Claim);
			await s1.GetSumOfInvoicesByClaimID(s1.Claim);
			await s1.GetPlanesByInspectionID(s1.Inspection);
			DoMath();


			
		}
		private double DoMath()
		{
			DTO_CalculatedResults cr = new DTO_CalculatedResults();

			double numsq = 0;
			foreach (DTO_Plane pl in s1.PlanesList)
			{
				numsq += (double)pl.SquareFootage;
			}
			double tc = 0, tp = 0;
			int kf = 0;
			int totalsq = int.Parse(numsq.ToString());
			if (totalsq > 39) kf = 500;
			else kf = 250;
			LeadFeeCO.SetValue(ContentProperty, kf);
			string FinishedName="";
			FinishedName = "";
			if (s1.Cust.FirstName != string.Empty)
				FinishedName += s1.Cust.FirstName + " ";

			if (s1.Cust.MiddleName != string.Empty)
				FinishedName += s1.Cust.MiddleName + " ";

			if (s1.Cust.LastName != string.Empty)
				FinishedName += s1.Cust.LastName + " ";

			if (s1.Cust.Suffix != string.Empty)
				FinishedName += s1.Cust.Suffix;


			CustomerNameCO.SetValue(ContentProperty, FinishedName);
			CustomerAddressCO.SetValue(ContentProperty, s1.Address1);
		//	CityStateZipCO.SetValue(ContentProperty, s1.A)
			TotCollectedCO.SetValue(ContentProperty, s1.SumOfPayments);
			TotalExpenseCO.SetValue(ContentProperty, s1.SumOfInvoices);
			tc = s1.SumOfInvoices;
			tp = s1.SumOfPayments;
			double oh = tc * .1;
			OverheadCO.SetValue(ContentProperty, oh);
			int sd = 500;
			InitialDrawCO.SetValue(ContentProperty, sd);

			double profit = tp - tc - oh - kf;
			TotalProfitCO.SetValue(ContentProperty, profit);
			double split = profit / 2;
			SalesSplitCO.SetValue(ContentProperty, split);
			double mrnpay = split;
			MRNDueCO.SetValue(ContentProperty, mrnpay);

			double smpay = 100;
			double mrnthp = mrnpay - smpay;
			double trueoh = oh - smpay;
			double costpersq = tc / numsq;
			double profitpersq = profit / numsq;
			double profitmargin = tp / tc;
			double pay = split - sd;

			SalespersonDueCO.SetValue(ContentProperty, pay);
			return pay;







		}
	}
}
