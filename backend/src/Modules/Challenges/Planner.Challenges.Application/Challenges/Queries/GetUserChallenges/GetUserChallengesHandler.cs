using Planner.Challenges.Application.Challenges.Models;
using Planner.Challenges.Domain.Challenges.Entities;
using Planner.Challenges.Domain.Challenges.Repositories;
using Planner.Common.Application.Messaging;

namespace Planner.Challenges.Application.Challenges.Queries.GetUserChallenges;

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
