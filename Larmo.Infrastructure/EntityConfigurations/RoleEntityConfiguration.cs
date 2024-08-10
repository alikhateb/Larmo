using Larmo.Domain.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Larmo.Infrastructure.EntityConfigurations;

public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(r => r.ModuleName)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(r => r.GroupRoles)
            .WithOne(gr => gr.Role)
            .HasForeignKey(gr => gr.RoleId);
    }
}