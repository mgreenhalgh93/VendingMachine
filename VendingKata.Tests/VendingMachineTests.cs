using VendingKata.Domain;
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

            //Assert
            Assert.Equal(0, _vendingMachine.Slot.Total);
            Assert.Equal(1, _vendingMachine.Return.Total);
        }

        [Fact]
        public void SlotEmpty_ReturnsDisplayMessage_InsertCoins()
        {
            //Arrange

            //Act

            //Assert
            Assert.Equal("INSERT COINS", _vendingMachine.Display);
        }

        [Fact]
        public void InsertedQuarter_ReturnsDisplayMessage_025()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Coin.Quarter, 1);

            //Assert
            Assert.Equal("0.25", _vendingMachine.Display);
        }

        [Fact]
        public void Vend_ItemsInStock_ReturnsDecreasedStockValue_1()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Product.Cola, 2);
            _vendingMachine.Vend(Product.Cola);

            var colaStock = _vendingMachine.Stock.Cola;

            //Assert
            Assert.Equal(1, colaStock);
        }
    }
}
