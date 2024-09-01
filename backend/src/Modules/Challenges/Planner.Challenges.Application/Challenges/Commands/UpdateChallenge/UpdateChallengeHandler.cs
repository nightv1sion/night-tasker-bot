using Planner.Challenges.Application.Abstractions.Data;
using Planner.Challenges.Domain.Challenges.Entities;
using Planner.Challenges.Domain.Challenges.Errors;
using Planner.Challenges.Domain.Challenges.Repositories;
using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Challenges.Application.Challenges.Commands.UpdateChallenge;

internal sealed class UpdateChallengeHandler(
    IChallengeRepository challengeRepository,
    IUnitOfWork UnitOfWork) : ICommandHandler<UpdateChallengeCommand, Result>
{
    public async Task<Result> Handle(UpdateChallengeCommand request, CancellationToken cancellationToken)
    {
        Challenge? challenge = await challengeRepository.TryGetByIdAsync(request.ChallengeId, cancellationToken);

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
