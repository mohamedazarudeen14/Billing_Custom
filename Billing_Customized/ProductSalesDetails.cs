using BusinessLayer;
using CommonClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace Billing_Customized
{
    public partial class ProductSalesDetails : Form
    {
        private Admin admin;
        List<List<ProductSalesDetail>> listOfSalesDetailfromSelectedDate;
        string date = string.Empty;
        long productId = 0L;
        string productName = string.Empty;
        decimal quantity = 0;
        decimal billAmount = 0;
        decimal gstAmount = 0;

        public ProductSalesDetails()
        {
            InitializeComponent();
            admin = new Admin();
        }

        private void TransactionDetail_ListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = TransactionDetail_ListView.Columns[e.ColumnIndex].Width;
        }

        private void GetDetails_button_Click(object sender, EventArgs e)
        {
            try
            {
                quantity = 0;
                billAmount = 0;
                gstAmount = 0;
                SearchProduct_Textbox.ReadOnly = true;
                SearchProduct_Textbox.Text = string.Empty;
                TransactionDetail_ListView.Items.Clear();
                DateTime fromDate = FromDateDatePicker.Value;
                DateTime toDate = ToDateDatePicker.Value;
                if (fromDate.Date <= toDate.Date)
                {
                    listOfSalesDetailfromSelectedDate = admin.GetProductSalesDetailsForSelectedDate(fromDate, toDate);

                    if (listOfSalesDetailfromSelectedDate != null && listOfSalesDetailfromSelectedDate.Count > 0)
                    {
                        SearchProduct_Textbox.ReadOnly = false;
                        Print_Details_btn.Enabled = true;
                        LoadDataIntoListview();
                    }
                    else
                    {
                        MessageBox.Show("No sales details found for selected date", "ITEM NOT FOUND", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("From date should be lesser than or equal till date", "ITEM NOT FOUND", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at TransactionDetailsPage", MessageBoxButtons.OK);
            }
        }

        private void ProductSalesDetails_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetDetails_button_Click(null, null);
            }
            else if(e.KeyCode == Keys.F2)
            {
                Print_Details_btn_Click(null, null);
            }
        }

        private void Search_Textbox_TextChanged(object sender, EventArgs e)
        {
            bool isAvailable = false;
            TransactionDetail_ListView.Items.Clear();
            int i = 0;

            if (!string.IsNullOrWhiteSpace(SearchProduct_Textbox.Text))
            {
                foreach (var items in listOfSalesDetailfromSelectedDate)
                {
                    quantity = 0;
                    billAmount = 0;
                    gstAmount = 0;
                    foreach (var item in items)
                    {
                        if (item.ProductId.ToString().ToLower().StartsWith(SearchProduct_Textbox.Text) || item.ProductName.ToLower().StartsWith(SearchProduct_Textbox.Text))
                        {
                            isAvailable = true;
                            date = item.SoldDate.Date.ToString("dd-MM-yyyy");
                            productId = item.ProductId;
                            productName = item.ProductName;
                            quantity += item.Quantity;
                            billAmount += item.BillAmount;
                            gstAmount += item.GstAmount;
                        }
                        else
                        {
                            isAvailable = false;
                        }
                    }
                    if (isAvailable)
                    {
                        TransactionDetail_ListView.Items.Add(new ListViewItem(new string[] { (++i).ToString(), date, productId.ToString(), productName, string.Format("{0:0.00}", quantity), string.Format("{0:0.00}", billAmount), string.Format("{0:0.00}", gstAmount) }));
                    }
                }
            }
            else
            {
                quantity = 0;
                billAmount = 0;
                gstAmount = 0;
                LoadDataIntoListview();
            }
        }

        private void LoadDataIntoListview()
        {
            int i = 0;
            foreach (var items in listOfSalesDetailfromSelectedDate)
            {
                foreach (var item in items)
                {
                    date = item.SoldDate.Date.ToString("dd-MM-yyyy");
                    productId = item.ProductId;
                    productName = item.ProductName;
                    quantity += item.Quantity;
                    billAmount += item.BillAmount;
                    gstAmount += item.GstAmount;
                }
                TransactionDetail_ListView.Items.Add(new ListViewItem(new string[] { (++i).ToString(), date, productId.ToString(), productName, string.Format("{0:0.00}", quantity), string.Format("{0:0.00}", billAmount), string.Format("{0:0.00}", gstAmount) }));
            }
        }

        private void Print_Details_btn_Click(object sender, EventArgs e)
        {
            if (TransactionDetail_ListView != null && TransactionDetail_ListView.Items.Count > 0)
            {
                var doc = new PrintDocument();
                doc.PrintPage += new PrintPageEventHandler(ProvideContentForThermal);
                doc.Print();
            }
        }

        private void ProvideContentForThermal(object sender, PrintPageEventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("PRODUCT SALES REPORT");
            sb.AppendLine("-".PadRight(80, '-'));
            sb.AppendLine("DATE: " + DateTime.Today.Date.ToString("dd/MM/yyyy"));
            sb.AppendLine("-".PadRight(80, '-'));
            sb.Append("DATE".PadLeft(4));
            sb.Append("PRD.ID".PadLeft(12));
            sb.AppendLine("AMOUNT".PadLeft(15));
            sb.AppendLine("-".PadRight(80, '-'));

            for (int i = 0; i < TransactionDetail_ListView.Items.Count; i++)
            {
                var date = DateTime.ParseExact(TransactionDetail_ListView.Items[i].SubItems[1].Text, "dd-MM-yyyy", null);
                var dateString = date.ToString("dd/MM/yy");
                sb.Append(dateString.PadLeft(4));
                sb.Append(TransactionDetail_ListView.Items[i].SubItems[2].Text.ToString().PadLeft(6));
                sb.AppendLine(TransactionDetail_ListView.Items[i].SubItems[5].Text.ToString().PadLeft(18));                
            }
            sb.AppendLine("-".PadRight(80, '-'));
            
            Graphics graphics = e.Graphics;
            int startX = 0;
            int startY = 0;
            int Offset = 10;

            string[] txt = sb.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < txt.Length; i++)
            {
                if (i == 0)
                {
                    Offset = Offset + 19;
                    graphics.DrawString(txt[i], new Font(System.Drawing.FontFamily.GenericMonospace, 12, System.Drawing.FontStyle.Bold),
                                new SolidBrush(Color.Black), startX, startY + Offset);
                }
                else
                {
                    Offset = Offset + 16;
                    graphics.DrawString(txt[i], new Font(System.Drawing.FontFamily.GenericMonospace, 10, System.Drawing.FontStyle.Bold),
                                new SolidBrush(Color.Black), startX, startY + Offset);
                }
            }
        }
    }
}
