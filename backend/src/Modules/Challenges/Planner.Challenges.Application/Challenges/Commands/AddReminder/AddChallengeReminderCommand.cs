using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Challenges.Application.Challenges.Commands.AddReminder;

public sealed record AddChallengeReminderCommand(
    int UserId,
    Guid ChallengeId,
    DateTimeOffset RemindAt) : ICommand<Result<Guid>>;
