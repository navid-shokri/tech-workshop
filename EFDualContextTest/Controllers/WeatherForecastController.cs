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
    private readonly IProductRepository _productRepository;
    private readonly ISellerRepository _sellerRepository;
    private readonly OrderDbContext _dbContext;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IPersonRepository personRepository, OrderDbContext dbContext, ILogger<WeatherForecastController> logger, ISellerRepository sellerRepository, IProductRepository productRepository)
    {
        _personRepository = personRepository;
        _dbContext = dbContext;
        _logger = logger;
        _sellerRepository = sellerRepository;
        _productRepository = productRepository;
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
        person.AddOrder(new Order(200));
        person.AddOrder(new Order(300));
        person.AddOrder(new Order(400));
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
        person.AddOrder(new Order(Random.Shared.Next(1000, 1555)));
        await _personRepository.UpdateAsync(person);
        return Ok(id);
    }
    
    [HttpPut("{personId:guid}/address")]
    public async Task<ActionResult<Guid>> SetAddress([FromRoute] Guid personId)
    {
        var person = await _personRepository.GetByIdAsync(personId);
        person.SetPersonalInfo("Name" + Random.Shared.Next(1, 1000),"Family" + Random.Shared.Next(1, 1000));
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
    
    
    [HttpPost("product")]
    public async Task<ActionResult<Guid>> AddProduct()
    {
        var product = new Product
        {
            Title = "Product1",
            Price = 1200
        }; 
        await _productRepository.AddAsync(product);
        return Ok(product.Id);
    }
    
    [HttpPost("seller/{productId:guid}")]
    public async Task<ActionResult<Guid>> AddSeller([FromRoute] Guid productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        var seller = new Seller
        {
            Address = "shahmirzad",
            Product = product,
            ProductId = productId
        };
        await _sellerRepository.AddAsync(seller);
        return Ok(product.Id);
    }
}