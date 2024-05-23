using TaskTracker.Core.Application.Abstractions.Messaging;
using TaskTracker.Core.Domain.Core.Primitives.Result;

namespace TaskTracker.Core.Application.Features.Challenges.Commands.CreateChallenge;

public sealed record CreateChallengeCommand(
    string Name,
    string? Description,
    int UserId) : ICommand<Result<Guid>>;