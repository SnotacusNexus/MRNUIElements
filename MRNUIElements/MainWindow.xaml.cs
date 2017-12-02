#region Using

using MRNNexus_Model;

//using Awesomium.Core;
//using Awesomium.Windows.Controls;

using MRNUIElements.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

#endregion Using

namespace MRNUIElements

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Syncfusion.Windows.Controls.Notification.SfBusyIndicator _busyindicator;
        public bool DoneLoading;
        public static ServiceLayer s1 = ServiceLayer.getInstance();
        static public string Status = "Loading...!!!";
        private static MainWindow mw;
        private static NavigationService ns;
        // public static Syncfusion.Windows.Controls.Notification.SfBusyIndicator busyindicator {
        // get; set; }
        private BackgroundWorker myWorker = new BackgroundWorker();

        public MainWindow()
        {  InitializeComponent();
            myWorker.DoWork += new DoWorkEventHandler(myWorker_DoWork);
            myWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorker_RunWorkerCompleted);
            myWorker.ProgressChanged += new ProgressChangedEventHandler(myWorker_ProgressChanged);
            myWorker.WorkerReportsProgress = true;
            myWorker.WorkerSupportsCancellation = true;
          

          
            
            preprocessing();
            //Binding exitBinding = new Binding();
            //exitBinding.Path = new PropertyPath("Exit");
            //exitBinding.Mode = BindingMode.TwoWay;
            //SetBinding(ExitProperty, exitBinding);
            //Binding ZoomInBinding = new Binding();
            //ZoomInBinding.Path = new PropertyPath("ZoomIn");
            //SetBinding(ZoomInProperty, ZoomInBinding);
            //Binding ZoomOutBinding = new Binding();
            //ZoomOutBinding.Path = new PropertyPath("ZoomOut");
            //SetBinding(ZoomOutProperty, ZoomOutBinding);
            //Exit = new Command(OnExitCommand);
            //ZoomIn = new Command(OnZoomInCommand);
            //ZoomOut = new Command(OnZoomOutCommand);
            _busyindicator = getBusyIndicator();
            Application.Current.Properties["NavigationService"] = this.MRNClaimNexusMainFrame.NavigationService;
            // WebCore.Initialize(new WebConfig() { UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64)
            // AppleWebKit/537.11 (KHTML, like Gecko) Chrome/50.0.2661.102 m Safari/537.11" });//23.0.1271.97
            ns = this.MRNClaimNexusMainFrame.NavigationService;
            while (myWorker.IsBusy)
                if (!myWorker.IsBusy)
                    busyIndicator.Visibility = Visibility.Hidden;
        }
    
       

          
        static public DTO_Claim Claim
        {
            get
            {
                return claim;
            }
            set { }
        }

        private static DTO_Claim claim { get; set; }
        static public void GetBusy(bool busy = true)
        {
            if (busy)
            {
                if (!_busyindicator.IsVisible)
                    _busyindicator.Visibility = Visibility.Visible;
                _busyindicator.IsBusy = true;
            }
            else
            {
                if (_busyindicator.IsVisible)
                    _busyindicator.Visibility = Visibility.Collapsed;
                _busyindicator.IsBusy = false;
            }
        }

        public static Syncfusion.Windows.Controls.Notification.SfBusyIndicator getBusyIndicator()
        {
            if (_busyindicator == null)
                _busyindicator = new Syncfusion.Windows.Controls.Notification.SfBusyIndicator();
            return _busyindicator;
        }

        static public MainWindow getMainWindowInstance()
        {
            if (mw == null)
                mw = new MainWindow();

            return mw;
        }

        public static NavigationService getNavigationService()
        {
            return ns;
        }

        public bool UpdateStatusBarText(string textToDisplay)
        {
            VerboseStatusDisplay.Items.Add(textToDisplay);

            return true;
        }

        protected void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var a = Task.Run(async () => !await s1.buildLUs(this, myWorker));
            while (!DoneLoading)
                Thread.Yield();

            this.DataContext = this;
            //    int j = 0;
            //    myWorker.ReportProgress(j++);
            // Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AdjustmentResult>), "GetAdjustmentResults"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AppointmentTypes>), "GetAppointmentTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ClaimDocumentType>), "GetClaimDocumentTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ClaimStatusTypes>), "GetClaimStatusTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_DamageTypes>), "GetDamageTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_EmployeeType>), "GetEmployeeTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Invoice>), "GetAllInvoices"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_InvoiceType>), "GetInvoiceTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_KnockResponseType>), "GetKnockResponseTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_LeadType>), "GetLeadTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PayFrequncy>), "GetPayFrequencies"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PaymentDescription>), "GetPayDescriptions"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PaymentType>), "GetPaymentTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PayType>), "GetPayTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_Permissions>), "GetPermissions"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PlaneTypes>), "GetPlaneTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ProductType>), "GetProductTypes"));
            //    // mw.Text = "Building Ridge Material Types Lookup Table";
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_RidgeMaterialType>), "GetRidgeMaterialTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ScopeType>), "GetScopeTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ServiceTypes>), "GetServiceTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ShingleType>), "GetShingleTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_UnitOfMeasure>), "GetUnitsOfMeasure"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_VendorTypes>), "GetVendorTypes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_InsuranceCompany>), "GetAllInsuranceCompanies"));
            //    // //Non LU
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Inspection>), "GetAllInspections"));
            //    //	 Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetOpenClaimsBySalespersonID"));
            //    // Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Vendor>), "GetAllVendors"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_ClaimDocument>), "GetAllClaimDocuments"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Payment>), "GetAllPayments"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Employee>), "GetAllEmployees"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_ClaimContacts>), "GetAllClaimContacts"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Address>), "GetAllAddresses"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Customer>), "GetAllCustomers"));
            //    // Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_EmployeeDetail>), "GetAllEmployeeDetail"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_Product>), "GetAllProducts"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Scope>), "GetAllScopes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_ClaimStatus>), "GetAllClaimStatuses"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Lead>), "GetAllLeads"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Plane>), "GetAllPlanes"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_User>), "GetAllUsers"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_AdditionalSupply>), "GetAllAdditionalSupplies"));
            //    myWorker.ReportProgress(j++);

            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_SurplusSupplies>), "GetAllSurplusSupplies"));
            //    myWorker.ReportProgress(j++);

            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Referrer>), "GetAllReferrers"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Damage>), "GetAllDamages"));
            //    // Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllClaimsToSchedule"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllClaims"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_CallLog>), "GetAllCallLogs"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Adjustment>), "GetAllAdjustments"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Adjuster>), "GetAllAdjusters"));
            //    // Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AdjustmentResult>), "GetAdjustmentResults"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_NewRoof>), "GetAllNewRoofs"));
            //    myWorker.ReportProgress(j++);
            //     Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_KnockerResponse>), "GetAllKnockerResponses"));
            //    // Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllInactiveClaims"));
            //    // Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllClosedClaims"));
            //    //if (s1.OpenClaimsList == null)
            //    //    s1.OpenClaimsList = s1.getOpenClaims();
            //    //if (s1.ClosedClaimsList == null)
            //    //    s1.ClosedClaimsList = s1.getClosedClaims();
            //    //if (s1.InactiveClaimsList == null)
            //    //    s1.InactiveClaimsList = s1.getInactiveClaims();
            //Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Vendor>), "GetAllVendors"));
        }

        protected void myWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            switch (e.ProgressPercentage)
            {
                case 0:{setStatusText("GetAdjustmentResults"); break;}

            case 1:{setStatusText("GetAppointmentTypes"); break;}

            case 2:{setStatusText("GetClaimDocumentTypes"); break;}

            case 3:{setStatusText("GetClaimStatusTypes"); break;}

            case 4:{setStatusText("GetDamageTypes"); break;}

            case 5:{setStatusText("GetEmployeeTypes"); break;}

            case 6:{setStatusText("GetAllInvoices"); break;}

            case 7:{setStatusText("GetInvoiceTypes"); break;}

            case 8:{setStatusText("GetKnockResponseTypes"); break;}

            case 9:{setStatusText("GetLeadTypes"); break;}

            case 10:{setStatusText("GetPayFrequencies"); break;}

            case 11:{setStatusText("GetPayDescriptions"); break;}

            case 12:{setStatusText("GetPaymentTypes"); break;}

            case 13:{setStatusText("GetPayTypes"); break;}

            case 14:{setStatusText("GetPermissions"); break;}

            case 15:{setStatusText("GetPlaneTypes"); break;}

            case 16:{setStatusText("GetProductTypes"); break;}

            case 17:{setStatusText("GetRidgeMaterialTypes"); break;}

            case 18:{setStatusText("GetScopeTypes"); break;}

            case 19:{setStatusText("GetServiceTypes"); break;}

            case 20:{setStatusText("GetShingleTypes"); break;}

            case 21:{setStatusText("GetUnitsOfMeasure"); break;}

            case 22:{setStatusText("GetVendorTypes"); break;}

            case 23:{setStatusText("GetAllInsuranceCompanies"); break;}

            case 24:{setStatusText("GetAllInspections"); break;}

            case 25:{setStatusText("GetAllClaimDocuments"); break;}

            case 26:{setStatusText("GetAllPayments"); break;}

            case 27:{setStatusText("GetAllEmployees"); break;}

            case 28:{setStatusText("GetAllClaimContacts"); break;}

            case 29:{setStatusText("GetAllAddresses"); break;}

            case 30:{setStatusText("GetAllCustomers"); break;}

            case 31:{setStatusText("GetAllProducts"); break;}

            case 32:{setStatusText("GetAllScopes"); break;}

            case 33:{setStatusText("GetAllClaimStatuses"); break;}

            case 34:{setStatusText("GetAllLeads"); break;}

            case 35:{setStatusText("GetAllPlanes"); break;}

            case 36:{setStatusText("GetAllUsers"); break;}

            case 37:{setStatusText("GetAllAdditionalSupplies"); break;}

            case 38:{setStatusText("GetAllSurplusSupplies"); break;}

            case 39:{setStatusText("GetAllReferrers"); break;}

            case 40:{setStatusText("GetAllDamages"); break;}

            case 41:{setStatusText("GetAllClaims"); break;}

            case 42:{setStatusText("GetAllCallLogs"); break;}

            case 43:{setStatusText("GetAllAdjustments"); break;}

            case 44:{setStatusText("GetAllAdjusters"); break;}

            case 45:{setStatusText("GetAllNewRoofs"); break;}

            case 46:{setStatusText("GetAllKnockerResponses"); break;}

            default:
                    break;
            }

          
        }


        void setStatusText(string s)
        {
            setDisplayStatus.Text = s;
        }

        protected void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DoneLoading = true;
        }
        private void Add_Inspection_Click(object sender, RoutedEventArgs e)
        {
            var f = new Form1();
            f.ShowDialog();

            //ns.Navigate(new Form1());
        }

        private void Add_Inspection_Photos_Click(object sender, RoutedEventArgs e)
        {
            var f2 = new Form2();
            f2.ShowDialog();
        }

        private void Add_Invoice_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Add_Payment_Click(object sender, RoutedEventArgs e)
        {
            var cp = new PaymentForm();
            cp.ShowDialog();
        }

        private void AddCycle_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Adjustment_Click(object sender, RoutedEventArgs e)
        {
        }

        private void calendar_Click(object sender, RoutedEventArgs e)
        {
            // Schedule inspectionspage = new Schedule(); this.MRNClaimNexusMainFrame.NavigationService.Navigate(inspectionspage);
        }

        async private void Claim_Click(object sender, RoutedEventArgs e)
        {
            ns.Navigate(new AddPropertyAddress());
        }

        private void Contests_Click(object sender, RoutedEventArgs e)
        {
            ns.Navigate(new Controllers.WebBrowser());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Generate_Supplement_Click(object sender, RoutedEventArgs e)
        {
        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            ns.Navigate(new LoginAs());
            //CustomerAgreement inspectionspage = new CustomerAgreement();
            //this.MRNClaimNexusMainFrame.NavigationService.Navigate(inspectionspage);
        }

        private void Inspections_Click(object sender, RoutedEventArgs e)
        {
            //CustomerAgreement inspectionspage = new CustomerAgreement();
            //this.MRNClaimNexusMainFrame.NavigationService.Navigate(inspectionspage);
        }

        private void Material_Adjustment_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ModifyClaim_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CPD = new ClaimPickerPopUp();
                if ((bool)CPD.ShowDialog())

                    // var claim = s1.ClaimsList.Single(x => x.ClaimID == 37);
                    ns.Navigate(new Controllers.ClaimView(CPD.Claim));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void NextCycle_Click(object sender, RoutedEventArgs e)
        {
        }

        private void preprocessing()
        {
            //  await s1.buildLUs();
          
           DoneLoading = false;

         //   while (!DoneLoading)
            {
                //if (s1.VendorsList != null)
                //{
                //	await Task.Run(async()=> await Task.Delay(500));
                //	doneLoading = true;
              //  DoneLoading = ServiceLayer.DoneLoading;
                // busyIndicator.IsBusy = true;

                // moved to login.xaml.cs menuBar.IsEnabled = true;
                //	if (s1.InvoicesList != null)
                //	System.Windows.Forms.MessageBox.Show("Invoices Loaded");
                //	if (s1.VendorsList != null)
                //		System.Windows.Forms.MessageBox.Show("Vendors Loaded");
                //}
            }
            busyIndicator.IsBusy = false;
            
            Login loginpage = new Login();
VerboseStatusDisplay.Visibility = Visibility.Collapsed;
            this.MRNClaimNexusMainFrame.NavigationService.Navigate(loginpage);
        }
        private void RemoveClaim_Click(object sender, RoutedEventArgs e)
        {
        }
        private void ScheduleRoof_Click(object sender, RoutedEventArgs e)
        {
            ns.Navigate(new RoofMeasurmentsPage());
        }

        private void Settle_Claim_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ThisCycle_Click(object sender, RoutedEventArgs e)
        {
        }
        private void View_Console_Click(object sender, RoutedEventArgs e)
        {
        }
        private void View_Order_Console_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MRNClaimNexusMainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(async () =>
            {
                await s1.GetAllClaims();
                await s1.GetAllCustomers();
                await s1.GetAllReferrers();
                await s1.GetAllInsuranceCompanies();
                await s1.GetLeadTypes();
                await s1.GetAllLeads();
                await s1.GetAllClaimStatuses();
                await s1.GetAllEmployees();
                await s1.GetAllAddresses();
                await s1.GetAllClaimContacts();
                await s1.GetLeadTypes();
                await s1.GetAllCustomers();
                await s1.GetAllScopes();
                await s1.GetAllCallLogs();
                await s1.GetAllCalendarData();
                await s1.GetAllInvoices();
                await s1.GetAllPayments();
                await s1.GetAllPlanes();
                await s1.GetAdjustmentResults();
                await s1.GetAllAdjustments();
                await s1.GetAllAdjusters();
                await s1.GetAllInspections();
                await s1.GetAllNewRoofs();
                await s1.GetAllOrders();
                await s1.GetAllOrderItems();

                System.Windows.Forms.MessageBox.Show("Loaded");
            });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ((MainWindow)sender).busyIndicator.Visibility = Visibility.Visible;

            myWorker.RunWorkerAsync();
          
            
        }
    }
}