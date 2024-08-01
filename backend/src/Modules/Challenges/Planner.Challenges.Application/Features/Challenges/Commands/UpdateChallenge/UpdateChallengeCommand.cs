using Challenges.Domain.Core.Primitives.Result;
using Planner.Challenges.Application.Abstractions.Messaging;

namespace Planner.Challenges.Application.Features.Challenges.Commands.UpdateChallenge;

public sealed record UpdateChallengeCommand(
    Guid ChallengeId,
    string Name,
    string? Description) : ICommand<Result>;