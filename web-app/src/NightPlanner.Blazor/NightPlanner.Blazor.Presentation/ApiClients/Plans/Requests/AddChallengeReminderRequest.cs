namespace NightPlanner.Blazor.Presentation.ApiClients.TaskTracker.Requests;

public sealed record AddPlanReminderRequest(
    int UserId,
    DateTimeOffset RemindAt);