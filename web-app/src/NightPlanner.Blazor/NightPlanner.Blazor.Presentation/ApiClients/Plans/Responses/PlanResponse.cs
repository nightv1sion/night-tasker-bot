namespace NightPlanner.Blazor.Presentation.ApiClients.Plans.Responses;

public sealed class PlanResponse
{
    public required Guid Id { get; init; }
    
    public required string Name { get; init; }

    public string? Description { get; init; }
}