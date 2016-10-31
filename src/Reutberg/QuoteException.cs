using System;

namespace Reutberg
{
    public sealed class QuoteException : Exception
    {
        public QuoteException(string ticker)
        {
            Ticker = ticker;
        }

        public string Ticker { get; private set; }
    }
}