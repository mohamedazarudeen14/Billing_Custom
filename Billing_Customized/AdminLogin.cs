using BusinessLayer;
using CommonClasses;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Billing_Customized
{
    public partial class AdminLogin : Form
    {
        public Admin admin;
        private BackgroundWorker backgroundWorker;
        public bool isLoggedIn = false;
        public string loggedInAdmin = string.Empty;

        public AdminLogin()
        {
            InitializeComponent();
            admin = new Admin();
        }

        private void Showpassword_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            adminPassword_textBox.UseSystemPasswordChar = !Showpassword_checkBox.Checked;
        }

        private void adminPassword_textBox_TextChanged(object sender, EventArgs e)
        {
            if (!Showpassword_checkBox.Checked)
            {
                adminPassword_textBox.UseSystemPasswordChar = true;
            }
        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Loginbutton.Enabled = false;
                backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += AuthenticateAdmin;
                backgroundWorker.RunWorkerCompleted += ShowAdminHomePage;
                if (!string.IsNullOrWhiteSpace(adminUserId_textBox.Text) && !string.IsNullOrWhiteSpace(adminPassword_textBox.Text))
                {
                    backgroundWorker.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Admin_FillAllFields");
                    Loginbutton.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at AdminLoginPage", MessageBoxButtons.OK);
            }
        }

        private void AuthenticateAdmin(object sender, DoWorkEventArgs e)
        {
            e.Result = admin.IsAdminAuthenticated(adminUserId_textBox.Text, adminPassword_textBox.Text);
        }

        private void ShowAdminHomePage(object sender, RunWorkerCompletedEventArgs e)
        {
            bool isAuthenticated = (bool)e.Result;
            if (isAuthenticated)
            {
                isLoggedIn = true;
                loggedInAdmin = adminUserId_textBox.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Admin_InvalidUserNamePassword");
            }
            Loginbutton.Enabled = true;
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            try
            {
                isLoggedIn = false;
                loggedInAdmin = string.Empty;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString(), "Error Occured at AdminLoginPage", MessageBoxButtons.OK);
            }
        }

        private void AdminLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Loginbutton_Click(null, e);
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
        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (!isAnyButtonClicked && sender != null && string.Equals((sender as Form).Name, "AdminLogin"))
        //    {
        //        Application.Exit();
        //    }
        //}
    }
}
