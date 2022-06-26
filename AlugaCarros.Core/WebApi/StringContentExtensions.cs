using System.Text;
using System.Text.Json;

namespace AlugaCarros.Core.WebApi;

public static class StringContentExtensions
{
    public static StringContent ToStringContent(this object dado)
    {
        return new StringContent(
            JsonSerializer.Serialize(dado),
            Encoding.UTF8,
            "application/json");
    }
}