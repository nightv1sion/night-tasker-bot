using Challenges.Domain.ChallengeMessages.Entities;
using Challenges.Domain.ChallengeMessages.Repositories;
using Dapper;
using Planner.Challenges.Infrastructure.Abstractions;
using TaskTracker.Core.Domain.Challenges.Entities;
using TaskTracker.Infrastructure.Persistence.Configurations;

namespace Planner.Challenges.Infrastructure.Repositories.ChallengeMessages;

internal sealed class ChallengeMessageReadRepository(ISqlConnectionFactory sqlConnectionFactory)
    : GenericReadRepository<ChallengeMessage>(sqlConnectionFactory), IChallengeMessageReadRepository
{
}