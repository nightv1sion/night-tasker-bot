using Challenges.Domain.Challenges.Entities;
using Challenges.Domain.Challenges.Repositories;
using Challenges.Domain.Core.Primitives.Result;
using Planner.Challenges.Application.Abstractions.Data;
using Planner.Challenges.Application.Abstractions.Messaging;

namespace Planner.Challenges.Application.Features.Challenges.Commands.CreateChallenge;

internal sealed class CreateChallengeHandler(
    IChallengeWriteRepository ChallengeWriteRepository,
    IChallengeReadRepository ChallengeReadRepository,
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