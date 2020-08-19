using EShop.BL.Common;

namespace EShop.BL
{
    public class ProductDiscountCoupon : Entity
    {
        public Product Product { get; set; }
        public DiscountCoupon DiscountCoupon { get; set; }
    }
}