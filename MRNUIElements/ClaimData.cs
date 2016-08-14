using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNUIElements.Controllers.Collection
{
	
	public class ClaimData:ObservableCollection<ClaimData>
	{

		public int OriginalScopeID { get; set; }
		public int MRNEstimateID { get; set; }
		public int NewScopeID { get; set; }
		public int AdjustmentResult { get; set; }
		public string InspectionReport { get; set; }
		public ObservableCollection<string> InspectionImages { get; set; }
		public ObservableCollection<double> RoofMeasurements { get; set; }
		public ObservableCollection<int> RoofOrder { get; set; }
		



	}
	public class CustomerInfo
	{

		public string CustomerName { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public int Zipcode { get; set; }
		public string SecondaryPhone { get; set; }
		public string SecondaryEmail { get; set; }


	}

	public class ClaimInfo
	{
		public string DamageType { get; set; }
		public bool WasReferral { get; set; }
		public bool WasKnocked { get; set; }
		public bool WasReferred { get; set; }

	}



	public class Invoices
	{
		public DateTime InvoiceDate { get; set; }
		public double InvoiceAmount { get; set; }
		public string CompanyInvoicing { get; set; }

	}

	public class Checks
	{
		public double FirstCheckAmount { get; set; }
		public double DepreciationAmount { get; set; }
		public double DeductibleAmount { get; set; }
		public double UpgradeAmount { get; set; }
		public double SupplementAmount { get; set; }

	}

	public class RoofOrder
	{
		public string RoofMaterialSupplier { get; set; }
		public string RoofLaborSupplier { get; set; }
		public CustomerInfo Customer { get; set; }
		public DateTime DropDate { get; set; }		   
		public DateTime InstallDateRoof { get; set; }
		public DateTime InstallDateGutter { get; set; }
		public DateTime InstallDateInterior { get; set; }
		public DateTime InstallDateExterior { get; set; }
		public string SpecialInstructions { get; set; }

	}

	public class RoofMeasurements
	{
		public double RidgeFeet { get; set; }
		public double RakeFeet { get; set; }
		public double HipFeet { get; set; }
		public double ValleyFeet { get; set; }
		public int WasteFactor { get; set; }
		public double EaveFeet { get; set; }
		public int PipeBoot3 { get; set; }
		public int PipeBoot4 { get; set; }
		public int BoxNails { get; set; }
		public int BoxCaps { get; set; }
		public int CansPaint { get; set; }
		public int TubesCaulk { get; set; }
		public double Squares { get; set; }
		public double StepFlashing { get; set; }
		public double Flashing { get; set; }
		public int TurtleVents { get; set; }
		public int RidgeVentFeet { get; set; }
		public int PredominantPitch { get; set; }

	}

	public class LeadInfo
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; }
		public string State { get; }
		public int Zipcode { get; set; }
		public string ContactNumber { get; set; }

	}

	public class InsurancePolicyInfo
	{
		public string InsCoName { get; set; }
		public bool ACVOnly { get; set; }
		public bool CopyOnFile { get; set; }
		public string DocumentPath { get; set; }
		public string PolicyID { get; set; }
	}

	public class CallLog
	{
		public DateTime CallTime { get; set; }
		public string ReasonForCall { get; set; }
		public string CallResult { get; set; }
		public bool CallBack { get; set; }
		public DateTime CallBackWhen { get; set; }

	}

	public class ClaimStatusData
	{
		public ObservableCollection<CallLog> CallLog { get; set; }
		public DateTime ClaimDate { get; set;}
		public String CurrentStatus { get; set; }

	}

	public class ClaimContactInfo
	{
		public CustomerInfo Customer { get; set; }
		public string Salesperson { get; set; }
		public string Supervisor { get; set; }
		public string Installer { get; set; }
		public string InteriorFinisher { get; set; }
		public string RoofMaterialSupplier { get; set; }
		public string InsuranceCompany { get; set; }
		public string ReferralName { get; set; }


	}

	public class AdjustedSupplies:InvoiceItem
	{
		public double Amount { get; set; }
		public bool PositiveTowardClaim { get; set; }


	}

	public class InvoiceItem
	{
		public string UnitName { get; set; }
		public string UnitDescription { get; set; }
		public int Quantity { get; set; }
		public double UnitPrice { get; set; }
		public string UnitOfMeasure { get; set; }

	}

	public class MiscReceipt:InvoiceItem
	{
		public double Amount { get; set; }
	}

	public class CapOut
	{
		public double RoofLaborTotal { get; set; }
		public double RoofMaterialTotal { get;set; }
		public double ReferralAmount { get; set; }
		public double Draw { get; set; }
		public int OverheadPercentSplit { get; set; }     //10% default value greater increases job cost

		public int ProfitPercentSplit { get; set; }     // Salesperson = X  Company = Y default formula X<=100  Y=100-X
		public double OriginalScopeAmout { get; set; }
		public int RoofLaborFactor { get; set; }
		public double NoOfSQ { get; set; }
		public int Location { get; set; }
		public string Salesperson { get; set; }
		public AdjustedSupplies BringBack { get; set; }
		public double SettlementAmount { get; set; }
		public int OverheadLayout { get; set; }
		public CustomerInfo Customer { get; set; }
		public double SalesSplit { get; set; }
		public double CompanySplit { get; set; }
		public double Overhead { get; set; }
		public double GutterAmount { get; set; }
		public double InteriorAmount { get; set; }
		public double ExteriorAmount { get; set; }
		public ObservableCollection<MiscReceipt> MiscFigures { get; set; }


	}

}
