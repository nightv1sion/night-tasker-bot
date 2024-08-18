using Planner.Challenges.Domain.Challenges.Repositories;
using Planner.Common.Application.Messaging;
using Planner.Challenges.Application.Features.Challenges.Models;
using Planner.Challenges.Domain.Challenges.Entities;

namespace Planner.Challenges.Application.Features.Challenges.Queries.GetUserChallenges;

internal sealed class GetUserChallengesHandler(IChallengeReadRepository ChallengeRepository)
    : IQueryHandler<GetUserChallengesQuery, IReadOnlyCollection<ChallengeDto>>
{
    public async Task<IReadOnlyCollection<ChallengeDto>> Handle(
        GetUserChallengesQuery request,
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Challenge> challenges = await ChallengeRepository.GetUserChallengesAsync(request.UserId);
        return challenges
            .Select(ChallengeDto.FromEntity)
            .ToArray();
    }
}
