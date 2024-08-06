using Planner.Common.Domain.Core.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Planner.Challenges.Infrastructure.Repositories;

internal class GenericWriteRepository<TEntity>(ChallengesDbContext dbContext) where TEntity : Entity
{
    protected readonly ChallengesDbContext DbContext = dbContext;

    public async Task<TEntity?> TryGetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        TEntity? entity = await DbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
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
