using AlugaCarros.Core.WebApi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AlugaCarros.Core.WebApi;

public static class HttpClientFactoryExtensions
{
    public static IHttpClientBuilder AddHttpClient(this IServiceCollection services, string httpClientName, string endpoint)
    {
        return services.AddHttpClient(httpClientName, httpClient =>
        {
            httpClient.BaseAddress = new Uri(endpoint);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("charset", "utf-8");
        });
    }

    public static IHttpClientBuilder AddHttpClient<HttpMessageHandler>(this IServiceCollection services, string httpClientName, string endpoint)
        where HttpMessageHandler : DelegatingHandler
    {

        return services.AddHttpClient(httpClientName, httpClient =>
        {
            httpClient.BaseAddress = new Uri(endpoint);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("charset", "utf-8");
        }).AddHttpMessageHandler<HttpMessageHandler>();
    }
}
