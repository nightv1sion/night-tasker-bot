using Challenges.Domain.ChallengeMessages.Errors;
using Challenges.Domain.Challenges.Repositories;
using Challenges.Domain.Core.Primitives.Result;
using Planner.Challenges.Application.Abstractions.Messaging;
using Planner.Challenges.Application.Features.Challenges.Models;

namespace Planner.Challenges.Application.Features.Challenges.Queries.GetChallengeByMessageId;

internal sealed class GetChallengeByMessageIdHandler(IChallengeReadRepository ChallengeReadRepository)
    : IQueryHandler<GetChallengeByMessageIdQuery, Result<ChallengeDto>>
{
    public async Task<Result<ChallengeDto>> Handle(GetChallengeByMessageIdQuery request,
        CancellationToken cancellationToken)
    {
        var challenge = await ChallengeReadRepository.TryGetByMessageIdAsync(request.MessageId, cancellationToken);

        if (challenge is null || challenge.UserId != request.UserId)
        {
            return Result.Failure<ChallengeDto>(
                ChallengeMessageErrors.ChallengeForMessageIdNotFound(request.MessageId));
        }

        var challengeDto = ChallengeDto.FromEntity(challenge);

        return Result.Success(challengeDto);
    }
}