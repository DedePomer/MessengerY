namespace Backend.Gateway.Application.Model;

public record Connections(
    string Name,
    string PathPrefix,
    string Destination,
    string[] AllowedMethods);