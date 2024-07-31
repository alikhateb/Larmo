using Larmo.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Larmo.Infrastructure.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.OwnsOne<RefreshToken>(user => user.RefreshToken, navigationBuilder =>
        {
            navigationBuilder.ToTable("User.RefreshTokens");
            navigationBuilder.WithOwner().HasForeignKey(t => t.UserId);
            navigationBuilder.HasKey(t => t.Id);
        });
    }
}