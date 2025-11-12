using Backend.Gateway.Api.Extensions;
using Backend.Gateway.Api.Middlewares;
using Backend.Gateway.Application.Model;
using Microsoft.Extensions.Options;
using Serilog;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

configuration.AddJsonFile("gatewaysettings.json", optional: false, reloadOnChange: true);
configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Logging.ClearProviders();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddServices(configuration);

builder.Services.AddHttpClient();

var app = builder.Build();

app.UseMiddleware<ApiExceptionMiddleware>();


if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.UseHttpsRedirection();


app.Map("/{**catchall}",
    async (IOptions<GatewaySettings> options, HttpContext httpContext, IHttpClientFactory clientFactory) =>
    {
        GatewaySettings gatewaySettings = options.Value;

        var client = clientFactory.CreateClient();
        var method = httpContext.Request.Method;      
        var pathPrefix = httpContext.Request.Path.Value;

        var connection =
            gatewaySettings.Connections.FirstOrDefault(c =>
                c.PathPrefix == pathPrefix && c.AllowedMethods.Contains(method));

        if (connection == null)
        {
            return Results.BadRequest();
        }

        var request = new HttpRequestMessage(new HttpMethod(method),
            connection.Destination + connection.PathPrefix);

        var response = await client.SendAsync(request);
        
        return Results.Ok();
    });

app.Run();

