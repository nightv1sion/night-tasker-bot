using Planner.Challenges.Domain.Challenges.Entities;
using Planner.Challenges.Domain.Challenges.Repositories;

namespace Planner.Challenges.Infrastructure.Repositories.Challenges;

internal sealed class ChallengeWriteRepository(
    ApplicationDbContext dbContext) : GenericWriteRepository<Challenge>(dbContext), IChallengeWriteRepository;
