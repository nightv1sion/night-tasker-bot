using NightPlanner.Blazor.Presentation.ApiClients.TaskTracker.Requests;
using NightPlanner.Blazor.Presentation.ApiClients.TaskTracker.Responses;
using Refit;

namespace NightPlanner.Blazor.Presentation.ApiClients.Plans;

public interface IPlansApi
{
    [Post("/plans")]
    Task CreatePlan([Body] CreatePlanRequest request, CancellationToken cancellationToken = default);
    
    [Get("/plans")]
    Task<List<PlanResponse>> GetPlans([Query] int userId, CancellationToken cancellationToken = default);
    
    [Post("/plans/{planId}/reminders")]
    Task AddPlanReminder(
        Guid planId,
        [Body] AddPlanReminderRequest request,
        CancellationToken cancellationToken = default);
}