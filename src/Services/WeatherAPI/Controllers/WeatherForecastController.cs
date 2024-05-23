using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace Api.Controllers;

[ApiController]
[Route("api/WeatherForecast")]
[Authorize]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("usa")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes:Write")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Region = "USA",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
    
    [HttpGet("sahara")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes:Read")]
    public IEnumerable<WeatherForecast> GetDesertForecast()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Region = "Sahara",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(80, 120),
                Summary = "Scorching"
            })
            .ToArray();
    }

    [HttpGet("headers")]
    public ActionResult GetHeaders(){
        var headers = Request.Headers
            .Select(x => $"{x.Key}: {x.Value}")
            .ToArray();

        return Ok(headers);
    }
}
