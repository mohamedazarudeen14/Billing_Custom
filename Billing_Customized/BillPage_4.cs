using BusinessLayer;
using CommonClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Billing_Customized
{
    public partial class BillPage_4 : Form
    {
        private Cashier cashier;
        private List<StockDetail> availableProducts;
        private BackgroundWorker backgroundWorker;
        private static BillPage_4 billPage;
        public bool isBillPrinted = false;
        private string billNumber;

        public static BillPage_4 Singelton
        {
            get
            {
                if (billPage == null)
                {
                    billPage = new BillPage_4();
                }
                return billPage;
            }
            set
            {
                if (billPage != null)
                {
                    billPage = value;
                }
            }
        }

        public BillPage_4()
        {
            InitializeComponent();
            cashier = new Cashier();
            backgroundWorker = new BackgroundWorker();
        }

        private void BillPage_Load(object sender, EventArgs e)
        {
            try
            {
                Bill_Number_textBox.Text = cashier.GetCurrentBillNumber();
                BillDate_textBox.Text = DateTime.Today.ToString("dd-MM-yyyy");
                availableProducts = cashier.GetAllProducts();
                Product_Search_Textbox.Focus();
                BilledProducts_GridView.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
                BilledProducts_GridView.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
                BilledProducts_GridView.Columns[2].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
                BilledProducts_GridView.Columns[3].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
                BilledProducts_GridView.Columns[4].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
                BilledProducts_GridView.Columns[5].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
                BilledProducts_GridView.Columns[6].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
                BilledProducts_GridView.Columns[7].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at Bill Page", MessageBoxButtons.OK);
            }
        }

        private void Product_Search_Textbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Price_textBox.Text = Quantity_textBox.Text = MetersOrPiecesTextBox.Text = string.Empty;
                Product_Search_ListBox.Items.Clear();

                if (Product_Search_Textbox.Text.Length == 0)
                {
                    HideResults();
                    return;
                }

                if (availableProducts != null)
                {
                    foreach (StockDetail searchedProduct in availableProducts)
                    {
                        if (searchedProduct.ProductName.ToLower().StartsWith(Product_Search_Textbox.Text.ToLower()) ||
                            searchedProduct.ProductId.ToString().Equals(Product_Search_Textbox.Text))
                        {
                            Product_Search_ListBox.Items.Add(searchedProduct.ProductName);
                            Product_Search_ListBox.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at Bill Page", MessageBoxButtons.OK);
            }
        }

        void HideResults()
        {
            Product_Search_ListBox.Visible = false;
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            decimal purchasedQuantity = 0;
            decimal purchasedMeters = 0;
            decimal purchasedPrice = 0;
            decimal gstDividend = 1.05M;
            decimal selectedProductBillAmount;
            decimal selectedProductGSTAmount;
            decimal metersEntered;
            try
            {
                Product_Search_Textbox.Focus();

                if (!string.IsNullOrWhiteSpace(MetersOrPiecesTextBox.Text) && decimal.TryParse(MetersOrPiecesTextBox.Text, out decimal metersValidaton))
                {
                    purchasedMeters = Convert.ToDecimal(MetersOrPiecesTextBox.Text);
                }
                if (!string.IsNullOrWhiteSpace(Quantity_textBox.Text) && decimal.TryParse(Quantity_textBox.Text, out decimal quantityValidaton))
                {
                    purchasedQuantity = Convert.ToDecimal(Quantity_textBox.Text);
                }
                if (!string.IsNullOrWhiteSpace(Price_textBox.Text) && decimal.TryParse(Price_textBox.Text, out decimal priceValidaton))
                {
                    purchasedPrice = Convert.ToDecimal(Price_textBox.Text);
                }

                metersEntered = purchasedMeters == 0 ? 1 : purchasedMeters;


                if (Product_Search_Textbox.Text == string.Empty)
                {
                    Error_Message_Label.Text = Constants.SELECT_ANY_PRODUCT_ERROR_MESSAGE;
                    HideWarningMessage();
                    Product_Search_Textbox.Focus();
                }
                else if (purchasedPrice == 0)
                {
                    Error_Message_Label.Text = Constants.ENTER_VALID_PRICE_ERROR_MESSAGE;
                    HideWarningMessage();
                    Price_textBox.Focus();
                }
                else if (purchasedQuantity == 0)
                {
                    Error_Message_Label.Text = Constants.ENTER_VALID_QUANTITY_ERROR_MESSAGE;
                    HideWarningMessage();
                    Quantity_textBox.Focus();
                }
                else
                {
                    selectedProductBillAmount = purchasedQuantity * metersEntered * purchasedPrice;
                    selectedProductGSTAmount = selectedProductBillAmount - selectedProductBillAmount / gstDividend;

                    BilledProducts_GridView.Rows.Add((BilledProducts_GridView.Rows.Count + 1).ToString(), Product_Search_Textbox.Text, ProductName_Display_Label.Text, purchasedMeters == 0 ? string.Empty : purchasedMeters.ToString(), purchasedQuantity, purchasedPrice, string.Format("{0:0.00}", selectedProductBillAmount), string.Format("{0:0.00}", selectedProductGSTAmount));

                    if (BillAmount_Textbox.Text == string.Empty)
                    {
                        BillAmount_Textbox.Text = string.Format("{0:0.00}", Math.Round(selectedProductBillAmount, MidpointRounding.ToEven));
                        GSTAmount_TextBox.Text = string.Format("{0:0.00}", selectedProductGSTAmount);
                        Total_Bill_Qty_Textbox.Text = string.Format("{0:0}", purchasedQuantity);
                    }
                    else
                    {
                        BillAmount_Textbox.Text = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(BillAmount_Textbox.Text) + selectedProductBillAmount, MidpointRounding.ToEven));
                        GSTAmount_TextBox.Text = string.Format("{0:0.00}", Convert.ToDecimal(GSTAmount_TextBox.Text) + selectedProductGSTAmount);
                        Total_Bill_Qty_Textbox.Text = string.Format("{0:0}", Convert.ToDecimal(Total_Bill_Qty_Textbox.Text) + purchasedQuantity);
                    }

                    Price_textBox.ReadOnly = Quantity_textBox.ReadOnly = MetersOrPiecesTextBox.ReadOnly = true;
                    AssignEmptyToAvailableTextboxes();
                }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at Bill Page", MessageBoxButtons.OK);
            }

        }

        private void HideWarningMessage()
        {
            var t = new Timer();
            t.Interval = 5000; // it will Tick in 5 seconds
            t.Tick += (s, e) =>
            {
                Error_Message_Label.Text = string.Empty;
                t.Stop();
            };
            t.Start();
        }

        private void Print_Bill_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                Product_Search_Textbox.Focus();
                if (BilledProducts_GridView.Rows.Count > 0)
                {
                    isBillPrinted = true;
                    Print_Bill_Btn.Enabled = Add_Product_Btn.Enabled = Remove_Btn.Enabled = false;
                    Product_Search_Textbox.ReadOnly = true;
                    Error_Message_Label.Text = "UPDATING CURRENT BILL";
                    billNumber = cashier.GetCurrentBillNumber();
                    Print();
                }
                else
                {
                    Error_Message_Label.Text = "Add Products For Bill";
                    HideWarningMessage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at Bill Page", MessageBoxButtons.OK);
            }
        }

        private void BillDetailsUpdation()
        {
            if (isBillPrinted)
            {
                Product_Search_Textbox.Focus();
                cashier.UpdateBillDetails(billNumber, Convert.ToDecimal(GSTAmount_TextBox.Text), Convert.ToDecimal(BillAmount_Textbox.Text), BilledProducts_GridView);
                Print_Bill_Btn.Enabled = Add_Product_Btn.Enabled = Remove_Btn.Enabled = true;
                Product_Search_Textbox.ReadOnly = isBillPrinted = false;
                GSTAmount_TextBox.Text = BillAmount_Textbox.Text = Total_Bill_Qty_Textbox.Text = string.Empty;
                BilledProducts_GridView.Rows.Clear();
                AssignEmptyToAvailableTextboxes();
                BillDate_textBox.Text = DateTime.Today.ToString("dd-MM-yyyy");
                backgroundWorker.DoWork += GetCurrentBillNumber;
                backgroundWorker.RunWorkerCompleted += WriteCurrentBillNumberTextBox;
                StartToGetCurrentBillNumber();
                HideWarningMessage();
            }
            else
            {
                MessageBox.Show("Please Print the Bill First");
            }
        }

        private void GetCurrentBillNumber(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = cashier.GetCurrentBillNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at Bill Page", MessageBoxButtons.OK);
            }
        }

        private void WriteCurrentBillNumberTextBox(object sender, RunWorkerCompletedEventArgs e)
        {
            string currentBillNumber = (string)e.Result;
            Bill_Number_textBox.Text = currentBillNumber;
        }

        private void StartToGetCurrentBillNumber()
        {
            try
            {
                var t = new Timer();
                t.Interval = 5000; // it will Tick in 5 seconds
                t.Tick += (s, e) =>
                {
                    backgroundWorker.RunWorkerAsync();
                    t.Stop();
                };
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at Bill Page", MessageBoxButtons.OK);
            }
        }

        private void Remove_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                Add_Product_Btn.Enabled = true;
                if (BilledProducts_GridView.SelectedRows.Count > 0)
                {
                    double selectedProductId = Convert.ToDouble(BilledProducts_GridView.SelectedRows[0].Cells[1].Value);
                    BilledProducts_GridView.Rows.Remove(BilledProducts_GridView.SelectedRows[0]);
                    BilledProducts_GridView_RowsRemoved();
                    AssignEmptyToAvailableTextboxes();
                }
                else
                {
                    Error_Message_Label.Text = "Select Any Billed Product To Remove";
                    HideWarningMessage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at Bill Page", MessageBoxButtons.OK);
            }
        }

        private void BilledProducts_GridView_RowsRemoved()
        {
            try
            {
                decimal billAmount = 0;
                decimal gstAmount = 0;
                decimal quantity = 0;
                int serialIdUpdate = 1;

                if (BilledProducts_GridView.Rows.Count > 0)
                {
                    for (int i = 0; i < BilledProducts_GridView.Rows.Count; i++)
                    {
                        BilledProducts_GridView.Rows[i].Cells[0].Value = serialIdUpdate;
                        billAmount += Convert.ToDecimal(BilledProducts_GridView.Rows[i].Cells[6].Value);
                        gstAmount += Convert.ToDecimal(BilledProducts_GridView.Rows[i].Cells[7].Value);
                        quantity += Convert.ToDecimal(BilledProducts_GridView.Rows[i].Cells[4].Value);
                        serialIdUpdate++;
                    }

                    BillAmount_Textbox.Text = string.Format("{0:0.00}", Math.Round(billAmount, MidpointRounding.ToEven));
                    GSTAmount_TextBox.Text = string.Format("{0:0.00}", gstAmount);
                    Total_Bill_Qty_Textbox.Text = string.Format("{0:0}", quantity);
                }
                else
                {
                    GSTAmount_TextBox.Text = string.Empty;
                    BillAmount_Textbox.Text = string.Empty;
                    Total_Bill_Qty_Textbox.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at Bill Page", MessageBoxButtons.OK);
            }
        }

        private void AssignEmptyToAvailableTextboxes()
        {
            Product_Search_Textbox.Text = string.Empty;
            Price_textBox.Text = string.Empty;
            Quantity_textBox.Text = string.Empty;
            MetersOrPiecesTextBox.Text = string.Empty;
            ProductName_Display_Label.Text = string.Empty;
            Error_Message_Label.Text = string.Empty;
        }

        private void BillPage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                Print_Bill_Btn_Click(null, null);
                Product_Search_Textbox.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (!Product_Search_ListBox.Visible && !isBillPrinted)
                {
                    Add_button_Click(null, null);
                }
                else if (isBillPrinted)
                {
                    BillDetailsUpdation();
                }
                else if (Product_Search_ListBox.Visible && Product_Search_ListBox.Items.Count == 1)
                {
                    ProductIdEntered();
                }
                else if (Product_Search_ListBox.Visible && Product_Search_ListBox.SelectedIndex != -1)
                {
                    Product_Search_ListBox_MouseClick(null, null);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (Product_Search_ListBox.Visible && Product_Search_ListBox.Items.Count > 0
                    && Product_Search_ListBox.SelectedIndex != 0)
                {
                    Product_Search_ListBox.Focus();
                    Product_Search_ListBox.Select();
                }
                if (Product_Search_ListBox.Visible && Product_Search_ListBox.Items.Count > 0
                    && Product_Search_ListBox.SelectedIndex == 0)
                {
                    Product_Search_Textbox.Focus();
                }
            }
            else if (e.KeyCode == Keys.Down && Product_Search_ListBox.Items.Count > 0)
            {
                if (Product_Search_ListBox.Visible)
                {
                    Product_Search_ListBox.Focus();
                    Product_Search_ListBox.Select();
                }
            }
            else if (e.KeyCode == Keys.F3)
            {
                Cancel_Button_Click(null, null);
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (Product_Search_ListBox.Visible && Product_Search_ListBox.Items.Count == 1)
                {
                    ProductIdEntered();
                }
            }
        }

        private void Product_Search_ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (Product_Search_ListBox.SelectedIndex != -1)
                {
                    var selectedFromListbox = Product_Search_ListBox.Items[Product_Search_ListBox.SelectedIndex].ToString();
                    availableProducts.Where(obj => obj.ProductId.ToString().Equals(selectedFromListbox) || obj.ProductName.Equals(selectedFromListbox)).ToList().ForEach(obj => { Product_Search_Textbox.Text = obj.ProductId.ToString(); ProductName_Display_Label.Text = obj.ProductName; });
                    HideResults();
                    Price_textBox.Focus();
                    Price_textBox.ReadOnly = Quantity_textBox.ReadOnly = MetersOrPiecesTextBox.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at Bill Page", MessageBoxButtons.OK);
            }
        }

        private void ProductIdEntered()
        {
            try
            {
                StockDetail selectedProduct = availableProducts.FirstOrDefault(obj => obj.ProductId.ToString().Equals(Product_Search_Textbox.Text) || obj.ProductName.Equals(Product_Search_ListBox.Items[0]));
                if (selectedProduct == null)
                    return;
                Product_Search_Textbox.Text = selectedProduct.ProductId.ToString();
                ProductName_Display_Label.Text = selectedProduct.ProductName;
                HideResults();
                Price_textBox.Focus();
                Price_textBox.ReadOnly = Quantity_textBox.ReadOnly = MetersOrPiecesTextBox.ReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at Bill Page", MessageBoxButtons.OK);
            }
        }

        public void Print()
        {
            var doc = new PrintDocument();
            if (ConfigurationManager.AppSettings["Printer"] == "1")
            {
                doc.PrintPage += new PrintPageEventHandler(ProvideContentForDotMatrix);
            }
            else
            {
                doc.PrintPage += new PrintPageEventHandler(ProvideContentForThermal);
            }
            doc.Print();
        }

        public void ProvideContentForDotMatrix(object sender, PrintPageEventArgs e)
        {
            int FIRST_COL_PAD = 12;
            int SECOND_COL_PAD = 13;
            int THIRD_COL_PAD = 14;
            int FOURTH_COL_PAD = 15;

            var sb = new StringBuilder();
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings["AddressLine1"] != string.Empty)
            {
                sb.AppendLine(appSettings["AddressLine1"].PadLeft(SECOND_COL_PAD));
            }
            if (appSettings["AddressLine2"] != string.Empty)
            {
                sb.AppendLine(appSettings["AddressLine2"].PadLeft(SECOND_COL_PAD));
            }
            if (appSettings["AddressLine3"] != string.Empty)
            {
                sb.AppendLine(appSettings["AddressLine3"].PadLeft(SECOND_COL_PAD));
            }
            if (appSettings["AddressLine4"] != string.Empty)
            {
                sb.AppendLine(appSettings["AddressLine4"].PadLeft(SECOND_COL_PAD));
            }
            if (appSettings["PhoneNumber"] != string.Empty)
            {
                sb.AppendLine("Mob:- " + appSettings["PhoneNumber"].PadLeft(SECOND_COL_PAD));
            }
            if (appSettings["GSTNo"] != string.Empty)
            {
                sb.AppendLine("GST# " + appSettings["GSTNo"].PadLeft(SECOND_COL_PAD));
            }
            sb.AppendLine("-".PadRight(80, '-'));
            sb.AppendLine("CASH BILL".PadLeft(7));
            sb.AppendLine("-".PadRight(80, '-'));
            sb.Append(("DATE").PadRight(8));
            sb.AppendLine(": " + DateTime.Now.Date.ToString("dd/MM/yyyy"));
            sb.Append("Bill No".PadRight(8));
            sb.Append(": ");
            sb.AppendLine(billNumber);
            sb.AppendLine("-".PadRight(80, '-'));
            sb.Append(("ITEM").PadLeft(10));
            sb.Append(("PCX/MTS").PadLeft(FIRST_COL_PAD));
            sb.Append(("QTY").PadLeft(SECOND_COL_PAD));
            sb.Append(("PRICE").PadLeft(THIRD_COL_PAD));
            sb.AppendLine(("TOTAL").PadLeft(FOURTH_COL_PAD));
            sb.AppendLine("-".PadRight(80, '-'));

            for (int i = 0; i < BilledProducts_GridView.Rows.Count; i++)
            {
                string pd = "";
                if (BilledProducts_GridView.Rows[i].Cells[2].Value.ToString().Length > 10)
                {
                    pd = BilledProducts_GridView.Rows[i].Cells[2].Value.ToString().Substring(0, 10);
                }
                else
                {
                    pd = BilledProducts_GridView.Rows[i].Cells[2].Value.ToString();
                }
                sb.Append(pd.PadLeft(10));

                if (BilledProducts_GridView.Rows[i].Cells[2].Value.ToString().Length < 7)
                {
                    FIRST_COL_PAD = 14;
                    SECOND_COL_PAD = 21;
                    THIRD_COL_PAD = 19;
                    FOURTH_COL_PAD = 21;
                }
                else if (BilledProducts_GridView.Rows[i].Cells[2].Value.ToString().Length == 7)
                {
                    FIRST_COL_PAD = 14;
                    SECOND_COL_PAD = 20;
                    THIRD_COL_PAD = 18;
                    FOURTH_COL_PAD = 20;
                }
                else
                {
                    FIRST_COL_PAD = 13;
                    SECOND_COL_PAD = 20;
                    THIRD_COL_PAD = 18;
                    FOURTH_COL_PAD = 20;
                }
                sb.Append(BilledProducts_GridView.Rows[i].Cells[3].Value.ToString() == string.Empty ? "1".PadLeft(FIRST_COL_PAD) : BilledProducts_GridView.Rows[i].Cells[3].Value.ToString().PadLeft(FIRST_COL_PAD));
                sb.Append(BilledProducts_GridView.Rows[i].Cells[4].Value.ToString().PadLeft(SECOND_COL_PAD));
                sb.Append(BilledProducts_GridView.Rows[i].Cells[5].Value.ToString().PadLeft(THIRD_COL_PAD));
                sb.AppendLine(string.Format("{0:0.00}", BilledProducts_GridView.Rows[i].Cells[6].Value).ToString().PadLeft(FOURTH_COL_PAD));
            }
            sb.AppendLine("-".PadRight(80, '-'));
            sb.Append("Sub Total:".PadLeft(77));
            sb.AppendLine(string.Format("{0:0.00}", Convert.ToDecimal(BillAmount_Textbox.Text) - Convert.ToDecimal(GSTAmount_TextBox.Text)));
            sb.Append("5% GST: ".PadLeft(77));
            sb.AppendLine(GSTAmount_TextBox.Text);
            sb.AppendLine("-".PadRight(80, '-'));
            sb.Append("Total Qty: " + Total_Bill_Qty_Textbox.Text);
            sb.Append("Total ".PadLeft(77));
            sb.AppendLine(string.Format("{0:0.00}", BillAmount_Textbox.Text));
            sb.AppendLine("-".PadRight(80, '-'));
            sb.AppendLine("NO EXCHANGE; NO RETURN");
            sb.AppendLine("-".PadRight(80, '-'));


            var printText = new PrintText(sb.ToString(), new Font(System.Drawing.FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold));
            Graphics graphics = e.Graphics;
            int startX = 0;
            int startY = 0;
            int Offset = 20;

            graphics.DrawString(appSettings["StoreName"], new Font(System.Drawing.FontFamily.GenericSerif, 12, System.Drawing.FontStyle.Bold),
                                new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString(printText.Text, new Font(System.Drawing.FontFamily.GenericSerif, 10, System.Drawing.FontStyle.Bold),
                                new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);

        }

        public void ProvideContentForThermal(object sender, PrintPageEventArgs e)
        {
            int FIRST_COL_PAD = 5;
            int SECOND_COL_PAD = 7;
            int THIRD_COL_PAD = 8;
            int FOURTH_COL_PAD = 9;

            var sb = new StringBuilder();
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings["AddressLine1"] != string.Empty)
            {
                sb.AppendLine(appSettings["AddressLine1"].PadLeft(SECOND_COL_PAD));
            }
            if (appSettings["AddressLine2"] != string.Empty)
            {
                sb.AppendLine(appSettings["AddressLine2"].PadLeft(SECOND_COL_PAD));
            }
            if (appSettings["AddressLine3"] != string.Empty)
            {
                sb.AppendLine(appSettings["AddressLine3"].PadLeft(SECOND_COL_PAD));
            }
            if (appSettings["AddressLine4"] != string.Empty)
            {
                sb.AppendLine(appSettings["AddressLine4"].PadLeft(SECOND_COL_PAD));
            }
            if (appSettings["PhoneNumber"] != string.Empty)
            {
                sb.AppendLine("Mob:- " + appSettings["PhoneNumber"].PadLeft(SECOND_COL_PAD));
            }
            if (appSettings["GSTNo"] != string.Empty)
            {
                sb.AppendLine("GST# " + appSettings["GSTNo"].PadLeft(SECOND_COL_PAD));
            }
            sb.AppendLine("-".PadRight(80, '-'));
            sb.AppendLine("CASH BILL".PadLeft(7));
            sb.AppendLine("-".PadRight(80, '-'));
            sb.Append(("DATE").PadRight(8));
            sb.AppendLine(": " + DateTime.Now.Date.ToString("dd/MM/yyyy"));
            sb.Append("Bill No".PadRight(8));
            sb.Append(": ");
            sb.AppendLine(billNumber);
            sb.AppendLine("-".PadRight(80, '-'));
            sb.Append(("ITEM ").PadLeft(4));
            sb.Append(("PCX/MTS").PadLeft(4));
            sb.Append(("QTY").PadLeft(5));
            sb.Append(("PRICE").PadLeft(7));
            sb.AppendLine(("TOTAL").PadLeft(8));
            sb.AppendLine("-".PadRight(80, '-'));

            for (int i = 0; i < BilledProducts_GridView.Rows.Count; i++)
            {
                string pd = "";
                if (BilledProducts_GridView.Rows[i].Cells[2].Value.ToString().Length > 4)
                {
                    pd = BilledProducts_GridView.Rows[i].Cells[2].Value.ToString().Substring(0, 4);
                }
                else
                {
                    pd = BilledProducts_GridView.Rows[i].Cells[2].Value.ToString();
                }
                sb.Append(pd.PadLeft(4));

                sb.Append(BilledProducts_GridView.Rows[i].Cells[3].Value.ToString() == string.Empty ? "1".PadLeft(FIRST_COL_PAD) : BilledProducts_GridView.Rows[i].Cells[3].Value.ToString().PadLeft(FIRST_COL_PAD));
                sb.Append(BilledProducts_GridView.Rows[i].Cells[4].Value.ToString().PadLeft(SECOND_COL_PAD));
                sb.Append(BilledProducts_GridView.Rows[i].Cells[5].Value.ToString().PadLeft(7));
                sb.AppendLine(string.Format("{0:0.00}", BilledProducts_GridView.Rows[i].Cells[6].Value).ToString().PadLeft(FOURTH_COL_PAD));
            }
            sb.AppendLine("-".PadRight(80, '-'));
            sb.Append("Sub Total: ");
            sb.AppendLine(string.Format("{0:0.00}", Convert.ToDecimal(BillAmount_Textbox.Text) - Convert.ToDecimal(GSTAmount_TextBox.Text)));
            sb.Append("   5% GST:  ");
            sb.AppendLine(GSTAmount_TextBox.Text);
            sb.AppendLine("-".PadRight(80, '-'));
            sb.Append("Qty:" + Total_Bill_Qty_Textbox.Text);
            sb.Append("Total:".PadLeft(6 + 4 + Quantity_textBox.Text.Length));
            sb.AppendLine(string.Format("{0:0.00}", BillAmount_Textbox.Text));
            sb.AppendLine("-".PadRight(80, '-'));
            sb.AppendLine("NO EXCHANGE; NO RETURN");
            sb.AppendLine("-".PadRight(80, '-'));

            Graphics graphics = e.Graphics;
            int startX = 0;
            int startY = 0;
            int Offset = 10;
            graphics.DrawString(appSettings["StoreName"], new Font(System.Drawing.FontFamily.GenericMonospace, 12, System.Drawing.FontStyle.Bold),
                                new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);

            string[] txt = sb.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < txt.Length; i++)
            {
                if (i == 0)
                {
                    Offset = Offset + 19;
                }
                else
                {
                    Offset = Offset + 16;
                }
                if (i == txt.Length - 5)
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

        private void Price_Textbox_Keypress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Delete))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void Quantity_Textbox_Keypress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Delete))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void Meters_Pieces_Textbox_Keypress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Delete))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Product_Search_Textbox.Focus();
            Print_Bill_Btn.Enabled = Add_Product_Btn.Enabled = Remove_Btn.Enabled = true;
            Product_Search_Textbox.ReadOnly = isBillPrinted = false;
            GSTAmount_TextBox.Text = BillAmount_Textbox.Text = Total_Bill_Qty_Textbox.Text = string.Empty;
            BilledProducts_GridView.Rows.Clear();
            AssignEmptyToAvailableTextboxes();
            BillDate_textBox.Text = DateTime.Today.ToString("dd-MM-yyyy");
            backgroundWorker.DoWork += GetCurrentBillNumber;
            backgroundWorker.RunWorkerCompleted += WriteCurrentBillNumberTextBox;
            StartToGetCurrentBillNumber();
            HideWarningMessage();
        }
    }
}