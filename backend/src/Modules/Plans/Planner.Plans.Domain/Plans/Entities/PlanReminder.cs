using Planner.Common.Domain.Core.Primitives;

namespace Planner.Plans.Domain.Plans.Entities;

public sealed class PlanReminder : Entity
{
    private PlanReminder()
    {
        
    }

    public static PlanReminder Create(
        Guid planId,
        DateTimeOffset remindAt)
    {
        return new PlanReminder
        {
            PlanId = planId,
            RemindAt = remindAt,
            CreatedAt = DateTimeOffset.Now,
        };
    }

    public Guid PlanId { get; private set; }
    
    public DateTimeOffset RemindAt { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }
}
