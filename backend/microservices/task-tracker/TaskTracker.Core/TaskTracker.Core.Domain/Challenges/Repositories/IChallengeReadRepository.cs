using TaskTracker.Core.Domain.Challenges.Entities;

namespace TaskTracker.Core.Domain.Challenges.Repositories;

public interface IChallengeReadRepository
{
    Task<IReadOnlyCollection<Challenge>> GetUserChallenges(int userId);
}