using Challenges.Domain.Challenges.Entities;

namespace Planner.Challenges.Application.Features.Challenges.Models;

public sealed record ChallengeDto(Guid Id, string Name, string? Description, int UserId)
{
    public static ChallengeDto FromEntity(Challenge challenge)
    {
        return new ChallengeDto(challenge.Id, challenge.Name, challenge.Description, challenge.UserId);
    }
};