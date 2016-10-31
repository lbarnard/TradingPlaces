namespace TradingPlaces.Resources
{
    public interface ITradingStrategy
    {
        TradingStrategyResult ExecuteStrategy(string ticker, decimal quantity);
    }
}