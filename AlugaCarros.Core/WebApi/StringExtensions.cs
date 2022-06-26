using System.Text.Json;

namespace AlugaCarros.Core.WebApi;

public static class StringExtensions
{
    public static T Deserialize<T>(this string responseMessage)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<T>(responseMessage, options);
    }
}