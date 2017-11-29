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
using static MRNUIElements.Controllers.ClaimHandling;
using System.Drawing;
using System.IO;
using System.Data.Entity;
using MRNUIElements.DataObjectModels;
using MRNUIElements.DBActions;
using System.ComponentModel;
using System.Net;
using System.Threading;

namespace MRNUIElements
{

    /// <summary>
    /// Interaction logic for CustomerAgreement.xaml
    /// </summary>
    public partial class CustomerAgreement : Page
    {
        static ServiceLayer s = ServiceLayer.getInstance();

        ObservableCollection<DTO_InsuranceCompany> insco = new ObservableCollection<DTO_InsuranceCompany>();
        public DTO_Claim Claim { get; set; }
        //public DTO_Customer CustomerViewSource;
        //  ObservableCollection<DTO_InsuranceCompany> INSCO = new ObservableCollection<DTO_InsuranceCompany>();
        int i = 1;
        static public MRNClaim _MrnClaim = MRNClaim.getInstance();
        Lead _Lead { get; set; }
        Customer _Customer { get; set; }
        ClaimStatus _ClaimStatus { get; set; }
        Employee _Employee { get; set; }
        Address _Address { get; set; }
        InsuranceCompany _InsuranceCompany { get; set; }
        ClaimContacts _ClaimContacts { get; set; }
        Referrer _Referrer { get; set; }
        Scope _Scope { get; set; }
        CallLog _CallLog { get; set; }
        CalendarData _CalendarData { get; set; }
        ObservableCollection<string> fileList = new ObservableCollection<string>();
        ObservableCollection<System.Web.UI.WebControls.Image> ImageList = new ObservableCollection<System.Web.UI.WebControls.Image>();
        Invoice _Invoice { get; set; }
        ClaimDocument _ClaimDocument { get; set; }
        Adjustment _Adjustment { get; set; }

        Adjuster _Adjuster { get; set; }
        Inspection _Inspection { get; set; }
        Payment _Payment { get; set; }
        Plane _Plane { get; set; }
        NewRoof _NewRoof { get; set; }
        OrderItem _OrderItem { get; set; }
        Order _Order { get; set; }

        public CollectionViewSource ClaimViewSource { get; set; }
        public CollectionViewSource LeadViewSource { get; set; }
        public CollectionViewSource CustomerViewSource { get; set; }
        public CollectionViewSource ClaimStatusViewSource { get; set; }
        public CollectionViewSource EmployeeViewSource { get; set; }
        public CollectionViewSource AddressViewSource { get; set; }
        public CollectionViewSource InsuranceCompanyViewSource { get; set; }
        public CollectionViewSource ClaimContactsViewSource { get; set; }
        public CollectionViewSource LeadTypeViewSource { get; set; }
        public CollectionViewSource ReferrerViewSource { get; set; }
        public CollectionViewSource ScopeViewSource { get; set; }
        public CollectionViewSource CallLogViewSource { get; set; }
        public CollectionViewSource CalendarDataViewSource { get; set; }

        public CollectionViewSource InvoiceViewSource { get; set; }
        public CollectionViewSource AdjustmentResultViewSource { get; set; }
        public CollectionViewSource ClaimDocumentViewSource { get; set; }
        public CollectionViewSource AdjustmentViewSource { get; set; }
        public CollectionViewSource RidgeMaterialViewSource { get; set; }
        public CollectionViewSource AdjusterViewSource { get; set; }
        public CollectionViewSource InspectionViewSource { get; set; }
        public CollectionViewSource PaymentViewSource { get; set; }
        public CollectionViewSource PlaneViewSource { get; set; }
        public CollectionViewSource NewRoofViewSource { get; set; }
        public CollectionViewSource OrderItemViewSource { get; set; }
        public CollectionViewSource OrderViewSource { get; set; }
        public CustomerAgreement()
        {
            InitializeComponent();

            leadTypeIDComboBox.ItemsSource = s.LeadTypes;
           
        }



        private void CustomeerAgreement_Loaded(object sender, RoutedEventArgs e)
        {
            var cpp = new ClaimPickerPopUp();



            if (cpp.ShowDialog().Value == true)
            {
                Claim = cpp.Claim;
                carousel_Loaded(Claim, new RoutedEventArgs());
            }

            ClaimViewSource = ((CollectionViewSource)(this.FindResource("dTO_ClaimViewSource")));

            LeadViewSource = ((CollectionViewSource)(this.FindResource("dTO_LeadViewSource")));
            CustomerViewSource = ((CollectionViewSource)(this.FindResource("dTO_CustomerViewSource")));
            ClaimStatusViewSource = ((CollectionViewSource)(this.FindResource("dTO_ClaimStatusViewSource")));
            EmployeeViewSource = ((CollectionViewSource)(this.FindResource("dTO_EmployeeViewSource")));
            AddressViewSource = ((CollectionViewSource)(this.FindResource("dTO_AddressViewSource")));
            InsuranceCompanyViewSource = ((CollectionViewSource)(this.FindResource("dTO_InsuranceCompanyViewSource")));
            ClaimContactsViewSource = ((CollectionViewSource)(this.FindResource("dTO_ClaimContactsViewSource")));
            LeadTypeViewSource = ((CollectionViewSource)(this.FindResource("dTO_LU_LeadTypeViewSource")));
            ReferrerViewSource = ((CollectionViewSource)(this.FindResource("dTO_ReferrerViewSource")));
            ScopeViewSource = ((CollectionViewSource)(this.FindResource("dTO_ScopeViewSource")));
            CallLogViewSource = ((CollectionViewSource)(this.FindResource("dTO_CallLogViewSource")));
            CalendarDataViewSource = ((CollectionViewSource)(this.FindResource("dTO_CalendarDataViewSource")));

            InvoiceViewSource = ((CollectionViewSource)(this.FindResource("dTO_InvoiceViewSource")));
            AdjustmentResultViewSource = ((CollectionViewSource)(this.FindResource("dTO_LU_AdjustmentResultViewSource")));
            ClaimDocumentViewSource = ((CollectionViewSource)(this.FindResource("dTO_ClaimDocumentViewSource")));
            AdjustmentViewSource = ((CollectionViewSource)(this.FindResource("dTO_AdjustmentViewSource")));

            AdjusterViewSource = ((CollectionViewSource)(this.FindResource("dTO_AdjusterViewSource")));
            InspectionViewSource = ((CollectionViewSource)(this.FindResource("dTO_InspectionViewSource")));
            PaymentViewSource = ((CollectionViewSource)(this.FindResource("dTO_PaymentViewSource")));
            PlaneViewSource = ((CollectionViewSource)(this.FindResource("dTO_PlaneViewSource")));
            NewRoofViewSource = ((CollectionViewSource)(this.FindResource("dTO_NewRoofViewSource")));
            OrderItemViewSource = ((CollectionViewSource)(this.FindResource("dTO_OrderItemViewSource")));
            OrderViewSource = ((CollectionViewSource)(this.FindResource("dTO_OrderViewSource")));
            RidgeMaterialViewSource = ((CollectionViewSource)(this.FindResource("dTO_RidgeMaterialViewSource")));
            bool b = false;
            Task.Run(async () =>
            {
                await s.GetAllClaims();
                await s.GetAllCustomers();
                await s.GetAllReferrers();
                await s.GetAllInsuranceCompanies();
                await s.GetLeadTypes();
                await s.GetAllLeads();
                await s.GetAllClaimStatuses();
                await s.GetAllEmployees();
                await s.GetAllAddresses();
                await s.GetAllClaimContacts();
                await s.GetLeadTypes();
                await s.GetAllCustomers();
                await s.GetAllScopes();
                await s.GetAllCallLogs();
                await s.GetAllCalendarData();
                await s.GetAllInvoices();
                await s.GetAllPayments();
                await s.GetAllPlanes();
                await s.GetAdjustmentResults();
                await s.GetAllAdjustments();
                await s.GetAllAdjusters();
                await s.GetAllInspections();
                await s.GetAllNewRoofs();
                await s.GetAllOrders();
                await s.GetAllOrderItems();

                b = true;
            });
            while (!b)
                Thread.Sleep(1000);
            //  GetAllData();
            if (Claim != null)
            {

                //                   try
                //                   {
                //                       ClaimViewSource.Source = s.ClaimsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                //                   }
                //                   catch (NullReferenceException nre) { }
                //                   try
                //                   {
                //                       CallLogViewSource.Source = s.CallLogsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                //                   }
                //                   catch (NullReferenceException nre) { }
                //                   try { LeadGrid.DataContext = s.LeadsList.FindAll(x => x.LeadID == Claim.LeadID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { CustomerGrid.DataContext = s.CustomersList.FindAll(x => x.CustomerID == Claim.CustomerID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { ClaimGrid.DataContext = s.ClaimStatusList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { EmployeeViewSource.Source = s.EmployeesList.FindAll(x => x.EmployeeID == s.ClaimContactsList.Find(y => y.ClaimID == Claim.ClaimID).SalesPersonID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { CustAddressGrid.DataContext = s.AddressesList.FindAll(x => x.AddressID == Claim.PropertyID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { InsuranceCoGrid.DataContext = s.InsuranceCompaniesList.FindAll(x => x.InsuranceCompanyID == Claim.InsuranceCompanyID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //         //          try { ClaimContactsGrid = s.ClaimContactsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { leadTypeIDComboBox.DataContext = s.LeadTypes.FindAll(x => x.LeadTypeID == s.LeadsList.Find(y => y.LeadID == Claim.LeadID).LeadTypeID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { ReferrerGrid.DataContext = s.ReferrersList.FindAll(x => x.ReferrerID == s.LeadsList.Find(y => y.LeadID == Claim.LeadID).CreditToID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //         ///          try { ScopeGrid.DataContext = s.ScopesList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { dTO_CallLogDataGrid.DataContext = s.CallLogsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //       //            try { CalendarDataGrid.DataContext = s.CalendarDataList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { dTO_InvoiceDataGrid.DataContext = s.InvoicesList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { AdjustmentResultViewSource.Source = s.AdjustmentResults.FindAll(x => x.AdjustmentResultID == s.AdjustmentsList.Find(y => y.ClaimID == Claim.ClaimID).AdjustmentResultID); } catch (NullReferenceException nre) { }
                //      //             try { dTO_ClaimDocumentsGrid.DataContext = s.ClaimDocumentsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //       //            try { dTO_AdjustmentGrid.DataContext = s.AdjustmentsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //       //            try { dTO_AdjusterGrid.DataContext = s.AdjustersList.FindAll(x => x.AdjusterID == s.AdjustersList.Find(y => y.AdjusterID == s.AdjustmentsList.Find(z => z.ClaimID == Claim.ClaimID).AdjusterID).AdjusterID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //      //             try { dTO_InspectionsGrid.DataContext = s.InspectionsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { dTO_PaymentDataGrid.DataContext = s.PaymentsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //   //                try { dTO_PlaneGrid.DataContext = s.PlanesList.FindAll(x => x.InspectionID == s.InspectionsList.Find(y => y.ClaimID == Claim.ClaimID).InspectionID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //  //                 try { dTO_NewRoofGrid.DataContext = s.NewRoofsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { dTO_OrderItemDataGrid.DataContext = s.OrderItemsList.FindAll(x => x.OrderID == s.OrdersList.Find(y => y.ClaimID == Claim.ClaimID).OrderID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                ////                   try { dTO_OrderGrid.DataContext = s.OrdersList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //               }



                //               else
                //               {

                try
                {
                    try
                    {
                        ClaimViewSource.Source = s.ClaimsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        leadTypeIDComboBox.ItemsSource = s.LeadTypes;
                    }
                    catch (NullReferenceException nre) { }
                    try { dTO_InsuranceCompanyComboBox.ItemsSource = insuranceCompanyIDComboBox.ItemsSource = insco; } catch (NullReferenceException nre) { }
                    try
                    {
                        CallLogViewSource.Source = s.CallLogsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        LeadViewSource.Source = s.LeadsList.FindAll(x => x.LeadID == Claim.LeadID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        CustomerViewSource.Source = s.CustomersList.FindAll(x => x.CustomerID == Claim.CustomerID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        ClaimStatusViewSource.Source = s.ClaimStatusList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        EmployeeViewSource.Source = s.EmployeesList.FindAll(x => x.EmployeeID == s.ClaimContactsList.Find(y => y.ClaimID == Claim.ClaimID).SalesPersonID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        AddressViewSource.Source = s.AddressesList.FindAll(x => x.AddressID == Claim.PropertyID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        InsuranceCompanyViewSource.Source = s.InsuranceCompaniesList.FindAll(x => x.InsuranceCompanyID == Claim.InsuranceCompanyID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        ClaimContactsViewSource.Source = s.ClaimContactsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        LeadTypeViewSource.Source = s.LeadTypes;
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        ReferrerViewSource.Source = s.ReferrersList.FindAll(x => x.ReferrerID == s.LeadsList.Find(y => y.LeadID == Claim.LeadID).CreditToID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        ScopeViewSource.Source = s.ScopesList;
                    }
                    catch (NullReferenceException nre) { }

                    try
                    {
                        CalendarDataViewSource.Source = s.CalendarDataList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        InvoiceViewSource.Source = s.InvoicesList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        AdjustmentResultViewSource.Source = s.AdjustmentResults.FindAll(x => x.AdjustmentResultID == s.AdjustmentsList.Find(y => y.ClaimID == Claim.ClaimID).AdjustmentResultID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        ClaimDocumentViewSource.Source = s.ClaimDocumentsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        AdjustmentViewSource.Source = s.AdjustmentsList.FindAll(x => x.ClaimID == Claim.ClaimID); ;
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        AdjusterViewSource.Source = s.AdjustersList.FindAll(x => x.AdjusterID == s.AdjustersList.Find(y => y.AdjusterID == s.AdjustmentsList.Find(z => z.ClaimID == Claim.ClaimID).AdjusterID).AdjusterID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        InspectionViewSource.Source = s.InspectionsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        PaymentViewSource.Source = s.PaymentsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        PlaneViewSource.Source = s.PlanesList.FindAll(x => x.InspectionID == s.InspectionsList.Find(y => y.ClaimID == Claim.ClaimID).InspectionID);
                    }

                    catch (NullReferenceException nre) { }
                    try
                    {
                        NewRoofViewSource.Source = s.NewRoofsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        OrderItemViewSource.Source = s.OrderItemsList.FindAll(x => x.OrderID == s.OrdersList.Find(y => y.ClaimID == Claim.ClaimID).OrderID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        OrderViewSource.Source = s.OrdersList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {

                        ClaimDocumentViewSource.Source = Task.Run(async () => await GetImages(Claim)).Result;
                    }
                    catch (NullReferenceException nre) { }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }




        }
       
        async static Task<List<DTO_ClaimDocument>> GetDocuments(DTO_Claim Claim)
        {
            await s.GetClaimDocumentsByClaimID(Claim);
            return s.ClaimDocumentsList.FindAll(x => x.ClaimID == Claim.ClaimID && x.DocTypeID == 2);
        }
        async void DisplayRecordedClaimDocuments(DTO_ClaimDocument _claimDocument)
        {

            MainWindow.getBusyIndicator().Visibility = Visibility.Visible;

            if (_claimDocument != null)
                if (_claimDocument.FileExt == ".jepg" || _claimDocument.FileExt == ".JPEG" || _claimDocument.FileExt == ".jpg" || _claimDocument.FileExt == ".png" || _claimDocument.FileExt == ".bmp" || _claimDocument.FileExt == ".JPG" || _claimDocument.FileExt == ".BMP" || _claimDocument.FileExt == ".PNG")
                {
                    await DownloadImage("http://" + _claimDocument.FilePath + _claimDocument.FileName + _claimDocument.FileExt);
                }

            if (MainWindow.getBusyIndicator().Visibility == Visibility.Visible)
                MainWindow.getBusyIndicator().Visibility = Visibility.Collapsed;
        }
        public async Task<Bitmap> DownloadImage(string str)
        {

            var stream = new MemoryStream();
            try
            {


                var web = new System.Net.WebClient();


                stream = new MemoryStream(await web.DownloadDataTaskAsync(str));


            }
            catch (Exception)
            {
                //  throw;
            }




            MainWindow.getBusyIndicator().Visibility = Visibility.Collapsed;
            return (Bitmap)new ImageSourceConverter().ConvertFromString(str);

        }

        async Task<List<Bitmap>> GetImages(DTO_Claim Claim)
        {

            var listtoreturn = new List<Bitmap>();

            if (Claim != null)
                foreach (var item in await GetDocuments(Claim))
                {
                    if (item.FileExt == ".jepg" || item.FileExt == ".JPEG" || item.FileExt == ".jpg" || item.FileExt == ".png" || item.FileExt == ".bmp" || item.FileExt == ".JPG" || item.FileExt == ".BMP" || item.FileExt == ".PNG")
                    {
                        listtoreturn.Add(await DownloadImage("http://" + item.FilePath + item.FileName + item.FileExt));
                    }

                }
            else foreach (var item in s.ClaimDocumentsList)
                {
                    if (item.FileExt == ".jepg" || item.FileExt == ".JPEG" || item.FileExt == ".jpg" || item.FileExt == ".png" || item.FileExt == ".bmp" || item.FileExt == ".JPG" || item.FileExt == ".BMP" || item.FileExt == ".PNG")
                    {
                        listtoreturn.Add(await DownloadImage("http://" + item.FilePath + item.FileName + item.FileExt));
                    }

                }
            return listtoreturn;
        }

        static DTO_ClaimDocument GetClaimDocument(DTO_Claim Claim, int _claimDocTypeID)
        {
            return s.ClaimDocumentsList.Find(x => x.ClaimID == Claim.ClaimID && x.DocTypeID == _claimDocTypeID);

        }



        //public ClaimDataSet source = new ClaimDataSet();
        //private CollectionViewSource refreshView;
        //public CollectionViewSource RefreshView
        //{

        //    get { return refreshView; }
        //    set
        //    {
        //        if (value != refreshView)
        //        {
        //            refreshView = value;
        //            RaisePropertyChanged("RefreshView");
        //            foreach (var item in source)
        //            {
        //                ((CollectionViewSource)this.Resources["cvsActors"]).View.Refresh();

        //            }
        //        }
        //    }
        //}


        ////public CollectionViewSource ClaimViewSource { get; set; }
        ////public CollectionViewSource LeadViewSource { get; set; }
        ////public CollectionViewSource CustomerViewSource { get; set; }
        ////public CollectionViewSource ClaimStatusViewSource { get; set; }
        ////public CollectionViewSource EmployeeViewSource { get; set; }
        ////public CollectionViewSource AddressViewSource { get; set; }
        ////public CollectionViewSource InsuranceCompanyViewSource { get; set; }
        ////public CollectionViewSource ClaimContactsViewSource { get; set; }
        ////public CollectionViewSource LeadTypeViewSource { get; set; }
        ////public CollectionViewSource ReferrerViewSource { get; set; }
        ////public CollectionViewSource ScopeViewSource { get; set; }
        ////public CollectionViewSource CallLogViewSource { get; set; }
        ////public CollectionViewSource CalendarDataViewSource { get; set; }

        ////public CollectionViewSource InvoiceViewSource { get; set; }
        ////public CollectionViewSource AdjustmentResultViewSource { get; set; }
        ////public CollectionViewSource ClaimDocumentViewSource { get; set; }
        ////public CollectionViewSource AdjustmentViewSource { get; set; }

        ////public CollectionViewSource AdjusterViewSource { get; set; }
        ////public CollectionViewSource InspectionViewSource { get; set; }
        ////public CollectionViewSource PaymentViewSource { get; set; }
        ////public CollectionViewSource PlaneViewSource { get; set; }
        ////public CollectionViewSource NewRoofViewSource { get; set; }
        ////public CollectionViewSource OrderItemViewSource { get; set; }
        ////public CollectionViewSource OrderViewSource { get; set; }


        //private void RaisePropertyChanged(string v)
        //{
        //    throw new NotImplementedException();
        //}

        void GetAllData()
        {
            if (Claim != null)
            {

                try
                {
                    ClaimViewSource.Source = s.ClaimsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                }
                catch (NullReferenceException nre) { }
                try
                {
                    CallLogViewSource.Source = s.CallLogsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                }
                catch (NullReferenceException nre) { }
                try { LeadViewSource.Source = s.LeadsList.FindAll(x => x.LeadID == Claim.LeadID); } catch (NullReferenceException nre) { }
                try { CustomerViewSource.Source = s.CustomersList.FindAll(x => x.CustomerID == Claim.CustomerID); } catch (NullReferenceException nre) { }
                try { ClaimStatusViewSource.Source = s.ClaimStatusList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { EmployeeViewSource.Source = s.EmployeesList.FindAll(x => x.EmployeeID == s.ClaimContactsList.Find(y => y.ClaimID == Claim.ClaimID).SalesPersonID); } catch (NullReferenceException nre) { }
                try { AddressViewSource.Source = s.AddressesList.FindAll(x => x.AddressID == Claim.PropertyID); } catch (NullReferenceException nre) { }
                try { InsuranceCompanyViewSource.Source = s.InsuranceCompaniesList.FindAll(x => x.InsuranceCompanyID == Claim.InsuranceCompanyID); } catch (NullReferenceException nre) { }
                try { ClaimContactsViewSource.Source = s.ClaimContactsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { LeadTypeViewSource.Source = s.LeadTypes.FindAll(x => x.LeadTypeID == s.LeadsList.Find(y => y.LeadID == Claim.LeadID).LeadTypeID); } catch (NullReferenceException nre) { }
                try { ReferrerViewSource.Source = s.ReferrersList.FindAll(x => x.ReferrerID == s.LeadsList.Find(y => y.LeadID == Claim.LeadID).CreditToID); } catch (NullReferenceException nre) { }
                try { ScopeViewSource.Source = s.ScopesList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { CallLogViewSource.Source = s.CallLogsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { CalendarDataViewSource.Source = s.CalendarDataList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { InvoiceViewSource.Source = s.InvoicesList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { AdjustmentResultViewSource.Source = s.AdjustmentResults.FindAll(x => x.AdjustmentResultID == s.AdjustmentsList.Find(y => y.ClaimID == Claim.ClaimID).AdjustmentResultID); } catch (NullReferenceException nre) { }
                try { ClaimDocumentViewSource.Source = s.ClaimDocumentsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { AdjustmentViewSource.Source = s.AdjustmentsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { AdjusterViewSource.Source = s.AdjustersList.FindAll(x => x.AdjusterID == s.AdjustersList.Find(y => y.AdjusterID == s.AdjustmentsList.Find(z => z.ClaimID == Claim.ClaimID).AdjusterID).AdjusterID); } catch (NullReferenceException nre) { }
                try { InspectionViewSource.Source = s.InspectionsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { PaymentViewSource.Source = s.PaymentsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { PlaneViewSource.Source = s.PlanesList.FindAll(x => x.InspectionID == s.InspectionsList.Find(y => y.ClaimID == Claim.ClaimID).InspectionID); } catch (NullReferenceException nre) { }
                try { NewRoofViewSource.Source = s.NewRoofsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { OrderItemViewSource.Source = s.OrderItemsList.FindAll(x => x.OrderID == s.OrdersList.Find(y => y.ClaimID == Claim.ClaimID).OrderID); } catch (NullReferenceException nre) { }
                try { OrderViewSource.Source = s.OrdersList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
            }
        }



        async private void carousel_Loaded(object sender, RoutedEventArgs e)
        {


            await s.GetAllClaimDocuments();

            if (sender.GetType() == typeof(DTO_Claim))
            {


                //var sc = SynchronizationContext.Current;

                foreach (var item in s.ClaimDocumentsList.FindAll(x => x.ClaimID == ((DTO_Claim)sender).ClaimID && x.DocTypeID == 2))
                {
                    var im = new System.Web.UI.WebControls.Image();
                    im.Height = 200;
                    im.Width = 200;


                    var imageaddress = "http://" + item.FilePath + item.FileName + item.FileExt;

                    im.ImageUrl = imageaddress;


                    //var web = new System.Net.WebClient();
                    addImagesbutton_Click((string)imageaddress, e);
                    ImageList.Add(im);
                    //var stream = new MemoryStream(await web.DownloadDataTaskAsync(imageaddress));
                    //     var bmp = new Bitmap(stream);
                    //listOfImgs.Add(bmp);
                    // carousel.Items.Add(bmp);

                }

                carousel.ItemsSource = ImageList;

            }
        }

        private void addImagesbutton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty((string)sender))
                ImageList.Add(new System.Web.UI.WebControls.Image() { ImageUrl = sender.ToString() });

            else
                SelectFile(2).ForEach(x => imagelistBox.Items.Add(x.ToString()));
            imagelistBox.Items.Add((string)sender);
        }

        private void nextImageBtn_Click(object sender, RoutedEventArgs e)
        {
            imagelistBox.SelectedIndex++;
        }

        private void deleteImageButtonbutton_Click(object sender, RoutedEventArgs e)
        {
            image.Source = null;
            imagelistBox.Items.RemoveAt(imagelistBox.SelectedIndex);
        }

        private void imagelistBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(imagelistBox.SelectedValue.ToString());




        }
        private List<string> SelectFile(int docTypeID)
        {
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            if (docTypeID == 2)
                fileDialog.Multiselect = true;
            else
                fileDialog.Multiselect = false;
            fileDialog.Title = "Inspection Image Import Tool";
            fileDialog.Filter = Filter(docTypeID);
            var result = fileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //FullFilePath = fileDialog.FileName;
                foreach (string s in fileDialog.FileNames)
                {

                    imagelistBox.Items.Add(s);
                }

                imagelistBox.SelectedIndex = 0;
            }

            return FileNames;
        }
        List<string> FileNames = new List<string>();
        //internal ReturnEventHandler<object> Return;


        string Filter(int docTypeID)
        {
            switch (docTypeID)
            {
                case 2:
                    return "All Image Types (*.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png) | *.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png";

                default:
                    return "All Image Types (*.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png) | *.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png | All Document Types (*.pdf;*.doc;*.docx;*.txt;*.xml) | *.pdf;*.doc;*.docx;*.txt;*.xml| All File Types(*.*) | *.*";

            }




        }

        protected BitmapImage DisplayImage(ImageSource imgsrc)
        {

            return (BitmapImage)imgsrc;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }



        public class InspectionImage : DTO_ClaimDocument
        {
            ServiceLayer s1 = ServiceLayer.getInstance();
            static public ObservableCollection<InspectionImage> InspectionImages;
            public int DocImageID { get; set; }
            public string Path { get; set; }
            public DTO_Claim Claim { get; set; }
            public BitmapImage Image { get; set; }
            public string Comments { get; set; }
            bool youmayproceed = false;
            public InspectionImage()
            {
                if (this.Claim == null)
                    return;

                youmayproceed = false;
                GetCollection(this.Claim);
                while (!youmayproceed)
                    Thread.Sleep(10);
            }
            async void GetCollection(DTO_Claim claim)
            {
                await ConvertToInspectionImages(claim);
            }
            private async Task<ObservableCollection<InspectionImage>> ConvertToInspectionImages(DTO_Claim claim)
            {
                await s1.GetClaimDocumentsByClaimID(claim);


                var a = new ObservableCollection<InspectionImage>();
                foreach (var b in s1.ClaimDocumentsList.Where(x => x.DocTypeID == 1))
                {

                    a.Add(
                        new InspectionImage
                        {
                            Image = GetImage(b.FilePath + b.FileName + b.FileExt),
                            Comments = b.DocumentComments
                        });

                }

                youmayproceed = true;
                return a;

            }


            private BitmapImage GetImage(string Path)
            {
                var a = new BitmapImage();
                try
                {
                    if (!string.IsNullOrEmpty(Path))
                        a = new BitmapImage(new Uri(Path, UriKind.Absolute));
                    else if (!string.IsNullOrEmpty(this.Path))
                        a = new BitmapImage(new Uri(this.Path, UriKind.Absolute));

                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("No Image Found");

                }
                return a;
            }


        }






        //<Image Source = "{Binding Path=Image, IsAsync=True}" />



        public class ListItemViewData : INotifyPropertyChanged
        {
            public ListItemViewData(Uri uri)
            {
                this._uri = uri;
            }

            private readonly Uri _uri;
            public Uri Uri
            {
                get
                {
                    return this._uri;
                }
            }

            private BitmapSource _source = null;
            public BitmapSource Image
            {
                get
                {
                    return this._source;
                }
                set
                {
                    this._source = value;
                    this.OnPropertyChanged("Image");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string p)
            {
                var pc = this.PropertyChanged;
                if (pc != null)
                {
                    pc(this, new PropertyChangedEventArgs(p));
                }
            }
        }



        public static class WebHelper
        {
            public static Stream DownloadImage(Uri uri, string savePath)
            {
                var request = WebRequest.Create(uri);
                var response = request.GetResponse();
                using (var stream = response.GetResponseStream())
                {
                    Byte[] buffer = new Byte[response.ContentLength];
                    int offset = 0, actuallyRead = 0;
                    do
                    {
                        actuallyRead = stream.Read(buffer, offset, buffer.Length - offset);
                        offset += actuallyRead;
                    }
                    while (actuallyRead > 0);
                    File.WriteAllBytes(savePath, buffer);
                    return new MemoryStream(buffer);
                }
            }
        }


        Type ViewSourceTypeConverter(Type typeObject)
        {


            if ((Type)ClaimViewSource.GetType() == typeObject.GetType()) return typeof(DTO_Claim);
            if ((Type)CallLogViewSource.Source == typeObject.GetType()) return typeof(DTO_CallLog);
            if ((Type)LeadViewSource.Source == typeObject.GetType()) return typeof(DTO_Lead);
            if ((Type)CustomerViewSource.Source == typeObject.GetType()) return typeof(DTO_Customer);
            if ((Type)ClaimStatusViewSource.Source == typeObject.GetType()) return typeof(DTO_ClaimStatus);
            if ((Type)EmployeeViewSource.Source == typeObject.GetType()) return typeof(DTO_Employee);
            if ((Type)AddressViewSource.Source == typeObject.GetType()) return typeof(DTO_Address);
            if ((Type)InsuranceCompanyViewSource.Source == typeObject.GetType()) return typeof(DTO_InsuranceCompany);
            if ((Type)ClaimContactsViewSource.Source == typeObject.GetType()) return typeof(DTO_ClaimContacts);
            if ((Type)LeadTypeViewSource.Source == typeObject.GetType()) return typeof(DTO_LU_LeadType);
            if ((Type)ReferrerViewSource.Source == typeObject.GetType()) return typeof(DTO_Referrer);
            if ((Type)CalendarDataViewSource.Source == typeObject.GetType()) return typeof(DTO_CalendarData);
            if ((Type)InvoiceViewSource.Source == typeObject.GetType()) return typeof(DTO_Invoice);
            if ((Type)AdjustmentResultViewSource.Source == typeObject.GetType()) return typeof(DTO_LU_AdjustmentResult);
            if ((Type)ClaimDocumentViewSource.Source == typeObject.GetType()) return typeof(DTO_ClaimDocument);
            if ((Type)AdjustmentViewSource.Source == typeObject.GetType()) return typeof(DTO_Adjustment);
            if ((Type)AdjusterViewSource.Source == typeObject.GetType()) return typeof(DTO_Adjuster);
            if ((Type)InspectionViewSource.Source == typeObject.GetType()) return typeof(DTO_Inspection);
            if ((Type)NewRoofViewSource.Source == typeObject.GetType()) return typeof(DTO_NewRoof);
            if ((Type)OrderItemViewSource.Source == typeObject.GetType()) return typeof(DTO_OrderItem);
            if ((Type)OrderViewSource.Source == typeObject.GetType()) return typeof(DTO_Order);

            return null;



        }


        async private void AddClaimBtn_Click(object sender, RoutedEventArgs e)
        {


            _Customer = new Customer();
            _Address = new Address();
            _Lead = new Lead();
            _Referrer = new Referrer();
            _Inspection = new Inspection();
            _ClaimContacts = new ClaimContacts();
            Claim = new DTO_Claim();
            try
            {
                if (!string.IsNullOrEmpty(insuranceClaimNumberMaskedTextBox.Text))
                    if (System.Windows.Forms.MessageBox.Show("This hasn't been Claimed yet. Are you sure you would like to add it to the list of active claims?", "What is going on here?!?", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes)
                        return;
                try
                {
                    _Customer.Suffix = suffixMaskedTextBox.Text;
                }
                catch (NullReferenceException nre) { }
                try { _Customer.FirstName = firstNameMaskedTextBox.Text; } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show("Shit man you gotta put a first name! shooot?!?"); }
                try { _Customer.MiddleName = middleNameMaskedTextBox.Text; } catch (NullReferenceException nre) { }

                try
                {
                    _Customer.LastName = lastNameMaskedTextBox.Text;
                }
                catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show("Shit man you gotta put a last name! shooot?!?"); }
                try
                {
                    _Customer.MailPromos = mailPromosCheckBox.IsChecked.Value;
                }
                catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show("Shit man you gotta have a numba for these folks! shooot?!?"); }
                try
                {
                    _Customer.PrimaryNumber = primaryNumberMaskedTextBox.Text;
                }
                catch (NullReferenceException nre) { }
                try { _Customer.SecondaryNumber = secondaryNumberMaskedTextBox.Text; } catch (NullReferenceException nre) { }
                try
                { _Customer.Email = emailMaskedTextBox.Text; }
                catch (NullReferenceException nre) { }

                try
                {
                    Claim.ContractSigned = isSigned.IsChecked.Value;
                }
                catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show("Shit man it hasn't been that long since you signed this has it? shooot?!?"); }
                try
                {
                    Claim.LossDate = lossDateDatePicker.SelectedDate.Value;
                }
                catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show("Shit man you gotta know when this happened! shooot?!?"); }
                try
                {
                    Claim.IsOpen = isOpenCheckBox.IsChecked.Value;
                }
                catch (NullReferenceException nre) { }
                try { Claim.MortgageAccount = mortgageAccountMaskedTextBox.Text; } catch (NullReferenceException nre) { }
                try
                { Claim.MortgageCompany = mortgageCompanyMaskedTextBox.Text; }
                catch (NullReferenceException nre) { }
                try
                { Claim.InsuranceClaimNumber = insuranceClaimNumberMaskedTextBox.Text; }
                catch (NullReferenceException nre) { }

                try
                {
                    _Lead.KnockerResponseID = (int)knockerIDComboBox.SelectedValue;
                }
                catch (NullReferenceException nre) { }
                try
                {
                    _Lead.LeadTypeID = (int)leadTypeIDComboBox.SelectedIndex > -1 ? (int)leadTypeIDComboBox.SelectedIndex + 1 : -1;
                }
                catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show("How did we find out about this job?"); }

                try { } catch (NullReferenceException nre) { }
                try
                { }
                catch (NullReferenceException nre) { }

                try
                {
                    _Address._Address = addressMaskedTextBox.Text;

                }
                catch (NullReferenceException nre)
                {
                    System.Windows.Forms.MessageBox.Show("Need to know where to go to do this job.");

                }
                try
                {
                    _Address.Zip = zipMaskedTextBox.Text;

                }
                catch (NullReferenceException nre)
                {
                    System.Windows.Forms.MessageBox.Show("Will ya give us a hint as to what zipcode we might be working in?");

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ok you just turn right around and fix that shit right now!");
                return;
            }

            try
            {
                if (s.AddressesList.Exists(x => x.Address == _Address._Address && x.Zip == _Address.Zip))
                    System.Windows.Forms.MessageBox.Show("This address already exists in database.");
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                await Task.Run(async () => await s.AddCustomer(_Customer));

                if (s.Cust.Message == null)
                    _Lead.CustomerID = _ClaimContacts.CustomerID = Claim.CustomerID = _Address.CustomerID = _Customer.CustomerID = s.Cust.CustomerID;
            }
            catch (Exception ex)
            {
                return;
            }
            try { await s.AddAddress(_Address); } catch (Exception ex) { return; }

            if (s.Address.Message == null)
            {
                _Address = (Address)s.Address;

                addressIDIntegerTextBox.Value = (long)(Claim.BillingID = Claim.PropertyID = _Lead.AddressID = _Address.AddressID);




                switch (((DTO_LU_LeadType)leadTypeIDComboBox.SelectedItem).LeadTypeID)
                {
                    case 1:
                        {


                            ReferrerGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
                            _Lead.CreditToID = (int)((DTO_Employee)ExistingContactInfoCombo.SelectedItem).EmployeeID;

                            _ClaimContacts.KnockerID = _Lead.CreditToID;
                            ReferrerGrid.Visibility = Visibility.Hidden;

                            CustomerGrid.Visibility = Visibility.Hidden;
                            CustAddressGrid.Visibility = Visibility.Visible;
                            break;

                        }
                    case 2:
                        {

                            ReferrerGrid.DataContext = ExistingContactInfoCombo.SelectedItem;

                            _Lead.CreditToID = (int)((DTO_Referrer)ExistingContactInfoCombo.SelectedItem).ReferrerID;
                            ReferrerGrid.Visibility = Visibility.Visible;

                            CustomerGrid.Visibility = Visibility.Hidden;
                            CustAddressGrid.Visibility = Visibility.Hidden;
                            break;
                        }
                    case 3:
                        {

                            // PreviousReferrercheckBox.Visibility = Visibility.Hidden;
                            //ExistingContactInfoCombo.ItemsSource = s.CustomersList;
                            CustomerGrid.DataContext = ExistingContactInfoCombo.SelectedItem;

                            _Lead.CreditToID = (int)((DTO_Customer)ExistingContactInfoCombo.SelectedItem).CustomerID;
                            ReferrerGrid.Visibility = Visibility.Hidden;
                            //EmployeeGrid.Visibility = Visibility.Hidden;
                            CustomerGrid.Visibility = Visibility.Visible;
                            CustAddressGrid.Visibility = Visibility.Hidden;
                            break;
                        }
                    case 4:
                        {
                            // PreviousReferrercheckBox.Visibility = Visibility.Hidden;
                            _Lead.LeadTypeID = 4;
                            _Lead.CreditToID = 0;
                            ReferrerGrid.Visibility = Visibility.Hidden;
                            //EmployeeGrid.Visibility = Visibility.Hidden;
                            CustomerGrid.Visibility = Visibility.Hidden;
                            CustAddressGrid.Visibility = Visibility.Hidden;

                            break;
                        }

                    default:
                        {

                            // PreviousReferrercheckBox.Visibility = Visibility.Hidden;
                            //	ExistingContactInfoCombo.ItemsSource = s.EmployeesList;
                            //EmployeeGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
                            _Lead.LeadTypeID = 5;
                            _Lead.CreditToID = (int)((DTO_Employee)ExistingContactInfoCombo.SelectedItem).EmployeeID;
                            ReferrerGrid.Visibility = Visibility.Hidden;
                            //EmployeeGrid.Visibility = Visibility.Visible;
                            CustomerGrid.Visibility = Visibility.Hidden;
                            CustAddressGrid.Visibility = Visibility.Hidden;
                            break;
                        }

                } //sets if to look up info from referrer

                DTO_Referrer ConvertToReferrer(object o)
                {
                    DTO_Customer customer = new DTO_Customer();
                    DTO_Employee employee = new DTO_Employee();
                    DTO_Referrer referrer = new DTO_Referrer();

                    if (o.GetType() == customer.GetType())
                    {
                        referrer.FirstName = ((DTO_Customer)o).FirstName;
                        referrer.LastName = ((DTO_Customer)o).LastName;
                        referrer.CellPhone = ((DTO_Customer)o).PrimaryNumber;
                        referrer.Email = ((DTO_Customer)o).Email;
                        referrer.MailingAddress = s.AddressesList.Find(x => x.CustomerID == ((DTO_Customer)o).CustomerID).Address;
                        referrer.Suffix = ((DTO_Customer)o).Suffix;
                        referrer.ReferrerID = ((DTO_Customer)o).CustomerID;
                        referrer.Zip = s.AddressesList.Find(x => x.CustomerID == ((DTO_Customer)o).CustomerID).Zip;

                    }
                    else if (o.GetType() == employee.GetType())
                    {

                        referrer.FirstName = ((DTO_Employee)o).FirstName;
                        referrer.LastName = ((DTO_Employee)o).LastName;
                        referrer.CellPhone = ((DTO_Employee)o).CellPhone;
                        referrer.Email = ((DTO_Employee)o).Email;
                        referrer.MailingAddress = "196 Old Loganville Rd.";
                        referrer.Suffix = ((DTO_Employee)o).Suffix;
                        referrer.ReferrerID = ((DTO_Employee)o).EmployeeID;
                        referrer.Zip = "30052";

                    }
                    else if (o.GetType() == referrer.GetType())
                    {
                        referrer = (DTO_Referrer)o;
                    }

                    return referrer;
                }

                object GetClaimReferrer(Type type)
                {
                    if (((Type)type) == typeof(DTO_Employee))
                        return s.EmployeesList.Find(y => y.EmployeeID == (s.LeadsList.Find(x => x.LeadID == Claim.LeadID).CreditToID));
                    else if (type.GetType() == typeof(DTO_Employee))
                        return s.CustomersList.Find(y => y.CustomerID == (s.LeadsList.Find(x => x.LeadID == Claim.LeadID).CreditToID));
                    else if (type.GetType() == typeof(DTO_Employee))
                        return s.ReferrersList.Find(y => y.ReferrerID == (s.LeadsList.Find(x => x.LeadID == Claim.LeadID).CreditToID));
                    else
                        return null;
                }

                Type GetReferrerType(DTO_Claim claim)
                {
                    var lead = s.LeadsList.Find(x => x.LeadID == claim.LeadID);
                    switch (lead.LeadTypeID)
                    {
                        case 1:
                        case 5:

                            return typeof(DTO_Employee);
                        case 2:
                            return typeof(DTO_Referrer);
                        case 3:
                            return typeof(DTO_Customer);
                        default:
                            return null;


                    }
                }

                if (leadTypeIDComboBox.SelectedIndex != 4)
                    _Referrer = (Referrer)GetClaimReferrer((GetReferrerType(Claim)));
                try
                {
                    await s.AddReferrer(ConvertToReferrer(_Referrer));
                }
                catch (Exception)
                {

                    throw;
                }
                //await s.AddReferrer((DTO_Referrer)ReferrerViewSource.Source);
                try
                {
                    _ClaimContacts.SalesPersonID = _Lead.SalesPersonID = (int)salesPersonIDComboBox.SelectedValue;
                }
                catch (NullReferenceException nre) { }
                creditToIDComboBox.SelectedValue = _ClaimContacts.KnockerID = _Lead.CreditToID = s.Referrer.ReferrerID;
                ReferrerGrid.DataContext = s.Referrer;
                try
                {
                    await s.AddLead(_Lead);
                }
                catch (Exception)
                {


                }
                try
                {
                    if (s.Lead.Message == null)
                    {
                        _Lead = s.Lead as Lead;
                        Claim.LeadID = _Lead.LeadID;

                    }
                }
                catch (Exception)
                {

                }


                await s.AddInspection((DTO_Inspection)InspectionViewSource.Source);
                var i = new List<DTO_Inspection>();
                i.Add(s.Inspection);
                InspectionViewSource.Source = i;

                await s.AddClaim((DTO_Claim)ClaimViewSource.Source);
                if (s.Claim.Message == null)
                    System.Windows.Forms.MessageBox.Show("Success - Test - " + s.Claim.ClaimID.ToString() + " is the ClaimID Associated with your Claim.");
            }
            // await s.AddClaimDocument((DTO_ClaimDocument)ClaimDocumentViewSource.Source);
        }


        private static List<DTO_Lead> GetLead(List<DTO_Lead> _Lead)
        {
            return _Lead;
        }

        private void ExistingContactInfoCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // this.DataContext = this;
            switch (((DTO_LU_LeadType)leadTypeIDComboBox.SelectedItem).LeadTypeID)
            {
                case 1:
                    {

                        //  PreviousReferrercheckBox.Visibility = Visibility.Hidden;
                        //	ExistingContactInfoCombo.ItemsSource = s.EmployeesList;
                        ////EmployeeGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
                        _Lead.CreditToID = (int)((DTO_Employee)ExistingContactInfoCombo.SelectedItem).EmployeeID;
                        _Lead.LeadTypeID = 1;
                        _ClaimContacts.KnockerID = _Lead.CreditToID;
                        ReferrerGrid.Visibility = Visibility.Hidden;
                        //EmployeeGrid.Visibility = Visibility.Visible;
                        CustomerGrid.Visibility = Visibility.Hidden;
                        CustAddressGrid.Visibility = Visibility.Visible;
                        break;

                    }
                case 2:
                    {
                        //   isReferral = true;
                        //  PreviousReferrercheckBox.Visibility = Visibility.Visible;
                        //	ExistingContactInfoCombo.ItemsSource = s.ReferrersList;
                        ReferrerGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
                        _Lead.LeadTypeID = 2;
                        _Lead.CreditToID = (int)((DTO_Referrer)ExistingContactInfoCombo.SelectedItem).ReferrerID;
                        ReferrerGrid.Visibility = Visibility.Visible;
                        ////EmployeeGrid.Visibility = Visibility.Hidden;
                        CustomerGrid.Visibility = Visibility.Hidden;
                        CustAddressGrid.Visibility = Visibility.Hidden;
                        break;
                    }
                case 3:
                    {

                        // PreviousReferrercheckBox.Visibility = Visibility.Hidden;
                        //ExistingContactInfoCombo.ItemsSource = s.CustomersList;
                        CustomerGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
                        _Lead.LeadTypeID = 3;
                        _Lead.CreditToID = (int)((DTO_Customer)ExistingContactInfoCombo.SelectedItem).CustomerID;
                        ReferrerGrid.Visibility = Visibility.Hidden;
                        //EmployeeGrid.Visibility = Visibility.Hidden;
                        CustomerGrid.Visibility = Visibility.Visible;
                        CustAddressGrid.Visibility = Visibility.Hidden;
                        break;
                    }
                case 4:
                    {
                        // PreviousReferrercheckBox.Visibility = Visibility.Hidden;
                        _Lead.LeadTypeID = 4;
                        _Lead.CreditToID = 0;
                        ReferrerGrid.Visibility = Visibility.Hidden;
                        //EmployeeGrid.Visibility = Visibility.Hidden;
                        CustomerGrid.Visibility = Visibility.Hidden;
                        CustAddressGrid.Visibility = Visibility.Hidden;

                        break;
                    }

                default:
                    {

                        //  PreviousReferrercheckBox.Visibility = Visibility.Hidden;
                        //	ExistingContactInfoCombo.ItemsSource = s.EmployeesList;
                        //EmployeeGrid.DataContext = ExistingContactInfoCombo.SelectedItem;
                        _Lead.LeadTypeID = 5;
                        _Lead.CreditToID = (int)((DTO_Employee)ExistingContactInfoCombo.SelectedItem).EmployeeID;
                        ReferrerGrid.Visibility = Visibility.Hidden;
                        //EmployeeGrid.Visibility = Visibility.Visible;
                        CustomerGrid.Visibility = Visibility.Hidden;
                        CustAddressGrid.Visibility = Visibility.Hidden;
                        break;
                    }

            } //sets if to look up info from referrer


        }

        private void LeadTypecomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((DTO_LU_LeadType)leadTypeIDComboBox.SelectedItem).LeadTypeID)
            {
                case 1:
                    {


                        ExistingContactInfoCombo.ItemsSource = s.EmployeesList.Where(x => x.EmployeeTypeID == 14);

                        break;

                    }
                case 2:
                    {


                        ContactInfoDisplay(true);

                        if (ReferrerGrid.Visibility != Visibility.Visible)
                            ReferrerGrid.Visibility = Visibility.Visible;
                        ExistingContactInfoCombo.ItemsSource = s.ReferrersList;
                        break;
                    }
                case 3:
                    {
                        ContactLookupDisplay(true);
                        ContactInfoDisplay(true);

                        ExistingContactInfoCombo.ItemsSource = s.CustomersList;

                        break;
                    }
                case 4:
                    {
                        ContactLookupDisplay(true);
                        ContactInfoDisplay(false);


                        break;
                    }

                default:
                    {
                        ContactLookupDisplay(true);
                        ContactInfoDisplay(true);

                        ExistingContactInfoCombo.ItemsSource = s.EmployeesList.Where(x => x.EmployeeTypeID == 13);

                        break;
                    }

            } //sets if to look up info from referrer

        }
        bool ContactLookupDisplay(bool Enable)
        {
            if (Enable)
            {
                if (ExistingContactInfoCombo.Visibility != Visibility.Visible)

                    ExistingContactInfoCombo.Visibility = Visibility.Visible;

            }
            else
            {
                if (ExistingContactInfoCombo.Visibility == Visibility.Visible)

                    ExistingContactInfoCombo.Visibility = Visibility.Hidden;
            }

            return Enable;
        }
        bool ContactInfoDisplay(bool Enable)
        {

            if (Enable)
            {
                //if (Lead_FirstName.Visibility != Visibility.Visible)
                //	Lead_FirstName.Visibility = Visibility.Visible;
                //if (Lead_MiddleName.Visibility != Visibility.Visible)
                //	Lead_MiddleName.Visibility = Visibility.Visible;
                //if (Lead_LastName.Visibility != Visibility.Visible)
                //	Lead_LastName.Visibility = Visibility.Visible;
                //if (Lead_Suffix.Visibility != Visibility.Visible)
                //	Lead_Suffix.Visibility = Visibility.Visible;
                //if (Lead_Address.Visibility != Visibility.Visible)
                //	Lead_Address.Visibility = Visibility.Visible;
                //if (Lead_City.Visibility != Visibility.Visible)
                //	Lead_City.Visibility = Visibility.Visible;
                //if (Lead_State.Visibility != Visibility.Visible)
                //	Lead_State.Visibility = Visibility.Visible;
                //if (Lead_Zipcode.Visibility != Visibility.Visible)
                //	Lead_Zipcode.Visibility = Visibility.Visible;
                //if (Lead_Primary_Phone.Visibility != Visibility.Visible)
                //	Lead_Primary_Phone.Visibility = Visibility.Visible;
                //if (Lead_Secondary_Phone.Visibility != Visibility.Visible)
                //	Lead_Secondary_Phone.Visibility = Visibility.Visible;
                //if (Lead_Email_Address.Visibility != Visibility.Visible)
                //	Lead_Email_Address.Visibility = Visibility.Visible;

            }
            else
            {
                //if (Lead_FirstName.Visibility == Visibility.Visible)
                //	Lead_FirstName.Visibility = Visibility.Hidden;
                //if (Lead_MiddleName.Visibility == Visibility.Visible)
                //	Lead_MiddleName.Visibility = Visibility.Hidden;
                //if (Lead_LastName.Visibility == Visibility.Visible)
                //	Lead_LastName.Visibility = Visibility.Hidden;
                //if (Lead_Suffix.Visibility == Visibility.Visible)
                //	Lead_Suffix.Visibility = Visibility.Hidden;
                //if (Lead_Address.Visibility == Visibility.Visible)
                //	Lead_Address.Visibility = Visibility.Hidden;
                //if (Lead_City.Visibility == Visibility.Visible)
                //	Lead_City.Visibility = Visibility.Hidden;
                //if (Lead_State.Visibility == Visibility.Visible)
                //	Lead_State.Visibility = Visibility.Hidden;
                //if (Lead_Zipcode.Visibility == Visibility.Visible)
                //	Lead_Zipcode.Visibility = Visibility.Hidden;
                //if (Lead_Primary_Phone.Visibility == Visibility.Visible)
                //	Lead_Primary_Phone.Visibility = Visibility.Hidden;
                //if (Lead_Secondary_Phone.Visibility == Visibility.Visible)
                //	Lead_Secondary_Phone.Visibility = Visibility.Hidden;
                //if (Lead_Email_Address.Visibility == Visibility.Visible)
                //	Lead_Email_Address.Visibility = Visibility.Hidden;

            }

            return Enable;
        }

        private void SalesPersonInfoCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            _Lead.SalesPersonID = _ClaimContacts.SalesPersonID = (int)((DTO_Employee)ExistingContactInfoCombo.SelectedItem).EmployeeID;
            _MrnClaim.salesperson = (DTO_Employee)ExistingContactInfoCombo.SelectedItem;

            _ClaimContacts.SalesManagerID = s.EmployeesList.Find(x => x.EmployeeTypeID == ((DTO_LU_EmployeeType)s.EmployeeTypes.Find(y => y.EmployeeType == "Sales Manager")).EmployeeTypeID).EmployeeID;
        }
        private void PrevClaimBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextClaimBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void magneticRollersCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ExistingContactInfoCombo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (Claim != null)
                ExistingContactInfoCombo.DataContext = s.LeadsList.Find(x => x.LeadID == Claim.LeadID);
        }

        private void salesPersonIDComboBox1_SelectionChanged()
        {

        }
    }
    //public class CollectionViewSourceEnum
    //{
    //    static ServiceLayer s = ServiceLayer.getInstance();
    //    public string Name { get; set; }
    //    public CollectionViewSource MajorType { get; set; }
    //    public List<object> SourceData { get; set; }
    //    public Type DataType { get; set; }

    //    public CollectionViewSourceEnum()
    //    {
    //        Task.Run(async () =>
    //        {
    //            await s.GetAllClaims();
    //            await s.GetAllCustomers();
    //            await s.GetAllReferrers();
    //            await s.GetAllInsuranceCompanies();
    //            await s.GetLeadTypes();
    //            await s.GetAllLeads();
    //            await s.GetAllClaimStatuses();
    //            await s.GetAllEmployees();
    //            await s.GetAllAddresses();
    //            await s.GetAllClaimContacts();
    //            await s.GetLeadTypes();
    //            await s.GetAllCustomers();
    //            await s.GetAllScopes();
    //            await s.GetAllCallLogs();
    //            await s.GetAllCalendarData();
    //            await s.GetAllInvoices();
    //            await s.GetAllPayments();
    //            await s.GetAllPlanes();
    //            await s.GetAdjustmentResults();
    //            await s.GetAllAdjustments();
    //            await s.GetAllAdjusters();
    //            await s.GetAllInspections();
    //            await s.GetAllNewRoofs();
    //            await s.GetAllOrders();
    //            await s.GetAllOrderItems();


    //        });

    //        var CDS = new ClaimDataSet();

    //        CDS.ClaimViewSource.Source = s.ClaimsList;
    //        CDS.LU_LeadTypeViewSource.Source = s.LeadTypes;
    //        CDS.InsuranceCompanyViewSource.Source = s.InsuranceCompaniesList;
    //        CDS.CallLogViewSource.Source = s.CallLogsList;
    //        CDS.LeadViewSource.Source = s.LeadsList;
    //        CDS.CustomerViewSource.Source = s.CustomersList;
    //        CDS.ClaimStatusViewSource.Source = s.ClaimStatusList;
    //        CDS.EmployeeViewSource.Source = s.EmployeesList;
    //        CDS.AddressViewSource.Source = s.AddressesList;
    //        CDS.InsuranceCompanyViewSource.Source = s.InsuranceCompaniesList;
    //        CDS.ClaimContactsViewSource.Source = s.ClaimContactsList;
    //        CDS.ReferrerViewSource.Source = s.ReferrersList;
    //        CDS.ScopeViewSource.Source = s.ScopesList;
    //        CDS.CallLogViewSource.Source = s.CallLogsList;
    //        CDS.CalendarDataViewSource.Source = s.CalendarDataList;
    //        CDS.InvoiceViewSource.Source = s.InvoicesList;
    //        CDS.LU_AdjustmentResultViewSource.Source = s.AdjustmentResults;
    //        CDS.ClaimDocumentViewSource.Source = s.ClaimDocumentsList;
    //        CDS.AdjustmentViewSource.Source = s.AdjustmentsList;
    //        CDS.AdjusterViewSource.Source = s.AdjustersList;
    //        CDS.InspectionViewSource.Source = s.InspectionsList;
    //        CDS.PaymentViewSource.Source = s.PaymentsList;
    //        CDS.PlaneViewSource.Source = s.PlanesList;
    //        CDS.NewRoofViewSource.Source = s.NewRoofsList;
    //        CDS.OrderItemViewSource.Source = s.OrderItemsList;
    //        CDS.OrderViewSource.Source = s.OrdersList;


    //    }

    //}


    //public class ClaimDataSet : ObservableCollection<CollectionViewSourceEnum>
    //{
    //    public CollectionViewSource ClaimViewSource { get; set; }
    //    public CollectionViewSource LeadViewSource { get; set; }
    //    public CollectionViewSource CustomerViewSource { get; set; }
    //    public CollectionViewSource ClaimStatusViewSource { get; set; }
    //    public CollectionViewSource EmployeeViewSource { get; set; }
    //    public CollectionViewSource AddressViewSource { get; set; }
    //    public CollectionViewSource InsuranceCompanyViewSource { get; set; }
    //    public CollectionViewSource ClaimContactsViewSource { get; set; }
    //    public CollectionViewSource LU_LeadTypeViewSource { get; set; }
    //    public CollectionViewSource ReferrerViewSource { get; set; }
    //    public CollectionViewSource ScopeViewSource { get; set; }
    //    public CollectionViewSource CallLogViewSource { get; set; }
    //    public CollectionViewSource CalendarDataViewSource { get; set; }
    //    public CollectionViewSource InvoiceViewSource { get; set; }
    //    public CollectionViewSource LU_AdjustmentResultViewSource { get; set; }
    //    public CollectionViewSource ClaimDocumentViewSource { get; set; }
    //    public CollectionViewSource AdjustmentViewSource { get; set; }
    //    public CollectionViewSource AdjusterViewSource { get; set; }
    //    public CollectionViewSource InspectionViewSource { get; set; }
    //    public CollectionViewSource PaymentViewSource { get; set; }
    //    public CollectionViewSource PlaneViewSource { get; set; }
    //    public CollectionViewSource NewRoofViewSource { get; set; }
    //    public CollectionViewSource OrderItemViewSource { get; set; }
    //    public CollectionViewSource OrderViewSource { get; set; }



    //}
}


namespace MRNUIElements.DBActions
{
    public class Add
    {
        static ServiceLayer s = ServiceLayer.getInstance();

        public static async Task<object> AddItem(string objectToAddType, Object objectToAdd)
        {
            switch (objectToAddType)
            {
                case "Address":
                    {
                        await s.AddAddress((DTO_Address)objectToAdd);
                        return s.Address;
                    }
                case "Customer":
                    {
                        await s.AddCustomer((DTO_Customer)objectToAdd);
                        return s.Cust;
                    }
                case "Lead":
                    {
                        await s.AddLead((DTO_Lead)objectToAdd);
                        return s.Lead;
                    }
                case "Referrer":
                    {
                        await s.AddReferrer((DTO_Referrer)objectToAdd);
                        return s.Referrer;
                    }
                case "Inspection":
                    {
                        await s.AddInspection((DTO_Inspection)objectToAdd);
                        return s.Inspection;
                    }
                case "Claim":
                    {
                        await s.AddClaim((DTO_Claim)objectToAdd);
                        return s.Claim;
                    }
                case "Plane":
                    {
                        await s.AddPlane((DTO_Plane)objectToAdd);
                        return s.Plane;
                    }
                case "InspectionPhotos":
                    {
                        await s.AddClaimDocument((DTO_ClaimDocument)objectToAdd);
                        return s.ClaimDocument;
                    }
                case "Adjustment":
                    {
                        await s.AddAdjustment((DTO_Adjustment)objectToAdd);
                        return s.Adjustment;
                    }
                case "ClaimStatus":
                    {
                        await s.AddClaimStatus((DTO_ClaimStatus)objectToAdd);
                        return s.ClaimStatus;
                    }
                case "Salesperson":
                    {
                        await s.AddEmployee((DTO_Employee)objectToAdd);
                        return s.Employee;
                    }
                case "Contract":
                    {
                        await s.AddClaimDocument((DTO_ClaimDocument)objectToAdd);
                        return s.ClaimDocument;
                    }
                case "ClaimContact":
                    {
                        await s.AddAddress((DTO_Address)objectToAdd);
                        return s.Address;
                    }

                case "Invoice":
                    {
                        await s.AddInvoice((DTO_Invoice)objectToAdd);
                        return s.Invoice;
                    }
                case "Payment":
                    {
                        await s.AddPayment((DTO_Payment)objectToAdd);
                        return s.Payment;
                    }
                case "NewRoof":
                    {
                        await s.AddNewRoof((DTO_NewRoof)objectToAdd);
                        return s.NewRoof;
                    }

                default:
                    return objectToAdd;
            }
        }
        async Task<object> GetClaimData(DTO_Claim claim, List<object> claimData)
        {

            await s.GetClaimByClaimID(claim);
            claimData.Add(s.Claim);
            await s.GetCustomerByID(new DTO_Customer { CustomerID = s.Claim.CustomerID });
            claimData.Add(s.Cust);
            await s.GetLeadByLeadID(new DTO_Lead { LeadID = s.Claim.LeadID });
            claimData.Add(s.Lead);
            //await s.GetReferrerByID();
            await s.GetInspectionsByClaimID(s.Claim);
            if (s.InspectionsList.Count > 0)
                claimData.Add(s.InspectionsList.FindLast(x => x.ClaimID == s.Claim.ClaimID));
            await s.GetAddressByID(new DTO_Address { AddressID = s.Lead.AddressID });
            claimData.Add(s.Address);
            await s.GetPlanesByInspectionID(s.Inspection);
            claimData.Add(s.PlanesList);
            await s.GetClaimDocumentsByClaimID(s.Claim);
            claimData.Add(s.ClaimDocumentsList);
            await s.GetAdjustmentsByClaimID(s.Claim);
            claimData.Add(s.AdjustmentsList);
            await s.GetClaimStatusByClaimID(s.Claim);
            claimData.Add(s.ClaimStatusList);
            await s.GetEmployeeByID(new DTO_Employee { EmployeeID = s.Lead.SalesPersonID });
            claimData.Add(s.Employee);
            await s.GetInvoicesByClaimID(s.Claim);
            claimData.Add(s.InvoicesList);
            await s.GetPaymentsByClaimID(s.Claim);
            claimData.Add(s.PaymentsList);
            await s.GetNewRoofByClaimID(s.Claim);
            claimData.Add(s.NewRoof);

            return claimData;
        }


        Address AddAddress(Address address)
        {
            try
            {
                Task.Run(async () => await s.AddAddress(address));



            }
            catch (NullReferenceException nre)
            {
                return null;
            }
            return s.Address as Address;
        }

    }
}




















