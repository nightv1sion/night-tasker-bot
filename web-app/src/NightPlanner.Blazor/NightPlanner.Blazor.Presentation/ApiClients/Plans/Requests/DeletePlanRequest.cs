namespace NightPlanner.Blazor.Presentation.ApiClients.Plans.Requests;

public sealed class DeletePlanRequest
{
    public required int UserId { get; init; }
}