using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;

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
    //[TypeFilter(typeof(SnappAuthorizationAttribute))]
    public async Task<ActionResult> TestToken()
    {
        _logger.LogError("correlation Id is: {@id}", HttpContext.TraceIdentifier);
        var user = (UserData)HttpContext.Items["User"];
        return Ok(user);
    }
    
    [HttpPost("test")]
    public async Task<ActionResult> Opps()
    {
        var t =HttpContext.Request.Headers["Authorization"].FirstOrDefault();
        var user = (UserData)HttpContext.Items["User"];
        return Ok(user);
    }
}
