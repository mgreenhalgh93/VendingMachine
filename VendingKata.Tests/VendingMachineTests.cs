using System;
using Xunit;

namespace VendingKata.Tests
{
    public class VendingMachineTests
    {
        [Fact]
        public void InsertQuarter_ReturnsCorrectValue_25()
        {
            //Arrange
            var coinService = new CoinService();

            //Act
            coinService.Insert(Coin.Quarter, 1);

            var result = coinService.Total;

            //Assert
            Assert.Equal(25, result);
        }


        [Fact]
        public void InsertDime_ReturnsCorrectValue_10()
        {
            //Arrange
            var coinService = new CoinService();

            //Act
            coinService.Insert(Coin.Dime, 1);

            var result = coinService.Total;

            //Assert
            Assert.Equal(10, result);
        }
    }
}
