using TaskTracker.Core.Domain.Challenges.Entities;
using TaskTracker.Core.Domain.Core.Primitives;

namespace TaskTracker.Core.Domain.Challenges.Errors;

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
}