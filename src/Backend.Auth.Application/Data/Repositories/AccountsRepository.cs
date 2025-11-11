using Backend.Auth.Application.Data.DataBase;
using Backend.Auth.Application.Data.Entity;
using Backend.Auth.Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Backend.Auth.Application.Data.Repositories;

public class AccountsRepository(UsersDbContext  context) : IAccountsRepository
{
    public async Task<bool> UserExistAsync(string username)
    {
        var query = context.Accounts.AsNoTracking();
        
        var userExist = await query.AnyAsync(x => x.Username == username);
        
        return userExist;
    }

    public async Task RegistrateAsync(string username, string password)
    {
        var query = context.Accounts;
        
        var salt = SaltHelper.GenerateSalt16();
        password = salt + password;
        var hashedPassword = HashHelper.GetHash(password);
        
        await query.AddAsync(new AccountsEntity()
        {
            Username = username,
            PasswordHash = hashedPassword,
            PasswordSalt = salt,
        });
        
        await context.SaveChangesAsync();
    }

    public async Task<bool> AuthenticateAsync(string username, string password)
    {
        var query = context.Accounts;
        
        var account = await query.FirstOrDefaultAsync(a=>a.Username == username);
        if (account == null) return false;
        
        var salt = account.PasswordSalt;
        password = salt + password;
        var hashedPassword = HashHelper.GetHash(password);
        
        var isAuth = await query.AnyAsync(x => x.Username == username && x.PasswordHash == hashedPassword);
        
        return isAuth;
    }
}