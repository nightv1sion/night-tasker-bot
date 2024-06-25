namespace TaskTracker.Presentation.Api.Endpoints.Challenges.Requests;

public sealed class UpdateChallengeRequest
{
    public required string Name { get; init; }

    public string? Description { get; init; }
}