namespace MRNUIElements
{
    partial class AddNewOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewOrder));
            System.Windows.Forms.Label claimIDLabel;
            System.Windows.Forms.Label dateDroppedLabel;
            System.Windows.Forms.Label dateOrderedLabel;
            System.Windows.Forms.Label orderIDLabel;
            System.Windows.Forms.Label scheduledInstallationLabel;
            System.Windows.Forms.Label vendorIDLabel;
            this.dTO_OrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTO_OrderBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.dTO_OrderBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.claimIDTextBox = new System.Windows.Forms.TextBox();
            this.dateDroppedDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateOrderedDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.orderIDTextBox = new System.Windows.Forms.TextBox();
            this.scheduledInstallationDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vendorIDTextBox = new System.Windows.Forms.TextBox();
            claimIDLabel = new System.Windows.Forms.Label();
            dateDroppedLabel = new System.Windows.Forms.Label();
            dateOrderedLabel = new System.Windows.Forms.Label();
            orderIDLabel = new System.Windows.Forms.Label();
            scheduledInstallationLabel = new System.Windows.Forms.Label();
            vendorIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_OrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_OrderBindingNavigator)).BeginInit();
            this.dTO_OrderBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // dTO_OrderBindingSource
            // 
            this.dTO_OrderBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Order);
            // 
            // dTO_OrderBindingNavigator
            // 
            this.dTO_OrderBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_OrderBindingNavigator.BindingSource = this.dTO_OrderBindingSource;
            this.dTO_OrderBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_OrderBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_OrderBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_OrderBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.dTO_OrderBindingNavigatorSaveItem});
            this.dTO_OrderBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_OrderBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_OrderBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_OrderBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_OrderBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_OrderBindingNavigator.Name = "dTO_OrderBindingNavigator";
            this.dTO_OrderBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_OrderBindingNavigator.Size = new System.Drawing.Size(432, 33);
            this.dTO_OrderBindingNavigator.TabIndex = 0;
            this.dTO_OrderBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(28, 30);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(28, 30);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 33);
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(54, 30);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(28, 30);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(28, 30);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(28, 30);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(28, 30);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // dTO_OrderBindingNavigatorSaveItem
            // 
            this.dTO_OrderBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_OrderBindingNavigatorSaveItem.Enabled = false;
            this.dTO_OrderBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_OrderBindingNavigatorSaveItem.Image")));
            this.dTO_OrderBindingNavigatorSaveItem.Name = "dTO_OrderBindingNavigatorSaveItem";
            this.dTO_OrderBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 30);
            this.dTO_OrderBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // claimIDLabel
            // 
            claimIDLabel.AutoSize = true;
            claimIDLabel.Location = new System.Drawing.Point(36, 45);
            claimIDLabel.Name = "claimIDLabel";
            claimIDLabel.Size = new System.Drawing.Size(73, 20);
            claimIDLabel.TabIndex = 1;
            claimIDLabel.Text = "Claim ID:";
            // 
            // claimIDTextBox
            // 
            this.claimIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_OrderBindingSource, "ClaimID", true));
            this.claimIDTextBox.Location = new System.Drawing.Point(212, 42);
            this.claimIDTextBox.Name = "claimIDTextBox";
            this.claimIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.claimIDTextBox.TabIndex = 2;
            // 
            // dateDroppedLabel
            // 
            dateDroppedLabel.AutoSize = true;
            dateDroppedLabel.Location = new System.Drawing.Point(36, 78);
            dateDroppedLabel.Name = "dateDroppedLabel";
            dateDroppedLabel.Size = new System.Drawing.Size(114, 20);
            dateDroppedLabel.TabIndex = 3;
            dateDroppedLabel.Text = "Date Dropped:";
            // 
            // dateDroppedDateTimePicker
            // 
            this.dateDroppedDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_OrderBindingSource, "DateDropped", true));
            this.dateDroppedDateTimePicker.Location = new System.Drawing.Point(212, 74);
            this.dateDroppedDateTimePicker.Name = "dateDroppedDateTimePicker";
            this.dateDroppedDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.dateDroppedDateTimePicker.TabIndex = 4;
            // 
            // dateOrderedLabel
            // 
            dateOrderedLabel.AutoSize = true;
            dateOrderedLabel.Location = new System.Drawing.Point(36, 110);
            dateOrderedLabel.Name = "dateOrderedLabel";
            dateOrderedLabel.Size = new System.Drawing.Size(110, 20);
            dateOrderedLabel.TabIndex = 5;
            dateOrderedLabel.Text = "Date Ordered:";
            // 
            // dateOrderedDateTimePicker
            // 
            this.dateOrderedDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_OrderBindingSource, "DateOrdered", true));
            this.dateOrderedDateTimePicker.Location = new System.Drawing.Point(212, 106);
            this.dateOrderedDateTimePicker.Name = "dateOrderedDateTimePicker";
            this.dateOrderedDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.dateOrderedDateTimePicker.TabIndex = 6;
            // 
            // orderIDLabel
            // 
            orderIDLabel.AutoSize = true;
            orderIDLabel.Location = new System.Drawing.Point(36, 141);
            orderIDLabel.Name = "orderIDLabel";
            orderIDLabel.Size = new System.Drawing.Size(74, 20);
            orderIDLabel.TabIndex = 7;
            orderIDLabel.Text = "Order ID:";
            // 
            // orderIDTextBox
            // 
            this.orderIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_OrderBindingSource, "OrderID", true));
            this.orderIDTextBox.Location = new System.Drawing.Point(212, 138);
            this.orderIDTextBox.Name = "orderIDTextBox";
            this.orderIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.orderIDTextBox.TabIndex = 8;
            // 
            // scheduledInstallationLabel
            // 
            scheduledInstallationLabel.AutoSize = true;
            scheduledInstallationLabel.Location = new System.Drawing.Point(36, 174);
            scheduledInstallationLabel.Name = "scheduledInstallationLabel";
            scheduledInstallationLabel.Size = new System.Drawing.Size(170, 20);
            scheduledInstallationLabel.TabIndex = 9;
            scheduledInstallationLabel.Text = "Scheduled Installation:";
            // 
            // scheduledInstallationDateTimePicker
            // 
            this.scheduledInstallationDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_OrderBindingSource, "ScheduledInstallation", true));
            this.scheduledInstallationDateTimePicker.Location = new System.Drawing.Point(212, 170);
            this.scheduledInstallationDateTimePicker.Name = "scheduledInstallationDateTimePicker";
            this.scheduledInstallationDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.scheduledInstallationDateTimePicker.TabIndex = 10;
            // 
            // vendorIDLabel
            // 
            vendorIDLabel.AutoSize = true;
            vendorIDLabel.Location = new System.Drawing.Point(36, 205);
            vendorIDLabel.Name = "vendorIDLabel";
            vendorIDLabel.Size = new System.Drawing.Size(86, 20);
            vendorIDLabel.TabIndex = 11;
            vendorIDLabel.Text = "Vendor ID:";
            // 
            // vendorIDTextBox
            // 
            this.vendorIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_OrderBindingSource, "VendorID", true));
            this.vendorIDTextBox.Location = new System.Drawing.Point(212, 202);
            this.vendorIDTextBox.Name = "vendorIDTextBox";
            this.vendorIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.vendorIDTextBox.TabIndex = 12;
            // 
            // AddNewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 248);
            this.Controls.Add(claimIDLabel);
            this.Controls.Add(this.claimIDTextBox);
            this.Controls.Add(dateDroppedLabel);
            this.Controls.Add(this.dateDroppedDateTimePicker);
            this.Controls.Add(dateOrderedLabel);
            this.Controls.Add(this.dateOrderedDateTimePicker);
            this.Controls.Add(orderIDLabel);
            this.Controls.Add(this.orderIDTextBox);
            this.Controls.Add(scheduledInstallationLabel);
            this.Controls.Add(this.scheduledInstallationDateTimePicker);
            this.Controls.Add(vendorIDLabel);
            this.Controls.Add(this.vendorIDTextBox);
            this.Controls.Add(this.dTO_OrderBindingNavigator);
            this.Name = "AddNewOrder";
            this.Text = "AddNewOrder";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_OrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_OrderBindingNavigator)).EndInit();
            this.dTO_OrderBindingNavigator.ResumeLayout(false);
            this.dTO_OrderBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_OrderBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_OrderBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton dTO_OrderBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox claimIDTextBox;
        private System.Windows.Forms.DateTimePicker dateDroppedDateTimePicker;
        private System.Windows.Forms.DateTimePicker dateOrderedDateTimePicker;
        private System.Windows.Forms.TextBox orderIDTextBox;
        private System.Windows.Forms.DateTimePicker scheduledInstallationDateTimePicker;
        private System.Windows.Forms.TextBox vendorIDTextBox;
    }
}