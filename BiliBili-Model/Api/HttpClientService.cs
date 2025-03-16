using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using BiliBili_Model.Api.Models;

namespace BiliBili_Model.Api;

/// <summary>
/// HTTP客户端服务，处理所有API请求的基础类
/// </summary>
public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36 Edg/134.0.0.0");
        
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };
    }

    /// <summary>
    /// 发送GET请求
    /// </summary>
    /// <typeparam name="T">返回数据类型</typeparam>
    /// <param name="url">请求URL</param>
    /// <param name="headers">可选的额外请求头</param>
    /// <returns>API响应</returns>
    public async Task<ApiResponse<T>> GetAsync<T>(string url, Dictionary<string, string>? headers = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        
        if (headers != null)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }
        using var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(content, _jsonOptions);
        return apiResponse!;
    }

    /// <summary>
    /// 发送POST请求（JSON内容）
    /// </summary>
    /// <typeparam name="TRequest">请求数据类型</typeparam>
    /// <typeparam name="TResponse">响应数据类型</typeparam>
    /// <param name="url">请求URL</param>
    /// <param name="data">请求数据</param>
    /// <param name="headers">可选的额外请求头</param>
    /// <returns>API响应</returns>
    public async Task<ApiResponse<TResponse>> PostJsonAsync<TRequest, TResponse>(string url, TRequest data, Dictionary<string, string>? headers = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        
        if (headers != null)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }
        
        var json = JsonSerializer.Serialize(data, _jsonOptions);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        
        using var response = await _httpClient.SendAsync(request);
        
        var content = await response.Content.ReadAsStringAsync();
        
        var apiResponse = JsonSerializer.Deserialize<ApiResponse<TResponse>>(content, _jsonOptions);
        return apiResponse!;
    }

    /// <summary>
    /// 发送表单POST请求
    /// </summary>
    /// <typeparam name="T">返回数据类型</typeparam>
    /// <param name="url">请求URL</param>
    /// <param name="formData">表单数据</param>
    /// <param name="headers">可选的额外请求头</param>
    /// <returns>API响应</returns>
    public async Task<ApiResponse<T>> PostFormAsync<T>(string url, Dictionary<string, string> formData, Dictionary<string, string>? headers = null)
    {
        var content = new FormUrlEncodedContent(formData);
        
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = content
        };
        
        if (headers != null)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        using var response = await _httpClient.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();
        
        var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(responseContent, _jsonOptions);
        return apiResponse!;
    }
} 