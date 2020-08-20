using CSharpFunctionalExtensions;
using EShop.BL.Common;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace EShop.BL
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public List<PriceStamp> PrciceStamps { get; set; }
        public List<ProductSupplier> ProductSuppliers { get; set; }
        public List<ProductDiscountCoupon> ProductDiscountCoupons { get; set; }

        internal Result CanBuy(int quantityToBuy)
        {
            if (quantityToBuy <= 0)
                return Result.Failure("Quantity must be greater than zero.");

            if (StockQuantity < quantityToBuy)
                return Result.Failure("Not enought products in stock.");

            return Result.Success();
        }

        internal void Buy(int quantityToBuy)
        {
            if (CanBuy(quantityToBuy).IsFailure)
                throw new InvalidOperationException();

            StockQuantity -= quantityToBuy;
        }
    }
}