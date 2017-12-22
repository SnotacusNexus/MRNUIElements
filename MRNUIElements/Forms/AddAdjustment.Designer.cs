namespace MRNUIElements
{
    partial class AddAdjustment
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
            System.Windows.Forms.Label adjusterIDLabel;
            System.Windows.Forms.Label adjustmentCommentLabel;
            System.Windows.Forms.Label adjustmentDateLabel;
            System.Windows.Forms.Label adjustmentIDLabel;
            System.Windows.Forms.Label adjustmentResultIDLabel;
            System.Windows.Forms.Label claimIDLabel;
            System.Windows.Forms.Label exteriorLabel;
            System.Windows.Forms.Label guttersLabel;
            System.Windows.Forms.Label interiorLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAdjustment));
            this.dTO_AdjustmentBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.adjusterIDTextBox = new System.Windows.Forms.TextBox();
            this.adjustmentCommentTextBox = new System.Windows.Forms.TextBox();
            this.adjustmentDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.adjustmentIDTextBox = new System.Windows.Forms.TextBox();
            this.adjustmentResultIDTextBox = new System.Windows.Forms.TextBox();
            this.claimIDTextBox = new System.Windows.Forms.TextBox();
            this.exteriorCheckBox = new System.Windows.Forms.CheckBox();
            this.guttersCheckBox = new System.Windows.Forms.CheckBox();
            this.interiorCheckBox = new System.Windows.Forms.CheckBox();
            this.dTO_AdjustmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.dTO_AdjustmentBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            adjusterIDLabel = new System.Windows.Forms.Label();
            adjustmentCommentLabel = new System.Windows.Forms.Label();
            adjustmentDateLabel = new System.Windows.Forms.Label();
            adjustmentIDLabel = new System.Windows.Forms.Label();
            adjustmentResultIDLabel = new System.Windows.Forms.Label();
            claimIDLabel = new System.Windows.Forms.Label();
            exteriorLabel = new System.Windows.Forms.Label();
            guttersLabel = new System.Windows.Forms.Label();
            interiorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_AdjustmentBindingNavigator)).BeginInit();
            this.dTO_AdjustmentBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_AdjustmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dTO_AdjustmentBindingNavigator
            // 
            this.dTO_AdjustmentBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_AdjustmentBindingNavigator.BindingSource = this.dTO_AdjustmentBindingSource;
            this.dTO_AdjustmentBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_AdjustmentBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_AdjustmentBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_AdjustmentBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.dTO_AdjustmentBindingNavigatorSaveItem});
            this.dTO_AdjustmentBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_AdjustmentBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_AdjustmentBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_AdjustmentBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_AdjustmentBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_AdjustmentBindingNavigator.Name = "dTO_AdjustmentBindingNavigator";
            this.dTO_AdjustmentBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_AdjustmentBindingNavigator.Size = new System.Drawing.Size(633, 31);
            this.dTO_AdjustmentBindingNavigator.TabIndex = 0;
            this.dTO_AdjustmentBindingNavigator.Text = "bindingNavigator1";
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
            // adjusterIDLabel
            // 
            adjusterIDLabel.AutoSize = true;
            adjusterIDLabel.Location = new System.Drawing.Point(96, 85);
            adjusterIDLabel.Name = "adjusterIDLabel";
            adjusterIDLabel.Size = new System.Drawing.Size(93, 20);
            adjusterIDLabel.TabIndex = 1;
            adjusterIDLabel.Text = "Adjuster ID:";
            // 
            // adjusterIDTextBox
            // 
            this.adjusterIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjustmentBindingSource, "AdjusterID", true));
            this.adjusterIDTextBox.Location = new System.Drawing.Point(269, 82);
            this.adjusterIDTextBox.Name = "adjusterIDTextBox";
            this.adjusterIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.adjusterIDTextBox.TabIndex = 2;
            // 
            // adjustmentCommentLabel
            // 
            adjustmentCommentLabel.AutoSize = true;
            adjustmentCommentLabel.Location = new System.Drawing.Point(96, 117);
            adjustmentCommentLabel.Name = "adjustmentCommentLabel";
            adjustmentCommentLabel.Size = new System.Drawing.Size(167, 20);
            adjustmentCommentLabel.TabIndex = 3;
            adjustmentCommentLabel.Text = "Adjustment Comment:";
            // 
            // adjustmentCommentTextBox
            // 
            this.adjustmentCommentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjustmentBindingSource, "AdjustmentComment", true));
            this.adjustmentCommentTextBox.Location = new System.Drawing.Point(269, 114);
            this.adjustmentCommentTextBox.Name = "adjustmentCommentTextBox";
            this.adjustmentCommentTextBox.Size = new System.Drawing.Size(200, 26);
            this.adjustmentCommentTextBox.TabIndex = 4;
            // 
            // adjustmentDateLabel
            // 
            adjustmentDateLabel.AutoSize = true;
            adjustmentDateLabel.Location = new System.Drawing.Point(96, 150);
            adjustmentDateLabel.Name = "adjustmentDateLabel";
            adjustmentDateLabel.Size = new System.Drawing.Size(133, 20);
            adjustmentDateLabel.TabIndex = 5;
            adjustmentDateLabel.Text = "Adjustment Date:";
            // 
            // adjustmentDateDateTimePicker
            // 
            this.adjustmentDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_AdjustmentBindingSource, "AdjustmentDate", true));
            this.adjustmentDateDateTimePicker.Location = new System.Drawing.Point(269, 146);
            this.adjustmentDateDateTimePicker.Name = "adjustmentDateDateTimePicker";
            this.adjustmentDateDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.adjustmentDateDateTimePicker.TabIndex = 6;
            // 
            // adjustmentIDLabel
            // 
            adjustmentIDLabel.AutoSize = true;
            adjustmentIDLabel.Location = new System.Drawing.Point(96, 181);
            adjustmentIDLabel.Name = "adjustmentIDLabel";
            adjustmentIDLabel.Size = new System.Drawing.Size(115, 20);
            adjustmentIDLabel.TabIndex = 7;
            adjustmentIDLabel.Text = "Adjustment ID:";
            // 
            // adjustmentIDTextBox
            // 
            this.adjustmentIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjustmentBindingSource, "AdjustmentID", true));
            this.adjustmentIDTextBox.Location = new System.Drawing.Point(269, 178);
            this.adjustmentIDTextBox.Name = "adjustmentIDTextBox";
            this.adjustmentIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.adjustmentIDTextBox.TabIndex = 8;
            // 
            // adjustmentResultIDLabel
            // 
            adjustmentResultIDLabel.AutoSize = true;
            adjustmentResultIDLabel.Location = new System.Drawing.Point(96, 213);
            adjustmentResultIDLabel.Name = "adjustmentResultIDLabel";
            adjustmentResultIDLabel.Size = new System.Drawing.Size(165, 20);
            adjustmentResultIDLabel.TabIndex = 9;
            adjustmentResultIDLabel.Text = "Adjustment Result ID:";
            // 
            // adjustmentResultIDTextBox
            // 
            this.adjustmentResultIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjustmentBindingSource, "AdjustmentResultID", true));
            this.adjustmentResultIDTextBox.Location = new System.Drawing.Point(269, 210);
            this.adjustmentResultIDTextBox.Name = "adjustmentResultIDTextBox";
            this.adjustmentResultIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.adjustmentResultIDTextBox.TabIndex = 10;
            // 
            // claimIDLabel
            // 
            claimIDLabel.AutoSize = true;
            claimIDLabel.Location = new System.Drawing.Point(96, 245);
            claimIDLabel.Name = "claimIDLabel";
            claimIDLabel.Size = new System.Drawing.Size(73, 20);
            claimIDLabel.TabIndex = 11;
            claimIDLabel.Text = "Claim ID:";
            // 
            // claimIDTextBox
            // 
            this.claimIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjustmentBindingSource, "ClaimID", true));
            this.claimIDTextBox.Location = new System.Drawing.Point(269, 242);
            this.claimIDTextBox.Name = "claimIDTextBox";
            this.claimIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.claimIDTextBox.TabIndex = 12;
            // 
            // exteriorLabel
            // 
            exteriorLabel.AutoSize = true;
            exteriorLabel.Location = new System.Drawing.Point(96, 279);
            exteriorLabel.Name = "exteriorLabel";
            exteriorLabel.Size = new System.Drawing.Size(67, 20);
            exteriorLabel.TabIndex = 13;
            exteriorLabel.Text = "Exterior:";
            // 
            // exteriorCheckBox
            // 
            this.exteriorCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dTO_AdjustmentBindingSource, "Exterior", true));
            this.exteriorCheckBox.Location = new System.Drawing.Point(269, 274);
            this.exteriorCheckBox.Name = "exteriorCheckBox";
            this.exteriorCheckBox.Size = new System.Drawing.Size(200, 24);
            this.exteriorCheckBox.TabIndex = 14;
            this.exteriorCheckBox.Text = "checkBox1";
            this.exteriorCheckBox.UseVisualStyleBackColor = true;
            // 
            // guttersLabel
            // 
            guttersLabel.AutoSize = true;
            guttersLabel.Location = new System.Drawing.Point(96, 310);
            guttersLabel.Name = "guttersLabel";
            guttersLabel.Size = new System.Drawing.Size(67, 20);
            guttersLabel.TabIndex = 15;
            guttersLabel.Text = "Gutters:";
            // 
            // guttersCheckBox
            // 
            this.guttersCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dTO_AdjustmentBindingSource, "Gutters", true));
            this.guttersCheckBox.Location = new System.Drawing.Point(269, 305);
            this.guttersCheckBox.Name = "guttersCheckBox";
            this.guttersCheckBox.Size = new System.Drawing.Size(200, 24);
            this.guttersCheckBox.TabIndex = 16;
            this.guttersCheckBox.Text = "checkBox1";
            this.guttersCheckBox.UseVisualStyleBackColor = true;
            // 
            // interiorLabel
            // 
            interiorLabel.AutoSize = true;
            interiorLabel.Location = new System.Drawing.Point(96, 341);
            interiorLabel.Name = "interiorLabel";
            interiorLabel.Size = new System.Drawing.Size(63, 20);
            interiorLabel.TabIndex = 17;
            interiorLabel.Text = "Interior:";
            // 
            // interiorCheckBox
            // 
            this.interiorCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dTO_AdjustmentBindingSource, "Interior", true));
            this.interiorCheckBox.Location = new System.Drawing.Point(269, 336);
            this.interiorCheckBox.Name = "interiorCheckBox";
            this.interiorCheckBox.Size = new System.Drawing.Size(200, 24);
            this.interiorCheckBox.TabIndex = 18;
            this.interiorCheckBox.Text = "checkBox1";
            this.interiorCheckBox.UseVisualStyleBackColor = true;
            // 
            // dTO_AdjustmentBindingSource
            // 
            this.dTO_AdjustmentBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Adjustment);
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
            // dTO_AdjustmentBindingNavigatorSaveItem
            // 
            this.dTO_AdjustmentBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_AdjustmentBindingNavigatorSaveItem.Enabled = false;
            this.dTO_AdjustmentBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_AdjustmentBindingNavigatorSaveItem.Image")));
            this.dTO_AdjustmentBindingNavigatorSaveItem.Name = "dTO_AdjustmentBindingNavigatorSaveItem";
            this.dTO_AdjustmentBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.dTO_AdjustmentBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // AddAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 381);
            this.Controls.Add(adjusterIDLabel);
            this.Controls.Add(this.adjusterIDTextBox);
            this.Controls.Add(adjustmentCommentLabel);
            this.Controls.Add(this.adjustmentCommentTextBox);
            this.Controls.Add(adjustmentDateLabel);
            this.Controls.Add(this.adjustmentDateDateTimePicker);
            this.Controls.Add(adjustmentIDLabel);
            this.Controls.Add(this.adjustmentIDTextBox);
            this.Controls.Add(adjustmentResultIDLabel);
            this.Controls.Add(this.adjustmentResultIDTextBox);
            this.Controls.Add(claimIDLabel);
            this.Controls.Add(this.claimIDTextBox);
            this.Controls.Add(exteriorLabel);
            this.Controls.Add(this.exteriorCheckBox);
            this.Controls.Add(guttersLabel);
            this.Controls.Add(this.guttersCheckBox);
            this.Controls.Add(interiorLabel);
            this.Controls.Add(this.interiorCheckBox);
            this.Controls.Add(this.dTO_AdjustmentBindingNavigator);
            this.Name = "AddAdjustment";
            this.Text = "AddAdjustment";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_AdjustmentBindingNavigator)).EndInit();
            this.dTO_AdjustmentBindingNavigator.ResumeLayout(false);
            this.dTO_AdjustmentBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_AdjustmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_AdjustmentBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_AdjustmentBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton dTO_AdjustmentBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox adjusterIDTextBox;
        private System.Windows.Forms.TextBox adjustmentCommentTextBox;
        private System.Windows.Forms.DateTimePicker adjustmentDateDateTimePicker;
        private System.Windows.Forms.TextBox adjustmentIDTextBox;
        private System.Windows.Forms.TextBox adjustmentResultIDTextBox;
        private System.Windows.Forms.TextBox claimIDTextBox;
        private System.Windows.Forms.CheckBox exteriorCheckBox;
        private System.Windows.Forms.CheckBox guttersCheckBox;
        private System.Windows.Forms.CheckBox interiorCheckBox;
    }
}