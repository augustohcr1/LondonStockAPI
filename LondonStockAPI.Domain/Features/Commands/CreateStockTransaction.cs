using EnsureThat;
using LondonStockAPI.Domain.Dtos;
using MediatR;

namespace LondonStockAPI.Domain.Features.Commands;

public sealed record CreateStockTransaction : IRequest<StockDto>
{
    public CreateStockTransaction(
        string brokerId,
        decimal numberOfShares,
        decimal price)
    {
        EnsureArg.IsNotNullOrWhiteSpace(brokerId);
        EnsureArg.IsNotDefault(numberOfShares);
        EnsureArg.IsNotDefault(price);

        BrokerId = brokerId;
        NumberOfShares = numberOfShares;
        Price = price;
    }

    public string BrokerId { get; set; }
    public decimal NumberOfShares { get; set; }
    public decimal Price { get; set; }
    public string TickerSymbol { get; private set; } = string.Empty;

    public CreateStockTransaction BindParentId(string tickerSymbol)
    {
        TickerSymbol = tickerSymbol;
        return this;
    }
}

