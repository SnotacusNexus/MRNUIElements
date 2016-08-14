using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.Compression;
using Syncfusion.Licensing;
using Syncfusion.PdfViewer.Base;
using Syncfusion.Pdf;
using Syncfusion.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MRNNexus_Model;
using System.ComponentModel;

namespace MRNUIElements.Controllers
{
	class DownloadFilePath : INotifyPropertyChanged
	{

		public static ServiceLayer s1 = ServiceLayer.getInstance();
		public static DownloadFilePath t1;
		public static DTO_Claim Claim { get; set; }
		public static int DocType { get; set; }
		public DTO_Claim _claim { get; set; }
		public  int _docType { get; set; }
		public static DTO_ClaimDocument Document { get; set; }
		public static string FilePath { get; set; }

		public static Stream docStream { get; set; }
		public string fullFilePath { get; set; }



		public event PropertyChangedEventHandler PropertyChanged;

 public static DownloadFilePath getInstance(DTO_Claim claim, int docTypeID)
		{
			if (t1 == null)
				return t1=new DownloadFilePath(claim, docTypeID);
			else return t1;
		}

		public Stream DocumentStream

		{

			get

			{

				return docStream;

			}

			set

			{

				docStream = value;

				OnPropertyChanged(new PropertyChangedEventArgs("DocumentStream"));

			}
		}
		public  DownloadFilePath(DTO_Claim claim, int docType)
		{
			if (claim != null)
				this._claim = Claim = claim;
			
			if (docType <1)
				this._docType = DocType = docType;
			
			

			GetDocumentObject(Claim, DocType);
			 
		}
		public void OnPropertyChanged(PropertyChangedEventArgs e)

		{

			if (PropertyChanged != null)

				PropertyChanged(this, e);

		}






		 async private void GetDocumentObject(DTO_Claim claim,int docType)
		{
			
				var wwe = await CheckFileExist(claim, docType);
		
				
			
		}

		//private object PickViewer(DTO_ClaimDocument cd)
		//{
		//	if (cd.DocTypeID ==2)
		//	{
		//		Uri uri = new Uri((cd.FilePath + cd.FileName + cd.FileExt).ToString(), UriKind.Absolute);
		//		ImageSource imgsrc = new BitmapImage(uri);
		//		return new System.Windows.Controls.Image().Source = imgsrc;  
		//	}
		//	else
		//	{
		//		return CheckFileExist(Claim,DocType);
		//	}
		//}
		async public Task<string> CheckFileExist(DTO_Claim claim, int docType)
		{
			await s1.GetAllClaimDocuments();

			foreach (var cd in s1.ClaimDocumentsList.Where(t => t.ClaimID == claim.ClaimID && t.DocTypeID == docType))
			{

				if (s1.ClaimDocumentsList.Count > 0)
				{
					Document = cd;
					string str = cd.FilePath + cd.FileName + cd.FileExt;
					 fullFilePath= str;
					return str;
				}
				
			}
			
	
		    ShowCollectedClaimDocuments(claim);

			return "";
			//bitmap.UriSource = new Uri(FileListBox.SelectedItem.ToString(), UriKind.Absolute);
		}

		static string  GetDocumentTypeByID(int doctypeid)
		{
			return s1.ClaimDocTypes[doctypeid - 1].ToString();
		}


		static void  ShowCollectedClaimDocuments(DTO_Claim claim)
		{

			///getallclaimdocs
			///
			string s = "This claim has ";
			if (s1.ClaimDocumentsList != null)
				foreach (var cd in s1.ClaimDocumentsList.Where(t => t.ClaimID == claim.ClaimID))
				{
					if (cd.ClaimID == claim.ClaimID)
						s += " \n\r" + (GetDocumentTypeByID(cd.DocTypeID)) + " ,";
				}
			s += "documents present.";
			System.Windows.Forms.MessageBox.Show(s);
		}
		
		}
	}

