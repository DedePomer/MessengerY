using System.Text;
using System.Text.Json;
using Backend.Auth.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/test/gch",
    async (IHttpClientFactory factory, [FromBody] UserDto user) =>
    {
        const string gatewayPath = "https://localhost:7192";
        const string gatewayMethod = "POST";
        const string gatewayPref = "/api/login";
        var client = factory.CreateClient();

        string jsonUser = JsonSerializer.Serialize(user);

        var request =  new HttpRequestMessage(new HttpMethod(gatewayMethod), gatewayPath+gatewayPref);
        request.Content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
        
        var response = await client.SendAsync(request);
        
        if (response.IsSuccessStatusCode)
        {
            return Results.Ok();
        }
        return Results.BadRequest(); 
    });

app.Run();


