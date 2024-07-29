using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Larmo.Infrastructure.Context;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}