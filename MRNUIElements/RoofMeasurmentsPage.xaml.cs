﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using static MRNUIElements.MainWindow;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MRNNexus_Model;
using static Syncfusion.Windows.Controls.Notification.SfBusyIndicator;

using MRNUIElements.Controllers;


namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for RoofMeasurmentsPage.xaml
	/// </summary>
	public partial class RoofMeasurmentsPage : Page
	{
		static ServiceLayer s = ServiceLayer.getInstance();
		public DTO_Claim claim { get; set; }
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
		public List<DTO_LU_Product> AllProducts { get; set; }
		public DTO_Inspection Inspection { get; set; }
		List<DTO_Plane> Planes = new List<DTO_Plane>();
		public DTO_Plane Plane { get; set; }
		public int PredPitch { get; set; }
		public string googleAddress { get; set; }
		string startsubstring = "Lengths, Areas and Pitches";
		public static List<string> OC = new List<string>();
		public static List<string> Certainteed = new List<string>();
		//        List<string> Lststg = new List<string>();
		string latitude = "";
		string longitude = "Longitude = ";
		string PropertyAddressBlockStart = "Online map of property";
		//    string PropertyAddressBlockEnd = "Directions from MRN Homes of Ga. to this property";
		public RoofMeasurmentsPage(DTO_Claim claim = null)
		{
			if (claim != null)
				this.claim = claim;

			InitializeComponent();
			//	_busyIndicator = ((MainWindow)App.Current.MainWindow).busyIndicator;
			if (claim != null || this.claim != null)
			{

				try
				{



					if (claim == null && this.claim != null)
					{
						claim = this.claim;
					}
					if (s.Claim != null && this.claim == null)
						this.claim = s.Claim;
					GetDialogData(claim);
					Inspection = new DTO_Inspection();
					Plane = new DTO_Plane();
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

		async private Task<bool> DoesMeasurementsExist(DTO_Claim _claim)
		{
			if (_claim == null && claim != null)
				_claim = this.claim;
			else claim = _claim;

			if (s.InspectionsList != null)
				s.InspectionsList = null;
			if (s.PlanesList != null)
				s.PlanesList = null;
			try
			{
				await s.GetAllInspections();
			}
			catch (Exception)
			{
				System.Windows.Forms.MessageBox.Show("Need to add an inspection for the list to have any to find.");
				//TODO add ADD Inspection for claim Here
				//throw;
			}
			try
			{
				await s.GetAllPlanes();
			}
			catch (Exception)
			{

				System.Windows.Forms.MessageBox.Show("Need to add measurements for the list to have any to find.");

				//TODO add AddPlane script here
				try
				{

				}
				catch (Exception Ex)
				{

					throw;
				}

				return false;

				//throw;
			}
			if (s.InspectionsList.Exists(x => x.ClaimID == _claim.ClaimID))
				try
				{
					if (s.Inspection != null)
						s.Inspection = null;

					await s.GetInspectionsByClaimID(_claim);
				}
				catch (Exception)
				{

					System.Windows.Forms.MessageBox.Show("Something went wrong.");
					return false;                                            //throw;
				}



			try
			{
				if (s.PlanesList.Exists(y => y.InspectionID == s.Inspection.InspectionID))
					await s.GetPlanesByInspectionID(s.Inspection);

				else
				{
					System.Windows.Forms.MessageBox.Show("Measurements DO NOT Exist.  We should add them now.");
					return false;
				}
				return true;
			}
			catch (Exception)
			{
				System.Windows.Forms.MessageBox.Show("Measurements DO NOT Exist.  We should add them now.");
				//throw;
				return false;
			}






		}

		//async void ViewDocument(string str, string str2 = null)
		//{
		//	try { 
		//		var web = new System.Net.WebClient();
		//		stream = new MemoryStream(await web.DownloadDataTaskAsync(str));
		//		while (stream == null)
		//			if (_busyIndicator.Visibility == Visibility.Collapsed)
		//				_busyIndicator.Visibility = Visibility.Visible;


		//		_busyIndicator.Visibility = Visibility.Collapsed;
		//	}
		//	catch (Exception ex)
		//	{

		//		System.Windows.Forms.MessageBox.Show(ex.ToString());
		//		throw;
		//	}



		//}


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
			return s.ClaimDocumentsList.Find(x => x.ClaimID == _claim.ClaimID && x.DocTypeID == _claimDocTypeID);

		}
		async private void GetProducts()
		{
			await s.GetProducts();
		}
		async private void GetDialogData(DTO_Claim claim)
		{
			DTO_Claim _claim = new DTO_Claim();
			if (s.Products != null)
				s.Products = null;
			await s.GetProducts();
			//	if(!_busyIndicator.IsVisible)
			//	_busyIndicator.Visibility = Visibility.Visible;
			//	while (s.Products == null)
			//		_busyIndicator.IsBusy=true;
			//	_busyIndicator.Visibility = Visibility.Collapsed;

			if (!string.IsNullOrEmpty(claim.ClaimID.ToString()))
				_claim = claim;
			else if (!string.IsNullOrEmpty(this.claim.ToString()))
				_claim = this.claim;

			else
				System.Windows.Forms.MessageBox.Show("No Claim To Get For Dialog Data.");


			if (await DoesMeasurementsExist(_claim))
			{
				PDFTextExtractor pdfExtract = new PDFTextExtractor();
				DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 3));

				//textbox.Text = pdfExtract.Extract(DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 3)), true);
				//FillVariables(pdfExtract.Extract(DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 3)), true));
				this.DataContext = this;
				System.Windows.Forms.MessageBox.Show("We found claim." + _claim.ClaimID.ToString());
			}

			else
			{
				System.Windows.Forms.MessageBox.Show("We couldn't find a claim associated to gather plane details so we will give you the opportunity to find it yourself.");
				PDFTextExtractor pdfExtract = new PDFTextExtractor();
				var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "PDF Files (*.pdf)|*.pdf" };
				var result = ofd.ShowDialog();
				if (result == false) return;
				//textbox.Text = pdfExtract.Extract(ofd.FileName, true);
				//FillVariables(pdfExtract.Extract(ofd.FileName, true));
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

			foreach (var v in ShingleLineName == null ? s.Products : s.Products.Where(x => x.Name == ShingleLineName))
			{
				products.Add(v.Name + " - " + v.Color);
				colors.Add(v.Color);
			}


			OrderBrandType.ItemsSource = products;
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
			//  stringlist.RemoveAll(s => s.Contains("http://", "+") != true);
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
			DTO_Inspection token = new DTO_Inspection();

			//TODO Try Catch
			//{
			//	await s.GetAllInspections();
			//	if (s.InspectionsList.Exists(x => x.ClaimID == claim.ClaimID))
			//		await s.GetInspectionsByClaimID(claim);



			//	else

			if (s.Inspection == null)
			{

				{
					token.ClaimID = claim.ClaimID;
					token.Comments = "None";
					token.CoverPool = false;
					token.MagneticRollers = true;
					token.InspectionDate = DateTime.Now;
					token.ShingleTypeID = 1;
					token.SkyLights = true;
					token.Leaks = false;
					token.GutterDamage = false;
					token.DrivewayDamage = false;
					token.IceWaterShield = true;
					token.EmergencyRepair = false;
					token.EmergencyRepairAmount = 0;
					token.QualityControl = true;
					token.ProtectLandscaping = true;
					token.RemoveTrash = true;
					token.FurnishPermit = true;
					token.InteriorDamage = false;
					token.ExteriorDamage = false;
					token.RoofAge = 10;
					token.Satellite = false;
					token.TearOff = true;
					token.SolarPanels = false;
					token.RidgeMaterialTypeID = 1;
					token.LightningProtection = false;
					//new PageFunction()

						try
					{
						await s.AddInspection(token);
					}
					catch (Exception ex)
					{
						System.Windows.Forms.MessageBox.Show(ex.ToString());

					}



					//token.ClaimID = result.ClaimID;
					//token.Comments = result.Comments;
					//token.CoverPool = result.CoverPool;
					//token.DrivewayDamage = result.DrivewayDamage;
					//token.EmergencyRepair = result.EmergencyRepair;
					//token.EmergencyRepairAmount = result.EmergencyRepairAmount;
					//token.ExteriorDamage = result.ExteriorDamage;
					//token.FurnishPermit = result.FurnishPermit;
					//token.GutterDamage = result.GutterDamage;
					//token.IceWaterShield = result.IceWaterShield;
					//token.InspectionDate = result.InspectionDate;
					//token.InteriorDamage = result.InteriorDamage;
					//token.Leaks = result.Leaks;
					//token.MagneticRollers = result.MagneticRollers;
					//token.ProtectLandscaping = result.ProtectLandscaping;
					//token.QualityControl = result.QualityControl;
					//token.RemoveTrash = result.RemoveTrash;
					//token.RidgeMaterialTypeID = result.RidgeMaterialTypeID;
					//token.RoofAge = result.RoofAge;
					//token.Satellite = result.Satellite;
					//token.ShingleTypeID = result.ShingleTypeID;
					//token.SkyLights = result.SkyLights;
					//token.SolarPanels = result.SolarPanels;
					//token.TearOff = result.TearOff;
					//token.LightningProtection = result.LightningProtection;
					//token.SuccessFlag = true;
					if (s.Inspection.Message == null)
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
						p.InspectionID = s.Inspection.InspectionID;
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
							await s.AddPlane(p);
						}
						catch (Exception ex)
						{
							System.Windows.Forms.MessageBox.Show(ex.ToString());


						}
						System.Windows.Forms.MessageBox.Show(s.Inspection.InspectionID.ToString());
						if (s.Plane.Message == null)
							System.Windows.Forms.MessageBox.Show(s.Plane.PlaneID.ToString());
						else
							System.Windows.Forms.MessageBox.Show(s.Plane.Message);

					}
					else System.Windows.Forms.MessageBox.Show(s.Inspection.Message);
				}
			//	new DTO_Claim Order({ })
				s.Inspection = null;
				//	}
			}


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
				MessageBox.Show(ex.Message.ToString(), "Custom Error Message");
				throw;
			}
		}



		private void PeekABoo(bool bVisible = false)
		{
			if (!bVisible)
			{

				textBlock.Background = System.Windows.Media.Brushes.White;
				textBlock.Foreground = System.Windows.Media.Brushes.Black;
				canvas.Background = System.Windows.Media.Brushes.White;
				PrintButton.Visibility = Visibility.Hidden;
				Print();
			}
			else
			{
				textBlock.Background = Brushes.Transparent;
				textBlock.Foreground = System.Windows.Media.Brushes.White;
				canvas.Background = System.Windows.Media.Brushes.Transparent;
				PrintButton.Visibility = Visibility.Visible;
			}
		}

		private void Print()
		{
			PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
			var z = OrderCanvas.LayoutTransform;

			OrderCanvas.LayoutTransform = new ScaleTransform(1.62, 1.5);
			Size pageSize = new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight);
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
	}
}
