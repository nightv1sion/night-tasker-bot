using Planner.Challenges.Application.Challenges.Models;
using Planner.Common.Application.Messaging;

namespace Planner.Challenges.Application.Challenges.Queries.GetUserChallenges;

public sealed record GetUserChallengesQuery(int UserId) : IQuery<IReadOnlyCollection<ChallengeDto>>;
