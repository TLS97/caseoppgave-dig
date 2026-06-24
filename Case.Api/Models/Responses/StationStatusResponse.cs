namespace Case.Api.Models.Responses;

public class StationStatusResponse
{
    public StatusData Data { get; set; }
}

public class StatusData
{
    public List<StationStatus> Stations { get; set; }
}

public class StationStatus
{
    public string StationId { get; set; }
    public int NumBikesAvailable { get; set; }
    public int NumDocksAvailable { get; set; }
}
