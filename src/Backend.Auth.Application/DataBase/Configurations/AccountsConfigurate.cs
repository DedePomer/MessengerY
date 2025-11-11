using Backend.Auth.Application.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Auth.Application.DataBase.Configurations;

public class AccountsConfigurate:IEntityTypeConfiguration<AccountsEntity>
{
    public void Configure(EntityTypeBuilder<AccountsEntity> builder)
    {
        builder
            .HasKey(x => x.AccountsId);
    }
}