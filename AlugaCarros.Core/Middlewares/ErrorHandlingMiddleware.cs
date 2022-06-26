using Microsoft.AspNetCore.Http;
using Serilog;
using System.Net;

namespace AlugaCarros.Core.Middlewares;
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "There was an Error");

            var code = HttpStatusCode.InternalServerError;

            var result = System.Text.Json.JsonSerializer.Serialize(new { error = ex?.Message });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            await context.Response.WriteAsync(result);
        }
    }
}