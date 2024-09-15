namespace NightPlanner.Blazor.Presentation.ApiClients.Plans.Responses;

public sealed class PlanResponse
{
    public required Guid Id { get; init; }
    
    public required string Name { get; init; }

    public string? Description { get; init; }
    
    public required IReadOnlyCollection<ReminderResponse> Reminders { get; init; }
    
    public sealed class ReminderResponse
    {
        public required Guid Id { get; init; }
        
        public required DateTimeOffset RemindAt { get; init; }
    }
}

