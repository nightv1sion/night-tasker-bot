using TaskTracker.Core.Domain.ChallengeMessages.Entities;
using TaskTracker.Core.Domain.ChallengeMessages.Repositories;

namespace TaskTracker.Infrastructure.Persistence.Repositories.ChallengeMessages;

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