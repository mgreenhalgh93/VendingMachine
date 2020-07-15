﻿using System;
using VendingKata.Domain;
using VendingKata.Services;

namespace VendingKata
{
    public class VendingMachine
    {
        public VendingMachine()
        {
            Slot = new CoinService();
            Return = new CoinService();
            Stock = new ProductService();
        }

        public CoinService Slot { get; set; }
        public CoinService Return { get; set; }
        public ProductService Stock { get; set; }

        public string Display
        {
            get
            {
                string display;

                if (!string.IsNullOrEmpty(TempDisplay))
                    display = TempDisplay;
                else if (Slot.Total == 0)
                    display = "INSERT COINS";
                else
                    display = $"{Slot.Total / 100.0}";

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
            Stock.Insert(product, number);
        }

        public void Vend(Product product)
        {
            if (Slot.Total >= GetPrice(product))
            {
                Stock.Vend(product);
                TempDisplay = "THANK YOU";
            }
        }

        private string TempDisplay { get; set; }
    }
}
