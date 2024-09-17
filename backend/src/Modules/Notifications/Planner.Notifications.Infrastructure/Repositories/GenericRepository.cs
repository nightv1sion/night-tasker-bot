using Planner.Common.Domain.Core.Primitives;

namespace Planner.Notifications.Infrastructure.Repositories;

internal class GenericRepository<TEntity>(NotificationsDbContext dbContext) where TEntity : Entity
{
    protected readonly NotificationsDbContext DbContext = dbContext;

    public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public async Task InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await DbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
    }

    public void Update(TEntity entity)
    {
        DbContext.Set<TEntity>().Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        DbContext.Set<TEntity>().UpdateRange(entities);
    }

    public void Remove(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        DbContext.Set<TEntity>().RemoveRange(entities);
    }
}
