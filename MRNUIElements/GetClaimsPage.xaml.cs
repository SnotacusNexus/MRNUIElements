using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Web.ClientServices;
using System.Web.ApplicationServices;
using System.Web.UI;
using System.Net.Http.Handlers;
using System.IO;
using MRNNexus_Model;
using MRNUIElements.Controllers;
using MRNUIElements.Controllers.Collection;
using static MRNUIElements.PaymentEntryPage;
using static MRNUIElements.InvoicePage;
using System.Drawing;
using System.Threading;
using MRNNexus_Model;
namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for GetClaimsPage.xaml
	/// </summary>
	public partial class GetClaimsPage : System.Windows.Controls.Page
	{
		const int ESTIMATE = 1;
		const int OLDSCOPE = 2;
		const int NEWSCOPE = 3;
		static Frame F;
		static GetClaimsPage G;
		static ObservableCollection<DTO_ClaimDocument> CDC;
		static ObservableCollection<DTO_ClaimDocument> ClaimDocsCollection = new ObservableCollection<DTO_ClaimDocument>();
		public static DTO_Payment payment = new DTO_Payment();
		public static DTO_Invoice invoice = new DTO_Invoice();
		public static List<DTO_Invoice> InvoiceList = new List<DTO_Invoice>();
		static ServiceLayer s1 = ServiceLayer.getInstance();

		public static string FullFilePath { get; set; }
		public ClaimData ClaimData { get; set; }
		public static int ClaimDocTypeID { get; set; }
		public bool EditData { get; set; }
		public static string statusText { get; set; }

		public static readonly DependencyProperty statusTextProperty = DependencyProperty.Register("statusText", typeof(string), typeof(GetClaimsPage), new UIPropertyMetadata(string.Empty));
		public static DTO_Claim _claim = new DTO_Claim();
		private static List<int> ClaimDocPresent = new List<int>();
		private static List<System.Windows.Controls.Button> ButtonList = new List<System.Windows.Controls.Button>();
		private readonly SynchronizationContext synchronizationContext;
		private DateTime previousTime = DateTime.Now;
		static List<string> FileNames = new List<string>();

		public static bool ReadyForUpdate { get; set; }
		public GetClaimsPage()
		{
			InitializeComponent();
			this.DataContext = this;

			F = frame;
			G = this;
			ReadyForUpdate = false;
			synchronizationContext = SynchronizationContext.Current;

			Init();
			this.statusTextBlock.Text = statusText;
			this.ClaimsList.ItemsSource = s1.ClaimsList;
			ButtonsEnabled();
			//Browser.Visibility = Visibility.Collapsed;
		//	Browser.Navigate("https://xactimate.com/xo/");
		}

		public static Frame getInstanceg()
		{
			if (F == null)
				return new Frame();

			return F;
		}
		public static GetClaimsPage getInstanceH()
		{
			if (G == null)
				return new GetClaimsPage();
			return G;
		}
		public static ObservableCollection<DTO_ClaimDocument> getCollectionInstance()
		{
			if (CDC == null)
				return new ObservableCollection<DTO_ClaimDocument>();
			else
				return CDC;
		}
		public static int SetPaymentTypeID(int docTypeID)
		{
			switch (docTypeID)
			{
				case 13:
					{


						return 1;
					}
				case 14:
					{

						return 5;
					}
				case 15:
					{


						return 3;
					}
				case 16:
					{

						return 2;
					}
				default:
					{


						return 4;
					}
			}
		}
		private void LogOut(object sender, RoutedEventArgs e)
		{

			Login Page = new Login();
			this.NavigationService.Navigate(Page);
		}
		private async void Init()
		{
		//	await s1.GetAllClaimDocuments();
			//await UpdateClaimDocumentsLists();
			//await s1.GetAllOpenClaims();
			frame.Navigate(new MRNLogo1());
			EditData = false;
			EDcheckBox.IsChecked = false;
			BusyIndicator.Visibility = Visibility.Collapsed;
			LoadButtons();
			//	var a = new ClaimUtilities.ClaimDataService.AccessableClaim();
			//	await a.joinTables(s1.OpenClaimsList, s1.LoggedInEmployee);




		}
		bool ButtonsEnabled(bool enabled = false, bool checkstatus = false)
		{
			if (!checkstatus)
				foreach (var a in ButtonList)
					a.IsEnabled = enabled;

			if (ButtonList.Count() > 9)
				return ButtonList[10].IsEnabled;


			return false;
		}


		async private void ClaimsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

			_claim = (((DTO_Claim)ClaimsList.SelectedItem));
			ClaimDocPresent = await ClaimDocAvailability(_claim);
			updateUI();

		}
		void DisplayRecordedClaimDocuments(DTO_ClaimDocument _claimDocument, DTO_ClaimDocument _claimDocument2 = null)
		{

			BusyIndicator.Visibility = Visibility.Visible;

			if (_claimDocument != null)
				if (_claimDocument.FileExt == ".pdf" || _claimDocument.FileExt == ".PDF")
				{
					if ((bool)SupplementModeSelector.IsChecked && _claimDocument2 != null)
						ViewDocument("http://" + _claimDocument.FilePath + _claimDocument.FileName + _claimDocument.FileExt, "http://" + _claimDocument2.FilePath + _claimDocument2.FileName + _claimDocument2.FileExt);
					else ViewDocument("http://" + _claimDocument.FilePath + _claimDocument.FileName + _claimDocument.FileExt);
				}
				else if (_claimDocument.FileExt == ".jepg" || _claimDocument.FileExt == ".JPEG" || _claimDocument.FileExt == ".jpg" || _claimDocument.FileExt == ".png" || _claimDocument.FileExt == ".bmp" || _claimDocument.FileExt == ".JPG" || _claimDocument.FileExt == ".BMP" || _claimDocument.FileExt == ".PNG")
				{
					DisplayImage("http://" + _claimDocument.FilePath + _claimDocument.FileName + _claimDocument.FileExt);
				}

			if (BusyIndicator.Visibility == Visibility.Visible)
				BusyIndicator.Visibility = Visibility.Collapsed;
		}
		async void DisplayImage(string str)
		{
			try
			{
				if (pdfviewer1.Visibility == Visibility.Visible)
					pdfviewer1.Visibility = Visibility.Collapsed;
				image.Visibility = Visibility.Visible;
				var web = new System.Net.WebClient();


				stream = new MemoryStream(await web.DownloadDataTaskAsync(str));

				image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(str);
				BusyIndicator.Visibility = Visibility.Collapsed;
			}
			catch (Exception)
			{

				throw;
			}
		}
		static DTO_ClaimDocument GetClaimDocument(DTO_Claim _claim, int _claimDocTypeID)
		{
			return s1.ClaimDocumentsList.Find(x => x.ClaimID == _claim.ClaimID && x.DocTypeID == _claimDocTypeID);

		}

		async static public Task<object> checkExist(DTO_Claim claim, string existWhat, int optionalparameter = 0)
		{
			switch (existWhat)
			{
				case "Document":
					{

						return true;
					}
				// case: all the text and the methods to get to it;

				default:
					return false;
			}








		}

		async static Task<bool> UpdateClaimDocumentsLists()
		{
			await s1.GetAllClaimDocuments();

			ObservableCollection<DTO_ClaimDocument> collection = new ObservableCollection<DTO_ClaimDocument>();

			if (s1.ClaimDocumentsList != null || s1.ClaimDocumentsList.Count > 0)
				s1.ClaimDocumentsList.Clear();
			await s1.GetAllClaimDocuments();
			while (s1.ClaimDocumentsList == null)
				G.BusyIndicator.Visibility = Visibility.Visible;
			foreach (var a in s1.ClaimDocumentsList)
				collection.Add(a);
			getCollectionInstance();
			if (ClaimDocsCollection.Count > 0)
				ClaimDocsCollection.Clear();


			ClaimDocsCollection = collection;
			return true;

		}

		async static Task<bool> ProcessButtonClick()
		{

			if (!ClaimDocPresent.Exists(x => x == ClaimDocTypeID))
				await G.ConfirmDocUpload(await UploadImage());
			//statusText = "Confirmed Uploaded.";

			await UpdateClaimDocumentsLists();
			G.DisplayRecordedClaimDocuments(GetClaimDocument(_claim, ClaimDocTypeID));
			G.BusyIndicator.Visibility = Visibility.Collapsed;
			var a = s1.PaymentsList.Where(x => x.ClaimID == _claim.ClaimID && x.PaymentTypeID == SetPaymentTypeID(ClaimDocTypeID)).ToList();
			if (a.Count() > 0)
				payment = a[0];

			else
				payment = new DTO_Payment { PaymentDate = DateTime.Today, PaymentDescriptionID = PaymentDescriptionID, Amount = 0d };

			return true;


		}
		async Task<DTO_ClaimDocument> ConfirmDocUpload(List<object> a)
		{
			DTO_ClaimDocument c = (DTO_ClaimDocument)a[0];
			DTO_ClaimStatus d = (DTO_ClaimStatus)a[1];
			await UpdateClaimDocumentsLists();
			if (s1.ClaimDocumentsList.Find(z => z.ClaimID == c.ClaimID && z.DocTypeID == c.DocTypeID).DocumentDate == c.DocumentDate)
			{
				s1.ClaimDocumentsList.Add(c);
				//	updateUI();
				return c;
			}
			return new DTO_ClaimDocument();
		}

		async static private Task<List<object>> UploadImage()
		{
			List<object> objlist = new List<object>();
			var fileDialog = new System.Windows.Forms.OpenFileDialog();
			if (ClaimDocTypeID == 2)
				fileDialog.Multiselect = true;
			else
				fileDialog.Multiselect = false;
			fileDialog.Title = ((DTO_LU_ClaimDocumentType)s1.ClaimDocTypes[ClaimDocTypeID]).ClaimDocumentType + " Import Tool";
			fileDialog.Filter = Filter(ClaimDocTypeID);
			DTO_ClaimDocument b;
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if (fileDialog.FileNames.Count() > 0)
					{
						foreach (var a in fileDialog.FileNames)
						{
							var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(a);
							onlyFileName = onlyFileName.Replace(" ", "_");
							byte[] imageBytes = System.IO.File.ReadAllBytes(a);
							string ext = System.IO.Path.GetExtension(a);
							DTO_ClaimDocument documentUploadRequest = new DTO_ClaimDocument
							{
								FileBytes = Convert.ToBase64String(imageBytes),
								FileName = onlyFileName,
								FileExt = ext,
								ClaimID = _claim.ClaimID,
								DocTypeID = ClaimDocTypeID,
								DocumentDate = DateTime.Today
							};
							await s1.AddClaimDocument(documentUploadRequest);

							if (documentUploadRequest.Message == null)
							{
								objlist.Add(documentUploadRequest);
								b = documentUploadRequest;
								statusText = "Success!, " + documentUploadRequest + " has been uploaded. ";
							}
						}

						int claimStatusTypeID = 0;
						switch (ClaimDocTypeID)
						{
							case 5: claimStatusTypeID = 1; break;//	Contract Created
							case 1: claimStatusTypeID = 2; break;//Inspection Date
							case 3: claimStatusTypeID = 3; break;//Plane Measurements Received
							case 6: claimStatusTypeID = 4; break;//Estimate Complete
																 //case : claimStatusTypeID = 5; break;//Adjustment Date
							case 7: claimStatusTypeID = 6; break;//Original Scope Received
							case 13: claimStatusTypeID = 7; break;//First Check Received
							case 23: claimStatusTypeID = 8; break;//Roof Ordered
																  //case : claimStatusTypeID = 9; break;//Supplement Sent
							case 8: claimStatusTypeID = 10; break;//Supplement Settled
							case 9: claimStatusTypeID = 11; break;//Roof Scheduled
																  //case : claimStatusTypeID = 12; break;//Roof Complete
							case 10: claimStatusTypeID = 13; break;//Interior Scheduled
							case 11: claimStatusTypeID = 14; break;//Exterior Scheduled
							case 12: claimStatusTypeID = 15; break;//Gutters Scheduled
							case 20: claimStatusTypeID = 16; break;//Certificate of Completion Sent
																   //	case : claimStatusTypeID = 17; break;//Supplement Check Received
							case 16: claimStatusTypeID = 18; break;//Supplement Check Collected
																   //	case : claimStatusTypeID = 19; break;//Depreciation Check Received
							case 15: claimStatusTypeID = 20; break;//Depreciation Check Collected
							case 14: claimStatusTypeID = 21; break;//Deductible Check Collected
							case 19: claimStatusTypeID = 22; break;//Capped Out
							case 24: claimStatusTypeID = 23; break;//Warranty Sent


						}


						var newClaimStatus = new DTO_ClaimStatus
						{
							ClaimID = _claim.ClaimID,
							ClaimStatusDate = DateTime.Today,
							ClaimStatusTypeID = claimStatusTypeID
						};

						await s1.AddClaimStatus(newClaimStatus);

						if (newClaimStatus.Message == null)

						{
							objlist.Add(newClaimStatus);

						}
						statusText = " and status updated to  " + (s1.ClaimStatusTypes[claimStatusTypeID]) + " to " + newClaimStatus.ClaimStatusDate + " successfully.";

					}


					return objlist;
				}
				catch (Exception)
				{
					return new List<object>();
				}
			}
			return new List<object>();
		}



		async public Task<bool> CheckFileExist(int cdt = 0)
		{                                                           //the worker function to callback after determining if the file exists in the location that has been picked if so it will ask what would you like to do with it.
			try
			{

				await s1.GetAllClaimDocuments();


			}
			catch (Exception ex)
			{

				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			if (s1.ClaimDocumentsList.Exists(x => x.ClaimID == _claim.ClaimID))
				return true;
			else return false;
		}
		async public void updateUI()
		{
			ClaimDocPresent = await ClaimDocAvailability(_claim);
			SetButtonStatus();
			DisplayRecordedClaimDocuments(GetClaimDocument(_claim, ClaimDocTypeID));
			if (ReadyForUpdate)
				frame.Navigate(new MRNLogo1());
			this.statusTextBlock.Text = statusText;
			//while (!ReadyToUpdate)
			//await Task.Delay(10);
			ReadyToUpdate = false;
			UpdateUI(0);
		}

		#region Problem Free Areas
		static string Filter(int docTypeID)
		{
			switch (docTypeID)
			{
				case 2:
					return "All Image Types (*.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png) | *.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png";

				default:
					return "All Image Types (*.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png) | *.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png | All Document Types (*.pdf;*.doc;*.docx;*.txt;*.xml) | *.pdf;*.doc;*.docx;*.txt;*.xml| All File Types(*.*) | *.*";

			}
		}

		Stream stream, stream2;
		internal bool ReadyToUpdate;

		async void ViewDocument(string str, string str2 = null)
		{
			if (!(bool)SupplementModeSelector.IsChecked)
			{
				if (image.Visibility == Visibility.Visible)
					image.Visibility = Visibility.Collapsed;
				pdfviewer1.Visibility = Visibility.Visible;
			}
			try
			{
				var web = new System.Net.WebClient();
				stream = new MemoryStream(await web.DownloadDataTaskAsync(str));
				if ((bool)SupplementModeSelector.IsChecked)
				{
					var web2 = new System.Net.WebClient();
					stream2 = new MemoryStream(await web2.DownloadDataTaskAsync(str2));
					pdfviewer2.Load(stream2);
				}
				while (stream == null)
					if (BusyIndicator.Visibility == Visibility.Collapsed)
						BusyIndicator.Visibility = Visibility.Visible;

				pdfviewer1.Load(stream);
				BusyIndicator.Visibility = Visibility.Collapsed;
			}
			catch (Exception ex)
			{

				System.Windows.Forms.MessageBox.Show(ex.ToString());
				throw;
			}



		}
		async static Task<bool> GetDocuments()
		{
			await s1.GetClaimDocumentsByClaimID(_claim);
			return true;
		}
		#region	  Button Behavior
		#region	  LoadButtons
		#region
		void LoadButtons()
		{
			if (ButtonList.Count > 0)
				ButtonList.Clear();
			ButtonList.Add(button);//dummybutton to make the index and the id's match
			ButtonList.Add(InspectionReportBtn); ButtonList.Add(InspectionPhotos);
			ButtonList.Add(RoofMeasurementBtn); ButtonList.Add(SketchBtn);
			ButtonList.Add(CustomerAgreementBtn); ButtonList.Add(MRNEstimateBtn);
			ButtonList.Add(OriginalScopeBtn); ButtonList.Add(NewestScopeBtn);
			ButtonList.Add(RoofLaborInvoiceBtn); ButtonList.Add(MaterialInvoiceBtn);
			ButtonList.Add(InteriorInvoice); ButtonList.Add(GutterInvoiceBtn);
			ButtonList.Add(FirstCheckBtn); ButtonList.Add(SupplementCheckBtn);
			ButtonList.Add(DepreciationCheckBtn); ButtonList.Add(DeductibleCheckBtn);
			ButtonList.Add(CertificateOfCompletionBtn); ButtonList.Add(LienWaiverBtn);
			ButtonList.Add(AuthorizatonOfCommunicationBtn); ButtonList.Add(SatisfactionSurveyBtn);
			ButtonList.Add(PlaneDamages); ButtonList.Add(CapOutBtn);
			ButtonList.Add(WarrantyBtn); ButtonList.Add(ThankyouLetterBtn);
			ButtonList.Add(RoofOrderBtn); ButtonList.Add(PolicyBtn);

		}
		#endregion

		#region	  SetButtonStatus
		static void SetButtonStatus()
		{
			foreach (var b in ButtonList)
				b.Background = System.Windows.Media.Brushes.Red;

			if (s1.ClaimDocumentsList != null)
				foreach (var cdt in s1.ClaimDocumentsList)
				{

					ButtonList[cdt.DocTypeID].Background = System.Windows.Media.Brushes.Green;
				}


		}
		#endregion
		#endregion

		//if object exist then the icon is clickable
		async static private Task<List<int>> ClaimDocAvailability(DTO_Claim claim)
		{
			List<int> DocExist = new List<int>();
			if (await GetDocuments())
			{

				List<DTO_ClaimDocument> claimdocs = s1.ClaimDocumentsList;
				int i = 0;

				foreach (var b in ButtonList)
					b.Background = System.Windows.Media.Brushes.Red;

				if (s1.ClaimDocumentsList != null)
					foreach (var cdt in s1.ClaimDocumentsList)
					{

						ButtonList[cdt.DocTypeID].Background = System.Windows.Media.Brushes.Green;
						DocExist.Add(cdt.DocTypeID);
						DTO_ClaimDocument cd = new DTO_ClaimDocument { ClaimID = claim.ClaimID, DocTypeID = i++ };





					}
				ClaimDocPresent = DocExist;

				return DocExist;
			}
			return new List<int>();
		}
		#endregion
		#endregion
		#region Controls

		private async void InspectionReportBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 1;

			await ProcessButtonClick();
			updateUI();
			//	frame.Navigate(new InspectionPage());
		}

		private async void InspectionPhotos_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 2;
			await ProcessButtonClick();
			//	frame.Navigate(new InspectionPhotoPage());
			updateUI();
		}

		private async void RoofMeasurementBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 3;
			await ProcessButtonClick();
			//	frame.Navigate(new FetchEagleViewInfo());
			updateUI();
		}

		private async void SketchBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 4;
			await ProcessButtonClick();
			//	frame.Navigate(new FetchEagleViewInfo());
			updateUI();
		}

		private async void OriginalScopeBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 7;
			await ProcessButtonClick();
			updateUI();
			await s1.GetScopesByClaimID(_claim);
			var a = s1.ScopesList.Where(x => x.ClaimID == _claim.ClaimID && x.ScopeTypeID == OLDSCOPE).ToList();
			if (a.Count() > 0)
				frame.Navigate(new ScopeViewer(_claim, OLDSCOPE, a[0]));
			else
				frame.Navigate(new ScopeViewer(_claim, OLDSCOPE));

			//TODO ADD EDIT CODE IF NEEDS CHANGING AND CHECK TO MAKE SURE SECOND VARIABLE ALIGNS WITH ACTUAL CLAIM DOC TYPE SCOPEVIEWER IS EXPECTING TO SEE. status type 4 scope type 2

		}

		private async void CustomerAgreementBtn_Click(object sender, RoutedEventArgs e)

		{
			ClaimDocTypeID = 5;
			await ProcessButtonClick();
			//	frame.Navigate(new FetchEagleViewInfo());
			updateUI();


		}

		private async void MRNEstimateBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 6;
			await ProcessButtonClick();
			updateUI();

			//TODO ADD EDIT CODE IF NEEDS CHANGING AND CHECK TO MAKE SURE SECOND VARIABLE ALIGNS WITH ACTUAL CLAIM DOC TYPE SCOPEVIEWER IS EXPECTING TO SEE. status 6 scope type 1
			await s1.GetScopesByClaimID(_claim);
			var a = s1.ScopesList.Where(x => x.ClaimID == _claim.ClaimID && x.ScopeTypeID == ESTIMATE).ToList();
			if (a.Count() > 0)
				frame.Navigate(new ScopeViewer(_claim, ESTIMATE, a[0]));
			else
				frame.Navigate(new ScopeViewer(_claim, ESTIMATE));

		}

		private async void NewestScopeBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 8;
			await ProcessButtonClick();
			updateUI();
			await s1.GetScopesByClaimID(_claim);
			var a = s1.ScopesList.Where(x => x.ClaimID == _claim.ClaimID && x.ScopeTypeID == NEWSCOPE).ToList();
			if (a.Count() > 0)
				frame.Navigate(new ScopeViewer(_claim, NEWSCOPE, a[0]));
			else
				frame.Navigate(new ScopeViewer(_claim, NEWSCOPE));
			//TODO ADD EDIT CODE IF NEEDS CHANGING AND CHECK TO MAKE SURE SECOND VARIABLE ALIGNS WITH ACTUAL CLAIM DOC TYPE SCOPEVIEWER IS EXPECTING TO SEE. I think this should be 10 or 3 depending on status 10 scope type 3

		}
		//			Exterior - Labor / Material
		//Gutter - Labor / Material
		//Interior - Labor / Material
		//Roof - Labor
		//Roof - Material
		private async void RoofLaborInvoiceBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 9;
			await ProcessButtonClick(); updateUI();
			frame.Navigate(new InvoicePage(_claim, 4));

		}

		private async void MaterialInvoiceBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 11;
			await ProcessButtonClick(); updateUI();
			//	frame.Navigate(new FetchEagleViewInfo());

		}

		private async void InteriorInvoice_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 10;
			await ProcessButtonClick(); updateUI();
			//	frame.Navigate(new FetchEagleViewInfo());

		}

		private async void GutterInvoiceBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 12;
			await ProcessButtonClick(); updateUI();
			//	frame.Navigate(new FetchEagleViewInfo());

		}

		private async void FirstCheckBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 13;
			await ProcessButtonClick(); updateUI();
			frame.Navigate(new PaymentEntryPage(_claim, ClaimDocTypeID, payment));

			//TODO EDITCHECK

		}

		private async void SupplementCheckBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 16;
			await ProcessButtonClick(); updateUI();
			frame.Navigate(new PaymentEntryPage(_claim, ClaimDocTypeID, payment));

			//TODO EDITCHECK

		}

		private async void DepreciationCheckBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 15;
			await ProcessButtonClick(); updateUI();
			frame.Navigate(new PaymentEntryPage(_claim, ClaimDocTypeID, payment));

			//TODO EDITCHECK

		}

		private async void DeductibleCheckBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 14;
			await ProcessButtonClick(); updateUI();
			frame.Navigate(new PaymentEntryPage(_claim, ClaimDocTypeID, payment));

			//TODO EDITCHECK

		}

		private async void CertificateOfCompletionBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 20;
			await ProcessButtonClick(); updateUI();

			//	frame.Navigate(new FetchEagleViewInfo());

		}

		private async void LienWaiverBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 18;
			await ProcessButtonClick();
			updateUI();
			//	frame.Navigate(new FetchEagleViewInfo());
		}

		private async void AuthorizatonOfCommunicationBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 21;
			await ProcessButtonClick();
			updateUI();
			//	frame.Navigate(new FetchEagleViewInfo());

		}

		private async void SatisfactionSurveyBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 22;
			await ProcessButtonClick();
			updateUI();
			//	frame.Navigate(new FetchEagleViewInfo());

		}

		private async void PlaneDamages_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 23;
			await ProcessButtonClick();

			updateUI();
			//	frame.Navigate(new FetchEagleViewInfo());

		}

		private async void WarrantyBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 25;
			await ProcessButtonClick();
			updateUI();
			//	frame.Navigate(new FetchEagleViewInfo());

		}

		private async void ThankyouLetterBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 26;
			await ProcessButtonClick();
			updateUI();
			//	frame.Navigate(new FetchEagleViewInfo());

		}

		private async void RoofOrderBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 17;
			await ProcessButtonClick();
			updateUI();
			//	frame.Navigate(new FetchEagleViewInfo());

		}

		private async void PolicyBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 25;
			await ProcessButtonClick();
			updateUI();
			//	frame.Navigate(new FetchEagleViewInfo());

		}

		private async void CapOutBtn_Click(object sender, RoutedEventArgs e)
		{
			ClaimDocTypeID = 19;
			await ProcessButtonClick();
			updateUI();
			//	frame.Navigate(new FetchEagleViewInfo());

		}

		private void checkBox_Checked(object sender, RoutedEventArgs e)
		{
			if (EDcheckBox.IsChecked == false)
				EditData = true;
			else EditData = false;

		}
		#endregion
		#region Supplement Mode Control
		private void SupplementModeSelector_Clicked(object sender, RoutedEventArgs e)
		{
			if (pdfviewer1.Visibility == Visibility.Collapsed)
				pdfviewer1.Visibility = Visibility.Visible;


			//else pdfviewer1.Visibility = Visibility.Collapsed;
			if (pdfviewer2.Visibility == Visibility.Collapsed || GridSupplement.Visibility == Visibility.Collapsed)
			{
				pdfviewer2.Visibility = Visibility.Visible;
				GridSupplement.Visibility = Visibility.Visible;
			}
			else
			{
				pdfviewer2.Visibility = Visibility.Collapsed;
				GridSupplement.Visibility = Visibility.Collapsed;
			}
			if (image.Visibility == Visibility.Visible)
				image.Visibility = Visibility.Collapsed;
			DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 6), GetClaimDocument(_claim, 7));

		}
		#endregion
		#region Async UI Operations NOT IMPLEMENTED YET
		private async void CheckCallBackAvailability(object sender, EventArgs e)
		{
			RoofOrderBtn.IsEnabled = false;


			await Task.Run(() =>
			{

				updateUI();
				Task.Delay(5000);
				this.statusTextBlock.Text = "";

			});

			this.statusTextBlock.Text = statusText;
		}

		private void Xactimate_Checked(object sender, RoutedEventArgs e)
		{
		//	Browser.Visibility = Visibility.Visible;
		}

		private void Xactimate_Unchecked(object sender, RoutedEventArgs e)
		{
		//	Browser.Visibility = Visibility.Collapsed;
		}

		public void UpdateUI(int value)
		{
			var timeNow = DateTime.Now;

			if ((DateTime.Now - previousTime).Milliseconds <= 50) return;

			synchronizationContext.Post(new SendOrPostCallback(o =>
			{
				statusText = @"Counter " + (int)o;
			}), value);

			previousTime = timeNow;
		}
	}

	#endregion
	class DocumentViewerConfig : ObservableCollection<DocumentViewerConfig>
	{
		public DocumentViewerConfig DocConfig { get; set; }
		public object viewer { get; set; }
		public string source { get; set; }
		public Type type { get; set; }
		public int DocTypeID { get; set; }



	}
}




