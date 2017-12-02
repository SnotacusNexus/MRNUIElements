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
        static ServiceLayer s1 = ServiceLayer.getInstance();
        static MRNClaim MRNClaim = MRNClaim.getInstance();
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
        bool b = false;

        public CustomerAgreement()
        {



            InitializeComponent();

            leadTypeIDComboBox.ItemsSource = s1.LeadTypes;

        }

        public void SetContext()
        {
           knockerIDComboBox.ItemsSource = s1.EmployeesList.FindAll(x => x.EmployeeTypeID == 14);
          salesPersonIDComboBox.ItemsSource = s1.EmployeesList.FindAll(x => x.EmployeeTypeID == 13);
          supervisorIDComboBox.ItemsSource = s1.EmployeesList.FindAll(x => x.EmployeeTypeID == 10);
           salesManagerIDComboBox.ItemsSource = s1.EmployeesList.FindAll(x => x.EmployeeTypeID == 7);

        }

        private void CustomeerAgreement_Loaded(object sender, RoutedEventArgs e)
        {
            var cpp = new ClaimPickerPopUp();



            if (cpp.ShowDialog().Value == true)
            {
                Claim = cpp.Claim;
                carousel_Loaded(Claim, new RoutedEventArgs());
            }
            _Address = new Address();
            _Lead = new Lead();
            _Customer = new Customer();
            _Inspection = new Inspection();
            _Referrer = new Referrer();
            _ClaimContacts = new ClaimContacts();

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

            //  GetAllData();
            if (Claim != null)
            {

                //                   try
                //                   {
                //                       ClaimViewSource.Source = s1.ClaimsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                //                   }
                //                   catch (NullReferenceException nre) { }
                //                   try
                //                   {
                //                       CallLogViewSource.Source = s1.CallLogsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                //                   }
                //                   catch (NullReferenceException nre) { }
                //                   try { LeadGrid.DataContext = s1.LeadsList.FindAll(x => x.LeadID == Claim.LeadID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { CustomerGrid.DataContext = s1.CustomersList.FindAll(x => x.CustomerID == Claim.CustomerID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { ClaimGrid.DataContext = s1.ClaimStatusList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { EmployeeViewSource.Source = s1.EmployeesList.FindAll(x => x.EmployeeID == s1.ClaimContactsList.Find(y => y.ClaimID == Claim.ClaimID).SalesPersonID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { CustAddressGrid.DataContext = s1.AddressesList.FindAll(x => x.AddressID == Claim.PropertyID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { InsuranceCoGrid.DataContext = s1.InsuranceCompaniesList.FindAll(x => x.InsuranceCompanyID == Claim.InsuranceCompanyID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //         //          try { ClaimContactsGrid = s1.ClaimContactsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { leadTypeIDComboBox.DataContext = s1.LeadTypes.FindAll(x => x.LeadTypeID == s1.LeadsList.Find(y => y.LeadID == Claim.LeadID).LeadTypeID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { ReferrerGrid.DataContext = s1.ReferrersList.FindAll(x => x.ReferrerID == s1.LeadsList.Find(y => y.LeadID == Claim.LeadID).CreditToID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //         ///          try { ScopeGrid.DataContext = s1.ScopesList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { dTO_CallLogDataGrid.DataContext = s1.CallLogsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //       //            try { CalendarDataGrid.DataContext = s1.CalendarDataList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { dTO_InvoiceDataGrid.DataContext = s1.InvoicesList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { AdjustmentResultViewSource.Source = s1.AdjustmentResults.FindAll(x => x.AdjustmentResultID == s1.AdjustmentsList.Find(y => y.ClaimID == Claim.ClaimID).AdjustmentResultID); } catch (NullReferenceException nre) { }
                //      //             try { dTO_ClaimDocumentsGrid.DataContext = s1.ClaimDocumentsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //       //            try { dTO_AdjustmentGrid.DataContext = s1.AdjustmentsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //       //            try { dTO_AdjusterGrid.DataContext = s1.AdjustersList.FindAll(x => x.AdjusterID == s1.AdjustersList.Find(y => y.AdjusterID == s1.AdjustmentsList.Find(z => z.ClaimID == Claim.ClaimID).AdjusterID).AdjusterID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //      //             try { dTO_InspectionsGrid.DataContext = s1.InspectionsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { dTO_PaymentDataGrid.DataContext = s1.PaymentsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //   //                try { dTO_PlaneGrid.DataContext = s1.PlanesList.FindAll(x => x.InspectionID == s1.InspectionsList.Find(y => y.ClaimID == Claim.ClaimID).InspectionID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //  //                 try { dTO_NewRoofGrid.DataContext = s1.NewRoofsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //                   try { dTO_OrderItemDataGrid.DataContext = s1.OrderItemsList.FindAll(x => x.OrderID == s1.OrdersList.Find(y => y.ClaimID == Claim.ClaimID).OrderID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                ////                   try { dTO_OrderGrid.DataContext = s1.OrdersList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show(nre.ToString()); }
                //               }



                //               else
                //               {

                try
                {
                    try
                    {
                        ClaimViewSource.Source = s1.ClaimsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        leadTypeIDComboBox.ItemsSource = s1.LeadTypes;
                    }
                    catch (NullReferenceException nre) { }
                    try { dTO_InsuranceCompanyComboBox.ItemsSource = insuranceCompanyIDComboBox.ItemsSource = insco; } catch (NullReferenceException nre) { }
                    try
                    {
                        CallLogViewSource.Source = MRNClaim.cl = s1.CallLogsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        MRNClaim.Lead = s1.LeadsList.Find(x => x.LeadID == Claim.LeadID);
                        LeadViewSource.Source = s1.LeadsList.FindAll(x => x.LeadID == Claim.LeadID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        MRNClaim.c = s1.CustomersList.Find(x => x.CustomerID == Claim.CustomerID);
                        CustomerViewSource.Source = s1.CustomersList.FindAll(x => x.CustomerID == Claim.CustomerID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        MRNClaim.cs = s1.ClaimStatusList.FindAll(x => x.ClaimID == Claim.ClaimID);
                        ClaimStatusViewSource.Source = s1.ClaimStatusList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        MRNClaim.el = s1.EmployeesList.FindAll(x => x.EmployeeID == s1.ClaimContactsList.Find(y => y.ClaimID == Claim.ClaimID).SalesPersonID);
                        EmployeeViewSource.Source = s1.EmployeesList.FindAll(x => x.EmployeeID == s1.ClaimContactsList.Find(y => y.ClaimID == Claim.ClaimID).SalesPersonID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        MRNClaim.a = s1.AddressesList.Find(x => x.AddressID == Claim.PropertyID) == null ? s1.AddressesList.Find(x => x.AddressID == Claim.BillingID) : s1.AddressesList.Find(x => x.AddressID == Claim.PropertyID);
                        AddressViewSource.Source = s1.AddressesList.FindAll(x => x.AddressID == Claim.PropertyID) == null ? s1.AddressesList.FindAll(x => x.AddressID == Claim.BillingID) : s1.AddressesList.FindAll(x => x.AddressID == Claim.PropertyID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        MRNClaim.ic = s1.InsuranceCompaniesList.Find(x => x.InsuranceCompanyID == Claim.InsuranceCompanyID);
                        InsuranceCompanyViewSource.Source = s1.InsuranceCompaniesList.FindAll(x => x.InsuranceCompanyID == Claim.InsuranceCompanyID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        MRNClaim.cc = s1.ClaimContactsList.Find(x => x.ClaimID == Claim.ClaimID);
                        ClaimContactsViewSource.Source = s1.ClaimContactsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        LeadTypeViewSource.Source = s1.LeadTypes;
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        MRNClaim.r = s1.ReferrersList.Find(x => x.ReferrerID == s1.LeadsList.Find(y => y.LeadID == Claim.LeadID).CreditToID);
                        ReferrerViewSource.Source = s1.ReferrersList.FindAll(x => x.ReferrerID == s1.LeadsList.Find(y => y.LeadID == Claim.LeadID).CreditToID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        ScopeViewSource.Source = s1.ScopesList;
                        MRNClaim.finalScope = s1.ScopesList.Exists(x => x.ScopeTypeID > 2) ? s1.ScopesList.Find(x => x.ScopeTypeID > 2) : new DTO_Scope();
                        MRNClaim.origScope = s1.ScopesList.Exists(x => x.ScopeTypeID == 2) ? s1.ScopesList.Find(x => x.ScopeTypeID == 2) : new DTO_Scope();
                        MRNClaim.mrnestimate = s1.ScopesList.Exists(x => x.ScopeTypeID == 1) ? s1.ScopesList.Find(x => x.ScopeTypeID == 1) : new DTO_Scope();
                    }
                    catch (NullReferenceException nre) { }

                    try
                    {
                        CalendarDataViewSource.Source = MRNClaim.appts = s1.CalendarDataList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        InvoiceViewSource.Source = s1.InvoicesList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        AdjustmentResultViewSource.Source = s1.AdjustmentResults.FindAll(x => x.AdjustmentResultID == s1.AdjustmentsList.Find(y => y.ClaimID == Claim.ClaimID).AdjustmentResultID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        ClaimDocumentViewSource.Source = s1.ClaimDocumentsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        AdjustmentViewSource.Source = s1.AdjustmentsList.FindAll(x => x.ClaimID == Claim.ClaimID); ;
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        AdjusterViewSource.Source = s1.AdjustersList.FindAll(x => x.AdjusterID == s1.AdjustersList.Find(y => y.AdjusterID == s1.AdjustmentsList.Find(z => z.ClaimID == Claim.ClaimID).AdjusterID).AdjusterID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        InspectionViewSource.Source = s1.InspectionsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        PaymentViewSource.Source = s1.PaymentsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        PlaneViewSource.Source = s1.PlanesList.FindAll(x => x.InspectionID == s1.InspectionsList.Find(y => y.ClaimID == Claim.ClaimID).InspectionID);
                    }

                    catch (NullReferenceException nre) { }
                    try
                    {
                        NewRoofViewSource.Source = s1.NewRoofsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        OrderItemViewSource.Source = s1.OrderItemsList.FindAll(x => x.OrderID == s1.OrdersList.Find(y => y.ClaimID == Claim.ClaimID).OrderID);
                    }
                    catch (NullReferenceException nre) { }
                    try
                    {
                        OrderViewSource.Source = s1.OrdersList.FindAll(x => x.ClaimID == Claim.ClaimID);
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
            await s1.GetClaimDocumentsByClaimID(Claim);
            return s1.ClaimDocumentsList.FindAll(x => x.ClaimID == Claim.ClaimID && x.DocTypeID == 2);
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
            else foreach (var item in s1.ClaimDocumentsList)
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
            return s1.ClaimDocumentsList.Find(x => x.ClaimID == Claim.ClaimID && x.DocTypeID == _claimDocTypeID);

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
                    ClaimViewSource.Source = s1.ClaimsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                }
                catch (NullReferenceException nre) { }
                try
                {
                    CallLogViewSource.Source = s1.CallLogsList.FindAll(x => x.ClaimID == Claim.ClaimID);
                }
                catch (NullReferenceException nre) { }
                try { LeadViewSource.Source = s1.LeadsList.FindAll(x => x.LeadID == Claim.LeadID); } catch (NullReferenceException nre) { }
                try { CustomerViewSource.Source = s1.CustomersList.FindAll(x => x.CustomerID == Claim.CustomerID); } catch (NullReferenceException nre) { }
                try { ClaimStatusViewSource.Source = s1.ClaimStatusList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { EmployeeViewSource.Source = s1.EmployeesList.FindAll(x => x.EmployeeID == s1.ClaimContactsList.Find(y => y.ClaimID == Claim.ClaimID).SalesPersonID); } catch (NullReferenceException nre) { }
                try { AddressViewSource.Source = s1.AddressesList.FindAll(x => x.AddressID == Claim.PropertyID) == null ? s1.AddressesList.FindAll(x => x.AddressID == Claim.BillingID) : s1.AddressesList.FindAll(x => x.AddressID == Claim.PropertyID); } catch (NullReferenceException nre) { }
                try { InsuranceCompanyViewSource.Source = s1.InsuranceCompaniesList.FindAll(x => x.InsuranceCompanyID == Claim.InsuranceCompanyID); } catch (NullReferenceException nre) { }
                try { ClaimContactsViewSource.Source = s1.ClaimContactsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { LeadTypeViewSource.Source = s1.LeadTypes.FindAll(x => x.LeadTypeID == s1.LeadsList.Find(y => y.LeadID == Claim.LeadID).LeadTypeID); } catch (NullReferenceException nre) { }
                try { ReferrerViewSource.Source = s1.ReferrersList.FindAll(x => x.ReferrerID == s1.LeadsList.Find(y => y.LeadID == Claim.LeadID).CreditToID); } catch (NullReferenceException nre) { }
                try { ScopeViewSource.Source = s1.ScopesList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { CallLogViewSource.Source = s1.CallLogsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { CalendarDataViewSource.Source = s1.CalendarDataList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { InvoiceViewSource.Source = s1.InvoicesList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { AdjustmentResultViewSource.Source = s1.AdjustmentResults.FindAll(x => x.AdjustmentResultID == s1.AdjustmentsList.Find(y => y.ClaimID == Claim.ClaimID).AdjustmentResultID); } catch (NullReferenceException nre) { }
                try { ClaimDocumentViewSource.Source = s1.ClaimDocumentsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { AdjustmentViewSource.Source = s1.AdjustmentsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { AdjusterViewSource.Source = s1.AdjustersList.FindAll(x => x.AdjusterID == s1.AdjustersList.Find(y => y.AdjusterID == s1.AdjustmentsList.Find(z => z.ClaimID == Claim.ClaimID).AdjusterID).AdjusterID); } catch (NullReferenceException nre) { }
                try { InspectionViewSource.Source = s1.InspectionsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { PaymentViewSource.Source = s1.PaymentsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { PlaneViewSource.Source = s1.PlanesList.FindAll(x => x.InspectionID == s1.InspectionsList.Find(y => y.ClaimID == Claim.ClaimID).InspectionID); } catch (NullReferenceException nre) { }
                try { NewRoofViewSource.Source = s1.NewRoofsList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
                try { OrderItemViewSource.Source = s1.OrderItemsList.FindAll(x => x.OrderID == s1.OrdersList.Find(y => y.ClaimID == Claim.ClaimID).OrderID); } catch (NullReferenceException nre) { }
                try { OrderViewSource.Source = s1.OrdersList.FindAll(x => x.ClaimID == Claim.ClaimID); } catch (NullReferenceException nre) { }
            }
        }


        public ObservableCollection<System.Windows.Controls.Image> imgCollection { get; set; }



        async private void carousel_Loaded(object sender, RoutedEventArgs e)
        {


            await s1.GetAllClaimDocuments();
            imgCollection = new ObservableCollection<System.Windows.Controls.Image>();

            if (sender.GetType() == typeof(DTO_Claim))
            {


                //var sc = SynchronizationContext.Current;

                foreach (var item in s1.ClaimDocumentsList.FindAll(x => x.ClaimID == ((DTO_Claim)sender).ClaimID && x.DocTypeID == 2))
                {
                    var im = new System.Web.UI.WebControls.Image();
                    im.Height = 200;
                    im.Width = 200;



                    var uri = new Uri("http://" + item.FilePath + item.FileName + item.FileExt);

                    var bitmap = new BitmapImage(uri);

                    System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                    img.Source = bitmap;

                    
                    //var web = new System.Net.WebClient();
                    addImagesbutton_Click((string)uri.OriginalString, e);
                    ImageList.Add(im);
                    imgCollection.Add(img);
                    //var stream = new MemoryStream(await web.DownloadDataTaskAsync(imageaddress));
                    //     var bmp = new Bitmap(stream);
                    //listOfImgs.Add(bmp);
                    // carousel.Items.Add(bmp);

                }

                carousel.ItemsSource = imgCollection;
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
            #region OldAddButtonClick


            //    _Customer = new Customer();
            //    _Address = new Address();
            //    _Lead = new Lead();
            //    _Referrer = new Referrer();
            //    _Inspection = new Inspection();
            //    _ClaimContacts = new ClaimContacts();
            //    Claim = new DTO_Claim();
            //    try
            //    {
            //        try
            //        {
            //            if (string.IsNullOrEmpty(insuranceClaimNumberMaskedTextBox.Text))
            //                if (System.Windows.Forms.MessageBox.Show("This hasn't been Claimed yet. Are you sure you would like to add it to the list of active claims?", "What is going on here?!?", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes) ;


            //        }

            //        catch (NullReferenceException nre) { }
            //        try
            //        {
            //            _Customer.Suffix = suffixMaskedTextBox.Text;
            //        }
            //        catch (NullReferenceException nre) { }
            //        try { _Customer.FirstName = firstNameMaskedTextBox.Text; } catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show("Shit man you gotta put a first name! shooot?!?"); }
            //        try { _Customer.MiddleName = middleNameMaskedTextBox.Text; } catch (NullReferenceException nre) { }

            //        try
            //        {
            //            _Customer.LastName = lastNameMaskedTextBox.Text;
            //        }
            //        catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show("Shit man you gotta put a last name! shooot?!?"); }
            //        try
            //        {
            //            _Customer.MailPromos = mailPromosCheckBox.IsChecked.Value;
            //        }
            //        catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show("Shit man you gotta have a numba for these folks! shooot?!?"); }
            //        try
            //        {
            //            _Customer.PrimaryNumber = primaryNumberMaskedTextBox.Text;
            //        }
            //        catch (NullReferenceException nre) { }
            //        try { _Customer.SecondaryNumber = secondaryNumberMaskedTextBox.Text; } catch (NullReferenceException nre) { }
            //        try
            //        { _Customer.Email = emailMaskedTextBox.Text; }
            //        catch (NullReferenceException nre) { }

            //        try
            //        {
            //            Claim.ContractSigned = isSigned.IsChecked.Value;
            //        }
            //        catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show("Shit man it hasn't been that long since you signed this has it? shooot?!?"); }
            //        try
            //        {
            //            Claim.LossDate = lossDateDatePicker.SelectedDate.Value;
            //        }
            //        catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show("Shit man you gotta know when this happened! shooot?!?"); }
            //        try
            //        {
            //            Claim.IsOpen = isOpenCheckBox.IsChecked.Value;
            //        }
            //        catch (NullReferenceException nre) { }
            //        try { Claim.MortgageAccount = mortgageAccountMaskedTextBox.Text; } catch (NullReferenceException nre) { }
            //        try
            //        { Claim.MortgageCompany = mortgageCompanyMaskedTextBox.Text; }
            //        catch (NullReferenceException nre) { }
            //        try
            //        { Claim.InsuranceClaimNumber = insuranceClaimNumberMaskedTextBox.Text; }
            //        catch (NullReferenceException nre) { }

            //        try
            //        {
            //            _Lead.KnockerResponseID = (int)knockerIDComboBox.SelectedValue;
            //        }
            //        catch (NullReferenceException nre) { }
            //        try
            //        {
            //            _Lead.LeadTypeID = (int)leadTypeIDComboBox.SelectedIndex > -1 ? (int)leadTypeIDComboBox.SelectedIndex + 1 : -1;
            //        }
            //        catch (NullReferenceException nre) { System.Windows.Forms.MessageBox.Show("How did we find out about this job?"); }

            //        try { } catch (NullReferenceException nre) { }
            //        try
            //        { }
            //        catch (NullReferenceException nre) { }

            //        try
            //        {
            //            _Address._Address = addressMaskedTextBox.Text;

            //        }
            //        catch (NullReferenceException nre)
            //        {
            //            System.Windows.Forms.MessageBox.Show("Need to know where to go to do this job.");

            //        }
            //        try
            //        {
            //            _Address.Zip = zipMaskedTextBox.Text;

            //        }
            //        catch (NullReferenceException nre)
            //        {
            //            System.Windows.Forms.MessageBox.Show("Will ya give us a hint as to what zipcode we might be working in?");

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Windows.Forms.MessageBox.Show("Ok you just turn right around and fix that shit right now!");
            //        return;
            //    }

            //    try
            //    {
            //        if (s1.AddressesList.Exists(x => x.Address == _Address._Address && x.Zip == _Address.Zip))
            //            System.Windows.Forms.MessageBox.Show("This address already exists in database.");
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //    try
            //    {
            //        await Task.Run(async () => await s1.AddCustomer(_Customer));

            //        if (s1.Cust.Message == null)
            //            _Lead.CustomerID = _ClaimContacts.CustomerID = Claim.CustomerID = _Address.CustomerID = _Customer.CustomerID = s1.Cust.CustomerID;
            //    }
            //    catch (Exception ex)
            //    {
            //        return;
            //    }
            //    try { await s1.AddAddress(_Address); } catch (Exception ex) { return; }

            //    if (s1.Address.Message == null)
            //    {
            //        _Address = (Address)s1.Address;

            //        addressIDIntegerTextBox.Value = (long)(Claim.BillingID = Claim.PropertyID = _Lead.AddressID = _Address.AddressID);




            //    }

            //    if (leadTypeIDComboBox.SelectedIndex != 4)
            //        _Referrer = (Referrer)GetClaimReferrer((GetReferrerType(Claim)));
            //    try
            //    {
            //        await s1.AddReferrer(ConvertToReferrer(_Referrer));
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //    //await s1.AddReferrer((DTO_Referrer)ReferrerViewSource.Source);
            //    try
            //    {
            //        _ClaimContacts.SalesPersonID = _Lead.SalesPersonID = (int)salesPersonIDComboBox.SelectedValue;
            //    }
            //    catch (NullReferenceException nre) { }
            //    creditToIDComboBox.SelectedValue = _ClaimContacts.KnockerID = _Lead.CreditToID = s1.Referrer.ReferrerID;
            //    ReferrerGrid.DataContext = s1.Referrer;
            //    try
            //    {
            //        await s1.AddLead(_Lead);
            //    }
            //    catch (Exception)
            //    {


            //    }
            //    try
            //    {
            //        if (s1.Lead.Message == null)
            //        {
            //            _Lead = s1.Lead as Lead;
            //            Claim.LeadID = _Lead.LeadID;

            //        }
            //    }
            //    catch (Exception)
            //    {

            //    }


            //    await s1.AddInspection((DTO_Inspection)InspectionViewSource.Source);
            //    var i = new List<DTO_Inspection>();
            //    i.Add(s1.Inspection);
            //    InspectionViewSource.Source = i;

            //    await s1.AddClaim((DTO_Claim)ClaimViewSource.Source);
            //    if (s1.Claim.Message == null)
            //        System.Windows.Forms.MessageBox.Show("Success - Test - " + s1.Claim.ClaimID.ToString() + " is the ClaimID Associated with your Claim.");

            #endregion

            await AddClaim();

        }
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
                referrer.MailingAddress = s1.AddressesList.Find(x => x.CustomerID == ((DTO_Customer)o).CustomerID).Address;
                referrer.Suffix = ((DTO_Customer)o).Suffix;
                referrer.ReferrerID = ((DTO_Customer)o).CustomerID;
                referrer.Zip = s1.AddressesList.Find(x => x.CustomerID == ((DTO_Customer)o).CustomerID).Zip;

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
                return s1.EmployeesList.Find(y => y.EmployeeID == (s1.LeadsList.Find(x => x.LeadID == Claim.LeadID).CreditToID));
            else if (type.GetType() == typeof(DTO_Employee))
                return s1.CustomersList.Find(y => y.CustomerID == (s1.LeadsList.Find(x => x.LeadID == Claim.LeadID).CreditToID));
            else if (type.GetType() == typeof(DTO_Employee))
                return s1.ReferrersList.Find(y => y.ReferrerID == (s1.LeadsList.Find(x => x.LeadID == Claim.LeadID).CreditToID));
            else
                return null;
        }

        Type GetReferrerType(DTO_Claim claim)
        {
            var lead = s1.LeadsList.Find(x => x.LeadID == claim.LeadID);
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

            _ClaimContacts.SalesManagerID = s1.EmployeesList.Find(x => x.EmployeeTypeID == ((DTO_LU_EmployeeType)s1.EmployeeTypes.Find(y => y.EmployeeType == "Sales Manager")).EmployeeTypeID).EmployeeID;
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
                ExistingContactInfoCombo.DataContext = s1.LeadsList.Find(x => x.LeadID == Claim.LeadID);
        }

        private void salesPersonIDComboBox1_SelectionChanged()
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public void RefreshData()
        {
            Task.Run(async () =>
            {
                await s1.GetAllClaims();
                await s1.GetAllLeads();
                await s1.GetAllClaimContacts();
                await s1.GetAllCustomers();
                await s1.GetAllEmployees();
            });

        }

        async Task<bool> AddClaimContacts(DTO_Claim claim)
        {

            RefreshData();
            DTO_ClaimContacts cc = new DTO_ClaimContacts();
            try
            {
                if (s1.ClaimContactsList.Exists(x => x.ClaimID == claim.ClaimID))
                {
                    cc = s1.ClaimContactsList.Find(x => x.ClaimID == claim.ClaimID);


                    var l = s1.LeadsList.Find(x => x.LeadID == claim.LeadID);
                    cc.CustomerID = s1.CustomersList.Find(x => x.CustomerID == claim.CustomerID).CustomerID;
                    cc.SalesPersonID = (int)salesPersonIDComboBox.SelectedValue;
                    cc.SalesManagerID = 0;
                    cc.AdjusterID = 0;
                    cc.KnockerID = ((DTO_Employee)knockerIDComboBox.SelectedItem).EmployeeID;
                    cc.SupervisorID = ((DTO_Employee)supervisorIDComboBox.SelectedItem).EmployeeID;

                    await s1.UpdateClaimContacts(cc);

                }
                else
                {
                    var l = s1.LeadsList.Find(x => x.LeadID == claim.LeadID);
                    cc.CustomerID = s1.CustomersList.Find(x => x.CustomerID == claim.CustomerID).CustomerID;
                    cc.SalesPersonID = (int)salesPersonIDComboBox.SelectedValue;
                    cc.SalesManagerID = 0;
                    cc.AdjusterID = 0;
                    cc.KnockerID = ((DTO_Employee)knockerIDComboBox.SelectedItem).EmployeeID;
                    cc.SupervisorID = ((DTO_Employee)supervisorIDComboBox.SelectedItem).EmployeeID;

                    await s1.AddClaimContacts(cc);
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }


        async Task<int> AddClaim()
        {

            if (s1.Claim != null)
                s1.Claim = null;
            DTO_Claim claim = new DTO_Claim();

            claim.BillingID=_Address.AddressID;
            claim.PropertyID =_Address.AddressID;
            claim.LeadID = await AddLead();
            claim.CustomerID = _Lead.CustomerID;
            try
            {
                claim.InsuranceClaimNumber = insuranceClaimNumberMaskedTextBox.Text;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Claim Isn't Claimed!");
            }
            claim.InsuranceCompanyID = ((DTO_InsuranceCompany)insuranceCompanyIDComboBox.SelectedItem).InsuranceCompanyID;


            if(!string.IsNullOrEmpty(mortgageAccountMaskedTextBox.Text))
            claim.MortgageAccount = mortgageAccountMaskedTextBox.Text;
            if (!string.IsNullOrEmpty(mortgageCompanyMaskedTextBox.Text))
              claim.MortgageCompany = mortgageCompanyMaskedTextBox.Text;
            claim.LossDate = lossDateDatePicker.SelectedDate.Value;
            claim.IsOpen = isOpenCheckBox.IsChecked.Value;
            claim.ContractSigned = isSigned.IsChecked.Value;
            try
            {
                await s1.AddClaim(claim);
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(),"Error Adding Claim",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error,System.Windows.Forms.MessageBoxDefaultButton.Button1);

            }
            finally
            {
                Claim = s1.Claim;
            }


            return s1.Claim.ClaimID;
        }


        async private Task<int> AddLead()
        {
            if (s1.Lead != null)
                s1.Lead = null;
            DTO_Lead lead = new DTO_Lead();
            try
            {
            lead.LeadTypeID = ((DTO_LU_LeadType)leadTypeIDComboBox.SelectedItem).LeadTypeID;//LeadTypeID
            lead.KnockerResponseID = ((DTO_LU_KnockResponseType)knockerResponseIDComboBox.SelectedItem).KnockResponseTypeID;//KnockerResponseID
            lead.SalesPersonID = ((DTO_Employee)salesPersonIDComboBox.SelectedItem).EmployeeID;//SalesPersonID
                lead.AddressID = await AddAddress();// AddressID;//AddressID
            lead.LeadDate = leadDateDatePicker.SelectedDate.Value;//LeadDate
            lead.CustomerID = _Customer.CustomerID;//CustomerID
            _Lead.CreditToID = lead.CreditToID = await setCreditToIDContext(((DTO_LU_LeadType)leadTypeIDComboBox.SelectedItem).LeadTypeID);//CreditToID=>getCreditToID;
            lead.Temperature = "W";//Temperature
            }
            catch (Exception ex) {

            }
            finally
            {
                await s1.AddLead(lead);
                if(s1.Lead.Message == null)
                {
                    _Lead = (Lead)s1.Lead;
                }
            }            
            return s1.Lead.LeadID;
        }

        async private Task<int> AddReferrer()
        {
            if (s1.Referrer != null)
                s1.Referrer = null;

            DTO_Referrer referrer = new DTO_Referrer();
            try
            {
                if (!string.IsNullOrEmpty(firstNameMaskedTextBox1.Text))
                    referrer.FirstName = firstNameMaskedTextBox1.Text;
                if (!string.IsNullOrEmpty(lastNameMaskedTextBox1.Text))
                    referrer.LastName = lastNameMaskedTextBox1.Text;
                if (!string.IsNullOrEmpty(mailingAddressMaskedTextBox.Text))
                    referrer.MailingAddress = mailingAddressMaskedTextBox.Text;
                if (!string.IsNullOrEmpty(suffixMaskedTextBox1.Text))
                    referrer.Suffix = suffixMaskedTextBox1.Text;
                if (!string.IsNullOrEmpty(zipMaskedTextBox1.Text))
                    referrer.Zip = zipMaskedTextBox1.Text;
                if (!string.IsNullOrEmpty(cellPhoneMaskedTextBox.Text))
                    referrer.CellPhone = cellPhoneMaskedTextBox.Text;
                if (!string.IsNullOrEmpty(emailMaskedTextBox1.Text))
                    referrer.Email = emailMaskedTextBox1.Text;

            }
            catch (Exception)
            {

                System.Windows.Forms.MessageBox.Show("Complete Referrer Info");
            }
            finally
            {
                await s1.AddReferrer(referrer);
                if (s1.Referrer.Message == null)
                {
                    _Lead.CreditToID = s1.Referrer.ReferrerID;
                    _Referrer = (Referrer)s1.Referrer;
                    ExistingContactInfoCombo.Text = _Referrer.ToString();
                }

            }
            return s1.Referrer.ReferrerID;
        }
        async private Task<int> setCreditToIDContext(int leadLeadTypeID)
        {
            

            switch (leadLeadTypeID)
            {
                case 1:
                    {




                        return ((DTO_Employee)ExistingContactInfoCombo.SelectedItem).EmployeeID;


                    }
                case 2:
                    {
                        return await AddReferrer();

                    }
                case 3:
                    {


                        return ((DTO_Customer)ExistingContactInfoCombo.SelectedItem).CustomerID;
                    }
                case 4:
                    {


                        return 0;
                    }
                default:
                    {




                        return ((DTO_Employee)ExistingContactInfoCombo.SelectedItem).EmployeeID;

                    }
            }

         
        }

        async private Task<int> AddAddress()
        {
            if (s1.Address != null)
                s1.Address = null;
            DTO_Address address = new DTO_Address();
            address.Address = addressMaskedTextBox.Text;
            address.Zip = zipMaskedTextBox.Text;
            address.CustomerID = (await AddCustomer());

            _Address = (Address)s1.Address;
            return s1.Address.AddressID;

        }


        async private Task<int> AddCustomer()
        {
            if (s1.Cust != null)
                s1.Cust = null;
            DTO_Customer customer = new DTO_Customer();
            try
            {

                customer.FirstName = firstNameMaskedTextBox.Text;
                if (!string.IsNullOrEmpty(middleNameMaskedTextBox.Text))
                    customer.MiddleName = middleNameMaskedTextBox.Text;
                customer.LastName = lastNameMaskedTextBox.Text;
                if (!string.IsNullOrEmpty(suffixMaskedTextBox.Text))
                    customer.Suffix = suffixMaskedTextBox.Text;
                customer.PrimaryNumber = primaryNumberMaskedTextBox.Text;
                customer.MailPromos = mailPromosCheckBox.IsChecked.Value;
                if (!string.IsNullOrEmpty(secondaryNumberMaskedTextBox.Text))
                    customer.SecondaryNumber = secondaryNumberMaskedTextBox.Text;
                if (!string.IsNullOrEmpty(emailMaskedTextBox.Text))
                    customer.Email = emailMaskedTextBox.Text;
                await s1.AddCustomer(customer);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Somebody aint got right stuff in their box(s)-- with enuf time i'd write some code that would tell you where this failure occured but im in a hurry so figure it out youself. jk .. but not really","A Fucking Error Occured", System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
            }
            _Customer = (Customer)s1.Cust;
            return s1.Cust.CustomerID;
        }

        private void leadTypeIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((DTO_LU_LeadType)leadTypeIDComboBox.SelectedItem).LeadTypeID)
            {
                case 1:
                    {


                        ExistingContactInfoCombo.ItemsSource = s1.EmployeesList.Where(x => x.EmployeeTypeID == 14);

                        break;

                    }
                case 2:
                    {


                        ContactInfoDisplay(true);

                        if (ReferrerGrid.Visibility != Visibility.Visible)
                            ReferrerGrid.Visibility = Visibility.Visible;
                        ExistingContactInfoCombo.ItemsSource = s1.ReferrersList;
                        break;
                    }
                case 3:
                    {
                        ContactLookupDisplay(true);
                        ContactInfoDisplay(true);

                        ExistingContactInfoCombo.ItemsSource = s1.CustomersList;

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

                        ExistingContactInfoCombo.ItemsSource = s1.EmployeesList.Where(x => x.EmployeeTypeID == 13);

                        break;
                    }

            } //sets if to look up info from referrer

        }
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
    //            await s1.GetAllClaims();
    //            await s1.GetAllCustomers();
    //            await s1.GetAllReferrers();
    //            await s1.GetAllInsuranceCompanies();
    //            await s1.GetLeadTypes();
    //            await s1.GetAllLeads();
    //            await s1.GetAllClaimStatuses();
    //            await s1.GetAllEmployees();
    //            await s1.GetAllAddresses();
    //            await s1.GetAllClaimContacts();
    //            await s1.GetLeadTypes();
    //            await s1.GetAllCustomers();
    //            await s1.GetAllScopes();
    //            await s1.GetAllCallLogs();
    //            await s1.GetAllCalendarData();
    //            await s1.GetAllInvoices();
    //            await s1.GetAllPayments();
    //            await s1.GetAllPlanes();
    //            await s1.GetAdjustmentResults();
    //            await s1.GetAllAdjustments();
    //            await s1.GetAllAdjusters();
    //            await s1.GetAllInspections();
    //            await s1.GetAllNewRoofs();
    //            await s1.GetAllOrders();
    //            await s1.GetAllOrderItems();


    //        });

    //        var CDS = new ClaimDataSet();

    //        CDS.ClaimViewSource.Source = s1.ClaimsList;
    //        CDS.LU_LeadTypeViewSource.Source = s1.LeadTypes;
    //        CDS.InsuranceCompanyViewSource.Source = s1.InsuranceCompaniesList;
    //        CDS.CallLogViewSource.Source = s1.CallLogsList;
    //        CDS.LeadViewSource.Source = s1.LeadsList;
    //        CDS.CustomerViewSource.Source = s1.CustomersList;
    //        CDS.ClaimStatusViewSource.Source = s1.ClaimStatusList;
    //        CDS.EmployeeViewSource.Source = s1.EmployeesList;
    //        CDS.AddressViewSource.Source = s1.AddressesList;
    //        CDS.InsuranceCompanyViewSource.Source = s1.InsuranceCompaniesList;
    //        CDS.ClaimContactsViewSource.Source = s1.ClaimContactsList;
    //        CDS.ReferrerViewSource.Source = s1.ReferrersList;
    //        CDS.ScopeViewSource.Source = s1.ScopesList;
    //        CDS.CallLogViewSource.Source = s1.CallLogsList;
    //        CDS.CalendarDataViewSource.Source = s1.CalendarDataList;
    //        CDS.InvoiceViewSource.Source = s1.InvoicesList;
    //        CDS.LU_AdjustmentResultViewSource.Source = s1.AdjustmentResults;
    //        CDS.ClaimDocumentViewSource.Source = s1.ClaimDocumentsList;
    //        CDS.AdjustmentViewSource.Source = s1.AdjustmentsList;
    //        CDS.AdjusterViewSource.Source = s1.AdjustersList;
    //        CDS.InspectionViewSource.Source = s1.InspectionsList;
    //        CDS.PaymentViewSource.Source = s1.PaymentsList;
    //        CDS.PlaneViewSource.Source = s1.PlanesList;
    //        CDS.NewRoofViewSource.Source = s1.NewRoofsList;
    //        CDS.OrderItemViewSource.Source = s1.OrderItemsList;
    //        CDS.OrderViewSource.Source = s1.OrdersList;


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
        static ServiceLayer s1 = ServiceLayer.getInstance();

        public static async Task<object> AddItem(string objectToAddType, Object objectToAdd)
        {
            switch (objectToAddType)
            {
                case "Address":
                    {
                        await s1.AddAddress((DTO_Address)objectToAdd);
                        return s1.Address;
                    }
                case "Customer":
                    {
                        await s1.AddCustomer((DTO_Customer)objectToAdd);
                        return s1.Cust;
                    }
                case "Lead":
                    {
                        await s1.AddLead((DTO_Lead)objectToAdd);
                        return s1.Lead;
                    }
                case "Referrer":
                    {
                        await s1.AddReferrer((DTO_Referrer)objectToAdd);
                        return s1.Referrer;
                    }
                case "Inspection":
                    {
                        await s1.AddInspection((DTO_Inspection)objectToAdd);
                        return s1.Inspection;
                    }
                case "Claim":
                    {
                        await s1.AddClaim((DTO_Claim)objectToAdd);
                        return s1.Claim;
                    }
                case "Plane":
                    {
                        await s1.AddPlane((DTO_Plane)objectToAdd);
                        return s1.Plane;
                    }
                case "InspectionPhotos":
                    {
                        await s1.AddClaimDocument((DTO_ClaimDocument)objectToAdd);
                        return s1.ClaimDocument;
                    }
                case "Adjustment":
                    {
                        await s1.AddAdjustment((DTO_Adjustment)objectToAdd);
                        return s1.Adjustment;
                    }
                case "ClaimStatus":
                    {
                        await s1.AddClaimStatus((DTO_ClaimStatus)objectToAdd);
                        return s1.ClaimStatus;
                    }
                case "Salesperson":
                    {
                        await s1.AddEmployee((DTO_Employee)objectToAdd);
                        return s1.Employee;
                    }
                case "Contract":
                    {
                        await s1.AddClaimDocument((DTO_ClaimDocument)objectToAdd);
                        return s1.ClaimDocument;
                    }
                case "ClaimContact":
                    {
                        await s1.AddAddress((DTO_Address)objectToAdd);
                        return s1.Address;
                    }

                case "Invoice":
                    {
                        await s1.AddInvoice((DTO_Invoice)objectToAdd);
                        return s1.Invoice;
                    }
                case "Payment":
                    {
                        await s1.AddPayment((DTO_Payment)objectToAdd);
                        return s1.Payment;
                    }
                case "NewRoof":
                    {
                        await s1.AddNewRoof((DTO_NewRoof)objectToAdd);
                        return s1.NewRoof;
                    }

                default:
                    return objectToAdd;
            }
        }
        async Task<object> GetClaimData(DTO_Claim claim, List<object> claimData)
        {

            await s1.GetClaimByClaimID(claim);
            claimData.Add(s1.Claim);
            await s1.GetCustomerByID(new DTO_Customer { CustomerID = s1.Claim.CustomerID });
            claimData.Add(s1.Cust);
            await s1.GetLeadByLeadID(new DTO_Lead { LeadID = s1.Claim.LeadID });
            claimData.Add(s1.Lead);
            //await s1.GetReferrerByID();
            await s1.GetInspectionsByClaimID(s1.Claim);
            if (s1.InspectionsList.Count > 0)
                claimData.Add(s1.InspectionsList.FindLast(x => x.ClaimID == s1.Claim.ClaimID));
            await s1.GetAddressByID(new DTO_Address { AddressID = s1.Lead.AddressID });
            claimData.Add(s1.Address);
            await s1.GetPlanesByInspectionID(s1.Inspection);
            claimData.Add(s1.PlanesList);
            await s1.GetClaimDocumentsByClaimID(s1.Claim);
            claimData.Add(s1.ClaimDocumentsList);
            await s1.GetAdjustmentsByClaimID(s1.Claim);
            claimData.Add(s1.AdjustmentsList);
            await s1.GetClaimStatusByClaimID(s1.Claim);
            claimData.Add(s1.ClaimStatusList);
            await s1.GetEmployeeByID(new DTO_Employee { EmployeeID = s1.Lead.SalesPersonID });
            claimData.Add(s1.Employee);
            await s1.GetInvoicesByClaimID(s1.Claim);
            claimData.Add(s1.InvoicesList);
            await s1.GetPaymentsByClaimID(s1.Claim);
            claimData.Add(s1.PaymentsList);
            await s1.GetNewRoofByClaimID(s1.Claim);
            claimData.Add(s1.NewRoof);

            return claimData;
        }


        Address AddAddress(Address address)
        {
            try
            {
                Task.Run(async () => await s1.AddAddress(address));



            }
            catch (NullReferenceException nre)
            {
                return null;
            }
            return s1.Address as Address;
        }

    }
}




















