using System.ComponentModel.DataAnnotations;

namespace Backend.Auth.Application.Data.Entity;

public class AccountsEntity
{
    public Guid AccountsId { get; init; } =  Guid.NewGuid();
    
    [MaxLength(50)]
    public required string Username { get; init; }
    public required byte[] PasswordHash { get; init; }
    [MaxLength(30)]
    public required string PasswordSalt { get; init; }
}