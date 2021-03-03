namespace Billing_Customized
{
    partial class ProductSalesDetails
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
            this.FromDateDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ToDateDatePicker = new System.Windows.Forms.DateTimePicker();
            this.IndividualProductDetails_label = new System.Windows.Forms.Label();
            this.From_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Print_Details_btn = new System.Windows.Forms.Button();
            this.SearchProduct_Textbox = new System.Windows.Forms.TextBox();
            this.Search_Product_Label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // FromDateDatePicker
            // 
            this.FromDateDatePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FromDateDatePicker.CustomFormat = "dd/MM/yyyy";
            this.FromDateDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDateDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromDateDatePicker.Location = new System.Drawing.Point(260, 23);
            this.FromDateDatePicker.Name = "FromDateDatePicker";
            this.FromDateDatePicker.Size = new System.Drawing.Size(200, 30);
            this.FromDateDatePicker.TabIndex = 0;
            // 
            // ToDateDatePicker
            // 
            this.ToDateDatePicker.Checked = false;
            this.ToDateDatePicker.CustomFormat = "dd/MM/yyyy";
            this.ToDateDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDateDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToDateDatePicker.Location = new System.Drawing.Point(644, 23);
            this.ToDateDatePicker.Name = "ToDateDatePicker";
            this.ToDateDatePicker.Size = new System.Drawing.Size(200, 30);
            this.ToDateDatePicker.TabIndex = 1;
            // 
            // IndividualProductDetails_label
            // 
            this.IndividualProductDetails_label.AutoSize = true;
            this.IndividualProductDetails_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndividualProductDetails_label.Location = new System.Drawing.Point(366, 22);
            this.IndividualProductDetails_label.Name = "IndividualProductDetails_label";
            this.IndividualProductDetails_label.Size = new System.Drawing.Size(513, 25);
            this.IndividualProductDetails_label.TabIndex = 2;
            this.IndividualProductDetails_label.Text = "PRODUCT SOLD DETAILS FOR SELECTED DATE";
            // 
            // From_label
            // 
            this.From_label.AutoSize = true;
            this.From_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.From_label.Location = new System.Drawing.Point(95, 28);
            this.From_label.Name = "From_label";
            this.From_label.Size = new System.Drawing.Size(138, 25);
            this.From_label.TabIndex = 5;
            this.From_label.Text = "FROM DATE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(502, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "TILL DATE";
            // 
            // GetDetails_button
            // 
            this.GetDetails_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GetDetails_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetDetails_button.Location = new System.Drawing.Point(936, 15);
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
            this.TransactionDetail_ListView.Location = new System.Drawing.Point(12, 261);
            this.TransactionDetail_ListView.Name = "TransactionDetail_ListView";
            this.TransactionDetail_ListView.Size = new System.Drawing.Size(1221, 328);
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
            this.panel1.Controls.Add(this.ToDateDatePicker);
            this.panel1.Controls.Add(this.GetDetails_button);
            this.panel1.Controls.Add(this.FromDateDatePicker);
            this.panel1.Controls.Add(this.From_label);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1221, 80);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.IndividualProductDetails_label);
            this.panel2.Location = new System.Drawing.Point(12, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1221, 69);
            this.panel2.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel3.Controls.Add(this.Print_Details_btn);
            this.panel3.Controls.Add(this.SearchProduct_Textbox);
            this.panel3.Controls.Add(this.Search_Product_Label);
            this.panel3.Location = new System.Drawing.Point(12, 167);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1221, 88);
            this.panel3.TabIndex = 28;
            // 
            // Print_Details_btn
            // 
            this.Print_Details_btn.Enabled = false;
            this.Print_Details_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Print_Details_btn.Location = new System.Drawing.Point(936, 20);
            this.Print_Details_btn.Name = "Print_Details_btn";
            this.Print_Details_btn.Size = new System.Drawing.Size(150, 51);
            this.Print_Details_btn.TabIndex = 4;
            this.Print_Details_btn.Text = "Print Details";
            this.Print_Details_btn.UseVisualStyleBackColor = true;
            this.Print_Details_btn.Click += new System.EventHandler(this.Print_Details_btn_Click);
            // 
            // SearchProduct_Textbox
            // 
            this.SearchProduct_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchProduct_Textbox.Location = new System.Drawing.Point(260, 27);
            this.SearchProduct_Textbox.Name = "SearchProduct_Textbox";
            this.SearchProduct_Textbox.ReadOnly = true;
            this.SearchProduct_Textbox.Size = new System.Drawing.Size(264, 30);
            this.SearchProduct_Textbox.TabIndex = 3;
            this.SearchProduct_Textbox.TextChanged += new System.EventHandler(this.Search_Textbox_TextChanged);
            // 
            // Search_Product_Label
            // 
            this.Search_Product_Label.AutoSize = true;
            this.Search_Product_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_Product_Label.Location = new System.Drawing.Point(17, 32);
            this.Search_Product_Label.Name = "Search_Product_Label";
            this.Search_Product_Label.Size = new System.Drawing.Size(225, 25);
            this.Search_Product_Label.TabIndex = 0;
            this.Search_Product_Label.Text = "Search Listed Product";
            // 
            // ProductSalesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1245, 601);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TransactionDetail_ListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ProductSalesDetails";
            this.Text = "TransactionDetails";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ProductSalesDetails_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker FromDateDatePicker;
        private System.Windows.Forms.DateTimePicker ToDateDatePicker;
        private System.Windows.Forms.Label IndividualProductDetails_label;
        private System.Windows.Forms.Label From_label;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.Label Search_Product_Label;
        private System.Windows.Forms.TextBox SearchProduct_Textbox;
        private System.Windows.Forms.ColumnHeader ProductName;
        private System.Windows.Forms.Button Print_Details_btn;
    }
}