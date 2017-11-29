namespace MRNUIElements
{
    partial class PaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.paymentAmountTextBox = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            this.dTOPaymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PaymentClaimID = new System.Windows.Forms.ComboBox();
            this.dTOClaimBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClaimCustomerPaymentTextBox = new System.Windows.Forms.MaskedTextBox();
            this.customerAddressTextBoxPayment = new System.Windows.Forms.MaskedTextBox();
            this.MakePaymentBtn = new System.Windows.Forms.Button();
            this.PaymentDatePIcker = new System.Windows.Forms.DateTimePicker();
            this.PaymentTypeIDcomboboxP = new System.Windows.Forms.ComboBox();
            this.dTOLUPaymentTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProofOfPaymentImage = new System.Windows.Forms.PictureBox();
            this.BrowsePaymentBtn = new System.Windows.Forms.Button();
            this.dTOClaimDocumentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.PaymentComments = new System.Windows.Forms.TextBox();
            this.paymentDescriptions = new System.Windows.Forms.ComboBox();
            this.dTOLUPaymentDescriptionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTOLUClaimStatusTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.paymentAmountTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOPaymentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOClaimBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOLUPaymentTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProofOfPaymentImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOClaimDocumentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOLUPaymentDescriptionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOLUClaimStatusTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // paymentAmountTextBox
            // 
            this.paymentAmountTextBox.BackGroundColor = System.Drawing.SystemColors.Window;
            this.paymentAmountTextBox.BeforeTouchSize = new System.Drawing.Size(100, 20);
            this.paymentAmountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.dTOPaymentBindingSource, "Amount", true));
            this.paymentAmountTextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.paymentAmountTextBox.Location = new System.Drawing.Point(305, 50);
            this.paymentAmountTextBox.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.paymentAmountTextBox.Name = "paymentAmountTextBox";
            this.paymentAmountTextBox.NullString = "";
            this.paymentAmountTextBox.OverWriteText = true;
            this.paymentAmountTextBox.Size = new System.Drawing.Size(100, 20);
            this.paymentAmountTextBox.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.paymentAmountTextBox.TabIndex = 1;
            this.paymentAmountTextBox.Text = "$0.00";
            this.paymentAmountTextBox.TextChanged += new System.EventHandler(this.paymentAmountTextBox_TextChanged);
            // 
            // dTOPaymentBindingSource
            // 
            this.dTOPaymentBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Payment);
            // 
            // PaymentClaimID
            // 
            this.PaymentClaimID.DataSource = this.dTOClaimBindingSource;
            this.PaymentClaimID.DisplayMember = "MRNNumber";
            this.PaymentClaimID.FormattingEnabled = true;
            this.PaymentClaimID.Location = new System.Drawing.Point(12, 19);
            this.PaymentClaimID.Name = "PaymentClaimID";
            this.PaymentClaimID.Size = new System.Drawing.Size(161, 21);
            this.PaymentClaimID.TabIndex = 2;
            this.PaymentClaimID.Text = "MRN Number";
            this.PaymentClaimID.ValueMember = "ClaimID";
            this.PaymentClaimID.SelectedIndexChanged += new System.EventHandler(this.PaymentClaimID_SelectedIndexChanged);
            // 
            // dTOClaimBindingSource
            // 
            this.dTOClaimBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Claim);
            // 
            // ClaimCustomerPaymentTextBox
            // 
            this.ClaimCustomerPaymentTextBox.Location = new System.Drawing.Point(12, 50);
            this.ClaimCustomerPaymentTextBox.Name = "ClaimCustomerPaymentTextBox";
            this.ClaimCustomerPaymentTextBox.ReadOnly = true;
            this.ClaimCustomerPaymentTextBox.Size = new System.Drawing.Size(192, 20);
            this.ClaimCustomerPaymentTextBox.TabIndex = 3;
            // 
            // customerAddressTextBoxPayment
            // 
            this.customerAddressTextBoxPayment.Location = new System.Drawing.Point(12, 76);
            this.customerAddressTextBoxPayment.Name = "customerAddressTextBoxPayment";
            this.customerAddressTextBoxPayment.ReadOnly = true;
            this.customerAddressTextBoxPayment.Size = new System.Drawing.Size(192, 20);
            this.customerAddressTextBoxPayment.TabIndex = 4;
            // 
            // MakePaymentBtn
            // 
            this.MakePaymentBtn.Location = new System.Drawing.Point(305, 74);
            this.MakePaymentBtn.Name = "MakePaymentBtn";
            this.MakePaymentBtn.Size = new System.Drawing.Size(100, 22);
            this.MakePaymentBtn.TabIndex = 5;
            this.MakePaymentBtn.Text = "Make Payment";
            this.MakePaymentBtn.UseVisualStyleBackColor = true;
            this.MakePaymentBtn.Click += new System.EventHandler(this.MakePaymentBtn_Click);
            // 
            // PaymentDatePIcker
            // 
            this.PaymentDatePIcker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTOPaymentBindingSource, "PaymentDate", true));
            this.PaymentDatePIcker.Location = new System.Drawing.Point(205, 20);
            this.PaymentDatePIcker.Name = "PaymentDatePIcker";
            this.PaymentDatePIcker.Size = new System.Drawing.Size(200, 20);
            this.PaymentDatePIcker.TabIndex = 6;
            this.PaymentDatePIcker.ValueChanged += new System.EventHandler(this.PaymentDatePIcker_ValueChanged);
            // 
            // PaymentTypeIDcomboboxP
            // 
            this.PaymentTypeIDcomboboxP.DataSource = this.dTOLUPaymentTypeBindingSource;
            this.PaymentTypeIDcomboboxP.DisplayMember = "PaymentType";
            this.PaymentTypeIDcomboboxP.FormattingEnabled = true;
            this.PaymentTypeIDcomboboxP.Location = new System.Drawing.Point(12, 103);
            this.PaymentTypeIDcomboboxP.Name = "PaymentTypeIDcomboboxP";
            this.PaymentTypeIDcomboboxP.Size = new System.Drawing.Size(192, 21);
            this.PaymentTypeIDcomboboxP.TabIndex = 7;
            this.PaymentTypeIDcomboboxP.Text = "Payment Type";
            this.PaymentTypeIDcomboboxP.ValueMember = "PaymentTypeID";
            this.PaymentTypeIDcomboboxP.SelectedIndexChanged += new System.EventHandler(this.PaymentTypeIDcomboboxP_SelectedIndexChanged);
            // 
            // dTOLUPaymentTypeBindingSource
            // 
            this.dTOLUPaymentTypeBindingSource.DataSource = typeof(MRNNexus_Model.DTO_LU_PaymentType);
            // 
            // ProofOfPaymentImage
            // 
            this.ProofOfPaymentImage.BackgroundImage = global::MRNUIElements.Properties.Resources.RoofInspectionWizardBkgnd;
            this.ProofOfPaymentImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProofOfPaymentImage.Location = new System.Drawing.Point(12, 227);
            this.ProofOfPaymentImage.Name = "ProofOfPaymentImage";
            this.ProofOfPaymentImage.Size = new System.Drawing.Size(392, 186);
            this.ProofOfPaymentImage.TabIndex = 8;
            this.ProofOfPaymentImage.TabStop = false;
            this.ProofOfPaymentImage.UseWaitCursor = true;
            this.ProofOfPaymentImage.WaitOnLoad = true;
            this.ProofOfPaymentImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.ProofOfPaymentImage_DragDrop);
            // 
            // BrowsePaymentBtn
            // 
            this.BrowsePaymentBtn.Location = new System.Drawing.Point(305, 103);
            this.BrowsePaymentBtn.Name = "BrowsePaymentBtn";
            this.BrowsePaymentBtn.Size = new System.Drawing.Size(100, 22);
            this.BrowsePaymentBtn.TabIndex = 9;
            this.BrowsePaymentBtn.Text = "Browse...";
            this.BrowsePaymentBtn.UseVisualStyleBackColor = true;
            this.BrowsePaymentBtn.Click += new System.EventHandler(this.BrowsePaymentBtn_Click);
            // 
            // dTOClaimDocumentBindingSource
            // 
            this.dTOClaimDocumentBindingSource.DataSource = typeof(MRNNexus_Model.DTO_ClaimDocument);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PaymentComments
            // 
            this.PaymentComments.AcceptsReturn = true;
            this.PaymentComments.AcceptsTab = true;
            this.PaymentComments.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTOClaimDocumentBindingSource, "DocumentComments", true));
            this.PaymentComments.Location = new System.Drawing.Point(12, 193);
            this.PaymentComments.Multiline = true;
            this.PaymentComments.Name = "PaymentComments";
            this.PaymentComments.Size = new System.Drawing.Size(392, 28);
            this.PaymentComments.TabIndex = 10;
            this.PaymentComments.Text = "Additional Comments:";
            this.PaymentComments.Enter += new System.EventHandler(this.PaymentComments_Enter);
            this.PaymentComments.Leave += new System.EventHandler(this.PaymentComments_Leave);
            // 
            // paymentDescriptions
            // 
            this.paymentDescriptions.DataSource = this.dTOLUPaymentDescriptionBindingSource;
            this.paymentDescriptions.DisplayMember = "PaymentDescription";
            this.paymentDescriptions.FormattingEnabled = true;
            this.paymentDescriptions.Location = new System.Drawing.Point(12, 130);
            this.paymentDescriptions.Name = "paymentDescriptions";
            this.paymentDescriptions.Size = new System.Drawing.Size(192, 21);
            this.paymentDescriptions.TabIndex = 11;
            this.paymentDescriptions.Text = "Payment Description";
            this.paymentDescriptions.ValueMember = "PaymentDescriptionID";
            // 
            // dTOLUPaymentDescriptionBindingSource
            // 
            this.dTOLUPaymentDescriptionBindingSource.DataSource = typeof(MRNNexus_Model.DTO_LU_PaymentDescription);
            // 
            // dTOLUClaimStatusTypesBindingSource
            // 
            this.dTOLUClaimStatusTypesBindingSource.DataSource = typeof(MRNNexus_Model.DTO_LU_ClaimStatusTypes);
            this.dTOLUClaimStatusTypesBindingSource.CurrentChanged += new System.EventHandler(this.dTOLUClaimStatusTypesBindingSource_CurrentChanged);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 425);
            this.Controls.Add(this.paymentDescriptions);
            this.Controls.Add(this.PaymentComments);
            this.Controls.Add(this.BrowsePaymentBtn);
            this.Controls.Add(this.ProofOfPaymentImage);
            this.Controls.Add(this.PaymentTypeIDcomboboxP);
            this.Controls.Add(this.PaymentDatePIcker);
            this.Controls.Add(this.MakePaymentBtn);
            this.Controls.Add(this.customerAddressTextBoxPayment);
            this.Controls.Add(this.ClaimCustomerPaymentTextBox);
            this.Controls.Add(this.PaymentClaimID);
            this.Controls.Add(this.paymentAmountTextBox);
            this.Name = "PaymentForm";
            this.Text = "PaymentForm";
            ((System.ComponentModel.ISupportInitialize)(this.paymentAmountTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOPaymentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOClaimBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOLUPaymentTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProofOfPaymentImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOClaimDocumentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOLUPaymentDescriptionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOLUClaimStatusTypesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox paymentAmountTextBox;
        private System.Windows.Forms.ComboBox PaymentClaimID;
        private System.Windows.Forms.MaskedTextBox ClaimCustomerPaymentTextBox;
        private System.Windows.Forms.MaskedTextBox customerAddressTextBoxPayment;
        private System.Windows.Forms.Button MakePaymentBtn;
        private System.Windows.Forms.DateTimePicker PaymentDatePIcker;
        private System.Windows.Forms.ComboBox PaymentTypeIDcomboboxP;
        private System.Windows.Forms.BindingSource dTOLUPaymentTypeBindingSource;
        private System.Windows.Forms.PictureBox ProofOfPaymentImage;
        private System.Windows.Forms.Button BrowsePaymentBtn;
        private System.Windows.Forms.BindingSource dTOClaimBindingSource;
        private System.Windows.Forms.BindingSource dTOPaymentBindingSource;
        private System.Windows.Forms.BindingSource dTOClaimDocumentBindingSource;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox PaymentComments;
        private System.Windows.Forms.ComboBox paymentDescriptions;
        private System.Windows.Forms.BindingSource dTOLUClaimStatusTypesBindingSource;
        private System.Windows.Forms.BindingSource dTOLUPaymentDescriptionBindingSource;
    }
}