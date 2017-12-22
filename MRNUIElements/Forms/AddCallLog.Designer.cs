namespace MRNUIElements
{
    partial class AddCallLog
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
            System.Windows.Forms.Label additionalCommentsLabel;
            System.Windows.Forms.Label callLogIDLabel;
            System.Windows.Forms.Label callResultsLabel;
            System.Windows.Forms.Label claimIDLabel;
            System.Windows.Forms.Label employeeIDLabel;
            System.Windows.Forms.Label reasonForCallLabel;
            System.Windows.Forms.Label whoAnsweredLabel;
            System.Windows.Forms.Label whoWasCalledLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCallLog));
            this.dTO_CallLogBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.additionalCommentsTextBox = new System.Windows.Forms.TextBox();
            this.callLogIDTextBox = new System.Windows.Forms.TextBox();
            this.callResultsTextBox = new System.Windows.Forms.TextBox();
            this.claimIDTextBox = new System.Windows.Forms.TextBox();
            this.employeeIDTextBox = new System.Windows.Forms.TextBox();
            this.reasonForCallTextBox = new System.Windows.Forms.TextBox();
            this.whoAnsweredTextBox = new System.Windows.Forms.TextBox();
            this.whoWasCalledTextBox = new System.Windows.Forms.TextBox();
            this.dTO_CallLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.dTO_CallLogBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            additionalCommentsLabel = new System.Windows.Forms.Label();
            callLogIDLabel = new System.Windows.Forms.Label();
            callResultsLabel = new System.Windows.Forms.Label();
            claimIDLabel = new System.Windows.Forms.Label();
            employeeIDLabel = new System.Windows.Forms.Label();
            reasonForCallLabel = new System.Windows.Forms.Label();
            whoAnsweredLabel = new System.Windows.Forms.Label();
            whoWasCalledLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_CallLogBindingNavigator)).BeginInit();
            this.dTO_CallLogBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_CallLogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dTO_CallLogBindingNavigator
            // 
            this.dTO_CallLogBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_CallLogBindingNavigator.BindingSource = this.dTO_CallLogBindingSource;
            this.dTO_CallLogBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_CallLogBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_CallLogBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_CallLogBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.dTO_CallLogBindingNavigatorSaveItem});
            this.dTO_CallLogBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_CallLogBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_CallLogBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_CallLogBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_CallLogBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_CallLogBindingNavigator.Name = "dTO_CallLogBindingNavigator";
            this.dTO_CallLogBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_CallLogBindingNavigator.Size = new System.Drawing.Size(344, 31);
            this.dTO_CallLogBindingNavigator.TabIndex = 0;
            this.dTO_CallLogBindingNavigator.Text = "bindingNavigator1";
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
            // additionalCommentsLabel
            // 
            additionalCommentsLabel.AutoSize = true;
            additionalCommentsLabel.Location = new System.Drawing.Point(32, 31);
            additionalCommentsLabel.Name = "additionalCommentsLabel";
            additionalCommentsLabel.Size = new System.Drawing.Size(164, 20);
            additionalCommentsLabel.TabIndex = 1;
            additionalCommentsLabel.Text = "Additional Comments:";
            // 
            // additionalCommentsTextBox
            // 
            this.additionalCommentsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CallLogBindingSource, "AdditionalComments", true));
            this.additionalCommentsTextBox.Location = new System.Drawing.Point(202, 28);
            this.additionalCommentsTextBox.Name = "additionalCommentsTextBox";
            this.additionalCommentsTextBox.Size = new System.Drawing.Size(100, 26);
            this.additionalCommentsTextBox.TabIndex = 2;
            // 
            // callLogIDLabel
            // 
            callLogIDLabel.AutoSize = true;
            callLogIDLabel.Location = new System.Drawing.Point(32, 63);
            callLogIDLabel.Name = "callLogIDLabel";
            callLogIDLabel.Size = new System.Drawing.Size(91, 20);
            callLogIDLabel.TabIndex = 3;
            callLogIDLabel.Text = "Call Log ID:";
            // 
            // callLogIDTextBox
            // 
            this.callLogIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CallLogBindingSource, "CallLogID", true));
            this.callLogIDTextBox.Location = new System.Drawing.Point(202, 60);
            this.callLogIDTextBox.Name = "callLogIDTextBox";
            this.callLogIDTextBox.Size = new System.Drawing.Size(100, 26);
            this.callLogIDTextBox.TabIndex = 4;
            // 
            // callResultsLabel
            // 
            callResultsLabel.AutoSize = true;
            callResultsLabel.Location = new System.Drawing.Point(32, 95);
            callResultsLabel.Name = "callResultsLabel";
            callResultsLabel.Size = new System.Drawing.Size(97, 20);
            callResultsLabel.TabIndex = 5;
            callResultsLabel.Text = "Call Results:";
            // 
            // callResultsTextBox
            // 
            this.callResultsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CallLogBindingSource, "CallResults", true));
            this.callResultsTextBox.Location = new System.Drawing.Point(202, 92);
            this.callResultsTextBox.Name = "callResultsTextBox";
            this.callResultsTextBox.Size = new System.Drawing.Size(100, 26);
            this.callResultsTextBox.TabIndex = 6;
            // 
            // claimIDLabel
            // 
            claimIDLabel.AutoSize = true;
            claimIDLabel.Location = new System.Drawing.Point(32, 127);
            claimIDLabel.Name = "claimIDLabel";
            claimIDLabel.Size = new System.Drawing.Size(73, 20);
            claimIDLabel.TabIndex = 7;
            claimIDLabel.Text = "Claim ID:";
            // 
            // claimIDTextBox
            // 
            this.claimIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CallLogBindingSource, "ClaimID", true));
            this.claimIDTextBox.Location = new System.Drawing.Point(202, 124);
            this.claimIDTextBox.Name = "claimIDTextBox";
            this.claimIDTextBox.Size = new System.Drawing.Size(100, 26);
            this.claimIDTextBox.TabIndex = 8;
            // 
            // employeeIDLabel
            // 
            employeeIDLabel.AutoSize = true;
            employeeIDLabel.Location = new System.Drawing.Point(32, 159);
            employeeIDLabel.Name = "employeeIDLabel";
            employeeIDLabel.Size = new System.Drawing.Size(104, 20);
            employeeIDLabel.TabIndex = 9;
            employeeIDLabel.Text = "Employee ID:";
            // 
            // employeeIDTextBox
            // 
            this.employeeIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CallLogBindingSource, "EmployeeID", true));
            this.employeeIDTextBox.Location = new System.Drawing.Point(202, 156);
            this.employeeIDTextBox.Name = "employeeIDTextBox";
            this.employeeIDTextBox.Size = new System.Drawing.Size(100, 26);
            this.employeeIDTextBox.TabIndex = 10;
            // 
            // reasonForCallLabel
            // 
            reasonForCallLabel.AutoSize = true;
            reasonForCallLabel.Location = new System.Drawing.Point(32, 191);
            reasonForCallLabel.Name = "reasonForCallLabel";
            reasonForCallLabel.Size = new System.Drawing.Size(127, 20);
            reasonForCallLabel.TabIndex = 11;
            reasonForCallLabel.Text = "Reason For Call:";
            // 
            // reasonForCallTextBox
            // 
            this.reasonForCallTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CallLogBindingSource, "ReasonForCall", true));
            this.reasonForCallTextBox.Location = new System.Drawing.Point(202, 188);
            this.reasonForCallTextBox.Name = "reasonForCallTextBox";
            this.reasonForCallTextBox.Size = new System.Drawing.Size(100, 26);
            this.reasonForCallTextBox.TabIndex = 12;
            // 
            // whoAnsweredLabel
            // 
            whoAnsweredLabel.AutoSize = true;
            whoAnsweredLabel.Location = new System.Drawing.Point(32, 223);
            whoAnsweredLabel.Name = "whoAnsweredLabel";
            whoAnsweredLabel.Size = new System.Drawing.Size(121, 20);
            whoAnsweredLabel.TabIndex = 13;
            whoAnsweredLabel.Text = "Who Answered:";
            // 
            // whoAnsweredTextBox
            // 
            this.whoAnsweredTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CallLogBindingSource, "WhoAnswered", true));
            this.whoAnsweredTextBox.Location = new System.Drawing.Point(202, 220);
            this.whoAnsweredTextBox.Name = "whoAnsweredTextBox";
            this.whoAnsweredTextBox.Size = new System.Drawing.Size(100, 26);
            this.whoAnsweredTextBox.TabIndex = 14;
            // 
            // whoWasCalledLabel
            // 
            whoWasCalledLabel.AutoSize = true;
            whoWasCalledLabel.Location = new System.Drawing.Point(32, 255);
            whoWasCalledLabel.Name = "whoWasCalledLabel";
            whoWasCalledLabel.Size = new System.Drawing.Size(130, 20);
            whoWasCalledLabel.TabIndex = 15;
            whoWasCalledLabel.Text = "Who Was Called:";
            // 
            // whoWasCalledTextBox
            // 
            this.whoWasCalledTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CallLogBindingSource, "WhoWasCalled", true));
            this.whoWasCalledTextBox.Location = new System.Drawing.Point(202, 252);
            this.whoWasCalledTextBox.Name = "whoWasCalledTextBox";
            this.whoWasCalledTextBox.Size = new System.Drawing.Size(100, 26);
            this.whoWasCalledTextBox.TabIndex = 16;
            // 
            // dTO_CallLogBindingSource
            // 
            this.dTO_CallLogBindingSource.DataSource = typeof(MRNNexus_Model.DTO_CallLog);
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
            // dTO_CallLogBindingNavigatorSaveItem
            // 
            this.dTO_CallLogBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_CallLogBindingNavigatorSaveItem.Enabled = false;
            this.dTO_CallLogBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_CallLogBindingNavigatorSaveItem.Image")));
            this.dTO_CallLogBindingNavigatorSaveItem.Name = "dTO_CallLogBindingNavigatorSaveItem";
            this.dTO_CallLogBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.dTO_CallLogBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // AddCallLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 294);
            this.Controls.Add(additionalCommentsLabel);
            this.Controls.Add(this.additionalCommentsTextBox);
            this.Controls.Add(callLogIDLabel);
            this.Controls.Add(this.callLogIDTextBox);
            this.Controls.Add(callResultsLabel);
            this.Controls.Add(this.callResultsTextBox);
            this.Controls.Add(claimIDLabel);
            this.Controls.Add(this.claimIDTextBox);
            this.Controls.Add(employeeIDLabel);
            this.Controls.Add(this.employeeIDTextBox);
            this.Controls.Add(reasonForCallLabel);
            this.Controls.Add(this.reasonForCallTextBox);
            this.Controls.Add(whoAnsweredLabel);
            this.Controls.Add(this.whoAnsweredTextBox);
            this.Controls.Add(whoWasCalledLabel);
            this.Controls.Add(this.whoWasCalledTextBox);
            this.Controls.Add(this.dTO_CallLogBindingNavigator);
            this.Name = "AddCallLog";
            this.Text = "AddCallLog";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_CallLogBindingNavigator)).EndInit();
            this.dTO_CallLogBindingNavigator.ResumeLayout(false);
            this.dTO_CallLogBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_CallLogBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_CallLogBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_CallLogBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton dTO_CallLogBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox additionalCommentsTextBox;
        private System.Windows.Forms.TextBox callLogIDTextBox;
        private System.Windows.Forms.TextBox callResultsTextBox;
        private System.Windows.Forms.TextBox claimIDTextBox;
        private System.Windows.Forms.TextBox employeeIDTextBox;
        private System.Windows.Forms.TextBox reasonForCallTextBox;
        private System.Windows.Forms.TextBox whoAnsweredTextBox;
        private System.Windows.Forms.TextBox whoWasCalledTextBox;
    }
}