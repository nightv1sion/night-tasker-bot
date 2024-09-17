using Planner.Common.Application.Messaging;

namespace Planner.Plans.Application.Plans.GetUserPlans;

public sealed record GetUserPlansQuery(int UserId) : IQuery<IReadOnlyCollection<PlanDto>>;
