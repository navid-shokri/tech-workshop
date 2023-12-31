using ErrorHandeling.Model;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandeling.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult<IEnumerable<WeatherForecast>> Get()
    {
        throw new Exception();
    }

    [HttpPost]
    public IActionResult Add(AddRequestDto dto)
    {
        return Ok(dto.First + dto.Second);
    }

    [HttpGet("bad-request")]
    public IActionResult TestAgain()
    {
        return BadRequest();
    }

    [Route("/error")]
    [HttpGet]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult HandleError()
    {
        return Problem();
        //return BadRequest(new { IsSuccess = false});
    }

}