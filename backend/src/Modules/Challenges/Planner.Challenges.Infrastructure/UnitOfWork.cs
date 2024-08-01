using Challenges.Application.Abstractions.Data;

namespace Planner.Challenges.Infrastructure;

internal sealed class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}