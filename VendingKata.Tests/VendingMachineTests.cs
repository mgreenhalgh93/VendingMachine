using VendingKata.Domain;
using VendingKata.Services;
using Xunit;

namespace VendingKata.Tests
{
    public class VendingMachineTests
    {
        private readonly VendingMachine _vendingMachine;

        public VendingMachineTests()
        {
            _vendingMachine = new VendingMachine();
        }

        [Fact]
        public void AcceptsQuarter_ReturnsCorrectValue_3()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Coin.Quarter, 3);

            //Assert
            Assert.Equal(3, _vendingMachine.Slot.Quarters);
        }


        [Fact]
        public void AcceptsDime_ReturnsCorrectValue_5()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Coin.Dime, 5);

            //Assert
            Assert.Equal(5, _vendingMachine.Slot.Dimes);
        }

        [Fact]
        public void ReturnsPenny_ReturnsCorrectValue_1()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Coin.Penny, 1);

            var coinTotal = _vendingMachine.Slot.Total;
            int coinReturn = _vendingMachine.Return.Total;

            //Assert
            Assert.Equal(0, coinTotal);
            Assert.Equal(1, coinReturn);
        }

        [Fact]
        public void SlotEmpty_ReturnsInsertCoinsMessage()
        {
            //Arrange

            //Act
            var displayMessage = _vendingMachine.Display;

            //Assert
            Assert.Equal("INSERT COINS", displayMessage);
        }
    }
}
