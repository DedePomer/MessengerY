namespace Frontend.Auth.Application.Model.DataType;

public class RoutesInformation
{
    public required string GatewayHost { get; init; }
    public required List<Route> Routes { get; init; }
}