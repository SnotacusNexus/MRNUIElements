using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using MRNUIElements.Controllers;
using MRNNexus_Model;

namespace MRNUIElements
{
	
	/// <summary>
	/// Interaction logic for LoginAs.xaml
	/// </summary>
	public partial class LoginAs : Page
	{
		static LoginAs W;
		public static LoginAs getInstance()
		{
			if (W == null)
				W = new LoginAs();
			return W;
		}


		static ServiceLayer s1 = ServiceLayer.getInstance();

		public LoginAs()
		{
			InitializeComponent();
		}

		private void LoginAsSalesperson_Click(object sender, RoutedEventArgs e)
		{
			Claim_Administration Page = new Claim_Administration();
			NavigationService.Navigate(Page);
		}

		private void LoginAsAuditor_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new ClaimStartPage());

			
		}

		private void LoginAsAuditingAsst_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new CustomerAgreement());
		}
		

		private void LoginAsSalesManager_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Controllers.New_Inspection_Page());

		}

		private void LoginAsProdManager_Click(object sender, RoutedEventArgs e)
		{
			try
			{
                var CPD = new ClaimPickerPopUp();
                if ((bool)CPD.ShowDialog())

                    //	var claim = s1.ClaimsList.Single(x => x.ClaimID == 37);
                    NavigationService.Navigate(new Controllers.ClaimView(CPD.Claim));
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
		}

		private void LoginAsBoss_Click(object sender, RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new Controllers.StartClaim());
		}

		private void LoginAsGODMode_Click(object sender, RoutedEventArgs e)
		{
            var CPD = new ClaimPickerPopUp();
           
            if ((bool)CPD.ShowDialog())
            NavigationService.Navigate(new Controllers.ClaimView(CPD.Claim));
        }

		private void LoginAsSuperAdmin_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new MRNClaimConverter());
		}
	}
}
