using Case.Api.Models.Responses;

namespace Case.Api.Clients;

public interface IOsloBysykkelApiClient
{
    Task<StationStatusResponse> GetStationStatusAsync();
    Task<StationInformationResponse> GetStationInformationAsync();
}
