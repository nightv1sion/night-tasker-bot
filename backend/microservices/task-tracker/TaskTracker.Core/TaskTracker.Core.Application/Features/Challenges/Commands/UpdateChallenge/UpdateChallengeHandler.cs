using TaskTracker.Core.Application.Abstractions.Data;
using TaskTracker.Core.Application.Abstractions.Messaging;
using TaskTracker.Core.Domain.Challenges.Errors;
using TaskTracker.Core.Domain.Challenges.Repositories;
using TaskTracker.Core.Domain.Core.Primitives.Result;

namespace TaskTracker.Core.Application.Features.Challenges.Commands.UpdateChallenge;

internal sealed class UpdateChallengeHandler(
    IChallengeWriteRepository ChallengeWriteRepository,
    IUnitOfWork UnitOfWork) : ICommandHandler<UpdateChallengeCommand, Result>
{
    public async Task<Result> Handle(UpdateChallengeCommand request, CancellationToken cancellationToken)
    {
        var challenge = await ChallengeWriteRepository.TryGetByIdAsync(request.ChallengeId, cancellationToken);

        if (challenge is null)
        {
            return Result.Failure(ChallengeErrors.ChallengeNotFound(request.ChallengeId));
        }

        challenge.UpdateName(request.Name);
        challenge.UpdateDescription(request.Description);

        await UnitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}