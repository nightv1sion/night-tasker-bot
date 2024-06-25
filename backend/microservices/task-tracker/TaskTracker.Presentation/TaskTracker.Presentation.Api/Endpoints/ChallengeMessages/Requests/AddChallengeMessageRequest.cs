using TaskTracker.Core.Application.Features.ChallengeMessages.Models;

namespace TaskTracker.Presentation.Api.Endpoints.ChallengeMessages.Requests;

public sealed class AddChallengeMessageRequest
{
    public required IReadOnlyCollection<AddChallengeMessageDto> ChallengeMessages { get; init; }

    public required int UserId { get; init; }
}