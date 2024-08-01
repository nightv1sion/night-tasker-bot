using Planner.Challenges.Domain.Challenges.Entities;

namespace Planner.Challenges.Domain.Challenges.Repositories;

public interface IChallengeReadRepository
{
    Task<IReadOnlyCollection<Challenge>> GetUserChallengesAsync(int userId);

    Task<IReadOnlyCollection<Challenge>> GetMapBy(
        IReadOnlyCollection<Guid> challengeIds,
        int userId,
        CancellationToken cancellationToken);

    Task<Challenge?> TryGetByMessageIdAsync(int messageId, CancellationToken cancellationToken);
}