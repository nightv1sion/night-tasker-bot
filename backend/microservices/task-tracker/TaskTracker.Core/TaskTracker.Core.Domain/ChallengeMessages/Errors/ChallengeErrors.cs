using TaskTracker.Core.Domain.Challenges.Entities;
using TaskTracker.Core.Domain.Challenges.Errors;
using TaskTracker.Core.Domain.Core.Primitives;

namespace TaskTracker.Core.Domain.ChallengeMessages.Errors;

public static class ChallengeMessageErrors
{
    public static Error ChallengeForMessageIdNotFound(int messageId)
    {
        return Error.NotFound(ChallengeMessageErrorCodes.ChallengeForMessageIdNotFound,
            $"{nameof(Challenge)} for message id: {messageId} not found");
    }
}