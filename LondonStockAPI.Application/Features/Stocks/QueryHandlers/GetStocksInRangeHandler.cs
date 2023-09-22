using AutoMapper;
using LondonStockAPI.Domain.Dtos;
using LondonStockAPI.Domain.Features.Queries;
using LondonStockAPI.Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LondonStockAPI.Application.Features.Stocks.QueryHandlers;

public sealed class GetStocksInRangeHandler : IRequestHandler<GetStocksInRange, IEnumerable<StockDto>>
{
    private readonly IDbContextFactory<DomainContext> _contextFactory;
    private readonly IMapper _mapper;

    public GetStocksInRangeHandler(IDbContextFactory<DomainContext> contextFactory, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StockDto>> Handle(GetStocksInRange query, CancellationToken cancellationToken)
    {
        using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var stocks = await context.Stocks
            .Include(s => s.StockTransactions)
            .Where(s => query.Symbols.Contains(s.TickerSymbol))
            .ToListAsync(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return _mapper.Map<IEnumerable<StockDto>>(stocks);
    }
}

