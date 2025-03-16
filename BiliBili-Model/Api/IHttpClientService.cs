using BiliBili_Model.Api.Models;

namespace BiliBili_Model.Api;

/// <summary>
/// HTTP客户端服务接口
/// </summary>
public interface IHttpClientService
{
    /// <summary>
    /// 发送GET请求
    /// </summary>
    /// <typeparam name="T">返回数据类型</typeparam>
    /// <param name="url">请求URL</param>
    /// <param name="headers">可选的额外请求头</param>
    /// <returns>API响应</returns>
    Task<ApiResponse<T>> GetAsync<T>(string url, Dictionary<string, string>? headers = null);
    
    /// <summary>
    /// 发送POST请求（JSON内容）
    /// </summary>
    /// <typeparam name="TRequest">请求数据类型</typeparam>
    /// <typeparam name="TResponse">响应数据类型</typeparam>
    /// <param name="url">请求URL</param>
    /// <param name="data">请求数据</param>
    /// <param name="headers">可选的额外请求头</param>
    /// <returns>API响应</returns>
    Task<ApiResponse<TResponse>> PostJsonAsync<TRequest, TResponse>(string url, TRequest data, Dictionary<string, string>? headers = null);
    
    /// <summary>
    /// 发送表单POST请求
    /// </summary>
    /// <typeparam name="T">返回数据类型</typeparam>
    /// <param name="url">请求URL</param>
    /// <param name="formData">表单数据</param>
    /// <param name="headers">可选的额外请求头</param>
    /// <returns>API响应</returns>
    Task<ApiResponse<T>> PostFormAsync<T>(string url, Dictionary<string, string> formData, Dictionary<string, string>? headers = null);
} 