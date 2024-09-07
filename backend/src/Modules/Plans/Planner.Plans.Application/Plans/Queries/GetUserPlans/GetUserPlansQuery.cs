using Planner.Plans.Application.Plans.Models;
using Planner.Common.Application.Messaging;

namespace Planner.Plans.Application.Plans.Queries.GetUserPlans;

public sealed record GetUserPlansQuery(int UserId) : IQuery<IReadOnlyCollection<PlanDto>>;
