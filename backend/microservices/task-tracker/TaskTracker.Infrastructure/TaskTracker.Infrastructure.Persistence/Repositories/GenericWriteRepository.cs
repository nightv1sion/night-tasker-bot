using Microsoft.EntityFrameworkCore;
using TaskTracker.Core.Domain.Core.Primitives;
using TaskTracker.Core.Domain.Core.Primitives.Maybe;
namespace TaskTracker.Infrastructure.Persistence.Repositories;

internal class GenericWriteRepository<TEntity>(ApplicationDbContext dbContext) where TEntity : Entity
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Maybe<TEntity>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return Maybe<TEntity>.From(entity!);
    }
    
    public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public async Task InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await _dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
    }

    public void UpdateAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }

    public void UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().UpdateRange(entities);
    }

    public void Remove(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }
    
    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().RemoveRange(entities);
    }
}