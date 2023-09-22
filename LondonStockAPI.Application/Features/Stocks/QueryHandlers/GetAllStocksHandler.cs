using AutoMapper;
using LondonStockAPI.Domain.Dtos;
using LondonStockAPI.Domain.Features.Queries;
using LondonStockAPI.Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LondonStockAPI.Application.Features.Stocks.QueryHandlers;

public sealed class GetAllStocksHandler : IRequestHandler<GetAllStocks, IEnumerable<StockDto>>
{
    private readonly IDbContextFactory<DomainContext> _contextFactory;
    private readonly IMapper _mapper;

    public GetAllStocksHandler(IDbContextFactory<DomainContext> contextFactory, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StockDto>> Handle(GetAllStocks request, CancellationToken cancellationToken)
    {
        using var context = await _contextFactory.CreateDbContextAsync(cancellationToken).ConfigureAwait(false);
        var stocks = await context.Stocks
            .Include(s => s.StockTransactions)
            .ToListAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<IEnumerable<StockDto>>(stocks);
    }
}

