using Planner.Plans.Domain.Plans.Entities;

namespace Planner.Plans.Application.Plans.GetUserPlans;

public sealed record PlanDto(
    Guid Id,
    string Name,
    string? Description,
    long UserId,
    IReadOnlyCollection<PlanDto.ReminderModel> Reminders)
{
    public sealed record ReminderModel(
        Guid Id,
        DateTimeOffset RemindAt);
    
    public static PlanDto FromEntity(Plan plan)
    {
        return new PlanDto(
            plan.Id,
            plan.Name,
            plan.Description,
            plan.UserId,
            plan.Reminders.Select(x => new ReminderModel(
                x.Id,
                x.RemindAt))
                .ToArray());
    }
};
