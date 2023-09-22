using EnsureThat;
using LondonStockAPI.Domain.Dtos;
using LondonStockAPI.Domain.Exceptions;
using LondonStockAPI.Domain.Features.Queries;
using LondonStockAPI.Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LondonStockAPI.Application.Features.Stocks.QueryHandlers;

public sealed class GetStockCurrentPriceHandler : IRequestHandler<GetStockCurrentPrice, StockCurrentPriceDto>
{
    private readonly IDbContextFactory<DomainContext> _contextFactory;

    public GetStockCurrentPriceHandler(IDbContextFactory<DomainContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<StockCurrentPriceDto> Handle(GetStockCurrentPrice query, CancellationToken cancellationToken)
    {
        EnsureArg.IsNotNull(query);

        using var context = _contextFactory.CreateDbContext();
        var stock = await context.Stocks
            .Include(s => s.StockTransactions)
            .FirstOrDefaultAsync(s => s.TickerSymbol == query.TickerSymbol, cancellationToken: cancellationToken)
            .ConfigureAwait(false)
            ?? throw new StockNotFoundException("Stock not found");

        return new StockCurrentPriceDto
        {
            CurrentPrice = stock.CurrentPrice
        };
    }
}

