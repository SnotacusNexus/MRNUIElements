using MRNUIElements.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MRNNexus_Model;
using System.Windows;
using System.IO;
using System.Windows.Media;
using System.Collections.ObjectModel;
using MRNNexus_Model;
using static MRNUIElements.PaymentEntryPage;
using static MRNUIElements.InvoicePage;
using MRNUIElements.Controllers.Collection;
using System.Threading;
using System.Windows.Controls;
using System.Net;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Forms.Tools;

namespace MRNUIElements
{
    public partial class Form1 : Form
    {
        static Frame F;
        static GetClaimsPage G;
        static ObservableCollection<DTO_ClaimDocument> CDC;

        static ObservableCollection<DTO_ClaimDocument> ClaimDocsCollection = new ObservableCollection<DTO_ClaimDocument>();
        public static DTO_Payment payment = new DTO_Payment();
        public static DTO_Invoice invoice = new DTO_Invoice();
        public static List<DTO_Invoice> InvoiceList = new List<DTO_Invoice>();

        public static string FullFilePath { get; set; }
        public ClaimData ClaimData { get; set; }
        public static int ClaimDocTypeID { get; set; }
        public bool EditData { get; set; }
        public static string statusText { get; set; }

        public static readonly DependencyProperty statusTextProperty = DependencyProperty.Register("statusText", typeof(string), typeof(GetClaimsPage), new UIPropertyMetadata(string.Empty));
        public static DTO_Claim _claim { get; set; }
        private static List<int> ClaimDocPresent = new List<int>();
        private static List<System.Windows.Controls.Button> ButtonList = new List<System.Windows.Controls.Button>();
        private readonly SynchronizationContext synchronizationContext;
        private DateTime previousTime = DateTime.Now;
        private DTO_Lead l { get; set; }
        private DTO_Customer c { get; set; }
        private DTO_Employee sp { get; set; }
        private DTO_Employee k { get; set; }
        private DTO_Referrer r { get; set; }
        private DTO_Inspection i { get; set; }
        private DTO_Claim cl { get; set; }
        private DTO_ClaimContacts cc { get; set; }
        private DTO_Address a { get; set; }
        private DTO_InsuranceCompany ins { get; set; }
        private DTO_Adjuster adj { get; set; }
        private DTO_Adjustment adjmnt { get; set; }
        private DTO_CalendarData caldata { get; set; }
        private DTO_Scope scp { get; set; }
        private List<DTO_Payment> claimPayments { get; set; }
        private List<DTO_Invoice> claimInvoices { get; set; }

        private DTO_ClaimVendor claimVendor { get; set; }
        static List<string> FileNames = new List<string>();
        static ServiceLayer s1 = ServiceLayer.getInstance();
        public Form1()
        {
            InitializeComponent();



            var cpp = new ClaimPickerPopUp();
            if ((bool)cpp.ShowDialog())
                _claim = cpp.Claim;
            else System.Windows.Forms.MessageBox.Show("WTF");

            //Get list of paths to images to download

            Init();
        }
        private async void Init()
        {
            //	await s1.GetAllClaimDocuments();
            //await UpdateClaimDocumentsLists();

            //	var a = new ClaimUtilities.ClaimDataService.AccessableClaim();
            //	await a.joinTables(s1.OpenClaimsList, s1.LoggedInEmployee);
            backgroundWorker1.RunWorkerAsync();


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
                return s1.EmployeesList.Find(y => y.EmployeeID == (s1.LeadsList.Find(x => x.LeadID == _claim.LeadID).CreditToID));
            else if (type.GetType() == typeof(DTO_Employee))
                return s1.CustomersList.Find(y => y.CustomerID == (s1.LeadsList.Find(x => x.LeadID == _claim.LeadID).CreditToID));
            else if (type.GetType() == typeof(DTO_Employee))
                return s1.ReferrersList.Find(y => y.ReferrerID == (s1.LeadsList.Find(x => x.LeadID == _claim.LeadID).CreditToID));
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

        public static Frame getInstanceg()
        {
            if (F == null)
                return new Frame();

            return F;
        }
        public static GetClaimsPage getInstanceH()
        {
            if (G == null)
                return new GetClaimsPage();
            return G;
        }
        public static ObservableCollection<DTO_ClaimDocument> getCollectionInstance()
        {
            if (CDC == null)
                return new ObservableCollection<DTO_ClaimDocument>();
            else
                return CDC;
        }
        public static int SetPaymentTypeID(int docTypeID)
        {
            switch (docTypeID)
            {
                case 13:
                    {


                        return 1;
                    }
                case 14:
                    {

                        return 5;
                    }
                case 15:
                    {


                        return 3;
                    }
                case 16:
                    {

                        return 2;
                    }
                default:
                    {


                        return 4;
                    }
            }
        }
        private void LogOut(object sender, RoutedEventArgs e)
        {


        }
        private void exteriorDamageCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void qualityControlCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void secondaryNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void secondaryNumberMaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        #region Problem Free Areas
        static string Filter(int docTypeID)
        {
            switch (docTypeID)
            {
                case 2:
                    return "All Image Types (*.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png) | *.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png";

                default:
                    return "All Image Types (*.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png) | *.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png | All Document Types (*.pdf;*.doc;*.docx;*.txt;*.xml) | *.pdf;*.doc;*.docx;*.txt;*.xml| All File Types(*.*) | *.*";

            }
        }

        Stream stream, stream2;
        internal bool ReadyToUpdate;

        async void ViewDocument(string str, string str2 = null)
        {

            if (image.Visible == true)
                image.Visible = false;
            //  pdfDocumentView1.Visible = true;

            try
            {
                var web = new System.Net.WebClient();
                stream = new MemoryStream(await web.DownloadDataTaskAsync(str));


                while (stream == null)
                    if (MainWindow.getBusyIndicator().Visibility == Visibility.Collapsed)
                        MainWindow.getBusyIndicator().Visibility = Visibility.Visible;

                //      pdfDocumentView1.Load(stream);
                MainWindow.getBusyIndicator().Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.ToString());
                throw;
            }



        }
        async static Task<bool> GetDocuments()
        {
            await s1.GetClaimDocumentsByClaimID(_claim);
            return true;
        }
        void DisplayRecordedClaimDocuments(DTO_ClaimDocument _claimDocument, DTO_ClaimDocument _claimDocument2 = null)
        {

            MainWindow.getBusyIndicator().Visibility = Visibility.Visible;

            if (_claimDocument != null)
                if (_claimDocument.FileExt == ".pdf" || _claimDocument.FileExt == ".PDF")
                {

                    ViewDocument("http://" + _claimDocument.FilePath + _claimDocument.FileName + _claimDocument.FileExt);
                }
                else if (_claimDocument.FileExt == ".jepg" || _claimDocument.FileExt == ".JPEG" || _claimDocument.FileExt == ".jpg" || _claimDocument.FileExt == ".png" || _claimDocument.FileExt == ".bmp" || _claimDocument.FileExt == ".JPG" || _claimDocument.FileExt == ".BMP" || _claimDocument.FileExt == ".PNG")
                {
                    DisplayImage("http://" + _claimDocument.FilePath + _claimDocument.FileName + _claimDocument.FileExt);
                }

            if (MainWindow.getBusyIndicator().Visibility == Visibility.Visible)
                MainWindow.getBusyIndicator().Visibility = Visibility.Collapsed;
        }
        public async void DisplayImage(string str)
        {
            try
            {
                //     if (pdfDocumentView1.Visible == true)
                //        pdfDocumentView1.Visible = false;
                image.Visible = true;
                var web = new System.Net.WebClient();


                stream = new MemoryStream(await web.DownloadDataTaskAsync(str));

                image.Image = (Bitmap)new ImageSourceConverter().ConvertFromString(str);
                MainWindow.getBusyIndicator().Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {

                throw;
            }

        }



        static DTO_ClaimDocument GetClaimDocument(DTO_Claim _claim, int _claimDocTypeID)
        {
            return s1.ClaimDocumentsList.Find(x => x.ClaimID == _claim.ClaimID && x.DocTypeID == _claimDocTypeID);

        }

        async static Task<bool> UpdateClaimDocumentsLists()
        {
            await s1.GetAllClaimDocuments();

            ObservableCollection<DTO_ClaimDocument> collection = new ObservableCollection<DTO_ClaimDocument>();

            if (s1.ClaimDocumentsList != null || s1.ClaimDocumentsList.Count > 0)
                s1.ClaimDocumentsList.Clear();
            await s1.GetAllClaimDocuments();
            while (s1.ClaimDocumentsList == null)
                MainWindow.getBusyIndicator().Visibility = Visibility.Visible;
            foreach (var a in s1.ClaimDocumentsList)
                collection.Add(a);
            getCollectionInstance();
            if (ClaimDocsCollection.Count > 0)
                ClaimDocsCollection.Clear();


            ClaimDocsCollection = collection;
            return true;

        }



        async Task<DTO_ClaimDocument> ConfirmDocUpload(List<object> a)
        {
            DTO_ClaimDocument c = (DTO_ClaimDocument)a[0];
            DTO_ClaimStatus d = (DTO_ClaimStatus)a[1];
            await UpdateClaimDocumentsLists();
            if (s1.ClaimDocumentsList.Find(z => z.ClaimID == c.ClaimID && z.DocTypeID == c.DocTypeID).DocumentDate == c.DocumentDate)
            {
                s1.ClaimDocumentsList.Add(c);
                //	updateUI();
                return c;
            }
            return new DTO_ClaimDocument();
        }

        async static private Task<List<object>> UploadImage()
        {
            List<object> objlist = new List<object>();
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            if (ClaimDocTypeID == 2)
                fileDialog.Multiselect = true;
            else
                fileDialog.Multiselect = false;
            fileDialog.Title = ((DTO_LU_ClaimDocumentType)s1.ClaimDocTypes[ClaimDocTypeID]).ClaimDocumentType + " Import Tool";
            fileDialog.Filter = Filter(ClaimDocTypeID);
            DTO_ClaimDocument b;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (fileDialog.FileNames.Count() > 0)
                    {
                        foreach (var a in fileDialog.FileNames)
                        {
                            var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(a);
                            onlyFileName = onlyFileName.Replace(" ", "_");
                            byte[] imageBytes = System.IO.File.ReadAllBytes(a);
                            string ext = System.IO.Path.GetExtension(a);
                            DTO_ClaimDocument documentUploadRequest = new DTO_ClaimDocument
                            {
                                FileBytes = Convert.ToBase64String(imageBytes),
                                FileName = onlyFileName,
                                FileExt = ext,
                                ClaimID = _claim.ClaimID,
                                DocTypeID = ClaimDocTypeID,
                                DocumentDate = DateTime.Today
                            };
                            await s1.AddClaimDocument(documentUploadRequest);

                            if (documentUploadRequest.Message == null)
                            {
                                objlist.Add(documentUploadRequest);
                                b = documentUploadRequest;
                                statusText = "Success!, " + documentUploadRequest + " has been uploaded. ";
                            }
                        }

                        int claimStatusTypeID = 0;
                        switch (ClaimDocTypeID)
                        {
                            case 5: claimStatusTypeID = 1; break;//	Contract Created
                            case 1: claimStatusTypeID = 2; break;//Inspection Date
                            case 3: claimStatusTypeID = 3; break;//Plane Measurements Received
                            case 6: claimStatusTypeID = 4; break;//Estimate Complete
                                                                 //case : claimStatusTypeID = 5; break;//Adjustment Date
                            case 7: claimStatusTypeID = 6; break;//Original Scope Received
                            case 13: claimStatusTypeID = 7; break;//First Check Received
                            case 23: claimStatusTypeID = 8; break;//Roof Ordered
                                                                  //case : claimStatusTypeID = 9; break;//Supplement Sent
                            case 8: claimStatusTypeID = 10; break;//Supplement Settled
                            case 9: claimStatusTypeID = 11; break;//Roof Scheduled
                                                                  //case : claimStatusTypeID = 12; break;//Roof Complete
                            case 10: claimStatusTypeID = 13; break;//Interior Scheduled
                            case 11: claimStatusTypeID = 14; break;//Exterior Scheduled
                            case 12: claimStatusTypeID = 15; break;//Gutters Scheduled
                            case 20: claimStatusTypeID = 16; break;//Certificate of Completion Sent
                                                                   //	case : claimStatusTypeID = 17; break;//Supplement Check Received
                            case 16: claimStatusTypeID = 18; break;//Supplement Check Collected
                                                                   //	case : claimStatusTypeID = 19; break;//Depreciation Check Received
                            case 15: claimStatusTypeID = 20; break;//Depreciation Check Collected
                            case 14: claimStatusTypeID = 21; break;//Deductible Check Collected
                            case 19: claimStatusTypeID = 22; break;//Capped Out
                            case 24: claimStatusTypeID = 23; break;//Warranty Sent


                        }


                        var newClaimStatus = new DTO_ClaimStatus
                        {
                            ClaimID = _claim.ClaimID,
                            ClaimStatusDate = DateTime.Today,
                            ClaimStatusTypeID = claimStatusTypeID
                        };

                        await s1.AddClaimStatus(newClaimStatus);

                        if (newClaimStatus.Message == null)

                        {
                            objlist.Add(newClaimStatus);

                        }
                        statusText = " and status updated to  " + (s1.ClaimStatusTypes[claimStatusTypeID]) + " to " + newClaimStatus.ClaimStatusDate + " successfully.";

                    }


                    return objlist;
                }
                catch (Exception)
                {
                    return new List<object>();
                }
            }
            return new List<object>();
        }



        async public Task<bool> CheckFileExist(int cdt = 0)
        {                                                           //the worker function to callback after determining if the file exists in the location that has been picked if so it will ask what would you like to do with it.
            try
            {

                await s1.GetAllClaimDocuments();


            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            if (s1.ClaimDocumentsList.Exists(x => x.ClaimID == _claim.ClaimID))
                return true;
            else return false;
        }

        private void pdfDocumentView1_Load(object sender, EventArgs e)
        {

        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 10)
            {
                var zc = new AddressZipcodeValidation();
                maskedTextBox10.Text = zc.CityStateLookupRequest(a.Zip, 4);
                maskedTextBox11.Text = zc.CityStateLookupRequest(a.Zip, 5);
            }
            //if (e.ProgressPercentage == 20)
            //   comboBox2.SelectedIndex = l.LeadTypeID - 1;


            ProgressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            carousel1 = new Syncfusion.Windows.Forms.Tools.Carousel();
            Task.Run(async () => await s1.GetAllInspections());
            Task.Run(async () => await s1.GetInsuranceCompanyByID(new DTO_InsuranceCompany { InsuranceCompanyID = _claim.InsuranceCompanyID }));
            Task.Run(async () => await s1.GetAllClaimContacts());
            Task.Run(async () => await s1.GetAllReferrers());
            Task.Run(async () => await s1.GetAllEmployees());
            Task.Run(async () => await s1.GetAllCustomers());
            Task.Run(async () => await s1.GetAllLeads());
            if (_claim == null)
                return;
            else
            {
                cl = _claim;
                bool b = false;
                try
                {
                    //while (!b)
                    //{
                    //    if (dTO_AddressBindingSource.DataSource == null)
                    dTO_AddressBindingSource.DataSource = a = s1.AddressesList.Find(x => x.AddressID == _claim.PropertyID);

                    //      else
                    backgroundWorker1.ReportProgress(10);
                    //        if (dTO_LeadBindingSource.DataSource == null)
                    dTO_LeadBindingSource.DataSource = l = s1.LeadsList.Find(x => x.LeadID == _claim.LeadID);
                    //          else
                    backgroundWorker1.ReportProgress(20);
                    //            if (dTO_CustomerBindingSource.DataSource == null)
                    dTO_CustomerBindingSource.DataSource = c = s1.CustomersList.Find(x => x.CustomerID == _claim.CustomerID);
                    //              else
                    backgroundWorker1.ReportProgress(30);

                    //                if (dTO_ClaimContactsBindingSource.DataSource == null)
                    dTO_ClaimContactsBindingSource.DataSource = cc = s1.ClaimContactsList.Find(x => x.ClaimID == _claim.ClaimID);
                    //                  else
                    backgroundWorker1.ReportProgress(40);

                    //     if (dTOEmployeeBindingSource.DataSource == null) {
               
                    var spds = s1.EmployeesList.Find(x => x.EmployeeID == l.SalesPersonID);

                    dTOEmployeeBindingSource.DataSource = spds;

                    //}
                    //else
                    backgroundWorker1.ReportProgress(50);
                    //  if (dTO_InspectionBindingSource.DataSource == null)
                    dTO_InspectionBindingSource.DataSource = s1.InspectionsList.FindLast(x => x.ClaimID == cl.ClaimID);
                    //  else
                    backgroundWorker1.ReportProgress(60);
                    if (dTO_ReferrerBindingSource.DataSource == null)
                        dTO_ReferrerBindingSource.DataSource = r = ConvertToReferrer(GetClaimReferrer(GetReferrerType(cl)));
                    //       else
                    backgroundWorker1.ReportProgress(70);
                    //     if (dTO_InsuranceCompanyBindingSource.DataSource == null)
                    dTO_InsuranceCompanyBindingSource.DataSource = ins = s1.InsuranceCompaniesList.Find(x => x.InsuranceCompanyID == cl.InsuranceCompanyID);
                    //         else
                    backgroundWorker1.ReportProgress(80);
                    //   if (dTOLULeadTypeBindingSource.DataSource == null)
                    dTOLULeadTypeBindingSource.DataSource = s1.LeadTypes.Find(x => x.LeadTypeID == l.LeadTypeID);
                    //           else
                    backgroundWorker1.ReportProgress(90);

                    //             if (dTO_InsuranceCompanyBindingSource.DataSource != null)
                    dTO_InsuranceCompanyBindingSource.DataSource = s1.InsuranceCompany;

                    //  }
                }
                catch (Exception ex)
                {
                    while(backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
                    backgroundWorker1.RunWorkerAsync();
                }
                finally
                {

                    var imgList = new ImageList();
                    imgList.ColorDepth = ColorDepth.Depth24Bit;
                    var imgPaths = new List<string>();
                    var inspectionImages = s1.ClaimDocumentsList.FindAll(x => x.DocTypeID == 2 && x.ClaimID == _claim.ClaimID);
                    flowLayoutPanel1.GetContainerControl();
                    carousel2 = new Carousel();

                    foreach (var item in inspectionImages)
                    {
                        if (item.FileExt == ".jpg" || item.FileExt == ".png" || item.FileExt == ".bmp")
                        {
                            var str = "http://" + item.FilePath + item.FileName + item.FileExt;
                            //    System.Windows.Forms.MessageBox.Show(str);
                            var web = new System.Net.WebClient();

                            var response = web.DownloadData(str);
                            CarouselImage carouselImage = new Syncfusion.Windows.Forms.Tools.CarouselImage();
                            // Sets the carousel image.

                            stream = new MemoryStream(web.DownloadData(str));
                            var pb = new PictureBox();
                            pb.ImageLocation = str;
                            pb.Height = 320; pb.Width = 320;


                            //    flowLayoutPanel1.Container.Add(pb);

                            var bmp = ByteToImage(response);

                            pb.Image = bmp;
                            //      this.furnishPermitCheckBox.Container.Add(pb);
                            image.Image = bmp;
                            carousel2.Items.Add(pb);


                            //Adds the carousel images to ImageListCollection.
                            //  this.carousel2.ImageListCollection.Add(carouselImage);
                        }
                        // Displays the images in the Carousel.



                    }


                    // carousel1.ImageList = imgList;
                    //          this.carousel2.ImageSlides = true;












                }

            }
        }



        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        async Task<bool> AddClaim()
        {
            await s1.AddCustomer((DTO_Customer)dTO_CustomerBindingSource.DataSource);
            dTO_CustomerBindingSource.DataSource = s1.Cust;
            await s1.AddAddress((DTO_Address)dTO_AddressBindingSource.DataSource);
            dTO_AddressBindingSource.DataSource = s1.Address;
            await s1.AddLead((DTO_Lead)dTO_LeadBindingSource.DataSource);
            dTO_LeadBindingSource.DataSource = s1.Lead;
            await s1.AddReferrer((DTO_Referrer)dTO_ReferrerBindingSource.DataSource);
            dTO_ReferrerBindingSource.DataSource = s1.Referrer;
            await s1.AddInspection((DTO_Inspection)dTO_InspectionBindingSource.DataSource);
            dTO_InspectionBindingSource.DataSource = s1.Inspection;
            await s1.AddClaim((DTO_Claim)dTO_ClaimBindingSource.DataSource);
            dTO_ClaimBindingSource.DataSource = s1.Claim;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(async () => await AddClaim());
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void scheduleControl1_Load(object sender, EventArgs e)
        {

        }

        private void carousel2_Click(object sender, EventArgs e)
        {

        }

        async public void updateUI()
        {

            DisplayRecordedClaimDocuments(GetClaimDocument(_claim, ClaimDocTypeID));

            //while (!ReadyToUpdate)
            //await Task.Delay(10);
            ReadyToUpdate = false;

        }
    }
    public class AddressResolver
    {
        public string State { get; set; }
        public string City { get; set; }

        public AddressResolver(string zip)
        {
            var a = new AddressZipcodeValidation();
            a.CityStateLookupRequest(zip, 1);
            State = a.ST;

            City = a.City;

        }
    }
}
#endregion