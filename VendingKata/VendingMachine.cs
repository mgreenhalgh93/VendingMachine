using System;
using System.Collections.Generic;
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
                return "INSERT COINS";
            }
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
