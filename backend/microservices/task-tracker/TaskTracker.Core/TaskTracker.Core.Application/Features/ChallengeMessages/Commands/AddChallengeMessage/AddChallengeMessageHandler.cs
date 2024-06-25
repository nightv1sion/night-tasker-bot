using TaskTracker.Core.Application.Abstractions.Data;
using TaskTracker.Core.Application.Abstractions.Messaging;
using TaskTracker.Core.Domain.ChallengeMessages.Entities;
using TaskTracker.Core.Domain.ChallengeMessages.Repositories;
using TaskTracker.Core.Domain.Challenges.Errors;
using TaskTracker.Core.Domain.Challenges.Repositories;
using TaskTracker.Core.Domain.Core.Primitives.Result;

namespace TaskTracker.Core.Application.Features.ChallengeMessages.Commands.AddChallengeMessage;

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