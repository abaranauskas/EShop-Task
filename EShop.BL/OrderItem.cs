using EShop.BL.Common;

namespace EShop.BL
{
    public class OrderItem: Entity
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }       
    }
}