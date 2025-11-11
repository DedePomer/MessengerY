using Backend.Auth.Api.DTOs;
using Backend.Auth.Application.Infrastructure.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Auth.Api.Endpoints;

internal static class LoginEndpoint
{
    internal static void MapLoginEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/login", Login);
    }
    
    private static async Task<IResult> Login(AccountService accountService,IValidator<UserDto> validator,[FromBody] UserDto user)
    {
        var validatorResult = await validator.ValidateAsync(user);
        if (!validatorResult.IsValid)
        {
            return Results.BadRequest(validatorResult.Errors);
        }

        var isAuth = await accountService.AuthenticateAsync(user.Username, user.Password);
        if  (isAuth)
        {
            return Results.Ok();
        }
        return Results.Unauthorized();
    }
}