using AutoMapper;
using LondonStockAPI.Domain;
using LondonStockAPI.Domain.Dtos;
using LondonStockAPI.Domain.Features.Commands;
using LondonStockAPI.Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LondonStockAPI.Application.Features.Stocks.CommandHandler;

public class CreateStockTransactionHandler : IRequestHandler<CreateStockTransaction, StockDto>
{
    private readonly IDbContextFactory<DomainContext> _contextFactory;
    private readonly IMapper _mapper;


    public CreateStockTransactionHandler(IDbContextFactory<DomainContext> contextFactory, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
    }


    public async Task<StockDto> Handle(CreateStockTransaction command, CancellationToken cancellationToken)
    {
        using var context = await _contextFactory.CreateDbContextAsync(cancellationToken).ConfigureAwait(false);
        var stock = await context.Stocks
            .Include(s => s.StockTransactions)
            .Where(s => s.TickerSymbol == command.TickerSymbol)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);


        if(stock is null)
        {
            stock = new Stock(command.TickerSymbol);
            await context.Stocks.AddAsync(stock, cancellationToken).ConfigureAwait(false);
        }

        stock.AddTransaction(
               command.BrokerId,
               command.NumberOfShares,
               command.Price,
               command.TickerSymbol);


        await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<StockDto>(stock);
    }
}

