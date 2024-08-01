using Challenges.Domain.Core.Primitives;
using Microsoft.EntityFrameworkCore;
using Planner.Challenges.Infrastructure;
using TaskTracker.Core.Domain.Core.Primitives.Maybe;

namespace Planner.Challenges.Infrastructure.Repositories;

internal class GenericWriteRepository<TEntity>(ApplicationDbContext dbContext) where TEntity : Entity
{
    protected readonly ApplicationDbContext DbContext = dbContext;

    public async Task<TEntity?> TryGetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await DbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return entity;
    }

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