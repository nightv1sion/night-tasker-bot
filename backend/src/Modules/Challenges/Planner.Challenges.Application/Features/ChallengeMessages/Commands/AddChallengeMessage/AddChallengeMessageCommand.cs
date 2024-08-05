using Planner.Common.Domain.Core.Primitives.Result;
using Planner.Common.Application.Messaging;
using Planner.Challenges.Application.Features.ChallengeMessages.Models;

namespace Planner.Challenges.Application.Features.ChallengeMessages.Commands.AddChallengeMessage;

public sealed record AddChallengeMessageCommand(
    IReadOnlyCollection<AddChallengeMessageDto> ChallengeMessages,
    int UserId) : ICommand<Result>;
