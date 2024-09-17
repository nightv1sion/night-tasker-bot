using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;
using Planner.Plans.Domain.Plans.Entities;
using Planner.Plans.Domain.Plans.Errors;
using Planner.Plans.Domain.Plans.Repositories;

namespace Planner.Plans.Application.Plans.AddReminder;

internal sealed class AddPlanReminderHandler(
    IPlanRepository planRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddPlanReminderCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddPlanReminderCommand request, CancellationToken cancellationToken)
    {
        Plan? plan = await planRepository.TryGetByIdAsync(request.PlanId, cancellationToken);

        if (plan is null || plan.UserId != request.UserId)
        {
            return Result.Failure<Guid>(PlanErrors.PlanNotFound(request.PlanId));
        }
        
        plan.AddReminder(request.RemindAt);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(plan.Id);
    }
}
