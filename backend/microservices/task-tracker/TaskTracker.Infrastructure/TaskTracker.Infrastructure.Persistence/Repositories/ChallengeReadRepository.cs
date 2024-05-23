using System.Data;
using Dapper;
using TaskTracker.Core.Domain.Challenges.Entities;
using TaskTracker.Core.Domain.Challenges.Repositories;
using TaskTracker.Infrastructure.Persistence.Abstractions;
using TaskTracker.Infrastructure.Persistence.Configurations;

namespace TaskTracker.Infrastructure.Persistence.Repositories;

internal sealed class ChallengeReadRepository(ISqlConnectionFactory sqlConnectionFactory)
    : GenericReadRepository<Challenge>(sqlConnectionFactory), IChallengeReadRepository
{
    public async Task<IReadOnlyCollection<Challenge>> GetUserChallenges(int userId)
    {
        var challenges = await _connection.QueryAsync<Challenge>(
            @$"SELECT * FROM {ChallengeConfiguration.TableName}
            WHERE user_id = @userId", new { userId });
        return challenges.ToArray();
    }
}