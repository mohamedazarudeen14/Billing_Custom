//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommonClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductSalesDetail
    {
        public long Id { get; set; }
        public System.DateTime SoldDate { get; set; }
        public Nullable<long> BillNumber { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal BillAmount { get; set; }
        public decimal GstAmount { get; set; }
    }
}
