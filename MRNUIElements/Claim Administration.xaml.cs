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
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Web.ClientServices;
using System.Web.ApplicationServices;
using System.Web.UI;
using System.Net.Http.Handlers;
using System.IO;
using MRNNexus_Model;
using MRNUIElements.Controllers;
using MRNUIElements.Controllers.Collection;
using System.Drawing;
using System.Threading;
using MRNUIElements.Models;
using static MRNUIElements.Controllers.Collection.ClaimData;
using static MRNUIElements.MainWindow;
using Syncfusion.Windows.Controls.Navigation;
using MRNUIElements.Interface.Command;
using static MRNUIElements.Interface.Command.RoutedCommands;
using static MRNUIElements.AddressZipcodeValidation;


namespace MRNUIElements
{

	public class ClaimFolderView
	{
		public string Name { get; set; }
		public string State { get; set; }
		public string IconImagePath { get; set; }
		public int Status { get; set; }



	}

	public class ApplicationCommand

	{

		public string Name { get; set; }



		public string ImagePath { get; set; }



		public ICommand Command { get; set; }

	}

	/// <summary>
	/// Interaction logic for Claim_Administration.xaml
	/// </summary>
	public partial class Claim_Administration : System.Windows.Controls.Page
	{
		static NavigationService ns = getNavigationService();
		static ServiceLayer s1 = ServiceLayer.getInstance();
		public string FullFilePath { get; set; }
		public ClaimData ClaimData { get; set; }
		public int ClaimDocTypeID { get; set; }
		public bool EditData { get; set; }
		//	public DTO_Claim _claim = new DTO_Claim();
		public DTO_Claim CurrentClaim { get; set; }
		public List<DTO_Claim> ClaimsList { get; set; }
		public List<DTO_LU_ClaimDocumentType> AvailableDocuments { get; set; }

		private List<ApplicationCommand> options;
		protected bool holdItOpen = false;
		private List<ClaimFolderView> claimViewOptions;
		static public DTO_Employee currentLoggedInUser = (DTO_Employee)System.Windows.Application.Current.Properties["CurrentUser"];

		public List<ClaimFolderView> ClaimViewOptions

		{

			get { return claimViewOptions; }

			set { claimViewOptions = value; }

		}


		public List<ApplicationCommand> Options

		{

			get { return options; }

			set { options = value; }

		}
		public DTO_Claim claim { get; set; }
		
		public List<DTO_Claim> OpenClaimsList { get; set; }
		private void LogOut(object sender, RoutedEventArgs e)
		{

			ns.Navigate(new Login());
		}
		private async void Init()
		{
			CurrentClaim = claim = new DTO_Claim();
			claim = s1.ClaimsList.Find(x => x.ClaimID == 19); }
		public Claim_Administration()
		{
			InitializeComponent();
			getClaims();
			ns = this.NavigationService;
			Init();

			this.ClaimsList = s1.ClaimsList;
			this.AvailableDocuments = s1.ClaimDocTypes;

			SetButtonStatus(ClaimDocAvailability(CurrentClaim));
			currentLoggedInUser = s1.LoggedInEmployee;
			

			CurrentLoggedInUser.Text = currentLoggedInUser.FirstName + " " + currentLoggedInUser.LastName;
			if (claim == null)
				claim = (DTO_Claim)System.Windows.Application.Current.Properties["CurrentClaim"];

			var invoice = new AddInvoiceCommand(this.frame, claim);
			var payment = new AddPaymentCommand(this.frame, claim);
			var selectClaim = new SelectClaimCommand(this.frame);
			Options = new List<ApplicationCommand>();

			Options.Add(new ApplicationCommand() { Name = "Add Invoice", ImagePath = "Invoice.png", Command = invoice });

			Options.Add(new ApplicationCommand() { Name = "Add Payment", ImagePath = "Payment.png", Command = payment });

			Options.Add(new ApplicationCommand() { Name = "Copy", ImagePath = "copy.png" });

			Options.Add(new ApplicationCommand() { Name = "Select Claim", ImagePath = "paste.png", Command = selectClaim });

			SfRadialMenu radialMenu = new SfRadialMenu();

			SfRadialMenuItem addInvoice = new SfRadialMenuItem() { Header = "Add Invoice" };

			SfRadialMenuItem addPayment = new SfRadialMenuItem() { Header = "Add Payment" };

			SfRadialMenuItem copy = new SfRadialMenuItem() { Header = "Copy" };

			SfRadialMenuItem paste = new SfRadialMenuItem() { Header = "Select Claim" };

			radialMenu.Items.Add(addInvoice);

			radialMenu.Items.Add(addPayment);

			radialMenu.Items.Add(copy);

			radialMenu.Items.Add(selectClaim);

			if (s1.OpenClaimsList.Count() > 0)
				OpenClaimsList = s1.OpenClaimsList;

			ClaimslistBox.DataContext = this.OpenClaimsList;
			ClaimslistBox.ItemsSource = this.OpenClaimsList;


			this.DataContext = this;

			getInfoForClaimWorkstation(claim, ns);


		}

		async Task<bool> GetClaimDocuments()
		{
			ServiceLayer s = ServiceLayer.getInstance();
			await s.GetAllClaimDocuments();
			int j = 0;
			while (s.ClaimDocumentsList == null)
			{
				await Task.Delay(1);
				j++;
				if (j > 1000000)
					return false;
			}

			


			return true;
		}
		async void getClaims()
		{

			if(await GetClaimDocuments())

			await s1.GetAllOpenClaims();
		}

		void DisplayRecordedClaimDocuments(DTO_ClaimDocument _claimDocument, DTO_ClaimDocument _claimDocument2 = null)
		{
			//BusyIndicator.Visibility = Visibility.Visible;
			if (_claimDocument != null)
				if (_claimDocument.FileExt == ".pdf" || _claimDocument.FileExt == ".PDF")
				{
					ViewDocument("http://" + _claimDocument.FilePath + _claimDocument.FileName + _claimDocument.FileExt);
				}
				else if (_claimDocument.FileExt == ".jepg" || _claimDocument.FileExt == ".JPEG" || _claimDocument.FileExt == ".jpg" || _claimDocument.FileExt == ".png" || _claimDocument.FileExt == ".bmp" || _claimDocument.FileExt == ".JPG" || _claimDocument.FileExt == ".BMP" || _claimDocument.FileExt == ".PNG")
				{
					DisplayImage("http://" + _claimDocument.FilePath + _claimDocument.FileName + _claimDocument.FileExt);
				}

		}
		/// <summary>
		/// 			if (PdfViewer.Visibility == Visibility.Visible)
		///			PdfViewer.Visibility = Visibility.Collapsed;
		/// </summary>
		/// <param name="str"></param>
		async void DisplayImage(string str)
		{
			try
			{
	/////
				image.Visibility = Visibility.Visible;
				var web = new System.Net.WebClient();


				stream = new MemoryStream(await web.DownloadDataTaskAsync(str));

				image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(str);
			//	BusyIndicator.Visibility = Visibility.Collapsed;
			}
			catch (Exception)
			{

				throw;
			}



		}
		DTO_ClaimDocument GetClaimDocument(DTO_Claim _claim, int _claimDocTypeID)
		{
			return s1.ClaimDocumentsList.Find(x => x.ClaimID == _claim.ClaimID && x.DocTypeID == _claimDocTypeID);

		}
		bool uploadselected = false;
		private void AvailableDocuments_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//DTO_Claim _claim = new DTO_Claim();
			//_claim.ClaimID = (((DTO_Claim)ClaimsList.SelectedItem).ClaimID);
			//DisplayRecordedClaimDocuments(_claim);
		}
		private void button_Click(object sender, RoutedEventArgs e)
		{


			uploadselected = true;
			SetButtonStatus(UploadSelector());


		}

		List<bool> UploadSelector()
		{
			List<bool> enableall = new List<bool>();
			foreach (var cdt in s1.ClaimDocTypes)
				if (uploadselected)
					enableall.Add(true);
			return enableall;
		}

		async private void UploadImage(string filepathtoupload = null)
		{
			var fileDialog = new System.Windows.Forms.OpenFileDialog();
			var result = System.Windows.Forms.DialogResult.OK;
			if (filepathtoupload == null)
				result = fileDialog.ShowDialog();


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
						ClaimID = CurrentClaim.ClaimID,
						DocTypeID = ClaimDocTypeID,
						DocumentDate = DateTime.Today

					};

					await s1.AddClaimDocument(documentUploadRequest);
			//		BusyIndicator.Visibility = Visibility.Visible;
					if (documentUploadRequest.Message == null)
					{
			//			BusyIndicator.Visibility = Visibility.Collapsed;
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
					break;
				case System.Windows.Forms.DialogResult.Cancel:
				default:

					return;
			}
		}
		void SetButtonStatus(List<bool> enablelist)
		{

			if (enablelist.Count > 0)
			{
				InspectionReportBtn.IsEnabled = enablelist[0];

				InspectionPhotos.IsEnabled = enablelist[1];

				RoofMeasurementBtn.IsEnabled = enablelist[2];

				SketchBtn.IsEnabled = enablelist[3];

				CustomerAgreementBtn.IsEnabled = enablelist[4];

				MRNEstimateBtn.IsEnabled = enablelist[5];

				OriginalScopeBtn.IsEnabled = enablelist[6];

				NewestScopeBtn.IsEnabled = enablelist[7];

				RoofOrderBtn.IsEnabled = enablelist[8];

				InteriorInvoice.IsEnabled = enablelist[9];

				RoofLaborInvoiceBtn.IsEnabled = enablelist[10];

				GutterInvoiceBtn.IsEnabled = enablelist[11];

				FirstCheckBtn.IsEnabled = enablelist[12];

				DeductibleCheckBtn.IsEnabled = enablelist[13];

				DepreciationCheckBtn.IsEnabled = enablelist[14];

				SupplementCheckBtn.IsEnabled = enablelist[15];

				MaterialInvoiceBtn.IsEnabled = enablelist[16];

				LienWaiverBtn.IsEnabled = enablelist[17];

				CapOutBtn.IsEnabled = enablelist[18];

				CertificateOfCompletionBtn.IsEnabled = enablelist[19];

				AuthorizatonOfCommunicationBtn.IsEnabled = enablelist[20];

				SatisfactionSurveyBtn.IsEnabled = enablelist[21];

				PlaneDamages.IsEnabled = enablelist[22];

				WarrantyBtn.IsEnabled = enablelist[23];

				PolicyBtn.IsEnabled = enablelist[24];

				ThankyouLetterBtn.IsEnabled = enablelist[25];
			}
		}
		private List<string> SelectFile(int docTypeID)
		{
			uploadselected = false;
			ClaimDocTypeID = docTypeID;
			var fileDialog = new System.Windows.Forms.OpenFileDialog();
			if (docTypeID == 2)
				fileDialog.Multiselect = true;
			else
				fileDialog.Multiselect = false;
			fileDialog.Title = " Import Tool";
			fileDialog.Filter = Filter(docTypeID);
			var result = fileDialog.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.OK)
			{
				if (FileNames.Count > 0)
					FileNames.Clear();
				FullFilePath = fileDialog.FileName;
				foreach (string s in fileDialog.FileNames)
				{

					FileNames.Add(s);
				}
				//FileListBox.ItemsSource = FileNames;
				//FileListBox.SelectedIndex = 0; 
				return FileNames;
			}
			return null;
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
		Stream stream, stream2;
		async void ViewDocument(string str, string str2 = null)
		{

			try
			{
				//var bi = new MainWindow().busyIndicator;
				var web = new System.Net.WebClient();
				stream = new MemoryStream(await web.DownloadDataTaskAsync(str));

			/*	while (stream == null)
					if (BusyIndicator.Visibility == Visibility.Collapsed)
						BusyIndicator.Visibility = Visibility.Visible;
						*/
///				PdfViewer.Load(stream);
			//	BusyIndicator.Visibility = Visibility.Collapsed;
			}
			catch (Exception ex)
			{

				System.Windows.Forms.MessageBox.Show(ex.ToString());
				throw;
			}



		}

		async void GetDocuments()
		{
			await s1.GetAllClaimDocuments();

		}
		//if object exist then the icon is clickable

	 private List<bool> ClaimDocAvailability(DTO_Claim claim)
		{
			List<bool> DocExist = new List<bool>();
			GetDocuments();
			int j = 0;
			//while (s1.ClaimDocumentsList == null)
				//j++;
			List<DTO_ClaimDocument> claimdocs = s1.ClaimDocumentsList;
			int i = 1;
			//if (s1.ClaimDocumentsList != null)
				foreach (var cdt in s1.ClaimDocTypes)
				{
				//claim = new DTO_Claim();
				//claim.ClaimID = 19;
					DTO_ClaimDocument cd = new DTO_ClaimDocument { ClaimID = claim.ClaimID, DocTypeID = i++ };

					if (claimdocs.Exists(x => x.ClaimID == cd.ClaimID && x.DocTypeID == cd.DocTypeID))
						DocExist.Add(true);
					else
						DocExist.Add(false);

					//returns a list of what docs exist and which ones dont. apply this to an enabled binding and wallah



				}
			return DocExist;
		}
		#region	  Button Behavior
		private void InspectionReportBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 1));
			else UploadImage(SelectFile(1)[0]);
			uploadselected = false;

		}

		private void InspectionPhotos_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 2));
			else UploadImage(SelectFile(2)[0]);
			uploadselected = false;
		}

		private void RoofMeasurementBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 3));
			else UploadImage(SelectFile(3)[0]);
			uploadselected = false;
		}

		private void SketchBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 4));
			else UploadImage(SelectFile(4)[0]);
			uploadselected = false;
		}

		private void OriginalScopeBtn_Click(object sender, RoutedEventArgs e)
		{
			if (EditData)
				frame.Navigate(new ScopeViewer(CurrentClaim, 7));
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 7));
			else
				UploadImage(SelectFile(7)[0]);


			uploadselected = false;
		}

		private void CustomerAgreementBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 5));

			else UploadImage(SelectFile(5)[0]);
			uploadselected = false;
		}

		private void MRNEstimateBtn_Click(object sender, RoutedEventArgs e)
		{
			if (EditData)
				frame.Navigate(new ScopeViewer(CurrentClaim, 6));
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 6));
			else
				UploadImage(SelectFile(6)[0]);



			uploadselected = false;
		}

		private void NewestScopeBtn_Click(object sender, RoutedEventArgs e)
		{
			if (EditData)
				frame.Navigate(new ScopeViewer(CurrentClaim, 8));

			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 8));
			else
				UploadImage(SelectFile(8)[0]);

			uploadselected = false;
		}

		private void RoofLaborInvoiceBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 11));
			else UploadImage(SelectFile(11)[0]);
			uploadselected = false;
		}

		private void MaterialInvoiceBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 17));
			else UploadImage(SelectFile(17)[0]);
			uploadselected = false;
		}

		private void InteriorInvoice_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 10));
			else UploadImage(SelectFile(10)[0]);
		}

		private void GutterInvoiceBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 12));
			else UploadImage(SelectFile(12)[0]);
			uploadselected = false;
		}


		private void CertificateOfCompletionBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 20));
			else UploadImage(SelectFile(20)[0]);
			uploadselected = false;
		}

		private void LienWaiverBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 18));
			else UploadImage(SelectFile(18)[0]);
			uploadselected = false;
		}

		private void AuthorizatonOfCommunicationBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 21));
			else UploadImage(SelectFile(21)[0]);
			uploadselected = false;
		}

		private void SatisfactionSurveyBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 22));
			else UploadImage(SelectFile(22)[0]);
			uploadselected = false;
		}

		private void PlaneDamages_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 23));
			else UploadImage(SelectFile(23)[0]);
			uploadselected = false;
		}

		private void WarrantyBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 24));
			else UploadImage(SelectFile(24)[0]);
			uploadselected = false;
		}

		private void ThankyouLetterBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 26));
			else UploadImage(SelectFile(26)[0]);
			uploadselected = false;
		}

		private void RoofOrderBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 9));
			else UploadImage(SelectFile(9)[0]);
			uploadselected = false;
		}

		private void PolicyBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 25));
			else UploadImage(SelectFile(25)[0]);
			uploadselected = false;
		}

		private void CapOutBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!uploadselected)
				DisplayRecordedClaimDocuments(GetClaimDocument(CurrentClaim, 19));
			else UploadImage(SelectFile(19)[0]);
			uploadselected = false;
		}

		private void FetchFormView(int docTypeID, bool docPresent)
		{
			switch (docTypeID)
			{

				case 0:
					{
						break;
					}
				case 1:
					{
						break;
					}
				case 2:
					{
						break;
					}
				case 3:
					{
						break;
					}
				case 4:
					{
						break;
					}
				case 5:
					{
						break;
					}
				case 6:
					{
						break;
					}
				case 7:
					{
						break;
					}
				case 8:
					{
						break;
					}
				case 9:
					{
						break;
					}
				case 10:
					{
						break;

					}
				case 11:
					{
						break;
					}
				case 12:
					{
						break;
					}
				case 13:
					{
						break;
					}
				case 14:
					{
						break;
					}
				case 15:
					{
						break;
					}
				case 16:
					{
						break;
					}
				case 17:
					{
						break;
					}
				case 18:
					{
						break;
					}
				case 19:
					{
						break;
					}
				case 20:
					{
						break;

					}
				default:
					{
						break;


					}

			}
			//follow on with code here

		}
		public static void AddInvoice(DTO_Claim Claim = null)
		{




		}
		public void AddInvoicePage(DTO_Claim Claim = null)
		{

			var AuthorizationCode = true;
			//TODO get CurrentView Handle and Change it to reflect Invoice Entry For This Claim
			NavigationService.Navigate(new InvoicePage(Claim));




		}

		public void AddPayment()
		{
			var AuthorizationCode = true;
			//TODO get CurrentView Handle and Change it to reflect Payment Entry For This Claim
		//	NavigationService.Navigate(new PaymentEntryPage());

		}
		private void LeftButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void RightButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Command.ToString() == "invoice")
				AddInvoicePage();
			else if (e.Command.ToString() == "payment")
				AddPayment();
		}

		private void scopeTypeIDTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void ClaimDocumentWorkstation_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{

///			if (PdfViewer.Visibility != Visibility.Visible)
///				PdfViewer.Visibility = Visibility.Visible;
		}

		private void ClaimDocumentWorkstation_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
///			if (PdfViewer.Visibility == Visibility.Visible)
///				PdfViewer.Visibility = Visibility.Collapsed;
		}

		private void dTO_ClaimDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void getInfoForClaimWorkstation(DTO_Claim claim, NavigationService NavSvc)
		{
			

		}
	}


}
#endregion