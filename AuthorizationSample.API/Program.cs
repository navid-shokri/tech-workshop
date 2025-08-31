using AuthorizationSample.API;
using EasyNetQ;
using Winton.Extensions.Configuration.Consul;
using Winton.Extensions.Configuration.Consul.Parsers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient("whatsapp", client =>
{
    client.BaseAddress = new Uri("");
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new AttributedEnumConvertor());
});

/*builder.Configuration.AddConsul("Bifrost/appsettings.Development.json", options =>
{
    options.Parser = new JsonConfigurationParser();
    options.ReloadOnChange = true;
    options.ConsulConfigurationOptions = configuration =>
    {
        configuration.Address = new Uri("http://localhost:8500/");
    };
}).Build();*/
builder.Services.Configure<Person>(builder.Configuration.GetSection("appsettings.Development.json:info"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPersonable, LoginOtpService>();
/*builder.Services.AddSingleton<IBus>(provider =>
    RabbitHutch.CreateBus($"username=user;password=password;virtualHost=/;host=localhost:5672"));*/
//builder.Services.AddOtpService<LoginOtpService>(builder.Configuration.GetConnectionString("RedisConnectionString"), "abbas");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
