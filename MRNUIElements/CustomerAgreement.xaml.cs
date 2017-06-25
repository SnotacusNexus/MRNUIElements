using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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



namespace MRNUIElements
{

	/// <summary>
	/// Interaction logic for CustomerAgreement.xaml
	/// </summary>
	public partial class CustomerAgreement : Page
	{
		static ServiceLayer s = ServiceLayer.getInstance();
		ObservableCollection<DTO_InsuranceCompany> insco = new ObservableCollection<DTO_InsuranceCompany>();
		//  ObservableCollection<DTO_InsuranceCompany> INSCO = new ObservableCollection<DTO_InsuranceCompany>();
		ObservableCollection<DTO_OrderItem> OrderItemCollection = new ObservableCollection<DTO_OrderItem>();


		int i = 1;

		public CustomerAgreement()
		{
			InitializeComponent();
			Getem();
			// InsuranceLU.ItemsSource = s.InsuranceCompaniesList;
		}

		async public void Getem()
		{
			try
			{


				await s.GetAllReferrers();
				await s.GetAllInsuranceCompanies();
				foreach (DTO_InsuranceCompany item in s.InsuranceCompaniesList)
				{
					insco.Add(item);

				}
				InsuranceLU.ItemsSource = insco;
				InspectionImages.ItemsSource = new ObservableCollection<string>() { "Item1", "Item2", "Item3", "Item4", "Item5", "Item6", "Item7", "Item8", "Item9" };

			}
			catch (Exception ex)
			{

				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
		}
		private void Customer_MouseEnter(object sender, MouseEventArgs e)
		{
			((TextBlock)sender).Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
		}


		private void Customer_MouseLeave(object sender, MouseEventArgs e)
		{
			((TextBlock)sender).Background = null;
		}
		#region Navigation
		

		private void Home(object sender, RoutedEventArgs e)
		{

			//NavigationService.Navigate(new NexusHome());

		}

		private void Roof_Inspection_Click(object sender, RoutedEventArgs e)
		{
		//	NavigationService.Navigate(new DrawPlanePage());
		}

		private void Exterior_Inspection_Click(object sender, RoutedEventArgs e)
		{
		//	NavigationService.Navigate(new ClaimItPage());
		}

		private void Edit_Inspection_Click(object sender, RoutedEventArgs e)
		{
		//	ClaimInspectionWizard Page = new ClaimInspectionWizard(i);

		}

		private void Gutter_Inspection_Click(object sender, RoutedEventArgs e)
		{
			//NavigationService.Navigate(new ContestPage());
		}

		private void Interior_Inspection_Click(object sender, RoutedEventArgs e)
		{
			//NavigationService.Navigate(new InteriorInspectionWizard());
		}



		private void Button_Click(object sender, RoutedEventArgs e)
		{
			AddClaim();

		}
		#endregion
		#region Add a claim


		async public void AddClaim()
		{



			#region Create New Instance Of DTO's needed
			DTO_Lead lead = new DTO_Lead();
			DTO_Address address = new DTO_Address();
			DTO_Claim claim = new DTO_Claim();
			DTO_Customer customer = new DTO_Customer();
			DTO_Inspection inspection = new DTO_Inspection();
			DTO_ClaimStatus claimStatus = new DTO_ClaimStatus();
			DTO_NewRoof newRoof = new DTO_NewRoof();
			DTO_Order order = new DTO_Order();
			DTO_OrderItem orderItem = new DTO_OrderItem();
			DTO_Scope scope = new DTO_Scope();



			DTO_Referrer referral = new DTO_Referrer();
			#endregion
			#region Populate Customer

			customer.FirstName = Cust_FirstName.Text;
			customer.MiddleName = Cust_MiddleName.Text;
			customer.LastName = Cust_LastName.Text;
			customer.Suffix = Cust_Suffix.Text;
			customer.PrimaryNumber = Cust_Primary_Phone.Text;
			customer.SecondaryNumber = Cust_Secondary_Phone.Text;
			customer.Email = Cust_Email_Address.Text;
			customer.MailPromos = false;


			#endregion
			#region Populate Address


			address.Address = Cust_Address.Text;
			address.Zip = Cust_Zipcode.Text;
			#endregion  
			#region Populate Referrer
			int referrerID = 0;
			referral.FirstName = Lead_FirstName.Text;
			referral.Zip = Lead_Zipcode.Text;
			referral.LastName = Lead_LastName.Text;
			referral.Suffix = Lead_Suffix.Text;
			referral.CellPhone = Lead_Primary_Phone.Text;
			referral.MailingAddress = Lead_Address.Text;
			referral.Email = Lead_Email_Address.Text;
			//CheckIfTheyExist if so get the referralID

			if (s.ReferrersList.Count > 0)
				foreach (DTO_Referrer r in s.ReferrersList)
				{
					if (r.Equals(referral))

						referrerID = r.ReferrerID;
					break;
				}
			try
			{

				if (referrerID == 0)
				{
					await s.AddReferrer(referral);
				}
				else referrerID = s.Referrer.ReferrerID;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());

			}
			//
			#endregion
			#region Populate Lead
			lead.Temperature = "W";
			lead.CreditToID = referrerID;
			lead.SalesPersonID = s.LoggedInEmployee.EmployeeID;
			lead.KnockerResponseID = null;
			lead.LeadDate = ContractDate.SelectedDate.Value;
			lead.LeadTypeID = 1;
			#endregion
			#region Claim Addition Underway
			try
			{
				await s.AddCustomer(customer);
				if (s.Cust.Message == null)
				{
					lead.CustomerID = s.Cust.CustomerID;
					address.CustomerID = s.Cust.CustomerID;
					claim.CustomerID = s.Cust.CustomerID;
					System.Windows.Forms.MessageBox.Show(s.Cust.CustomerID.ToString());
				}

				else System.Windows.Forms.MessageBox.Show(s.Cust.Message.ToString());

				#endregion
				#region Add Address
				await s.AddAddress(address);


				if (s.Address1.Message == null)
				{
					lead.AddressID = s.Address1.AddressID;
					System.Windows.Forms.MessageBox.Show(s.Address1.AddressID.ToString());
				}
				else
					System.Windows.Forms.MessageBox.Show(s.Address1.Message.ToString());
				await s.AddLead(lead);
				#endregion
				#region AddLead
				if (s.Lead.Message == null)
				{
					claim.LeadID = s.Lead.LeadID;
					System.Windows.Forms.MessageBox.Show(s.Lead.LeadID.ToString());
				}
				else
					System.Windows.Forms.MessageBox.Show(s.Lead.Message.ToString());

				#endregion
				#region Popuate Claim
				claim.MRNNumber = "MRN-" + s.Lead.SalesPersonID + "-" + s.Cust.CustomerID;
				claim.PropertyID = s.Address1.AddressID;
				claim.BillingID = claim.PropertyID;
				claim.LossDate = DateTime.Now.Date;
				claim.InsuranceCompanyID = InsuranceLU.SelectedIndex;


				//claim.InsuranceCompanyID = ((DTO_InsuranceCompany)InsuranceLU.SelectedItem).InsuranceCompanyID;
				if (MortgageHolder.Text != string.Empty)
					claim.MortgageCompany = MortgageHolder.Text;
				if (MortgageAcctNumber.Text != string.Empty)
					claim.MortgageAccount = MortgageAcctNumber.Text;

				#endregion
				#region Doing the damn thang
				#region Claim Being Added Here
				await s.AddClaim(claim);
				if (s.Claim.Message == null)
				{
					claim.LeadID = s.Lead.LeadID;
					System.Windows.Forms.MessageBox.Show("Congratulations You Have Successfully became a statistic! Your Claim and Experience is now associated with " + s.Claim.MRNNumber.ToString());
				}
				else
					System.Windows.Forms.MessageBox.Show(s.Lead.Message.ToString());
				#endregion
				#endregion
				//TODO: REMOVE DUMMY DATA AND SCRIPT IN ACTUAL GATHERING CODE
				#region	Dummy Data and Fixed Variable Must Remove Before Production
				bool hasscope = false;
				//HACK


				//scope?
				if (hasscope)
				{
					scope.ClaimID = claim.ClaimID;
					scope.Deductible = 1000;
					scope.Exterior = 600;
					scope.Gutter = 995;
					scope.Interior = 2040;
					scope.OandP = 900;
					scope.ScopeTypeID = 2;
					scope.Tax = 345.87;
					scope.Total = 80021.35;
					scope.RoofAmount = scope.Total - scope.Tax - scope.OandP - scope.Interior - scope.Gutter - scope.Exterior;
					try
					{
						await s.AddScope(scope);
					}
					catch (Exception ex)
					{


					}
				}
				#endregion
				// claimStatus


				//scope?

				// inspection

				//TODO: REMOVE DUMMY DATA AND SCRIPT IN ACTUAL GATHERING CODE
				//order?
				#region	Dummy Data and Fixed Variable Must Remove Before Production
				bool hasorder = false;
				#endregion
				//HACK

				#endregion

				#region OrderRoofSupplies
				if (hasorder)
				{
					order.ClaimID = claim.ClaimID;
					order.DateDropped = DateTime.Today.Date;
					order.DateOrdered = DateTime.Today.Subtract(TimeSpan.FromDays(1));
					order.ScheduledInstallation = DateTime.Today.AddDays(1);
					order.VendorID = 7;
					try
					{
						await s.AddOrder(order);
					}
					catch (Exception ex)
					{
					}

				}
				#endregion
				#region ROOF ORDER
				ObservableCollection<DTO_OrderItem> orderitems = new ObservableCollection<DTO_OrderItem>();


				orderItem.OrderID = s.Order.OrderID;
				orderItem.ProductID = 1;
				orderItem.Quantity = 99;



				//orderitems?

			}
			catch (Exception ex)
			{


			}

		}


		bool AddItemToOrder(DTO_Order Order, DTO_OrderItem OrderItem, double Quantity)
		{



			return true;

		}



		#endregion




		#region Update Claims Number on comboBox Selection Change
		private void InsuranceLU_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (InsuranceLU.SelectedIndex > -1 && InsuranceLU.SelectedIndex < insco.Count())
				if (!string.IsNullOrEmpty(insco[InsuranceLU.SelectedIndex].ClaimPhoneNumber))
					ClaimsPhoneNumber.Text = insco[InsuranceLU.SelectedIndex].ClaimPhoneNumber;
				else ClaimsPhoneNumber.Text = "No Number Available";
			else ClaimsPhoneNumber.Text = "No Number Available";

		}
		#endregion
	}
}









