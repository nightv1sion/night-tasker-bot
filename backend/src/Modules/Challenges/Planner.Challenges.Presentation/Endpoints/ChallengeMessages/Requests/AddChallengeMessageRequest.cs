using Planner.Challenges.Application.Features.ChallengeMessages.Models;

namespace Planner.Challenges.Presentation.Endpoints.ChallengeMessages.Requests;

public sealed class AddChallengeMessageRequest
{
    public required IReadOnlyCollection<AddChallengeMessageDto> ChallengeMessages { get; init; }

    public required int UserId { get; init; }
}
