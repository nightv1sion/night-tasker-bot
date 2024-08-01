using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Planner.Challenges.Infrastructure.Abstractions;
using Planner.Challenges.Infrastructure.Infrastructure;

namespace Planner.Challenges.Infrastructure;

internal sealed class SqlConnectionFactory(IConfiguration configuration) : ISqlConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(configuration.GetConnectionString(ConnectionString.SettingsKey));
    }
}