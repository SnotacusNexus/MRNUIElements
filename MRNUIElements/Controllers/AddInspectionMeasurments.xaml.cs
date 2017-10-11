using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using static MRNUIElements.Controllers.ClaimView;
using MRNNexus_Model;
namespace MRNUIElements.Controllers
{
	/// <summary>
	/// Interaction logic for AddInspectionMeasurments.xaml
	/// </summary>
	public partial class AddInspectionMeasurments : Page
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		static MRNClaim MrnClaim;
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
		public List<string> Measurements = new List<string>();
		string startsubstring = "Lengths, Areas and Pitches";
		//        List<string> Lststg = new List<string>();
		string latitude = "";
		string longitude = "Longitude = ";
		string PropertyAddressBlockStart = "Online map of property";

		Slider Slider = new Slider();
		public AddInspectionMeasurments(MRNClaim MrnClaim)
		{
			InitializeComponent();
			AddInspectionMeasurments.MrnClaim = MrnClaim;
			_Claim = MrnClaim._claim;
		}
		async void init()
		{

			if (!s1.InspectionsList.Exists(x => x.ClaimID == MrnClaim._claim.ClaimID))
			{
				//Create Inspection to Attach Measurements to


			}
			if (!s1.PlanesList.Exists(x => x.InspectionID == s1.InspectionsList.Find(y => y.ClaimID == MrnClaim._claim.ClaimID).InspectionID)) //we have inspection but no plane data
																																			   //What Type of plane data do we have to import?

				//Is this an EagleView or are we going to do this manually

				//if eagleview and we find it in db
				if (s1.ClaimDocumentsList.Exists(x => x.ClaimID == MrnClaim._claim.ClaimID && x.DocTypeID == 3))
				{
					PDFTextExtractor pdfExtract = new PDFTextExtractor();
					DisplayRecordedClaimDocuments(GetClaimDocument(MrnClaim._claim, 3));
					var client = new HttpClient();
					//var response = client.GetStreamAsync(new Uri((DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 3))))
					//textbox.Text = pdfExtract.Extract(DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 3)), true);
					FillVariables(pdfExtract.Extract(await client.GetStreamAsync(new Uri((DisplayRecordedClaimDocuments(GetClaimDocument(MrnClaim._claim, 3))))), true));
					client.Dispose();
					this.DataContext = this;
					System.Windows.Forms.MessageBox.Show("We found claim." + MrnClaim._claim.ClaimID.ToString());
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
			Measurements.Add(MeasurementList2[1].ToString());//Ridges.Text = 
			Measurements.Add(MeasurementList2[2].ToString());//Hips.Text = 
			Measurements.Add(MeasurementList2[3].ToString());//OrderIceWaterValleys.Text = 
			Measurements.Add(MeasurementList2[4].ToString());//(Rakes.Text = 
			Measurements.Add(MeasurementList2[6].ToString());//Eaves.Text = 
			Measurements.Add(MeasurementList2[7].ToString());//OrderDripEdge.Text = 
			Measurements.Add(MeasurementList2[11].ToString());// TotalAreaOFF.Text =
			 Measurements.Add(MeasurementList2[12].ToString());//PrePitch.Text = 
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
			if (a.Count > 0)
				InspectionMeasurementsGrid.DataContext = a[0];
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
					p.Valley = (int)ValleyMeasurement;
					p.EaveLength = (int)EaveMeasurement;
					p.InspectionID = s1.Inspection.InspectionID;
					//TODO Make this Dynamic
					
					p.NumberDecking = 2;
					p.NumOfLayers = 1;//int.Parse(OrderNoOfLayers.Text)
					p.NumOfLayers = 1;
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

		List<double> dblMeasurements = new List<double>();

		public void DoMath()
		{

			dblMeasurements.Add((long)FigureWaste(Slider.Value, TotalSQFTOFF));// OrderSqShingle.Value = 

			dblMeasurements.Add(FigureRoofNails());//OrderRoofNails.Value = 

			dblMeasurements.Add(FigureRidgevent());//OrderRidgeVent.Value = 

			dblMeasurements.Add(FigurePlasticCaps());//OrderButtonCaps.Value = 

			dblMeasurements.Add(FigureIceAndWater());//OrderIceWater.Value =

			dblMeasurements.Add(FigureHipRidge());//OrderHipandRidge.Value = 

			dblMeasurements.Add(FigureDripedge());//OrderDripEdge.Value = 

			dblMeasurements.Add(FigureStarter());//OrderStarter.Value = 
												 //	if (UnderlaymentCombo.SelectedIndex < 2)
			dblMeasurements.Add(FigureUnderlayment(10));//OrderUnderlayment.Text = .ToString();
			//	else
			//	OrderUnderlayment.Text = FigureUnderlayment(4).ToString();
			dblMeasurements.Add(3d); //OrderPaint.Text =
			dblMeasurements.Add(3d);//OrderCaulk.Text = 

			dblMeasurements.Add((FigureWaste(Slider.Value, TotalSQFTOFF) * (double)60));//InstallerPrice.Text = .ToString()

			dblMeasurements.Add(FigureRoofCost(1, FigureWaste(Slider.Value, TotalSQFTOFF), FigureHipRidge(), FigureStarter(), 1, FigureRidgevent(), 0, FigureUnderlayment(), FigureIceAndWater(), 3, 1, 3, 2, 3, FigureRoofNails(), FigurePlasticCaps(), FigureDripedge()));//VendorPrice.Text = , OrderBrandType.SelectedIndex=1,UnderlaymentCombo.SelectedIndex,.ToString()
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

		private void Prevbutton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Advance1Record_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Decrease1Record_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ImportEagleView_Click(object sender, RoutedEventArgs e)
		{
			//ImportEagleview
		}

		private void PageDecreaseRecords_Click(object sender, RoutedEventArgs e)
		{
			//Make order
			//sender should be MRNRoofOrder and it will generate the Document to send and order roof

		}

		private void PageAdvanceRecords_Click(object sender, RoutedEventArgs e)
		{
			//Adjust Order
		}

		private void UPPlaneGroup_Click(object sender, RoutedEventArgs e)
		{
			//UpArrow
		}
	}
}
