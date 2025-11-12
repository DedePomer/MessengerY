namespace Backend.Gateway.Api.Model;

public record Connections(
    string Name,
    string PathPrefix,
    string Destination,
    string[] AllowedMethods);