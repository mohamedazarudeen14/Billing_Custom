using BusinessLayer;
using CommonClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Billing_Customized
{
    public partial class NewTransactionDetails : Form
    {
        private Admin admin;

        public NewTransactionDetails()
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
                Total_bill_Nos_Textbox.Text = BillAmount_Textbox.Text = Total_GST_Textbox.Text = string.Empty;
                TransactionDetail_ListView.Items.Clear();
                DateTime fromDate = FromDateDatePicker.Value;
                DateTime toDate = ToDateDatePicker.Value;
                if (fromDate.Date <= toDate.Date)
                {
                    List<SalesDetail> listOfSalesDetailfromSelectedDate = admin.GetSalesDetailsForSelectedDate(fromDate, toDate);

                    if (listOfSalesDetailfromSelectedDate != null && listOfSalesDetailfromSelectedDate.Count > 0)
                    {
                        int i = 0;
                        Total_bill_Nos_Textbox.Text = listOfSalesDetailfromSelectedDate.Count.ToString();
                        BillAmount_Textbox.Text = Total_GST_Textbox.Text = "0";
                        Print_Button.Enabled = true;

                        foreach (var item in listOfSalesDetailfromSelectedDate)
                        {
                            TransactionDetail_ListView.Items.Add(new ListViewItem(new string[] { (++i).ToString(), item.SalesDate.ToString("dd-MM-yyyy"), item.BillNos.ToString(), string.Format("{0:0.00}", item.BillAmount), string.Format("{0:0.00}", item.GstAmount) }));
                            BillAmount_Textbox.Text = string.Format("{0:0.00}", Convert.ToDecimal(BillAmount_Textbox.Text) + item.BillAmount);
                            Total_GST_Textbox.Text = string.Format("{0:0.00}", Convert.ToDecimal(Total_GST_Textbox.Text) + item.GstAmount);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No sales details found for selected date", "SELECTED DATE", MessageBoxButtons.OK);
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

        private void TransactionDetails_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetDetails_button_Click(null, null);
            }
            else if(e.KeyCode == Keys.F2)
            {
                Print_Button_Click(null, null);
            }
        }

        private void Print_Button_Click(object sender, EventArgs e)
        {
            if(TransactionDetail_ListView != null && TransactionDetail_ListView.Items.Count > 0)
            {
                var doc = new PrintDocument();
                doc.PrintPage += new PrintPageEventHandler(ProvideContentForThermal);
                doc.Print();
            }
        }

        public void ProvideContentForThermal(object sender, PrintPageEventArgs e)
        {
            int FIRST_COL_PAD = 5;

            var sb = new StringBuilder();
            sb.AppendLine("TRANSACTION REPORT");
            sb.AppendLine("From " + FromDateDatePicker.Value.ToString("dd/MM/yyyy") + " To " + ToDateDatePicker.Value.ToString("dd/MM/yyyy"));
            sb.AppendLine("-".PadRight(80, '-'));
            sb.Append(("Date").PadLeft(4));
            sb.Append(("BillNo ").PadLeft(11));
            sb.Append(("BillAmt").PadLeft(9));
            sb.AppendLine(("GSTAmt").PadLeft(9));
            sb.AppendLine("-".PadRight(80, '-'));

            for (int i = 0; i < TransactionDetail_ListView.Items.Count; i++)
            {
                var date = DateTime.ParseExact(TransactionDetail_ListView.Items[i].SubItems[1].Text, "dd-MM-yyyy", null);
                var dateString = date.ToString("dd/MM/yy");
                sb.Append(dateString.PadLeft(FIRST_COL_PAD));
                sb.Append(TransactionDetail_ListView.Items[i].SubItems[2].Text.PadLeft(5));
                sb.Append(TransactionDetail_ListView.Items[i].SubItems[3].Text.PadLeft(11));
                sb.AppendLine(TransactionDetail_ListView.Items[i].SubItems[4].Text.PadLeft(9));
            }

            sb.AppendLine("-".PadRight(80, '-'));
            sb.Append("Tot.Bills   :");
            sb.AppendLine(Total_bill_Nos_Textbox.Text);
            sb.Append("Tot.Bill Amt:");
            sb.AppendLine(BillAmount_Textbox.Text);
            sb.Append("Tot.GST Amt :");
            sb.AppendLine(Total_GST_Textbox.Text);
            sb.AppendLine("-".PadRight(80, '-'));
           
            Graphics graphics = e.Graphics;
            int startX = 0;
            int startY = 0;
            int Offset = 10;

            string[] txt = sb.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for(int i = 0; i < txt.Length; i++)
            {
                Offset = Offset + 16;
                if (i == txt.Length - 3 || i == txt.Length - 4 || i == txt.Length - 5 || i == 0)
                {                  
                    graphics.DrawString(txt[i], new Font(System.Drawing.FontFamily.GenericMonospace, 12, System.Drawing.FontStyle.Bold),
                                new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
                }
                else
                {
                    graphics.DrawString(txt[i], new Font(System.Drawing.FontFamily.GenericMonospace, 10, System.Drawing.FontStyle.Bold),
                                new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
                }
                
            }           
        }

    }
}
