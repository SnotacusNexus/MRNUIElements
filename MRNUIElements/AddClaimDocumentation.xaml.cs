using System;
using System.Net;
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
	/// Interaction logic for AddClaimDocumentation.xaml
	/// </summary>

	public partial class AddClaimDocumentation : Page
	{

		static ServiceLayer s1 = ServiceLayer.getInstance();
		public BitmapImage bitmap = new BitmapImage();
		public static ImageSource imgsrc = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Snotacus\\Dropbox\\MRNUIElements\\MRNUIElements\\ResourceFiles\\RoofInspectionWizardBkgnd.png");
		Geometry _textGeometry = null;
		Geometry _textHighlightGeometry = null;
		List<string> FileList = new List<string>();
		public DTO_Claim claim = new DTO_Claim();

		string FullFilePath = "";
		public AddClaimDocumentation()
		{
			InitializeComponent();
			this.ClaimList.ItemsSource = s1.ClaimsList;
			this.AvailableDocuments.ItemsSource = s1.ClaimDocTypes;
			AvailableDocuments.IsEnabled = false;
			BitmapSource bitmap = (BitmapSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Snotacus\\Dropbox\\MRNUIElements\\MRNUIElements\\ResourceFiles\\RoofInspectionWizardBkgnd.png");
			SubmitBtn.IsEnabled = false;
			if (!ClaimList.IsFocused)
				ClaimList.Focus();
			image.Source = imgsrc;
			image.Stretch = Stretch.Uniform;
			image.StretchDirection = StretchDirection.DownOnly;
			//ShowImage();
		}

		private List<string> SelectFile(int docTypeID)
		{
			var fileDialog = new System.Windows.Forms.OpenFileDialog();
			if (docTypeID == 2)
				fileDialog.Multiselect = true;
			else
				fileDialog.Multiselect = false;
			fileDialog.Title = AvailableDocuments.SelectedValue.ToString() + " Import Tool";
			fileDialog.Filter = Filter(docTypeID);
			var result = fileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				FullFilePath = fileDialog.FileName;
				foreach (string s in fileDialog.FileNames)
				{

					FileNames.Add(s);
				}
				FileListBox.ItemsSource = FileNames;
				FileListBox.SelectedIndex = 0;
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

		protected BitmapImage DisplayImage(ImageSource imgsrc)
		{

			return (BitmapImage)imgsrc;


		}






		private void LogOut(object sender, RoutedEventArgs e)
		{
			Login Page = new Login();
			this.NavigationService.Navigate(Page);
		}

		private void SubmitBtn_Click(object sender, RoutedEventArgs e)
		{
			//if (string.IsNullOrEmpty(FullFilePath))
			//	SelectFile();


			//var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(FullFilePath);
			//if (AvailableDocuments.SelectedItem.ToString() == string.Empty || AvailableDocuments.SelectedItem.ToString() == null)
			//	onlyFileName = AvailableDocuments.SelectedItem.ToString();
			//onlyFileName = onlyFileName.Replace(" ", "_");
			//	System.Windows.Forms.MessageBox.Show(FileListBox.SelectedValue.ToString());
			//UploadImage(FileListBox.SelectedValue.ToString());
			// ****************** We Have a winner, we select this file as the winner now do what you will currently it saves it locally but we can if we want to upload it.**************
			//	UpdateImageText(FormatText(TextToOverlayPicture.Text, System.Windows.Media.Brushes.Cyan, new Typeface("Times New Roman")), FullFilePath, true);
			UploadImage(FullFilePath);
		}

		private void BtnFileOpen_Click(object sender, RoutedEventArgs e)
		{
			UploadImage();
		}

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
			WriteTextToImage(ShowImage(null, ImgPath, true), ImgPath, text, new System.Windows.Point((bitmap.PixelWidth / 2) - (text.Width / 2), bitmap.PixelHeight - text.Height), bSave, _textGeometry);
		}

		private FormattedText FormatText(string str, System.Windows.Media.Brush brush, Typeface tf)
		{
			// function that is work to prepare for display function as to help compartmentalize all the necessary steps in making text changes to display in realtime
			FormattedText text = new FormattedText(
			str,
			CultureInfo.CurrentCulture,
			System.Windows.FlowDirection.LeftToRight,
			tf,
			bitmap.PixelHeight / 10,
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
			//BitmapImage bitmap1 = new BitmapImage(new Uri(inputFile)); // inputFile must be absolute path
			//	image.Source = bitmap1;
			DrawingVisual visual = new DrawingVisual();

			if (bitmap != null)
			{

				using (DrawingContext dc = visual.RenderOpen())
				{
					//bitmap1.BeginInit();

					//image.Stretch = Stretch.Uniform;
					//	image.StretchDirection = StretchDirection.Both;

					dc.DrawImage(bitmap, new Rect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight));
					if (_textGeometry == null)
						dc.DrawText(text, position);
					else
						dc.DrawGeometry(System.Windows.Media.Brushes.DarkRed, new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, bitmap.Height / 500), _textGeometry);
					if (_textHighlightGeometry != null)
						dc.DrawGeometry(new System.Windows.Media.ImageBrush(new System.Windows.Controls.Image().Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Snotacus\\Dropbox\\MRNUIElements\\MRNUIElements\\ResourceFiles\\RoofInspectionWizardBkgnd.png")), new System.Windows.Media.Pen(new System.Windows.Media.ImageBrush(new System.Windows.Controls.Image().Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Snotacus\\Dropbox\\MRNUIElements\\MRNUIElements\\ResourceFiles\\RoofInspectionWizardBkgnd.png")), 2), _textHighlightGeometry);
					dc.Close();
				}

				//bitmap1.EndInit();
				RenderTargetBitmap target = new RenderTargetBitmap(bitmap.PixelWidth, bitmap.PixelHeight, 96, 96, PixelFormats.Default);
				target.Render(visual);

				var renderTargetbitmap = target;
				var bitmapImage = new BitmapImage();
				var bitmapEncoder = new PngBitmapEncoder();
				bitmapEncoder.Frames.Add(BitmapFrame.Create(target));
				using (var stream = new MemoryStream())
				{
					bitmapEncoder.Save(stream);
					//	stream.Seek(0, SeekOrigin.Begin);
					//bitmapImage.BeginInit();
					//bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
					bitmapImage.StreamSource = stream;
					//	bitmapImage.EndInit();
				}
				bitmap = bitmapImage;
				image.Source = bitmapImage;

				image.Source = target;
				image.Stretch = Stretch.Uniform;
				image.StretchDirection = StretchDirection.DownOnly;
				// Save is set to true when user is satisfied with the text on the picture
				// some functional changes will need to be made to make this save files in the write place on upload but that should be taken care of on upload this is for temporary storage only 
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

		//public static BitmapSource ConvertBitmapTo96DPI(BitmapImage bitmapImage)
		//{
		//	double dpi = 96;
		//	int width = bitmapImage.PixelWidth;
		//	int height = bitmapImage.PixelHeight;

		//	int stride = width * bitmapImage.Format.BitsPerPixel;
		//	byte[] pixelData = new byte[stride * height];
		//	bitmapImage.CopyPixels(pixelData, stride, 0);

		//	return BitmapSource.Create(width, height, dpi, dpi, bitmapImage.Format, null, pixelData, stride);
		//}




		#endregion

		private void ClaimList_DropDownClosed(object sender, EventArgs e)
		{
			//called when claimlist dropdown is closed after selection of claim to attach the file to by user in ui
			// validates user input and calls next step for user

			if (ClaimList.SelectedIndex > -1)
			{
				AvailableDocuments.IsEnabled = true;
				AvailableDocuments.Focus();
				//ShowCollectedClaimDocuments((DTO_Claim)ClaimList.SelectedItem);
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("Select a claim to import file(s) into.", "Select a claim.", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Question);

			}
		}

		//public class SizeToStretchConverter : IValueConverter
		//{
		//	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		//	{
		//		return (int)value <= targetWidth ? Stretch.None : Stretch.Uniform;
		//	}

		//	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		//	{
		//		throw new NotImplementedException();
		//	}
		//}


		private void ClaimList_GotFocus(object sender, RoutedEventArgs e)
		{
			//opens the dropdown upon initialization to help move the user in the desired direction as to expidite the actions necessary to move to the next file
			if (!ClaimList.IsDropDownOpen && ClaimList.IsFocused)
				ClaimList.IsDropDownOpen = true;

		}


		private void AvailableDocuments_GotFocus(object sender, RoutedEventArgs e)
		{
			if (AvailableDocuments.IsFocused)
			{
				AvailableDocuments.IsDropDownOpen = true;
				ClaimList.IsEnabled = false;
			}
		}

		async private void AvailableDocuments_DropDownClosed(object sender, EventArgs e)
		{
			//called when user selects a claimdocument to verify that the document doesnt exist to make sure that the actions pending are congruent with the database schema
			bool b;
			if (AvailableDocuments.SelectedIndex > -1)

				if (ShowImage() != null)
				{
					SubmitBtn.IsEnabled = true;
					SkipFileButton.IsEnabled = true;
					DeleteFileButton.IsEnabled = true;
					if (s1.ClaimDocumentsList != null)
					{
						b = await CheckFileExist();
						if (b) getImage.IsEnabled = true;
						else getImage.IsEnabled = false;
					}

				}
			//	else
			//	bitmap = null;
		}

		async public Task<bool> CheckFileExist(int cdt = 0)
		{                                                           //the worker function to callback after determining if the file exists in the location that has been picked if so it will ask what would you like to do with it.
			await s1.GetAllClaimDocuments();
			if (s1.ClaimDocumentsList.Exists(x => x.DocTypeID == AvailableDocuments.SelectedIndex + 1 && x.ClaimID == ((DTO_Claim)ClaimList.SelectedItem).ClaimID))
				return true;
			else return false;
		}

		async private void getImage_Click(object sender, RoutedEventArgs e)
		{
			DTO_Claim claim = new DTO_Claim();
			claim.ClaimID = ((DTO_Claim)AvailableDocuments.SelectedItem).ClaimID;

			await s1.GetAllClaimDocuments();

			ShowCollectedClaimDocuments(claim);
			bitmap.UriSource = new Uri(FileListBox.SelectedItem.ToString(), UriKind.Absolute);
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
						PopTheTopOfListBox();// ok now then since the file has been appropriated then we can remove its name from our list of files to appropriate
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
			else
			{

			}
			switch (result)
			{
				case System.Windows.Forms.DialogResult.OK:
					if (filepathtoupload == null)
						FullFilePath = fileDialog.FileName;
					else
						FullFilePath = filepathtoupload;
					var file = FullFilePath;
					TextFile.Text = file;
					TextFile.ToolTip = file;
					var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(file);
					if (AvailableDocuments.SelectedItem.ToString() == string.Empty || AvailableDocuments.SelectedItem.ToString() == null)
						onlyFileName = AvailableDocuments.SelectedItem.ToString();
					onlyFileName = onlyFileName.Replace(" ", "_");
					byte[] imageBytes = System.IO.File.ReadAllBytes(file);
					string ext = System.IO.Path.GetExtension(file);
					DTO_ClaimDocument documentUploadRequest = new DTO_ClaimDocument
					{
						FileBytes = Convert.ToBase64String(imageBytes),
						FileName = onlyFileName,
						FileExt = ext,
						ClaimID = ((DTO_Claim)ClaimList.SelectedItem).ClaimID,
						DocTypeID = ((DTO_LU_ClaimDocumentType)AvailableDocuments.SelectedItem).ClaimDocumentTypeID,
						DocumentDate = DateTime.Today

					};

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
					break;
				case System.Windows.Forms.DialogResult.Cancel:
				default:
					TextFile.Text = null;
					TextFile.ToolTip = null;
					break;
			}
		}
		bool UploadInProgress(DTO_ClaimDocument cd)
		{




			return true;
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




		protected BitmapImage ShowImage(MemoryStream ms = null, string filetoshow = null, bool isUpdate = false)
		{
			if (ms != null)
				bitmap.StreamSource = ms;
			if (bitmap != null)
				return bitmap;
			bitmap.BeginInit();
			if (filetoshow != null)  //supposed to be for when you have a location and want to generate a bitmap of that file
			{
				bitmap.UriSource = new Uri(filetoshow, UriKind.Absolute);

			}
			else
			{

				SelectFile(AvailableDocuments.SelectedIndex + 1);  //initialization function if you try to use this function this forces you to find a bitmap to kick the whole thing off
				if (FileListBox.HasItems)
					if (Checkifimagetype(FullFilePath))
						bitmap.UriSource = new Uri(FullFilePath, UriKind.Absolute);
				UploadImage(FullFilePath);
			}

			bitmap.EndInit();
			image.Source = bitmap;
			image.Stretch = Stretch.Uniform;
			image.StretchDirection = StretchDirection.DownOnly;
			return bitmap;


		}

		private void FileListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (FileListBox.HasItems)
			{
				if (FileListBox.SelectedIndex < FileListBox.Items.Count)
					if (FileListBox.SelectedValue.ToString() != string.Empty)
						FullFilePath = FileListBox.SelectedValue.ToString();
				if (!Checkifimagetype(FileListBox.SelectedValue.ToString()))
					UploadImage(FileListBox.SelectedValue.ToString());
				else
				{

					BitmapSource bitmap = (BitmapSource)new ImageSourceConverter().ConvertFromString(FullFilePath);
					image.Source = bitmap;
					//	image.Stretch = Stretch.Uniform;
					//	image.StretchDirection = StretchDirection.DownOnly;

				}
			}
			else
			{
				ResetButtons();
				//	bitmap = null;
			}
		}

		private void FileListBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (FileListBox.HasItems)
				if (FileListBox.SelectedIndex > -1)
					FileListBox.SelectedValue.ToString();
		}

		private void ResetButtons()
		{
			if (SubmitBtn.IsEnabled == true)
				SubmitBtn.IsEnabled = false;
			if (SkipFileButton.IsEnabled == true)
				SkipFileButton.IsEnabled = false;
			if (DeleteFileButton.IsEnabled == true)
				DeleteFileButton.IsEnabled = false;
			if (getImage.IsEnabled == true)
				getImage.IsEnabled = false;

		}

		private void PopTheTopOfListBox()
		{
			//if (FileListBox.SelectedItems.Count > -1)
			//{
			if (FileListBox.SelectedItem != null)
			{
				FileListBox.Items.Remove(FileListBox.SelectedItem);
			}

			FileListBox.Focus();
			//}
		}

		private void AvailableDocuments_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			SelectFile(AvailableDocuments.SelectedIndex + 1);
			//		if (AvailableDocuments.SelectedValue.ToString().Contains("Check"))
			UploadImage();

		}
	}
}
