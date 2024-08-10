using Larmo.Domain.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Larmo.Infrastructure.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasMany(u => u.UserGroups)
            .WithOne(ug => ug.User)
            .HasForeignKey(ug => ug.UserId);

        builder.OwnsOne(user => user.RefreshToken, navigationBuilder =>
        {
            navigationBuilder.WithOwner()
                .HasForeignKey(t => t.UserId);
            navigationBuilder.ToTable("User.RefreshTokens");
            navigationBuilder.HasKey(t => t.Id);
        });

        builder.Navigation(u => u.UserGroups).AutoInclude(false);
    }
}