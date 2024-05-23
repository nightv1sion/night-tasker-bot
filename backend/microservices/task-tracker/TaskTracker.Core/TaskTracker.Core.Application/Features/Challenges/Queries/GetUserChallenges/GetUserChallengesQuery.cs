using TaskTracker.Core.Application.Abstractions.Messaging;
using TaskTracker.Core.Application.Features.Challenges.Models;

namespace TaskTracker.Core.Application.Features.Challenges.Queries.GetUserChallenges;

public sealed record GetUserChallengesQuery(int UserId) : IQuery<IReadOnlyCollection<ChallengeDto>>;