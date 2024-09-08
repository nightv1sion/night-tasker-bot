namespace NightPlanner.Blazor.Presentation.ApiClients.Plans.Requests;

public sealed class CreatePlanRequest
{
    public required string Name { get; init; }

    public string? Description { get; init; }
    
    public required int UserId { get; init; }
}