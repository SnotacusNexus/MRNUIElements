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
	/// Interaction logic for LoginAs.xaml
	/// </summary>
	public partial class LoginAs : Page
	{
		public LoginAs()
		{
			InitializeComponent();
		}

		private void LoginAsSalesperson_Click(object sender, RoutedEventArgs e)
		{
			NexusHome Page = new NexusHome();
			NavigationService.Navigate(Page);
		}

		private void LoginAsAuditor_Click(object sender, RoutedEventArgs e)
		{

		}

		private void LoginAsAuditingAsst_Click(object sender, RoutedEventArgs e)
		{

		}

		private void LoginAsSalesManager_Click(object sender, RoutedEventArgs e)
		{

		}

		private void LoginAsProdManager_Click(object sender, RoutedEventArgs e)
		{

		}

		private void LoginAsBoss_Click(object sender, RoutedEventArgs e)
		{

		}

		private void LoginAsGODMode_Click(object sender, RoutedEventArgs e)
		{

		}

		private void LoginAsSuperAdmin_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
