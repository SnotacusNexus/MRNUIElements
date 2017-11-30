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
using MRNNexus_Model;
using MRNUIElements.Controllers;

namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for ScopeViewer.xaml
	/// </summary>
	public partial class ScopeViewerUC : UserControl
	{

		static ServiceLayer s1 = ServiceLayer.getInstance();
		public List<DTO_Scope> claimscopelist = new List<DTO_Scope>();
		protected ObservableCollection<DTO_Scope> claimScopes = new ObservableCollection<DTO_Scope>();
		//public int scopetype;
		public int TypeScope { get; set; }
		public DTO_Scope scope = new DTO_Scope();
		public double acv;
		public double depreciation;
		public double roof;
		public int ScopeID;
		public bool bab = true;
		private double temp = 0;
		static public string selTxt = "";
		protected List<bool> ScopeExist = new List<bool>();
		public DTO_Claim claim { get; set; }


		public ScopeViewerUC(DTO_Claim _claim, int scopeType = 0)   //should be 1-3
		{
			InitializeComponent();
			GetScopes();
			claim = Init(_claim);
			//	GetScopeData(this.claim);
			//TODO: add the code to go fetch a claim or die
			if (claim != null)
			{

				GetScopeData(claim);
				claimIDTextBox.Text = claim.MRNNumber;
				ClearData();

				EnableAddButton();

			}

			//waiting for new scope to be selected

			if (claimscopelist != null && claimscopelist.Count > 0 && scopeType != 0)
				DisplayScopeInfo(claimscopelist, TypeScope, claim);

			foreach (var s in claimScopes)
			{
				if (s.ScopeTypeID == 1)
				{
					ScopeExist.Add(true);
					EstimateBtn.Foreground = Brushes.Gold;
				}
				else
					ScopeExist.Add(false);
				if (s.ScopeTypeID == 2)
				{
					ScopeExist.Add(true);
					OldScopeBtn.Foreground = Brushes.Gold;
				}
				else
					ScopeExist.Add(false);

				if (s.ScopeTypeID == 3)
				{
					ScopeExist.Add(true);
					NewScopeBtn.Foreground = Brushes.Gold;
				}
				else
					ScopeExist.Add(false);
			}
			EstimateBtn.Foreground = Brushes.Gold;
		}


		DTO_Claim Init(DTO_Claim claim)
		{
			if (claim != null)
				return claim;
			var cppu = new ClaimPickerPopUp();

			var result = cppu.ShowDialog();

			if ((bool)result)
			{

				if (cppu.Claim != null)
					return cppu.Claim;
				else
					return new DTO_Claim();


			}

			return cppu.Claim;

		}

		void SetSwitches()
		{
			//TODO: ADD Switch setter logic

			switch (TypeScope)
			{
				case 1:
					{

						selTxt = "MRN Estimate";


						break;
					}
				case 2:
					{

						selTxt = "Original Scope";



						break;
					}
				case 3:
					{

						selTxt = "New Scope";


						break;

					}
				default:
					{
						TypeScope = 0;
						selTxt = "No Scope Selected";
						break;
					}
					
			}
			ScopeTypeTextBlock.Text = selTxt;
		}
		void EnableAddButton()
		{
			if (this.gutterTextBox != null && this.exteriorTextBox != null && this.deductibleTextBox != null && this.claimIDTextBox != null && this.ACV != null && this.Depreciation != null && this.interiorTextBox != null && this.oandPTextBox != null && this.Roof != null && this.taxTextBox != null && this.totalTextBox != null && !SubmitScopeEntry.IsEnabled)
				SubmitScopeEntry.IsEnabled = true;
			else
				SubmitScopeEntry.IsEnabled = true;

		}
		async void GetScopeData(DTO_Claim claim)
		{
			if (s1.ScopesList != null)
				s1.ScopesList.Clear();
			if (claimScopes.Count > 0)
				claimScopes.Clear();

			if (s1.ScopesList == null)
			{
				try
				{


					await s1.GetAllScopes();
					while (s1.ScopesList == null)
						await Task.Delay(1);
					if (claim != null)
						foreach (var cs in s1.ScopesList.Where(x => x.ClaimID == claim.ClaimID))
						{

							if (cs.ScopeTypeID == 3)
							{
								NewScopeBtn.Background = Brushes.Green;
								NewScopeBtn.IsEnabled = true;
							}
							else
							{
								NewScopeBtn.Background = Brushes.Red;
								NewScopeBtn.IsEnabled = true;
							}
							if (cs.ScopeTypeID == 1)
							{
								EstimateBtn.Background = Brushes.Green;
								EstimateBtn.IsEnabled = true;
							}
							else
							{
								EstimateBtn.Background = Brushes.Red;
								EstimateBtn.IsEnabled = true;
							}
							if (cs.ScopeTypeID == 2)
							{
								OldScopeBtn.Background = Brushes.Green;
								OldScopeBtn.IsEnabled = true;
							}
							else
							{
								OldScopeBtn.Background = Brushes.Red;
								OldScopeBtn.IsEnabled = true;
							}
							claimScopes.Add(cs);
						}
				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.ToString());

				}

			}

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

			EnableAddButton();
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

		async private void GetScopes()
		{
			await s1.GetScopesByClaimID(claim);
			while (s1.ScopesList == null)
				await Task.Delay(1);
			claimscopelist = s1.ScopesList;

		}

		private void DisplayScopeInfo(List<DTO_Scope> scopelist, int typescope, DTO_Claim c)
		{
			DTO_Scope t = new DTO_Scope();
			try
			{
				t = (DTO_Scope)scopelist.Select(x => x.ScopeTypeID == typescope && x.ClaimID == c.ClaimID);

			}
			catch (Exception ex)
			{

				System.Windows.Forms.MessageBox.Show("Enter the scope details to add this scope type to this claim.");
				claimIDTextBox.Text = claim.MRNNumber;
				ClearData();

				SubmitScopeEntry.IsEnabled = true;
			}

			if (scope != null && c != null && typescope > 5 && typescope < 9)

				foreach (DTO_Scope s in s1.ScopesList)
				{
					if (s.ScopeTypeID == TypeScope)
					{


						bool b = s.ScopeID.Equals(t.ScopeID);
						if (!b)
						{

							deductibleTextBox.Value = (decimal)s.Deductible;
							oandPTextBox.Value = (decimal)s.OandP;
							interiorTextBox.Value = (decimal)s.Interior;
							gutterTextBox.Value = (decimal)s.Gutter;
							totalTextBox.Value = (decimal)s.Total;
							exteriorTextBox.Value = (decimal)s.Exterior;
							taxTextBox.Value = (decimal)s.Tax;
							Roof.Value = (decimal)s.RoofAmount;

						}


					}
				}
			SubmitScopeEntry.IsEnabled = false;
		}



		private void ClearData()
		{

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

		private void NewScopeBtn_Click(object sender, RoutedEventArgs e)
		{
			TypeScope = 3;
			SetSwitches();
			DisplayScopeInfo(claimscopelist, TypeScope, claim);
			SubmitScopeEntry.IsEnabled = false;
		}

		private void EstimateBtn_Click(object sender, RoutedEventArgs e)
		{
			TypeScope = 1;
			SetSwitches();
			DisplayScopeInfo(claimscopelist, TypeScope, claim);
			SubmitScopeEntry.IsEnabled = false;

		}

		private void OldScopeBtn_Click(object sender, RoutedEventArgs e)
		{
			TypeScope = 2;
			SetSwitches();
			DisplayScopeInfo(claimscopelist, TypeScope, claim);
			SubmitScopeEntry.IsEnabled = false;

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
