using Planner.Challenges.Domain.Challenges.Entities;
using Planner.Challenges.Domain.Challenges.Errors;
using Planner.Challenges.Domain.Challenges.Repositories;
using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Challenges.Application.Challenges.Commands.AddReminder;

internal sealed class AddChallengeReminderHandler(IChallengeRepository challengeRepository)
    : ICommandHandler<AddChallengeReminderCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddChallengeReminderCommand request, CancellationToken cancellationToken)
    {
        Challenge? challenge = await challengeRepository.TryGetByIdAsync(request.ChallengeId, cancellationToken);

        if (challenge is null || challenge.UserId != request.UserId)
        {
            return Result.Failure<Guid>(ChallengeErrors.ChallengeNotFound(request.ChallengeId));
        }
        
        challenge.AddReminder(request.RemindAt);
        
        return Result.Success(challenge.Id);
    }
}
