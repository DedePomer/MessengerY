using Backend.Auth.Application.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Auth.Application.Data.DataBase.Configurations;

public class AccountsConfigurate:IEntityTypeConfiguration<AccountsEntity>
{
    public void Configure(EntityTypeBuilder<AccountsEntity> builder)
    {
        builder
            .HasKey(x => x.AccountsId);
        
        builder
            .HasIndex(x => x.Username)
            .IsUnique();
    }
}