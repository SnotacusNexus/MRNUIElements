namespace MRN_Claim_Services
{
    partial class AddSurplusSupplies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSurplusSupplies));
            System.Windows.Forms.Label claimIDLabel;
            System.Windows.Forms.Label dropOffDateLabel;
            System.Windows.Forms.Label itemsLabel;
            System.Windows.Forms.Label pickUpDateLabel;
            System.Windows.Forms.Label quantityLabel;
            System.Windows.Forms.Label surplusSuppliesIDLabel;
            System.Windows.Forms.Label unitOfMeasureIDLabel;
            this.dTO_SurplusSuppliesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dTO_SurplusSuppliesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.dTO_SurplusSuppliesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.claimIDTextBox = new System.Windows.Forms.TextBox();
            this.dropOffDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.itemsTextBox = new System.Windows.Forms.TextBox();
            this.pickUpDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.surplusSuppliesIDTextBox = new System.Windows.Forms.TextBox();
            this.unitOfMeasureIDTextBox = new System.Windows.Forms.TextBox();
            claimIDLabel = new System.Windows.Forms.Label();
            dropOffDateLabel = new System.Windows.Forms.Label();
            itemsLabel = new System.Windows.Forms.Label();
            pickUpDateLabel = new System.Windows.Forms.Label();
            quantityLabel = new System.Windows.Forms.Label();
            surplusSuppliesIDLabel = new System.Windows.Forms.Label();
            unitOfMeasureIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_SurplusSuppliesBindingNavigator)).BeginInit();
            this.dTO_SurplusSuppliesBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_SurplusSuppliesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dTO_SurplusSuppliesBindingNavigator
            // 
            this.dTO_SurplusSuppliesBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_SurplusSuppliesBindingNavigator.BindingSource = this.dTO_SurplusSuppliesBindingSource;
            this.dTO_SurplusSuppliesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_SurplusSuppliesBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_SurplusSuppliesBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_SurplusSuppliesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.dTO_SurplusSuppliesBindingNavigatorSaveItem});
            this.dTO_SurplusSuppliesBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_SurplusSuppliesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_SurplusSuppliesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_SurplusSuppliesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_SurplusSuppliesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_SurplusSuppliesBindingNavigator.Name = "dTO_SurplusSuppliesBindingNavigator";
            this.dTO_SurplusSuppliesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_SurplusSuppliesBindingNavigator.Size = new System.Drawing.Size(463, 31);
            this.dTO_SurplusSuppliesBindingNavigator.TabIndex = 0;
            this.dTO_SurplusSuppliesBindingNavigator.Text = "bindingNavigator1";
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
            // dTO_SurplusSuppliesBindingSource
            // 
            this.dTO_SurplusSuppliesBindingSource.DataSource = typeof(MRNNexus_Model.DTO_SurplusSupplies);
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
            // dTO_SurplusSuppliesBindingNavigatorSaveItem
            // 
            this.dTO_SurplusSuppliesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_SurplusSuppliesBindingNavigatorSaveItem.Enabled = false;
            this.dTO_SurplusSuppliesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_SurplusSuppliesBindingNavigatorSaveItem.Image")));
            this.dTO_SurplusSuppliesBindingNavigatorSaveItem.Name = "dTO_SurplusSuppliesBindingNavigatorSaveItem";
            this.dTO_SurplusSuppliesBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.dTO_SurplusSuppliesBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // claimIDLabel
            // 
            claimIDLabel.AutoSize = true;
            claimIDLabel.Location = new System.Drawing.Point(84, 87);
            claimIDLabel.Name = "claimIDLabel";
            claimIDLabel.Size = new System.Drawing.Size(73, 20);
            claimIDLabel.TabIndex = 1;
            claimIDLabel.Text = "Claim ID:";
            // 
            // claimIDTextBox
            // 
            this.claimIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_SurplusSuppliesBindingSource, "ClaimID", true));
            this.claimIDTextBox.Location = new System.Drawing.Point(243, 84);
            this.claimIDTextBox.Name = "claimIDTextBox";
            this.claimIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.claimIDTextBox.TabIndex = 2;
            // 
            // dropOffDateLabel
            // 
            dropOffDateLabel.AutoSize = true;
            dropOffDateLabel.Location = new System.Drawing.Point(84, 120);
            dropOffDateLabel.Name = "dropOffDateLabel";
            dropOffDateLabel.Size = new System.Drawing.Size(113, 20);
            dropOffDateLabel.TabIndex = 3;
            dropOffDateLabel.Text = "Drop Off Date:";
            // 
            // dropOffDateDateTimePicker
            // 
            this.dropOffDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_SurplusSuppliesBindingSource, "DropOffDate", true));
            this.dropOffDateDateTimePicker.Location = new System.Drawing.Point(243, 116);
            this.dropOffDateDateTimePicker.Name = "dropOffDateDateTimePicker";
            this.dropOffDateDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.dropOffDateDateTimePicker.TabIndex = 4;
            // 
            // itemsLabel
            // 
            itemsLabel.AutoSize = true;
            itemsLabel.Location = new System.Drawing.Point(84, 151);
            itemsLabel.Name = "itemsLabel";
            itemsLabel.Size = new System.Drawing.Size(53, 20);
            itemsLabel.TabIndex = 5;
            itemsLabel.Text = "Items:";
            // 
            // itemsTextBox
            // 
            this.itemsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_SurplusSuppliesBindingSource, "Items", true));
            this.itemsTextBox.Location = new System.Drawing.Point(243, 148);
            this.itemsTextBox.Name = "itemsTextBox";
            this.itemsTextBox.Size = new System.Drawing.Size(200, 26);
            this.itemsTextBox.TabIndex = 6;
            // 
            // pickUpDateLabel
            // 
            pickUpDateLabel.AutoSize = true;
            pickUpDateLabel.Location = new System.Drawing.Point(84, 184);
            pickUpDateLabel.Name = "pickUpDateLabel";
            pickUpDateLabel.Size = new System.Drawing.Size(106, 20);
            pickUpDateLabel.TabIndex = 7;
            pickUpDateLabel.Text = "Pick Up Date:";
            // 
            // pickUpDateDateTimePicker
            // 
            this.pickUpDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_SurplusSuppliesBindingSource, "PickUpDate", true));
            this.pickUpDateDateTimePicker.Location = new System.Drawing.Point(243, 180);
            this.pickUpDateDateTimePicker.Name = "pickUpDateDateTimePicker";
            this.pickUpDateDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.pickUpDateDateTimePicker.TabIndex = 8;
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.Location = new System.Drawing.Point(84, 215);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new System.Drawing.Size(72, 20);
            quantityLabel.TabIndex = 9;
            quantityLabel.Text = "Quantity:";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_SurplusSuppliesBindingSource, "Quantity", true));
            this.quantityTextBox.Location = new System.Drawing.Point(243, 212);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(200, 26);
            this.quantityTextBox.TabIndex = 10;
            // 
            // surplusSuppliesIDLabel
            // 
            surplusSuppliesIDLabel.AutoSize = true;
            surplusSuppliesIDLabel.Location = new System.Drawing.Point(84, 247);
            surplusSuppliesIDLabel.Name = "surplusSuppliesIDLabel";
            surplusSuppliesIDLabel.Size = new System.Drawing.Size(153, 20);
            surplusSuppliesIDLabel.TabIndex = 11;
            surplusSuppliesIDLabel.Text = "Surplus Supplies ID:";
            // 
            // surplusSuppliesIDTextBox
            // 
            this.surplusSuppliesIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_SurplusSuppliesBindingSource, "SurplusSuppliesID", true));
            this.surplusSuppliesIDTextBox.Location = new System.Drawing.Point(243, 244);
            this.surplusSuppliesIDTextBox.Name = "surplusSuppliesIDTextBox";
            this.surplusSuppliesIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.surplusSuppliesIDTextBox.TabIndex = 12;
            // 
            // unitOfMeasureIDLabel
            // 
            unitOfMeasureIDLabel.AutoSize = true;
            unitOfMeasureIDLabel.Location = new System.Drawing.Point(84, 279);
            unitOfMeasureIDLabel.Name = "unitOfMeasureIDLabel";
            unitOfMeasureIDLabel.Size = new System.Drawing.Size(150, 20);
            unitOfMeasureIDLabel.TabIndex = 13;
            unitOfMeasureIDLabel.Text = "Unit Of Measure ID:";
            // 
            // unitOfMeasureIDTextBox
            // 
            this.unitOfMeasureIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_SurplusSuppliesBindingSource, "UnitOfMeasureID", true));
            this.unitOfMeasureIDTextBox.Location = new System.Drawing.Point(243, 276);
            this.unitOfMeasureIDTextBox.Name = "unitOfMeasureIDTextBox";
            this.unitOfMeasureIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.unitOfMeasureIDTextBox.TabIndex = 14;
            // 
            // AddSurplusSupplies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 322);
            this.Controls.Add(claimIDLabel);
            this.Controls.Add(this.claimIDTextBox);
            this.Controls.Add(dropOffDateLabel);
            this.Controls.Add(this.dropOffDateDateTimePicker);
            this.Controls.Add(itemsLabel);
            this.Controls.Add(this.itemsTextBox);
            this.Controls.Add(pickUpDateLabel);
            this.Controls.Add(this.pickUpDateDateTimePicker);
            this.Controls.Add(quantityLabel);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(surplusSuppliesIDLabel);
            this.Controls.Add(this.surplusSuppliesIDTextBox);
            this.Controls.Add(unitOfMeasureIDLabel);
            this.Controls.Add(this.unitOfMeasureIDTextBox);
            this.Controls.Add(this.dTO_SurplusSuppliesBindingNavigator);
            this.Name = "AddSurplusSupplies";
            this.Text = "AddSurplusSupplies";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_SurplusSuppliesBindingNavigator)).EndInit();
            this.dTO_SurplusSuppliesBindingNavigator.ResumeLayout(false);
            this.dTO_SurplusSuppliesBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_SurplusSuppliesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_SurplusSuppliesBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_SurplusSuppliesBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton dTO_SurplusSuppliesBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox claimIDTextBox;
        private System.Windows.Forms.DateTimePicker dropOffDateDateTimePicker;
        private System.Windows.Forms.TextBox itemsTextBox;
        private System.Windows.Forms.DateTimePicker pickUpDateDateTimePicker;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.TextBox surplusSuppliesIDTextBox;
        private System.Windows.Forms.TextBox unitOfMeasureIDTextBox;
    }
}