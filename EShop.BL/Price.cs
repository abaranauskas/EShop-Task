using EShop.BL.Common;
using System;

namespace EShop.BL
{
    public class PriceStamp : Entity
    {
        public decimal Price { get; set; }
        public DateTimeOffset ValidFrom { get; set; }
        public DateTimeOffset? ValidTo { get; set; }
    }
}