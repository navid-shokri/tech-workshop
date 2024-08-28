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
    
    
    [HttpPost("test")]
    public async Task<ActionResult> Opps([FromBody] rq rq)
    {
        var t =HttpContext.Request.Headers["Authorization"].FirstOrDefault();
        var user = (UserData)HttpContext.Items["User"];
        return Ok(user);
    }
}
