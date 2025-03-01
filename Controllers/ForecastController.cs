using Microsoft.AspNetCore.Mvc;
using Weather.Data;
using Weather.Models;

namespace Weather.Controllers;

[ApiController]
[Route("api/forecast")]
public class ForecastController : ControllerBase{
    private readonly AppDbContext _db;
    public ForecastController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost("CreateLocation")]
    public async Task<ActionResult<Location>> CreateLocation(Location location)
    {
        _db.Locations.Add(location);
        await _db.SaveChangesAsync();
        return Ok(location);
    }
}