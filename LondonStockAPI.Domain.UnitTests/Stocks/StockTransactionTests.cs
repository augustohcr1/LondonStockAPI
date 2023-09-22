namespace LondonStockAPI.Domain.UnitTests.Stocks;

public class StockTransactionTests
{
    [Fact]
    public void Constructor_WithValidData_ShouldInitializeTransaction()
    {
        // Arrange & Act
        var stock = new Stock("AAPL");
        var transaction = new StockTransaction(150.0M, 10, "broker1", stock);

        // Assert
        Assert.NotNull(transaction);
        Assert.Equal("broker1", transaction.BrokerId);
        Assert.Equal(10, transaction.NumberOfShares);
        Assert.Equal(150.0M, transaction.Price);
        Assert.Equal("AAPL", transaction.TickerSymbol);
    }

    [Fact]
    public void Constructor_WithInvalidPrice_ShouldThrowArgumentException()
    {
        // Arrange
        var stock = new Stock("AAPL");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new StockTransaction(0, 10, "broker1", stock));
    }

    [Fact]
    public void Constructor_WithInvalidNumberOfShares_ShouldThrowArgumentException()
    {
        // Arrange
        var stock = new Stock("AAPL");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new StockTransaction(150.0M, 0, "broker1", stock));
    }

    [Fact]
    public void Constructor_WithEmptyBrokerId_ShouldThrowArgumentException()
    {
        // Arrange
        var stock = new Stock("AAPL");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new StockTransaction(150.0M, 10, "", stock));
    }
}

