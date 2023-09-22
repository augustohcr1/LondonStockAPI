namespace LondonStockAPI.Domain.Exceptions;

public class LondonStockApiDomainException : Exception
{
    public LondonStockApiDomainException()
    { }

    public LondonStockApiDomainException(string message)
            : base(message)
    { }

    public LondonStockApiDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}

