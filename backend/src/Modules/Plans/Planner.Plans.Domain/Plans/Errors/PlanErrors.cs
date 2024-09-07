using Planner.Common.Domain.Core.Primitives;
using Planner.Plans.Domain.Plans.Entities;

namespace Planner.Plans.Domain.Plans.Errors;

public static class PlanErrors
{
    public static Error PlanNotFound(Guid planId)
    {
        return Error.NotFound(PlanErrorCodes.PlanNotFound,
            $"{nameof(Plan)} with id: {planId} not found");
    }

    public static Error PlansNotFound(IReadOnlyCollection<Guid> planIds)
    {
        return Error.NotFound(PlanErrorCodes.PlanNotFound,
            $"{nameof(Plan)} with ids: {string.Join(", ", planIds)} not found");
    }

    public static Error PlanHasSameDateTimeReminder(DateTimeOffset remindAt)
    {
        return Error.Validation(PlanErrorCodes.PlanHasSameDateTimeReminder, 
            $"{nameof(Plan)} already has a reminder at {remindAt}");
    }
}
