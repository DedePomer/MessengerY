namespace Frontend.Auth.Application.Model.DataType;

internal class RoutesInformation
{
    internal required string GatewayHost { get; init; }
    internal required List<Route> Routes { get; init; }
}