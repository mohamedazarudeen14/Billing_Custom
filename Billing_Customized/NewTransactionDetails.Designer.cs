namespace Billing_Customized
{
    partial class NewTransactionDetails
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
            this.TransactionDetails_label = new System.Windows.Forms.Label();
            this.From_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GetDetails_button = new System.Windows.Forms.Button();
            this.TransactionDetail_ListView = new System.Windows.Forms.ListView();
            this.SerialNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BillNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Bill_Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GST_Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BillAmount_Textbox = new System.Windows.Forms.TextBox();
            this.Total_GST_Textbox = new System.Windows.Forms.TextBox();
            this.Total_GST_Amount = new System.Windows.Forms.Label();
            this.Total_Bill_Amount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Total_bill_Nos_Textbox = new System.Windows.Forms.TextBox();
            this.TotalBill_Nos_Label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Get_Transaction_Details_Label = new System.Windows.Forms.Label();
            this.Print_Button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FromDateDatePicker
            // 
            this.FromDateDatePicker.CustomFormat = "dd/MM/yyyy";
            this.FromDateDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDateDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromDateDatePicker.Location = new System.Drawing.Point(203, 24);
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
            this.ToDateDatePicker.Location = new System.Drawing.Point(203, 113);
            this.ToDateDatePicker.Name = "ToDateDatePicker";
            this.ToDateDatePicker.Size = new System.Drawing.Size(200, 30);
            this.ToDateDatePicker.TabIndex = 1;
            // 
            // TransactionDetails_label
            // 
            this.TransactionDetails_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionDetails_label.AutoSize = true;
            this.TransactionDetails_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionDetails_label.Location = new System.Drawing.Point(644, 18);
            this.TransactionDetails_label.Name = "TransactionDetails_label";
            this.TransactionDetails_label.Size = new System.Drawing.Size(499, 25);
            this.TransactionDetails_label.TabIndex = 2;
            this.TransactionDetails_label.Text = "TRANSACTION DETAILS FOR SELECTED DATE";
            // 
            // From_label
            // 
            this.From_label.AutoSize = true;
            this.From_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.From_label.Location = new System.Drawing.Point(37, 24);
            this.From_label.Name = "From_label";
            this.From_label.Size = new System.Drawing.Size(138, 25);
            this.From_label.TabIndex = 5;
            this.From_label.Text = "FROM DATE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "TILL DATE";
            // 
            // GetDetails_button
            // 
            this.GetDetails_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetDetails_button.Location = new System.Drawing.Point(42, 187);
            this.GetDetails_button.Name = "GetDetails_button";
            this.GetDetails_button.Size = new System.Drawing.Size(361, 51);
            this.GetDetails_button.TabIndex = 2;
            this.GetDetails_button.Text = "Get Details";
            this.GetDetails_button.UseVisualStyleBackColor = true;
            this.GetDetails_button.Click += new System.EventHandler(this.GetDetails_button_Click);
            // 
            // TransactionDetail_ListView
            // 
            this.TransactionDetail_ListView.AutoArrange = false;
            this.TransactionDetail_ListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TransactionDetail_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SerialNumber,
            this.Date,
            this.BillNumber,
            this.Bill_Amount,
            this.GST_Amount});
            this.TransactionDetail_ListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionDetail_ListView.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.TransactionDetail_ListView.FullRowSelect = true;
            this.TransactionDetail_ListView.GridLines = true;
            this.TransactionDetail_ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.TransactionDetail_ListView.HideSelection = false;
            this.TransactionDetail_ListView.LabelWrap = false;
            this.TransactionDetail_ListView.Location = new System.Drawing.Point(477, 72);
            this.TransactionDetail_ListView.Name = "TransactionDetail_ListView";
            this.TransactionDetail_ListView.Size = new System.Drawing.Size(797, 527);
            this.TransactionDetail_ListView.TabIndex = 15;
            this.TransactionDetail_ListView.UseCompatibleStateImageBehavior = false;
            this.TransactionDetail_ListView.View = System.Windows.Forms.View.Details;
            this.TransactionDetail_ListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.TransactionDetail_ListView_ColumnWidthChanging);
            // 
            // SerialNumber
            // 
            this.SerialNumber.Text = "S.NO.";
            this.SerialNumber.Width = 125;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Date.Width = 148;
            // 
            // BillNumber
            // 
            this.BillNumber.Text = "Bill Number";
            this.BillNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BillNumber.Width = 158;
            // 
            // Bill_Amount
            // 
            this.Bill_Amount.Text = "Bill Amount";
            this.Bill_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Bill_Amount.Width = 179;
            // 
            // GST_Amount
            // 
            this.GST_Amount.Text = "GST Amount";
            this.GST_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GST_Amount.Width = 182;
            // 
            // BillAmount_Textbox
            // 
            this.BillAmount_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillAmount_Textbox.Location = new System.Drawing.Point(238, 351);
            this.BillAmount_Textbox.Name = "BillAmount_Textbox";
            this.BillAmount_Textbox.ReadOnly = true;
            this.BillAmount_Textbox.Size = new System.Drawing.Size(165, 30);
            this.BillAmount_Textbox.TabIndex = 19;
            // 
            // Total_GST_Textbox
            // 
            this.Total_GST_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total_GST_Textbox.Location = new System.Drawing.Point(238, 411);
            this.Total_GST_Textbox.Name = "Total_GST_Textbox";
            this.Total_GST_Textbox.ReadOnly = true;
            this.Total_GST_Textbox.Size = new System.Drawing.Size(165, 30);
            this.Total_GST_Textbox.TabIndex = 23;
            // 
            // Total_GST_Amount
            // 
            this.Total_GST_Amount.AutoSize = true;
            this.Total_GST_Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total_GST_Amount.Location = new System.Drawing.Point(37, 414);
            this.Total_GST_Amount.Name = "Total_GST_Amount";
            this.Total_GST_Amount.Size = new System.Drawing.Size(192, 25);
            this.Total_GST_Amount.TabIndex = 22;
            this.Total_GST_Amount.Text = "Total GST Amount";
            // 
            // Total_Bill_Amount
            // 
            this.Total_Bill_Amount.AutoSize = true;
            this.Total_Bill_Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total_Bill_Amount.Location = new System.Drawing.Point(37, 354);
            this.Total_Bill_Amount.Name = "Total_Bill_Amount";
            this.Total_Bill_Amount.Size = new System.Drawing.Size(176, 25);
            this.Total_Bill_Amount.TabIndex = 24;
            this.Total_Bill_Amount.Text = "Total Bill Amount";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.Print_Button);
            this.panel1.Controls.Add(this.Total_bill_Nos_Textbox);
            this.panel1.Controls.Add(this.TotalBill_Nos_Label);
            this.panel1.Controls.Add(this.From_label);
            this.panel1.Controls.Add(this.FromDateDatePicker);
            this.panel1.Controls.Add(this.Total_GST_Textbox);
            this.panel1.Controls.Add(this.Total_Bill_Amount);
            this.panel1.Controls.Add(this.Total_GST_Amount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BillAmount_Textbox);
            this.panel1.Controls.Add(this.ToDateDatePicker);
            this.panel1.Controls.Add(this.GetDetails_button);
            this.panel1.Location = new System.Drawing.Point(12, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 527);
            this.panel1.TabIndex = 26;
            // 
            // Total_bill_Nos_Textbox
            // 
            this.Total_bill_Nos_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total_bill_Nos_Textbox.Location = new System.Drawing.Point(238, 290);
            this.Total_bill_Nos_Textbox.Name = "Total_bill_Nos_Textbox";
            this.Total_bill_Nos_Textbox.ReadOnly = true;
            this.Total_bill_Nos_Textbox.Size = new System.Drawing.Size(165, 30);
            this.Total_bill_Nos_Textbox.TabIndex = 27;
            // 
            // TotalBill_Nos_Label
            // 
            this.TotalBill_Nos_Label.AutoSize = true;
            this.TotalBill_Nos_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalBill_Nos_Label.Location = new System.Drawing.Point(37, 293);
            this.TotalBill_Nos_Label.Name = "TotalBill_Nos_Label";
            this.TotalBill_Nos_Label.Size = new System.Drawing.Size(149, 25);
            this.TotalBill_Nos_Label.TabIndex = 26;
            this.TotalBill_Nos_Label.Text = "Total Bill NOS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.Get_Transaction_Details_Label);
            this.panel2.Controls.Add(this.TransactionDetails_label);
            this.panel2.Location = new System.Drawing.Point(12, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1262, 59);
            this.panel2.TabIndex = 27;
            // 
            // Get_Transaction_Details_Label
            // 
            this.Get_Transaction_Details_Label.AutoSize = true;
            this.Get_Transaction_Details_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Get_Transaction_Details_Label.Location = new System.Drawing.Point(81, 18);
            this.Get_Transaction_Details_Label.Name = "Get_Transaction_Details_Label";
            this.Get_Transaction_Details_Label.Size = new System.Drawing.Size(315, 25);
            this.Get_Transaction_Details_Label.TabIndex = 3;
            this.Get_Transaction_Details_Label.Text = "GET TRANSACTION DETAILS";
            // 
            // Print_Button
            // 
            this.Print_Button.Enabled = false;
            this.Print_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Print_Button.Location = new System.Drawing.Point(42, 460);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(361, 51);
            this.Print_Button.TabIndex = 28;
            this.Print_Button.Text = "Print Details";
            this.Print_Button.UseVisualStyleBackColor = true;
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // NewTransactionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1286, 611);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TransactionDetail_ListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "NewTransactionDetails";
            this.Text = "TransactionDetails";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TransactionDetails_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker FromDateDatePicker;
        private System.Windows.Forms.DateTimePicker ToDateDatePicker;
        private System.Windows.Forms.Label TransactionDetails_label;
        private System.Windows.Forms.Label From_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GetDetails_button;
        private System.Windows.Forms.ColumnHeader SerialNumber;
        private System.Windows.Forms.ColumnHeader Date;
        public System.Windows.Forms.ListView TransactionDetail_ListView;
        private System.Windows.Forms.ColumnHeader BillNumber;
        private System.Windows.Forms.ColumnHeader GST_Amount;
        private System.Windows.Forms.TextBox BillAmount_Textbox;
        private System.Windows.Forms.TextBox Total_GST_Textbox;
        private System.Windows.Forms.Label Total_GST_Amount;
        private System.Windows.Forms.ColumnHeader Bill_Amount;
        private System.Windows.Forms.Label Total_Bill_Amount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox Total_bill_Nos_Textbox;
        private System.Windows.Forms.Label TotalBill_Nos_Label;
        private System.Windows.Forms.Label Get_Transaction_Details_Label;
        private System.Windows.Forms.Button Print_Button;
    }
}