using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

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
        
        // 配置默认请求头
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
        
        // 配置JSON序列化选项
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
    /// <returns>API响应数据</returns>
    public async Task<T?> GetAsync<T>(string url, Dictionary<string, string>? headers = null)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        
        // 添加额外的请求头
        if (headers != null)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        using var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content, _jsonOptions);
    }

    /// <summary>
    /// 发送POST请求
    /// </summary>
    /// <typeparam name="TRequest">请求数据类型</typeparam>
    /// <typeparam name="TResponse">响应数据类型</typeparam>
    /// <param name="url">请求URL</param>
    /// <param name="data">请求数据</param>
    /// <param name="headers">可选的额外请求头</param>
    /// <returns>API响应数据</returns>
    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data, Dictionary<string, string>? headers = null)
    {
        var json = JsonSerializer.Serialize(data, _jsonOptions);
        using var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        using var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = content
        };
        
        // 添加额外的请求头
        if (headers != null)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        using var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
    }

    /// <summary>
    /// 发送表单POST请求
    /// </summary>
    /// <typeparam name="TResponse">响应数据类型</typeparam>
    /// <param name="url">请求URL</param>
    /// <param name="formData">表单数据</param>
    /// <param name="headers">可选的额外请求头</param>
    /// <returns>API响应数据</returns>
    public async Task<TResponse?> PostFormAsync<TResponse>(string url, Dictionary<string, string> formData, Dictionary<string, string>? headers = null)
    {
        using var content = new FormUrlEncodedContent(formData);
        
        using var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = content
        };
        
        // 添加额外的请求头
        if (headers != null)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        using var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
    }
} 