
using LondonStockAPI.Domain.Dtos;
using System.Net;
using LondonStockAPI.Domain.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockAPI.WebApi.Controllers;

[ApiController]
[Route("api/stock/{tickerSymbol}/transaction")]
public class StockTransactionController : ControllerBase
{
    private readonly IMediator _mediator;

    public StockTransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(StockDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateTransaction(
        string tickerSymbol,
        CreateStockTransaction command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator
            .Send(command.BindParentId(tickerSymbol), cancellationToken)
            .ConfigureAwait(false);
        return Ok(result);
    }
}

