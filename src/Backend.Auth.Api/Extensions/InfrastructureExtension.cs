using Backend.Auth.Application.Infrastructure.Services;

namespace Backend.Auth.Api.Extensions;

internal static class InfrastructureExtension
{
    internal static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AccountService>();
    }
}