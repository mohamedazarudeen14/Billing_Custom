using BusinessLayer;
using CommonClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Billing_Customized
{
    public partial class AddStockPage : Form
    {
        private Admin admin;
        private BackgroundWorker backgroundWorkerForStock;
        private List<ListViewItem> productDetails;
        private bool Resizing = false;
        private int selectedGst = 0; 

        public AddStockPage()
        {
            InitializeComponent();
            admin = new Admin();
        }

        private void AddProduct_button_Click(object sender, EventArgs e)
        {
            try
            {
                bool isProductDetailsSaved = false;

                if (!string.IsNullOrWhiteSpace(ProductId_textBox.Text) && !string.IsNullOrWhiteSpace(ProductName_textBox.Text) 
                    && !string.IsNullOrWhiteSpace(Quantity_Textbox.Text) && !string.IsNullOrWhiteSpace(RetailPrice_Textbox.Text)
                    && !string.IsNullOrWhiteSpace(WholesalePrice_Textbox.Text) && !string.IsNullOrWhiteSpace(CreditPrice_Textbox.Text)
                    && !string.IsNullOrWhiteSpace(BuyingPrice_Textbox.Text)
                    && GST_ComboBox.SelectedItem != null && !string.IsNullOrWhiteSpace(GST_ComboBox.SelectedItem.ToString()))
                {
                    bool isProductIdUsedAlready = admin.IsProductIdAvailable(Convert.ToDouble(ProductId_textBox.Text));

                    if (!isProductIdUsedAlready)
                    {
                        isProductDetailsSaved = admin.SaveProductDetails(Convert.ToInt64(ProductId_textBox.Text), 
                                                                         ProductName_textBox.Text, Convert.ToDecimal(Quantity_Textbox.Text),
                                                                         Convert.ToDecimal(BuyingPrice_Textbox.Text),
                                                                         Convert.ToDecimal(RetailPrice_Textbox.Text), 
                                                                         Convert.ToDecimal(WholesalePrice_Textbox.Text),
                                                                         Convert.ToDecimal(CreditPrice_Textbox.Text), Convert.ToInt32(GST_ComboBox.SelectedItem));
                    }
                    else
                    {
                        MessageBox.Show(Constants.PRODUCT_ID_AVAILABLE_MESSAGE);
                        ProductId_textBox.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(Constants.ENTER_ALL_TEXTFIELD_MESSAGE);
                    ProductId_textBox.Focus();
                    return;
                }

                if (isProductDetailsSaved)
                {
                    MessageBox.Show(Constants.PRODUCT_ADDED_MESSAGE);
                    ListViewItem listView = new ListViewItem((AllProduct_ListView.Items.Count > 0 ? (Convert.ToInt64(AllProduct_ListView.Items[AllProduct_ListView.Items.Count - 1].SubItems[0].Text) + 1).ToString() : "1"));
                    listView.SubItems.Add(ProductId_textBox.Text);
                    listView.SubItems.Add(ProductName_textBox.Text);
                    listView.SubItems.Add(string.Format("{0:0.00}", Quantity_Textbox.Text));
                    listView.SubItems.Add(string.Format("{0:0.00}", BuyingPrice_Textbox.Text));
                    listView.SubItems.Add(string.Format("{0:0.00}", RetailPrice_Textbox.Text));
                    listView.SubItems.Add(string.Format("{0:0.00}", WholesalePrice_Textbox.Text));
                    listView.SubItems.Add(string.Format("{0:0.00}", CreditPrice_Textbox.Text));
                    listView.SubItems.Add(GST_ComboBox.SelectedItem.ToString());
                    AllProduct_ListView.Items.Add(listView);
                    EnableDisableFormControls();
                }
                else
                {
                    MessageBox.Show("Error occured while adding Product to the database");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at AddStockPage", MessageBoxButtons.OK);
            }
        }

        private void AddStockPage_Load(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerForStock = new BackgroundWorker();
                backgroundWorkerForStock.DoWork += LoadAllProductDetails;
                backgroundWorkerForStock.RunWorkerCompleted += AddProductDetailsToListView;
                backgroundWorkerForStock.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at AddStockPage", MessageBoxButtons.OK);
            }
        }

        private void LoadAllProductDetails(object sender, DoWorkEventArgs e)
        {
            try
            {
                productDetails = new List<ListViewItem>();
                List<StockDetail> allStockDetails = admin.GetAllStockDetails();

                if (allStockDetails.Count > 0)
                {
                    for (int i = 0; i < allStockDetails.Count; i++)
                    {
                        ListViewItem listView = new ListViewItem((i + 1).ToString());
                        listView.SubItems.Add(allStockDetails[i].ProductId.ToString());
                        listView.SubItems.Add(allStockDetails[i].ProductName);
                        listView.SubItems.Add(string.Format("{0:0.00}",allStockDetails[i].Quantity));
                        listView.SubItems.Add(string.Format("{0:0.00}",allStockDetails[i].BuyingPrice));
                        listView.SubItems.Add(string.Format("{0:0.00}", allStockDetails[i].RetailPrice));
                        listView.SubItems.Add(string.Format("{0:0.00}", allStockDetails[i].WholesalePrice));
                        listView.SubItems.Add(string.Format("{0:0.00}", allStockDetails[i].CreditPrice));
                        listView.SubItems.Add(allStockDetails[i].GSTPercentage.ToString());
                        productDetails.Add(listView);
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at AddStockPage", MessageBoxButtons.OK);
            }
        }

        private void AddProductDetailsToListView(object sender, RunWorkerCompletedEventArgs e)
        {
            AllProduct_ListView.Items.AddRange((productDetails.ToArray()));
        }

        private void AllProduct_ListView_Click(object sender, EventArgs e)
        {
            try
            {
                AddProduct_button.Enabled = false;
                UpdateProduct_button.Enabled = true;
                DeleteProduct_button.Enabled = true;
                ProductId_textBox.ReadOnly = true;

                if (AllProduct_ListView.SelectedItems != null && AllProduct_ListView.SelectedItems.Count == 1)
                {
                    ProductId_textBox.Text = AllProduct_ListView.SelectedItems[0].SubItems[1].Text;
                    ProductName_textBox.Text = AllProduct_ListView.SelectedItems[0].SubItems[2].Text;
                    Quantity_Textbox.Text = AllProduct_ListView.SelectedItems[0].SubItems[3].Text;
                    BuyingPrice_Textbox.Text = AllProduct_ListView.SelectedItems[0].SubItems[4].Text;
                    RetailPrice_Textbox.Text = AllProduct_ListView.SelectedItems[0].SubItems[5].Text;
                    WholesalePrice_Textbox.Text = AllProduct_ListView.SelectedItems[0].SubItems[6].Text;
                    CreditPrice_Textbox.Text = AllProduct_ListView.SelectedItems[0].SubItems[7].Text;
                    GST_ComboBox.SelectedItem = AllProduct_ListView.SelectedItems[0].SubItems[8].Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at AddStockPage", MessageBoxButtons.OK);
            }
        }

        private void UpdateProduct_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(ProductId_textBox.Text) && !string.IsNullOrWhiteSpace(ProductName_textBox.Text)
                    && !string.IsNullOrWhiteSpace(Quantity_Textbox.Text) && !string.IsNullOrWhiteSpace(RetailPrice_Textbox.Text)
                    && !string.IsNullOrWhiteSpace(WholesalePrice_Textbox.Text) && !string.IsNullOrWhiteSpace(CreditPrice_Textbox.Text)
                    && !string.IsNullOrWhiteSpace(BuyingPrice_Textbox.Text)
                    && GST_ComboBox.SelectedItem != null && !string.IsNullOrWhiteSpace(GST_ComboBox.SelectedItem.ToString()))
                {
                    selectedGst = Convert.ToInt32(GST_ComboBox.SelectedItem);
                    BackgroundWorker backgroundWorker = new BackgroundWorker();
                    backgroundWorker.DoWork += UpdateProductDetails;
                    backgroundWorker.RunWorkerCompleted += UpdateProcductDetailsCompleted;
                    backgroundWorker.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show(Constants.ENTER_ALL_TEXTFIELD_MESSAGE);
                    ProductName_textBox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at AddStockPage", MessageBoxButtons.OK);
            }
        }

        private void AllProduct_ListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = AllProduct_ListView.Columns[e.ColumnIndex].Width;
        }

        private void ListView_SizeChanged(object sender, EventArgs e)
        {
            if (!Resizing)
            {
                Resizing = true;

                ListView listView = sender as ListView;
                if (listView != null)
                {
                    double totalColumnWidth = 0;

                    for (int i = 0; i < listView.Columns.Count; i++)
                        totalColumnWidth += Convert.ToDouble(listView.Columns[i].Tag);

                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        double colPercentage = (Convert.ToDouble(listView.Columns[i].Tag) / totalColumnWidth);
                        listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
                    }
                }
            }
            Resizing = false;
        }

        private void UpdateProductDetails(object sender, DoWorkEventArgs e)
        {
            e.Result = admin.UpdateProductDetails(long.Parse(ProductId_textBox.Text), ProductName_textBox.Text,
                                                  Convert.ToDecimal(Quantity_Textbox.Text), Convert.ToDecimal(BuyingPrice_Textbox.Text),
                                                  Convert.ToDecimal(RetailPrice_Textbox.Text), Convert.ToDecimal(WholesalePrice_Textbox.Text),
                                                  Convert.ToDecimal(CreditPrice_Textbox.Text), selectedGst);
        }

        private void UpdateProcductDetailsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool isCashierUpdatedConformation = (bool)e.Result;
            if (isCashierUpdatedConformation)
            {
                MessageBox.Show(Constants.PRODUCT_DETAILS_UPDATED);
                AllProduct_ListView.Items.Clear();
                LoadAllProductDetails(sender, null);
                AddProductDetailsToListView(sender, e);
                EnableDisableFormControls();
            }
            else
            {
                MessageBox.Show(Constants.PRODUCT_DETAILS_UPDATE_ERROR_MESSAGE);
                ProductName_textBox.Focus();
            }
        }

        private void DeleteProduct_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Constants.DELETE_PRODUCT_CONFORMATION_MESSAGE, Constants.DELETE_PRODUCT_MESSAGE_BOX_CAPTION, MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BackgroundWorker backgroundWorker = new BackgroundWorker();
                    backgroundWorker.DoWork += DeleteSelectedProductFromListView;
                    backgroundWorker.RunWorkerCompleted += LoadProductDetailsAfterDeletion;
                    backgroundWorker.RunWorkerAsync();
                    ProductId_textBox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at AddStockPage", MessageBoxButtons.OK);
            }
        }

        private void DeleteSelectedProductFromListView(object sender, DoWorkEventArgs e)
        {
            e.Result = admin.DeletedSelectedProduct(Int64.Parse(ProductId_textBox.Text));
            LoadAllProductDetails(sender, e);
        }

        private void LoadProductDetailsAfterDeletion(object sender, RunWorkerCompletedEventArgs e)
        {
            bool isProductDeleted = (bool)e.Result;
            if (isProductDeleted)
            {
                MessageBox.Show(Constants.PRODUCT_DELETED_CONFORMATION_MESSAGE);
                AllProduct_ListView.Items.Clear();
                AddProductDetailsToListView(sender, e);
                EnableDisableFormControls();
            }
            else
            {
                MessageBox.Show(Constants.PRODUCT_NOT_DELETED_MESSAGE);
            }
        }

        private void ClearAllFields_button_Click(object sender, EventArgs e)
        {
            EnableDisableFormControls();
        }

        private void EnableDisableFormControls()
        {
            ProductId_textBox.Focus();
            AddProduct_button.Enabled = true;
            UpdateProduct_button.Enabled = false;
            DeleteProduct_button.Enabled = false;
            ProductId_textBox.ReadOnly = false;
            ProductId_textBox.Text = string.Empty;
            ProductName_textBox.Text = string.Empty;
            Quantity_Textbox.Text = string.Empty;
            BuyingPrice_Textbox.Text = string.Empty;
            RetailPrice_Textbox.Text = string.Empty;
            WholesalePrice_Textbox.Text = string.Empty;
            CreditPrice_Textbox.Text = string.Empty;
            GST_ComboBox.SelectedItem = null;
            AvailableStock_Search_Textbox.Text = string.Empty;
        }

        private void Available_Stock_Search_Textbox_Textchanged(object sender, EventArgs e)
        {
            if(productDetails.Count > 0)
            {
                AllProduct_ListView.Items.Clear();
                if (string.IsNullOrWhiteSpace(AvailableStock_Search_Textbox.Text))
                {                   
                    AddProductDetailsToListView(null, null);
                }
                else
                {
                    int i = 0;
                    foreach (var item in productDetails)
                    {
                        if (item.SubItems[1].Text.StartsWith(AvailableStock_Search_Textbox.Text.ToLower()) 
                            || item.SubItems[2].Text.ToLower().StartsWith(AvailableStock_Search_Textbox.Text.ToLower()))
                        {
                            AllProduct_ListView.Items.Add(new ListViewItem(new string[] 
                            { (++i).ToString(),
                              item.SubItems[1].Text,
                              item.SubItems[2].Text,
                              item.SubItems[3].Text,
                              item.SubItems[4].Text,
                              item.SubItems[5].Text,
                              item.SubItems[6].Text,
                              item.SubItems[7].Text,
                              item.SubItems[8].Text,
                            }));
                        }
                    }
                }
            }
        }

        private void AddStock_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                AddProduct_button_Click(null, null);
            }
            if(e.KeyCode == Keys.Delete)
            {
                DeleteProduct_button_Click(null, null);
            }
        }

        private void Textbox_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back
                      && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Product_ID_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }
    }
}

