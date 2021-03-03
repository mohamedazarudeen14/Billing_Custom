using CommonClasses;
using System;
using System.Windows.Forms;

namespace Billing_Customized
{
    public partial class CashierHomePage : Form
    {
        private string loggedInCashierId;
        public string adminLogin;
        public bool isAdminLoggedInBefore;
        private Timer t;
        private BillPage_1 billPage1;
        private BillPage_2 billPage2;
        private BillPage_3 billPage3;
        private BillPage_4 billPage4;
        private BillPage_5 billPage5;

        public CashierHomePage(string loggedInCashierId)
        {
            this.loggedInCashierId = loggedInCashierId;
            InitializeComponent();
        }

        public CashierHomePage()
        {
            InitializeComponent();
        }

        private void Bill_1_MenuStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if(AnyTabClickInCashierHomePage())
                {
                    return;
                }
                if (billPage1 != null && billPage1.BilledProducts_GridView.Rows.Count > 0)
                {
                    BillPageOpen(1);
                }
                else
                {
                    BillPage_1.Singelton = null;
                    BillPageOpen(1);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at CashierHomepage", MessageBoxButtons.OK);
            }
        }
        private void Bill_2_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (AnyTabClickInCashierHomePage())
                {
                    return;
                }
                if (billPage2 != null && billPage2.BilledProducts_GridView.Rows.Count > 0)
                {
                    BillPageOpen(2);
                }
                else
                {
                    BillPage_2.Singelton = null;
                    BillPageOpen(2);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at CashierHomepage", MessageBoxButtons.OK);
            }
        }

        private void Bill_3_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (AnyTabClickInCashierHomePage())
                {
                    return;
                }
                if (billPage3 != null && billPage3.BilledProducts_GridView.Rows.Count > 0)
                {
                    BillPageOpen(3);
                }
                else
                {
                    BillPage_3.Singelton = null;
                    BillPageOpen(3);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at CashierHomepage", MessageBoxButtons.OK);
            }
        }

        private void Bill_4_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (AnyTabClickInCashierHomePage())
                {
                    return;
                }
                if (billPage4 != null && billPage4.BilledProducts_GridView.Rows.Count > 0)
                {
                    BillPageOpen(4);
                }
                else
                {
                    BillPage_4.Singelton = null;
                    BillPageOpen(4);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at CashierHomepage", MessageBoxButtons.OK);
            }
        }

        private void Bill_5_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (AnyTabClickInCashierHomePage())
                {
                    return;
                }
                if (billPage5 != null && billPage5.BilledProducts_GridView.Rows.Count > 0)
                {
                    BillPageOpen(5);
                }
                else
                {
                    BillPage_5.Singelton = null;
                    BillPageOpen(5);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at CashierHomepage", MessageBoxButtons.OK);
            }
        }

        private void BillPageOpen(int billPage)
        {
            CloseOpenedChildForm();
            EnableDisbaledMenuStripItem();            
            if (t != null)
            {
                t.Stop();
                isAdminLoggedInBefore = false;
            }
            if (billPage.Equals(1))
            {                
                billPage1 = BillPage_1.Singelton;
                billPage1.MdiParent = this;
                billPage1.StartPosition = FormStartPosition.CenterScreen;
                billPage1.Dock = DockStyle.Fill;
                billPage1.Show();
                Bill1MenuStripMenuItem.Enabled = false;
            }
            else if(billPage.Equals(2))
            {
                billPage2 = BillPage_2.Singelton;
                billPage2.MdiParent = this;
                billPage2.StartPosition = FormStartPosition.CenterScreen;
                billPage2.Show();
                Bill2ToolStripMenuItem.Enabled = false;
            }
            else if (billPage.Equals(3))
            {
                billPage3 = BillPage_3.Singelton;
                billPage3.MdiParent = this;
                billPage3.StartPosition = FormStartPosition.CenterScreen;
                billPage3.Show();
                Bill3ToolStripMenuItem.Enabled = false;
            }
            else if (billPage.Equals(4))
            {
                billPage4 = BillPage_4.Singelton;
                billPage4.MdiParent = this;
                billPage4.StartPosition = FormStartPosition.CenterScreen;
                billPage4.Show();
                Bill4ToolStripMenuItem.Enabled = false;
            }
            else
            {
                billPage5 = BillPage_5.Singelton;
                billPage5.MdiParent = this;
                billPage5.StartPosition = FormStartPosition.CenterScreen;
                billPage5.Show();
                Bill5ToolStripMenuItem.Enabled = false;
            }
        }

        private void LogOut_Cashier_MenuStrip_Click(object sender, EventArgs e)
        {
            if(billPage1 != null && billPage1.BilledProducts_GridView.Rows.Count > 0 
               || billPage2 != null && billPage2.BilledProducts_GridView.Rows.Count > 0
               || billPage3 != null && billPage3.BilledProducts_GridView.Rows.Count > 0
               || billPage4 != null && billPage4.BilledProducts_GridView.Rows.Count > 0
               || billPage5 != null && billPage5.BilledProducts_GridView.Rows.Count > 0)
            {
                DialogResult messge = MessageBox.Show("Billed Items Not Updated in the Database. " +
                                "Please check all the Bill Tabs " +
                                 "Are you sure you want to Exit?", "Information", MessageBoxButtons.OKCancel);
                if(messge == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
                
        }

        private void CloseOpenedChildForm()
        {
            if (ActiveMdiChild != null)
            {
                if(ActiveMdiChild.Name.StartsWith("BillPage"))
                {
                    ActiveMdiChild.Hide();
                    return;
                }
                ActiveMdiChild.Close();
            }
        }

        private void EnableDisbaledMenuStripItem()
        {
            for (int i = 0; i < Cashier_HomePage_MenuStrip.Items.Count; i++)
            {
                if (!Cashier_HomePage_MenuStrip.Items[i].Enabled)
                {
                    Cashier_HomePage_MenuStrip.Items[i].Enabled = true;
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | Constants.CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void SalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (AnyTabClickInCashierHomePage())
                {
                    return;
                }
                CloseOpenedChildForm();
                EnableDisbaledMenuStripItem();
                if (!isAdminLoggedInBefore)
                {
                    AdminLogin admin = new AdminLogin
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.CenterScreen,
                    };
                    admin.FormClosed += (s, args) =>
                    {
                        if (admin.isLoggedIn)
                        {
                            isAdminLoggedInBefore = admin.isLoggedIn;
                            SessionTimeOut();
                            NewTransactionDetails newTransactionDetails = new NewTransactionDetails
                            {
                                MdiParent = this,
                                StartPosition = FormStartPosition.CenterScreen,
                                Dock = DockStyle.Fill
                            };
                            newTransactionDetails.Show();
                        }
                        else
                        {
                            EnableDisbaledMenuStripItem();
                        }
                    };
                    admin.Show();
                }
                else
                {
                    NewTransactionDetails newTransactionDetails = new NewTransactionDetails
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.CenterScreen,
                        Dock = DockStyle.Fill
                    };
                    newTransactionDetails.Show();
                }
                SalesReportToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at CashierHomepage", MessageBoxButtons.OK);
            }
        }

        private void AddStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (AnyTabClickInCashierHomePage())
                {
                    return;
                }
                CloseOpenedChildForm();
                EnableDisbaledMenuStripItem();
                if (!isAdminLoggedInBefore)
                {
                    AdminLogin admin = new AdminLogin
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    admin.FormClosed += (s, args) =>
                    {
                        if (admin.isLoggedIn)
                        {
                            isAdminLoggedInBefore = admin.isLoggedIn;
                            SessionTimeOut();
                            AddStockPage addStockPage = new AddStockPage()
                            {
                                MdiParent = this,
                                StartPosition = FormStartPosition.CenterScreen,
                                Dock = DockStyle.Fill
                            };
                            addStockPage.Show();
                        }
                        else
                        {
                            EnableDisbaledMenuStripItem();
                        }
                    };
                    admin.Show();
                }
                else
                {
                    AddStockPage addStockPage = new AddStockPage()
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.CenterScreen,
                        Dock = DockStyle.Fill
                    };
                    addStockPage.Show();
                }
                AddStockToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at CashierHomepage", MessageBoxButtons.OK);
            }
        }

        private void ProductSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (AnyTabClickInCashierHomePage())
                {
                    return;
                }
                CloseOpenedChildForm();
                EnableDisbaledMenuStripItem();
                if (!isAdminLoggedInBefore)
                {
                    AdminLogin admin = new AdminLogin
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    admin.FormClosed += (s, args) =>
                    {
                        if (admin.isLoggedIn)
                        {
                            isAdminLoggedInBefore = admin.isLoggedIn;
                            SessionTimeOut();
                            ProductSalesDetails productSalesDetails = new ProductSalesDetails
                            {
                                MdiParent = this,
                                StartPosition = FormStartPosition.CenterScreen,
                                Dock = DockStyle.Fill
                            };
                            productSalesDetails.Show();
                        }
                        else
                        {
                            EnableDisbaledMenuStripItem();
                        }
                    };
                    admin.Show();
                }
                else
                {
                    ProductSalesDetails productSalesDetails = new ProductSalesDetails
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.CenterScreen,
                        Dock = DockStyle.Fill
                    };
                    productSalesDetails.Show();
                }
                ProductSalesToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at CashierHomepage", MessageBoxButtons.OK);
            }
        }

        public void SessionTimeOut()
        {
            t = new Timer();
            t.Interval = 300000; // it will Tick in 5 seconds
            t.Tick += (s, e) =>
            {
                isAdminLoggedInBefore = false;
                t.Stop();
            };
            t.Start();
        }

        private bool AnyTabClickInCashierHomePage()
        {
            if(billPage1 != null && billPage1.isBillPrinted
               || billPage2 != null && billPage2.isBillPrinted
               || billPage3 != null && billPage3.isBillPrinted
               || billPage4 != null && billPage4.isBillPrinted
               || billPage5 != null && billPage5.isBillPrinted)
            {
                MessageBox.Show("Bill Printed But Not Updated In Database. " +
                                "Without Updation You Cannot Proceed To Another Tab ", "Information");
                return true;
            }
            return false;
        }

        private void ReturnBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (AnyTabClickInCashierHomePage())
                {
                    return;
                }
                CloseOpenedChildForm();
                EnableDisbaledMenuStripItem();
                if (!isAdminLoggedInBefore)
                {
                    AdminLogin admin = new AdminLogin
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    admin.FormClosed += (s, args) =>
                    {
                        if (admin.isLoggedIn)
                        {
                            isAdminLoggedInBefore = admin.isLoggedIn;
                            SessionTimeOut();
                            ReturnBill returnBill = new ReturnBill
                            {
                                MdiParent = this,
                                StartPosition = FormStartPosition.CenterScreen,
                                Dock = DockStyle.Fill
                            };
                            returnBill.Show();
                        }
                        else
                        {
                            EnableDisbaledMenuStripItem();
                        }
                    };
                    admin.Show();
                }
                else
                {
                    ReturnBill returnBill = new ReturnBill
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.CenterScreen,
                        Dock = DockStyle.Fill
                    };
                    returnBill.Show();
                }
                ReturnBillToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at CashierHomepage", MessageBoxButtons.OK);
            }
        }
    }
}
