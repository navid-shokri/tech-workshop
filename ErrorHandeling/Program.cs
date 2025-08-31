using System.Buffers;
using System.Net;
using System.Net.Mime;
using System.Text;
using ErrorHandeling;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NEventStore;
using NEventStore.Persistence.Sql;
using NEventStore.Persistence.Sql.SqlDialects;
using NEventStore.Serialization.Json;

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
//builder.Services.AddHostedService<EventStoreService>();
//builder.Services.AddProblemDetails();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();

builder.Services.AddTransient<EventStoreHandler>();
builder.Services.AddSingleton<IStoreEvents>(provider =>
{
    return Wireup.Init()
        .UsingSqlPersistence(new SqlConnectionFactory(builder.Configuration.GetConnectionString("SqlConnectionString")))
        .WithDialect(new MsSqlDialect())
        .InitializeStorageEngine()
        .UsingJsonSerialization()
        .Compress()
        .EncryptWith(Encoding.UTF8.GetBytes("EncryptionKey123"))
        //.HookIntoPipelineUsing(new[] { new AuthorizationPipelineHook() })
        /* DIspatcher has been removed in NEventStore 6.x
        .UsingAsynchronousDispatchScheduler()
        // Example of NServiceBus dispatcher: https://gist.github.com/1311195
        .DispatchTo(new My_NServiceBus_Or_MassTransit_OrEven_WCF_Adapter_Code())
        */
        .Build();
});
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