using Planner.Challenges.Domain.Challenges.Errors;
using Planner.Common.Domain.Core.Primitives;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Challenges.Domain.Challenges.Entities;

public sealed class Challenge : AggregateRoot
{
    private Challenge()
    {
    }

    private Challenge(
        string name,
        string? description,
        int userId) : base(Guid.NewGuid())
    {
        Name = name;
        Description = description;
        UserId = userId;
    }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public int UserId { get; private set; }

    public List<ChallengeReminder> Reminders { get; private set; } = [];
    

    public static Challenge Create(string name, string? description, int userId)
    {
        return new Challenge(name, description, userId);
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
            return Result.Failure(ChallengeErrors.ChallengeHasSameDateTimeReminder(remindAt));
        }
        
        var reminder = ChallengeReminder.Create(Id, remindAt);
        Reminders.Add(reminder);

        return Result.Success();
    }
}
