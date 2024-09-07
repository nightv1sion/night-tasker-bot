using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Plans.Application.Plans.Commands.UpdatePlan;

public sealed record UpdatePlanCommand(
    Guid PlanId,
    string Name,
    string? Description) : ICommand<Result>;
