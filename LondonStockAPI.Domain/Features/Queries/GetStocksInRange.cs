using EnsureThat;
using LondonStockAPI.Domain.Dtos;
using MediatR;

namespace LondonStockAPI.Domain.Features.Queries;

public sealed record GetStocksInRange : IRequest<IEnumerable<StockDto>>
{
    public GetStocksInRange(IEnumerable<string> symbols)
    {
        EnsureArg.IsNotNull(symbols);
        
        Symbols = symbols;
    }

    public IEnumerable<string> Symbols { get; }
}