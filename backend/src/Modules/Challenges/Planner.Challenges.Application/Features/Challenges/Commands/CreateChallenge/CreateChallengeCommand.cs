using Challenges.Domain.Core.Primitives.Result;
using Planner.Challenges.Application.Abstractions.Messaging;

namespace Planner.Challenges.Application.Features.Challenges.Commands.CreateChallenge;

public sealed record CreateChallengeCommand(
    string Name,
    string? Description,
    int UserId) : ICommand<Result<Guid>>;