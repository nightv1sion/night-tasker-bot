using System.Data;
using Dapper;
using TaskTracker.Core.Domain.Core.Primitives;
using TaskTracker.Core.Domain.Core.Primitives.Maybe;
using TaskTracker.Infrastructure.Persistence.Abstractions;

namespace TaskTracker.Infrastructure.Persistence.Repositories;

internal class GenericReadRepository<TEntity>(ISqlConnectionFactory sqlConnectionFactory)
    where TEntity : Entity
{
    protected readonly IDbConnection _connection = sqlConnectionFactory.CreateConnection();

    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(
        string tableName,
        CancellationToken cancellationToken)
    {
        var entities = await _connection.QueryAsync<TEntity>($"SELECT * FROM {tableName}");
        return entities.ToArray();
    }

    public async Task<Maybe<TEntity>> GetById(Guid id, string tableName, CancellationToken cancellationToken)
    {
        var entity = await _connection.QueryFirstOrDefaultAsync<TEntity>(
            $"SELECT * FROM {tableName} WHERE id = @id", new { id });
        return Maybe<TEntity>.From(entity!);
    }
}