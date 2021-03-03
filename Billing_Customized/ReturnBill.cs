using BusinessLayer;
using CommonClasses;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Billing_Customized
{
    public partial class ReturnBill : Form
    {
        private Admin admin;
        private List<ProductSalesDetail> listOfProductSalesDetailsForBill;
        private SalesDetail salesDetailsForBill;

        public ReturnBill()
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
                Delete_btn.Enabled = false;
                Sales_Textbox.Text = Bill_Amount_Textbox.Text = string.Empty;
                TransactionDetail_ListView.Items.Clear();
                DateTime date = Date_DatePicker.Value;
                if (!string.IsNullOrWhiteSpace(Bill_Number_Textbox.Text))
                {
                    listOfProductSalesDetailsForBill = admin.GetProductSalesDetailsForBillNumber(date, Convert.ToInt64(Bill_Number_Textbox.Text));
                    salesDetailsForBill = admin.GetSalesDetailsForBillNumber(date, Convert.ToInt64(Bill_Number_Textbox.Text));

                    if (listOfProductSalesDetailsForBill != null && listOfProductSalesDetailsForBill.Count > 0 
                        && salesDetailsForBill != null)
                    {
                        Delete_btn.Enabled = true;
                        LoadDataIntoListview();
                    }
                    else
                    {
                        MessageBox.Show("No sales details found for selected date and Bill Number", "ITEM NOT FOUND", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Bill Number", "REQUIRED", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at ReturnBillPage", MessageBoxButtons.OK);
            }
        }

        private void ProductSalesDetails_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetDetails_button_Click(null, null);
            }
            else if(e.KeyCode == Keys.F3 || e.KeyCode == Keys.Delete)
            {
                Delete_btn_Click(null, null);
            }
        }

        private void BillNumber_Textbox_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void LoadDataIntoListview()
        {
            int i = 0;
            Sales_Textbox.Text = salesDetailsForBill.SalesDate.ToString("dd/MM/yyyy");
            Bill_Amount_Textbox.Text = string.Format("{0:0.00}", salesDetailsForBill.BillAmount);
            foreach (var item in listOfProductSalesDetailsForBill)
            {
                TransactionDetail_ListView.Items.Add(new ListViewItem(new string[] { (++i).ToString(), item.SoldDate.Date.ToString("dd-MM-yyyy"), item.ProductId.ToString(), item.ProductName, string.Format("{0:0.00}", item.Quantity), string.Format("{0:0.00}", item.BillAmount), string.Format("{0:0.00}", item.GstAmount) }));
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure? You Want To Delete The Sales Details", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    admin.DeleteSalesDetailsForReturnBill(listOfProductSalesDetailsForBill, salesDetailsForBill);
                    if (MessageBox.Show("Successfully Deleted Sales Details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        Sales_Textbox.Text = Bill_Amount_Textbox.Text = Bill_Number_Textbox.Text = string.Empty;
                        Delete_btn.Enabled = false;
                        TransactionDetail_ListView.Items.Clear();
                        Date_DatePicker.ResetText();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at ReturnBillPage", MessageBoxButtons.OK);
            }
        }
    }
}
