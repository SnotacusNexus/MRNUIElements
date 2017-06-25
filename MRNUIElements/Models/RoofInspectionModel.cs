using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization;
using System.Windows.Threading;
using MRNNexus_Model;

using MRNUIElements.Controllers;


namespace MRNUIElements.Models
{
	public class InspectionPhoto : DTO_ClaimDocument
	{
		public string photoPath { get; set; }
		public BitmapImage inspectionImage { get; set; }
		public string friendlyName { get; set; }
		public int InspectionID { get; set; }
		public DTO_Claim Claim { get; set; }
		public string Comments { get; set; } 
			
			
	}


	public class RoofInspectionModel
	{
		static ServiceLayer s = ServiceLayer.getInstance();
		
		public ObservableCollection<InspectionPhoto> inspectionPhotos = new ObservableCollection<InspectionPhoto>();
		public DTO_Inspection inspection = new DTO_Inspection();
		public DTO_Customer customer = new DTO_Customer();
		public DTO_Claim claim = new DTO_Claim();
		public DTO_Address address = new DTO_Address();
		public DTO_Employee salesperson = new DTO_Employee();
		int i = 0;
		int count = 0;
		public string salespersonName;
		public RoofInspectionModel()
		{

		}

		public System.Windows.Controls.WrapPanel wp = new System.Windows.Controls.WrapPanel();

		public ObservableCollection<InspectionPhoto> MakeInspectionPhotoGallery(DTO_Inspection _inspection, DTO_Customer customer, DTO_Address address, DTO_Employee salesperson)
		{
			this.customer = customer;
			this.address = address;
			this.salesperson = salesperson;

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Image files (*.bmp,*.jpg, *.jpeg, *.jpe, *.jfif, *.png,*.tiff) | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.tiff|All Files (*.*)|*.*";
			dialog.Multiselect = true;
			
			dialog.Title = "Please select image(s) to add to this inspection.";
			if (DialogResult.OK == dialog.ShowDialog())
			{

				if (dialog.FileNames.Count() > 0) {
					count = dialog.FileNames.Count();
					foreach (var f in dialog.FileNames)
					{
						string str = "";
						System.Windows.Controls.VirtualizingStackPanel vsp = new System.Windows.Controls.VirtualizingStackPanel();
						vsp.Children.Add(new System.Windows.Controls.Frame { Height = 150, Width = 150, Content = new BitmapImage { UriSource = new Uri(f, UriKind.Absolute) } });
						
					
						if (string.IsNullOrEmpty(str))
							str = "No Comment";
						UploadImages(f,str);

					}
				}
			}
			return new ObservableCollection<InspectionPhoto>();


		}


		async private void UploadImages(string photoPath, string comments)
		{


			var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(photoPath);
			onlyFileName = onlyFileName.Replace(" ", "_");
			byte[] imageBytes = System.IO.File.ReadAllBytes(photoPath);
			string ext = System.IO.Path.GetExtension(photoPath);
			if (claim == null)
				generateSkeletonClaim();
			while (claim == null)
				await Task.Delay(10);

			DTO_ClaimDocument documentUploadRequest = new DTO_ClaimDocument
			{
				FileBytes = Convert.ToBase64String(imageBytes),
				FileName = onlyFileName,
				FileExt = ext,
				ClaimID = claim.ClaimID,
				DocTypeID = 1,
				DocumentDate = DateTime.Today,
				DocumentComments = comments
			};

			await s.AddClaimDocument(documentUploadRequest);

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





		}
		async void generateSkeletonClaim()
		{

			var _claim = new DTO_Claim();
			_claim.BillingID = 1;
			_claim.CustomerID = customer.CustomerID;
			_claim.InsuranceClaimNumber = "SkeletonClaim" + customer.CustomerID.ToString() + salespersonName;
			_claim.LeadID = 1;
			_claim.LossDate = DateTime.Today;
			_claim.MRNNumber = _claim.InsuranceClaimNumber;
			_claim.PropertyID = address.AddressID;

			await s.AddClaim(_claim);
		}
		async public Task<bool> CheckFileExist(int cdt = 0)
		{                                                           //the worker function to callback after determining if the file exists in the location that has been picked if so it will ask what would you like to do with it.
			await s.GetAllClaimDocuments();
			if (s.ClaimDocumentsList.Exists(x => x.DocTypeID == 1 && x.ClaimID == claim.ClaimID))
				return true;
			else return false;
		}
	}

}
