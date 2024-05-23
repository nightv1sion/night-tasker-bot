using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using TaskTracker.Infrastructure.Persistence.Abstractions;
using TaskTracker.Infrastructure.Persistence.Infrastructure;

namespace TaskTracker.Infrastructure.Persistence;

internal sealed class SqlConnectionFactory(IConfiguration configuration) : ISqlConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(configuration.GetConnectionString(ConnectionString.SettingsKey));
    }
}