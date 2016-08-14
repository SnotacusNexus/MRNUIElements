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
using MRNUIElements.Controllers;

namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for ScopeViewer.xaml
	/// </summary>
	public partial class ScopeViewer : Page
	{

		static ServiceLayer s1 = ServiceLayer.getInstance();
		public List<DTO_Scope> claimscopelist = new List<DTO_Scope>();
		public int scopetype;
		public int TypeScope { get; set; }
		public DTO_Scope scope = new DTO_Scope();
		public double acv;
		public double depreciation;
		public double roof;
		public int ScopeID;
		public bool bab = true;
		private double temp = 0;


		public DTO_Claim claim { get; set; }


		public ScopeViewer(DTO_Claim _claim = null, int scopeType = 0)   //should be 6, 7, 8 
		{
			InitializeComponent();
			switch (scopeType)
			{
				case 6:
					{
						ScopeTypeTextBox.Text = "MRN Estimate";

						scopetype = scopeType;
						TypeScope = 1;
						break;
					}
				case 7:
					{
						ScopeTypeTextBox.Text = "Original Scope";


						scopetype = scopeType;
						TypeScope = 2;
						break;
					}
				case 8:
					{
						ScopeTypeTextBox.Text = "New Scope";

						scopetype = scopeType;
						TypeScope = 3;
						break;

					}
				default:
					{
						scopetype = scopeType;
						break;
					}

			}
			if (_claim != null) { 
				claim = _claim;
			GetScopes(); }
			if (claim != null)
				claimIDTextBox.Text = claim.MRNNumber;
			ClearData();
			
			SubmitScopeEntry.IsEnabled = false;

		
			if (claimscopelist != null && claimscopelist.Count > 0 && scopeType != 0)
				DisplayScopeInfo(claimscopelist, scopetype, claim);

		}






	   

		

	








		async private void SubmitScopeEntry_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBoxResult.Yes == MessageBox.Show("Are the figures correct?", "Confirm addition of information to claim", MessageBoxButton.YesNo, MessageBoxImage.Question))
			{
				await AddScope(claim,scopetype);
				//NexusHome Page = new NexusHome();
				//this.NavigationService.Navigate(Page);
			}
		}







		private void CancelScopeEntry_Click(object sender, RoutedEventArgs e)
		{

			NexusHome Page = new NexusHome();
			this.NavigationService.Navigate(Page);
		}

		
		private void totalTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (totalTextBox.Text == string.Empty) totalTextBox.Text = "0";

			totalTextBox.SelectAll();
		}

		private void totalTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (totalTextBox.Text == string.Empty) totalTextBox.Text = "0";
			exteriorTextBox.IsEnabled = true;
			exteriorTextBox.SelectAll();
			ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);
		}
		private void totalTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (totalTextBox.Text == string.Empty) totalTextBox.Text = "0"; ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);

		}

		private void exteriorTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (exteriorTextBox.Text == string.Empty) exteriorTextBox.Text = "0";

			gutterTextBox.IsEnabled = true;
			gutterTextBox.SelectAll(); ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);


		}
		private void exteriorTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (exteriorTextBox.Text == string.Empty) exteriorTextBox.Text = "0";


			ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);


		}

		private void gutterTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (gutterTextBox.Text == string.Empty) gutterTextBox.Text = "0";
			interiorTextBox.IsEnabled = true;
			interiorTextBox.SelectAll(); ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);

		}
		private void gutterTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			{
				if (gutterTextBox.Text == string.Empty) gutterTextBox.Text = "0";

				temp = double.Parse(gutterTextBox.Text); ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

				Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);

			}
		}

		private void interiorTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (interiorTextBox.Text == string.Empty) interiorTextBox.Text = "0";
			oandPTextBox.IsEnabled = true;
			oandPTextBox.SelectAll(); ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);

		}
		private void interiorTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (interiorTextBox.Text == string.Empty) interiorTextBox.Text = "0";
			ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);


		}

		private void oandPTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (oandPTextBox.Text == string.Empty) oandPTextBox.Text = "0";
			taxTextBox.IsEnabled = true;
			taxTextBox.SelectAll(); ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);

		}
		private void oandPTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (oandPTextBox.Text == string.Empty) oandPTextBox.Text = "0";
			ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);



		}

		private void taxTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (taxTextBox.Text == string.Empty) taxTextBox.Text = "0";
			deductibleTextBox.IsEnabled = true;
			deductibleTextBox.SelectAll(); ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);

		}
		private void taxTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (taxTextBox.Text == string.Empty) taxTextBox.Text = "0";

			ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);



		}

		private void deductibleTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (deductibleTextBox.Text == string.Empty) deductibleTextBox.Text = "0";

			SubmitScopeEntry.IsEnabled = true;
			ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);

		}
		private void deductibleTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (deductibleTextBox.Text == string.Empty) deductibleTextBox.Text = "0";
			ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);




		}
		private void Roof_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (Roof.Text == string.Empty) Roof.Text = "0";

			ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);
		}

		private void Roof_LostFocus(object sender, RoutedEventArgs e)
		{
			ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);

		}
		
		
		virtual public string Calculate(string interior = "0", string exterior = "0", string gutters = "0", string roof = "0", string total = "0", string oandp = "0", string tax = "0", string deductible = "0", bool acv = true)
		{

			double a, b, c, d, e, f, g, h;
			if (interior == "") interior = "0";
			a = double.Parse(interior);
			if (exterior == "") exterior = "0";
			b = double.Parse(exterior);
			if (gutters == "") gutters = "0";
			c = double.Parse(gutters);
			if (roof == "") roof = "0";
			d = double.Parse(roof);
			if (total == "") total = "0";
			e = double.Parse(total);
			if (oandp == "") oandp = "0";
			f = double.Parse(oandp);
			if (tax == "") tax = "0";
			g = double.Parse(tax);
			if (deductible == "") deductible = "0";
			h = double.Parse(deductible);





			if (acv)

				return (e - a - b - c - d - f - g - h).ToString();


			return (e - a - b - c - d - g).ToString();

		}

			   async private void GetScopes()
		{
			await s1.GetScopesByClaimID(claim);
			//await s1.GetAllScopes();
		}

		private void DisplayScopeInfo(List<DTO_Scope> scopelist, int typescope, DTO_Claim c)
		{
			DTO_Scope t = new DTO_Scope();
			if (scope != null && c != null && typescope > 5 && typescope < 9)
			{


				foreach (DTO_Scope s in s1.ScopesList)
				{
					if (s.ScopeTypeID == TypeScope)
					{


						bool b = s.ScopeID.Equals(t.ScopeID);
						if (!b)
						{
							
							deductibleTextBox.Text = s.Deductible.ToString();
							oandPTextBox.Text = s.OandP.ToString();
							interiorTextBox.Text = s.Interior.ToString();
							gutterTextBox.Text = s.Gutter.ToString();
							totalTextBox.Text = s.Total.ToString();
							exteriorTextBox.Text = s.Exterior.ToString();
							taxTextBox.Text = s.Tax.ToString();
							Roof.Text = s.RoofAmount.ToString();
							
						}
						

					}
				}
			}
			
		}


		private void ClearData()
		{

			deductibleTextBox.Text = "0";
			oandPTextBox.Text = "0";
			interiorTextBox.Text = "0";
			gutterTextBox.Text = "0";
			totalTextBox.Text = "0";
			exteriorTextBox.Text = "0";
			taxTextBox.Text = "0";
			ACV.Text = "0";
			Roof.Text = "0";
			Depreciation.Text = "0";
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
				Deductible = double.Parse(deductibleTextBox.Text),
				Exterior = double.Parse(exteriorTextBox.Text),
				Interior = double.Parse(interiorTextBox.Text),
				Gutter = double.Parse(gutterTextBox.Text),
				ScopeTypeID = TypeScope,
				Tax = double.Parse(taxTextBox.Text),
				OandP = double.Parse(oandPTextBox.Text),
				Total = double.Parse(totalTextBox.Text),
				RoofAmount = double.Parse(Roof.Text)
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
			RoofInspectionWizard Page = new RoofInspectionWizard();
			NavigationService.Navigate(Page);
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
