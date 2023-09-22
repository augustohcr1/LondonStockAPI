using System.Net;
using LondonStockAPI.Domain.Dtos;
using LondonStockAPI.Domain.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockAPI.WebApi.Controllers;

[ApiController]
[Route("api/stocks")]
public class StocksController : ControllerBase
{
    private readonly IMediator _mediator;

    public StocksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{tickerSymbol}")]
    [ProducesResponseType(typeof(StockCurrentPriceDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetCurrentStockPrice(string tickerSymbol, CancellationToken cancellationToken)
    {
        var result = await _mediator
            .Send(new GetStockCurrentPrice(tickerSymbol), cancellationToken)
            .ConfigureAwait(false);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StockDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAllStocks(CancellationToken cancellationToken)
    {
        var result = await _mediator
            .Send(new GetAllStocks(), cancellationToken)
            .ConfigureAwait(false);
        return Ok(result);
    }

    [HttpGet("range")]
    [ProducesResponseType(typeof(IEnumerable<StockDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetStocksInRange([FromQuery] List<string> symbols, CancellationToken cancellationToken)
    {
        var result = await _mediator
            .Send(new GetStocksInRange(symbols), cancellationToken)
            .ConfigureAwait(false);
        return Ok(result);
    }
}
