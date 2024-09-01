using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Challenges.Application.Challenges.Commands.CreateChallenge;

public sealed record CreateChallengeCommand(
    string Name,
    string? Description,
    int UserId) : ICommand<Result<Guid>>;