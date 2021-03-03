using CommonClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataAccessLayer
{
    public class AdminDataAccess
    {
        public void CheckDbConnection()
        {
            using (Billing_Customized_Entities billingEntities = new Billing_Customized_Entities())
            {
                billingEntities.AdminDetails.ToList();
            }
        }

        public List<AdminDetail> GetAllAdmin()
        {
            using (Billing_Customized_Entities allAdmin = new Billing_Customized_Entities())
            {
                return allAdmin.AdminDetails.ToList();
            }

        }

        public bool SaveProduct(StockDetail newStock)
        {
            using (Billing_Customized_Entities saveProductDetails = new Billing_Customized_Entities())
            {
                saveProductDetails.StockDetails.Add(newStock);
                saveProductDetails.SaveChanges();
                return true;
            }
        }

        public List<StockDetail> GetAllStock()
        {
            using (Billing_Customized_Entities getAllStock = new Billing_Customized_Entities())
            {
                return getAllStock.StockDetails.ToList();
            }
        }

        public void AddLastoggedInTimeForLoggedAdmin(string loggedAdminUserId)
        {
            using (Billing_Customized_Entities allAdmin = new Billing_Customized_Entities())
            {
                allAdmin.AdminDetails.Where(obj => obj.UserId.Equals(loggedAdminUserId)).ToList().ForEach(obj => obj.Last_LoggedIn_Time = DateTime.Now);
                allAdmin.SaveChanges();
            }
        }

        public void AddLastLoggedOutTimeForLoggedAdmin(string loggedInAdminUserId)
        {
            using (Billing_Customized_Entities allAdmin = new Billing_Customized_Entities())
            {
                allAdmin.AdminDetails.Where(obj => obj.UserId.Equals(loggedInAdminUserId)).ToList().ForEach(obj => obj.Last_LoggedOut_Time = DateTime.Now);
                allAdmin.SaveChanges();
            }
        }

        public bool DeleteProduct(long productId)
        {
            bool isProductdeleted = false;
            using (Billing_Customized_Entities deleteProduct = new Billing_Customized_Entities())
            {
                StockDetail stockDetail = deleteProduct.StockDetails.FirstOrDefault(obj => obj.ProductId == productId);
                if (stockDetail != null)
                {
                    deleteProduct.StockDetails.Remove(stockDetail);
                    isProductdeleted = true;
                    deleteProduct.SaveChanges();
                }

                return isProductdeleted;
            }
        }

        public bool UpdateProductDetails(long productId, string productName, decimal quantity,
                                         decimal buyingPrice, decimal retailPrice, decimal wholesalePrice,
                                         decimal creditPrice, int gstPercentage)
        {
            bool isProductDetailsUpdated = false;
            using (Billing_Customized_Entities updateProductDetails = new Billing_Customized_Entities())
            {
                StockDetail stock = updateProductDetails.StockDetails.FirstOrDefault(obj => obj.ProductId == productId);

                if(stock != null)
                {
                    stock.ProductName = productName;
                    stock.Quantity = quantity;
                    stock.BuyingPrice = Math.Round(buyingPrice, 2);
                    stock.RetailPrice = Math.Round(retailPrice, 2);
                    stock.WholesalePrice = Math.Round(wholesalePrice, 2);
                    stock.CreditPrice = Math.Round(creditPrice, 2);
                    stock.GSTPercentage = gstPercentage;
                    isProductDetailsUpdated = true;
                    updateProductDetails.SaveChanges();
                }
                
                return isProductDetailsUpdated;
            }
        }

        public List<ProductSalesDetail> RetrieveAllProductSalesDetails()
        {
            using (Billing_Customized_Entities allSalesDetails = new Billing_Customized_Entities())
            {
                return allSalesDetails.ProductSalesDetails.ToList();
            }
        }

        public List<SalesDetail> GetAllSalesDetails()
        {
            using (Billing_Customized_Entities allSalesDetails = new Billing_Customized_Entities())
            {
                return allSalesDetails.SalesDetails.ToList();
            }
        }

        public void DeleteSalesDetailsForReturnBill(List<ProductSalesDetail> productSalesDetail, SalesDetail salesDetail)
        {
            using (Billing_Customized_Entities allSalesDetails = new Billing_Customized_Entities())
            {
                allSalesDetails.SalesDetails.Attach(salesDetail);
                allSalesDetails.Entry(salesDetail).State = System.Data.Entity.EntityState.Deleted;
                foreach(var items in productSalesDetail)
                {
                    allSalesDetails.ProductSalesDetails.Attach(items);
                    allSalesDetails.Entry(items).State = System.Data.Entity.EntityState.Deleted;
                }                
                allSalesDetails.SaveChanges();
            }
        }
    }
}
