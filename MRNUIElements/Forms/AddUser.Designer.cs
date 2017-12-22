namespace MRNUIElements
{
    partial class AddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            System.Windows.Forms.Label activeLabel;
            System.Windows.Forms.Label employeeIDLabel;
            System.Windows.Forms.Label passLabel;
            System.Windows.Forms.Label permissionIDLabel;
            System.Windows.Forms.Label userIDLabel;
            System.Windows.Forms.Label usernameLabel;
            this.dTO_UserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTO_UserBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.dTO_UserBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.employeeIDTextBox = new System.Windows.Forms.TextBox();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.permissionIDTextBox = new System.Windows.Forms.TextBox();
            this.userIDTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            activeLabel = new System.Windows.Forms.Label();
            employeeIDLabel = new System.Windows.Forms.Label();
            passLabel = new System.Windows.Forms.Label();
            permissionIDLabel = new System.Windows.Forms.Label();
            userIDLabel = new System.Windows.Forms.Label();
            usernameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_UserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_UserBindingNavigator)).BeginInit();
            this.dTO_UserBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // dTO_UserBindingSource
            // 
            this.dTO_UserBindingSource.DataSource = typeof(MRNNexus_Model.DTO_User);
            // 
            // dTO_UserBindingNavigator
            // 
            this.dTO_UserBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_UserBindingNavigator.BindingSource = this.dTO_UserBindingSource;
            this.dTO_UserBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_UserBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_UserBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_UserBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.dTO_UserBindingNavigatorSaveItem});
            this.dTO_UserBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_UserBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_UserBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_UserBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_UserBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_UserBindingNavigator.Name = "dTO_UserBindingNavigator";
            this.dTO_UserBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_UserBindingNavigator.Size = new System.Drawing.Size(297, 33);
            this.dTO_UserBindingNavigator.TabIndex = 0;
            this.dTO_UserBindingNavigator.Text = "bindingNavigator1";
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
            // dTO_UserBindingNavigatorSaveItem
            // 
            this.dTO_UserBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_UserBindingNavigatorSaveItem.Enabled = false;
            this.dTO_UserBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_UserBindingNavigatorSaveItem.Image")));
            this.dTO_UserBindingNavigatorSaveItem.Name = "dTO_UserBindingNavigatorSaveItem";
            this.dTO_UserBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.dTO_UserBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // activeLabel
            // 
            activeLabel.AutoSize = true;
            activeLabel.Location = new System.Drawing.Point(56, 19);
            activeLabel.Name = "activeLabel";
            activeLabel.Size = new System.Drawing.Size(56, 20);
            activeLabel.TabIndex = 1;
            activeLabel.Text = "Active:";
            // 
            // activeCheckBox
            // 
            this.activeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dTO_UserBindingSource, "Active", true));
            this.activeCheckBox.Location = new System.Drawing.Point(173, 14);
            this.activeCheckBox.Name = "activeCheckBox";
            this.activeCheckBox.Size = new System.Drawing.Size(104, 24);
            this.activeCheckBox.TabIndex = 2;
            this.activeCheckBox.Text = "checkBox1";
            this.activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // employeeIDLabel
            // 
            employeeIDLabel.AutoSize = true;
            employeeIDLabel.Location = new System.Drawing.Point(56, 48);
            employeeIDLabel.Name = "employeeIDLabel";
            employeeIDLabel.Size = new System.Drawing.Size(104, 20);
            employeeIDLabel.TabIndex = 3;
            employeeIDLabel.Text = "Employee ID:";
            // 
            // employeeIDTextBox
            // 
            this.employeeIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_UserBindingSource, "EmployeeID", true));
            this.employeeIDTextBox.Location = new System.Drawing.Point(173, 45);
            this.employeeIDTextBox.Name = "employeeIDTextBox";
            this.employeeIDTextBox.Size = new System.Drawing.Size(104, 26);
            this.employeeIDTextBox.TabIndex = 4;
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Location = new System.Drawing.Point(56, 80);
            passLabel.Name = "passLabel";
            passLabel.Size = new System.Drawing.Size(48, 20);
            passLabel.TabIndex = 5;
            passLabel.Text = "Pass:";
            // 
            // passTextBox
            // 
            this.passTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_UserBindingSource, "Pass", true));
            this.passTextBox.Location = new System.Drawing.Point(173, 77);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.Size = new System.Drawing.Size(104, 26);
            this.passTextBox.TabIndex = 6;
            // 
            // permissionIDLabel
            // 
            permissionIDLabel.AutoSize = true;
            permissionIDLabel.Location = new System.Drawing.Point(56, 112);
            permissionIDLabel.Name = "permissionIDLabel";
            permissionIDLabel.Size = new System.Drawing.Size(111, 20);
            permissionIDLabel.TabIndex = 7;
            permissionIDLabel.Text = "Permission ID:";
            // 
            // permissionIDTextBox
            // 
            this.permissionIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_UserBindingSource, "PermissionID", true));
            this.permissionIDTextBox.Location = new System.Drawing.Point(173, 109);
            this.permissionIDTextBox.Name = "permissionIDTextBox";
            this.permissionIDTextBox.Size = new System.Drawing.Size(104, 26);
            this.permissionIDTextBox.TabIndex = 8;
            // 
            // userIDLabel
            // 
            userIDLabel.AutoSize = true;
            userIDLabel.Location = new System.Drawing.Point(56, 144);
            userIDLabel.Name = "userIDLabel";
            userIDLabel.Size = new System.Drawing.Size(68, 20);
            userIDLabel.TabIndex = 9;
            userIDLabel.Text = "User ID:";
            // 
            // userIDTextBox
            // 
            this.userIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_UserBindingSource, "UserID", true));
            this.userIDTextBox.Location = new System.Drawing.Point(173, 141);
            this.userIDTextBox.Name = "userIDTextBox";
            this.userIDTextBox.Size = new System.Drawing.Size(104, 26);
            this.userIDTextBox.TabIndex = 10;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new System.Drawing.Point(56, 176);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(87, 20);
            usernameLabel.TabIndex = 11;
            usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_UserBindingSource, "Username", true));
            this.usernameTextBox.Location = new System.Drawing.Point(173, 173);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(104, 26);
            this.usernameTextBox.TabIndex = 12;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 244);
            this.Controls.Add(activeLabel);
            this.Controls.Add(this.activeCheckBox);
            this.Controls.Add(employeeIDLabel);
            this.Controls.Add(this.employeeIDTextBox);
            this.Controls.Add(passLabel);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(permissionIDLabel);
            this.Controls.Add(this.permissionIDTextBox);
            this.Controls.Add(userIDLabel);
            this.Controls.Add(this.userIDTextBox);
            this.Controls.Add(usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.dTO_UserBindingNavigator);
            this.Name = "AddUser";
            this.Text = "AddUser";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_UserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_UserBindingNavigator)).EndInit();
            this.dTO_UserBindingNavigator.ResumeLayout(false);
            this.dTO_UserBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_UserBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_UserBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton dTO_UserBindingNavigatorSaveItem;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.TextBox employeeIDTextBox;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.TextBox permissionIDTextBox;
        private System.Windows.Forms.TextBox userIDTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
    }
}