using FluentValidation;

namespace Backend.Auth.Api.DTOs.Validators;

public class DtoValidatorFilter<T>(IValidator<T> validator, ILogger<DtoValidatorFilter<T>> logger): IEndpointFilter
{
    
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var dto = context.Arguments.OfType<T>().FirstOrDefault();
        if (dto == null)
        {
            logger.LogDebug("Ошибка в DtoValidatorFilter. Не нашлись данные типа Т.");
            return Results.BadRequest("Invalid request body");
        }

        
        var result = await validator.ValidateAsync(dto);
        if (!result.IsValid)
        {
            logger.LogDebug("Ошибка в DtoValidatorFilter. Данные не валидны.");
            return Results.BadRequest(result.Errors);
        }
        
        return await next(context);
    }
}