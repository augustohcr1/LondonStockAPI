using System.Net;
using System.Text;
using LondonStockAPI.Domain.Exceptions;

namespace LondonStockAPI.WebApi.Extensions;

internal static class DomainExceptionHandlingExtension
{
    public static void UseDomainExceptionHandling(this IApplicationBuilder applicationBuilder) =>
        applicationBuilder.Use(HandleDomainException);

    private static async Task HandleDomainException(HttpContext httpContext, Func<Task> next)
    {
        try
        {
            await next();
        }
        catch (LondonStockApiDomainException exception)
        {
            await LogException(httpContext, exception, HttpStatusCode.BadRequest).ConfigureAwait(false);
        }
        catch (StockNotFoundException exception)
        {
            await LogException(httpContext, exception, HttpStatusCode.NotFound).ConfigureAwait(false);
        }
        catch (ArgumentException exception)
        {
            await LogException(httpContext, exception, HttpStatusCode.BadRequest).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            await LogException(httpContext, exception, HttpStatusCode.InternalServerError).ConfigureAwait(false);
        }
    }

    private static async Task LogException(
        HttpContext httpContext,
        Exception exception,
        HttpStatusCode statusCode)
    {
        var loggerFactory = httpContext.RequestServices.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("ApplicationError");

        logger.LogError(exception, "HTTP {statusCode} Error: {exception.Message}", statusCode, exception.Message);

        httpContext.Response.StatusCode = (int)statusCode;
        httpContext.Response.ContentType = "text/plain";

        await httpContext.Response.WriteAsync(exception.Message, Encoding.UTF8).ConfigureAwait(false);
    }
}

