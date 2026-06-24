namespace Case.Api.Models.DTOs;

public class StationDTO
{
    public string StationId { get; set; }
    public int NumBikesAvailable { get; set; }
    public int NumDocksAvailable { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}
