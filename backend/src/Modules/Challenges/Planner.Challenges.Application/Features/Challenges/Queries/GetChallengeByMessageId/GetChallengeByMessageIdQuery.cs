using Challenges.Domain.Core.Primitives.Result;
using Planner.Challenges.Application.Abstractions.Messaging;
using Planner.Challenges.Application.Features.Challenges.Models;

namespace Planner.Challenges.Application.Features.Challenges.Queries.GetChallengeByMessageId;

public sealed record GetChallengeByMessageIdQuery(int MessageId, int UserId) : IQuery<Result<ChallengeDto>>;