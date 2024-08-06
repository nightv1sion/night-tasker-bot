using Planner.Challenges.Application.Abstractions.Data;

namespace Planner.Challenges.Infrastructure;

internal sealed class UnitOfWork(ChallengesDbContext dbContext) : IUnitOfWork
{
    private readonly ChallengesDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
