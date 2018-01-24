using MRNNexus_Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace MRN_Claim_Services.Controllers
{

    public class MRNClaimView
    {
        DateTime entryDate = DateTime.Today;
        DTO_ClaimContacts cc = new DTO_ClaimContacts();
        //ClaimContact **cc**

        DTO_Lead lead = new DTO_Lead();
        //Lead	cc

        DTO_KnockerResponse kr = new DTO_KnockerResponse();
        //KnockerResponse
        //
        DTO_Employee salesperson = new DTO_Employee();
        //Salesperson  cc
        bool isReferral;
        //bool isreferral
        DTO_Referrer r = new DTO_Referrer();
        //Referral  cc
        DTO_Employee k = new DTO_Employee();
        //Knocker  cc
        DTO_Address a = new DTO_Address();
        //Property Address
        DTO_Customer c = new DTO_Customer();
        //Customer     cc
        DTO_InsuranceCompany ic = new DTO_InsuranceCompany();
        //InsuranceCompany
        DTO_Claim _claim = new DTO_Claim();
        //Complete Contract
        //DTO_Claim
        DTO_CalendarData schedinspect = new DTO_CalendarData();
        //Schedule Inspection--Calendar Data
        DTO_Inspection i = new DTO_Inspection();
        //Inspection
        List<DTO_Damage> damagePhotos = new List<DTO_Damage>();
        //Damages
        List<DTO_ClaimDocument> claimDocs = new List<DTO_ClaimDocument>();
        DTO_ClaimDocument contract, capout, rooforder, shinglecolorauthorize, estimate, origscope, finalscope, inspectionResult, policy, roofmaterialinv, rooflaborinvoice, bringback, gutterinvoice, exteriorinvoice, interiorinvoice, claimsuppworksheet, sketch, eagleview, coc, warranty, supplierroofmaterialorderform, interiorworkorder, exteriorworkorder, firstcheck, depreciationcheck, supplementcheck, upgradecheck, deductiblecheck, receipt1, receipt2, receipt3, receipt4, receipt5, lienwaver = new DTO_ClaimDocument();

        //ClaimDocumentation
        DTO_Plane roofData = new DTO_Plane();
        //Plane
        DTO_Scope mrnestimate = new DTO_Scope();
        //ClaimIt
        List<DTO_CallLog> cl = new List<DTO_CallLog>();
        DTO_CallLog correspondence01 = new DTO_CallLog();

        //CallLog
        DTO_Adjustment adjustment = new DTO_Adjustment();
        //Adjustment
        DTO_Adjuster siteAdjuster = new DTO_Adjuster();
        //Adjuster
        bool bought;
        //AdjustmentResult
        DTO_Scope origScope = new DTO_Scope();
        //Scope
        DTO_Adjuster insideAdjuster = new DTO_Adjuster();
        //Supplement -- 
        DTO_CallLog suppRecCor = new DTO_CallLog();
        //CallLog -- Settle
        DTO_CallLog suppRecConfCor = new DTO_CallLog();
        //CallLog -- Confirm
        DTO_Payment firstCheck, supplementCheck, depreciationCheck, upgradeCheck, deductibleCheck = new DTO_Payment();
        //FirstCheck--DTOPayment
        DTO_Scope finalScope = new DTO_Scope();
        //NewScope
        DTO_NewRoof nr = new DTO_NewRoof();
        //NewRoof
        DTO_Order roofOrder = new DTO_Order();
        //Order
        List<DTO_OrderItem> roofOrderContents = new List<DTO_OrderItem>();
        DTO_OrderItem primaryshingles, startershingle, underlayment, valleyunderlayment, ridgeShinges, turtlebacks, ridgeVent, coilnails, plasticCaps, osb, dripedge, caulk, paint = new DTO_OrderItem();
        //Order -- OrderItems
        DTO_ClaimVendor roofer, supplier, gutterguy, interiorguy, exteriorguy = new DTO_ClaimVendor();
        //ClaimVendor
        //Invoice -- Material
        DTO_Invoice roofmatinv, roofLaborInv, extinv, gutinv, intinv = new DTO_Invoice();

        DTO_CalendarData schedroof, gutter, interior, exterior = new DTO_CalendarData();
        //Schedule Roof -- CalendarData
        //


        //Invoice -- Roofer
        DTO_CallLog RoofSchedNotify = new DTO_CallLog();
        //Call Log -- Notify Homeowner


        //RoofGoesOn
        //Additional Supply
        DTO_AdditionalSupply ads = new DTO_AdditionalSupply();

        DTO_SurplusSupplies ss = new DTO_SurplusSupplies();
        //Surplus Supply

        //Invoice -- Interior -- ClaimVendor
        //Invoice -- Exterior -- ClaimVendor
        //Invoice -- Gutter -- ClaimVendor
        DTO_Adjuster newinsideAdjuster = new DTO_Adjuster();
        //Supplement -- 
        DTO_CallLog cocRecCor = new DTO_CallLog();
        //CallLog -- Settle
        DTO_CallLog cocRecConfCor = new DTO_CallLog();
        List<bool> QuestionaireAnswersBool;
        List<DateTime> QuestionaireDates;
        List<string> QuestionaireAnswersStg;
        int[] QuestionAnswerRouting = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};//1-bool,2-Date/Time,3-String
        int[] FUNQuestionAnswerRout = { 3, 4, 3, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 0, 0 };
        int[] FUYQuestionAnswerRout = { 0, 3, 3, 23, 23, 23, 23, 23, 23, 4, 2, 2, 2, 4, 3, 3, 3, 3, 3, 3, 3, 13, 13, 13, 13, 13, 13, 13, 13, 13 };
		//CallLog -- Confirm
		//Payment -- Supplement
		//Paymrnt -- Depreciation
		//Payment -- Deductible
		DTO_CalculatedResults cr = new DTO_CalculatedResults();
		//Capout -- CalculatedResults
		public MRNClaimView()
		{

		}
	
		//Warranty
			public List<string> claimquestions = claimQuestions();
		public static List<string> claimQuestions()
		{
			List<string> cq = new List<string>();
			string q1 = "Is this an insurance claim?";
			string q2 = "Do you have the insurance claim number available?";
			string q3 = "Was this claim generated by a knocker?";
			string contract = "Contract";
			string cdsketch = "Sketch";
			string cdpolicy = "Ins Policy";
			string q4 = "Was the supplement accepted?";
			string scope1 = "MRN Estimate";
			string scope3 = "Final scope";
			string scope2 = "Original scope";
			string insrep = "Inspection Report";
			string insphotos = "Are inspection photos available for import?";
			string cdeagle = "Was an eagleview ordered for this claim?";
			string finPhoto = "Finished Photos";
			string firstcheck = "First";
			string suppcheck = "Supplement";
			string depcheck = "Depreciation";
			string dedcheck = "Deductible";
			string upgcheck = "Upgrade";
			string labinv = "Roof Labor";
			string matinv = "Roof Material";
			string intinv = "Interior";
			string gutinv = "Gutters";
			string extinv = "Exterior";
			string miscinv = "Misc";
			string shingAuth = "Shingle Color Authorization";
			string satis = "Customer Satisfaction";
			string matspec = "Sales Material Specs Sheet";
			string supplierOrder = "Roof Material Order Form";
			string coc = "Certificate of Completion";
			string cap = "Profit Sheet(Cap Out)";
			cq.Add(q1); cq.Add(q2); cq.Add(q3); cq.Add(contract); cq.Add(cdsketch); cq.Add(cdpolicy); cq.Add(q4); cq.Add(scope1); cq.Add(scope2); cq.Add(scope3); cq.Add(insrep); cq.Add(insphotos); cq.Add(cdeagle); cq.Add(finPhoto); cq.Add(firstcheck); cq.Add(suppcheck); cq.Add(depcheck); cq.Add(dedcheck); cq.Add(upgcheck); cq.Add(labinv); cq.Add(matinv); cq.Add(intinv); cq.Add(gutinv); cq.Add(extinv); cq.Add(miscinv); cq.Add(shingAuth); cq.Add(satis); cq.Add(matspec); cq.Add(supplierOrder); cq.Add(coc); cq.Add(cap);


			return cq;
		}
	}

	public class MRNClaim
	{
		static MRNClaim _MrnClaim;
		public static MRNClaim getInstance()
		{
			if (_MrnClaim == null)
				_MrnClaim = new MRNClaim();
			return _MrnClaim;
		}
		public DTO_ClaimContacts cc { get; set; }
		//ClaimContact **cc**

		public DTO_Lead Lead { get; set; }
		//Lead	cc

		public DTO_KnockerResponse KnockResponse { get; set; }
		//KnockerResponse
		//
		public DTO_Employee salesperson { get; set; }
		//Salesperson  cc
		bool isReferral;
		//bool isreferral
		public DTO_Referrer r { get; set; }
       
		public DTO_LU_LeadType lt { get; set; }
		//Referral  cc
		public DTO_Employee k { get; set; }
		//Knocker  cc
		public DTO_Address a { get; set; }
		//Property Address
		public DTO_Customer c { get; set; }
		//Customer     cc
		public DTO_InsuranceCompany ic { get; set; }
		//InsuranceCompany
		public DTO_Claim _claim { get; set; }
		//Complete Contract
		//DTO_Claim
		public DTO_CalendarData schedinspect { get; set; }
		public DTO_Inspection i { get; set; }
		//Inspection
		public List<DTO_ClaimDocument> inspectionPhotos { get; set; }
        public List<DTO_Employee> el { get; set; }
		public List<DTO_Damage> damageLocations { get; set; }
		//Damages
		public List<DTO_ClaimDocument> claimDocs { get; set; }
		public DTO_ClaimDocument contract { get; set; }
		public DTO_ClaimDocument capout { get; set; }
		public DTO_ClaimDocument rooforder { get; set; }
		public DTO_ClaimDocument shinglecolorauthorize { get; set; }
		public DTO_ClaimDocument estimate { get; set; }
		public DTO_ClaimDocument origscope { get; set; }
		public DTO_ClaimDocument finalscope { get; set; }
		public DTO_ClaimDocument inspectionResult { get; set; }
		public DTO_ClaimDocument policy { get; set; }
		public DTO_ClaimDocument roofmaterialinv { get; set; }
		public DTO_ClaimDocument rooflaborinvoice { get; set; }
		public DTO_ClaimDocument bringback { get; set; }
		public DTO_ClaimDocument gutterinvoice { get; set; }
		public DTO_ClaimDocument exteriorinvoice { get; set; }
		public DTO_ClaimDocument interiorinvoice { get; set; }
		public DTO_ClaimDocument claimsuppworksheet { get; set; }
		public DTO_ClaimDocument sketch { get; set; }
		public DTO_ClaimDocument eagleview { get; set; }
		public DTO_ClaimDocument coc { get; set; }
		public DTO_ClaimDocument warranty { get; set; }
		public DTO_ClaimDocument supplierroofmaterialorderform { get; set; }
		public DTO_ClaimDocument interiorworkorder { get; set; }
		public DTO_ClaimDocument exteriorworkorder { get; set; }
		public DTO_ClaimDocument firstcheck { get; set; }
		public DTO_ClaimDocument depreciationcheck { get; set; }
		public DTO_ClaimDocument supplementcheck { get; set; }
		public DTO_ClaimDocument upgradecheck { get; set; }
		public DTO_ClaimDocument deductiblecheck { get; set; }
		public DTO_ClaimDocument receipt1 { get; set; }
		public DTO_ClaimDocument receipt2 { get; set; }
		public DTO_ClaimDocument receipt3 { get; set; }
		public DTO_ClaimDocument receipt4 { get; set; }
		public DTO_ClaimDocument receipt5 { get; set; }
		public DTO_ClaimDocument lienwaver { get; set; }
        public List<DTO_CalendarData> cd { get; set; }
		//ClaimDocumentation
		public DTO_Plane roofData { get; set; }
		//Plane
		public DTO_Scope mrnestimate { get; set; }
		//ClaimIt
		public List<DTO_CallLog> cl { get; set; }
		public DTO_CallLog correspondence01 { get; set; }

		//CallLog
		public DTO_Adjustment adjustment { get; set; }
		//Adjustment
		public DTO_Adjuster siteAdjuster { get; set; }
		//Adjuster
		bool bought;
		//AdjustmentResult
		public DTO_Scope origScope { get; set; }
		//Scope
		public DTO_Adjuster insideAdjuster { get; set; }
		//Supplement -- 
		public DTO_CallLog suppRecCor { get; set; }
		//CallLog -- Settle
		public DTO_CallLog suppRecConfCor { get; set; }
		//CallLog -- Confirm
		public DTO_Payment firstCheck { get; set; }
		public DTO_Payment supplementCheck { get; set; }
		public DTO_Payment depreciationCheck { get; set; }
		public DTO_Payment upgradeCheck { get; set; }
		public DTO_Payment deductibleCheck { get; set; }
		//FirstCheck--DTOPayment
		public DTO_Scope finalScope { get; set; }
		//NewScope
		public DTO_NewRoof nr { get; set; }
		//NewRoof
		public DTO_Order roofOrder { get; set; }
		//Order
		public List<DTO_OrderItem> roofOrderContents = new List<DTO_OrderItem>();
		public DTO_OrderItem primaryshingles { get; set; }
		public DTO_OrderItem startershingle { get; set; }
		public DTO_OrderItem underlayment { get; set; }
		public DTO_OrderItem valleyunderlayment { get; set; }
		public DTO_OrderItem ridgeShinges { get; set; }
		public DTO_OrderItem turtlebacks { get; set; }
		public DTO_OrderItem ridgeVent { get; set; }
		public DTO_OrderItem coilnails { get; set; }
		public DTO_OrderItem plasticCaps { get; set; }
		public DTO_OrderItem osb { get; set; }
		public DTO_OrderItem dripedge { get; set; }
		public DTO_OrderItem caulk { get; set; }
		public DTO_OrderItem paint { get; set; }
        public List<DTO_ClaimStatus> cs { get; set; }
		//Order -- OrderItems
		public DTO_ClaimVendor roofer { get; set; }
		public DTO_ClaimVendor supplier { get; set; }
		public DTO_ClaimVendor gutterguy { get; set; }
		public DTO_ClaimVendor interiorguy { get; set; }
		public DTO_ClaimVendor exteriorguy { get; set; }
		//ClaimVendor
		//Invoice -- Material
		public DTO_Invoice roofmatinv { get; set; }
		public DTO_Invoice roofLaborInv { get; set; }
		public DTO_Invoice extinv { get; set; }
		public DTO_Invoice gutinv { get; set; }
		public DTO_Invoice intinv { get; set; }
		public DTO_CalendarData schedroof { get; set; }
		public DTO_CalendarData gutter { get; set; }
		public DTO_CalendarData interior { get; set; }
		public DTO_CalendarData exterior { get; set; }
		//Schedule Roof -- CalendarData
		
		//Invoice -- Roofer
		public DTO_CallLog RoofSchedNotify { get; set; }
		//Call Log -- Notify Homeowner
		//RoofGoesOn
		//Additional Supply
		public DTO_AdditionalSupply ads { get; set; }
        public List<DTO_CalendarData> appts { get; set; }
        public DTO_SurplusSupplies ss { get; set; }
		//Surplus Supply

		//Invoice -- Interior -- ClaimVendor
		//Invoice -- Exterior -- ClaimVendor
		//Invoice -- Gutter -- ClaimVendor
		public DTO_Adjuster newinsideAdjuster { get; set; }
		static ServiceLayer s1 = ServiceLayer.getInstance();
		//Supplement -- 
		public DTO_CallLog cocRecCor { get; set; }
		//CallLog -- Settle
		public DTO_CallLog cocRecConfCor { get; set; }
		//CallLog -- Confirm
		//Payment -- Supplement
		//Paymrnt -- Depreciation
		//Payment -- Deductible
		public DTO_CalculatedResults cr { get; set; }
		//Capout -- CalculatedResults
		public string MortgageCo { get; set; }
		public string MortgageCoAcctNum { get; set; }
		public async Task<bool> InitalizeClaim(MRNClaim mrnClaim)
		{
			await s1.AddCustomer(c);
			if (mrnClaim.c.Message == null)
			{
				mrnClaim.Lead.CustomerID = mrnClaim.a.CustomerID = mrnClaim.c.CustomerID;
				await s1.AddAddress(mrnClaim.a);
				if (mrnClaim.a.Message == null)
					mrnClaim.Lead.LeadDate = DateTime.Today;
				await s1.AddLead(mrnClaim.Lead);

				if (mrnClaim.Lead == null)
					await s1.AddReferrer(r);
				if (mrnClaim.r.Message == null)

					mrnClaim._claim.IsOpen = true;
				mrnClaim._claim.LeadID = mrnClaim.Lead.LeadID;
				mrnClaim._claim.BillingID = mrnClaim.a.AddressID;
				await s1.AddClaim(mrnClaim._claim);
				if (mrnClaim._claim.Message == null)
					await s1.AddClaimStatus(new DTO_ClaimStatus { ClaimID = mrnClaim._claim.ClaimID, ClaimStatusTypeID = 1, ClaimStatusDate = DateTime.Today });
				mrnClaim.cc.ClaimID = mrnClaim._claim.ClaimID;
				await s1.UpdateClaimContacts(cc);
			}

			return true;
		}
	
}
	public class MRNClaimVendors
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		List<DTO_ClaimVendor> ClaimVendorsList = new List<DTO_ClaimVendor>();
		DTO_Claim Claim = new DTO_Claim();
		DTO_Vendor Roofer = new DTO_Vendor();
		DTO_Vendor GutterGuy = new DTO_Vendor();
		DTO_Vendor ExteriorGuy = new DTO_Vendor();
		DTO_Vendor InteriorGuy = new DTO_Vendor();
		DTO_Vendor RoofMaterialSupplier = new DTO_Vendor();
		

		public MRNClaimVendors(DTO_Claim Claim)
		{
			var roofer = new DTO_ClaimVendor();
			var gutterGuy = new DTO_ClaimVendor();
			var exteriorGuy = new DTO_ClaimVendor();
			var interiorGuy = new DTO_ClaimVendor();
			var roofmaterialSupplier = new DTO_ClaimVendor();
			roofer.ClaimID = gutterGuy.ClaimID=exteriorGuy.ClaimID=interiorGuy.ClaimID= roofmaterialSupplier.ClaimID = Claim.ClaimID; ;
			roofer.ServiceTypeID = 4;
			exteriorGuy.ServiceTypeID = 1;
			gutterGuy.ServiceTypeID = 2;
			interiorGuy.ServiceTypeID = 3;
			roofmaterialSupplier.ServiceTypeID = 5;

			roofer.VendorID = Roofer.VendorID;
			exteriorGuy.VendorID = ExteriorGuy.VendorID;
			interiorGuy.VendorID = InteriorGuy.VendorID;
			gutterGuy.VendorID = GutterGuy.VendorID;
			roofmaterialSupplier.VendorID = RoofMaterialSupplier.VendorID;
			

			ClaimVendorsList.Add(roofer);
			ClaimVendorsList.Add(gutterGuy);
			ClaimVendorsList.Add(exteriorGuy);
			ClaimVendorsList.Add(interiorGuy);
			ClaimVendorsList.Add(roofmaterialSupplier);
		
		}
       
		async Task<List<DTO_ClaimVendor>> GetClaimVendors(DTO_Claim claim)
		{

			await s1.GetAllClaimVendors();

			return new List<DTO_ClaimVendor>(s1.ClaimVendorsList.FindAll(x => x.ClaimID == claim.ClaimID));
		}
		async Task<bool> AddClaimVendors(List<DTO_ClaimVendor> claimVendorList)
		{

			var claimvendors = await GetClaimVendors(new DTO_Claim { ClaimID = claimVendorList[0].ClaimID });


			foreach (var item in claimVendorList)
			{
				try {
					if (item != null)
						if (!claimvendors.Exists(x => x.ServiceTypeID == item.ServiceTypeID))
							await s1.AddClaimVendor(item);
					Debug.Write("ClaimVendor Added.");
				}
				catch(Exception ex){
					Debug.Write(ex.ToString());
					return false;
				}
			}

				return true;
			}
	}
	public class MRNRoofOrder 
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		public string ShingleColor { get; set; }
		public List<List<string>> ShingleColors { get; set; }
		public List<List<string>> OwensCorningShingleColors = new List<List<string>>();
		public List<string> OwensCorningShingles = new List<string>();
		public List<string> Duration = new List<string>();
		public List<string> Trudef = new List<string>();
		public List<string> Supreme = new List<string>();
		public List<string> DesignerDuration = new List<string>();


		public double SquareFeetOff { get; set; }
		public double Ridges { get; set; }
		public int HipShingleBundles { get; set; }
		public int RollsValleysUnderlayment { get; set; }
		public int RollsUnderlayment { get; set; }
		public double Eaves { get; set; }
		public double Rakes { get; set; }
		public double DripEdge { get; set; }
		public string ShingleManufacurer { get; set; }
		public string ShingleType { get; set; }
		public int StarterShingle { get; set; }
		public string Underlayment { get; set; }
		public string Ventilation { get; set; }
		public int PredPitch { get; set; }
		public string ValleyUnderlayment { get; set; }
		public int TurtleBacks { get; set; }

		public MRNRoofOrder(/*List<DTO_Plane> planesList, int ventType, int iunderlayment, int iValleyType, int HipRidgeType, bool bDripEdge=true, bool RakesOnly =true , bool isInchesMeasured = true, int turtleBacks = 0, bool fillInTurtles= true*/)
		{
			//double sQCtAggregate = 0, ridgesAggregate = 0, hipsAggregate = 0, valleysAggregate = 0, rakesAggregate = 0, eavesAggregate = 0;
			//int pjb3 = 0, pjb4 = 0, noOfDecking = 0;
			//double sdivisor = isInchesMeasured ? 144 : 1;
			//double ldivisor = isInchesMeasured ? 12 : 1;
			//double TotsSq = 0;
			
			//// lets add some shit up and get the totals so we can order;
			//bool hasTurtleBackRR = turtleBacks > 0 ? true : false;
			//int tempDeck = 0; 
			//// totalSquares off
			//foreach (var item in planesList)
			//{
			//	sQCtAggregate += (double)((((item.EaveLength + item.RidgeLength) * (item.RakeLength + item.RakeLength))/2) / sdivisor);
			//	ridgesAggregate += (double)(item.RidgeLength);
			//	hipsAggregate += (double)(item.Hip);
			//	valleysAggregate += (double)(item.Valley);
			//	rakesAggregate += (double)(item.RakeLength);
			//	eavesAggregate += (double)(item.EaveLength);
			//	pjb3 += (int)(item.ThreeAndOne);
			//	pjb4 += (int)(item.FourAndUp);
			//	TotsSq += (double)(item.SquareFootage);
			//	noOfDecking += item.NumberDecking > 0 ? (int)item.NumberDecking : 0;
				
			//}
			//noOfDecking += (fillInTurtles == hasTurtleBackRR) ? turtleBacks / 6 : 0;
			//this.SquareFeetOff = sQCtAggregate;
			//this.HipShingleBundles =(int)Math.Ceiling((hipsAggregate + ridgesAggregate) / 26);
			//this.RollsValleysUnderlayment = (int)Math.Ceiling(valleysAggregate / 66);
			//this.RollsUnderlayment = (int)Math.Ceiling(TotsSq / 20);
			//this.




		}
		async Task<bool> GotNewRoof(DTO_Claim claim) {
			await s1.GetAllNewRoofs();

			return s1.NewRoofsList.Exists(x => x.ClaimID == claim.ClaimID);
			

		}

		async private Task<DTO_NewRoof> GetNewRoof(DTO_Claim claim)
		{
			return await GotNewRoof(claim) ? s1.NewRoofsList.Find(x => x.ClaimID == claim.ClaimID) : null;
		}

		async Task<bool> figureMaterials(List<DTO_Plane> planesList, DTO_NewRoof roof)
		{

			double sQCtAggregate = 0, ridgesAggregate = 0, hipsAggregate = 0, valleysAggregate = 0, rakesAggregate = 0, eavesAggregate = 0;
			int pjb3 = 0, pjb4 = 0, noOfDecking = 0, turtleBacks = 0;
			
			double TotsSq = 0;
			bool isInchesMeasured = true;
			bool fillInTurtles = true;
			int tempDeck = 0;
			double sdivisor = isInchesMeasured ? 144 : 1;
			double ldivisor = isInchesMeasured ? 12 : 1;
			// totalSquares off
			foreach (var item in planesList)
			{
				sQCtAggregate += (double)((((item.EaveLength + item.RidgeLength) * (item.RakeLength + item.RakeLength)) / 2) / sdivisor);
				ridgesAggregate += (double)(item.RidgeLength);
				hipsAggregate += (double)(item.Hip);
				valleysAggregate += (double)(item.Valley);
				rakesAggregate += (double)(item.RakeLength);
				eavesAggregate += (double)(item.EaveLength);
				pjb3 += (int)(item.ThreeAndOne);
				pjb4 += (int)(item.FourAndUp);
				TotsSq += (double)(item.SquareFootage);
				noOfDecking += item.NumberDecking > 0 ? (int)item.NumberDecking : 0;
				turtleBacks += item.TurtleBacks == null ? 0 : (int)item.TurtleBacks;
			}
			
			// lets add some shit up and get the totals so we can order;
			bool hasTurtleBackRR = turtleBacks > 0 ? true : false;

			noOfDecking += (fillInTurtles == hasTurtleBackRR) ? turtleBacks / 6 : 0;
			this.SquareFeetOff = sQCtAggregate;
			this.primaryshingles.Quantity = (int)((this.SquareFeetOff / 100) * 3);
			this.HipShingleBundles = (int)Math.Ceiling((hipsAggregate + ridgesAggregate) / 26);
			this.ridgeShingles.Quantity = this.HipShingleBundles;
			this.RollsValleysUnderlayment = (int)Math.Ceiling(valleysAggregate / 66);
			this.valleyunderlayment.Quantity = this.RollsValleysUnderlayment;

			this.RollsUnderlayment = (int)Math.Ceiling(TotsSq / 20);
			this.underlayment.Quantity = this.RollsUnderlayment;
			this.StarterShingle = (int)Math.Ceiling((eavesAggregate + rakesAggregate) / 100);
			this.startershingle.Quantity = StarterShingle;
			this.DripEdge = !roof.DripEdgeInstall ? 0 : roof.RakesOnly ? (int)Math.Ceiling(rakesAggregate / 9.1) : (int)Math.Ceiling((rakesAggregate + eavesAggregate) / 9.1);
			this.dripedge.Quantity = (int)this.DripEdge;

			this.plasticCaps.Quantity = (int)Math.Ceiling(TotsSq / 20);
			this.coilnails.Quantity = (int)Math.Ceiling((TotsSq*1.15) / 16);
			this.osb.Quantity =noOfDecking;
			this.ridgeVent.Quantity = (int)Math.Ceiling(ridgesAggregate / 4);
			this.paint.Quantity = 3;
			this.caulk.Quantity = 3;

			return true;
		}

		public List<object> BuildRoofOrder(DTO_NewRoof roof)
		{
			List<object> mrnRoofOrder = new List<object>();
			mrnRoofOrder.Add(roofOrder);
			primaryshingles = s1.Products.Where(x => x.ProductID == roof.ProductID) as DTO_OrderItem;
			roofOrderContents.Add(primaryshingles); // OwensCorningShingles[Type].ToString()).Select(x=>x.Name)));
			roofOrderContents.Add(startershingle);
			roofOrderContents.Add(underlayment);
			roofOrderContents.Add(valleyunderlayment);
			roofOrderContents.Add(ridgeShingles);
			roofOrderContents.Add(turtlebacks);
			roofOrderContents.Add(ridgeVent);
			roofOrderContents.Add(coilnails);
			roofOrderContents.Add(plasticCaps);
			roofOrderContents.Add(osb);
			roofOrderContents.Add(dripedge);
			roofOrderContents.Add(paint);
			roofOrderContents.Add(caulk);
			mrnRoofOrder.Add(roofOrderContents);
			return mrnRoofOrder;
		}
		public DTO_Order roofOrder { get; set; }
		//Order
		public List<DTO_OrderItem> roofOrderContents { get; set; }
		public DTO_OrderItem primaryshingles { get; set; }
		public DTO_OrderItem startershingle { get; set; }
		public DTO_OrderItem underlayment { get; set; }
		public DTO_OrderItem valleyunderlayment { get; set; }
		public DTO_OrderItem ridgeShingles { get; set; }
		public DTO_OrderItem turtlebacks { get; set; }
		public DTO_OrderItem ridgeVent { get; set; }
		public DTO_OrderItem coilnails { get; set; }
		public DTO_OrderItem plasticCaps { get; set; }
		public DTO_OrderItem osb { get; set; }
		public DTO_OrderItem dripedge { get; set; }
		public DTO_OrderItem caulk { get; set; }
		public DTO_OrderItem paint { get; set; }

		//Order -- OrderItems
	}
	/// <summary>
	/// Interaction logic for StartClaim.xaml
	/// </summary>
	public partial class StartClaim : Page
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();


		public StartClaim()
		{
			InitializeComponent();
		}

		private void Startbutton_Click(object sender, RoutedEventArgs e)
		{
			DTO_Employee Salesperson = new DTO_Employee();
			this.NavigationService.Navigate(new MRN_Claim_Services.Controllers.SalespersonSelectionPage());

		}

		public MRNClaim GenerateNewClaim()
		{
			return new MRNClaim();
		}
	}
}
