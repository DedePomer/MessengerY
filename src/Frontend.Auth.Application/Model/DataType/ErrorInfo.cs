namespace Frontend.Auth.Application.Model.DataType;

public class ErrorInfo
{
    public required int  ErrorCode { get; init; }
    public required string  ErrorText { get; init; } = String.Empty;
}