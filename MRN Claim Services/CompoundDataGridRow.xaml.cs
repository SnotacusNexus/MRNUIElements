using System;
using Syncfusion.UI.Xaml.Charts;
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
using MRN_Claim_Services.Controllers;
using MRN_Claim_Services.ViewModels.Converters;
using MRN_Claim_Services.Models;
using MRNNexus_Model;
//using static MRN_Claim_Services.Models.Calculations;
using static MRN_Claim_Services.Models.ScopeModel;
using static MRN_Claim_Services.Models.TransactionModel;
using static MRN_Claim_Services.ViewModels.Claims_Receivables;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;
using Syncfusion;
using System.IO;
using System.Windows.Media.Animation;


namespace MRN_Claim_Services
{

    //public class CompoundDataGridResult
    //{


    //    public ScopeModel sourceModel { get; set; }

    //    public decimal TotalClaimValue { get; set; }
    //    public decimal  FirstCheckValue { get; set; }
    //    public decimal MaterialsTax { get; set; }
    //    public decimal DeductibleAmount { get; set; }
    //    public decimal DepreciationCheckScopeValue { get; set; }
    //    public decimal  OverheadIncomeValue { get; set; }
    //    public decimal OverheadFigureExpenseValue { get; set; }
    //    public decimal MaterialCostValue { get; set; }
    //    public decimal LaborCostValue { get; set; }
    //    public decimal OtherWorkCostValue { get; set; }
    //    public decimal SupervisorCostValue { get; set; }
    //    public decimal AdministrativeCostValue { get; set; }
    //    public decimal AuditingCostValue { get; set; }
    //    public decimal AuditingAssitantValue { get; set; }
    //    public decimal ProductionCostValue { get; set; }
    //    public decimal SalesManagerCostValue { get; set; }
    //    public decimal SalespersonCommissionValue { get; set; }
    //    public decimal KnockerReferralCommissionValue { get; set; }
    //    public decimal CompanyCollectionValue { get; set; }
    //    public decimal CollectionsTotal { get; set; }
    //    public double SalespersonCommissionPercent { get; set; }
    //    public decimal SupplementAmount { get; set; }
    //    public decimal SettledValue { get; set; }
    //    public decimal AmountRemainingValue { get; set; }

    //    public bool IsSupplementCollected { get; set; }
    //    public bool IsClaimSettled { get; set; }
    //    public bool IsDepreciationCollected { get; set; }
    //    public bool IsFirstCheckCollected { get; set; }
    //    public bool IsSupervised { get; set; }
    //    public bool IsKnockedReferral { get; set; }
    //    public bool IsHouseDeal { get; set; }
    //    public bool IsFinalPayment { get; set; }

    //    public DateTime SignedDate { get; set; }
    //    public DateTime TrackingStartDate { get; set; }
    //    public DateTime FinalCollectedDate { get; set; }

    //    public double FirstCheckPercent { get; set; }
    //    public  double DepreciationPercent { get; set; }
    //    public double  DeductiblePercent { get; set; }
    //    public double SettlementPercentIncrease { get; set; }
    //    public double MaterialsCostExpensePercent { get; set; }
    //    public double LaborCostExpensePercent { get; set; }
    //    public double OverheadCostExpensePercent { get; set; }
    //    public double SalescommissionExpensePercent { get; set; }
    //    public double ProfitMarginPercent { get; set; }
    //    public decimal ProfitPerSquareValue { get; set; }
    //    public decimal ExpensePerSqValue { get; set; }




    //    public CompoundDataGridResult()
    //    {


    //    }

    //    public CompoundDataGridResult(ScopeModel sm)
    //    {
    //        sourceModel = sm;
    //    }

    //    public CompoundDataGridResult ResultSetCompoundDataGridResult(ScopeModel sm, object varReturnType, int infoRequested)
    //    {
    //        return this;
    //    }
    //}
    /// <summary>
    /// Interaction logic for CompoundDataGridRow.xaml
    /// </summary>
    public partial class CompoundDataGridRow
    {
        public static CompoundDataGridRow CDR;
        public static ObservableCollection<CompoundDataGridRow> CDGR;
        public static ScopeModel s1 = ScopeModel.getInstance();
        public static ObservableCollection<ScopeModel> scopelist = ScopeModel.lgetInstance();
    //    public static ObservableCollection<Calculations> calculations = Calculations.lgetInstance();
    //    public static Calculations c1 = Calculations.getInstance();
        public double Profitability { get; set; }
     //   public  Calculations calculation { get; set; }
        public double PercentLabor {get;set;}
        public StateChanged StateChanged { get; set; }
        private StateChanged stateChanged { get; set; }
        public double PercentMaterial { get; set; }
        public int CommentNumberIndex=0;
        public int index = 0;
        public CompoundDataGridRow(int index = -1, ScopeModel sourceModel = null)
        {
            InitializeComponent();
          //  listViewB.ItemsSource = scopelist;
          //  if (sourceModel == null)
           //     sourceModel = new ScopeModel();
           
            Animation.Animate3D(PieChart);
            if (index > -1)
                sourceModel = scopelist[index];

          
           
            this.index= index;


            if (sourceModel == null && index < 0)
            {
                return;
            }
           
            init(sourceModel);
        }

        public bool HasStateChanged(StateChanged stateChanged)
        {
            if (stateChanged.Deductible != StateChanged.Deductible || stateChanged.Depreciation != StateChanged.Depreciation || stateChanged.First != StateChanged.First)
                return true;

            return false;
        }
        private void SetState(ScopeModel s)
        {

            stateChanged.Deductible = s.IsCollectedDed;
            stateChanged.Depreciation = s.IsCollectedDep;
            stateChanged.First = s.IsCollectedFirst;
        }
        private double AmountSalesManagerPay(bool IsHouse, double adjustedOH)
        {
            if (IsHouse == true)
            {
                return 0;

            }
            else
            {
                return((adjustedOH*.1) * .125);

            }
        }

        public decimal ForgivenDeductible(ObservableCollection<ScopeModel> s, string who)
        {
            decimal deduct = 0;
            if (s != null && who != null)
                foreach (var d in s.Where(d => d.Salesperson == who))
                    if (d.IsCollectedDed == false)
                        deduct -= (decimal)d.Deductible;
                    else deduct += (decimal)d.Deductible;


            return deduct;
        }
        private double SplitIt(double totalprofit, out double overhead, out double companypart,  double percentsplit=50, double percentOH = 10)
        {

            overhead = (totalprofit * .1);
            companypart = totalprofit - ((totalprofit - overhead) * (percentsplit * .01));
            return ((totalprofit - overhead) * (percentsplit *.01));
        }
        
        private double ReferralAmount(bool IsRef)
        {
            if (IsRef == true)
                if (TotalSquares.Value > 40)
                    return 500;
                else return 250;
            else return 0;
        }
    
        public double IsDeductibleCollected(bool dedcol, double dedamt)
        {
            if (dedcol == true)
                return 0;
            return dedamt;
        }
        private double HowOldIsThisClaim(DateTime dtt)
        {
            DateTime dt = new DateTime(DateTime.Today.Ticks);
            return dt.Subtract(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)).TotalDays;
        }
        #region Comment Functions
        #region File Duties Read Write Serialize Deserialize type things



        public List<string> LoadCommentsForClaims(string ClaimNumber = null)
        {
            List<string> sl = new List<string>();


            //   OpenFileDialog ofd = new OpenFileDialog();
            //    ofd.Filter = ".txt | text files || .xml | XML (ExtensibleMarkupLanguage)";
            //     StringBuilder output = new StringBuilder();
            try
            {
                //ofd.FileName;
                using (StreamReader st = new StreamReader("claimComments.txt"))

                {
                    string line;
                    while ((line = st.ReadLine()) != null)
                    {
                        if (ClaimNumber != null)
                            if (line.Contains(ClaimNumber))
                                sl.Add(line.Remove(line.IndexOf(".=.")));
                      //      else;
                      //  else commentlist.Add(line);

                    }
                }



            }

            catch (Exception ex)
            {
                MessageBox.Show("File Couldn't be read! " + ex.Message);

            }

            return sl;
        }

        public bool SaveClaimComment(string commenttosave, string claimnumber, bool append = true)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(claimnumber);
            sb.Append(".=.");
            sb.Append(commenttosave);

            using (StreamWriter sw = new StreamWriter("claimComments.txt", append))
            {

                sw.WriteLine(sb.ToString());
            }

            return true;
        }

        #endregion

        public string GetClaimComments(List<string> ccl)
        {
            if (ccl.Count > CommentNumberIndex + 1)
                return ccl[CommentNumberIndex++];
            else return "";

        }




        public string DisplayClaimsComments(string claimNumber, List<string> CommentList)
        {
            string w = "";
            if (CommentList!=null)
            foreach (var s in CommentList.Where(s => s.Contains(claimNumber)))
            {

                w += "#" + s.Remove(s.IndexOf(".=.")) + "#";
            }

            return w;
        }








        #endregion


        public CompoundDataGridRow init(ScopeModel s) {

           
            s1 = s;
            Salesperson.Text = s.Salesperson;
            CustomerName.Text = s.CustomerName;
            ClaimNumber.Text = s.ClaimNumber;
            if (TotalClaimScope.Value == 0)
                if (SettledAmount.Value < (decimal)s.RCV)
                    TotalClaimScope.Value = (decimal)s.RCV;
                else TotalClaimScope.Value = SettledAmount.Value;
            TotalSquares.Value = s.NoSquares;
            DepreciationCheckScope.Value = (decimal)s.RCV - (decimal)s.ACV - (decimal)s.Deductible;
            FirstCheckScope.Value = (decimal)s.ACV;
            DeductibleScope.Value = (decimal)s.Deductible;
            SalespersonDraw.Value = (decimal)s.Draw;
            KnockRefAmount.Value = (decimal)ReferralAmount((bool)s.IsReferral);
            ProjectedLaborCost.Value = (decimal)(TotalSquares.Value * 1.15) * 68;
            ProjectedMaterialCost.Value = (decimal)(TotalSquares.Value * 1.15) * 107;
            DeductibleIsCollected.IsChecked = s.IsCollectedDed;
            DepreciationIsCollected.IsChecked = bool.Parse(s.IsCollectedDep.ToString());
            FirstCheckIsCollected.IsChecked = bool.Parse(s.IsCollectedFirst.ToString());
            MaterialIsPaid.IsChecked = bool.Parse(s.IsPaidMaterial.ToString());
            LaborIsPaid.IsChecked = bool.Parse(s.IsPaidRoof.ToString());


            if (s.IsPaidOW == true)
                OtherWorkCost.Value = (decimal)s.RCV - (decimal)s.RoofAmount - (decimal)s.Tax;
            else OtherWorkCost.Value = 0;
            if(SettledAmount.Value>0 && SettledAmount.Value > (decimal)s.RCV)
            if (ClaimIsSettled.IsChecked == false)
                SupplementCollected.Value = 0;
            else SupplementCollected.Value = SettledAmount.Value - (decimal)s.RCV;
            if (DeductibleIsCollected.IsChecked == false)
                DeductibleCollected.Value = 0;
            else DeductibleCollected.Value = DeductibleScope.Value;
            if (DepreciationIsCollected.IsChecked == false)
                DepreciationCheckCollected.Value = 0;
            else DepreciationCheckCollected.Value = DepreciationCheckScope.Value;
            if (FirstCheckIsCollected.IsChecked == false)
                FirstCheckCollected.Value = 0;
            else FirstCheckCollected.Value = FirstCheckScope.Value;
            if (MaterialIsPaid.IsChecked == false)
                MaterialCostApplied.Value = 0;
            else MaterialCostApplied.Value = ProjectedMaterialCost.Value;
            if (LaborIsPaid.IsChecked == false)
                LaborCostAppled.Value = 0;
            else LaborCostAppled.Value = ProjectedLaborCost.Value;
            SettledAmount.Value = (decimal)s.SettlementAmount;
            TotalCollected.Value = FirstCheckCollected.Value + DepreciationCheckCollected.Value + DeductibleCollected.Value + SupplementCollected.Value;
            AmountOwedLeft.Value = TotalClaimScope.Value - TotalCollected.Value;
            OverheadOnTotalClaim.Value = (decimal)(TotalClaimScope.Value /10);
            if (s.IsSupervised)
                SupervisorCharge.Value = 120;
            else SupervisorCharge.Value = 0;
            ProductionFee.Value = 200;
            AdministrationCharge.Value = Salesmanagerpart2.Value;
            AuditingAsst.Value = Salesmanagerpart2.Value;
            Auditor.Value = Salesmanagerpart2.Value;
            AmountSpent.Value = (decimal)LaborCostAppled.Value + MaterialCostApplied.Value + ((TotalCollected.Value/10) - KnockRefAmount.Value - OtherWorkCost.Value - SupervisorCharge.Value - Auditor.Value- AuditingAsst.Value - AdministrationCharge.Value-ProductionFee.Value-Salesmanagerpart2.Value);
            ClaimAge.Value = (long)HowOldIsThisClaim(s.ScopeDate);
            ProjectedProfit.Value = TotalClaimScope.Value - ProjectedLaborCost.Value - ProjectedMaterialCost.Value - (decimal)s.Tax - OverheadOnTotalClaim.Value;
            SalesProjectedProfit.Value = ProjectedProfit.Value / 2;
            OHLeft.Value= (TotalCollected.Value / 10) - KnockRefAmount.Value - OtherWorkCost.Value - SupervisorCharge.Value - Auditor.Value - AuditingAsst.Value - AdministrationCharge.Value - ProductionFee.Value - Salesmanagerpart2.Value;
            double d = 0;
            double e = 0;
           
            ProjectedCapTotal.Value = ProjectedProfit.Value - SalesProjectedProfit.Value;
            CurrentProfit.Value = TotalCollected.Value - AmountSpent.Value;
            SalespersonCurrent.Value = (CurrentProfit.Value * ((decimal)s.SalesSplit * (1 / 100)) - SalespersonDraw.Value);
            SalespersonCurrent.Value = (decimal)SplitIt((double)CurrentProfit.Value, out d, out e,s.SalesSplit);
            SalesmanagerpartOH.Value =TotalCollected.Value/10;
            double f = 0;
            f = (double)SalesmanagerpartOH.Value;
            f = f * .125;
            Salesmanagerpart2.Value =  (decimal)f;
            ActualCapOutTotal.Value = (decimal)e;
          
            if (SchedRoofDate.Text == "1/1/0001"||SchedRoofDate.Text == "Not Scheduled")
                SchedRoofDate.Text = "Not Scheduled";
            else SchedRoofDate.Text = s.ScheduledRoofDate.ToShortDateString();
            if (OtherWorkDate.Text == "1/1/0001" || OtherWorkDate.Text == "Not Scheduled")
                OtherWorkDate.Text = "Not Scheduled";
           else OtherWorkDate.Text = s.ScheduledCOCDate.ToShortDateString();
            if(TotalSquares.Value>0)
            CostPerSQ.Value = (decimal)AmountSpent.Value / (decimal)TotalSquares.Value;
            if (TotalSquares.Value > 0)
                ProfitPerSQ.Value = (decimal)TotalCollected.Value / (decimal)TotalSquares.Value;
           // ClaimStatus.Text = DisplayClaimsComments(ClaimNumber.Text, commentlist);
            AmountOwedLeft.Value = TotalClaimScope.Value - TotalCollected.Value;
            FirstCheckpercentofClaim.PercentValue = (double)FirstCheckScope.Value / (double)TotalClaimScope.Value * 100; 
            DeductiblepercentofClaim.PercentValue = (double)DeductibleScope.Value / (double)TotalClaimScope.Value * 100;
            DepreciationpercentofClaim.PercentValue = (double)DepreciationCheckScope.Value / (double)TotalClaimScope.Value * 100;
            Materialpercentofcost.PercentValue = (double)ProjectedMaterialCost.Value / (double)TotalClaimScope.Value*100;
            rooflaborpercentofcost.PercentValue = (double)ProjectedLaborCost.Value / (double)TotalClaimScope.Value*100;
            Overheadpercentofcost.PercentValue = (double)OverheadOnTotalClaim.Value / (double)TotalClaimScope.Value * 100;
            ProfitMargin.PercentValue = (double)ProfitPerSQ.Value / (double)CostPerSQ.Value;
            ProfitabilityValue.Value = (decimal)TotalCollected.Value - (decimal)AmountSpent.Value;
            return this;
        }
        public string UpdatedClaimStatus(string str)
        {
            StringBuilder strbuild = new StringBuilder();
            strbuild.Append("Testing 1, 2 this is a test!");

            return strbuild.ToString();
        }
     
        public static CompoundDataGridRow getInstance()
        {
            if (CDR == null)
            {
                CDR = new CompoundDataGridRow(-1,null);
            }

            return CDR;
        }
        public static ObservableCollection<CompoundDataGridRow> lgetInstance()
        {
            if (CDGR == null)
            {
                CDGR = new ObservableCollection<CompoundDataGridRow>();
            }

            return CDGR;
        }


        private void DetailedClaimGridRow_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void FirstCheckIsCollected_Checked(object sender, RoutedEventArgs e)
        {
          
        }

        private void FirstCheckIsCollected_Click(object sender, RoutedEventArgs e)
        {
            if (!scopelist[index].IsCollectedFirst)
                scopelist[index].IsCollectedFirst = true;
            else scopelist[index].IsCollectedFirst = false;
            s1.SaveClaimDetails(false, scopelist[index]);
            init(scopelist[index]);
        }

        private void DepreciationIsCollected_Click(object sender, RoutedEventArgs e)
        {
            if (!scopelist[index].IsCollectedDep)
                scopelist[index].IsCollectedDep = true;
             else scopelist[index].IsCollectedDep = false;

            s1.SaveClaimDetails(false, scopelist[index]);
            init(scopelist[index]);
        }

        private void DeductibleIsCollected_Click(object sender, RoutedEventArgs e)
        {
            if (!scopelist[index].IsCollectedDed)
                scopelist[index].IsCollectedDed = true;
            else scopelist[index].IsCollectedDed = false;

            s1.SaveClaimDetails(false, scopelist[index]);
            init(scopelist[index]);
        }

        private void DeductibleIsCollected_Copy_Click(object sender, RoutedEventArgs e)
        {
           
        }

     

        private void MaterialIsPaid_Click(object sender, RoutedEventArgs e)
        {

            if (!scopelist[index].IsPaidMaterial)
                scopelist[index].IsPaidMaterial = true;
            else scopelist[index].IsPaidMaterial = false;
            s1.SaveClaimDetails(false, scopelist[index]);
            init(scopelist[index]);
        }

        private void LaborIsPaid_Click(object sender, RoutedEventArgs e)
        {
            if (!scopelist[index].IsPaidRoof)
                scopelist[index].IsPaidRoof = true;
            else scopelist[index].IsPaidRoof = false;
            s1.SaveClaimDetails(false, scopelist[index]);
            init(scopelist[index]);
        }

        private void LaborIsPaid_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void PieChart_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void SettledClick(object sender, RoutedEventArgs e)
        {

        }

        private void SupplementIsCollected_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public static class Animation
        {
            public static void Animate3D(SfChart3D chart)
            {
                var sb = new Storyboard();

                DoubleAnimation animation = new DoubleAnimation() { From = 0, To = chart.Rotation, };
                Storyboard.SetTarget(animation, chart);
                Storyboard.SetTargetProperty(animation, new PropertyPath(SfChart3D.RotationProperty));

                sb.Children.Add(animation);

                animation = new DoubleAnimation() { From = 0, To = chart.Tilt, };
                Storyboard.SetTarget(animation, chart);
                Storyboard.SetTargetProperty(animation, new PropertyPath(SfChart3D.TiltProperty));
                sb.Children.Add(animation);

                EventHandler handler = (object sender, EventArgs e) =>
                {
                    var rotation = chart.Rotation;
                    var tilt = chart.Tilt;
                    chart.BeginAnimation(SfChart3D.RotationProperty, null);
                    chart.BeginAnimation(SfChart3D.TiltProperty, null);
                    chart.Rotation = rotation;
                    chart.Tilt = tilt;
                };
                sb.Completed += handler;
                sb.Begin();
            }
        }

        public class StateChanged
        {
            public bool First
            {
                get;
                set;
            }

            public bool Depreciation
            {
                get;
                set;
            }
        public bool Deductible
        {
            get;
            set;
        }
    }

       
        /// <summary>
        /// To apply format for the adornment label.
        /// </summary>
        public class Labelconvertor : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                ChartAdornment pieAdornment = value as ChartAdornment;
                return String.Format("{0} %", pieAdornment.YData);
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// To vary the light proportion in the color. 
        /// </summary>
        public class ColorConverter : IValueConverter
        {
            private SolidColorBrush ApplyLight(Color color)
            {
                return new SolidColorBrush(Color.FromArgb(color.A, (byte)(color.R * 0.9), (byte)(color.G * 0.9), (byte)(color.B * 0.9)));
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value != null)
                {
                    ChartAdornment pieAdornment = value as ChartAdornment;
                    int index = pieAdornment.Series.Adornments.IndexOf(pieAdornment);
                    SolidColorBrush brush = pieAdornment.Series.ColorModel.CustomBrushes[index] as SolidColorBrush;
                    return ApplyLight(brush.Color);
                }
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
   

}

