using System.Text;
using MessagePack;
using Microsoft.AspNetCore.Mvc;

namespace NRule.Controllers;

[ApiController]
[Route("[controller]")]
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

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpGet("msg-pack")]
    public async Task<ActionResult> serialize()
    {
        var c = new Child
        {
            Name = "navid",
            Familt = "shokri",
            Hubby = "coding"
        };

        var b = MessagePackSerializer.Serialize(c);
        var str = Convert.ToBase64String(b);
        var t = MessagePackSerializer.Deserialize<Child>(b);
        return Ok(str);
    }
}