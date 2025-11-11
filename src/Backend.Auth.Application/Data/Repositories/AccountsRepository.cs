using Backend.Auth.Application.Data.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Backend.Auth.Application.Data.Repositories;

public class AccountsRepository(UsersDbContext  context) : IAccountsRepository
{
    public Task Registration(string username, string password)
    {
        var query = context.Accounts.AsNoTracking();
        
        
    }

    public Task Login(string username, string password)
    {
        throw new NotImplementedException();
    }
}