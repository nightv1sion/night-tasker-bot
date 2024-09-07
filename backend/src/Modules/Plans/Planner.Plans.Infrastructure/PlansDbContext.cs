using Microsoft.EntityFrameworkCore;
using Planner.Plans.Infrastructure.Configurations;

namespace Planner.Plans.Infrastructure;

public sealed class PlansDbContext(DbContextOptions<PlansDbContext> dbContextOptions)
    : DbContext(dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(Schemas.Plans);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlansDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder
            .UseSnakeCaseNamingConvention();
    }
};
