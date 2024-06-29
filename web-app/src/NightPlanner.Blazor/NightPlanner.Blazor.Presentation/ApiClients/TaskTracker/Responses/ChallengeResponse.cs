namespace NightPlanner.Blazor.Presentation.ApiClients.TaskTracker.Responses;

public sealed class ChallengeResponse
{
    public required Guid Id { get; init; }
    
    public required string Name { get; init; }

    public string? Description { get; init; }
}