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
		static MRNClaim MrnClaim = MRNClaim.getInstance();
		public bool isReferral { get; set; } = false;

		
		//On to Customer
		DTO_Lead l = new DTO_Lead();
		DTO_ClaimContacts cc = new DTO_ClaimContacts();
		DTO_Claim c = new DTO_Claim();
		DTO_Referrer r = new DTO_Referrer();
		//On to Customer
		

	

		public AddLeadInformation(MRNClaim MrnClaim)
		{
			InitializeComponent();

			AddLeadInformation.MrnClaim = MrnClaim;
			LeadTypecomboBox.ItemsSource = s1.LeadTypes;
			SalesPersonInfoCombo.ItemsSource = s1.EmployeesList.Where(x => x.EmployeeTypeID == 13);
            this.DataContext = this;
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

                MRNClaim.getInstance().r = r;
			}
           l.AddressID = MRNClaim.getInstance().a.AddressID;
            c.PropertyID = MRNClaim.getInstance().a.AddressID;
            MRNClaim.getInstance().Lead = l;
            MRNClaim.getInstance()._claim = c;
            MRNClaim.getInstance().cc = cc;

			//Get KnockerInfo Return
			

			
				 
			NavigationService.Navigate(new AddClaimCustomer(MrnClaim));
		}

		private void ExistingContactInfoCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
           // this.DataContext = this;
			switch (((DTO_LU_LeadType)LeadTypecomboBox.SelectedItem).LeadTypeID)
			{
				case 1:
					{
						PreviousReferrercheckBox.Visibility = Visibility.Hidden;
						//	ExistingContactInfoCombo.ItemsSource = s1.EmployeesList;
						EmployeeGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
                        l.CreditToID = (int)((DTO_Employee)ExistingContactInfoCombo.SelectedItem).EmployeeID;
                        l.LeadTypeID = 1;
						cc.KnockerID = l.CreditToID;
						ReferralGrid.Visibility = Visibility.Hidden;
						EmployeeGrid.Visibility = Visibility.Visible;
						CustomerGrid.Visibility = Visibility.Hidden;
						AddressGrid.Visibility = Visibility.Visible;
						break;

					}
				case 2:
					{
						isReferral = true;
						PreviousReferrercheckBox.Visibility = Visibility.Visible;
						//	ExistingContactInfoCombo.ItemsSource = s1.ReferrersList;
						ReferralGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
                       l.LeadTypeID = 2;
                        l.CreditToID = (int)((DTO_Referrer)ExistingContactInfoCombo.SelectedItem).ReferrerID;
						ReferralGrid.Visibility = Visibility.Visible;
						EmployeeGrid.Visibility = Visibility.Hidden;
						CustomerGrid.Visibility = Visibility.Hidden;
						AddressGrid.Visibility = Visibility.Hidden;
						break;
					}
				case 3:
					{
						PreviousReferrercheckBox.Visibility = Visibility.Hidden;
						//ExistingContactInfoCombo.ItemsSource = s1.CustomersList;
						CustomerGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
                       l.LeadTypeID = 3;
                        l.CreditToID = (int)((DTO_Customer)ExistingContactInfoCombo.SelectedItem).CustomerID;
						ReferralGrid.Visibility = Visibility.Hidden;
						EmployeeGrid.Visibility = Visibility.Hidden;
						CustomerGrid.Visibility = Visibility.Visible;
						AddressGrid.Visibility = Visibility.Hidden;
						break;
					}
				case 4:
					{
						PreviousReferrercheckBox.Visibility = Visibility.Hidden;
                        l.LeadTypeID = 4;
                        l.CreditToID = 0;
						ReferralGrid.Visibility = Visibility.Hidden;
						EmployeeGrid.Visibility = Visibility.Hidden;
						CustomerGrid.Visibility = Visibility.Hidden;
						AddressGrid.Visibility = Visibility.Hidden;

						break;
					}

				case 5:
					{
						PreviousReferrercheckBox.Visibility = Visibility.Hidden;
						//	ExistingContactInfoCombo.ItemsSource = s1.EmployeesList;
						EmployeeGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
                       l.LeadTypeID = 5;
                        l.CreditToID = (int)((DTO_Employee)ExistingContactInfoCombo.SelectedItem).EmployeeID;
						ReferralGrid.Visibility = Visibility.Hidden;
						EmployeeGrid.Visibility = Visibility.Visible;
						CustomerGrid.Visibility = Visibility.Hidden;
						AddressGrid.Visibility = Visibility.Hidden;
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
						ContactInfoDisplay(true);
						if (PreviousReferrercheckBox.Visibility == Visibility.Visible)
							PreviousReferrercheckBox.Visibility = Visibility.Hidden;
						ExistingContactInfoCombo.ItemsSource = s1.EmployeesList.Where(x => x.EmployeeTypeID == 14);
						
						break;

					}
				case 2:
					{
						
						
						ContactInfoDisplay(true);
						if (PreviousReferrercheckBox.Visibility != Visibility.Visible)
							PreviousReferrercheckBox.Visibility = Visibility.Visible;
						ExistingContactInfoCombo.ItemsSource = s1.ReferrersList;
						break;
					}
				case 3:
					{
						ContactLookupDisplay(true);
						ContactInfoDisplay(true);
						if (PreviousReferrercheckBox.Visibility == Visibility.Visible)
							PreviousReferrercheckBox.Visibility = Visibility.Hidden;
						ExistingContactInfoCombo.ItemsSource = s1.CustomersList;
						
						break;
					}
				case 4:
					{
						ContactLookupDisplay(true);
						ContactInfoDisplay(false);
						if (PreviousReferrercheckBox.Visibility == Visibility.Visible)
							PreviousReferrercheckBox.Visibility = Visibility.Hidden;

						break;
					}

				case 5:
					{
						ContactLookupDisplay(true);
						ContactInfoDisplay(true);
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
		bool ContactInfoDisplay(bool Enable)
		{

			if (Enable)
			{
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

			}
			else
			{
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

			}

			return Enable;
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
