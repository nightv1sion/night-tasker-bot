using TaskTracker.Core.Domain.ChallengeMessages.Entities;

namespace TaskTracker.Core.Domain.ChallengeMessages.Repositories;

public interface IChallengeMessageWriteRepository
{
    Task InsertAsync(ChallengeMessage challengeMessage, CancellationToken cancellationToken);

    Task InsertAsync(IReadOnlyCollection<ChallengeMessage> challengeMessages, CancellationToken cancellationToken);
}