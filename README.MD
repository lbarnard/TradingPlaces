Scenario

You are a developer in an Agile development team at “Trading Places”, a small but growing hedge fund, and you have been assigned to work on one of the numerous trading strategies. 
Trading Places uses a small broker ‘Reutberg’ for issuing price quotes and executing trades.

Instructions

Your task is to write an implementation of ITradingStrategy. This implementation should request price quotes from Reutberg, and execute a buy trade if the price drops by a user specified percentage figure of the first quoted price. 
You may reference any free to use external libraries of your choice. 
You have 45 minutes to complete the test.

Resources

You have been provided with two assemblies:
TradingPlaces.Resources.dll 
Contains the ITradingStrategy to implement, and related classes.

Reutberg.dll

Third party library, containing the service to connect to Reutberg infrastructure, issue price quotes and execute trades. 
For simplicity, this library assumes all prices are USD.

There are 3 main methods available:

decimal GetQuote(string ticker): Returns the current price for the specified ticker
decimal Buy(string ticker, int quantity) : Executes a buy trade for the specified ticker and amount, and returns the value of the trade.
decimal Sell(string ticker, int quantity) : Executes a sell  trade for the specified ticker and amount, and returns the value of the trade.