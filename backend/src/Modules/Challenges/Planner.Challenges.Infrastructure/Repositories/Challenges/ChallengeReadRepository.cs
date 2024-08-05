using Dapper;
using Planner.Challenges.Domain.Challenges.Entities;
using Planner.Challenges.Domain.Challenges.Repositories;
using Planner.Challenges.Infrastructure.Configurations;
using Planner.Common.Infrastructure.Abstractions;

namespace Planner.Challenges.Infrastructure.Repositories.Challenges;

internal sealed class ChallengeReadRepository(IDbConnectionFactory dbConnectionFactory)
    : GenericReadRepository<Challenge>(dbConnectionFactory), IChallengeReadRepository
{
    public async Task<IReadOnlyCollection<Challenge>> GetUserChallengesAsync(int userId)
    {
        IEnumerable<Challenge> challenges = await _connection.QueryAsync<Challenge>(
            @$"SELECT * FROM {ChallengeConfiguration.TableName}
            WHERE user_id = @userId", new { userId });
        return challenges.ToArray();
    }

    public async Task<IReadOnlyCollection<Challenge>> GetMapBy(
        IReadOnlyCollection<Guid> challengeIds,
        int userId,
        CancellationToken cancellationToken)
    {
        IEnumerable<Challenge> challenges = await _connection.QueryAsync<Challenge>(
            @$"SELECT * FROM {ChallengeConfiguration.TableName}
            WHERE id = ANY(@challengeIds) AND user_id = @userId", new { challengeIds, userId });
        return challenges.ToArray();
    }

    public async Task<Challenge?> TryGetByMessageIdAsync(int messageId, CancellationToken cancellationToken)
    {
        Challenge? challenge = await _connection.QueryFirstOrDefaultAsync<Challenge>(
            $"""
             SELECT * FROM {ChallengeConfiguration.TableName} 
                      WHERE id IN (SELECT challenge_id FROM {ChallengeMessageConfiguration.TableName} 
                                                       WHERE message_id = @messageId)
             """, new { messageId });
        return challenge;
    }
}
