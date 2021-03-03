namespace Billing_Customized
{
    partial class ReturnBill
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
            this.Date_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.ReturnBill_label = new System.Windows.Forms.Label();
            this.Date_label = new System.Windows.Forms.Label();
            this.BILL_NUMBER = new System.Windows.Forms.Label();
            this.GetDetails_button = new System.Windows.Forms.Button();
            this.TransactionDetail_ListView = new System.Windows.Forms.ListView();
            this.SerialNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Product_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BillAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GST_Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Bill_Number_Textbox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Bill_Details_Label = new System.Windows.Forms.Label();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Bill_Amount_Textbox = new System.Windows.Forms.TextBox();
            this.BillAmount_Label = new System.Windows.Forms.Label();
            this.Sales_Textbox = new System.Windows.Forms.TextBox();
            this.SalesDate_Label = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Purchases_Product_Details_Label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Date_DatePicker
            // 
            this.Date_DatePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Date_DatePicker.CustomFormat = "dd/MM/yyyy";
            this.Date_DatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Date_DatePicker.Location = new System.Drawing.Point(190, 23);
            this.Date_DatePicker.Name = "Date_DatePicker";
            this.Date_DatePicker.Size = new System.Drawing.Size(149, 30);
            this.Date_DatePicker.TabIndex = 0;
            // 
            // ReturnBill_label
            // 
            this.ReturnBill_label.AutoSize = true;
            this.ReturnBill_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnBill_label.Location = new System.Drawing.Point(513, 24);
            this.ReturnBill_label.Name = "ReturnBill_label";
            this.ReturnBill_label.Size = new System.Drawing.Size(245, 25);
            this.ReturnBill_label.TabIndex = 2;
            this.ReturnBill_label.Text = "RETURN BILL DETAILS";
            // 
            // Date_label
            // 
            this.Date_label.AutoSize = true;
            this.Date_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_label.Location = new System.Drawing.Point(109, 28);
            this.Date_label.Name = "Date_label";
            this.Date_label.Size = new System.Drawing.Size(70, 25);
            this.Date_label.TabIndex = 5;
            this.Date_label.Text = "DATE";
            // 
            // BILL_NUMBER
            // 
            this.BILL_NUMBER.AutoSize = true;
            this.BILL_NUMBER.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BILL_NUMBER.Location = new System.Drawing.Point(480, 28);
            this.BILL_NUMBER.Name = "BILL_NUMBER";
            this.BILL_NUMBER.Size = new System.Drawing.Size(94, 25);
            this.BILL_NUMBER.TabIndex = 6;
            this.BILL_NUMBER.Text = "BILL NO";
            // 
            // GetDetails_button
            // 
            this.GetDetails_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GetDetails_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetDetails_button.Location = new System.Drawing.Point(845, 15);
            this.GetDetails_button.Name = "GetDetails_button";
            this.GetDetails_button.Size = new System.Drawing.Size(150, 51);
            this.GetDetails_button.TabIndex = 2;
            this.GetDetails_button.Text = "Get Details";
            this.GetDetails_button.UseVisualStyleBackColor = true;
            this.GetDetails_button.Click += new System.EventHandler(this.GetDetails_button_Click);
            // 
            // TransactionDetail_ListView
            // 
            this.TransactionDetail_ListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionDetail_ListView.AutoArrange = false;
            this.TransactionDetail_ListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TransactionDetail_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SerialNumber,
            this.Date,
            this.Product_ID,
            this.ProductName,
            this.Quantity,
            this.BillAmount,
            this.GST_Amount});
            this.TransactionDetail_ListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionDetail_ListView.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.TransactionDetail_ListView.FullRowSelect = true;
            this.TransactionDetail_ListView.GridLines = true;
            this.TransactionDetail_ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.TransactionDetail_ListView.HideSelection = false;
            this.TransactionDetail_ListView.LabelWrap = false;
            this.TransactionDetail_ListView.Location = new System.Drawing.Point(12, 371);
            this.TransactionDetail_ListView.Name = "TransactionDetail_ListView";
            this.TransactionDetail_ListView.Size = new System.Drawing.Size(1221, 218);
            this.TransactionDetail_ListView.TabIndex = 4;
            this.TransactionDetail_ListView.UseCompatibleStateImageBehavior = false;
            this.TransactionDetail_ListView.View = System.Windows.Forms.View.Details;
            this.TransactionDetail_ListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.TransactionDetail_ListView_ColumnWidthChanging);
            // 
            // SerialNumber
            // 
            this.SerialNumber.Text = "S.NO.";
            this.SerialNumber.Width = 110;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Date.Width = 144;
            // 
            // Product_ID
            // 
            this.Product_ID.Text = "Product ID";
            this.Product_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Product_ID.Width = 175;
            // 
            // ProductName
            // 
            this.ProductName.Text = "Product Name";
            this.ProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProductName.Width = 279;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Total Quantity";
            this.Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Quantity.Width = 171;
            // 
            // BillAmount
            // 
            this.BillAmount.Text = "Bill Amount";
            this.BillAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BillAmount.Width = 175;
            // 
            // GST_Amount
            // 
            this.GST_Amount.Text = "GST Amount";
            this.GST_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GST_Amount.Width = 164;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.Bill_Number_Textbox);
            this.panel1.Controls.Add(this.GetDetails_button);
            this.panel1.Controls.Add(this.Date_DatePicker);
            this.panel1.Controls.Add(this.Date_label);
            this.panel1.Controls.Add(this.BILL_NUMBER);
            this.panel1.Location = new System.Drawing.Point(12, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1221, 80);
            this.panel1.TabIndex = 26;
            // 
            // Bill_Number_Textbox
            // 
            this.Bill_Number_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bill_Number_Textbox.Location = new System.Drawing.Point(592, 25);
            this.Bill_Number_Textbox.Name = "Bill_Number_Textbox";
            this.Bill_Number_Textbox.Size = new System.Drawing.Size(149, 30);
            this.Bill_Number_Textbox.TabIndex = 7;
            this.Bill_Number_Textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BillNumber_Textbox_Keypress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.ReturnBill_label);
            this.panel2.Location = new System.Drawing.Point(12, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1221, 69);
            this.panel2.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.Bill_Details_Label);
            this.panel3.Location = new System.Drawing.Point(12, 167);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1221, 46);
            this.panel3.TabIndex = 28;
            // 
            // Bill_Details_Label
            // 
            this.Bill_Details_Label.AutoSize = true;
            this.Bill_Details_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bill_Details_Label.Location = new System.Drawing.Point(554, 9);
            this.Bill_Details_Label.Name = "Bill_Details_Label";
            this.Bill_Details_Label.Size = new System.Drawing.Size(153, 25);
            this.Bill_Details_Label.TabIndex = 5;
            this.Bill_Details_Label.Text = "BILL DETAILS";
            // 
            // Delete_btn
            // 
            this.Delete_btn.Enabled = false;
            this.Delete_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_btn.Location = new System.Drawing.Point(845, 17);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(150, 51);
            this.Delete_btn.TabIndex = 4;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel4.Controls.Add(this.Bill_Amount_Textbox);
            this.panel4.Controls.Add(this.Delete_btn);
            this.panel4.Controls.Add(this.BillAmount_Label);
            this.panel4.Controls.Add(this.Sales_Textbox);
            this.panel4.Controls.Add(this.SalesDate_Label);
            this.panel4.Location = new System.Drawing.Point(12, 219);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1221, 94);
            this.panel4.TabIndex = 29;
            // 
            // Bill_Amount_Textbox
            // 
            this.Bill_Amount_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bill_Amount_Textbox.Location = new System.Drawing.Point(592, 27);
            this.Bill_Amount_Textbox.Name = "Bill_Amount_Textbox";
            this.Bill_Amount_Textbox.ReadOnly = true;
            this.Bill_Amount_Textbox.Size = new System.Drawing.Size(149, 30);
            this.Bill_Amount_Textbox.TabIndex = 3;
            // 
            // BillAmount_Label
            // 
            this.BillAmount_Label.AutoSize = true;
            this.BillAmount_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillAmount_Label.Location = new System.Drawing.Point(387, 30);
            this.BillAmount_Label.Name = "BillAmount_Label";
            this.BillAmount_Label.Size = new System.Drawing.Size(187, 25);
            this.BillAmount_Label.TabIndex = 2;
            this.BillAmount_Label.Text = "TOTAL BILL AMT";
            // 
            // Sales_Textbox
            // 
            this.Sales_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sales_Textbox.Location = new System.Drawing.Point(190, 24);
            this.Sales_Textbox.Name = "Sales_Textbox";
            this.Sales_Textbox.ReadOnly = true;
            this.Sales_Textbox.Size = new System.Drawing.Size(149, 30);
            this.Sales_Textbox.TabIndex = 1;
            // 
            // SalesDate_Label
            // 
            this.SalesDate_Label.AutoSize = true;
            this.SalesDate_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesDate_Label.Location = new System.Drawing.Point(32, 27);
            this.SalesDate_Label.Name = "SalesDate_Label";
            this.SalesDate_Label.Size = new System.Drawing.Size(147, 25);
            this.SalesDate_Label.TabIndex = 0;
            this.SalesDate_Label.Text = "SALES DATE";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Controls.Add(this.Purchases_Product_Details_Label);
            this.panel5.Location = new System.Drawing.Point(12, 319);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1221, 46);
            this.panel5.TabIndex = 30;
            // 
            // Purchases_Product_Details_Label
            // 
            this.Purchases_Product_Details_Label.AutoSize = true;
            this.Purchases_Product_Details_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Purchases_Product_Details_Label.Location = new System.Drawing.Point(450, 9);
            this.Purchases_Product_Details_Label.Name = "Purchases_Product_Details_Label";
            this.Purchases_Product_Details_Label.Size = new System.Drawing.Size(353, 25);
            this.Purchases_Product_Details_Label.TabIndex = 5;
            this.Purchases_Product_Details_Label.Text = "PURCHASED PRODUCT DETAILS";
            // 
            // ReturnBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1245, 601);
            this.ControlBox = false;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TransactionDetail_ListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ReturnBill";
            this.Text = "TransactionDetails";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ProductSalesDetails_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Date_DatePicker;
        private System.Windows.Forms.Label ReturnBill_label;
        private System.Windows.Forms.Label Date_label;
        private System.Windows.Forms.Label BILL_NUMBER;
        private System.Windows.Forms.Button GetDetails_button;
        private System.Windows.Forms.ColumnHeader SerialNumber;
        private System.Windows.Forms.ColumnHeader Date;
        public System.Windows.Forms.ListView TransactionDetail_ListView;
        private System.Windows.Forms.ColumnHeader Product_ID;
        private System.Windows.Forms.ColumnHeader GST_Amount;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader BillAmount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ColumnHeader ProductName;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.TextBox Bill_Number_Textbox;
        private System.Windows.Forms.Label Bill_Details_Label;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox Bill_Amount_Textbox;
        private System.Windows.Forms.Label BillAmount_Label;
        private System.Windows.Forms.TextBox Sales_Textbox;
        private System.Windows.Forms.Label SalesDate_Label;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label Purchases_Product_Details_Label;
    }
}