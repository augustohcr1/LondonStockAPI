using LondonStockAPI.Domain.Dtos;
using MediatR;

namespace LondonStockAPI.Domain.Features.Queries;

public sealed record GetAllStocks : IRequest<IEnumerable<StockDto>>
{ }

