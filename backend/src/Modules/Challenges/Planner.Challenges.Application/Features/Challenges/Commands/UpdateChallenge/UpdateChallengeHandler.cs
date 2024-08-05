using Challenges.Domain.Challenges.Errors;
using Challenges.Domain.Challenges.Repositories;
using Planner.Common.Domain.Core.Primitives.Result;
using Planner.Challenges.Application.Abstractions.Data;
using Planner.Common.Application.Messaging;

namespace Planner.Challenges.Application.Features.Challenges.Commands.UpdateChallenge;

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