﻿using System.Collections.Generic;
using System.Windows.Controls;
using MRNNexus_Model;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MRNUIElements.Controllers
{
	public partial class ClaimView : Page
	{
		
		static ClaimValues claimValues;
		static DTO_Customer ClaimCustomer;
		static DTO_Address ClaimAddress;
		static List<DTO_Payment> ClaimPayments;
		static List<DTO_Invoice> ClaimExpenses;
		static DTO_ClaimContacts ClaimContacts;
		static DTO_Order ClaimOrder;
		static List<DTO_Scope> Scopes;
		static List<DTO_Inspection> ClaimInspections;
		static bool JobSplit;
		static List<DTO_AdditionalSupply> TakeOuts;
		static List<DTO_SurplusSupplies> BringBacks;
		static List<DTO_Plane> ClaimMeasurements;
		static DTO_Lead ClaimLead;
		static DTO_Referrer Referral;
		static DTO_Inspection ClaimInspection;
		static ObservableCollection<DTO_ClaimDocument> ClaimDocuments;
		List<decimal> inv = new List<decimal>();
		List<decimal> pay = new List<decimal>();
		public class ClaimValues
		{
			
			public ClaimValues()
			{
				Init();
			}
			private async void Init()
			{

				
			}
			public static ClaimValues getInstanceClaimValues()
			{
				if (claimValues == null)
					claimValues = new ClaimValues();
				return claimValues;
			}
			public static DTO_ClaimContacts getInstanceClaimContacts()
			{
				if (ClaimContacts== null)
					ClaimContacts = new DTO_ClaimContacts();
				return ClaimContacts;
			}
			public static List<DTO_Payment> getInstanceClaimPayments()
			{
				if (ClaimPayments == null)
					ClaimPayments = new List<DTO_Payment>();
				return ClaimPayments;
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
			public async static Task<ObservableCollection<DTO_ClaimDocument>> getInstanceClaimDocuments()
			{
				var b = new List<DTO_ClaimDocument>();
				await s1.GetAllClaimDocuments();
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
			public async static Task<List<DTO_Inspection>> getInstanceClaimInspections()
			{
				if (ClaimInspections == null)
				{
					ClaimInspections = new List<DTO_Inspection>();
					await s1.GetInspectionsByClaimID(_Claim);
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
			public static List<DTO_Invoice> getInstanceClaimInvoices()
			{
				if (ClaimExpenses == null)
					ClaimExpenses = new List<DTO_Invoice>();
				return ClaimExpenses;
			}
			public static List<DTO_LU_InvoiceType> getInstanceClaimInvoiceTypes()
			{
				if (InvoiceTypes == null)
					InvoiceTypes = new List<DTO_LU_InvoiceType>();
				return InvoiceTypes;
			}
			public static List<DTO_Scope> getInstanceClaimScopes()
			{
				if (Scopes == null)
				{
					Scopes = new List<DTO_Scope>();
					if (s1.ScopesList != null)
						Scopes = s1.ScopesList.FindAll(x=> x.ClaimID ==_Claim.ClaimID);
					
				}
				return Scopes;
			}
			public static DTO_Customer getInstanceClaimCustomer()
			{
				if (ClaimCustomer == null)
					ClaimCustomer = new DTO_Customer();
				return ClaimCustomer;
			}
			public static DTO_Lead getInstanceClaimLead()
			{
				if (ClaimLead == null)
					ClaimLead = new DTO_Lead();
				return ClaimLead;
			}
			public static DTO_Address getInstanceClaimAddress()
			{
				if (ClaimAddress== null)
					ClaimAddress = new DTO_Address();
				return ClaimAddress;
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
		}
	}
}
	



//}
//}
