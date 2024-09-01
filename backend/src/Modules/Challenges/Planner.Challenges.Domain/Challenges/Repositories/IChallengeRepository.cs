using Planner.Challenges.Domain.Challenges.Entities;

namespace Planner.Challenges.Domain.Challenges.Repositories;

public interface IChallengeRepository
{
    Task<Challenge?> TryGetByIdAsync(Guid challengeId, CancellationToken cancellationToken);

    Task InsertAsync(Challenge entity, CancellationToken cancellationToken);
    
    void Update(Challenge entity);
}
