using Planner.Plans.Application.Abstractions.Data;

namespace Planner.Plans.Infrastructure;

internal sealed class UnitOfWork(PlansDbContext dbContext) : IUnitOfWork
{
    private readonly PlansDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
