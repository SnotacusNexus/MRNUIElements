﻿using System.Collections.Generic;
using System.Windows.Controls;
using MRNNexus_Model;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System;
//using static MRNUIElements.Controllers.ClaimView.ClaimValues;
using static MRNUIElements.Controllers.ClaimValues;
using static MRNUIElements.Controllers.Customer;
using Prism.Mvvm;
using PropertyChanged;

namespace MRNUIElements.Controllers
{
	
	public partial class ClaimView : Page
	{
		public static ClaimView.ClaimValues Claim_Values;
		static ClaimValues claimValues;

		public static ClaimValues _ClaimValues;
		static DTO_Customer ClaimCustomer;
		static DTO_Address ClaimAddress;
		static ObservableCollection<DTO_Payment> ClaimIncome;
		static ObservableCollection<DTO_Invoice> ClaimExpenses;
		static DTO_ClaimContacts ClaimContacts;
		static DTO_Order ClaimOrder;
		static List<DTO_Scope> Scopes;
		static List<DTO_Inspection> ClaimInspections;
		static bool JobSplit;
		static List<DTO_Lead> Leads;
		static List<DTO_AdditionalSupply> TakeOuts;
		static List<DTO_SurplusSupplies> BringBacks;
		static List<DTO_Plane> ClaimMeasurements;
		static DTO_Lead ClaimLead;
		static DTO_Referrer Referral;
		static DTO_Inspection ClaimInspection;
		static ObservableCollection<DTO_ClaimDocument> ClaimDocuments;
		List<decimal> inv = new List<decimal>();
		List<decimal> pay = new List<decimal>();
		
		static List<DTO_Vendor> Vendors;
		
		public class ClaimValues 
		{


			





			public static DTO_ClaimContacts getInstanceClaimContacts()
			{
				if (ClaimContacts == null)
					ClaimContacts = new DTO_ClaimContacts();
				return ClaimContacts;
			}
			public static ObservableCollection<ClaimPayment> getInstanceClaimPayments()
			{
				if (ClaimPayments == null)
					ClaimPayments = new ObservableCollection<ClaimPayment>();
				return ClaimPayments;
			}



			public static ObservableCollection<DTO_Invoice> getInstanceClaimInvoices()
			{
				if (ClaimExpenses == null)
					ClaimExpenses = new ObservableCollection<DTO_Invoice>();
				return ClaimExpenses;
			}
			public static List<DTO_LU_InvoiceType> getInstanceClaimInvoiceTypes()
			{
				if (InvoiceTypes == null)
					InvoiceTypes = new List<DTO_LU_InvoiceType>();
				return InvoiceTypes;
			}
			public static List<DTO_Vendor> getInstanceVendors()
			{
				if (Vendors == null)
				{
					Vendors = new List<DTO_Vendor>();
					if (s1.VendorsList != null)
						Vendors = s1.VendorsList;
				}
				return Vendors;
			}
			//public static List<DTO_Scope> getInstanceClaimScopes()
			//{
			//	if (Scopes == null)
			//	{
			//		Scopes = new List<DTO_Scope>();
			//		if (s1.ScopesList != null)
			//			Scopes = s1.ScopesList.FindAll(x => x.ClaimID == _Claim.ClaimID);

			//	}
			//	return Scopes;
			//}
			
			public static DTO_Lead getInstanceClaimLead()
			{
				if (ClaimLead == null)
					ClaimLead = new DTO_Lead();
				return ClaimLead;
			}
			
			public static DTO_Order getInstanceClaimOrder()
			{
				if (ClaimOrder == null)
					ClaimOrder = new DTO_Order();
				return ClaimOrder;
			}
			public static DTO_Inspection getInstanceClaimInspection()
			{
				if (ClaimInspection == null)
					ClaimInspection = new DTO_Inspection();
				return ClaimInspection;
			}
			public static ObservableCollection<ClaimInvoice> getInstanceClaimInvoice()
			{
				ObservableCollection<DTO_Invoice> ii = new ObservableCollection<DTO_Invoice>();
				if (ClaimInvoices == null)
				{
					var a = new ClaimInvoice();
					ClaimInvoices = new ObservableCollection<ClaimInvoice>();
				}
				if (ClaimExpenses != null)
				{
					ii = getInstanceClaimInvoices();
					foreach (var b in ii)
					{
						ClaimInvoices.Add(new ClaimInvoice { InvoiceAmount = b.InvoiceAmount, InvoiceDate = b.InvoiceDate, InvoiceType = getInstanceClaimInvoiceTypes().Find(x => x.InvoiceTypeID == b.InvoiceTypeID).InvoiceType, VendorCompanyName = getInstanceVendors().Find(x => x.VendorID == b.VendorID).CompanyName });
					}
					return ClaimInvoices;


				}
				return ClaimInvoices;
			}






			public ClaimValues()
			{
				//Init();
			}
			private void Init()
			{

				//await s1.GetAllLeads();
			}

			public static ClaimValues getInstanceClaimValues()
			{
				if (claimValues == null)
					Claim_Values = claimValues = new ClaimValues();
				return claimValues;
			}
			
			public static List<DTO_AdditionalSupply> getInstanceClaimAdditionalSupplies()
			{
				if (TakeOuts == null)
					TakeOuts = new List<DTO_AdditionalSupply>();
				return TakeOuts;
			}
			public static List<DTO_SurplusSupplies> getInstanceClaimSurplusSupplies()
			{
				if (BringBacks == null)
					BringBacks = new List<DTO_SurplusSupplies>();
				return BringBacks;
			}
			public static ObservableCollection<DTO_ClaimDocument> getInstanceClaimDocuments()
			{
				var b = new List<DTO_ClaimDocument>();
			
				if (ClaimDocuments == null) {
					ClaimDocuments = new ObservableCollection<DTO_ClaimDocument>();
					if (s1.ClaimDocumentsList != null)
					{
						b = s1.ClaimDocumentsList.FindAll(x => x.ClaimID == _Claim.ClaimID);
						b.ForEach(x => ClaimDocuments.Add(x));
					}

				}

				return ClaimDocuments;
			}
			public static List<DTO_Inspection> getInstanceClaimInspections()
			{
				if (ClaimInspections == null)
				{
					ClaimInspections = new List<DTO_Inspection>();
					
					ClaimInspections = s1.InspectionsList.FindAll(x => x.ClaimID == _Claim.ClaimID);
				}
				return ClaimInspections;
			}
			public static List<DTO_Plane> getInstanceClaimMeasurements()
			{
				if (ClaimMeasurements == null)
					ClaimMeasurements = new List<DTO_Plane>();
				return ClaimMeasurements;
			}
			
			public static List<DTO_Lead> getInstanceLeads()
			{
				if (Leads == null)
				{
					Leads = new List<DTO_Lead>();
					if (s1.LeadsList != null)
						Leads = s1.LeadsList;
				}
				return Leads;
			}
			//public static List<DTO_Scope> getInstanceClaimScopes()
			//{
			//	if (Scopes == null)
			//	{
			//		Scopes = new List<DTO_Scope>();
			//		if (s1.ScopesList != null)
			//			Scopes = s1.ScopesList.FindAll(x=> x.ClaimID ==_Claim.ClaimID);

			//	}
			//	return Scopes;
			//}
			//public async static Task<List<DTO_Inspection>> getInstanceClaimInspections()
			//{
			//	if (ClaimInspections == null)
			//	{
			//		ClaimInspections = new List<DTO_Inspection>();
			//		await s1.GetInspectionsByClaimID(_Claim);
			//		ClaimInspections = s1.InspectionsList.FindAll(x => x.ClaimID == _Claim.ClaimID);
			//	}
			//	return ClaimInspections;
			//}
			public static DTO_Customer getInstanceClaimCustomer()
			{
				if (ClaimCustomer == null)
				{
					ClaimCustomer = new DTO_Customer();
					try
					{
						ClaimCustomer = s1.CustomersList.Find(x => x.CustomerID == _Claim.CustomerID);
					}
					catch (Exception ex)
					{
						System.Windows.Forms.MessageBox.Show(ex.ToString());
					}



				}
				return ClaimCustomer;
			}
			
			public static DTO_Address getInstanceClaimAddress()
			{
				if (ClaimAddress == null)
					ClaimAddress = new DTO_Address();
				return ClaimAddress;
			}
			
		}
	}
}
	



//}
//}
