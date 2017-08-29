using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRNNexus_Model;


namespace MRNUIElements.Controllers
{
	public class ClaimHandling
	{
		static ServiceLayer s = ServiceLayer.getInstance();

		public ClaimHandling()
		{

		}

	static async public Task<DTO_Claim> AddClaim(DTO_Employee salesperson, DTO_Lead lead, DTO_Referrer referral, DTO_Address address, DTO_Customer customer, int insuranceID = 0, DTO_Inspection inspection = null, string mortgageCo = "")
		{

			try
			{


				#region Create New Instance Of DTO's needed

				DTO_Claim claim = new DTO_Claim();
				DTO_ClaimStatus claimStatus = new DTO_ClaimStatus();
				DTO_NewRoof newRoof = new DTO_NewRoof();
				DTO_Order order = new DTO_Order();
				DTO_OrderItem orderItem = new DTO_OrderItem();
				DTO_Scope scope = new DTO_Scope();




				#endregion
				#region Populate Customer

				//customer.FirstName = FirstName1.Text;
				//customer.MiddleName = MiddleName1.Text;
				//customer.LastName = LastName1.Text;
				//customer.Suffix = Suffix1.Text;
				//customer.PrimaryNumber = Primary_Phone1.Text;
				//customer.SecondaryNumber = Secondary_Phone1.Text;
				//customer.Email = Email_Address1.Text;
				//customer.MailPromos = false;
				
				
				//#endregion
				//#region Populate Address


				//address.Address = Address1.Text;
				//address.Zip = Zipcode1.Text;
				#endregion
				#region Populate Referrer
				int referrerID = 0;


				string FirstName="";
				string Zipcode = "";
				 string Lastname = "";
				string suffix = "";
				string Primary_Phone = "";
				 string Address = "";
				 string Email_Address = "";
				string MiddleName = "";
				switch (lead.LeadTypeID)
				{
					case 1:
						{//knocker
							var a = s.EmployeesList.Find(x => x.Email == referral.Email);
							 

							 FirstName=a.FirstName;
							 Zipcode="00000";
							Lastname = a.LastName;
							MiddleName = a.MiddleName;
							suffix=a.Suffix;
							Primary_Phone = a.CellPhone;
							Address="On File";
							Email_Address=a.Email;
							break;
						}
					case 2:
						{//referrer
							 FirstName = referral.FirstName;
							 Zipcode = referral.Zip;
							Lastname = referral.LastName;
							suffix =referral.Suffix;
							Primary_Phone = referral.CellPhone;
							Address = referral.MailingAddress;
							Email_Address = referral.Email;
							break;
						}
					case 3:
						{//prev Cust
							 FirstName = customer.FirstName;
							 Zipcode = address.Zip;
							Lastname = customer.LastName;
							suffix = customer.Suffix;
							Primary_Phone = customer.PrimaryNumber;
							Address = address.Address;
							Email_Address = customer.Email;
							break;
						}
					case 4:
						{//House
							 FirstName = "House";
							 Zipcode="00000";
							Lastname = "House";
							suffix="";
							Primary_Phone =  "House";
							Address = "House";
							Email_Address = "House";
							break;
						}
					case 5:
						{//Self Gen
							
							 FirstName = salesperson.FirstName;
							Zipcode = "00000";
							Lastname =salesperson.LastName;
							suffix =salesperson.Suffix;
							Primary_Phone =salesperson.CellPhone;
							Address= "";
							Email_Address= salesperson.Email;
							break;
						}
				}
				referral.FirstName = FirstName;
				referral.Zip = Zipcode;
				referral.LastName = Lastname;
				referral.Suffix = suffix;
				referral.CellPhone = Primary_Phone;
				referral.MailingAddress = Address;
				referral.Email = Email_Address;
				//CheckIfTheyExist if so get the referralID

				if (s.ReferrersList.Count > 0)
					foreach (DTO_Referrer r in s.ReferrersList)
					{
						if (r.Equals(referral))

							referrerID = r.ReferrerID;
						break;
					}

				if (referrerID == 0)
				{
					await s.AddReferrer(referral);
				}
				else referrerID = s.Referrer.ReferrerID;

				//
				#endregion
				#region Populate Lead
				lead.Temperature = "W";
				//lead.CreditToID = referrerID;
				//lead.SalesPersonID = s.LoggedInEmployee.EmployeeID;
				//lead.KnockerResponseID = null;
				//lead.LeadDate = ContractDate.SelectedDate.Value;
				//lead.LeadTypeID = 1;
				#endregion
				#region Claim Addition Underway

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
				claim.InsuranceCompanyID = insuranceID;


				//claim.InsuranceCompanyID = ((DTO_InsuranceCompany)InsuranceLU.SelectedItem).InsuranceCompanyID;
				if (mortgageCo != string.Empty)
					claim.MortgageCompany = mortgageCo;


				#endregion
				#region Doing the damn thang

				await s.AddClaim(claim);
				if (s.Claim.Message == null)
				{
					claim.LeadID = s.Lead.LeadID;
					System.Windows.Forms.MessageBox.Show("Congratulations You Have Successfully became a statistic! Your Claim and Experience is now associated with " + s.Claim.MRNNumber.ToString());
				}
				else
					System.Windows.Forms.MessageBox.Show(s.Lead.Message.ToString());
				#endregion

				//bool hasscope = false;


				////scope?
				//if (hasscope)
				//{
				//	scope.ClaimID = claim.ClaimID;
				//	scope.Deductible = 1000;
				//	scope.Exterior = 600;
				//	scope.Gutter = 995;
				//	scope.Interior = 2040;
				//	scope.OandP = 900;
				//	scope.ScopeTypeID = 2;
				//	scope.Tax = 345.87;
				//	scope.Total = 80021.35;
				//	scope.RoofAmount = scope.Total - scope.Tax - scope.OandP - scope.Interior - scope.Gutter - scope.Exterior;

				//	await s.AddScope(scope);

				//}

				//// claimStatus


				////scope?

				//// inspection


				////order?
				//bool hasorder = false;
				//if (hasorder)
				//{
				//	order.ClaimID = claim.ClaimID;
				//	order.DateDropped = DateTime.Today.Date;
				//	order.DateOrdered = DateTime.Today.Subtract(TimeSpan.FromDays(1));
				//	order.ScheduledInstallation = DateTime.Today.AddDays(1);
				//	order.VendorID = 7;

				//	await s.AddOrder(order);

				//}
				//ObservableCollection<DTO_OrderItem> orderitems = new ObservableCollection<DTO_OrderItem>();


				//orderItem.OrderID = s.Order.OrderID;
				//orderItem.ProductID = 1;
				//orderItem.Quantity = 99;

				return claim;

				//orderitems?

			}
			catch (Exception)
			{

				throw;
			}

		}
	}
}
