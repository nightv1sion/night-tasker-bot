using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Plans.Application.Plans.DeletePlan;

public sealed record DeletePlanCommand(int UserId, Guid PlanId) : ICommand<Result>;