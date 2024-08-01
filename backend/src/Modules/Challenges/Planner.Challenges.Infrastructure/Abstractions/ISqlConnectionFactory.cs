using System.Data;

namespace Planner.Challenges.Infrastructure.Abstractions;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}