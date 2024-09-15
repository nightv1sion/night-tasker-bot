namespace NightPlanner.Blazor.Presentation.Models.Plans;

public sealed record PlanDto(
    Guid Id,
    string Name,
    string? Description,
    IReadOnlyCollection<PlanDto.ReminderModel> Reminders)
{
    public sealed record ReminderModel(
        Guid Id,
        DateTimeOffset RemindAt);
};