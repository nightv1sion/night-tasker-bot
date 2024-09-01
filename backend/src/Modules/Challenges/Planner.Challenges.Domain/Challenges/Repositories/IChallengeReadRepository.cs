using Planner.Challenges.Domain.Challenges.Entities;

namespace Planner.Challenges.Domain.Challenges.Repositories;

public interface IChallengeReadRepository
{
    Task<IReadOnlyCollection<Challenge>> GetUserChallengesAsync(int userId);
}
