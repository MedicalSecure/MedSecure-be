namespace Sensor.API.Endpoints.Sensor;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/sensor")]
public class SensorDataController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public SensorDataController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var sensorData = _dbContext.SensorData.ToList();
        return Ok(sensorData);
    }
}
