using Planner.Plans.Application.Abstractions.Data;
using Planner.Plans.Domain.Plans.Entities;
using Planner.Plans.Domain.Plans.Errors;
using Planner.Plans.Domain.Plans.Repositories;
using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Plans.Application.Plans.Commands.DeletePlan;

internal sealed class DeletePlanHandler(
    IPlanRepository planRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeletePlanCommand, Result>
{
    public async Task<Result> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
    {
        Plan? Plan = await planRepository.TryGetByIdAsync(request.PlanId, cancellationToken);

        if (Plan is null)
        {
            return Result.Failure(PlanErrors.PlanNotFound(request.PlanId));
        }
        
        planRepository.Remove(Plan);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
