namespace MRNUIElements
{
    partial class AddClaimContacts
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
            System.Windows.Forms.Label claimContactIDLabel;
            System.Windows.Forms.Label claimIDLabel;
            System.Windows.Forms.Label customerIDLabel;
            System.Windows.Forms.Label knockerIDLabel;
            System.Windows.Forms.Label salesManagerIDLabel;
            System.Windows.Forms.Label salesPersonIDLabel;
            System.Windows.Forms.Label supervisorIDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClaimContacts));
            this.dTO_ClaimContactsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.adjusterIDTextBox = new System.Windows.Forms.TextBox();
            this.claimContactIDTextBox = new System.Windows.Forms.TextBox();
            this.claimIDTextBox = new System.Windows.Forms.TextBox();
            this.customerIDTextBox = new System.Windows.Forms.TextBox();
            this.knockerIDTextBox = new System.Windows.Forms.TextBox();
            this.salesManagerIDTextBox = new System.Windows.Forms.TextBox();
            this.salesPersonIDTextBox = new System.Windows.Forms.TextBox();
            this.supervisorIDTextBox = new System.Windows.Forms.TextBox();
            this.dTO_ClaimContactsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.dTO_ClaimContactsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            adjusterIDLabel = new System.Windows.Forms.Label();
            claimContactIDLabel = new System.Windows.Forms.Label();
            claimIDLabel = new System.Windows.Forms.Label();
            customerIDLabel = new System.Windows.Forms.Label();
            knockerIDLabel = new System.Windows.Forms.Label();
            salesManagerIDLabel = new System.Windows.Forms.Label();
            salesPersonIDLabel = new System.Windows.Forms.Label();
            supervisorIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_ClaimContactsBindingNavigator)).BeginInit();
            this.dTO_ClaimContactsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_ClaimContactsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dTO_ClaimContactsBindingNavigator
            // 
            this.dTO_ClaimContactsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_ClaimContactsBindingNavigator.BindingSource = this.dTO_ClaimContactsBindingSource;
            this.dTO_ClaimContactsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_ClaimContactsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_ClaimContactsBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_ClaimContactsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.dTO_ClaimContactsBindingNavigatorSaveItem});
            this.dTO_ClaimContactsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_ClaimContactsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_ClaimContactsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_ClaimContactsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_ClaimContactsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_ClaimContactsBindingNavigator.Name = "dTO_ClaimContactsBindingNavigator";
            this.dTO_ClaimContactsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_ClaimContactsBindingNavigator.Size = new System.Drawing.Size(399, 31);
            this.dTO_ClaimContactsBindingNavigator.TabIndex = 0;
            this.dTO_ClaimContactsBindingNavigator.Text = "bindingNavigator1";
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
            adjusterIDLabel.Location = new System.Drawing.Point(24, 41);
            adjusterIDLabel.Name = "adjusterIDLabel";
            adjusterIDLabel.Size = new System.Drawing.Size(93, 20);
            adjusterIDLabel.TabIndex = 1;
            adjusterIDLabel.Text = "Adjuster ID:";
            // 
            // adjusterIDTextBox
            // 
            this.adjusterIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimContactsBindingSource, "AdjusterID", true));
            this.adjusterIDTextBox.Location = new System.Drawing.Point(171, 38);
            this.adjusterIDTextBox.Name = "adjusterIDTextBox";
            this.adjusterIDTextBox.Size = new System.Drawing.Size(198, 26);
            this.adjusterIDTextBox.TabIndex = 2;
            // 
            // claimContactIDLabel
            // 
            claimContactIDLabel.AutoSize = true;
            claimContactIDLabel.Location = new System.Drawing.Point(24, 73);
            claimContactIDLabel.Name = "claimContactIDLabel";
            claimContactIDLabel.Size = new System.Drawing.Size(133, 20);
            claimContactIDLabel.TabIndex = 3;
            claimContactIDLabel.Text = "Claim Contact ID:";
            // 
            // claimContactIDTextBox
            // 
            this.claimContactIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimContactsBindingSource, "ClaimContactID", true));
            this.claimContactIDTextBox.Location = new System.Drawing.Point(171, 70);
            this.claimContactIDTextBox.Name = "claimContactIDTextBox";
            this.claimContactIDTextBox.Size = new System.Drawing.Size(198, 26);
            this.claimContactIDTextBox.TabIndex = 4;
            // 
            // claimIDLabel
            // 
            claimIDLabel.AutoSize = true;
            claimIDLabel.Location = new System.Drawing.Point(24, 105);
            claimIDLabel.Name = "claimIDLabel";
            claimIDLabel.Size = new System.Drawing.Size(73, 20);
            claimIDLabel.TabIndex = 5;
            claimIDLabel.Text = "Claim ID:";
            // 
            // claimIDTextBox
            // 
            this.claimIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimContactsBindingSource, "ClaimID", true));
            this.claimIDTextBox.Location = new System.Drawing.Point(171, 102);
            this.claimIDTextBox.Name = "claimIDTextBox";
            this.claimIDTextBox.Size = new System.Drawing.Size(198, 26);
            this.claimIDTextBox.TabIndex = 6;
            // 
            // customerIDLabel
            // 
            customerIDLabel.AutoSize = true;
            customerIDLabel.Location = new System.Drawing.Point(24, 137);
            customerIDLabel.Name = "customerIDLabel";
            customerIDLabel.Size = new System.Drawing.Size(103, 20);
            customerIDLabel.TabIndex = 7;
            customerIDLabel.Text = "Customer ID:";
            // 
            // customerIDTextBox
            // 
            this.customerIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimContactsBindingSource, "CustomerID", true));
            this.customerIDTextBox.Location = new System.Drawing.Point(171, 134);
            this.customerIDTextBox.Name = "customerIDTextBox";
            this.customerIDTextBox.Size = new System.Drawing.Size(198, 26);
            this.customerIDTextBox.TabIndex = 8;
            // 
            // knockerIDLabel
            // 
            knockerIDLabel.AutoSize = true;
            knockerIDLabel.Location = new System.Drawing.Point(24, 169);
            knockerIDLabel.Name = "knockerIDLabel";
            knockerIDLabel.Size = new System.Drawing.Size(92, 20);
            knockerIDLabel.TabIndex = 9;
            knockerIDLabel.Text = "Knocker ID:";
            // 
            // knockerIDTextBox
            // 
            this.knockerIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimContactsBindingSource, "KnockerID", true));
            this.knockerIDTextBox.Location = new System.Drawing.Point(171, 166);
            this.knockerIDTextBox.Name = "knockerIDTextBox";
            this.knockerIDTextBox.Size = new System.Drawing.Size(198, 26);
            this.knockerIDTextBox.TabIndex = 10;
            // 
            // salesManagerIDLabel
            // 
            salesManagerIDLabel.AutoSize = true;
            salesManagerIDLabel.Location = new System.Drawing.Point(24, 201);
            salesManagerIDLabel.Name = "salesManagerIDLabel";
            salesManagerIDLabel.Size = new System.Drawing.Size(141, 20);
            salesManagerIDLabel.TabIndex = 11;
            salesManagerIDLabel.Text = "Sales Manager ID:";
            // 
            // salesManagerIDTextBox
            // 
            this.salesManagerIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimContactsBindingSource, "SalesManagerID", true));
            this.salesManagerIDTextBox.Location = new System.Drawing.Point(171, 198);
            this.salesManagerIDTextBox.Name = "salesManagerIDTextBox";
            this.salesManagerIDTextBox.Size = new System.Drawing.Size(198, 26);
            this.salesManagerIDTextBox.TabIndex = 12;
            // 
            // salesPersonIDLabel
            // 
            salesPersonIDLabel.AutoSize = true;
            salesPersonIDLabel.Location = new System.Drawing.Point(24, 233);
            salesPersonIDLabel.Name = "salesPersonIDLabel";
            salesPersonIDLabel.Size = new System.Drawing.Size(128, 20);
            salesPersonIDLabel.TabIndex = 13;
            salesPersonIDLabel.Text = "Sales Person ID:";
            // 
            // salesPersonIDTextBox
            // 
            this.salesPersonIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimContactsBindingSource, "SalesPersonID", true));
            this.salesPersonIDTextBox.Location = new System.Drawing.Point(171, 230);
            this.salesPersonIDTextBox.Name = "salesPersonIDTextBox";
            this.salesPersonIDTextBox.Size = new System.Drawing.Size(198, 26);
            this.salesPersonIDTextBox.TabIndex = 14;
            // 
            // supervisorIDLabel
            // 
            supervisorIDLabel.AutoSize = true;
            supervisorIDLabel.Location = new System.Drawing.Point(24, 265);
            supervisorIDLabel.Name = "supervisorIDLabel";
            supervisorIDLabel.Size = new System.Drawing.Size(109, 20);
            supervisorIDLabel.TabIndex = 15;
            supervisorIDLabel.Text = "Supervisor ID:";
            // 
            // supervisorIDTextBox
            // 
            this.supervisorIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_ClaimContactsBindingSource, "SupervisorID", true));
            this.supervisorIDTextBox.Location = new System.Drawing.Point(171, 262);
            this.supervisorIDTextBox.Name = "supervisorIDTextBox";
            this.supervisorIDTextBox.Size = new System.Drawing.Size(198, 26);
            this.supervisorIDTextBox.TabIndex = 16;
            // 
            // dTO_ClaimContactsBindingSource
            // 
            this.dTO_ClaimContactsBindingSource.DataSource = typeof(MRNNexus_Model.DTO_ClaimContacts);
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
            // dTO_ClaimContactsBindingNavigatorSaveItem
            // 
            this.dTO_ClaimContactsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_ClaimContactsBindingNavigatorSaveItem.Enabled = false;
            this.dTO_ClaimContactsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_ClaimContactsBindingNavigatorSaveItem.Image")));
            this.dTO_ClaimContactsBindingNavigatorSaveItem.Name = "dTO_ClaimContactsBindingNavigatorSaveItem";
            this.dTO_ClaimContactsBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.dTO_ClaimContactsBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // AddClaimContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 294);
            this.Controls.Add(adjusterIDLabel);
            this.Controls.Add(this.adjusterIDTextBox);
            this.Controls.Add(claimContactIDLabel);
            this.Controls.Add(this.claimContactIDTextBox);
            this.Controls.Add(claimIDLabel);
            this.Controls.Add(this.claimIDTextBox);
            this.Controls.Add(customerIDLabel);
            this.Controls.Add(this.customerIDTextBox);
            this.Controls.Add(knockerIDLabel);
            this.Controls.Add(this.knockerIDTextBox);
            this.Controls.Add(salesManagerIDLabel);
            this.Controls.Add(this.salesManagerIDTextBox);
            this.Controls.Add(salesPersonIDLabel);
            this.Controls.Add(this.salesPersonIDTextBox);
            this.Controls.Add(supervisorIDLabel);
            this.Controls.Add(this.supervisorIDTextBox);
            this.Controls.Add(this.dTO_ClaimContactsBindingNavigator);
            this.Name = "AddClaimContacts";
            this.Text = "AddClaimContacts";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_ClaimContactsBindingNavigator)).EndInit();
            this.dTO_ClaimContactsBindingNavigator.ResumeLayout(false);
            this.dTO_ClaimContactsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_ClaimContactsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_ClaimContactsBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_ClaimContactsBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton dTO_ClaimContactsBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox adjusterIDTextBox;
        private System.Windows.Forms.TextBox claimContactIDTextBox;
        private System.Windows.Forms.TextBox claimIDTextBox;
        private System.Windows.Forms.TextBox customerIDTextBox;
        private System.Windows.Forms.TextBox knockerIDTextBox;
        private System.Windows.Forms.TextBox salesManagerIDTextBox;
        private System.Windows.Forms.TextBox salesPersonIDTextBox;
        private System.Windows.Forms.TextBox supervisorIDTextBox;
    }
}