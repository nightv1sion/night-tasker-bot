using Microsoft.EntityFrameworkCore;

namespace Planner.Challenges.Infrastructure;

public sealed class ChallengesDbContext(DbContextOptions<ChallengesDbContext> dbContextOptions)
    : DbContext(dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("challenges");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChallengesDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder
            .UseSnakeCaseNamingConvention();
    }
};
