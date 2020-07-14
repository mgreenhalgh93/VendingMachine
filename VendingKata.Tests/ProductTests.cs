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
        public void ValidateCostChips_Retun_50()
        {
            //Arrange

            //Act
            var price = _vendingMachine.GetPrice(Product.Chips);

            //Assert
            Assert.Equal(50, price);
        }

        [Fact]
        public void ValidateCostCandy_Retun_65()
        {
            //Arrange

            //Act
            var price = _vendingMachine.GetPrice(Product.Candy);

            //Assert
            Assert.Equal(65, price);
        }
    }
}
