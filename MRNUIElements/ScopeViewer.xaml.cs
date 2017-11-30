using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MRNNexus_Model;
using MRNUIElements.Controllers;

namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for ScopeViewer.xaml
	/// </summary>
	public partial class ScopeViewer : Page
	{
		const int ESTIMATE = 6;
		const int OLDSCOPE = 7;
		const int NEWSCOPE = 10;
		static ServiceLayer s1 = ServiceLayer.getInstance();
		public List<DTO_Scope> claimscopelist = new List<DTO_Scope>();
		protected ObservableCollection<DTO_Scope> claimScopes = new ObservableCollection<DTO_Scope>();
		//public int scopetype;
		static GetClaimsPage G = GetClaimsPage.getInstanceH();
		public int scopeType { get; set; }
		public int TypeScope { get; set; }
		public DTO_Scope scope = new DTO_Scope();
		public double acv;
		public double depreciation;
		public double roof;
		public int ScopeID;
		public bool bab = true;
		private double temp = 0;
		public string selTxt { get; set; }
		protected List<bool> ScopeExist = new List<bool>();
		public List<DTO_Scope> ScopesList { get; set; }
		public DTO_Claim claim { get; set; }
		bool EstimateExists = false;
		bool OldScopeExists = false;
		bool NewScopeExists = false;


		public ScopeViewer(DTO_Claim _claim, int scopeType = 0, DTO_Scope scope = null)   //should be 6, 7, 8
		{ InitializeComponent();


			switch (scopeType)
			{
				case 6:
					{
						scopeType = ESTIMATE;
						break;
					}
				case 7:
					{
						scopeType = OLDSCOPE;
						break;
					}
				case 10:
					{
						scopeType = NEWSCOPE;
						break;
					}
		
			}
			if (s1.ScopesList.Count() > 0)
			{
				DisplayScopeInfo(scope);
			//	ScopesList = orderScopes(s1.ScopesList.Where(x => x.ClaimID == claim.ClaimID).ToList());

			}

            //	ShowsAvailableScopes(ScopesList);
            ScopesList = s1.ScopesList.FindAll(y =>/* y.ScopeTypeID == scopeType &&*/ y.ClaimID == _claim.ClaimID);
            if(scopeType>0)
            ScopeTypeTextBlock.Text = s1.ScopeTypes.Find(x=>x.ScopeTypeID==scopeType).ScopeType.ToString();
			//GetScopes(_claim, scopeType); //Find all scopes for claim and store them in order for structured retrieval
			if (_claim != null )
			{
				claimIDTextBox.Text = _claim.MRNNumber;
			}
			
		
			else if (scope != null)
			{


				DisplayScopeInfo(scope);
			}
			else
			{

				//basic initialization
			}

		}//end function

		async void GetScopes(DTO_Claim claim, int scopeType)
		{

			await s1.GetScopesByClaimID(claim);
			while (s1.ScopesList == null)
				;

		


		}



		async Task<bool> DisplayScopeInfo(DTO_Scope scope = null, List<DTO_Scope> scopeList = null, int scopeType = 0)
		{ if (scope == null)
				scope = new DTO_Scope();
			else
			{
				claimIDTextBox.Text = s1.ClaimsList.Where(x => x.ClaimID == scope.ClaimID).ToList()[0].MRNNumber.ToString();
				ScopeTypeTextBlock.Text = s1.ScopeTypes[scope.ScopeTypeID - 1].ToString().ToString();
				deductibleTextBox.Value = (decimal)scope.Deductible;
				oandPTextBox.Value = (decimal)scope.OandP;
				interiorTextBox.Value = (decimal)scope.Interior;
				gutterTextBox.Value = (decimal)scope.Gutter;
				totalTextBox.Value = (decimal)scope.Total;
				exteriorTextBox.Value = (decimal)scope.Exterior;
				taxTextBox.Value = (decimal)scope.Tax;
				Roof.Value = (decimal)scope.RoofAmount;
				return true;
			}
			if (scopeList != null && scopeType > 0) {
				{
					scope = scopeList[scopeType - 1];



					claimIDTextBox.Text = s1.ClaimsList.Where(x => x.ClaimID == scope.ClaimID).ToList()[0].MRNNumber.ToString();
					ScopeTypeTextBlock.Text = s1.ScopeTypes[scope.ScopeTypeID - 1].ToString().ToString();
					deductibleTextBox.Value = (decimal)scope.Deductible;
					oandPTextBox.Value = (decimal)scope.OandP;
					interiorTextBox.Value = (decimal)scope.Interior;
					gutterTextBox.Value = (decimal)scope.Gutter;
					totalTextBox.Value = (decimal)scope.Total;
					exteriorTextBox.Value = (decimal)scope.Exterior;
					taxTextBox.Value = (decimal)scope.Tax;
					Roof.Value = (decimal)scope.RoofAmount;
					return true;
				} }
			return false;

		}
		




		
		void EnableAddButton()
		{
			if (this.gutterTextBox != null && this.exteriorTextBox != null && this.deductibleTextBox != null && this.claimIDTextBox != null && this.ACV != null && this.Depreciation != null && this.interiorTextBox != null && this.oandPTextBox != null && this.Roof != null && this.taxTextBox != null && this.totalTextBox != null && !SubmitScopeEntry.IsEnabled)
				SubmitScopeEntry.IsEnabled = true;
			else
				SubmitScopeEntry.IsEnabled = true;


		}


		async private void SubmitScopeEntry_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBoxResult.Yes == MessageBox.Show("Are the figures correct?", "Confirm addition of information to claim", MessageBoxButton.YesNo, MessageBoxImage.Question))
			{
				await AddScope(claim, TypeScope);

			}
		}







		private void CancelScopeEntry_Click(object sender, RoutedEventArgs e)
		{

			NavigationService.GoBack();
		}


		private void totalTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			EnableAddButton();
		}

		private void totalTextBox_LostFocus(object sender, RoutedEventArgs e)
		{

			EnableAddButton();


		}
		private void totalTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			EnableAddButton();

		}

		private void exteriorTextBox_LostFocus(object sender, RoutedEventArgs e)
		{



			EnableAddButton();



		}
		private void exteriorTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

			EnableAddButton();
		}

		private void gutterTextBox_LostFocus(object sender, RoutedEventArgs e)
		{

			EnableAddButton();

		}
		private void gutterTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			EnableAddButton();
		}

		private void interiorTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
            EnableAddButton();
		}
		private void interiorTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			EnableAddButton();

		}

		private void oandPTextBox_LostFocus(object sender, RoutedEventArgs e)
		{

			EnableAddButton();
		}
		private void oandPTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			EnableAddButton();
		}

		private void taxTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			EnableAddButton();
		}
		private void taxTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			EnableAddButton();
		}

		private void deductibleTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			EnableAddButton();


		}
		private void deductibleTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			EnableAddButton();
		}
		private void Roof_TextChanged(object sender, TextChangedEventArgs e)
		{
			EnableAddButton();
		}

		private void Roof_LostFocus(object sender, RoutedEventArgs e)
		{
			EnableAddButton();
		}


		virtual public double Calculate(decimal interior = 0, decimal exterior = 0, decimal gutters = 0, decimal roof = 0, decimal total = 0, decimal oandp = 0, decimal tax = 0, decimal deductible = 0, bool acv = true)
		{

			double a, b, c, d, e, f, g, h;

			a = (double)interior;

			b = (double)exterior;

			c = (double)gutters;

			d = (double)roof;

			e = (double)total;

			f = (double)oandp;

			g = (double)tax;

			h = (double)deductible;

			if (acv)

				return (double)total - (double)interior - (double)exterior - (double)gutters - (double)roof - (double)oandp - (double)tax - (double)deductible;


			return (double)total - (double)interior - (double)exterior - (double)gutters - (double)roof - (double)tax;

		}

		async private Task<List<DTO_Scope>> GetScopes(DTO_Claim claim)
		{
			await s1.GetScopesByClaimID(claim);
			while (s1.ScopesList == null)
				await Task.Delay(1);
		return GetClaimScopes(claim, s1.ScopesList);

		}
		List<DTO_Scope> GetClaimScopes(DTO_Claim claim,List<DTO_Scope> scopesList)
		{
			List<DTO_Scope> claimScopes = new List<DTO_Scope>();
			for(int i =0; i<3; i++)
			{

				claimScopes.Add(FetchScope(scopesList.Where(x => x.ClaimID == claim.ClaimID).ToList(), i));
			}
			return claimScopes;

		}
		DTO_Scope FetchScope(List<DTO_Scope> scopesList, int scopeType)
		{
			if (ScopeExists(scopesList, scopeType))
			{


			
				
				NewScopeBtn.IsEnabled = true;
				EstimateBtn.IsEnabled = true;
				OldScopeBtn.IsEnabled = true;
				if (scopeType == 1) EstimateBtn.Background = Brushes.Green;
				if (scopeType ==2) OldScopeBtn.Background = Brushes.Green;
				if(scopeType==3) NewScopeBtn.Background = Brushes.Green;
				return scopesList.Find(x => x.ScopeTypeID == scopeType);
			}
			else
			{
				return new DTO_Scope { ScopeTypeID = scopeType };
			}
		}
		bool ScopeExists(List<DTO_Scope> scopesList,int scopeType)
		{
			return scopesList.Exists(x => x.ScopeTypeID == scopeType);
		}

		

		
	
		

		private void ClearData()
		{
			OldScopeBtn.Background = Brushes.Red;
			EstimateBtn.Background = Brushes.Red;
			NewScopeBtn.Background = Brushes.Red;

			deductibleTextBox.Value = 0;
			oandPTextBox.Value = 0;
			interiorTextBox.Value = 0;
			gutterTextBox.Value = 0;
			totalTextBox.Value = 0;
			exteriorTextBox.Value = 0;
			taxTextBox.Value = 0;
			ACV.Value = 0;
			Roof.Value = 0;
			Depreciation.Value = 0;
			SubmitScopeEntry.IsEnabled = false;

		}


		private async Task<bool> AddScope(DTO_Claim claim, int typescope)
		{


			int claimstatustypeid = 0;
			switch (TypeScope)
			{
				case 1:
					{
						claimstatustypeid = 4;          //estimate 4
						break;
					}
				case 2:
					{
						claimstatustypeid = 6;            //originalscope 6
						break;
					}
				case 3:
					{
						claimstatustypeid = 10;            //newscope(aka) supplementsettled 10
						break;
					}
			}

			await s1.AddScope(new DTO_Scope
			{
				ClaimID = claim.ClaimID,
				Deductible = (double)deductibleTextBox.Value,
				Exterior = (double)exteriorTextBox.Value,
				Interior = (double)interiorTextBox.Value,
				Gutter = (double)gutterTextBox.Value,
				ScopeTypeID = TypeScope,
				Tax = (double)taxTextBox.Value,
				OandP = (double)oandPTextBox.Value,
				Total = (double)totalTextBox.Value,
				RoofAmount = (double)Roof.Value
			});
			if (s1.Scope.Message == null)
			{
				await s1.AddClaimStatus(new DTO_ClaimStatus
				{
					ClaimID = claim.ClaimID,
					ClaimStatusTypeID = claimstatustypeid,
					ClaimStatusDate = DateTime.Today

				});




				if (s1.ClaimStatus.Message == null)
				{
					MessageBox.Show("Everything Uploaded Successfully");
				}
				else
				{
					MessageBox.Show(s1.ClaimStatus.Message);
				}


			}
			else
			{
				MessageBox.Show(s1.Scope.Message);
			}


			return true;
		}

		private void ShapePickerBtn_Click(object sender, RoutedEventArgs e)
		{


		}

		private async void NewScopeBtn_Click(object sender, RoutedEventArgs e)
		{
			TypeScope = 3;
			await DisplayScopeInfo(ScopesList[2], ScopesList,3);
			SubmitScopeEntry.IsEnabled = false;
			selTxt = "New Scope";
			
			NewScopeBtn.Foreground = Brushes.Gold;
			OldScopeBtn.Foreground = Brushes.White;
			EstimateBtn.Foreground = Brushes.White;
		}

		private async void EstimateBtn_Click(object sender, RoutedEventArgs e)
		{
			TypeScope = 1;
		
			await DisplayScopeInfo(ScopesList[0], ScopesList, 1);
			SubmitScopeEntry.IsEnabled = false;
			selTxt = "MRN Estimate";
			EstimateBtn.Foreground = Brushes.Gold;
		OldScopeBtn.Foreground = Brushes.White;
			NewScopeBtn.Foreground = Brushes.White;
		}

		private async void OldScopeBtn_Click(object sender, RoutedEventArgs e)
		{
			TypeScope = 2;
			await DisplayScopeInfo(ScopesList[1], ScopesList, 2);
			SubmitScopeEntry.IsEnabled = false;
			selTxt = "Original Scope";
			OldScopeBtn.Foreground = Brushes.Gold;
			NewScopeBtn.Foreground = Brushes.White;
			EstimateBtn.Foreground = Brushes.White;

		}

        private void AddScopeBtn_Click(object sender, RoutedEventArgs e)
        {
            var a = System.Windows.Forms.MessageBox.Show("View Inspections/Photos (Yes), View Contract (No)", "Choose A Path!",System.Windows.Forms.MessageBoxButtons.YesNoCancel,System.Windows.Forms.MessageBoxIcon.Question,System.Windows.Forms.MessageBoxDefaultButton.Button3);

            if (a == System.Windows.Forms.DialogResult.Cancel)
                return;
            else if (a == System.Windows.Forms.DialogResult.No)
                NavigationService.Navigate(new ScopeViewer(this.claim));
            else NavigationService.Navigate(null);

        }

        private void AddSettlementBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddEVBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}



//namespace MRNUIElements
//{
//	/// <summary>
//	/// Interaction logic for ScopeViewer.xaml
//	/// </summary>
//	public partial class ScopeViewer : Page
//	{
//		public ScopeViewer()
//		{
//			InitializeComponent();
//		}
//	}
//}
