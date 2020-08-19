using EShop.BL.Common;
using System.Collections.Generic;

namespace EShop.BL
{
    public class Product : Entity
    {
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        //public OrderItem OrderItem { get; set; }
        public List<PriceStamp> PrciceStamps { get; set; }
        public List<ProductSupplier> ProductSuppliers { get; set; }
        public List<ProductDiscountCoupon> ProductDiscountCoupons { get; set; }
    }
}