using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static MRN_Claim_Services.MainWindow;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using MRN_Claim_Services.Models.Structure;
using MRN_Claim_Services.Controllers;
using MRNNexus_Model;

namespace MRN_Claim_Services.Models
{
	public class DetailedCompactClaimModel
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		public static DetailedCompactClaimModel DCM;
		public static ObservableCollection<DetailedCompactClaimModel> DCML;


		public DetailedCompactClaimModel()
		{
			BuildList();
		}

		#region Members For DetailedCompactClaimModel

		public DTO_Claim Claim { get; set; }
		public string InsCoClaimNumber { get; set; }
		public string MRNClaimNumber { get; set; }
		public string ClaimCustomer { get; set; }
		public string Salesperson { get; set; }
		public string ClaimReferral { get; set; }
		public DateTime SignedDate { get; set; }
		public DateTime AdjustmentDate { get; set; }
		public bool Bought { get; set; }
		public DateTime FirstCheckCollected { get; set; }
		public int ClaimAge { get; set; }
		public bool bFirstCheckCollected { get; set; }
		public DateTime InspectionDate { get; set; }
		public DateTime PlaneMeasurementsRcvd { get; set; }
		public DateTime EstimateCompleted { get; set; }
		public DateTime SupplemetSent { get; set; }
		public DateTime SupplementSettled { get; set; }
		public DateTime RoofScheduled { get; set; }
		public DateTime RoofCompleted { get; set; }
		public DateTime GuttersScheduled { get; set; }
		public DateTime InteriorScheduled { get; set; }
		public DateTime ExteriorScheduled { get; set; }
		public DateTime CertOfCompSent { get; set; }
		public DateTime SupplementCheckRcvd { get; set; }
		public DateTime SupplementCheckColl { get; set; }
		public DateTime DepreciationCheckRcvd { get; set; }
		public DateTime DepreciationCheckColl { get; set; }
		public DateTime DeductibleCheckColl { get; set; }
		public DateTime CappedOut { get; set; }
		public DateTime WarrantySent { get; set; }
		public string ClaimAddress { get; set; }
		public string ClaimCSZ { get; set; }
		public string ClaimZip { get; set; }
		public DTO_ClaimStatus ClaimStatus { get; set; }
		public List<DTO_ClaimStatus> ClaimStatuses { get; set; }
		public DTO_ClaimContacts ClaimContact { get; set; }
		public List<DTO_ClaimContacts> ClaimContacts { get; set; }
		public string Supervisor { get; set; }
		public string Supplier { get; set; }
		public string Installer { get; set; }
		public string DeductibleAmount { get; set; }
		public DateTime LossDate { get; set; }
		public string LossType { get; set; }
		public DTO_ClaimDocument ClaimDoc { get; set; }
		public List<DTO_ClaimDocument> ClaimDocs { get; set; }
		public List<DTO_Invoice> InvoiceList { get; set; }
		public List<DTO_Payment> PaymentsList { get; set; }
		public string LeadType { get; set; }
		public ObservableCollection<DTO_Employee> ClaimEmployees { get; set; }
		public List<DTO_CallLog> ClaimCallLogs { get; set; }
		public List<DTO_Employee> AvailableViewers { get; set; }
		public bool bHasViewPermission { get; set; }
		public List<string> CallLogComments { get; set; }
		public DTO_Customer Customer { get; set; }
		public DTO_Address Address { get; set; }
		public DTO_Lead Lead { get; set; }
		public DTO_Adjustment ClaimAdjustment { get; set; }
		public DTO_Adjuster Adjuster { get; set; }
		public DTO_CalculatedResults CalculatedResults { get; set; }
		public DTO_ClaimVendor ClaimVendor { get; set; }
		public List<DTO_ClaimVendor> ClaimVendors { get; set; }
		public DTO_Inspection Inspection { get; set; }
		public DTO_InsuranceCompany InsuranceCompany { get; set; }
		public DTO_Order RoofOrder { get; set; }
		public DTO_Referrer Referral { get; set; }
		public DTO_Scope WorkingScope { get; set; }
		public List<DTO_Scope> ScopesList { get; set; }
		public List<DTO_SurplusSupplies> ClaimSurplusSupplies { get; set; }
		public List<DTO_AdditionalSupply> ClaimAdditionalSupplies { get; set; }
		public List<DTO_Adjustment> ClaimAdjustmentResults { get; set; }
		public DTO_Inspection WorkingInspection { get; set; }



		#endregion

		#region Functions For DetailedCompactClaimModel
		public static DetailedCompactClaimModel getInstance()
		{
			if (DCM == null)
				DCM = new DetailedCompactClaimModel();


			return DCM;


		}
		async void BuildList()
		{
			await s1.GetAllOpenClaims();
			foreach (DTO_Claim c in s1.OpenClaimsList)
			{
				PopulateLists(c);

			}

		}
		async void PopulateLists(DTO_Claim Claim)
		{
			DetailedCompactClaimModel D = new DetailedCompactClaimModel();

			await s1.GetAdditionalSuppliesByClaimID(Claim);
			ClaimAdditionalSupplies = s1.AdditionalSuppliesList.ToList();
			await s1.GetAdjustmentsByClaimID(Claim);
			ClaimAdjustmentResults = s1.AdjustmentsList;
			ClaimAdjustment = s1.AdjustmentsList.LastOrDefault(x => x.ClaimID == Claim.ClaimID);
			await s1.GetLeadByLeadID(new DTO_Lead { LeadID = Claim.LeadID });
			Lead = s1.Lead;
			await s1.GetCustomerByID(new DTO_Customer { CustomerID = Claim.CustomerID });
			Customer = s1.Cust;
			await s1.GetAddressByID(new DTO_Address { AddressID = Lead.AddressID });
			Address = s1.Address;
			await s1.GetCallLogsByClaimID(Claim);
			ClaimCallLogs = s1.CallLogsList;
			await s1.GetClaimContactsByClaimID(Claim);
			ClaimContacts = s1.ClaimContactsList;
			await s1.GetClaimDocumentsByClaimID(Claim);
			ClaimDocs = s1.ClaimDocumentsList;
			await s1.GetClaimStatusByClaimID(Claim);
			ClaimStatuses = s1.ClaimStatusList;
			await s1.GetMostRecentDateByClaimID(Claim);
			try
			{
				ClaimStatus = s1.ClaimStatus;
			}
			catch (Exception ex)
			{

				ClaimStatus = ClaimStatuses.Last();

			}

			await s1.GetClaimVendorsByClaimID(Claim);
			ClaimVendors = s1.ClaimVendorsList;
			await s1.GetInspectionsByClaimID(Claim);
			WorkingInspection = s1.InspectionsList.Last();
			await s1.GetInvoicesByClaimID(Claim);
			InvoiceList = s1.InvoicesList;
			await s1.GetPaymentsByClaimID(Claim);
			PaymentsList = s1.PaymentsList;


			DCML.Add(this);

		}
		#endregion


		#region DBOperations for DetailedCompactClaimModel



		#endregion

	}

	public class ScopeModel
	{

		public static ScopeModel S1;
		public static ObservableCollection<ScopeModel> ScopesList;
		public static ObservableCollection<ScopeModel> ScopesList2;
		public static ObservableCollection<TransactionModel> Transactions = TransactionModel.tgetInstance();

		public ScopeModel()
		{

			PopulateLists();


		}



		#region Members for ScopeModel

		public ObservableCollection<ScopeModel> ScopesList3 = new ObservableCollection<ScopeModel>();
		public string ClaimNumber { get; set; }
		public DateTime ScopeDate { get; set; }
		public bool IsEstimate { get; set; }
		public double ACV { get; set; }
		public double RCV { get; set; }
		public double RoofAmount { get; set; }
		public double Tax { get; set; }
		public double Deductible { get; set; }
		public double NoSquares { get; set; }
		public double AmountDepCollected { get; set; }
		public double NumberofFirstChecksNotCollected { get; set; }
		public int NumberofDepChecksNotCollected { get; set; }
		public int NumberofDedChecksNotCollected { get; set; }
		public bool CollectingDeductible { get; set; }

		public bool HasOW { get; set; }
		public bool IsHouseDeal { get; set; }
		public bool IsReferral { get; set; }
		public string Branch { get; set; }
		public double Draw { get; set; }
		public double SalesSplit { get; set; }
		public string Salesperson { get; set; }
		public double LastRemainingBalance { get; set; }
		public string CustomerName { get; set; }
		public DateTime ScheduledRoofDate { get; set; }
		public DateTime ScheduledCOCDate { get; set; }
		public double SettlementAmount { get; set; }
		public string Comment { get; set; }
		public double AmountFirstCollected { get; set; }
		public double RoofAmountPaid { get; set; }
		public double OWAmount { get; set; }
		public double OWAmountPaid { get; set; }
		public double MaterialAmount { get; set; }
		public double MaterialAmountPaid { get; set; }
		public bool IsCollectedFirst { get; set; }
		public bool IsCollectedDep { get; set; }
		public bool IsCollectedDed { get; set; }
		public bool IsUpdated { get; set; }
		public bool IsPaidRoof { get; set; }
		public bool IsPaidMaterial { get; set; }
		public bool IsPaidOW { get; set; }
		public bool IsPaidCommissions { get; set; }
		public double SupplementAmount { get; set; }
		public double SupplementAmountCollected { get; set; }
		public double SettlementAmountCollected { get; set; }
		public bool IsSupervised { get; set; }
		public bool IsSettled { get; set; }
		public bool ReadyToCap { get; set; }
		public double LaborAmount { get; set; }


		public double TotalSquares { get; set; }
		public double TotalProfit { get; set; }
		public int NoRoof { get; set; }
		public int NumberSalesPersons { get; set; }
		public double HowMuchNeedsCollected { get; set; }
		public double HowMuchHasBeenCollected { get; set; }
		public int HowManyRoofsLastWeek { get; set; }
		public int HowManyNextWeek { get; set; }
		public int HowManyNC { get; set; }
		public int HowManyGA { get; set; }
		public double AverageProfitPerDeal { get; set; }
		public double HowManyCapoutsThisWeek { get; set; }
		public double EstimatedCapoutTotal { get; set; }
		public double NoOfFirstChecks { get; set; }
		public double FirstCheckTotals { get; set; }
		public static List<BitmapImage> NameTags { get; set; }
		public double HowMuchOwed { get; set; }
		public double FirstOutstanding { get; set; }
		public double DepreciationOutstanding { get; set; }
		public double DeductibleOutstanding { get; set; }
		public static List<string> ClaimsToCapout { get; set; }

		public static List<string> ClaimsWithFirstChecks { get; set; }

		DateTime today = DateTime.Today;
		// DateTime FirstDayWorkWeek =DateTime.Today.AddDays(DateTime.Today.DayOfWeek+5)


		#endregion

		public TextBlock BuildReportHeader(string afc, string adc, string adedc, string ctm)
		{
			var rephdr = new TextBlock();
			rephdr.Width = 1490;
			rephdr.Height = 30;
			string dt = DateTime.Today.Date.ToShortDateString();
			string tao = HowMuchOwed.ToString();
			string nfc = NumberofFirstChecksNotCollected.ToString();
			string ndc = NumberofDepChecksNotCollected.ToString();

			rephdr.Text = "As of " + dt + " we are owed " + tao + " made up of " + nfc + " amounting to " + afc + ", and " + ndc + " depreciation checks amounting to " + adc + ", and the remaing in deductibles amounting to " + adedc + ".";







			return rephdr;
		}








		#region Lists For ScopeModel

		public string ALLTEXT1 = "";
		public List<string> RAW = new List<string>();
		public List<string> FILTER = new List<string>();
		public List<string> KEYS = new List<string>();
		public static List<string> BRANCHES = new List<string>();
		public static List<string> SALESPERSON = new List<string>();
		#endregion


		#region Building List for ComboBoxes

		public void PopulateLists()
		{

			BRANCHES.Add("Georgia");
			BRANCHES.Add("North Carolina");
			BRANCHES.Add("Future Expansion");



			SALESPERSON.Add("Preston");
			SALESPERSON.Add("Tony");
			SALESPERSON.Add("Foy");
			SALESPERSON.Add("Jeremy");
			SALESPERSON.Add("Taylor");
			SALESPERSON.Add("Taylor/Payton");
			SALESPERSON.Add("Taylor/Josh");
			SALESPERSON.Add("Taylor/BJ");
			SALESPERSON.Add("Logan");
			SALESPERSON.Add("Harvard");
			SALESPERSON.Add("Craig");
			SALESPERSON.Add("Richard");
			SALESPERSON.Add("Matt");
			SALESPERSON.Add("Lee");
			SALESPERSON.Add("Blake");
			SALESPERSON.Add("Josh");


			FILTER.Add("<Claim>");//0
			FILTER.Add("<Scope>");//1
			FILTER.Add("<Transactions>");//2
			FILTER.Add("<Transaction>");//3
			FILTER.Add("<Scopes>");//4
			FILTER.Add("<Claims>");//5
			FILTER.Add("<Begin>");//6
			FILTER.Add("<End>");//7
			FILTER.Add("<Transactions>");//8
			FILTER.Add("<Transaction>");//9
			FILTER.Add("<Scopes>");//10
			FILTER.Add("<Claims>");//11
			FILTER.Add("<Values>");//12
			FILTER.Add("=\"");//13
			FILTER.Add("\"");//14
			FILTER.Add("ClaimNumber");//15
			FILTER.Add("ScopeDate");//16
			FILTER.Add("IsEstimate");//17
			FILTER.Add("ACV");//18
			FILTER.Add("RCV");//19
			FILTER.Add("RoofAmount");//20
			FILTER.Add("InteriorAmount");//21
			FILTER.Add("ExteriorAmount");//22
			FILTER.Add("GutterAmount");//23
			FILTER.Add("Deductible");//24
			FILTER.Add("NoSquares");//25
			FILTER.Add("IsOP");//26
			FILTER.Add("IsHouseDeal");//27
			FILTER.Add("IsReferral");//28
			FILTER.Add("Branch");//29
			FILTER.Add("TakesFirst");//30
			FILTER.Add("SalesSplit");//31
			FILTER.Add("TakesFirst");//32
									 //TransactionValues
			FILTER.Add("AccountTo");
			FILTER.Add("AccountFrom");
			FILTER.Add("TransactionDate");
			FILTER.Add("For");
			FILTER.Add("AmountofTransaction");



		}
		#endregion

		#region ScopeModel Static Helpers

		public static ScopeModel getInstance()
		{
			if (S1 == null)
			{
				S1 = new ScopeModel();
			}

			return S1;
		}

		public static ObservableCollection<ScopeModel> lgetInstance()
		{
			if (ScopesList == null)
			{
				ScopesList = new ObservableCollection<ScopeModel>();
			}

			return ScopesList;
		}
		public static ObservableCollection<ScopeModel> lgetInstance2()
		{
			if (ScopesList2 == null)
			{
				ScopesList2 = new ObservableCollection<ScopeModel>();
			}

			return ScopesList2;
		}
		#endregion


		#region File Duties Read Write Serialize Deserialize type things



		public string LoadClaimDetails()
		{

			try
			{
				if (ScopesList.Count > 0)
					ScopesList.Clear();
				using (StreamReader st = new StreamReader("claimscopedata.txt"))
				{
					string line;


					while ((line = st.ReadLine()) != null)
					{
						RAW.Add(line);
					}
				}
				bool notfirsttime = false;
				for (int j = 0; j < RAW.Count; j++)
				{

					ScopeModel ns = new ScopeModel();


					if (notfirsttime)
						j--;
					else
						notfirsttime = true;

					ns.ACV = double.Parse(RAW[j++]);//0
					ns.Branch = RAW[j++].ToString();//1
					ns.ClaimNumber = RAW[j++].ToString();//2
					ns.Deductible = double.Parse(RAW[j++]);//3
					ns.Tax = double.Parse(RAW[j++]);//4
					ns.IsEstimate = bool.Parse(RAW[j++]);//5
					ns.IsHouseDeal = bool.Parse(RAW[j++]);//6
					ns.HasOW = bool.Parse(RAW[j++]);//7
					ns.IsReferral = bool.Parse(RAW[j++]);//8
					ns.LastRemainingBalance = double.Parse(RAW[j++]);//9
					ns.NoSquares = double.Parse(RAW[j++]);//10
					ns.RCV = double.Parse(RAW[j++]);//11
					ns.RoofAmount = double.Parse(RAW[j++]);//12
					ns.SalesSplit = double.Parse(RAW[j++]);//13
					ns.ScopeDate = DateTime.Parse(RAW[j++]);//14
					ns.Draw = double.Parse(RAW[j++]);//15
					ns.Salesperson = RAW[j++];//16
					ns.CustomerName = RAW[j++];//17
					ns.ScheduledRoofDate = DateTime.Parse(RAW[j++]);//18
					ns.ScheduledCOCDate = DateTime.Parse(RAW[j++]);//19
					ns.SettlementAmount = double.Parse(RAW[j++]);//20
					ns.IsPaidRoof = bool.Parse(RAW[j++]);//21
					ns.MaterialAmountPaid = double.Parse(RAW[j++]);//22
					ns.IsCollectedFirst = bool.Parse(RAW[j++]);//23
					ns.IsCollectedDep = bool.Parse(RAW[j++]);//24
					ns.IsCollectedDed = bool.Parse(RAW[j++]);//25
					ns.IsUpdated = bool.Parse(RAW[j++]);//26
					ns.IsPaidOW = bool.Parse(RAW[j++]);//27
					ns.IsPaidCommissions = bool.Parse(RAW[j++]);//28
					ns.IsSettled = bool.Parse(RAW[j++]);//29
					ns.SettlementAmount = double.Parse(RAW[j++]);//30
					ns.SettlementAmount = double.Parse(RAW[j++]);//31
					ns.IsSupervised = bool.Parse(RAW[j++]);//32

					ScopesList.Add(ns);






				}
				if (RAW.Count > 0)
					RAW.Clear();
			}

			catch (Exception ex)
			{
				MessageBox.Show("File Couldn't be read! " + ex.Message);
			}

			return "Good Shit All Added!";
		}
		public ScopeModel MakeUpdatedList(ScopeModel ns)
		{

			return new ScopeModel
			{
				ACV = ns.ACV,// = double.Parse(RAW[j++]);//0
				Branch = ns.Branch,// = RAW[j++].ToString();//1
				ClaimNumber = ns.ClaimNumber,// = RAW[j++].ToString();//2
				Deductible = ns.Deductible,// = double.Parse(RAW[j++]);//3
				Tax = ns.Tax,// = double.Parse(RAW[j++]);//4
				IsEstimate = ns.IsEstimate,// = bool.Parse(RAW[j++]);//5
				IsHouseDeal = ns.IsHouseDeal,// = bool.Parse(RAW[j++]);//6
				HasOW = ns.HasOW,// = bool.Parse(RAW[j++]);//7
				IsReferral = ns.IsReferral,// = bool.Parse(RAW[j++]);//8
				LastRemainingBalance = ns.LastRemainingBalance,// = double.Parse(RAW[j++]);//9
				NoSquares = ns.NoSquares,// = double.Parse(RAW[j++]);//10
				RCV = ns.RCV,// = double.Parse(RAW[j++]);//11
				RoofAmount = ns.RoofAmount,// = double.Parse(RAW[j++]);//12
				SalesSplit = ns.SalesSplit,// = double.Parse(RAW[j++]);//13
				ScopeDate = ns.ScopeDate,// = DateTime.Parse(RAW[j++]);//14
				Draw = ns.Draw,// = double.Parse(RAW[j++]);//15
				Salesperson = ns.Salesperson,// = RAW[j++];//16
				CustomerName = ns.CustomerName,// = RAW[j++];//17
				ScheduledRoofDate = ns.ScheduledRoofDate,// = DateTime.Parse(RAW[j++]);//18
				ScheduledCOCDate = ns.ScheduledCOCDate,// = DateTime.Parse(RAW[j++]);//19
				SettlementAmount = ns.SettlementAmount,// = double.Parse(RAW[j++]);//20
				IsPaidRoof = ns.IsPaidRoof,// = bool.Parse(RAW[j++]);//21
				MaterialAmountPaid = ns.MaterialAmountPaid,// = double.Parse(RAW[j++]);//22
				IsCollectedFirst = ns.IsCollectedFirst,// = bool.Parse(RAW[j++]);//23
				IsCollectedDep = ns.IsCollectedDep,// = bool.Parse(RAW[j++]);//24
				IsCollectedDed = ns.IsCollectedDed,// = bool.Parse(RAW[j++]);//25
				IsUpdated = ns.IsUpdated,// = bool.Parse(RAW[j++]);//26
				IsPaidOW = ns.IsPaidOW,// = bool.Parse(RAW[j++]);//27
				IsPaidCommissions = ns.IsPaidCommissions,// = bool.Parse(RAW[j++]);//28
				IsSettled = ns.IsSettled,// = bool.Parse(RAW[j++]);//29
				IsSupervised = ns.IsSupervised
			};// = bool.Parse(RAW[j++]);//32

		}
		public void GetTotals()
		{
			HowManyGA = 0;
			HowManyNC = 0;
			HowMuchHasBeenCollected = 0;
			HowMuchNeedsCollected = 0;
			HowMuchOwed = 0;
			double acvt = 0;
			double acvc = 0;
			double rcvt = 0;
			double rcvc = 0;
			double dedt = 0;
			double dedc = 0;

			foreach (var ab in ScopesList)
			{
				ScopeModel ns = new ScopeModel();
				ns = ab;
				var sm = new ScopeModel();
				sm = MakeUpdatedList(ns);
				ns = sm;
				acvt += ns.ACV;
				acvc += ns.AmountFirstCollected;
				rcvt += ns.RCV - ns.ACV - ns.Deductible - ns.Tax;
				rcvc += ns.AmountDepCollected;
				dedt += ns.Deductible;
				if (ns.IsCollectedDed)
					dedc += Deductible;
				ns.FirstOutstanding = acvt - acvc;
				ns.DepreciationOutstanding = rcvt - rcvc;
				ns.DeductibleOutstanding = dedt - dedc;
				ns.LaborAmount = NoSquares * 68;
				ns.MaterialAmount = NoSquares * 107;
				ns.TotalProfit += ns.RCV - ns.MaterialAmount - (ns.RoofAmount - ns.RCV / 10);
				if (ns.IsCollectedDed)
					//  HowMuchHasBeenCollected += ns.Deductible;
					if (ns.IsCollectedFirst)

						ns.HowMuchHasBeenCollected += (ns.RCV - ns.ACV - ns.Deductible - ns.Tax);
				if (IsCollectedFirst)
					ns.HowMuchHasBeenCollected += AmountFirstCollected;
				ns.HowMuchNeedsCollected += ns.RCV;
				ns.HowMuchOwed = HowMuchNeedsCollected - HowMuchHasBeenCollected;

				if (ns.Branch == "North Carolina")
					ns.HowManyNC++;
				if (ns.Branch == "Georgia")
					ns.HowManyGA++;
				var d = (int)DateTime.Today.DayOfWeek;


				//  if (d<3)

				ScopesList3.Add(ns);
			}





			ScopesList2 = ScopesList3;

		}



		public void SaveClaimDetails(bool DirtyFile = false, ScopeModel g = null)
		{

			DirtyFile = false;



			foreach (ScopeModel s in ScopesList)
			{
				ScopeModel w = new ScopeModel();

				if (g != null && g.ClaimNumber == s.ClaimNumber)
					w = g;
				else w = s;
				if (DirtyFile)
					using (StreamWriter sw = new StreamWriter("claimscopedata.txt", true))
					{
						sw.WriteLine(w.ACV.ToString());
						sw.WriteLine(w.Branch.ToString());
						sw.WriteLine(w.ClaimNumber.ToString());
						sw.WriteLine(w.Deductible.ToString());
						sw.WriteLine(w.Tax.ToString());
						sw.WriteLine(w.IsEstimate.ToString());
						sw.WriteLine(w.IsHouseDeal.ToString());
						sw.WriteLine(w.HasOW.ToString());
						sw.WriteLine(w.IsReferral.ToString());
						sw.WriteLine(w.LastRemainingBalance.ToString());
						sw.WriteLine(w.NoSquares.ToString());
						sw.WriteLine(w.RCV.ToString());
						sw.WriteLine(w.RoofAmount.ToString());
						sw.WriteLine(w.SalesSplit.ToString());
						sw.WriteLine(w.ScopeDate.ToString());
						sw.WriteLine(w.Draw.ToString());
						sw.WriteLine(w.Salesperson.ToString());
						sw.WriteLine(w.CustomerName.ToString());
						sw.WriteLine(w.ScheduledRoofDate.ToString());
						sw.WriteLine(w.ScheduledCOCDate.ToString());
						sw.WriteLine(w.SettlementAmount.ToString());
						sw.WriteLine(w.IsPaidRoof.ToString());
						sw.WriteLine(w.MaterialAmountPaid.ToString());
						sw.WriteLine(w.IsCollectedFirst.ToString());
						sw.WriteLine(w.IsCollectedDep.ToString());
						sw.WriteLine(w.IsCollectedDed.ToString());
						sw.WriteLine(w.IsUpdated.ToString());
						sw.WriteLine(w.IsPaidOW.ToString());
						sw.WriteLine(w.IsPaidCommissions.ToString());
						sw.WriteLine(w.IsSettled.ToString());
						sw.WriteLine(w.SettlementAmount.ToString());
						sw.WriteLine(w.SettlementAmount.ToString());
						sw.WriteLine(w.IsSupervised.ToString());
					}
				if (!DirtyFile)
					using (StreamWriter sw = new StreamWriter("claimscopedata.txt", false))
					{
						sw.WriteLine(w.ACV.ToString());
						sw.WriteLine(w.Branch.ToString());
						sw.WriteLine(w.ClaimNumber.ToString());
						sw.WriteLine(w.Deductible.ToString());
						sw.WriteLine(w.Tax.ToString());
						sw.WriteLine(w.IsEstimate.ToString());
						sw.WriteLine(w.IsHouseDeal.ToString());
						sw.WriteLine(w.HasOW.ToString());
						sw.WriteLine(w.IsReferral.ToString());
						sw.WriteLine(w.LastRemainingBalance.ToString());
						sw.WriteLine(w.NoSquares.ToString());
						sw.WriteLine(w.RCV.ToString());
						sw.WriteLine(w.RoofAmount.ToString());
						sw.WriteLine(w.SalesSplit.ToString());
						sw.WriteLine(w.ScopeDate.ToString());
						sw.WriteLine(w.Draw.ToString());
						sw.WriteLine(w.Salesperson.ToString());
						sw.WriteLine(w.CustomerName.ToString());
						sw.WriteLine(w.ScheduledRoofDate.ToString());
						sw.WriteLine(w.ScheduledCOCDate.ToString());
						sw.WriteLine(w.SettlementAmount.ToString());
						sw.WriteLine(w.IsPaidRoof.ToString());
						sw.WriteLine(w.MaterialAmountPaid.ToString());
						sw.WriteLine(w.IsCollectedFirst.ToString());
						sw.WriteLine(w.IsCollectedDep.ToString());
						sw.WriteLine(w.IsCollectedDed.ToString());
						sw.WriteLine(w.IsUpdated.ToString());
						sw.WriteLine(w.IsPaidOW.ToString());
						sw.WriteLine(w.IsPaidCommissions.ToString());
						sw.WriteLine(w.IsSettled.ToString());
						sw.WriteLine(w.SettlementAmount.ToString());
						sw.WriteLine(w.SettlementAmount.ToString());
						sw.WriteLine(w.IsSupervised.ToString());
						DirtyFile = true;
					}
			}
		}

		#endregion

		public void OnInit()
		{





		}

	}


	//public class Calculations
	//{


	//    #region Members of Calculations





	//    //CalculatedTotals
	//    public static Calculations C;
	//    public static ObservableCollection<Calculations> C1;
	//    public static ScopeModel S1 = ScopeModel.getInstance();
	//    public static ObservableCollection<ScopeModel> scopeslist = ScopeModel.lgetInstance();
	//    private ObservableCollection<Calculations> calculations = new ObservableCollection<Calculations>();
	//    public static ObservableCollection<CompoundDataGridRow> CDGR = CompoundDataGridRow.lgetInstance();
	//    public List<string> ClaimNumbers = new List<string>();
	//    public static List<string> commentlist;

	//    public double PercentCollected { get; set; }
	//    public double AmountCollected { get; set; }
	//    public double PercentFirst { get; set; }
	//    public double AmountFirst { get; set; }
	//    public double PercentDep { get; set; }
	//    public double AmountDep { get; set; }
	//    public double PercentDed { get; set; }
	//    public double AmountDed { get; set; }
	//    public double PercentTotalClaim { get; set; }
	//    public double AmountTotalClaim { get; set; }
	//    public double PercentMRN { get; set; }
	//    public double AmountMRN { get; set; }
	//    public double PercentSalesPerson { get; set; }
	//    public double AmountSalesPerson { get; set; }
	//    public double PercentOverhead { get; set; }
	//    public double AmountOverhead { get; set; }
	//    public double PercentSalesManager { get; set; }
	//    public double AmountSalesManager { get; set; }
	//    public double PercentMaterial { get; set; }
	//    public double AmountMaterial { get; set; }
	//    public double PercentLabor { get; set; }
	//    public double AmountLabor { get; set; }
	//    public double PercentOtherwork { get; set; }
	//    public double AmountOtherwork { get; set; }
	//    public double ProjectedProfit { get; set; }
	//    public double ActualProfit { get; set; }
	//    public double NoSq { get; set; }
	//    public double TotalExpense { get; set; }
	//    public double Profit { get; set; }
	//    public double Draw { get; set; }
	//    public double MRNTotalO_U { get; set; }
	//    public string CustomerName { get; set; }
	//    public string ClaimNumber { get; set; }
	//    public double AmountReferral { get; set; }
	//    public double SalesPersonTotalO_U { get; set; }
	//    public double PercentProjectedProfit { get; set; }
	//    public double PercentActualProfit { get; set; }
	//    public double PercentTotalExpense { get; set; }
	//    public double PercentProfit { get; set; }
	//    public double PercentDraw { get; set; }
	//    public double PercentMRNTotalO_U { get; set; }
	//    public double PercentAmountReferral { get; set; }
	//    public double PercentSalesPersonTotalO_U { get; set; }
	//    public double PercentAmountOtherwork { get; set; }
	//    public bool LastRemainingBalanceChanged { get; set; }
	//    public double ClaimAge { get; set; }
	//    public double ForgivenDeductible { get; set; }
	//    public int TotalRoofs { get; set; }
	//    public DateTime ScheduledRoofDate { get; set; }
	//    public DateTime ScheduledCOCDate { get; set; }
	//    public double SettlementAmount { get; set; }
	//    public string Comment { get; set; }
	//    public double RoofAmountPaid { get; set; }
	//    public double OWAmount { get; set; }
	//    public double OWAmountPaid { get; set; }
	//    public double MaterialAmount { get; set; }
	//    public double MaterialAmountPaid { get; set; }
	//    public bool IsCollectedFirst { get; set; }
	//    public bool IsCollectedDep { get; set; }
	//    public bool IsCollectedDed { get; set; }
	//    public bool IsUpdated { get; set; }
	//    public bool IsPaidRoof { get; set; }
	//    public bool IsPaidMaterial { get; set; }
	//    public bool IsPaidOW { get; set; }
	//    public bool IsPaidCommissions { get; set; }
	//    public double AmountOwed { get; set; }
	//    public double AmountSettlementCollected { get; set; }
	//    public double AmountSettlement { get; set; }
	//    public double PercentofRoofs { get; set; }
	//    public int GrandTotalRoofs { get; set; }
	//    public double AmountSupplement { get; set; }
	//    public double ProjectedSalesProfit { get; set; }
	//    public double AmountSuppelementCollected { get; set; }
	//    public double ProfitPerSQ { get; set; }
	//    public double CostPerSQ { get; set; }
	//    public string Salesperson { get; set; }
	//    public double ProfitMargin { get; set; }
	//    public double ProjectedExpense { get; set; }
	//    public double ProjectedProfitMargin { get; set; }
	//    public double PercentSuppUp { get; set; }
	//    public double AmountDeductibleCollected { get; set; }
	//    public double AmountFirstCollected { get; set; }
	//    public double AmountDepCollected { get; set; }
	//    public int ClaimNumberIndex = 0;
	//    public int CommentNumberIndex = 0;

	//    #endregion
	//    public Calculations()
	//    {

	//    }

	//    #region StaticHelpers for Calculations

	//    public static Calculations getInstance()
	//    {
	//        if (C == null)
	//        {
	//            C = new Calculations();
	//        }
	//        return C;
	//    }

	//    public static ObservableCollection<Calculations> lgetInstance()
	//    {
	//        if (C1 == null)
	//        {
	//            C1 = new ObservableCollection<Calculations>();
	//        }

	//        return C1;
	//    }

	//    public static List<string> clgetInstance()
	//    {
	//        if (commentlist == null)
	//        {
	//            commentlist = new List<string>();
	//        }

	//        return commentlist;
	//    }

	//    #endregion
	//    #region Comment Functions
	//    #region File Duties Read Write Serialize Deserialize type things
	//    public List<string> LoadCommentsForClaims(string ClaimNumber = null)
	//    {
	//        List<string> sl = new List<string>();
	//        try
	//        {
	//            using (StreamReader st = new StreamReader("claimComments.txt"))
	//            {
	//                string line;
	//                while ((line = st.ReadLine()) != null)
	//                {
	//                    if (ClaimNumber != null)
	//                        if (line.Contains(ClaimNumber))
	//                            sl.Add(line.Remove(line.IndexOf(".=.")));
	//                        else;
	//                    else commentlist.Add(line);
	//                }
	//            }
	//        }

	//        catch (Exception ex)
	//        {
	//            MessageBox.Show("File Couldn't be read! " + ex.Message);

	//        }
	//        return sl;
	//    }

	//    public bool SaveClaimComment(string commenttosave, string claimnumber, bool append = true)
	//    {
	//        StringBuilder sb = new StringBuilder();
	//        sb.Append(claimnumber);
	//        sb.Append(".=.");
	//        sb.Append(commenttosave);

	//        using (StreamWriter sw = new StreamWriter("claimComments.txt", append))
	//        {

	//            sw.WriteLine(sb.ToString());
	//        }

	//        return true;
	//    }

	//    #endregion
	//    public string GetClaimComments(List<string> ccl)
	//    {
	//        if (ccl.Count > CommentNumberIndex + 1)
	//            return ccl[CommentNumberIndex++];
	//        else return "";

	//    }

	//    public string DisplayClaimsComments(string claimNumber, List<string> CommentList)
	//    {
	//        string w = "";

	//        foreach (var s in CommentList.Where(s => s.Contains(claimNumber)))
	//        {

	//            w += "#" + s.Remove(s.IndexOf(".=.")) + "#";
	//        }

	//        return w;
	//    }

	//    #endregion

	//    #region Calculating Helpers

	//    private double AmountSalesManagerPay(bool IsHouse)
	//    {
	//        if (IsHouse == true)
	//        {
	//            return 0;
	//        }
	//        else
	//        {
	//            return (AmountCollected * .1) * .125;
	//        }
	//    }

	//    private double PercentSalesManagerPay(bool IsHouse)
	//    {
	//        if (IsHouse == true)
	//        {
	//            return 0;
	//        }
	//        else
	//        {
	//            return AmountSalesManagerPay(IsHouse) / AmountTotalClaim;
	//        }
	//    }

	//    private double ReferralAmount(bool IsRef)
	//    {
	//        if (IsRef == true)
	//            if (NoSq > 40)
	//                return 500;
	//            else return 250;
	//        else return 0;
	//    }

	//    private bool IsLastBalanceChanged(double lrb)
	//    {

	//        if (Profit != lrb)
	//            return true;
	//        return false;
	//    }

	//    public double IsDeductibleCollected(bool dedcol, double dedamt)
	//    {
	//        if (dedcol == true)
	//            return 0;
	//        return dedamt;
	//    }

	//    private double HowOldIsThisClaim()
	//    {
	//        DateTime dt = new DateTime(DateTime.Today.Ticks);
	//        return dt.Subtract(new DateTime(2016, 8, 1)).TotalDays;
	//    }
	//    #endregion

	//    #region Calculating
	//    public Calculations Calculate(ScopeModel s)
	//    {
	//        List<string> commentlist = clgetInstance();
	//        Calculations nc = new Calculations();
	//        //nc.NoSq = s.NoSquares;
	//        //nc.Draw = s.Draw;
	//        //if (nc.AmountSettlement < s.RCV)
	//        //    nc.AmountTotalClaim = s.RCV;
	//        //else nc.AmountTotalClaim = nc.AmountSettlement;
	//        //nc.AmountFirst = s.ACV;
	//        //nc.PercentTotalClaim = nc.AmountTotalClaim / nc.AmountTotalClaim * 100;
	//        //nc.AmountDep = s.RCV - s.ACV - s.Deductible;
	//        //nc.PercentDep = nc.AmountDep / nc.AmountTotalClaim * 100;
	//        //nc.AmountDed = s.Deductible;
	//        //nc.AmountLabor = (nc.NoSq * 1.15) * 68;
	//        //nc.PercentLabor = nc.AmountLabor / nc.AmountTotalClaim;
	//        //nc.AmountMaterial = (nc.NoSq * 1.15) * 107;
	//        //nc.PercentMaterial = nc.AmountMaterial / nc.AmountTotalClaim;
	//        //nc.AmountOverhead = nc.AmountTotalClaim * .1;
	//        //nc.PercentOverhead = nc.AmountOverhead / nc.AmountTotalClaim * 100;
	//        //nc.AmountCollected = nc.AmountSettlementCollected + nc.AmountSuppelementCollected + nc.AmountFirstCollected + AmountDeductibleCollected;
	//        //nc.PercentCollected = nc.AmountCollected / nc.AmountTotalClaim * 100;
	//        //nc.AmountSalesManager = nc.AmountSalesManagerPay(s.IsHouseDeal);
	//        //nc.PercentSalesManager = nc.PercentSalesManagerPay(s.IsHouseDeal) * 100;
	//        //nc.AmountReferral = nc.ReferralAmount(s.IsReferral);
	//        //if (nc.IsPaidOW == true)
	//        //    nc.AmountOtherwork = s.RCV - s.RoofAmount - s.Tax;
	//        //else nc.AmountOtherwork = 0;
	//        //if (nc.AmountOtherwork != 0)
	//        //    nc.PercentAmountOtherwork = nc.AmountOtherwork / nc.AmountTotalClaim * 100;
	//        //else nc.PercentAmountOtherwork = 0;
	//        //nc.TotalExpense = nc.AmountLabor + nc.AmountMaterial + nc.AmountOverhead + nc.AmountReferral + AmountOtherwork;
	//        //nc.PercentTotalExpense = (nc.TotalExpense / nc.AmountTotalClaim) * 100;
	//        //nc.Profit = nc.AmountCollected - nc.TotalExpense;
	//        //nc.ProfitPerSQ = nc.Profit / nc.NoSq;
	//        //nc.CostPerSQ = nc.TotalExpense / nc.NoSq;
	//        //nc.LastRemainingBalanceChanged = IsLastBalanceChanged(s.LastRemainingBalance);
	//        //nc.AmountSalesPerson = (nc.Profit * (s.SalesSplit * .01)) - nc.Draw;
	//        //nc.AmountMRN = nc.Profit - nc.AmountSalesPerson;
	//        //nc.MRNTotalO_U = nc.AmountMRN - nc.AmountSalesManager + nc.AmountOverhead;
	//        //nc.SalesPersonTotalO_U = nc.Profit * (s.SalesSplit * .01);
	//        //nc.ClaimAge = HowOldIsThisClaim();
	//        //nc.AmountOwed = nc.AmountTotalClaim - nc.AmountCollected;
	//        //nc.CustomerName = s.CustomerName;
	//        //nc.ClaimNumber = s.ClaimNumber;
	//        //nc.IsCollectedDed = s.IsCollectedDed;
	//        //nc.IsCollectedDep = s.IsCollectedDep;
	//        //nc.IsCollectedFirst = s.IsCollectedFirst;
	//        //nc.IsPaidCommissions = s.IsPaidCommissions;
	//        //nc.IsPaidOW = s.IsPaidOW;
	//        //nc.IsPaidRoof = s.IsPaidRoof;
	//        //nc.IsPaidMaterial = s.IsPaidMaterial;
	//        //nc.IsUpdated = s.IsUpdated;
	//        //nc.ScheduledCOCDate = s.ScheduledCOCDate;
	//        //nc.ScheduledRoofDate = s.ScheduledRoofDate;
	//        //nc.SettlementAmount = s.SettlementAmount;
	//        //nc.Comment = DisplayClaimsComments(nc.ClaimNumber, commentlist);
	//        //nc.ForgivenDeductible = IsDeductibleCollected(s.IsCollectedDed, s.Deductible);
	//        //nc.ActualProfit = nc.AmountCollected - nc.TotalExpense;
	//        //nc.MaterialAmount = nc.AmountMaterial;
	//        //nc.OWAmount = nc.AmountOtherwork;
	//        //nc.OWAmountPaid = s.OWAmountPaid;
	//        //nc.MaterialAmountPaid = s.MaterialAmountPaid;
	//        //nc.ProjectedProfit = s.RCV - nc.AmountLabor - nc.AmountMaterial - s.Tax - nc.AmountOverhead;
	//        //nc.RoofAmountPaid = s.RoofAmountPaid;
	//        //nc.AmountSettlement = s.SettlementAmount;
	//        //nc.AmountSettlementCollected = s.SettlementAmountCollected;//not true
	//        //nc.AmountSuppelementCollected = s.SupplementAmountCollected;
	//        //nc.AmountSupplement = nc.AmountSettlement - nc.AmountTotalClaim;
	//        //nc.ProjectedSalesProfit = nc.ProjectedProfit / 2;
	//        //nc.Salesperson = s.Salesperson;
	//        //nc.ProfitMargin = nc.AmountCollected / TotalExpense;
	//        //nc.ProjectedExpense = nc.NoSq * 200;
	//        //nc.ProjectedProfitMargin = nc.AmountTotalClaim / nc.ProjectedExpense;
	//        //if (nc.SettlementAmount > 0)
	//        //    nc.PercentSuppUp = nc.AmountTotalClaim / nc.SettlementAmount;
	//        //else nc.PercentSuppUp = 0;
	//        //nc.PercentMaterial = nc.TotalExpense / nc.MaterialAmount;
	//        //nc.PercentLabor = nc.TotalExpense / nc.AmountLabor;
	//        //nc.PercentOverhead = nc.AmountOverhead / nc.AmountTotalClaim * 100;
	//        //nc.AmountMRN = nc.AmountTotalClaim - nc.TotalExpense - nc.ProjectedSalesProfit;
	//        //nc.PercentFirst = nc.AmountFirst / nc.AmountTotalClaim * 100;
	//        //nc.PercentDep = nc.AmountDep / nc.AmountTotalClaim * 100;
	//        //nc.PercentDed = nc.AmountDed / nc.AmountTotalClaim * 100;
	//        //nc.AmountDepCollected = s.AmountDepCollected;
	//        return nc;
	//    }
	//    #endregion
	//}

	public class TransactionModel
	{
		public static TransactionModel T1;
		public static ObservableCollection<TransactionModel> T;
		public string ClaimNumber { get; set; }
		public int AccountTo { get; set; }
		public int AccountFrom { get; set; }
		public DateTime TransactionDate { get; set; }
		public string For { get; set; }
		public double AmountofTransaction { get; set; }

		public TransactionModel()
		{

		}

		public static TransactionModel getInstance()
		{
			if (T1 == null)
			{
				T1 = new TransactionModel();
			}

			return T1;
		}

		public static ObservableCollection<TransactionModel> tgetInstance()
		{
			if (T == null)
			{
				T = new ObservableCollection<TransactionModel>();
			}

			return T;
		}
	}

	public class RoofStatsModel
	{
		public static RoofStatsModel T1;
		public static ObservableCollection<RoofStatsModel> T;
		public ObservableCollection<RoofStatsModel> rsm = tgetInstance();

		public string ClaimNumber { get; set; }
		public string Salesperson { get; set; }
		public double NumberSquares { get; set; }
		public int ClaimAge { get; set; }
		public double MRNProfit { get; set; }
		public double SalesProfit { get; set; }
		public bool WasKnockedorReferred { get; set; }

		public RoofStatsModel()
		{

		}

		public static RoofStatsModel getInstance()
		{
			if (T1 == null)
			{
				T1 = new RoofStatsModel();
			}

			return T1;
		}

		public static ObservableCollection<RoofStatsModel> tgetInstance()
		{
			if (T == null)
			{
				T = new ObservableCollection<RoofStatsModel>();
			}

			return T;

		}
	}
}
