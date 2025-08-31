using Bogus;
using EasyNetQ;
using EasyNetQ.Topology;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Logging;
using SnappFood.Clays.Cache;
using SnappFood.Clays.OTP.Models;
using SnappFood.Clays.OTP.Service;

namespace AuthorizationSample.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IBus _bus;
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IPrefixedDistributedCache _cache;
    private readonly IGenericOtpService<OtpModel> otp;
    private readonly IGenericOtpService<LoginOtpModel> _loginotp;
    private readonly Faker faker;
    private readonly IPersonable _personable;
    public WeatherForecastController(IHttpClientFactory httpClientFactory, IPersonable personable, IBus bus, ILogger<WeatherForecastController> logger)
    {
        _httpClientFactory = httpClientFactory;
        _bus = bus;
        _logger = logger;
        faker = new Faker();
        _personable = personable;
    }


    [HttpPost ("/whatsapp")]

    public async Task<ActionResult<string>> SendWhatsAppMessage()
    {
        return Ok(_personable.GetFullName());
    }

    [HttpGet("test")]
    public async Task<ActionResult> Opps()
    {
        var myotp = new OtpModel("09128317648", 2);
        await otp.SetOtpAsync(myotp);
        var strCount = await _cache.GetStringAsync("CallCounter");
        var count = strCount == null ? 1 : int.Parse(strCount);
        await _cache.SetStringAsync("CallCounter", $"{count + 1}");
        return Ok($"{count}:{myotp.Id}");
    }

    [HttpPost("test")]
    public async Task<ActionResult> OppsVer([FromBody] verify ver)
    {
        var verifyOtpAsync = await otp.VerifyOtpAsync(ver.Id, ver.val, ver.Phone);
        return verifyOtpAsync ? Ok() : BadRequest();

    }
    
    [HttpGet("logintest/{phone}")]
    public async Task<ActionResult> loginOppsVer([FromRoute] string phone)
    {
        var login = new LoginOtpModel(phone);
        await _loginotp.SetOtpAsync(login);
        return Ok(login);

    }

    [HttpGet("msg")]
    public async Task<ActionResult> publishAsync()
    {
        
        var msg = new OrderStatusChangeEvent
        {
            Code = faker.Random.AlphaNumeric(6),
            ClientOrderId = faker.Random.Int(0,100000000),
            Status = faker.Random.ListItem(new List<string>
            {
                "ACK",
                "REQUESTED",
                "PICKED",
                "DELIVERED"
            }),
            BikerId = faker.Random.Int(100,
                1220),
            BikerCellPhone = faker.Phone.PhoneNumber("09#########"),
            BikerName = faker.Name.FullName(),
            IsSnappboxFleet = faker.Random.Bool(),
            BikerImageUrl = null,
            PaymentType = faker.Random.ListItem(new List<string>
            {
                "online",
                "cash",
                "round_trip",
            }),
            StatusCode = faker.Random.Word(),
            BikerToVendorRideTime = faker.Random.Int(2,11),
            VendorToCustomerRideTime = faker.Random.Int(2,11)
        };
        var exchange = new Exchange("update_bordar_trip_status");
        await _bus.Advanced.PublishAsync(exchange, string.Empty, false, new Message<OrderStatusChangeEvent>(msg));
        return Ok();
    }

    public class OrderStatusChangeEvent
    {
        public string Code  { get; set; }
        public int? ClientOrderId  { get; set; }
        public string Status { get; set; }
        public int? BikerId { get; set; }
        public string? BikerCellPhone { get; set; }
        public string? BikerName { get; set; }
        public bool? IsSnappboxFleet  { get; set; }
        public string? BikerImageUrl { get; set; }
        public string? PaymentType { get; set; }
        public string StatusCode { get; set; }
        public int? BikerToVendorRideTime { get; set; }
        public int? VendorToCustomerRideTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
    public class verify
    {
        public string Id { get; set; }
        public string val { get; set; }
        public string Phone { get; set; }
    }

    
}
