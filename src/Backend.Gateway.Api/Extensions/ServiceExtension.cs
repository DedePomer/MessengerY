using Backend.Gateway.Application.Model;

namespace Backend.Gateway.Api.Extensions;

public static class ServiceExtension
{
    internal static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Settings>(configuration.GetSection("GatewaySettings"));
    }
    
}