namespace MRN_Claim_Services
{
    partial class AddNewOrderItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewOrderItem));
            System.Windows.Forms.Label orderIDLabel;
            System.Windows.Forms.Label orderItemIDLabel;
            System.Windows.Forms.Label productIDLabel;
            System.Windows.Forms.Label quantityLabel;
            System.Windows.Forms.Label unitOfMeasureIDLabel;
            this.dTO_OrderItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTO_OrderItemBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.dTO_OrderItemBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.orderIDTextBox = new System.Windows.Forms.TextBox();
            this.orderItemIDTextBox = new System.Windows.Forms.TextBox();
            this.productIDTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.unitOfMeasureIDTextBox = new System.Windows.Forms.TextBox();
            orderIDLabel = new System.Windows.Forms.Label();
            orderItemIDLabel = new System.Windows.Forms.Label();
            productIDLabel = new System.Windows.Forms.Label();
            quantityLabel = new System.Windows.Forms.Label();
            unitOfMeasureIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_OrderItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_OrderItemBindingNavigator)).BeginInit();
            this.dTO_OrderItemBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // dTO_OrderItemBindingSource
            // 
            this.dTO_OrderItemBindingSource.DataSource = typeof(MRNNexus_Model.DTO_OrderItem);
            // 
            // dTO_OrderItemBindingNavigator
            // 
            this.dTO_OrderItemBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dTO_OrderItemBindingNavigator.BindingSource = this.dTO_OrderItemBindingSource;
            this.dTO_OrderItemBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dTO_OrderItemBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dTO_OrderItemBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dTO_OrderItemBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.dTO_OrderItemBindingNavigatorSaveItem});
            this.dTO_OrderItemBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dTO_OrderItemBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dTO_OrderItemBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dTO_OrderItemBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dTO_OrderItemBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dTO_OrderItemBindingNavigator.Name = "dTO_OrderItemBindingNavigator";
            this.dTO_OrderItemBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dTO_OrderItemBindingNavigator.Size = new System.Drawing.Size(304, 33);
            this.dTO_OrderItemBindingNavigator.TabIndex = 0;
            this.dTO_OrderItemBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // dTO_OrderItemBindingNavigatorSaveItem
            // 
            this.dTO_OrderItemBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dTO_OrderItemBindingNavigatorSaveItem.Enabled = false;
            this.dTO_OrderItemBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dTO_OrderItemBindingNavigatorSaveItem.Image")));
            this.dTO_OrderItemBindingNavigatorSaveItem.Name = "dTO_OrderItemBindingNavigatorSaveItem";
            this.dTO_OrderItemBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.dTO_OrderItemBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // orderIDLabel
            // 
            orderIDLabel.AutoSize = true;
            orderIDLabel.Location = new System.Drawing.Point(28, 25);
            orderIDLabel.Name = "orderIDLabel";
            orderIDLabel.Size = new System.Drawing.Size(74, 20);
            orderIDLabel.TabIndex = 1;
            orderIDLabel.Text = "Order ID:";
            // 
            // orderIDTextBox
            // 
            this.orderIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_OrderItemBindingSource, "OrderID", true));
            this.orderIDTextBox.Location = new System.Drawing.Point(184, 22);
            this.orderIDTextBox.Name = "orderIDTextBox";
            this.orderIDTextBox.Size = new System.Drawing.Size(100, 26);
            this.orderIDTextBox.TabIndex = 2;
            // 
            // orderItemIDLabel
            // 
            orderItemIDLabel.AutoSize = true;
            orderItemIDLabel.Location = new System.Drawing.Point(28, 57);
            orderItemIDLabel.Name = "orderItemIDLabel";
            orderItemIDLabel.Size = new System.Drawing.Size(110, 20);
            orderItemIDLabel.TabIndex = 3;
            orderItemIDLabel.Text = "Order Item ID:";
            // 
            // orderItemIDTextBox
            // 
            this.orderItemIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_OrderItemBindingSource, "OrderItemID", true));
            this.orderItemIDTextBox.Location = new System.Drawing.Point(184, 54);
            this.orderItemIDTextBox.Name = "orderItemIDTextBox";
            this.orderItemIDTextBox.Size = new System.Drawing.Size(100, 26);
            this.orderItemIDTextBox.TabIndex = 4;
            // 
            // productIDLabel
            // 
            productIDLabel.AutoSize = true;
            productIDLabel.Location = new System.Drawing.Point(28, 89);
            productIDLabel.Name = "productIDLabel";
            productIDLabel.Size = new System.Drawing.Size(89, 20);
            productIDLabel.TabIndex = 5;
            productIDLabel.Text = "Product ID:";
            // 
            // productIDTextBox
            // 
            this.productIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_OrderItemBindingSource, "ProductID", true));
            this.productIDTextBox.Location = new System.Drawing.Point(184, 86);
            this.productIDTextBox.Name = "productIDTextBox";
            this.productIDTextBox.Size = new System.Drawing.Size(100, 26);
            this.productIDTextBox.TabIndex = 6;
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.Location = new System.Drawing.Point(28, 121);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new System.Drawing.Size(72, 20);
            quantityLabel.TabIndex = 7;
            quantityLabel.Text = "Quantity:";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_OrderItemBindingSource, "Quantity", true));
            this.quantityTextBox.Location = new System.Drawing.Point(184, 118);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(100, 26);
            this.quantityTextBox.TabIndex = 8;
            // 
            // unitOfMeasureIDLabel
            // 
            unitOfMeasureIDLabel.AutoSize = true;
            unitOfMeasureIDLabel.Location = new System.Drawing.Point(28, 153);
            unitOfMeasureIDLabel.Name = "unitOfMeasureIDLabel";
            unitOfMeasureIDLabel.Size = new System.Drawing.Size(150, 20);
            unitOfMeasureIDLabel.TabIndex = 9;
            unitOfMeasureIDLabel.Text = "Unit Of Measure ID:";
            // 
            // unitOfMeasureIDTextBox
            // 
            this.unitOfMeasureIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dTO_OrderItemBindingSource, "UnitOfMeasureID", true));
            this.unitOfMeasureIDTextBox.Location = new System.Drawing.Point(184, 150);
            this.unitOfMeasureIDTextBox.Name = "unitOfMeasureIDTextBox";
            this.unitOfMeasureIDTextBox.Size = new System.Drawing.Size(100, 26);
            this.unitOfMeasureIDTextBox.TabIndex = 10;
            // 
            // AddNewOrderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 244);
            this.Controls.Add(orderIDLabel);
            this.Controls.Add(this.orderIDTextBox);
            this.Controls.Add(orderItemIDLabel);
            this.Controls.Add(this.orderItemIDTextBox);
            this.Controls.Add(productIDLabel);
            this.Controls.Add(this.productIDTextBox);
            this.Controls.Add(quantityLabel);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(unitOfMeasureIDLabel);
            this.Controls.Add(this.unitOfMeasureIDTextBox);
            this.Controls.Add(this.dTO_OrderItemBindingNavigator);
            this.Name = "AddNewOrderItem";
            this.Text = "AddNewOrderItem";
            ((System.ComponentModel.ISupportInitialize)(this.dTO_OrderItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTO_OrderItemBindingNavigator)).EndInit();
            this.dTO_OrderItemBindingNavigator.ResumeLayout(false);
            this.dTO_OrderItemBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dTO_OrderItemBindingSource;
        private System.Windows.Forms.BindingNavigator dTO_OrderItemBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton dTO_OrderItemBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox orderIDTextBox;
        private System.Windows.Forms.TextBox orderItemIDTextBox;
        private System.Windows.Forms.TextBox productIDTextBox;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.TextBox unitOfMeasureIDTextBox;
    }
}