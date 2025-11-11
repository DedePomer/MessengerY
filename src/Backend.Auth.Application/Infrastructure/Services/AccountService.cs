using Backend.Auth.Application.Data.Repositories;

namespace Backend.Auth.Application.Infrastructure.Services;

public class AccountService(IAccountsRepository accountsRepository)
{
    public async Task<bool> RegistrateAsync(string username, string password)
    {
        var canReg = await accountsRepository.UserExistAsync(username);
        
        if (!canReg) return false;
        
        await accountsRepository.RegistrateAsync(username, password);
        return true;
    }

    public async Task<bool> AuthenticateAsync(string username, string password)
    {
       return await accountsRepository.AuthenticateAsync(username, password);
    }
}