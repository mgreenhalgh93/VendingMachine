using VendingKata.Domain;
using VendingKata.Services;
using Xunit;

namespace VendingKata.Tests.Services
{
    public class CoinServiceTests
    {
        private readonly CoinService _coinService;

        public CoinServiceTests()
        {
            _coinService = new CoinService();
        }

        [Fact]
        public void InsertQuarter_ReturnsCorrectValue_25()
        {
            //Arrange

            //Act
            _coinService.Insert(Coin.Quarter, 1);

            //Assert
            Assert.Equal(25, _coinService.Total);
        }


        [Fact]
        public void InsertDime_ReturnsCorrectValue_10()
        {
            //Arrange

            //Act
            _coinService.Insert(Coin.Dime, 1);

            //Assert
            Assert.Equal(10, _coinService.Total);
        }

        [Fact]
        public void InsertNickle_ReturnsCorrectValue_5()
        {
            //Arrange

            //Act
            _coinService.Insert(Coin.Nickel, 1);

            //Assert
            Assert.Equal(5, _coinService.Total);
        }

        [Fact]
        public void InsertPenny_ReturnsCorrectValue_1()
        {
            //Arrange

            //Act
            _coinService.Insert(Coin.Penny, 1);

            //Assert
            Assert.Equal(1, _coinService.Total);
        }
    }
}
