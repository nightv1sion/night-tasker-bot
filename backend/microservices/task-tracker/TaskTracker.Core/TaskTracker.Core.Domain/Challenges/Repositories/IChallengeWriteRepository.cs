using TaskTracker.Core.Domain.Challenges.Entities;

namespace TaskTracker.Core.Domain.Challenges.Repositories;

public interface IChallengeWriteRepository
{
    Task InsertAsync(Challenge entity, CancellationToken cancellationToken);
}