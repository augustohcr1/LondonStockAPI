using EnsureThat;
using LondonStockAPI.Domain.Dtos;
using MediatR;

namespace LondonStockAPI.Domain.Features.Queries;

public sealed record GetStockCurrentPrice : IRequest<StockCurrentPriceDto> 
{
	public GetStockCurrentPrice(string tickerSymbol)
	{
		EnsureArg.IsNotNullOrWhiteSpace(tickerSymbol);

		TickerSymbol = tickerSymbol;
	}

	public string TickerSymbol { get; }
}

