using Frontend.Auth.Application.Model.DataType;

namespace Frontend.Auth.Application.Services;

public interface ILoginService
{
    Task<ErrorInfo> Singin(string username, string password);
}