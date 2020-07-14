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
        }

        public CoinService Slot { get; set; }
        public CoinService Return { get; set; }

        public string Display
        {
            get
            {
                if (Slot.Total == 0)
                    return "INSERT COINS";
                else
                    return $"{Slot.Total / 100.0}";
            }
        }

        public int GetPrice(Product product)
        {
            return 100;
        }

        public void Insert(Coin coin, int number)
        {
            if(coin == Coin.Penny)
                Return.Insert(coin, number);
            else
                Slot.Insert(coin, number);
        }
    }
}