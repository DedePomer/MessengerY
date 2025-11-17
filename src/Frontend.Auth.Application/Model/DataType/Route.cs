namespace Frontend.Auth.Application.Model.DataType;

internal class Route
{
    internal required string Name { get; init; }
    internal required string PathPrefix { get; init; }
    internal required string HttpMethod { get; init; }
}