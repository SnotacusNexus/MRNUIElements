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
using System.Windows.Forms;
using System.Web.ClientServices;
using System.Web.ApplicationServices;
using System.Web.UI;
using System.Net.Http.Handlers;
using System.IO;
using MRNNexus_Model;
using MRN_Claim_Services.Controllers;
using MRN_Claim_Services.Controllers.Collection;
using System.Drawing;
using static MRN_Claim_Services.NexusHome;
using System.Threading;
using System.Collections.ObjectModel;

namespace MRN_Claim_Services
{

    public partial class ClaimDetailsPage : System.Windows.Controls.Page
    {
        public static ServiceLayer s1 = ServiceLayer.getInstance();
        public string FullFilePath { get; set; }
        public ClaimData ClaimData { get; set; }
        public int ClaimDocTypeID { get; set; }
        public bool EditData { get; set; }
        public DTO_Claim _claim = new DTO_Claim();
        public DTO_Claim CurrentClaim { get; set; }
        public ClaimDetailsPage(DTO_Claim CurrentClaim = null)
        {
            InitializeComponent();
            Init();

            this.ClaimsList.ItemsSource = s1.ClaimsList;
            this.AvailableDocuments.ItemsSource = s1.ClaimDocTypes;
            if (_claim != null)
                CurrentClaim = _claim;
        }
        private void LogOut(object sender, RoutedEventArgs e)
        {
            Login Page = new Login();
            this.NavigationService.Navigate(Page);
        }



        private async void Init()
        {
            EditData = false;
            EDcheckBox.IsChecked = false;
            await s1.GetAllClaimDocuments();
            while (s1.ClaimDocumentsList == null)
                BusyIndicator.Visibility = Visibility.Visible;
            BusyIndicator.Visibility = Visibility.Collapsed;
        }
        private void ClaimsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //if (AvailableDocuments.SelectedIndex > -1)
            //{
            //	DTO_Claim _claim = new DTO_Claim();

            _claim.ClaimID = (((DTO_Claim)ClaimsList.SelectedItem).ClaimID);
            MRN_Claim_Services.NexusHome.CurrentClaim = s1.Claim = CurrentClaim = _claim = ((DTO_Claim)ClaimsList.SelectedItem);

            SetButtonStatus(ClaimDocAvailability(_claim));
            //	DisplayRecordedClaimDocuments(_claim);
            //}
        }
        void DisplayRecordedClaimDocuments(DTO_ClaimDocument _claimDocument, DTO_ClaimDocument _claimDocument2 = null)
        {
            BusyIndicator.Visibility = Visibility.Visible;
            if (_claimDocument != null)
                if (_claimDocument.FileExt == ".pdf" || _claimDocument.FileExt == ".PDF")
                {
                    if ((bool)SupplementModeSelector.IsChecked && _claimDocument2 != null)
                        ViewDocument("http://" + _claimDocument.FilePath + _claimDocument.FileName + _claimDocument.FileExt, "http://" + _claimDocument2.FilePath + _claimDocument2.FileName + _claimDocument2.FileExt);
                    else ViewDocument("http://" + _claimDocument.FilePath + _claimDocument.FileName + _claimDocument.FileExt);
                }
                else if (_claimDocument.FileExt == ".jepg" || _claimDocument.FileExt == ".JPEG" || _claimDocument.FileExt == ".jpg" || _claimDocument.FileExt == ".png" || _claimDocument.FileExt == ".bmp" || _claimDocument.FileExt == ".JPG" || _claimDocument.FileExt == ".BMP" || _claimDocument.FileExt == ".PNG")
                {
                    DisplayImage("http://" + _claimDocument.FilePath + _claimDocument.FileName + _claimDocument.FileExt);
                }

        }
        async void DisplayImage(string str)
        {
            try
            {
                if (pdfviewer1.Visibility == Visibility.Visible)
                    pdfviewer1.Visibility = Visibility.Collapsed;
                image.Visibility = Visibility.Visible;
                var web = new System.Net.WebClient();


                stream = new MemoryStream(await web.DownloadDataTaskAsync(str));

                image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(str);
                BusyIndicator.Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {

                throw;
            }



        }
        DTO_ClaimDocument GetClaimDocument(DTO_Claim _claim, int _claimDocTypeID)
        {
            return s1.ClaimDocumentsList.Find(x => x.ClaimID == _claim.ClaimID && x.DocTypeID == _claimDocTypeID);

        }
        bool uploadselected = false;
        private void AvailableDocuments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DTO_Claim _claim = new DTO_Claim();
            //_claim.ClaimID = (((DTO_Claim)ClaimsList.SelectedItem).ClaimID);
            //DisplayRecordedClaimDocuments(_claim);
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

            _claim.ClaimID = (((DTO_Claim)ClaimsList.SelectedItem).ClaimID);
            uploadselected = true;
            SetButtonStatus(UploadSelector());


        }

        List<bool> UploadSelector()
        {
            List<bool> enableall = new List<bool>();
            foreach (var cdt in s1.ClaimDocTypes)
                if (uploadselected)
                    enableall.Add(true);
            return enableall;
        }

        async private void UploadImage(string filepathtoupload = null)
        {
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            var result = System.Windows.Forms.DialogResult.OK;
            if (filepathtoupload == null)
                result = fileDialog.ShowDialog();


            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    if (filepathtoupload == null)
                        FullFilePath = fileDialog.FileName;
                    else
                        FullFilePath = filepathtoupload;
                    var file = FullFilePath;
                    var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(file);


                    onlyFileName = onlyFileName.Replace(" ", "_");
                    byte[] imageBytes = System.IO.File.ReadAllBytes(file);
                    string ext = System.IO.Path.GetExtension(file);
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
                    BusyIndicator.Visibility = Visibility.Visible;
                    if (documentUploadRequest.Message == null)
                    {
                        BusyIndicator.Visibility = Visibility.Collapsed;
                        System.Windows.Forms.MessageBox.Show("Success");
                    }
                    //SAVING FILES TO DISK
                    //string filename = fileDialog.FileName = @"newfile" + ext;
                    //using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                    //{
                    //    saveFileDialog1.FileName = filename;
                    //    if (System.Windows.Forms.DialogResult.OK != saveFileDialog1.ShowDialog())
                    //        return;
                    //    System.IO.File.WriteAllBytes(saveFileDialog1.FileName,Convert.FromBase64String(s1.ClaimDocument.FileBytes));
                    //}
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:

                    return;
            }
        }
        void SetButtonStatus(List<bool> enablelist)
        {

            if (enablelist.Count > 0)
            {
                InspectionReportBtn.IsEnabled = enablelist[0];

                InspectionPhotos.IsEnabled = enablelist[1];

                RoofMeasurementBtn.IsEnabled = enablelist[2];

                SketchBtn.IsEnabled = enablelist[3];

                CustomerAgreementBtn.IsEnabled = enablelist[4];

                MRNEstimateBtn.IsEnabled = enablelist[5];

                OriginalScopeBtn.IsEnabled = enablelist[6];

                NewestScopeBtn.IsEnabled = enablelist[7];

                RoofOrderBtn.IsEnabled = enablelist[8];

                InteriorInvoice.IsEnabled = enablelist[9];

                RoofLaborInvoiceBtn.IsEnabled = enablelist[10];

                GutterInvoiceBtn.IsEnabled = enablelist[11];

                FirstCheckBtn.IsEnabled = enablelist[12];

                DeductibleCheckBtn.IsEnabled = enablelist[13];

                DepreciationCheckBtn.IsEnabled = enablelist[14];

                SupplementCheckBtn.IsEnabled = enablelist[15];

                MaterialInvoiceBtn.IsEnabled = enablelist[16];

                LienWaiverBtn.IsEnabled = enablelist[17];

                CapOutBtn.IsEnabled = enablelist[18];

                CertificateOfCompletionBtn.IsEnabled = enablelist[19];

                AuthorizatonOfCommunicationBtn.IsEnabled = enablelist[20];

                SatisfactionSurveyBtn.IsEnabled = enablelist[21];

                PlaneDamages.IsEnabled = enablelist[22];

                WarrantyBtn.IsEnabled = enablelist[23];

                PolicyBtn.IsEnabled = enablelist[24];

                ThankyouLetterBtn.IsEnabled = enablelist[25];
            }
        }
        private List<string> SelectFile(int docTypeID)
        {
            uploadselected = false;
            ClaimDocTypeID = docTypeID;
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            if (docTypeID == 2)
                fileDialog.Multiselect = true;
            else
                fileDialog.Multiselect = false;
            fileDialog.Title = " Import Tool";
            fileDialog.Filter = Filter(docTypeID);
            var result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (FileNames.Count > 0)
                    FileNames.Clear();
                FullFilePath = fileDialog.FileName;
                foreach (string s in fileDialog.FileNames)
                {

                    FileNames.Add(s);
                }
                //FileListBox.ItemsSource = FileNames;
                //FileListBox.SelectedIndex = 0; 
                return FileNames;
            }
            return null;
        }
        List<string> FileNames = new List<string>();
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
        Stream stream, stream2;
        async void ViewDocument(string str, string str2 = null)
        {
            if (!(bool)SupplementModeSelector.IsChecked)
            {
                if (image.Visibility == Visibility.Visible)
                    image.Visibility = Visibility.Collapsed;
                pdfviewer1.Visibility = Visibility.Visible;
            }
            try
            {
                //var bi = new MainWindow().busyIndicator;
                var web = new System.Net.WebClient();
                stream = new MemoryStream(await web.DownloadDataTaskAsync(str));
                if ((bool)SupplementModeSelector.IsChecked)
                {
                    var web2 = new System.Net.WebClient();
                    stream2 = new MemoryStream(await web2.DownloadDataTaskAsync(str2));
                    pdfviewer2.Load(stream2);
                }
                while (stream == null)
                    if (BusyIndicator.Visibility == Visibility.Collapsed)
                        BusyIndicator.Visibility = Visibility.Visible;

                pdfviewer1.Load(stream);
                BusyIndicator.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.ToString());
                throw;
            }



        }

        async void GetDocuments()
        {
            await s1.GetAllClaimDocuments();

        }
        //if object exist then the icon is clickable

        private List<bool> ClaimDocAvailability(DTO_Claim claim)
        {
            List<bool> DocExist = new List<bool>();
            GetDocuments();
            while (s1.ClaimDocumentsList == null)
                Thread.Sleep(10);
            List<DTO_ClaimDocument> claimdocs = s1.ClaimDocumentsList;
            int i = 1;
            if (s1.ClaimDocumentsList != null)
                foreach (var cdt in s1.ClaimDocTypes)
                {
                    DTO_ClaimDocument cd = new DTO_ClaimDocument { ClaimID = claim.ClaimID, DocTypeID = i++ };

                    if (claimdocs.Exists(x => x.ClaimID == cd.ClaimID && x.DocTypeID == cd.DocTypeID))
                        DocExist.Add(true);
                    else
                        DocExist.Add(false);

                    //returns a list of what docs exist and which ones dont. apply this to an enabled binding and wallah



                }
            return DocExist;
        }
        #region	  Button Behavior
        private void InspectionReportBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 1));
            else UploadImage(SelectFile(1)[0]);
            uploadselected = false;

        }

        private void InspectionPhotos_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 2));
            else UploadImage(SelectFile(2)[0]);
            uploadselected = false;
        }

        private void RoofMeasurementBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 3));
            else UploadImage(SelectFile(3)[0]);
            uploadselected = false;
        }

        private void SketchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 4));
            else UploadImage(SelectFile(4)[0]);
            uploadselected = false;
        }

        private void OriginalScopeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EditData)
                this.NavigationService.Navigate(new ScopeViewer(_claim, 7));
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 7));
            else
                UploadImage(SelectFile(7)[0]);


            uploadselected = false;
        }

        private void CustomerAgreementBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 5));

            else UploadImage(SelectFile(5)[0]);
            uploadselected = false;
        }

        private void MRNEstimateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EditData)
                this.NavigationService.Navigate(new ScopeViewer(_claim, 6));
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 6));
            else
                UploadImage(SelectFile(6)[0]);



            uploadselected = false;
        }

        private void NewestScopeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EditData)
                this.NavigationService.Navigate(new ScopeViewer(_claim, 8));

            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 8));
            else
                UploadImage(SelectFile(8)[0]);

            uploadselected = false;
        }

        private void RoofLaborInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 11));
            else UploadImage(SelectFile(11)[0]);
            uploadselected = false;
        }

        private void MaterialInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 17));
            else UploadImage(SelectFile(17)[0]);
            uploadselected = false;
        }

        private void InteriorInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 10));
            else UploadImage(SelectFile(10)[0]);
        }

        private void GutterInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 12));
            else UploadImage(SelectFile(12)[0]);
            uploadselected = false;
        }

        private void FirstCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EditData)
                NavigationService.Navigate(new PaymentEntryPage(_claim, 13));
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 13));
            else UploadImage(SelectFile(13)[0]);

            uploadselected = false;
        }

        private void SupplementCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EditData)
                NavigationService.Navigate(new PaymentEntryPage(_claim, 16));
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 16));
            else UploadImage(SelectFile(16)[0]);

            uploadselected = false;
        }

        private void DepreciationCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EditData)
                NavigationService.Navigate(new PaymentEntryPage(_claim, 15));
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 15));
            else UploadImage(SelectFile(15)[0]);

            uploadselected = false;
        }

        private void DeductibleCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EditData)
                NavigationService.Navigate(new PaymentEntryPage(_claim, 14));
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 14));
            else UploadImage(SelectFile(14)[0]);

            uploadselected = false;
        }

        private void CertificateOfCompletionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 20));
            else UploadImage(SelectFile(20)[0]);
            uploadselected = false;
        }

        private void LienWaiverBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 18));
            else UploadImage(SelectFile(18)[0]);
            uploadselected = false;
        }

        private void AuthorizatonOfCommunicationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 21));
            else UploadImage(SelectFile(21)[0]);
            uploadselected = false;
        }

        private void SatisfactionSurveyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 22));
            else UploadImage(SelectFile(22)[0]);
            uploadselected = false;
        }

        private void PlaneDamages_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 23));
            else UploadImage(SelectFile(23)[0]);
            uploadselected = false;
        }

        private void WarrantyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 24));
            else UploadImage(SelectFile(24)[0]);
            uploadselected = false;
        }

        private void ThankyouLetterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 26));
            else UploadImage(SelectFile(26)[0]);
            uploadselected = false;
        }

        private void RoofOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 9));
            else UploadImage(SelectFile(9)[0]);
            uploadselected = false;
        }

        private void PolicyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 25));
            else UploadImage(SelectFile(25)[0]);
            uploadselected = false;
        }

        private void CapOutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!uploadselected)
                DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 19));
            else UploadImage(SelectFile(19)[0]);
            uploadselected = false;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if (EDcheckBox.IsChecked == false)
                EditData = true;
            else EditData = false;

        }
        #endregion

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            //CapOutDownload
        }

        private void SupplementModeSelector_Clicked(object sender, RoutedEventArgs e)
        {
            if (pdfviewer1.Visibility == Visibility.Collapsed)
                pdfviewer1.Visibility = Visibility.Visible;


            //else pdfviewer1.Visibility = Visibility.Collapsed;
            if (pdfviewer2.Visibility == Visibility.Collapsed || GridSupplement.Visibility == Visibility.Collapsed)
            {
                pdfviewer2.Visibility = Visibility.Visible;
                GridSupplement.Visibility = Visibility.Visible;
            }
            else
            {
                pdfviewer2.Visibility = Visibility.Collapsed;
                GridSupplement.Visibility = Visibility.Collapsed;
            }
            if (image.Visibility == Visibility.Visible)
                image.Visibility = Visibility.Collapsed;
            DisplayRecordedClaimDocuments(GetClaimDocument(_claim, 6), GetClaimDocument(_claim, 7));
        }
    }
}
class DocumentViewerConfig : ObservableCollection<DocumentViewerConfig>
{
    public DocumentViewerConfig DocConfig { get; set; }
    public object viewer { get; set; }
    public string source { get; set; }
    public Type type { get; set; }
    public int DocTypeID { get; set; }

}

