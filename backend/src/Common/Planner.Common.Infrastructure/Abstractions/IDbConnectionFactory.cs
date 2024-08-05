using System.Data;

namespace Planner.Common.Infrastructure.Abstractions;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
