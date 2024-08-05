using Planner.Challenges.Domain.Challenges.Entities;
using Planner.Common.Domain.Core.Primitives;

namespace Planner.Challenges.Domain.ChallengeMessages.Errors;

public static class ChallengeMessageErrors
{
    public static Error ChallengeForMessageIdNotFound(int messageId)
    {
        return Error.NotFound(ChallengeMessageErrorCodes.ChallengeForMessageIdNotFound,
            $"{nameof(Challenge)} for message id: {messageId} not found");
    }
}
