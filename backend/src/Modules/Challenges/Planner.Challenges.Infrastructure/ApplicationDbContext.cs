using Microsoft.EntityFrameworkCore;

namespace Planner.Challenges.Infrastructure;

internal sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
    : DbContext(dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder
            .UseSnakeCaseNamingConvention();
    }
};