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
//using System.Drawing;
//using System.Drawing.Imaging;
//using System.Drawing.Drawing2D;
//using System.Drawing.Text;


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
		
		string FullFilePath = "";
		public AddClaimDocumentation()
		{
			InitializeComponent();
			this.ClaimList.ItemsSource = s1.ClaimsList;
			this.AvailableDocuments.ItemsSource = s1.ClaimDocTypes;
			AvailableDocuments.IsEnabled = false;
			BitmapSource bitmap=(BitmapSource) new ImageSourceConverter().ConvertFromString("C:\\Users\\Snotacus\\Dropbox\\MRNUIElements\\MRNUIElements\\ResourceFiles\\RoofInspectionWizardBkgnd.png");
			SubmitBtn.IsEnabled = false;
			if (!ClaimList.IsFocused)
				ClaimList.Focus();
				image.Source = imgsrc;
				image.Stretch = Stretch.Uniform;
				image.StretchDirection = StretchDirection.DownOnly;
			//ShowImage();
		}

		private void SelectFile()
		{
			var fileDialog = new System.Windows.Forms.OpenFileDialog();
			fileDialog.Multiselect = true;
			var result = fileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				FullFilePath = fileDialog.FileName;
				foreach (string s in fileDialog.FileNames)
				{
					//FileList.Add(s);
					FileListBox.Items.Add(s);
				}
			//	FileListBox.ItemsSource = FileList;
				FileListBox.SelectedIndex = 0;
			}
		}
		
		protected BitmapImage ShowImage(ImageSource imgsrc=null, RenderTargetBitmap tarbmp=null, string filetoshow = null, bool isUpdate = false)
		{
			////if (imgsrc != null)
			////{
			////	return (BitmapImage)imgsrc;

			////}
			////if (tarbmp != null)
			////{
			////	image.Source = tarbmp;
			////}
			if (bitmap != null && isUpdate)//this is used just to make the program flow the best as far as programming goes
			{
				BitmapSource bmpsrc = bitmap;
				image.Source = bitmap;
				//	image.Stretch = Stretch.Uniform;
				//	image.StretchDirection = StretchDirection.DownOnly;
				//return (BitmapImage)image.Source;
				return bitmap;
			}
			else
			{
					bitmap.BeginInit();
				//if (filetoshow != null)  //supposed to be for when you have a location and want to generate a bitmap of that file
				//{
				//	bitmap.UriSource = new Uri(filetoshow, UriKind.Absolute);
					
				//}
				//else
				//{
					SelectFile();  //initialization function if you try to use this function this forces you to find a bitmap to kick the whole thing off
					if (FileListBox.HasItems)
						bitmap.UriSource = new Uri(FullFilePath, UriKind.Absolute);
				//}
				
				bitmap.EndInit();
				image.Source = bitmap;
				image.Stretch = Stretch.Uniform;
				image.StretchDirection = StretchDirection.DownOnly;
				return bitmap;
			}
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


			// ****************** We Have a winner, we select this file as the winner now do what you will currently it saves it locally but we can if we want to upload it.**************
			UpdateImageText(FormatText(TextToOverlayPicture.Text, System.Windows.Media.Brushes.Cyan, new Typeface("Times New Roman")), FullFilePath, true);
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
			WriteTextToImage(ShowImage(null, null, ImgPath, true), ImgPath, text, new System.Windows.Point((bitmap.PixelWidth / 2) - (text.Width / 2), bitmap.PixelHeight - text.Height), bSave, _textGeometry);
		}

		private FormattedText FormatText(string str, System.Windows.Media.Brush brush, Typeface tf)
		{
			// function that is work to prepare for display function as to help compartmentalize all the necessary steps in making text changes to display in realtime
			FormattedText text = new FormattedText(
			str,
			CultureInfo.InvariantCulture,
			System.Windows.FlowDirection.LeftToRight,
			tf,
			bitmap.PixelHeight/10,
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
						dc.DrawGeometry(System.Windows.Media.Brushes.DarkRed, new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, bitmap.Height/500), _textGeometry);
					if (_textHighlightGeometry != null)
						dc.DrawGeometry(new System.Windows.Media.ImageBrush(new System.Windows.Controls.Image().Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Snotacus\\Dropbox\\MRNUIElements\\MRNUIElements\\ResourceFiles\\RoofInspectionWizardBkgnd.png")), new System.Windows.Media.Pen(new System.Windows.Media.ImageBrush(new System.Windows.Controls.Image().Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Snotacus\\Dropbox\\MRNUIElements\\MRNUIElements\\ResourceFiles\\RoofInspectionWizardBkgnd.png")), 2), _textHighlightGeometry);

				}

				//bitmap1.EndInit();
				RenderTargetBitmap target = new RenderTargetBitmap(bitmap.PixelWidth, bitmap.PixelHeight, 96,96, PixelFormats.Default);
				target.Render(visual);
/*
				var renderTargetbitmap = target;
				var bitmapImage = new BitmapImage();
				var bitmapEncoder = new PngBitmapEncoder();
				bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetbitmap));
				using (var stream = new MemoryStream())
				{
					bitmapEncoder.Save(stream);
					stream.Seek(0, SeekOrigin.Begin);
					bitmapImage.BeginInit();
					bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
					bitmapImage.StreamSource = stream;
					bitmapImage.EndInit();
				}
				bitmap = bitmapImage;
				image.Source = bitmapImage;
*/
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
		
		async public Task<bool> CheckFileExist()
		{															//the worker function to callback after determining if the file exists in the location that has been picked if so it will ask what would you like to do with it.
			await s1.GetClaimDocumentsByClaimID(new DTO_Claim { MRNNumber = ClaimList.SelectedValue.ToString() });
			if (s1.ClaimDocumentsList[AvailableDocuments.SelectedIndex] != null)
				return true;
			else return false;
		}

		async private void getImage_Click(object sender, RoutedEventArgs e)
		{
			await s1.GetClaimDocumentsByClaimID(new DTO_Claim
			{
				ClaimID = 30
			});
			bitmap.UriSource = new Uri(FileListBox.SelectedItem.ToString(), UriKind.Absolute);
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
			//	UploadImage(outputFile);
					}
				}
			}
		}

		async private void UploadImage(string filepathtoupload=null)
		{
			var fileDialog = new System.Windows.Forms.OpenFileDialog();
			var result = System.Windows.Forms.DialogResult.OK;
			if (filepathtoupload == null)
			{
				result = fileDialog.ShowDialog();
			}
			else { 

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
						ClaimID = int.Parse(ClaimList.Text),
						DocTypeID = AvailableDocuments.SelectedIndex,
						DocumentDate = DateTime.Today
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

		private void lbVCKicks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://vcskicks.com/");
		}
		SaveFileDialog saveDiag1 = new SaveFileDialog();

		private byte[] downloadedData;

		//Connects to a URL and attempts to download the file
		private void downloadData(string url)
		{
			progressBar1.Value = 0;
			downloadedData = new byte[0];
			try
			{
				//Optional
				this.TextFile.Text = "Connecting...";
				System.Windows.Forms.Application.DoEvents();
				//Get a data stream from the url
				WebRequest req = WebRequest.Create(url);
				WebResponse response = req.GetResponse();
				Stream stream = response.GetResponseStream();
				//Download in chuncks
				byte[] buffer = new byte[1024];
				//Get Total Size
				int dataLength = (int)response.ContentLength;
				//With the total data we can set up our progress indicators
				progressBar1.Maximum = dataLength;
				TextFile.Text = "0/" + dataLength.ToString();
				this.TextFile.Text = "Downloading...";
				System.Windows.Forms.Application.DoEvents();
				//Download to memory
				//Note: adjust the streams here to download directly to the hard drive
				MemoryStream memStream = new MemoryStream();
				while (true)
				{
					//Try to read the data
					int bytesRead = stream.Read(buffer, 0, buffer.Length);
					if (bytesRead == 0)
					{
						//Finished downloading
						progressBar1.Value = progressBar1.Maximum;
						TextFile.Text = dataLength.ToString() + "/" + dataLength.ToString();
						System.Windows.Forms.Application.DoEvents();
						break;
					}
					else
					{
						//Write the downloaded data
						memStream.Write(buffer, 0, bytesRead);
						//Update the progress bar
						if (progressBar1.Value + bytesRead <= progressBar1.Maximum)
						{
							progressBar1.Value += bytesRead;
							TextFile.Text = progressBar1.Value.ToString() + "/" + dataLength.ToString();
							//progressBar1.
							System.Windows.Forms.Application.DoEvents();
						}
					}
				}
				//Convert the downloaded stream to a byte array
				downloadedData = memStream.ToArray();
				//Clean up
				stream.Close();
				memStream.Close();
			}
			catch (Exception)
			{
				//May not be connected to the internet
				//Or the URL might not exist
				System.Windows.Forms.MessageBox.Show("There was an error accessing the URL.");
			}
			TextFile.Text = downloadedData.Length.ToString();
			this.TextFile.Text = "Download Data through HTTP";
		}
		
		//Start the downloading process
		private void btnDownload_Click(object sender, EventArgs e)
		{
			downloadData(TextFile.Text);

			//Get the last part of the url, ie the file name
			if (downloadedData != null && downloadedData.Length != 0)
			{
				string urlName = TextFile.Text;
				if (urlName.EndsWith("/"))
					urlName = urlName.Substring(0, urlName.Length - 1); //Chop off the last '/'
				urlName = urlName.Substring(urlName.LastIndexOf('/') + 1);
				saveDiag1.FileName = urlName;
			}
		}

		//Take data from memory and save it to the drive
		private void btnSave_Click(object sender, EventArgs e)
		{
			if (downloadedData != null && downloadedData.Length != 0)
			{
				if (saveDiag1.ShowDialog() == DialogResult.OK)
				{
					this.TextFile.Text = "Saving Data...";
					System.Windows.Forms.Application.DoEvents();
					//Write the bytes to a file
					FileStream newFile = new FileStream(saveDiag1.FileName, FileMode.Create);
					newFile.Write(downloadedData, 0, downloadedData.Length);
					newFile.Close();
					this.TextFile.Text = "Download Data";
					System.Windows.Forms.MessageBox.Show("Saved Successfully");
				}
			}
			else
				System.Windows.Forms.MessageBox.Show("No File was Downloaded Yet!");
		}

		private void FileListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (FileListBox.HasItems)
			{
				if (FileListBox.SelectedIndex<FileListBox.Items.Count)
					if (FileListBox.SelectedValue.ToString() != string.Empty)
						FullFilePath = FileListBox.SelectedValue.ToString();
				BitmapSource bitmap = (BitmapSource)new ImageSourceConverter().ConvertFromString(FullFilePath);
				image.Source = bitmap;
			//	image.Stretch = Stretch.Uniform;
			//	image.StretchDirection = StretchDirection.DownOnly;
				
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
			if(SubmitBtn.IsEnabled == true)
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
				if (FileListBox.SelectedItem!=null)
				{
					FileListBox.Items.Remove(FileListBox.SelectedItem);
				}
			
				FileListBox.Focus();
			//}
		}

		private void AvailableDocuments_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			FileListBox.SelectedIndex = 0;
		}
	}
}
