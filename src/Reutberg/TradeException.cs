using System;

namespace Reutberg
{
    public class TradeException : Exception
    {
        public string Ticker { get; private set; }

        public TradeException(string ticker)
        {
            Ticker = ticker;
        }
    }
}