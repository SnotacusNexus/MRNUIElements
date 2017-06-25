using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MRNUIElements.Models;
using static MRNUIElements.ViewModels.ViewModelBase;
using static MRNUIElements.Models.ScopeModel;
//using static MRNUIElements.Models.Calculations;
using static MRNUIElements.Models.TransactionModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics.Tracing;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Data;
using System.ComponentModel;
using MRNUIElements.ViewModels;
//using static MRNUIElements.CompoundDataGridRow;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Windows.Controls.Grid;

namespace MRNUIElements.ViewModels
{
   
    /// <summary>
    /// Interaction logic for Claims_Receivables.xaml
    /// </summary>
    public partial class Claims_Receivables : Page
    {
        
       static public ScopeModel sm = ScopeModel.getInstance();
     //   static public Calculations C = Calculations.getInstance();
     //   static public ObservableCollection<Calculations> C1 = Calculations.lgetInstance();
        static public ObservableCollection<ScopeModel> ScopeList = ScopeModel.lgetInstance();
 //       static public ObservableCollection<CompoundDataGridRow> cdr = CompoundDataGridRow.lgetInstance();
  //      static public CompoundDataGridRow CDGR = CompoundDataGridRow.getInstance();
       // Syncfusion.UI.Xaml.Grid.SfDataGrid dataGrid = new SfDataGrid();
      // public static ObservableCollection<CompoundDataGridRow> collection { get; set; } 
        bool needsUpdate = false;
        public int listbox = -1;
       // private int ypos=0;
      //  private int fontposition=0;
        private System.Windows.Controls.PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
        System.Windows.Forms.PrintPreviewDialog previewDlg = new System.Windows.Forms.PrintPreviewDialog();
        PrintDocument pd = new PrintDocument();
        public Claims_Receivables()
        {
            InitializeComponent();
            InIt();
           // this.DataContext =CDGR;
            scopeDateDatePicker.SelectedDate = DateTime.Today;
            sm.PopulateLists();
            SalespersonCombo.ItemsSource = SALESPERSON;
            BranchCombo.ItemsSource = BRANCHES;
           
          

        }

     
        private bool SaveFile()
        {



            sm.SaveClaimDetails(false);


            return true;
        }

        private bool LoadFile()
        {
           sm.LoadClaimDetails();

            return true;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            
            AddScopeModelToCollection();
            if (SaveFile())
                LoadFile();
            InIt();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ScopeList.Count - 1 > 0)
            {
              //  AddScopeModelToCollection();
              //  Calculations.C1.Add(Calculations.C.Calculate(ScopeList[ScopeList.Count - 1]));
               // listBox.Items.Add(new CompoundDataGridRow(-1,Calculations.C.Calculate(AddScopeModelToCollection())));
            }
        }

        public void AddScopeModelToCollection(ScopeModel s = null)
        {
            double Draw = 0;
            if ((bool)takesFirstCheckBox.IsChecked == true)
                Draw = 500;
            ScopeModel nsm = new ScopeModel();

            if (s != null)
                nsm = s;
            
            nsm.ACV = (double)aCVTextBox.Value;
            nsm.RCV = (double)rCVTextBox.Value;
            nsm.NoSquares = (int)noSquaresTextBox.Value;
            nsm.Branch = BranchCombo.SelectedValue.ToString();
            nsm.ClaimNumber = claimNumberTextBox.Text;
            nsm.Deductible = (double)deductibleTextBox.Value;
            nsm.Tax = (double)TaxTextBox.Value;
            nsm.LastRemainingBalance = 0;
            nsm.IsEstimate = (bool)isEstimateCheckBox.IsChecked.Value;
            nsm.IsHouseDeal = (bool)isHouseDealCheckBox.IsChecked.Value;
            nsm.HasOW = (bool)HasOW.IsChecked.Value;
            nsm.IsReferral = (bool)isReferralCheckBox.IsChecked.Value;
            nsm.RoofAmount = (double)roofAmountTextBox.Value;
            if (SalespersonCombo.SelectedValue.ToString() == "Preston")
                nsm.SalesSplit = 60;
            else nsm.SalesSplit = 50;
          //  nsm.SalesSplit = (double)salesSplitTextBox.PercentValue;
            nsm.ScopeDate = scopeDateDatePicker.SelectedDate.Value;
            nsm.Draw = Draw;
            nsm.Salesperson = SalespersonCombo.SelectedValue.ToString();
            nsm.CustomerName = CustomerName.Text;
            nsm.IsSupervised = IsSupervised.IsChecked.Value;
            ScopeList.Add(nsm);
            SaveFile();

            //C1.Add();
           // listBox.Items.Add(new CompoundDataGridRow(ScopeList.Count - 1));


//            Calculations.C1.Add(Calculations.C.Calculate(nsm));
           // listBox.Items.Add(new CompoundDataGridRow((Calculations.C.Calculate(nsm))));
          //  return nsm;
        }

     
        private void UpdateClaimButton(object sender, RoutedEventArgs e)
        {
            needsUpdate = true;
            bottomgrid.Visibility = Visibility.Collapsed;
            UpdateItemGrid.Visibility = Visibility.Visible;
            listBox.Visibility = Visibility.Collapsed;



        }

        private void ShowListView(object sender, RoutedEventArgs e)
        {
            if (needsUpdate)
                if(SaveFile())
                    LoadFile();
            bottomgrid.Visibility = Visibility.Collapsed;
            UpdateItemGrid.Visibility = Visibility.Collapsed;
            listBox.Visibility = Visibility.Visible;
            needsUpdate = false;
        }

        private void NewTracking(object sender, RoutedEventArgs e)
        {
            bottomgrid.Visibility = Visibility.Visible;
            UpdateItemGrid.Visibility = Visibility.Collapsed;
            listBox.Visibility = Visibility.Collapsed;
        }

        private void Add_ClickGGG(object sender, RoutedEventArgs e)
        {
            needsUpdate = true;
            AddScopeModelToCollection();
        }

        private void ButtonAdv_Click(object sender, RoutedEventArgs e)
        {
       //    this.NavigationService.Navigate(new ShowList());
        }

        private void CanelClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Claims_Receivables());
        }
        private void InIt()
        {

            
            if (LoadFile())
            {
                if (listBox.HasItems)
                {
                    listBox.Items.Clear();
                }
                int i = 0;
                if (ScopeList.Count > 0)
                    foreach (var s in ScopeList)
                    {
                        
                        // Calculations.C1.Add(Calculations.C.Calculate(s));
                    //    listBox.Items.Add(new CompoundDataGridRow(i));
                        
                        i++;
                    }
                sm.GetTotals();
                TotalMaterial.Value = (decimal)sm.FirstOutstanding + (decimal)sm.DeductibleOutstanding + (decimal)sm.DepreciationOutstanding;
                grandTotalToCollected.Value = (decimal)sm.FirstOutstanding;
                currencyTextBox1.Value = (decimal)sm.DepreciationOutstanding;
                currencyTextBox2.Value = (decimal)sm.DeductibleOutstanding;
                integerTextBox.Value = ScopeList.Count;
                bottomgrid.Visibility = Visibility.Collapsed;
                listBox.Visibility = Visibility.Visible;
                UpdateItemGrid.Visibility = Visibility.Collapsed;
                aCVTextBox.Value = 0;
                rCVTextBox.Value = 0;
                noSquaresTextBox.Value = 0;
                BranchCombo.SelectedIndex = -1;
                claimNumberTextBox.Text = string.Empty;
                deductibleTextBox.Value = 1000;
                TaxTextBox.Value = 0;
                isEstimateCheckBox.IsChecked = false;
                isHouseDealCheckBox.IsChecked = false;
                HasOW.IsChecked = false;
                isReferralCheckBox.IsChecked = true;
                roofAmountTextBox.Value = 0;
                scopeDateDatePicker.SelectedDate = DateTime.Today;
                SalespersonCombo.SelectedIndex = -1;
                CustomerName.Text = string.Empty;
                IsSupervised.IsChecked = true;
            }

           

            else bottomgrid.Visibility = Visibility.Visible;
        }

        private void BranchCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (BranchCombo.SelectedIndex == 1)
                IsSupervised.IsChecked = false;
            else IsSupervised.IsChecked = true;
            //   sm.RAW.Clear();
         

        }

        private void RemoveFromList(object sender, RoutedEventArgs e)
        {
            ScopeList.RemoveAt(listBox.Items.IndexOf(listBox.SelectedItem));
            listBox.Items.RemoveAt(this.listbox);
          
            SaveFile();
        }

        private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            listbox = listBox.SelectedIndex;
        }

        private void PrintList(object sender, RoutedEventArgs e)
        {
            PeekABoo();
            PeekABoo1();
        }

        private void PeekABoo(bool bVisible = false)
        {
            if (!bVisible)
            {

               // CDR.scopeModelListView.Visibility = Visibility.Visible;
               
            }
            else
            {

            //    CDR.scopeModelListView.Visibility = Visibility.Hidden;
            }
        }
        private void PeekABoo1(bool bVisible = false)
        {
            if (!bVisible)
            {
                
                //.Visibility = Visibility.Visible;
            //    Print();
            }
            else
            {
          //      CDGR.scopeModelListView.Visibility = Visibility.Hidden;
               // CDR.scopeModelListView.Visibility = Visibility.Hidden;
            }
        }

      

        private void ViewList(object sender, RoutedEventArgs e)
        {
         //   NavigationService.Navigate(new MonthOutlookGridview());
        }

        private void listBox_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
         //   NavigationService.Navigate(new NexusHome());
        }
    }
}


//namespace MRNUIElements.Interface.Command
//{

    
//    public class Command : ICommand
//    {
//        public ViewModelBase SaveCommand { get; set; }


//        public event EventHandler CanExecuteChanged;

//        public bool CanExecute(object parameter)
//        {
//            return true;
//        }

//        public void Execute(object parameter)
//        {
            
//        }

       
//    }
   
























//}
/* DateTime dt = new DateTime(DateTime.Today.Ticks);
            double dm = new DateTime(2016, 8, 1).Subtract(dt).TotalDays;*/
