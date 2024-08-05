using Planner.Common.Domain.Core.Primitives.Result;
using Planner.Common.Application.Messaging;

namespace Planner.Challenges.Application.Features.Challenges.Commands.CreateChallenge;

public sealed record CreateChallengeCommand(
    string Name,
    string? Description,
    int UserId) : ICommand<Result<Guid>>;