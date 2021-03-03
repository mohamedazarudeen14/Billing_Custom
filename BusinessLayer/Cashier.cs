using CommonClasses;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class Cashier
    {
        private CashierDataAccess cashierDataAccess;
        public Cashier()
        {
            cashierDataAccess = new CashierDataAccess();
        }
        
        public List<StockDetail> GetAllProducts()
        {
            return cashierDataAccess.GetAllProducts();
        }

        public void UpdateBillDetails(string currentBillNumber, decimal totalGST, decimal billAmount, DataGridView purchasedProductsFromGridView)
        {
            List<ProductSalesDetail> purchased = new List<ProductSalesDetail>();
            SalesDetail salesDetail = new SalesDetail();
            if (purchasedProductsFromGridView.Rows.Count > 0)
            {
                for (int i = 0; i < purchasedProductsFromGridView.Rows.Count; i++)
                {
                    ProductSalesDetail billedProducts = new ProductSalesDetail
                    {
                        ProductId = Convert.ToInt64(purchasedProductsFromGridView.Rows[i].Cells[1].Value),
                        ProductName = purchasedProductsFromGridView.Rows[i].Cells[2].Value.ToString(),
                        Quantity = purchasedProductsFromGridView.Rows[i].Cells[3].Value.ToString() == string.Empty ? 1 : Convert.ToDecimal(purchasedProductsFromGridView.Rows[i].Cells[3].Value) * Convert.ToDecimal(purchasedProductsFromGridView.Rows[i].Cells[4].Value),
                        BillAmount = Convert.ToDecimal(purchasedProductsFromGridView.Rows[i].Cells[6].Value),
                        GstAmount = Convert.ToDecimal(purchasedProductsFromGridView.Rows[i].Cells[7].Value),
                        SoldDate = DateTime.Today,
                        BillNumber = Convert.ToInt64(currentBillNumber)
                    };
                    purchased.Add(billedProducts);
                }

                salesDetail.BillNos = Convert.ToInt64(currentBillNumber);
                salesDetail.GstAmount = totalGST;
                salesDetail.BillAmount = Math.Round(billAmount,MidpointRounding.ToEven);
                salesDetail.SalesDate = DateTime.Today;
            }
            Task.Run(() => cashierDataAccess.AddSalesDetails(salesDetail));
            Task.Run(() => cashierDataAccess.UpdateProductSalesDetails(purchased));
        }

        public string GetCurrentBillNumber()
        {
            List<SalesDetail> allSalesDetails = cashierDataAccess.RetrieveAllSalesDetails();
            if (allSalesDetails.Count > 0)
            {
                if (allSalesDetails[allSalesDetails.Count - 1].SalesDate != DateTime.Today)
                {
                    return "1";
                }
                else
                {
                    return (allSalesDetails.Where(obj => obj.SalesDate == DateTime.Today).Max(obj => obj.BillNos) + 1).ToString();
                }
            }
            else
            {
                return "1";
            }
        }
    }
}
