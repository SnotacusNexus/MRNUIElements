namespace MRNUIElements
{
    partial class AddClaimStatus
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
            System.Windows.Forms.Label claimIDLabel;
            System.Windows.Forms.Label claimStatusDateLabel;
            System.Windows.Forms.Label claimStatusDateForSerializationLabel;
            System.Windows.Forms.Label claimStatusIDLabel;
            System.Windows.Forms.Label claimStatusTypeIDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClaimStatus));
            this.dTO_ClaimStatusBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.claimIDTextBox = new System.Windows.Forms.TextBox();
            this.claimStatusDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.claimStatusDateForSerializationTextBox = new System.Windows.Forms.TextBox();
            this.claimStatusIDTextBox = new System.Windows.Forms.TextBox();
            this.claimStatusTypeIDTextBox = new System.Windows.Forms.TextBox();
            this.dTO_ClaimStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.dTO_ClaimStatusBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            claimIDLabel = new System.Windows.Forms.Label();
            claimStatusDateLabel = new System.Windows.Forms.Label();
            claimStatusDateForSerializationLabel = new System.Windows.Forms.Label();
            claimStatusIDLabel = new System.Windows.Forms.Label();
            claimStatusTypeIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_ClaimStatusBindingNavigator)).BeginInit();
            this.dTO_ClaimStatusBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_ClaimStatusBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dTO_ClaimStatusBindingNavigator
            // 
            this.dTO_ClaimStatusBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_ClaimStatusBindingNavigator.BindingSource = this.dTO_ClaimStatusBindingSource;
            this.dTO_ClaimStatusBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_ClaimStatusBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_ClaimStatusBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_ClaimStatusBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.dTO_ClaimStatusBindingNavigatorSaveItem});
            this.dTO_ClaimStatusBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_ClaimStatusBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_ClaimStatusBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_ClaimStatusBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_ClaimStatusBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_ClaimStatusBindingNavigator.Name = "dTO_ClaimStatusBindingNavigator";
            this.dTO_ClaimStatusBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_ClaimStatusBindingNavigator.Size = new System.Drawing.Size(500, 31);
            this.dTO_ClaimStatusBindingNavigator.TabIndex = 0;
            this.dTO_ClaimStatusBindingNavigator.Text = "bindingNavigator1";
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
            // claimIDLabel
            // 
            claimIDLabel.AutoSize = true;
            claimIDLabel.Location = new System.Drawing.Point(14, 37);
            claimIDLabel.Name = "claimIDLabel";
            claimIDLabel.Size = new System.Drawing.Size(73, 20);
            claimIDLabel.TabIndex = 1;
            claimIDLabel.Text = "Claim ID:";
            // 
            // claimIDTextBox
            // 
            this.claimIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimStatusBindingSource, "ClaimID", true));
            this.claimIDTextBox.Location = new System.Drawing.Point(280, 34);
            this.claimIDTextBox.Name = "claimIDTextBox";
            this.claimIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.claimIDTextBox.TabIndex = 2;
            // 
            // claimStatusDateLabel
            // 
            claimStatusDateLabel.AutoSize = true;
            claimStatusDateLabel.Location = new System.Drawing.Point(14, 70);
            claimStatusDateLabel.Name = "claimStatusDateLabel";
            claimStatusDateLabel.Size = new System.Drawing.Size(142, 20);
            claimStatusDateLabel.TabIndex = 3;
            claimStatusDateLabel.Text = "Claim Status Date:";
            // 
            // claimStatusDateDateTimePicker
            // 
            this.claimStatusDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_ClaimStatusBindingSource, "ClaimStatusDate", true));
            this.claimStatusDateDateTimePicker.Location = new System.Drawing.Point(280, 66);
            this.claimStatusDateDateTimePicker.Name = "claimStatusDateDateTimePicker";
            this.claimStatusDateDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.claimStatusDateDateTimePicker.TabIndex = 4;
            // 
            // claimStatusDateForSerializationLabel
            // 
            claimStatusDateForSerializationLabel.AutoSize = true;
            claimStatusDateForSerializationLabel.Location = new System.Drawing.Point(14, 101);
            claimStatusDateForSerializationLabel.Name = "claimStatusDateForSerializationLabel";
            claimStatusDateForSerializationLabel.Size = new System.Drawing.Size(260, 20);
            claimStatusDateForSerializationLabel.TabIndex = 5;
            claimStatusDateForSerializationLabel.Text = "Claim Status Date For Serialization:";
            // 
            // claimStatusDateForSerializationTextBox
            // 
            this.claimStatusDateForSerializationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimStatusBindingSource, "ClaimStatusDateForSerialization", true));
            this.claimStatusDateForSerializationTextBox.Location = new System.Drawing.Point(280, 98);
            this.claimStatusDateForSerializationTextBox.Name = "claimStatusDateForSerializationTextBox";
            this.claimStatusDateForSerializationTextBox.Size = new System.Drawing.Size(200, 26);
            this.claimStatusDateForSerializationTextBox.TabIndex = 6;
            // 
            // claimStatusIDLabel
            // 
            claimStatusIDLabel.AutoSize = true;
            claimStatusIDLabel.Location = new System.Drawing.Point(14, 133);
            claimStatusIDLabel.Name = "claimStatusIDLabel";
            claimStatusIDLabel.Size = new System.Drawing.Size(124, 20);
            claimStatusIDLabel.TabIndex = 7;
            claimStatusIDLabel.Text = "Claim Status ID:";
            // 
            // claimStatusIDTextBox
            // 
            this.claimStatusIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimStatusBindingSource, "ClaimStatusID", true));
            this.claimStatusIDTextBox.Location = new System.Drawing.Point(280, 130);
            this.claimStatusIDTextBox.Name = "claimStatusIDTextBox";
            this.claimStatusIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.claimStatusIDTextBox.TabIndex = 8;
            // 
            // claimStatusTypeIDLabel
            // 
            claimStatusTypeIDLabel.AutoSize = true;
            claimStatusTypeIDLabel.Location = new System.Drawing.Point(14, 165);
            claimStatusTypeIDLabel.Name = "claimStatusTypeIDLabel";
            claimStatusTypeIDLabel.Size = new System.Drawing.Size(162, 20);
            claimStatusTypeIDLabel.TabIndex = 9;
            claimStatusTypeIDLabel.Text = "Claim Status Type ID:";
            // 
            // claimStatusTypeIDTextBox
            // 
            this.claimStatusTypeIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimStatusBindingSource, "ClaimStatusTypeID", true));
            this.claimStatusTypeIDTextBox.Location = new System.Drawing.Point(280, 162);
            this.claimStatusTypeIDTextBox.Name = "claimStatusTypeIDTextBox";
            this.claimStatusTypeIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.claimStatusTypeIDTextBox.TabIndex = 10;
            // 
            // dTO_ClaimStatusBindingSource
            // 
            this.dTO_ClaimStatusBindingSource.DataSource = typeof(MRNNexus_Model.DTO_ClaimStatus);
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
            // dTO_ClaimStatusBindingNavigatorSaveItem
            // 
            this.dTO_ClaimStatusBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_ClaimStatusBindingNavigatorSaveItem.Enabled = false;
            this.dTO_ClaimStatusBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_ClaimStatusBindingNavigatorSaveItem.Image")));
            this.dTO_ClaimStatusBindingNavigatorSaveItem.Name = "dTO_ClaimStatusBindingNavigatorSaveItem";
            this.dTO_ClaimStatusBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.dTO_ClaimStatusBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // AddClaimStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 272);
            this.Controls.Add(claimIDLabel);
            this.Controls.Add(this.claimIDTextBox);
            this.Controls.Add(claimStatusDateLabel);
            this.Controls.Add(this.claimStatusDateDateTimePicker);
            this.Controls.Add(claimStatusDateForSerializationLabel);
            this.Controls.Add(this.claimStatusDateForSerializationTextBox);
            this.Controls.Add(claimStatusIDLabel);
            this.Controls.Add(this.claimStatusIDTextBox);
            this.Controls.Add(claimStatusTypeIDLabel);
            this.Controls.Add(this.claimStatusTypeIDTextBox);
            this.Controls.Add(this.dTO_ClaimStatusBindingNavigator);
            this.Name = "AddClaimStatus";
            this.Text = "AddClaimStatus";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_ClaimStatusBindingNavigator)).EndInit();
            this.dTO_ClaimStatusBindingNavigator.ResumeLayout(false);
            this.dTO_ClaimStatusBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_ClaimStatusBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_ClaimStatusBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_ClaimStatusBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton dTO_ClaimStatusBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox claimIDTextBox;
        private System.Windows.Forms.DateTimePicker claimStatusDateDateTimePicker;
        private System.Windows.Forms.TextBox claimStatusDateForSerializationTextBox;
        private System.Windows.Forms.TextBox claimStatusIDTextBox;
        private System.Windows.Forms.TextBox claimStatusTypeIDTextBox;
    }
}