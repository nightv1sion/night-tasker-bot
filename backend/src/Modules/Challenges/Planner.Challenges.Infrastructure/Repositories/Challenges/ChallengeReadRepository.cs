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
        IEnumerable<Challenge> challenges = await _connection.QueryAsync<Challenge, ChallengeReminder, Challenge>(
            @$"SELECT * FROM {Schemas.Challenges}.{ChallengeConfiguration.TableName} c
            LEFT JOIN {Schemas.Challenges}.{ChallengeReminderConfiguration.TableName} cr on c.id = cr.challenge_id
            WHERE c.user_id = @userId", (challenge, reminder) =>
            {
                if (reminder is not null)
                {
                    challenge.Reminders.Add(reminder);
                }
                
                return challenge;
            } ,
            new { userId }
            );
        return challenges.ToArray();
    }
}
