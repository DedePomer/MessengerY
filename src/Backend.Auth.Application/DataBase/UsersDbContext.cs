using Backend.Auth.Application.DataBase.Configurations;
using Backend.Auth.Application.Entity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Auth.Application.DataBase;

public class UsersDbContext(DbContextOptions<UsersDbContext> options): DbContext(options)
{
    public DbSet<AccountsEntity> Accounts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountsConfigurate());
        
        base.OnModelCreating(modelBuilder);
    }
}