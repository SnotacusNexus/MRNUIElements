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

using MRNNexus.WPFClient.Controllers;
using MRNNexusDTOs;
using System.ComponentModel;
using System.Threading;

namespace MRNNexus.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MainWindow mw;
        ServiceLayer s1 = ServiceLayer.getInstance();
        const int MONTH = 0;
        const int WEEK = 1;
        const int DAY = 2;
        static DTO_Employee LoggedInEmployee;
        public static Syncfusion.Windows.Controls.Notification.SfBusyIndicator _busyindicator;
        public bool DoneLoading;
  
        static public string Status = "Loading...!!!";
     
        private static NavigationService ns;
        // public static Syncfusion.Windows.Controls.Notification.SfBusyIndicator busyindicator {
        // get; set; }
        private BackgroundWorker myWorker = new BackgroundWorker();
        static public DTO_Employee getLoggedInEmployee()
        {
            if (LoggedInEmployee == null)
                LoggedInEmployee = new DTO_Employee();
            return LoggedInEmployee;

        }
        public MainWindow()
        {
            myWorker.DoWork += new DoWorkEventHandler(myWorker_DoWork);
            myWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorker_RunWorkerCompleted);
            myWorker.ProgressChanged += new ProgressChangedEventHandler(myWorker_ProgressChanged);
            myWorker.WorkerReportsProgress = true;
            myWorker.WorkerSupportsCancellation = true;




            preprocessing();
            InitializeComponent();
            _busyindicator = getBusyIndicator();
            Application.Current.Properties["NavigationService"] = this.MRNNexusMainFrame.NavigationService;
            // WebCore.Initialize(new WebConfig() { UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64)
            // AppleWebKit/537.11 (KHTML, like Gecko) Chrome/50.0.2661.102 m Safari/537.11" });//23.0.1271.97
            ns = this.MRNNexusMainFrame.NavigationService;
            while (myWorker.IsBusy)
                if (!myWorker.IsBusy)
                    busyIndicator.Visibility = Visibility.Hidden;
           
            
        }
        private void MRNClaimNexusMainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            //    menuBar.IsEnabled = false;
            //  busyIndicator.IsBusy = true;
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

            });

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ((MainWindow)sender).busyIndicator.Visibility = Visibility.Visible;

            myWorker.RunWorkerAsync();
            menuBar.IsEnabled = true;
            busyIndicator.IsBusy = false;
            ((MainWindow)sender).busyIndicator.Visibility = Visibility.Hidden;
        }
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

            //switch (e.ProgressPercentage)
            //{
            //    case 0: { setStatusText("GetAdjustmentResults"); break; }

            //    case 1: { setStatusText("GetAppointmentTypes"); break; }

            //    case 2: { setStatusText("GetClaimDocumentTypes"); break; }

            //    case 3: { setStatusText("GetClaimStatusTypes"); break; }

            //    case 4: { setStatusText("GetDamageTypes"); break; }

            //    case 5: { setStatusText("GetEmployeeTypes"); break; }

            //    case 6: { setStatusText("GetAllInvoices"); break; }

            //    case 7: { setStatusText("GetInvoiceTypes"); break; }

            //    case 8: { setStatusText("GetKnockResponseTypes"); break; }

            //    case 9: { setStatusText("GetLeadTypes"); break; }

            //    case 10: { setStatusText("GetPayFrequencies"); break; }

            //    case 11: { setStatusText("GetPayDescriptions"); break; }

            //    case 12: { setStatusText("GetPaymentTypes"); break; }

            //    case 13: { setStatusText("GetPayTypes"); break; }

            //    case 14: { setStatusText("GetPermissions"); break; }

            //    case 15: { setStatusText("GetPlaneTypes"); break; }

            //    case 16: { setStatusText("GetProductTypes"); break; }

            //    case 17: { setStatusText("GetRidgeMaterialTypes"); break; }

            //    case 18: { setStatusText("GetScopeTypes"); break; }

            //    case 19: { setStatusText("GetServiceTypes"); break; }

            //    case 20: { setStatusText("GetShingleTypes"); break; }

            //    case 21: { setStatusText("GetUnitsOfMeasure"); break; }

            //    case 22: { setStatusText("GetVendorTypes"); break; }

            //    case 23: { setStatusText("GetAllInsuranceCompanies"); break; }

            //    case 24: { setStatusText("GetAllInspections"); break; }

            //    case 25: { setStatusText("GetAllClaimDocuments"); break; }

            //    case 26: { setStatusText("GetAllPayments"); break; }

            //    case 27: { setStatusText("GetAllEmployees"); break; }

            //    case 28: { setStatusText("GetAllClaimContacts"); break; }

            //    case 29: { setStatusText("GetAllAddresses"); break; }

            //    case 30: { setStatusText("GetAllCustomers"); break; }

            //    case 31: { setStatusText("GetAllProducts"); break; }

            //    case 32: { setStatusText("GetAllScopes"); break; }

            //    case 33: { setStatusText("GetAllClaimStatuses"); break; }

            //    case 34: { setStatusText("GetAllLeads"); break; }

            //    case 35: { setStatusText("GetAllPlanes"); break; }

            //    case 36: { setStatusText("GetAllUsers"); break; }

            //    case 37: { setStatusText("GetAllAdditionalSupplies"); break; }

            //    case 38: { setStatusText("GetAllSurplusSupplies"); break; }

            //    case 39: { setStatusText("GetAllReferrers"); break; }

            //    case 40: { setStatusText("GetAllDamages"); break; }

            //    case 41: { setStatusText("GetAllClaims"); break; }

            //    case 42: { setStatusText("GetAllCallLogs"); break; }

            //    case 43: { setStatusText("GetAllAdjustments"); break; }

            //    case 44: { setStatusText("GetAllAdjusters"); break; }

            //    case 45: { setStatusText("GetAllNewRoofs"); break; }

            //    case 46: { setStatusText("GetAllKnockerResponses"); break; }

            //    default:
            //        break;
            //}


        }


        void setStatusText(string s)
        {
        //   setDisplayStatus.Text = s;
        }

        protected void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DoneLoading = true;
        }
        public static Syncfusion.Windows.Controls.Notification.SfBusyIndicator getBusyIndicator()
        {
            if (_busyindicator == null)
                _busyindicator = new Syncfusion.Windows.Controls.Notification.SfBusyIndicator();
            return _busyindicator;
        }

        static public MainWindow getMainWindowInstance(DTO_Employee employee = null)
        {
            if (mw == null)
                mw = new MainWindow();
            if (employee != null)
                LoggedInEmployee = employee;


            return mw;
        }
        //void setStatusText(string s)
        //{
        //    setDisplayStatus.Text = s;
        //}
        async private void preprocessing()
        {
          
           // await s1.buildLUs();

            bool doneLoading = false;

            while (!doneLoading)
            {
                if(s1.VendorTypes != null)
                {
                    doneLoading = true;
                    busyIndicator.IsBusy = false;
                    // moved to login.xaml.cs menuBar.IsEnabled = true;

                    Login loginpage = new Login();
                    this.MRNNexusMainFrame.NavigationService.Navigate(loginpage);
                }
            }
        }

        private void Inspections_Click(object sender, RoutedEventArgs e)
        {
            NewInspection inspectionspage = new NewInspection();
            this.MRNNexusMainFrame.NavigationService.Navigate(inspectionspage);
        }

        private void calendar_Click(object sender, RoutedEventArgs e)
        {

            ///TODO add code for who is logged in and the view structure the seek
           
            this.MRNNexusMainFrame.NavigationService.Navigate(new Schedule(null,MONTH));
        }

        private void add_Claim_Click(object sender, RoutedEventArgs e)
        {

        }

        private void view_All_Claims_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {

        }

        private void calendarDay_Click(object sender, RoutedEventArgs e)
        {
            this.MRNNexusMainFrame.NavigationService.Navigate(new Schedule(null, DAY));
        }

        private void calendarWeek_Click(object sender, RoutedEventArgs e)
        {
            this.MRNNexusMainFrame.NavigationService.Navigate(new Schedule(null, WEEK));
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
