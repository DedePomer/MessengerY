using FluentValidation;

namespace Backend.Auth.Api.DTOs.Validators;

public class DtoValidatorFilter<T>(IValidator<T> validator): IEndpointFilter
{
    
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var dto = context.Arguments.OfType<T>().FirstOrDefault();
        if (dto is null)
            return Results.BadRequest("Invalid request body");

        var result = await validator.ValidateAsync(dto);
        if (!result.IsValid)
            return Results.BadRequest(result.Errors);

        return await next(context);
    }
}