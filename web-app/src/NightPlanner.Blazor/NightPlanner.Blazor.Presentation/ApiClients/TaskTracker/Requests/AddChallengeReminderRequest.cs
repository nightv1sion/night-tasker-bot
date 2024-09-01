namespace NightPlanner.Blazor.Presentation.ApiClients.TaskTracker.Requests;

public sealed record AddChallengeReminderRequest(
    int UserId,
    DateTimeOffset RemindAt);