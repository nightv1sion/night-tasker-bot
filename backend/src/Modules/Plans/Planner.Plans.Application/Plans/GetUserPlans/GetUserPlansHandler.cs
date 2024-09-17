using Planner.Common.Application.Messaging;
using Planner.Plans.Domain.Plans.Entities;
using Planner.Plans.Domain.Plans.Repositories;

namespace Planner.Plans.Application.Plans.GetUserPlans;

internal sealed class GetUserPlansHandler(IPlanReadRepository planRepository)
    : IQueryHandler<GetUserPlansQuery, IReadOnlyCollection<PlanDto>>
{
    public async Task<IReadOnlyCollection<PlanDto>> Handle(
        GetUserPlansQuery request,
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Plan> plans = await planRepository.GetUserPlansAsync(request.UserId);
        return plans
            .Select(PlanDto.FromEntity)
            .ToArray();
    }
}
