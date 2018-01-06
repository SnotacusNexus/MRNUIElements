namespace MRNUIElements
{
    partial class AddClaim
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
            System.Windows.Forms.Label billingIDLabel;
            System.Windows.Forms.Label claimIDLabel;
            System.Windows.Forms.Label customerIDLabel;
            System.Windows.Forms.Label insuranceClaimNumberLabel;
            System.Windows.Forms.Label insuranceCompanyIDLabel;
            System.Windows.Forms.Label leadIDLabel;
            System.Windows.Forms.Label lossDateLabel;
            System.Windows.Forms.Label mortgageAccountLabel;
            System.Windows.Forms.Label mortgageCompanyLabel;
            System.Windows.Forms.Label mRNNumberLabel;
            System.Windows.Forms.Label propertyIDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClaim));
            this.dTO_ClaimBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.dTO_ClaimBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dTO_ClaimBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.billingIDTextBox = new System.Windows.Forms.ComboBox();
            this.dTOAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.claimIDTextBox = new System.Windows.Forms.TextBox();
            this.contractSignedCheckBox = new System.Windows.Forms.CheckBox();
            this.customerIDTextBox = new System.Windows.Forms.TextBox();
            this.insuranceClaimNumberTextBox = new System.Windows.Forms.TextBox();
            this.isOpenCheckBox = new System.Windows.Forms.CheckBox();
            this.leadIDTextBox = new System.Windows.Forms.TextBox();
            this.lossDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.mortgageAccountTextBox = new System.Windows.Forms.TextBox();
            this.mortgageCompanyTextBox = new System.Windows.Forms.TextBox();
            this.mRNNumberTextBox = new System.Windows.Forms.TextBox();
            this.propertyIDTextBox = new System.Windows.Forms.ComboBox();
            this.AddClaimBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dTOInsuranceCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            billingIDLabel = new System.Windows.Forms.Label();
            claimIDLabel = new System.Windows.Forms.Label();
            customerIDLabel = new System.Windows.Forms.Label();
            insuranceClaimNumberLabel = new System.Windows.Forms.Label();
            insuranceCompanyIDLabel = new System.Windows.Forms.Label();
            leadIDLabel = new System.Windows.Forms.Label();
            lossDateLabel = new System.Windows.Forms.Label();
            mortgageAccountLabel = new System.Windows.Forms.Label();
            mortgageCompanyLabel = new System.Windows.Forms.Label();
            mRNNumberLabel = new System.Windows.Forms.Label();
            propertyIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_ClaimBindingNavigator)).BeginInit();
            this.dTO_ClaimBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_ClaimBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOAddressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOInsuranceCompanyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // billingIDLabel
            // 
            billingIDLabel.AutoSize = true;
            billingIDLabel.Location = new System.Drawing.Point(96, 50);
            billingIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            billingIDLabel.Name = "billingIDLabel";
            billingIDLabel.Size = new System.Drawing.Size(48, 13);
            billingIDLabel.TabIndex = 1;
            billingIDLabel.Text = "Address:";
            // 
            // claimIDLabel
            // 
            claimIDLabel.AutoSize = true;
            claimIDLabel.Location = new System.Drawing.Point(8, 305);
            claimIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            claimIDLabel.Name = "claimIDLabel";
            claimIDLabel.Size = new System.Drawing.Size(49, 13);
            claimIDLabel.TabIndex = 3;
            claimIDLabel.Text = "Claim ID:";
            claimIDLabel.Visible = false;
            // 
            // customerIDLabel
            // 
            customerIDLabel.AutoSize = true;
            customerIDLabel.Location = new System.Drawing.Point(90, 30);
            customerIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            customerIDLabel.Name = "customerIDLabel";
            customerIDLabel.Size = new System.Drawing.Size(54, 13);
            customerIDLabel.TabIndex = 7;
            customerIDLabel.Text = "Customer:";
            // 
            // insuranceClaimNumberLabel
            // 
            insuranceClaimNumberLabel.AutoSize = true;
            insuranceClaimNumberLabel.Location = new System.Drawing.Point(21, 112);
            insuranceClaimNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            insuranceClaimNumberLabel.Name = "insuranceClaimNumberLabel";
            insuranceClaimNumberLabel.Size = new System.Drawing.Size(125, 13);
            insuranceClaimNumberLabel.TabIndex = 9;
            insuranceClaimNumberLabel.Text = "Insurance Claim Number:";
            // 
            // insuranceCompanyIDLabel
            // 
            insuranceCompanyIDLabel.AutoSize = true;
            insuranceCompanyIDLabel.Location = new System.Drawing.Point(27, 132);
            insuranceCompanyIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            insuranceCompanyIDLabel.Name = "insuranceCompanyIDLabel";
            insuranceCompanyIDLabel.Size = new System.Drawing.Size(118, 13);
            insuranceCompanyIDLabel.TabIndex = 11;
            insuranceCompanyIDLabel.Text = "Insurance Company ID:";
            // 
            // leadIDLabel
            // 
            leadIDLabel.AutoSize = true;
            leadIDLabel.Location = new System.Drawing.Point(95, 72);
            leadIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            leadIDLabel.Name = "leadIDLabel";
            leadIDLabel.Size = new System.Drawing.Size(48, 13);
            leadIDLabel.TabIndex = 15;
            leadIDLabel.Text = "Referrer:";
            // 
            // lossDateLabel
            // 
            lossDateLabel.AutoSize = true;
            lossDateLabel.Location = new System.Drawing.Point(85, 153);
            lossDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lossDateLabel.Name = "lossDateLabel";
            lossDateLabel.Size = new System.Drawing.Size(58, 13);
            lossDateLabel.TabIndex = 17;
            lossDateLabel.Text = "Loss Date:";
            // 
            // mortgageAccountLabel
            // 
            mortgageAccountLabel.AutoSize = true;
            mortgageAccountLabel.Location = new System.Drawing.Point(49, 173);
            mortgageAccountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            mortgageAccountLabel.Name = "mortgageAccountLabel";
            mortgageAccountLabel.Size = new System.Drawing.Size(98, 13);
            mortgageAccountLabel.TabIndex = 19;
            mortgageAccountLabel.Text = "Mortgage Account:";
            // 
            // mortgageCompanyLabel
            // 
            mortgageCompanyLabel.AutoSize = true;
            mortgageCompanyLabel.Location = new System.Drawing.Point(45, 198);
            mortgageCompanyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            mortgageCompanyLabel.Name = "mortgageCompanyLabel";
            mortgageCompanyLabel.Size = new System.Drawing.Size(102, 13);
            mortgageCompanyLabel.TabIndex = 21;
            mortgageCompanyLabel.Text = "Mortgage Company:";
            // 
            // mRNNumberLabel
            // 
            mRNNumberLabel.AutoSize = true;
            mRNNumberLabel.Location = new System.Drawing.Point(74, 220);
            mRNNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            mRNNumberLabel.Name = "mRNNumberLabel";
            mRNNumberLabel.Size = new System.Drawing.Size(72, 13);
            mRNNumberLabel.TabIndex = 23;
            mRNNumberLabel.Text = "MRNNumber:";
            // 
            // propertyIDLabel
            // 
            propertyIDLabel.AutoSize = true;
            propertyIDLabel.Location = new System.Drawing.Point(-5, 308);
            propertyIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            propertyIDLabel.Name = "propertyIDLabel";
            propertyIDLabel.Size = new System.Drawing.Size(63, 13);
            propertyIDLabel.TabIndex = 25;
            propertyIDLabel.Text = "Property ID:";
            propertyIDLabel.Visible = false;
            // 
            // dTO_ClaimBindingNavigator
            // 
            this.dTO_ClaimBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_ClaimBindingNavigator.BindingSource = this.dTO_ClaimBindingSource;
            this.dTO_ClaimBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_ClaimBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_ClaimBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_ClaimBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.dTO_ClaimBindingNavigatorSaveItem});
            this.dTO_ClaimBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_ClaimBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_ClaimBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_ClaimBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_ClaimBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_ClaimBindingNavigator.Name = "dTO_ClaimBindingNavigator";
            this.dTO_ClaimBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_ClaimBindingNavigator.Size = new System.Drawing.Size(387, 20);
            this.dTO_ClaimBindingNavigator.TabIndex = 0;
            this.dTO_ClaimBindingNavigator.Text = "bindingNavigator1";
            this.dTO_ClaimBindingNavigator.Visible = false;
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(28, 17);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // dTO_ClaimBindingSource
            // 
            this.dTO_ClaimBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Claim);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 17);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(28, 17);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(28, 17);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(28, 17);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 20);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(35, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 20);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(28, 17);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(28, 17);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 20);
            // 
            // dTO_ClaimBindingNavigatorSaveItem
            // 
            this.dTO_ClaimBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_ClaimBindingNavigatorSaveItem.Enabled = false;
            this.dTO_ClaimBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_ClaimBindingNavigatorSaveItem.Image")));
            this.dTO_ClaimBindingNavigatorSaveItem.Name = "dTO_ClaimBindingNavigatorSaveItem";
            this.dTO_ClaimBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 17);
            this.dTO_ClaimBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // billingIDTextBox
            // 
            this.billingIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimBindingSource, "BillingID", true));
            this.billingIDTextBox.DataSource = this.dTOAddressBindingSource;
            this.billingIDTextBox.DisplayMember = "Address";
            this.billingIDTextBox.Location = new System.Drawing.Point(9, 317);
            this.billingIDTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.billingIDTextBox.Name = "billingIDTextBox";
            this.billingIDTextBox.Size = new System.Drawing.Size(135, 21);
            this.billingIDTextBox.TabIndex = 2;
            this.billingIDTextBox.ValueMember = "AddressID";
            this.billingIDTextBox.Visible = false;
            // 
            // dTOAddressBindingSource
            // 
            this.dTOAddressBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Address);
            // 
            // claimIDTextBox
            // 
            this.claimIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimBindingSource, "ClaimID", true));
            this.claimIDTextBox.Location = new System.Drawing.Point(5, 320);
            this.claimIDTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.claimIDTextBox.Name = "claimIDTextBox";
            this.claimIDTextBox.ReadOnly = true;
            this.claimIDTextBox.Size = new System.Drawing.Size(135, 20);
            this.claimIDTextBox.TabIndex = 4;
            this.claimIDTextBox.Visible = false;
            // 
            // contractSignedCheckBox
            // 
            this.contractSignedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dTO_ClaimBindingSource, "ContractSigned", true));
            this.contractSignedCheckBox.Location = new System.Drawing.Point(150, 274);
            this.contractSignedCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.contractSignedCheckBox.Name = "contractSignedCheckBox";
            this.contractSignedCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contractSignedCheckBox.Size = new System.Drawing.Size(133, 16);
            this.contractSignedCheckBox.TabIndex = 13;
            this.contractSignedCheckBox.Text = "Contract Signed            ";
            this.contractSignedCheckBox.UseVisualStyleBackColor = true;
            // 
            // customerIDTextBox
            // 
            this.customerIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimBindingSource, "CustomerID", true));
            this.customerIDTextBox.Location = new System.Drawing.Point(149, 28);
            this.customerIDTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.customerIDTextBox.Name = "customerIDTextBox";
            this.customerIDTextBox.ReadOnly = true;
            this.customerIDTextBox.Size = new System.Drawing.Size(135, 20);
            this.customerIDTextBox.TabIndex = 8;
            // 
            // insuranceClaimNumberTextBox
            // 
            this.insuranceClaimNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimBindingSource, "InsuranceClaimNumber", true));
            this.insuranceClaimNumberTextBox.Location = new System.Drawing.Point(149, 110);
            this.insuranceClaimNumberTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.insuranceClaimNumberTextBox.Name = "insuranceClaimNumberTextBox";
            this.insuranceClaimNumberTextBox.Size = new System.Drawing.Size(135, 20);
            this.insuranceClaimNumberTextBox.TabIndex = 7;
            // 
            // isOpenCheckBox
            // 
            this.isOpenCheckBox.Checked = true;
            this.isOpenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isOpenCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dTO_ClaimBindingSource, "IsOpen", true));
            this.isOpenCheckBox.Location = new System.Drawing.Point(293, 220);
            this.isOpenCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.isOpenCheckBox.Name = "isOpenCheckBox";
            this.isOpenCheckBox.Size = new System.Drawing.Size(92, 20);
            this.isOpenCheckBox.TabIndex = 12;
            this.isOpenCheckBox.Text = "Open Claim";
            this.isOpenCheckBox.UseVisualStyleBackColor = true;
            // 
            // leadIDTextBox
            // 
            this.leadIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimBindingSource, "LeadID", true));
            this.leadIDTextBox.Location = new System.Drawing.Point(149, 70);
            this.leadIDTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.leadIDTextBox.Name = "leadIDTextBox";
            this.leadIDTextBox.ReadOnly = true;
            this.leadIDTextBox.Size = new System.Drawing.Size(135, 20);
            this.leadIDTextBox.TabIndex = 16;
            // 
            // lossDateDateTimePicker
            // 
            this.lossDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_ClaimBindingSource, "LossDate", true));
            this.lossDateDateTimePicker.Location = new System.Drawing.Point(149, 150);
            this.lossDateDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.lossDateDateTimePicker.Name = "lossDateDateTimePicker";
            this.lossDateDateTimePicker.Size = new System.Drawing.Size(231, 20);
            this.lossDateDateTimePicker.TabIndex = 9;
            // 
            // mortgageAccountTextBox
            // 
            this.mortgageAccountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimBindingSource, "MortgageAccount", true));
            this.mortgageAccountTextBox.Location = new System.Drawing.Point(149, 171);
            this.mortgageAccountTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.mortgageAccountTextBox.Name = "mortgageAccountTextBox";
            this.mortgageAccountTextBox.Size = new System.Drawing.Size(231, 20);
            this.mortgageAccountTextBox.TabIndex = 10;
            // 
            // mortgageCompanyTextBox
            // 
            this.mortgageCompanyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimBindingSource, "MortgageCompany", true));
            this.mortgageCompanyTextBox.Location = new System.Drawing.Point(149, 194);
            this.mortgageCompanyTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.mortgageCompanyTextBox.Name = "mortgageCompanyTextBox";
            this.mortgageCompanyTextBox.Size = new System.Drawing.Size(231, 20);
            this.mortgageCompanyTextBox.TabIndex = 11;
            // 
            // mRNNumberTextBox
            // 
            this.mRNNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimBindingSource, "MRNNumber", true));
            this.mRNNumberTextBox.Location = new System.Drawing.Point(149, 220);
            this.mRNNumberTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.mRNNumberTextBox.Name = "mRNNumberTextBox";
            this.mRNNumberTextBox.ReadOnly = true;
            this.mRNNumberTextBox.Size = new System.Drawing.Size(135, 20);
            this.mRNNumberTextBox.TabIndex = 15;
            // 
            // propertyIDTextBox
            // 
            this.propertyIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimBindingSource, "PropertyID", true));
            this.propertyIDTextBox.Location = new System.Drawing.Point(11, 320);
            this.propertyIDTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.propertyIDTextBox.Name = "propertyIDTextBox";
            this.propertyIDTextBox.Size = new System.Drawing.Size(135, 21);
            this.propertyIDTextBox.TabIndex = 26;
            this.propertyIDTextBox.Visible = false;
            // 
            // AddClaimBtn
            // 
            this.AddClaimBtn.Enabled = false;
            this.AddClaimBtn.Location = new System.Drawing.Point(158, 294);
            this.AddClaimBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddClaimBtn.Name = "AddClaimBtn";
            this.AddClaimBtn.Size = new System.Drawing.Size(125, 42);
            this.AddClaimBtn.TabIndex = 14;
            this.AddClaimBtn.Text = "Add Claim";
            this.AddClaimBtn.UseVisualStyleBackColor = true;
            this.AddClaimBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(287, 49);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 20);
            this.button2.TabIndex = 2;
            this.button2.Text = "Select Address";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(286, 27);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 21);
            this.button4.TabIndex = 1;
            this.button4.Text = "Select Customer";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(287, 70);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 20);
            this.button5.TabIndex = 3;
            this.button5.Text = "Select Lead";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(24, 320);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(92, 21);
            this.button7.TabIndex = 33;
            this.button7.Text = "Select Property Address";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.dTOInsuranceCompanyBindingSource, "InsuranceCompanyID", true));
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dTOInsuranceCompanyBindingSource, "InsuranceCompanyID", true));
            this.comboBox2.DataSource = this.dTOInsuranceCompanyBindingSource;
            this.comboBox2.DisplayMember = "CompanyName";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(149, 128);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(231, 21);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.ValueMember = "InsuranceCompanyID";
            // 
            // dTOInsuranceCompanyBindingSource
            // 
            this.dTOInsuranceCompanyBindingSource.DataSource = typeof(MRNNexus_Model.DTO_InsuranceCompany);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(149, 90);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(135, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(287, 91);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 19);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add Inspection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(149, 49);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.ReadOnly = true;
            this.addressTextBox.Size = new System.Drawing.Size(135, 20);
            this.addressTextBox.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Inspection Date:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(42, 94);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // AddClaim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 343);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AddClaimBtn);
            this.Controls.Add(billingIDLabel);
            this.Controls.Add(this.billingIDTextBox);
            this.Controls.Add(claimIDLabel);
            this.Controls.Add(this.claimIDTextBox);
            this.Controls.Add(this.contractSignedCheckBox);
            this.Controls.Add(customerIDLabel);
            this.Controls.Add(this.customerIDTextBox);
            this.Controls.Add(insuranceClaimNumberLabel);
            this.Controls.Add(this.insuranceClaimNumberTextBox);
            this.Controls.Add(insuranceCompanyIDLabel);
            this.Controls.Add(this.isOpenCheckBox);
            this.Controls.Add(leadIDLabel);
            this.Controls.Add(this.leadIDTextBox);
            this.Controls.Add(lossDateLabel);
            this.Controls.Add(this.lossDateDateTimePicker);
            this.Controls.Add(mortgageAccountLabel);
            this.Controls.Add(this.mortgageAccountTextBox);
            this.Controls.Add(mortgageCompanyLabel);
            this.Controls.Add(this.mortgageCompanyTextBox);
            this.Controls.Add(mRNNumberLabel);
            this.Controls.Add(this.mRNNumberTextBox);
            this.Controls.Add(propertyIDLabel);
            this.Controls.Add(this.propertyIDTextBox);
            this.Controls.Add(this.dTO_ClaimBindingNavigator);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddClaim";
            this.Text = "AddClaim";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_ClaimBindingNavigator)).EndInit();
            this.dTO_ClaimBindingNavigator.ResumeLayout(false);
            this.dTO_ClaimBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_ClaimBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOAddressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOInsuranceCompanyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_ClaimBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_ClaimBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton dTO_ClaimBindingNavigatorSaveItem;
        private System.Windows.Forms.ComboBox billingIDTextBox;
        private System.Windows.Forms.TextBox claimIDTextBox;
        private System.Windows.Forms.CheckBox contractSignedCheckBox;
        private System.Windows.Forms.TextBox customerIDTextBox;
        private System.Windows.Forms.TextBox insuranceClaimNumberTextBox;
        private System.Windows.Forms.CheckBox isOpenCheckBox;
        private System.Windows.Forms.TextBox leadIDTextBox;
        private System.Windows.Forms.DateTimePicker lossDateDateTimePicker;
        private System.Windows.Forms.TextBox mortgageAccountTextBox;
        private System.Windows.Forms.TextBox mortgageCompanyTextBox;
        private System.Windows.Forms.TextBox mRNNumberTextBox;
        private System.Windows.Forms.ComboBox propertyIDTextBox;
        private System.Windows.Forms.Button AddClaimBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource dTOInsuranceCompanyBindingSource;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource dTOAddressBindingSource;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}