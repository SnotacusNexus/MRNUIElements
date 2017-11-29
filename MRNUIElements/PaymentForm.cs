using MRNNexus_Model;
using MRNUIElements.Controllers;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MRNUIElements.MainWindow;

namespace MRNUIElements
{
    public partial class PaymentForm : Form
    {
        private static MainWindow mw = getMainWindowInstance();
        private static ServiceLayer s1 = ServiceLayer.getInstance();
        private DTO_ClaimDocument cd = new DTO_ClaimDocument();
        private DTO_Payment payment = new DTO_Payment();
        private DTO_ClaimStatus cs = new DTO_ClaimStatus();
        private DTO_Claim cl = new DTO_Claim();

        public PaymentForm()
        {
            InitializeComponent();
            dTOClaimBindingSource.DataSource = s1.ClaimsList;
            dTOLUPaymentTypeBindingSource.DataSource = s1.PaymentTypes;
            dTOLUPaymentDescriptionBindingSource.DataSource = s1.PaymentDescriptions;

            s1.GetAllAddresses();
            s1.GetAllClaims();
            s1.GetAllClaimStatuses();
            s1.GetAllCustomers();
            s1.GetAllClaimDocuments();
            s1.GetAllPayments();
           

        }
       
        private void BrowsePaymentBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK)
                return;

            cd.ClaimID = ((DTO_Claim)PaymentClaimID.SelectedItem).ClaimID;
            cd.DocTypeID = ((DTO_LU_ClaimDocumentType)PaymentTypeIDcomboboxP.SelectedItem).ClaimDocumentTypeID;
            cd.InitialImagePath = openFileDialog1.FileName;

            cd.FileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
            cd.FileExt = System.IO.Path.GetExtension(openFileDialog1.FileName);
            ProofOfPaymentImage.ImageLocation = openFileDialog1.FileName;
        }

        async private Task<bool> uploadPaymentImage(string file, DTO_Claim cl, DTO_ClaimDocument doc)
        {
            var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(file);

            onlyFileName = onlyFileName.Replace(" ", "_");
            byte[] imageBytes = System.IO.File.ReadAllBytes(file);
            string ext = System.IO.Path.GetExtension(file);
            DTO_ClaimDocument documentUploadRequest = new DTO_ClaimDocument
            {
                FileBytes = Convert.ToBase64String(imageBytes),
                FileName = onlyFileName,
                FileExt = ext,
                ClaimID = cl.ClaimID,
                DocTypeID = doc.DocTypeID,
                DocumentDate = DateTime.Today
            };
            try
            {
                await s1.AddClaimDocument(documentUploadRequest);

                if (documentUploadRequest.Message != null)
                {
                    return false;
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
            }

            //put sound of cha ching in here

            return true;
        }

        async private void MakePaymentBtn_Click(object sender, EventArgs e)
        {
            mw.busyIndicator.IsBusy = true;
            mw.busyIndicator.Visibility = System.Windows.Visibility.Visible;
            try
            {
                if (await uploadPaymentImage(cd.InitialImagePath, cl, cd))
                {
                    await s1.AddPayment(payment);
                    if (s1.Payment.Message == null)
                    {
                        await s1.AddClaimDocument(cd);
                        if (s1.ClaimDocument.Message == null)
                        {
                            await (s1.AddClaimStatus((DTO_ClaimStatus)getClaimStatusType(payment)));
                            if (s1.ClaimStatus.Message != null)
                                return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            mw.busyIndicator.IsBusy = false;
            mw.busyIndicator.Visibility = System.Windows.Visibility.Hidden;
        }

        private void PaymentTypeIDcomboboxP_SelectedIndexChanged(object sender, EventArgs e)
        {
            payment.PaymentTypeID = ((DTO_LU_PaymentType)PaymentTypeIDcomboboxP.SelectedItem).PaymentTypeID;
        }

        private object getClaimStatusType(Object obj)
        {
            DTO_ClaimStatus cs = new DTO_ClaimStatus();
            if (obj.GetType() == typeof(DTO_Payment))
            {
                DTO_Payment i = ((DTO_Payment)obj);

                switch (i.PaymentDescriptionID)
                {
                    case 1:
                        return new DTO_ClaimStatus { ClaimID = i.ClaimID, ClaimStatusTypeID = 7, ClaimStatusDate = i.PaymentDate };

                    case 2:
                        return new DTO_ClaimStatus { ClaimID = i.ClaimID, ClaimStatusTypeID = 18, ClaimStatusDate = i.PaymentDate };

                    case 3:
                        return new DTO_ClaimStatus { ClaimID = i.ClaimID, ClaimStatusTypeID = 20, ClaimStatusDate = i.PaymentDate };

                    case 4:
                        return new DTO_ClaimStatus { ClaimID = i.ClaimID, ClaimStatusTypeID = 24, ClaimStatusDate = i.PaymentDate };

                    case 5:
                        return new DTO_ClaimStatus { ClaimID = i.ClaimID, ClaimStatusTypeID = 21, ClaimStatusDate = i.PaymentDate };

                    default:
                        return obj;
                }
            }

            return obj;
        }

        private void paymentAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            payment.Amount = (double)paymentAmountTextBox.DecimalValue;
        }

        private void PaymentDatePIcker_ValueChanged(object sender, EventArgs e)
        {
            cs.ClaimStatusDate = payment.PaymentDate = cd.DocumentDate = PaymentDatePIcker.Value.Date;
        }

        private void ProofOfPaymentImage_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                ProofOfPaymentImage.Image = ((Image)sender);
            }
            catch
            {
            }
        }

        private void PaymentClaimID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DTO_Customer cust = new DTO_Customer();
                DTO_Address a = new DTO_Address();
                cl = ((DTO_Claim)PaymentClaimID.SelectedItem);
                AddressZipcodeValidation azv = new AddressZipcodeValidation();
                string c = "", s = "", z = "";
                cd.ClaimID = payment.ClaimID = cl.ClaimID;
                cust = s1.CustomersList.Find(x => x.CustomerID == cl.CustomerID);

                ClaimCustomerPaymentTextBox.Text = cust.FirstName + " " + cust.LastName;
                a = s1.AddressesList.Find(x => x.AddressID == cl.PropertyID);
                c = azv.CityStateLookupRequest(z, 3);
                s = azv.CityStateLookupRequest(z, 4);
                customerAddressTextBoxPayment.Text = a + ", " + c + ", " + "  " + z;
;
            }
            catch (Exception)
            {
            }
        }

        private void PaymentComments_Leave(object sender, EventArgs e)
        {
            if (!PaymentComments.Focused)
            {
                cd.DocumentComments = PaymentComments.Text;
            }
        }

        private void PaymentComments_Enter(object sender, EventArgs e)
        {
            if (PaymentComments.Focused)
            {
                if (PaymentComments.Text == "Additional Comments:")
                    PaymentComments.Clear();
            }
        }

        private void dTOLUClaimStatusTypesBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            payment.PaymentDescriptionID = ((DTO_LU_PaymentDescription)paymentDescriptions.SelectedItem).PaymentDescriptionID;
        }
    }
}