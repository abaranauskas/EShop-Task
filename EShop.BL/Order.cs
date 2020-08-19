using EShop.BL.Common;
using System.Collections.Generic;

namespace EShop.BL
{
    public class Order : Entity
    {
        public User Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
