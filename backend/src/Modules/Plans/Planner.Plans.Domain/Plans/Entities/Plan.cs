using Planner.Common.Domain.Core.Primitives;
using Planner.Common.Domain.Core.Primitives.Result;
using Planner.Plans.Domain.Plans.Errors;

namespace Planner.Plans.Domain.Plans.Entities;

public sealed class Plan : AggregateRoot
{
    private Plan()
    {
    }

    private Plan(
        string name,
        string? description,
        long userId) : base(Guid.NewGuid())
    {
        Name = name;
        Description = description;
        UserId = userId;
    }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public long UserId { get; private set; }

    public List<PlanReminder> Reminders { get; private set; } = [];
    

    public static Plan Create(string name, string? description, long userId)
    {
        return new Plan(name, description, userId);
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdateDescription(string? description)
    {
        Description = description;
    }

    public Result AddReminder(DateTimeOffset remindAt)
    {
        if (Reminders.Any(x => x.RemindAt == remindAt))
        {
            return Result.Failure(PlanErrors.PlanHasSameDateTimeReminder(remindAt));
        }
        
        var reminder = PlanReminder.Create(Id, remindAt);

        AddDomainEvent(new PlanReminderCreatedDomainEvent(UserId, Name, remindAt, reminder.Id));
        
        Reminders.Add(reminder);

        return Result.Success();
    }

    public void Remove()
    {
        AddDomainEvent(new PlanRemovedDomainEvent(Reminders.Select(x => x.Id).ToArray()));
    }
}
