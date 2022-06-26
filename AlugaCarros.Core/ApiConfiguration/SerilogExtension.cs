using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Filters;

namespace AlugaCarros.Core.ApiConfiguration;

public static class SerilogExtension
{
    public static void AddSerilog(this WebApplicationBuilder builder, string applicationName)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithCorrelationId()
            .Enrich.WithProperty("ApplicationName", $"{applicationName}")
            .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
            .WriteTo.Async(wt => wt.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [CorrelationId={CorrelationId}] [Message={Message:lj}] [Properties={Properties:j}]{NewLine}{Exception}"))
            .CreateLogger();

        builder.Host.UseSerilog(Log.Logger);
    }
}