using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Plans.Application.Plans.CreatePlan;

public sealed record CreatePlanCommand(
    string Name,
    string? Description,
    long UserId) : ICommand<Result<Guid>>;
