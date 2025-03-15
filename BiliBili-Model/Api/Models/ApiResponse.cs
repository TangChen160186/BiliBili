using System.Text.Json.Serialization;

namespace BiliBili_Model.Api.Models;

/// <summary>
/// 哔哩哔哩API通用响应模型
/// </summary>
/// <typeparam name="T">数据类型</typeparam>
public class ApiResponse<T>
{
    /// <summary>
    /// 状态码，0表示成功
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }
    
    /// <summary>
    /// 消息
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
    
    /// <summary>
    /// 响应数据
    /// </summary>
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    
    /// <summary>
    /// 是否成功
    /// </summary>
    public bool IsSuccess => Code == 0;
} 