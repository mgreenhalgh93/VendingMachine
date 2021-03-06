﻿using VendingKata.Domain;
using VendingKata.Services;

namespace VendingKata
{
    public class VendingMachine
    {
        public VendingMachine()
        {
            Slot = new CoinService();
            Return = new CoinService();
            Store = new CoinService();

            Products = new ProductService();
        }

        public CoinService Slot { get; set; }
        public CoinService Return { get; set; }
        public CoinService Store { get; set; }

        public ProductService Products { get; set; }

        public string Display
        {
            get
            {
                string display;

                if (!string.IsNullOrEmpty(TempDisplay))
                {
                    display = TempDisplay;
                    TempDisplay = string.Empty;
                }

                else if (Slot.Total == 0)
                {
                    if (Store.Total == 0)
                        display = "EXACT CHANGE ONLY";
                    else
                        display = "INSERT COINS";
                }
                else
                    display = PriceString(Slot.Total);

                return display;
            }
        }

        public int GetPrice(Product product)
        {
            switch (product)
            {
                case Product.Cola:
                    return 100;
                case Product.Chips:
                    return 50;
                case Product.Candy:
                    return 65;
                default:
                    return 0;
            }
        }

        public void Insert(Coin coin, int number)
        {
            if(coin == Coin.Penny)
                Return.Insert(coin, number);
            else
                Slot.Insert(coin, number);
        }

        public void Insert(Product product, int number)
        {
            Products.Insert(product, number);
        }

        public void Vend(Product product)
        {
            int price = GetPrice(product);

            if (Products.Stock(product) == 0)
                TempDisplay = "SOLD OUT";
            else if (Slot.Total >= price)
            {
                Products.Vend(product);
                TempDisplay = "THANK YOU";

                int changeDue = Slot.Total - price;
                if (changeDue > 0)
                {
                    Store.Return(Return, changeDue);
                }

                Slot.Deposit(Store);
            }
            else
            {
                TempDisplay = $"PRICE {PriceString(price)}";
            }
        }

        public void ReturnCoins()
        {
            Slot.Deposit(Return);
        }

        public void DepositToStore(Coin coin, int number)
        {
            Store.Insert(coin, number);
        }

        private string TempDisplay { get; set; }

        private string PriceString(int amount)
        {
            return string.Format("${0}", amount / 100.0);
        }
    }
}
