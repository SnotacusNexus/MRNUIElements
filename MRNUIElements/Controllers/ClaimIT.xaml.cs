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
	/// Interaction logic for ClaimIT.xaml
	/// </summary>
	public partial class ClaimIT : Page
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		static MRNClaim MrnClaim = MRNClaim.getInstance();
		public ClaimIT()
		{
			InitializeComponent();
			ClaimIT.MrnClaim = MrnClaim;
		}

		private void Prevbutton_Click(object sender, RoutedEventArgs e)
		{
           NavigationService.GoBack();
            
		}

		private void InspectionButton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AddClaimInspection(MrnClaim));
		}

		async private void ClaimItbutton_Copy_Click(object sender, RoutedEventArgs e)
		{
            if(MrnClaim.r!=null)
            await s1.AddReferrer(MrnClaim.r);
            await s1.AddCustomer(MrnClaim.c);
            MrnClaim.c.CustomerID = s1.Cust.CustomerID;
            MrnClaim.a.CustomerID = MrnClaim.c.CustomerID;
            MrnClaim.Lead.CustomerID = MrnClaim.c.CustomerID;
            await s1.AddAddress(MrnClaim.a);
            MrnClaim.Lead.AddressID = s1.Address1.AddressID;
          //  MrnClaim.Lead.SalesPersonID = 10;
            //set temp for lead
            MrnClaim.Lead.Temperature = "W";
            await s1.AddLead(MrnClaim.Lead);
            MrnClaim._claim.LeadID = s1.Lead.LeadID;
            MrnClaim._claim.CustomerID = MrnClaim.c.CustomerID;
            MrnClaim._claim.PropertyID = MrnClaim._claim.BillingID = MrnClaim.Lead.AddressID;
            MrnClaim._claim.LossDate = lossDateDatePicker.SelectedDate.Value;
            //make this down there variable get from previous box about insurance coID
       //     MrnClaim._claim.InsuranceCompanyID = /*MrnClaim.ic.InsuranceCompanyID=*/10;
            MrnClaim._claim.IsOpen = true;
          //  MrnClaim._claim.MortgageAccount = "";
          //  MrnClaim._claim.MortgageCompany = "";
            MrnClaim._claim.InsuranceClaimNumber = "";
            MrnClaim._claim.MRNNumber = "MRN-" + MrnClaim.Lead.SalesPersonID.ToString() + "-" + MrnClaim.c.CustomerID.ToString();
            await s1.AddClaim(MrnClaim._claim);
			//NavigationService.Navigate(//This should point to ScheduleAdjustment)
		}

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
