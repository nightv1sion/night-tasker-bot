using Planner.Challenges.Domain.ChallengeMessages.Entities;

namespace Planner.Challenges.Domain.ChallengeMessages.Repositories;

public interface IChallengeMessageWriteRepository
{
    Task InsertAsync(ChallengeMessage challengeMessage, CancellationToken cancellationToken);

    Task InsertAsync(IReadOnlyCollection<ChallengeMessage> challengeMessages, CancellationToken cancellationToken);
}