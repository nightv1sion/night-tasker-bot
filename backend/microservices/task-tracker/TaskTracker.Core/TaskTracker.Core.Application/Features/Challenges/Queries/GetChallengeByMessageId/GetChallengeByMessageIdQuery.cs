using TaskTracker.Core.Application.Abstractions.Messaging;
using TaskTracker.Core.Application.Features.Challenges.Models;
using TaskTracker.Core.Domain.Core.Primitives.Result;

namespace TaskTracker.Core.Application.Features.Challenges.Queries.GetChallengeByMessageId;

public sealed record GetChallengeByMessageIdQuery(int MessageId, int UserId) : IQuery<Result<ChallengeDto>>;