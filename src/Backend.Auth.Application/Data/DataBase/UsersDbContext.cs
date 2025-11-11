using Backend.Auth.Application.Data.DataBase.Configurations;
using Backend.Auth.Application.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Auth.Application.Data.DataBase;

public class UsersDbContext(DbContextOptions<UsersDbContext> options): DbContext(options)
{
    public DbSet<AccountsEntity> Accounts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountsConfigurate());
        
        base.OnModelCreating(modelBuilder);
    }
}