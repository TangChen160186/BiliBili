using System.Text.Json.Serialization;

namespace BiliBili_Model.Api.Models;

public class ApiResponse
{
    [JsonPropertyName("code")] public int Code { get; set; }


    [JsonPropertyName("message")] public string Message { get; set; } = string.Empty;

    [JsonPropertyName("ttl")] public int? Ttl { get; set; }
}

public class ApiResponse<T> : ApiResponse
{
    [JsonPropertyName("data")] public T? Data { get; set; }
}

public class Result
{
    public int Code { get; protected set; }

    public string? ErrorMessage { get; protected set; }

    public bool IsSuccess => Code == 0;

    public static Result Success()
    {
        return new Result { Code = 0 };
    }

    public static Result Fail(string errorMessage, int errorCode = -400)
    {
        return new Result
        {
            Code = errorCode,
            ErrorMessage = errorMessage
        };
    }
}

public class Result<T> : Result
{
    public T? Data { get; private set; }

    public static Result<T> Success(T? data)
    {
        return new Result<T>()
        {
            Code = 0,
            Data = data,
        };
    }

    public new static Result<T> Fail(string errorMessage, int errorCode = -400)
    {
        return new Result<T>
        {
            Code = errorCode,
            ErrorMessage = errorMessage
        };
    }
}