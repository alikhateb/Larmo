using Larmo.Domain.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Larmo.Infrastructure.EntityConfigurations;

public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasMany<UserRole>()
            .WithOne(userRole => userRole.Role)
            .HasForeignKey(userRole => userRole.RoleId);
    }
}