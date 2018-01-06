namespace MRNUIElements.Forms
{
    partial class AddLead
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
            System.Windows.Forms.Label addressIDLabel;
            System.Windows.Forms.Label creditToIDLabel;
            System.Windows.Forms.Label customerIDLabel;
            System.Windows.Forms.Label knockerResponseIDLabel;
            System.Windows.Forms.Label leadDateLabel;
            System.Windows.Forms.Label leadIDLabel;
            System.Windows.Forms.Label leadTypeIDLabel;
            System.Windows.Forms.Label salesPersonIDLabel;
            System.Windows.Forms.Label temperatureLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLead));
            this.dTO_LeadBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.dTO_LeadBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.dTO_LeadBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.addressIDComboBox = new System.Windows.Forms.ComboBox();
            this.dTOAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.creditToIDComboBox = new System.Windows.Forms.ComboBox();
            this.customerIDComboBox = new System.Windows.Forms.ComboBox();
            this.dTOCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.knockerResponseIDComboBox = new System.Windows.Forms.ComboBox();
            this.dTOLUKnockResponseTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.leadDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.leadIDTextBox = new System.Windows.Forms.TextBox();
            this.leadTypeIDComboBox = new System.Windows.Forms.ComboBox();
            this.dTOLULeadTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salesPersonIDComboBox = new System.Windows.Forms.ComboBox();
            this.dTOEmployeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.temperatureComboBox = new System.Windows.Forms.ComboBox();
            this.Add_Lead = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.successCheckBox = new System.Windows.Forms.CheckBox();
            addressIDLabel = new System.Windows.Forms.Label();
            creditToIDLabel = new System.Windows.Forms.Label();
            customerIDLabel = new System.Windows.Forms.Label();
            knockerResponseIDLabel = new System.Windows.Forms.Label();
            leadDateLabel = new System.Windows.Forms.Label();
            leadIDLabel = new System.Windows.Forms.Label();
            leadTypeIDLabel = new System.Windows.Forms.Label();
            salesPersonIDLabel = new System.Windows.Forms.Label();
            temperatureLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_LeadBindingNavigator)).BeginInit();
            this.dTO_LeadBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_LeadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOAddressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOCustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOLUKnockResponseTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOLULeadTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOEmployeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // addressIDLabel
            // 
            addressIDLabel.AutoSize = true;
            addressIDLabel.Location = new System.Drawing.Point(42, 49);
            addressIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            addressIDLabel.Name = "addressIDLabel";
            addressIDLabel.Size = new System.Drawing.Size(62, 13);
            addressIDLabel.TabIndex = 1;
            addressIDLabel.Text = "Address ID:";
            // 
            // creditToIDLabel
            // 
            creditToIDLabel.AutoSize = true;
            creditToIDLabel.Location = new System.Drawing.Point(42, 71);
            creditToIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            creditToIDLabel.Name = "creditToIDLabel";
            creditToIDLabel.Size = new System.Drawing.Size(67, 13);
            creditToIDLabel.TabIndex = 3;
            creditToIDLabel.Text = "Credit To ID:";
            // 
            // customerIDLabel
            // 
            customerIDLabel.AutoSize = true;
            customerIDLabel.Location = new System.Drawing.Point(42, 94);
            customerIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            customerIDLabel.Name = "customerIDLabel";
            customerIDLabel.Size = new System.Drawing.Size(68, 13);
            customerIDLabel.TabIndex = 5;
            customerIDLabel.Text = "Customer ID:";
            // 
            // knockerResponseIDLabel
            // 
            knockerResponseIDLabel.AutoSize = true;
            knockerResponseIDLabel.Location = new System.Drawing.Point(42, 116);
            knockerResponseIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            knockerResponseIDLabel.Name = "knockerResponseIDLabel";
            knockerResponseIDLabel.Size = new System.Drawing.Size(101, 13);
            knockerResponseIDLabel.TabIndex = 7;
            knockerResponseIDLabel.Text = "Knocker Response:";
            // 
            // leadDateLabel
            // 
            leadDateLabel.AutoSize = true;
            leadDateLabel.Location = new System.Drawing.Point(42, 138);
            leadDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            leadDateLabel.Name = "leadDateLabel";
            leadDateLabel.Size = new System.Drawing.Size(60, 13);
            leadDateLabel.TabIndex = 9;
            leadDateLabel.Text = "Lead Date:";
            // 
            // leadIDLabel
            // 
            leadIDLabel.AutoSize = true;
            leadIDLabel.Location = new System.Drawing.Point(1, 268);
            leadIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            leadIDLabel.Name = "leadIDLabel";
            leadIDLabel.Size = new System.Drawing.Size(48, 13);
            leadIDLabel.TabIndex = 11;
            leadIDLabel.Text = "Lead ID:";
            leadIDLabel.Visible = false;
            // 
            // leadTypeIDLabel
            // 
            leadTypeIDLabel.AutoSize = true;
            leadTypeIDLabel.Location = new System.Drawing.Point(42, 27);
            leadTypeIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            leadTypeIDLabel.Name = "leadTypeIDLabel";
            leadTypeIDLabel.Size = new System.Drawing.Size(75, 13);
            leadTypeIDLabel.TabIndex = 13;
            leadTypeIDLabel.Text = "Lead Type ID:";
            // 
            // salesPersonIDLabel
            // 
            salesPersonIDLabel.AutoSize = true;
            salesPersonIDLabel.Location = new System.Drawing.Point(42, 159);
            salesPersonIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            salesPersonIDLabel.Name = "salesPersonIDLabel";
            salesPersonIDLabel.Size = new System.Drawing.Size(72, 13);
            salesPersonIDLabel.TabIndex = 15;
            salesPersonIDLabel.Text = "Sales Person:";
            // 
            // temperatureLabel
            // 
            temperatureLabel.AutoSize = true;
            temperatureLabel.Location = new System.Drawing.Point(42, 181);
            temperatureLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            temperatureLabel.Name = "temperatureLabel";
            temperatureLabel.Size = new System.Drawing.Size(70, 13);
            temperatureLabel.TabIndex = 17;
            temperatureLabel.Text = "Temperature:";
            // 
            // dTO_LeadBindingNavigator
            // 
            this.dTO_LeadBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_LeadBindingNavigator.BindingSource = this.dTO_LeadBindingSource;
            this.dTO_LeadBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_LeadBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_LeadBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_LeadBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.dTO_LeadBindingNavigatorSaveItem});
            this.dTO_LeadBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_LeadBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_LeadBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_LeadBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_LeadBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_LeadBindingNavigator.Name = "dTO_LeadBindingNavigator";
            this.dTO_LeadBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_LeadBindingNavigator.Size = new System.Drawing.Size(467, 20);
            this.dTO_LeadBindingNavigator.TabIndex = 0;
            this.dTO_LeadBindingNavigator.Text = "bindingNavigator1";
            this.dTO_LeadBindingNavigator.Visible = false;
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
            // dTO_LeadBindingSource
            // 
            this.dTO_LeadBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Lead);
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
            // dTO_LeadBindingNavigatorSaveItem
            // 
            this.dTO_LeadBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_LeadBindingNavigatorSaveItem.Enabled = false;
            this.dTO_LeadBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_LeadBindingNavigatorSaveItem.Image")));
            this.dTO_LeadBindingNavigatorSaveItem.Name = "dTO_LeadBindingNavigatorSaveItem";
            this.dTO_LeadBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 17);
            this.dTO_LeadBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // addressIDComboBox
            // 
            this.addressIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "AddressID", true));
            this.addressIDComboBox.DataSource = this.dTOAddressBindingSource;
            this.addressIDComboBox.DisplayMember = "Address";
            this.addressIDComboBox.Enabled = false;
            this.addressIDComboBox.Location = new System.Drawing.Point(159, 49);
            this.addressIDComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.addressIDComboBox.Name = "addressIDComboBox";
            this.addressIDComboBox.Size = new System.Drawing.Size(188, 21);
            this.addressIDComboBox.TabIndex = 2;
            this.addressIDComboBox.ValueMember = "AddressID";
            // 
            // dTOAddressBindingSource
            // 
            this.dTOAddressBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Address);
            // 
            // creditToIDComboBox
            // 
            this.creditToIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "CreditToID", true));
            this.creditToIDComboBox.FormattingEnabled = true;
            this.creditToIDComboBox.Location = new System.Drawing.Point(159, 70);
            this.creditToIDComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.creditToIDComboBox.Name = "creditToIDComboBox";
            this.creditToIDComboBox.Size = new System.Drawing.Size(188, 21);
            this.creditToIDComboBox.TabIndex = 2;
            this.creditToIDComboBox.SelectedIndexChanged += new System.EventHandler(this.creditToIDComboBox_SelectedIndexChanged);
            // 
            // customerIDComboBox
            // 
            this.customerIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "CustomerID", true));
            this.customerIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.dTOCustomerBindingSource, "CustomerID", true));
            this.customerIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dTOCustomerBindingSource, "CustomerID", true));
            this.customerIDComboBox.DataSource = this.dTOCustomerBindingSource;
            this.customerIDComboBox.DisplayMember = "LastName";
            this.customerIDComboBox.Enabled = false;
            this.customerIDComboBox.Location = new System.Drawing.Point(159, 92);
            this.customerIDComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.customerIDComboBox.Name = "customerIDComboBox";
            this.customerIDComboBox.Size = new System.Drawing.Size(188, 21);
            this.customerIDComboBox.TabIndex = 6;
            this.customerIDComboBox.ValueMember = "CustomerID";
            // 
            // dTOCustomerBindingSource
            // 
            this.dTOCustomerBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Customer);
            // 
            // knockerResponseIDComboBox
            // 
            this.knockerResponseIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "KnockerResponseID", true));
            this.knockerResponseIDComboBox.DataSource = this.dTOLUKnockResponseTypeBindingSource;
            this.knockerResponseIDComboBox.DisplayMember = "KnockResponseType";
            this.knockerResponseIDComboBox.FormattingEnabled = true;
            this.knockerResponseIDComboBox.Location = new System.Drawing.Point(159, 114);
            this.knockerResponseIDComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.knockerResponseIDComboBox.Name = "knockerResponseIDComboBox";
            this.knockerResponseIDComboBox.Size = new System.Drawing.Size(188, 21);
            this.knockerResponseIDComboBox.TabIndex = 3;
            this.knockerResponseIDComboBox.ValueMember = "KnockResponseTypeID";
            this.knockerResponseIDComboBox.SelectedIndexChanged += new System.EventHandler(this.knockerResponseIDComboBox_SelectedIndexChanged);
            // 
            // dTOLUKnockResponseTypeBindingSource
            // 
            this.dTOLUKnockResponseTypeBindingSource.DataSource = typeof(MRNNexus_Model.DTO_LU_KnockResponseType);
            // 
            // leadDateDateTimePicker
            // 
            this.leadDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_LeadBindingSource, "LeadDate", true));
            this.leadDateDateTimePicker.Location = new System.Drawing.Point(159, 136);
            this.leadDateDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.leadDateDateTimePicker.Name = "leadDateDateTimePicker";
            this.leadDateDateTimePicker.Size = new System.Drawing.Size(188, 20);
            this.leadDateDateTimePicker.TabIndex = 4;
            // 
            // leadIDTextBox
            // 
            this.leadIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "LeadID", true));
            this.leadIDTextBox.Enabled = false;
            this.leadIDTextBox.Location = new System.Drawing.Point(52, 266);
            this.leadIDTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.leadIDTextBox.Name = "leadIDTextBox";
            this.leadIDTextBox.ReadOnly = true;
            this.leadIDTextBox.Size = new System.Drawing.Size(57, 20);
            this.leadIDTextBox.TabIndex = 12;
            this.leadIDTextBox.Visible = false;
            // 
            // leadTypeIDComboBox
            // 
            this.leadTypeIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "LeadTypeID", true));
            this.leadTypeIDComboBox.DataSource = this.dTOLULeadTypeBindingSource;
            this.leadTypeIDComboBox.DisplayMember = "LeadType";
            this.leadTypeIDComboBox.FormattingEnabled = true;
            this.leadTypeIDComboBox.Location = new System.Drawing.Point(159, 25);
            this.leadTypeIDComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.leadTypeIDComboBox.Name = "leadTypeIDComboBox";
            this.leadTypeIDComboBox.Size = new System.Drawing.Size(188, 21);
            this.leadTypeIDComboBox.TabIndex = 1;
            this.leadTypeIDComboBox.ValueMember = "LeadTypeID";
            this.leadTypeIDComboBox.SelectedIndexChanged += new System.EventHandler(this.leadTypeIDComboBox_SelectedIndexChanged);
            // 
            // dTOLULeadTypeBindingSource
            // 
            this.dTOLULeadTypeBindingSource.DataSource = typeof(MRNNexus_Model.DTO_LU_LeadType);
            // 
            // salesPersonIDComboBox
            // 
            this.salesPersonIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "SalesPersonID", true));
            this.salesPersonIDComboBox.DataSource = this.dTOEmployeeBindingSource;
            this.salesPersonIDComboBox.DisplayMember = "LastName";
            this.salesPersonIDComboBox.FormattingEnabled = true;
            this.salesPersonIDComboBox.Location = new System.Drawing.Point(159, 157);
            this.salesPersonIDComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.salesPersonIDComboBox.Name = "salesPersonIDComboBox";
            this.salesPersonIDComboBox.Size = new System.Drawing.Size(188, 21);
            this.salesPersonIDComboBox.TabIndex = 5;
            this.salesPersonIDComboBox.ValueMember = "EmployeeID";
            // 
            // dTOEmployeeBindingSource
            // 
            this.dTOEmployeeBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Employee);
            // 
            // temperatureComboBox
            // 
            this.temperatureComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "Temperature", true));
            this.temperatureComboBox.FormattingEnabled = true;
            this.temperatureComboBox.Items.AddRange(new object[] {
            "HOT",
            "Warm",
            "cold"});
            this.temperatureComboBox.Location = new System.Drawing.Point(159, 179);
            this.temperatureComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.temperatureComboBox.Name = "temperatureComboBox";
            this.temperatureComboBox.Size = new System.Drawing.Size(188, 21);
            this.temperatureComboBox.TabIndex = 6;
            // 
            // Add_Lead
            // 
            this.Add_Lead.Enabled = false;
            this.Add_Lead.Location = new System.Drawing.Point(159, 254);
            this.Add_Lead.Margin = new System.Windows.Forms.Padding(2);
            this.Add_Lead.Name = "Add_Lead";
            this.Add_Lead.Size = new System.Drawing.Size(133, 27);
            this.Add_Lead.TabIndex = 8;
            this.Add_Lead.Text = "&Add Lead";
            this.Add_Lead.UseVisualStyleBackColor = true;
            this.Add_Lead.Click += new System.EventHandler(this.Add_Lead_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(350, 71);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 20);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add New Referrer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // successCheckBox
            // 
            this.successCheckBox.Checked = true;
            this.successCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.successCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dTO_LeadBindingSource, "Success", true));
            this.successCheckBox.Location = new System.Drawing.Point(158, 207);
            this.successCheckBox.Name = "successCheckBox";
            this.successCheckBox.Size = new System.Drawing.Size(104, 24);
            this.successCheckBox.TabIndex = 22;
            this.successCheckBox.TabStop = false;
            this.successCheckBox.Text = "Success";
            this.successCheckBox.UseVisualStyleBackColor = true;
            this.successCheckBox.Visible = false;
            // 
            // AddLead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 306);
            this.Controls.Add(this.successCheckBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Add_Lead);
            this.Controls.Add(addressIDLabel);
            this.Controls.Add(this.addressIDComboBox);
            this.Controls.Add(creditToIDLabel);
            this.Controls.Add(this.creditToIDComboBox);
            this.Controls.Add(customerIDLabel);
            this.Controls.Add(this.customerIDComboBox);
            this.Controls.Add(knockerResponseIDLabel);
            this.Controls.Add(this.knockerResponseIDComboBox);
            this.Controls.Add(leadDateLabel);
            this.Controls.Add(this.leadDateDateTimePicker);
            this.Controls.Add(leadIDLabel);
            this.Controls.Add(this.leadIDTextBox);
            this.Controls.Add(leadTypeIDLabel);
            this.Controls.Add(this.leadTypeIDComboBox);
            this.Controls.Add(salesPersonIDLabel);
            this.Controls.Add(this.salesPersonIDComboBox);
            this.Controls.Add(temperatureLabel);
            this.Controls.Add(this.temperatureComboBox);
            this.Controls.Add(this.dTO_LeadBindingNavigator);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddLead";
            this.Text = "AddLead";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_LeadBindingNavigator)).EndInit();
            this.dTO_LeadBindingNavigator.ResumeLayout(false);
            this.dTO_LeadBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_LeadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOAddressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOCustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOLUKnockResponseTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOLULeadTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOEmployeeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_LeadBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_LeadBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton dTO_LeadBindingNavigatorSaveItem;
        private System.Windows.Forms.BindingSource dTOAddressBindingSource;
        private System.Windows.Forms.ComboBox creditToIDComboBox;
        private System.Windows.Forms.BindingSource dTOCustomerBindingSource;
        private System.Windows.Forms.ComboBox knockerResponseIDComboBox;
        private System.Windows.Forms.BindingSource dTOLUKnockResponseTypeBindingSource;
        private System.Windows.Forms.DateTimePicker leadDateDateTimePicker;
        private System.Windows.Forms.TextBox leadIDTextBox;
        private System.Windows.Forms.ComboBox leadTypeIDComboBox;
        private System.Windows.Forms.BindingSource dTOLULeadTypeBindingSource;
        private System.Windows.Forms.ComboBox salesPersonIDComboBox;
        private System.Windows.Forms.ComboBox temperatureComboBox;
        private System.Windows.Forms.Button Add_Lead;
        private System.Windows.Forms.BindingSource dTOEmployeeBindingSource;
        private System.Windows.Forms.ComboBox addressIDComboBox;
        private System.Windows.Forms.ComboBox customerIDComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox successCheckBox;
    }
}