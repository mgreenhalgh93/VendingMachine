using System;
using VendingKata.Domain;

namespace VendingKata.Services
{
    public class CoinService
    {
        public CoinService()
        {
        }

        public int Total
        {
            get
            {
                return (Quarters * 25) + (Dimes * 10);
            }
        }

        public int Quarters { get; private set; }
        public int Dimes { get; private set; }

        public void Insert(Coin coin, int number)
        {
            switch (coin)
            {
                case Coin.Dime:
                    Dimes += number;
                    break;
                case Coin.Quarter:
                    Quarters += number;
                    break;         
            }
        }
    }
}