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
                return (Quarters * 25) + (Dimes * 10) + (Nickels * 5) + Pennies;
            }
        }

        public int Quarters { get; private set; }
        public int Dimes { get; private set; }
        public int Nickels { get; private set; }
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
                    Nickels += number;
                    break;
                case Coin.Penny:
                    Pennies += number;
                    break;
            }
        }

        public void Deposit(CoinService service)
        {
            service.Quarters += Quarters;
            Quarters = 0;

            service.Dimes += Dimes;
            Dimes = 0;

            service.Nickels += Nickels;
            Nickels = 0;

            service.Pennies += Pennies;
            Pennies = 0;
        }
    }
}