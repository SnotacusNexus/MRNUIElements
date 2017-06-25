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

			var claim = (DTO_Claim)s1.ClaimsList.Where(x => x.ClaimID == 19);
			NavigationService.Navigate(new Controllers.ClaimView(claim));
		}

		private void LoginAsAuditingAsst_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new GetClaimsPage());
		}
		

		private void LoginAsSalesManager_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Controllers.New_Inspection_Page());

		}

		private void LoginAsProdManager_Click(object sender, RoutedEventArgs e)
		{
			var claim = s1.ClaimsList.Single(x => x.ClaimID == 19);
			NavigationService.Navigate(new Controllers.ClaimView(claim));

		}

		private void LoginAsBoss_Click(object sender, RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new Controllers.StartClaim());
		}

		private void LoginAsGODMode_Click(object sender, RoutedEventArgs e)
		{

		}

		private void LoginAsSuperAdmin_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
