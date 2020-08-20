using CSharpFunctionalExtensions;
using EShop.BL.Common;
using System;
using System.Collections.Generic;

namespace EShop.BL
{
    public class Order : Entity
    {
        public Order()
        {                
        }

        public Order(User customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            Customer = customer;
            OrderItems = new List<OrderItem>();
        }

        public User Customer { get; }
        public List<OrderItem> OrderItems { get; }


        public Result CanBuyProduct(Product product, int quantityToBuy)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            return product.CanBuy(quantityToBuy);
        }

        public void BuyProduct(Product product, int quantityToBuy)
        {
            if (CanBuyProduct(product, quantityToBuy).IsFailure)
                throw new InvalidOperationException();

            product.Buy(quantityToBuy); // in future hould be change by method in purpose of validation
            OrderItems.Add(new OrderItem { Product = product, Quantity = quantityToBuy });
        }
    }
}
