using TaskTracker.Core.Application.Abstractions.Messaging;
using TaskTracker.Core.Application.Features.Challenges.Models;
using TaskTracker.Core.Domain.Challenges.Repositories;

namespace TaskTracker.Core.Application.Features.Challenges.Queries.GetUserChallenges;

internal sealed class GetUserChallengesHandler(IChallengeReadRepository ChallengeRepository)
    : IQueryHandler<GetUserChallengesQuery, IReadOnlyCollection<ChallengeDto>>
{
    public async Task<IReadOnlyCollection<ChallengeDto>> Handle(
        GetUserChallengesQuery request,
        CancellationToken cancellationToken)
    {
        var challenges = await ChallengeRepository.GetUserChallengesAsync(request.UserId);
        return challenges
            .Select(ChallengeDto.FromEntity)
            .ToArray();
    }
}