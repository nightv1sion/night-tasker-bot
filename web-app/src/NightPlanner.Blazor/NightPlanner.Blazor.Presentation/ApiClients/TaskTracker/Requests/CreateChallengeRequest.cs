namespace NightPlanner.Blazor.Presentation.ApiClients.TaskTracker.Requests;

public sealed class CreateChallengeRequest
{
    public required string Name { get; init; }

    public string? Description { get; init; }
    
    public required int UserId { get; init; }
}