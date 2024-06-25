using TaskTracker.Core.Domain.Challenges.Entities;

namespace TaskTracker.Core.Domain.Challenges.Repositories;

public interface IChallengeWriteRepository
{
    Task<Challenge?> TryGetByIdAsync(Guid challengeId, CancellationToken cancellationToken);

    Task InsertAsync(Challenge entity, CancellationToken cancellationToken);

    void Update(Challenge entity);
}