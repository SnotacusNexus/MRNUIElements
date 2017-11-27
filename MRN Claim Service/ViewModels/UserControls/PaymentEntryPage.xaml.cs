using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

using System.Windows.Forms;
using System.Drawing;
//using System.Drawing.Imaging;
//using System.Drawing.Drawing2D;
//using System.Drawing.Text;
using MRNUIElements.ImageManipulation;

using System.IO;
using MRNNexus_Model;
using System.Globalization;
using MRNUIElements.Controllers;

namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for CheckInvoicePage.xaml
	/// </summary>
	public partial class PaymentEntryPageUC : System.Windows.Controls.UserControl
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		public DTO_Claim Claim { get; set; }
		public DateTime PaymentDate { get; set; }
		public int PaymentDescriptionID { get; set; }
		protected int DocTypeID = 0;
		protected int ClaimStatusType = 0;
		protected string FullFilePath;
		public System.Drawing.Image bitmap;

		public PaymentEntryPageUC(DTO_Claim claim = null, int DocTypeID = 0)
		{
			//	OnInit();
			InitializeComponent();
			paymentDateDatePicker.Text = DateTime.Today.ToShortDateString();
			OnInit();
			var cppu = new ClaimPickerPopUp();
			try
			{
				if (string.IsNullOrEmpty(Claim.ToString()))
					if (claim != null)
					{
						Claim = claim;

					}
					else
					{
						cppu.ShowDialog();


					}

			}

			catch (Exception ex)
			{

				System.Windows.Forms.MessageBox.Show("No Claim Selected. You must have found the back door. Try coming through the front door.");
			}
			finally
			{

				//TODO Build Claim Selection Mini Window for pop up with filtered list based on user creds.


			}

			if (cppu.DialogResult.HasValue)
				Claim = (DTO_Claim)cppu.Claim;
			else return;



			if (Claim != null)                  // overkill
				if (s1.PaymentsList.Exists(x => x.ClaimID == this.Claim.ClaimID && x.PaymentDescriptionID == this.PaymentDescriptionID))
				{
					var result = System.Windows.MessageBox.Show("A Payment of this type has already been recorded.", "UPDATE PAYMENT INFO FOR " + Claim + "?!?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);    //TODO add follow up message box would you like to up date it?
					if (result == System.Windows.MessageBoxResult.No)
						DisplayPayment(Claim, PaymentDescriptionID);

					//new MainWindow().MRNClaimNexusMainFrame.Navigate(new GetClaimsPage());
				}
		}
		async private void OnInit()
		{
			try
			{
				while (s1.PaymentsList == null)
					Thread.Sleep(10);
				await s1.GetPaymentsByClaimID(Claim);


			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("Payment Date Error Code " + paymentDateDatePicker.Text + "-" + Claim.ToString() + "--" + PaymentDescriptionID + " Report this error to IT Dept." + "\r\n" + ex.ToString());

			}
		}

		private void paymentDateDatePicker_LostFocus(object sender, RoutedEventArgs e)
		{
			if (paymentDateDatePicker.SelectedDate.HasValue)
				PaymentDate = paymentDateDatePicker.SelectedDate.Value;
		}


		private void amountTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

			if (amountTextBox.Text == string.Empty) amountTextBox.Value = 0;
			if (amountTextBox.Text != string.Empty) SubmitScopeEntry.IsEnabled = true;

		}


		private void CancelScopeEntry_Click(object sender, RoutedEventArgs e)
		{

		}

		async private void SubmitScopeEntry_Click(object sender, RoutedEventArgs e)
		{

			if (paymentDateDatePicker.SelectedDate != null && paymentDateDatePicker.SelectedDate <= DateTime.Today && amountTextBox.Value > 0)
			{
				SetPaymentTypeID();
				DTO_Payment p = new DTO_Payment();

				p.Amount = (double)amountTextBox.Value;
				p.PaymentDate = paymentDateDatePicker.SelectedDate.Value;
				p.PaymentDescriptionID = this.PaymentDescriptionID;
				p.ClaimID = Claim.ClaimID;
				p.PaymentTypeID = 1;
				try
				{

					await s1.AddPayment(p);
					UploadImage(SelectFile());
				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.ToString());

				}


				if (s1.Payment.Message == null)
				{
					// TODO: Upload the pic of check.
					//TODO:  Add Claim Document Entry. Taken Care of on upload. But the update of the claim status still needs updating;

					var cs = new DTO_ClaimStatus();
					cs.ClaimID = Claim.ClaimID;
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
			}
		}





		private string SelectFile()
		{
			var fileDialog = new System.Windows.Forms.OpenFileDialog();
			string Filter = "All Image Types (*.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png) | *.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png | All Document Types (*.pdf;*.doc;*.docx;*.txt;*.xml) | *.pdf;*.doc;*.docx;*.txt;*.xml| All File Types(*.*) | *.*";

			return fileDialog.FileName;




		}

		protected BitmapImage DisplayImage(ImageSource imgsrc)
		{

			return (BitmapImage)imgsrc;


		}




		bool Checkifimagetype(string path)
		{


			string ext = System.IO.Path.GetExtension(path);

			if (ext.Contains('.'))
				ext = ext.Remove(ext.IndexOf('.'), 1);

			switch (ext)
			{
				case "jpg":
					{
						return true;
					}
				case "bmp":
					{
						return true;
					}
				case "png":
					{
						return true;
					}
				case "tif":
					{
						return true;
					}
				case "jpeg":
					{
						return true;
					}

				default:
					return false;
			}

		}



		private void DisplayPayment(DTO_Claim claim, int paymentDescriptionType)
		{
			System.Windows.Forms.MessageBox.Show("On " + s1.PaymentsList.Find(x => x.ClaimID == claim.ClaimID && x.PaymentDescriptionID == paymentDescriptionType).PaymentDate.ToString() + " a payment was made for the amount of $ " + s1.PaymentsList.Find(x => x.ClaimID == claim.ClaimID && x.PaymentDescriptionID == paymentDescriptionType).Amount.ToString());
		}

		private void InkCanvas_Drop(object sender, System.Windows.DragEventArgs e)
		{
			e.Data.GetType().TypeHandle.Value.ToString();
			e.Data.GetFormats();
			System.Windows.Controls.Image bmp = new System.Windows.Controls.Image();

			System.Windows.Forms.MessageBox.Show(sender.ToString());
			//e.Data.GetData(System.Windows.DataFormats.
		}

		private void InkCanvas_SourceUpdated(object sender, DataTransferEventArgs e)
		{

		}

		private void radioButton1stCheck_Checked(object sender, RoutedEventArgs e)
		{
			SetPaymentTypeID();
		}
		void SetPaymentTypeID()
		{
			switch (DocTypeID)
			{
				case 13:
					{
						PaymentDescriptionID = 1;
						PaymentDescriptionTextBlock.Text = "First/Deposit Check";
						ClaimStatusType = 7;

						break;
					}
				case 14:
					{
						PaymentDescriptionID = 5;
						PaymentDescriptionTextBlock.Text = "Deductible Check";
						ClaimStatusType = 21;
						break;
					}
				case 15:
					{
						PaymentDescriptionID = 3;
						PaymentDescriptionTextBlock.Text = "Depreciation Check";
						ClaimStatusType = 20;
						break;
					}
				case 16:
					{
						PaymentDescriptionID = 2;
						PaymentDescriptionTextBlock.Text = "Supplemental Check";
						ClaimStatusType = 18;
						break;
					}
				default:
					{
						PaymentDescriptionID = 4;
						PaymentDescriptionTextBlock.Text = "Upgrade Check";

						break;
					}
			}
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
			if (s1.ClaimDocumentsList.Exists(x => x.DocTypeID == Claim.ClaimID))
				return true;
			else return false;
		}



		string GetDocumentTypeByID(int doctypeid)
		{
			return ((DTO_LU_ClaimDocumentType)s1.ClaimDocTypes.Where(t => t.ClaimDocumentTypeID == doctypeid)).ClaimDocumentType.ToString();
		}


		void ShowCollectedClaimDocuments(DTO_Claim claim)
		{

			string s = "This claim has ";
			foreach (var cd in s1.ClaimDocumentsList.Where(t => t.ClaimID == claim.ClaimID))
				s += " \n\r" + (GetDocumentTypeByID(cd.DocTypeID)) + " ,";

			s += "documents present.";
			System.Windows.Forms.MessageBox.Show(s);
		}
		private void DisplayVisual(RenderTargetBitmap target, string outputFile, bool Save = false)
		{// part 2 of the display to save operation... this is picking out the appropriate encoder for saving the file in the format that was opened
			BitmapEncoder encoder = null;
			switch (System.IO.Path.GetExtension(outputFile))
			{
				case ".png":
					encoder = new PngBitmapEncoder();
					break;
				case ".jpeg":
					encoder = new JpegBitmapEncoder();
					break;
				case ".jpg":
					encoder = new JpegBitmapEncoder();
					break;
				case ".bmp":
					encoder = new BmpBitmapEncoder();
					break;
				case ".wmp":
					encoder = new WmpBitmapEncoder();
					break;
				case ".tiff":
					encoder = new TiffBitmapEncoder();
					break;
				case ".gif":
					encoder = new GifBitmapEncoder();
					break;
			}
			if (encoder != null)
			{
				encoder.Frames.Add(BitmapFrame.Create(target));
				if (Save)
				{
					using (FileStream outputStream = new FileStream(outputFile, FileMode.Create))
					{//get ready to save stream set

						encoder.Save(outputStream);//ok spit that shit to the file biatch
												   //PopTheTopOfListBox();// ok now then since the file has been appropriated then we can remove its name from our list of files to appropriate
						UploadImage(outputFile);
					}
				}
			}
		}

		async private void UploadImage(string filepathtoupload = null)
		{
			var fileDialog = new System.Windows.Forms.OpenFileDialog();
			var result = System.Windows.Forms.DialogResult.OK;
			if (filepathtoupload == null)
			{
				result = fileDialog.ShowDialog();
			}

			switch (result)
			{
				case System.Windows.Forms.DialogResult.OK:
					busyIndicator.IsBusy = true;
					if (filepathtoupload == null)
						FullFilePath = fileDialog.FileName;
					else
						FullFilePath = filepathtoupload;
					var file = FullFilePath;

					var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(file);
					if (string.IsNullOrEmpty(file))
					{
						System.Windows.MessageBox.Show("File Name not valid.");
						busyIndicator.IsBusy = false;
						return;
					}
					onlyFileName = onlyFileName.Replace(" ", "_");
					byte[] imageBytes = System.IO.File.ReadAllBytes(file);
					string ext = System.IO.Path.GetExtension(file);
					DTO_ClaimDocument documentUploadRequest = new DTO_ClaimDocument
					{
						FileBytes = Convert.ToBase64String(imageBytes),
						FileName = onlyFileName,
						FileExt = ext,
						ClaimID = Claim.ClaimID,
						DocTypeID = DocTypeID,
						DocumentDate = DateTime.Today

					};
					try
					{

						await s1.AddClaimDocument(documentUploadRequest);


					}
					catch (Exception ex)
					{
						System.Windows.MessageBox.Show(ex.ToString());
						busyIndicator.IsBusy = false;


					}

					if (documentUploadRequest.Message == null)
					{
						busyIndicator.IsBusy = false;
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

					busyIndicator.IsBusy = false;
					break;
			}



		}




		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			busyIndicator.IsBusy = false;
		}

		//Connects to a URL and attempts to download the file

	}
}
