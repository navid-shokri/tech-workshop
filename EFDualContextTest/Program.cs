using System.Text.Json.Serialization;
using EFDualContextTest.DataAccess;
using EFDualContextTest.Models;
using EFDualContextTest.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var constr = builder.Configuration.GetConnectionString("OrderDatabase");
builder.Services.AddDbContext<OrderDbContext>(optionsBuilder =>
{
    optionsBuilder.UseMySql(constr,  ServerVersion.AutoDetect(constr));
});
builder.Services.AddTransient<IPersonRepository, PersonRepository>();
builder.Services.AddTransient<ISellerRepository, SellerRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

/*builder.Services.AddDbContext<ProductDbContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlServer(builder.Configuration["ConnectionStrings__ProductDatabase"]);
});*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();