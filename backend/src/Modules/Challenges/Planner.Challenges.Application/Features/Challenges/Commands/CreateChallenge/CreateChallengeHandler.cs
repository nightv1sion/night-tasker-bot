using Planner.Challenges.Domain.Challenges.Entities;
using Planner.Challenges.Domain.Challenges.Repositories;
using Planner.Common.Domain.Core.Primitives.Result;
using Planner.Challenges.Application.Abstractions.Data;
using Planner.Common.Application.Messaging;

namespace Planner.Challenges.Application.Features.Challenges.Commands.CreateChallenge;

internal sealed class CreateChallengeHandler(
    IChallengeWriteRepository ChallengeWriteRepository,
    IUnitOfWork UnitOfWork) : ICommandHandler<CreateChallengeCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateChallengeCommand request, CancellationToken cancellationToken)
    {
        var challenge = Challenge.Create(request.Name, request.Description, request.UserId);
        await ChallengeWriteRepository.InsertAsync(challenge, cancellationToken);
        await UnitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(challenge.Id);
    }
}