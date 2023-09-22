namespace LondonStockAPI.Domain.Dtos;

public sealed class StockDto
{
	public string TickerSymbol { get; set; } = string.Empty;
	public decimal CurrentPrice { get; set; }
}

