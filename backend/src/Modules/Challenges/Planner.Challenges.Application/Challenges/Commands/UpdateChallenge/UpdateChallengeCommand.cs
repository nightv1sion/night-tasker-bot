using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Challenges.Application.Challenges.Commands.UpdateChallenge;

public sealed record UpdateChallengeCommand(
    Guid ChallengeId,
    string Name,
    string? Description) : ICommand<Result>;
