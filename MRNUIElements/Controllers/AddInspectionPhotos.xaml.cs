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
using MRNNexus_Model;
using static MRNUIElements.Controllers.UploadDocuments;
namespace MRNUIElements.Controllers
{
	/// <summary>
	/// Interaction logic for AddInspectionPhotos.xaml
	/// </summary>
	public partial class AddInspectionPhotos : Page
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		static MRNClaim MrnClaim;
		public AddInspectionPhotos(MRNClaim MrnClaim)
		{
			InitializeComponent();
			AddInspectionPhotos.MrnClaim = MrnClaim;
			
			onInit();
			
		}

		async void onInit()
		{
			
			await s1.GetAllClaimDocuments();
			ImageCarosel.ItemsSource = MrnClaim.inspectionPhotos =  MrnClaim.inspectionPhotos == null||MrnClaim.inspectionPhotos.Count<1 ? await GetDamagePhotos(MrnClaim._claim) : MrnClaim.inspectionPhotos;
			this.DataContext = MrnClaim.inspectionPhotos;
			foreach (var item in MrnClaim.inspectionPhotos)
			{
				var imgconv = new ImageSourceConverter();
				var bmpimg = new BitmapImage(new Uri(item.FilePath + item.FileName + item.FileExt, UriKind.Absolute));
				Image img = new Image();
				img = (Image)imgconv.ConvertFrom(bmpimg);
				

				wp.Children.Add(img);
			}
		}


		async Task<List<DTO_ClaimDocument>> GetDamagePhotos(DTO_Claim claim)
		{
			try
			{
				return new List<DTO_ClaimDocument>(s1.ClaimDocumentsList.FindAll(x => x.ClaimID == claim.ClaimID));
			}
			catch (Exception ex)
			{
				var a = new List<DTO_ClaimDocument>();
				var fileDialog = new System.Windows.Forms.OpenFileDialog();


				var result = fileDialog.ShowDialog();



				switch (result)
				{
					case System.Windows.Forms.DialogResult.OK:
						{
							foreach (var item in fileDialog.FileNames)
							{
								UploadImageFile(item);
							}
							break;
						}
					default: return new List<DTO_ClaimDocument>();
				}

				await s1.GetAllClaimDocuments();

				return new List<DTO_ClaimDocument>(s1.ClaimDocumentsList.FindAll(x => x.ClaimID == claim.ClaimID));
			}
		}
	


	async void UploadImageFile(string file, string comment="No Comment")
		{
			

			var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(file);

			onlyFileName = onlyFileName.Replace(" ", "_");
			byte[] imageBytes = System.IO.File.ReadAllBytes(file);
			string ext = System.IO.Path.GetExtension(file);
			DTO_ClaimDocument documentUploadRequest = new DTO_ClaimDocument
			{
				FileBytes = Convert.ToBase64String(imageBytes),
				FileName = onlyFileName,
				FileExt = ext,
				ClaimID = _Claim.ClaimID,
				DocTypeID = _DocType.ClaimDocumentTypeID,
				DocumentDate = DateTime.Today,
				DocumentComments = comment
			};
			try
			{
				await s1.AddClaimDocument(documentUploadRequest);

				if (documentUploadRequest.Message != null)
				{
					System.Windows.Forms.MessageBox.Show(documentUploadRequest.Message.ToString());
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
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());

			}
		}
	}
}
