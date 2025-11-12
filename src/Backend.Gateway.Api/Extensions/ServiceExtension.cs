using Backend.Gateway.Application.Model;

namespace Backend.Gateway.Api.Extensions;

public static class ServiceExtension
{
    internal static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connections = configuration.GetSection("GatewaySettings").Get<GatewaySettings>();
        services.Configure<GatewaySettings>(configuration.GetSection("GatewaySettings"));
    }
    
}