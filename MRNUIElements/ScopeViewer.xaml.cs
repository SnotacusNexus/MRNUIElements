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


namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for ScopeViewer.xaml
	/// </summary>
	public partial class ScopeViewer : Page
	{
		
		public ServiceLayer s1 = ServiceLayer.getInstance();
		public List<DTO_Scope> claimscopelist = new List<DTO_Scope>();
		public int scopetype;
		public DTO_Scope scope = new DTO_Scope();
		public double acv;
		public double depreciation;
		public double roof;
		public int ScopeID;
		public bool bab=true;
		private double temp = 0;
		

			  DTO_Claim claim = new DTO_Claim();

		public ScopeViewer()
		{
			InitializeComponent();

			ClearData();
		SubmitScopeEntry.IsEnabled = false;


			this.claimIDComboBox.DataContext = s1.ClaimsList;
		

		}


		private void radioButton_Checked(object sender, RoutedEventArgs e)
		{

			
			claim = (DTO_Claim)claimIDComboBox.SelectedValue;
			ClaimScopeListProcessingForDisplay(GetScopes(claim), 1);

			totalTextBox.IsEnabled = true;
			DisplayScopeInfo(GetScopes(claim),1, claim);

		}

		private void radioButton_Copy_Checked(object sender, RoutedEventArgs e)
		{

		//	DTO_Claim claim = new DTO_Claim();
			claim = (DTO_Claim)claimIDComboBox.SelectedValue;
			ClaimScopeListProcessingForDisplay(GetScopes(claim), 2);

			totalTextBox.IsEnabled = true;
			DisplayScopeInfo(GetScopes(claim), 2, claim);
		}

		private void radioButton_Copy1_Checked(object sender, RoutedEventArgs e)
		{

		//	DTO_Claim claim = new DTO_Claim();
			claim = (DTO_Claim)claimIDComboBox.SelectedValue;
			ClaimScopeListProcessingForDisplay(GetScopes(claim), 3);

			totalTextBox.IsEnabled = true;
			DisplayScopeInfo(GetScopes(claim), 3, claim);
		}

		private int SetScopeByScopeID(DTO_Scope scope)
		{
			int i = scope.ScopeTypeID;

			switch (i)
			{
				case 1:
					{
						ImageBrush ib = new ImageBrush();
						ib.ImageSource = new BitmapImage(new Uri(@"../../ResourceFiles/CheckMark.png", UriKind.Relative));
						MRNEstimateStatusImage.Background = ib;



						radioButton.IsChecked = true;
						claimscopelist.Add(scope);
						return i;
					}
				case 2:
					{
						ImageBrush ib = new ImageBrush();
						ib.ImageSource = new BitmapImage(new Uri(@"../../ResourceFiles/CheckMark.png", UriKind.Relative));
						OldScopeStatusImage.Background = ib;

						radioButton_Copy.IsChecked = true;
						claimscopelist.Add(scope);
						return i;
					}
				case 3:
					{
						ImageBrush ib = new ImageBrush();
						ib.ImageSource = new BitmapImage(new Uri(@"../../ResourceFiles/CheckMark.png", UriKind.Relative));
						NewScopeStatusImage.Background = ib;
						radioButton_Copy1.IsChecked = true;
					
						return i;

					}
				default:
					{
						if (i < 1)
						{
							if (MessageBoxResult.Yes == MessageBox.Show("No Scopes were available for this Claim. Would you like to enter our estimate details?", "No previous data found", MessageBoxButton.YesNo, MessageBoxImage.Question))
							{
								radioButton.IsChecked = true;
								

								claimscopelist.Add(scope);
								i = 1;
							}
						}
						else if (i > 3)
						{
							if (MessageBoxResult.Yes == MessageBox.Show("A Scope with an out of range value has been found for this claim it may be a final scope. Would you like to enter the view it's details?", "Scope Out of Range", MessageBoxButton.YesNo, MessageBoxImage.Warning))
							{
								
								radioButton_Copy1.IsChecked = true;
								i = 3;
							}
						}
					}
					return i;
			}


		}

	 public List<DTO_Scope> GetScopes(DTO_Claim claim)
		{



			//	if (s1.ScopesList.Count == 1)
			//{
			//		if (s1.ScopesList[0].Message != string.Empty)
			//			claimscopelist.Clear();
			//			DTO_Scope scope = new DTO_Scope();
			////		scope.ScopeTypeID = 1;
			//	claimscopelist.Add(scope);
			//	}
			ImageBrush ib = new ImageBrush();
			ib.ImageSource = new BitmapImage(new Uri(@"../../ResourceFiles/XMark.png", UriKind.Relative));
			MRNEstimateStatusImage.Background = ib;
			OldScopeStatusImage.Background = ib;
			NewScopeStatusImage.Background = ib;
			claimscopelist.Clear();
			foreach (DTO_Scope c in s1.ScopesList)
				{
				if (c.ClaimID == claim.ClaimID)
				{
					claimscopelist.Add(c);
					SetScopeByScopeID(c);
				}
				}

			return claimscopelist;
		}

		private DTO_Scope ClaimScopeListProcessingForDisplay(List<DTO_Scope> cl, int ScopeTypeRequested)
		{

			if (cl.Count == 0)
			{
				if (MessageBoxResult.Yes == MessageBox.Show("The scope type you requested has not been saved for this claim, in fact no scopes are recorded for this claim.  Would you like to enter the estimate details now?", "No previous data found", MessageBoxButton.YesNo, MessageBoxImage.Question))
				 	return new DTO_Scope();	
				
			}
			foreach (DTO_Scope c in cl)
			{
				if (c.ScopeTypeID == ScopeTypeRequested) return c; ; //found it send it back




			}
			return null;
			}


		





		async private void SubmitScopeEntry_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBoxResult.Yes == MessageBox.Show("Are the figures correct?", "Confirm addition of information to claim", MessageBoxButton.YesNo, MessageBoxImage.Question))
			{
				 await AddScope((DTO_Claim)claimIDComboBox.SelectedValue, GetScopeTypeByButtonSelected());
				//NexusHome Page = new NexusHome();
				//this.NavigationService.Navigate(Page);
			}
		}







		private void CancelScopeEntry_Click(object sender, RoutedEventArgs e)
		{

			NexusHome Page = new NexusHome();
			this.NavigationService.Navigate(Page);
		}

		private void claimIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
			if (bab == false)
			{

				
			
		//	DTO_Claim claim = new DTO_Claim();
			claim = (DTO_Claim)claimIDComboBox.SelectedValue;
			ClaimScopeListProcessingForDisplay(GetScopes(claim),GetScopeTypeByButtonSelected());

			totalTextBox.IsEnabled = true;
			DisplayScopeInfo(GetScopes(claim),GetScopeTypeByButtonSelected(),claim);
		}
			bab = false;
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
		{		if (gutterTextBox.Text == string.Empty) gutterTextBox.Text = "0";
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
		{						if (deductibleTextBox.Text == string.Empty) deductibleTextBox.Text = "0";
			
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
			ACV.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text,deductibleTextBox.Text, taxTextBox.Text, true);

			Depreciation.Text = Calculate(interiorTextBox.Text, exteriorTextBox.Text, gutterTextBox.Text, Roof.Text, totalTextBox.Text, oandPTextBox.Text, deductibleTextBox.Text, taxTextBox.Text, false);

		}
		private int SetDisplayToScopeTypeIDByScope(DTO_Scope s)
		{
			int scopeType = s.ScopeTypeID;
			if (scopeType == 1) {  radioButton.IsChecked = true; }
		  	if (scopeType == 2) {  radioButton_Copy.IsChecked = true;  }
		   	if (scopeType == 3) {  radioButton_Copy1.IsChecked = true; }
			return scopeType;
		}
		private int GetScopeTypeByButtonSelected()
		{
			int i = 0;
			if (radioButton.IsChecked == true) return 1;
			else if (radioButton_Copy.IsChecked == true) return 2;
			else if (radioButton_Copy1.IsChecked == true) return 3;
			else if (i < 1) return 1;
			else if (i > 3) return 3;
			else return i;
		}

		virtual public double Calculate(DTO_Scope scope, bool acv=true)
		{ 
			if (acv)
				return scope.Total - scope.Interior - scope.Exterior - scope.Gutter - scope.RoofAmount - scope.Deductible - scope.OandP - scope.Tax;
			else
				return scope.Total - scope.Interior - scope.Exterior - scope.Gutter - scope.RoofAmount - scope.Tax;
		}


		virtual public double Calculate(double interior, double exterior, double gutters, double roof, double total, double oandp,double deductible, double tax,bool acv=true)
		{
			


			if (acv)
				return total - interior - exterior - gutters - roof - deductible- oandp;
			else return total - interior - exterior - gutters - roof - tax;


		}
		virtual public string Calculate(string interior="0", string exterior="0", string gutters = "0", string roof = "0", string total = "0", string oandp = "0", string tax = "0", string deductible="0", bool acv= true)
		{
			string w;
			double a, b, c, d, e, f, g,h;
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

				return (e - a - b - c - d - f - g-h).ToString();


			return (e - a - b - c - d - g).ToString();

		}
		private DTO_Scope DisplayScopeInfo(List<DTO_Scope> scopelist, int typescope, DTO_Claim c)
		{
			DTO_Scope t = new DTO_Scope();
			if (scope != null && c != null && typescope > 0 && typescope < 4)
			{


				foreach (DTO_Scope s in scopelist)
				{
					if (s.ScopeTypeID == typescope)
					{
						
						
						bool b = s.ScopeID.Equals(t.ScopeID);
						if (!b)
						{
							SetDisplayToScopeTypeIDByScope(s);
							deductibleTextBox.Text = s.Deductible.ToString();
							oandPTextBox.Text = s.OandP.ToString();
							interiorTextBox.Text = s.Interior.ToString();
							gutterTextBox.Text = s.Gutter.ToString();
							totalTextBox.Text = s.Total.ToString();
							exteriorTextBox.Text = s.Exterior.ToString();
							taxTextBox.Text = s.Tax.ToString();
							Roof.Text = s.RoofAmount.ToString();
							return scope;
						}
						else return t;

					}
				}
			}  return t;
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
			switch (typescope)
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
				ScopeTypeID = typescope,
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
					MessageBox.Show(s1.ClaimStatus.ClaimStatusID.ToString());
				}
				else
				{
					MessageBox.Show(s1.ClaimStatus.Message);
				}

				MessageBox.Show(s1.Scope.ScopeID.ToString());
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
