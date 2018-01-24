#region Usings and namespace declaration


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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using MRN_Claim_Services.Controllers;
using System.IO;
using MRNNexus_Model;
using System.Globalization;
using static MRN_Claim_Services.Controllers.ServiceLayer;

namespace MRN_Claim_Services
{

	/// <summary>
	/// Interaction logic for AnalogFileUploadPage.xaml
	/// </summary>
	/// 

	#endregion


	#region Initialization of Class

	public partial class AnalogFileUploadPage : Page
	{

		ServiceLayer s1 = MRN_Claim_Services.Controllers.ServiceLayer.getInstance();
		public WhenClicked whenclicked = new WhenClicked();
		public BitmapImage bitmap = new BitmapImage();
		static Uri src = new Uri(@"/MRN_Claim_Services/ResourceFiles/RoofInspectionWizardBkgnd.png", UriKind.Relative);
		BitmapImage img = new BitmapImage(src);
		public List<string> FileList = new List<string>();
		Geometry _textGeometry = null;
		Geometry _textHighlightGeometry = null;
		string[] files;
		string file;
		bool processingfile;
		int currentcount = 0;
		int totalcount = 0;
		string FullFilePath = "";
		public System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();

        internal ServiceLayer S1
        {
            get
            {
                return s1;
            }

            set
            {
                s1 = value;
            }
        }

        public AnalogFileUploadPage()
		{
			InitializeComponent();
			this.ClaimList.ItemsSource = S1.ClaimsList;
			this.AvailableDocuments.ItemsSource = S1.ClaimDocTypes;

			img.UriSource = src;
		}

		#endregion
		#region WhileProcessing


		public partial class WhenClicked
		{

			public Task WhenClick(System.Windows.Controls.Button SubmitBtn)
			{
				var next = new TaskCompletionSource<bool>();
				RoutedEventHandler handler = null;
				handler = (s, e) =>
				{

					next.TrySetResult(true);
					SubmitBtn.Click -= handler;
				};
				SubmitBtn.Click += handler;
				return next.Task;
			}
		}


		private async Task WaitForPress(string[] filestoprocess)
		{
			foreach (string s in filestoprocess)
			{

				var file = s;

				{
					image.Source = GetImage(s);
					FullFilePath = s;
					UpdateImageText(FormatText(TextToOverlayPicture.Text, System.Windows.Media.Brushes.Cyan, new Typeface("Times New Roman")), FullFilePath, false);

				}
				await whenclicked.WhenClick(SubmitBtn);
			}
		}

		#endregion


		#region FileSelection


		#region Maybe Depreciated

		async private void SelectFile(string[] filetodisplay = null)
		{


			//this function has been changed from its original state to help navigate the files to be sent for storage and turned itself from work horse to helper function to keep 
			//everything and all other functions that depended on it for file automatic detection of files that are being presented for archival and manipulation
			//was very clean but has recently became a little more messy while trying to retrofit it to its new purpose of traffic control function
			#region OldSelectFileFunciton
			/*
		 * 
		 * this is the old function and it is clear to see that it has been changed*
		 * 
		 * private string SelectFile()
	{
		var fileDialog = new System.Windows.Forms.OpenFileDialog();
		var result = fileDialog.ShowDialog();

		if (result == DialogResult.OK)
		{
			FullFilePath = fileDialog.FileName;
			return fileDialog.FileName;

		}
		else return "User Canceled Operation";

	}

		 */
			#endregion



			if (filetodisplay != null && filetodisplay.Count() > 1)
				await WaitForPress(filetodisplay);
			else
				UpdateImageText(FormatText(TextToOverlayPicture.Text, System.Windows.Media.Brushes.Cyan, new Typeface("Times New Roman")), FullFilePath, false);

			}

					


			
		

	
		#endregion

		private void PrepareFileOpenDialog(string DocumentToImport)
		{
			if (DocumentToImport == "Inspection Photos")
			{
				this.fileDialog.Multiselect = true;
				this.fileDialog.DefaultExt = ".png";
				this.fileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files(*gif)|*.gif";

			}

			else
			{
				this.fileDialog.DefaultExt = ".png";
				this.fileDialog.Filter = "PDF Files (*.pdf)";
			}

			var result = fileDialog.ShowDialog();


			if (System.Windows.Forms.DialogResult.OK == result)
			{
				if (DocumentToImport == "Inspection Photos")
					files = fileDialog.FileNames;
				else
					file = fileDialog.FileName;
			}
		}









		#endregion

		#region ImageVerification


		protected BitmapImage GetImage(string filetoshow = null, bool isUpdate = false)
		{
			//function used to check to see if bitmap variable has a bitmap stored and if it doesnt finds the appropriate one and if that cant be found starts at the beginning to make it available
			//chances are that alot of this burden will be shared by other function written after it but i left it in place just in case it can be used
			//this function may find itself depreciated although it is great in singular file capture for manipulation

			if (bitmap != null && isUpdate)
			{
				image.Source = bitmap;
				return bitmap;
			}
			else
			{
				bitmap.BeginInit();
				if (filetoshow != null)
				{
					bitmap.UriSource = new Uri(filetoshow, UriKind.Absolute);
					image.Source = bitmap;

				}
				else
				{
					//bitmap.UriSource = new Uri((PrepareFileOpenDialog(AvailableDocuments.Text)), UriKind.Absolute);
				}
				bitmap.EndInit();
				image.Source = bitmap;
				return bitmap;

			}

		}

		#endregion

		#region Adding and displaying text on image functions

		private void TextToOverlayPicture_TextChanged(object sender, TextChangedEventArgs e)
		{
			//used to signal to ui that change has been made that needs to be shown to user in ui to verify that change is correct in realtime before saving
			//im sure some cost savings can be found in this image manipulation class but can be used in production case for now pinto status great catillac status caution at best.

			UpdateImageText(FormatText(TextToOverlayPicture.Text, System.Windows.Media.Brushes.Cyan, new Typeface("Times New Roman")), FullFilePath, false);

		}

		public void UpdateImageText(FormattedText text, string ImgPath = null, bool bSave = false)
		{
			//call this function anytime a text change is made to be displayed on to image shows in real time carries the save boolean when user has finished making changes and accepts

			WriteTextToImage(GetImage(ImgPath, true), ImgPath, text, new System.Windows.Point((bitmap.PixelWidth / 2) - (text.Width / 2), bitmap.PixelHeight - text.Height), bSave, _textGeometry);


		}




		private FormattedText FormatText(string str, System.Windows.Media.Brush brush, Typeface tf)
		{
			// function that is work to prepare for display function as to help compartmentalize all the necessary steps in making text changes to display in realtime

			FormattedText text = new FormattedText(
			str,
				CultureInfo.InvariantCulture,
				System.Windows.FlowDirection.LeftToRight,
				tf,
				70,
				brush);
			// this nugget is necessary period to create a situation where no mods to the text are necessary to view on any pic background
			_textGeometry = text.BuildGeometry(new System.Windows.Point((bitmap.PixelWidth / 2) - (text.Width / 2), bitmap.PixelHeight - text.Height));

			// this nugget is unnecessary and probably should be removed cause it really provides no feature or worth to any thing but is different in a manner of speaking

			_textHighlightGeometry = text.BuildHighlightGeometry(new System.Windows.Point((bitmap.PixelWidth / 2) - (text.Width / 2), bitmap.PixelHeight - text.Height));


			return text;
		}



		public void WriteTextToImage(BitmapImage bitmap, string inputFile, FormattedText text, System.Windows.Point position, bool Save = false, Geometry _textGeometry = null, Geometry _textHighlightGeometry = null)
		{
			//used to make changes and write text onto images before uploading to server for final storage
			//some more modifications need to be made for customization but not necessary other than to be more feature rich can be used as is in the context of this file 
			//changes would be necessary to make this function portable outside the context of this codebehind

			//	BitmapImage bitmap = new BitmapImage(new Uri(inputFile)); // inputFile must be absolute path
			DrawingVisual visual = new DrawingVisual();
			if (bitmap != null)
			{

				using (DrawingContext dc = visual.RenderOpen())
				{
					dc.DrawImage(bitmap, new Rect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight));
					if (_textGeometry == null)
						dc.DrawText(text, position);
					else
						dc.DrawGeometry(System.Windows.Media.Brushes.DarkRed, new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 2), _textGeometry);
					if (_textHighlightGeometry != null)
						dc.DrawGeometry(new System.Windows.Media.ImageBrush(new System.Windows.Controls.Image().Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Snotacus\\Dropbox\\MRN_Claim_Services\\MRN_Claim_Services\\ResourceFiles\\RoofInspectionWizardBkgnd.png")), new System.Windows.Media.Pen(new System.Windows.Media.ImageBrush(new System.Windows.Controls.Image().Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Snotacus\\Dropbox\\MRN_Claim_Services\\MRN_Claim_Services\\ResourceFiles\\RoofInspectionWizardBkgnd.png")), 2), _textHighlightGeometry);

				}

				RenderTargetBitmap target = new RenderTargetBitmap(bitmap.PixelWidth, bitmap.PixelHeight,
																   bitmap.DpiX, bitmap.DpiY, PixelFormats.Default);
				target.Render(visual);
				image.Source = target;

				// Save is set to true when user is satisfied with the text on the picture
				// some functional changes will need to be made to make this save files in the right place on upload but that should be taken care of on upload this is for temporary storage only 
				// 


				if (Save)
				{
					string path = System.IO.Path.GetDirectoryName(inputFile);
					string filename = System.IO.Path.GetFileNameWithoutExtension(inputFile);
					string ext = System.IO.Path.GetExtension(inputFile);
					string outputFile = path + "\\" + filename + @"_TextAdded" + ext;
					DisplayVisual(target, outputFile, Save);
				}
			}
		}

		#endregion

		#region Local temporary storage and uploading permenent storage of files/images



		private void DisplayVisual(RenderTargetBitmap target, string outputFile, bool Save = false)
		{

			// should be apparent that is is a funtion to help determine what type file the original picture was and helps in saving it in its native format after manipulation
			// probably should be shortened to either png or jpg only just for simplicity sake and to help any future coding to be easier as to determine what if any other file types are to be manipulated
			BitmapEncoder encoder = null;

			switch (System.IO.Path.GetExtension(outputFile))
			{
				case ".png":
					encoder = new PngBitmapEncoder();
					break;
				// more encoders here

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
					{
						encoder.Save(outputStream);

					}
				}

			}

		}

		private void Upload(string file)
		{

			string onlyFileName = System.IO.Path.GetFileNameWithoutExtension(file);
			byte[] imageBytes = System.IO.File.ReadAllBytes(file);
			string ext = System.IO.Path.GetExtension(file);

			//	SaveTo(AddTextToImage(TextToOverlayPicture.Text, onlyFileName), onlyFileName + "TextAdded");      //Get Text overlay display pic rename image prepare for upload after modifications

			DTO_ClaimDocument documentUploadRequest = new DTO_ClaimDocument
			{
				FileBytes = Convert.ToBase64String(imageBytes),
				FileName = onlyFileName,
				FileExt = ext,
				ClaimID = int.Parse(ClaimList.Text),
				DocTypeID = AvailableDocuments.SelectedIndex,
				DocumentDate = DateTime.Today
			};
		}

		async private void UploadFile(DTO_ClaimDocument documentUploadRequest)
		{

			//intended to use after display and local save of changes to upload finalized document to server for keeping
			await S1.AddClaimDocument(documentUploadRequest);



		}


		#endregion

		#region Validation and Navigation


		async private void getImage_Click(object sender, RoutedEventArgs e)
		{
			//will be used to retrieve already stored document to see if user really wants to replace it after ui finds that a document for that claim already exist and only 1 or a limited number of the documents are already saved
			//technically over write verification advanced feature
			await S1.GetClaimDocumentsByClaimID(new DTO_Claim
			{
				ClaimID = 30
			});

		//	bitmap.UriSource = new Uri((SelectFile()), UriKind.Absolute);
		}



		private void LogOut(object sender, RoutedEventArgs e)
		{
			Login Page = new Login();
			this.NavigationService.Navigate(Page);
		}

		private void SubmitBtn_Click(object sender, RoutedEventArgs e)
		{
			//saves current file after modification and validation viewing

			UpdateImageText(FormatText(TextToOverlayPicture.Text, System.Windows.Media.Brushes.Cyan, new Typeface("Times New Roman")), FullFilePath, true);
		}

		private void BtnFileOpen_Click(object sender, RoutedEventArgs e)
		{
			//used to setup file open dialog box based on the document type to be uploaded... basically whether or not multifile and what filetype filter...ie jpg pdf txt ....etc...
			PrepareFileOpenDialog(AvailableDocuments.Text);

		}

		private void ClaimList_DropDownClosed(object sender, EventArgs e)
		{

			//called when claimlist dropdown is closed after selection of claim to attach the file to by user in ui
			// validates user input and calls next step for user

			if (ClaimList.SelectedIndex > -1)
			{
				AvailableDocuments.IsEnabled = true;
				AvailableDocuments.Focus();
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("Select a claim to import file(s) into.", "Select a claim.", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Question);
				ClaimList.IsDropDownOpen = true;
			}
		}

		private void ClaimList_GotFocus(object sender, RoutedEventArgs e)
		{
			//opens the dropdown upon initialization to help move the user in the desired direction as to expidite the actions necessary to move to the next file
			ClaimList.IsDropDownOpen = true;
		}

		async private void AvailableDocuments_DropDownClosed(object sender, EventArgs e)
		{
			//called when user selects a claimdocument to verify that the document doesn't exist to make sure that the actions pending are congruent with the database schema
			await CheckForExistingDocument(AvailableDocuments.SelectedIndex + 1);




		}

		async private Task<bool> CheckForExistingDocument(int DocumentTypeID)
		{
			// prototype unchecked at this point to validate that the file about to be scheduled for upload is non existent and if so should it be overwritten or kept

			DTO_Claim claim = new DTO_Claim();
			claim.MRNNumber = ClaimList.SelectedItem.ToString();
			DTO_ClaimDocument claimdoc = new DTO_ClaimDocument();
			await S1.GetClaimDocumentsByClaimID(claim);
			List<DTO_ClaimDocument> doclist = new List<DTO_ClaimDocument>();
			foreach (DTO_ClaimDocument d in doclist)
			{
				if (d.DocTypeID.ToString() != (DocumentTypeID).ToString())
				{
					return true;
				}

			}
			return false;

		}


		#endregion


		#region EndofClass and namespace declaration

	}

}
#endregion




#region OldWorkingCode


/*
 * 
 * 
 * the entire before this change working code just incase its easier to scrap and start over from a working model including the xaml file changes that will be necessary to make this codebehind function as normal
 * using System;
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

using System.IO;
using MRNNexus_Model;
using System.Globalization;

namespace MRN_Claim_Services
{
/// <summary>
/// Interaction logic for AnalogFileUploadPage.xaml
/// </summary>
public partial class AnalogFileUploadPage : Page
{
	ServiceLayer s1 = ServiceLayer.getInstance();
	public BitmapImage bitmap = new BitmapImage();
	static Uri src = new Uri(@"/MRN_Claim_Services;/ResourceFiles/RoofInspectionWizardBkgnd.png", UriKind.Relative);
	BitmapImage img = new BitmapImage(src);

	Geometry _textGeometry = null;
	Geometry _textHighlightGeometry = null;
	string file = "";
	string FullFilePath = "";
	public AnalogFileUploadPage()
	{
		InitializeComponent();
		this.ClaimList.ItemsSource = s1.ClaimsList;
		this.AvailableDocuments.ItemsSource = s1.ClaimDocTypes;
		ShowImage();
		img.UriSource = src;
	}
	private void LogOut(object sender, RoutedEventArgs e)
	{
		Login Page = new Login();
		this.NavigationService.Navigate(Page);
	}

	private void SubmitBtn_Click(object sender, RoutedEventArgs e)
	{
		//var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(file);
		//if (AvailableDocuments.SelectedItem.ToString() == string.Empty || AvailableDocuments.SelectedItem.ToString() == null)
		//	onlyFileName = AvailableDocuments.SelectedItem.ToString();
		//onlyFileName = onlyFileName.Replace(" ", "_");

		UpdateImageText(FormatText(TextToOverlayPicture.Text, System.Windows.Media.Brushes.Cyan, new Typeface("Times New Roman")), FullFilePath, true);
	}

	private void BtnFileOpen_Click(object sender, RoutedEventArgs e)
	{

		UploadImage();

	}


	async private void UploadImage()
	{
		var fileDialog = new System.Windows.Forms.OpenFileDialog();
		var result = fileDialog.ShowDialog();
		switch (result)
		{
			case System.Windows.Forms.DialogResult.OK:
				FullFilePath = fileDialog.FileName;
				var file = fileDialog.FileName;
				TextFile.Text = file;
				TextFile.ToolTip = file;
				var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(file);
				if (AvailableDocuments.SelectedItem.ToString() == string.Empty || AvailableDocuments.SelectedItem.ToString() == null)
					onlyFileName = AvailableDocuments.SelectedItem.ToString();
				onlyFileName = onlyFileName.Replace(" ", "_");

				byte[] imageBytes = System.IO.File.ReadAllBytes(file);
				string ext = System.IO.Path.GetExtension(file);

				//	SaveTo(AddTextToImage(TextToOverlayPicture.Text, onlyFileName), onlyFileName + "TextAdded");      //Get Text overlay display pic rename image prepare for upload after modifications

				DTO_ClaimDocument documentUploadRequest = new DTO_ClaimDocument
				{
					FileBytes = Convert.ToBase64String(imageBytes),
					FileName = onlyFileName,
					FileExt = ext,
					ClaimID = int.Parse(ClaimList.Text),
					DocTypeID = AvailableDocuments.SelectedIndex,
					DocumentDate = DateTime.Now
				};


				await s1.AddClaimDocument(documentUploadRequest);

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
				TextFile.Text = null;
				TextFile.ToolTip = null;
				break;
		}
	}

	async private void getImage_Click(object sender, RoutedEventArgs e)
	{


		await s1.GetClaimDocumentsByClaimID(new DTO_Claim
		{
			ClaimID = 30
		});

		bitmap.UriSource = new Uri(SelectFile(), UriKind.Absolute);
	}


	public void WriteTextToImage(BitmapImage bitmap, string inputFile, FormattedText text,  System.Windows.Point position, bool Save = false, Geometry _textGeometry=null, Geometry _textHighlightGeometry=null)
	{

		//	BitmapImage bitmap = new BitmapImage(new Uri(inputFile)); // inputFile must be absolute path
		DrawingVisual visual = new DrawingVisual();
		if (bitmap != null)
		{

			using (DrawingContext dc = visual.RenderOpen())
			{
				dc.DrawImage(bitmap, new Rect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight));
				if (_textGeometry == null)
					dc.DrawText(text, position);
				else// System.Windows.Media.Pen(System.Windows.Media.Brushes.Black
					dc.DrawGeometry(System.Windows.Media.Brushes.DarkRed, new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 2 ), _textGeometry);
				if (_textHighlightGeometry!=null)
				dc.DrawGeometry(new System.Windows.Media.ImageBrush(new System.Windows.Controls.Image().Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Snotacus\\Dropbox\\MRN_Claim_Services\\MRN_Claim_Services\\ResourceFiles\\RoofInspectionWizardBkgnd.png")), new System.Windows.Media.Pen(new System.Windows.Media.ImageBrush(new System.Windows.Controls.Image().Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Snotacus\\Dropbox\\MRN_Claim_Services\\MRN_Claim_Services\\ResourceFiles\\RoofInspectionWizardBkgnd.png")), 2),_textHighlightGeometry);

			}

			RenderTargetBitmap target = new RenderTargetBitmap(bitmap.PixelWidth, bitmap.PixelHeight,
															   bitmap.DpiX, bitmap.DpiY, PixelFormats.Default);
			target.Render(visual);
			image.Source=target;
			string path = System.IO.Path.GetDirectoryName(inputFile);
			string filename = System.IO.Path.GetFileNameWithoutExtension(inputFile);
			string ext = System.IO.Path.GetExtension(inputFile);
			string outputFile = path + "\\"+filename + @"_TextAdded" + ext;
			DisplayVisual(target, outputFile, Save);
		}
	}


	public void UpdateImageText(FormattedText text, string ImgPath=null, bool bSave=false)
	{

			WriteTextToImage(ShowImage(ImgPath,true), ImgPath, text,	new System.Windows.Point((bitmap.PixelWidth/2)-(text.Width/2), bitmap.PixelHeight-text.Height), bSave,_textGeometry);


	}


	private void TextToOverlayPicture_TextChanged(object sender, TextChangedEventArgs e)
	{
		TextOverlay.Text = TextToOverlayPicture.Text;
		UpdateImageText(FormatText(TextToOverlayPicture.Text, System.Windows.Media.Brushes.Cyan, new Typeface("Times New Roman")),FullFilePath, false);

	}

	private FormattedText FormatText(string str, System.Windows.Media.Brush brush, Typeface tf)
	{

		FormattedText text = new FormattedText(
		str,
			CultureInfo.InvariantCulture,
			System.Windows.FlowDirection.LeftToRight,
			tf,
			70,
			brush);
		_textGeometry = text.BuildGeometry(new System.Windows.Point((bitmap.PixelWidth / 2) - (text.Width / 2), bitmap.PixelHeight - text.Height));
		_textHighlightGeometry = text.BuildHighlightGeometry(new System.Windows.Point((bitmap.PixelWidth / 2) - (text.Width / 2), bitmap.PixelHeight - text.Height));


		return text;
	}




	protected BitmapImage ShowImage(string filetoshow = null, bool isUpdate = false) {


		if (bitmap != null && isUpdate)
		{
			image.Source = bitmap;
			return bitmap;
		}
		else
		{
			bitmap.BeginInit();
			if (filetoshow != null)
			{
				bitmap.UriSource = new Uri(filetoshow, UriKind.Absolute);
				image.Source = bitmap;

			}
			else
			{
				bitmap.UriSource = new Uri(SelectFile(), UriKind.Absolute);
			}
			bitmap.EndInit();
			image.Source = bitmap;
			return bitmap;

		}

	}



	private string SelectFile()
	{
		var fileDialog = new System.Windows.Forms.OpenFileDialog();
		var result = fileDialog.ShowDialog();

		if (result == DialogResult.OK)
		{
			FullFilePath = fileDialog.FileName;
			return fileDialog.FileName;

		}
		else return "User Canceled Operation";

	}



	private void DisplayVisual(RenderTargetBitmap target, string outputFile, bool Save=false)
	{
		BitmapEncoder encoder = null;

		switch (System.IO.Path.GetExtension(outputFile))
		{
			case ".png":
				encoder = new PngBitmapEncoder();
				break;
			// more encoders here

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
				{
					encoder.Save(outputStream);

				}
			}

		}

	}
}

}

******************************************************************************************************************************************************************************************************************
<Page
  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
  xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
  xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
  xmlns:local="clr-namespace:MRN_Claim_Services"
  xmlns:MRNNexus_Model="clr-namespace:MRNNexus_Model;assembly=MRNNexus_Model" x:Class="MRN_Claim_Services.AnalogFileUploadPage"
  mc:Ignorable="d"
  Title="AnalogFileUploadPage" Height="606" Width="738">

<Page.Resources>
	<CollectionViewSource x:Key="dTO_LU_ClaimDocumentTypeViewSource" d:DesignSource="{d:DesignInstance {x:Type MRNNexus_Model:DTO_LU_ClaimDocumentType}, CreateList=True}"/>
	<Image x:Key="imagesrc2">
		<Image.Source x:Uid="n">
			<BitmapImage  x:Name="jon" UriSource="C:\Users\Snotacus\Dropbox\MRN_Claim_Services\MRN_Claim_Services\ResourceFiles\RoofInspectionWizardBkgnd.png"></BitmapImage>
		</Image.Source>
	</Image>
</Page.Resources>

<Grid Margin="0,0,-1,0" DataContext="{StaticResource dTO_LU_ClaimDocumentTypeViewSource}">
	<!--<Button x:Name="SubmitBTN" Content="GetData" HorizontalAlignment="Left" Margin="362,385,0,0" VerticalAlignment="Top" Width="75" Click="SubmitBTN_Click"/>
	<DataGrid x:Name="dataGrid" AutoGenerateColumns ="false" HorizontalAlignment="Left" Margin="48,39,0,0" VerticalAlignment="Top" Height="234" Width="196">
		<DataGrid.Columns>
			<DataGridTextColumn x:Name="StartTime" Binding="{Binding StartTime}" Header="StartTime" />
			<DataGridTextColumn x:Name="EndTime" Binding="{Binding EndTime}" Header="Endtime" />
			<DataGridTextColumn x:Name="Note" Binding="{Binding Note}" Header="Note" />
			<DataGridTextColumn x:Name="AppointmentType" Binding="{Binding AppointmentType}" Header="AppointmentType" />
			<DataGridTextColumn x:Name="CustomerName" Binding="{Binding CustomerName}" Header="CustomerName" />
		</DataGrid.Columns>
	</DataGrid>-->


	<TextBox x:Name="TextFile" HorizontalAlignment="Left" Height="22" Margin="624,516,0,0" TextWrapping="Wrap" Text="" VerticalAlignment="Top" Width="105" Visibility="Hidden"/>
	<Button x:Name="BtnFileOpen" Content="_Browse ..." HorizontalAlignment="Left" Margin="656,518,0,0" VerticalAlignment="Top" Width="74" /><!--Click="BtnFileOpen_Click"-->
	<Button x:Name="getImage" Content="Get Image" HorizontalAlignment="Left" Margin="504,30,0,0" VerticalAlignment="Top" Width="74" Click="getImage_Click"/>
	<ComboBox x:Name="ClaimList" HorizontalAlignment="Left" Margin="112,61,0,0" VerticalAlignment="Top" Width="120" DataContext="{Binding}" ItemsSource="{Binding Mode=OneWay}" DisplayMemberPath="MRNNumber"/>
	<Canvas x:Name="canvas"  HorizontalAlignment="Left" Height="387" Margin="62,97,0,0" VerticalAlignment="Top" Width="556">
		<Image x:Name="image" Height="377" Width="546" Source="http://services.mrncontracting.com/" Stretch="UniformToFill"/>
		<TextBlock x:Name="TextOverlay" Height="45" Canvas.Left="0" TextWrapping="Wrap" Canvas.Bottom="0"  Panel.ZIndex="10" Width="{Binding ActualWidth, ElementName=canvas, Mode=OneWay}" />
	</Canvas>
	<Label x:Name="label" Content="Available Claims" HorizontalAlignment="Left" Margin="112,30,0,0" VerticalAlignment="Top" Width="120" Foreground="White"/>
	<ComboBox x:Name="AvailableDocuments" HorizontalAlignment="Left" Margin="454,61,0,0" VerticalAlignment="Top" Width="120" SelectedValuePath="ClaimDocumentType" ItemsSource="{Binding Mode=OneWay}" DisplayMemberPath="ClaimDocumentType"/>
	<Label x:Name="label_Copy" Content="Available Document Types" HorizontalAlignment="Left" Margin="368,30,0,0" VerticalAlignment="Top" Width="120" Foreground="White"/>
	<TextBox x:Name="TextToOverlayPicture" HorizontalAlignment="Left" Height="27" Margin="173,511,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="381" TextChanged="TextToOverlayPicture_TextChanged"/>
	<Button x:Name="AddPicture" Content="_Add Document" HorizontalAlignment="Left" Margin="624,543,0,0" VerticalAlignment="Top" Width="106"/>
	<Button x:Name="SubmitBtn" Content="_Submit" HorizontalAlignment="Left" Height="30" Margin="656,483,0,0" VerticalAlignment="Top" Width="73" IsDefault="True" Click="SubmitBtn_Click"/>

</Grid>
</Page>





 * 
 * 




 */


#endregion













//SAVING FILES TO DISK
//string filename = fileDialog.FileName = @"newfile" + ext;

//using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
//{
//    saveFileDialog1.FileName = filename;
//    if (System.Windows.Forms.DialogResult.OK != saveFileDialog1.ShowDialog())
//        return;
//    System.IO.File.WriteAllBytes(saveFileDialog1.FileName,Convert.FromBase64String(s1.ClaimDocument.FileBytes));
//}

