using Backend.Auth.Application.Data.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Backend.Auth.Api.Extinsions;

internal static class DataBaseExtensions
{
    internal static void AddDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:UserDBConnection"] ?? string.Empty; 
        
        services.AddDbContext<UsersDbContext>(
            options =>
            {
                options.UseNpgsql(connectionString);
            });
    }
}