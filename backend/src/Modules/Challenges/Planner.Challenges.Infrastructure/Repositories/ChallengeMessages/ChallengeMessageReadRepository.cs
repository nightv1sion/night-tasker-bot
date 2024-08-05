using Dapper;
using Planner.Challenges.Domain.ChallengeMessages.Entities;
using Planner.Challenges.Domain.ChallengeMessages.Repositories;
using Planner.Common.Infrastructure.Abstractions;
using TaskTracker.Infrastructure.Persistence.Configurations;

namespace Planner.Challenges.Infrastructure.Repositories.ChallengeMessages;

internal sealed class ChallengeMessageReadRepository(IDbConnectionFactory dbConnectionFactory)
    : GenericReadRepository<ChallengeMessage>(dbConnectionFactory), IChallengeMessageReadRepository
{
}
