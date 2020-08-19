using EShop.BL.Common;

namespace EShop.BL
{
    public class DiscountCoupon : Entity
    {
        public string Name { get; set; }
        public decimal Percentage { get; set; }
    }
}