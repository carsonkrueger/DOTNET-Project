using System.Net.Http.Json;

namespace MyHttpClient;

public class ApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ApiClient(string baseUrl)
    {
        _httpClient = new HttpClient();
        _baseUrl = baseUrl;
    }

    /// <summary>
    /// Throws on unsuccessful status codes
    /// </summary>
    /// <param name="endpoint"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> GetDataAsync(string endpoint)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{endpoint}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
    }

    /// <summary>
    /// Throws on unsuccessful status codes
    /// </summary>
    /// <param name="endpoint"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> PutJsonDataAsync(string endpoint, JsonContent json)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{endpoint}", json);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
    }

    /// <summary>
    /// Throws on unsuccessful status codes
    /// </summary>
    /// <param name="endpoint"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> PostJsonDataAsync(string endpoint, JsonContent json)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/{endpoint}", json);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
    }
    /// <summary>
    /// Throws on unsuccessful status codes
    /// </summary>
    /// <param name="endpoint"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> PatchJsonDataAsync(string endpoint, JsonContent json)
    {
        var response = await _httpClient.PatchAsJsonAsync($"{_baseUrl}/{endpoint}", json);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
    }

}
