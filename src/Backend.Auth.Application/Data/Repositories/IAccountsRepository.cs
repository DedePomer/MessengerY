namespace Backend.Auth.Application.Data.Repositories;

public interface IAccountsRepository
{
    Task<bool> UserExistAsync(string username);
    Task RegistrateAsync (string username, string password);
    Task<bool> AuthenticateAsync (string username, string password);
}