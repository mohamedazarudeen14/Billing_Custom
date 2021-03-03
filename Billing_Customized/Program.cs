using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Billing_Customized
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!IsAnotherProcessRunning())
            {
                Application.Run(new CashierHomePage());
            }
            else
            {
                MessageBox.Show("Another Instance Of This Application Running");
                Application.Exit();
            }
        }

        private static bool IsAnotherProcessRunning()
        {
            Process[] process = Process.GetProcessesByName("Billing_Customized");
            if (process.Length > 1)
            {
                return true;
            }
            return false;
        }
    }
}
