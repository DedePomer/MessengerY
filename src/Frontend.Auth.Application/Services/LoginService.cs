using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Frontend.Auth.Application.Model.DataType;
using Frontend.Auth.Application.Model.DTOs;
using Microsoft.Extensions.Options;

namespace Frontend.Auth.Application.Services;

public class LoginService(HttpClient client, IOptions<RoutesInformation> options) : ILoginService
{
    private const string RouteName = "Login";

    public async Task<ErrorInfo> Singin(string username, string password)
    {
        var information = options.Value;

        UserDto user = new()
        {
            Username = username,
            Password = password,
        };

        string method = information
            .Routes
            .First(x => x.Name == RouteName)
            .HttpMethod;

        string host = information.GatewayHost;
        string prefix = information
            .Routes
            .First(x => x.Name == RouteName)
            .PathPrefix;

        string requestUrl = host + prefix;
        string content = JsonSerializer.Serialize(user);

        var request = new HttpRequestMessage(new HttpMethod(method), requestUrl);

        request.Content = new StringContent(content, Encoding.UTF8);
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            // должно открыть другой микросервис
        }

        return new ErrorInfo()
        {
            ErrorCode = (int)response.StatusCode,
            ErrorText = await response.Content.ReadAsStringAsync(),
        };
    }

}
