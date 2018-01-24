namespace MRN_Claim_Services
{
    partial class AddAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAppointment));
            System.Windows.Forms.Label appointmentTextLabel;
            System.Windows.Forms.Label appointmentTypeIDLabel;
            System.Windows.Forms.Label claimIDLabel;
            System.Windows.Forms.Label employeeIDLabel;
            System.Windows.Forms.Label endTimeLabel;
            System.Windows.Forms.Label entryIDLabel;
            System.Windows.Forms.Label leadIDLabel;
            System.Windows.Forms.Label noteLabel;
            System.Windows.Forms.Label startTimeLabel;
            this.dTO_CalendarDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTO_CalendarDataBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.dTO_CalendarDataBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.appointmentTextTextBox = new System.Windows.Forms.TextBox();
            this.appointmentTypeIDTextBox = new System.Windows.Forms.TextBox();
            this.claimIDTextBox = new System.Windows.Forms.TextBox();
            this.employeeIDTextBox = new System.Windows.Forms.TextBox();
            this.endTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.entryIDTextBox = new System.Windows.Forms.TextBox();
            this.leadIDTextBox = new System.Windows.Forms.TextBox();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.startTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            appointmentTextLabel = new System.Windows.Forms.Label();
            appointmentTypeIDLabel = new System.Windows.Forms.Label();
            claimIDLabel = new System.Windows.Forms.Label();
            employeeIDLabel = new System.Windows.Forms.Label();
            endTimeLabel = new System.Windows.Forms.Label();
            entryIDLabel = new System.Windows.Forms.Label();
            leadIDLabel = new System.Windows.Forms.Label();
            noteLabel = new System.Windows.Forms.Label();
            startTimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_CalendarDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_CalendarDataBindingNavigator)).BeginInit();
            this.dTO_CalendarDataBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // dTO_CalendarDataBindingSource
            // 
            this.dTO_CalendarDataBindingSource.DataSource = typeof(MRNNexus_Model.DTO_CalendarData);
            // 
            // dTO_CalendarDataBindingNavigator
            // 
            this.dTO_CalendarDataBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_CalendarDataBindingNavigator.BindingSource = this.dTO_CalendarDataBindingSource;
            this.dTO_CalendarDataBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_CalendarDataBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_CalendarDataBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_CalendarDataBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.dTO_CalendarDataBindingNavigatorSaveItem});
            this.dTO_CalendarDataBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_CalendarDataBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_CalendarDataBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_CalendarDataBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_CalendarDataBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_CalendarDataBindingNavigator.Name = "dTO_CalendarDataBindingNavigator";
            this.dTO_CalendarDataBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_CalendarDataBindingNavigator.Size = new System.Drawing.Size(523, 33);
            this.dTO_CalendarDataBindingNavigator.TabIndex = 0;
            this.dTO_CalendarDataBindingNavigator.Text = "bindingNavigator1";
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
            // dTO_CalendarDataBindingNavigatorSaveItem
            // 
            this.dTO_CalendarDataBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_CalendarDataBindingNavigatorSaveItem.Enabled = false;
            this.dTO_CalendarDataBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_CalendarDataBindingNavigatorSaveItem.Image")));
            this.dTO_CalendarDataBindingNavigatorSaveItem.Name = "dTO_CalendarDataBindingNavigatorSaveItem";
            this.dTO_CalendarDataBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 30);
            this.dTO_CalendarDataBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // appointmentTextLabel
            // 
            appointmentTextLabel.AutoSize = true;
            appointmentTextLabel.Location = new System.Drawing.Point(134, 107);
            appointmentTextLabel.Name = "appointmentTextLabel";
            appointmentTextLabel.Size = new System.Drawing.Size(138, 20);
            appointmentTextLabel.TabIndex = 1;
            appointmentTextLabel.Text = "Appointment Text:";
            // 
            // appointmentTextTextBox
            // 
            this.appointmentTextTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CalendarDataBindingSource, "AppointmentText", true));
            this.appointmentTextTextBox.Location = new System.Drawing.Point(303, 104);
            this.appointmentTextTextBox.Name = "appointmentTextTextBox";
            this.appointmentTextTextBox.Size = new System.Drawing.Size(200, 26);
            this.appointmentTextTextBox.TabIndex = 2;
            // 
            // appointmentTypeIDLabel
            // 
            appointmentTypeIDLabel.AutoSize = true;
            appointmentTypeIDLabel.Location = new System.Drawing.Point(134, 139);
            appointmentTypeIDLabel.Name = "appointmentTypeIDLabel";
            appointmentTypeIDLabel.Size = new System.Drawing.Size(163, 20);
            appointmentTypeIDLabel.TabIndex = 3;
            appointmentTypeIDLabel.Text = "Appointment Type ID:";
            // 
            // appointmentTypeIDTextBox
            // 
            this.appointmentTypeIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CalendarDataBindingSource, "AppointmentTypeID", true));
            this.appointmentTypeIDTextBox.Location = new System.Drawing.Point(303, 136);
            this.appointmentTypeIDTextBox.Name = "appointmentTypeIDTextBox";
            this.appointmentTypeIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.appointmentTypeIDTextBox.TabIndex = 4;
            // 
            // claimIDLabel
            // 
            claimIDLabel.AutoSize = true;
            claimIDLabel.Location = new System.Drawing.Point(134, 171);
            claimIDLabel.Name = "claimIDLabel";
            claimIDLabel.Size = new System.Drawing.Size(73, 20);
            claimIDLabel.TabIndex = 5;
            claimIDLabel.Text = "Claim ID:";
            // 
            // claimIDTextBox
            // 
            this.claimIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CalendarDataBindingSource, "ClaimID", true));
            this.claimIDTextBox.Location = new System.Drawing.Point(303, 168);
            this.claimIDTextBox.Name = "claimIDTextBox";
            this.claimIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.claimIDTextBox.TabIndex = 6;
            // 
            // employeeIDLabel
            // 
            employeeIDLabel.AutoSize = true;
            employeeIDLabel.Location = new System.Drawing.Point(134, 203);
            employeeIDLabel.Name = "employeeIDLabel";
            employeeIDLabel.Size = new System.Drawing.Size(104, 20);
            employeeIDLabel.TabIndex = 7;
            employeeIDLabel.Text = "Employee ID:";
            // 
            // employeeIDTextBox
            // 
            this.employeeIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CalendarDataBindingSource, "EmployeeID", true));
            this.employeeIDTextBox.Location = new System.Drawing.Point(303, 200);
            this.employeeIDTextBox.Name = "employeeIDTextBox";
            this.employeeIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.employeeIDTextBox.TabIndex = 8;
            // 
            // endTimeLabel
            // 
            endTimeLabel.AutoSize = true;
            endTimeLabel.Location = new System.Drawing.Point(134, 236);
            endTimeLabel.Name = "endTimeLabel";
            endTimeLabel.Size = new System.Drawing.Size(80, 20);
            endTimeLabel.TabIndex = 9;
            endTimeLabel.Text = "End Time:";
            // 
            // endTimeDateTimePicker
            // 
            this.endTimeDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_CalendarDataBindingSource, "EndTime", true));
            this.endTimeDateTimePicker.Location = new System.Drawing.Point(303, 232);
            this.endTimeDateTimePicker.Name = "endTimeDateTimePicker";
            this.endTimeDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.endTimeDateTimePicker.TabIndex = 10;
            // 
            // entryIDLabel
            // 
            entryIDLabel.AutoSize = true;
            entryIDLabel.Location = new System.Drawing.Point(134, 267);
            entryIDLabel.Name = "entryIDLabel";
            entryIDLabel.Size = new System.Drawing.Size(71, 20);
            entryIDLabel.TabIndex = 11;
            entryIDLabel.Text = "Entry ID:";
            // 
            // entryIDTextBox
            // 
            this.entryIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CalendarDataBindingSource, "EntryID", true));
            this.entryIDTextBox.Location = new System.Drawing.Point(303, 264);
            this.entryIDTextBox.Name = "entryIDTextBox";
            this.entryIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.entryIDTextBox.TabIndex = 12;
            // 
            // leadIDLabel
            // 
            leadIDLabel.AutoSize = true;
            leadIDLabel.Location = new System.Drawing.Point(134, 299);
            leadIDLabel.Name = "leadIDLabel";
            leadIDLabel.Size = new System.Drawing.Size(70, 20);
            leadIDLabel.TabIndex = 13;
            leadIDLabel.Text = "Lead ID:";
            // 
            // leadIDTextBox
            // 
            this.leadIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CalendarDataBindingSource, "LeadID", true));
            this.leadIDTextBox.Location = new System.Drawing.Point(303, 296);
            this.leadIDTextBox.Name = "leadIDTextBox";
            this.leadIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.leadIDTextBox.TabIndex = 14;
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(134, 331);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(47, 20);
            noteLabel.TabIndex = 15;
            noteLabel.Text = "Note:";
            // 
            // noteTextBox
            // 
            this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_CalendarDataBindingSource, "Note", true));
            this.noteTextBox.Location = new System.Drawing.Point(303, 328);
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(200, 26);
            this.noteTextBox.TabIndex = 16;
            // 
            // startTimeLabel
            // 
            startTimeLabel.AutoSize = true;
            startTimeLabel.Location = new System.Drawing.Point(134, 364);
            startTimeLabel.Name = "startTimeLabel";
            startTimeLabel.Size = new System.Drawing.Size(86, 20);
            startTimeLabel.TabIndex = 17;
            startTimeLabel.Text = "Start Time:";
            // 
            // startTimeDateTimePicker
            // 
            this.startTimeDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dTO_CalendarDataBindingSource, "StartTime", true));
            this.startTimeDateTimePicker.Location = new System.Drawing.Point(303, 360);
            this.startTimeDateTimePicker.Name = "startTimeDateTimePicker";
            this.startTimeDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.startTimeDateTimePicker.TabIndex = 18;
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 406);
            this.Controls.Add(appointmentTextLabel);
            this.Controls.Add(this.appointmentTextTextBox);
            this.Controls.Add(appointmentTypeIDLabel);
            this.Controls.Add(this.appointmentTypeIDTextBox);
            this.Controls.Add(claimIDLabel);
            this.Controls.Add(this.claimIDTextBox);
            this.Controls.Add(employeeIDLabel);
            this.Controls.Add(this.employeeIDTextBox);
            this.Controls.Add(endTimeLabel);
            this.Controls.Add(this.endTimeDateTimePicker);
            this.Controls.Add(entryIDLabel);
            this.Controls.Add(this.entryIDTextBox);
            this.Controls.Add(leadIDLabel);
            this.Controls.Add(this.leadIDTextBox);
            this.Controls.Add(noteLabel);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(startTimeLabel);
            this.Controls.Add(this.startTimeDateTimePicker);
            this.Controls.Add(this.dTO_CalendarDataBindingNavigator);
            this.Name = "AddAppointment";
            this.Text = "AddAppointment";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_CalendarDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_CalendarDataBindingNavigator)).EndInit();
            this.dTO_CalendarDataBindingNavigator.ResumeLayout(false);
            this.dTO_CalendarDataBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_CalendarDataBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_CalendarDataBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton dTO_CalendarDataBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox appointmentTextTextBox;
        private System.Windows.Forms.TextBox appointmentTypeIDTextBox;
        private System.Windows.Forms.TextBox claimIDTextBox;
        private System.Windows.Forms.TextBox employeeIDTextBox;
        private System.Windows.Forms.DateTimePicker endTimeDateTimePicker;
        private System.Windows.Forms.TextBox entryIDTextBox;
        private System.Windows.Forms.TextBox leadIDTextBox;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.DateTimePicker startTimeDateTimePicker;
    }
}