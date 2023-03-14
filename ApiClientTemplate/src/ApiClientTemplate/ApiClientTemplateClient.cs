using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;
using ApiClientTemplate.Requests;
using ApiClientTemplate.Responses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ApiClientTemplate;

public class ApiClientTemplateClient
{
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;
    
    [ActivatorUtilitiesConstructor]
    public ApiClientTemplateClient(IOptions<ApiClientTemplateOptions> options, HttpClient httpClient) : this(options.Value, httpClient)
    {
    }

    public ApiClientTemplateClient(ApiClientTemplateOptions options, HttpClient? httpClient = null)
    {
        _httpClient = httpClient ?? new HttpClient();
        _httpClient.BaseAddress = new Uri(string.IsNullOrWhiteSpace(options.ApiBaseAddress) ? "https://your_api.com/api/" : options.ApiBaseAddress);
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));

        if (string.IsNullOrWhiteSpace(options.ApiKey))
        {
            throw new ArgumentException(nameof(options.ApiKey));
        }
        _apiKey = options.ApiKey;
    }

    //TODO below sample methods and you can delete them safely
    public async Task<SomeApiResponse> GetAsync(GetRequest request)
    {
        var response = await _httpClient.GetAsync("get").ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var data = JsonSerializer.Deserialize<SomeApiResponse>(responseBody);

        return data;
    }

    public async Task PostAsync(PostRequest request)
    {
        using StringContent jsonContent = new(JsonSerializer.Serialize(request));

        var response = await _httpClient.PostAsync("post", jsonContent).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
}