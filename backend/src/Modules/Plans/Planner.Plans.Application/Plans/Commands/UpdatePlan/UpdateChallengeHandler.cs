using Planner.Plans.Application.Abstractions.Data;
using Planner.Plans.Domain.Plans.Entities;
using Planner.Plans.Domain.Plans.Errors;
using Planner.Plans.Domain.Plans.Repositories;
using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Plans.Application.Plans.Commands.UpdatePlan;

internal sealed class UpdatePlanHandler(
    IPlanRepository planRepository,
    IUnitOfWork UnitOfWork) : ICommandHandler<UpdatePlanCommand, Result>
{
    public async Task<Result> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        Plan? plan = await planRepository.TryGetByIdAsync(request.PlanId, cancellationToken);

        if (plan is null)
        {
            return Result.Failure(PlanErrors.PlanNotFound(request.PlanId));
        }

        plan.UpdateName(request.Name);
        plan.UpdateDescription(request.Description);

        await UnitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
