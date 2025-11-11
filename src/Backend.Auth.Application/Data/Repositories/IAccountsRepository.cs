namespace Backend.Auth.Application.Data.Repositories;

public interface IAccountsRepository
{
    Task<bool> UserCanRegistrate(string username);
    Task Registrate (string username, string password);
    Task<bool> Authenticate (string username, string password);
}