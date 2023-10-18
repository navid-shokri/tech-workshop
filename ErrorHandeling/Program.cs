using System.Buffers;
using System.Net;
using System.Net.Mime;
using ErrorHandeling;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
})
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressMapClientErrors = true;
        options.InvalidModelStateResponseFactory = context =>
        {
            var code = 5;
            var messages = context.ModelState.Select(x => $"{string.Join("|",x.Value.Errors.Select(x=>x.ErrorMessage))}");
            return new BadRequestObjectResult(new {code, messages})
            {
                ContentTypes =
                {
                    MediaTypeNames.Application.Json,
                    MediaTypeNames.Application.Xml,
                }
            };
        };
    });
//builder.Services.AddProblemDetails();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
}

//app.UseExceptionHandler();
//app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
