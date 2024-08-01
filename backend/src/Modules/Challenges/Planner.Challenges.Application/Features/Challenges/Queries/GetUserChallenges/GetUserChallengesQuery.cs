using Planner.Challenges.Application.Abstractions.Messaging;
using Planner.Challenges.Application.Features.Challenges.Models;

namespace Planner.Challenges.Application.Features.Challenges.Queries.GetUserChallenges;

public sealed record GetUserChallengesQuery(int UserId) : IQuery<IReadOnlyCollection<ChallengeDto>>;