using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace AlugaCarros.Core.Middlewares;

public class LoggingRequestMiddleware
{
    private readonly RequestDelegate next;

    public LoggingRequestMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        var correlationIdKey = "x-correlation-id";
        var headerCorrelationId = context.Request.Headers[correlationIdKey];
        var correlationId = string.IsNullOrEmpty(headerCorrelationId.ToString()) ? Guid.NewGuid().ToString() : headerCorrelationId.ToString();
        LogContext.PushProperty(correlationIdKey, correlationIdKey);

        await next(context);
    }
}