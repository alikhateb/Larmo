using Larmo.Domain.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Larmo.Infrastructure.EntityConfigurations;

public class GroupEntityConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups");

        builder.Property(g => g.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(g => g.UserGroups)
            .WithOne(ug => ug.Group)
            .HasForeignKey(ug => ug.GroupId);

        builder.HasMany(g => g.GroupRoles)
            .WithOne(ug => ug.Group)
            .HasForeignKey(ug => ug.GroupId);
    }
}