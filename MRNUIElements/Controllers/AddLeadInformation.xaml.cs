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

namespace MRNUIElements.Controllers
{
	
	/// <summary>
	/// Interaction logic for AddLeadInformation.xaml
	/// </summary>
	public partial class AddLeadInformation 
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		public static MRNClaim MrnClaim;
		public bool isReferral { get; set; } = false;

		
		//On to Customer
		DTO_Lead l = new DTO_Lead();
		DTO_ClaimContacts cc = new DTO_ClaimContacts();
		DTO_Claim c = new DTO_Claim();
		DTO_Referrer r = new DTO_Referrer();
		//On to Customer
		

		public MRNClaim GetInstance()
		{
			if (MrnClaim == null)
				MrnClaim = new MRNClaim();
			return MrnClaim;
		}

		public AddLeadInformation(MRNClaim MrnClaim)
		{
			InitializeComponent();

			AddLeadInformation.MrnClaim = MrnClaim;
			LeadTypecomboBox.ItemsSource = s1.LeadTypes;
			SalesPersonInfoCombo.ItemsSource = s1.EmployeesList.Where(x => x.EmployeeTypeID == 13);

		}

		


		int GetLeadType()
		{
			




			//FunctionPage to get lead type 
			return ((DTO_LU_LeadType)LeadTypecomboBox.SelectionBoxItem).LeadTypeID;
		}
		private void button_Click(object sender, RoutedEventArgs e)
		{
		
			l.LeadDate = DateTime.Today;
			l.LeadTypeID = GetLeadType();
			// table customer table or employee table

			if (isReferral)
			{
				r.FirstName = firstNameTextBox.Text;
				r.LastName = lastNameTextBox.Text;
				r.Suffix = suffixTextBox.Text;
				r.CellPhone = cellPhoneTextBox.Text;
				r.Email = emailTextBox.Text;
				r.MailingAddress = mailingAddressTextBox.Text;
				r.Zip = zipTextBox.Text;
				
				MrnClaim.r = r;
			}
			l.AddressID = MrnClaim.a.AddressID;
			c.PropertyID = MrnClaim.a.AddressID;
			MrnClaim.Lead = l;
			MrnClaim._claim = c;
			MrnClaim.cc = cc;

			//Get KnockerInfo Return
			

			
				 
			NavigationService.Navigate(new AddClaimCustomer(MrnClaim));
		}

		private void ExistingContactInfoCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch (((DTO_LU_LeadType)LeadTypecomboBox.SelectedItem).LeadTypeID)
			{
				case 1:
					{
						PreviousReferrercheckBox.Visibility = Visibility.Hidden;
						EmployeeGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
						if (((DTO_Employee)ExistingContactInfoCombo.SelectedItem) != null)
							cc.KnockerID = l.CreditToID = (int)((DTO_Employee)ExistingContactInfoCombo.SelectedItem).EmployeeID;
						l.LeadTypeID = 1;
						
						
						break;

					}
				case 2:
					{
						isReferral = true;
						PreviousReferrercheckBox.Visibility = Visibility.Visible;
						ReferralGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
						l.LeadTypeID = 2;
						if (((DTO_Referrer)ExistingContactInfoCombo.SelectedItem) != null)
							l.CreditToID = (int)((DTO_Referrer)ExistingContactInfoCombo.SelectedItem).ReferrerID;
					
						break;
					}
				case 3:
					{
						PreviousReferrercheckBox.Visibility = Visibility.Hidden;
						CustomerGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
						l.LeadTypeID = 3;
						if (((DTO_Customer)ExistingContactInfoCombo.SelectedItem) != null)
							l.CreditToID = (int)((DTO_Customer)ExistingContactInfoCombo.SelectedItem).CustomerID;
					
						break;
					}
				case 4:
					{
						PreviousReferrercheckBox.Visibility = Visibility.Hidden;
						l.LeadTypeID = 4;
						l.CreditToID = 0;
					

						break;
					}

				case 5:
					{
						PreviousReferrercheckBox.Visibility = Visibility.Hidden;
						EmployeeGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
						l.LeadTypeID = 5;
						if (((DTO_Employee)ExistingContactInfoCombo.SelectedItem)!=null)
							l.CreditToID = (int)((DTO_Employee)ExistingContactInfoCombo.SelectedItem).EmployeeID;
						
						break;
					}
				default:
					break;
			} //sets if to look up info from referrer
		}

		private void LeadTypecomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
			switch (((DTO_LU_LeadType)LeadTypecomboBox.SelectedItem).LeadTypeID)
			{
				case 1:
					{
						ContactLookupDisplay(true);
						ShowContactInfoDisplay(1);
						if (PreviousReferrercheckBox.Visibility == Visibility.Visible)
							PreviousReferrercheckBox.Visibility = Visibility.Hidden;
						ExistingContactInfoCombo.ItemsSource = s1.EmployeesList.Where(x => x.EmployeeTypeID == 14);
						
						break;

					}
				case 2:
					{
						
						
						ShowContactInfoDisplay(2);
						if (PreviousReferrercheckBox.Visibility != Visibility.Visible)
							PreviousReferrercheckBox.Visibility = Visibility.Visible;
						ExistingContactInfoCombo.ItemsSource = s1.ReferrersList;
						break;
					}
				case 3:
					{
						ContactLookupDisplay(true);
						ShowContactInfoDisplay(3);
						if (PreviousReferrercheckBox.Visibility == Visibility.Visible)
							PreviousReferrercheckBox.Visibility = Visibility.Hidden;
						ExistingContactInfoCombo.ItemsSource = s1.CustomersList;
						
						break;
					}
				case 4:
					{
						ContactLookupDisplay(true);
						ShowContactInfoDisplay(4);
						if (PreviousReferrercheckBox.Visibility == Visibility.Visible)
							PreviousReferrercheckBox.Visibility = Visibility.Hidden;

						break;
					}

				case 5:
					{
						ContactLookupDisplay(true);
						ShowContactInfoDisplay(5);
						if(PreviousReferrercheckBox.Visibility == Visibility.Visible)
						PreviousReferrercheckBox.Visibility = Visibility.Hidden;
						ExistingContactInfoCombo.ItemsSource = s1.EmployeesList.Where(x => x.EmployeeTypeID == 13);

						break;
					}
				default:
					break;
			} //sets if to look up info from referrer

		}
		bool ContactLookupDisplay(bool Enable)
		{
			if (Enable)
			{
				if (ExistingContactInfoCombo.Visibility != Visibility.Visible)

					ExistingContactInfoCombo.Visibility = Visibility.Visible;

			}
			else
			{
				if (ExistingContactInfoCombo.Visibility == Visibility.Visible)

					ExistingContactInfoCombo.Visibility = Visibility.Hidden;
			}

			return Enable;
		}
		int ShowContactInfoDisplay(int Display)
		{
			switch (Display)
			{
				case 1:
					{

						ReferralGrid.Visibility = Visibility.Hidden;
						EmployeeGrid.Visibility = Visibility.Visible;
						CustomerGrid.Visibility = Visibility.Hidden;
						AddressGrid.Visibility = Visibility.Visible;

						//if (Lead_FirstName.Visibility != Visibility.Visible)
						//	Lead_FirstName.Visibility = Visibility.Visible;
						//if (Lead_MiddleName.Visibility != Visibility.Visible)
						//	Lead_MiddleName.Visibility = Visibility.Visible;
						//if (Lead_LastName.Visibility != Visibility.Visible)
						//	Lead_LastName.Visibility = Visibility.Visible;
						//if (Lead_Suffix.Visibility != Visibility.Visible)
						//	Lead_Suffix.Visibility = Visibility.Visible;
						//if (Lead_Address.Visibility != Visibility.Visible)
						//	Lead_Address.Visibility = Visibility.Visible;
						//if (Lead_City.Visibility != Visibility.Visible)
						//	Lead_City.Visibility = Visibility.Visible;
						//if (Lead_State.Visibility != Visibility.Visible)
						//	Lead_State.Visibility = Visibility.Visible;
						//if (Lead_Zipcode.Visibility != Visibility.Visible)
						//	Lead_Zipcode.Visibility = Visibility.Visible;
						//if (Lead_Primary_Phone.Visibility != Visibility.Visible)
						//	Lead_Primary_Phone.Visibility = Visibility.Visible;
						//if (Lead_Secondary_Phone.Visibility != Visibility.Visible)
						//	Lead_Secondary_Phone.Visibility = Visibility.Visible;
						//if (Lead_Email_Address.Visibility != Visibility.Visible)
						//	Lead_Email_Address.Visibility = Visibility.Visible;
						return Display;
					}
				case 2:
					{


						ReferralGrid.Visibility = Visibility.Visible;
						EmployeeGrid.Visibility = Visibility.Hidden;
						CustomerGrid.Visibility = Visibility.Hidden;
						AddressGrid.Visibility = Visibility.Hidden;
						//if (Lead_FirstName.Visibility == Visibility.Visible)
						//	Lead_FirstName.Visibility = Visibility.Hidden;
						//if (Lead_MiddleName.Visibility == Visibility.Visible)
						//	Lead_MiddleName.Visibility = Visibility.Hidden;
						//if (Lead_LastName.Visibility == Visibility.Visible)
						//	Lead_LastName.Visibility = Visibility.Hidden;
						//if (Lead_Suffix.Visibility == Visibility.Visible)
						//	Lead_Suffix.Visibility = Visibility.Hidden;
						//if (Lead_Address.Visibility == Visibility.Visible)
						//	Lead_Address.Visibility = Visibility.Hidden;
						//if (Lead_City.Visibility == Visibility.Visible)
						//	Lead_City.Visibility = Visibility.Hidden;
						//if (Lead_State.Visibility == Visibility.Visible)
						//	Lead_State.Visibility = Visibility.Hidden;
						//if (Lead_Zipcode.Visibility == Visibility.Visible)
						//	Lead_Zipcode.Visibility = Visibility.Hidden;
						//if (Lead_Primary_Phone.Visibility == Visibility.Visible)
						//	Lead_Primary_Phone.Visibility = Visibility.Hidden;
						//if (Lead_Secondary_Phone.Visibility == Visibility.Visible)
						//	Lead_Secondary_Phone.Visibility = Visibility.Hidden;
						//if (Lead_Email_Address.Visibility == Visibility.Visible)
						//	Lead_Email_Address.Visibility = Visibility.Hidden;
						return Display;
					}
				case 3:
					{


						ReferralGrid.Visibility = Visibility.Hidden;
						EmployeeGrid.Visibility = Visibility.Hidden;
						CustomerGrid.Visibility = Visibility.Visible;
						AddressGrid.Visibility = Visibility.Hidden;

						return Display;

					}

				case 4:
					{

						ReferralGrid.Visibility = Visibility.Hidden;
						EmployeeGrid.Visibility = Visibility.Hidden;
						CustomerGrid.Visibility = Visibility.Hidden;
						AddressGrid.Visibility = Visibility.Hidden;

						return Display;
					}

				case 5:
					{

						ReferralGrid.Visibility = Visibility.Hidden;
						EmployeeGrid.Visibility = Visibility.Visible;
						CustomerGrid.Visibility = Visibility.Hidden;
						AddressGrid.Visibility = Visibility.Hidden;

						return Display;
					}

				default:
					return Display;
			}
		}

		private void SalesPersonInfoCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
			l.SalesPersonID = cc.SalesPersonID = (int)((DTO_Employee)SalesPersonInfoCombo.SelectedItem).EmployeeID;
			MrnClaim.salesperson = (DTO_Employee)SalesPersonInfoCombo.SelectedItem;
		
			cc.SalesManagerID = s1.EmployeesList.Find(x => x.EmployeeTypeID == ((DTO_LU_EmployeeType)s1.EmployeeTypes.Find(y => y.EmployeeType == "Sales Manager")).EmployeeTypeID).EmployeeID;
		}

		private void PreviousReferrercheckBox_Checked(object sender, RoutedEventArgs e)
		{
			ContactLookupDisplay(true);
		}

		private void PreviousReferrercheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			ContactLookupDisplay(false);
		}

		private void middleNameTextBox1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}
