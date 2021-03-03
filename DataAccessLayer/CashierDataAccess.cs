using CommonClasses;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class CashierDataAccess
    {
        public List<StockDetail> GetAllProducts()
        {
            using (Billing_Customized_Entities getAllProducts = new Billing_Customized_Entities())
            {
                return getAllProducts.StockDetails.ToList();
            }
        }

        public void UpdateProductSalesDetails(List<ProductSalesDetail> purchasedProductDetails)
        {
            using (Billing_Customized_Entities addBilledProducts = new Billing_Customized_Entities())
            {
                addBilledProducts.ProductSalesDetails.AddRange(purchasedProductDetails);
                addBilledProducts.SaveChanges();
            }
        }

        public List<SalesDetail> RetrieveAllSalesDetails()
        {
            using (Billing_Customized_Entities allSalesDetails = new Billing_Customized_Entities())
            {
                return allSalesDetails.SalesDetails.ToList();
            }
        }

        public void AddSalesDetails(SalesDetail billedProducts)
        {
            using (Billing_Customized_Entities billedProductDetails = new Billing_Customized_Entities())
            {
                billedProductDetails.SalesDetails.Add(billedProducts);
                billedProductDetails.SaveChanges();
            }
        }
    }
}