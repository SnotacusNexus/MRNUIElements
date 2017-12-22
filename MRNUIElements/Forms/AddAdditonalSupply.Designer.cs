namespace MRNUIElements
{
    partial class AddAdditonalSupply
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
            System.Windows.Forms.Label additionalSuppliesIDLabel;
            System.Windows.Forms.Label claimIDLabel;
            System.Windows.Forms.Label costLabel;
            System.Windows.Forms.Label dropOffDateLabel;
            System.Windows.Forms.Label itemsLabel;
            System.Windows.Forms.Label pickUpDateLabel;
            System.Windows.Forms.Label receiptImagePathLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAdditonalSupply));
            this.dTO_AdditionalSupplyBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.additionalSuppliesIDTextBox = new System.Windows.Forms.TextBox();
            this.claimIDTextBox = new System.Windows.Forms.TextBox();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.dropOffDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.itemsTextBox = new System.Windows.Forms.TextBox();
            this.pickUpDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.receiptImagePathTextBox = new System.Windows.Forms.TextBox();
            this.dTO_AdditionalSupplyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.dTO_AdditionalSupplyBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            additionalSuppliesIDLabel = new System.Windows.Forms.Label();
            claimIDLabel = new System.Windows.Forms.Label();
            costLabel = new System.Windows.Forms.Label();
            dropOffDateLabel = new System.Windows.Forms.Label();
            itemsLabel = new System.Windows.Forms.Label();
            pickUpDateLabel = new System.Windows.Forms.Label();
            receiptImagePathLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_AdditionalSupplyBindingNavigator)).BeginInit();
            this.dTO_AdditionalSupplyBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_AdditionalSupplyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dTO_AdditionalSupplyBindingNavigator
            // 
            this.dTO_AdditionalSupplyBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_AdditionalSupplyBindingNavigator.BindingSource = this.dTO_AdditionalSupplyBindingSource;
            this.dTO_AdditionalSupplyBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_AdditionalSupplyBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_AdditionalSupplyBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_AdditionalSupplyBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.dTO_AdditionalSupplyBindingNavigatorSaveItem});
            this.dTO_AdditionalSupplyBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_AdditionalSupplyBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_AdditionalSupplyBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_AdditionalSupplyBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_AdditionalSupplyBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_AdditionalSupplyBindingNavigator.Name = "dTO_AdditionalSupplyBindingNavigator";
            this.dTO_AdditionalSupplyBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_AdditionalSupplyBindingNavigator.Size = new System.Drawing.Size(633, 31);
            this.dTO_AdditionalSupplyBindingNavigator.TabIndex = 0;
            this.dTO_AdditionalSupplyBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(54, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // additionalSuppliesIDLabel
            // 
            additionalSuppliesIDLabel.AutoSize = true;
            additionalSuppliesIDLabel.Location = new System.Drawing.Point(84, 67);
            additionalSuppliesIDLabel.Name = "additionalSuppliesIDLabel";
            additionalSuppliesIDLabel.Size = new System.Drawing.Size(169, 20);
            additionalSuppliesIDLabel.TabIndex = 1;
            additionalSuppliesIDLabel.Text = "Additional Supplies ID:";
            // 
            // additionalSuppliesIDTextBox
            // 
            this.additionalSuppliesIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdditionalSupplyBindingSource, "AdditionalSuppliesID", true));
            this.additionalSuppliesIDTextBox.Location = new System.Drawing.Point(259, 64);
            this.additionalSuppliesIDTextBox.Name = "additionalSuppliesIDTextBox";
            this.additionalSuppliesIDTextBox.Size = new System.Drawing.Size(292, 26);
            this.additionalSuppliesIDTextBox.TabIndex = 2;
            // 
            // claimIDLabel
            // 
            claimIDLabel.AutoSize = true;
            claimIDLabel.Location = new System.Drawing.Point(84, 99);
            claimIDLabel.Name = "claimIDLabel";
            claimIDLabel.Size = new System.Drawing.Size(73, 20);
            claimIDLabel.TabIndex = 3;
            claimIDLabel.Text = "Claim ID:";
            // 
            // claimIDTextBox
            // 
            this.claimIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdditionalSupplyBindingSource, "ClaimID", true));
            this.claimIDTextBox.Location = new System.Drawing.Point(259, 96);
            this.claimIDTextBox.Name = "claimIDTextBox";
            this.claimIDTextBox.Size = new System.Drawing.Size(292, 26);
            this.claimIDTextBox.TabIndex = 4;
            // 
            // costLabel
            // 
            costLabel.AutoSize = true;
            costLabel.Location = new System.Drawing.Point(84, 131);
            costLabel.Name = "costLabel";
            costLabel.Size = new System.Drawing.Size(46, 20);
            costLabel.TabIndex = 5;
            costLabel.Text = "Cost:";
            // 
            // costTextBox
            // 
            this.costTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdditionalSupplyBindingSource, "Cost", true));
            this.costTextBox.Location = new System.Drawing.Point(259, 128);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(292, 26);
            this.costTextBox.TabIndex = 6;
            // 
            // dropOffDateLabel
            // 
            dropOffDateLabel.AutoSize = true;
            dropOffDateLabel.Location = new System.Drawing.Point(84, 164);
            dropOffDateLabel.Name = "dropOffDateLabel";
            dropOffDateLabel.Size = new System.Drawing.Size(113, 20);
            dropOffDateLabel.TabIndex = 7;
            dropOffDateLabel.Text = "Drop Off Date:";
            // 
            // dropOffDateDateTimePicker
            // 
            this.dropOffDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_AdditionalSupplyBindingSource, "DropOffDate", true));
            this.dropOffDateDateTimePicker.Location = new System.Drawing.Point(259, 160);
            this.dropOffDateDateTimePicker.Name = "dropOffDateDateTimePicker";
            this.dropOffDateDateTimePicker.Size = new System.Drawing.Size(292, 26);
            this.dropOffDateDateTimePicker.TabIndex = 8;
            // 
            // itemsLabel
            // 
            itemsLabel.AutoSize = true;
            itemsLabel.Location = new System.Drawing.Point(84, 195);
            itemsLabel.Name = "itemsLabel";
            itemsLabel.Size = new System.Drawing.Size(53, 20);
            itemsLabel.TabIndex = 9;
            itemsLabel.Text = "Items:";
            // 
            // itemsTextBox
            // 
            this.itemsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdditionalSupplyBindingSource, "Items", true));
            this.itemsTextBox.Location = new System.Drawing.Point(259, 192);
            this.itemsTextBox.Name = "itemsTextBox";
            this.itemsTextBox.Size = new System.Drawing.Size(292, 26);
            this.itemsTextBox.TabIndex = 10;
            // 
            // pickUpDateLabel
            // 
            pickUpDateLabel.AutoSize = true;
            pickUpDateLabel.Location = new System.Drawing.Point(84, 228);
            pickUpDateLabel.Name = "pickUpDateLabel";
            pickUpDateLabel.Size = new System.Drawing.Size(106, 20);
            pickUpDateLabel.TabIndex = 11;
            pickUpDateLabel.Text = "Pick Up Date:";
            // 
            // pickUpDateDateTimePicker
            // 
            this.pickUpDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_AdditionalSupplyBindingSource, "PickUpDate", true));
            this.pickUpDateDateTimePicker.Location = new System.Drawing.Point(259, 224);
            this.pickUpDateDateTimePicker.Name = "pickUpDateDateTimePicker";
            this.pickUpDateDateTimePicker.Size = new System.Drawing.Size(292, 26);
            this.pickUpDateDateTimePicker.TabIndex = 12;
            // 
            // receiptImagePathLabel
            // 
            receiptImagePathLabel.AutoSize = true;
            receiptImagePathLabel.Location = new System.Drawing.Point(84, 259);
            receiptImagePathLabel.Name = "receiptImagePathLabel";
            receiptImagePathLabel.Size = new System.Drawing.Size(154, 20);
            receiptImagePathLabel.TabIndex = 13;
            receiptImagePathLabel.Text = "Receipt Image Path:";
            // 
            // receiptImagePathTextBox
            // 
            this.receiptImagePathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdditionalSupplyBindingSource, "ReceiptImagePath", true));
            this.receiptImagePathTextBox.Location = new System.Drawing.Point(259, 256);
            this.receiptImagePathTextBox.Name = "receiptImagePathTextBox";
            this.receiptImagePathTextBox.Size = new System.Drawing.Size(292, 26);
            this.receiptImagePathTextBox.TabIndex = 14;
            // 
            // dTO_AdditionalSupplyBindingSource
            // 
            this.dTO_AdditionalSupplyBindingSource.DataSource = typeof(MRNNexus_Model.DTO_AdditionalSupply);
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
            // dTO_AdditionalSupplyBindingNavigatorSaveItem
            // 
            this.dTO_AdditionalSupplyBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_AdditionalSupplyBindingNavigatorSaveItem.Enabled = false;
            this.dTO_AdditionalSupplyBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_AdditionalSupplyBindingNavigatorSaveItem.Image")));
            this.dTO_AdditionalSupplyBindingNavigatorSaveItem.Name = "dTO_AdditionalSupplyBindingNavigatorSaveItem";
            this.dTO_AdditionalSupplyBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.dTO_AdditionalSupplyBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // AddAdditonalSupply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 326);
            this.Controls.Add(additionalSuppliesIDLabel);
            this.Controls.Add(this.additionalSuppliesIDTextBox);
            this.Controls.Add(claimIDLabel);
            this.Controls.Add(this.claimIDTextBox);
            this.Controls.Add(costLabel);
            this.Controls.Add(this.costTextBox);
            this.Controls.Add(dropOffDateLabel);
            this.Controls.Add(this.dropOffDateDateTimePicker);
            this.Controls.Add(itemsLabel);
            this.Controls.Add(this.itemsTextBox);
            this.Controls.Add(pickUpDateLabel);
            this.Controls.Add(this.pickUpDateDateTimePicker);
            this.Controls.Add(receiptImagePathLabel);
            this.Controls.Add(this.receiptImagePathTextBox);
            this.Controls.Add(this.dTO_AdditionalSupplyBindingNavigator);
            this.Name = "AddAdditonalSupply";
            this.Text = "AddAdditonalSupply";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_AdditionalSupplyBindingNavigator)).EndInit();
            this.dTO_AdditionalSupplyBindingNavigator.ResumeLayout(false);
            this.dTO_AdditionalSupplyBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_AdditionalSupplyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_AdditionalSupplyBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_AdditionalSupplyBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton dTO_AdditionalSupplyBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox additionalSuppliesIDTextBox;
        private System.Windows.Forms.TextBox claimIDTextBox;
        private System.Windows.Forms.TextBox costTextBox;
        private System.Windows.Forms.DateTimePicker dropOffDateDateTimePicker;
        private System.Windows.Forms.TextBox itemsTextBox;
        private System.Windows.Forms.DateTimePicker pickUpDateDateTimePicker;
        private System.Windows.Forms.TextBox receiptImagePathTextBox;
    }
}