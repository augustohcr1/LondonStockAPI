using EnsureThat;

namespace LondonStockAPI.Domain;

public class StockTransaction
{
#nullable disable
    private StockTransaction()
    { }
#nullable enable

    public StockTransaction(
        decimal price,
        decimal numberOfShares,
        string brokerId,
        Stock stock)
    {
        EnsureArg.IsNotDefault(price);
        EnsureArg.IsNotDefault(numberOfShares);
        EnsureArg.IsNotNullOrWhiteSpace(brokerId);
        EnsureArg.IsNotNull(stock);

        Price = price;
        NumberOfShares = numberOfShares;
        BrokerId = brokerId;
        TransactionTimestamp = DateTime.Now;
        Stock = stock;
        TickerSymbol = stock.TickerSymbol;
    }
    
    public string BrokerId { get; set; }
    public Guid Id { get; set; }
    public decimal NumberOfShares { get; set; }
    public decimal Price { get; set; }
    public string TickerSymbol { get; set; }
    public DateTime TransactionTimestamp { get; set; }

    public Stock Stock { get; set; }
}