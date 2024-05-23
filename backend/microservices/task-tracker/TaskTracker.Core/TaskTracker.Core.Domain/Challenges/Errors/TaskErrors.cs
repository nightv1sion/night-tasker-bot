using TaskTracker.Core.Domain.Core.Primitives;

namespace TaskTracker.Core.Domain.Challenges.Errors;

public static class TaskErrors
{
    public static Error TaskNotFound(Guid id) => Error.NotFound(
        ChallengeErrorCodes.ChallengeNotFound, $"Task with id: '{id}' was not found.");
}