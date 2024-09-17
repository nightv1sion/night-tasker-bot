using Planner.Common.Application.Messaging;
using Planner.Common.Domain.Core.Primitives.Result;
using Planner.Plans.Domain.Plans.Entities;
using Planner.Plans.Domain.Plans.Repositories;

namespace Planner.Plans.Application.Plans.CreatePlan;

internal sealed class CreatePlanHandler(
    IPlanRepository planRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreatePlanCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        var plan = Plan.Create(request.Name, request.Description, request.UserId);
        await planRepository.InsertAsync(plan, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(plan.Id);
    }
}
