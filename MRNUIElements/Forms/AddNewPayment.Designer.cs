namespace MRNUIElements
{
    partial class AddNewPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewPayment));
            System.Windows.Forms.Label amountLabel;
            System.Windows.Forms.Label claimIDLabel;
            System.Windows.Forms.Label paymentDateLabel;
            System.Windows.Forms.Label paymentDescriptionIDLabel;
            System.Windows.Forms.Label paymentIDLabel;
            System.Windows.Forms.Label paymentTypeIDLabel;
            this.dTO_PaymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTO_PaymentBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.dTO_PaymentBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.claimIDTextBox = new System.Windows.Forms.TextBox();
            this.paymentDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.paymentDescriptionIDTextBox = new System.Windows.Forms.TextBox();
            this.paymentIDTextBox = new System.Windows.Forms.TextBox();
            this.paymentTypeIDTextBox = new System.Windows.Forms.TextBox();
            amountLabel = new System.Windows.Forms.Label();
            claimIDLabel = new System.Windows.Forms.Label();
            paymentDateLabel = new System.Windows.Forms.Label();
            paymentDescriptionIDLabel = new System.Windows.Forms.Label();
            paymentIDLabel = new System.Windows.Forms.Label();
            paymentTypeIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_PaymentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_PaymentBindingNavigator)).BeginInit();
            this.dTO_PaymentBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // dTO_PaymentBindingSource
            // 
            this.dTO_PaymentBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Payment);
            // 
            // dTO_PaymentBindingNavigator
            // 
            this.dTO_PaymentBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_PaymentBindingNavigator.BindingSource = this.dTO_PaymentBindingSource;
            this.dTO_PaymentBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_PaymentBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_PaymentBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_PaymentBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.dTO_PaymentBindingNavigatorSaveItem});
            this.dTO_PaymentBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_PaymentBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_PaymentBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_PaymentBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_PaymentBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_PaymentBindingNavigator.Name = "dTO_PaymentBindingNavigator";
            this.dTO_PaymentBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_PaymentBindingNavigator.Size = new System.Drawing.Size(426, 33);
            this.dTO_PaymentBindingNavigator.TabIndex = 0;
            this.dTO_PaymentBindingNavigator.Text = "bindingNavigator1";
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
            // dTO_PaymentBindingNavigatorSaveItem
            // 
            this.dTO_PaymentBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_PaymentBindingNavigatorSaveItem.Enabled = false;
            this.dTO_PaymentBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_PaymentBindingNavigatorSaveItem.Image")));
            this.dTO_PaymentBindingNavigatorSaveItem.Name = "dTO_PaymentBindingNavigatorSaveItem";
            this.dTO_PaymentBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 30);
            this.dTO_PaymentBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = true;
            amountLabel.Location = new System.Drawing.Point(20, 33);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new System.Drawing.Size(69, 20);
            amountLabel.TabIndex = 1;
            amountLabel.Text = "Amount:";
            // 
            // amountTextBox
            // 
            this.amountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_PaymentBindingSource, "Amount", true));
            this.amountTextBox.Location = new System.Drawing.Point(206, 30);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(200, 26);
            this.amountTextBox.TabIndex = 2;
            // 
            // claimIDLabel
            // 
            claimIDLabel.AutoSize = true;
            claimIDLabel.Location = new System.Drawing.Point(20, 65);
            claimIDLabel.Name = "claimIDLabel";
            claimIDLabel.Size = new System.Drawing.Size(73, 20);
            claimIDLabel.TabIndex = 3;
            claimIDLabel.Text = "Claim ID:";
            // 
            // claimIDTextBox
            // 
            this.claimIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_PaymentBindingSource, "ClaimID", true));
            this.claimIDTextBox.Location = new System.Drawing.Point(206, 62);
            this.claimIDTextBox.Name = "claimIDTextBox";
            this.claimIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.claimIDTextBox.TabIndex = 4;
            // 
            // paymentDateLabel
            // 
            paymentDateLabel.AutoSize = true;
            paymentDateLabel.Location = new System.Drawing.Point(20, 98);
            paymentDateLabel.Name = "paymentDateLabel";
            paymentDateLabel.Size = new System.Drawing.Size(114, 20);
            paymentDateLabel.TabIndex = 5;
            paymentDateLabel.Text = "Payment Date:";
            // 
            // paymentDateDateTimePicker
            // 
            this.paymentDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_PaymentBindingSource, "PaymentDate", true));
            this.paymentDateDateTimePicker.Location = new System.Drawing.Point(206, 94);
            this.paymentDateDateTimePicker.Name = "paymentDateDateTimePicker";
            this.paymentDateDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.paymentDateDateTimePicker.TabIndex = 6;
            // 
            // paymentDescriptionIDLabel
            // 
            paymentDescriptionIDLabel.AutoSize = true;
            paymentDescriptionIDLabel.Location = new System.Drawing.Point(20, 129);
            paymentDescriptionIDLabel.Name = "paymentDescriptionIDLabel";
            paymentDescriptionIDLabel.Size = new System.Drawing.Size(180, 20);
            paymentDescriptionIDLabel.TabIndex = 7;
            paymentDescriptionIDLabel.Text = "Payment Description ID:";
            // 
            // paymentDescriptionIDTextBox
            // 
            this.paymentDescriptionIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_PaymentBindingSource, "PaymentDescriptionID", true));
            this.paymentDescriptionIDTextBox.Location = new System.Drawing.Point(206, 126);
            this.paymentDescriptionIDTextBox.Name = "paymentDescriptionIDTextBox";
            this.paymentDescriptionIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.paymentDescriptionIDTextBox.TabIndex = 8;
            // 
            // paymentIDLabel
            // 
            paymentIDLabel.AutoSize = true;
            paymentIDLabel.Location = new System.Drawing.Point(20, 161);
            paymentIDLabel.Name = "paymentIDLabel";
            paymentIDLabel.Size = new System.Drawing.Size(96, 20);
            paymentIDLabel.TabIndex = 9;
            paymentIDLabel.Text = "Payment ID:";
            // 
            // paymentIDTextBox
            // 
            this.paymentIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_PaymentBindingSource, "PaymentID", true));
            this.paymentIDTextBox.Location = new System.Drawing.Point(206, 158);
            this.paymentIDTextBox.Name = "paymentIDTextBox";
            this.paymentIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.paymentIDTextBox.TabIndex = 10;
            // 
            // paymentTypeIDLabel
            // 
            paymentTypeIDLabel.AutoSize = true;
            paymentTypeIDLabel.Location = new System.Drawing.Point(20, 193);
            paymentTypeIDLabel.Name = "paymentTypeIDLabel";
            paymentTypeIDLabel.Size = new System.Drawing.Size(134, 20);
            paymentTypeIDLabel.TabIndex = 11;
            paymentTypeIDLabel.Text = "Payment Type ID:";
            // 
            // paymentTypeIDTextBox
            // 
            this.paymentTypeIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_PaymentBindingSource, "PaymentTypeID", true));
            this.paymentTypeIDTextBox.Location = new System.Drawing.Point(206, 190);
            this.paymentTypeIDTextBox.Name = "paymentTypeIDTextBox";
            this.paymentTypeIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.paymentTypeIDTextBox.TabIndex = 12;
            // 
            // AddNewPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 244);
            this.Controls.Add(amountLabel);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(claimIDLabel);
            this.Controls.Add(this.claimIDTextBox);
            this.Controls.Add(paymentDateLabel);
            this.Controls.Add(this.paymentDateDateTimePicker);
            this.Controls.Add(paymentDescriptionIDLabel);
            this.Controls.Add(this.paymentDescriptionIDTextBox);
            this.Controls.Add(paymentIDLabel);
            this.Controls.Add(this.paymentIDTextBox);
            this.Controls.Add(paymentTypeIDLabel);
            this.Controls.Add(this.paymentTypeIDTextBox);
            this.Controls.Add(this.dTO_PaymentBindingNavigator);
            this.Name = "AddNewPayment";
            this.Text = "AddNewPayment";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_PaymentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_PaymentBindingNavigator)).EndInit();
            this.dTO_PaymentBindingNavigator.ResumeLayout(false);
            this.dTO_PaymentBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_PaymentBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_PaymentBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton dTO_PaymentBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.TextBox claimIDTextBox;
        private System.Windows.Forms.DateTimePicker paymentDateDateTimePicker;
        private System.Windows.Forms.TextBox paymentDescriptionIDTextBox;
        private System.Windows.Forms.TextBox paymentIDTextBox;
        private System.Windows.Forms.TextBox paymentTypeIDTextBox;
    }
}