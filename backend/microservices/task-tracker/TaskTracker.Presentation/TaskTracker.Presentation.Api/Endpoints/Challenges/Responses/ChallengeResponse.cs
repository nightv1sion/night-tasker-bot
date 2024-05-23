using TaskTracker.Core.Application.Features.Challenges.Models;

namespace TaskTracker.Presentation.Api.Endpoints.Challenges.Responses;

public sealed record ChallengeResponse(Guid Id, string Name, string? Description, int UserId)
{
    public static ChallengeResponse FromDto(ChallengeDto dto)
    {
        return new ChallengeResponse(dto.Id, dto.Name, dto.Description, dto.UserId);
    }
}