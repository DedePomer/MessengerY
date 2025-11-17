using System.Net.Http.Headers;
using System.Text;
using Backend.Gateway.Api.Extensions;
using Backend.Gateway.Api.Middlewares;
using Backend.Gateway.Application.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

configuration.AddJsonFile("endpoints.json", optional: false, reloadOnChange: true);
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
    async (IOptions<Endpoints> options, HttpContext httpContext, IHttpClientFactory clientFactory) =>
    {
        Endpoints endpoints = options.Value;

        var client = clientFactory.CreateClient();
        var method = httpContext.Request.Method;      
        var pathPrefix = httpContext.Request.Path.Value;

        var connection =
            endpoints.Connections.FirstOrDefault(c =>
                c.PathPrefix == pathPrefix && c.AllowedMethods.Contains(method));

        if (connection == null)
        {
            return Results.BadRequest();
        }
        
        var request = new HttpRequestMessage(new HttpMethod(method),
            connection.Destination + connection.PathPrefix);
        
        request.Content = new StreamContent(httpContext.Request.Body);
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await client.SendAsync(request);
        
        string contentType = response.Content.Headers.ContentType?.ToString() ?? "application/octet-stream";
        string responseString  = await response.Content.ReadAsStringAsync();
        int responseCode = (int)response.StatusCode;

        var result = Results.Content(responseString, contentType, Encoding.UTF8,responseCode);

        return result;
    });

app.Run();

