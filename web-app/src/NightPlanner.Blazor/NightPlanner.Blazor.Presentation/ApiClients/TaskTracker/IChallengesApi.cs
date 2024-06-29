using NightPlanner.Blazor.Presentation.ApiClients.TaskTracker.Requests;
using NightPlanner.Blazor.Presentation.ApiClients.TaskTracker.Responses;
using Refit;

namespace NightPlanner.Blazor.Presentation.ApiClients.TaskTracker;

public interface IChallengesApi
{
    [Post("/challenges")]
    Task CreateChallenge([Body] CreateChallengeRequest request, CancellationToken cancellationToken = default);
    
    [Get("/challenges")]
    Task<List<ChallengeResponse>> GetChallenges([Query] int userId, CancellationToken cancellationToken = default);
}