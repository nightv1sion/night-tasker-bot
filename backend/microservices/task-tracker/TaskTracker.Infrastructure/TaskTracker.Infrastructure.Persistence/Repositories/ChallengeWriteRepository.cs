using TaskTracker.Core.Domain.Challenges.Entities;
using TaskTracker.Core.Domain.Challenges.Repositories;

namespace TaskTracker.Infrastructure.Persistence.Repositories;

internal sealed class ChallengeWriteRepository(
    ApplicationDbContext dbContext) : GenericWriteRepository<Challenge>(dbContext), IChallengeWriteRepository;