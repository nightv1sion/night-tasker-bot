using System.Data;

namespace TaskTracker.Infrastructure.Persistence.Abstractions;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}