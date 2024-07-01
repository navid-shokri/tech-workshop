using EFDualContextTest.DataAccess;
using EFDualContextTest.Models;
using EFDualContextTest.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFDualContextTest.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IPersonRepository _personRepository;
    private readonly OrderDbContext _dbContext;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IPersonRepository personRepository, OrderDbContext dbContext, ILogger<WeatherForecastController> logger)
    {
        _personRepository = personRepository;
        _dbContext = dbContext;
        _logger = logger;
    }

    [HttpDelete]
    public ActionResult FlushDb()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreatePerson()
    {
        Person person = new Person("navid", "shokri"); 
        person.AddOrder(new Order
        {
            TotalPrice = 200
        });
        person.AddOrder(new Order
        {
            TotalPrice = 300
        });
        person.AddOrder(new Order
        {
            TotalPrice = 400
        });
        await _personRepository.AddAsync(person);
        return Ok(person.Id);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Person>> GetPerson([FromRoute] Guid id)
    {

        var person = await _personRepository.GetByIdAsync(id);
        return Ok(person);
    }

    [HttpPut("{personId:guid}")]
    public async Task<ActionResult<Guid>> AddOrder([FromRoute] Guid personId)
    {
        var id = Guid.NewGuid();
        var person= await _personRepository.GetByIdAsync(personId);
        person.AddOrder(new Order
        {
            TotalPrice = Random.Shared.Next(1000, 1555),
            Id = id
        });
        await _personRepository.UpdateAsync(person);
        return Ok(id);
    }
    
    [HttpPut("{personId:guid}/address")]
    public async Task<ActionResult<Guid>> SetAddress([FromRoute] Guid personId)
    {
        var person = await _personRepository.GetByIdAsync(personId);
        person.Name = "Name" + Random.Shared.Next(1, 1000);
        person.Family = "Family" + Random.Shared.Next(1, 1000);
        person.SetAddress(" Iran", $"amnesia alley {DateTime.Now.Minute}-{DateTime.Now.Minute}");
        await _personRepository.UpdateAsync(person);
        return Ok();
    }
    
    
    [HttpGet("{id:guid}/remove/{orderid:guid}")]
    public async Task<ActionResult<Guid>> UpdatePerson([FromRoute] Guid id, [FromRoute] Guid orderid)
    {
        var person = await _personRepository.GetByIdAsync(id);
        person.RemoveOrder(orderid);
        await _personRepository.UpdateAsync(person);
        return Ok(person.Id);
    }
}