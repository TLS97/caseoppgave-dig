using Case.Api.Models.Responses;
using System.Text.Json;

namespace Case.Api.Clients;

public class OsloBysykkelApiClient : IOsloBysykkelApiClient
{
    private readonly HttpClient _httpClient;
    private static readonly JsonSerializerOptions JsonOptions =
    new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public OsloBysykkelApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("Client-Identifier", "tine-storvoll");
    }

    public async Task<StationStatusResponse> GetStationStatusAsync()
    {
        var request = await _httpClient.GetAsync("station_status.json");

        request.EnsureSuccessStatusCode();

        return await request.Content.ReadFromJsonAsync<StationStatusResponse>(JsonOptions)
            ?? throw new InvalidOperationException("Response was null");
    }

    public async Task<StationInformationResponse> GetStationInformationAsync()
    {
        var request = await _httpClient.GetAsync("station_information.json");

        request.EnsureSuccessStatusCode();

        return await request.Content.ReadFromJsonAsync<StationInformationResponse>(JsonOptions)
            ?? throw new InvalidOperationException("Response was null");
    }
}
