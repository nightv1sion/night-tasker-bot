using System.Data;
using Challenges.Domain.Core.Primitives;
using Challenges.Domain.Core.Primitives.Maybe;
using Dapper;
using Planner.Challenges.Infrastructure.Abstractions;

namespace Planner.Challenges.Infrastructure.Repositories;

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