using System.Data;
using Npgsql;
using Planner.Common.Infrastructure.Abstractions;

namespace Planner.Common.Infrastructure;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        return dataSource.OpenConnection();
    }
}
