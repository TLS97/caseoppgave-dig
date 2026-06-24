namespace Case.Api.Models.Responses;

public class StationInformationResponse
{
    public InformationData Data { get; set; }
}

public class InformationData
{
    public List<StationInformation> Stations { get; set; }

}
public class StationInformation
{
    public string StationId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}