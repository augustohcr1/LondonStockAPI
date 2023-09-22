using LondonStockAPI.Domain;
using LondonStockAPI.Domain.Dtos;

namespace LondonStockAPI.Application.Features.Stocks.Mappings;

internal sealed class StockProfile: AutoMapper.Profile
{
	public StockProfile()
	{
		CreateMap<Stock, StockDto>()
			.ForMember(
				dto => dto.TickerSymbol,
				opt => opt.MapFrom(stock => stock.TickerSymbol))
			.ForMember(
				dto => dto.CurrentPrice,
				opt => opt.MapFrom(stock => stock.CurrentPrice));
    }
}

