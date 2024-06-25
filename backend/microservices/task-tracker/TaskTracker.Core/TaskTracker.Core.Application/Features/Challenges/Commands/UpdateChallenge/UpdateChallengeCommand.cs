using TaskTracker.Core.Application.Abstractions.Messaging;
using TaskTracker.Core.Domain.Core.Primitives.Result;

namespace TaskTracker.Core.Application.Features.Challenges.Commands.UpdateChallenge;

public sealed record UpdateChallengeCommand(
    Guid ChallengeId,
    string Name,
    string? Description) : ICommand<Result>;