namespace Backend.Auth.Application.Data.Repositories;

public interface IAccountsRepository
{
    Task Registration (string username, string password);
    Task Login (string username, string password);
}