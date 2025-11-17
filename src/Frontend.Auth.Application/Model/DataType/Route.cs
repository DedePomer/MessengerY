namespace Frontend.Auth.Application.Model.DataType;

public class Route
{
    public required string Name { get; init; }
    public required string PathPrefix { get; init; }
    public required string HttpMethod { get; init; }
}