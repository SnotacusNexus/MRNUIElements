namespace MRN_Claim_Services
{
    partial class AddAdjuster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAdjuster));
            System.Windows.Forms.Label adjusterIDLabel;
            System.Windows.Forms.Label commentsLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label insuranceCompanyIDLabel;
            System.Windows.Forms.Label lastNameLabel;
            System.Windows.Forms.Label phoneExtLabel;
            System.Windows.Forms.Label phoneNumberLabel;
            System.Windows.Forms.Label suffixLabel;
            this.dTO_AdjusterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTO_AdjusterBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.dTO_AdjusterBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.adjusterIDTextBox = new System.Windows.Forms.TextBox();
            this.commentsTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.insuranceCompanyIDTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.phoneExtTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.suffixTextBox = new System.Windows.Forms.TextBox();
            adjusterIDLabel = new System.Windows.Forms.Label();
            commentsLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            insuranceCompanyIDLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            phoneExtLabel = new System.Windows.Forms.Label();
            phoneNumberLabel = new System.Windows.Forms.Label();
            suffixLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_AdjusterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_AdjusterBindingNavigator)).BeginInit();
            this.dTO_AdjusterBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // dTO_AdjusterBindingSource
            // 
            this.dTO_AdjusterBindingSource.DataSource = typeof(MRNNexus_Model.DTO_Adjuster);
            // 
            // dTO_AdjusterBindingNavigator
            // 
            this.dTO_AdjusterBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_AdjusterBindingNavigator.BindingSource = this.dTO_AdjusterBindingSource;
            this.dTO_AdjusterBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_AdjusterBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_AdjusterBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_AdjusterBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.dTO_AdjusterBindingNavigatorSaveItem});
            this.dTO_AdjusterBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_AdjusterBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_AdjusterBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_AdjusterBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_AdjusterBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_AdjusterBindingNavigator.Name = "dTO_AdjusterBindingNavigator";
            this.dTO_AdjusterBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_AdjusterBindingNavigator.Size = new System.Drawing.Size(394, 31);
            this.dTO_AdjusterBindingNavigator.TabIndex = 0;
            this.dTO_AdjusterBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
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
            // dTO_AdjusterBindingNavigatorSaveItem
            // 
            this.dTO_AdjusterBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_AdjusterBindingNavigatorSaveItem.Enabled = false;
            this.dTO_AdjusterBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_AdjusterBindingNavigatorSaveItem.Image")));
            this.dTO_AdjusterBindingNavigatorSaveItem.Name = "dTO_AdjusterBindingNavigatorSaveItem";
            this.dTO_AdjusterBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.dTO_AdjusterBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // adjusterIDLabel
            // 
            adjusterIDLabel.AutoSize = true;
            adjusterIDLabel.Location = new System.Drawing.Point(16, 53);
            adjusterIDLabel.Name = "adjusterIDLabel";
            adjusterIDLabel.Size = new System.Drawing.Size(93, 20);
            adjusterIDLabel.TabIndex = 1;
            adjusterIDLabel.Text = "Adjuster ID:";
            // 
            // adjusterIDTextBox
            // 
            this.adjusterIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjusterBindingSource, "AdjusterID", true));
            this.adjusterIDTextBox.Location = new System.Drawing.Point(198, 50);
            this.adjusterIDTextBox.Name = "adjusterIDTextBox";
            this.adjusterIDTextBox.Size = new System.Drawing.Size(142, 26);
            this.adjusterIDTextBox.TabIndex = 2;
            // 
            // commentsLabel
            // 
            commentsLabel.AutoSize = true;
            commentsLabel.Location = new System.Drawing.Point(16, 85);
            commentsLabel.Name = "commentsLabel";
            commentsLabel.Size = new System.Drawing.Size(90, 20);
            commentsLabel.TabIndex = 3;
            commentsLabel.Text = "Comments:";
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjusterBindingSource, "Comments", true));
            this.commentsTextBox.Location = new System.Drawing.Point(198, 82);
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.Size = new System.Drawing.Size(142, 26);
            this.commentsTextBox.TabIndex = 4;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(16, 117);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(52, 20);
            emailLabel.TabIndex = 5;
            emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjusterBindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(198, 114);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(142, 26);
            this.emailTextBox.TabIndex = 6;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(16, 149);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(90, 20);
            firstNameLabel.TabIndex = 7;
            firstNameLabel.Text = "First Name:";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjusterBindingSource, "FirstName", true));
            this.firstNameTextBox.Location = new System.Drawing.Point(198, 146);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(142, 26);
            this.firstNameTextBox.TabIndex = 8;
            // 
            // insuranceCompanyIDLabel
            // 
            insuranceCompanyIDLabel.AutoSize = true;
            insuranceCompanyIDLabel.Location = new System.Drawing.Point(16, 181);
            insuranceCompanyIDLabel.Name = "insuranceCompanyIDLabel";
            insuranceCompanyIDLabel.Size = new System.Drawing.Size(176, 20);
            insuranceCompanyIDLabel.TabIndex = 9;
            insuranceCompanyIDLabel.Text = "Insurance Company ID:";
            // 
            // insuranceCompanyIDTextBox
            // 
            this.insuranceCompanyIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjusterBindingSource, "InsuranceCompanyID", true));
            this.insuranceCompanyIDTextBox.Location = new System.Drawing.Point(198, 178);
            this.insuranceCompanyIDTextBox.Name = "insuranceCompanyIDTextBox";
            this.insuranceCompanyIDTextBox.Size = new System.Drawing.Size(142, 26);
            this.insuranceCompanyIDTextBox.TabIndex = 10;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(16, 213);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(90, 20);
            lastNameLabel.TabIndex = 11;
            lastNameLabel.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjusterBindingSource, "LastName", true));
            this.lastNameTextBox.Location = new System.Drawing.Point(198, 210);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(142, 26);
            this.lastNameTextBox.TabIndex = 12;
            // 
            // phoneExtLabel
            // 
            phoneExtLabel.AutoSize = true;
            phoneExtLabel.Location = new System.Drawing.Point(16, 245);
            phoneExtLabel.Name = "phoneExtLabel";
            phoneExtLabel.Size = new System.Drawing.Size(86, 20);
            phoneExtLabel.TabIndex = 13;
            phoneExtLabel.Text = "Phone Ext:";
            // 
            // phoneExtTextBox
            // 
            this.phoneExtTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjusterBindingSource, "PhoneExt", true));
            this.phoneExtTextBox.Location = new System.Drawing.Point(198, 242);
            this.phoneExtTextBox.Name = "phoneExtTextBox";
            this.phoneExtTextBox.Size = new System.Drawing.Size(142, 26);
            this.phoneExtTextBox.TabIndex = 14;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new System.Drawing.Point(16, 277);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new System.Drawing.Size(119, 20);
            phoneNumberLabel.TabIndex = 15;
            phoneNumberLabel.Text = "Phone Number:";
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjusterBindingSource, "PhoneNumber", true));
            this.phoneNumberTextBox.Location = new System.Drawing.Point(198, 274);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(142, 26);
            this.phoneNumberTextBox.TabIndex = 16;
            // 
            // suffixLabel
            // 
            suffixLabel.AutoSize = true;
            suffixLabel.Location = new System.Drawing.Point(16, 309);
            suffixLabel.Name = "suffixLabel";
            suffixLabel.Size = new System.Drawing.Size(53, 20);
            suffixLabel.TabIndex = 17;
            suffixLabel.Text = "Suffix:";
            // 
            // suffixTextBox
            // 
            this.suffixTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_AdjusterBindingSource, "Suffix", true));
            this.suffixTextBox.Location = new System.Drawing.Point(198, 306);
            this.suffixTextBox.Name = "suffixTextBox";
            this.suffixTextBox.Size = new System.Drawing.Size(142, 26);
            this.suffixTextBox.TabIndex = 18;
            // 
            // AddAdjuster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 434);
            this.Controls.Add(adjusterIDLabel);
            this.Controls.Add(this.adjusterIDTextBox);
            this.Controls.Add(commentsLabel);
            this.Controls.Add(this.commentsTextBox);
            this.Controls.Add(emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(firstNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(insuranceCompanyIDLabel);
            this.Controls.Add(this.insuranceCompanyIDTextBox);
            this.Controls.Add(lastNameLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(phoneExtLabel);
            this.Controls.Add(this.phoneExtTextBox);
            this.Controls.Add(phoneNumberLabel);
            this.Controls.Add(this.phoneNumberTextBox);
            this.Controls.Add(suffixLabel);
            this.Controls.Add(this.suffixTextBox);
            this.Controls.Add(this.dTO_AdjusterBindingNavigator);
            this.Name = "AddAdjuster";
            this.Text = "AddAdjuster";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_AdjusterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_AdjusterBindingNavigator)).EndInit();
            this.dTO_AdjusterBindingNavigator.ResumeLayout(false);
            this.dTO_AdjusterBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_AdjusterBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_AdjusterBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton dTO_AdjusterBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox adjusterIDTextBox;
        private System.Windows.Forms.TextBox commentsTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox insuranceCompanyIDTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox phoneExtTextBox;
        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.TextBox suffixTextBox;
    }
}