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


using System.Globalization;



namespace MRNUIElements.Controllers
{
	

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class Capout_Calculator : Window
	{
		
		bool suspendcapoutfunction = false;
		bool SAVE = true;
		public Capout_Calculator()
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
				ClearButton_Copy.Visibility = Visibility.Hidden;
				textBlock.Background = System.Windows.Media.Brushes.White;
				textBlock.Foreground = System.Windows.Media.Brushes.Black;
				Canvas.Background = System.Windows.Media.Brushes.White;
				PrintButton.Visibility = Visibility.Hidden;
				SplitOverride.Visibility = Visibility.Hidden;
				SalespersonSplitText.Visibility = Visibility.Hidden;
				Canvas.InvalidateVisual();
				
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
				//textBlock.Foreground = System.Windows.Media.Brushes.White;
				Canvas.Background = System.Windows.Media.Brushes.Transparent;
				ClearButton.Visibility = Visibility.Visible;
				ClearButton_Copy.Visibility = Visibility.Visible;
				PrintButton.Visibility = Visibility.Visible;
				SplitOverride.Visibility = Visibility.Visible;
				SalespersonSplitText.Visibility = Visibility.Visible;
				Canvas.InvalidateVisual();


			}
		}
		private void Save(string path, string fileName, int width, int height)
		{
			try
			{

				RenderTargetBitmap target = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
			target.Render(Canvas);

			var renderTargetbitmap = target;
			var bitmapImage = new BitmapImage();
			var bitmapEncoder = new PngBitmapEncoder();

			

				bitmapEncoder.Frames.Add(BitmapFrame.Create(target));
				/*	using (var stream = new MemoryStream())
					{
						bitmapEncoder.Save(stream);
						//	stream.Seek(0, SeekOrigin.Begin);
						//bitmapImage.BeginInit();
						//bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
						bitmapImage.StreamSource = stream;
						//	bitmapImage.EndInit();
					}  */
				path = path.Replace(" ", "_");
				path = path.Replace(",", "_");
				fileName = fileName.Replace(" ", "_");
				fileName = fileName.Replace(",", "_");
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);
				using (Stream outputStream = File.Create(path+fileName))
			{//get ready to save stream set
					System.Windows.Forms.MessageBox.Show(path + fileName);
					bitmapEncoder.Save(outputStream);//ok spit that shit to the file biatch
			}

			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());

			}
			
			// Save is set to true when user is satisfied with the text on the picture
			// some functional changes will need to be made to make this save files in the write place on upload but that should be taken care of on upload this is for temporary storage only 
			// 





		}

		
		   

				
		
	  

		private void Print()
		{
			
			PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
			Size windowSize = new Size(Canvas.Width, Canvas.Height);
			Size pageSize = new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight);
			Canvas.Measure(pageSize);
			Canvas.Background = System.Windows.Media.Brushes.White;
			Canvas.Arrange(new Rect(0, 0, pageSize.Width, pageSize.Height));
			printDlg.PrintVisual(Canvas, "Job Profit Loss Report");
			var directory = new StringBuilder();
			var fileName = new StringBuilder();

			if (directory.Length > 0)
				directory.Clear();
			if (fileName.Length > 0)
				fileName.Clear();
			directory.Append("c:\\Capouts\\" + CustomerNameText.Text + "\\");

			fileName.Append(ZipcodeText.Text + ".png");

			Save(directory.ToString(), fileName.ToString(), (int)pageSize.Width,(int) pageSize.Height);
			Canvas.InvalidateVisual();
			Canvas.Measure(windowSize);
			Canvas.Arrange(new Rect(0, 0, windowSize.Width, windowSize.Height));
			Canvas.UpdateLayout();
			Canvas.InvalidateVisual();
		


			PeekABoo(true);
		}

		private void PrintButton_Click(object sender, RoutedEventArgs e)
		{
			PeekABoo();


		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			
			  Initialize();

		}

		#endregion

		#region Math

		private double ChecksTotal()
		{
			double chk = 0;


			
			chk += (double)DeductibleCheckAmountText.Value;
		
			chk += (double)FirstCheckAmountText.Value;
			
			chk += (double)DepreciationAmountText.Value;
		
			chk += (double)SupplementCheckAmountText.Value;
		
			chk += (double)UpgradeCheckAmountText.Value;

			return chk;
		}

		private double MiscCost()
		{
			double exp = 0;
			{
				
				exp += (double)ReceiptAmount1Text.Value;
				
				exp += (double)ReceiptAmount2Text.Value;
				
				exp += (double)ReceiptAmount3Text.Value;
			
				exp += (double)ReceiptAmount4Text.Value;
			
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
			
		}

		private double FigureScopeDiff()
		{
			if (OriginalScopeAmountText.Value == null) OriginalScopeAmountText.Value = 0;
			if (FinalScopeAmount.Value == null) FinalScopeAmount.Value = 0;
			return (double)FinalScopeAmount.Value - (double)OriginalScopeAmountText.Value;
		

		}

		private double TotalExpense()
		{
			double TotalExpense = 0;


			TotalExpense += FigureRoofersBill((double)NumberOfSquaresAmountText.Value, checkBox.IsChecked.Value);
			
			TotalExpense += (double)InteriorBillAmountText.Value;
			
			TotalExpense += (double)ExteriorBillAmountText.Value;
		
			TotalExpense += (double)GutterBillAmountText.Value;
			
			TotalExpense += (double)MiscBillAmount.Value;

			TotalExpense += (double)FigureKnockerReferralFee((double)NumberOfSquaresAmountText.Value);
			
			TotalExpense += (double)RoofMaterialExpenseSubtotalText.Value;
			
			TotalExpense += (double)OverheadAmountText.Value;

			return TotalExpense;
		}

		private double TotalProfit()
		{
		
			return ChecksTotal() - TotalExpense();

			
		}

		private double FigureRoofersBill(double NOS, bool isNC = false)
		{
			if (this.IsLoaded && this.IsInitialized)
				if (suspendcapoutfunction)
					return (double)RoofLaborBillAmountText.Value;
				if (isNC)
					return NOS * 67.5;
				else 
					//if (MessageBoxResult.Yes == MessageBox.Show("Is the roofer Marteen or Oscar", "Which Mexican did this job?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes))
						if (NOS < 40)
							return NOS * 50 + 250;
			return NOS * 56.25;
		}

		private double FigureKnockerReferralFee(double NOS)
		{
			try
			{
				if (string.IsNullOrEmpty(ReferralKnockerText.Text))
					return 0;
				else if (ReferralKnockerText.Text == "")
					return 0;
				else if (NOS > 0 && NOS < 40)
					return 250;
				else
					return 500;
			
				
					

			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Knocker / Referral didn't figure proper.");
				return 0;
			}

		}
		#endregion

		#region WorkFunctions

		private void Initialize()
		{
			if (!RoofLaborBillAmountText.IsReadOnly)
			{
				RoofLaborBillAmountText.Background = Brushes.White;
				RoofLaborBillAmountText.IsReadOnly = true;
				RoofLaborBillAmountText.IsReadOnlyCaretVisible = true;
				suspendcapoutfunction = false;
			}

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
			if ((bool)checkBox.IsChecked)
				checkBox.IsChecked = false;
			ReferralKnockerText.Text = string.Empty;
			TotalAmountCollectedText.Value = 0;
			AmountCollectedSubTotal.Value = 0;
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
			SalespersonSplitAmountText.Value = 0;
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
			MRNTEXTBLOCK.Text = "";
		}


		private void CapOutJob(double TotChk = 0, double TotExp = 0, double NoSq = 0, double splitvar = 50, double ohvar = 10, double smp = 25)
		{
			try
			{


			//	if (NumberOfSquaresAmountText.Value != 0 || NumberOfSquaresAmountText.Value != null)
					NoSq = (double)NumberOfSquaresAmountText.Value;
				InitialDrawAmountText.Value = 500;
				//	if (NoSq != 0)
				//	{	
				double OH = (double)FinalScopeAmount.Value * (ohvar * .01);
				KnockerReferralAmountText.Value = (decimal)FigureKnockerReferralFee(NoSq);
				OverheadAmountText.Value = (decimal)OH;
					// double RawProfit = TotalProfit();
					double SalesProfit = TotalProfit() - (TotalProfit() * ((100 - splitvar) * .01));
					double MRNSP = TotalProfit() - SalesProfit;
					double SalesMP = (ChecksTotal() * .1) * (smp * .01);
					double MRNTP = MRNSP - SalesMP;
					double CPSQ = 0;
					double PPSQ = 0;

					TotalAmountCollectedText.Value = (decimal)ChecksTotal();
					TotalExpenseText.Value = (decimal)TotalExpense();

					MiscBillAmount.Value = (decimal)MiscCost();
				
					
				
					RoofLaborBillAmountText.Value = (decimal)FigureRoofersBill(NoSq, (bool)checkBox.IsChecked);
					RoofMaterialExpenseSubtotalText.Value = (decimal)FigureJobMaterialCost();
					AdjustedRoofSubtotalAmountText.Value = RoofMaterialExpenseSubtotalText.Value;
					#region FigureSalesManagerPortion
					if (RecruiterText.Text != string.Empty)
					{
						StringBuilder sb = new StringBuilder();
						sb.Clear();
						if (ChecksTotal() > 0)
							if (SalespersonName.Text != string.Empty)
							{
								RecruiterText.Text = SalesMP.ToString();
							}
					}
					#endregion
					if (NoSq != 0)
						CPSQ = (TotalExpense()-OH) / NoSq;
					CostPerSquareAmount.Value = (decimal)CPSQ;
					if (NoSq != 0)
						PPSQ = TotalProfit() / NoSq;
					ProfitPerSquareAmount.Value = (decimal)PPSQ;
					ProfitAmountText.Value = (decimal)TotalProfit();
					AmountCollectedSubTotal.Value = (decimal)ChecksTotal();
					SalespersonSplitAmountText.Value = (decimal)SalesProfit;
					MRNAmountDueText.Value = (decimal)MRNTP;
					MRNTEXTBLOCK.Text = MRNTP.ToString();
					SalespersonAmountDueText.Value = (decimal)SalesProfit - (decimal)InitialDrawAmountText.Value;

			//	}

			}
			catch (Exception ex)
			{

				
			}
		}

		public void CapOut()
		{
			{
				try
				{

			
				
				SettlementDifferenceAmount.Value = (decimal)FigureScopeDiff();

				//if (NumberOfSquaresAmountText.Value != 0 || NumberOfSquaresAmountText.Value != null)
					FigureRoofersBill((double)NumberOfSquaresAmountText.Value, (bool)checkBox.IsChecked.Value);
				CapOutJob((double)ChecksTotal(), (double)TotalExpense(), (double)NumberOfSquaresAmountText.Value, (double)SalespersonSplitText.PercentValue, (double)OverheadMultiplierAmountText.PercentValue, (double)25);
			
					}
				catch (Exception ex)
			{


			}
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

		private void NumberOfSquaresAmountText_LostFocus(object sender, RoutedEventArgs e)
		{
			CapOut();
		}


		#endregion

		private void ZipcodeText_TextChanged(object sender, TextChangedEventArgs e)
		{
			string str = string.Empty;
			str = ZipcodeText.Text;

			try
			{
				if (str.All((char.IsNumber)) && str.Count() == 5)
				{
					ZipcodeText.Text = new AddressZipcodeValidation().CityStateLookupRequest(str, 1);
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Come on Homie you can do better than that.");

			}
			
			CapOut();
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you want to quit?", "Program Exit Sequence Activated!", MessageBoxButton.YesNo, MessageBoxImage.Question))
				this.Close();
			else return;
		}

		private void CustomerNameText_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void CustomerAddressText_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void SalespersonSplitText_PercentValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void OverheadMultiplierAmountText_PercentValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void RoofLaborBillAmountText_TextChanged_1(object sender, TextChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
			
			
		}

		private void RoofLaborBillAmountText_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			suspendcapoutfunction = true;
			if (RoofLaborBillAmountText.IsReadOnly)
			{
				if (NumberOfSquaresAmountText.Value < 5)
				{
					MessageBox.Show("Don't Forget to put the squares in, I will take you there to do that", "Potential Problem ahead!", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
					NumberOfSquaresAmountText.Focus();
			 	}
				
				//RoofLaborBillAmountText.IsEnabled = true;
				RoofLaborBillAmountText.IsReadOnly = false;
				RoofLaborBillAmountText.IsReadOnlyCaretVisible = false;
				RoofLaborBillAmountText.Focus();
				

			}
			
		}

		private void RoofLaborBillAmountText_LostFocus(object sender, RoutedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized){
				if (suspendcapoutfunction == true)
				{
					suspendcapoutfunction = false;
					CapOut();
				}
				else {
					if (!RoofLaborBillAmountText.IsReadOnly)
						RoofLaborBillAmountText.IsReadOnly = true;
					if (!RoofLaborBillAmountText.IsReadOnlyCaretVisible)
						RoofLaborBillAmountText.IsReadOnlyCaretVisible = true;

					CapOut();
				}
			}
		}

		private void NumberOfSquaresAmountText_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		
				CapOut();
		}

		private void MaterialBillAmountText_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void OverheadAmountText_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void OverheadAmountText_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void ReceiptAmount1Text_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void ReceiptAmount2Text_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void ReceiptAmount3Text_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void ReceiptAmount4Text_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void ReceiptAmount5Text_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void NumberOfSquaresAmountText_GotFocus(object sender, RoutedEventArgs e)
		{
			
			

		}

		private void FirstCheckAmountText_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void SupplementCheckAmountText_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void DeductibleCheckAmountText_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void DepreciationAmountText_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void UpgradeCheckAmountText_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();
		}

		private void checkBox1_Checked(object sender, RoutedEventArgs e)
		{
			if (this.IsLoaded && this.IsInitialized)
				CapOut();

		}
	}
}