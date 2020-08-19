using EShop.BL.Common;

namespace EShop.BL
{
    public class ProductSupplier : Entity
    {
        public Product Product { get; set; }
        public Supplier Suppier { get; set; }
    }
}