using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Plans.Application.Plans.AddReminder;

public sealed record AddPlanReminderCommand(
    long UserId,
    Guid PlanId,
    DateTimeOffset RemindAt) : ICommand<Result<Guid>>;
