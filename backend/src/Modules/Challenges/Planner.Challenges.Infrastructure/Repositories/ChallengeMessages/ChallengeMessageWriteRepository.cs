using Planner.Challenges.Domain.ChallengeMessages.Entities;
using Planner.Challenges.Domain.ChallengeMessages.Repositories;

namespace Planner.Challenges.Infrastructure.Repositories.ChallengeMessages;

internal sealed class ChallengeMessageWriteRepository(ApplicationDbContext dbContext)
    : GenericWriteRepository<ChallengeMessage>(dbContext), IChallengeMessageWriteRepository
{
    public async Task InsertAsync(
        IReadOnlyCollection<ChallengeMessage> challengeMessages,
        CancellationToken cancellationToken)
    {
        await DbContext.AddRangeAsync(challengeMessages, cancellationToken);
    }
}
