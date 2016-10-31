namespace Reutberg
{
    public sealed class TradeResult
    {
        public string Ticker { get; private set; }
        public decimal TradeValue { get; private set; }

        public TradeResult(string ticker, decimal tradeValue)
        {
            Ticker = ticker;
            TradeValue = tradeValue;
        }
    }
}