using Microsoft.EntityFrameworkCore;
using Planner.Challenges.Domain.Challenges.Entities;
using Planner.Challenges.Domain.Challenges.Repositories;

namespace Planner.Challenges.Infrastructure.Repositories.Challenges;

internal sealed class ChallengeRepository(
    ChallengesDbContext dbContext) : GenericRepository<Challenge>(dbContext), IChallengeRepository
{
    public async Task<Challenge?> TryGetByIdAsync(Guid challengeId, CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<Challenge>()
            .Include(challenge => challenge.Reminders)
            .FirstOrDefaultAsync(challenge => challenge.Id == challengeId, cancellationToken);
    }
}
