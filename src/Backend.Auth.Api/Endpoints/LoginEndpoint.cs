using Backend.Auth.Api.DTOs;
using Backend.Auth.Api.DTOs.Validators;
using Backend.Auth.Application.Infrastructure.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Auth.Api.Endpoints;

internal static class LoginEndpoint
{
    internal static void MapLoginEndpoint(this IEndpointRouteBuilder app)
    {
        app
            .MapPost("/login", Login)
            .AddEndpointFilter<DtoValidatorFilter<UserDto>>();
    }
    
    private static async Task<IResult> Login(AccountService accountService,[FromBody] UserDto user)
    {
        var isAuth = await accountService.AuthenticateAsync(user.Username, user.Password);
        if  (isAuth)
        {
            return Results.Ok();
        }
        return Results.Unauthorized();
    }
}