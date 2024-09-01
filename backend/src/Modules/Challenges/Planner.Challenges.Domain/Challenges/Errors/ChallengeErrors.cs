using Planner.Challenges.Domain.Challenges.Entities;
using Planner.Common.Domain.Core.Primitives;

namespace Planner.Challenges.Domain.Challenges.Errors;

public static class ChallengeErrors
{
    public static Error ChallengeNotFound(Guid challengeId)
    {
        return Error.NotFound(ChallengeErrorCodes.ChallengeNotFound,
            $"{nameof(Challenge)} with id: {challengeId} not found");
    }

    public static Error ChallengesNotFound(IReadOnlyCollection<Guid> challengeIds)
    {
        return Error.NotFound(ChallengeErrorCodes.ChallengeNotFound,
            $"{nameof(Challenge)} with ids: {string.Join(", ", challengeIds)} not found");
    }

    public static Error ChallengeHasSameDateTimeReminder(DateTimeOffset remindAt)
    {
        return Error.Validation(ChallengeErrorCodes.ChallengeHasSameDateTimeReminder, 
            $"{nameof(Challenge)} already has a reminder at {remindAt}");
    }
}
