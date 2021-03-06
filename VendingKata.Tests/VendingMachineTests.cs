﻿using VendingKata.Domain;
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
            Assert.Equal(3, _vendingMachine.Slot.Stored(Coin.Quarter));
        }


        [Fact]
        public void AcceptsDime_ReturnsCorrectValue_5()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Coin.Dime, 5);

            //Assert
            Assert.Equal(5, _vendingMachine.Slot.Stored(Coin.Dime));
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
            _vendingMachine.DepositToStore(Coin.Dime, 1);

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
            Assert.Equal("$0.25", _vendingMachine.Display);
        }

        [Fact]
        public void Vend_ItemsInStock_ReturnsDecreasedStockValue_1()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Product.Cola, 2);
            _vendingMachine.Insert(Coin.Quarter, 4);
            _vendingMachine.Vend(Product.Cola);

            //Assert
            Assert.Equal(1, _vendingMachine.Products.Stock(Product.Cola));
        }

        [Fact]
        public void Vend_ItemsInStock_NotEnoughCoinsInserted_ReturnsCorrectStockValue_4()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Product.Candy, 4);
            _vendingMachine.Vend(Product.Candy);

            //Assert
            Assert.Equal(4, _vendingMachine.Products.Stock(Product.Candy));
        }

        [Fact]
        public void Vend_ItemsInStock_ReturnsDisplayMessage_ThankYou()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Product.Cola, 2);
            _vendingMachine.Insert(Coin.Quarter, 4);
            _vendingMachine.Vend(Product.Cola);

            //Assert
            Assert.Equal(1, _vendingMachine.Products.Stock(Product.Cola));
            Assert.Equal("THANK YOU", _vendingMachine.Display);
        }

        [Fact]
        public void Vend_NotEnoughCoinsInserted_ReturnsDisplayMessage_Price()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Product.Cola, 1);
            _vendingMachine.Insert(Coin.Quarter, 2);
            _vendingMachine.Vend(Product.Cola);

            string display = _vendingMachine.Display;

            //Assert
            Assert.Equal(1, _vendingMachine.Products.Stock(Product.Cola));
            Assert.Equal("PRICE $1", display);
        }

        [Fact]
        public void Vend_NotEnoughCoinsInserted_ReturnsDisplayMessage_AmountDueAfterPrice()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Product.Cola, 1);
            _vendingMachine.Insert(Coin.Quarter, 2);
            _vendingMachine.Vend(Product.Cola);

            string display = _vendingMachine.Display;
            display = _vendingMachine.Display;

            //Assert
            Assert.Equal(1, _vendingMachine.Products.Stock(Product.Cola));
            Assert.Equal("$0.5", display);
        }


        [Fact]
        public void Vend_ItemsInStock_ReturnsDisplayMessage_InsertCoinsAfterThankYou()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Product.Cola, 2);
            _vendingMachine.Insert(Coin.Quarter, 4);
            _vendingMachine.Vend(Product.Cola);

            string display = _vendingMachine.Display;
            display = _vendingMachine.Display;

            //Assert
            Assert.Equal(1, _vendingMachine.Products.Stock(Product.Cola));
            Assert.Equal("INSERT COINS", display);
        }


        [Fact]
        public void CoinStore_CoinsAreAddedIntoTheStoreOnceInserted_ReturnsCorrectAmount_2()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Product.Chips, 1);
            _vendingMachine.Insert(Coin.Quarter, 2);
            _vendingMachine.Vend(Product.Chips);

            var coinStore = _vendingMachine.Store.Stored(Coin.Quarter);

            //Assert
            Assert.Equal(2, coinStore);
        }


        [Fact]
        public void CoinStore_CorrectChangeIsProvided_ReturnsDime()
        {
            //Arrange
            _vendingMachine.DepositToStore(Coin.Dime, 1);

            //Act
            _vendingMachine.Insert(Product.Cola, 1);
            _vendingMachine.Insert(Coin.Dime, 1);
            _vendingMachine.Insert(Coin.Quarter, 4);
     

            _vendingMachine.Vend(Product.Cola);

            //Assert
            Assert.Equal(1, _vendingMachine.Return.Stored(Coin.Dime));
        }

        [Fact]
        public void CoinReturn_CoinsAreReturnedWhenCallActioned_CoinsFromTheSlotAreInTheReturn()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Coin.Nickel, 3);
            _vendingMachine.ReturnCoins();

            //Assert
            Assert.Equal(3, _vendingMachine.Return.Stored(Coin.Nickel));

        }

        [Fact]
        public void CoinReturn_ReturnsDisplayMessage_InsertCoinAfterCoinsReturned()
        {
            //Arrange
            _vendingMachine.DepositToStore(Coin.Nickel, 1);

            //Act
            _vendingMachine.Insert(Coin.Dime, 2);
            _vendingMachine.ReturnCoins();

            string display = _vendingMachine.Display;

            //Assert
            Assert.Equal("INSERT COINS", display);
        }

        [Fact]
        public void SoldOut_ItemNotInStock_ReturnsDisplayMessage_SoldOut()
        {
            //Arrange

            //Act
            _vendingMachine.Vend(Product.Chips);
            string display = _vendingMachine.Display;

            //Assert
            Assert.Equal("SOLD OUT", display);
        }

        [Fact]
        public void SoldOut_ItemNotInStock_ReturnsDisplayMessage_PriceAfterSoldOut()
        {
            //Arrange

            //Act
            _vendingMachine.Insert(Coin.Nickel, 10);
            _vendingMachine.Vend(Product.Chips);

            string display = _vendingMachine.Display;
            display = _vendingMachine.Display;

            //Assert
            Assert.Equal("$0.5", display);
        }

        [Fact]
        public void ExactChangeOnly_CoinStoreEmpty_ReturnsDisplayMessage_ExactChangeOnly()
        {
            //Arrange

            //Act
            string display = _vendingMachine.Display;

            //Assert
            Assert.Equal("EXACT CHANGE ONLY", display);
        }
    }
}
