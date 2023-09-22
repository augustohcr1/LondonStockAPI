namespace LondonStockAPI.Domain.UnitTests.Stocks;

public class StockTests
{
    [Fact]
    public void Constructor_WithValidTickerSymbol_ShouldInitializeStock()
    {
        // Arrange & Act
        var stock = new Stock("AAPL");

        // Assert
        Assert.NotNull(stock);
        Assert.Equal("AAPL", stock.TickerSymbol);
        Assert.Empty(stock.StockTransactions);
        Assert.Equal(Stock.DefaultStockPrice, stock.CurrentPrice);
    }

    [Fact]
    public void AddTransaction_WithValidData_ShouldAddTransactionToStock()
    {
        // Arrange
        var stock = new Stock("AAPL");

        // Act
        stock.AddTransaction("broker1", 10, 150.0M, "AAPL");

        // Assert
        Assert.Single(stock.StockTransactions);
        var transaction = stock.StockTransactions.First();
        Assert.Equal("broker1", transaction.BrokerId);
        Assert.Equal(10, transaction.NumberOfShares);
        Assert.Equal(150.0M, transaction.Price);
    }

    [Fact]
    public void GetCurrentPrice_WithTransactions_ShouldCalculateCorrectCurrentPrice()
    {
        // Arrange
        var stock = new Stock("AAPL");
        stock.AddTransaction("broker1", 10, 150.0M, "AAPL");
        stock.AddTransaction("broker2", 5, 160.0M, "AAPL");

        // Act
        var currentPrice = stock.GetCurrentPrice();

        // Assert
        Assert.Equal(153.33M, currentPrice); // (10 * 150.0M + 5 * 160.0M) / (10 + 5) = (1500.0M + 800.0M) / 15 = 2300.0M / 15 = 153.33M
    }

    [Fact]
    public void GetCurrentPrice_WithoutTransactions_ShouldReturnDefaultPrice()
    {
        // Arrange
        var stock = new Stock("AAPL");

        // Act
        var currentPrice = stock.GetCurrentPrice();

        // Assert
        Assert.Equal(Stock.DefaultStockPrice, currentPrice); // Default price
    }
}


