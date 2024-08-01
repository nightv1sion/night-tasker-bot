using Challenges.Domain.Challenges.Entities;
using Challenges.Domain.Challenges.Repositories;
using Dapper;
using Planner.Challenges.Infrastructure.Abstractions;
using Planner.Challenges.Infrastructure.Configurations;

namespace Planner.Challenges.Infrastructure.Repositories.Challenges;

internal sealed class ChallengeReadRepository(ISqlConnectionFactory sqlConnectionFactory)
    : GenericReadRepository<Challenge>(sqlConnectionFactory), IChallengeReadRepository
{
    public async Task<IReadOnlyCollection<Challenge>> GetUserChallengesAsync(int userId)
    {
        var challenges = await _connection.QueryAsync<Challenge>(
            @$"SELECT * FROM {ChallengeConfiguration.TableName}
            WHERE user_id = @userId", new { userId });
        return challenges.ToArray();
    }

    public async Task<IReadOnlyCollection<Challenge>> GetMapBy(
        IReadOnlyCollection<Guid> challengeIds,
        int userId,
        CancellationToken cancellationToken)
    {
        var challenges = await _connection.QueryAsync<Challenge>(
            @$"SELECT * FROM {ChallengeConfiguration.TableName}
            WHERE id = ANY(@challengeIds) AND user_id = @userId", new { challengeIds, userId });
        return challenges.ToArray();
    }

    public async Task<Challenge?> TryGetByMessageIdAsync(int messageId, CancellationToken cancellationToken)
    {
        var challenge = await _connection.QueryFirstOrDefaultAsync<Challenge>(
            $"""
             SELECT * FROM {ChallengeConfiguration.TableName} 
                      WHERE id IN (SELECT challenge_id FROM {ChallengeMessageConfiguration.TableName} 
                                                       WHERE message_id = @messageId)
             """, new { messageId });
        return challenge;
    }
}