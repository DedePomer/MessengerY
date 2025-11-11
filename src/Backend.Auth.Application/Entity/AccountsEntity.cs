using System.ComponentModel.DataAnnotations;

namespace Backend.Auth.Application.Entity;

public class AccountsEntity
{
    public required Guid AccountsId { get; init; } =  Guid.NewGuid();
    
    [MaxLength(50)]
    public required string Username { get; init; }
    public required byte[] PasswordHash { get; init; }
    [MaxLength(5)]
    public required string PasswordSalt { get; init; }
}