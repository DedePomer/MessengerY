using Backend.Auth.Api.DTOs;
using Backend.Auth.Application.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Auth.Api.Endpoints;

internal static class SignupEndpoint
{
    internal static void MapSignupEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/sigup", Signup);
    }

    private static async Task<IResult> Signup(AccountService accountService,[FromBody] UserDto user)
    {
        var isCorrect = await accountService.RegistrateAsync(user.Username, user.Password);
        if  (!isCorrect)
        {
            return Results.BadRequest("Пользователь с такими данными существует");
        }
        return Results.Ok();
    }
}