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
using MRNNexus_Model;
using System.Threading;
using System.Windows.Forms;

namespace MRNUIElements.Controllers
{
	/// <summary>
	/// Interaction logic for New_Inspection_Page.xaml
	/// </summary>
	public partial class New_Inspection_Page : PageFunction<Object>
	{
		public ObservableCollection<InspectionImage> InspectionImagesData;
		int claimnumber = 19;

		public New_Inspection_Page()
		{
			InitializeComponent();


			InspectionImages.ItemsSource = new ObservableCollection<string>() { "Item1", "Item2", "Item3", "Item4", "Item5", "Item6", "Item7", "Item8", "Item9" };
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
		//internal ReturnEventHandler<object> Return;
		

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

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ObservableCollection<InspectionImage> inspectionImages = new ObservableCollection<InspectionImage>();
			ReturnEventArgs<object> returnObject = new ReturnEventArgs<object>((object)inspectionImages);
			OnReturn(returnObject);
		}
	}


	public class InspectionImage : DTO_ClaimDocument
	{
		ServiceLayer s1 = ServiceLayer.getInstance();
		static public ObservableCollection<InspectionImage> InspectionImages;
		public int DocImageID { get; set; }
		public string Path { get; set; }
		public DTO_Claim Claim { get; set; }
		public BitmapImage Image {get;set;}
		public string Comments { get; set; }
		bool youmayproceed = false;
		public InspectionImage()
		{
			if (this.Claim == null)
				return;

			youmayproceed = false;
			GetCollection(this.Claim);
			while (!youmayproceed)
				Thread.Sleep(10);
		}
		 async void GetCollection(DTO_Claim claim)
		{
			await ConvertToInspectionImages(claim);
		}
		private async Task<ObservableCollection<InspectionImage>>ConvertToInspectionImages(DTO_Claim claim)
		{
			await s1.GetClaimDocumentsByClaimID(claim);
		

			var a = new ObservableCollection<InspectionImage>();
			foreach(var b in s1.ClaimDocumentsList.Where(x=> x.DocTypeID == 1))
			{

				a.Add( 
					new InspectionImage {  
					Image = GetImage(b.FilePath + b.FileName + b.FileExt),
					Comments = b.DocumentComments });

			}

			youmayproceed = true;
			return a;

		}


		private BitmapImage GetImage(string Path)
		{
			var a = new BitmapImage();
			try
			{
				if (!string.IsNullOrEmpty(Path))
					a= new BitmapImage(new Uri(Path, UriKind.Absolute));
				else if (!string.IsNullOrEmpty(this.Path))
					a= new BitmapImage(new Uri(this.Path, UriKind.Absolute));
				
			}
			catch (Exception)
			{
				System.Windows.Forms.MessageBox.Show("No Image Found");
				
			}
			return a;
		}
		

	}


}
