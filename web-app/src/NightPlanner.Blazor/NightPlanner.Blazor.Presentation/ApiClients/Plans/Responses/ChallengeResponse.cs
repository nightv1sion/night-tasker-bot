namespace NightPlanner.Blazor.Presentation.ApiClients.TaskTracker.Responses;

public sealed class PlanResponse
{
    public required Guid Id { get; init; }
    
    public required string Name { get; init; }

    public string? Description { get; init; }
}