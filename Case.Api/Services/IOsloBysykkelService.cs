using Case.Api.Models.DTOs;

namespace Case.Api.Services;

public interface IOsloBysykkelService
{
    Task<List<StationDTO>> GetStationsAsync();
}
