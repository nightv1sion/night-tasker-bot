using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Plans.Application.Plans.Commands.DeletePlan;

public sealed record DeletePlanCommand(Guid PlanId) : ICommand<Result>;
