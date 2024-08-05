using Planner.Common.Domain.Core.Primitives.Result;
using Planner.Common.Application.Messaging;

namespace Planner.Challenges.Application.Features.Challenges.Commands.UpdateChallenge;

public sealed record UpdateChallengeCommand(
    Guid ChallengeId,
    string Name,
    string? Description) : ICommand<Result>;