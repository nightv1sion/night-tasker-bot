using TaskTracker.Core.Application.Abstractions.Data;
using TaskTracker.Core.Application.Abstractions.Messaging;
using TaskTracker.Core.Domain.Challenges.Entities;
using TaskTracker.Core.Domain.Challenges.Repositories;
using TaskTracker.Core.Domain.Core.Primitives.Result;

namespace TaskTracker.Core.Application.Features.Challenges.Commands.CreateChallenge;

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