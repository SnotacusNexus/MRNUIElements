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
            this.creditToIDComboBox = new System.Windows.Forms.ComboBox();
            this.customerIDComboBox = new System.Windows.Forms.ComboBox();
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
            this.dTOAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTOCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.dTOLUKnockResponseTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOLULeadTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOEmployeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOAddressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOCustomerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // addressIDLabel
            // 
            addressIDLabel.AutoSize = true;
            addressIDLabel.Location = new System.Drawing.Point(63, 76);
            addressIDLabel.Name = "addressIDLabel";
            addressIDLabel.Size = new System.Drawing.Size(93, 20);
            addressIDLabel.TabIndex = 1;
            addressIDLabel.Text = "Address ID:";
            // 
            // creditToIDLabel
            // 
            creditToIDLabel.AutoSize = true;
            creditToIDLabel.Location = new System.Drawing.Point(63, 110);
            creditToIDLabel.Name = "creditToIDLabel";
            creditToIDLabel.Size = new System.Drawing.Size(98, 20);
            creditToIDLabel.TabIndex = 3;
            creditToIDLabel.Text = "Credit To ID:";
            // 
            // customerIDLabel
            // 
            customerIDLabel.AutoSize = true;
            customerIDLabel.Location = new System.Drawing.Point(63, 144);
            customerIDLabel.Name = "customerIDLabel";
            customerIDLabel.Size = new System.Drawing.Size(103, 20);
            customerIDLabel.TabIndex = 5;
            customerIDLabel.Text = "Customer ID:";
            // 
            // knockerResponseIDLabel
            // 
            knockerResponseIDLabel.AutoSize = true;
            knockerResponseIDLabel.Location = new System.Drawing.Point(63, 178);
            knockerResponseIDLabel.Name = "knockerResponseIDLabel";
            knockerResponseIDLabel.Size = new System.Drawing.Size(148, 20);
            knockerResponseIDLabel.TabIndex = 7;
            knockerResponseIDLabel.Text = "Knocker Response:";
            // 
            // leadDateLabel
            // 
            leadDateLabel.AutoSize = true;
            leadDateLabel.Location = new System.Drawing.Point(63, 213);
            leadDateLabel.Name = "leadDateLabel";
            leadDateLabel.Size = new System.Drawing.Size(88, 20);
            leadDateLabel.TabIndex = 9;
            leadDateLabel.Text = "Lead Date:";
            // 
            // leadIDLabel
            // 
            leadIDLabel.AutoSize = true;
            leadIDLabel.Location = new System.Drawing.Point(2, 413);
            leadIDLabel.Name = "leadIDLabel";
            leadIDLabel.Size = new System.Drawing.Size(70, 20);
            leadIDLabel.TabIndex = 11;
            leadIDLabel.Text = "Lead ID:";
            leadIDLabel.Visible = false;
            // 
            // leadTypeIDLabel
            // 
            leadTypeIDLabel.AutoSize = true;
            leadTypeIDLabel.Location = new System.Drawing.Point(63, 42);
            leadTypeIDLabel.Name = "leadTypeIDLabel";
            leadTypeIDLabel.Size = new System.Drawing.Size(108, 20);
            leadTypeIDLabel.TabIndex = 13;
            leadTypeIDLabel.Text = "Lead Type ID:";
            // 
            // salesPersonIDLabel
            // 
            salesPersonIDLabel.AutoSize = true;
            salesPersonIDLabel.Location = new System.Drawing.Point(63, 245);
            salesPersonIDLabel.Name = "salesPersonIDLabel";
            salesPersonIDLabel.Size = new System.Drawing.Size(107, 20);
            salesPersonIDLabel.TabIndex = 15;
            salesPersonIDLabel.Text = "Sales Person:";
            // 
            // temperatureLabel
            // 
            temperatureLabel.AutoSize = true;
            temperatureLabel.Location = new System.Drawing.Point(63, 279);
            temperatureLabel.Name = "temperatureLabel";
            temperatureLabel.Size = new System.Drawing.Size(104, 20);
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
            this.dTO_LeadBindingNavigator.Size = new System.Drawing.Size(619, 31);
            this.dTO_LeadBindingNavigator.TabIndex = 0;
            this.dTO_LeadBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // dTO_LeadBindingSource
            // 
            this.dTO_LeadBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Lead);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(54, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 31);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // dTO_LeadBindingNavigatorSaveItem
            // 
            this.dTO_LeadBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_LeadBindingNavigatorSaveItem.Enabled = false;
            this.dTO_LeadBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_LeadBindingNavigatorSaveItem.Image")));
            this.dTO_LeadBindingNavigatorSaveItem.Name = "dTO_LeadBindingNavigatorSaveItem";
            this.dTO_LeadBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.dTO_LeadBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // addressIDComboBox
            // 
            this.addressIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "AddressID", true));
            this.addressIDComboBox.DataSource = this.dTOAddressBindingSource;
            this.addressIDComboBox.DisplayMember = "Address";
            this.addressIDComboBox.Location = new System.Drawing.Point(238, 75);
            this.addressIDComboBox.Name = "addressIDComboBox";
            this.addressIDComboBox.Size = new System.Drawing.Size(280, 28);
            this.addressIDComboBox.TabIndex = 2;
            this.addressIDComboBox.ValueMember = "AddressID";
            // 
            // creditToIDComboBox
            // 
            this.creditToIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "CreditToID", true));
            this.creditToIDComboBox.FormattingEnabled = true;
            this.creditToIDComboBox.Location = new System.Drawing.Point(238, 107);
            this.creditToIDComboBox.Name = "creditToIDComboBox";
            this.creditToIDComboBox.Size = new System.Drawing.Size(280, 28);
            this.creditToIDComboBox.TabIndex = 4;
            this.creditToIDComboBox.SelectedIndexChanged += new System.EventHandler(this.creditToIDComboBox_SelectedIndexChanged);
            // 
            // customerIDComboBox
            // 
            this.customerIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "CustomerID", true));
            this.customerIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.dTOCustomerBindingSource, "CustomerID", true));
            this.customerIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dTOCustomerBindingSource, "CustomerID", true));
            this.customerIDComboBox.DataSource = this.dTOCustomerBindingSource;
            this.customerIDComboBox.Location = new System.Drawing.Point(238, 141);
            this.customerIDComboBox.Name = "customerIDComboBox";
            this.customerIDComboBox.Size = new System.Drawing.Size(280, 28);
            this.customerIDComboBox.TabIndex = 6;
            // 
            // knockerResponseIDComboBox
            // 
            this.knockerResponseIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "KnockerResponseID", true));
            this.knockerResponseIDComboBox.DataSource = this.dTOLUKnockResponseTypeBindingSource;
            this.knockerResponseIDComboBox.DisplayMember = "KnockResponseType";
            this.knockerResponseIDComboBox.FormattingEnabled = true;
            this.knockerResponseIDComboBox.Location = new System.Drawing.Point(238, 175);
            this.knockerResponseIDComboBox.Name = "knockerResponseIDComboBox";
            this.knockerResponseIDComboBox.Size = new System.Drawing.Size(280, 28);
            this.knockerResponseIDComboBox.TabIndex = 8;
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
            this.leadDateDateTimePicker.Location = new System.Drawing.Point(238, 209);
            this.leadDateDateTimePicker.Name = "leadDateDateTimePicker";
            this.leadDateDateTimePicker.Size = new System.Drawing.Size(280, 26);
            this.leadDateDateTimePicker.TabIndex = 10;
            // 
            // leadIDTextBox
            // 
            this.leadIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "LeadID", true));
            this.leadIDTextBox.Enabled = false;
            this.leadIDTextBox.Location = new System.Drawing.Point(78, 410);
            this.leadIDTextBox.Name = "leadIDTextBox";
            this.leadIDTextBox.ReadOnly = true;
            this.leadIDTextBox.Size = new System.Drawing.Size(83, 26);
            this.leadIDTextBox.TabIndex = 12;
            this.leadIDTextBox.Visible = false;
            // 
            // leadTypeIDComboBox
            // 
            this.leadTypeIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_LeadBindingSource, "LeadTypeID", true));
            this.leadTypeIDComboBox.DataSource = this.dTOLULeadTypeBindingSource;
            this.leadTypeIDComboBox.DisplayMember = "LeadType";
            this.leadTypeIDComboBox.FormattingEnabled = true;
            this.leadTypeIDComboBox.Location = new System.Drawing.Point(238, 39);
            this.leadTypeIDComboBox.Name = "leadTypeIDComboBox";
            this.leadTypeIDComboBox.Size = new System.Drawing.Size(280, 28);
            this.leadTypeIDComboBox.TabIndex = 14;
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
            this.salesPersonIDComboBox.Location = new System.Drawing.Point(238, 242);
            this.salesPersonIDComboBox.Name = "salesPersonIDComboBox";
            this.salesPersonIDComboBox.Size = new System.Drawing.Size(280, 28);
            this.salesPersonIDComboBox.TabIndex = 16;
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
            this.temperatureComboBox.Location = new System.Drawing.Point(238, 276);
            this.temperatureComboBox.Name = "temperatureComboBox";
            this.temperatureComboBox.Size = new System.Drawing.Size(280, 28);
            this.temperatureComboBox.TabIndex = 18;
            // 
            // Add_Lead
            // 
            this.Add_Lead.Enabled = false;
            this.Add_Lead.Location = new System.Drawing.Point(238, 391);
            this.Add_Lead.Name = "Add_Lead";
            this.Add_Lead.Size = new System.Drawing.Size(200, 42);
            this.Add_Lead.TabIndex = 19;
            this.Add_Lead.Text = "Add Lead";
            this.Add_Lead.UseVisualStyleBackColor = true;
            this.Add_Lead.Click += new System.EventHandler(this.Add_Lead_Click);
            // 
            // dTOAddressBindingSource
            // 
            this.dTOAddressBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Address);
            // 
            // dTOCustomerBindingSource
            // 
            this.dTOCustomerBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Customer);
            // 
            // AddLead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 445);
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
            this.Name = "AddLead";
            this.Text = "AddLead";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_LeadBindingNavigator)).EndInit();
            this.dTO_LeadBindingNavigator.ResumeLayout(false);
            this.dTO_LeadBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_LeadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOLUKnockResponseTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOLULeadTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOEmployeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOAddressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOCustomerBindingSource)).EndInit();
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
    }
}