#region Using

using MRNNexus_Model;

//using Awesomium.Core;
//using Awesomium.Windows.Controls;

using MRNUIElements.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        static public bool DoneLoading;
        public static ServiceLayer s1 = ServiceLayer.getInstance();
        static public string Status = "Loading...!!!";
        private static MainWindow mw;
        private static NavigationService ns;
        // public static Syncfusion.Windows.Controls.Notification.SfBusyIndicator busyindicator {
        // get; set; }
        private BackgroundWorker myWorker = new BackgroundWorker();

        public MainWindow()
        {
            myWorker.DoWork += new DoWorkEventHandler(myWorker_DoWork);
            myWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorker_RunWorkerCompleted);
            myWorker.ProgressChanged += new ProgressChangedEventHandler(myWorker_ProgressChanged);
            myWorker.WorkerReportsProgress = true;
            myWorker.WorkerSupportsCancellation = true;
            preprocessing(myWorker);

            InitializeComponent();

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

        protected async void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int j = 0;
            myWorker.ReportProgress(j++);

            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AdjustmentResult>), "GetAdjustmentResults");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AppointmentTypes>), "GetAppointmentTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ClaimDocumentType>), "GetClaimDocumentTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ClaimStatusTypes>), "GetClaimStatusTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_DamageTypes>), "GetDamageTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_EmployeeType>), "GetEmployeeTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Invoice>), "GetAllInvoices");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_InvoiceType>), "GetInvoiceTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_KnockResponseType>), "GetKnockResponseTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_LeadType>), "GetLeadTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PayFrequncy>), "GetPayFrequencies");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PaymentDescription>), "GetPayDescriptions");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PaymentType>), "GetPaymentTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PayType>), "GetPayTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_Permissions>), "GetPermissions");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PlaneTypes>), "GetPlaneTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ProductType>), "GetProductTypes");
            // mw.Text = "Building Ridge Material Types Lookup Table";
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_RidgeMaterialType>), "GetRidgeMaterialTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ScopeType>), "GetScopeTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ServiceTypes>), "GetServiceTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ShingleType>), "GetShingleTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_UnitOfMeasure>), "GetUnitsOfMeasure");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_VendorTypes>), "GetVendorTypes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_InsuranceCompany>), "GetAllInsuranceCompanies");
            // //Non LU
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Inspection>), "GetAllInspections");
            //	await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetOpenClaimsBySalespersonID");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Vendor>), "GetAllVendors");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_ClaimDocument>), "GetAllClaimDocuments");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Payment>), "GetAllPayments");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Employee>), "GetAllEmployees");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_ClaimContacts>), "GetAllClaimContacts");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Address>), "GetAllAddresses");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Customer>), "GetAllCustomers");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_EmployeeDetail>), "GetAllEmployeeDetail");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_Product>), "GetAllProducts");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Scope>), "GetAllScopes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_ClaimStatus>), "GetAllClaimStatuses");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Lead>), "GetAllLeads");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Plane>), "GetAllPlanes");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_User>), "GetAllUsers");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_AdditionalSupply>), "GetAllAdditionalSupplies");
            myWorker.ReportProgress(j++);

            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_SurplusSupplies>), "GetAllSurplusSupplies");
            myWorker.ReportProgress(j++);

            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Referrer>), "GetAllReferrers");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Damage>), "GetAllDamages");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllClaimsToSchedule");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllClaims");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_CallLog>), "GetAllCallLogs");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Adjustment>), "GetAllAdjustments");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Adjuster>), "GetAllAdjusters");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AdjustmentResult>), "GetAdjustmentResults");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_NewRoof>), "GetAllNewRoofs");
            myWorker.ReportProgress(j++);
            await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_KnockerResponse>), "GetAllKnockerResponses");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllInactiveClaims");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllClosedClaims");
            if (s1.OpenClaimsList == null)
                s1.OpenClaimsList = s1.getOpenClaims();
            if (s1.ClosedClaimsList == null)
                s1.ClosedClaimsList = s1.getClosedClaims();
            if (s1.InactiveClaimsList == null)
                s1.InactiveClaimsList = s1.getInactiveClaims();
            DoneLoading = await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Vendor>), "GetAllVendors");
        }

        protected void myWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            switch (e.ProgressPercentage)
            {
                case 0:{ VerboseStatusDisplay.Items.Add("GetAdjustmentResults"); break;}

            case 1:{ VerboseStatusDisplay.Items.Add("GetAppointmentTypes"); break;}

            case 2:{ VerboseStatusDisplay.Items.Add("GetClaimDocumentTypes"); break;}

            case 3:{ VerboseStatusDisplay.Items.Add("GetClaimStatusTypes"); break;}

            case 4:{ VerboseStatusDisplay.Items.Add("GetDamageTypes"); break;}

            case 5:{ VerboseStatusDisplay.Items.Add("GetEmployeeTypes"); break;}

            case 6:{ VerboseStatusDisplay.Items.Add("GetAllInvoices"); break;}

            case 7:{ VerboseStatusDisplay.Items.Add("GetInvoiceTypes"); break;}

            case 8:{ VerboseStatusDisplay.Items.Add("GetKnockResponseTypes"); break;}

            case 9:{ VerboseStatusDisplay.Items.Add("GetLeadTypes"); break;}

            case 10:{ VerboseStatusDisplay.Items.Add("GetPayFrequencies"); break;}

            case 11:{ VerboseStatusDisplay.Items.Add("GetPayDescriptions"); break;}

            case 12:{ VerboseStatusDisplay.Items.Add("GetPaymentTypes"); break;}

            case 13:{ VerboseStatusDisplay.Items.Add("GetPayTypes"); break;}

            case 14:{ VerboseStatusDisplay.Items.Add("GetPermissions"); break;}

            case 15:{ VerboseStatusDisplay.Items.Add("GetPlaneTypes"); break;}

            case 16:{ VerboseStatusDisplay.Items.Add("GetProductTypes"); break;}

            case 17:{ VerboseStatusDisplay.Items.Add("GetRidgeMaterialTypes"); break;}

            case 18:{ VerboseStatusDisplay.Items.Add("GetScopeTypes"); break;}

            case 19:{ VerboseStatusDisplay.Items.Add("GetServiceTypes"); break;}

            case 20:{ VerboseStatusDisplay.Items.Add("GetShingleTypes"); break;}

            case 21:{ VerboseStatusDisplay.Items.Add("GetUnitsOfMeasure"); break;}

            case 22:{ VerboseStatusDisplay.Items.Add("GetVendorTypes"); break;}

            case 23:{ VerboseStatusDisplay.Items.Add("GetAllInsuranceCompanies"); break;}

            case 24:{ VerboseStatusDisplay.Items.Add("GetAllInspections"); break;}

            case 25:{ VerboseStatusDisplay.Items.Add("GetAllClaimDocuments"); break;}

            case 26:{ VerboseStatusDisplay.Items.Add("GetAllPayments"); break;}

            case 27:{ VerboseStatusDisplay.Items.Add("GetAllEmployees"); break;}

            case 28:{ VerboseStatusDisplay.Items.Add("GetAllClaimContacts"); break;}

            case 29:{ VerboseStatusDisplay.Items.Add("GetAllAddresses"); break;}

            case 30:{ VerboseStatusDisplay.Items.Add("GetAllCustomers"); break;}

            case 31:{ VerboseStatusDisplay.Items.Add("GetAllProducts"); break;}

            case 32:{ VerboseStatusDisplay.Items.Add("GetAllScopes"); break;}

            case 33:{ VerboseStatusDisplay.Items.Add("GetAllClaimStatuses"); break;}

            case 34:{ VerboseStatusDisplay.Items.Add("GetAllLeads"); break;}

            case 35:{ VerboseStatusDisplay.Items.Add("GetAllPlanes"); break;}

            case 36:{ VerboseStatusDisplay.Items.Add("GetAllUsers"); break;}

            case 37:{ VerboseStatusDisplay.Items.Add("GetAllAdditionalSupplies"); break;}

            case 38:{ VerboseStatusDisplay.Items.Add("GetAllSurplusSupplies"); break;}

            case 39:{ VerboseStatusDisplay.Items.Add("GetAllReferrers"); break;}

            case 40:{ VerboseStatusDisplay.Items.Add("GetAllDamages"); break;}

            case 41:{ VerboseStatusDisplay.Items.Add("GetAllClaims"); break;}

            case 42:{ VerboseStatusDisplay.Items.Add("GetAllCallLogs"); break;}

            case 43:{ VerboseStatusDisplay.Items.Add("GetAllAdjustments"); break;}

            case 44:{ VerboseStatusDisplay.Items.Add("GetAllAdjusters"); break;}

            case 45:{ VerboseStatusDisplay.Items.Add("GetAllNewRoofs"); break;}

            case 46:{ VerboseStatusDisplay.Items.Add("GetAllKnockerResponses"); break;}

            default:
                    break;
            }
        }

        protected void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
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

        async private void preprocessing(BackgroundWorker myWorker)
        {
            //  await s1.buildLUs();
            myWorker.RunWorkerAsync();
            bool DoneLoading = false;

            while (!DoneLoading)
            {
                //if (s1.VendorsList != null)
                //{
                //	await Task.Run(async()=> await Task.Delay(500));
                //	doneLoading = true;
                DoneLoading = ServiceLayer.DoneLoading;
                // busyIndicator.IsBusy = true;

                // moved to login.xaml.cs menuBar.IsEnabled = true;
                //	if (s1.InvoicesList != null)
                //	System.Windows.Forms.MessageBox.Show("Invoices Loaded");
                //	if (s1.VendorsList != null)
                //		System.Windows.Forms.MessageBox.Show("Vendors Loaded");
                //}
            }
            busyIndicator.IsBusy = false;
            VerboseStatusDisplay.Visibility = Visibility.Collapsed;
            Login loginpage = new Login();

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
    }
}