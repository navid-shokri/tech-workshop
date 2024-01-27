using Microsoft.AspNetCore.Mvc;

namespace AuthorizationSample.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
   private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [TypeFilter(typeof(SnappAuthorizationAttribute))]
    public async Task<ActionResult> TestToken()
    {
        var user = (UserData)HttpContext.Items["User"];
        return Ok(user);
    }
}
