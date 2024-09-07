using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Plans.Application.Plans.Commands.AddReminder;

public sealed record AddPlanReminderCommand(
    int UserId,
    Guid PlanId,
    DateTimeOffset RemindAt) : ICommand<Result<Guid>>;
