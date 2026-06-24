using Case.Api.Clients;
using Case.Api.Models.DTOs;

namespace Case.Api.Services;

public class OsloBysykkelService : IOsloBysykkelService
{
    private readonly IOsloBysykkelApiClient _apiClient;

    public OsloBysykkelService(IOsloBysykkelApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<StationDTO>> GetStationsAsync()
    {
        var stationStatusTask = _apiClient.GetStationStatusAsync();
        var stationInformationTask = _apiClient.GetStationInformationAsync();

        await Task.WhenAll(stationStatusTask, stationInformationTask);

        var stationStatus = await stationStatusTask;
        var stationInfo = await stationInformationTask;

        var infoLookup = stationInfo.Data.Stations.ToDictionary(s => s.StationId);
        var stations = stationStatus.Data.Stations.Select(s =>
        {
            infoLookup.TryGetValue(s.StationId, out var info);

            return new StationDTO
            {
                StationId = s.StationId,
                NumBikesAvailable = s.NumBikesAvailable,
                NumDocksAvailable = s.NumDocksAvailable,
                Name = info?.Name,
                Address = info?.Address,
            };
        }).ToList();

        return stations;
    }
}
