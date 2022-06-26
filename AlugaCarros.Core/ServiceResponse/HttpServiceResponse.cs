using System.Net;

namespace AlugaCarros.Core.ServiceResponse;
public struct HttpResultDto
{
    public HttpResultDto(HttpStatusCode statusCode, string message, bool fail)
    {
        StatusCode = statusCode;
        Message = message;
        Fail = fail;
    }

    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public bool Fail { get; set; }
    public static HttpResultDto Success(HttpStatusCode statusCode, string message = "") => new HttpResultDto(statusCode, message, false);
    public static HttpResultDto Failed(HttpStatusCode statusCode, string message = "") => new HttpResultDto(statusCode, message, true);
}

public struct HttpResultDto<TData>
    where TData : class
{
    public HttpResultDto(TData data, HttpStatusCode statusCode, string message, bool fail)
    {
        Data = data;
        StatusCode = statusCode;
        Message = message;
        Fail = fail;
    }

    public TData Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public bool Fail { get; set; }
    public static HttpResultDto<TData> Success(HttpStatusCode statusCode, TData data, string message = "") => new HttpResultDto<TData>(data, statusCode, message, false);
    public static HttpResultDto<TData> Failed(HttpStatusCode statusCode, string message = "") => new HttpResultDto<TData>(data: null, statusCode, message, true);
}