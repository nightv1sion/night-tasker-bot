using Challenges.Domain.ChallengeMessages.Entities;
using Challenges.Domain.ChallengeMessages.Repositories;
using Challenges.Domain.Challenges.Errors;
using Challenges.Domain.Challenges.Repositories;
using Challenges.Domain.Core.Primitives.Result;
using Planner.Challenges.Application.Abstractions.Data;
using Planner.Challenges.Application.Abstractions.Messaging;

namespace Planner.Challenges.Application.Features.ChallengeMessages.Commands.AddChallengeMessage;

internal sealed class AddChallengeMessageHandler(
    IChallengeMessageWriteRepository ChallengeMessageWriteRepository,
    IChallengeReadRepository ChallengeReadRepository,
    IUnitOfWork UnitOfWork)
    : ICommandHandler<AddChallengeMessageCommand, Result>
{
    public async Task<Result> Handle(AddChallengeMessageCommand request, CancellationToken cancellationToken)
    {
        var challengeIds = request.ChallengeMessages.Select(x => x.ChallengeId).ToArray();
        var challenges = await ChallengeReadRepository.GetMapBy(
            challengeIds,
            request.UserId,
            cancellationToken);

        var notFoundChallenges = challengeIds
            .Except(challenges.Select(x => x.Id))
            .ToList();

        if (notFoundChallenges.Any())
        {
            return Result.Failure(ChallengeErrors.ChallengesNotFound(notFoundChallenges));
        }

        var challengeMessages = request.ChallengeMessages
            .Select(x => ChallengeMessage.Create(x.MessageId, x.ChallengeId))
            .ToList();

        await ChallengeMessageWriteRepository.InsertAsync(challengeMessages, cancellationToken);

        await UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}