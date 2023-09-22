using System.ComponentModel.DataAnnotations.Schema;
using EnsureThat;

namespace LondonStockAPI.Domain;

public class Stock : IAggregateRoot
{
    public const decimal DefaultStockPrice = 100.00M;

    private readonly List<StockTransaction> _stockTransactions = new();

#nullable disable
    private Stock()
    { }
#nullable enable

    public Stock(string tickerSymbol)
    {
        TickerSymbol = tickerSymbol;
    }

    [NotMapped]
    public decimal CurrentPrice => GetCurrentPrice();
    public IReadOnlyCollection<StockTransaction> StockTransactions => _stockTransactions.AsReadOnly();
    public string TickerSymbol { get; set; }

    public void AddTransaction(
        string brokerId,
        decimal numberOfShares,
        decimal price,
        string tickerSymbol)
    {
        EnsureArg.IsNotNullOrWhiteSpace(brokerId);
        EnsureArg.IsNotDefault(numberOfShares);
        EnsureArg.IsNotDefault(price);
        EnsureArg.IsNotNullOrWhiteSpace(tickerSymbol);

        _stockTransactions.Add(new StockTransaction(price, numberOfShares, brokerId, this));
    }

    public decimal GetCurrentPrice()
    {
        if (StockTransactions.Count > 0)
        {
            var totalPrice = StockTransactions.Sum(st => st.Price * st.NumberOfShares);
            var totalShares = StockTransactions.Sum(st => st.NumberOfShares);

            if (totalShares != 0)
            {
                return Math.Round(totalPrice / totalShares, 2);
            }
        }

        return DefaultStockPrice;
    }
}