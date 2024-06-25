using TaskTracker.Core.Application.Abstractions.Messaging;
using TaskTracker.Core.Application.Features.ChallengeMessages.Models;
using TaskTracker.Core.Domain.Core.Primitives.Result;

namespace TaskTracker.Core.Application.Features.ChallengeMessages.Commands.AddChallengeMessage;

public sealed record AddChallengeMessageCommand(
    IReadOnlyCollection<AddChallengeMessageDto> ChallengeMessages,
    int UserId) : ICommand<Result>;