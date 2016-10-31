using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Reutberg
{
    public sealed class ReutbergService
    {
        private readonly ConcurrentDictionary<string, decimal> _lastPrices =
            new ConcurrentDictionary<string, decimal>();

        private readonly Random _seed = new Random();

        public decimal GetQuote(string ticker)
        {
            if (ShouldFail(5))
            {
                throw new QuoteException(ticker);
            }

            return _lastPrices.AddOrUpdate(ticker, GetInitialQuote, UpdateQuote);
        }

        public decimal Buy(string ticker, int quantity)
        {
            return Trade(ticker, quantity, true);
        }

        public decimal Sell(string ticker, int quantity)
        {
            return Trade(ticker, quantity, false);
        }

        private decimal Trade(string ticker, int quantity, bool positive)
        {
            if (quantity <= 0) throw new ArgumentOutOfRangeException("quantity", quantity, "Must be greater than 0");
            if (ShouldFail(5)) throw new TradeException(ticker);

            decimal quote;
            if (!_lastPrices.TryGetValue(ticker, out quote))
            {
                quote = GetInitialQuote(ticker);
            }
            return quote * quantity*(positive ? 1 : -1);
        }

        private decimal UpdateQuote(string ticker, decimal quote)
        {
            var newPrice = GetNextPrice(quote);
            return newPrice;
        }

        private decimal GetNextPrice(decimal quote)
        {
            var price = quote + (quote * _seed.Next(-100, 50)/100000m);
            return Math.Floor(price*100)/100;
        }

        private decimal GetInitialQuote(string ticker)
        {
            return _seed.Next(100, 1000);
        }
        
        private bool ShouldFail(int denominator)
        {
            return _seed.Next(0, denominator) == 1;
        }
    }
}