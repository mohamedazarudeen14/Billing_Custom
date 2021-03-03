using CommonClasses;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Admin
    {
        private CashierDataAccess cashierDataAccess = new CashierDataAccess();
        private AdminDataAccess accessDB = new AdminDataAccess();

        public void CheckDbConnection()
        {
            Task.Run(() => accessDB.CheckDbConnection());
        }

        public bool IsAdminAuthenticated(string userId, string password)
        {
            EncryptionDecryption passwordEncryptionDecryption = new EncryptionDecryption();
            string EncryptedPassword = passwordEncryptionDecryption.Encryptdata(password);
            List<AdminDetail> allAdmins = accessDB.GetAllAdmin();
            foreach (AdminDetail admin in allAdmins)
            {
                if (userId.Equals(admin.UserId) && EncryptedPassword.Equals(admin.Password))
                {
                    Task.Run(() => accessDB.AddLastoggedInTimeForLoggedAdmin(admin.UserId));
                    return true;
                }
            }
            return false;
        }

        public bool DeletedSelectedProduct(long selectedProductId)
        {
            return accessDB.DeleteProduct(selectedProductId);
        }

        public void AdminLogout(string adminId)
        {
            Task.Run(() => accessDB.AddLastLoggedOutTimeForLoggedAdmin(adminId));
        }

        public bool SaveProductDetails(long productId, string productName, decimal quantity, decimal buyingPrice,
            decimal retailPrice, decimal wholesalePrice, decimal creditPrice, int gstPercentage)
        {
            StockDetail newStock = new StockDetail
            {
                ProductId = Convert.ToInt64(productId),
                ProductName = productName,
                Quantity = quantity,
                BuyingPrice = Math.Round(buyingPrice, 2),
                RetailPrice = Math.Round(retailPrice, 2),
                WholesalePrice = Math.Round(wholesalePrice, 2),
                CreditPrice = Math.Round(creditPrice, 2),
                GSTPercentage = gstPercentage
            };
            return accessDB.SaveProduct(newStock);
        }

        public List<StockDetail> GetAllStockDetails()
        {
            return accessDB.GetAllStock();
        }

        public bool UpdateProductDetails(long productId, string productName, decimal quantity, decimal buyingPrice,
            decimal retailPrice, decimal wholesalePrice, decimal creditPrice, int gstPercentage)
        {
            return accessDB.UpdateProductDetails(productId, productName, quantity, buyingPrice, retailPrice, wholesalePrice, creditPrice, gstPercentage);
        }

        public bool IsProductIdAvailable(double productId)
        {
            List<StockDetail> allProuctdetails = accessDB.GetAllStock();

            return allProuctdetails.Any(obj => obj.ProductId == productId);
        }

        public List<List<ProductSalesDetail>> GetProductSalesDetailsForSelectedDate(DateTime fromDate, DateTime toDate)
        {
            List<ProductSalesDetail> allSalesDetails = accessDB.RetrieveAllProductSalesDetails();
            if (allSalesDetails.Count > 0)
            {
            var selectedDateSalesDetails = allSalesDetails.Where(obj => obj.SoldDate.Date >= fromDate.Date && obj.SoldDate.Date <= toDate.Date)
                                                          .GroupBy(obj => new { obj.ProductId, obj.SoldDate.Date })
                                                          .OrderBy(obj => obj.Key.Date)
                                                          .ThenBy(obj => obj.Key.ProductId)
                                                          .Select(obj => obj.ToList()).ToList();

                return selectedDateSalesDetails;
            }

            return null;
        }

        public List<SalesDetail> GetSalesDetailsForSelectedDate(DateTime fromDate, DateTime toDate)
        {
            List<SalesDetail> allSalesDetails = accessDB.GetAllSalesDetails();
            if (allSalesDetails != null && allSalesDetails.Count > 0)
            {
                List<SalesDetail> selectedDateSalesDetails = allSalesDetails.Where(obj => obj.SalesDate.Date >= fromDate.Date && obj.SalesDate.Date <= toDate.Date).OrderByDescending(obj => obj.SalesDate).ThenBy(obj => obj.BillNos).ToList();

                return selectedDateSalesDetails;
            }

            return null;
        }

        public List<ProductSalesDetail> GetProductSalesDetailsForBillNumber(DateTime date, long billNumber)
        {
            List<ProductSalesDetail> productSalesDetails = accessDB.RetrieveAllProductSalesDetails();
            if(productSalesDetails != null && productSalesDetails.Count > 0)
            {
                return productSalesDetails.Where(obj => obj.SoldDate.Date.Equals(date.Date) && obj.BillNumber != null && obj.BillNumber.Equals(billNumber)).OrderBy(obj => obj.ProductId).ToList();
            }

            return null;
        }

        public SalesDetail GetSalesDetailsForBillNumber(DateTime date, long billNumber)
        {
            List<SalesDetail> allSalesDetails = accessDB.GetAllSalesDetails();
            if (allSalesDetails != null && allSalesDetails.Count > 0)
            {
               return allSalesDetails.FirstOrDefault(obj => obj.SalesDate.Date.Equals(date.Date) && obj.BillNos.Equals(billNumber));
            }

            return null;
        }

        public void DeleteSalesDetailsForReturnBill(List<ProductSalesDetail> productSales, SalesDetail salesDetail)
        {
            accessDB.DeleteSalesDetailsForReturnBill(productSales, salesDetail);
        }

    }
}
