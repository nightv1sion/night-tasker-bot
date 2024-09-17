using Planner.Notifications.Application;

namespace Planner.Notifications.Infrastructure;

internal sealed class UnitOfWork(NotificationsDbContext dbContext) : IUnitOfWork
{
    private readonly NotificationsDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
