using Frontend.Auth.Application.Model.DataType;
using Frontend.Auth.Application.Model.DTOs;

namespace Frontend.Auth.Application.Services;

public class LoginService(HttpClient client)
{
    
    
    
    public async Task<ErrorInfo> Singin(string username, string password)
    {
        UserDto user = new()
        {
            Username = username,
            Password = password,
        };
        
        
    }
}
