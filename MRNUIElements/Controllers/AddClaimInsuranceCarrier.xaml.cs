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
using MRNUIElements.Utility;
using System.IO;
using System.Threading;

namespace MRNUIElements.Controllers
{
	/// <summary>
	/// Interaction logic for AddClaimInsuranceCarrier.xaml
	/// </summary>
	public partial class AddClaimInsuranceCarrier
	{


		static ServiceLayer s1 = ServiceLayer.getInstance();
		static public MRNClaim MrnClaim = MRNClaim.getInstance();
		public AddClaimInsuranceCarrier(MRNClaim MrnClaim)
		{
			InitializeComponent();
			AddClaimInsuranceCarrier.MrnClaim = MrnClaim;
			GetInsuranceCompanies();
			AddClaimInsuranceCarrier.MrnClaim = MrnClaim;
			while (s1.InsuranceCompaniesList == null)
				Thread.Sleep(1000);

			InsuranceCompanyLookupcomboBox.ItemsSource = s1.InsuranceCompaniesList;
		}
		async void GetInsuranceCompanies()
		{
			await s1.GetAllInsuranceCompanies();
			InsuranceCompanyLookupcomboBox.ItemsSource = s1.InsuranceCompaniesList;
		}
	


		private void UploadPolicybutton_Click(object sender, RoutedEventArgs e)
		{
			UploadImage();

		}
		async private void UploadImage(string filepathtoupload = null)
		{
			string FullFilePath = "";
			var fileDialog = new System.Windows.Forms.OpenFileDialog();
			var result = System.Windows.Forms.DialogResult.OK;
			if (filepathtoupload == null)
			{
				result = fileDialog.ShowDialog();
			}
			else
			{

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
							ClaimID = 0,
							DocTypeID = 25,//TODO Correct This DocTypeID
							DocumentDate = DateTime.Today

						};
						try
						{
							MrnClaim.policy = documentUploadRequest;
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
						}
						catch (Exception ex)
						{
							System.Windows.Forms.MessageBox.Show(ex.ToString());

						}

						break;
					case System.Windows.Forms.DialogResult.Cancel:
					default:

						break;
				}
			}
		}

		private void Nextbutton_Click(object sender, RoutedEventArgs e)
		{
			MRNClaim.getInstance()._claim.PropertyID = MRNClaim.getInstance().a.AddressID;
            MRNClaim.getInstance()._claim.MortgageAccount = LoanNumber.Text + LoanNumber2 != null ? ("a"+LoanNumber2.Text) : "a";
            MRNClaim.getInstance()._claim.MortgageCompany = LienHolder.Text + LienHolder2 != null ? ("a " + LienHolder2.Text) : "a";
            NavigationService.Navigate(new ClaimIT(MrnClaim));
		}

		private void Prevbutton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}

		private void Addbutton_Click(object sender, RoutedEventArgs e)
		{
			//TODO Implement ADD Independent 
		}
	}
}
