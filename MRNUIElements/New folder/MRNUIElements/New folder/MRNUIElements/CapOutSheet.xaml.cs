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
//using System.Drawing;

using System.Diagnostics;

using System.IO;
using MRNNexus_Model;
using System.Globalization;

namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class CapOutSheet : Page
	{
		public CapOutSheet()
		{
	
			InitializeComponent();
            Initialize();
	
			SalespersonName.Focus();
		}
		#region UtilityFunctions

		private void Window_Initialized(object sender, EventArgs e)
		{
            Initialize();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
            Initialize();
        }

		private void PeekABoo(bool bVisible = false)
		{
			if (!bVisible)
			{
                if (ReferralKnockerText.Text == string.Empty)
                    ReferralKnockerText.Visibility = Visibility.Hidden;
				OverheadOverride.Visibility = Visibility.Hidden;
				OverheadMultiplierAmountText.Visibility = Visibility.Hidden;
				label1_Copy15.Visibility = Visibility.Hidden;
				OverheadLabel.Visibility = Visibility.Hidden;
				SplitOverRideGroupbox.Visibility = Visibility.Hidden;
				label1_Copy24.Visibility = Visibility.Hidden;
				RecruiterText.Visibility = Visibility.Hidden;
				ClearButton.Visibility = Visibility.Hidden;
				textBlock.Background = System.Windows.Media.Brushes.White;
				textBlock.Foreground = System.Windows.Media.Brushes.Black;
				Canvas.Background = System.Windows.Media.Brushes.White;
				PrintButton.Visibility = Visibility.Hidden;
				SplitOverride.Visibility = Visibility.Hidden;
				SalespersonSplitText.Visibility = Visibility.Hidden;
				
				Print();
			}
			else
			{


                ReferralKnockerText.Visibility = Visibility.Visible;
				OverheadOverride.Visibility = Visibility.Visible;
				OverheadMultiplierAmountText.Visibility = Visibility.Visible;
				label1_Copy15.Visibility = Visibility.Visible;
				OverheadLabel.Visibility = Visibility.Visible;
				SplitOverRideGroupbox.Visibility = Visibility.Visible;
				label1_Copy24.Visibility = Visibility.Visible;
				RecruiterText.Visibility = Visibility.Visible;
                textBlock.Background = Brushes.Transparent;
				textBlock.Foreground = System.Windows.Media.Brushes.White;
				Canvas.Background = System.Windows.Media.Brushes.Transparent;
				ClearButton.Visibility = Visibility.Visible;
				PrintButton.Visibility = Visibility.Visible;
				SplitOverride.Visibility = Visibility.Visible;
				SalespersonSplitText.Visibility = Visibility.Visible;
			

			}
		}

		private void Print()
		{
			PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
			Canvas.LayoutTransform = new ScaleTransform(1, 1);
			Size pageSize = new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight-300);
			Canvas.Measure(pageSize);
			Canvas.Arrange(new Rect(0,0, pageSize.Width, pageSize.Height));
			printDlg.PrintVisual(Canvas, "Job Profit Loss Report");
			Canvas.LayoutTransform = null;


			PeekABoo(true);
		}

		private void PrintButton_Click(object sender, RoutedEventArgs e)
		{
			PeekABoo();
			

		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
            Page page = new CapOutSheet();
            NavigationService.Navigate(page);
          //  Initialize();
			
		}

		#endregion

		#region Math

		private double ChecksTotal()
		{
			double chk = 0;

			
				//if (DeductibleCheckAmountText.Value != null)
					chk += (double)DeductibleCheckAmountText.Value;
				//if (FirstCheckAmountText.Value != null)
					chk += (double)FirstCheckAmountText.Value;
				//if (DepreciationAmountText.Value != null)
					chk += (double)DepreciationAmountText.Value;
				//if (SupplementCheckAmountText.Value != null)
					chk += (double)SupplementCheckAmountText.Value;
				//if (UpgradeCheckAmountText.Value != null)
					chk += (double)UpgradeCheckAmountText.Value;
			
			return chk;
		}

		private double MiscCost()
		{
			double exp = 0;
			{
				//if (ReceiptAmount1Text.Value != null)
					exp += (double)ReceiptAmount1Text.Value;
			//	if (ReceiptAmount2Text.Value != null)
					exp += (double)ReceiptAmount2Text.Value;
				//if (ReceiptAmount3Text.Value != null)
					exp += (double)ReceiptAmount3Text.Value;
				//if (ReceiptAmount4Text.Value != null)
					exp += (double)ReceiptAmount4Text.Value;
				//if (ReceiptAmount5Text.Value != null)
					exp += (double)ReceiptAmount5Text.Value;
			}
			return exp;
		}


        private double FigureJobMaterialCost(double MaterialBillAmount = 0, double BringBackAmount = 0)
		{
            if (MaterialBillAmountText.Value != null)
                MaterialBillAmount = (double)MaterialBillAmountText.Value;

            if (BringBackAmountText.Value != null)
                BringBackAmount = (double)BringBackAmountText.Value;


            return (double)MaterialBillAmount + (double)BringBackAmount;
			//return 0;
		}

		private double FigureScopeDiff()
		{
			if (OriginalScopeAmountText.Value == null) OriginalScopeAmountText.Value = 0;
			if (FinalScopeAmount.Value == null) FinalScopeAmount.Value = 0;
			//if (((double)OriginalScopeAmountText.Value > 0 || OriginalScopeAmountText.Value != null) && ((double)FinalScopeAmount.Value > 0 || (FinalScopeAmount.Value != null)))
				return  (double)FinalScopeAmount.Value - (double)OriginalScopeAmountText.Value;
		//	return 0;

		}

		private double TotalExpense()
		{
			double TotalExpense = 0;

            if (RoofLaborBillAmountText.Value == null) RoofLaborBillAmountText.Value = 0;
                 TotalExpense += (double)RoofLaborBillAmountText.Value;
            if (InteriorBillAmountText.Value == null) InteriorBillAmountText.Value = 0;
                 TotalExpense += (double)InteriorBillAmountText.Value;
            if (ExteriorBillAmountText.Value == null) ExteriorBillAmountText.Value = 0;
                 TotalExpense += (double)ExteriorBillAmountText.Value;
            if (GutterBillAmountText.Value == null) GutterBillAmountText.Value = 0;
                 TotalExpense += (double)GutterBillAmountText.Value;
            if (MiscBillAmount.Value == null) MiscBillAmount.Value = 0;
                 TotalExpense += (double)MiscBillAmount.Value;
            if (KnockerReferralAmountText.Value == null) KnockerReferralAmountText.Value = 0;
                 TotalExpense += (double)KnockerReferralAmountText.Value;
            if (RoofMaterialExpenseSubtotalText.Value == null) RoofMaterialExpenseSubtotalText.Value = 0;
                 TotalExpense += (double)RoofMaterialExpenseSubtotalText.Value;
            if (OverheadAmountText.Value == null) OverheadAmountText.Value = 0;
                 TotalExpense += (double)OverheadAmountText.Value;

			return TotalExpense;
		}

		private double TotalProfit()
		{
		//	if (ChecksTotal() > 0 || TotalExpense() > 0)
				return ChecksTotal() - TotalExpense();

		//	return 0;
		}

		private double FigureRoofersBill(double NOS, bool isNC=false)
		{

			if (isNC)
				return NOS * 67.5;
		
				return NOS * 56.25;

		}

		private double FigureKnockerReferralFee(double NOS)
		{
            
			
                if (NOS < 40)
                    return 250;
                else
                    return 500;
			
		}
		#endregion
		
		#region WorkFunctions

        private void Initialize()
        {
           
            NumberOfSquaresAmountText.Value = 0;
            MaterialBillAmountText.Value = 0;
            BringBackAmountText.Value = 0;
          
           
            OriginalScopeAmountText.Value = 0;
            FinalScopeAmount.Value = 0;
            SettlementDifferenceAmount.Value = 0;
            DeductibleCheckAmountText.Value = 0;
            FirstCheckAmountText.Value = 0;
            DepreciationAmountText.Value = 0;
            UpgradeCheckAmountText.Value = 0;
            SupplementCheckAmountText.Value = 0;
            ReceiptAmount1Text.Value = 0;
            ReceiptAmount2Text.Value = 0;
            ReceiptAmount3Text.Value = 0;
            ReceiptAmount4Text.Value = 0;
            ReceiptAmount5Text.Value = 0;
            SalespersonName.Text = string.Empty;
            CustomerNameText.Text = string.Empty;
            CustomerAddressText.Text = string.Empty;
            ZipcodeText.Text = string.Empty;
            SalespersonSplitText.PercentValue = 50;
            OverheadMultiplierAmountText.PercentValue = 10;
            if ((bool)SplitOverride.IsChecked)
                SplitOverride.IsChecked = false;
            if ((bool)OverheadOverride.IsChecked)
            OverheadOverride.IsChecked = false;
            if((bool)checkBox.IsChecked)
            checkBox.IsChecked = false;
            ReferralKnockerText.Text = string.Empty;
            TotalAmountCollectedText.Value = 0;
            TotalExpenseText.Value = 0;
            OverheadAmountText.Value = 0;
            MiscBillAmount.Value = 0;
            KnockerReferralAmountText.Value = 0;
            RoofLaborBillAmountText.Value = 0;
            RoofMaterialExpenseSubtotalText.Value = 0;
            AdjustedRoofSubtotalAmountText.Value = 0;
            RecruiterText.Text = string.Empty;
            CostPerSquareAmount.Value = 0;
            ProfitPerSquareAmount.Value = 0;
            ProfitAmountText.Value = 0;
            AmountCollectedSubTotal.Value = 0;
            SalespersonSplitAmountText.Value =0;
            MRNAmountDueText.Value = 0;
            SalespersonAmountDueText.Value = 0;
            TotalExpenseText.Value = 0;
            GutterBillAmountText.Value = 0;
            InteriorBillAmountText.Value = 0;
            ExteriorBillAmountText.Value = 0;
            RoofLaborBillAmountText.Value = 0;
            ChecksTotal();
            TotalExpense();
            InitialDrawAmountText.Value = 500;
            SalespersonName.Focus();

        }


		private void CapOutJob(double TotChk = 0, double TotExp = 0, double NoSq = .01, double splitvar = 50, double ohvar = 10, double smp = .25)
		{
            if (NumberOfSquaresAmountText.Value != 0)
            NoSq = (double)NumberOfSquaresAmountText.Value;
            InitialDrawAmountText.Value = 500;
            if (NoSq != 0)
            {
                double OH = TotChk * (ohvar * .01);
                double RawProfit = TotalProfit();
                double SalesProfit = RawProfit - (RawProfit * ((100 - splitvar) * .01));
                double MRNSP = RawProfit - SalesProfit;
                double SalesMP = OH * (smp * .01);
                double MRNTP = MRNSP - SalesMP;
                double CPSQ = 0;
                double PPSQ = 0;
                   
                TotalAmountCollectedText.Value = (decimal)ChecksTotal();
                TotalExpenseText.Value = (decimal)TotalExpense();
                OverheadAmountText.Value = (decimal)OH;
                MiscBillAmount.Value = (decimal)MiscCost();
                if (ReferralKnockerText.Text != string.Empty)
                    KnockerReferralAmountText.Value = (decimal)FigureKnockerReferralFee(NoSq);
                RoofLaborBillAmountText.Value = (decimal)FigureRoofersBill(NoSq, (bool)checkBox.IsChecked);
                RoofMaterialExpenseSubtotalText.Value = (decimal)FigureJobMaterialCost();
                AdjustedRoofSubtotalAmountText.Value = RoofMaterialExpenseSubtotalText.Value;
                #region FigureSalesManagerPortion
                if (RecruiterText.Text != string.Empty)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Clear();
                    if (SalespersonSplitText.PercentValue > 0)
                        if (SalespersonName.Text != string.Empty)
                        {
                            string tempstring = RecruiterText.Text;
                            if (tempstring.Contains(" "))
                                sb.Append(tempstring.Substring(0, tempstring.IndexOf(" ")));

                            else sb.Append(RecruiterText.Text);
                            sb.Append(" -- $");
                            sb.Append(SalesMP);
                            tempstring = sb.ToString();

                            if (tempstring.Length - tempstring.IndexOf(".") > 2)
                                RecruiterText.Text = tempstring.Substring(0, tempstring.IndexOf(".") + 3);
                        }
                }
                #endregion
                CPSQ = TotExp / NoSq;
                CostPerSquareAmount.Value = (decimal)CPSQ;
                PPSQ = RawProfit / NoSq;
                ProfitPerSquareAmount.Value = (decimal)PPSQ;
                ProfitAmountText.Value = (decimal)RawProfit;
                AmountCollectedSubTotal.Value = (decimal)ChecksTotal();
                SalespersonSplitAmountText.Value = (decimal)SalesProfit;
                MRNAmountDueText.Value = (decimal)MRNTP;
               
                SalespersonAmountDueText.Value = (decimal)SalesProfit - (decimal)InitialDrawAmountText.Value;
              
            }

            else
                MessageBox.Show("You can't divide by Zero (0) that's just retarded!", "Stupid People Doing Stupid Shit!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

		}

		public void CapOut()
		{
			{
				SettlementDifferenceAmount.Value = (decimal)FigureScopeDiff();


                if (NumberOfSquaresAmountText.Value != 0)
					CapOutJob((double)ChecksTotal(), (double)TotalExpense(), (double)NumberOfSquaresAmountText.Value, (double)SalespersonSplitText.PercentValue, (double)OverheadMultiplierAmountText.PercentValue, (double)2.5);
			}
		}
		#endregion
		#region Controls
		#region TextChangeHandlers

		

		private void FirstCheckAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void SupplementCheckAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void DeductibleCheckAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void DepreciationAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void UpgradeCheckAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void RoofLaborBillAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void GutterBillAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void InteriorBillAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void ExteriorBillAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void BringBackAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void MaterialBillAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void ReceiptAmount4Text_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void ReceiptAmount5Text_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void ReceiptAmount3Text_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void ReceiptAmount2Text_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void ReceiptAmount1Text_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void NumberOfSquaresAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}


		private void FinalScopeAmount_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}


		private void OverheadMultiplierAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void SalespersonSplitText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}


		private void OriginalScopeAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void FinalScopeAmount_TextChanged_1(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void ReferralKnockerText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}

		private void RecruiterText_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();

		}

		private void SalespersonName_TextChanged(object sender, TextChangedEventArgs e)
		{
			CapOut();
		}
		#endregion

		private void checkBox_Checked(object sender, RoutedEventArgs e)
		{
			CapOut();
		}


        #endregion

        private void ZipcodeText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = string.Empty;
            str = ZipcodeText.Text;
            AddressZipcodeValidation azv = new AddressZipcodeValidation();

            if (str.All((char.IsNumber)) && str.Count() == 5)
            {
                string citystate = azv.CityStateLookupRequest(str);

                string city = citystate.Substring(citystate.IndexOf("<City>") + 6, citystate.IndexOf("</City>") - citystate.IndexOf("<City>") - 6);

                string state = AddressZipcodeValidation.ConvertStateToAbbreviation(citystate.Substring(citystate.IndexOf("<State>") + 7, citystate.IndexOf("</State>") - citystate.IndexOf("<State>") - 7));
                ZipcodeText.Text = CustomerAddressText.ToString();
                string[] w = city.Split(' ');
                city = "";
                int i = 0;

                foreach (string t in w)
                {
                    city += t.Substring(0, 1).ToUpper();
                    city += t.Substring(1, t.Length - 1).ToLower();
                    if (i > 0)
                        city += " ";

                }



                //	city.ToLower();
                //	TextInfo textinfo = new CultureInfo("en-US", false).TextInfo;
                //	textinfo.ToTitleCase(city);
                //city = Regex.Replace(city, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
                ZipcodeText.Text = city + ", " + state + "  " + str;
            }
        }
    }
}