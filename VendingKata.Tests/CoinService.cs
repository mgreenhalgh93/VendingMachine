using System;

namespace VendingKata.Tests
{
    internal class CoinService
    {
        public CoinService()
        {
        }

        public object Total { get; internal set; }

        internal void Insert(object quarter, int v)
        {
            throw new NotImplementedException();
        }
    }
}