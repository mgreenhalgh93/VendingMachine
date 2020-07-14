using VendingKata.Domain;
using VendingKata.Services;
using Xunit;

namespace VendingKata.Tests
{
    public class VendingMachineTests
    {
        private readonly CoinService _coinService;

        public VendingMachineTests()
        {
            _coinService = new CoinService();
        }

        [Fact]
        public void AcceptsQuarter_ReturnsCorrectValue_25()
        {
            //Arrange
            
            //Act
            _coinService.Insert(Coin.Quarter, 1);

            //Assert
            Assert.Equal(25, _coinService.Total);
        }


        [Fact]
        public void AcceptsDime_ReturnsCorrectValue_10()
        {
            //Arrange

            //Act
            _coinService.Insert(Coin.Dime, 1);

            //Assert
            Assert.Equal(10, _coinService.Total);
        }

        [Fact]
        public void ReturnsPenny_ReturnsCorrectValue_1()
        {
            //Arrange

            //Act
            _coinService.Insert(Coin.Penny, 1);

            var coinTotal = _coinService.Total;
            int coinReturn = _coinService.Return;

            //Assert
            Assert.Equal(0, coinTotal);
            Assert.Equal(1, coinReturn);
        }
    }
}
