using EShop.BL;
using FluentAssertions;
using System;
using Xunit;

namespace EShop.Tests
{
    public class OrdersTests
    {
        [Fact]
        public void Creates_order_and_updates_products_quantity_when_data_is_valid()
        {
            //Arrange   
            var quantityToBuy = 2;
            var product = new Product
            {
                Name = "Test1",
                StockQuantity = 8
            };
            var customer = new User
            {
                FirstName = "Aidas",
                LastName = "Baranauskas"
            };

            var order = new Order(customer);

            //Act
            var result = order.CanBuyProduct(product, quantityToBuy);
            order.BuyProduct(product, quantityToBuy);

            //Assert
            result.IsSuccess.Should().Be(true);
            product.StockQuantity.Should().Be(6);
            order.OrderItems.Count.Should().Be(1);
        }
    }
}
