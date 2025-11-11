using Backend.Auth.Application.Data.Repositories;

namespace Backend.Auth.Api.Extensions;

internal static class DataExtension
{
    internal static void AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAccountsRepository,AccountsRepository>();
    }
}