using Planner.Plans.Application.Abstractions.Data;
using Planner.Plans.Domain.Plans.Entities;
using Planner.Plans.Domain.Plans.Errors;
using Planner.Plans.Domain.Plans.Repositories;
using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;

namespace Planner.Plans.Application.Plans.Commands.AddReminder;

internal sealed class AddPlanReminderHandler(
    IPlanRepository planRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddPlanReminderCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddPlanReminderCommand request, CancellationToken cancellationToken)
    {
        Plan? Plan = await planRepository.TryGetByIdAsync(request.PlanId, cancellationToken);

        if (Plan is null || Plan.UserId != request.UserId)
        {
            return Result.Failure<Guid>(PlanErrors.PlanNotFound(request.PlanId));
        }
        
        Plan.AddReminder(request.RemindAt);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(Plan.Id);
    }
}
