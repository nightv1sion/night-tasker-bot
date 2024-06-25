using Dapper;
using TaskTracker.Core.Domain.ChallengeMessages.Entities;
using TaskTracker.Core.Domain.ChallengeMessages.Repositories;
using TaskTracker.Core.Domain.Challenges.Entities;
using TaskTracker.Infrastructure.Persistence.Abstractions;
using TaskTracker.Infrastructure.Persistence.Configurations;

namespace TaskTracker.Infrastructure.Persistence.Repositories.ChallengeMessages;

internal sealed class ChallengeMessageReadRepository(ISqlConnectionFactory sqlConnectionFactory)
    : GenericReadRepository<ChallengeMessage>(sqlConnectionFactory), IChallengeMessageReadRepository
{
}