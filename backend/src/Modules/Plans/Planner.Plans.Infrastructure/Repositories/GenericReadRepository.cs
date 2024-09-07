using System.Data;
using Planner.Common.Domain.Core.Primitives;
using Planner.Common.Domain.Core.Primitives.Maybe;
using Dapper;
using Planner.Common.Infrastructure.Abstractions;

namespace Planner.Plans.Infrastructure.Repositories;

internal class GenericReadRepository<TEntity>(IDbConnectionFactory dbConnectionFactory)
    where TEntity : Entity
{
    protected readonly IDbConnection _connection = dbConnectionFactory.CreateConnection();

    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(
        string tableName,
        CancellationToken cancellationToken)
    {
        IEnumerable<TEntity> entities = await _connection.QueryAsync<TEntity>($"SELECT * FROM {tableName}");
        return entities.ToArray();
    }

    public async Task<Maybe<TEntity>> GetById(Guid id, string tableName, CancellationToken cancellationToken)
    {
        TEntity? entity = await _connection.QueryFirstOrDefaultAsync<TEntity>(
            $"SELECT * FROM {tableName} WHERE id = @id", new { id });
        return Maybe<TEntity>.From(entity!);
    }
}
