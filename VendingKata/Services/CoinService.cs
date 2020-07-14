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
                return (Quarters * 25) + (Dimes * 10) + (Nickles * 5) + Pennies;
            }
        }

        public int Return { get; set; }

        public int Quarters { get; private set; }
        public int Dimes { get; private set; }
        public int Nickles { get; private set; }
        public int Pennies { get; private set; }

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
                case Coin.Nickel:
                    Nickles += number;
                    break;
                case Coin.Penny:
                    Pennies += number;
                    break;
            }
        }
    }
}