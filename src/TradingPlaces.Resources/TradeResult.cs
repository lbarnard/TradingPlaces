namespace TradingPlaces.Resources
{
    public sealed class TradingStrategyResult
    {
        public TradingStrategyResult(string ticker, decimal tradeValue)
        {
            Ticker = ticker;
            TradeValue = tradeValue;
        }

        public string Ticker { get; private set; }
        public decimal TradeValue { get; private set; }
    }
}