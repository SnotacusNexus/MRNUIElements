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
using System.Net;
using System.Collections.ObjectModel;
using MRNNexus_Model;
using MRNUIElements.Controllers.Collection;
using static MRNUIElements.PaymentEntryPage;
using static MRNUIElements.InvoicePage;
using System.Drawing;
using System.Threading;
using MRNUIElements.ClaimDataService;
using static MRNUIElements.RoofMeasurmentsPage;
using System.Text.RegularExpressions;
using static MRNUIElements.MainWindow;
using static Syncfusion.Windows.Controls.Notification.SfBusyIndicator;
using MRNUIElements.Controllers;
using static MRNUIElements.Controllers.ClaimView;
using System.Windows.Forms;
using System.IO;
using static MRNUIElements.Utilities;
using static MRNUIElements.Controllers.Inspection;
using static MRNUIElements.Controllers.ClaimValues;
namespace MRNUIElements.Controllers
{



	/// <summary>
	/// Interaction logic for ClaimView.xaml
	/// </summary>
	public partial class ClaimView : Page
	{
		//static ServiceLayer s = ServiceLayer.getInstance();

		static protected ObservableCollection<DTO_Scope> claimScopes = new ObservableCollection<DTO_Scope>();
		public static List<string> OC;
		public static List<string> Certainteed = new List<string>();
		static ServiceLayer s1 = ServiceLayer.getInstance();
		static GetClaimsPage G = GetClaimsPage.getInstanceH();
		public bool supplementnumberexists = false;
		ObservableCollection<DTO_InsuranceCompany> insco = new ObservableCollection<DTO_InsuranceCompany>();
		//  ObservableCollection<DTO_InsuranceCompany> INSCO = new ObservableCollection<DTO_InsuranceCompany>();
		ObservableCollection<DTO_OrderItem> OrderItemCollection = new ObservableCollection<DTO_OrderItem>();

		//	public DTO_Claim claim { get; set; }
		//	public static DTO_Claim _Claim;
		private static DTO_Claim _claim;

		static DTO_Claim getInstanceClaim()
		{
			if (_claim == null)
				_claim = new DTO_Claim();
			return _claim;
		}
		public static DTO_Claim _Claim
		{
			get { return getInstanceClaim(); }
			set { _claim = value; }
		}
		private static ObservableCollection<string> _inspectionImageList;
		public static ObservableCollection<string> InspectionImageList
		{
			get { return getInstanceImageList(); }
			set { _inspectionImageList = value; }
		}
		static ClaimValues cvs = ClaimValues.getInstanceClaimValues();
		#region Create New Instance Of DTO's needed
		DTO_Lead lead = new DTO_Lead();
		DTO_Address address = new DTO_Address();
		DTO_Customer customer = new DTO_Customer();
		DTO_Inspection inspection = new DTO_Inspection();
		DTO_ClaimStatus claimStatus = new DTO_ClaimStatus();
		DTO_NewRoof newRoof = new DTO_NewRoof();
		DTO_Order order = new DTO_Order();
		DTO_OrderItem orderItem = new DTO_OrderItem();
		DTO_Scope scope = new DTO_Scope();
		DTO_Referrer referral = new DTO_Referrer();
		List<DTO_Plane> Planes = new List<DTO_Plane>();
		public DTO_Inspection Inspection { get; set; }
		public DTO_Plane Plane { get; set; }
		public List<DTO_Scope> ScopesList { get; set; }
		static Frame f = GetClaimsPage.getInstanceg();
		public static List<string> InspectionCheckBoxList;
		public static PaymentEntryPage P;
		//public static DTO_Claim Claim { get; set; }
		//public DateTime PaymentDate { get; set; }
		public static int PaymentDescriptionID { get; set; }
		public static string PaymentDescription { get; set; }
		public static double Amount { get; set; }
		private static List<DTO_LU_InvoiceType> _invoiceTypes = ClaimValues.getInstanceClaimInvoiceTypes();
		public static List<DTO_LU_InvoiceType> InvoiceTypes { get { return _invoiceTypes; } set { _invoiceTypes = value; } }
		public static int DocTypeID { get; set; }
		protected int ClaimStatusType = 0;
		protected string FullFilePath;
		public System.Drawing.Image bitmap;
		//static DTO_Payment payment = new DTO_Payment();
		private static DateTime _PaymentDate;
		public static DateTime PaymentDate
		{
			get { return _PaymentDate; }
			set { _PaymentDate = value; }
		}

		public List<DTO_LU_PaymentDescription> PDList = new List<DTO_LU_PaymentDescription>();
		public List<DTO_Payment> Payments = new List<DTO_Payment>();
		ClaimPickerPopUp cppu = new ClaimPickerPopUp();
		protected bool paymentExist = true;
		public List<DTO_LU_Product> AllProducts { get; set; }
		public List<DTO_Scope> claimscopelist = new List<DTO_Scope>();

		#endregion
		public Syncfusion.Windows.Controls.Notification.SfBusyIndicator _busyIndicator { get; set; }
		public double RidgeMeasurement { get; set; }
		public double HipMeasurement { get; set; }
		public double ValleyMeasurement { get; set; }
		public double RakeMeasurement { get; set; }
		public double EaveMeasurement { get; set; }
		public double StarterMeasurement { get; set; }
		public double TotalSQFTOFF { get; set; }
		public string Installer { get; set; }
		public string Supplier { get; set; }
		public string Supervisor { get; set; }
		public string Salesperson { get; set; }
		public bool HasMeasurements { get; set; }
		public int PredPitch { get; set; }
		public string googleAddress { get; set; }
		string startsubstring = "Lengths, Areas and Pitches";
		//        List<string> Lststg = new List<string>();
		string latitude = "";
		string longitude = "Longitude = ";
		string PropertyAddressBlockStart = "Online map of property";
		//    string PropertyAddressBlockEnd = "Directions from MRN Homes of Ga. to this property";
		const int ESTIMATE = 6;
		const int OLDSCOPE = 7;
		const int NEWSCOPE = 10;
		//public int scopetype;

		public static int scopeType { get; set; }
		public int TypeScope { get; set; }

		public double acv;
		public double depreciation;
		public double roof;
		public int ScopeID;
		public bool bab = true;
		private double temp = 0;
		static public string selTxt { get; set; }
		protected List<bool> ScopeExist = new List<bool>();
		static public ObservableCollection<DTO_Invoice> InvoiceCollection = new ObservableCollection<DTO_Invoice>();
		List<DTO_ClaimVendor> ClaimVendorList = new List<DTO_ClaimVendor>();
		static ObservableCollection<string> getInstanceImageList()
		{
			if (_inspectionImageList == null)
				_inspectionImageList = new ObservableCollection<string>();
			return _inspectionImageList;
		}
		public ClaimView(DTO_Claim claim)
		{

			InitializeComponent();
			if (claim != null)
				_Claim = claim;
			else _Claim = getInstanceClaim();


			InitPayment();
			Getem();
			//Connects to a URL and attempts to download the file



			InitialDBFunctions();




			//	ShowsAvailableScopes(ScopesList);
			ScopeTypeTextBlockE.Text = "MRN Estimate";
			ScopeTypeTextBlockOS.Text = "Original Scope";
			ScopeTypeTextBlockNS.Text = "Newest Scope";

			GetScopes(); //Find all scopes for claim and store them in order for structured retrieval
			if (_Claim != null)
			{
				claimIDTextBoxE.Text = claimIDTextBoxOS.Text = claimIDTextBoxNS.Text = _Claim.MRNNumber;
			}
			populateScopeData();

			OCShingles();



		}//end function







		void EnableAddButton()
		{
			if (this.gutterTextBoxE != null && this.exteriorTextBoxE != null && this.deductibleTextBoxE != null && this.claimIDTextBoxE != null && this.ACVE != null && this.DepreciationE != null && this.interiorTextBoxE != null && this.oandPTextBoxE != null && this.RoofE != null && this.taxTextBoxE != null && this.totalTextBoxE != null && !SubmitScopeEntryE.IsEnabled)
				SubmitScopeEntryE.IsEnabled = true;
			else
				SubmitScopeEntryE.IsEnabled = true;
			if (this.gutterTextBoxOS != null && this.exteriorTextBoxOS != null && this.deductibleTextBoxOS != null && this.claimIDTextBoxOS != null && this.ACVOS != null && this.DepreciationOS != null && this.interiorTextBoxOS != null && this.oandPTextBoxOS != null && this.RoofOS != null && this.taxTextBoxOS != null && this.totalTextBoxOS != null && !SubmitScopeEntryOS.IsEnabled)
				SubmitScopeEntryOS.IsEnabled = true;
			else
				SubmitScopeEntryOS.IsEnabled = true;
			if (this.gutterTextBoxNS != null && this.exteriorTextBoxNS != null && this.deductibleTextBoxNS != null && this.claimIDTextBoxNS != null && this.ACVNS != null && this.DepreciationNS != null && this.interiorTextBoxNS != null && this.oandPTextBoxNS != null && this.RoofNS != null && this.taxTextBoxNS != null && this.totalTextBoxNS != null && !SubmitScopeEntryNS.IsEnabled)
				SubmitScopeEntryNS.IsEnabled = true;
			else
				SubmitScopeEntryNS.IsEnabled = true;


		}


		async private void SubmitScopeEntry_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBoxResult.Yes == System.Windows.MessageBox.Show("Are the figures correct?", "Confirm addition of information to claim", MessageBoxButton.YesNo, MessageBoxImage.Question))
			{
				await AddScope(scope);

			}
		}







		private void CancelScopeEntry_Click(object sender, RoutedEventArgs e)
		{

			EnableAddButton();
		}


		private void totalTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			EnableAddButton();
		}


		private void exteriorTextBox_LostFocus(object sender, RoutedEventArgs e)
		{



			EnableAddButton();



		}


		private void gutterTextBox_LostFocus(object sender, RoutedEventArgs e)
		{

			EnableAddButton();

		}





		private void Roof_LostFocus(object sender, RoutedEventArgs e)
		{
			EnableAddButton();
		}


		virtual public double Calculate(decimal interior = 0, decimal exterior = 0, decimal gutters = 0, decimal roof = 0, decimal total = 0, decimal oandp = 0, decimal tax = 0, decimal deductible = 0, bool acv = true)
		{

			double a, b, c, d, e, f, g, h;

			a = (double)interior;

			b = (double)exterior;

			c = (double)gutters;

			d = (double)roof;

			e = (double)total;

			f = (double)oandp;

			g = (double)tax;

			h = (double)deductible;

			if (acv)

				return (double)total - (double)interior - (double)exterior - (double)gutters - (double)roof - (double)oandp - (double)tax - (double)deductible;


			return (double)total - (double)interior - (double)exterior - (double)gutters - (double)roof - (double)tax;

		}

		private async Task<List<DTO_Scope>> GetScopes()
		{
			if (Scopes == null)
				ClaimView.Scopes = GetClaimScopes().Where(x => x.ClaimID == _Claim.ClaimID).ToList();

			return Scopes.Where(x => x.ClaimID == _Claim.ClaimID).ToList();

		}
		List<DTO_Scope> GetClaimScopes(/*DTO_Claim claim,*/)
		{
			List<DTO_Scope> claimScopes = new List<DTO_Scope>();
			for (int i = 0; i < 3; i++)
			{

				Scopes.Add(FetchScope(i));
			}
			return claimScopes;

		}
		DTO_Scope FetchScope(int scopeType)
		{
			if (ScopeExists(ClaimView.Scopes.Where(x => x.ClaimID == _Claim.ClaimID).ToList(), scopeType))
			{
				return Scopes.Where(x => x.ScopeTypeID == scopeType).ToList()[0];
			}
			else
			{
				return new DTO_Scope { ScopeTypeID = scopeType };
			}
		}
		bool ScopeExists(List<DTO_Scope> Scopes, int scopeType)
		{
			return ClaimView.Scopes.Exists(x => x.ScopeTypeID == scopeType);
		}

		async Task<bool> populateScopeData()
		{
			try
			{
				ClaimView.Scopes = await GetScopes();

				for (int i = 0; i < 3; i++)
				{
					if (Scopes[i].ScopeTypeID == 1)
					{


						deductibleTextBoxE.Value = (decimal)Scopes[i].Deductible;
						oandPTextBoxE.Value = (decimal)Scopes[i].OandP;
						interiorTextBoxE.Value = (decimal)Scopes[i].Interior;
						gutterTextBoxE.Value = (decimal)Scopes[i].Gutter;
						totalTextBoxE.Value = (decimal)Scopes[i].Total;
						exteriorTextBoxE.Value = (decimal)Scopes[i].Exterior;
						taxTextBoxE.Value = (decimal)Scopes[i].Tax;
						/*ACVE.Value = (decimal)Scopes[i];*/
						RoofE.Value = (decimal)Scopes[i].RoofAmount;
						DepreciationE.Value = (decimal)Scopes[i].Total - (decimal)Scopes[i].Deductible - ACVE.Value;
					}
					else if (Scopes[i].ScopeTypeID == 2)
					{
						deductibleTextBoxOS.Value = (decimal)Scopes[i].Deductible;
						oandPTextBoxOS.Value = (decimal)Scopes[i].OandP;
						interiorTextBoxOS.Value = (decimal)Scopes[i].Interior;
						gutterTextBoxOS.Value = (decimal)Scopes[i].Gutter;
						totalTextBoxOS.Value = (decimal)Scopes[i].Total;
						exteriorTextBoxOS.Value = (decimal)Scopes[i].Exterior;
						taxTextBoxOS.Value = (decimal)Scopes[i].Tax;
						/*ACVOS.Value = (decimal)Scopes[i].Deductible;*/
						RoofOS.Value = (decimal)Scopes[i].RoofAmount;
						DepreciationOS.Value = (decimal)Scopes[i].Total - (decimal)Scopes[i].Deductible - ACVOS.Value;
					}
					else if (Scopes[i].ScopeTypeID == 3)
						deductibleTextBoxNS.Value = (decimal)Scopes[i].Deductible;
					oandPTextBoxNS.Value = (decimal)Scopes[i].OandP;
					interiorTextBoxNS.Value = (decimal)Scopes[i].Interior;
					gutterTextBoxNS.Value = (decimal)Scopes[i].Gutter;
					totalTextBoxNS.Value = (decimal)Scopes[i].Total;
					exteriorTextBoxNS.Value = (decimal)Scopes[i].Exterior;
					taxTextBoxNS.Value = (decimal)Scopes[i].Tax;
					/*ACVNS.Value = (decimal)Scopes[i].Deductible;*/
					RoofNS.Value = (decimal)Scopes[i].RoofAmount;
					DepreciationNS.Value = (decimal)Scopes[i].Total - (decimal)Scopes[i].Deductible - ACVNS.Value;
				}
				return true;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				return false;
			}
		}
		private void ClearData(string s)
		{

			switch (s)
			{
				case "E":
					{
						deductibleTextBoxE.Value = 0;
						oandPTextBoxE.Value = 0;
						interiorTextBoxE.Value = 0;
						gutterTextBoxE.Value = 0;
						totalTextBoxE.Value = 0;
						exteriorTextBoxE.Value = 0;
						taxTextBoxE.Value = 0;
						ACVE.Value = 0;
						RoofE.Value = 0;
						DepreciationE.Value = 0;
						SubmitScopeEntryE.IsEnabled = false;
						break;
					}
				case "OS":
					{
						deductibleTextBoxOS.Value = 0;
						oandPTextBoxOS.Value = 0;
						interiorTextBoxOS.Value = 0;
						gutterTextBoxOS.Value = 0;
						totalTextBoxOS.Value = 0;
						exteriorTextBoxOS.Value = 0;
						taxTextBoxOS.Value = 0;
						ACVOS.Value = 0;
						RoofOS.Value = 0;
						DepreciationOS.Value = 0;
						SubmitScopeEntryOS.IsEnabled = false;

						break;
					}
				case "NS":
					{
						deductibleTextBoxNS.Value = 0;
						oandPTextBoxNS.Value = 0;
						interiorTextBoxNS.Value = 0;
						gutterTextBoxNS.Value = 0;
						totalTextBoxNS.Value = 0;
						exteriorTextBoxNS.Value = 0;
						taxTextBoxNS.Value = 0;
						ACVNS.Value = 0;
						RoofNS.Value = 0;
						DepreciationNS.Value = 0;
						SubmitScopeEntryNS.IsEnabled = false;

						break;
					}

			}
		}
		private async Task<bool> AddScope(/*DTO_Claim claim,*/ DTO_Scope _scope)
		/*	private async Task<bool> AddScope(DTO_Claim claim, int typescope)*/
		{


			int claimstatustypeid = 0;
			switch (scope.ScopeTypeID)
			{
				case 1:
					{
						claimstatustypeid = 4;          //estimate 4
						await s1.AddScope(new DTO_Scope
						{
							ClaimID = _Claim.ClaimID,
							Deductible = (double)deductibleTextBoxE.Value,
							Exterior = (double)exteriorTextBoxE.Value,
							Interior = (double)interiorTextBoxE.Value,
							Gutter = (double)gutterTextBoxE.Value,
							ScopeTypeID = TypeScope,
							Tax = (double)taxTextBoxE.Value,
							OandP = (double)oandPTextBoxE.Value,
							Total = (double)totalTextBoxE.Value,
							RoofAmount = (double)RoofE.Value
						});
						break;
					}
				case 2:
					{
						claimstatustypeid = 6;            //originalscope 6
						await s1.AddScope(new DTO_Scope
						{
							ClaimID = _Claim.ClaimID,
							Deductible = (double)deductibleTextBoxOS.Value,
							Exterior = (double)exteriorTextBoxOS.Value,
							Interior = (double)interiorTextBoxOS.Value,
							Gutter = (double)gutterTextBoxOS.Value,
							ScopeTypeID = TypeScope,
							Tax = (double)taxTextBoxOS.Value,
							OandP = (double)oandPTextBoxOS.Value,
							Total = (double)totalTextBoxOS.Value,
							RoofAmount = (double)RoofOS.Value
						});
						break;
					}
				case 3:
					{
						claimstatustypeid = 10;            //newscope(aka) supplementsettled 10
						await s1.AddScope(new DTO_Scope
						{
							ClaimID = _Claim.ClaimID,
							Deductible = (double)deductibleTextBoxNS.Value,
							Exterior = (double)exteriorTextBoxNS.Value,
							Interior = (double)interiorTextBoxNS.Value,
							Gutter = (double)gutterTextBoxNS.Value,
							ScopeTypeID = TypeScope,
							Tax = (double)taxTextBoxNS.Value,
							OandP = (double)oandPTextBoxNS.Value,
							Total = (double)totalTextBoxNS.Value,
							RoofAmount = (double)RoofNS.Value
						});
						break;
					}
			}



			if (s1.Scope.Message == null)
			{
				await s1.AddClaimStatus(new DTO_ClaimStatus
				{
					ClaimID = _Claim.ClaimID,
					ClaimStatusTypeID = claimstatustypeid,
					ClaimStatusDate = DateTime.Today

				});




				if (s1.ClaimStatus.Message == null)
				{
					System.Windows.MessageBox.Show("Everything Uploaded Successfully");
				}
				else
				{
					System.Windows.MessageBox.Show(s1.ClaimStatus.Message);
				}


			}
			else
			{
				System.Windows.MessageBox.Show(s1.Scope.Message);
			}


			return true;
		}





		////async public void Getem()
		////{
		////	try
		////	{


		////		await s1.GetAllReferrers();
		////		await s1.GetAllInsuranceCompanies();
		////		foreach (DTO_InsuranceCompany item in s1.InsuranceCompaniesList)
		////		{
		////			insco.Add(item);

		////		}
		////		InsuranceLU.ItemsSource = insco;
		////		InspectionImages.ItemsSource = new ObservableCollection<string>() { "Item1", "Item2", "Item3", "Item4", "Item5", "Item6", "Item7", "Item8", "Item9" };

		////	}
		////	catch (Exception ex)
		////	{

		////		System.Windows.Forms.MessageBox.Show(ex.ToString());
		////	}
		////}
		//private void Customer_MouseEnter(object sender, MouseEventArgs e)
		//{
		//	((TextBlock)sender).Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
		//}


		//private void Customer_MouseLeave(object sender, MouseEventArgs e)
		//{
		//	((TextBlock)sender).Background = null;
		//}
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



		//private void Button_Click(object sender, RoutedEventArgs e)
		//{
		//	AddClaim();

		//}
		#endregion
		private void ClaimFileFolder_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
		private void Cust_Address_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void GetMapView(string streetaddress, string zip)
		{
			buildMapLink(streetaddress, zip);
		}

		string buildMapLink(string street, string zip)
		{
			var csz = new AddressZipcodeValidation();
			csz.CityStateLookupRequest(zip);

			// "https://www.google.com/maps/place/1030+Gray+Horse+Rd,+Greensboro,+GA+30642/@33.505144,-83.1672317,17z/data=!4m5!3m4!1s0x88f6f3e28236b395:0x6008d1d0c9a8c0ee!8m2!3d33.505144!4d-83.165043" //
			var a = new StringBuilder();
			var b = new StringBuilder();
			if (a.Length > 0)
				a.Clear();
			a.Append("https://www.google.com/maps/place/");//start string
			a.Append("," + street.Replace(' ', '+') + ",");
			a.Append("+" + csz.City + ",");
			a.Append("+" + csz.ST + "+" + zip + "/");




			a.Append("/data=!3m1!1e3"); //end string

			Uri myUri = new Uri(a.ToString());
			HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(a.ToString()));
			HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
			GoogleView.Navigate(new Uri(WebRequest.Create(myHttpWebResponse.ResponseUri).ToString()));
			myHttpWebResponse.Close();

			return a.ToString();
		}

		private void Cust_Address_LostFocus(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrEmpty(Cust_Zipcode.Text) && !string.IsNullOrEmpty(Cust_Address.Text))
			{
				GetMapView(Cust_Address.Text, Cust_Zipcode.Text);

			}
		}

		async public void Getem()
		{
			try
			{

				await s1.GetRidgeMaterialTypes();
				await s1.GetShingleTypes();
				await s1.GetAllReferrers();
				await s1.GetAllInsuranceCompanies();
				foreach (DTO_InsuranceCompany item in s1.InsuranceCompaniesList)
				{
					insco.Add(item);

				}
				InsuranceLU.ItemsSource = insco;
				ridgeMaterialTypeIDTextBox.ItemsSource = s1.RidgeMaterialTypes;
				shingleTypeIDTextBox.ItemsSource = s1.ShingleTypes;
			}
			catch (Exception ex)
			{

				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
		}
		private void Customer_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			((TextBlock)sender).Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
		}


		private void Customer_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			((TextBlock)sender).Background = null;
		}
		#region Navigation



		private void Button_Click(object sender, RoutedEventArgs e)
		{
			AddClaim();

		}
		#endregion
		#region Add a claim
		private async void scopeaReturn_Return(object sender, ReturnEventArgs<Object> e)
		{//Display the Items selected
			scope = (DTO_Scope)e.Result;
			if (scope != null)
				await s1.AddScope(scope);
		}

		private async void AddClaimCustomer_Return(object sender, ReturnEventArgs<Object> e)
		{//Display the Items selected
			customer = (DTO_Customer)e.Result;
			if (customer != null)
				await s1.AddCustomer(customer);
		}
		private async void AddPropertyAddress_Return(object sender, ReturnEventArgs<Object> e)
		{//Display the Items selected
			address = (DTO_Address)e.Result;
			if (address != null)
				await s1.AddAddress(address);
		}

		private async void AddLeadInformation_Return(object sender, ReturnEventArgs<Object> e)
		{//Display the Items selected
			DTO_Referrer referrer = (DTO_Referrer)e.Result;
			if (referrer != null)
				await s1.AddReferrer(referrer);
		}
		private async void New_Inspection_Page_Return(object sender, ReturnEventArgs<Object> e)
		{//Display the Items selected
			Inspection = (DTO_Inspection)e.Result;
			if (Inspection != null)
				await s1.AddInspection(Inspection);
		}
		async public void AddClaim()
		{

			var claim = new DTO_Claim();


			#region Populate Customer
			//

			//Create instance of PageFunction
			AddClaimCustomer AddClaimCustomer = new AddClaimCustomer();
			//Attach the Return EventHandler to Handle ReturnEventAgrs passed from PageFunction            
			AddClaimCustomer.Return += new ReturnEventHandler<object>(AddClaimCustomer_Return);
			//Navigate to Page Function
			NavigationService.Navigate(AddClaimCustomer);

			//working code
			/*customer.FirstName = Cust_FirstName.Text;
			customer.MiddleName = Cust_MiddleName.Text;
			customer.LastName = Cust_LastName.Text;
			customer.Suffix = Cust_Suffix.Text;
			customer.PrimaryNumber = Cust_Primary_Phone.Text;
			customer.SecondaryNumber = Cust_Secondary_Phone.Text;
			customer.Email = Cust_Email_Address.Text;
			customer.MailPromos = false;
			*/

			#endregion
			#region Populate Address

			AddPropertyAddress AddPropertyAddress = new AddPropertyAddress();
			//Attach the Return EventHandler to Handle ReturnEventAgrs passed from PageFunction            
			AddPropertyAddress.Return += new ReturnEventHandler<object>(AddPropertyAddress_Return);
			//Navigate to Page Function
			NavigationService.Navigate(AddPropertyAddress);
			//address.Address = Cust_Address.Text;
			//address.Zip = Cust_Zipcode.Text;
			#endregion
			#region Populate Referrer
			int referrerID = 0;
			AddLeadInformation AddLeadInformation = new AddLeadInformation();
			//Attach the Return EventHandler to Handle ReturnEventAgrs passed from PageFunction            
			AddLeadInformation.Return += new ReturnEventHandler<object>(AddLeadInformation_Return);
			//Navigate to Page Function
			NavigationService.Navigate(AddLeadInformation);
			//referral.FirstName = Lead_FirstName.Text;
			//referral.Zip = Lead_Zipcode.Text;
			//referral.LastName = Lead_LastName.Text;
			//referral.Suffix = Lead_Suffix.Text;
			//referral.CellPhone = Lead_Primary_Phone.Text;
			//referral.MailingAddress = Lead_Address.Text;
			//referral.Email = Lead_Email_Address.Text;
			//CheckIfTheyExist if so get the referralID

			if (s1.ReferrersList.Count > 0)
				foreach (DTO_Referrer r in s1.ReferrersList)
				{
					if (r.Equals(referral))

						referrerID = r.ReferrerID;
					break;
				}
			try
			{

				if (referrerID == 0)
				{
					await s1.AddReferrer(referral);
				}
				else referrerID = s1.Referrer.ReferrerID;
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
			lead.SalesPersonID = s1.LoggedInEmployee.EmployeeID;
			lead.KnockerResponseID = null;
			lead.LeadDate = ContractDate.SelectedDate.Value;
			lead.LeadTypeID = 1;
			#endregion
			#region Claim Addition Underway
			try
			{
				await s1.AddCustomer(customer);
				if (s1.Cust.Message == null)
				{
					lead.CustomerID = s1.Cust.CustomerID;
					address.CustomerID = s1.Cust.CustomerID;
					claim.CustomerID = s1.Cust.CustomerID;
					System.Windows.Forms.MessageBox.Show(s1.Cust.CustomerID.ToString());
				}

				else System.Windows.Forms.MessageBox.Show(s1.Cust.Message.ToString());

				#endregion
				#region Add Address
				await s1.AddAddress(address);


				if (s1.Address1.Message == null)
				{
					lead.AddressID = s1.Address1.AddressID;
					System.Windows.Forms.MessageBox.Show(s1.Address1.AddressID.ToString());
				}
				else
					System.Windows.Forms.MessageBox.Show(s1.Address1.Message.ToString());
				await s1.AddLead(lead);
				#endregion
				#region AddLead
				if (s1.Lead.Message == null)
				{
					claim.LeadID = s1.Lead.LeadID;
					System.Windows.Forms.MessageBox.Show(s1.Lead.LeadID.ToString());
				}
				else
					System.Windows.Forms.MessageBox.Show(s1.Lead.Message.ToString());

				#endregion
				#region Popuate Claim
				claim.MRNNumber = "MRN-" + s1.Lead.SalesPersonID + "-" + s1.Cust.CustomerID;
				claim.PropertyID = s1.Address1.AddressID;
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
				await s1.AddClaim(claim);
				if (s1.Claim.Message == null)
				{
					claim.LeadID = s1.Lead.LeadID;
					System.Windows.Forms.MessageBox.Show("Congratulations You Have Successfully became a statistic! Your Claim and Experience is now associated with " + s1.Claim.MRNNumber.ToString());
				}
				else
					System.Windows.Forms.MessageBox.Show(s1.Lead.Message.ToString());
				#endregion
				#endregion
				//TODO: REMOVE DUMMY DATA AND SCRIPT IN ACTUAL GATHERING CODE
				#region	Dummy Data and Fixed Variable Must Remove Before Production
				//Create instance of PageFunction
				PageFunction scopea = new PageFunction();
				//Attach the Return EventHandler to Handle ReturnEventAgrs passed from PageFunction  
				try
				{
					if (Inspection != null)
						await s1.AddInspection(Inspection);



				}
				catch (Exception ex)
				{
					#region Populate Address

					New_Inspection_Page New_Inspection_Page = new New_Inspection_Page();
					//Attach the Return EventHandler to Handle ReturnEventAgrs passed from PageFunction            
					New_Inspection_Page.Return += new ReturnEventHandler<object>(New_Inspection_Page_Return);
					//Navigate to Page Function
					NavigationService.Navigate(New_Inspection_Page);
					//address.Address = Cust_Address.Text;
					//address.Zip = Cust_Zipcode.Text;
					#endregion

				}
				finally
				{
					scopea.Return += new ReturnEventHandler<object>(scopeaReturn_Return);
					//Navigate to Page Function
					NavigationService.Navigate(scopea);
					//bool hasscope = true;
					////HACK


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
				}

				#endregion
				// claimStatus


				//scope?

				// inspection

				//TODO: REMOVE DUMMY DATA AND SCRIPT IN ACTUAL GATHERING CODE
				//order?
				#region	Dummy Data and Fixed Variable Must Remove Before Production
				bool hasorder = true;
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
						await s1.AddOrder(order);
						List<DTO_OrderItem> OrderItems = new List<DTO_OrderItem>();
						double a = 0, b = 0, c = 0, d = 0, e = 0, f = 0, g = 0, h = 0, i = 0, j = 0, k = 0, l = 0, m = 0;
						double.TryParse(OrderSqShingle.Text, out a);
						double.TryParse(OrderHipandRidge.Text, out b);
						double.TryParse(Order3PipeBoot.Text, out c);
						double.TryParse(Order4PipeBoot.Text, out d);
						double.TryParse(OrderOSB.Text, out e);
						double.TryParse(OrderButtonCaps.Text, out f);
						double.TryParse(OrderRoofNails.Text, out g);
						double.TryParse(OrderStarter.Text, out h);
						double.TryParse(OrderUnderlayment.Text, out i);
						double.TryParse(OrderPaint.Text, out j);
						double.TryParse(OrderCaulk.Text, out k);
						double.TryParse(OrderDripEdge.Text, out l);
						double.TryParse(OrderIceWater.Text, out m);
						//	double.TryParse(OrderPaint.Text, out n);
						OrderItems.Add(new DTO_OrderItem
						{
							OrderID = order.OrderID,
							ProductID = 34,
							Quantity = (int)a * 3
						});//Shingles
						OrderItems.Add(new DTO_OrderItem
						{
							OrderID = order.OrderID,
							ProductID = 52,
							Quantity = (int)b
						});//Hip Ridge
						OrderItems.Add(new DTO_OrderItem
						{
							OrderID = order.OrderID,
							ProductID = 53,
							Quantity = (int)c
						});//3/1pipeboot
						OrderItems.Add(new DTO_OrderItem
						{
							OrderID = order.OrderID,
							ProductID = 54,
							Quantity = (int)d
						});//4PipeBoot
						OrderItems.Add(new DTO_OrderItem
						{
							OrderID = order.OrderID,
							ProductID = 55,
							Quantity = (int)e
						});//OSB
						OrderItems.Add(new DTO_OrderItem
						{
							OrderID = order.OrderID,
							ProductID = 56,
							Quantity = (int)f
						});//PlasticCapsBucket
						OrderItems.Add(new DTO_OrderItem
						{
							OrderID = order.OrderID,
							ProductID = 57,
							Quantity = (int)g
						});//CoilNails
						OrderItems.Add(new DTO_OrderItem
						{
							OrderID = order.OrderID,
							ProductID = 59,
							Quantity = (int)h
						});//ProStart
						OrderItems.Add(new DTO_OrderItem
						{
							OrderID = order.OrderID,
							ProductID = 60,
							Quantity = (int)i
						});//DeckDefense
						OrderItems.Add(new DTO_OrderItem
						{
							OrderID = order.OrderID,
							ProductID = 62,
							Quantity = (int)j
						});//CanPaint
						OrderItems.Add(new DTO_OrderItem
						{
							OrderID = order.OrderID,
							ProductID = 63,
							Quantity = (int)k
						});//TubeCaulk
						OrderItems.Add(new DTO_OrderItem
						{
							OrderID = order.OrderID,
							ProductID = 65,
							Quantity = (int)l
						});//WhiteDripEdge
						OrderItems.Add(new DTO_OrderItem
						{
							OrderID = order.OrderID,
							ProductID = 72,
							Quantity = (int)m
						});//IceAndWater

						foreach (var z in OrderItems)
							await s1.AddOrderItem(z);


					}
					catch (Exception ex)
					{
					}

				}



				#endregion
				#region ROOF ORDER
				ObservableCollection<DTO_OrderItem> orderitems = new ObservableCollection<DTO_OrderItem>();


				orderItem.OrderID = s1.Order.OrderID;
				orderItem.ProductID = 1;
				orderItem.Quantity = 99;



				//orderitems?









				bool AddItemToOrder(DTO_Order Order, DTO_OrderItem OrderItem, double Quantity, int sequence)
				{



					return true;


				}
			}


			catch (Exception ex)
			{

			}

			#endregion


		}
		#region DisplayOrder
		//void DisplayOrder() {
		//	if (ClaimView.ClaimOrder != null)
		//	{

		//		ScheduledDeliveryDate.Text = ClaimOrder.DateDropped.ToLongDateString();
		//		InstallDate.Text = ClaimOrder.ScheduledInstallation.ToLongDateString();
		//		//order.VendorID = 7;
		//		try
		//		{

		//			OrderSqShingle.Text=ClaimO
		//				ProductID = 34,
		//				Quantity = (int)a * 3

		//			OrderItems.Add(new DTO_OrderItem
		//			{
		//				OrderID = order.OrderID,
		//				ProductID = 52,
		//				Quantity = (int)b
		//			});//Hip Ridge
		//			OrderItems.Add(new DTO_OrderItem
		//			{
		//				OrderID = order.OrderID,
		//				ProductID = 53,
		//				Quantity = (int)c
		//			});//3/1pipeboot
		//			OrderItems.Add(new DTO_OrderItem
		//			{
		//				OrderID = order.OrderID,
		//				ProductID = 54,
		//				Quantity = (int)d
		//			});//4PipeBoot
		//			OrderItems.Add(new DTO_OrderItem
		//			{
		//				OrderID = order.OrderID,
		//				ProductID = 55,
		//				Quantity = (int)e
		//			});//OSB
		//			OrderItems.Add(new DTO_OrderItem
		//			{
		//				OrderID = order.OrderID,
		//				ProductID = 56,
		//				Quantity = (int)f
		//			});//PlasticCapsBucket
		//			OrderItems.Add(new DTO_OrderItem
		//			{
		//				OrderID = order.OrderID,
		//				ProductID = 57,
		//				Quantity = (int)g
		//			});//CoilNails
		//			OrderItems.Add(new DTO_OrderItem
		//			{
		//				OrderID = order.OrderID,
		//				ProductID = 59,
		//				Quantity = (int)h
		//			});//ProStart
		//			OrderItems.Add(new DTO_OrderItem
		//			{
		//				OrderID = order.OrderID,
		//				ProductID = 60,
		//				Quantity = (int)i
		//			});//DeckDefense
		//			OrderItems.Add(new DTO_OrderItem
		//			{
		//				OrderID = order.OrderID,
		//				ProductID = 62,
		//				Quantity = (int)j
		//			});//CanPaint
		//			OrderItems.Add(new DTO_OrderItem
		//			{
		//				OrderID = order.OrderID,
		//				ProductID = 63,
		//				Quantity = (int)k
		//			});//TubeCaulk
		//			OrderItems.Add(new DTO_OrderItem
		//			{
		//				OrderID = order.OrderID,
		//				ProductID = 65,
		//				Quantity = (int)l
		//			});//WhiteDripEdge
		//			OrderItems.Add(new DTO_OrderItem
		//			{
		//				OrderID = order.OrderID,
		//				ProductID = 72,
		//				Quantity = (int)m
		//			});//IceAndWater




		//		}
		//		catch (Exception ex)
		//		{
		//		}

		//	}


		//}
		#endregion

		#region ADD Order
		async void AddOrder(DTO_Order order, bool hasorder = true)
		{
			if (hasorder)
			{
				order.ClaimID = _Claim.ClaimID;
				order.DateDropped = DateTime.Today.Date;
				order.DateOrdered = DateTime.Today.Subtract(TimeSpan.FromDays(1));
				order.ScheduledInstallation = DateTime.Today.AddDays(1);
				order.VendorID = 7;
				try
				{
					await s1.AddOrder(order);
					List<DTO_OrderItem> OrderItems = new List<DTO_OrderItem>();
					double a = 0, b = 0, c = 0, d = 0, e = 0, f = 0, g = 0, h = 0, i = 0, j = 0, k = 0, l = 0, m = 0;
					double.TryParse(OrderSqShingle.Text, out a);
					double.TryParse(OrderHipandRidge.Text, out b);
					double.TryParse(Order3PipeBoot.Text, out c);
					double.TryParse(Order4PipeBoot.Text, out d);
					double.TryParse(OrderOSB.Text, out e);
					double.TryParse(OrderButtonCaps.Text, out f);
					double.TryParse(OrderRoofNails.Text, out g);
					double.TryParse(OrderStarter.Text, out h);
					double.TryParse(OrderUnderlayment.Text, out i);
					double.TryParse(OrderPaint.Text, out j);
					double.TryParse(OrderCaulk.Text, out k);
					double.TryParse(OrderDripEdge.Text, out l);
					double.TryParse(OrderIceWater.Text, out m);
					//	double.TryParse(OrderPaint.Text, out n);
					OrderItems.Add(new DTO_OrderItem
					{
						OrderID = order.OrderID,
						ProductID = 34,
						Quantity = (int)a * 3
					});//Shingles
					OrderItems.Add(new DTO_OrderItem
					{
						OrderID = order.OrderID,
						ProductID = 52,
						Quantity = (int)b
					});//Hip Ridge
					OrderItems.Add(new DTO_OrderItem
					{
						OrderID = order.OrderID,
						ProductID = 53,
						Quantity = (int)c
					});//3/1pipeboot
					OrderItems.Add(new DTO_OrderItem
					{
						OrderID = order.OrderID,
						ProductID = 54,
						Quantity = (int)d
					});//4PipeBoot
					OrderItems.Add(new DTO_OrderItem
					{
						OrderID = order.OrderID,
						ProductID = 55,
						Quantity = (int)e
					});//OSB
					OrderItems.Add(new DTO_OrderItem
					{
						OrderID = order.OrderID,
						ProductID = 56,
						Quantity = (int)f
					});//PlasticCapsBucket
					OrderItems.Add(new DTO_OrderItem
					{
						OrderID = order.OrderID,
						ProductID = 57,
						Quantity = (int)g
					});//CoilNails
					OrderItems.Add(new DTO_OrderItem
					{
						OrderID = order.OrderID,
						ProductID = 59,
						Quantity = (int)h
					});//ProStart
					OrderItems.Add(new DTO_OrderItem
					{
						OrderID = order.OrderID,
						ProductID = 60,
						Quantity = (int)i
					});//DeckDefense
					OrderItems.Add(new DTO_OrderItem
					{
						OrderID = order.OrderID,
						ProductID = 62,
						Quantity = (int)j
					});//CanPaint
					OrderItems.Add(new DTO_OrderItem
					{
						OrderID = order.OrderID,
						ProductID = 63,
						Quantity = (int)k
					});//TubeCaulk
					OrderItems.Add(new DTO_OrderItem
					{
						OrderID = order.OrderID,
						ProductID = 65,
						Quantity = (int)l
					});//WhiteDripEdge
					OrderItems.Add(new DTO_OrderItem
					{
						OrderID = order.OrderID,
						ProductID = 72,
						Quantity = (int)m
					});//IceAndWater

					foreach (var z in OrderItems)
						await s1.AddOrderItem(z);


				}
				catch (Exception ex)
				{
				}

			}


		}
		static public List<DTO_LU_Product> OCShingles()
		{
			var shing = s1.Products.FindAll(x => x.ProductTypeID == 1);
			return shing;
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
		private void googleViewCheckbox_Checked(object sender, RoutedEventArgs e)
		{
			if (!GoogleView.IsVisible)
				GoogleView.Visibility = Visibility.Visible;
		}
		private void googleViewCheckbox_Unchecked(object sender, RoutedEventArgs e)
		{
			if (GoogleView.IsVisible)
				GoogleView.Visibility = Visibility.Collapsed;
		}
		public void RoofMeasurmentsPage()
		{


			InitializeComponent();
			//	_busyIndicator = ((MainWindow)App.Current.MainWindow).busyIndicator;
			if (_Claim != null)
			{

				try
				{



					GetDialogData();
					Inspection = ClaimView.ClaimInspection;
					SetInspectionPlaneData();
					if (Plane != null)
						Plane = ClaimView.ClaimMeasurements[0];
				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.ToString());

				}
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("Something went wrong I'm going back!");

				var ns = NavigationService.GetNavigationService(this);

				return;

			}




		}
		async private Task<bool> DoesMeasurementsExist()
		{


			try
			{
				if (Inspection == null)
					Inspection = ClaimView.ClaimInspection;
				if (Inspection != null)
					return true;
			}
			catch (Exception)
			{
				System.Windows.Forms.MessageBox.Show("Need to add measurements for the list to have any to find.");

			}
			return false;
		}
		//TODO add AddPlane script here





		async Task<Stream> ViewDocument(string str, string str2 = null)
		{
			try
			{
				var web = new System.Net.WebClient();
				var stream = new MemoryStream(await web.DownloadDataTaskAsync(str));
				//while (stream == null)
				//	if (_busyIndicator.Visibility == Visibility.Collapsed)
				//		_busyIndicator.Visibility = Visibility.Visible;

				return stream;
				//_busyIndicator.Visibility = Visibility.Collapsed;
			}
			catch (Exception ex)
			{

				System.Windows.Forms.MessageBox.Show(ex.ToString());

			}

			return (Stream)null;

		}
		string DisplayRecordedClaimDocuments(DTO_ClaimDocument _claimDocument, DTO_ClaimDocument _claimDocument2 = null)
		{
			//	_busyIndicator.Visibility = Visibility.Visible;
			if (_claimDocument != null)
				if (_claimDocument.FileExt == ".pdf" || _claimDocument.FileExt == ".PDF")
				{
					return @"http://" + _claimDocument.FilePath + _claimDocument.FileName + _claimDocument.FileExt;
				}
			return null;
		}
		DTO_ClaimDocument GetClaimDocument(/*DTO_Claim _claim,*/ int _claimDocTypeID)
		{
			return s1.ClaimDocumentsList.Find(x => x.ClaimID == _Claim.ClaimID && x.DocTypeID == _claimDocTypeID);

		}
		async private void GetProducts()
		{
			await s1.GetProducts();
		}
		async private void GetDialogData(/*DTO_Claim claim*/)
		{
			//DTO_Claim _claim = new DTO_Claim();
			if (s1.Products != null)
				s1.Products = null;
			await s1.GetProducts();
			//	if(!_busyIndicator.IsVisible)
			//	_busyIndicator.Visibility = Visibility.Visible;
			//	while (s1.Products == null)
			//		_busyIndicator.IsBusy=true;
			//	_busyIndicator.Visibility = Visibility.Collapsed;

			if (string.IsNullOrEmpty(_Claim.ClaimID.ToString()))
				System.Windows.Forms.MessageBox.Show("No Claim To Get For Dialog Data.");


			if (await DoesMeasurementsExist())
			{
				var cd = GetClaimDocument(3);
				PDFTextExtractor pdfExtract = new PDFTextExtractor();
				try
				{

					if (cd != null)
						//textbox.Text = pdfExtract.Extract(DisplayRecordedClaimDocuments(GetClaimDocument(3)), true);
						FillVariables(pdfExtract.Extract(await ViewDocument(DisplayRecordedClaimDocuments(GetClaimDocument(3))), true));
					//DisplayRecordedClaimDocuments(GetClaimDocument(3));
				}
				catch (Exception ex)
				{

				}

				this.DataContext = this;
				//	System.Windows.Forms.MessageBox.Show("We found claim." + _Claim.ClaimID.ToString());
			}

			else
			{
				System.Windows.Forms.MessageBox.Show("We couldn't find a claim associated to gather plane details so we will give you the opportunity to find it yourself.");
				PDFTextExtractor pdfExtract = new PDFTextExtractor();
				var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "PDF Files (*.pdf)|*.pdf" };
				var result = ofd.ShowDialog();
				if (result == false) return;
				textbox.Text = pdfExtract.Extract(await ViewDocument(ofd.FileName), true);
				FillVariables(pdfExtract.Extract(await ViewDocument(ofd.FileName), true));
				this.DataContext = this;
			}




		}

		private List<string> products = new List<string>();
		private List<string> colors = new List<string>();

		void GatherProducts(DTO_ClaimVendor vid = null, string ShingleLineName = null)
		{
			if (products.Count > 0)
				products.Clear();
			if (colors.Count > 0)
				colors.Clear();

			foreach (var v in ShingleLineName == null ? s1.Products : s1.Products.Where(x => x.Name == ShingleLineName))
			{
				products.Add(v.Name + " - " + v.Color);
				colors.Add(v.Color);
			}


			OrderBrandType.ItemsSource = s1.Products;
			NewShingleCombo.ItemsSource = colors;
		}
		public List<string> PopulateLists(string str = null)
		{
			List<string> ItemList = new List<string>();
			ItemList.Clear();



			return ItemList;
		}
		//TODO:    Finish working the selectionlists for shingle
		//TODO:	   Link NewRoofs Table
		//TODO:	   GetCurrentClaimFromParent
		//TODO:    Find and implement another browser to display google maps and implement PDF Viewer to display the pdf created by this for viewing later "Resume Feature"
		//TODO:	   Update ClaimContacts when ordered
		//TODO:    Build Order
		//TODO:	   Add Order
		//TODO:    Retrieve All info that is available to enable resume feature

		public List<string> URL(string str)
		{
			List<string> UrlList = new List<string>();
			char[] charseperatorarg = "\r\n".ToCharArray();
			List<string> stringlist = new List<string>();
			string w = "";
			stringlist = str.Split(charseperatorarg, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
			//  stringlist.RemoveAll(s => s1.Contains("http://", "+") != true);
			foreach (var l in stringlist)
			{
				var stringholder = "";
				if (l.Contains("http://"))
					if (w == string.Empty)
						w = l;
				stringholder = w + l;
				if (l.IndexOf("http://maps.google.com/maps?f=g&source=s_q") == 0 ||
					(l.IndexOf("http://maps.google.com/maps?f=d&source=s_d") != 0 && l.Contains("+")))
					UrlList.Add(stringholder);
			}
			return UrlList;
		}

		public double S2D(string str)
		{
			double dbl = -1;
			char[] cleanchar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*(\r\n)+_= \\|}{[\"],';:".ToCharArray();
			double.TryParse(str.Trim(cleanchar), out dbl);
			return dbl;
		}

		public List<double> FunWithStrings(string str = null, List<string> strarg = null)
		{
			char[] charseperatorarg = "=\r\n".ToCharArray();
			List<string> stringlist = new List<string>();
			List<double> dblList = new List<double>();
			try
			{
				if (str != null)
					stringlist = str.Split(charseperatorarg, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
				else if (strarg != null)
					stringlist = strarg;
				else str = " ";

				foreach (var l in stringlist)
				{
					double a = 0;
					string t = string.Empty;
					t = l.Trim();

					if (t.Contains(' '))
					{
						t = t.Remove(t.IndexOf(" "));
					}

					if (double.TryParse(t, out a))
						dblList.Add(a);
					else //if (t.Contains('/') || t.Contains('(') || t.Contains(',') || t.Contains('-'))
					{
						if (t.IndexOf('(') > 0)
							dblList.Add(S2D(t.Remove(t.IndexOf('(')).ToString()));
						else if (t.IndexOf(',') > 0)
							dblList.Add(S2D(t.Remove(t.IndexOf(','), 1)));
						else if (t.IndexOf('/') > 0)
							dblList.Add(S2D(t.Replace('/', '.')));
						else if (t.IndexOf('-') > 0)
							dblList.Add(-1 * S2D(t.Replace('-', ' ')));
					}
				}
				dblList.RemoveAll(dbl => dbl == -1);
				return dblList;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				throw;
			}

		}


		public void FillVariables(string texttoparse)
		{
			List<double> MeasurementList2 = new List<double>();
			List<string> MeasurementList3 = new List<string>();
			string workingtext = texttoparse.Substring(texttoparse.IndexOf(startsubstring));
			string propertyaddress = URL(texttoparse.Substring(texttoparse.IndexOf(PropertyAddressBlockStart)))[0];
			// string directionsaddress = URL(texttoparse.Substring(texttoparse.IndexOf(PropertyAddressBlockStart)))[1];
			List<double> MeasurementList4 = new List<double>();
			List<string> MeasurementList5 = new List<string>();
			MeasurementList2 = FunWithStrings(workingtext);
			MeasurementList3 = URL(workingtext);
			List<string> list = MeasurementList3;
			MeasurementList4 = FunWithStrings(null, list);
			char[] cleanchar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()+_= \\|}{[\"],';:".ToCharArray();
			char[] charseperatorarg = "( )=\r\n".ToCharArray();
			List<string> stringlist1 = new List<string>();
			List<double> dblList = new List<double>();
			stringlist1 = workingtext.Split(charseperatorarg, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
			stringlist1.RemoveAll(c => c.All(char.IsLetter));
			stringlist1.RemoveAll(c => c == "");
			MeasurementList5.RemoveAll(s => s == "-1");
			Ridges.Text = MeasurementList2[1].ToString();
			Hips.Text = MeasurementList2[2].ToString();
			OrderIceWaterValleys.Text = MeasurementList2[3].ToString();
			Rakes.Text = MeasurementList2[4].ToString();
			Eaves.Text = MeasurementList2[6].ToString();
			OrderDripEdge.Text = MeasurementList2[7].ToString();
			TotalAreaOFF.Text = MeasurementList2[11].ToString();
			PrePitch.Text = MeasurementList2[12].ToString();
			latitude = MeasurementList2[13].ToString();
			longitude = MeasurementList2[14].ToString();
			RidgeMeasurement = S2D(MeasurementList2[1].ToString());
			HipMeasurement = S2D(MeasurementList2[2].ToString());
			ValleyMeasurement = S2D(MeasurementList2[3].ToString());
			RakeMeasurement = S2D(MeasurementList2[4].ToString());
			EaveMeasurement = S2D(MeasurementList2[6].ToString());
			StarterMeasurement = S2D(MeasurementList2[7].ToString());
			TotalSQFTOFF = S2D(MeasurementList2[11].ToString());
			PredPitch = (int)S2D(MeasurementList2[12].ToString());
			DoMath();
		}
		/// <summary>
		/// Takes Data in the form usually of string objects has the selector to identify which function to call with the data and 2 other control variables
		/// </summary>
		//Show Property On Map      S2D is cleaner string to double converter
		/// <param name="jlbArg"></param>
		//jlbArg[0] = latitude               //jlbArg[0] = MRNNumber 
		//jlbArg[1] = longitude              //jlbArg[1] = Customer Namw  
		//jlbArg[2] = Zoom                   //jlbArg[2] = Customer Street Address  
		//jlbArg[9] =  Zipcode 
		/// <param name="iOutputSelection"></param>
		/// <param name="bVarible"></param>
		/// <param name="ivariable"></param>
		public virtual object GoFetch(int iOutputSelection, double[] dblarg = null, Page page = null, string str = null)
		{

			string address = string.Empty;

			switch (iOutputSelection)
			{
				case 1:
					{
						NavigationService.Navigate(page);
						break;
					}
				case 2:                 //Show Eagle View        
					{

						address = "";

						break;
					}
				case 3:                 //Show Order
					{
						address = "";
						break;
					}
				case 4:                 //Show Scope
					{
						address = "";
						break;
					}
				case 5:                 //Show Sketch
					{
						address = "";
						break;
					}
				case 6:                 //Show Calendar
					{
						address = "";
						break;
					}
				case 7:                 //Show Weather
					{
						address = "";
						break;
					}
				case 8:                 //Show Authorization Form
					{
						address = "";
						break;
					}
				default:                        // Normal thing for this function to perform
					address = "";
					break;
			}
			StringBuilder sb = new StringBuilder();
			sb.Clear();


			return this;
		}
		/// <returns></returns>
		public virtual object GoFetch(string[] jlbArg, int iOutputSelection = 0, bool bVarible = true)
		{
			string address = string.Empty;

			switch (iOutputSelection)
			{
				case 1:
					{
						OrderCanvas.Visibility = Visibility.Collapsed;
						textbox.Visibility = Visibility.Collapsed;
						//AppointmentWebView.Visibility = Visibility.Visible;
						address = "https://www.google.com/maps/@" + jlbArg[0] + "," + jlbArg[1] + ",+" + jlbArg[2] + "m/data=!3m1!1e3?hl=en";//if satdata true 
						break;
					}
				case 2:                 //Show Eagle View        
					{

						address = "";

						break;
					}
				case 3:                 //Show Order
					{
						address = "";
						break;
					}
				case 4:                 //Show Scope
					{
						address = "";
						break;
					}
				case 5:                 //Show Sketch
					{
						address = "";
						break;
					}
				case 6:                 //Show Calendar
					{
						address = "";
						break;
					}
				case 7:                 //Show Weather
					{
						address = "";
						break;
					}
				case 8:                 //Show Authorization Form
					{
						address = "";
						break;
					}
				default:                        // Normal thing for this function to perform
					address = "";
					break;
			}
			StringBuilder sb = new StringBuilder();
			sb.Clear();
			return new Uri(sb.ToString());
		}
		async private void SetInspectionPlaneData()
		{
			if (Inspection == null)
				inspection = new DTO_Inspection();
			if (Inspection == null)
			{


				//TODO Try Catch
				//{
				//	await s1.GetAllInspections();
				//	if (s.InspectionsList.Exists(x => x.ClaimID == claim.ClaimID))
				//		await s1.GetInspectionsByClaimID(claim);



				//	else



				{
					inspection.ClaimID = _Claim.ClaimID;
					inspection.Comments = "None";
					inspection.CoverPool = false;
					inspection.MagneticRollers = true;
					inspection.InspectionDate = DateTime.Now;
					inspection.ShingleTypeID = 1;
					inspection.SkyLights = true;
					inspection.Leaks = false;
					inspection.GutterDamage = false;
					inspection.DrivewayDamage = false;
					inspection.IceWaterShield = true;
					inspection.EmergencyRepair = false;
					inspection.EmergencyRepairAmount = 0;
					inspection.QualityControl = true;
					inspection.ProtectLandscaping = true;
					inspection.RemoveTrash = true;
					inspection.FurnishPermit = true;
					inspection.InteriorDamage = false;
					inspection.ExteriorDamage = false;
					inspection.RoofAge = 10;
					inspection.Satellite = false;
					inspection.TearOff = true;
					inspection.SolarPanels = false;
					inspection.RidgeMaterialTypeID = 1;
					inspection.LightningProtection = false;


				}


				#region Old inspection code

				//inspection.ClaimID = result.ClaimID;
				//inspection.Comments = result.Comments;
				//inspection.CoverPool = result.CoverPool;
				//inspection.DrivewayDamage = result.DrivewayDamage;
				//inspection.EmergencyRepair = result.EmergencyRepair;
				//inspection.EmergencyRepairAmount = result.EmergencyRepairAmount;
				//inspection.ExteriorDamage = result.ExteriorDamage;
				//inspection.FurnishPermit = result.FurnishPermit;
				//inspection.GutterDamage = result.GutterDamage;
				//inspection.IceWaterShield = result.IceWaterShield;
				//inspection.InspectionDate = result.InspectionDate;
				//inspection.InteriorDamage = result.InteriorDamage;
				//inspection.Leaks = result.Leaks;
				//inspection.MagneticRollers = result.MagneticRollers;
				//inspection.ProtectLandscaping = result.ProtectLandscaping;
				//inspection.QualityControl = result.QualityControl;
				//inspection.RemoveTrash = result.RemoveTrash;
				//inspection.RidgeMaterialTypeID = result.RidgeMaterialTypeID;
				//inspection.RoofAge = result.RoofAge;
				//inspection.Satellite = result.Satellite;
				//inspection.ShingleTypeID = result.ShingleTypeID;
				//inspection.SkyLights = result.SkyLights;
				//inspection.SolarPanels = result.SolarPanels;
				//inspection.TearOff = result.TearOff;
				//inspection.LightningProtection = result.LightningProtection;
				//inspection.SuccessFlag = true;
				#endregion
				try
				{
					await s1.AddInspection(inspection);
				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.ToString());

				}
				if (s1.Inspection.Message == null)
				{




					DTO_Plane p = new DTO_Plane();


					p.SquareFootage = TotalSQFTOFF;
					p.RidgeLength = (int)RidgeMeasurement;
					p.RakeLength = (int)RakeMeasurement;
					p.Pitch = PredPitch;
					p.HipValley = (int)HipMeasurement;
					p.GroupNumber = 1;
					p.ItemSpec = "EV " + ValleyMeasurement.ToString();
					p.EaveLength = (int)EaveMeasurement;
					p.InspectionID = s1.Inspection.InspectionID;
					//TODO Make this Dynamic
					if (!string.IsNullOrEmpty(OrderOSB.Text))
						p.NumberDecking = int.Parse(OrderOSB.Text);
					else p.NumberDecking = 0;
					if (!string.IsNullOrEmpty(OrderNoOfLayers.Text))
						p.NumOfLayers = int.Parse(OrderNoOfLayers.Text);
					else p.NumOfLayers = 1;

					p.PlaneTypeID = 15;
					p.StepFlashing = int.Parse("0");
					try
					{
						await s1.AddPlane(p);
					}
					catch (Exception ex)
					{
						System.Windows.Forms.MessageBox.Show(ex.ToString());


					}
					System.Windows.Forms.MessageBox.Show(s1.Inspection.InspectionID.ToString());
					if (s1.Plane.Message == null)
						System.Windows.Forms.MessageBox.Show(s1.Plane.PlaneID.ToString());
					else
						System.Windows.Forms.MessageBox.Show(s1.Plane.Message);

				}
				else System.Windows.Forms.MessageBox.Show(s1.Inspection.Message);
			}
			//	new DTO_Claim Order({ })
			s1.Inspection = null;
			//	}
		}



		public void DoMath()
		{

			OrderSqShingle.Text = FigureWaste(Slider.Value, TotalSQFTOFF).ToString();

			OrderRoofNails.Text = FigureRoofNails().ToString();

			OrderRidgeVent.Text = FigureRidgevent().ToString();

			OrderButtonCaps.Text = FigurePlasticCaps().ToString();

			OrderIceWater.Text = FigureIceAndWater().ToString();

			OrderHipandRidge.Text = FigureHipRidge().ToString();

			OrderDripEdge.Text = FigureDripedge().ToString();

			OrderStarter.Text = FigureStarter().ToString();
			if (UnderlaymentCombo.SelectedIndex < 2)
				OrderUnderlayment.Text = FigureUnderlayment(10).ToString();
			else
				OrderUnderlayment.Text = FigureUnderlayment(4).ToString();
			OrderPaint.Text = "3";
			OrderCaulk.Text = "3";

			InstallerPrice.Text = (FigureWaste(Slider.Value, TotalSQFTOFF) * (double)60).ToString();

			VendorPrice.Text = FigureRoofCost(OrderBrandType.SelectedIndex, FigureWaste(Slider.Value, TotalSQFTOFF), FigureHipRidge(), FigureStarter(), UnderlaymentCombo.SelectedIndex, FigureRidgevent(), 0, FigureUnderlayment(), FigureIceAndWater(), 3, 1, 3, 2, 3, FigureRoofNails(), FigurePlasticCaps(), FigureDripedge()).ToString();
		}

		public double FigureRoofCost(int shingletype = 0, double shingleON = 0, int bdlHR = 0, int bdlstart = 0, int ULType = 0, int rv = 0, int tb = 0, int ULRolls = 0, int IandW = 0, int i3n1 = 0, int i4in = 0, int canpt = 0, int OSB = 0, int caulk = 0, int rnail = 0, int pcbuck = 0, int DE = 0)
		{

			double EstimatedOCCost = 0;
			double prvent = 6.50;


			double pButtonCap = 21.00;
			double pRNails = 22.00;
			double pSprayPaint = 5.29;
			double pCaulk = 4.71;
			double p31pjb = 4.12;
			double p4ipjb = 4.12;
			double pOCHRShingle = 37.50;
			double pOCStarterShin = 30;
			double pOCWeatherlockG = 56.71;
			double pTBSlant = 14.08;
			double[] OCShingle = { 71.00, 66.00, 65.00, 54.00 };//0=Duration,1=TruDef,2=Oakridge,3=Supreme
			double[] Underlayment = { 120, 65.00, 32.67 };//0=DeckDefense,1=ProArmor,2=GorillaGuard
			double pOSB = 11;
			double taxrate = 1.06;
			double pDE = 6.5;
			try
			{
				if (shingletype > -1 && shingletype < OCShingle.Count())
					EstimatedOCCost += (OCShingle[shingletype] * shingleON);
				else EstimatedOCCost += (OCShingle[1] * shingleON);
				EstimatedOCCost += bdlHR * pOCHRShingle;
				EstimatedOCCost += bdlstart * pOCStarterShin;
				if (ULType > -1 && ULType < Underlayment.Count())
					EstimatedOCCost += Underlayment[ULType] * ULRolls;
				else EstimatedOCCost += Underlayment[1] * ULRolls;
				EstimatedOCCost += tb * pTBSlant;
				EstimatedOCCost += IandW * pOCWeatherlockG;
				EstimatedOCCost += rv * prvent;
				EstimatedOCCost += i3n1 * p31pjb;
				EstimatedOCCost += i4in * p4ipjb;
				EstimatedOCCost += canpt * pSprayPaint;
				EstimatedOCCost += caulk * pCaulk;
				EstimatedOCCost += rnail * pRNails;
				EstimatedOCCost += pcbuck * pButtonCap;
				EstimatedOCCost += pOSB * OSB;
				EstimatedOCCost += pDE * DE;

				return EstimatedOCCost * taxrate;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				throw;
			}

		}


		public double FigureWaste(double wastefactor = 0, double sqftOff = 0)
		{
			if (sqftOff == 0 && wastefactor == 0)
				return Math.Ceiling((sqftOff + (sqftOff * (Slider.Value * .01))) / 100);
			else if (sqftOff > 0)
				return Math.Ceiling((sqftOff + (sqftOff * (Slider.Value * .01))) / 100);
			else return TotalSQFTOFF / 100;
		}

		public int FigureRoofNails()
		{
			return (int)Math.Ceiling(FigureWaste(Slider.Value, TotalSQFTOFF) / 16);
		}

		public int FigurePlasticCaps()
		{
			return (int)Math.Ceiling(FigureWaste(Slider.Value, TotalSQFTOFF) / 20);
		}

		public int FigureRidgevent()
		{
			if (RidgeMeasurement > 0)
				return (int)Math.Ceiling(RidgeMeasurement / 4);
			return 0;
		}

		public int FigureUnderlayment(int underlaymentsqroll = 4)
		{
			if (underlaymentsqroll > 0)
				return (int)Math.Ceiling((TotalSQFTOFF / 100) / underlaymentsqroll);
			return 0;
		}

		public int FigureIceAndWater()
		{
			if (ValleyMeasurement > 0)
				return (int)Math.Ceiling(ValleyMeasurement / 62);
			return 0;
		}

		public int FigureHipRidge()
		{
			if (HipMeasurement + RidgeMeasurement > 0)
				return (int)Math.Ceiling((HipMeasurement + RidgeMeasurement) / 25);
			return 0;
		}

		public int FigureStarter()
		{
			if (StarterMeasurement > 0)
				return (int)Math.Ceiling(StarterMeasurement / 100);
			return 0;
		}

		public int FigureDripedge()
		{
			if (RakeMeasurement > 0)
				return (int)Math.Ceiling((RakeMeasurement + (RakeMeasurement * .1)) / 10);
			return 0;
		}

		private void LogOut(object sender, RoutedEventArgs e)
		{
			Login Page = new Login();
			this.NavigationService.Navigate(Page);
		}

		private string MakeAddress(string street, string city, string state, string zipcode)
		{
			StringBuilder queryaddress = new StringBuilder();
			if (street != string.Empty)
			{
				queryaddress.Append(street + "," + "+");
			}
			if (city != string.Empty)
			{
				queryaddress.Append(city + "," + "+");
			}
			if (state != string.Empty)
			{
				queryaddress.Append(state + "," + "+");
			}
			if (zipcode != string.Empty)
			{
				queryaddress.Append(zipcode + "," + "+");
			}
			return queryaddress.ToString();
		}

		private void FetchWebsite(string webaddress)
		{
			//  AppointmentWebView.Source = new Uri(webaddress.ToString());
		}

		private void GetJobInfo(string Latatitude, string longitudestring, string address, string zipcode = "30052", bool b = true)
		{
			if (b == true)
			{
				FetchWebsite("https://weather.com/weather/today/l/" + zipcode + ":4:US");
				b = false;
			}
			else
			{
				ShowOnMap(null, address);
				b = true;
			}
		}

		private void ShowOnMap(string from = null, string to = null)
		{
			//  private void ShowOnMap(int ContentToShow)
			try
			{
				StringBuilder queryaddress = new StringBuilder();
				queryaddress.Append("http://maps.google.com/maps");
				queryaddress.Append("/dir/196 Old Loganville Road,Loganville,Georgia,30052/" + to);
				FetchWebsite(queryaddress.ToString());
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.Message.ToString(), "Custom Error Message");
				throw;
			}
		}



		private void PeekABoo(bool bVisible = false)
		{
			if (!bVisible)
			{

				textBlockOS.Background = System.Windows.Media.Brushes.White;
				textBlockOS.Foreground = System.Windows.Media.Brushes.Black;
				canvas.Background = System.Windows.Media.Brushes.White;
				PrintButton.Visibility = Visibility.Hidden;
				Print();
			}
			else
			{
				textBlockOS.Background = System.Windows.Media.Brushes.Transparent;
				textBlockOS.Foreground = System.Windows.Media.Brushes.White;
				canvas.Background = System.Windows.Media.Brushes.Transparent;
				PrintButton.Visibility = Visibility.Visible;
			}
		}

		private void Print()
		{
			System.Windows.Controls.PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
			var z = OrderCanvas.LayoutTransform;

			OrderCanvas.LayoutTransform = new ScaleTransform(1.62, 1.5);
			System.Windows.Size pageSize = new System.Windows.Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight);
			OrderCanvas.Measure(pageSize);
			OrderCanvas.Arrange(new Rect(20, 20, pageSize.Width + 20, pageSize.Height + 50));
			printDlg.PrintVisual(OrderCanvas, "Roof Order #" + MRNNumber);
			OrderCanvas.LayoutTransform = z;

			PeekABoo(true);
		}

		private void PrintButton_Click(object sender, RoutedEventArgs e)
		{
			PeekABoo();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new RoofMeasurmentsPage(new DTO_Claim()));
		}

		private void On_OK(object sender, RoutedEventArgs e)
		{

			SetInspectionPlaneData();
			//NavigationService.Navigate(new NexusHome());

		}



		private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (TotalSQFTOFF > 0) DoMath();
		}

		private void Print_Click(object sender, RoutedEventArgs e)
		{
			PeekABoo();
		}

		private void PreviousButton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new RoofMeasurmentsPage(new DTO_Claim()));
		}

		private void NextButton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new RoofMeasurmentsPage());
		}

		private void toggleButton_Checked(object sender, RoutedEventArgs e)
		{
			OrderCanvas.Visibility = Visibility.Collapsed;
			textbox.Visibility = Visibility.Collapsed;
			//  AppointmentWebView.Visibility = Visibility.Visible;


		}

		private void toggleButton_Click(object sender, RoutedEventArgs e)
		{
			if (toggleButton.IsChecked == true)
				toggleButton.IsChecked = false;
			else toggleButton.IsChecked = true;
		}

		private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
		{
			OrderCanvas.Visibility = Visibility.Visible;
			textbox.Visibility = Visibility.Collapsed;
			// AppointmentWebView.Visibility = Visibility.Collapsed;
		}

		private void OrderSqShingle_TextChanged(object sender, TextChangedEventArgs e)
		{
			double a = 0;
			if (double.TryParse(OrderSqShingle.Text, out a))
			{
				double dtemp = 0;
				dtemp = a - (a * (Slider.Value * .01));
				TotalAreaOFF.Text = dtemp.ToString();

				DoMath();
			}
			else OrderSqShingle.Text = FigureWaste(Slider.Value, TotalSQFTOFF).ToString();
		}

		private void View_Order(object sender, RoutedEventArgs e)
		{
			OrderCanvas.Visibility = Visibility.Visible;
			textbox.Visibility = Visibility.Collapsed;
			//  AppointmentWebView.Visibility = Visibility.Collapsed;
		}

		private void SatViewGoogle(object sender, RoutedEventArgs e)
		{
			OrderCanvas.Visibility = Visibility.Collapsed;
			textbox.Visibility = Visibility.Collapsed;
			// AppointmentWebView.Visibility = Visibility.Visible;
		}
		string a = "", b = "";
		private void OrderBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			a = OrderBrand.Text;



			if (OrderBrand.SelectedIndex > -1)
				//	OrderBrandType.ItemsSource = PopulateLists(OrderBrand.SelectedIndex == 1 ? 5 : 0);

				GetProducts();

			DoMath();
		}

		private void OrderBrandType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//if (OrderBrandType.SelectedIndex > -1)
			//  if (NewShingleCombo.HasItems)
			//NewShingleCombo.ItemsSource = PopulateLists((OrderBrand.SelectedIndex == 0 ? 0 : 5) + OrderBrandType.SelectedIndex == 0 ? 1 : (OrderBrandType.SelectedIndex + 1));
			//b = OrderBrandType.Text;

			//	ShingleType.Text = a + " - " + b;
			DoMath();
		}


		private void maskedTextBox_CustomerNameChanged(object sender, TextChangedEventArgs e)
		{
			//  CustomerName.Text = maskedTextBoxCustomerName.Text;
			DoMath();

		}

		private void maskedTextBox_StreetAddressChanged(object sender, TextChangedEventArgs e)
		{
			//  CustomerAddress.Text = maskedTextBoxCustomerAddress.Text;
			DoMath();
		}

		private void maskedTextBox_CSZChanged(object sender, TextChangedEventArgs e)
		{
			string str = string.Empty;
			str = maskedTextBoxCustomerCSZ.Text;
			AddressZipcodeValidation azv = new AddressZipcodeValidation();

			if (str.All((char.IsNumber)) && str.Count() == 5)
			{
				if (azv.CityStateLookupRequest(str) == null)
				{
					System.Windows.Forms.MessageBox.Show("No such zipcode!");
					maskedTextBoxCustomerCSZ.Text = str = string.Empty;
					return;
				}
				string citystate = azv.CityStateLookupRequest(str);

				string city = citystate.Substring(citystate.IndexOf("<City>") + 6, citystate.IndexOf("</City>") - citystate.IndexOf("<City>") - 6);

				string state = AddressZipcodeValidation.ConvertStateToAbbreviation(citystate.Substring(citystate.IndexOf("<State>") + 7, citystate.IndexOf("</State>") - citystate.IndexOf("<State>") - 7));
				CustomerAddressCSZ.Text = CustomerAddress.ToString();
				string[] w = city.Split(' ');
				city = "";
				int i = 0;

				foreach (string t in w)
				{
					city += t.Substring(0, 1).ToUpper();
					city += t.Substring(1, t.Length - 1).ToLower();
					if (i > 0)
						city += " ";

				}

				CustomerAddressCSZ.Text = city + ", " + state + "  " + str;
			}

			DoMath();


		}

		private void maskedTextBox_CommentsChanged(object sender, TextChangedEventArgs e)
		{
			// CommentsOrder.Text = Comments.Text; 
			DoMath();
		}

		private void SalespersonCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//  SalespersonText.Text = SalespersonCombo.SelectionBoxItem.ToString();
			DoMath();
		}

		private void OrderPaint_TextChanged(object sender, TextChangedEventArgs e)
		{
			//  PaintQuan.Text = OrderPaint.Text;
			DoMath();
		}

		private void OrderCaulk_TextChanged(object sender, TextChangedEventArgs e)
		{
			//   CaulkQuan.Text = OrderCaulk.Text;
			DoMath();
		}

		private void Order4PipeBoot_TextChanged(object sender, TextChangedEventArgs e)
		{
			//  FourInchPipeBootQuan.Text = Order4PipeBoot.Text;
			DoMath();
		}

		private void Order3PipeBoot_TextChanged(object sender, TextChangedEventArgs e)
		{
			//  ThreeAndOnePipeBootQuan.Text = Order3PipeBoot.Text;
			DoMath();
		}

		private void OrderTurtleVent_TextChanged(object sender, TextChangedEventArgs e)
		{
			//  TurtleBackQuan.Text = OrderTurtleVent.Text;
			DoMath();
		}

		private void DripedgeColorCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//    DripEdgeColor.Text = DripedgeColorCombo.SelectionBoxItem.ToString();
			DoMath();
		}

		private void Hips_TextChanged(object sender, TextChangedEventArgs e)
		{

			double dbl = 0;
			double.TryParse(Hips.Text, out dbl);
			HipMeasurement = dbl;
			DoMath();
		}

		private void Ridges_TextChanged(object sender, TextChangedEventArgs e)
		{
			double dbl = 0;
			double.TryParse(Ridges.Text, out dbl);
			RidgeMeasurement = dbl;
			DoMath();
		}

		private void OrderIceWaterValleys_TextChanged(object sender, TextChangedEventArgs e)
		{
			double dbl = 0;
			double.TryParse(OrderIceWaterValleys.Text, out dbl);
			ValleyMeasurement = dbl;
			DoMath();
		}

		private void Rakes_TextChanged(object sender, TextChangedEventArgs e)
		{
			double dbl = 0;
			double.TryParse(Rakes.Text, out dbl);
			RakeMeasurement = dbl;
			DoMath();
		}

		private void Eaves_TextChanged(object sender, TextChangedEventArgs e)
		{
			double dbl = 0;
			double.TryParse(Eaves.Text, out dbl);
			EaveMeasurement = dbl;

			DoMath();
		}

		private void InstallerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void TotalAreaOFF_TextChanged(object sender, TextChangedEventArgs e)
		{
			double dbl = 0;
			double.TryParse(TotalAreaOFF.Text, out dbl);
			TotalSQFTOFF = dbl;
			DoMath();
		}
		private void addImagesbutton_Click(object sender, RoutedEventArgs e)
		{
			imagelistBox.ItemsSource = SelectFile(2);
		}

		private void nextImageBtn_Click(object sender, RoutedEventArgs e)
		{
			imagelistBox.SelectedIndex++;
		}

		private void deleteImageButtonbutton_Click(object sender, RoutedEventArgs e)
		{
			image.Source = null;
			imagelistBox.Items.RemoveAt(imagelistBox.SelectedIndex);
		}

		private void imagelistBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(imagelistBox.SelectedValue.ToString());
		}
		private List<string> SelectFile(int docTypeID)
		{
			var fileDialog = new System.Windows.Forms.OpenFileDialog();
			if (docTypeID == 2)
				fileDialog.Multiselect = true;
			else
				fileDialog.Multiselect = false;
			fileDialog.Title = "Inspection Image Import Tool";
			fileDialog.Filter = Filter(docTypeID);
			var result = fileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				//FullFilePath = fileDialog.FileName;
				foreach (string s in fileDialog.FileNames)
				{

					FileNames.Add(s);
				}
				imagelistBox.ItemsSource = FileNames;
				imagelistBox.SelectedIndex = 0;
			}

			return FileNames;
		}
		List<string> FileNames = new List<string>();
		string Filter(int docTypeID)
		{
			switch (docTypeID)
			{
				case 2:
					return "All Image Types (*.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png) | *.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png";

				default:
					return "All Image Types (*.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png) | *.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png | All Document Types (*.pdf;*.doc;*.docx;*.txt;*.xml) | *.pdf;*.doc;*.docx;*.txt;*.xml| All File Types(*.*) | *.*";

			}




		}
		public async Task<List<string>> Roofers()
		{
			if (s1.VendorsList == null)
				await s1.GetAllVendors();
			var roofers = new List<string>();
			foreach (var t in s1.VendorsList.Where(x => x.VendorTypeID == 3))
				roofers.Add(t.CompanyName);
			return roofers;
		}

		protected BitmapImage DisplayImage(ImageSource imgsrc)
		{

			return (BitmapImage)new ImageSourceConverter().ConvertFrom(imgsrc);


		}

		void InitPayment()
		{
			paymentDateDatePicker.Text = DateTime.Today.ToShortDateString();
			if (_Claim != null)
			{
				OnInit(DocTypeID);
				//	while (s1.PaymentsList == null)
				//		Thread.Sleep(10);

				try
				{


					var a = s1.PaymentsList.Where(x => x.PaymentDescriptionID == SetPaymentTypeID(DocTypeID)).ToList();
					if (a.Count() > 0)
					{

						paymentDateDatePicker.SelectedDate = a[0].PaymentDate;
						amountTextBox.Value = (decimal)a[0].Amount;
						amountTextBox.IsEnabled = false;
						paymentDateDatePicker.IsEnabled = false;
						/*	if (System.Windows.Forms.MessageBox.Show("Found this document.", "Do you want to change it?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
							{
								amountTextBox.IsEnabled = true;
								paymentDateDatePicker.IsEnabled = true;
								G.statusTextBlock.Text = "How much was this check for?";
								amountTextBox.IsEnabled = true;
							}*/
					}

					else
					{
						paymentDateDatePicker.Text = DateTime.Today.ToShortDateString();
						SetPaymentTypeID(DocTypeID);
						G.statusTextBlock.Text = "How much was this check for?";
					}



				}

				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show("You Suck! You Jackass!!!");
					paymentDateDatePicker.SelectedDate = DateTime.Today;
					SetPaymentTypeID(DocTypeID);
					G.statusTextBlock.Text = "How much was this check for?";
				}


			}

			//else if (payment != null)
			//	DisplayPayment(payment);






		}


		public void DisplayPayment(DTO_Payment payment)
		{
			amountTextBox.Value = (decimal)payment.Amount;
			SetPaymentTypeID(payment.PaymentDescriptionID);
			paymentDateDatePicker.SelectedDate = payment.PaymentDate;
		}

		async private void OnInit(int DocTypeId)
		{
			try
			{

				await s1.GetPaymentsByClaimID(_Claim);
				s1.PaymentsList.ForEach(x => Payments.Add(x));


			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("Payment Date Error Code " + paymentDateDatePicker.Text + "-" + _Claim.ToString() + "--" + PaymentDescriptionID + " Report this error to IT Dept." + "\r\n" + ex.ToString());

			}

		}

		private void paymentDateDatePicker_LostFocus(object sender, RoutedEventArgs e)
		{
			if (paymentDateDatePicker.SelectedDate.HasValue)
				PaymentDate = paymentDateDatePicker.SelectedDate.Value;
		}


		private void amountTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

			//if (amountTextBox.Text == string.Empty) amountTextBox.Value = 0;
			if (amountTextBox.Value > 0) SubmitPaymentEntry.IsEnabled = true;

		}

		private void checkBox_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void checkBox_Copy_Checked(object sender, RoutedEventArgs e)
		{

		}







		private void CancelPaymentEntry_Click(object sender, RoutedEventArgs e)
		{
			G.ReadyToUpdate = true;
			G.updateUI();
		}

		async private void SubmitPaymentEntry_Click(object sender, RoutedEventArgs e)
		{

			if (paymentDateDatePicker.SelectedDate != null && paymentDateDatePicker.SelectedDate <= DateTime.Today && amountTextBox.Value > 0)
			{
				SetPaymentTypeID(DocTypeID);
				DTO_Payment p = new DTO_Payment();

				p.Amount = (double)amountTextBox.Value;
				p.PaymentDate = paymentDateDatePicker.SelectedDate.Value;
				p.PaymentDescriptionID = PaymentDescriptionID;
				p.ClaimID = _Claim.ClaimID;
				p.PaymentTypeID = 1;
				try
				{

					await s1.AddPayment(p);
					//		UploadImage(SelectFile());
				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.ToString());

				}


				if (s1.Payment.Message == null)
				{
					// TODO: Upload the pic of check.
					//TODO:  Add claim Document Entry. Taken Care of on upload. But the update of the claim status still needs updating;

					var cs = new DTO_ClaimStatus();
					cs.ClaimID = _Claim.ClaimID;
					cs.ClaimStatusDate = DateTime.Today;
					cs.ClaimStatusTypeID = ClaimStatusType;
					try
					{


						await s1.UpdateClaimStatuses(cs);

					}
					catch (Exception ex)
					{
						System.Windows.Forms.MessageBox.Show(ex.ToString());
					}

					System.Windows.MessageBox.Show("Payment Added.");

				}
				else
				{
					System.Windows.MessageBox.Show(s1.Payment.Message);
				}
				G.ReadyToUpdate = true;
				f.Navigate(new MRNLogo1());
				G.updateUI();

			}

		}

		private void DisplayPayment(/*DTO_Claim claim,*/ int paymentDescriptionType)
		{
			System.Windows.Forms.MessageBox.Show("On " + s1.PaymentsList.Find(x => x.ClaimID == _Claim.ClaimID && x.PaymentDescriptionID == paymentDescriptionType).PaymentDate.ToString() + " a payment was made for the amount of $ " + s1.PaymentsList.Find(x => x.ClaimID == _Claim.ClaimID && x.PaymentDescriptionID == paymentDescriptionType).Amount.ToString());
		}


		int SetPaymentTypeID(int docTypeID)
		{
			switch (docTypeID)
			{
				case 13:
					{
						PaymentDescriptionID = 1;
						PaymentDescriptionTextBlock.Text = "First/Deposit Check";
						ClaimStatusType = 7;

						return 1;
					}
				case 14:
					{
						PaymentDescriptionID = 5;
						PaymentDescriptionTextBlock.Text = "Deductible Check";
						ClaimStatusType = 21;
						return 5;
					}
				case 15:
					{
						PaymentDescriptionID = 3;
						PaymentDescriptionTextBlock.Text = "Depreciation Check";
						ClaimStatusType = 20;
						return 3;
					}
				case 16:
					{
						PaymentDescriptionID = 2;
						PaymentDescriptionTextBlock.Text = "Supplemental Check";
						ClaimStatusType = 18;

						return 2;
					}
				default:
					{
						PaymentDescriptionID = 4;
						PaymentDescriptionTextBlock.Text = "Upgrade Check";

						return 4;
					}
			}
		}

		async public Task<bool> CheckFileExist(int cdt = 0)
		{                                                           //the worker function to callback after determining if the file exists in the location that has been picked if so it will ask what would you like to do with it.
			try
			{

				await s1.GetPaymentsByClaimID(_Claim);


			}
			catch (Exception ex)
			{

				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			if (s1.ClaimDocumentsList.Exists(x => x.DocTypeID == PaymentDescriptionID))
				return true;
			else return false;
		}



		string GetDocumentTypeByID(int doctypeid)
		{
			return ((DTO_LU_ClaimDocumentType)s1.ClaimDocTypes.Where(t => t.ClaimDocumentTypeID == doctypeid)).ClaimDocumentType.ToString();
		}

		DTO_Invoice invoice = new DTO_Invoice();



		private decimal tempInvoiceAmount = 0;
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			//	busyIndicator.IsBusy = false;
		}
		private void init()
		{


			//	while (s1.VendorsList.Count() < 1)
			//	Thread.Sleep(10);
			if (invoice != null)
			{
				textBox_Copy4.Value = tempInvoiceAmount = (decimal)invoice.InvoiceAmount;
				((DTO_Vendor)VendorsList.SelectedValue).VendorID = invoice.VendorID;
				((DTO_LU_InvoiceType)InvoiceTypeList.SelectedValue).InvoiceTypeID = invoice.InvoiceTypeID;
				InvoiceDatePicker.SelectedDate = invoice.InvoiceDate;
			}
			else InvoiceDatePicker.SelectedDate = DateTime.Today;


		}

		private void AddVendor_Click(object sender, RoutedEventArgs e)
		{


		}


		async private void InitialDBFunctions()
		{
			//MainWindow.GetBusy();
			var VendorList = new List<DTO_Vendor>();
			if (_Claim == null)
				await s1.GetAllClaims();
			var claimValue = await GetClaimValues();
			await s1.GetAllVendors();
			await s1.GetInvoicesByClaimID(_Claim);
			await s1.GetAllClaimVendors();
			SalespersonSplitText1.PercentValue = 50;
			OverheadMultiplierAmountText1.PercentValue = 10;

			foreach (var a in s1.InvoicesList)
				InvoiceCollection.Add(a);

			foreach (DTO_Vendor v in s1.VendorsList)
			{
				VendorList.Add(v);
			}
			foreach (DTO_ClaimVendor cv in s1.ClaimVendorsList)
			{
				ClaimVendorList.Add(cv);
			}

			var ci = new ClaimInvoice();
			ClaimInvoice.I = getInstanceClaimInvoices();
			this.InvoiceTypeList.DataContext = s1.InvoiceTypes;
			this.VendorsList.DataContext = s1.VendorsList;
			this.InvoiceTypeList.ItemsSource = s1.InvoiceTypes;
			this.VendorsList.ItemsSource = s1.VendorsList;
			this.InvoiceDatePicker.SelectedDate = DateTime.Today;
			this.listview.ItemsSource = ci.GetInvoices();
			RoofMeasurmentsPage();
			await PopulateInspection();
		}

		async private void SubmitInvoiceEntry_Click(object sender, RoutedEventArgs e)
		{

			/*
			try
			{
				await s1.GetClaimVendorsByClaimID(Claim);

			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}

				   */


			if ((_Claim != null) && (VendorsList.SelectedIndex > -1) && (InvoiceTypeList.SelectedIndex > -1) && (InvoiceDatePicker.SelectedDate.HasValue) && (textBox_Copy4.Value > 0))
			{
				DTO_ClaimVendor cv = new DTO_ClaimVendor();
				DTO_Vendor vendor = new DTO_Vendor();
				// s1.Vendor.VendorID = 7;
				DTO_Invoice i = new DTO_Invoice();

				i.ClaimID = _Claim.ClaimID;
				i.InvoiceTypeID = ((DTO_LU_InvoiceType)InvoiceTypeList.SelectedValue).InvoiceTypeID;
				i.VendorID = ((DTO_Vendor)VendorsList.SelectedValue).VendorID;
				if (i.InvoiceTypeID == this.invoice.InvoiceTypeID)
					if (MessageBoxResult.Yes == System.Windows.MessageBox.Show("This type of invoice already exist for this claim would you like to replace the old invoice with this one? If you would like to add this to the total already in the system press 'No' and then yes on the following prompt.", "Invoice Type Exists", MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
					{
						if (MessageBoxResult.Yes == System.Windows.MessageBox.Show("If you would like to add this to the total already in the system press 'Yes' .", "Invoice Type Exists", MessageBoxButton.YesNo, MessageBoxImage.Question))
						{
							i = invoice;
							i.InvoiceAmount += (double)textBox_Copy4.Value;
						}
					}
					else
						i.InvoiceAmount = (double)textBox_Copy4.Value;
				i.InvoiceDate = (DateTime)InvoiceDatePicker.SelectedDate;
				i.Paid = true;

				try
				{
					await s1.AddInvoice(i);
				}
				catch (Exception ex)
				{

					System.Windows.Forms.MessageBox.Show(ex.ToString());
				}
				cv.VendorID = ((DTO_Vendor)VendorsList.SelectedValue).VendorID;
				cv.ClaimID = _Claim.ClaimID;
				cv.ServiceTypeID = ((DTO_LU_InvoiceType)InvoiceTypeList.SelectedValue).InvoiceTypeID;
				try
				{
					await s1.AddClaimVendor(cv);
				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.ToString());

				}

			}
			else System.Windows.Forms.MessageBox.Show("Select a date, Invoice Type, Invoice Amount > 0  and a Vendor");



			if (s1.Invoice.Message == null)
			{
				System.Windows.Forms.MessageBox.Show(s1.Invoice.InvoiceID.ToString());
			}
			else
			{
				System.Windows.Forms.MessageBox.Show(s1.Invoice.Message);
			}

		}



		private async static Task<List<string>> getInspectionDetailsInstance()
		{
			ClaimInspections = await ClaimView.ClaimValues.getInstanceClaimInspections();
			var ClaimInspection = ClaimInspections[0];
			var inspection = new List<string>();
			if (InspectionCheckBoxList == null)
			{

				inspection.Add(ClaimInspection.DrivewayDamage.ToString());
				inspection.Add(ClaimInspection.EmergencyRepair.ToString());
				inspection.Add(ClaimInspection.IceWaterShield.ToString());
				inspection.Add(ClaimInspection.InteriorDamage.ToString());
				inspection.Add(ClaimInspection.Leaks.ToString());
				inspection.Add(ClaimInspection.TearOff.ToString());
				inspection.Add(ClaimInspection.Valley.ToString());
				inspection.Add(ClaimInspection.GutterDamage.ToString());
				inspection.Add(ClaimInspection.LightningProtection.ToString());
				inspection.Add(ClaimInspection.SolarPanels.ToString());
				inspection.Add(ClaimInspection.CoverPool.ToString());
				inspection.Add(ClaimInspection.ExteriorDamage.ToString());
				inspection.Add(ClaimInspection.FurnishPermit.ToString());
				inspection.Add(ClaimInspection.MagneticRollers.ToString());
				inspection.Add(ClaimInspection.ProtectLandscaping.ToString());
				inspection.Add(ClaimInspection.QualityControl.ToString());
				inspection.Add(ClaimInspection.RemoveTrash.ToString());
				inspection.Add(ClaimInspection.Satellite.ToString());
				inspection.Add(ClaimInspection.SkyLights.ToString());
			}
			return inspection;
		}

		bool stringtobool(string str)
		{
			if (str == "true" || str == "TRUE" || str == "True")
				return true;
			else return false;
		}
		private async Task<bool> PopulateInspection()
		{

			//InspectionImages
			//image

			//InspectionCheckBoxList.Add(ClaimInspection.DrivewayDamage.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.EmergencyRepair.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.IceWaterShield.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.InteriorDamage.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.Leaks.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.TearOff.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.Valley.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.GutterDamage.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.LightningProtection.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.SolarPanels.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.CoverPool.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.ExteriorDamage.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.FurnishPermit.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.MagneticRollers.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.ProtectLandscaping.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.QualityControl.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.RemoveTrash.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.Satellite.ToString());
			//InspectionCheckBoxList.Add(ClaimInspection.SkyLights.ToString());


			InspectionCheckBoxList = await getInspectionDetailsInstance();



			inspectionDateDatePicker.SelectedDate = ClaimInspection.InspectionDate;
			emergencyRepairAmountTextBox.Text = ClaimInspection.EmergencyRepairAmount.ToString();
			inspectionIDTextBox.Text = ClaimInspection.InspectionID.ToString();
			roofAgeTextBox.Text = ClaimInspection.RoofAge.ToString();


			drivewayDamageCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[0]);
			emergencyRepairCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[1]);

			iceWaterShieldCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[2]);
			interiorDamageCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[3]);
			leaksCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[4]);

			tearOffCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[5]);
			valleyCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[6]);
			gutterDamageCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[7]);

			lightningProtectionCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[8]);
			solarPanelsCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[9]);
			coverPoolCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[10]);
			exteriorDamageCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[11]);
			furnishPermitCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[12]);
			magneticRollersCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[13]);
			protectLandscapingCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[14]);
			qualityControlCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[15]);
			removeTrashCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[16]);
			satelliteCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[17]);
			skyLightsCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[18]);
			//ImageComments_Copy.Text = "";//edit

			//imagelistBox//


			return true;
		}
		private async Task<List<InspectionImage>> getInspectionImages()
		{
			//await s1.GetClaimDocumentsByClaimID(_Claim);
			await s1.GetAllClaimDocuments();
			var inspectionImages = s1.ClaimDocumentsList.FindAll(x => x.DocTypeID == 2);
			var iil = new List<InspectionImage>();

			foreach (var i in inspectionImages)
			{
				addToWarpPanel((InspectionImage)i);
				InspectionImageList.Add(i.FileName + i.FileExt);

			}
			imagelistBox.DataContext = ClaimView.InspectionImageList;
			return iil;
		}

		private async void addToWarpPanel(InspectionImage ii)
		{


			var vb = new System.Windows.Controls.Viewbox();
			vb.Width = 200;
			vb.Height = 200;
			vb.StretchDirection = StretchDirection.DownOnly;
			var ic = new System.Windows.Controls.Image();
			ic.Width = 200;
			ic.Height = 200;
			ic.Stretch = Stretch.Fill;
			ic.StretchDirection = StretchDirection.DownOnly;
			var img = new BitmapImage();
			img.StreamSource = await ViewDocument(ii.FilePath + ii.FileName + ii.FileExt);

			ic.Source = img;
			vb.Child = ic;
			wp.Children.Add(ic);
		}
		private void CancelInvoiceEntry_Click(object sender, RoutedEventArgs e)
		{
			//CustomerAgreement inspectionspage = new CustomerAgreement();
			//new MRNUIElements.MainWindow().MRNClaimNexusMainFrame.NavigationService.Navigate(inspectionspage);
		}

		private void textBox_Copy4_TextChanged(object sender, TextChangedEventArgs e)
		{

			if (textBox_Copy4.Text == string.Empty) textBox_Copy4.Value = 0;
			if (textBox_Copy4.Text != string.Empty) SubmitInvoiceEntry.IsEnabled = true;

		}

		private void InvoiceDatePicker_CalendarClosed(object sender, RoutedEventArgs e)
		{

		}



		private void textBox_Copy4_GotFocus(object sender, RoutedEventArgs e)
		{
			textBox_Copy4.SelectAll();
		}


		private void comboBox1_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//	InvoiceTypeList.Text = InvoiceTypeList.SelectedValue.ToString();
		}

		private void checkBox1_Checked(object sender, RoutedEventArgs e)
		{
			if (!(bool)checkBox1.IsChecked)
				InitialDrawAmountText.Value = 0;
			else InitialDrawAmountText.Value = 500;
		}

		private void CustomerNameText_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (!string.IsNullOrEmpty(CustomerNameText1_Copy.Text))
				ReceiptAmount5Text1.Value = 125;
			else ReceiptAmount5Text1.Value = 0;

		}

		private void UpgradeCheckAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void OriginalScopeAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
		private async Task<ObservableCollection<DTO_ClaimDocument>> getClaimDocs()
		{

			cdo = await ClaimValues.getInstanceClaimDocuments();
			return cdo;
		}

		async Task<ClaimValues> GetClaimValues()
		{

			var Scopes = ClaimValues.getInstanceClaimScopes();
			var Payments = ClaimValues.getInstanceClaimPayments();
			var Invoices = ClaimValues.getInstanceClaimInvoices();
			var TakeOuts = ClaimValues.getInstanceClaimAdditionalSupplies();
			var BringBacks = ClaimValues.getInstanceClaimSurplusSupplies();
			var Customer = ClaimValues.getInstanceClaimCustomer();
			var Lead = ClaimValues.getInstanceClaimLead();
			var Address = ClaimValues.getInstanceClaimAddress();
			var Measurements = ClaimValues.getInstanceClaimMeasurements();
			var Inspections = ClaimValues.getInstanceClaimInspections();
			var Inspection = ClaimValues.getInstanceClaimInspection();
			var ClaimContacts = ClaimValues.getInstanceClaimContacts();
			cdo = await ClaimValues.getInstanceClaimDocuments();

			try
			{




				await s1.GetAdditionalSuppliesByClaimID(_Claim);
				if (s1.AdditionalSuppliesList != null && s1.AdditionalSuppliesList.Count > 0)
					TakeOuts = s1.AdditionalSuppliesList;
			}


			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{
				await s1.GetClaimContactsByClaimID(_Claim);
				if (s1.ClaimContacts != null)
					await s1.GetCustomerByID(new DTO_Customer { CustomerID = s1.ClaimContacts.CustomerID });
				if (s1.Cust != null)
					ClaimCustomer = s1.Cust;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{
				await s1.GetLeadByLeadID(new DTO_Lead { LeadID = _Claim.LeadID });
				Lead = s1.Lead;

			}
			catch (Exception ex)
			{

				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{

				Inspections = ClaimValues.getInstanceClaimInspections();
				Inspection = Inspections.Result[0];
			}
			catch (Exception ex)
			{

				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{

				await s1.GetPaymentsByClaimID(_Claim);
				if (s1.PaymentsList.Count > 0)
					s1.PaymentsList.ForEach(x => Payments.Add(x));

			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{

				await s1.GetPlanesByInspectionID(Inspection);
				Measurements = s1.PlanesList;
				//System.Windows.Forms.MessageBox.Show(Measurements[0].SquareFootage.ToString());
			}
			catch (Exception ex)
			{
				try
				{
					await s1.GetAllPlanes();
				}
				catch (Exception)
				{

					System.Windows.Forms.MessageBox.Show(ex.ToString());
				}

			}
			try
			{

				await s1.GetInvoicesByClaimID(_Claim);
				if (s1.InvoicesList.Count > 0)
					s1.InvoicesList.ForEach(x => Invoices.Add(x));
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{
				await s1.GetSurplusSuppliesByClaimID(_Claim);
				if (s1.SurplusSuppliesList.Count > 0)
					BringBacks = s1.SurplusSuppliesList;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{
				await s1.GetScopesByClaimID(_Claim);

				if (s1.ScopesList.Exists(x => x.ScopeTypeID == 2))
				{

					Scopes.Add(s1.ScopesList.Single(y => y.ScopeTypeID == 2));
					if (s1.ScopesList.Exists(z => z.ScopeTypeID == 3))
					{
						Scopes.Add(s1.ScopesList.Single(w => w.ScopeTypeID == 3));
						supplementnumberexists = true;
					}

				}

			}


			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{
				double supplementnumber = Scopes[1].Total - Scopes[0].Total;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{

				if (s1.ClaimContacts.SupervisorID != null)
				{
					await s1.GetEmployeeByID(new DTO_Employee { EmployeeID = (int)s1.ClaimContacts.SupervisorID });
					if (!string.IsNullOrEmpty(s1.Employee.FirstName) || !string.IsNullOrEmpty(s1.Employee.LastName))
						SupervisorNameText.Text = s1.Employee.FirstName + s1.Employee.LastName;

				}
				else SupervisorNameText.Text = "No Supervisor assigned";
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{
				await s1.GetEmployeeByID(new DTO_Employee { EmployeeID = (int)s1.ClaimContacts.SalesPersonID });
				if (!string.IsNullOrEmpty(s1.Employee.FirstName) || !string.IsNullOrEmpty(s1.Employee.LastName))
					SalespersonName1.Text = s1.Employee.FirstName + s1.Employee.LastName;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{
				await s1.GetEmployeeByID(new DTO_Employee { EmployeeID = (int)s1.ClaimContacts.SalesManagerID });
				if (!string.IsNullOrEmpty(s1.Employee.FirstName) || !string.IsNullOrEmpty(s1.Employee.LastName))
					RecruiterText1.Text = s1.Employee.FirstName + s1.Employee.LastName;
				//await s1.GetClaimByClaimID(_Claim);
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{

				await s1.GetLeadByLeadID(new DTO_Lead { LeadID = _Claim.LeadID });

			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{
				var csz = new AddressZipcodeValidation();
				await s1.GetAddressByID(new DTO_Address { AddressID = (int)_Claim.PropertyID });
				CustomerAddressText1.Text = s1.Address1.Address;
				ZipcodeText1.Text = csz.CityStateLookupRequest(s1.Address1.Zip, 1);
			}
			catch (Exception)
			{
				try
				{
					await s1.GetAddressByID(new DTO_Address { AddressID = (int)_Claim.BillingID });
				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.ToString());
				}

			}
			try
			{
				if (Lead.CreditToID != null)
				{
					if (Lead.CreditToID == _Claim.LeadID)
					{
						try
						{
							await s1.GetEmployeeByID(new DTO_Employee { EmployeeID = (int)_Claim.LeadID });
						}
						catch (Exception ex)
						{
							System.Windows.Forms.MessageBox.Show(ex.ToString());
						}
						try
						{
							if (!string.IsNullOrEmpty(s1.Employee.FirstName) || !string.IsNullOrEmpty(s1.Employee.LastName))
								ReferralKnockerText1.Text = s1.Employee.FirstName + s1.Employee.LastName;
						}
						catch (Exception ex)
						{
							System.Windows.Forms.MessageBox.Show(ex.ToString());
						}
					}
					else if (Lead.CreditToID != s1.Claim.LeadID)
					{
						try
						{
							await s1.GetReferrerByID(new DTO_Referrer { ReferrerID = (int)Lead.CreditToID });
							ReferralKnockerText1.Text = s1.Referrer.FirstName + s1.Referrer.LastName;
						}
						catch (Exception ex)
						{
							System.Windows.Forms.MessageBox.Show(ex.ToString());
						}
					}

				}
				else ReferralKnockerText1.Text = "No Knock/Ref";
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{
				List<decimal> checks = new List<decimal>();
				checks.Add((decimal)((DTO_Payment)Payments.Single(x => x.PaymentDescriptionID == 1)).Amount);
				checks.Add((decimal)((DTO_Payment)Payments.Single(x => x.PaymentDescriptionID == 2)).Amount);
				checks.Add((decimal)((DTO_Payment)Payments.Single(x => x.PaymentDescriptionID == 3)).Amount);
				checks.Add((decimal)((DTO_Payment)Payments.Single(x => x.PaymentDescriptionID == 4)).Amount);
				checks.Add((decimal)((DTO_Payment)Payments.Single(x => x.PaymentDescriptionID == 5)).Amount);
				//Payments
				FirstCheckAmountText1.Value = checks[0];
				SupplementCheckAmountText1.Value = checks[1];
				DepreciationAmountText1.Value = checks[2];
				DeductibleCheckAmountText1.Value = checks[3];
				UpgradeCheckAmountText1.Value = checks[4];
				pay = checks;
				//Invoices
				List<decimal> invoices = new List<decimal>();
				invoices.Add((decimal)((DTO_Invoice)Invoices.Single(x => x.InvoiceTypeID == 2)).InvoiceAmount);
				invoices.Add((decimal)((DTO_Invoice)Invoices.Single(x => x.InvoiceTypeID == 3)).InvoiceAmount);
				invoices.Add((decimal)((DTO_Invoice)Invoices.Single(x => x.InvoiceTypeID == 1)).InvoiceAmount);
				invoices.Add((decimal)((DTO_Invoice)Invoices.Single(x => x.InvoiceTypeID == 4)).InvoiceAmount);
				invoices.Add((decimal)((DTO_Invoice)Invoices.Single(x => x.InvoiceTypeID == 5)).InvoiceAmount);
				GutterBillAmountText1.Value = invoices[0];
				InteriorBillAmountText1.Value = invoices[1];
				ExteriorBillAmountText1.Value = invoices[2];
				RoofLaborBillAmountText1.Value = invoices[3];
				MaterialBillAmountText1.Value = invoices[4];
				inv = invoices;
				//overhead		
				double forgiveness = 0;
				forgiveness = Scopes[1].Total;
				if ((bool)InteriorForgiven.IsChecked)
					forgiveness -= (double)InteriorBillAmountText1.Value;
				if ((bool)ExteriorForgiven.IsChecked)
					forgiveness -= (double)ExteriorBillAmountText1.Value;
				if ((bool)GutterForgiven.IsChecked)
					forgiveness -= (double)GutterBillAmountText1.Value;



				OverheadAmountText1.Value = (decimal)((double)forgiveness * ((double)OverheadMultiplierAmountText1.PercentValue * .1));
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			try
			{
				//time to do math
				if (ReceiptAmount5Text1.Value != null)
					inv.Add((decimal)ReceiptAmount5Text1.Value);
				if (ReceiptAmount4Text1.Value != null)
					inv.Add((decimal)ReceiptAmount4Text1.Value);
				if (ReceiptAmount3Text1.Value != null)
					inv.Add((decimal)ReceiptAmount3Text1.Value);
				if (ReceiptAmount2Text1.Value != null)
					inv.Add((decimal)ReceiptAmount2Text1.Value);
				if (ReceiptAmount1Text1.Value != null)
					inv.Add((decimal)ReceiptAmount1Text1.Value);
				if (BringBackAmountText1.Value != null)
					inv.Add((decimal)BringBackAmountText1.Value);
				//await s1.GetSumOfPaymentsByClaimID(_Claim);
				//await s1.GetSumOfInvoicesByClaimID(_Claim);
				double totcollect = (double)pay.Sum();
				double totexpense = (double)inv.Sum();
				AmountCollectedSubTotal1.Value = (decimal)totcollect;
				TotalAmountCollectedText1.Value = (decimal)totcollect;
				SalespersonSplitText1.PercentValue = 50;

				double profit = totcollect - totexpense;
				if (OverheadAmountText1.Value != null)
					profit -= (double)OverheadAmountText1.Value;
				if (KnockerReferralAmountText1.Value != null)
					profit -= (double)KnockerReferralAmountText1.Value;

				double salessplit = profit * ((double)SalespersonSplitText1.PercentValue * .01);
				double companysplit = profit - salessplit;
				double salessplitsplit = 0;
				if (JobSplit == true)
					salessplitsplit = salessplit * .5;
				SalespersonAmountDueText1.Value = (decimal)salessplit;
				string custname = "";
				if (!String.IsNullOrEmpty(s1.Cust.FirstName))
					custname += s1.Cust.FirstName + " ";
				if (!String.IsNullOrEmpty(s1.Cust.MiddleName))
					custname += s1.Cust.MiddleName + " ";
				if (!String.IsNullOrEmpty(s1.Cust.LastName))
					custname += s1.Cust.LastName;
				if (!String.IsNullOrEmpty(s1.Cust.Suffix))
					custname += " " + s1.Cust.Suffix;

				CustomerNameText.Text = custname;
				ProfitAmountText1.Value = (decimal)profit;
				MRNAmountDueText1.Value = (decimal)companysplit;
				SalespersonSplitAmountText1.Value = (decimal)salessplit;
				if ((bool)TakesFirstChkBox1.IsChecked)
				{
					InitialDrawAmountText1.Value = 500;
					SalespersonSplitAmountText1.Value = (decimal)salessplit - 500;
				}
				else
					SalespersonAmountDueText1.Value = SalespersonSplitAmountText1.Value;

				NumberOfSquaresAmountText1.Value = Measurements[0].SquareFootage / 100;
				BringBackAmountText1.Value = 0;//needs work
				RoofMaterialExpenseSubtotalText1.Value = MaterialBillAmountText1.Value - BringBackAmountText1.Value;
				AmountCollectedSubTotal1.Value = TotalAmountCollectedText1.Value = (decimal)totcollect;
				TotalExpenseText1.Value = (decimal)s1.SumOfInvoices;
				OriginalScopeAmountText1.Value = (decimal)Scopes[0].Total;
				AdjustedRoofSubtotalAmountText1.Value = RoofMaterialExpenseSubtotalText1.Value;
				FinalScopeAmount1.Value = (decimal)Scopes[1].Total;
				SettlementDifferenceAmount1.Value = FinalScopeAmount1.Value - OriginalScopeAmountText1.Value;
				CostPerSquareAmount1.Value = TotalExpenseText1.Value / (decimal)NumberOfSquaresAmountText1.Value;
				ProfitPerSquareAmount1.Value = (decimal)profit / (decimal)NumberOfSquaresAmountText1.Value;
				OverheadAmountText1.Value = (decimal)(((double)FinalScopeAmount1.Value) * (.1d));
				TotalExpenseText1.Value = (decimal)totexpense;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}


			return cvs;

		}

		private void InvoiceTypeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{




		}

		private void ImageComments_Copy_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
		public static ObservableCollection<DTO_ClaimDocument> cdo;



		private void UploadBtn_Copy_Click(object sender, RoutedEventArgs e)
		{

			var cd = new DTO_ClaimDocument();
			cd.ClaimID = _Claim.ClaimID;
			cd.DocumentDate = DateTime.Today;
			cd.DocTypeID = 1;
			cd.DocumentComments= ImageComments_Copy.Text;
			cd.FilePath = System.IO.Path.GetExtension(imagelistBox.SelectedItem.ToString());
			cd.FileName = System.IO.Path.GetExtension(imagelistBox.SelectedItem.ToString());
			cd.FileExt = System.IO.Path.GetExtension(imagelistBox.SelectedItem.ToString());
			//remove item
			CheckToEnableUpload();
		}


		void CheckToEnableUpload()
		{
			if (cdo.Count > 0 && imagelistBox.Items.Count < 1)
				UploadBtn.IsEnabled = true;
			else UploadBtn.IsEnabled = false;
		}

		private void paymentDateDatePicker_Initialized(object sender, EventArgs e)
		{
			paymentDateDatePicker.SelectedDate = DateTime.Today;
		}

		private void OverheadOverride1_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void OverheadOverride1_Unchecked(object sender, RoutedEventArgs e)
		{

		}

		private void RecruiterText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void ReferralKnockerText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void ZipcodeText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void SupervisorNameText_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void checkBox2_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void checkBox2_Unchecked(object sender, RoutedEventArgs e)
		{

		}

		private void NumberOfSquaresAmountText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void MaterialBillAmountText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void BringBackAmountText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void RoofLaborBillAmountText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void ReceiptAmount1Text1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void ReceiptAmount2Text1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void ReceiptAmount3Text1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void ReceiptAmount5Text1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void GutterForgiven_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void InteriorForgiven_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void GutterForgiven_Unchecked(object sender, RoutedEventArgs e)
		{

		}

		private void InteriorForgiven_Unchecked(object sender, RoutedEventArgs e)
		{

		}

		private void ExteriorForgiven_Unchecked(object sender, RoutedEventArgs e)
		{

		}

		private void ExteriorForgiven_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void GutterBillAmountText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void InteriorBillAmountText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void ExteriorBillAmountText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void FirstCheckAmountText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void SupplementCheckAmountText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void DeductibleCheckAmountText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void UpgradeCheckAmountText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void OriginalScopeAmountText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void FinalScopeAmount1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void TakesFirstChkBox1_Unchecked(object sender, RoutedEventArgs e)
		{

		}

		private void SalespersonSplitText1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void SplitOverride1_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void SplitOverride1_Unchecked(object sender, RoutedEventArgs e)
		{

		}

		private void textBox_Copy4_TextChanged_1(object sender, TextChangedEventArgs e)
		{
			if (textBox_Copy4.Value > 0)
				SubmitInvoiceEntry.IsEnabled = true;
			else
				SubmitInvoiceEntry.IsEnabled = false;

		}

		async private void UploadBtn_Click(object sender, RoutedEventArgs e)
		{
			if (cdo.Count > 0)
				foreach (var c in cdo)
				{

					var FullFilePath = "";
					FullFilePath = c.FilePath + c.FileName + c.FileExt;
					await s1.AddClaimDocument(c);


					var file = FullFilePath;

					var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(file);

					onlyFileName = onlyFileName.Replace(" ", "_");
					byte[] imageBytes = System.IO.File.ReadAllBytes(file);
					string ext = System.IO.Path.GetExtension(file);
					DTO_ClaimDocument documentUploadRequest = new DTO_ClaimDocument
					{
						FileBytes = Convert.ToBase64String(imageBytes),
						FileName = onlyFileName,
						FileExt = ext,
						ClaimID = _Claim.ClaimID,
						DocTypeID = 2,
						DocumentDate = DateTime.Today

					};
					try
					{
						await s1.AddClaimDocument(documentUploadRequest);

						if (documentUploadRequest.Message == null)
						{
							System.Windows.Forms.MessageBox.Show("Success");
						}
						//SAVING FILES TO DISK
						//string filename = fileDialog.FileName = @"newfile" + ext;
						//using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
						//{
						//    saveFileDialog1.FileName = filename;
						//    if (System.Windows.Forms.DialogResult.OK != saveFileDialog1.ShowDialog())
						//        return;
						//    System.IO.File.WriteAllBytes(saveFileDialog1.FileName,Convert.FromBase64String(s1.ClaimDocument.FileBytes));
						//}
					}
					catch (Exception ex)
					{
						System.Windows.Forms.MessageBox.Show(ex.ToString());

					}


				}
		}
	}


	public class ClaimInvoice
	{
		public string VendorCompanyName { get; set; }
		public double InvoiceAmount { get; set; }
		public DateTime InvoiceDate { get; set; }
		public string InvoiceType { get; set; }
		private static List<DTO_Invoice> i;
		public static List<DTO_Invoice> I { get { return i; } set { i = value; } }
		public ClaimInvoice()
		{



		}
		public async void init()
		{
			if (!await GetData())
				Thread.Sleep(1);
			async Task<bool> GetData()
			{
				await ServiceLayer.getInstance().GetAllVendors();
				await ServiceLayer.getInstance().GetAllInvoices();

				if (ServiceLayer.getInstance().VendorsList != null && ServiceLayer.getInstance().InvoicesList != null)
					return true;
				return false;
			}
		}
		public ObservableCollection<ClaimInvoice> GetInvoices()
		{
			var a = new ObservableCollection<ClaimInvoice>();
			if (i != null)
				foreach (var invoice in i)
				{
					this.VendorCompanyName = ServiceLayer.getInstance().VendorsList.Find(x => x.VendorID == invoice.VendorID).CompanyName;
					this.InvoiceAmount = invoice.InvoiceAmount;
					this.InvoiceDate = invoice.InvoiceDate;
					this.InvoiceType = ServiceLayer.getInstance().InvoiceTypes.Find(x => x.InvoiceTypeID == invoice.InvoiceTypeID).InvoiceType;


					a.Add(this);
				}
			return a;
		}

	}

}





//}
//}
