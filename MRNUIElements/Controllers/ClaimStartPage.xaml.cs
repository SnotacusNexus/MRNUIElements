using MRNNexus_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MRNUIElements.Controllers
{
	/// <summary>
	/// Interaction logic for ClaimStartPage.xaml
	/// </summary>
	public partial class ClaimStartPage : Page
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		public DTO_Claim Claim { get; set; }
		
		public static MRNClaim MRNClaim;

		public ClaimStartPage()
		{
			InitializeComponent();
			if (MRNClaim == null)
				MRNClaim = new MRNClaim();

		}

		private void NewClaimBtn_Click(object sender, RoutedEventArgs e)
		{
			var AddressReturn = new AddPropertyAddress();
			AddressReturn.Return += new ReturnEventHandler<object>(AddPropertyAddress_Return);
			NavigationService.Navigate(AddressReturn);
		}
		private void AddPropertyAddress_Return(object sender, ReturnEventArgs<Object> e)
		{
			var propertyaddress = (DTO_Address)e.Result;
			MRNClaim.a = propertyaddress;
			var claimLead = new AddLeadInformation();
			claimLead.Return += new ReturnEventHandler<object>(AddClaimLeadInformation_Return);
			NavigationService.Navigate(claimLead);

		}
	
		private void AddClaimLeadInformation_Return(object sender, ReturnEventArgs<Object> e)
		{
			var claimLeadReturn = new DTO_Lead();
			claimLeadReturn = (DTO_Lead)e.Result;
			MRNClaim.Lead = claimLeadReturn;
			var claimCustomer = new AddClaimCustomer();
			claimCustomer.Return += new ReturnEventHandler<object>(AddClaimCustomer_Return);
			NavigationService.Navigate(claimCustomer);

		}


		private void AddClaimCustomer_Return(object sender, ReturnEventArgs<Object> e)
		{
			var claimCustomerReturn = new DTO_Customer();
			claimCustomerReturn = (DTO_Customer)e.Result;
			MRNClaim.c = claimCustomerReturn;
			var claimInsuranceCarrier = new AddClaimInsuranceCarrier();
			claimInsuranceCarrier.Return += new ReturnEventHandler<object>(AddClaimInsuranceCarrier_Return);
			NavigationService.Navigate(claimInsuranceCarrier);
		}
		private void AddClaimInsuranceCarrier_Return(object sender, ReturnEventArgs<Object> e)
		{


		}


			private void AddInspection_Return(object sender, ReturnEventArgs<Object> e)
		{



			var inspectionImages = (ObservableCollection<InspectionImage>)e.Result;
			foreach (var inspectionimage in inspectionImages)
				MRNClaim.claimDocs.Add(inspectionimage);

		}

		private void AddClaim_Return(object sender, ReturnEventArgs<Object> e)
		{
			var inspection = new AddClaimInspection();
			inspection.Return += new ReturnEventHandler<object>(AddInspection_Return);
			NavigationService.Navigate(inspection);
		}
		private void AddClaimAdjustment_Return(object sender, ReturnEventArgs<Object> e)
		{
		}


		private void AddInspectionImages_Return(object sender, ReturnEventArgs<Object> e)
		{



			var inspectionImages = (ObservableCollection<InspectionImage>)e.Result;
			foreach (var inspectionimage in inspectionImages)
				MRNClaim.claimDocs.Add(inspectionimage);
		
		}

		private void OpenEditBtn_Click(object sender, RoutedEventArgs e)
		{
			var ClaimPickerDialog = new ClaimPickerDialog();
		}

		private void OptionsBtn_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Forms.MessageBox.Show("They ain't no options fool!");
		}

		private MRNClaim BuildMRNClaim()
		{



			return new MRNClaim();
		}
	}
}
