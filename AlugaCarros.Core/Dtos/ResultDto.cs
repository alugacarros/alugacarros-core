namespace AlugaCarros.Core.Dtos;

public struct ResultDto
{
    public ResultDto(string message, bool fail)
    {
        Message = message;
        Fail = fail;
    }

    public string Message { get; set; }
    public bool Fail { get; set; }
    public static ResultDto Success(string message = "") => new ResultDto(message, false);
    public static ResultDto Failed(string message = "") => new ResultDto(message, true);
}

public struct ResultDto<TData>
    where TData : class
{
    public ResultDto(TData data, string message, bool fail)
    {
        Data = data;
        Message = message;
        Fail = fail;
    }

    public TData Data { get; set; }
    public string Message { get; set; }
    public bool Fail { get; set; }

    public static ResultDto<TData> Success(TData data, string message = "") => new ResultDto<TData>(data, message, false);
    public static ResultDto<TData> Failed(string message = "") => new(data: null, message, true);
}