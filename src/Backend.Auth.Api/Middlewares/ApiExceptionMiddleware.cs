namespace Backend.Auth.Api.Middlewares;

public class ApiExceptionMiddleware(RequestDelegate next, ILogger<ApiExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Auth API server error");
            
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync("Server error");
        }
    }
}