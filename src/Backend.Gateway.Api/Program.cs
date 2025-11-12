using Backend.Gateway.Api.Extensions;
using Backend.Gateway.Api.Middlewares;
using Backend.Gateway.Application.Model;
using Microsoft.Extensions.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

configuration.AddJsonFile("gatewaysettings.json", optional: false, reloadOnChange: true);
    
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddServices(configuration);

var app = builder.Build();

app.UseMiddleware<ApiExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.UseHttpsRedirection();


app.Map("/{**catchall}",
    async (IOptions<GatewaySettings> options,HttpContext context) =>
    {
        var gatewaySettings = options.Value;
        
        
        return gatewaySettings;
    });

app.Run();

