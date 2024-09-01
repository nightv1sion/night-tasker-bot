using Planner.Challenges.Application.Abstractions.Data;
using Planner.Challenges.Domain.Challenges.Entities;
using Planner.Challenges.Domain.Challenges.Repositories;
using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Challenges.Application.Challenges.Commands.CreateChallenge;

internal sealed class CreateChallengeHandler(
    IChallengeRepository challengeRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateChallengeCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateChallengeCommand request, CancellationToken cancellationToken)
    {
        var challenge = Challenge.Create(request.Name, request.Description, request.UserId);
        await challengeRepository.InsertAsync(challenge, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(challenge.Id);
    }
}
