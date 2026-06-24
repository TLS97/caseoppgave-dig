using Case.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Case.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OsloBysykkelController : ControllerBase
{
    private readonly IOsloBysykkelService _service;

    public OsloBysykkelController(IOsloBysykkelService service)
    {
        _service = service;
    }

    [HttpGet("stations")]
    public async Task<IActionResult> GetStations()
    {
        var result = await _service.GetStationsAsync();
        return Ok(result);
    }
}
