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

namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for ModifyClaimActivity.xaml
    /// </summary>
    public partial class ModifyClaimActivity : Page
    {
		
		public ModifyClaimActivity(int nActionType)
        {
            InitializeComponent();

			this.NavigationService.Navigate(GetPage(nActionType));
			
		}

		//this.NavigationService.Navigate(Pg);
		private Page GetPage(int i)
		{
			Page Pg = null;

			switch (i)
			{
				case 1:
					return new ContestPage();
				case 2:
					return new ClaimDetailsPage();
				case 3:
					return new CustomerAgreement();
				case 4:		
					return new DrawPlanePage();
				case 5:
					return new MyMRNHUDPage();
				case 6:
					return new SupplementPage();
				case 7:
					return new CapOutPage();
				case 8:	
					return new RoofOrderPage();
				default:
					return Pg;
			}
			
		}
		private void LogOut(object sender, RoutedEventArgs e)
		{
			Login Page = new Login();
			this.NavigationService.Navigate(Page);
		}
    }
}
