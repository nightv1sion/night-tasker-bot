using Planner.Common.Application.Messaging;

namespace Planner.Plans.Application.Plans.GetUserPlans;

public sealed record GetUserPlansQuery(long UserId) : IQuery<IReadOnlyCollection<PlanDto>>;
