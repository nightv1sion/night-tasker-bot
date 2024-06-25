using TaskTracker.Core.Application.Abstractions.Messaging;
using TaskTracker.Core.Application.Features.Challenges.Models;
using TaskTracker.Core.Domain.ChallengeMessages.Errors;
using TaskTracker.Core.Domain.Challenges.Repositories;
using TaskTracker.Core.Domain.Core.Primitives.Result;

namespace TaskTracker.Core.Application.Features.Challenges.Queries.GetChallengeByMessageId;

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