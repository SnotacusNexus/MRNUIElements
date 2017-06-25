using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MRNNexus_Model;
using NexusClaimGenerator.Controllers;
using NexusClaimGenerator.Interface.Command;
using NexusClaimGenerator.ViewModels.Commands;
using NexusClaimGenerator.ViewModels.Converters;
using static NexusClaimGenerator.ViewModels.Converters.BackgroundConverter;
using System.Threading;

namespace NexusClaimGenerator.ClaimUtilities
{
	public static class ClaimDataService
	{
		static AccessableClaim ac;
		public static DTO_Claim currentClaim;
		public static DTO_Employee currentUser;
		public static int creds;
		public static ServiceLayer s1 = ServiceLayer.getInstance();
		public static ObservableCollection<AccessableClaim> AccessableClaimsCollection;
		public static DTO_Employee EmployeeRequestingAccess { get; set; }
		public static List<DTO_Claim> ClaimsToProcess { get; set; }
		public static ObservableCollection<AccessableClaim> AccessableClaims { get; set; }
		public static DTO_Claim CLAIM = new DTO_Claim();
		public static ObservableCollection<DTO_Claim> CLAIMS = new ObservableCollection<DTO_Claim>();
		public static ObservableCollection<DTO_ClaimContacts> CONTACTS = new ObservableCollection<DTO_ClaimContacts>();
		public static ObservableCollection<object> ALLDATA;
		public static ObservableCollection<DTO_ClaimDocument> CLAIMDOCS = new ObservableCollection<DTO_ClaimDocument>();
		public static ObservableCollection<DTO_ClaimStatus> CLAIMSTATUSES = new ObservableCollection<DTO_ClaimStatus>();
		public static ObservableCollection<DTO_ClaimVendor> CLAIMVENDORS = new ObservableCollection<DTO_ClaimVendor>();
		public static ObservableCollection<DTO_CallLog> CLAIMCALLLOG = new ObservableCollection<DTO_CallLog>();
		public static ObservableCollection<DTO_Invoice> CLAIMINVOICES = new ObservableCollection<DTO_Invoice>();
		public static ObservableCollection<DTO_Payment> CLAIMPAYMENTS = new ObservableCollection<DTO_Payment>();
		public static ObservableCollection<DTO_Scope> CLAIMSCOPES = new ObservableCollection<DTO_Scope>();
		public static ObservableCollection<DTO_Plane> CLAIMPLANES = new ObservableCollection<DTO_Plane>();
		public static ObservableCollection<DTO_OrderItem> CLAIMORDERITEMS = new ObservableCollection<DTO_OrderItem>();
		public static ObservableCollection<DTO_AdditionalSupply> ADDITIONALSUPPLIES = new ObservableCollection<DTO_AdditionalSupply>();
		public static ObservableCollection<DTO_Address> ADDRESSES = new ObservableCollection<DTO_Address>();
		public static ObservableCollection<DTO_Adjuster> ADJUSTERS = new ObservableCollection<DTO_Adjuster>();
		public static ObservableCollection<DTO_Adjustment> ADJUSTMENTS = new ObservableCollection<DTO_Adjustment>();
		public static ObservableCollection<DTO_Customer> CUSTOMERS = new ObservableCollection<DTO_Customer>();
		public static ObservableCollection<DTO_CalendarData> CALENDARDATA = new ObservableCollection<DTO_CalendarData>();
		public static ObservableCollection<DTO_Employee> EMPLOYEES = new ObservableCollection<DTO_Employee>();
		public static ObservableCollection<DTO_Damage> DAMAGES = new ObservableCollection<DTO_Damage>();
		public static ObservableCollection<DTO_Inspection> INSPECTIONS = new ObservableCollection<DTO_Inspection>();
		public static ObservableCollection<DTO_InsuranceCompany> INSURANCECOMPANIES = new ObservableCollection<DTO_InsuranceCompany>();
		public static ObservableCollection<DTO_KnockerResponse> KNOCKERRESPONSES = new ObservableCollection<DTO_KnockerResponse>();
		public static ObservableCollection<DTO_Lead> LEADS = new ObservableCollection<DTO_Lead>();
		public static ObservableCollection<DTO_NewRoof> NEWROOFS = new ObservableCollection<DTO_NewRoof>();
		public static ObservableCollection<DTO_Claim> OPENCLAIMS = new ObservableCollection<DTO_Claim>();
		public static ObservableCollection<DTO_SurplusSupplies> SURPLUSSUPPLIES = new ObservableCollection<DTO_SurplusSupplies>();
		public static ObservableCollection<DTO_Referrer> REFERRERS = new ObservableCollection<DTO_Referrer>();
		public static ObservableCollection<DTO_User> USERS = new ObservableCollection<DTO_User>();
		public static ObservableCollection<DTO_Vendor> VENDORS = new ObservableCollection<DTO_Vendor>();
		public static ObservableCollection<DTO_Order> ORDERS = new ObservableCollection<DTO_Order>();




		public static async Task<bool> GetCollectionData()
		{


			ObservableCollection<object> a = new ObservableCollection<object>();


			await s1.GetAllClaims();
			s1.ClaimsList.ForEach(x => CLAIMS.Add(x));


			await s1.GetAllClaimContacts();
			s1.ClaimContactsList.ForEach(x => CONTACTS.Add(x));


			await s1.GetAllClaimDocuments();
			s1.ClaimDocumentsList.ForEach(x => CLAIMDOCS.Add(x));

			await s1.GetAllClaimStatuses();
			s1.ClaimStatusList.ForEach(x => CLAIMSTATUSES.Add(x));

			await s1.GetAllClaimVendors();
			s1.ClaimVendorsList.ForEach(x => CLAIMVENDORS.Add(x));

			await s1.GetAllCallLogs();
			s1.CallLogsList.ForEach(x => CLAIMCALLLOG.Add(x));

			await s1.GetAllInvoices();
			s1.InvoicesList.ForEach(x => CLAIMINVOICES.Add(x));

			await s1.GetAllPayments();
			s1.PaymentsList.ForEach(x => CLAIMPAYMENTS.Add(x));

			await s1.GetAllScopes();
			s1.ScopesList.ForEach(x => CLAIMSCOPES.Add(x));

			await s1.GetAllPlanes();
			s1.PlanesList.ForEach(x => CLAIMPLANES.Add(x));

			await s1.GetAllOrderItems();
			s1.OrderItemsList.ForEach(x => CLAIMORDERITEMS.Add(x));

			await s1.GetAllOrders();
			s1.OrdersList.ForEach(x => ORDERS.Add(x));

			await s1.GetAllAdditionalSupplies();
			s1.AdditionalSuppliesList.ForEach(x => ADDITIONALSUPPLIES.Add(x));

			await s1.GetAllAddresses();
			s1.AddressesList.ForEach(x => ADDRESSES.Add(x));



			await s1.GetAllAdjusters();
			s1.AdjustersList.ForEach(x => ADJUSTERS.Add(x));

			await s1.GetAllAdjustments();
			s1.AdjustmentsList.ForEach(x => ADJUSTMENTS.Add(x));
			await s1.GetAllCustomers();
			s1.CustomersList.ForEach(x => CUSTOMERS.Add(x));
			await s1.GetAllCalendarData();
			s1.CalendarDataList.ForEach(x => CALENDARDATA.Add(x));
			await s1.GetAllEmployees();
			s1.EmployeesList.ForEach(x => EMPLOYEES.Add(x));
			await s1.GetAllDamages();
			s1.DamagesList.ForEach(x => DAMAGES.Add(x));
			await s1.GetAllInspections();
			s1.InspectionsList.ForEach(x => INSPECTIONS.Add(x));
			await s1.GetAllInsuranceCompanies();
			s1.InsuranceCompaniesList.ForEach(x => INSURANCECOMPANIES.Add(x));
			await s1.GetAllKnockerResponses();
			s1.KnockerResponsesList.ForEach(x => KNOCKERRESPONSES.Add(x));
			await s1.GetAllLeads();
			s1.LeadsList.ForEach(x => LEADS.Add(x));
			await s1.GetAllNewRoofs();
			s1.NewRoofsList.ForEach(x => NEWROOFS.Add(x));
			await s1.GetAllOpenClaims();
			s1.OpenClaimsList.ForEach(x => OPENCLAIMS.Add(x));
			await s1.GetAllSurplusSupplies();
			s1.SurplusSuppliesList.ForEach(x => SURPLUSSUPPLIES.Add(x));
			await s1.GetAllReferrers();
			s1.ReferrersList.ForEach(x => REFERRERS.Add(x));
			await s1.GetAllUsers();
			s1.UsersList.ForEach(x => USERS.Add(x));
			await s1.GetAllVendors();
			s1.VendorsList.ForEach(x => VENDORS.Add(x));
			return true;

		}
		public class AccessableClaim : DTO_Claim
		{
			public static AccessableClaim getAccessableClaimInstance()
			{
				if (ac == null)
					ac = new AccessableClaim();
				return ac;
			}
	public static ObservableCollection<AccessableClaim> getInstanceAccessableClaims()
			{

				if (AccessableClaimsCollection == null)
					AccessableClaimsCollection = new ObservableCollection<AccessableClaim>();
				return AccessableClaimsCollection;

			}

			public AccessableClaim()
			{
				Go();
				while (s1.VendorsList == null)
					Thread.Sleep(1);
			}
			public async void Go()
			{
				while (!await Init())
					await Task.Delay(1);
			}
			async Task<bool> Init()
			{
				if (ALLDATA == null)
					ALLDATA = new ObservableCollection<object>();


				while (!await GetCollectionData())
					await Task.Delay(1);

				return true;
			}

		


			public static async Task<bool> GetCollectionData()
			{

				await s1.GetAllClaims();
				s1.ClaimsList.ForEach(x => CLAIMS.Add(x));
				await s1.GetAllClaimContacts();
				s1.ClaimContactsList.ForEach(x => CONTACTS.Add(x));
				await s1.GetAllClaimDocuments();
				s1.ClaimDocumentsList.ForEach(x => CLAIMDOCS.Add(x));
				await s1.GetAllClaimStatuses();
				s1.ClaimStatusList.ForEach(x => CLAIMSTATUSES.Add(x));
				await s1.GetAllClaimVendors();
				s1.ClaimVendorsList.ForEach(x => CLAIMVENDORS.Add(x));
				await s1.GetAllCallLogs();
				s1.CallLogsList.ForEach(x => CLAIMCALLLOG.Add(x));
				await s1.GetAllInvoices();
				s1.InvoicesList.ForEach(x => CLAIMINVOICES.Add(x));
				await s1.GetAllPayments();
				s1.PaymentsList.ForEach(x => CLAIMPAYMENTS.Add(x));
				await s1.GetAllScopes();
				s1.ScopesList.ForEach(x => CLAIMSCOPES.Add(x));
				await s1.GetAllPlanes();
				s1.PlanesList.ForEach(x => CLAIMPLANES.Add(x));
				await s1.GetAllOrderItems();
				s1.OrderItemsList.ForEach(x => CLAIMORDERITEMS.Add(x));
				await s1.GetAllOrders();
				s1.OrdersList.ForEach(x => ORDERS.Add(x));
				await s1.GetAllAdditionalSupplies();
				s1.AdditionalSuppliesList.ForEach(x => ADDITIONALSUPPLIES.Add(x));
				await s1.GetAllAddresses();
				s1.AddressesList.ForEach(x => ADDRESSES.Add(x));
				await s1.GetAllAdjusters();
				s1.AdjustersList.ForEach(x => ADJUSTERS.Add(x));
				await s1.GetAllAdjustments();
				s1.AdjustmentsList.ForEach(x => ADJUSTMENTS.Add(x));
				await s1.GetAllCustomers();
				s1.CustomersList.ForEach(x => CUSTOMERS.Add(x));
				await s1.GetAllCalendarData();
				s1.CalendarDataList.ForEach(x => CALENDARDATA.Add(x));
				await s1.GetAllEmployees();
				s1.EmployeesList.ForEach(x => EMPLOYEES.Add(x));
				await s1.GetAllDamages();
				s1.DamagesList.ForEach(x => DAMAGES.Add(x));
				await s1.GetAllInspections();
				s1.InspectionsList.ForEach(x => INSPECTIONS.Add(x));
				await s1.GetAllInsuranceCompanies();
				s1.InsuranceCompaniesList.ForEach(x => INSURANCECOMPANIES.Add(x));
				await s1.GetAllKnockerResponses();
				s1.KnockerResponsesList.ForEach(x => KNOCKERRESPONSES.Add(x));
				await s1.GetAllLeads();
				s1.LeadsList.ForEach(x => LEADS.Add(x));
				await s1.GetAllNewRoofs();
				s1.NewRoofsList.ForEach(x => NEWROOFS.Add(x));
				await s1.GetAllOpenClaims();
				s1.OpenClaimsList.ForEach(x => OPENCLAIMS.Add(x));
				await s1.GetAllSurplusSupplies();
				s1.SurplusSuppliesList.ForEach(x => SURPLUSSUPPLIES.Add(x));
				await s1.GetAllReferrers();
				s1.ReferrersList.ForEach(x => REFERRERS.Add(x));
				await s1.GetAllUsers();
				s1.UsersList.ForEach(x => USERS.Add(x));
				await s1.GetAllVendors();
				s1.VendorsList.ForEach(x => VENDORS.Add(x));
				return true;

			}

			public async Task<ObservableCollection<AccessableClaim>> joinTables(List<DTO_Claim> ClaimsToProcess, DTO_Employee EmployeeRequestingAccess)
			{
				var c = new List<DTO_ClaimContacts>();
				var e = new List<int>();
				var ClaimsList = s1.ClaimsList;
				await s1.GetAllClaimContacts();
				await s1.GetAllEmployees();
				await s1.GetAllClaimContacts();
				await s1.GetAllClaimDocuments();
				await s1.GetAllCustomers();
				while (s1.ClaimsList == null || s1.ClaimContactsList == null || s1.EmployeesList == null || s1.ClaimDocumentsList == null)
					await Task.Delay(1);
				while (s1.ClaimsList.Count < 1 || s1.ClaimContactsList.Count < 1 || s1.EmployeesList.Count < 1)
					await Task.Delay(1);



				if (AccessableClaim.getInstanceAccessableClaims().Count() > 0)
					AccessableClaim.getInstanceAccessableClaims().Clear();
				await s1.GetAllOpenClaims();
				while (s1.OpenClaimsList == null)
					await Task.Delay(1);
				if (s1.OpenClaimsList.Count < 1)
					System.Windows.Forms.MessageBox.Show("No Open Claims To Process!");
				else
				{

					await joinTables(s1.OpenClaimsList, s1.LoggedInEmployee);


				}
				/*
							SELECT C.FirstName,C.MiddleName, C.LastName, C.Suffix, A.Address, A.Zip, CL.MRNNumber, CL.LossDate, CL.MortgageCompany, CL.MortgageAccount, CL.InsuranceClaimNumber, IC.CompanyName, IC.ClaimPhoneNumber/*,  L.FirstName,L.LastName,E.FirstName,E.LastName,S.FirstName,S.LastName*/
				/* FROM[Claims] CL
			   JOIN ClaimContacts CC ON CL.ClaimID = CC.ClaimID
				 JOIN Addresses A ON CL.PropertyID = A.AddressID
				  JOIN Customers C ON CC.CustomerID = C.CustomerID
				  JOIN InsuranceCompanies IC ON CL.InsuranceCompanyID = IC.InsuranceCompanyID
				 /* JOIN Employees E ON CC.SalesPersonID = E.EmployeeID
				  JOIN Employees L ON CC.KnockerID = E.EmployeeID 
				  JOIN Employees S ON CC.SupervisorID = E.EmployeeID*/

				/*
				ORDER BY CL.ClaimID
								*/
				var query =
					from Contacts in s1.ClaimContactsList
					join Customers in s1.CustomersList on Contacts.CustomerID equals Customers.CustomerID
					where Contacts.CustomerID == CustomerID
					select new { DTO_Claimcontacts = Contacts, DTO_Customer = Customers };

				var subquery =
					from Contacts in query
					join Claims in s1.ClaimsList on Contacts.DTO_Claimcontacts.ClaimID equals Claims.ClaimID
					where Contacts.DTO_Claimcontacts.ClaimID == ClaimID
					select new { DTO_ClaimContacts = Contacts.DTO_Claimcontacts, DTO_Customer = Contacts.DTO_Customer, DTO_Claim = Claims };
				var subquery2 =
				from Claims in subquery
				join Addresses in s1.AddressesList on Claims.DTO_Claim.PropertyID equals Addresses.AddressID
				where Claims.DTO_Claim.PropertyID == Addresses.AddressID
				select new { DTO_ClaimContacts = Claims.DTO_ClaimContacts, DTO_Customer = Claims.DTO_Customer, DTO_Claim = Claims, DTO_Address = Addresses };
				AddressZipcodeValidation azv = new AddressZipcodeValidation();
				foreach (var b in subquery2)
				{
					azv.CityStateLookupRequest(b.DTO_Address.Zip);
					System.Windows.Forms.MessageBox.Show(b.DTO_Customer.FirstName + " " + b.DTO_Customer.MiddleName + " " + b.DTO_Customer.LastName + "/n/r" + b.DTO_Address.Address + "/n/r" + azv.City + ", " + azv.ST + "  " + b.DTO_Address.Zip.ToString() + "/r/n" + b.DTO_Customer.PrimaryNumber + "/r/n" + b.DTO_Customer.Email);
					AccessableClaims.Add(b.DTO_Claim.DTO_Claim as AccessableClaim);
				}

				return AccessableClaims;
			}
			/*
						var z =
						from Claim in ClaimsToProcess
						join ClaimContacts in s1.ClaimContactsList on Claim.ClaimID equals ClaimContacts.ClaimID
						where Claim.ClaimID == ClaimID
						select new { DTO_Claim = Claim, DTO_ClaimContacts = ClaimContacts };

						var y =
							from Claim in z
							join Documents in s1.ClaimDocumentsList on Claim.DTO_Claim.ClaimID equals Documents.ClaimID
							where Claim.DTO_Claim.ClaimID == ClaimID
							select new { DTO_Claim = Claim, DTO_ClaimDocument = Documents };

						var w =
							from Claim in y
							join Statuses in s1.ClaimStatusList on Claim.DTO_Claim.DTO_Claim.ClaimID equals Statuses.ClaimID
							where Claim.DTO_Claim.DTO_Claim.ClaimID == ClaimID
							select new { DTO_Claim = Claim, DTO_ClaimStatus = Statuses };

						var v =

							from Claim in y
							join Statuses in s1.ClaimStatusList on Claim.DTO_Claim.DTO_Claim.ClaimID equals Statuses.ClaimID
							where Claim.DTO_Claim.DTO_Claim.ClaimID == ClaimID
							select new { DTO_Claim = Claim, DTO_ClaimStatus = Statuses };
							*/

			//	return AccessableClaims;





			public async Task<bool> IsAccessable(DTO_Claim ClaimRequestingAccessTo, DTO_Employee EmployeeRequestingAccess)
			{
				await s1.GetClaimContactsByClaimID(ClaimRequestingAccessTo);
				if (s1.ClaimContacts != null)
					if (((EmployeeRequestingAccess.EmployeeID == s1.ClaimContacts.KnockerID || EmployeeRequestingAccess.EmployeeID == s1.ClaimContacts.SalesPersonID || EmployeeRequestingAccess.EmployeeID == s1.ClaimContacts.SupervisorID) && (s1.ClaimContacts.ClaimID == ClaimRequestingAccessTo.ClaimID)) || (EmployeeRequestingAccess.EmployeeTypeID < 10 || EmployeeRequestingAccess.EmployeeTypeID == 12))
						return true;
				return false;

			}
			public async Task<ObservableCollection<AccessableClaim>> IsAccessable(List<DTO_Claim> ClaimsRequestingAccessTo, DTO_Employee EmployeeRequestingAccess)
			{
				ObservableCollection<AccessableClaim> accessableClaims = new ObservableCollection<AccessableClaim>();
				foreach (var a in ClaimsRequestingAccessTo)
					if (await IsAccessable(a, EmployeeRequestingAccess))
						accessableClaims.Add(a as AccessableClaim);
				return accessableClaims;


			}


			public class MRNClaim
			{
				ServiceLayer s1 = ServiceLayer.getInstance();
				public int ClaimNumber { get; set; } = 0;
				public string CustomerName { get; set; }
				public string PropertyAddress { get; set; }
				public int PropertyZipcode { get; set; }
				public string MortgageCompanyName { get; set; }
				public string MortgageAcctNumber { get; set; }
				public string InsuranceCompanyName { get; set; }
				public string InsuranceClaimNumber { get; set; }
				public string InsuranceCoClaimsPhoneNumber { get; set; }
				public string LeadGeneratedBy { get; set; }
				public string JobSupervisedBy { get; set; }
				public string JobSoldBy { get; set; }
				public MRNClaim()
				{
					if (ClaimNumber > 0)
						Init(new DTO_Claim { ClaimID = ClaimNumber });

				}
				async void Init(DTO_Claim claim)
				{
					await s1.GetAllAdditionalSupplies();
					await s1.GetAllAddresses();
					await s1.GetAllAdjusters();
					await s1.GetAllAdjustments();
					await s1.GetAllCalendarData();
					await s1.GetAllCallLogs();
					await s1.GetAllClaimContacts();
					await s1.GetAllClaimDocuments();
					await s1.GetAllClaims();
					await s1.GetAllClaimStatuses();
					await s1.GetAllClaimVendors();
					await s1.GetAllCustomers();
					await s1.GetAllDamages();
					await s1.GetAllEmployees();
					await s1.GetAllInspections();
					await s1.GetAllInsuranceCompanies();
					await s1.GetAllInvoices();
					await s1.GetAllKnockerResponses();
					await s1.GetAllLeads();
					await s1.GetAllNewRoofs();
					await s1.GetAllOpenClaims();
					await s1.GetAllOrderItems();
					await s1.GetAllOrders();
					await s1.GetAllPayments();
					await s1.GetAllPlanes();
					await s1.GetAllReferrers();
					await s1.GetAllScopes();
					await s1.GetAllSurplusSupplies();
					await s1.GetAllUsers();
					await s1.GetAllVendors();
					await s1.GetAppointmentTypes();
					await s1.GetClaimStatusTypes();


					int superid = 0;
					int salesid = 0;
					int knockerid = 0;
					int referralid = 0;
					int salesmanagerid = 0;
					int adjustid = 0;
					int inscoid = 0;
					bool claimisfiled = false;
					bool bought = false;
					bool hasAdjustment = false;
					bool hasfirstcheckcollect = false;
					bool hasroofscheduled = false;
					bool hasroofinstalled = false;
					bool hasinterior = false;
					bool hasgutter = false;
					bool haseagleviewordered = false;
					bool haseagleviewready = false;
					bool hassupplementsent = false;
					bool hassettlement = false;
					bool hasdepreciationsent = false;
					bool hasexception = false;
					bool hasdepreciationcollect = false;
					bool hasdeductibledue = false;
					bool hasallfundscollected = false;
					bool isreadyforcapout = false;
					bool iswarrantysent = false;
					bool weatherisgoodforinstall = false;
					DateTime SchedInstallRoof;
					DateTime FirstCheckCollected;
					DateTime DepreciationReleased;
					DateTime DepreciationCollected;
					DateTime DealSigned;
					DateTime Adjustment;

					await s1.GetClaimByClaimID(claim);
					if (s1.Claim != null)
					{
						await s1.GetClaimContactsByClaimID(s1.Claim);
						await s1.GetAdditionalSuppliesByClaimID(claim);
						await s1.GetCallLogsByClaimID(claim);
						await s1.GetClaimVendorsByClaimID(claim);
						await s1.GetClaimStatusByClaimID(claim);
						await s1.GetClaimDocumentsByClaimID(claim);
						await s1.GetInspectionsByClaimID(claim);
						await s1.GetScopesByClaimID(claim);
						await s1.GetMostRecentDateByClaimID(claim);
						await s1.GetNewRoofByClaimID(claim);
						await s1.GetOrdersByClaimID(claim);

						claimisfiled = true;
						if (s1.ClaimContacts != null)
						{
							var cc = s1.ClaimContacts;
							if (superid > 0)
								superid = (int)cc.SupervisorID;
							salesid = cc.SalesPersonID;
							if (knockerid > 0)
								knockerid = (int)cc.KnockerID;
							if (referralid > 0)
								referralid = (int)cc.KnockerID;
							salesmanagerid = cc.SalesManagerID;
							if (adjustid > 0)
								adjustid = (int)cc.AdjusterID;
							inscoid = claim.InsuranceCompanyID;



						}
					}



				}
				public class Capout
				{
					public double CompanyCollects { get; set; }
					public double SalespersonCollects { get; set; }
					public double OverheadCollected { get; set; }

				}
				Capout capout(double totinv, double totclaimamt, double totpayment, double ohpercent = 10, double splitpercent = 50, double staticcost = 150)
				{
					return new Capout
					{
						SalespersonCollects = (totpayment - (totclaimamt * ohpercent) - totinv - staticcost) * (splitpercent * .01),
						CompanyCollects = (totpayment - (totclaimamt * ohpercent) - totinv - staticcost) * ((100 - splitpercent) * .01),
						OverheadCollected = (totclaimamt * (ohpercent * .01))
					};

				}
				string MakeName(string fn = null, string mn = null, string ln = null, string suf = null)
				{
					var a = new StringBuilder();
					if (a.Length > 0)
						a.Clear();
					if (!string.IsNullOrEmpty(fn))
						a.Append(fn);
					if (!string.IsNullOrEmpty(mn))
						a.Append(mn);
					if (!string.IsNullOrEmpty(ln))
						a.Append(ln);
					if (!string.IsNullOrEmpty(suf))
						a.Append(suf);
					return a.ToString();
				}
				/*	C.FirstName,C.MiddleName, C.LastName, C.Suffix, A.Address, A.Zip, CL.MRNNumber, CL.LossDate, CL.MortgageCompany, CL.MortgageAccount, CL.InsuranceClaimNumber, IC.CompanyName, IC.ClaimPhoneNumber,  L.FirstName,L.LastName,E.FirstName,E.LastName,S.FirstName,S.LastName*/
			}
			public class ClaimIndices : ObservableCollection<int>
			{
				#region ClaimIDs Class
				public ClaimIndices()
				{

				}

				public static ClaimIndices claimIndices;
				static ServiceLayer s1 = ServiceLayer.getInstance();
				public static int ClaimID { get; set; }
				public static Nullable<int> KnockerID { get; set; }
				public static int SalesPersonID { get; set; }
				public static int SalesManagerID { get; set; }
				public static int CustomerID { get; set; }
				public static Nullable<int> SupervisorID { get; set; }
				public static Nullable<int> AdjusterID { get; set; }
				//	public static Roofer RooferID { get; set; }
				//	public static Nullable<int> RooferID { get; set; }
				//	public static Nullable<int> ExteriorContractorID { get; set; }
				//	public static Nullable<int> InteriorContractorID { get; set;}
				//	public static Nullable<int> GutterContractorID { get; set; }
				//	public static int ServiceTypeID { get; set; }
				public static int ScopeID { get; set; }
				public static int ScopeTypeID { get; set; }
				public static int VendorTypeID { get; set; }
				public static string CompanyName { get; set; }
				public static double Interior { get; set; }
				public static double Exterior { get; set; }
				public static double Gutter { get; set; }
				public static double Tax { get; set; }
				public static double Deductible { get; set; }
				public static double Total { get; set; }
				public static double OandP { get; set; }
				public static double RoofAmount { get; set; }
				public static DateTime DateDropped { get; set; }
				[DataMember(Name = "DateDropped")]
				public static DateTime ScheduledInstallation { get; set; }
				static bool Ready = false;

				public static ClaimIndices GetClaimIndices(DTO_Claim Claim)
				{
					ClaimIndices ci = new ClaimIndices();

					if (Claim != null)
					{

						ci.Init(Claim);
						ClaimID = Claim.ClaimID;
						SalesPersonID = s1.ClaimContacts.SalesPersonID;
						SalesManagerID = s1.ClaimContacts.SalesManagerID;
						if (s1.ClaimContacts.KnockerID != null)
							KnockerID = s1.ClaimContacts.KnockerID;
						CustomerID = s1.ClaimContacts.CustomerID;






					}
					return ci;
				}

				#endregion

				// async Task<bool> Get(DTO_Claim token)
				//{

				//}
				async void Init(DTO_Claim Claim)
				{
					while (!await GetAllDataAvailableByClaimID(Claim))
						Thread.Sleep(1);
				}
			}
			async static Task<bool> GetAllDataAvailableByClaimID(DTO_Claim Claim)
			{
				await s1.GetClaimStatusByClaimID(Claim);
				await s1.GetClaimContactsByClaimID(Claim);
				await s1.GetClaimDocumentsByClaimID(Claim);
				await s1.GetClaimVendorsByClaimID(Claim);
				await s1.GetCallLogsByClaimID(Claim);
				await s1.GetAllSurplusSupplies();
				await s1.GetAllAdditionalSupplies();
				await s1.GetAllAddresses();
				await s1.GetAdjustmentsByClaimID(Claim);
				await s1.GetInspectionsByClaimID(Claim);
				await s1.GetInvoicesByClaimID(Claim);
				await s1.GetPaymentsByClaimID(Claim);
				await s1.GetNewRoofByClaimID(Claim);
				//	await GetRoofOrderByClaimID(Claim);
				await s1.GetScopesByClaimID(Claim);

				return true;
			}




		}
		public class AddClaim
		{

			#region Add a claim
			static ServiceLayer s = ServiceLayer.getInstance();
			public static string orderInfo = "No Order Found";
			public static string salesPersonName = "";
			public static string customerFullName = "";

			public static string streetaddress = "";
			public static string CSZ = "";
			public static string PhoneNumber = "";
			public static string emailAddress = "";
			public static string knockerName = "No Knocker";
			public static string referrerName = "No Referrer";
			public static string claimNumber = "";
			public static string MRNNumber = "";
			public static string claimSupervisor = "No Job Site Supervisor found for this claim";
			public static string claimSalesManager = "";
			public static string claimRoofInstaller = "No Roof Installer Found for this claim";
			public static string claimRoofMaterialSupplier = "No Materials Supplier found for this claim";
			public static string claimInspector = "No Inspector Found";
			public static string claimAdjuster = "No Adjuster Info Available";
			public static string claimCurrentStatus = "No Status Available";
			public static string claimAdjustmentDate = "No Adjustment Date Available";
			public static string claimSignedDate = "No Signed Date Available";
			public static string claimEstimateDate = "No Estimate Date Available";
			public static string claimAmountCollected = "No Collected Amount Available";
			public static string claimAmountExpense = "No Invoice Info Available";
			public static string claimSupplementDate = "No Supplement Info Available";
			public static string claimRoofInstallDate = "No Roof Install Date Available";
			public static string claimSquaresOrdered = "No Squares Ordered at this time.";
			public static string claimGutterGuy = "No Gutter Guy found on this claim.";
			public static string claimInteriorGuy = "No Interior Guy found on this claim.";
			public static string claimExteriorGuy = "No Exterior Guy found on this claim";
			public static string claimRoofScheduledDropDate = "No Scheduled Material Drop Date At This Time";
			public static List<DTO_OrderItem> OrderItems = new List<DTO_OrderItem>();
			public static List<string> InspectionsPhotoList = new List<string>();
			public static List<DTO_ClaimDocument> ClaimDocs = new List<DTO_ClaimDocument>();
			public static List<string> ClaimStatusDates = new List<string>();
			public static List<DTO_Inspection> Inspections = new List<DTO_Inspection>();
			public static DTO_Inspection WorkingInspection = new DTO_Inspection();
			public static string InsuranceCompanyName = "No Insurance Company Recorded for this claim.";
			public static string MortgageCompany = "No Lein Holders for this property recorded.";
			public static double TotalClaimAmount = 0;
			public static double claimSupplementAmount = 0;
			public static double claimSettlementAmount = 0;
			public static List<DTO_Scope> Scopes = new List<DTO_Scope>();
			public static DTO_Scope WorkingScope = new DTO_Scope();
			public static DTO_Scope claimEstimate = new DTO_Scope();
			public static int existingClaimWithThisAddressID = 0;
			public static int existingAddressID = 0;

			static int timeoutCounter = 0;
			async public static Task<bool> checkAddressExist(DTO_Address address)
			{
				bool exist = false;
				if (string.IsNullOrEmpty(address.Address))
				{
					return exist;
				}
				if (s.AddressesList.Count > 0)
					s.AddressesList.Clear();
				await s.GetAllAddresses();

				while (s.AddressesList == null && timeoutCounter < 9)
				{
					await Task.Delay(10);
					timeoutCounter++;
				}
				try
				{
					exist = (s.AddressesList.Exists(x => x.Address == address.Address));
				}
				catch (Exception ex)
				{
					Debug.Print(ex.ToString());
				}

				return exist;



			}

			async public static Task<bool> checkAddressExist(string address)
			{
				bool exist = false;
				//TODO make sure that all the special chars are removed before being saved in db
				address = address.Trim(' ', '.', '\r', '\n');
				if (string.IsNullOrEmpty(address))
				{
					System.Windows.Forms.MessageBox.Show("Invalid Address");
					return exist;
				}
				if (s.AddressesList.Count > 0)
					s.AddressesList.Clear();

				await s.GetAllAddresses();

				while (s.AddressesList == null && timeoutCounter < 9)
				{
					await Task.Delay(10);
					timeoutCounter++;
				}
				try
				{
					exist = (s.AddressesList.Exists(x => x.Address == address));
				}
				catch (Exception ex)
				{
					Debug.Print(ex.ToString());
				}

				return exist;



			}

			public static string CustomerFullName(DTO_Customer cust)
			{
				StringBuilder fullName = new StringBuilder();
				if (string.IsNullOrEmpty(cust.FirstName))
					System.Windows.Forms.MessageBox.Show("No First Name");
				else
					fullName.Append(cust.FirstName);
				if (!string.IsNullOrEmpty(cust.MiddleName))
					fullName.Append(cust.MiddleName);
				if (string.IsNullOrEmpty(cust.LastName))
					System.Windows.Forms.MessageBox.Show("No Last Name");
				else
					fullName.Append(cust.LastName);
				if (!string.IsNullOrEmpty(cust.Suffix))
					fullName.Append(cust.Suffix);

				return fullName.ToString();
			}


			public static async void getClaimDetails(DTO_Claim claim)
			{
				await s.GetClaimContactsByClaimID(claim);
				//Add em while they are fresh.
				if (s.Cust != null)
					s.Cust = null;
				await s.GetCustomerByID(new DTO_Customer { CustomerID = s.ClaimContacts.CustomerID });
				if (s.Cust != null)
					customerFullName = CustomerFullName(s.Cust);

				salesPersonName = await GetEmpoyeeNameFromID((int)s.ClaimContacts.SalesPersonID);

				claimSalesManager = await GetEmpoyeeNameFromID((int)s.ClaimContacts.SalesManagerID);

				if (s.ClaimContacts.SupervisorID != null)
					claimSupervisor = await GetEmpoyeeNameFromID((int)s.ClaimContacts.SupervisorID);
				if (s.ClaimContacts.KnockerID != null)
					knockerName = await GetEmpoyeeNameFromID((int)s.ClaimContacts.KnockerID);

				if (s.ClaimContacts.AdjusterID != null)
				{
					await s.GetAdjusterByID(new DTO_Adjuster { AdjusterID = (int)s.ClaimContacts.AdjusterID });
					claimAdjuster = s.Adjuster.FirstName + " " + s.Adjuster.LastName;
				}
				else
					claimAdjuster = "No Adjuster Info Available";

				//TODO add function to get order info for the claim make it static so that we are always accessing the same info
				await s.GetOrdersByClaimID(claim);
				if (s.Order != null)
				{
					if (s.OrderItemsList.Count > 0)
						s.OrderItemsList.Clear();

					await s.GetOrderItemsByOrderID(s.Order);
					orderInfo = "Order Found";
					OrderItems = s.OrderItemsList;

				}
				await s.GetClaimDocumentsByClaimID(claim);

				if (s.ClaimDocumentsList.Count > 0)
				{
					ClaimDocs = s.ClaimDocumentsList;


					foreach (var cd in s.ClaimDocumentsList.Where(x => x.DocTypeID == 2))
						InspectionsPhotoList.Add(cd.FilePath + cd.FileName + cd.FileExt);
				}

				if (s.ClaimStatusList.Count > 0)
					s.ClaimStatusList.Clear();
				await s.GetClaimStatusByClaimID(claim);
				if (s.ClaimStatusList.Count > 0)
					foreach (var cs in s.ClaimStatusList)
					{
						int counter = 0;
						for (int i = 1; i < s.ClaimStatusTypes.Count + 1; i++)
							try
							{

								if (s.ClaimStatusList.Exists(x => x.ClaimStatusTypeID == i))
									ClaimStatusDates.Add(s.ClaimStatusList[counter].ToString());
								counter++;
								if (counter >= s.ClaimStatusList.Count)
									break;

							}
							catch
							{
								ClaimStatusDates.Add("No " + s.ClaimStatusTypes[i - 1].ClaimStatusType.ToString() + " found.");
								counter++;
							}

					}

				if (s.ClaimVendorsList.Count > 0)
					s.ClaimVendorsList.Clear();
				await s.GetClaimVendorsByClaimID(claim);

				await s.GetVendorByID((DTO_Vendor)s.ClaimVendorsList.Where(x => x.ServiceTypeID == 1));
				claimGutterGuy = s.Vendor.CompanyName;
				await s.GetVendorByID((DTO_Vendor)s.ClaimVendorsList.Where(x => x.ServiceTypeID == 2));
				claimInteriorGuy = s.Vendor.CompanyName;

				await s.GetVendorByID((DTO_Vendor)s.ClaimVendorsList.Where(x => x.ServiceTypeID == 3));
				claimExteriorGuy = s.Vendor.CompanyName;
				await s.GetVendorByID((DTO_Vendor)s.ClaimVendorsList.Where(x => x.ServiceTypeID == 4));
				claimRoofInstaller = s.Vendor.CompanyName;

				if (s.InspectionsList.Count > 0)
					s.InspectionsList.Clear();

				await s.GetInspectionsByClaimID(claim);
				Inspections = s.InspectionsList;
				await s.GetInspectionByID(s.InspectionsList.Last(x => x.ClaimID == claim.ClaimID));
				WorkingInspection = s.Inspection;

				await s.GetScopesByClaimID(claim);
				Scopes = s.ScopesList;


			}






			//Get Employee Name from any ID that is an employee subgroup of mrn  everything but referrals, adjusters, vendors, customers

			async static Task<string> GetEmpoyeeNameFromID(int id)
			{

				await s.GetEmployeeByID(new DTO_Employee { EmployeeID = id });
				return s.Employee.FirstName + " " + s.Employee.LastName;



			}

			Func<DTO_Customer, string> GetCustomerName = i => CustomerFullName(i);

			//use this to find out if this address exist but more importantly to see if it exist attached to a previous claim
			async public static Task<bool> checkForExistingClaimCustomerAddress(object obj)
			{
				if (obj.GetType() == typeof(string))
					obj = new DTO_Address { Address = obj.ToString() };
				bool exist = false;
				DTO_Claim claim = new DTO_Claim();
				if (obj != null)
				{
					if (obj.GetType() == typeof(DTO_Address))
					{



						if (s.AddressesList.Count > 0)
							s.AddressesList.Clear();

						await s.GetAllAddresses();
						while (s.AddressesList == null && timeoutCounter < 9)
						{
							await Task.Delay(10);
							timeoutCounter++;
						}
						try
						{
							exist = (s.AddressesList.Exists(x => x.Address == ((DTO_Address)obj).Address));
							if (exist)
							{
								if (s.OpenClaimsList.Count < 1)
									await s.GetAllOpenClaims();
								if (s.ClaimsList.Count < 1)
									await s.GetAllClaims();
								while (s.OpenClaimsList == null && timeoutCounter < 9)
								{
									await Task.Delay(10);
									timeoutCounter++;
								}


								try
								{
									claim = (DTO_Claim)s.OpenClaimsList.Select(x => x.PropertyID == ((DTO_Address)obj).AddressID);
									existingClaimWithThisAddressID = claim.ClaimID;
									return true;//Open Claim Exist with Address ID


								}
								catch (Exception ex)
								{
									try
									{

										claim = (DTO_Claim)s.ClaimsList.Select(x => x.PropertyID == ((DTO_Address)obj).AddressID);

										//		exist = (DTO_Customer)s.CustomersList.Exist(w => w == ((DTO_Customer)w).FirstName + (DTO_Customer)w).LastName)

										return true;
										// an old claim exist with address ID

									}
									catch
									{
										return exist;
									}
								}

							}
						}
						catch (Exception ex)
						{
							System.Windows.Forms.MessageBox.Show(ex.ToString());
						}

					}
				}
				else
					System.Windows.Forms.MessageBox.Show("Need Valid Address");

				//exist = (s.AddressesList.Exists(x => x.Address == ((DTO_Address)obj).Address));
				//	}

				return exist;
			}
			async public static void _AddClaim(DTO_Address address, DTO_Claim claim, DTO_Customer customer,
				/*DTO_Inspection inspection,*/ DTO_ClaimStatus claimStatus,/* DTO_NewRoof newRoof,*//* DTO_Order order,*//*
			DTO_OrderItem orderItem,*//* DTO_Scope scope,*/DTO_Lead lead, DTO_Referrer referral)
			{



				#region Create New Instance Of DTO's needed
				/*	DTO_Lead lead = new DTO_Lead();
					DTO_Address address = new DTO_Address();
					DTO_Claim claim = new DTO_Claim();
					DTO_Customer customer = new DTO_Customer();
					DTO_Inspection inspection = new DTO_Inspection();
					DTO_ClaimStatus claimStatus = new DTO_ClaimStatus();
					DTO_NewRoof newRoof = new DTO_NewRoof();
					DTO_Order order = new DTO_Order();
					DTO_OrderItem orderItem = new DTO_OrderItem();
					DTO_Scope scope = new DTO_Scope();	 */
				/*	DTO_Referrer referral = new DTO_Referrer();	   */
				#endregion
				#region Populate Customer

				//Check for required Info

				if (string.IsNullOrWhiteSpace(customer.FirstName)) { System.Windows.Forms.MessageBox.Show("Needs First Name"); }
				if (string.IsNullOrWhiteSpace(customer.LastName)) { System.Windows.Forms.MessageBox.Show("Needs Last Name"); }
				if (string.IsNullOrWhiteSpace(customer.PrimaryNumber)) { System.Windows.Forms.MessageBox.Show("Needs Primary Phone Number"); }
				if (string.IsNullOrWhiteSpace(customer.Email)) { System.Windows.Forms.MessageBox.Show("Needs Email Address"); }

				//bool exist = await checkAddressExist(address);

				#endregion
				#region Populate Address
				if (await checkForExistingClaimCustomerAddress(address))
					if ((System.Windows.MessageBoxResult)System.Windows.MessageBox.Show("Possible Duplicate Entry", "Another Claim With the same address, customer name exist is this a new claim for the same address?", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question, System.Windows.MessageBoxResult.No) == System.Windows.MessageBoxResult.No)
					{
						System.Windows.Forms.MessageBox.Show("Claim Addition aborted due to duplicate entry detected.");

						//TODO add code to ask to show the existing almost duplicated claim.

						return;
						// retreat run for the hills
					}
				if (await checkAddressExist(address))
				{
					try
					{
						await s.GetCustomerByID(new DTO_Customer { CustomerID = address.CustomerID });
						if (s.Cust.LastName + s.Cust.FirstName == customer.LastName + customer.FirstName)
							address = (DTO_Address)s.AddressesList.Select(x => x == address);
					}
					catch (Exception ex)
					{
						System.Windows.Forms.MessageBox.Show(ex.ToString());

					}
				}

				else
				{
					//at this point we now have enuf information to add the address
					try
					{
						await (s.AddCustomer(customer));
					}
					catch (Exception ex)
					{
						System.Windows.Forms.MessageBox.Show(ex.ToString());
					}
					if (s.Cust.Message == null)
					{

						try
						{
							customer = s.Cust;
							await s.AddAddress(new DTO_Address { Address = address.Address, Zip = address.Zip, CustomerID = customer.CustomerID });
						}
						catch (Exception ex)
						{
							System.Windows.Forms.MessageBox.Show(ex.ToString());

						}
						if (s.Address.Message == null)  //success
						{
							//AddLead

						}
						else
						{
							System.Windows.Forms.MessageBox.Show(s.Address.Message);
						}
					}
					else
					{
						System.Windows.Forms.MessageBox.Show(s.Cust.Message);
					}

				}
				#endregion
				#region Populate Referrer
				int referrerID = 0;
				await s.GetAllLeads();
				if (!s.LeadsList.Exists(x => ((DTO_Lead)x).CreditToID == referral.ReferrerID && ((DTO_Lead)x).AddressID == address.AddressID))

					try
					{
						await s.AddReferrer(referral);
					}
					catch (Exception ex)
					{

						System.Windows.Forms.MessageBox.Show(ex.ToString());
					}

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
				if (lead == null)
				{  //if anything other than self generated this should not be null since it is then we will basically put just enuf info to make this successfull as we wont need to access this for more than the stats of self generated;

					lead.Temperature = "W";
					lead.CreditToID = referrerID;
					lead.SalesPersonID = s.LoggedInEmployee.EmployeeID;
					lead.KnockerResponseID = null;
					lead.LeadDate = DateTime.Today;
					lead.LeadTypeID = 5;
				}
				else
				{
					lead.Temperature = lead.Temperature;
					lead.CreditToID = referral.ReferrerID;
					lead.SalesPersonID = s.LoggedInEmployee.EmployeeID;//need to adjust this to impersonated SalespersonID
					lead.KnockerResponseID = null;
					lead.LeadDate = DateTime.Today;
					lead.LeadTypeID = 1;

				}
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
					/*	claim.MRNNumber = "MRN-" + s.Lead.SalesPersonID + "-" + s.Cust.CustomerID;
						claim.PropertyID = s.Address1.AddressID;
						claim.BillingID = claim.PropertyID;
						claim.LossDate = DateTime.Now.Date;
						claim.InsuranceCompanyID =


						//claim.InsuranceCompanyID = ((DTO_InsuranceCompany)InsuranceLU.SelectedItem).InsuranceCompanyID;
						claim.MortgageAccount = 0;
						claim.MortgageCompany = "";
						*/
					#endregion

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
				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.ToString());

				}
			}

			public static async Task<int> AddScope(DTO_Scope scope, DTO_Claim claim)
			{
				//TODO: REMOVE DUMMY DATA AND SCRIPT IN ACTUAL GATHERING CODE
				#region	Dummy Data and Fixed Variable Must Remove Before Production
				//HACK
				//scope?

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
					System.Windows.Forms.MessageBox.Show(ex.ToString());
				}
				if (s.Scope.Message == null)
					return s.Scope.ScopeID;
				return 0;
			}
			#endregion

			// claimStatus
			async public static void UpdateClaimStatus(DTO_Claim claim, int ClaimStatusIDtoUpdate, DateTime? dt = null)
			{

				await s.GetClaimStatusByClaimID(claim);
				DTO_ClaimStatus cs = s.ClaimStatus;

				cs.ClaimStatusTypeID = ClaimStatusIDtoUpdate;
				if (dt == null)
					dt = DateTime.Today;
				cs.ClaimStatusDate = (DateTime)dt;
				await s.UpdateClaimStatuses(cs);

			}

			//scope?

			// inspection

			//TODO: REMOVE DUMMY DATA AND SCRIPT IN ACTUAL GATHERING CODE
			//order?
			#region	Dummy Data and Fixed Variable Must Remove Before Production
			/*
				bool hasorder = false;

			*/
			#endregion
			//HACK

			#endregion

			#region OrderRoofSupplies

			public static async Task<int> AddOrder(DTO_Order order, DTO_Claim claim)
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
				if (order.Message == null)
					return s.Order.OrderID;
				else
					return 0;


			}

			#endregion
			#region ROOF ORDER Items
		}
		public class RoofOrderItemMapping : RoofOrder
		{
			static ObservableCollection<DTO_OrderItem> orderitems = new ObservableCollection<DTO_OrderItem>();
			static DTO_OrderItem oi = new DTO_OrderItem();


			void ConvertToOrderWithOrderItems(RoofOrder ro)
			{
				/*
				 Shingles

				OC
				Duration Designer
				Colors:
					name           DD   D	OTD	 O	S
				02	Aged Copper
				03	Antique Silver
				04	Aspen Gray
				05	Automn Brown
				06	Beachwood Sand
				07	Brownwood
				08	Chateau Green
				09	Desert Tan
				10	Driftwood
				11	Estate Gray
				12	Flagstone
				13	Harbor Blue
				14	Merlot
				15	Onyx Black
				16	Pacific Wave
				17	Peppermill Gray
				18	Quarry Gray
				19	Sand Dune
				20	Sedona Canyon
				21	Shasta White
				22	Spanish Red
				23	Storm Cloud
				24	Teak
				25	Twilight Black
				26	Weathered Wood
				27	Williamsburg Gray

				Duration
				Oakridge TruDef
				Oakridge
				Supreme







				oi.OrderID;
				oi.OrderItemID;
				oi.ProductID;
				oi.Quantity;
				oi.UnitOfMeasureID;
				 */

			}
			/*
			orderItem.OrderID = s.Order.OrderID;
				orderItem.ProductID = 1;
				orderItem.Quantity = 99;
				*/


			//orderitems?





		}
		#region RoofOrder Class
		public class RoofOrder
		{
			public static int ShingleManufacturerID { get; set; }
			public static int ShingleTypeID { get; set; }
			public static int ShingleColorID { get; set; }
			public static int ClaimID { get; set; }
			public static int ShingleQuantitySQ { get; set; }
			public static int UnderlaymentQuantity { get; set; }
			public static int UnderlaymentTypeID { get; set; }
			public static int HipRidgeTypeID { get; set; }
			public static int HipRidgeQuantity { get; set; }
			public static int DripEdgeQuantity { get; set; }
			public static int DripEdgeColorID { get; set; }
			public static int IceWaterShieldQuantity { get; set; }
			public static int PrimayVentilationTypeID { get; set; }
			public static int SecondaryVentilationTypeID { get; set; }
			public static int PrimaryVentilationQuantity { get; set; }
			public static int SecondaryVentilationQuantity { get; set; }
			public static int StarterQuantity { get; set; }
			public static int PipeBoot3Quantity { get; set; }
			public static int PipeBoot4Quantity { get; set; }
			public static int OSBQuantity { get; set; }
			public static int CoilNailQuantity { get; set; }
			public static int PlasticCapsQuantity { get; set; }
			public static int TubeCaulkQuantity { get; set; }
			public static int CanPaintQuantity { get; set; }
			public static DateTime OrderDate { get; set; }
			public static DateTime DropDate { get; set; }
			public static DateTime InstallDate { get; set; }
			public static string Comments { get; set; }


			public static void GenerateAllRoofOrdersWithAvailableInformation()
			{


			}

			public static DTO_Order AddThisRoofOrderToDB(object roofOrder)
			{


				return new DTO_Order();

			}
			public static void DeleteRoofOrderFromDB(object roofOrder, DTO_Employee creds)
			{


			}
			public static List<RoofOrder> GetRoofsReadyToOrder(DateTime dt)
			{




				return new List<RoofOrder>();
			}
			public static void ConvertAndAddRoofOrderAsDBOrder(RoofOrder roofOrder)
			{


			}

			public static RoofOrder GetRoofOrderFromFromClaim(DTO_Claim claim)
			{





				return new RoofOrder();
			}
		}
		#endregion

	}
}
#endregion