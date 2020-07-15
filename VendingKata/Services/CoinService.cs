using System;
using System.Collections.Generic;
using VendingKata.Domain;

namespace VendingKata.Services
{
    public class CoinService
    {
        private Dictionary<Coin, int> _coins { get; set; }

        public CoinService()
        {
            _coins = new Dictionary<Coin, int>();
        }

        public int Total
        {
            get
            {
                return GetCoinTotal();
            }
        }

        public int Stored(Coin coin)
        {
            if (_coins.ContainsKey(coin))
               return _coins[coin];

            return 0;
        }

        public void Insert(Coin coin, int number)
        {
            if (_coins.ContainsKey(coin))
                _coins[coin] += number;
            else
                _coins.Add(coin, number);
        }

        public void Deposit(CoinService service)
        {
            foreach (var coin in _coins)
            {
                service.Insert(coin.Key, coin.Value);
            }
           _coins.Clear();
        }

        public void Return(CoinService service, int amount)
        {
            int returnedQuarters = ReturnCoin(service, Coin.Quarter, amount);
            amount -= returnedQuarters * CoinValue(Coin.Quarter);

            int returnedDimes = ReturnCoin(service, Coin.Dime, amount);
            amount -= returnedDimes * CoinValue(Coin.Dime);

            int returnedNickels = ReturnCoin(service, Coin.Nickel, amount);
            amount -= returnedNickels * CoinValue(Coin.Nickel);

            int returnedPennies = ReturnCoin(service, Coin.Penny, amount);
            amount -= returnedPennies * CoinValue(Coin.Penny);
        }

        private int ReturnCoin(CoinService service, Coin coin, int amount)
        {
            int dispensedCoins = Math.Min(amount / CoinValue(coin), Stored(coin));
            service.Insert(coin, dispensedCoins);
            RemoveFromService(coin, dispensedCoins);

            return dispensedCoins;
        }

        private void RemoveFromService(Coin coin, int num)
        {
            if (_coins.ContainsKey(coin))
            {
                _coins[coin] -= Math.Min(num, _coins[coin]);
            }
        }

        private int CoinValue(Coin coin)
        {
            switch (coin)
            {
                case Coin.Penny:
                    return 1;
                case Coin.Nickel:
                    return 5;
                case Coin.Dime:
                    return 10;
                case Coin.Quarter:
                    return 25;
                default:
                    return 0;
            }
        }

        private int GetCoinTotal()
        {
            var total = 0;
            foreach (var coin in _coins)
            {
                total += Stored(coin.Key) * CoinValue(coin.Key);
            }
            return total;
        }
    }
}