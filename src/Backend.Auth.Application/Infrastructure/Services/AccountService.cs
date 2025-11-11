using Backend.Auth.Application.Data.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Auth.Application.Infrastructure.Services;

public class AccountService(IAccountsRepository accountsRepository, ILogger<AccountService> logger)
{
    public async Task<bool> RegistrateAsync(string username, string password)
    {
        var canReg = await accountsRepository.UserExistAsync(username);

        if (!canReg)
        {
            logger.LogDebug("User {username} is already registered", username);
            return false;
        }

        
        
        await accountsRepository.RegistrateAsync(username, password);
        return true;
    }

    public async Task<bool> AuthenticateAsync(string username, string password)
    {
       return await accountsRepository.AuthenticateAsync(username, password);
    }
}