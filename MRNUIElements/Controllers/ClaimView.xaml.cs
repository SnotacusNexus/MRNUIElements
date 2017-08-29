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
using System.Windows.Forms;
using System.IO;
using static MRNUIElements.Utilities;
using static MRNUIElements.Controllers.UploadDocuments;


using System.ComponentModel;
using PropertyChanged;
using Syncfusion.UI.Xaml.Schedule;
using System.Net.Http;

namespace MRNUIElements.Controllers
{


	[AddINotifyPropertyChangedInterface]
	/// <summary>
	/// Interaction logic for ClaimView.xaml
	/// </summary>
	public partial class ClaimView : Page, INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
		public ObservableCollection<DTO_OrderItem> OrderItem { get; set; }
		public ObservableCollection<BringBacks> adjustmentItems { get; set; }
		public object dTO_ScopeViewSource { get; private set; }
		public object dTO_EScopeViewSource { get; private set; }
		public object dTO_NScopeViewSource { get; private set; }
		public object dTO_LU_ServiceTypesViewSource { get; private set; }
		public object dTO_PlaneViewSource { get; private set; }
		public object dTO_InspectionViewSource { get; private set; }
        public object dTO_InvoiceViewSource { get; private set; }
        public object dTO_PaymentViewSource { get; private set; }
        public object dTO_AddressViewSource { get; private set; }
		static ServiceLayer s1 = ServiceLayer.getInstance();
		static public DTO_Claim _Claim;
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
		public ClaimView(DTO_Claim claim)
		{

			try
			{
				InitializeComponent();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			if (claim != null)
				_Claim = claim;

			//dTO_EScopeViewSource = s1.ScopesList.Find(x => x.ClaimID == _Claim.ClaimID && x.ScopeTypeID == 1);
			//dTO_ScopeViewSource = s1.ScopesList.Find(x => x.ClaimID == _Claim.ClaimID && x.ScopeTypeID == 2);
			//dTO_NScopeViewSource = s1.ScopesList.Find(x => x.ClaimID == _Claim.ClaimID && x.ScopeTypeID == 3);
			dTO_LU_ServiceTypesViewSource = s1.ScopeTypes;
			ralphOS.DataContext = grid1OS.DataContext = dTO_ScopeViewSource = s1.ScopesList.Find(x => x.ClaimID == _Claim.ClaimID && x.ScopeTypeID == 2); 
            ralphNS.DataContext = grid1NS.DataContext = dTO_NScopeViewSource = s1.ScopesList.Find(x => x.ClaimID == _Claim.ClaimID && x.ScopeTypeID == 3);
            ralphE.DataContext = grid1E.DataContext = dTO_EScopeViewSource = s1.ScopesList.Find(x => x.ClaimID == _Claim.ClaimID && x.ScopeTypeID == 1);
            InvoiceTypeList.ItemsSource = s1.InvoiceTypes;
            VendorList.ItemsSource = s1.VendorsList;
			dTO_AddressViewSource = s1.CustomersList.Find(x => x.CustomerID == _Claim.CustomerID);
			CustomerGrid.DataContext = s1.CustomersList.Find(x => x.CustomerID == _Claim.CustomerID);
			Cust_Address.DataContext = s1.AddressesList.Find(x => x.AddressID == _Claim.BillingID);
			Cust_City.DataContext = s1.AddressesList.Find(x => x.AddressID == _Claim.BillingID);
			Cust_State.DataContext = s1.AddressesList.Find(x => x.AddressID == _Claim.BillingID);
			Cust_Zipcode.DataContext = s1.AddressesList.Find(x => x.AddressID == _Claim.BillingID);
			rutroP.DataContext=	ClaimPayments = new ObservableCollection<DTO_Payment>(s1.PaymentsList.FindAll(x => x.ClaimID == _Claim.ClaimID).OrderBy(y => y.PaymentDescriptionID));
				rutro.DataContext=ClaimInvoices = new ObservableCollection<DTO_Invoice>(s1.InvoicesList.FindAll(x => x.ClaimID == _Claim.ClaimID).OrderBy(y => y.InvoiceTypeID));
			listviewP.ItemsSource = s1.PaymentsList.FindAll(x => x.ClaimID == _Claim.ClaimID).OrderBy(y => y.PaymentDescriptionID);
			listview.ItemsSource = s1.InvoicesList.FindAll(x => x.ClaimID == _Claim.ClaimID).OrderBy(y => y.InvoiceTypeID);
			var inspection = new DTO_Inspection();
			if (s1.InspectionsList.Exists(y => y.ClaimID == _Claim.ClaimID))
			{
				InspectionGrid.DataContext = inspection =  s1.InspectionsList.Find(y => y.ClaimID == _Claim.ClaimID);
stkpnl.DataContext = s1.PlanesList.Find(x => x.InspectionID == inspection.InspectionID && x.PlaneTypeID==15);
			}
            GetDialogData(_Claim);
		}
		[AddINotifyPropertyChangedInterface]
		public class ProductTypes : DTO_LU_ProductType, INotifyPropertyChanged
		{

			public string ShingleType { get; set; }


			public static ObservableCollection<ProductTypes> ClaimProductTypes;

			public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
			ServiceLayer s1 = ServiceLayer.getInstance();
			public List<string> ShingleBrands()
			{

				var a = new List<string>();
				a.Add("Owens Corning");
				a.Add("Certainteed");
				return a;
			}

			public List<DTO_LU_ProductType> GetAvailableShingleTypes(string brandselected = "Owens Corning")
			{
				if (brandselected == "Owens Corning")
				{
					return s1.ProductTypes.FindAll(x => x.ProductTypeID > 20);
				}
				else return s1.ProductTypes.FindAll(x => x.ProductTypeID > 20);

			}
		}

		[AddINotifyPropertyChangedInterface]
		public class Products : DTO_LU_Product, INotifyPropertyChanged
		{
			public string ShingleBrand { get; set; }
			public string ShingleType { get; set; }

			public string ShingleColor { get; set; }

			public static ObservableCollection<Product> ClaimProducts;

			public event PropertyChangedEventHandler PropertyChanged;
			ServiceLayer s1 = ServiceLayer.getInstance();
			public List<string> ShingleBrands()
			{

				var a = new List<string>();
				a.Add("Owens Corning");
				a.Add("Certainteed");
				return a;
			}



			public List<DTO_LU_Product> GetAvailableShingleColors(DTO_LU_Product productType = null)
			{
				if (productType != null)
					return s1.Products.FindAll(x => x.ProductTypeID == productType.ProductTypeID);


				return s1.Products.FindAll(x => x.ProductTypeID > 20);


			}

		}




		string DisplayRecordedClaimDocuments(DTO_ClaimDocument _claimDocument, DTO_ClaimDocument _claimDocument2 = null)
		{
			_busyIndicator.Visibility = Visibility.Visible;
			if (_claimDocument != null)
				if (_claimDocument.FileExt == ".pdf" || _claimDocument.FileExt == ".PDF")
				{
					return "http://" + _claimDocument.FilePath + _claimDocument.FileName + _claimDocument.FileExt;
				}
			return null;
		}
		DTO_ClaimDocument GetClaimDocument(DTO_Claim _claim, int _claimDocTypeID)
		{
			return s1.ClaimDocumentsList.Find(x => x.ClaimID == _claim.ClaimID && x.DocTypeID == _claimDocTypeID);

		}
		async private void GetProducts()
		{
			await s1.GetProducts();
		}
		async private void GetDialogData(DTO_Claim claim)
		{
			DTO_Claim _claim = new DTO_Claim();
			if (s1.Products != null)
				s1.Products = null;
			await s1.GetProducts();
			//	if(!_busyIndicator.IsVisible)
			//	_busyIndicator.Visibility = Visibility.Visible;
			//	while (s.Products == null)
			//		_busyIndicator.IsBusy=true;
			//	_busyIndicator.Visibility = Visibility.Collapsed;

			if (!string.IsNullOrEmpty(claim.ClaimID.ToString()))
				_claim = claim;
			else if (!string.IsNullOrEmpty(_Claim.ToString()))
				_claim = _Claim;

			else
				System.Windows.Forms.MessageBox.Show("No Claim To Get For Dialog Data.");

			if(!s1.InspectionsList.Exists(x=>x.ClaimID == _Claim.ClaimID))
			{
				//Create Inspection to Attach Measurements to


			}
			if (!s1.PlanesList.Exists(x => x.InspectionID == s1.InspectionsList.Find(y => y.ClaimID == _Claim.ClaimID).InspectionID)) //we have inspection but no plane data
				//What Type of plane data do we have to import?

			//Is this an EagleView or are we going to do this manually

			//if eagleview and we find it in db
			if(s1.ClaimDocumentsList.Exists(x=> x.ClaimID == _Claim.ClaimID && x.DocTypeID == 3))
			{
				PDFTextExtractor pdfExtract = new PDFTextExtractor();
				DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 3));
				var client = new HttpClient();
				//var response = client.GetStreamAsync(new Uri((DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 3))))
				//textbox.Text = pdfExtract.Extract(DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 3)), true);
				FillVariables(pdfExtract.Extract(await client.GetStreamAsync(new Uri((DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 3))))), true));
				client.Dispose();
				this.DataContext = this;
				System.Windows.Forms.MessageBox.Show("We found claim." + _claim.ClaimID.ToString());
			}

			else
			//we didnt find the ev in database
			{
				System.Windows.Forms.MessageBox.Show("We couldn't find a claim associated to gather plane details so we will give you the opportunity to find it yourself.");
				PDFTextExtractor pdfExtract = new PDFTextExtractor();
				var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "PDF Files (*.pdf)|*.pdf" };
				var result = ofd.ShowDialog();
				if (result == false) return;
				FillVariables(pdfExtract.Extract(new FileStream(ofd.FileName, FileMode.Open), true));
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


			OrderBrandType.ItemsSource = products;
			NewShingleCombo.ItemsSource = colors;
		}
		public List<string> PopulateLists(string str = null)
		{
			if(GetPlaneData(_Claim).Count()>0)
			stkpnl.DataContext = GetPlaneData(_Claim)[0];
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

		public List<DTO_Plane> GetPlaneData(DTO_Claim claim)
		{
			var a = new List<DTO_Plane>();
			if (s1.InspectionsList.Exists(x => x.ClaimID == claim.ClaimID))
			{
				if (s1.PlanesList.Exists(x => x.InspectionID == s1.InspectionsList.Find(y => y.ClaimID == claim.ClaimID).InspectionID))
					foreach (var item in s1.PlanesList.Where(x => x.InspectionID == s1.InspectionsList.Find(y => y.ClaimID == claim.ClaimID).InspectionID))
					{
						a.Add(s1.PlanesList.Find((x => x.InspectionID == s1.InspectionsList.Find(y => y.ClaimID == claim.ClaimID).InspectionID)));
					}
			}
			if(a.Count>0)
			stkpnl.DataContext = a[0];
			return a;
		}
		public async void AddPlaneData()
		{
			DTO_Inspection inspection = new DTO_Inspection();


			if (s1.InspectionsList.Exists(x => x.ClaimID == _Claim.ClaimID))
			{
				inspection = s1.InspectionsList.Find(x => x.ClaimID == _Claim.ClaimID);
				if (!s1.PlanesList.Exists(x => x.InspectionID == inspection.InspectionID) || s1.PlanesList.Exists(x => x.InspectionID == inspection.InspectionID && x.PlaneTypeID != 15))
				{




					DTO_Plane p = new DTO_Plane();


					p.SquareFootage = TotalSQFTOFF;
					p.RidgeLength = (int)RidgeMeasurement;
					p.RakeLength = (int)RakeMeasurement;
					p.Pitch = PredPitch;
					p.Hip = (int)HipMeasurement;
					p.GroupNumber = 1;
					P.Valley = (int)ValleyMeasurement;
					p.EaveLength = (int)EaveMeasurement;
					p.InspectionID = s1.Inspection.InspectionID;
					//TODO Make this Dynamic
					if (!string.IsNullOrEmpty(OrderOSB.Text))
						p.NumberDecking = int.Parse(OrderOSB.Text);
					else p.NumberDecking = 0;
					if (!string.IsNullOrEmpty(OrderNoOfLayers.Text))
						p.NumOfLayers = int.Parse(OrderNoOfLayers.Text);
					else p.NumOfLayers = 1;
					p.ItemSpec = "EV ";
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
		}
		                                               
		public void DoMath()
		{

			OrderSqShingle.Value = (long)FigureWaste(Slider.Value, TotalSQFTOFF);

			OrderRoofNails.Value = FigureRoofNails();

			OrderRidgeVent.Value = FigureRidgevent();

			OrderButtonCaps.Value = FigurePlasticCaps();

			OrderIceWater.Value = FigureIceAndWater();

			OrderHipandRidge.Value = FigureHipRidge();

			OrderDripEdge.Value = FigureDripedge();

			OrderStarter.Value = FigureStarter();
			if (UnderlaymentCombo.SelectedIndex < 2)
				OrderUnderlayment.Text = FigureUnderlayment(10).ToString();
			else
				OrderUnderlayment.Text = FigureUnderlayment(4).ToString();
			OrderPaint.Text = 3.ToString();
			OrderCaulk.Text = 3.ToString(); 

			InstallerPrice.Text = (FigureWaste(Slider.Value, TotalSQFTOFF) * (double)60).ToString();

			VendorPrice.Text = FigureRoofCost(OrderBrandType.SelectedIndex, FigureWaste(Slider.Value, TotalSQFTOFF), FigureHipRidge(), FigureStarter(), UnderlaymentCombo.SelectedIndex, FigureRidgevent(), 0, FigureUnderlayment(), FigureIceAndWater(), 3, 1, 3, 2, 3, FigureRoofNails(), FigurePlasticCaps(), FigureDripedge()).ToString();
		}

		private void Ridges_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void Ridges_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{

		}

		private void Hips_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{

		}

		private void OrderIceWaterValleys_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{

		}

		private void Rakes_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{

		}

		private void Eaves_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{

		}

		private void TotalAreaOFF_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{

		}

        private void Newest_Scope_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Original_Scope_Click(object sender, RoutedEventArgs e)
        {
            UploadImage(7);
           
        }
        static async public void UploadImage(int CDTypeID, string filepathtoupload=null)
        {
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            var result = System.Windows.Forms.DialogResult.OK;
            if (filepathtoupload == null)
            {
                result = fileDialog.ShowDialog();
            }
            else
            {

                switch (result)
                {
                    case System.Windows.Forms.DialogResult.OK:
                        if (filepathtoupload == null)
                            FullFilePath = fileDialog.FileName;
                        else
                            FullFilePath = filepathtoupload;
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
                            DocTypeID = CDTypeID,
                            DocumentDate = DateTime.Today

                        };
                        try
                        {
                            await s1.AddClaimDocument(documentUploadRequest);

                            if (documentUploadRequest.Message != null)
                            {
                                System.Windows.Forms.MessageBox.Show(documentUploadRequest.Message.ToString());
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

                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                    default:

                        break;
                }
            }
        }

        private void AuthorizationOfCommunication_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RoofColorVerification_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SpecialInstructions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AuthorizationOfCommunication_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RoofColorVerification_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SpecialInstructions_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Roof_Inspection1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Gutter_Inspection1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exterior_Inspection1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Interior_Inspection1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Inspection1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exterior_Inspection_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Interior_Inspection_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Inspection_Copy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}



































#region Old code
//}
//public void ClaimOrderAdjustments()
//{
//	adjustmentItems = new ObservableCollection<BringBacks>();
//	InitializeComponent();
//	Task.Run(async () => await getAdditionalSupplies());
//	AdjustmentList.ItemsSource = adjustmentItems;

//}















/*
private async void Button_Click(object sender, RoutedEventArgs e)
{

	var item = (DTO_OrderItem)OrderList.SelectedItem;
	var product = s1.Products.Find(x => x.ProductID == item.ProductID);
	var a = new BringBacks { Cost = (double)QuantityIntBox.Value * product.Price, PickUpDate = DateTime.Today, Items = product.Name, ReceiptImagePath = "", ClaimID = ClaimView._Claim.ClaimID, DropOffDate = DateTime.Today };
	//UploadPhotoOfReceipt
	var b = new DTO_AdditionalSupply { ClaimID = ClaimView._Claim.ClaimID, Cost = a.Cost, DropOffDate = DateTime.Today, ReceiptImagePath = "", Items = product.Name, PickUpDate = DateTime.Today };
	a.Products.Add(item);
	adjustmentItems.Add(a);
	try
	{
		await s1.AddAdditionalSupply(b);
	}
	catch (Exception ex)
	{
		System.Windows.Forms.MessageBox.Show(ex.ToString());
	}
	if (b.Message == null)
		System.Windows.Forms.MessageBox.Show("Successful Upload");
}

private void OrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
	if (OrderList.SelectedItem != null && QuantityIntBox.Value != 0)
		ApplyBtn.IsEnabled = true;
	else ApplyBtn.IsEnabled = false;
}
private void addItem(DTO_OrderItem item)
{
	var product = s1.Products.Find(x => x.ProductID == item.ProductID);
	var a = new BringBacks { Cost = (double)QuantityIntBox.Value * product.Price, PickUpDate = DateTime.Today, Items = product.Name, ReceiptImagePath = "", ClaimID = ClaimView._Claim.ClaimID, DropOffDate = DateTime.Today };
	//UploadPhotoOfReceipt
	var b = new DTO_AdditionalSupply { ClaimID = ClaimView._Claim.ClaimID, Cost = a.Cost, DropOffDate = DateTime.Today, ReceiptImagePath = "", Items = product.Name, PickUpDate = DateTime.Today };
	a.Products.Add(item);
	adjustmentItems.Add(a);

}

private void QuantityIntBox_TextChanged(object sender, TextChangedEventArgs e)
{
	if (OrderList.SelectedItem != null && QuantityIntBox.Value != 0)
		ApplyBtn.IsEnabled = true;
	else ApplyBtn.IsEnabled = false;
}
private async Task<bool> getAdditionalSupplies()
{
	await s1.GetAllAdditionalSupplies();
	if (s1.AdditionalSuppliesList != null)
		if (s1.AdditionalSuppliesList.Count > 0)
			return true;
	return false;
}
*/


//private async Task<bool> AddScope(DTO_Scope _scope)
/*	private async Task<bool> AddScope(DTO_Claim claim, int typescope)*/
/*{


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
					RoofAmount = (double)RoofE.Value,
					ACV = (double)ACVE.Value,
					Depreciation = (double)DepreciationE.Value,
					RCV = (double)totalTextBoxE.Value,
					Accepted = (bool)SettledCheckBoxNS.IsChecked
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
					RoofAmount = (double)RoofOS.Value,
					ACV = (double)ACVOS.Value,
					Depreciation = (double)DepreciationOS.Value,
					RCV = (double)totalTextBoxOS.Value,
					Accepted = (bool)SettledCheckBoxNS.IsChecked
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
					RoofAmount = (double)RoofNS.Value,
					ACV = (double)ACVNS.Value,
					Depreciation = (double)DepreciationNS.Value,
					RCV = (double)totalTextBoxNS.Value,
					Accepted = (bool)SettledCheckBoxNS.IsChecked
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


public void Getem()
{
	try
	{

		//await s1.GetRidgeMaterialTypes();
		//await s1.GetShingleTypes();
		//await s1.GetAllReferrers();
		//	await s1.GetAllInsuranceCompanies();
		try
		{
			foreach (DTO_InsuranceCompany item in s1.InsuranceCompaniesList)
			{
				insco.Add(item);

			}
			InsuranceLU.ItemsSource = insco;
			ridgeMaterialTypeIDTextBox.ItemsSource = s1.RidgeMaterialTypes;
			shingleTypeIDTextBox.ItemsSource = s1.ShingleTypes;
		}
		catch (Exception nex)
		{
			System.Windows.Forms.MessageBox.Show(nex.ToString());
		}
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



private void Button_Click1(object sender, RoutedEventArgs e)
{
	AddClaim();

}

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
	ClaimInspection = (DTO_Inspection)e.Result;
	if (ClaimInspection != null)
		await s1.AddInspection(ClaimInspection);
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
/*
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
		if (ClaimInspection != null)
			await s1.AddInspection(ClaimInspection);



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
	//var s = new Schedule();

	//s.MappedAppointments.Add(new Models.Appointments.MappedAppointment { AddressID = (int)_Claim.BillingID, MappedSubject = "Roof Goes On", MappedLocation = getInstanceClaimAddress().Address, MappedStartTime = order.ScheduledInstallation.Date, MappedEndTime = order.ScheduledInstallation.AddDays(1), MappedNote = order.DateOrdered.ToLongDateString(), LeadID = _Claim.LeadID });
	//Schedule.DataContext = s;

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
		System.Windows.Forms.MessageBox.Show(ex.ToString());
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
GetProducts();
//	_busyIndicator = ((MainWindow)App.Current.MainWindow).busyIndicator;
if (_Claim != null)
{

	try
	{



		GetDialogData();

		SetInspectionPlaneData();
		if (Plane != null)
			Plane = ClaimMeasurements[0];
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


	if (ClaimInspection != null)
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
DTO_ClaimDocument GetClaimDocument(/*DTO_Claim _claim,*/
//	int _claimDocTypeID)
//		{
//			return s1.ClaimDocumentsList.Find(x => x.ClaimID == _Claim.ClaimID && x.DocTypeID == _claimDocTypeID);

//		}

//		void GetShingleBrands()
//		{


//			OrderBrand.ItemsSource = new string[] { "Owens Corning", "Certainteed" };

//			if (OrderBrand.SelectedIndex > -1)
//				GetShingleBrandTypes(OrderBrand.SelectedValue.ToString());

//		}

//		void GetShingleBrandTypes(string Brand = "Owens Corning", int ProductTypeID = 20)
//		{
//			if (Brand == "Owens Corning")
//			{

//				var a = new List<DTO_LU_ProductType>();
//				foreach (var item in s1.ProductTypes.Where(y => y.ProductTypeID > 20))
//					if (!a.Exists(x => x.ProductType == item.ProductType))
//						a.Add(item);
//				OrderBrandType.ItemsSource = a;
//			}
//			else;


//		}
//		void GetShingleColors(string Brand, int ProductTypeID)
//		{
//			if (Brand == "Owens Corning")

//				if (ProductTypeID == 20)
//					NewShingleCombo.ItemsSource = s1.Products.Where(x => x.ProductTypeID > 20).Distinct();
//				else
//					NewShingleCombo.ItemsSource = s1.Products.Where(x => x.ProductTypeID == ProductTypeID).Distinct();
//			else;
//		}
//		private void GetProducts()
//		{

//			InstallerCombo.ItemsSource = (s1.VendorsList.Where(x => x.VendorTypeID == 3));
//			VendorComboBox.ItemsSource = (s1.VendorsList.Where(x => x.VendorTypeID == 2));
//			UnderlaymentCombo.ItemsSource = (s1.Products.Where(x => x.ProductTypeID == 14));



//			DripedgeColorCombo.ItemsSource = s1.Products.Where(x => x.ProductTypeID == 17);
//			GetShingleBrands();
//			//Sitter combo and Sales combo need to be done
//			//	await s1.GetProducts();
//		}
//		async private void GetDialogData(/*DTO_Claim claim*/)
//		{
//			//DTO_Claim _claim = new DTO_Claim();
//			//if (s1.Products != null)
//			//s1.Products = null;
//			//await s1.GetProducts();
//			//	if(!_busyIndicator.IsVisible)
//			//	_busyIndicator.Visibility = Visibility.Visible;
//			//	while (s1.Products == null)
//			//		_busyIndicator.IsBusy=true;
//			//	_busyIndicator.Visibility = Visibility.Collapsed;

//			if (string.IsNullOrEmpty(_Claim.ClaimID.ToString()))
//				System.Windows.Forms.MessageBox.Show("No Claim To Get For Dialog Data.");


//			if (await DoesMeasurementsExist())
//			{
//				var cd = GetClaimDocument(3);
//				PDFTextExtractor pdfExtract = new PDFTextExtractor();
//				try
//				{

//					if (cd != null)
//						//textbox.Text = pdfExtract.Extract(DisplayRecordedClaimDocuments(GetClaimDocument(3)), true);
//						FillVariables(pdfExtract.Extract(await ViewDocument(DisplayRecordedClaimDocuments(GetClaimDocument(3))), true));
//					//DisplayRecordedClaimDocuments(GetClaimDocument(3));
//				}
//				catch (Exception ex)
//				{

//				}

//				this.DataContext = this;
//				//	System.Windows.Forms.MessageBox.Show("We found claim." + _Claim.ClaimID.ToString());
//			}

//			else
//			{
//				System.Windows.Forms.MessageBox.Show("We couldn't find a claim associated to gather plane details so we will give you the opportunity to find it yourself.");
//				PDFTextExtractor pdfExtract = new PDFTextExtractor();
//				var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "PDF Files (*.pdf)|*.pdf" };
//				var result = ofd.ShowDialog();
//				if (result == false) return;
//				textbox.Text = pdfExtract.Extract(await ViewDocument(ofd.FileName), true);
//				FillVariables(pdfExtract.Extract(await ViewDocument(ofd.FileName), true));
//				this.DataContext = this;
//			}




//		}

//		private List<string> products = new List<string>();
//		private List<string> colors = new List<string>();

//		void GatherProducts(DTO_ClaimVendor vid = null, string ShingleLineName = null)
//		{
//			if (products.Count > 0)
//				products.Clear();
//			if (colors.Count > 0)
//				colors.Clear();

//			//foreach (var v in ShingleLineName == null ? s1.Products : s1.Products.Where(x => x.Name == ShingleLineName))
//			//{
//			//	products.Add(v.Name + " - " + v.Color);
//			//	colors.Add(v.Color);
//			//}


//			//OrderBrandType.ItemsSource = s1.Products;
//			//NewShingleCombo.ItemsSource = colors;
//		}
//		public List<string> PopulateLists(string str = null)
//		{
//			List<string> ItemList = new List<string>();
//			ItemList.Clear();



//			return ItemList;
//		}
//		//TODO:    Finish working the selectionlists for shingle
//		//TODO:	   Link NewRoofs Table
//		//TODO:	   GetCurrentClaimFromParent
//		//TODO:    Find and implement another browser to display google maps and implement PDF Viewer to display the pdf created by this for viewing later "Resume Feature"
//		//TODO:	   Update ClaimContacts when ordered
//		//TODO:    Build Order
//		//TODO:	   Add Order
//		//TODO:    Retrieve All info that is available to enable resume feature

//		public List<string> URL(string str)
//		{
//			List<string> UrlList = new List<string>();
//			char[] charseperatorarg = "\r\n".ToCharArray();
//			List<string> stringlist = new List<string>();
//			string w = "";
//			stringlist = str.Split(charseperatorarg, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
//			//  stringlist.RemoveAll(s => s1.Contains("http://", "+") != true);
//			foreach (var l in stringlist)
//			{
//				var stringholder = "";
//				if (l.Contains("http://"))
//					if (w == string.Empty)
//						w = l;
//				stringholder = w + l;
//				if (l.IndexOf("http://maps.google.com/maps?f=g&source=s_q") == 0 ||
//					(l.IndexOf("http://maps.google.com/maps?f=d&source=s_d") != 0 && l.Contains("+")))
//					UrlList.Add(stringholder);
//			}
//			return UrlList;
//		}

//		public double S2D(string str)
//		{
//			double dbl = -1;
//			char[] cleanchar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*(\r\n)+_= \\|}{[\"],';:".ToCharArray();
//			double.TryParse(str.Trim(cleanchar), out dbl);
//			return dbl;
//		}

//		public List<double> FunWithStrings(string str = null, List<string> strarg = null)
//		{
//			char[] charseperatorarg = "=\r\n".ToCharArray();
//			List<string> stringlist = new List<string>();
//			List<double> dblList = new List<double>();
//			try
//			{
//				if (str != null)
//					stringlist = str.Split(charseperatorarg, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
//				else if (strarg != null)
//					stringlist = strarg;
//				else str = " ";

//				foreach (var l in stringlist)
//				{
//					double a = 0;
//					string t = string.Empty;
//					t = l.Trim();

//					if (t.Contains(' '))
//					{
//						t = t.Remove(t.IndexOf(" "));
//					}

//					if (double.TryParse(t, out a))
//						dblList.Add(a);
//					else //if (t.Contains('/') || t.Contains('(') || t.Contains(',') || t.Contains('-'))
//					{
//						if (t.IndexOf('(') > 0)
//							dblList.Add(S2D(t.Remove(t.IndexOf('(')).ToString()));
//						else if (t.IndexOf(',') > 0)
//							dblList.Add(S2D(t.Remove(t.IndexOf(','), 1)));
//						else if (t.IndexOf('/') > 0)
//							dblList.Add(S2D(t.Replace('/', '.')));
//						else if (t.IndexOf('-') > 0)
//							dblList.Add(-1 * S2D(t.Replace('-', ' ')));
//					}
//				}
//				dblList.RemoveAll(dbl => dbl == -1);
//				return dblList;
//			}
//			catch (Exception ex)
//			{
//				System.Windows.Forms.MessageBox.Show(ex.ToString());
//				throw;
//			}

//		}


//		public void FillVariables(string texttoparse)
//		{
//			List<double> MeasurementList2 = new List<double>();
//			List<string> MeasurementList3 = new List<string>();
//			string workingtext = texttoparse.Substring(texttoparse.IndexOf(startsubstring));
//			string propertyaddress = URL(texttoparse.Substring(texttoparse.IndexOf(PropertyAddressBlockStart)))[0];
//			// string directionsaddress = URL(texttoparse.Substring(texttoparse.IndexOf(PropertyAddressBlockStart)))[1];
//			List<double> MeasurementList4 = new List<double>();
//			List<string> MeasurementList5 = new List<string>();
//			MeasurementList2 = FunWithStrings(workingtext);
//			MeasurementList3 = URL(workingtext);
//			List<string> list = MeasurementList3;
//			MeasurementList4 = FunWithStrings(null, list);
//			char[] cleanchar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()+_= \\|}{[\"],';:".ToCharArray();
//			char[] charseperatorarg = "( )=\r\n".ToCharArray();
//			List<string> stringlist1 = new List<string>();
//			List<double> dblList = new List<double>();
//			stringlist1 = workingtext.Split(charseperatorarg, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
//			stringlist1.RemoveAll(c => c.All(char.IsLetter));
//			stringlist1.RemoveAll(c => c == "");
//			MeasurementList5.RemoveAll(s => s == "-1");
//			Ridges.Text = MeasurementList2[1].ToString();
//			Hips.Text = MeasurementList2[2].ToString();
//			OrderIceWaterValleys.Text = MeasurementList2[3].ToString();
//			Rakes.Text = MeasurementList2[4].ToString();
//			Eaves.Text = MeasurementList2[6].ToString();
//			OrderDripEdge.Text = MeasurementList2[7].ToString();
//			TotalAreaOFF.Text = MeasurementList2[11].ToString();
//			PrePitch.Text = MeasurementList2[12].ToString();
//			latitude = MeasurementList2[13].ToString();
//			longitude = MeasurementList2[14].ToString();
//			RidgeMeasurement = S2D(MeasurementList2[1].ToString());
//			HipMeasurement = S2D(MeasurementList2[2].ToString());
//			ValleyMeasurement = S2D(MeasurementList2[3].ToString());
//			RakeMeasurement = S2D(MeasurementList2[4].ToString());
//			EaveMeasurement = S2D(MeasurementList2[6].ToString());
//			StarterMeasurement = S2D(MeasurementList2[7].ToString());
//			TotalSQFTOFF = S2D(MeasurementList2[11].ToString());
//			PredPitch = (int)S2D(MeasurementList2[12].ToString());
//			DoMath();
//		}
//		/// <summary>
//		/// Takes Data in the form usually of string objects has the selector to identify which function to call with the data and 2 other control variables
//		/// </summary>
//		//Show Property On Map      S2D is cleaner string to double converter
//		/// <param name="jlbArg"></param>
//		//jlbArg[0] = latitude               //jlbArg[0] = MRNNumber 
//		//jlbArg[1] = longitude              //jlbArg[1] = Customer Namw  
//		//jlbArg[2] = Zoom                   //jlbArg[2] = Customer Street Address  
//		//jlbArg[9] =  Zipcode 
//		/// <param name="iOutputSelection"></param>
//		/// <param name="bVarible"></param>
//		/// <param name="ivariable"></param>
//		public virtual object GoFetch(int iOutputSelection, double[] dblarg = null, Page page = null, string str = null)
//		{

//			string address = string.Empty;

//			switch (iOutputSelection)
//			{
//				case 1:
//					{
//						NavigationService.Navigate(page);
//						break;
//					}
//				case 2:                 //Show Eagle View        
//					{

//						address = "";

//						break;
//					}
//				case 3:                 //Show Order
//					{
//						address = "";
//						break;
//					}
//				case 4:                 //Show Scope
//					{
//						address = "";
//						break;
//					}
//				case 5:                 //Show Sketch
//					{
//						address = "";
//						break;
//					}
//				case 6:                 //Show Calendar
//					{
//						address = "";
//						break;
//					}
//				case 7:                 //Show Weather
//					{
//						address = "";
//						break;
//					}
//				case 8:                 //Show Authorization Form
//					{
//						address = "";
//						break;
//					}
//				default:                        // Normal thing for this function to perform
//					address = "";
//					break;
//			}
//			StringBuilder sb = new StringBuilder();
//			sb.Clear();


//			return this;
//		}
//		/// <returns></returns>
//		public virtual object GoFetch(string[] jlbArg, int iOutputSelection = 0, bool bVarible = true)
//		{
//			string address = string.Empty;

//			switch (iOutputSelection)
//			{
//				case 1:
//					{
//						OrderCanvas.Visibility = Visibility.Collapsed;
//						textbox.Visibility = Visibility.Collapsed;
//						//AppointmentWebView.Visibility = Visibility.Visible;
//						address = "https://www.google.com/maps/@" + jlbArg[0] + "," + jlbArg[1] + ",+" + jlbArg[2] + "m/data=!3m1!1e3?hl=en";//if satdata true 
//						break;
//					}
//				case 2:                 //Show Eagle View        
//					{

//						address = "";

//						break;
//					}
//				case 3:                 //Show Order
//					{
//						address = "";
//						break;
//					}
//				case 4:                 //Show Scope
//					{
//						address = "";
//						break;
//					}
//				case 5:                 //Show Sketch
//					{
//						address = "";
//						break;
//					}
//				case 6:                 //Show Calendar
//					{
//						address = "";
//						break;
//					}
//				case 7:                 //Show Weather
//					{
//						address = "";
//						break;
//					}
//				case 8:                 //Show Authorization Form
//					{
//						address = "";
//						break;
//					}
//				default:                        // Normal thing for this function to perform
//					address = "";
//					break;
//			}
//			StringBuilder sb = new StringBuilder();
//			sb.Clear();
//			return new Uri(sb.ToString());
//		}
//		async private void SetInspectionPlaneData()
//		{
//			if (ClaimInspection == null)
//			{
//				var inspection = new DTO_Inspection();



//				//TODO Try Catch
//				//{
//				//	await s1.GetAllInspections();
//				//	if (s.InspectionsList.Exists(x => x.ClaimID == claim.ClaimID))
//				//		await s1.GetInspectionsByClaimID(claim);



//				//	else



//				{
//					inspection.ClaimID = _Claim.ClaimID;
//					inspection.Comments = "None";
//					inspection.CoverPool = false;
//					inspection.MagneticRollers = true;
//					inspection.InspectionDate = DateTime.Now;
//					inspection.ShingleTypeID = 1;
//					inspection.SkyLights = true;
//					inspection.Leaks = false;
//					inspection.GutterDamage = false;
//					inspection.DrivewayDamage = false;
//					inspection.IceWaterShield = true;
//					inspection.EmergencyRepair = false;
//					inspection.EmergencyRepairAmount = 0;
//					inspection.QualityControl = true;
//					inspection.ProtectLandscaping = true;
//					inspection.RemoveTrash = true;
//					inspection.FurnishPermit = true;
//					inspection.InteriorDamage = false;
//					inspection.ExteriorDamage = false;
//					inspection.RoofAge = 10;
//					inspection.Satellite = false;
//					inspection.TearOff = true;
//					inspection.SolarPanels = false;
//					inspection.RidgeMaterialTypeID = 1;
//					inspection.LightningProtection = false;


//				}


//				#region Old inspection code

//				//inspection.ClaimID = result.ClaimID;
//				//inspection.Comments = result.Comments;
//				//inspection.CoverPool = result.CoverPool;
//				//inspection.DrivewayDamage = result.DrivewayDamage;
//				//inspection.EmergencyRepair = result.EmergencyRepair;
//				//inspection.EmergencyRepairAmount = result.EmergencyRepairAmount;
//				//inspection.ExteriorDamage = result.ExteriorDamage;
//				//inspection.FurnishPermit = result.FurnishPermit;
//				//inspection.GutterDamage = result.GutterDamage;
//				//inspection.IceWaterShield = result.IceWaterShield;
//				//inspection.InspectionDate = result.InspectionDate;
//				//inspection.InteriorDamage = result.InteriorDamage;
//				//inspection.Leaks = result.Leaks;
//				//inspection.MagneticRollers = result.MagneticRollers;
//				//inspection.ProtectLandscaping = result.ProtectLandscaping;
//				//inspection.QualityControl = result.QualityControl;
//				//inspection.RemoveTrash = result.RemoveTrash;
//				//inspection.RidgeMaterialTypeID = result.RidgeMaterialTypeID;
//				//inspection.RoofAge = result.RoofAge;
//				//inspection.Satellite = result.Satellite;
//				//inspection.ShingleTypeID = result.ShingleTypeID;
//				//inspection.SkyLights = result.SkyLights;
//				//inspection.SolarPanels = result.SolarPanels;
//				//inspection.TearOff = result.TearOff;
//				//inspection.LightningProtection = result.LightningProtection;
//				//inspection.SuccessFlag = true;
//				#endregion
//				try
//				{
//					await s1.AddInspection(inspection);
//				}
//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());

//				}
//				if (s1.Inspection.Message == null)
//				{




//					DTO_Plane p = new DTO_Plane();


//					p.SquareFootage = TotalSQFTOFF;
//					p.RidgeLength = (int)RidgeMeasurement;
//					p.RakeLength = (int)RakeMeasurement;
//					p.Pitch = PredPitch;
//					p.HipValley = (int)HipMeasurement;
//					p.GroupNumber = 1;
//					p.ItemSpec = "EV " + ValleyMeasurement.ToString();
//					p.EaveLength = (int)EaveMeasurement;
//					p.InspectionID = s1.Inspection.InspectionID;
//					//TODO Make this Dynamic
//					if (!string.IsNullOrEmpty(OrderOSB.Text))
//						p.NumberDecking = int.Parse(OrderOSB.Text);
//					else p.NumberDecking = 2;
//					if (!string.IsNullOrEmpty(OrderNoOfLayers.Text))
//						p.NumOfLayers = int.Parse(OrderNoOfLayers.Text);
//					else p.NumOfLayers = 1;

//					p.PlaneTypeID = 15;
//					p.StepFlashing = int.Parse("0");
//					try
//					{
//						await s1.AddPlane(p);
//					}
//					catch (Exception ex)
//					{
//						System.Windows.Forms.MessageBox.Show(ex.ToString());


//					}
//					System.Windows.Forms.MessageBox.Show(s1.Inspection.InspectionID.ToString());
//					if (s1.Plane.Message == null)
//						System.Windows.Forms.MessageBox.Show(s1.Plane.PlaneID.ToString());
//					else
//						System.Windows.Forms.MessageBox.Show(s1.Plane.Message);

//				}
//				else System.Windows.Forms.MessageBox.Show(s1.Inspection.Message);
//			}
//			//	new DTO_Claim Order({ })
//			s1.Inspection = null;
//			//	}
//		}

//		public void GenerateOrder()
//		{
//			var ro = new MRNRoofOrder();

//			//add populate ro.rooforder first
//			ro.roofOrder.ScheduledInstallation = InstallDate.SelectedDate.Value;
//			ro.roofOrder.VendorID = ((DTO_Vendor)InstallerCombo.SelectedItem).VendorID;
//			ro.roofOrder.ClaimID = _Claim.ClaimID;
//			ro.roofOrder.DateDropped = DeliveryDate.SelectedDate.Value;
//			ro.roofOrder.DateOrdered = DateTime.Today;
//			ro.ridgeVent.ProductID =
//			ro.caulk.ProductID = 63;
//			if (!string.IsNullOrEmpty(OrderCaulk.Text))
//				ro.caulk.Quantity = (int)double.Parse(OrderCaulk.Text);
//			if (!string.IsNullOrEmpty(OrderPaint.Text))
//				ro.paint.Quantity = (int)double.Parse(OrderPaint.Text);
//			ro.ridgeVent.Quantity = FigureRidgevent();
//			ro.ridgeShingles.Quantity = FigureHipRidge();
//			ro.plasticCaps.Quantity = FigurePlasticCaps();
//			ro.coilnails.Quantity = FigureRoofNails();
//			ro.primaryshingles.Quantity = (int)FigureWaste(Slider.Value, TotalSQFTOFF) * 3;
//			ro.startershingle.Quantity = FigureStarter();
//			ro.dripedge.Quantity = FigureDripedge();
//			if (!string.IsNullOrEmpty(TurtleBackQuan.Text))
//				ro.turtlebacks.Quantity = (int)double.Parse(TurtleBackQuan.Text);
//			ro.underlayment.Quantity = FigureUnderlayment();
//			ro.valleyunderlayment.Quantity = FigureIceAndWater();
//			ro.ShingleColor = ((DTO_LU_Product)NewShingleCombo.SelectedItem).Color;
//			UnderlaymentCombo.ItemsSource = (s1.Products.Where(x => x.ProductID == 14));
//		}


//		public void DoMath()
//		{



//			OrderSqShingle.Text = FigureWaste(Slider.Value, TotalSQFTOFF).ToString();

//			OrderRoofNails.Text = FigureRoofNails().ToString();

//			OrderRidgeVent.Text = FigureRidgevent().ToString();

//			OrderButtonCaps.Text = FigurePlasticCaps().ToString();

//			OrderIceWater.Text = FigureIceAndWater().ToString();

//			OrderHipandRidge.Text = FigureHipRidge().ToString();

//			OrderDripEdge.Text = FigureDripedge().ToString();

//			OrderStarter.Text = FigureStarter().ToString();
//			if (UnderlaymentCombo.SelectedIndex < 2)
//				OrderUnderlayment.Text = FigureUnderlayment(10).ToString();
//			else
//				OrderUnderlayment.Text = FigureUnderlayment(4).ToString();
//			OrderPaint.Text = "3";
//			OrderCaulk.Text = "3";

//			InstallerPrice.Text = (FigureWaste(Slider.Value, TotalSQFTOFF) * (double)60).ToString();

//			VendorPrice.Text = FigureRoofCost(OrderBrandType.SelectedIndex, FigureWaste(Slider.Value, TotalSQFTOFF), FigureHipRidge(), FigureStarter(), UnderlaymentCombo.SelectedIndex, FigureRidgevent(), 0, FigureUnderlayment(), FigureIceAndWater(), 3, 1, 3, 2, 3, FigureRoofNails(), FigurePlasticCaps(), FigureDripedge()).ToString();
//		}

//		public double FigureRoofCost(int shingletype = 0, double shingleON = 0, int bdlHR = 0, int bdlstart = 0, int ULType = 0, int rv = 0, int tb = 0, int ULRolls = 0, int IandW = 0, int i3n1 = 0, int i4in = 0, int canpt = 0, int OSB = 0, int caulk = 0, int rnail = 0, int pcbuck = 0, int DE = 0)
//		{

//			double EstimatedOCCost = 0;
//			double prvent = 6.50;


//			double pButtonCap = 21.00;
//			double pRNails = 22.00;
//			double pSprayPaint = 5.29;
//			double pCaulk = 4.71;
//			double p31pjb = 4.12;
//			double p4ipjb = 4.12;
//			double pOCHRShingle = 37.50;
//			double pOCStarterShin = 30;
//			double pOCWeatherlockG = 56.71;
//			double pTBSlant = 14.08;
//			double[] OCShingle = { 71.00, 66.00, 65.00, 54.00 };//0=Duration,1=TruDef,2=Oakridge,3=Supreme
//			double[] Underlayment = { 120, 65.00, 32.67 };//0=DeckDefense,1=ProArmor,2=GorillaGuard
//			double pOSB = 11;
//			double taxrate = 1.06;
//			double pDE = 6.5;
//			try
//			{
//				if (shingletype > -1 && shingletype < OCShingle.Count())
//					EstimatedOCCost += (OCShingle[shingletype] * shingleON);
//				else EstimatedOCCost += (OCShingle[1] * shingleON);
//				EstimatedOCCost += bdlHR * pOCHRShingle;
//				EstimatedOCCost += bdlstart * pOCStarterShin;
//				if (ULType > -1 && ULType < Underlayment.Count())
//					EstimatedOCCost += Underlayment[ULType] * ULRolls;
//				else EstimatedOCCost += Underlayment[1] * ULRolls;
//				EstimatedOCCost += tb * pTBSlant;
//				EstimatedOCCost += IandW * pOCWeatherlockG;
//				EstimatedOCCost += rv * prvent;
//				EstimatedOCCost += i3n1 * p31pjb;
//				EstimatedOCCost += i4in * p4ipjb;
//				EstimatedOCCost += canpt * pSprayPaint;
//				EstimatedOCCost += caulk * pCaulk;
//				EstimatedOCCost += rnail * pRNails;
//				EstimatedOCCost += pcbuck * pButtonCap;
//				EstimatedOCCost += pOSB * OSB;
//				EstimatedOCCost += pDE * DE;

//				return EstimatedOCCost * taxrate;
//			}
//			catch (Exception ex)
//			{
//				System.Windows.Forms.MessageBox.Show(ex.ToString());
//				throw;
//			}

//		}


//		public double FigureWaste(double wastefactor = 0, double sqftOff = 0)
//		{
//			if (sqftOff == 0 && wastefactor == 0)
//				return Math.Ceiling((sqftOff + (sqftOff * (Slider.Value * .01))) / 100);
//			else if (sqftOff > 0)
//				return Math.Ceiling((sqftOff + (sqftOff * (Slider.Value * .01))) / 100);
//			else return TotalSQFTOFF / 100;
//		}

//		public int FigureRoofNails()
//		{
//			return (int)Math.Ceiling(FigureWaste(Slider.Value, TotalSQFTOFF) / 16);
//		}

//		public int FigurePlasticCaps()
//		{
//			return (int)Math.Ceiling(FigureWaste(Slider.Value, TotalSQFTOFF) / 20);
//		}

//		public int FigureRidgevent()
//		{
//			if (RidgeMeasurement > 0)
//				return (int)Math.Ceiling(RidgeMeasurement / 4);
//			return 0;
//		}

//		public int FigureUnderlayment(int underlaymentsqroll = 4)
//		{
//			if (underlaymentsqroll > 0)
//				return (int)Math.Ceiling((TotalSQFTOFF / 100) / underlaymentsqroll);
//			return 0;
//		}

//		public int FigureIceAndWater()
//		{
//			if (ValleyMeasurement > 0)
//				return (int)Math.Ceiling(ValleyMeasurement / 62);
//			return 0;
//		}

//		public int FigureHipRidge()
//		{
//			if (HipMeasurement + RidgeMeasurement > 0)
//				return (int)Math.Ceiling((HipMeasurement + RidgeMeasurement) / 25);
//			return 0;
//		}

//		public int FigureStarter()
//		{
//			if (StarterMeasurement > 0)
//				return (int)Math.Ceiling(StarterMeasurement / 100);
//			return 0;
//		}

//		public int FigureDripedge()
//		{
//			if (RakeMeasurement > 0)
//				return (int)Math.Ceiling((RakeMeasurement + (RakeMeasurement * .1)) / 10);
//			return 0;
//		}

//		private void LogOut(object sender, RoutedEventArgs e)
//		{
//			Login Page = new Login();
//			this.NavigationService.Navigate(Page);
//		}

//		private string MakeAddress(string street, string city, string state, string zipcode)
//		{
//			StringBuilder queryaddress = new StringBuilder();
//			if (street != string.Empty)
//			{
//				queryaddress.Append(street + "," + "+");
//			}
//			if (city != string.Empty)
//			{
//				queryaddress.Append(city + "," + "+");
//			}
//			if (state != string.Empty)
//			{
//				queryaddress.Append(state + "," + "+");
//			}
//			if (zipcode != string.Empty)
//			{
//				queryaddress.Append(zipcode + "," + "+");
//			}
//			return queryaddress.ToString();
//		}

//		private void FetchWebsite(string webaddress)
//		{
//			//  AppointmentWebView.Source = new Uri(webaddress.ToString());
//		}

//		private void GetJobInfo(string Latatitude, string longitudestring, string address, string zipcode = "30052", bool b = true)
//		{
//			if (b == true)
//			{
//				FetchWebsite("https://weather.com/weather/today/l/" + zipcode + ":4:US");
//				b = false;
//			}
//			else
//			{
//				ShowOnMap(null, address);
//				b = true;
//			}
//		}

//		private void ShowOnMap(string from = null, string to = null)
//		{
//			//  private void ShowOnMap(int ContentToShow)
//			try
//			{
//				StringBuilder queryaddress = new StringBuilder();
//				queryaddress.Append("http://maps.google.com/maps");
//				queryaddress.Append("/dir/196 Old Loganville Road,Loganville,Georgia,30052/" + to);
//				FetchWebsite(queryaddress.ToString());
//			}
//			catch (Exception ex)
//			{
//				System.Windows.MessageBox.Show(ex.Message.ToString(), "Custom Error Message");
//				throw;
//			}
//		}



//		private void PeekABoo(bool bVisible = false)
//		{
//			if (!bVisible)
//			{

//				textBlockOS.Background = System.Windows.Media.Brushes.White;
//				textBlockOS.Foreground = System.Windows.Media.Brushes.Black;
//				canvas.Background = System.Windows.Media.Brushes.White;
//				PrintButton.Visibility = Visibility.Hidden;
//				Print();
//			}
//			else
//			{
//				textBlockOS.Background = System.Windows.Media.Brushes.Transparent;
//				textBlockOS.Foreground = System.Windows.Media.Brushes.White;
//				canvas.Background = System.Windows.Media.Brushes.Transparent;
//				PrintButton.Visibility = Visibility.Visible;
//			}
//		}

//		private void Print()
//		{
//			System.Windows.Controls.PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
//			var z = OrderCanvas.LayoutTransform;

//			OrderCanvas.LayoutTransform = new ScaleTransform(1.62, 1.5);
//			System.Windows.Size pageSize = new System.Windows.Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight);
//			OrderCanvas.Measure(pageSize);
//			OrderCanvas.Arrange(new Rect(20, 20, pageSize.Width + 20, pageSize.Height + 50));
//			printDlg.PrintVisual(OrderCanvas, "Roof Order #" + MRNNumber);
//			OrderCanvas.LayoutTransform = z;

//			PeekABoo(true);
//		}

//		private void PrintButton_Click(object sender, RoutedEventArgs e)
//		{
//			PeekABoo();
//		}

//		private void button_Click(object sender, RoutedEventArgs e)
//		{
//			NavigationService.Navigate(new RoofMeasurmentsPage(new DTO_Claim()));
//		}

//		private void On_OK(object sender, RoutedEventArgs e)
//		{

//			SetInspectionPlaneData();
//			//NavigationService.Navigate(new NexusHome());

//		}



//		private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
//		{
//			if (TotalSQFTOFF > 0) DoMath();
//		}

//		private void Print_Click(object sender, RoutedEventArgs e)
//		{
//			PeekABoo();
//		}

//		private void PreviousButton_Click(object sender, RoutedEventArgs e)
//		{
//			NavigationService.Navigate(new RoofMeasurmentsPage(new DTO_Claim()));
//		}

//		private void NextButton_Click(object sender, RoutedEventArgs e)
//		{
//			NavigationService.Navigate(new RoofMeasurmentsPage());
//		}

//		private void toggleButton_Checked(object sender, RoutedEventArgs e)
//		{
//			OrderCanvas.Visibility = Visibility.Collapsed;
//			textbox.Visibility = Visibility.Collapsed;
//			//  AppointmentWebView.Visibility = Visibility.Visible;


//		}

//		private void toggleButton_Click(object sender, RoutedEventArgs e)
//		{
//			if (toggleButton.IsChecked == true)
//				toggleButton.IsChecked = false;
//			else toggleButton.IsChecked = true;
//		}

//		private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
//		{
//			OrderCanvas.Visibility = Visibility.Visible;
//			textbox.Visibility = Visibility.Collapsed;
//			// AppointmentWebView.Visibility = Visibility.Collapsed;
//		}

//		private void OrderSqShingle_TextChanged(object sender, TextChangedEventArgs e)
//		{
//			double a = 0;
//			if (double.TryParse(OrderSqShingle.Text, out a))
//			{
//				double dtemp = 0;
//				dtemp = a - (a * (Slider.Value * .01));
//				TotalAreaOFF.Text = dtemp.ToString();

//				DoMath();
//			}
//			else OrderSqShingle.Text = FigureWaste(Slider.Value, TotalSQFTOFF).ToString();
//		}

//		private void View_Order(object sender, RoutedEventArgs e)
//		{
//			OrderCanvas.Visibility = Visibility.Visible;
//			textbox.Visibility = Visibility.Collapsed;
//			//  AppointmentWebView.Visibility = Visibility.Collapsed;
//		}

//		private void SatViewGoogle(object sender, RoutedEventArgs e)
//		{
//			OrderCanvas.Visibility = Visibility.Collapsed;
//			textbox.Visibility = Visibility.Collapsed;
//			// AppointmentWebView.Visibility = Visibility.Visible;
//		}
//		string a = "", b = "";
//		private void OrderBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
//		{




//			if (OrderBrand.SelectedIndex > -1)
//				//	OrderBrandType.ItemsSource = PopulateLists(OrderBrand.SelectedIndex == 1 ? 5 : 0);

//				if (OrderBrand.SelectedValue.ToString() != "Owens Corning")
//					GetShingleBrandTypes("Owens Corning", 20);
//			GetShingleBrandTypes(OrderBrand.SelectedValue.ToString());



//		}

//		private void OrderBrandType_SelectionChanged(object sender, SelectionChangedEventArgs e)
//		{
//			if (OrderBrand.SelectedValue.ToString() != "Owens Corning")
//				GetShingleBrandTypes("Owens Corning", 20);

//			GetShingleColors(OrderBrand.SelectedValue.ToString(), ((DTO_LU_ProductType)OrderBrandType.SelectedItem).ProductTypeID);
//		}

//		private void maskedTextBox_CSZChanged(object sender, TextChangedEventArgs e)
//		{
//			string str = string.Empty;
//			str = maskedTextBoxCustomerCSZ.Text;
//			AddressZipcodeValidation azv = new AddressZipcodeValidation();

//			if (str.All((char.IsNumber)) && str.Count() == 5)
//			{
//				if (azv.CityStateLookupRequest(str) == null)
//				{
//					System.Windows.Forms.MessageBox.Show("No such zipcode!");
//					maskedTextBoxCustomerCSZ.Text = str = string.Empty;
//					return;
//				}
//				string citystate = azv.CityStateLookupRequest(str);

//				string city = citystate.Substring(citystate.IndexOf("<City>") + 6, citystate.IndexOf("</City>") - citystate.IndexOf("<City>") - 6);

//				string state = AddressZipcodeValidation.ConvertStateToAbbreviation(citystate.Substring(citystate.IndexOf("<State>") + 7, citystate.IndexOf("</State>") - citystate.IndexOf("<State>") - 7));
//				CustomerAddressCSZ.Text = CustomerAddress.ToString();
//				string[] w = city.Split(' ');
//				city = "";
//				int i = 0;

//				foreach (string t in w)
//				{
//					city += t.Substring(0, 1).ToUpper();
//					city += t.Substring(1, t.Length - 1).ToLower();
//					if (i > 0)
//						city += " ";

//				}

//				CustomerAddressCSZ.Text = city + ", " + state + "  " + str;
//			}




//		}

//		private void Hips_TextChanged(object sender, TextChangedEventArgs e)
//		{

//			double dbl = 0;
//			double.TryParse(Hips.Text, out dbl);
//			HipMeasurement = dbl;
//			DoMath();
//		}

//		private void Ridges_TextChanged(object sender, TextChangedEventArgs e)
//		{
//			double dbl = 0;
//			double.TryParse(Ridges.Text, out dbl);
//			RidgeMeasurement = dbl;
//			DoMath();
//		}

//		private void OrderIceWaterValleys_TextChanged(object sender, TextChangedEventArgs e)
//		{
//			double dbl = 0;
//			double.TryParse(OrderIceWaterValleys.Text, out dbl);
//			ValleyMeasurement = dbl;
//			DoMath();
//		}

//		private void Rakes_TextChanged(object sender, TextChangedEventArgs e)
//		{
//			double dbl = 0;
//			double.TryParse(Rakes.Text, out dbl);
//			RakeMeasurement = dbl;
//			DoMath();
//		}

//		private void Eaves_TextChanged(object sender, TextChangedEventArgs e)
//		{
//			double dbl = 0;
//			double.TryParse(Eaves.Text, out dbl);
//			EaveMeasurement = dbl;

//			DoMath();
//		}

//		private void InstallerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
//		{

//		}

//		private void TotalAreaOFF_TextChanged(object sender, TextChangedEventArgs e)
//		{
//			double dbl = 0;
//			double.TryParse(TotalAreaOFF.Text, out dbl);
//			TotalSQFTOFF = dbl;
//			DoMath();
//		}
//		private void addImagesbutton_Click(object sender, RoutedEventArgs e)
//		{
//			imagelistBox.ItemsSource = SelectFile(2);
//		}

//		private void nextImageBtn_Click(object sender, RoutedEventArgs e)
//		{
//			imagelistBox.SelectedIndex++;
//		}

//		private void deleteImageButtonbutton_Click(object sender, RoutedEventArgs e)
//		{
//			image.Source = null;
//			imagelistBox.Items.RemoveAt(imagelistBox.SelectedIndex);
//		}

//		private void imagelistBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
//		{
//			image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(imagelistBox.SelectedValue.ToString());
//		}
//		private List<string> SelectFile(int docTypeID)
//		{
//			var fileDialog = new System.Windows.Forms.OpenFileDialog();
//			if (docTypeID == 2)
//				fileDialog.Multiselect = true;
//			else
//				fileDialog.Multiselect = false;
//			fileDialog.Title = "Inspection Image Import Tool";
//			fileDialog.Filter = Filter(docTypeID);
//			var result = fileDialog.ShowDialog();
//			if (result == DialogResult.OK)
//			{
//				//FullFilePath = fileDialog.FileName;
//				foreach (string s in fileDialog.FileNames)
//				{

//					FileNames.Add(s);
//				}
//				imagelistBox.ItemsSource = FileNames;
//				imagelistBox.SelectedIndex = 0;
//			}

//			return FileNames;
//		}
//		List<string> FileNames = new List<string>();
//		string Filter(int docTypeID)
//		{
//			switch (docTypeID)
//			{
//				case 2:
//					return "All Image Types (*.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png) | *.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png";

//				default:
//					return "All Image Types (*.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png) | *.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png | All Document Types (*.pdf;*.doc;*.docx;*.txt;*.xml) | *.pdf;*.doc;*.docx;*.txt;*.xml| All File Types(*.*) | *.*";

//			}




//			//		}
//			//		public async Task<List<string>> Roofers()
//			//		{
//			//			if (s1.VendorsList == null)
//			//				await s1.GetAllVendors();
//			//			var roofers = new List<string>();
//			//			foreach (var t in s1.VendorsList.Where(x => x.VendorTypeID == 3))
//			//				roofers.Add(t.CompanyName);
//			//			return roofers;
//			//		}

//			//		protected BitmapImage DisplayImage(ImageSource imgsrc)
//			//		{

//			//			return (BitmapImage)new ImageSourceConverter().ConvertFrom(imgsrc);


//			//		}




//			//		//public void DisplayPayment(DTO_Payment payment)
//			//		//{
//			//		//	PaymentAmount.Value = (decimal)payment.Amount;
//			//		//	SetPaymentTypeID(payment.PaymentDescriptionID);
//			//		//	PaymentDatePicker.SelectedDate = payment.PaymentDate;
//			//		//}

//			//		private void OnInit(int DocTypeId)
//			//		{
//			//			try
//			//			{
//			//				if (Payments.Count() > 0)
//			//					Payments.Clear();

//			//				s1.PaymentsList.FindAll(y => y.ClaimID == _Claim.ClaimID).ForEach(x => Payments.Add(x));


//			//			}
//			//			catch (Exception ex)
//			//			{
//			//				System.Windows.MessageBox.Show("Payment Date Error Code " + PaymentDatePicker.Text + "-" + _Claim.ToString() + "--" + PaymentDescriptionID + " Report this error to IT Dept." + "\r\n" + ex.ToString());

//			//			}

//			//		}

//			#region UtilityFunctions

//			public bool CheckFileExist(int cdt = 0)
//			{                                                           //the worker function to callback after determining if the file exists in the location that has been picked if so it will ask what would you like to do with it.

//				if (s1.ClaimDocumentsList.Exists(x => x.DocTypeID == PaymentDescriptionID))
//					return true;
//				else return false;
//			}

//			/// <summary>
//			/// Converts Text True false to Boolean true false
//			/// </summary>
//			/// <param name="str"></param>
//			/// <returns></returns>
//			bool stringtobool(string str)
//			{
//				if (str == "true" || str == "TRUE" || str == "True")
//					return true;
//				else return false;
//			}
//			#endregion


//			#region Invoices
//			DTO_Invoice invoice = new DTO_Invoice();

//			async private void SubmitInvoiceEntry_Click(object sender, RoutedEventArgs e)
//			{

//				/*
//				try
//				{
//					await s1.GetClaimVendorsByClaimID(Claim);

//				}
//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}

//					   */


//				if ((_Claim != null) && (VendorsList.SelectedIndex > -1) && (InvoiceTypeList.SelectedIndex > -1) && (InvoiceDatePicker.SelectedDate.HasValue) && (textBox_Copy4.Value > 0))
//				{
//					DTO_ClaimVendor cv = new DTO_ClaimVendor();
//					DTO_Vendor vendor = new DTO_Vendor();
//					// s1.Vendor.VendorID = 7;
//					DTO_Invoice i = new DTO_Invoice();

//					i.ClaimID = _Claim.ClaimID;
//					i.InvoiceTypeID = ((DTO_LU_InvoiceType)InvoiceTypeList.SelectedValue).InvoiceTypeID;
//					i.VendorID = ((DTO_Vendor)VendorsList.SelectedValue).VendorID;
//					if (i.InvoiceTypeID == this.invoice.InvoiceTypeID)
//						if (MessageBoxResult.Yes == System.Windows.MessageBox.Show("This type of invoice already exist for this claim would you like to replace the old invoice with this one? If you would like to add this to the total already in the system press 'No' and then yes on the following prompt.", "Invoice Type Exists", MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
//						{
//							if (MessageBoxResult.Yes == System.Windows.MessageBox.Show("If you would like to add this to the total already in the system press 'Yes' .", "Invoice Type Exists", MessageBoxButton.YesNo, MessageBoxImage.Question))
//							{
//								i = invoice;
//								i.InvoiceAmount += (double)textBox_Copy4.Value;
//							}
//						}
//						else
//							i.InvoiceAmount = (double)textBox_Copy4.Value;
//					i.InvoiceDate = (DateTime)InvoiceDatePicker.SelectedDate;
//					i.Paid = true;

//					try
//					{
//						await s1.AddInvoice(i);
//					}
//					catch (Exception ex)
//					{

//						System.Windows.Forms.MessageBox.Show(ex.ToString());
//					}
//					cv.VendorID = ((DTO_Vendor)VendorsList.SelectedValue).VendorID;
//					cv.ClaimID = _Claim.ClaimID;
//					cv.ServiceTypeID = ((DTO_LU_InvoiceType)InvoiceTypeList.SelectedValue).InvoiceTypeID;
//					try
//					{
//						await s1.AddClaimVendor(cv);
//					}
//					catch (Exception ex)
//					{
//						System.Windows.Forms.MessageBox.Show(ex.ToString());

//					}

//				}
//				else System.Windows.Forms.MessageBox.Show("Select a date, Invoice Type, Invoice Amount > 0  and a Vendor");



//				if (s1.Invoice.Message == null)
//				{
//					System.Windows.Forms.MessageBox.Show(s1.Invoice.InvoiceID.ToString());
//				}
//				else
//				{
//					System.Windows.Forms.MessageBox.Show(s1.Invoice.Message);
//				}

//			}

//			private void textBox_Copy4_TextChanged_1(object sender, TextChangedEventArgs e)
//			{
//				if (textBox_Copy4.Value > 0)
//					SubmitInvoiceEntry.IsEnabled = true;
//				else
//					SubmitInvoiceEntry.IsEnabled = false;

//			}

//			private void listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
//			{
//				VendorsList.Text = ((ClaimInvoice)listview.SelectedItem).VendorCompanyName;
//				textBox_Copy4.Text = ((ClaimInvoice)listview.SelectedItem).InvoiceAmount.ToString();
//				InvoiceDatePicker.SelectedDate = ((ClaimInvoice)listview.SelectedItem).InvoiceDate;
//				InvoiceTypeList.Text = ((ClaimInvoice)listview.SelectedItem).InvoiceType;
//			}


//			private void CancelInvoiceEntry_Click(object sender, RoutedEventArgs e)
//			{
//				//CustomerAgreement inspectionspage = new CustomerAgreement();
//				//new MRNUIElements.MainWindow().MRNClaimNexusMainFrame.NavigationService.Navigate(inspectionspage);
//			}

//			private void textBox_Copy4_TextChanged(object sender, TextChangedEventArgs e)
//			{

//				if (textBox_Copy4.Text == string.Empty) textBox_Copy4.Value = 0;
//				if (textBox_Copy4.Text != string.Empty) SubmitInvoiceEntry.IsEnabled = true;

//			}


//			#region ClaimView


//			async private void InitialDBFunctions()
//			{

//				var VendorList = new List<DTO_Vendor>();

//				var claimValue = await GetClaimValues();

//				SalespersonSplitText1.PercentValue = 50;
//				OverheadMultiplierAmountText1.PercentValue = 10;


//				var ci = new ClaimInvoice();


//				this.InvoiceTypeList.ItemsSource = s1.InvoiceTypes;
//				this.VendorsList.ItemsSource = s1.VendorsList;
//				this.InvoiceDatePicker.SelectedDate = DateTime.Today;

//				RoofMeasurmentsPage();

//				PopulateInspection();
//				ClaimOrderAdjustments();
//			}


//			private void checkBox1_Checked(object sender, RoutedEventArgs e)
//			{
//				if (!(bool)checkBox1.IsChecked)
//					InitialDrawAmountText.Value = 0;
//				else InitialDrawAmountText.Value = -500;
//			}

//			private void CustomerNameText_TextChanged(object sender, TextChangedEventArgs e)
//			{
//				if (!string.IsNullOrEmpty(CustomerNameText1_Copy.Text))
//					ReceiptAmount5Text1.Value = 125;
//				else ReceiptAmount5Text1.Value = 0;

//			}

//			void GetClaimValues()
//			{
//				var Scopes = s1.ScopesList.FindAll(x => x.ClaimID == _Claim.ClaimID);
//				var Payments = s1.PaymentsList.FindAll(x => x.ClaimID == _Claim.ClaimID);
//				var Invoices = s1.InvoicesList.FindAll(x => x.ClaimID == _Claim.ClaimID);
//				var TakeOuts = s1.AdditionalSuppliesList.FindAll(x => x.ClaimID == _Claim.ClaimID);
//				var BringBacks = s1.SurplusSuppliesList.FindAll(x => x.ClaimID == _Claim.ClaimID);
//				//var Customer = getInstanceClaimCustomer();
//				var Leads = s1.LeadsList;
//				var Lead = s1.LeadsList.Find(x => x.LeadID == _Claim.ClaimID);
//				//var Address = getInstanceClaimAddress();
//				var Measurements = s1.PlanesList.FindAll(x => x.InspectionID == s1.InspectionsList.Find(y => y.ClaimID == _Claim.ClaimID).InspectionID);
//				var Inspections = s1.PaymentsList.FindAll(x => x.ClaimID == _Claim.ClaimID);
//				var Inspection = s1.InspectionsList.Find(x => x.InspectionID == s1.InspectionsList.Find(y => y.ClaimID == _Claim.ClaimID).InspectionID);
//				var ClaimContacts = s1.ClaimContactsList.Find(x => x.ClaimID == _Claim.ClaimID);

//				cdo = new ObservableCollection<DTO_ClaimDocument>(s1.ClaimDocumentsList.FindAll(x => x.ClaimID == _Claim.ClaimID && x.DocTypeID == 2));

//				try
//				{




//					//await s1.GetAdditionalSuppliesByClaimID(_Claim);
//					s1.AdditionalSuppliesList.FindAll(x => x.ClaimID == _Claim.ClaimID);
//					if (s1.AdditionalSuppliesList != null && s1.AdditionalSuppliesList.Count > 0)
//						TakeOuts = s1.AdditionalSuppliesList;
//				}


//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{
//					var ClaimCustomer = new DTO_Customer();
//					//await s1.GetClaimContactsByClaimID(_Claim);
//					ClaimContacts = s1.ClaimContactsList.Find(x => x.ClaimID == _Claim.ClaimID);
//					if (s1.ClaimContacts != null)
//						//	await s1.GetCustomerByID(new DTO_Customer { CustomerID = s1.ClaimContacts.CustomerID });
//						ClaimCustomer = s1.CustomersList.Find(x => x.CustomerID == s1.ClaimContacts.CustomerID);

//					//	if (s1.Cust != null)
//					//	ClaimCustomer = s1.Cust;
//				}
//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{
//					//await s1.GetLeadByLeadID(new DTO_Lead { LeadID = _Claim.LeadID });


//					s1.LeadsList.Find(x => x.LeadID == _Claim.LeadID);
//					Lead = s1.Lead;

//				}
//				catch (Exception ex)
//				{

//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{

//					//Inspections = ClaimValues.getInstanceClaimInspections();
//					//Inspection = Inspections.Result[0];
//				}
//				catch (Exception ex)
//				{

//					//	System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{

//					//await s1.GetPaymentsByClaimID(_Claim);
//					if (s1.PaymentsList.Count > 0)
//						s1.PaymentsList.FindAll(y => y.ClaimID == _Claim.ClaimID).ForEach(x => Payments.Add(x as ClaimPayment));

//				}
//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{

//					//	await s1.GetPlanesByInspectionID(Inspection);
//					s1.PlanesList.FindAll(x => x.InspectionID == Inspection.InspectionID);
//					Measurements = s1.PlanesList;
//					//System.Windows.Forms.MessageBox.Show(Measurements[0].SquareFootage.ToString());
//				}
//				catch (Exception ex)
//				{
//					try
//					{

//						System.Windows.Forms.MessageBox.Show("Measurements Error");
//						//await s1.GetAllPlanes();
//					}
//					catch (Exception)
//					{

//						System.Windows.Forms.MessageBox.Show(ex.ToString());
//					}

//				}
//				try
//				{

//					//	await s1.GetInvoicesByClaimID(_Claim);
//					if (s1.InvoicesList.Count > 0)
//					{
//						s1.InvoicesList.FindAll(y => y.ClaimID == _Claim.ClaimID).ForEach(x => Invoices.Add(x));


//					}
//				}
//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{
//					//await s1.GetSurplusSuppliesByClaimID(_Claim);
//					if (s1.SurplusSuppliesList.Count > 0)
//						BringBacks = s1.SurplusSuppliesList.FindAll(x => x.ClaimID == _Claim.ClaimID);
//				}
//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{
//					//	await s1.GetScopesByClaimID(_Claim);

//					if (s1.ScopesList.Exists(x => x.ClaimID == _Claim.ClaimID && x.ScopeTypeID == 2))
//					{

//						Scopes.Add(s1.ScopesList.Single(y => y.ScopeTypeID == 2));
//						if (s1.ScopesList.Exists(z => z.ScopeTypeID == 3))
//						{
//							Scopes.Add(s1.ScopesList.Single(w => w.ScopeTypeID == 3));
//							supplementnumberexists = true;
//						}

//					}

//				}


//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{
//					double supplementnumber = Scopes[1].Total - Scopes[0].Total;
//				}
//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{

//					if (ClaimContacts.SupervisorID != null)
//					{
//						//	await s1.GetEmployeeByID(new DTO_Employee { EmployeeID = (int)s1.ClaimContacts.SupervisorID });
//						var e = new DTO_Employee();
//						e = s1.EmployeesList.FirstOrDefault(x => x.EmployeeID == ClaimContacts.SupervisorID);
//						if (!string.IsNullOrEmpty(e.FirstName) || !string.IsNullOrEmpty(e.LastName))
//							SupervisorNameText.Text = e.FirstName + " " + e.LastName;

//					}
//					else SupervisorNameText.Text = "No Supervisor assigned";
//				}
//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{
//					//await s1.GetEmployeeByID(new DTO_Employee { EmployeeID = (int)s1.ClaimContacts.SalesPersonID });
//					var e = new DTO_Employee();
//					e = s1.EmployeesList.FirstOrDefault(x => x.EmployeeID == ClaimContacts.SalesPersonID);
//					if (!string.IsNullOrEmpty(e.FirstName) || !string.IsNullOrEmpty(e.LastName))
//						SalespersonName1.Text = e.FirstName + " " + e.LastName;
//				}
//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{

//					//await s1.GetEmployeeByID(new DTO_Employee { EmployeeID = (int)s1.ClaimContacts.SalesManagerID });
//					var e = new DTO_Employee();
//					e = s1.EmployeesList.FirstOrDefault(x => x.EmployeeID == ClaimContacts.SalesPersonID);
//					if (!string.IsNullOrEmpty(e.FirstName) || !string.IsNullOrEmpty(e.LastName))
//						RecruiterText1.Text = e.FirstName + " " + e.LastName;
//					//await s1.GetClaimByClaimID(_Claim);
//				}
//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{
//					Lead = Leads.Find(x => x.LeadID == _Claim.LeadID);
//					//await s1.GetLeadByLeadID(new DTO_Lead { LeadID = _Claim.LeadID });

//				}
//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{

//				}
//				catch (Exception)
//				{
//					try
//					{

//					}
//					catch (Exception ex)
//					{
//						System.Windows.Forms.MessageBox.Show(ex.ToString());
//					}

//				}
//				try
//				{
//					if (Leads != null)
//						Lead = Leads.Find(x => x.LeadID == _Claim.LeadID);
//					if (Lead != null)
//					{
//						//await s1.GetAllReferrers();
//						if (Lead.CreditToID != null)
//						{
//							try
//							{
//								if (Lead.CreditToID != null)
//								{
//									if (Lead.CreditToID == s1.CustomersList.Find(x => x.CustomerID == Lead.CreditToID).CustomerID)
//									{
//										try
//										{
//											if (Lead.CreditToID == s1.CustomersList.Find(x => x.CustomerID == Lead.CreditToID).CustomerID)
//												if (!string.IsNullOrEmpty(s1.CustomersList.Find(x => x.CustomerID == Lead.CreditToID).FirstName) || !string.IsNullOrEmpty(s1.CustomersList.Find(x => x.CustomerID == Lead.CreditToID).LastName))
//													ReferralKnockerText1.Text = s1.CustomersList.Find(x => x.CustomerID == Lead.CreditToID).FirstName + " " + s1.CustomersList.Find(x => x.CustomerID == Lead.CreditToID).LastName;
//										}
//										catch (Exception ex)
//										{
//											System.Windows.Forms.MessageBox.Show(ex.ToString());
//										}
//									}

//									else if (s1.ReferrersList != null)
//									{
//										if (Lead.CreditToID == s1.ReferrersList.Find(x => x.ReferrerID == Lead.CreditToID).ReferrerID)
//										{
//											try
//											{
//												var referrer = s1.ReferrersList.Find(x => x.ReferrerID == Lead.CreditToID);
//												if (referrer != null)
//													//await s1.GetReferrerByID(new DTO_Referrer { ReferrerID = (int)Lead.CreditToID });
//													ReferralKnockerText1.Text = referrer.FirstName + referrer.LastName;
//											}
//											catch (Exception ex)
//											{
//												System.Windows.Forms.MessageBox.Show(ex.ToString());
//											}
//										}
//										else ReferralKnockerText1.Text = "No Knock/Ref";
//									}
//									else ReferralKnockerText1.Text = "No Knock/Ref";

//								}
//							}
//							catch (Exception ex)
//							{
//								System.Windows.Forms.MessageBox.Show(ex.ToString());
//							}
//						}
//					}
//					else ReferralKnockerText1.Text = "No Knock/Ref";



//				}
//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{
//					List<decimal> checks = new List<decimal>();
//					ClaimPayments = new ObservableCollection<ClaimPayment>();
//					var PaymentsList = new ObservableCollection<DTO_Payment>(s1.PaymentsList.Where(x => x.ClaimID == _Claim.ClaimID));
//					//	PaymentsList.Add(item);
//					try
//					{
//						foreach (var item in PaymentsList)
//						{
//							var a = new ClaimPayment();

//							a.PaymentDescription = s1.PaymentDescriptions.Find(x => x.PaymentDescriptionID == item.PaymentDescriptionID).PaymentDescription;
//							a.Amount = item.Amount;
//							a.PaymentDate = item.PaymentDate;
//							a.PaymentType = s1.PaymentTypes.Find(x => x.PaymentTypeID == item.PaymentTypeID).PaymentType;
//							ClaimPayments.Add(a);
//						}
//					}
//					catch (Exception ex)
//					{
//						System.Windows.Forms.MessageBox.Show(ex.ToString());
//					}
//					listviewP.ItemsSource = ClaimPayments;

//					checks.Add((decimal)(s1.PaymentsList.Find(x => x.PaymentDescriptionID == 1) as DTO_Payment).Amount);
//					checks.Add((decimal)(s1.PaymentsList.Find(x => x.PaymentDescriptionID == 2) as DTO_Payment).Amount);
//					checks.Add((decimal)(s1.PaymentsList.Find(x => x.PaymentDescriptionID == 3) as DTO_Payment).Amount);
//					checks.Add((decimal)(s1.PaymentsList.Find(x => x.PaymentDescriptionID == 4) as DTO_Payment).Amount);
//					checks.Add((decimal)(s1.PaymentsList.Find(x => x.PaymentDescriptionID == 5) as DTO_Payment).Amount);
//					//Payments
//					FirstCheckAmountText1.Value = checks[0];
//					SupplementCheckAmountText1.Value = checks[1];
//					DepreciationAmountText1.Value = checks[2];
//					DeductibleCheckAmountText1.Value = checks[3];
//					UpgradeCheckAmountText1.Value = checks[4];
//					pay = checks;
//					//Invoices
//					List<decimal> invoices = new List<decimal>();

//					ClaimInvoices = new ObservableCollection<DTO_Invoice>();

//					InvoiceList = new ObservableCollection<DTO_Invoice>(s1.InvoicesList.Where(x => x.ClaimID == _Claim.ClaimID));
//					//	InvoiceList.Add(item);


//					//InvoiceList = new ObservableCollection<DTO_Invoice>(s1.InvoicesCollection.TakeWhile(x => x.ClaimID == 19));
//					try
//					{
//						foreach (var item in InvoiceList)
//						{
//							var a = new ClaimInvoice();

//							a.VendorCompanyName = s1.VendorsList.Find(x => x.VendorID == 7).CompanyName;
//							a.InvoiceAmount = item.InvoiceAmount;
//							a.InvoiceDate = item.InvoiceDate;
//							a.InvoiceType = s1.InvoiceTypes.Find(x => x.InvoiceTypeID == item.InvoiceTypeID).InvoiceType;
//							ClaimInvoices.Add(a);
//						}
//					}
//					catch (Exception ex)
//					{
//						System.Windows.Forms.MessageBox.Show(ex.ToString());
//					}
//					listview.ItemsSource = ClaimInvoices;
//					invoices.Add((decimal)((DTO_Invoice)Invoices.First(x => x.InvoiceTypeID == 2)).InvoiceAmount);
//					invoices.Add((decimal)((DTO_Invoice)Invoices.First(x => x.InvoiceTypeID == 3)).InvoiceAmount);
//					invoices.Add((decimal)((DTO_Invoice)Invoices.First(x => x.InvoiceTypeID == 1)).InvoiceAmount);
//					invoices.Add((decimal)((DTO_Invoice)Invoices.First(x => x.InvoiceTypeID == 4)).InvoiceAmount);
//					invoices.Add((decimal)((DTO_Invoice)Invoices.First(x => x.InvoiceTypeID == 5)).InvoiceAmount);
//					GutterBillAmountText1.Value = invoices[0];
//					InteriorBillAmountText1.Value = invoices[1];
//					ExteriorBillAmountText1.Value = invoices[2];
//					RoofLaborBillAmountText1.Value = invoices[3];
//					MaterialBillAmountText1.Value = invoices[4];
//					inv = invoices;
//					//overhead		
//					double forgiveness = 0;
//					forgiveness = Scopes[1].Total;
//					if ((bool)InteriorForgiven.IsChecked)
//						forgiveness -= (double)InteriorBillAmountText1.Value;
//					if ((bool)ExteriorForgiven.IsChecked)
//						forgiveness -= (double)ExteriorBillAmountText1.Value;
//					if ((bool)GutterForgiven.IsChecked)
//						forgiveness -= (double)GutterBillAmountText1.Value;



//					OverheadAmountText1.Value = (decimal)((double)forgiveness * ((double)OverheadMultiplierAmountText1.PercentValue * .1));
//				}
//				catch (Exception ex)
//				{
//					System.Windows.Forms.MessageBox.Show(ex.ToString());
//				}
//				try
//				{
//				//time to do math
//				if (ReceiptAmount5Text1.Value != null)
//					inv.Add((decimal)ReceiptAmount5Text1.Value);
//				if (ReceiptAmount4Text1.Value != null)
//					inv.Add((decimal)ReceiptAmount4Text1.Value);
//				if (ReceiptAmount3Text1.Value != null)
//					inv.Add((decimal)ReceiptAmount3Text1.Value);
//				if (ReceiptAmount2Text1.Value != null)
//					inv.Add((decimal)ReceiptAmount2Text1.Value);
//				if (ReceiptAmount1Text1.Value != null)
//					inv.Add((decimal)ReceiptAmount1Text1.Value);
//				if (BringBackAmountText1.Value != null)
//					inv.Add((decimal)BringBackAmountText1.Value);
//				//await s1.GetSumOfPaymentsByClaimID(_Claim);
//				//await s1.GetSumOfInvoicesByClaimID(_Claim);
//				double totcollect = (double)pay.Sum();
//				double totexpense = (double)inv.Sum();
//				AmountCollectedSubTotal1.Value = (decimal)totcollect;
//				TotalAmountCollectedText1.Value = (decimal)totcollect;
//				SalespersonSplitText1.PercentValue = 50;

//				double profit = totcollect - totexpense;
//				if (OverheadAmountText1.Value != null)
//					profit -= (double)OverheadAmountText1.Value;
//				if (KnockerReferralAmountText1.Value != null)
//					profit -= (double)KnockerReferralAmountText1.Value;

//				double salessplit = profit * ((double)SalespersonSplitText1.PercentValue * .01);
//				double companysplit = profit - salessplit;
//				double salessplitsplit = 0;
//				if (JobSplit == true)
//					salessplitsplit = salessplit * .5;
//				SalespersonAmountDueText1.Value = (decimal)salessplit;

//				CustomerName.Text = Customer.ToString();
//				CustomerNameText.Text = Customer.ToString();
//				ProfitAmountText1.Value = (decimal)profit;
//				MRNAmountDueText1.Value = (decimal)companysplit;
//				SalespersonSplitAmountText1.Value = (decimal)salessplit;
//				if ((bool)TakesFirstChkBox1.IsChecked)
//				{
//					InitialDrawAmountText1.Value = 500;
//					SalespersonSplitAmountText1.Value = (decimal)salessplit - 500;
//				}
//				else
//					SalespersonAmountDueText1.Value = SalespersonSplitAmountText1.Value;

//				NumberOfSquaresAmountText1.Value = Measurements[0].SquareFootage / 100;
//				BringBackAmountText1.Value = 0;//needs work
//				RoofMaterialExpenseSubtotalText1.Value = MaterialBillAmountText1.Value - BringBackAmountText1.Value;
//				AmountCollectedSubTotal1.Value = TotalAmountCollectedText1.Value = (decimal)totcollect;
//				//TotalExpenseText1.Value = (decimal)s1.SumOfInvoices;
//				OriginalScopeAmountText1.Value = (decimal)Scopes[0].Total;
//				AdjustedRoofSubtotalAmountText1.Value = RoofMaterialExpenseSubtotalText1.Value;
//				FinalScopeAmount1.Value = (decimal)Scopes[1].Total;
//				SettlementDifferenceAmount1.Value = FinalScopeAmount1.Value - OriginalScopeAmountText1.Value;
//				CostPerSquareAmount1.Value = TotalExpenseText1.Value / (decimal)NumberOfSquaresAmountText1.Value;
//				ProfitPerSquareAmount1.Value = (decimal)profit / (decimal)NumberOfSquaresAmountText1.Value;
//				OverheadAmountText1.Value = (decimal)(((double)FinalScopeAmount1.Value) * (.1d));
//				TotalExpenseText1.Value = (decimal)totexpense;
//			}
//			catch (Exception ex)
//			{
//				System.Windows.Forms.MessageBox.Show(ex.ToString());
//			}


////			return cvs;

////		}

////		private void OriginalScopeAmountText_TextChanged(object sender, TextChangedEventArgs e)
////		{

////		}
////		#endregion


////		#region Images
////		private void ImageComments_Copy_TextChanged(object sender, TextChangedEventArgs e)
////		{

////		}




////		#endregion


////		#region Inspections

////		/// <summary>
////		/// Gets inspection details for display
////		/// </summary>
////		/// <param name="str"></param>
////		/// <returns></returns>
////		private static List<string> getInspectionDetailsInstance()
////		{
////			var ClaimInspections = new ObservableCollection<DTO_Inspection>(s1.InspectionsList.FindAll(x => x.ClaimID == _Claim.ClaimID));
////			var ClaimInspection = ClaimInspections[0];
////			List<bool> InspectionCheckBoxList = new List<bool>();
////			var inspection = new List<string>();
////			if (InspectionCheckBoxList == null)
////			{

////				inspection.Add(ClaimInspection.DrivewayDamage.ToString());
////				inspection.Add(ClaimInspection.EmergencyRepair.ToString());
////				inspection.Add(ClaimInspection.IceWaterShield.ToString());
////				inspection.Add(ClaimInspection.InteriorDamage.ToString());
////				inspection.Add(ClaimInspection.Leaks.ToString());
////				inspection.Add(ClaimInspection.TearOff.ToString());
////				inspection.Add(ClaimInspection.Valley.ToString());
////				inspection.Add(ClaimInspection.GutterDamage.ToString());
////				inspection.Add(ClaimInspection.LightningProtection.ToString());
////				inspection.Add(ClaimInspection.SolarPanels.ToString());
////				inspection.Add(ClaimInspection.CoverPool.ToString());
////				inspection.Add(ClaimInspection.ExteriorDamage.ToString());
////				inspection.Add(ClaimInspection.FurnishPermit.ToString());
////				inspection.Add(ClaimInspection.MagneticRollers.ToString());
////				inspection.Add(ClaimInspection.ProtectLandscaping.ToString());
////				inspection.Add(ClaimInspection.QualityControl.ToString());
////				inspection.Add(ClaimInspection.RemoveTrash.ToString());
////				inspection.Add(ClaimInspection.Satellite.ToString());
////				inspection.Add(ClaimInspection.SkyLights.ToString());
////			}
////			return inspection;
////		}




////		/// <summary>
////		/// Populates the inspection form in claimview
////		/// </summary>
////		/// <returns></returns>
////		private bool PopulateInspection()
////		{
////			var ClaimInspection = new DTO_Inspection();

////			//InspectionImages
////			//image


////			var InspectionCheckBoxList = getInspectionDetailsInstance();



////			inspectionDateDatePicker.SelectedDate = ClaimInspection.InspectionDate;
////			emergencyRepairAmountTextBox.Text = ClaimInspection.EmergencyRepairAmount.ToString();
////			inspectionIDTextBox.Text = ClaimInspection.InspectionID.ToString();
////			roofAgeTextBox.Text = ClaimInspection.RoofAge.ToString();


////			drivewayDamageCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[0]);
////			emergencyRepairCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[1]);

////			iceWaterShieldCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[2]);
////			interiorDamageCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[3]);
////			leaksCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[4]);

////			tearOffCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[5]);
////			valleyCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[6]);
////			gutterDamageCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[7]);

////			lightningProtectionCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[8]);
////			solarPanelsCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[9]);
////			coverPoolCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[10]);
////			exteriorDamageCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[11]);
////			furnishPermitCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[12]);
////			magneticRollersCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[13]);
////			protectLandscapingCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[14]);
////			qualityControlCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[15]);
////			removeTrashCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[16]);
////			satelliteCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[17]);
////			skyLightsCheckBox.IsChecked = stringtobool(InspectionCheckBoxList[18]);
////			//ImageComments_Copy.Text = "";//edit

////			//imagelistBox//
////			try
////			{
////				getInspectionImages();
////			}
////			catch (Exception ex)
////			{
////				System.Windows.Forms.MessageBox.Show(ex.ToString());
////			}
////			return true;
////		}
////		private List<InspectionImage> getInspectionImages()
////		{
////			//await s1.GetClaimDocumentsByClaimID(_Claim);
////			//await s1.GetAllClaimDocuments();
////			var inspectionImages = s1.ClaimDocumentsList.FindAll(x => x.DocTypeID == 2);
////			var iil = new List<InspectionImage>();

////			foreach (var i in inspectionImages)
////			{
////				//var a = new InspectionImage() { Comments = i.DocumentComments, Path = i.FilePath + i.FileName + i.FileExt };
////				addToWarpPanel(new InspectionImage() { Comments = i.DocumentComments, Path = "http://" + i.FilePath + i.FileName + i.FileExt });
////				InspectionImageList.Add("http://" + i.FilePath + i.FileName + i.FileExt);

////			}
////			imagelistBox.ItemsSource = InspectionImageList;
////			return iil;
////		}

////		private async void addToWarpPanel(InspectionImage ii)
////		{


////			var vb = new System.Windows.Controls.Viewbox();
////			vb.Width = 200;
////			vb.Height = 200;
////			vb.StretchDirection = StretchDirection.DownOnly;
////			var ic = new System.Windows.Controls.Image();
////			ic.Width = 200;
////			ic.Height = 200;
////			ic.Stretch = Stretch.Fill;
////			ic.StretchDirection = StretchDirection.DownOnly;
////			ic.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(await ViewDocument(ii.Path));
////			vb.Child = ic;
////			wp.Children.Add(vb);
////		}


////		#endregion




////		#region Scopes







////		#endregion
////		#region ClaimDocs
////		private ObservableCollection<DTO_ClaimDocument> getClaimDocs()
////		{


////			return new ObservableCollection<DTO_ClaimDocument>(s1.ClaimDocumentsList.FindAll(x=> x.ClaimID == _Claim.ClaimID));
////		}

////		async private void UploadBtn_Click(object sender, RoutedEventArgs e)
////		{
////			if (cdo.Count > 0)
////				foreach (var c in cdo)
////				{

////					var FullFilePath = "";
////					FullFilePath = c.FilePath + c.FileName + c.FileExt;
////					await s1.AddClaimDocument(c);


////					var file = FullFilePath;

////					var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(file);

////					onlyFileName = onlyFileName.Replace(" ", "_");
////					byte[] imageBytes = System.IO.File.ReadAllBytes(file);
////					string ext = System.IO.Path.GetExtension(file);
////					DTO_ClaimDocument documentUploadRequest = new DTO_ClaimDocument
////					{
////						FileBytes = Convert.ToBase64String(imageBytes),
////						FileName = onlyFileName,
////						FileExt = ext,
////						ClaimID = _Claim.ClaimID,
////						DocTypeID = 2,
////						DocumentDate = DateTime.Today

////					};
////					try
////					{
////						await s1.AddClaimDocument(documentUploadRequest);

////						if (documentUploadRequest.Message == null)
////						{
////							System.Windows.Forms.MessageBox.Show("Success");
////						}
////						//SAVING FILES TO DISK
////						//string filename = fileDialog.FileName = @"newfile" + ext;
////						//using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
////						//{
////						//    saveFileDialog1.FileName = filename;
////						//    if (System.Windows.Forms.DialogResult.OK != saveFileDialog1.ShowDialog())
////						//        return;
////						//    System.IO.File.WriteAllBytes(saveFileDialog1.FileName,Convert.FromBase64String(s1.ClaimDocument.FileBytes));
////						//}
////					}
////					catch (Exception ex)
////					{
////						System.Windows.Forms.MessageBox.Show(ex.ToString());

////					}


////				}
////		}

////		public static ObservableCollection<DTO_ClaimDocument> cdo;



////		private void UploadBtn_Copy_Click(object sender, RoutedEventArgs e)
////		{

////			var cd = new DTO_ClaimDocument();
////			cd.ClaimID = _Claim.ClaimID;
////			cd.DocumentDate = DateTime.Today;
////			cd.DocTypeID = 1;
////			cd.DocumentComments = ImageComments_Copy.Text;
////			cd.FilePath = System.IO.Path.GetExtension(imagelistBox.SelectedItem.ToString());
////			cd.FileName = System.IO.Path.GetExtension(imagelistBox.SelectedItem.ToString());
////			cd.FileExt = System.IO.Path.GetExtension(imagelistBox.SelectedItem.ToString());
////			//remove item
////			CheckToEnableUpload();
////		}


////		void CheckToEnableUpload()
////		{
////			if (cdo.Count > 0 && imagelistBox.Items.Count < 1)
////				UploadBtn.IsEnabled = true;
////			else UploadBtn.IsEnabled = false;
////		}


////		#endregion

////	}
////}
#endregion