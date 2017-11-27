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
using System.Threading;

namespace MRNUIElements
{
    public partial class Form2 : Form
    {

        static ServiceLayer s1 = ServiceLayer.getInstance();
        public DTO_Claim Claim { get; set; }
        public DTO_LU_ClaimDocumentType DocType { get; set; }
        static public DTO_Claim _Claim;
        static public DTO_LU_ClaimDocumentType _DocType;
        public static string FullFilePath;
        public Form2()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();


        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            PopulateList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
                Claim = (DTO_Claim)comboBox1.SelectedItem;
        }
        async Task<bool> Init()
        {
            await s1.GetAllClaims();

            comboBox1.Items.AddRange(s1.ClaimsList.ToArray());
            comboBox2.DataSource = s1.ClaimDocTypes;

            return true;
        }

        async private void button2_Click(object sender, EventArgs e)
        {

            await UploadImage();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                PopulateList();

        }
        void PopulateList()
        {
            if (listView1.HasChildren)
                listView1.Clear();
            foreach (var item in openFileDialog1.FileNames)
            {
                listView1.Items.Add(item);

            }
        }

        public void UploadDocuments(DTO_Claim claim, DTO_LU_ClaimDocumentType docType, string filePath)
        {
            if (Claim == null && claim != null)
                _Claim = this.Claim = claim;
            if (DocType == null && docType != null)
                _DocType = this.DocType = docType;
            if (FullFilePath == null && filePath != null)
                FullFilePath = filePath;

            if (claim != null && docType != null && !string.IsNullOrEmpty(filePath))
                UploadImage(filePath);

        }


        async public Task<bool> UploadImage(string filepathtoupload = null)
        {
            bool multi = false;
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            var result = System.Windows.Forms.DialogResult.OK;

            if (DocType.ClaimDocumentTypeID == 2)
            {
                multi = true;
                fileDialog.Multiselect = true;
                fileDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF|Document Files(*.XLS; *.DOC; *.PDF)| *.XLS; *.DOC; *.PDF | All files(*.*) | *.*";


            }

            result = fileDialog.ShowDialog();


            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    if (filepathtoupload == null)
                        if (!multi)
                            await pushFiles(fileDialog.FileName);
                        else
                            foreach (var item in fileDialog.FileNames)
                                await pushFiles(item);
                    else
                        await pushFiles(filepathtoupload);


                    return true;
                case System.Windows.Forms.DialogResult.Cancel:
                default:

                    return false;
            }


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > -1)
                DocType = (DTO_LU_ClaimDocumentType)comboBox2.SelectedItem;


        }
        async Task<bool> pushFiles(string filepathtoupload)
        {


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
                ClaimID = Claim.ClaimID,
                DocTypeID = DocType.ClaimDocumentTypeID,
                DocumentDate = DateTime.Today

            };
            try
            {
                await s1.AddClaimDocument(documentUploadRequest);

                if (documentUploadRequest.Message != null)
                {
                    System.Windows.Forms.MessageBox.Show(documentUploadRequest.Message.ToString());
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
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            Task.Run(async () => await s1.GetAllClaims());

            var mylist = s1.ClaimsList;

            comboBox1.DataSource = s1.ClaimsList;
            comboBox2.DataSource = s1.ClaimDocTypes;


        }
        static string Filter(bool multi)
        {
           if (multi)
                    return "All Image Types (*.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png) | *.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png";

               
                    return "All Image Types (*.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png) | *.jpg;*.jpeg;*.bmp;*.tif;*.tiff;*.png | All Document Types (*.pdf;*.doc;*.docx;*.txt;*.xml) | *.pdf;*.doc;*.docx;*.txt;*.xml| All File Types(*.*) | *.*";

            
        }
        async Task<DTO_ClaimDocument> ConfirmDocUpload(List<object> a)
        {
            DTO_ClaimDocument c = (DTO_ClaimDocument)a[0];
            DTO_ClaimStatus d = (DTO_ClaimStatus)a[1];
         //   await UpdateClaimDocumentsLists();
            if (s1.ClaimDocumentsList.Find(z => z.ClaimID == c.ClaimID && z.DocTypeID == c.DocTypeID).DocumentDate == c.DocumentDate)
            {
                s1.ClaimDocumentsList.Add(c);
                //	updateUI();
                return c;
            }
            return new DTO_ClaimDocument();
        }

        async private Task<List<object>> UploadImage()
        {
            List<object> objlist = new List<object>();
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            bool multi = comboBox2.SelectedText == s1.ClaimDocTypes.Find(x => x.ClaimDocumentTypeID == 2).ClaimDocumentType?true:false;
            string statusText = "";
            if (multi)
               
                fileDialog.Multiselect = true;
            else
                fileDialog.Multiselect = false;
            fileDialog.Title = comboBox2.SelectedText + " Import Tool";
            fileDialog.Filter = Filter(multi);
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
                                ClaimID = Claim.ClaimID,
                                DocTypeID = comboBox2.SelectedIndex+1,
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
                        switch (comboBox2.SelectedIndex+1)
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
                            ClaimID = Claim.ClaimID,
                            ClaimStatusDate = DateTime.Today,
                            ClaimStatusTypeID = claimStatusTypeID
                        };

                        await s1.AddClaimStatus(newClaimStatus);

                        if (newClaimStatus.Message == null)

                        {
                            objlist.Add(newClaimStatus);

                        }
                        statusText +=" and status updated to  " + (s1.ClaimStatusTypes[claimStatusTypeID]) + " to " + newClaimStatus.ClaimStatusDate + " successfully.";
                        MessageBox.Show(statusText);
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

    }
}
