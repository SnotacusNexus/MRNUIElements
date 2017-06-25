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
using MRNUIElements.Controllers;
using MRNNexus_Model;

namespace MRNUIElements
{

	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : Page
	{



		static ServiceLayer s1 = ServiceLayer.getInstance();
		public DTO_User user = new DTO_User();

		public int i = 0;


		public Login()
		{

			InitializeComponent();
			LoginBtn.IsEnabled = false;

			// 	 user.Username = UserName.Text;
			//	 user.Pass = PasswordBox.Password;
			user.Username = "aharvey@gmail.com";
			user.Pass = "Harvey1214";

			AuthorizeLogin(user);
		}


		async private void LoginClick(object sender, RoutedEventArgs e)
		{
			LoginBtn.IsEnabled = false;
			Controllers.Login login = new Controllers.Login();

			await login.UserLogin(UserName, PasswordBox);

			if (login.IsEmployeeLoggedIn)
			{
				var menuBar = ((MainWindow)Application.Current.MainWindow).menuBar.IsEnabled = true;
		//		Schedule homePage = new Schedule();
		//		this.NavigationService.Navigate(homePage);
			}
			else
			{

				LoginBtn.IsEnabled = true;
				MessageBox.Show(ServiceLayer.getInstance().LoggedInEmployee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			/*LoginBtn.IsEnabled = false;

			
			// 	 user.Username = UserName.Text;
			//	 user.Pass = PasswordBox.Password;
			user.Username = "aharvey@gmail.com";
			user.Pass = "Harvey1214";

			AuthorizeLogin(user);*/
		}
		async private void RegisterNewUser(object sender, RoutedEventArgs e)
		{
			/*
			var User = new DTO_User();
			User.EmployeeID =((DTO_User)sender).EmployeeID; 
			User.PermissionID = ((DTO_User)sender).PermissionID;
			await s1.RegisterUser((DTO_User)sender);*/
		}
		public static DTO_Employee getCurrentLogInUser()
		{
			return s1.LoggedInEmployee;
		}

		async private void AuthorizeLogin(DTO_User user)
		{
			//DrawMe dm = new DrawMe();
			//dm.Show();


			bool b = false;
			while (!b)
			{
				BI.IsBusy = true;
				b = await BuildLookupLists();
				BI.IsBusy = true; ;
				await s1.Login(user);
				getCurrentLogInUser();
				BI.IsBusy = false;
			}
			int j = 3;
			LoginAs Page = new LoginAs();
			//	NexusHome Page = new NexusHome();
			StringBuilder s = new StringBuilder();
			s.Append("The username and password combination is not what is on file.  / n / r You have failed to login ");
			s.Append(i.ToString() + " of " + j.ToString() + " times. /r/n If you fail " + (j - i).ToString() + " more time");


			if (j - i > 1)
			{
				s.Append("'s");
			}

			s.Append(" your account will be locked until administration restores your credentials.");




			if (s1.LoggedInEmployee != null)
			{
				var menuBar = ((MainWindow)Application.Current.MainWindow).menuBar.IsEnabled = true;

				this.NavigationService.Navigate(Page);
			}

			else MessageBox.Show(s.ToString(), "Login Failure", MessageBoxButton.OK, MessageBoxImage.Error);

			LoginBtn.IsEnabled = true;


		}
		async private void loginBtn_Click(object sender, RoutedEventArgs e)
		{
			LoginBtn.IsEnabled = false;
			Controllers.Login login = new Controllers.Login();

			await login.UserLogin(UserName, PasswordBox);

			if (login.IsEmployeeLoggedIn)
			{
				var menuBar = ((MainWindow)Application.Current.MainWindow).menuBar.IsEnabled = true;
//				Schedule homePage = new Schedule();
	//			this.NavigationService.Navigate(homePage);
			}
			else
			{

				LoginBtn.IsEnabled = true;
				MessageBox.Show(ServiceLayer.getInstance().LoggedInEmployee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}
		async public Task<bool> BuildLookupLists()
		{
			await s1.GetClaimDocumentTypes();
			await s1.GetEmployeeTypes();
			await s1.GetAppointmentTypes();
			await s1.GetInvoiceTypes();
			await s1.GetKnockResponseTypes();
			await s1.GetLeadTypes();
			await s1.GetPayDescriptions();
			await s1.GetPayFrequencies();
			await s1.GetPaymentTypes();
			await s1.GetPayTypes();
			await s1.GetPermissions();
			await s1.GetProducts();
			await s1.GetProductTypes();
			await s1.GetRidgeMaterialTypes();
			await s1.GetScopeTypes();
			await s1.GetUnitsOfMeasure();
			await s1.GetAdjustmentResults();
			await s1.GetAllPayments();
			await s1.GetAllClaims();
			await s1.GetAllScopes();
			await s1.GetClaimStatusTypes();
			await s1.GetAllVendors();
			return true;
		}

		private void BI_LostFocus(object sender, RoutedEventArgs e)
		{
			BI.IsBusy = false;
		}
	}
}
