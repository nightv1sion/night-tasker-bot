namespace NightPlanner.Blazor.Presentation.ApiClients.Plans.Requests;

public sealed record AddPlanReminderRequest(
    int UserId,
    DateTimeOffset RemindAt);