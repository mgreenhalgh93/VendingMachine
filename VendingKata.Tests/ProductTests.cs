using System;
using VendingKata.Domain;
using Xunit;

namespace VendingKata.Tests
{
    public class ProductTests
    {
        private readonly VendingMachine _vendingMachine;

        public ProductTests()
        {
            _vendingMachine = new VendingMachine();
        }

        [Fact]
        public void ValidateCostCola_Retun_100()
        {
            //Arrange

            //Act
            var price = _vendingMachine.GetPrice(Product.Cola);

            //Assert
            Assert.Equal(100, price);
        }

        [Fact]
        public void ValidateCostCola_Retun_50()
        {
            //Arrange

            //Act
            var price = _vendingMachine.GetPrice(Product.Chips);

            //Assert
            Assert.Equal(50, price);
        }
    }
}
